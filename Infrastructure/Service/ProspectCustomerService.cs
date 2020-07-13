using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class ProspectCustomerService : IProspectCustomerService
    {
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ISettings _settings;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IRefundRequestRepository _refundRequestRepository;
        private readonly ICustomerCallNotesRepository _customerCallNotesRepository;
        private readonly INotesViewModelFactory _notesViewModelFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICorporateTagRepository _corporateTagRepository;

        public ProspectCustomerService(IProspectCustomerRepository prospectCustomerRepository, ISourceCodeRepository sourceCodeRepository, ISettings settings, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IEventCustomerRepository eventCustomerRepository, IOrderRepository orderRepository, IRefundRequestRepository refundRequestRepository, IStateRepository stateRepository,
            ICustomerCallNotesRepository customerCallNotesRepository, INotesViewModelFactory notesViewModelFactory, ICustomerRepository customerRepository,
            ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository, ICorporateAccountRepository corporateAccountRepository, ICorporateTagRepository corporateTagRepository)
        {
            _prospectCustomerRepository = prospectCustomerRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _settings = settings;
            _eventCustomerRepository = eventCustomerRepository;
            _refundRequestRepository = refundRequestRepository;
            _orderRepository = orderRepository;
            _stateRepository = stateRepository;
            _customerCallNotesRepository = customerCallNotesRepository;
            _notesViewModelFactory = notesViewModelFactory;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _corporateTagRepository = corporateTagRepository;
        }

        public ListModelBase<ProspectCustomerBasicInfoModel, ProspectCustomerListModelFilter> GetAbandonedCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var modelFilter = filter as ProspectCustomerListModelFilter;
            if (modelFilter.AgentOrganizationId > 0 && !modelFilter.FromDate.HasValue && !modelFilter.ToDate.HasValue)
            {
                modelFilter.FromDate = DateTime.Today.AddDays(-90);
                modelFilter.DateType = (int) ProspectCustomerDateTypeFilter.CreatedDate;
            }

            var prospectCustomers = _prospectCustomerRepository.GetAbandonedProspectCustomer(pageNumber, pageSize, modelFilter, out totalRecords);
            var model = new ProspectCustomerListModel();
            if (prospectCustomers != null && prospectCustomers.Any())
            {
                var prospectCustomerNotes = _customerCallNotesRepository.GetProspectCustomerNotes(prospectCustomers.Select(pc => pc.Id).ToArray());

                var orgRoleUserIds = prospectCustomers.Where(pc => pc.ContactedBy.HasValue).Select(pc => pc.ContactedBy.Value).ToList();

                if (prospectCustomerNotes != null && prospectCustomerNotes.Any())
                    orgRoleUserIds.AddRange(prospectCustomerNotes.Select(pcn => pcn.DataRecorderMetaData.DataRecorderCreator.Id));

                orgRoleUserIds = orgRoleUserIds.Distinct().ToList();
                var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());

                var customerIds = prospectCustomers.Where(x => x.CustomerId.HasValue && x.CustomerId.Value > 0).Select(x => x.CustomerId.Value);
                var customers = new List<Customer>();

                if (!customerIds.IsNullOrEmpty())
                {
                    customers = _customerRepository.GetCustomers(customerIds.ToArray());
                }

                var customTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

                var corportateAccounts = new List<CorporateAccount>();

                if (!customers.IsNullOrEmpty())
                {
                    var cutomerTags = customers.Where(x => !string.IsNullOrEmpty(x.Tag) && x.Tag.Trim().Length > 1).Select(x => x.Tag);

                    if (customTags.Any())
                        corportateAccounts.AddRange(_corporateAccountRepository.GetByTags(cutomerTags.ToArray()));

                }

                var pcBasicmodels = new ProspectCustomerBasicInfoModel[prospectCustomers.Count()];
                int index = 0;
                foreach (var prospectCustomer in prospectCustomers)
                {
                    SourceCode sourceCode = null;
                    if (prospectCustomer.SourceCodeId.HasValue)
                        sourceCode = _sourceCodeRepository.GetSourceCodeById(prospectCustomer.SourceCodeId.Value);

                    pcBasicmodels[index] = Mapper.Map<ProspectCustomer, ProspectCustomerBasicInfoModel>(prospectCustomer);

                    if (prospectCustomer.CustomerId.HasValue)
                    {
                        if (customers.Any())
                        {
                            var customer = customers.First(x => x.CustomerId == prospectCustomer.CustomerId);

                            pcBasicmodels[index].CorporateTag = string.IsNullOrEmpty(customer.Tag) ? "" : customer.Tag;
                            pcBasicmodels[index].MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "" : customer.InsuranceId;


                            if (corportateAccounts.Any() && !string.IsNullOrEmpty(customer.Tag))
                            {
                                var corportateAccount = corportateAccounts.First(x => x.Tag == customer.Tag);
                                pcBasicmodels[index].CorporateSponsor = corportateAccount.Name;
                            }
                        }

                        var corporateCustomTags = string.Empty;
                        if (customTags != null && customTags.Any())
                        {
                            var customerCustomTags =
                                customTags.Where(ct => ct.CustomerId == prospectCustomer.CustomerId).Select(ct => ct.Tag).ToArray();

                            if (customerCustomTags.Any())
                            {
                                corporateCustomTags = string.Join(",", customerCustomTags);
                            }
                        }
                        
                           pcBasicmodels[index].CustomTags = corporateCustomTags;
                           if (!string.IsNullOrEmpty(pcBasicmodels[index].CorporateTag) && string.IsNullOrEmpty(pcBasicmodels[index].CustomTags))
                               pcBasicmodels[index].CustomTags = "None";                        
                    }

                    var notesVieModel = new List<NotesViewModel>();

                    var prospectNotes = _notesViewModelFactory.GetProspectCustomerNotes(prospectCustomer.Id, prospectCustomerNotes, idNamePairs);

                    if (prospectNotes != null)
                        notesVieModel.AddRange(prospectNotes);

                    if (prospectCustomer.Tag == ProspectCustomerTag.Cancellation && prospectCustomer.CustomerId.HasValue && _settings.IsRefundQueueEnabled)
                    {
                        var eventCustomers = _eventCustomerRepository.GetbyCustomerId(prospectCustomer.CustomerId.Value);
                        eventCustomers = eventCustomers.Where(ec => !ec.AppointmentId.HasValue);

                        if (eventCustomers.Any())
                        {
                            var eventCustomerId = eventCustomers.Select(ec => ec.Id).Max();
                            if (eventCustomerId > 0)
                            {
                                var orderId = _orderRepository.GetOrderIdByEventCustomerId(eventCustomerId);
                                var refundRequests = _refundRequestRepository.GetbyOrderId(orderId, true);
                                if (refundRequests != null && refundRequests.Any() && refundRequests.Count(rr => rr.RefundRequestType == RefundRequestType.CustomerCancellation) > 0)
                                {
                                    var refundRequest = refundRequests.LastOrDefault(rr => rr.RefundRequestType == RefundRequestType.CustomerCancellation && rr.RefundRequestResult != null
                                                                                           && (rr.RefundRequestResult.RequestResultType == RequestResultType.IssueRefund || rr.RefundRequestResult.RequestResultType == RequestResultType.IssueGiftCertificate));

                                    if (refundRequest != null)
                                    {
                                        notesVieModel.Add(new NotesViewModel() { Note = refundRequest.RefundRequestResult.Notes });
                                    }
                                }
                            }
                        }
                    }

                    pcBasicmodels[index].Notes = notesVieModel;

                    if (sourceCode != null)
                        pcBasicmodels[index].SourceCode = sourceCode.CouponCode;

                    if (prospectCustomer.ContactedBy.HasValue)
                    {
                        pcBasicmodels[index].ContactedBy =
                            idNamePairs.Where(nip => nip.FirstValue == prospectCustomer.ContactedBy.Value).Select(nip => nip.SecondValue).SingleOrDefault();
                    }
                    index++;
                }
                model.Collection = pcBasicmodels;
            }
            return model;
        }

        public SchedulingCustomerEditModel GetforProspectCustomerId(long prospectCustomerId)
        {
            if (prospectCustomerId < 1) return new SchedulingCustomerEditModel();

            var prospectCustomer = _prospectCustomerRepository.GetProspectCustomer(prospectCustomerId);
            if (prospectCustomer == null) return new SchedulingCustomerEditModel();

            if (prospectCustomer.Address != null && !string.IsNullOrEmpty(prospectCustomer.Address.State))
            {
                var state = _stateRepository.GetState(prospectCustomer.Address.State);
                if (state != null)
                {
                    prospectCustomer.Address.StateId = state.Id;
                }
            }

            return new SchedulingCustomerEditModel
                {
                    FullName = new Name(prospectCustomer.FirstName, string.Empty, prospectCustomer.LastName),
                    ShippingAddress = prospectCustomer.Address == null ? new AddressEditModel() : Mapper.Map<Address, AddressEditModel>(prospectCustomer.Address),
                    HomeNumber = PhoneNumber.ToNumber(prospectCustomer.CallBackPhoneNumber.ToString()),
                    Email = prospectCustomer.Email != null ? prospectCustomer.Email.ToString() : string.Empty,
                    MarketingSource = prospectCustomer.MarketingSource,
                    Gender = (int)prospectCustomer.Gender,
                    DateofBirth = prospectCustomer.BirthDate

                };
        }

        //private IEnumerable<NotesViewModel> GetProspectCustomerNotes(long prospectCustomerId, IEnumerable<CustomerCallNotes> prospectCustomerNotes, IEnumerable<OrderedPair<long, string>> idNamePairs)
        //{
        //    var notes = prospectCustomerNotes.Where(pcn => pcn.ProspectCustomerId == prospectCustomerId).Select(pcn => pcn).ToArray();

        //    if (notes.Count() > 0)
        //    {
        //        return (from note in notes
        //                let idNamePair = idNamePairs.Where(inp => inp.FirstValue == note.DataRecorderMetaData.DataRecorderCreator.Id).Single()
        //                select new NotesViewModel
        //                           {
        //                               Note = note.Notes,
        //                               CreatedByUser = idNamePair.SecondValue,
        //                               EnteredOn = note.DataRecorderMetaData.DateCreated
        //                           }).ToArray();
        //    }
        //    return null;
        //}

    }
}