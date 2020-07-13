using System.Data;
using System.IO;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Medical.Factories;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{

    [DefaultImplementation]
    public class PcpResultExportServiceHelper : PersistenceRepository, IPcpResultExportServiceHelper
    {
        private readonly ILogger _logger;
        private readonly DateTime _cutOfDate;
        private readonly IPcpResultExportFactory _pcpResultExportFactory;
        private readonly DateTime _resultFlowChangeDate;
        private readonly ICsvReader _csvReader;

        public PcpResultExportServiceHelper(ILogger logger, ISettings settings, ICsvReader csvReader)
        {
            _logger = logger;
            _cutOfDate = settings.PcpDownloadCutOfDate;
            _pcpResultExportFactory = new PcpResultExportFactory(logger);
            _resultFlowChangeDate = settings.ResultFlowChangeDate;
            _csvReader = csvReader;
        }

        public void ResultExport(DateTime fromDate, DateTime toDate, long accountId, string destinationPath,
            string corporateTag, string[] customTags = null, bool excludeCustomtagCusomers = false, bool useBlankValue = false,
            string resultExportFileName = "", bool considerEventDate = false, string[] showHiddenColumns = null, DateTime? eventStartDate = null,
            DateTime? eventEndDate = null, string[] showHiddenAdditionalFields = null, DateTime? stopSendingPdftoHealthPlanDate = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                _logger.Info("Fetching EventCustomerResults");

                var eventCustomerResult = GetEventCustomerResult(linqMetaData, fromDate, toDate, accountId, corporateTag, customTags, excludeCustomtagCusomers, considerEventDate, eventStartDate, eventEndDate, stopSendingPdftoHealthPlanDate: stopSendingPdftoHealthPlanDate);

                if (eventCustomerResult == null || !Queryable.Any<EventCustomerResultEntity>(eventCustomerResult))
                {
                    _logger.Info("No Records Found");
                    return;
                }

                var customerIds = Queryable.Select<EventCustomerResultEntity, long>(eventCustomerResult, ecr => ecr.CustomerId);

                _logger.Info("Fetching UserIds");

                var orgRoleUserIdUserIdPairs = GetOrgRoleUserIdUserIdPairs(linqMetaData, customerIds);

                _logger.Info("Fetching Users info");

                var users = GetUsers(linqMetaData, Queryable.Select<OrderedPair<long, long>, long>(orgRoleUserIdUserIdPairs, oru => oru.SecondValue));

                _logger.Info("Fetching Address info");

                var addresses = GetAddress(linqMetaData, Queryable.Select<UserEntity, long>(users, u => u.HomeAddressId));

                _logger.Info("Fetching Customer Profile info");

                var customers = GetCustomers(linqMetaData, customerIds);

                _logger.Info("Fetching Event info");

                var events = GetEvents(linqMetaData, Queryable.Select<EventCustomerResultEntity, long>(eventCustomerResult, ecr => ecr.EventId));

                _logger.Info("Fetching Pod info");

                var eventIdPodIdPairs = GetEventIdPodIdPairs(linqMetaData, Queryable.Select<EventCustomerResultEntity, long>(eventCustomerResult, ecr => ecr.EventId));

                var pods = GetAllPods(linqMetaData);

                _logger.Info("Fetching Hospitalpartner info");

                var eventIdHospitalPartnerIdPairs = GetEventIdHospitalPartnerIdPairs(linqMetaData, Queryable.Select<EventCustomerResultEntity, long>(eventCustomerResult, ecr => ecr.EventId));

                var hospitalPartnerIdNamePairs = GetOrganizationIdNamePairs(linqMetaData, Queryable.Select<OrderedPair<long, long>, long>(eventIdHospitalPartnerIdPairs, eh => eh.SecondValue));

                var hafTemplateIds = GetHafTemplateIds(linqMetaData, accountId, _cutOfDate);
                var hafQuestionIds = GetHafQuestionIds(linqMetaData, hafTemplateIds);

                _logger.Info("Fetching EventCustomer info");

                var eventCustomers = GetEventCustomers(linqMetaData, Queryable.Select<EventCustomerResultEntity, long>(eventCustomerResult, ecr => ecr.EventCustomerResultId));

                _logger.Info("Fetching Event Appoint info");

                var eventAppointment = GetAppointmentDetails(linqMetaData, Queryable.Where<EventCustomersEntity>(eventCustomers, ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value));

                _logger.Info("Fetching Hospital Partner Customer info");

                var hospitalPartnerCustomers = GetHospitalPartnerCustomers(linqMetaData, Queryable.Select<EventCustomerResultEntity, long>(eventCustomerResult, ecr => ecr.EventId));

                var careCoordinatorIdNamePair = GetIdNamePairofUsers(linqMetaData, Queryable.Select<HospitalPartnerCustomerEntity, long>(hospitalPartnerCustomers, hpc => hpc.CareCoordinatorOrgRoleUserId));

                _logger.Info("Fetching Primary care physician info");

                var primaryCarePhysicians = GetPrimaryCarePhysicians(linqMetaData, customerIds);

                _logger.Info("Fetching Basic Biometric info");

                var basicBiometric = GetEventCustomerBasicBiometric(linqMetaData, Queryable.Select<EventCustomerResultEntity, long>(eventCustomerResult, ecr => ecr.EventCustomerResultId));

                _logger.Info("Fetching HAF info");

                var customerHealthAnswers = GetCustomerHealthAnswers(linqMetaData, Queryable.Select<EventCustomerResultEntity, long>(eventCustomerResult, ecr => ecr.EventCustomerResultId));

                IEnumerable<OrderedPair<string, string>> additionalFields = null;
                if (showHiddenAdditionalFields != null && showHiddenAdditionalFields.Any())
                {
                    _logger.Info("Fetching Additional Fields");
                    additionalFields = GetAdditionalFields(linqMetaData, accountId, showHiddenAdditionalFields);
                }

                _logger.Info("Creating CSV file");

                _pcpResultExportFactory.Create(Enumerable.ToArray<EventCustomerResultEntity>(eventCustomerResult), Enumerable.ToArray<OrderedPair<long, long>>(orgRoleUserIdUserIdPairs), Enumerable.ToArray<UserEntity>(users), addresses, customers, events, customerHealthAnswers,
                    Enumerable.ToArray<OrderedPair<long, long>>(eventIdPodIdPairs), pods, Enumerable.ToArray<OrderedPair<long, long>>(eventIdHospitalPartnerIdPairs), hospitalPartnerIdNamePairs, basicBiometric, Enumerable.ToArray<EventCustomersEntity>(eventCustomers), eventAppointment,
                    hospitalPartnerCustomers, careCoordinatorIdNamePair, primaryCarePhysicians, destinationPath, hafQuestionIds, useBlankValue, resultExportFileName, showHiddenColumns, additionalFields);

                _logger.Info("Completed");
            }
        }

        public void WriteCsvHeader(string fileName, string[] showHiddenColumns = null,
            IEnumerable<OrderedPair<string, string>> additionalFields = null)
        {
            _pcpResultExportFactory.WriteCsvHeader(fileName, showHiddenColumns, additionalFields);
        }

        private IQueryable<EventCustomerResultEntity> GetEventCustomerResult(LinqMetaData linqMetaData, DateTime startDate, DateTime endDate,
            long accountId, string corporateTag, string[] customTags = null, bool excludeCustomtagCusomers = false, bool considerEventDate = false,
            DateTime? startDateEvent = null, DateTime? endDateEvent = null, DateTime? stopSendingPdftoHealthPlanDate = null)
        {
            var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == corporateTag select cp.CustomerId);


            var query = (from ecr in linqMetaData.EventCustomerResult
                         join e in linqMetaData.Events on ecr.EventId equals e.EventId
                         join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                         where ea.AccountId == accountId
                               && (ecr.DateModified.HasValue && (startDate == null || ecr.DateModified > startDate) && ecr.DateModified <= endDate)
                              && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                               && customerIds.Contains(ecr.CustomerId)
                         select new { ecr, e });

            if (considerEventDate)
            {
                if (startDateEvent.HasValue)
                    query = (from q in query where q.e.EventDate >= startDateEvent.Value select q);

                if (endDateEvent.HasValue)
                    query = (from q in query where q.e.EventDate <= endDateEvent.Value select q);
            }

            if (customTags != null && customTags.Any())
            {
                var customTagCustomerIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && customTags.Contains(ct.Tag) select ct.CustomerId);

                if (excludeCustomtagCusomers)
                {
                    query = (from q in query where !customTagCustomerIds.Contains(q.ecr.CustomerId) select q);
                }
                else
                {
                    query = (from q in query where customTagCustomerIds.Contains(q.ecr.CustomerId) select q);
                }
            }

            if (stopSendingPdftoHealthPlanDate.HasValue)
            {
                query = (from q in query where q.e.EventDate < stopSendingPdftoHealthPlanDate.Value select q);
            }

            return query.OrderBy(q => q.e.EventDate).ThenBy(q => q.e.EventId).ThenBy(q => q.ecr.CustomerId).Select(q => q.ecr);
        }

        private IQueryable<OrderedPair<long, long>> GetOrgRoleUserIdUserIdPairs(LinqMetaData linqMetaData, IQueryable<long> orgRoleUserIds)
        {
            return (from oru in linqMetaData.OrganizationRoleUser
                    join u in linqMetaData.User on oru.UserId equals u.UserId
                    where orgRoleUserIds.Contains(oru.OrganizationRoleUserId)
                    select new OrderedPair<long, long>(oru.OrganizationRoleUserId, u.UserId));

        }

        private IQueryable<UserEntity> GetUsers(LinqMetaData linqMetaData, IQueryable<long> userIds)
        {
            return (from u in linqMetaData.User
                    where userIds.Contains(u.UserId)
                    select u);
        }

        private IEnumerable<Address> GetAddress(LinqMetaData linqMetaData, IQueryable<long> addressIds)
        {
            return (from a in linqMetaData.Address
                    join c in linqMetaData.City on a.CityId equals c.CityId
                    join s in linqMetaData.State on a.StateId equals s.StateId
                    join z in linqMetaData.Zip on a.ZipId equals z.ZipId
                    where addressIds.Contains(a.AddressId)
                    select new Address
                    {
                        Id = a.AddressId,
                        StreetAddressLine1 = a.Address1,
                        City = c.Name,
                        State = s.Name,
                        ZipCode = new ZipCode(z.ZipCode),
                    }).ToArray();
        }

        private IEnumerable<CustomerProfileEntity> GetCustomers(LinqMetaData linqMetaData, IQueryable<long> customerIds)
        {
            return (from cp in linqMetaData.CustomerProfile
                    where customerIds.Contains(cp.CustomerId)
                    select cp).ToArray();
        }

        private IEnumerable<EventsEntity> GetEvents(LinqMetaData linqMetaData, IQueryable<long> eventIds)
        {
            return (from e in linqMetaData.Events
                    where eventIds.Contains(e.EventId)
                    select e).ToArray();
        }

        private IEnumerable<CustomerHealthInfoEntity> GetCustomerHealthAnswers(LinqMetaData linqMetaData, IQueryable<long> eventCustomerIds)
        {
            return (from chi in linqMetaData.CustomerHealthInfo
                    where eventCustomerIds.Contains(chi.EventCustomerId)
                    select chi).ToArray();
        }

        private IEnumerable<OrderedPair<long, long>> GetEventIdPodIdPairs(LinqMetaData linqMetaData, IQueryable<long> eventIds)
        {
            return (from ep in linqMetaData.EventPod
                    where ep.IsActive && eventIds.Contains(ep.EventId)
                    select new OrderedPair<long, long>(ep.EventId, ep.PodId)).ToArray();
        }

        private IEnumerable<PodDetailsEntity> GetAllPods(LinqMetaData linqMetaData)
        {
            return (from pd in linqMetaData.PodDetails
                    select pd).ToArray();
        }

        private IQueryable<OrderedPair<long, long>> GetEventIdHospitalPartnerIdPairs(LinqMetaData linqMetaData, IQueryable<long> eventIds)
        {
            return (from ehp in linqMetaData.EventHospitalPartner
                    where eventIds.Contains(ehp.EventId)
                    select new OrderedPair<long, long>(ehp.EventId, ehp.HospitalPartnerId));
        }

        private IEnumerable<OrderedPair<long, string>> GetOrganizationIdNamePairs(LinqMetaData linqMetaData, IQueryable<long> organizationIds)
        {
            return (from o in linqMetaData.Organization
                    where organizationIds.Contains(o.OrganizationId)
                    select new OrderedPair<long, string>(o.OrganizationId, o.Name)).ToArray();
        }

        private IEnumerable<EventCustomerBasicBioMetricEntity> GetEventCustomerBasicBiometric(LinqMetaData linqMetaData, IQueryable<long> eventCustomerIds)
        {
            return (from bb in linqMetaData.EventCustomerBasicBioMetric
                    where eventCustomerIds.Contains(bb.EventCustomerId)
                    select bb).ToArray();
        }

        private IQueryable<EventCustomersEntity> GetEventCustomers(LinqMetaData linqMetaData, IQueryable<long> eventCustomerIds)
        {
            return (from ec in linqMetaData.EventCustomers
                    where eventCustomerIds.Contains(ec.EventCustomerId)
                    select ec);
        }

        private IEnumerable<EventAppointmentEntity> GetAppointmentDetails(LinqMetaData linqMetaData, IQueryable<long> appointmentIds)
        {
            return (from ea in linqMetaData.EventAppointment
                    where appointmentIds.Contains(ea.AppointmentId)
                    select ea).ToArray();
        }

        private IQueryable<HospitalPartnerCustomerEntity> GetHospitalPartnerCustomers(LinqMetaData linqMetaData, IQueryable<long> eventIds)
        {
            return (from hpc in linqMetaData.HospitalPartnerCustomer
                    where eventIds.Contains(hpc.EventId)
                    select hpc);
        }

        private IEnumerable<OrderedPair<long, string>> GetIdNamePairofUsers(LinqMetaData linqMetaData, IQueryable<long> orgRoleUserIds)
        {
            return (from u in linqMetaData.User
                    join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                    where orgRoleUserIds.Contains(oru.OrganizationRoleUserId)
                    select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).OrderBy(o => o.SecondValue)
                .ToArray();
        }

        private IEnumerable<CustomerPrimaryCarePhysicianEntity> GetPrimaryCarePhysicians(LinqMetaData linqMetaData, IQueryable<long> customerIds)
        {
            return (from pcp in linqMetaData.CustomerPrimaryCarePhysician
                    where customerIds.Contains(pcp.CustomerId) && pcp.IsActive
                    select pcp).ToArray();
        }

        private IEnumerable<long> GetHafTemplateIds(LinqMetaData linqMetaData, long accountId, DateTime cutOffDate)
        {
            var hafTemplateIds = new List<long>();

            var clinicalHafTemplateId = (from a in linqMetaData.Account
                                         where a.AccountId == accountId && a.ClinicalQuestionTemplateId.HasValue
                                         select a.ClinicalQuestionTemplateId.Value).SingleOrDefault();
            if (clinicalHafTemplateId > 0)
                hafTemplateIds.Add(clinicalHafTemplateId);

            var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == accountId select ea.EventId);

            var eventHafTemplateIds = (from e in linqMetaData.Events
                                       where e.EventDate >= cutOffDate
                                             && e.EventStatus == (long)EventStatus.Active
                                             && eventIds.Contains(e.EventId)
                                             && e.HafTemplateId.HasValue
                                       select e.HafTemplateId.Value).Distinct().ToList();

            if (eventHafTemplateIds.Any())
                hafTemplateIds.AddRange(eventHafTemplateIds);

            var packageHafTemplateIds = (from e in linqMetaData.Events
                                         join ep in linqMetaData.EventPackageDetails on e.EventId equals ep.EventId
                                         where e.EventDate >= cutOffDate
                                               && e.EventStatus == (long)EventStatus.Active
                                               && eventIds.Contains(e.EventId)
                                               && ep.HafTemplateId.HasValue
                                         select ep.HafTemplateId.Value).Distinct().ToList();

            if (packageHafTemplateIds.Any())
                hafTemplateIds.AddRange(packageHafTemplateIds);

            var testHafTemplateIds = (from e in linqMetaData.Events
                                      join et in linqMetaData.EventTest on e.EventId equals et.EventId
                                      where e.EventDate >= cutOffDate
                                            && e.EventStatus == (long)EventStatus.Active
                                            && eventIds.Contains(e.EventId)
                                            && et.HafTemplateId.HasValue
                                      select et.HafTemplateId.Value).Distinct().ToList();

            if (testHafTemplateIds.Any())
                hafTemplateIds.AddRange(testHafTemplateIds);

            return hafTemplateIds;
        }

        private IEnumerable<long> GetHafQuestionIds(LinqMetaData linqMetaData, IEnumerable<long> hafTemplateIds)
        {
            return
                (from hatq in linqMetaData.HafTemplateQuestion
                 where hafTemplateIds.Contains(hatq.HaftemplateId)
                 select hatq.QuestionId).Distinct().ToArray();
        }

        private string GetColumnName(DataTable dtable, string columnNameStartWith)
        {
            return dtable.Columns.Cast<DataColumn>().Where(column => column.ColumnName.StartsWith(columnNameStartWith)).Select(column => column.ColumnName).FirstOrDefault();
        }

        private DataTable CreateDataTable(string csvFileToConvertIntoDataTable)
        {
            if (string.IsNullOrWhiteSpace(csvFileToConvertIntoDataTable) || DirectoryOperationsHelper.IsFileExist(csvFileToConvertIntoDataTable) == false)
            {
                _logger.Info("File not exists at following path: " + csvFileToConvertIntoDataTable);
                return null;
            }

            try
            {
                var dtable = _csvReader.ConvertCsvToDataTable(csvFileToConvertIntoDataTable, true, "_$$");

                if (dtable == null || dtable.Rows == null || dtable.Rows.Count <= 0)
                {
                    _logger.Info("No record found in current File:  " + csvFileToConvertIntoDataTable);
                    return null;
                }

                return dtable;
            }
            catch (Exception ex)
            {
                _logger.Error("Some Exception occurred while converting csvtoDataTable");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

            return null;
        }

        private DataTable CreateAccumulativeDataTable(DataTable cumulative, DataTable incremental, string customerId, string eventId, string eventDate)
        {
            _logger.Info("Total Rows in Incremental files: " + incremental.Rows.Count);
            _logger.Info("Total Rows in Accumulative files: " + cumulative.Rows.Count);

            var orderPairs = incremental.AsEnumerable().Select(x => new OrderedPair<string, string>(x.Field<string>(customerId), x.Field<string>(eventId)));

            var cumulativeEnumerable = cumulative.AsEnumerable();

            var query = (from a in cumulativeEnumerable
                         join o in orderPairs
                         on new { CustomerId = a.Field<string>(customerId), EventId = a.Field<string>(eventId) } equals new { CustomerId = o.FirstValue, EventId = o.SecondValue }
                         into jointData
                         from jointRecord in jointData.DefaultIfEmpty()
                         where jointRecord == null
                         select a).ToList();

            _logger.Info("Total Rows in Accumulative files after removing duplicate from incremental: " + query.Count);

            var incrementalFileArray = incremental.AsEnumerable();
            IEnumerable<DataRow> drows = null;
            if (query.Any())
            {
                query.AddRange(incrementalFileArray.AsEnumerable());
                drows = query;
            }
            else
            {
                drows = incrementalFileArray;
            }

            var dt = drows.AsEnumerable().OrderBy(column => column.Field<string>(eventDate))
                 .ThenBy(column => column.Field<string>(eventId))
                 .ThenBy(column => column.Field<string>(customerId))
                 .CopyToDataTable();
            _logger.Info("Final Number of Records: " + drows.Count());

            return dt;
        }

        public void CreateCumulativeFileAndPost(string incrementalFilePath, string cumulativeFilePath, string finalFilename)
        {
            var incrementalDataTable = CreateDataTable(incrementalFilePath);
            var cumulativeDataTable = CreateDataTable(cumulativeFilePath);

            DirectoryOperationsHelper.DeleteFileIfExist(finalFilename);

            _logger.Info("Cumulative file Path: " + cumulativeFilePath);
            _logger.Info("Incremental file Path: " + incrementalFilePath);
            _logger.Info("final file Path: " + finalFilename);

            if (cumulativeDataTable == null || cumulativeDataTable.Rows == null || cumulativeDataTable.Rows.Count <= 0)
            {
                if (incrementalDataTable != null && incrementalDataTable.Rows != null && incrementalDataTable.Rows.Count > 0)
                {
                    DirectoryOperationsHelper.DeleteFileIfExist(cumulativeFilePath);
                    DirectoryOperationsHelper.Copy(incrementalFilePath, cumulativeFilePath);
                    DirectoryOperationsHelper.Copy(cumulativeFilePath, finalFilename);
                }
            }
            else if (incrementalDataTable == null || incrementalDataTable.Rows == null || incrementalDataTable.Rows.Count <= 0)
            {
                if (cumulativeDataTable.Rows != null && cumulativeDataTable.Rows.Count > 0)
                {
                    DirectoryOperationsHelper.Copy(cumulativeFilePath, finalFilename);
                }
            }
            else
            {
                var nameOfCustomerIdColumn = GetColumnName(cumulativeDataTable, "Id_$$");
                var nameOfEventIdColumn = GetColumnName(cumulativeDataTable, "Event Id_$$");
                var nameOfEventDateColumn = GetColumnName(cumulativeDataTable, "Event Date_$$");

                var tempAccumulativeDataTable = CreateAccumulativeDataTable(cumulativeDataTable, incrementalDataTable, nameOfCustomerIdColumn, nameOfEventIdColumn, nameOfEventDateColumn);

                if (tempAccumulativeDataTable != null && tempAccumulativeDataTable.Rows != null &&
                    tempAccumulativeDataTable.Rows.Count > 0)
                {
                    if (DirectoryOperationsHelper.IsFileExist(cumulativeFilePath))
                    {
                        _logger.Info("Final Record: " + tempAccumulativeDataTable.Rows.Count);
                    }

                    _csvReader.ConvertDataTableToCsv(tempAccumulativeDataTable, cumulativeFilePath, "_$$");

                    if (DirectoryOperationsHelper.IsFileExist(cumulativeFilePath))
                    {
                        _logger.Info("Final Record: " + tempAccumulativeDataTable.Rows.Count);
                    }

                    if (DirectoryOperationsHelper.IsDirectoryExist(Path.GetDirectoryName(cumulativeFilePath)))
                    {
                        _logger.Info("cumulativeFilePath: " + cumulativeFilePath + " exists");
                    }
                    else
                    {
                        _logger.Info("cumulativeFilePath: " + cumulativeFilePath + " Not exists");
                    }

                    DirectoryOperationsHelper.Copy(cumulativeFilePath, finalFilename);
                }
            }

        }

        private IEnumerable<OrderedPair<string, string>> GetAdditionalFields(LinqMetaData linqMetaData, long accountId, string[] showHiddenAdditionalFields)
        {
            return (from aaf in linqMetaData.AccountAdditionalFields
                    join af in linqMetaData.AdditionalFields on aaf.AdditionalFieldId equals af.Id
                    where aaf.AccountId == accountId && showHiddenAdditionalFields.Contains(aaf.DisplayName)
                    select new OrderedPair<string, string>() { FirstValue = af.Alias, SecondValue = aaf.DisplayName }).ToArray();
        }
    }
}