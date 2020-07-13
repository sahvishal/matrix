using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class AwvPrimaryCarePhysicianImportPollingAgent : IAwvPrimaryCarePhysicianImportPollingAgent
    {
        private const string IndividualPcpCode = "1";
        private const string OrganizationPcpCode = "2";

        private readonly ISettings _settings;
        private readonly ILogger _logger;

        private readonly IPrimaryCarePhysicianImportService _physicianImportService;
        private readonly ICsvReader _csvReader;
        private readonly IStateRepository _stateRepository;

        public AwvPrimaryCarePhysicianImportPollingAgent(ISettings settings, ILogManager logManager, IPrimaryCarePhysicianImportService physicianImportService, ICsvReader csvReader, IStateRepository stateRepository)
        {
            _settings = settings;
            _logger = logManager.GetLogger("Awv_Pcp_Import");

            _physicianImportService = physicianImportService;
            _csvReader = csvReader;
            _stateRepository = stateRepository;
        }

        public void PollForPcpImport()
        {
            var sourcePath = _settings.AwvPcpImportSourcePath;
            if (!Directory.Exists(sourcePath))
            {
                _logger.Info("Directory does not exist. Path:" + sourcePath);
                return;
            }

            var files = Directory.GetFiles(sourcePath, "*.csv");
            if (!files.Any())
            {
                _logger.Info("No file found");
                return;
            }

            foreach (var file in files)
            {
                _logger.Info("Importing data from file. Name : " + file);

                try
                {
                    //var pcpTable = _csvReader.ReadWithTextQualifier(file);
                    var pcpTables = _csvReader.ReadWithTextQualifierLargeData(file);
                    foreach (var pcpTable in pcpTables)
                    {
                        if (pcpTable.Rows.Count > 0)
                        {
                            var states = _stateRepository.GetAllStates();
                            var list = new List<long>();
                            foreach (DataRow row in pcpTable.Rows)
                            {
                                try
                                {
                                    var physicianMaster = GetPhysicianMaster(row);
                                    if (physicianMaster != null)
                                    {
                                        State state;
                                        try
                                        {
                                            state = states.First(s => s.Code.Trim().ToLower() == physicianMaster.PracticeState.Trim().ToLower() || s.Name.Trim().ToLower() == physicianMaster.PracticeState.Trim().ToLower());
                                        }
                                        catch (Exception)
                                        {
                                            _logger.Error(physicianMaster.PracticeState.Trim().ToLower());
                                            throw;
                                        }
                                        _physicianImportService.SavePhysicianMaster(physicianMaster, state.Id, state.CountryId);
                                        list.Add(physicianMaster.Id);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("Error while saving Physician. Message: " + ex.Message);
                                    _logger.Error("Stack Trace: " + ex.StackTrace);
                                }

                            }
                            _logger.Info("Number of physician parsed" + list.Count());
                        }
                    }

                    if (!Directory.Exists(_settings.AwvPcpImportArchivePath))
                        Directory.CreateDirectory(_settings.AwvPcpImportArchivePath);
                    File.Move(file, _settings.AwvPcpImportArchivePath + Path.GetFileName(file));
                    _logger.Info("Data imported from file. Name : " + file);
                }
                catch (Exception ex)
                {
                    _logger.Error("Error while reading csv file. Name : " + file);
                    _logger.Error("Message: " + ex.Message);
                    _logger.Error("Stack Trace: " + ex.StackTrace);
                }

            }
        }

        private PhysicianMaster GetPhysicianMaster(DataRow row)
        {
            var entityTypeCode = GetRowValue(row, "Entity Type Code");

            if (string.IsNullOrEmpty(entityTypeCode))
                return null;

            var physicianMaster = new PhysicianMaster();
            physicianMaster.Npi = GetRowValue(row, "NPI");

            if (entityTypeCode == IndividualPcpCode)
            {
                physicianMaster.LastName = GetRowValue(row, "Provider Last Name (Legal Name)");
                physicianMaster.FirstName = GetRowValue(row, "Provider First Name");
                physicianMaster.MiddleName = GetRowValue(row, "Provider Middle Name");
                physicianMaster.PrefixText = GetRowValue(row, "Provider Name Prefix Text");
                physicianMaster.SuffixText = GetRowValue(row, "Provider Name Suffix Text");
                physicianMaster.CredentialText = GetRowValue(row, "Provider Credential Text");
            }
            else if (entityTypeCode == OrganizationPcpCode)
            {
                physicianMaster.LastName = GetRowValue(row, "Authorized Official Last Name");
                physicianMaster.FirstName = GetRowValue(row, "Authorized Official First Name");
                physicianMaster.MiddleName = GetRowValue(row, "Authorized Official Middle Name");
            }

            physicianMaster.PracticeAddress1 = GetRowValue(row, "Provider First Line Business Practice Location Address");
            physicianMaster.PracticeAddress2 = GetRowValue(row, "Provider Second Line Business Practice Location Address");
            physicianMaster.PracticeCity = GetRowValue(row, "Provider Business Practice Location Address City Name");
            physicianMaster.PracticeState = GetRowValue(row, "Provider Business Practice Location Address State Name", false);
            physicianMaster.PracticeZip = GetRowValue(row, "Provider Business Practice Location Address Postal Code");

            if (physicianMaster.PracticeZip.Length > 5)
                physicianMaster.PracticeZip = physicianMaster.PracticeZip.Substring(0, 5);
            else if (physicianMaster.PracticeZip.Length == 4)
                physicianMaster.PracticeZip = "0" + physicianMaster.PracticeZip;
            else if (physicianMaster.PracticeZip.Length == 3)
                physicianMaster.PracticeZip = "00" + physicianMaster.PracticeZip;

            physicianMaster.PracticePhone = PhoneNumber.Create(GetRowValue(row, "Provider Business Practice Location Address Telephone Number"), PhoneNumberType.Office);
            physicianMaster.PracticeFax = PhoneNumber.Create(GetRowValue(row, "Provider Business Practice Location Address Fax Number"), PhoneNumberType.Unknown);

            physicianMaster.IsImported = true;
            physicianMaster.IsActive = true;
            return physicianMaster;
        }

        private static string GetRowValue(DataRow row, string fieldName, bool format = true)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            if (format)
                return FormatSentence(row[fieldName].ToString().Trim());
            return row[fieldName].ToString().Trim();
        }

        public static string FormatSentence(string source)
        {
            var words = source.Split(' ').Select(t => t.ToCharArray()).ToList();
            words.ForEach(t =>
            {
                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = i.Equals(0) ? char.ToUpper(t[i]) : char.ToLower(t[i]);
                }
            });
            return string.Join(" ", words.Select(t => new string(t)));
        }
    }
}
