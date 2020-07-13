using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.Web.Infrastructure.Marketing.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Users
{
    public class ProspectCustomerViewDataFactory : IProspectCustomerViewDataFactory
    {
        private readonly IPhoneNumberFactory _phoneNumberFactory;
        public ProspectCustomerViewDataFactory()
            :this(new PhoneNumberFactory())
        {
            
        }

        public ProspectCustomerViewDataFactory(IPhoneNumberFactory phoneNumberFactory)
        {
            _phoneNumberFactory = phoneNumberFactory;
        }

        public List<ProspectCustomerViewData> CreateViewDataforHSC
            (
                List<OrderedPair<long, string>> prospectIdSourceCodePair,
                List<OrderedPair<long, string>> seminarIdSourceCodePair,
                List<OrderedPair<long, long>> callIdProspectIdPair,
                List<ProspectCustomerEntity> prospectsCustomerEntity,
                List<EventsEntity> eventsEntity,
                List<CallsEntity> callsEntity
            )
        {
            //TODO: Need to do it with proper repository and factory and service,extension.
            var hscProspectCustomerViewDataList = new List<ProspectCustomerViewData>();

            foreach (var prospectCustomerEntity in prospectsCustomerEntity)
            {
                if (prospectCustomerEntity != null)
                {
                    var prospectCustomerId = prospectCustomerEntity.ProspectCustomerId;
                    var sourceCode =
                        prospectIdSourceCodePair.Find(p => p.FirstValue == prospectCustomerId).SecondValue;
                    var seminarId = seminarIdSourceCodePair.Find(p => p.SecondValue == sourceCode).FirstValue;

                    var currentevent =
                        eventsEntity.Where(events => events.Seminars.Any(se => se.SeminarId == seminarId)).FirstOrDefault();

                    var seminar = currentevent.Seminars.Where(se => se.SeminarId == seminarId).FirstOrDefault();

                    var callIds =
                        callIdProspectIdPair.Where(p => p.SecondValue == prospectCustomerId).Select(p => p.FirstValue).
                            ToList();

                    var callDetails = callIds.Count > 0 ? callsEntity.Where(call => callIds.Contains(call.CallId)).ToList() : null;


                    var callDetailses = new List<CallDetails>();
                    if (callDetails != null && callDetails.Count > 0)
                    {
                        foreach (var callDetail in callDetails)
                        {
                            if (callDetail != null)
                            {
                                var call = new CallDetails
                                {
                                    CallId = callDetail.CallId,
                                    CallNotes = callDetail.CallCenterNotes.Count > 0
                                                    ? callDetail.CallCenterNotes.SingleOrDefault().Notes
                                                    : string.Empty,
                                    CallStatus = (CallStatus)callDetail.Status,
                                    CallDate = callDetail.DateCreated,
                                    CallStartTime = callDetail.TimeCreated.HasValue ? callDetail.TimeCreated : null,
                                    CallEndTime = callDetail.TimeEnd.HasValue ? callDetail.TimeEnd : null
                                };
                                callDetailses.Add(call);
                            }
                        }

                    }

                    var hscProspectCustomerViewData = new ProspectCustomerViewData
                    {
                        FirstName = prospectCustomerEntity.FirstName,
                        LastName = prospectCustomerEntity.LastName,
                        SourceCode = sourceCode,
                        AddressLine1 = prospectCustomerEntity.Address1,
                        AddressLine2 = prospectCustomerEntity.Address2,
                        City = prospectCustomerEntity.City,
                        State = prospectCustomerEntity.State,
                        Zip = prospectCustomerEntity.ZipCode,
                        DateCreated = prospectCustomerEntity.DateCreated,
                        ProspectStatus = (ProspectCustomerConversionStatus)prospectCustomerEntity.Status,
                        WellnessSeminar = seminar.Name,
                        EventId = currentevent.EventId,
                        EventDate = currentevent.EventDate,
                        ProspectCallDetails = callDetailses
                    };
                    hscProspectCustomerViewDataList.Add(hscProspectCustomerViewData);

                }
            }

            return hscProspectCustomerViewDataList;

        }

        public List<ProspectCustomerViewData> CreateViewDataForCallCenterRep(List<ProspectCustomerEntity> listProspectCustomer,
            List<OrderedPair<SeminarsEntity, long>> listSeminarSourceCodePair,
            List<OrderedPair<long, string>> listSourceCodeIdpair)
        {
            var listProspectCustomerViewData = new List<ProspectCustomerViewData>();

            string wellnessSeminar = "";
            string sourceCode = "";
            DateTime seminarDate = DateTime.Now;

            listProspectCustomer.ForEach(prospectCustomer => {
                
                sourceCode = "";

                if (prospectCustomer.SourceCodeId != null)
                {
                    var selectedSourceCodeIdPair = listSourceCodeIdpair.Find(sourceCodeIdpair => sourceCodeIdpair.FirstValue == prospectCustomer.SourceCodeId.Value);
                    if (selectedSourceCodeIdPair != null) sourceCode = selectedSourceCodeIdPair.SecondValue;

                    var selectedSeminarSourceCodePair = listSeminarSourceCodePair.Find(seminarSourceCode => seminarSourceCode.SecondValue == prospectCustomer.SourceCodeId.Value);
                    if (selectedSeminarSourceCodePair != null)
                    {
                        wellnessSeminar = selectedSeminarSourceCodePair.FirstValue.Name;
                        seminarDate = selectedSeminarSourceCodePair.FirstValue.SeminarDate;
                    }
                }
                                
                var prospectCustomerViewData = new ProspectCustomerViewData() { 
                    ProspectCustomerId = prospectCustomer.ProspectCustomerId,
                    FirstName = prospectCustomer.FirstName,
                    LastName = prospectCustomer.LastName,
                    AddressLine1 = prospectCustomer.Address1,
                    AddressLine2 = prospectCustomer.Address2,
                    City = prospectCustomer.City,
                    State = prospectCustomer.State,
                    Zip = prospectCustomer.ZipCode,
                    WellnessSeminar = wellnessSeminar,
                    SourceCode = sourceCode,
                    SeminarDate = seminarDate,
                    PhoneHome = _phoneNumberFactory.CreatePhoneNumber(prospectCustomer.CallbackNo,PhoneNumberType.Home)
                };
                listProspectCustomerViewData.Add(prospectCustomerViewData);
            
            });

            return listProspectCustomerViewData;
        }

    }
}