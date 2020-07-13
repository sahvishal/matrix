using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Geo.Enum;

namespace Falcon.App.UI.HtmlHelpers
{
    public class DropDownHelper
    {
        public static IEnumerable<SelectListItem> States(long selected = -1)
        {
            IEnumerable<SelectListItem> states = new[] { new SelectListItem { Text = "Select State", Value = "-1" } }.Concat(IoC.Resolve<IStateRepository>().GetAllStates().Select(
                state => new SelectListItem { Text = state.Name, Value = state.Id.ToString(), Selected = selected == state.Id }));

            return states;
        }

        public static IEnumerable<SelectListItem> Countries(long selected = -1)
        {
            IEnumerable<SelectListItem> countries = IoC.Resolve<ICountryRepository>().GetAll().Select(
                country => new SelectListItem { Text = country.Name, Value = country.Id.ToString(), Selected = selected == country.Id });

            return countries;
        }


        public static IEnumerable<SelectListItem> FranchiseeOrganizations(long selected = -1)
        {
            IEnumerable<SelectListItem> organizations = new[] { new SelectListItem { Text = "-- Select Organization --", Value = "-1" } }.Concat(IoC.Resolve<IOrganizationRepository>().GetOrganizationIdNamePairs(OrganizationType.Franchisee).Select(
                orderedPair => new SelectListItem { Text = orderedPair.FirstValue, Value = orderedPair.SecondValue.ToString(), Selected = selected == orderedPair.SecondValue }));

            return organizations;
        }

        public static IEnumerable<SelectListItem> EventRoles(long selected = -1)
        {
            IEnumerable<SelectListItem> roles = new[] { new SelectListItem { Text = "-- Select Role --", Value = "-1" } }.Concat(IoC.Resolve<IEventRoleRepository>().GetAllActiveRoles().Select(
                ser => new SelectListItem { Text = ser.Name, Value = ser.Id.ToString(), Selected = selected == ser.Id }));

            return roles;
        }

        public static IEnumerable<SelectListItem> Organizations(long selected = -1)
        {

            IEnumerable<SelectListItem> organizations = new[] { new SelectListItem { Text = "-- Select Organization --", Value = "-1" } }.Concat(IoC.Resolve<IOrganizationRepository>().GetAllOrganizationIdNamePairs().Select(
                orderedPair => new SelectListItem { Text = orderedPair.FirstValue, Value = orderedPair.SecondValue.ToString(), Selected = selected == orderedPair.SecondValue }));

            return organizations;
        }

        public static IEnumerable<SelectListItem> OrganizationTypes(long selected = -1)
        {

            IEnumerable<SelectListItem> organizationTypes = new[] { new SelectListItem { Text = "-- Select OrganizationTypes --", Value = "-1" } }.Concat(IoC.Resolve<IOrganizationRepository>().GetOrganizationTypes().Select(
                orderedPair => new SelectListItem { Text = orderedPair.FirstValue, Value = orderedPair.SecondValue.ToString(), Selected = selected == orderedPair.SecondValue }));

            return organizationTypes;
        }

        public static IEnumerable<SelectListItem> UnUsedVans(long selected = -1)
        {

            IEnumerable<SelectListItem> unUsedVans = new[] { new SelectListItem { Text = "-- Select Vehicle --", Value = "-1" } }.Concat(IoC.Resolve<IVanRepository>().GetAllVans().Select(
                van => new SelectListItem { Text = van.Name, Value = van.Id.ToString(), Selected = selected == van.Id }));

            return unUsedVans;
        }

        public static IEnumerable<SelectListItem> Pods(long selected = -1)
        {

            IEnumerable<SelectListItem> unUsedVans = new[] { new SelectListItem { Text = "-- All Pods --", Value = "-1" } }.Concat(IoC.Resolve<IPodRepository>().GetAllPods().Select(
                pod => new SelectListItem { Text = pod.Name, Value = pod.Id.ToString(), Selected = selected == pod.Id }));

            //IEnumerable<SelectListItem> unUsedVans =IoC.Resolve<IPodRepository>().GetAllPods().Select(pod => new SelectListItem { Text = pod.Name, Value = pod.Id.ToString(), Selected = selected == pod.Id });

            return unUsedVans;
        }

        public static IEnumerable<SelectListItem> TechnicianStaff(long selected = -1)
        {
            IEnumerable<SelectListItem> technicianStaff = new[] { new SelectListItem { Text = "-- Select Staff Member --", Value = "-1" } }.Concat(IoC.Resolve<IUserRepository<User>>().GetUsersWithDefaultRole(Roles.Technician).Select(
                orderedPair => new SelectListItem { Text = orderedPair.SecondValue, Value = orderedPair.FirstValue.ToString(), Selected = selected == orderedPair.FirstValue }));

            return technicianStaff;
        }

        public static IEnumerable<SelectListItem> UsersHavingTechnicianRole(bool activeUsersOnly = false, long selected = -1)
        {
            var roleIds = new[] { (long)Roles.Technician, (long)Roles.NursePractitioner };
            IEnumerable<SelectListItem> technicianStaff = new[] { new SelectListItem { Text = "-- Select Staff Member --", Value = "-1" } }.Concat(IoC.Resolve<IUserRepository<User>>().GetUsersByRoles(roleIds, activeUsersOnly).Select(
                orderedPair => new SelectListItem { Text = orderedPair.SecondValue, Value = orderedPair.FirstValue.ToString(), Selected = selected == orderedPair.FirstValue }));

            return technicianStaff;
        }

        public static IEnumerable<SelectListItem> TechnicianStaffforEvent(long eventId, long selected = -1)
        {
            if (eventId > 0)
            {
                var technicianIds = IoC.Resolve<IEventStaffAssignmentRepository>().GetTechblockedforSomeotherEventonthesameDayofGivenEvent(eventId);

                var roleIds = new[] { (long)Roles.Technician, (long)Roles.NursePractitioner };
                IEnumerable<SelectListItem> technicianStaff = new[] { new SelectListItem { Text = "-- Select Staff Member --", Value = "-1" } }.Concat(IoC.Resolve<IUserRepository<User>>().GetUsersByRoles(roleIds, true).Select(
                    orderedPair => new SelectListItem { Text = technicianIds.Contains(orderedPair.FirstValue) ? orderedPair.SecondValue + " (Already Assinged to a event on the same day)" : orderedPair.SecondValue, Value = orderedPair.FirstValue.ToString(), Selected = selected == orderedPair.FirstValue }));

                return technicianStaff;
            }

            return new[] { new SelectListItem { Text = "-- Select Staff Member --", Value = "-1" } };
        }

        public static IEnumerable<SelectListItem> AssignedTechnicianStaff(long eventId, long selected = -1)
        {
            var eventStaffAssignementRepository = IoC.Resolve<IEventStaffAssignmentRepository>();
            var eventStaffCollection = eventStaffAssignementRepository.GetForEvent(eventId);

            var orgRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            var nameIdPairs = orgRoleUserRepository.GetNameIdPairofUsers(
                eventStaffCollection.Select(s => (s.ActualStaffOrgRoleUserId ?? s.ScheduledStaffOrgRoleUserId)).ToArray());

            IEnumerable<SelectListItem> technicianStaff =
                new[] { new SelectListItem { Text = "-- Select Staff Member --", Value = "-1" } }.Concat(nameIdPairs.Select(
                    orderedPair =>
                    new SelectListItem
                        {
                            Text = orderedPair.SecondValue,
                            Value = orderedPair.FirstValue.ToString(),
                            Selected = selected == orderedPair.FirstValue
                        }));

            return technicianStaff;
        }

        public static IEnumerable<SelectListItem> PodTerritoies(long selected = -1)
        {

            IEnumerable<SelectListItem> allTerritories = new[] { new SelectListItem { Text = "-- Select Territories --", Value = "-1" } }.Concat(IoC.Resolve<ITerritoryRepository>().GetAllTerritoriesIdNamePair(TerritoryType.Pod).Select(
                orderedPair => new SelectListItem { Text = orderedPair.SecondValue, Value = orderedPair.FirstValue.ToString(), Selected = selected == orderedPair.FirstValue }));

            return allTerritories;
        }

        public static IEnumerable<SelectListItem> Packages(long selected = -1)
        {
            IEnumerable<SelectListItem> allPackages = new[] { new SelectListItem { Text = "-- Select Packages --", Value = "-1" } }.
                Concat(IoC.Resolve<IPackageRepository>().GetAll().OrderBy(m => m.Name).
                        Select(orderedPair => new SelectListItem { Text = orderedPair.Name, Value = orderedPair.Id.ToString(), Selected = selected == orderedPair.Id }));

            return allPackages;
        }

        public static IEnumerable<SelectListItem> PackageTypes(long selected = -1)
        {
            IEnumerable<SelectListItem> allPackageTypes = new[] { new SelectListItem { Text = "-- Type --", Value = "-1" } }.
                Concat(PackageType.Retail.GetNameValuePairs().Select(nameIdPair => new SelectListItem { Text = nameIdPair.SecondValue, Value = nameIdPair.FirstValue.ToString(), Selected = selected == nameIdPair.FirstValue }));

            return allPackageTypes;
        }

        public static IEnumerable<SelectListItem> CorporatePackages(long selected = -1)
        {
            IEnumerable<SelectListItem> allPackages = new[] { new SelectListItem { Text = "-- Select Packages --", Value = "-1" } }.
                Concat(IoC.Resolve<IPackageRepository>().GetCorporatePackages().OrderBy(m => m.Name).
                        Select(orderedPair => new SelectListItem { Text = orderedPair.Name, Value = orderedPair.Id.ToString(), Selected = selected == orderedPair.Id }));

            return allPackages;
        }

        public static IEnumerable<SelectListItem> AllRoles(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- Select Role --", Value = "-1" } }.Concat(IoC.Resolve<IRoleRepository>().GetAll()
                                                    .Select(role => new SelectListItem { Text = role.DisplayName, Value = role.Id.ToString(), Selected = selected == role.Id }));
        }

        public static IEnumerable<SelectListItem> AllSystemRoles(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- Select Role --", Value = "-1" } }.Concat(IoC.Resolve<IRoleRepository>().GetAllSystemRoles()
                                                    .Select(role => new SelectListItem { Text = role.DisplayName, Value = role.Id.ToString(), Selected = selected == role.Id }));
        }

        public static IEnumerable<SelectListItem> RefundTypes(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(RefundRequestType.CustomerCancellation.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString(), Selected = selected == dt.FirstValue }));
        }

        public static IEnumerable<SelectListItem> ResultArchiveStatus(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(ResultArchiveUploadStatus.InvalidFileFormat.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString(), Selected = selected == dt.FirstValue }));
        }

        public static IEnumerable<SelectListItem> RequestStatusList(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(RequestStatus.Pending.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString() }));
        }

        public static IEnumerable<SelectListItem> CardTypes(long selected = -1)
        {
            var chargeCardRepository = IoC.Resolve<IChargeCardRepository>();

            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(chargeCardRepository.GetAllChargeCardType().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString() }));
        }

        public static IEnumerable<SelectListItem> PaymentTypes(IEnumerable<OrderedPair<long, string>> types)
        {
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(types.Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString() }));
        }

        public static IEnumerable<SelectListItem> CountryPhoneCodes(long selected = -1)
        {
            return new[]{
                          new SelectListItem {Value = "1", Text = "+1"}                          
                      };
        }

        public static IEnumerable<SelectListItem> UpSellByRole(long selected = -1)
        {
            var roles = IoC.Resolve<IRoleRepository>().GetAll();
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(roles.Where(
                r =>
                r.Id == (long)Roles.CallCenterManager || r.Id == (long)Roles.CallCenterRep ||
                r.Id == (long)Roles.Technician).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = r.DisplayName }));

        }

        public static IEnumerable<SelectListItem> DateRangeTypes(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(DateRangeType.Today.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString(), Selected = (dt.FirstValue == selected) ? true : false }));
        }

        public static IEnumerable<SelectListItem> SortOrderByRanges(long selected = -1)
        {
            return new[] { new SelectListItem { Text = SortOrderBy.Distance.GetDescription(), Value = ((int)SortOrderBy.Distance).ToString(), Selected = selected == (int)SortOrderBy.Distance }, 
                new SelectListItem { Text = SortOrderBy.EventDate.GetDescription(), Value = ((int)SortOrderBy.EventDate).ToString(), Selected = selected == (int)SortOrderBy.EventDate } };
        }

        public static IEnumerable<SelectListItem> RadiusRanges(long selected = -1)
        {
            var radius = ZipRadius.FiveMiles.GetNameValuePairs().OrderBy(x => x.FirstValue);
            return new[]
            {
                new SelectListItem
                {
                    Text = "Exact Search",
                    Value = "0"
                }
            }.Concat(radius
             .Select(x => new SelectListItem
             {
                 Text = x.SecondValue,
                 Value = x.FirstValue.ToString(),
                 Selected = (x.FirstValue == selected) ? true : false
             }));
        }

        public static IEnumerable<SelectListItem> Months(long selected = -1)
        {
            return new[]{
                          new SelectListItem {Value = "1", Text = "January"} ,
                         new SelectListItem {Value = "2", Text = "February"} ,
                         new SelectListItem {Value = "3", Text = "March"} ,
                         new SelectListItem {Value = "4", Text = "April"} ,
                         new SelectListItem {Value = "5", Text = "May"} ,
                         new SelectListItem {Value = "6", Text = "June"} ,
                         new SelectListItem {Value = "7", Text = "July"} ,
                         new SelectListItem {Value = "8", Text = "August"} ,
                         new SelectListItem {Value = "9", Text = "September"} ,
                         new SelectListItem {Value = "10", Text = "October"} ,
                         new SelectListItem {Value = "11", Text = "November"} ,
                         new SelectListItem {Value = "12", Text = "December"} ,
                      };
        }

        public static IEnumerable<SelectListItem> MedicalVendorTypes(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    MedicalVendorType.Individual.GetNameValuePairs().Select(
                        mvt =>
                        new SelectListItem
                            {
                                Text = mvt.SecondValue,
                                Value = mvt.FirstValue.ToString(),
                                Selected = (mvt.FirstValue == selected) ? true : false
                            }));
        }

        public static IEnumerable<SelectListItem> Contracts(long selected = -1)
        {
            var medicalVendorRepository = IoC.Resolve<IMedicalVendorRepository>();

            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    medicalVendorRepository.GetAllContracts().Select(
                        dt =>
                        new SelectListItem
                            {
                                Text = dt.SecondValue,
                                Value = dt.FirstValue.ToString(),
                                Selected = (dt.FirstValue == selected) ? true : false
                            }));
        }

        public static IEnumerable<SelectListItem> PhysicianSpecialization(long selected = -1)
        {
            var physicianRepository = IoC.Resolve<IPhysicianRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           physicianRepository.GetPhysicianSpecilizationIdNamePairs().Select(dt => new SelectListItem
                                                                                                       {
                                                                                                           Text = dt.SecondValue,
                                                                                                           Value = dt.FirstValue.ToString(),
                                                                                                           Selected = (dt.FirstValue == selected) ? true : false
                                                                                                       }));
        }

        public static IEnumerable<SelectListItem> PhysiciansForEvent(long eventId, long selected = -1)
        {
            if (eventId > 0)
            {
                var physicianRepository = IoC.Resolve<IPhysicianRepository>();
                return new[]
                           {
                               new SelectListItem
                                   {
                                       Text = "--Select--",
                                       Value = "-1"
                                   }
                           }.Concat(
                               physicianRepository.GetAvailablePhysiciansIdNamePairForEvent(eventId).Select(
                                   dt => new SelectListItem
                                             {
                                                 Text = dt.SecondValue,
                                                 Value = dt.FirstValue.ToString(),
                                                 Selected = (dt.FirstValue == selected) ? true : false
                                             }));
            }
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } };
        }

        public static IEnumerable<SelectListItem> PhysiciansForCustomer(long eventCustomerId, long selected = -1)
        {
            if (eventCustomerId > 0)
            {
                var physicianRepository = IoC.Resolve<IPhysicianRepository>();
                return new[]
                           {
                               new SelectListItem
                                   {
                                       Text = "--Select--",
                                       Value = "-1"
                                   }
                           }.Concat(
                               physicianRepository.GetAvailablePhysiciansIdNamePairForCustomer(eventCustomerId).Select(
                                   dt => new SelectListItem
                                   {
                                       Text = dt.SecondValue,
                                       Value = dt.FirstValue.ToString(),
                                       Selected = (dt.FirstValue == selected) ? true : false
                                   }));
            }
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } };
        }

        public static IEnumerable<SelectListItem> GetEventResultStatusFilter(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    EventResultStatusFilter.MissingResults.GetNameValuePairs().OrderBy(ers => ers.SecondValue).Select(
                        ers =>
                        new SelectListItem
                            {
                                Text = ers.SecondValue,
                                Value = ers.FirstValue.ToString(),
                                Selected = (ers.FirstValue == selected) ? true : false
                            }));
        }

        public static IEnumerable<SelectListItem> GetHospitalPartnerCustomerStatus(long selected = -1)
        {
            var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();

            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                               hospitalPartnerRepository.GetHospitalPartnerCustomerStatus().Select(
                                   dt => new SelectListItem
                                   {
                                       Text = dt.SecondValue,
                                       Value = dt.FirstValue.ToString(),
                                       Selected = (dt.FirstValue == selected) ? true : false
                                   }));
        }

        public static IEnumerable<SelectListItem> GetHospitalPartnerCustomerOutcome(long selected = -1)
        {
            var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();

            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                               hospitalPartnerRepository.GetHospitalPartnerCustomerOutcome().Select(
                                   dt => new SelectListItem
                                   {
                                       Text = dt.SecondValue,
                                       Value = dt.FirstValue.ToString(),
                                       Selected = (dt.FirstValue == selected) ? true : false
                                   }));
        }

        public static IEnumerable<SelectListItem> GetPhysicianReviewDateTypeFilter(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    PhysicianReviewDateTypeFilter.EventDate.GetNameValuePairs().Select(
                        ers =>
                        new SelectListItem
                            {
                                Text = ers.SecondValue,
                                Value = ers.FirstValue.ToString(),
                                Selected = (ers.FirstValue == selected) ? true : false
                            }));
        }

        public static IEnumerable<SelectListItem> GetPhysicianQueueDateTypeFilter(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    PhysicianQueueDateTypeFilter.EventDate.GetNameValuePairs().Select(
                        ers =>
                        new SelectListItem
                        {
                            Text = ers.SecondValue,
                            Value = ers.FirstValue.ToString(),
                            Selected = (ers.FirstValue == selected) ? true : false
                        }));
        }

        public static IEnumerable<SelectListItem> GetPhysicians(long selected = -1)
        {
            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRole(Roles.MedicalVendorUser).Select(
                               dt => new SelectListItem
                                         {
                                             Text = dt.SecondValue,
                                             Value = dt.FirstValue.ToString(),
                                             Selected = (dt.FirstValue == selected) ? true : false
                                         }));
        }

        public static IEnumerable<SelectListItem> GetHospiatlPartnerEventStatusFilter(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    HospitalPartnerEventStatusFilter.Unprocessed.GetNameValuePairs().Select(
                        ers =>
                        new SelectListItem
                        {
                            Text = ers.SecondValue,
                            Value = ers.FirstValue.ToString(),
                            Selected = (ers.FirstValue == selected) ? true : false
                        }));
        }

        public static IEnumerable<SelectListItem> GetResultInterpretation(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    ResultInterpretation.Normal.GetNameValuePairs().Select(
                        ers =>
                        new SelectListItem
                            {
                                Text = ers.SecondValue,
                                Value = ers.FirstValue.ToString(),
                                Selected = (ers.FirstValue == selected) ? true : false
                            }));
        }

        public static IEnumerable<SelectListItem> GetProspectCustomerDateTypeFilter(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    ProspectCustomerDateTypeFilter.CreatedDate.GetNameValuePairs().Select(
                        ers =>
                        new SelectListItem
                        {
                            Text = ers.SecondValue,
                            Value = ers.FirstValue.ToString(),
                            Selected = (ers.FirstValue == selected) ? true : false
                        }));

            //return
            //    ProspectCustomerDateTypeFilter.CreatedDate.GetNameValuePairs().Select(
            //        ers =>
            //        new SelectListItem
            //            {
            //                Text = ers.SecondValue,
            //                Value = ers.FirstValue.ToString(),
            //                Selected = (ers.FirstValue == selected) ? true : false
            //            });
        }

        public static IEnumerable<SelectListItem> GetProspectCustomerSource(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    ProspectCustomerSource.Online.GetNameValuePairs().Where(ers => ers.FirstValue != (int)ProspectCustomerSource.SalesRep).Select(
                        ers =>
                        new SelectListItem
                        {
                            Text = ers.SecondValue,
                            Value = ers.FirstValue.ToString(),
                            Selected = (ers.FirstValue == selected) ? true : false
                        }));

        }

        public static IEnumerable<SelectListItem> Tag(long selected = -1)
        {
            var tag = new[]
                       {
                           
                           new SelectListItem {Value = "OnlineSignup", Text = "Online Registration"},
                           new SelectListItem {Value = "CallCenterSignup", Text = "CallCenter Registration"},
                           new SelectListItem {Value = "NotServicedZip", Text = "Non-Serviced Zip code"},
                           new SelectListItem {Value = "InsuranceConcerns", Text = "Insurance concerns"},
                           new SelectListItem {Value = "PricingConcerns", Text = "Pricing concerns"},
                           new SelectListItem {Value = "NoEventsInTheArea", Text = "No events in the area"},
                           new SelectListItem {Value = "MorningAppointmentPreferred", Text = "Morning appointment preferred"},
                           new SelectListItem {Value = "AfternoonAppointmentPreferred", Text = "Afternoon appointment preferred"},
                           new SelectListItem {Value = "Cancellation", Text = "Cancellation"},
                           new SelectListItem {Value = "NoShow", Text = "No Show"},
                           new SelectListItem {Value = "AllEventsFull", Text = "All Events Full"},
                           new SelectListItem {Value = "DoctorConcerns", Text = "Doctor Concerns"},
                           new SelectListItem {Value = "PoorLocation", Text = "Poor Location"},
                           new SelectListItem {Value = "Corporate", Text = "Corporate"},
                           new SelectListItem {Value = "SurveyResponse", Text = "Survey Response"},
                           new SelectListItem {Value = "IndecisiveUndecided", Text = "Indecisive/Undecided"},
                           new SelectListItem {Value = "TestsAlreadyDoneOrScheduled", Text = "Tests already done or scheduled"},
                           new SelectListItem {Value = "EventsNotInAreaOrUnableToAttend", Text = "Events not in area or unable to attend"},
                           new SelectListItem {Value = "NoScreeningNeeded", Text = "I'm Healthy/No screening needed"},
                           new SelectListItem {Value = "LanguageBarrierMobilityIssue", Text = "Language barrier/Mobility Issue"},
                           new SelectListItem {Value = "PreferDoctorOffice", Text = "Prefer doctor's office"},
                           new SelectListItem {Value = "GettingHomeVisitByNurse", Text = "Getting Home visit by Nurse"},
                           new SelectListItem {Value = "DonotKnowHcpProgram", Text = "Don't know HCP or Program"},
                           new SelectListItem {Value = "AddToWaitingList", Text = "Add to waiting list"},
                               new SelectListItem {Value = "RequestedHomeVisit", Text = "Requested home visit"},
                               new SelectListItem {Value = "CustomerService", Text="Customer Service"}
                           
                       };

            var sortedTagList = new List<SelectListItem> { new SelectListItem { Value = "", Text = "-- Select --" } };
            sortedTagList.AddRange(tag.OrderBy(x => x.Text));

            return sortedTagList.ToArray();
        }

        public static IEnumerable<SelectListItem> Miles(long selected = -1)
        {
            return new[]
                       {
                           new SelectListItem {Value = "0", Text = "-- Select --"},
                           new SelectListItem {Value = "5", Text = "5"},
                           new SelectListItem {Value = "10", Text = "10"},
                           new SelectListItem {Value = "25", Text = "25"},
                           new SelectListItem {Value = "50", Text = "50"},
                           new SelectListItem {Value = "75", Text = "75"},
                           new SelectListItem {Value = "100", Text = "100"},
                       };
        }

        public static IEnumerable<SelectListItem> HospitalPartners(long selected = -1, bool individual = false)
        {
            var orgRoleUsers = IoC.Resolve<IHospitalPartnerRepository>().GetIdNamePairsforHospitalPartners() ?? new List<OrderedPair<long, string>>();
            return
                new[] { new SelectListItem { Text = individual ? "--Select--" : "-- All --", Value = "-1" } }.Concat(
                        orgRoleUsers.Select(oru => new SelectListItem { Text = oru.SecondValue, Value = oru.FirstValue.ToString() })
                    );
        }

        public static IEnumerable<SelectListItem> RecordableTests(long selected = -1)
        {
            var tests = IoC.Resolve<ITestRepository>().GetAll();
            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(
                tests.Where(t => t.IsRecordable).OrderBy(t => t.Name).Select(
                    t => new SelectListItem() { Text = t.Name, Value = t.Id.ToString() }));
        }

        public static IEnumerable<SelectListItem> ResultStatus()
        {

            var pairs = TestResultStateLabel.NoResults.GetNameValuePairs();
            var desired = new[] { (int)TestResultStateLabel.PreAudit, (int)TestResultStateLabel.Evaluated, (int)TestResultStateLabel.PostAudit, (int)TestResultStateLabel.ResultDelivered };
            pairs = pairs.Where(p => desired.Contains(p.FirstValue)).ToList();

            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(
                pairs.Select(p => new SelectListItem { Text = p.SecondValue, Value = p.FirstValue.ToString() }));
        }

        public static IEnumerable<SelectListItem> GetAllPrimaryCarePhysicians()
        {
            return new[] { new SelectListItem { Text = "", Value = "" } };
        }

        public static IEnumerable<SelectListItem> GetDeferredRevenueDateTypeFilter(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    DeferredRevenueFilterDateType.EventDate.GetNameValuePairs().Select(
                        ers =>
                        new SelectListItem
                        {
                            Text = ers.SecondValue,
                            Value = ers.FirstValue.ToString(),
                            Selected = (ers.FirstValue == selected) ? true : false
                        }));
        }

        public static IEnumerable<SelectListItem> GetCorporateAccounts(long selected = -1)
        {
            IEnumerable<SelectListItem> organizations = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(IoC.Resolve<IOrganizationRepository>().GetOrganizationIdNamePairs(OrganizationType.CooperateAccount).Select(
                orderedPair => new SelectListItem { Text = orderedPair.FirstValue, Value = orderedPair.SecondValue.ToString(), Selected = selected == orderedPair.SecondValue }));

            return organizations;
        }

        public static IEnumerable<SelectListItem> Genders(long selected = -1)
        {
            var pairs = Gender.Male.GetNameValuePairs();

            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(
                pairs.Where(p => p.FirstValue != (int)Gender.Unspecified).Select(p => new SelectListItem { Text = p.SecondValue, Value = p.FirstValue.ToString() }));
        }

        public static IEnumerable<SelectListItem> AllRace(long selected = -1)
        {
            var pairs = Race.None.GetNameValuePairs();

            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(
                pairs.Where(p => p.FirstValue != (int)Race.None).Select(p => new SelectListItem { Text = p.SecondValue, Value = p.FirstValue.ToString() }));

            //return pairs.Select(p => new SelectListItem { Text = p.SecondValue, Value = p.FirstValue.ToString() }).ToArray();
        }

        public static IEnumerable<SelectListItem> MarketingSources(string zipCode, string selected = "", bool showOnline = false)
        {
            var marketingSourceService = IoC.Resolve<IMarketingSourceService>();
            var marketingSources = marketingSourceService.FetchMarketingSourceByZip(zipCode, showOnline).OrderBy(ms => ms);

            return marketingSources.Select(ms => new SelectListItem() { Text = ms, Value = ms, Selected = ms == selected });
        }

        public static IEnumerable<SelectListItem> SourceCodeTypes(long selected = -1)
        {
            var sourceCodeRepository = IoC.Resolve<ISourceCodeRepository>();
            var couponTypes = sourceCodeRepository.GetCouponTypeIdNamepair();
            IEnumerable<SelectListItem> allSourceCodeTypes = new[] { new SelectListItem { Text = "-- Type --", Value = "-1" } }.
                Concat(couponTypes.Select(idNamePair => new SelectListItem { Text = idNamePair.SecondValue, Value = idNamePair.FirstValue.ToString(), Selected = selected == idNamePair.FirstValue }));

            return allSourceCodeTypes;
        }

        public static IEnumerable<SelectListItem> GetResultSummary(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    ResultInterpretation.Normal.GetNameValuePairs().Select(
                        ers =>
                        new SelectListItem
                        {
                            Text = ers.SecondValue,
                            Value = ers.FirstValue.ToString(),
                            Selected = (ers.FirstValue == selected) ? true : false
                        }));
        }

        public static IEnumerable<SelectListItem> GetHospitalPartnerCustomerDateTypeFilter(long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(
                    HospitalPartnerCustomerDateTypeFilter.EventDate.GetNameValuePairs().Where(p => p.FirstValue != (int)HospitalPartnerCustomerDateTypeFilter.ResultStatusUpdatedDate).Select(
                        ers =>
                        new SelectListItem
                        {
                            Text = ers.SecondValue,
                            Value = ers.FirstValue.ToString(),
                            Selected = (ers.FirstValue == selected) ? true : false
                        }));


        }

        public static IEnumerable<SelectListItem> GetAllTechnicians(long selected = -1)
        {
            var roleIds = new[] { (long)Roles.Technician, (long)Roles.NursePractitioner };
            var userRepository = IoC.Resolve<IUserRepository<User>>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           userRepository.GetUsersByRoles(roleIds).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> ShippingStatus(long selected = -1)
        {
            return ShipmentStatus.Processing.GetNameValuePairs().Select(p => new SelectListItem
                                                                               {
                                                                                   Text = p.SecondValue,
                                                                                   Value = p.FirstValue.ToString(),
                                                                                   Selected = (p.FirstValue == selected) ? true : false
                                                                               });
        }

        public static IEnumerable<SelectListItem> SlotFilter()
        {
            var pairs = EventSlotListViewOption.All.GetNameValuePairs();

            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(
                pairs.Select(p => new SelectListItem { Text = p.SecondValue, Value = p.FirstValue.ToString() }));
        }

        public static IEnumerable<SelectListItem> HealthAssessmentTemplateTypes(long selected = -1)
        {
            IEnumerable<SelectListItem> allTemplateTypes = new[] { new SelectListItem { Text = "-- Type --", Value = "-1" } }.
                Concat(HealthAssessmentTemplateType.Event.GetNameValuePairs().Select(nameIdPair => new SelectListItem { Text = nameIdPair.SecondValue, Value = nameIdPair.FirstValue.ToString(), Selected = selected == nameIdPair.FirstValue }));

            return allTemplateTypes;
        }

        public static IEnumerable<SelectListItem> GetHealthAssessmentTemplatesByType(HealthAssessmentTemplateType type, long selected = -1)
        {
            var templateRepository = IoC.Resolve<IHealthAssessmentTemplateRepository>();
            var templates = templateRepository.GetByType(type);
            if (templates.IsNullOrEmpty())
            {
                return new[] { new SelectListItem { Text = "-- None --", Value = "-1" } };
            }
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(templates.Select(dt => new SelectListItem
                                                           {
                                                               Text = dt.Name,
                                                               Value = dt.Id.ToString(),
                                                               Selected = (dt.Id == selected)
                                                           }));
        }

        public static IEnumerable<SelectListItem> GetShippingStatus(int selected = -1)
        {
            var pairs = ShipmentStatus.Processing.GetNameValuePairs();

            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(
                pairs.Where(p => p.FirstValue != (int)ShipmentStatus.Cancelled).Select(p => new SelectListItem { Text = p.SecondValue, Value = p.FirstValue.ToString() }));
        }

        public static IEnumerable<SelectListItem> GetAllInsuranceCompany(long selected = -1)
        {
            var companies = IoC.Resolve<IInsuranceCompanyRepository>().GetAll().OrderBy(ic => ic.Name);
            IEnumerable<SelectListItem> insuranceCompanies = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }
                .Concat(companies.Select(
                c => new SelectListItem { Text = c.Name, Value = c.Id.ToString(), Selected = selected == c.Id }));

            return insuranceCompanies;
        }

        public static IEnumerable<SelectListItem> InsurancePaymentStatusList(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(InsurancePaymentStatus.NotSettled.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString() }));
        }

        public static IEnumerable<SelectListItem> ParentHospitalPartners(long selected = -1)
        {
            var orgRoleUsers = IoC.Resolve<IHospitalPartnerRepository>().GetIdNamePairsforParentHospitalPartners() ?? new List<OrderedPair<long, string>>();
            return
                new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(
                        orgRoleUsers.Select(oru => new SelectListItem { Text = oru.SecondValue, Value = oru.FirstValue.ToString() })
                    );
        }

        public static IEnumerable<SelectListItem> BillingAccounts(long selected = -1)
        {
            IEnumerable<SelectListItem> allBillingAccounts = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.
                Concat(IoC.Resolve<IBillingAccountRepository>().GetAll().OrderBy(m => m.Name).Select(nameIdPair => new SelectListItem { Text = nameIdPair.Name, Value = nameIdPair.Id.ToString(), Selected = selected == nameIdPair.Id }));

            return allBillingAccounts;
        }

        public static IEnumerable<SelectListItem> Attempts(long selected = -1)
        {
            return new[]
                       {
                           new SelectListItem {Value = "0", Text = "-- Select --"},
                           new SelectListItem {Value = "1", Text = "1"},
                           new SelectListItem {Value = "2", Text = "2"},
                           new SelectListItem {Value = "3", Text = "3"},
                           new SelectListItem {Value = "4", Text = "4"},
                           new SelectListItem {Value = "5", Text = "5"}
                       };
        }

        public static IEnumerable<SelectListItem> QueueCriteria(long selected = -1)
        {
            IEnumerable<SelectListItem> allCriterias = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.
                Concat(IoC.Resolve<ICriteriaRepository>().GetAll().OrderBy(m => m.Name).Select(nameIdPair => new SelectListItem { Text = nameIdPair.Name, Value = nameIdPair.Id.ToString(), Selected = selected == nameIdPair.Id }));

            return allCriterias;
        }

        public static IEnumerable<SelectListItem> GetCallCenterRep(long selected = -1)
        {
            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRole(Roles.CallCenterRep).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> GetAllCallCenterRep(long selected = -1)
        {
            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[] { new SelectListItem { Text = "--Select--", Value = "-1" } }.Concat(organizationroleUserRepository.GetIdNamePairofAllUsersByRole(Roles.CallCenterRep).Select(dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> CallQueueInterval(long selected = -1)
        {
            return new[]
                       {
                           new SelectListItem {Value = "0", Text = "-- Select --"},
                           new SelectListItem {Value = "30", Text = "30 mins"},
                           new SelectListItem {Value = "60", Text = "1 hr"},
                           new SelectListItem {Value = "120", Text = "2 hrs"},
                           new SelectListItem {Value = "240", Text = "4 hrs"},
                           new SelectListItem {Value = "720", Text = "12 hrs"},
                           new SelectListItem {Value = "1440", Text = "24 hrs"}
                       };
        }

        public static IEnumerable<SelectListItem> GetCallQueue(long selected = -1)
        {
            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                       callQueueRepository.GetAll().Select(dt => new SelectListItem
                               {
                                   Text = dt.Name,
                                   Value = dt.Id.ToString(),
                                   Selected = (dt.Id == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> GetAllEmailTemplates(long selected = -1)
        {
            var emailRepository = IoC.Resolve<IEmailTemplateRepository>();
            return
                new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(emailRepository.GetAll().Select(et => new SelectListItem
                          {
                              Text = et.Subject,
                              Value = et.Id.ToString(),
                              Selected = (et.Id == selected)
                          }));
        }

        public static IEnumerable<SelectListItem> GetLookupSelectListItems(long lookupId, long selected = -1)
        {
            var lookupRepository = IoC.Resolve<ILookupRepository>();

            var lookups = lookupRepository.GetByLookupId(lookupId);

            return lookups.Select(et => new SelectListItem
            {
                Text = et.DisplayName,
                Value = et.Id.ToString(),
                Selected = (et.Id == selected)
            });
        }

        public static IEnumerable<SelectListItem> GetNotificationTypes(long selected = -1)
        {
            var notificationTypeRepository = IoC.Resolve<INotificationTypeRepository>();

            var notificationType = notificationTypeRepository.GetNotificationTypeForTemplate();

            var list = notificationType.Select(et => new SelectListItem
            {
                Text = et.NotificationTypeName,
                Value = et.Id.ToString(),
                Selected = (et.Id == selected)
            });
            return new[] {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(list);
        }

        public static IEnumerable<SelectListItem> GetEmailTemplatesByNotificationTypeAlias(string notificationTypeAlias, long selected = -1, long coverLetterType = -1)
        {
            var emailRepository = IoC.Resolve<IEmailTemplateRepository>();
            return
               new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(emailRepository.GetEmailTemplatesByNotificationAlias(notificationTypeAlias, coverLetterType).Select(et => new SelectListItem
                       {
                           Text = et.Subject,
                           Value = et.Id.ToString(),
                           Selected = (et.Id == selected)
                       }));
        }

        public static IEnumerable<SelectListItem> GetAllCustomTags()
        {
            var corporateTagRepository = IoC.Resolve<ICorporateTagRepository>();
            var customTags = corporateTagRepository.GetAll().OrderBy(x => x.Tag);
            if (customTags != null)
            {
                return customTags.Select(ct => new SelectListItem
                {
                    Text = ct.Tag,
                    Value = ct.Tag
                });
            }
            return new[]
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                }
            };
        }

        public static IEnumerable<SelectListItem> GetCustomTagsByAccountId(long accountId, string[] selectedCustomTags)
        {
            var corporateTagRepository = IoC.Resolve<ICorporateTagRepository>();
            var customTags = corporateTagRepository.GetByCorporateId(accountId);
            if (customTags != null && customTags.Any())
            {
                customTags = customTags.OrderBy(x => x.Tag);

                return customTags.Select(ct => new SelectListItem
                {
                    Text = ct.Tag,
                    Value = ct.Tag,
                    Selected = (selectedCustomTags != null && selectedCustomTags.Any() && selectedCustomTags.Contains(ct.Tag))
                });
            }
            return new[]
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                }
            };
        }

        public static IEnumerable<SelectListItem> GetCustomTagsByAccountIdForEditors(long accountId, string[] selectedCustomTags)
        {
            var corporateTagRepository = IoC.Resolve<ICorporateTagRepository>();
            var customTags = corporateTagRepository.GetByCorporateId(accountId, false);
            if (customTags != null && customTags.Any())
            {
                customTags = customTags.OrderBy(x => x.Tag);

                return customTags.Select(ct => new SelectListItem
                {
                    Text = ct.Tag,
                    Value = ct.Tag,
                    Selected = (selectedCustomTags != null && selectedCustomTags.Any() && selectedCustomTags.Contains(ct.Tag))
                });
            }
            return new[]
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                }
            };
        }

        public static IEnumerable<SelectListItem> HealthTemplateCategory(long selected = -1)
        {
            IEnumerable<SelectListItem> allTemplateTypes = new[] { new SelectListItem { Text = "-- Type --", Value = "-1" } }.
                Concat(HealthAssessmentTemplateCategory.ClinicalQuestions.GetNameValuePairs().Select(nameIdPair => new SelectListItem { Text = nameIdPair.SecondValue, Value = nameIdPair.FirstValue.ToString(), Selected = selected == nameIdPair.FirstValue }));

            return allTemplateTypes;
        }

        public static IEnumerable<SelectListItem> GetHafTemplateByCategory(HealthAssessmentTemplateCategory category, long selected = -1)
        {
            var healthAssessmentTemplateRepository = IoC.Resolve<IHealthAssessmentTemplateRepository>();

            var hafTemplates = healthAssessmentTemplateRepository.GetByCategory(category);

            var list = hafTemplates.Select(et => new SelectListItem
            {
                Text = et.Name,
                Value = et.Id.ToString(),
                Selected = (et.Id == selected)
            });
            return new[] {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(list);
        }
        public static IEnumerable<SelectListItem> GetComparisonOperatorsList(long selected = -1)
        {
            IEnumerable<SelectListItem> allComparisonOperators = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.
                Concat(ComparisonOperators.Between.GetNameValuePairs().Select(nameIdPair => new SelectListItem { Text = nameIdPair.SecondValue, Value = nameIdPair.FirstValue.ToString(), Selected = selected == nameIdPair.FirstValue }));

            return allComparisonOperators;
        }

        public static IEnumerable<SelectListItem> GetNumericList(int to, long selected = -1)
        {
            int from = 1;
            var numericList = new List<SelectListItem>();
            for (var i = from; i <= to; i++)
            {
                numericList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            IEnumerable<SelectListItem> numberList = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.
                Concat(numericList);

            return numberList;
        }

        public static IEnumerable<SelectListItem> GetClinicalCriteiraQuestionList(long templateId, long testId, long selected = -1)
        {
            var numericList = new List<SelectListItem>();
            var healthAssessmentRepository = IoC.Resolve<IHealthAssessmentRepository>();
            var groups = healthAssessmentRepository.GetQuestionWithGroupForTemplatId(templateId);
            var selectedGroup = groups.Where(x => x.TestId.HasValue && x.TestId.Value == testId).Select(x => x).FirstOrDefault();

            if (selectedGroup != null)
            {
                var healthAssessmentTemplateRepository = IoC.Resolve<IHealthAssessmentTemplateRepository>();
                var template = healthAssessmentTemplateRepository.GetById(templateId);

                var selectedQuestions = selectedGroup.Questions.Where(x => template.QuestionIds.Contains(x.Id) && x.ParentQuestionId == null);
                var parentQuestions = selectedGroup.Questions.Where(x => template.QuestionIds.Contains(x.Id) && x.ParentQuestionId != null);

                if (!parentQuestions.IsNullOrEmpty())
                {
                    selectedQuestions = selectedGroup.Questions.Where(x => template.QuestionIds.Contains(x.Id) && x.ParentQuestionId != null);
                }
                numericList.AddRange(selectedQuestions.Select(selectListItem => new SelectListItem { Text = selectListItem.Question, Value = selectListItem.Id.ToString() }));


            }

            IEnumerable<SelectListItem> numberList = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.
                Concat(numericList);

            return numberList;
        }

        public static IEnumerable<SelectListItem> GetYesNoDropdownList(string selected)
        {
            IEnumerable<SelectListItem> yesNoddl = new[]
            {
                new SelectListItem {Text = "-- Select --", Value = ""},
                new SelectListItem {Text = "Yes", Value = "Yes"},
                new SelectListItem {Text = "No", Value = "No"},
            };
            yesNoddl = yesNoddl.Select(x => new SelectListItem { Text = x.Text, Value = x.Value, Selected = x.Value == selected });

            return yesNoddl;
        }
        public static IEnumerable<SelectListItem> AllTests(long selected = -1)
        {
            var tests = IoC.Resolve<ITestRepository>().GetAll();
            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(
                tests.OrderBy(t => t.Name).Select(
                    t => new SelectListItem() { Text = t.Name, Value = t.Id.ToString() }));
        }

        public static IEnumerable<SelectListItem> GetEnumBasePairs(Enum enumType, long selected = -1)
        {
            var items = enumType.GetNameValuePairs();
            return items.Select(i => new SelectListItem { Text = i.SecondValue, Value = i.FirstValue.ToString(), Selected = selected == i.FirstValue }).ToArray();
        }

        public static IEnumerable<SelectListItem> CorporateTests(long selected = -1)
        {
            IEnumerable<SelectListItem> allTests = new[] { new SelectListItem { Text = "-- Select Tests --", Value = "-1" } }.
                //Concat(IoC.Resolve<IPackageRepository>().GetCorporateTests().OrderBy(m => m.Name).
                //        Select(orderedPair => new SelectListItem { Text = orderedPair.Name, Value = orderedPair.Id.ToString(), Selected = selected == orderedPair.Id }));

                 Concat(IoC.Resolve<ITestRepository>().GetAll().OrderBy(m => m.Name).
                        Select(orderedPair => new SelectListItem { Text = orderedPair.Name, Value = orderedPair.Id.ToString(), Selected = selected == orderedPair.Id }));

            return allTests;
        }

        public static IEnumerable<SelectListItem> GetEventStatus(Enum enumType, long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "  ALL  ", Value = "-1" } }.Concat(
                            enumType.GetNameValuePairs().Select(ers =>
                                new SelectListItem
                                {
                                    Text = ers.SecondValue,
                                    Value = ers.FirstValue.ToString(),
                                    Selected = (ers.FirstValue == selected)
                                }));

        }

        public static IEnumerable<SelectListItem> GetPcpDispositionItems(Enum enumType, long selected = -1)
        {
            return new[] { new SelectListItem { Text = "  Select  ", Value = "-1" } }.Concat(
                            enumType.GetNameValuePairs().Select(ers =>
                                new SelectListItem
                                {
                                    Text = ers.SecondValue,
                                    Value = ers.FirstValue.ToString(),
                                    Selected = (ers.FirstValue == selected)
                                }));
        }

        public static IEnumerable<SelectListItem> GetPcpDispositionFilterDateType(Enum enumType, long selected = -1)
        {
            return new[] { new SelectListItem { Text = "  Select  ", Value = "-1" } }.Concat(
                            enumType.GetNameValuePairs().Select(ers =>
                                new SelectListItem
                                {
                                    Text = ers.SecondValue,
                                    Value = ers.FirstValue.ToString(),
                                    Selected = (ers.FirstValue == selected)
                                }));
        }

        public static IEnumerable<SelectListItem> GetHealthPlanCorporateAccounts(long selected = -1)
        {
            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var healthPlans = corporateAccountRepository.GetAllHealthPlan().OrderBy(x => x.Name);
            IEnumerable<SelectListItem> healthPlansItemList = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.
                Concat(healthPlans.Select(hp => new SelectListItem { Text = hp.Name.ToString(), Value = hp.Id.ToString(), Selected = selected == hp.Id }));

            return healthPlansItemList;

        }

        public static IEnumerable<SelectListItem> CallUploadedBy(long selected = -1)
        {
            long[] roles = { (long)Roles.FranchisorAdmin, (long)Roles.CallCenterManager };

            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRoles(roles).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> GetCustomTagsForManageCustomerProspects(long agentOrganizationId)
        {
            var corporateTagRepository = IoC.Resolve<ICorporateTagRepository>();
            IEnumerable<CorporateTag> customTags = null;
            if (agentOrganizationId > 0)
            {
                customTags = corporateTagRepository.CorporateTagForHealthplanResticted(agentOrganizationId);
            }
            else
                customTags = corporateTagRepository.GetAll();
            if (customTags != null)
            {
                return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "None",
                                   Value = "None"
                               }
                       }.Concat(
                          customTags.Select(dt => new SelectListItem
                              {
                                  Text = dt.Tag,
                                  Value = dt.Tag
                              }));
            }
            return new[]
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                }
            };
        }

        public static IEnumerable<SelectListItem> GetHealthPlanCallQueue(long selected = -1)
        {
            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                       callQueueRepository.GetAll(false, true).Where(x => x.Category != HealthPlanCallQueueCategory.UncontactedCustomers && x.Category != HealthPlanCallQueueCategory.AppointmentConfirmation)
                       .OrderBy(x => x.Name).Select(dt => new SelectListItem
                       {
                           Text = dt.Name,
                           Value = dt.Category.ToString(),
                           Selected = (dt.Id == selected) ? true : false
                       }));
        }

        public static IEnumerable<SelectListItem> GetAllHealthPlanCallQueue(long roleId, long selected = -1)
        {
            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            if (roleId == (long)Roles.FranchisorAdmin)
            {
                return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                          callQueueRepository.GetAll(false, true).Where(x => x.Category != "PreAssessmentCallQueue").Select(dt => new SelectListItem
                          {
                              Text = dt.Name,
                              Value = dt.Id.ToString(),
                              Selected = (dt.Id == selected) ? true : false
                          }));
            }
            else
            {
                return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                       callQueueRepository.GetAll(false, true).Where(x => x.Category != "PreAssessmentCallQueue").Select(dt => new SelectListItem
                       {
                           Text = dt.Name,
                           Value = dt.Id.ToString(),
                           Selected = (dt.Id == selected) ? true : false
                       }));
            }

        }

        public static IEnumerable<SelectListItem> GetCallRoundNumberOfDays()
        {
            return new[]
                       {
                           new SelectListItem {Text = "--Select--", Value = "-1"},
                           new SelectListItem {Text = "0-3 Days", Value = "3"},
                           new SelectListItem {Text = "4-6 Days", Value = "6"},
                           new SelectListItem {Text = "1 Week or More", Value = "7"},
                           new SelectListItem {Text = "2 Week or More", Value = "15"},
                           new SelectListItem {Text = "More Than a Month", Value = "31"}
                       };
        }

        public static IEnumerable<SelectListItem> GetCallRoundRoundOfCalls()
        {
            return new[]
                       {
                           new SelectListItem {Text = "--Select--", Value = "-1"},
                           new SelectListItem {Text = "Never been called", Value = "0"},  
                           new SelectListItem {Text = "1", Value = "1"},  
                           new SelectListItem {Text = "2", Value = "2"},  
                           new SelectListItem {Text = "3", Value = "3"},  
                           new SelectListItem {Text = "4", Value = "4"},  
                           new SelectListItem {Text = "5", Value = "5"},       
                           new SelectListItem {Text = "6", Value = "6"},  
                           new SelectListItem {Text = "7", Value = "7"},  
                           new SelectListItem {Text = "8", Value = "8"},  
                           new SelectListItem {Text = "9", Value = "9"},  
                           new SelectListItem {Text = "10", Value = "10"}, 
                       };
        }

        public static IEnumerable<SelectListItem> Redius(long selected = -1)
        {
            return new[]
                       {   
                           new SelectListItem {Value = "-1", Text = "--Select--"},                     
                           new SelectListItem {Value = "0", Text = "Exact search"},
                           new SelectListItem {Value = "5", Text = "5 miles"},
                           new SelectListItem {Value = "10", Text = "10 miles"},
                           new SelectListItem {Value = "15", Text = "15 miles"},
                           new SelectListItem {Value = "20", Text = "20 miles"},
                           new SelectListItem {Value = "25", Text = "25 miles"},
                           new SelectListItem {Value = "50", Text = "50 miles"},                          
                       };
        }

        public static IEnumerable<SelectListItem> GetCampaignType(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(CampaignType.Corporate.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString(), Selected = selected == dt.FirstValue }));
        }

        public static IEnumerable<SelectListItem> GetCampaignMode(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(CampaignMode.OutBound.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString(), Selected = selected == dt.FirstValue }));
        }

        public static IEnumerable<SelectListItem> GetCampaignActivityType(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(CampaignActivityType.DirectMail.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString(), Selected = selected == dt.FirstValue }));
        }

        public static IEnumerable<SelectListItem> GetDirectMailType(long selected = -1)
        {
            var directMailRepository = IoC.Resolve<IDirectMailTypeRepository>();
            var directMails = directMailRepository.GetAll();

            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(directMails.OrderBy(t => t.Name).Select(t => new SelectListItem() { Text = t.Name, Value = t.Id.ToString() }));

        }

        public static IEnumerable<SelectListItem> GetReportType(long roleId, long selected = -1)
        {
            SelectListItem[] reportsType = null;

            if (roleId == (long)Roles.FranchisorAdmin)
            {
                reportsType = new[]
                       {
                           new SelectListItem {Text = ExportableReportType.AppointmentsBooked.GetDescription(), Value =((int) ExportableReportType.AppointmentsBooked).ToString()},
                           new SelectListItem {Text= ExportableReportType.CustomerExport.GetDescription(), Value =((int) ExportableReportType.CustomerExport).ToString()},
                           new SelectListItem {Text = ExportableReportType.OutreachCallReport.GetDescription(), Value =((int) ExportableReportType.OutreachCallReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.TestPerformed.GetDescription(), Value =((int) ExportableReportType.TestPerformed).ToString()},
                           new SelectListItem {Text = ExportableReportType.MemberStatusReport.GetDescription(), Value =((int) ExportableReportType.MemberStatusReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.TestNotPerformed.GetDescription(), Value =((int) ExportableReportType.TestNotPerformed).ToString()},
                           new SelectListItem {Text = ExportableReportType.GapsClosure.GetDescription(), Value =((int) ExportableReportType.GapsClosure).ToString()},
                           new SelectListItem {Text = ExportableReportType.GiftCertificate.GetDescription(), Value =((int) ExportableReportType.GiftCertificate).ToString()},
                           new SelectListItem {Text = ExportableReportType.EventArchiveStats.GetDescription(), Value =((int) ExportableReportType.EventArchiveStats).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallQueueSchedulingReport.GetDescription(), Value =((int) ExportableReportType.CallQueueSchedulingReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.TestBooked.GetDescription(), Value =((int) ExportableReportType.TestBooked).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallQueueCustomerReport.GetDescription(), Value =((int) ExportableReportType.CallQueueCustomerReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallQueueExcludedCustomerReport.GetDescription(), Value =((int) ExportableReportType.CallQueueExcludedCustomerReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CustomerWithNoEventsInAreaReport.GetDescription(), Value =((int) ExportableReportType.CustomerWithNoEventsInAreaReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallCenterCallReport.GetDescription(), Value =((int) ExportableReportType.CallCenterCallReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.ConfirmationReport.GetDescription(), Value =((int) ExportableReportType.ConfirmationReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallSkippedReport.GetDescription(), Value =((int) ExportableReportType.CallSkippedReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CustomerSchedule.GetDescription(), Value =((int) ExportableReportType.CustomerSchedule).ToString()},
                           new SelectListItem {Text = ExportableReportType.PcpTrackingReport.GetDescription(), Value =((int) ExportableReportType.PcpTrackingReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.ExcludedCustomerReport.GetDescription(), Value =((int) ExportableReportType.ExcludedCustomerReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.DisqualifiedTestReport.GetDescription(), Value =((int) ExportableReportType.DisqualifiedTestReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.PreAssessmentReport.GetDescription(), Value =((int) ExportableReportType.PreAssessmentReport).ToString()}
                       };
            }
            else if (roleId == (long)Roles.CallCenterManager)
            {
                reportsType = new[]
                       {
                           new SelectListItem {Text = ExportableReportType.AppointmentsBooked.GetDescription(), Value =((int) ExportableReportType.AppointmentsBooked).ToString()},
                           new SelectListItem { Text= ExportableReportType.CustomerExport.GetDescription(), Value =((int) ExportableReportType.CustomerExport).ToString()},       
                           new SelectListItem {Text = ExportableReportType.OutreachCallReport.GetDescription(), Value =((int) ExportableReportType.OutreachCallReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.MemberStatusReport.GetDescription(), Value =((int) ExportableReportType.MemberStatusReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallQueueSchedulingReport.GetDescription(), Value =((int) ExportableReportType.CallQueueSchedulingReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallQueueCustomerReport.GetDescription(), Value =((int) ExportableReportType.CallQueueCustomerReport).ToString()},                                                                                                                               
                           new SelectListItem {Text = ExportableReportType.TestBooked.GetDescription(), Value =((int) ExportableReportType.TestBooked).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallQueueExcludedCustomerReport.GetDescription(), Value =((int) ExportableReportType.CallQueueExcludedCustomerReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CustomerWithNoEventsInAreaReport.GetDescription(), Value =((int) ExportableReportType.CustomerWithNoEventsInAreaReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.CallCenterCallReport.GetDescription(), Value =((int) ExportableReportType.CallCenterCallReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.ConfirmationReport.GetDescription(), Value =((int) ExportableReportType.ConfirmationReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.ExcludedCustomerReport.GetDescription(), Value =((int) ExportableReportType.ExcludedCustomerReport).ToString()},
                           new SelectListItem {Text = ExportableReportType.PreAssessmentReport.GetDescription(), Value =((int) ExportableReportType.PreAssessmentReport).ToString()}
                       };
            }

            return new[] { new SelectListItem { Text = "-- All --", Value = "-1" } }.Concat(reportsType.OrderBy(x => x.Text));
        }

        public static IEnumerable<SelectListItem> CorporateReviewableTests(long selected = -1)
        {
            IEnumerable<SelectListItem> allTests = new[] { new SelectListItem { Text = "-- Select Tests --", Value = "-1" } }.
                 Concat(IoC.Resolve<ITestRepository>().GetReviewableTests().OrderBy(m => m.Name).
                        Select(orderedPair => new SelectListItem { Text = orderedPair.Name, Value = orderedPair.Id.ToString(), Selected = selected == orderedPair.Id }));

            return allTests;
        }

        public static IEnumerable<SelectListItem> PatientLeftReason(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }
                .Concat(IoC.Resolve<ILookupRepository>().GetByLookupId((long)LeftWithoutScreeningReason.DueToWait)
                .OrderBy(x => x.DisplayName).Select(x => new SelectListItem { Text = x.DisplayName, Value = x.Id.ToString() }));
        }

        public static IEnumerable<SelectListItem> GetAllHealthPlansCustomTags()
        {
            var corporateTagRepository = IoC.Resolve<ICorporateTagRepository>();
            var customTags = corporateTagRepository.GetAllForHealthPlans();

            if (customTags != null)
            {
                return customTags.Select(ct => new SelectListItem
                {
                    Text = ct.Tag,
                    Value = ct.Tag
                });
            }
            return new[]
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                }
            };
        }

        public static IEnumerable<SelectListItem> GetAdditionalFields(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(AdditionalFieldsEnum.AdditionalField1.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString(), Selected = selected == dt.FirstValue }));
        }
        public static IEnumerable<SelectListItem> GetHealthPlanRevenueType(long selected = -1)
        {
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(HealthPlanRevenueType.PerCustomer.GetNameValuePairs().Select(dt => new SelectListItem() { Text = dt.SecondValue, Value = dt.FirstValue.ToString(), Selected = selected == dt.FirstValue }));
        }

        public static IEnumerable<SelectListItem> GetBarrierCategory(long selected = -1)
        {
            IEnumerable<SelectListItem> barriers = new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(IoC.Resolve<IBarrierRepository>().GetBarrierCategoryIdNamePairs().Select(
                orderedPair => new SelectListItem { Text = orderedPair.FirstValue, Value = orderedPair.SecondValue.ToString(), Selected = selected == orderedPair.SecondValue }));

            return barriers;
        }

        public static IEnumerable<SelectListItem> ResultArchiveStatusForUploadOnly(long selected = -1)
        {
            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- All --", Value = "-1" });
            dropDownList.Add(new SelectListItem { Text = ResultArchiveUploadStatus.Uploading.GetDescription(), Value = ((long)ResultArchiveUploadStatus.Uploading).ToString() });
            dropDownList.Add(new SelectListItem { Text = ResultArchiveUploadStatus.UploadFailed.GetDescription(), Value = ((long)ResultArchiveUploadStatus.UploadFailed).ToString() });
            dropDownList.Add(new SelectListItem { Text = ResultArchiveUploadStatus.Uploaded.GetDescription(), Value = ((long)ResultArchiveUploadStatus.Uploaded).ToString() });
            return dropDownList;
        }

        public static IEnumerable<SelectListItem> GetHealthPlanCallQueueForReport(long selected = -1)
        {
            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                       callQueueRepository.GetAll(false, true).Where(x => x.Category != "PreAssessmentCallQueue").Select(dt => new SelectListItem
                       {
                           Text = dt.Name,
                           Value = dt.Id.ToString(),
                           Selected = selected == dt.Id
                       }));
        }

        public static IEnumerable<SelectListItem> GetCampaignsForHealthPlan(long healthPlanId)
        {
            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- Select --", Value = "-1" });

            if (healthPlanId > 0)
            {
                var campaigns = IoC.Resolve<ICampaignRepository>().GetCampaignsByHealthPlanId(healthPlanId);
                dropDownList.AddRange(campaigns.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));
            }

            return dropDownList;
        }

        public static IEnumerable<SelectListItem> GetDirectMailDate(long campaginId)
        {
            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- Select --", Value = "-1" });

            if (campaginId > 0)
            {
                var campaignRepository = IoC.Resolve<ICampaignActivityRepository>();
                var campaigns = campaignRepository.GetDirectMailActivityDates(campaginId);
                dropDownList.AddRange(campaigns.Select(x => new SelectListItem { Text = x.ToString("MM/dd/yyyy"), Value = x.ToString("MM/dd/yyyy") }));
            }

            return dropDownList;
        }

        public static IEnumerable<SelectListItem> GetPayPeriodWeeks(long selected = -1)
        {
            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- Select --", Value = "-1" });

            for (int i = 1; i <= 4; i++)
            {
                dropDownList.Add(new SelectListItem { Text = i + " Week", Value = i.ToString(), Selected = i == selected });
            }

            return dropDownList;
        }

        public static IEnumerable<SelectListItem> GetPayPeriods(long selected = -1)
        {
            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- Select --", Value = "-1" });

            var payPeriodRepository = IoC.Resolve<IPayPeriodRepository>();
            var payPeriod = payPeriodRepository.GetAllForDropdown();
            dropDownList.AddRange(payPeriod.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString(), Selected = x.Id == selected }));

            return dropDownList;
        }

        public static IEnumerable<SelectListItem> PayPeriodCriteriaTypes()
        {
            var list = PayPeriodCriteriaType.Between.GetNameValuePairs();

            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- Select --", Value = "-1" });

            dropDownList.AddRange(list.Select(x => new SelectListItem { Text = x.SecondValue, Value = x.FirstValue.ToString() }));
            return dropDownList;
        }

        public static IEnumerable<SelectListItem> GetPayRange(long payPeriodId = -1, string selected = "")
        {
            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- Select --", Value = "" });

            if (payPeriodId <= 0) return dropDownList;

            var payPeriodRepository = IoC.Resolve<IPayPeriodRepository>();
            var payPeriod = payPeriodRepository.GetById(payPeriodId);

            var nextPayPeriod = payPeriodRepository.GetNextPublishedPayPeriod(payPeriod.StartDate);
            var startDate = payPeriod.StartDate;
            var nextEffectiveDate = DateTime.Today;
            if (nextPayPeriod != null)
            {
                nextEffectiveDate = nextPayPeriod.StartDate > DateTime.Today ? DateTime.Today : nextPayPeriod.StartDate;
            }

            while (startDate < nextEffectiveDate)
            {
                var endDate = startDate.AddDays((7 * payPeriod.NumberOfWeeks) - 1);
                dropDownList.Add(new SelectListItem { Text = startDate.ToString("MM/dd/yyyy") + " - " + endDate.ToString("MM/dd/yyyy"), Value = startDate.ToString("MM/dd/yyyy") + "-" + endDate.ToString("MM/dd/yyyy") });
                startDate = endDate.AddDays(1);
            }

            return dropDownList;
        }

        public static IEnumerable<SelectListItem> GetYear(int selected = -1)
        {
            var dropDownList = new List<SelectListItem>();
            dropDownList.Add(new SelectListItem { Text = "-- Select --", Value = "-1" });

            int startYear = IoC.Resolve<ISettings>().StartYear;

            for (int year = startYear; year <= DateTime.Now.Year; year++)
            {
                dropDownList.Add(new SelectListItem { Text = year.ToString(), Value = year.ToString(), Selected = year == selected });
            }
            return dropDownList;
        }

        public static IEnumerable<SelectListItem> GetPdfGeneratedStatus(Enum enumType, long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "  All  ", Value = "-1" } }.Concat(
                            enumType.GetNameValuePairs().Select(ers =>
                                new SelectListItem
                                {
                                    Text = ers.SecondValue,
                                    Value = ers.FirstValue.ToString(),
                                    Selected = (ers.FirstValue == selected)
                                }));

        }

        public static IEnumerable<SelectListItem> GetSuppressionType(Enum enumType, long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "  --Select--  ", Value = "-1" } }.Concat(
                            enumType.GetNameValuePairs().Select(ers =>
                                new SelectListItem
                                {
                                    Text = ers.SecondValue,
                                    Value = ers.FirstValue.ToString(),
                                    Selected = (ers.FirstValue == selected)
                                }));

        }

        public static IEnumerable<SelectListItem> GetCallCenterCallType(Enum enumType, long selected = -1)
        {
            return
                new[] { new SelectListItem { Text = "  All  ", Value = "-1" } }.Concat(
                            enumType.GetNameValuePairs().Select(ers =>
                                new SelectListItem
                                {
                                    Text = ers.SecondValue,
                                    Value = ers.FirstValue.ToString(),
                                    Selected = (ers.FirstValue == selected)
                                }));

        }

        public static IEnumerable<SelectListItem> RpasUploadedBy(long selected = -1)
        {
            long[] roles = { (long)Roles.FranchisorAdmin };

            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRoles(roles).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> GetPhoneNumberUploadedBy(int selected = -1)       //Admin Role Only
        {
            long[] role = { (long)Roles.FranchisorAdmin };

            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRoles(role).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected)
                               }));
        }

        public static IEnumerable<SelectListItem> GetAgentTeams(int selected = -1)
        {
            var callCenterTeamRepository = IoC.Resolve<ICallCenterTeamRepository>();
            return new[]
            {
                new SelectListItem
                {
                    Text = "--Select--",
                    Value = "-1"
                }
            }.Concat(
            callCenterTeamRepository.GetIdNamePairOfTeams().Select(x => new SelectListItem
            {
                Text = x.SecondValue,
                Value = x.FirstValue.ToString(),
                Selected = (x.FirstValue == selected)
            })
            );
        }

        public static IEnumerable<SelectListItem> StateNames(string selected = "")
        {
            IEnumerable<SelectListItem> states = new[] { new SelectListItem { Text = "Select State", Value = "" } }.Concat(IoC.Resolve<IStateRepository>().GetAllStates().Select(
                state => new SelectListItem { Text = state.Name, Value = state.Name, Selected = selected == state.Name }));

            return states;
        }

        public static IEnumerable<SelectListItem> GetActiveHealthPlanCallQueues(long selected = -1)
        {
            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                       callQueueRepository.GetAll(false, true).Where(x => x.Category != HealthPlanCallQueueCategory.UncontactedCustomers && x.Category != HealthPlanCallQueueCategory.AppointmentConfirmation && x.Category!=HealthPlanCallQueueCategory.PreAssessmentCallQueue)
                       .OrderBy(x => x.Name).Select(dt => new SelectListItem
                       {
                           Text = dt.Name,
                           Value = dt.Id.ToString(),
                           Selected = (dt.Id == selected) ? true : false
                       }));
        }

        public static IEnumerable<SelectListItem> OrganizationsByOrganizationType(OrganizationType type, long selected = -1)
        {
            IEnumerable<SelectListItem> organizations = new[] { new SelectListItem { Text = "-- Select Organization --", Value = "-1" } }.Concat(IoC.Resolve<IOrganizationRepository>().GetOrganizationIdNamePairs(type).Select(
                orderedPair => new SelectListItem { Text = orderedPair.FirstValue, Value = orderedPair.SecondValue.ToString(), Selected = selected == orderedPair.SecondValue }));

            return organizations;
        }

        public static IEnumerable<SelectListItem> GetHealthPlanCallQueueCategories(string selected = "")
        {
            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                       callQueueRepository.GetAll(false, true).Where(x => x.Category != "PreAssessmentCallQueue")
                       .OrderBy(x => x.Name).Select(dt => new SelectListItem
                       {
                           Text = dt.Name,
                           Value = dt.Category.ToString(),
                           Selected = (dt.Category == selected) ? true : false
                       }));
        }

        public static IEnumerable<SelectListItem> GetLanguages(long selected = -1)
        {
            var languageRepository = IoC.Resolve<ILanguageRepository>();
            return new[]
            {
                new SelectListItem
                {
                    Text = "--Select--",
                    Value = "-1"
                }
            }.Concat(
            languageRepository.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = (x.Id == selected)
            })
            );
        }

        public static IEnumerable<SelectListItem> ConfirmationDispositions(string selected = "")
        {
            var tag = new[]
                       {
                           
                           new SelectListItem {Value = ProspectCustomerTag.PatientConfirmed.ToString(), Text = ProspectCustomerTag.PatientConfirmed.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.CancelAppointment.ToString(), Text = ProspectCustomerTag.CancelAppointment.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.RescheduleAppointment.ToString(), Text = ProspectCustomerTag.RescheduleAppointment.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.ConfirmLanguageBarrier.ToString(), Text = ProspectCustomerTag.ConfirmLanguageBarrier.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.ConfirmedHRANotComplete.ToString(), Text = ProspectCustomerTag.ConfirmedHRANotComplete.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.CallBackLater.ToString(), Text = ProspectCustomerTag.CallBackLater.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.Deceased.ToString(), Text = ProspectCustomerTag.Deceased.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.InLongTermCareNursingHome.ToString(), Text = ProspectCustomerTag.InLongTermCareNursingHome.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.LeftMessage.ToString(), Text = ProspectCustomerTag.LeftMessage.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString(), Text = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.DebilitatingDisease.ToString(), Text = ProspectCustomerTag.DebilitatingDisease.GetDescription()},
                       };

            var sortedTagList = new List<SelectListItem> { new SelectListItem { Value = "", Text = "-- Select --" } };
            sortedTagList.AddRange(tag.OrderBy(x => x.Text));

            return sortedTagList.ToArray();
        }

        public static IEnumerable<SelectListItem> EligibilityUploadedBy(long selected = -1)
        {
            long[] roles = { (long)Roles.FranchisorAdmin };

            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRoles(roles).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> MedicationUploadedBy(long selected = -1)
        {
            long[] roles = { (long)Roles.FranchisorAdmin };

            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRoles(roles).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> StaffEventScheduleUploadedBy(long selected = -1)
        {
            long[] roles = { (long)Roles.FranchisorAdmin };

            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRoles(roles).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> GcNotGivenReasons(long selected = -1)
        {
            var gcNotGivenRepository = IoC.Resolve<IGcNotGivenReasonRepository>();
            return new[]
            {
                new SelectListItem
                {
                    Text = "--Select--",
                    Value = "-1"
                }
            }.Concat(
                gcNotGivenRepository.GetReasonForDropDown().Select(
                    x => new SelectListItem
                    {
                        Text = x.SecondValue,
                        Value = x.FirstValue.ToString(),
                        Selected = (x.FirstValue == selected) ? true : false
                    }
                    )
                );
        }

        public static IEnumerable<SelectListItem> GetPatientPhoneConsent(long selected = -1)
        {
            return PatientConsent.Granted.GetNameValuePairs().OrderBy(x => x.SecondValue).Select(
             x => new SelectListItem
             {
                 Text = x.SecondValue,
                 Value = x.FirstValue.ToString(),
                 Selected = x.FirstValue == selected ? true : false
             });
        }

        public static IEnumerable<SelectListItem> SuspectConditionUploadedBy(long selected = -1)
        {
            long[] roles = { (long)Roles.FranchisorAdmin };

            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRoles(roles).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }

        public static IEnumerable<SelectListItem> RadiusForCallQueue(long selected = -1)
        {
            var radius = ZipRadius.FiveMiles.GetNameValuePairs().OrderBy(x => x.FirstValue);
            return new[]
            {
                new SelectListItem
                {
                    Text = "Exact Search",
                    Value = "0"
                }
            }.Concat(radius
             .Select(x => new SelectListItem
              {
                  Text = x.SecondValue,
                  Value = x.FirstValue.ToString(),
                  Selected = (x.FirstValue == selected) ? true : false
              }));
        }

        public static IEnumerable<SelectListItem> GetPreQualificationTestQuestionTemplates(long testId, long selected = -1)
        {
            var preQualificationTestTemplateRepository = IoC.Resolve<IPreQualificationTestTemplateRepository>();
            var templates = preQualificationTestTemplateRepository.GetByTestId(testId);
            if (templates.IsNullOrEmpty())
            {
                return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } };
            }
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(templates.Select(dt => new SelectListItem
                       {
                           Text = dt.TemplateName,
                           Value = dt.Id.ToString(),
                           Selected = (dt.Id == selected)
                       }));
        }

        public static IEnumerable<SelectListItem> GetAllTest(long selected = -1)
        {
            var tests = IoC.Resolve<ITestRepository>().GetAll();
            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(
                tests.OrderBy(t => t.Name).Select(
                    t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }));
        }

        public static IEnumerable<SelectListItem> GetDependentTests(long testId)
        {
            var tests = IoC.Resolve<ITestRepository>().GetDependentTests(testId);
            return tests.OrderBy(t => t.Name).Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() });
        }

        public static IEnumerable<SelectListItem> GetAllCheckListType()
        {

            var items = CheckListType.CheckList.GetNameValuePairs();

            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(items.Select(i => new SelectListItem { Text = i.SecondValue, Value = i.FirstValue.ToString() }).ToArray());
        }

        public static IEnumerable<SelectListItem> CustomerActivityTypeUploadedBy(long selected = -1)
        {
            long[] roles = { (long)Roles.FranchisorAdmin };

            var organizationroleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            return new[]
                       {
                           new SelectListItem
                               {
                                   Text = "--Select--",
                                   Value = "-1"
                               }
                       }.Concat(
                           organizationroleUserRepository.GetIdNamePairofUsersByRoles(roles).Select(
                               dt => new SelectListItem
                               {
                                   Text = dt.SecondValue,
                                   Value = dt.FirstValue.ToString(),
                                   Selected = (dt.FirstValue == selected) ? true : false
                               }));
        }
        public static IEnumerable<SelectListItem> PreAssessmentDispositions(string selected = "")
        {
            var tag = new[]
                       {
                           
                           new SelectListItem {Value = ProspectCustomerTag.CHATCompleted.ToString(), Text = ProspectCustomerTag.CHATCompleted.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.RequestedCHATMailed.ToString(), Text = ProspectCustomerTag.RequestedCHATMailed.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.MemberDoesntHaveTimeForQuestions.ToString(), Text = ProspectCustomerTag.MemberDoesntHaveTimeForQuestions.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.MemberDoesNotFeelComfortableAnsweringQuestions.ToString(), Text = ProspectCustomerTag.MemberDoesNotFeelComfortableAnsweringQuestions.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.FollowUpCallEscalated.ToString(), Text = ProspectCustomerTag.FollowUpCallEscalated.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.NotInterested.ToString(), Text = ProspectCustomerTag.NotInterested.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.CallBackLater.ToString(), Text = ProspectCustomerTag.CallBackLater.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.CancelledAppointment.ToString(), Text = ProspectCustomerTag.CancelledAppointment.GetDescription()},

                           new SelectListItem {Value = ProspectCustomerTag.Deceased.ToString(), Text = ProspectCustomerTag.Deceased.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.InLongTermCareNursingHome.ToString(), Text = ProspectCustomerTag.InLongTermCareNursingHome.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.LeftMessage.ToString(), Text = ProspectCustomerTag.LeftMessage.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString(), Text = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.GetDescription()},
                           new SelectListItem {Value = ProspectCustomerTag.DebilitatingDisease.ToString(), Text = ProspectCustomerTag.DebilitatingDisease.GetDescription()},
                       };

            var sortedTagList = new List<SelectListItem> { new SelectListItem { Value = "", Text = "-- Select --" } };
            sortedTagList.AddRange(tag.OrderBy(x => x.Text));

            return sortedTagList.ToArray();
        }

        public static IEnumerable<SelectListItem> GetAllProductType()
        {

            var items = ProductType.CHA.GetNameValuePairs();

            return new[] { new SelectListItem { Text = "-- Select --", Value = "-1" } }.Concat(items.Select(i => new SelectListItem { Text = i.SecondValue, Value = i.FirstValue.ToString() }).ToArray());
        }
    }
}