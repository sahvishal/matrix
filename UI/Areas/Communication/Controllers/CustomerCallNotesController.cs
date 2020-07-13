using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Communication.Controllers
{
    [RoleBasedAuthorize]
    public class CustomerCallNotesController : Controller
    {
        //
        // GET: /Communication/CustomerCallNotes/

        private readonly ICustomerCallNotesRepository _customerCallNotesRepository;
        private readonly IUniqueItemRepository<CustomerCallNotes> _customerNotesRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IRefundRequestRepository _refundRequestRepository;
        private readonly ICustomerNotesService _customerNotesService;
        private readonly IEventAppointmentCancellationLogRepository _eventAppointmentCancellationLogRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public CustomerCallNotesController(ICustomerCallNotesRepository customerCallNotesRepository, IUniqueItemRepository<CustomerCallNotes> itemRepository, IOrderRepository orderRepository, IRefundRequestRepository refundRequestRepository,
            ICustomerNotesService customerNotesService, IEventAppointmentCancellationLogRepository eventAppointmentCancellationLogRepository, IEventCustomerRepository eventCustomerRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _customerCallNotesRepository = customerCallNotesRepository;
            _customerNotesRepository = itemRepository;
            _orderRepository = orderRepository;
            _refundRequestRepository = refundRequestRepository;
            _customerNotesService = customerNotesService;
            _eventAppointmentCancellationLogRepository = eventAppointmentCancellationLogRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public ActionResult CustomerCallNotes(long customerId, long eventId = 0)
        {
            var customerCallNotes = _customerCallNotesRepository.GetCustomerNotes(customerId, true);
            customerCallNotes = customerCallNotes.Where(m => (m.NotesType == CustomerRegistrationNotesType.CancellationNote || m.NotesType == CustomerRegistrationNotesType.LeftWithoutScreeningNotes) || !string.IsNullOrWhiteSpace(m.Notes));

            var cancelledCustomerNotes = customerCallNotes.Where(m => m.NotesType == CustomerRegistrationNotesType.CancellationNote);
            var eventCustomers = _eventCustomerRepository.GetbyCustomerId(customerId);

            var cancellationLogByEventCustomers = _eventAppointmentCancellationLogRepository.GetByEventCustomerIds(eventCustomers.Select(x => x.Id));

            if (cancelledCustomerNotes.Any())
            {
                foreach (var customerCallNote in cancelledCustomerNotes)
                {
                    var cancellationNote = cancellationLogByEventCustomers.FirstOrDefault(x => x.NoteId == customerCallNote.Id);
                    customerCallNote.ReasonName = cancellationNote != null ? ((CancelAppointmentReason)cancellationNote.ReasonId).GetDescription() : "N/A";
                    //var createdBy = customerCallNote.DataRecorderMetaData != null && customerCallNote.DataRecorderMetaData.DataRecorderCreator != null ?
                    //    orgRoleUsers.FirstOrDefault(x => x.FirstValue == customerCallNote.DataRecorderMetaData.DataRecorderCreator.Id) : null;
                    //customerCallNote.CreatedBy = createdBy != null ? createdBy.SecondValue : string.Empty;
                }
            }

            if (eventId > 0)
                customerCallNotes = customerCallNotes.Where(ccn => !ccn.EventId.HasValue || (ccn.EventId.HasValue && ccn.EventId.Value == eventId)).ToArray();

            var orders = _orderRepository.GetAllOrdersForCustomer(customerId);

            if (orders != null && orders.Any())
            {
                var refundRequests = _refundRequestRepository.GeRefundRequestByOrderIds(orders.Select(oec => oec.Id).ToArray(), RefundRequestType.CustomerCancellation);

                if (refundRequests != null && refundRequests.Any())
                {
                    var refundRequestNotes = new List<CustomerCallNotes>();
                    foreach (var refundRequest in refundRequests)
                    {
                        var cancellationLog = cancellationLogByEventCustomers.FirstOrDefault(x => x.RefundRequestId.HasValue && x.RefundRequestId.Value == refundRequest.Id);

                        refundRequestNotes.Add(new CustomerCallNotes
                        {
                            CustomerId = customerId,
                            Notes = refundRequest.Reason,
                            EventId = cancellationLog != null ? cancellationLog.EventId : (long?)null,
                            ReasonName = cancellationLog != null ? ((CancelAppointmentReason)cancellationLog.ReasonId).GetDescription() : string.Empty,
                            NotesType = CustomerRegistrationNotesType.CancellationNote,
                            DataRecorderMetaData = new DataRecorderMetaData(refundRequest.RequestedByOrgRoleUserId, refundRequest.RequestedOn, null),

                        });
                    }

                    customerCallNotes = customerCallNotes.Concat(refundRequestNotes);
                }
            }

            cancellationLogByEventCustomers = cancellationLogByEventCustomers.Where(x => x.NoteId == null && x.RefundRequestId == null);

            if (cancellationLogByEventCustomers != null && cancellationLogByEventCustomers.Any())
            {
                var cancellationNotesLog = new List<CustomerCallNotes>();

                foreach (var cancellationLog in cancellationLogByEventCustomers)
                {
                    cancellationNotesLog.Add(new CustomerCallNotes
                    {
                        CustomerId = customerId,
                        EventId = cancellationLog.EventId,
                        Notes = string.Empty,
                        NotesType = CustomerRegistrationNotesType.CancellationNote,
                        ReasonName = ((CancelAppointmentReason)cancellationLog.ReasonId).GetDescription(),
                        DataRecorderMetaData = new DataRecorderMetaData(cancellationLog.CreatedBy, cancellationLog.DateCreated, null),
                    });
                }

                customerCallNotes = customerCallNotes.Concat(cancellationNotesLog);
            }

            if (!customerCallNotes.IsNullOrEmpty())
                customerCallNotes = customerCallNotes.OrderByDescending(x => x.DataRecorderMetaData.DateCreated);

            var patientLeftNotes = customerCallNotes.Where(x => x.NotesType == CustomerRegistrationNotesType.LeftWithoutScreeningNotes);

            if (!patientLeftNotes.IsNullOrEmpty())
            {
                foreach (var patientLeftNote in patientLeftNotes)
                {
                    patientLeftNote.ReasonName = patientLeftNote.ReasonId.HasValue ? ((LeftWithoutScreeningReason)patientLeftNote.ReasonId.Value).GetDescription() : "";
                    //var createdBy = patientLeftNote.DataRecorderMetaData != null && patientLeftNote.DataRecorderMetaData.DataRecorderCreator != null ?
                    //    orgRoleUsers.FirstOrDefault(x => x.FirstValue == patientLeftNote.DataRecorderMetaData.DataRecorderCreator.Id) : null;
                    //patientLeftNote.CreatedBy = createdBy != null ? createdBy.SecondValue : string.Empty;
                }
            }

            var orgRoleUserIds = customerCallNotes.Where(x => x.DataRecorderMetaData != null && x.DataRecorderMetaData.DataRecorderCreator != null).Select(x => x.DataRecorderMetaData.DataRecorderCreator.Id).ToArray();
            var orgRoleUsers = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            foreach (var customerCallNote in customerCallNotes)
            {
                var createdBy = customerCallNote.DataRecorderMetaData != null && customerCallNote.DataRecorderMetaData.DataRecorderCreator != null ?
                        orgRoleUsers.FirstOrDefault(x => x.FirstValue == customerCallNote.DataRecorderMetaData.DataRecorderCreator.Id) : null;
                customerCallNote.CreatedBy = createdBy != null ? createdBy.SecondValue : string.Empty;
            }

            return View(customerCallNotes);
        }

        public bool DeleteCustomerNotes(long notesId)
        {
            return _customerCallNotesRepository.Delete(notesId);
        }

        public JsonResult GetCustomerNotes(long notesId)
        {
            return Json(_customerNotesRepository.GetById(notesId), JsonRequestBehavior.AllowGet);
        }

        public bool UpdateCustomerNotes(long notesId, string notes)
        {
            return _customerCallNotesRepository.UpdateNotes(notesId, notes);
        }

        public bool AddCustomerNotes(long customerId, long eventId, string notes)
        {
            if (customerId <= 0)
                return false;

            var currentUser = IoC.Resolve<ISessionContext>().UserSession;

            var notesType = eventId > 0 ? CustomerRegistrationNotesType.AppointmentNote : CustomerRegistrationNotesType.CustomerNote;
            var customerRegistrationNotes = _customerNotesService.SaveCustomerNotes(customerId, eventId, notes, currentUser.CurrentOrganizationRole.OrganizationRoleUserId, notesType);
            return customerRegistrationNotes.Id > 0 ? true : false;
        }

    }
}
