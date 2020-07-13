using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using System.IO;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IResultParser))]
    public class ResultParser : IResultParser
    {
        private readonly long _resultArchiveId;
        private readonly string _compressedFolderPath;

        private const string NameforBiosoundFolder = "biosound";
        private const string NameforCardioFolder = "cardiovision";
        private const string NameforGeFolder = "ge";
        private const string NameforBloodworksFolder = "bloodwork";
        private string _nameforEkgFolder = "schiller";
        private string _nameforEkgCardioCardFolder = "cardiocard";
        private const string NameforPftFolder = "pft";
        private const string NameforKynFolder = "kyn";
        private const string NameforSonoTransducerFolder = "sono";
        private const string AltNameforSonoTransducerFolder = "sonosite";
        private const string NameforEventfilesFolder = "eventfiles";

        private const string NameForAwvPreventionPlanFolder = "awvpp";
        private const string NameForAwvSnapShotFolder = "awvss";
        private const string NameforFloChecAbiParser = "flocheck";
        private const string NameForFocAttestationParser = "FOC";
        private const string NameforQuantaFloABIParser = "quantaflo";

        private string nameforSpiroFolder = "spi";
        private string NameForDpnFolder = "\\dpn\\datastore\\reports";


        private string _ekgFileParsertoUse;
        private string _pathforScannedFiles;

        private IResultArchiveUploadRepository _resultArchiveUploadRepository;
        private IResultArchiveUploadLogRepository _resultArchiveUploadLogRepository;
        private ILogger _logger;
        private IResultArchiveParser _bioSoundResultParser;
        private IResultArchiveParser _cardioResultParser;
        private IResultArchiveParser _bloodworksParser;
        private IResultArchiveParser _ekgParser;
        private IResultArchiveParser _geParser;
        private IResultArchiveParser _pftParser;
        private IResultArchiveParser _kynParser;
        private IResultArchiveParser _awvParser;
        private IResultArchiveParser _floChecABIParser;
        private IResultArchiveParser _focAttestationParser;
        private IResultArchiveParser _quantaFloAbiParser;
        private IResultArchiveParser _spiroParser;
        private IResultArchiveParser _dpnParser;


        private Service.TestResultService _testResultService;
        private IMediaRepository _mediaRepository;
        private ICustomerRepository _customerRepository;
        private ICorporateAccountRepository _corporateAccountRepository;
        private readonly IZipHelper _zipHelper;

        private ISettings _settings;
        private readonly IRepository<BasicBiometric> _basicBiometricRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ILipidParserHelper _lipidParserHelper;
        private readonly IEventEndofDayService _endofDayService;
        private readonly ICustomerService _customerService;
        private readonly IEventRepository _eventRepository;

        public ResultParser(long resultArchiveId, string compressedFolderPath, ICorporateAccountRepository corporateAccountRepository, IMediaRepository mediaRepository, IResultArchiveUploadRepository resultArchiveUploadRepository,
            IResultArchiveUploadLogRepository resultArchiveUploadLogRepository, ILogger logger, ISettings settings, ICustomerRepository customerRepository, IZipHelper zipHelper, IRepository<BasicBiometric> basicBiometricRepository,
            IEventCustomerRepository eventCustomerRepository, ILipidParserHelper lipidParserHelper, IEventEndofDayService endofDayService, ICustomerService customerService, IEventRepository eventRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _resultArchiveId = resultArchiveId;
            _compressedFolderPath = compressedFolderPath;
            _resultArchiveUploadRepository = resultArchiveUploadRepository;
            _resultArchiveUploadLogRepository = resultArchiveUploadLogRepository;
            _customerRepository = customerRepository;
            _logger = logger;
            _nameforEkgFolder = settings.EkgParserFolderRepresentation;
            _nameforEkgCardioCardFolder = settings.EkgCardioCardParserFolderRepresentation;
            _ekgFileParsertoUse = settings.EkgParsertoUse;
            _settings = settings;

            _mediaRepository = mediaRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _zipHelper = zipHelper;
            _customerService = customerService;
            _eventRepository = eventRepository;
            if (string.IsNullOrEmpty(_compressedFolderPath))
            {
                throw new InvalidOperationException("Can not extract data on a empty path!");
            }

            if (_resultArchiveId < 1)
            {
                throw new InvalidOperationException("Need to provide a valid database Id for the Archive to parse!");
            }

            _testResultService = new Service.TestResultService();
            _basicBiometricRepository = basicBiometricRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _lipidParserHelper = lipidParserHelper;
            _endofDayService = endofDayService;
        }

        public void Parse()
        {
            long eventId;
            long uploadedBy;
            try
            {
                var resultArchive = _resultArchiveUploadRepository.GetById(_resultArchiveId);
                eventId = resultArchive.EventId;
                uploadedBy = resultArchive.UploadedByOrgRoleUserId;

                var location = _mediaRepository.GetScannedDocumentStorageFileLocation(eventId);
                _pathforScannedFiles = location.PhysicalPath;
            }
            catch (ObjectNotFoundInPersistenceException<ResultArchive> ex)
            {
                //Put the log file entries here.
                _logger.Error("Invalid record provided for Parsing! Error: " + ex.Message + "\n\t" + ex.StackTrace);
                throw;
            }
            var isNewResultFlow = _eventRepository.IsEventHasNewResultFlow(eventId);

            string corpCode = "";

            try
            {
                var account = _corporateAccountRepository.GetForEventIdWithOrganizationDetail(eventId);
                if (account != null) corpCode = account.Name.Trim();
            }
            catch (Exception ex)
            {
                _logger.Error("Exception while getting corp code. Message: " + ex.Message);
            }

            while (true)
            {
                var bioSoundFolderPath = GetFolderPathfor(_compressedFolderPath, NameforBiosoundFolder);
                var cardioFolderPath = GetFolderPathfor(_compressedFolderPath, NameforCardioFolder);
                var bloodworksFolderPath = GetFolderPathfor(_compressedFolderPath, NameforBloodworksFolder);
                var ekgFolderPath = GetFolderPathfor(_compressedFolderPath, _nameforEkgFolder);
                var ekgCardioCardFolderPath = GetFolderPathfor(_compressedFolderPath, _nameforEkgCardioCardFolder);
                var geFolderPath = GetFolderPathfor(_compressedFolderPath, NameforGeFolder);
                var pftFolderPath = GetFolderPathfor(_compressedFolderPath, NameforPftFolder);
                var kynFolderPath = GetFolderPathfor(_compressedFolderPath, NameforKynFolder);
                var eventFilesPath = GetFolderPathfor(_compressedFolderPath, NameforEventfilesFolder);
                var ultrasoundTransducerPath = GetFolderPathfor(_compressedFolderPath, NameforSonoTransducerFolder);

                var awvPreventionPlanFolderPath = GetFolderPathfor(_compressedFolderPath, NameForAwvPreventionPlanFolder);
                var awvSnapShotFolder = GetFolderPathfor(_compressedFolderPath, NameForAwvSnapShotFolder);

                var floChecFolderPath = GetFolderPathfor(_compressedFolderPath, NameforFloChecAbiParser);
                var quantaFloFolderPath = GetFolderPathfor(_compressedFolderPath, NameforQuantaFloABIParser);

                var focAttestationPath = GetFolderPathfor(_compressedFolderPath, NameForFocAttestationParser);

                var SpiroFolderPath = GetFolderPathfor(_compressedFolderPath, nameforSpiroFolder);

                var dpnFolderPath = GetFolderPathfor(_compressedFolderPath, NameForDpnFolder, true);

                if (string.IsNullOrEmpty(ultrasoundTransducerPath))
                    ultrasoundTransducerPath = GetFolderPathfor(_compressedFolderPath, AltNameforSonoTransducerFolder);

                if (string.IsNullOrEmpty(bioSoundFolderPath) && string.IsNullOrEmpty(cardioFolderPath) && string.IsNullOrEmpty(bloodworksFolderPath) && string.IsNullOrEmpty(ekgFolderPath)
                    && string.IsNullOrEmpty(geFolderPath) && string.IsNullOrEmpty(pftFolderPath) && string.IsNullOrEmpty(kynFolderPath) && string.IsNullOrEmpty(eventFilesPath)
                    && string.IsNullOrEmpty(ultrasoundTransducerPath) && string.IsNullOrEmpty(awvPreventionPlanFolderPath) && string.IsNullOrEmpty(awvSnapShotFolder)
                    && string.IsNullOrEmpty(floChecFolderPath) && string.IsNullOrEmpty(focAttestationPath) && string.IsNullOrEmpty(quantaFloFolderPath) && string.IsNullOrEmpty(ekgCardioCardFolderPath)
                    && string.IsNullOrEmpty(SpiroFolderPath) && string.IsNullOrEmpty(dpnFolderPath)
                    )
                    break;

                if (!string.IsNullOrEmpty(bloodworksFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== Bloodworks Parsing - " + Directory.GetParent(bloodworksFolderPath).Name + "\\" + (new DirectoryInfo(bloodworksFolderPath)).Name + " ===========================================\n");

                        //_bloodworksParser = new BloodworksResultParser(bloodworksFolderPath, eventId, _logger, uploadedBy);
                        //var bloodworksCustomerScreeningData = _bloodworksParser.Parse();
                        //Save(bloodworksCustomerScreeningData, uploadedBy);
                        //SaveResultArchiveLogs(_bloodworksParser.ResultArchiveLogs);

                        _bloodworksParser = new BloodworksResultParser2(eventId, bloodworksFolderPath, _logger, _basicBiometricRepository, _eventCustomerRepository, uploadedBy, _lipidParserHelper);
                        var bloodworksCustomerScreeningData = _bloodworksParser.Parse();
                        Save(bloodworksCustomerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_bloodworksParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Bloodworks parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(bloodworksFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting Blood works folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(kynFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== KYN Parsing - " + Directory.GetParent(kynFolderPath).Name + "\\" + (new DirectoryInfo(kynFolderPath)).Name + " ===========================================\n");

                        _kynParser = new KynResultParser(eventId, corpCode, _resultArchiveId, kynFolderPath, _settings, _logger, _customerRepository, _basicBiometricRepository, _eventCustomerRepository, uploadedBy, _lipidParserHelper, _customerService);
                        var testData = _kynParser.Parse();
                        Save(testData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_kynParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("KYN parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(kynFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting Kyn folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(eventFilesPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== Moving Event Files - " + Directory.GetParent(eventFilesPath).Name + "\\" + (new DirectoryInfo(eventFilesPath)).Name + " ===========================================\n");
                        MoveEventFiles(eventFilesPath, _pathforScannedFiles);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Event Files: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                    finally
                    {
                        Directory.Delete(eventFilesPath, true);
                    }
                }

                if (!string.IsNullOrEmpty(ultrasoundTransducerPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== Ultrasound Transducer Parsing - " + Directory.GetParent(ultrasoundTransducerPath).Name + "\\" + (new DirectoryInfo(ultrasoundTransducerPath)).Name + " ===========================================\n");

                        var ultrasoundParser = new UltrasoundTransducerResultParser(ultrasoundTransducerPath, eventId, _logger, _settings);
                        var ultrasoundEventCustomerScreeningData = ultrasoundParser.Parse();
                        Save(ultrasoundEventCustomerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(ultrasoundParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Ultrasound Parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(ultrasoundTransducerPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting Ultrasound folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(bioSoundFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== BioSound Parsing - " + Directory.GetParent(bioSoundFolderPath).Name + "\\" + (new DirectoryInfo(bioSoundFolderPath)).Name + " ===========================================\n");

                        if (IsNewBiosoundRequired(bioSoundFolderPath, _logger))
                        {
                            _bioSoundResultParser = new BioSound2ResultParser(bioSoundFolderPath, eventId, _logger);
                            var bioSoundEventCustomerScreeningData = _bioSoundResultParser.Parse();
                            Save(bioSoundEventCustomerScreeningData, uploadedBy, isNewResultFlow);
                            SaveResultArchiveLogs(_bioSoundResultParser.ResultArchiveLogs);
                        }
                        else
                        {
                            _bioSoundResultParser = new BioSoundResultParser(bioSoundFolderPath, _settings, eventId, _logger);
                            var bioSoundEventCustomerScreeningData = _bioSoundResultParser.Parse();
                            Save(bioSoundEventCustomerScreeningData, uploadedBy, isNewResultFlow);
                            SaveResultArchiveLogs(_bioSoundResultParser.ResultArchiveLogs);
                        }


                    }
                    catch (Exception ex)
                    {
                        _logger.Error("BioSound parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(bioSoundFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting Biosound folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(pftFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== PFT Parsing - " + Directory.GetParent(pftFolderPath).Name + "\\" + (new DirectoryInfo(pftFolderPath)).Name + " ===========================================\n");

                        _pftParser = new PftFileParser(pftFolderPath, eventId, _logger);
                        var pftEventCustomerScreeningData = _pftParser.Parse();
                        Save(pftEventCustomerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_pftParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("PFT parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(pftFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting PFT folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(cardioFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== Cardiovision Parsing - " + Directory.GetParent(cardioFolderPath).Name + "\\" + (new DirectoryInfo(cardioFolderPath)).Name + " ===========================================\n");

                        _cardioResultParser = new CardiovisionResultParser(cardioFolderPath, eventId, _logger, isNewResultFlow);
                        var cardioEventCustomerScreeningData = _cardioResultParser.Parse();
                        Save(cardioEventCustomerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_cardioResultParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Cardiovision parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(cardioFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting Cardiovision folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }


                if (!string.IsNullOrEmpty(ekgFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== EKG Parsing - " + Directory.GetParent(ekgFolderPath).Name + "\\" + (new DirectoryInfo(ekgFolderPath)).Name + " ===========================================\n");

                        if (_ekgFileParsertoUse.ToLower().Equals("ekgfileparser2"))
                            _ekgParser = new EkgFileParser2(ekgFolderPath, eventId, _logger, _settings, isNewResultFlow);
                        else
                            _ekgParser = new EkgFileParser(ekgFolderPath, eventId, _logger);

                        var customerScreeningData = _ekgParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_ekgParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Ekg parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(ekgFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting EKG folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(geFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== GE Parsing - " + Directory.GetParent(geFolderPath).Name + "\\" + (new DirectoryInfo(geFolderPath)).Name + " ===========================================\n");

                        _geParser = new GeResultParser(eventId, geFolderPath, _logger, new ExcelReader());
                        var customerScreeningData = _geParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_geParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("GE parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(geFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting GE folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(awvPreventionPlanFolderPath) || !string.IsNullOrEmpty(awvSnapShotFolder))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(awvSnapShotFolder))
                            _logger.Info("\n\n\n====================================== AWV Test(s) Parsing - " + Directory.GetParent(awvSnapShotFolder).Name + "\\" + (new DirectoryInfo(awvSnapShotFolder)).Name + " ===========================================\n");
                        if (!string.IsNullOrEmpty(awvPreventionPlanFolderPath))
                            _logger.Info("\n\n\n====================================== AWV Test(s) Parsing - " + Directory.GetParent(awvPreventionPlanFolderPath).Name + "\\" + (new DirectoryInfo(awvPreventionPlanFolderPath)).Name + " ===========================================\n");

                        _awvParser = new AwvParser(awvPreventionPlanFolderPath, awvSnapShotFolder, eventId, _logger);

                        var customerScreeningData = _awvParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_awvParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("AWV Test(s) parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        if (!string.IsNullOrEmpty(awvSnapShotFolder))
                            Directory.Delete(awvSnapShotFolder, true);
                        if (!string.IsNullOrEmpty(awvPreventionPlanFolderPath))
                            Directory.Delete(awvPreventionPlanFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting AWV folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(floChecFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== FloChec-ABI Parsing - " + Directory.GetParent(floChecFolderPath).Name + "\\" + (new DirectoryInfo(floChecFolderPath)).Name + " ===========================================\n");


                        _floChecABIParser = new FloChecABIParser(floChecFolderPath, eventId, _logger, _mediaRepository);

                        var customerScreeningData = _floChecABIParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_floChecABIParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("FloChec-ABI parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(floChecFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting FloChec-ABI folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(quantaFloFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== QuantaFlo-ABI Parsing - " + Directory.GetParent(quantaFloFolderPath).Name + "\\" + (new DirectoryInfo(quantaFloFolderPath)).Name + " ===========================================\n");


                        _quantaFloAbiParser = new QuantaFloABIParser(quantaFloFolderPath, eventId, _logger, _mediaRepository);

                        var customerScreeningData = _quantaFloAbiParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_quantaFloAbiParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("QuantaFlo-ABI parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(quantaFloFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting QuantaFlo-ABI folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(focAttestationPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== FOC-Attestation Parsing - " + Directory.GetParent(focAttestationPath).Name + "\\" + (new DirectoryInfo(focAttestationPath)).Name + " ===========================================\n");

                        _focAttestationParser = new FOCAttestationParser(focAttestationPath, eventId, _logger, _mediaRepository);

                        var customerScreeningData = _focAttestationParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_focAttestationParser.ResultArchiveLogs);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error("FOC-Attestation Parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                    try
                    {
                        Directory.Delete(focAttestationPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting FOC-Attestation folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }


                if (!string.IsNullOrEmpty(ekgCardioCardFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== EKG Parsing - " + Directory.GetParent(ekgCardioCardFolderPath).Name + "\\" + (new DirectoryInfo(ekgCardioCardFolderPath)).Name + " ===========================================\n");

                        _ekgParser = new EkgCardioCardFileParser(ekgCardioCardFolderPath, eventId, _logger);

                        var customerScreeningData = _ekgParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_ekgParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Ekg parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(ekgCardioCardFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting EKG folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(SpiroFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== Spiro Parsing - " + Directory.GetParent(SpiroFolderPath).Name + "\\" + (new DirectoryInfo(SpiroFolderPath)).Name + " ===========================================\n");

                        _spiroParser = new SpiroParser(SpiroFolderPath, eventId, _logger);

                        var customerScreeningData = _spiroParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_spiroParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Spiro parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(SpiroFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting Spiro folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }

                if (!string.IsNullOrEmpty(dpnFolderPath))
                {
                    try
                    {
                        _logger.Info("\n\n\n====================================== DPN Parsing - " + Directory.GetParent(dpnFolderPath).Name + "\\" + (new DirectoryInfo(dpnFolderPath)).Name + " ===========================================\n");

                        _dpnParser = new DpnParser(dpnFolderPath, eventId, _logger, isNewResultFlow);

                        var customerScreeningData = _dpnParser.Parse();
                        Save(customerScreeningData, uploadedBy, isNewResultFlow);
                        SaveResultArchiveLogs(_dpnParser.ResultArchiveLogs);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("DPN parsing: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }

                    try
                    {
                        Directory.Delete(dpnFolderPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Deleting DPN folder: " + ex.Message + "\n" + ex.StackTrace, ex);
                    }
                }


                if (Directory.GetDirectories(_compressedFolderPath).Length < 1)
                    break;
            }
        }

        public string GetFolderPathfor(string pathtoLookInto, string folderTolookfor, bool forDpn = false)
        {
            // Need to provide a better pattern
            if (forDpn)
            {
                var directoryName = pathtoLookInto.ToLower();
                if (directoryName.Contains(folderTolookfor.ToLower())) return pathtoLookInto;
            }
            else
            {
                var directoryName = new DirectoryInfo(pathtoLookInto).Name.ToLower();
                if (directoryName == folderTolookfor.ToLower()) return pathtoLookInto;
            }

            foreach (string directory in Directory.GetDirectories(pathtoLookInto))
            {
                var path = GetFolderPathfor(directory, folderTolookfor, forDpn);
                if (!string.IsNullOrEmpty(path)) return path;
            }

            return string.Empty;
        }

        private void Save(IEnumerable<EventCustomerScreeningAggregate> eventCustomerScreeningAggregates, long uploadedBy, bool isNewResultFlow)
        {
            if (eventCustomerScreeningAggregates == null)
                return;

            foreach (var eventCustomerScreeningAggregate in eventCustomerScreeningAggregates)
            {
                SaveEventCustomerResult(eventCustomerScreeningAggregate.EventId,
                                        eventCustomerScreeningAggregate.CustomerId, uploadedBy);

                foreach (var testResult in eventCustomerScreeningAggregate.TestResults)
                {
                    testResult.IsNewResultFlow = isNewResultFlow;

                    SaveTestResult(testResult, eventCustomerScreeningAggregate.EventId, eventCustomerScreeningAggregate.CustomerId, uploadedBy, isNewResultFlow);
                }
            }
        }

        private static void SaveEventCustomerResult(long eventId, long customerId, long uploadedBy)
        {
            var eventCustomerResultRepository = new EventCustomerResultRepository();
            var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult == null)
            {
                eventCustomerResult = new EventCustomerResult
                {
                    CustomerId = customerId,
                    EventId = eventId,
                    DataRecorderMetaData =
                        new DataRecorderMetaData(uploadedBy, DateTime.Now, null)
                };
                eventCustomerResultRepository.Save(eventCustomerResult);
            }
        }

        private void SaveTestResult(TestResult testResult, long eventId, long customerId, long uploadedBy, bool isNewResultFlow)
        {
            if (isNewResultFlow)
                testResult.ResultStatus = new TestResultState { StateNumber = (int)NewTestResultStateNumber.ResultEntryPartial };
            else
                testResult.ResultStatus = new TestResultState { StateNumber = (int)TestResultStateNumber.ResultsUploaded };
            testResult.DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = new OrganizationRoleUser(uploadedBy), DateCreated = DateTime.Now };

            try
            {
                _testResultService.SaveTestResult(testResult, eventId, customerId, uploadedBy, _logger, ReadingSource.Automatic);
            }
            catch
            {
                //Already recorded.
            }
        }

        private void SaveResultArchiveLogs(IEnumerable<ResultArchiveLog> logs)
        {
            foreach (ResultArchiveLog log in logs)
            {
                log.ResultArchiveId = _resultArchiveId;
                _resultArchiveUploadLogRepository.Save(log);
            }
        }

        private void MoveEventFiles(string sourceDirectoryPath, string destDirectoryPath)
        {
            if (!Directory.Exists(destDirectoryPath))
                Directory.CreateDirectory(destDirectoryPath);

            var files = Directory.GetFiles(sourceDirectoryPath);
            foreach (var filePath in files)
            {
                var fileName = Path.GetFileName(filePath);

                if (File.Exists(destDirectoryPath + fileName)) File.Delete(destDirectoryPath + fileName);

                File.Move(filePath, destDirectoryPath + fileName);
            }
            var location = _mediaRepository.GetScannedDocumentStorageFolderLocation();
            var eventId = Directory.GetParent(destDirectoryPath).Name;
            _zipHelper.CreateZipFiles(destDirectoryPath, location.PhysicalPath + eventId + ".zip", true);
        }


        private bool IsNewBiosoundRequired(string folderPath, ILogger logger)
        {
            try
            {
                if (!Directory.Exists(folderPath)) return false;

                var childDirectories = Directory.GetDirectories(folderPath);

                if (!childDirectories.Any()) return false;
                var firstDirectories = childDirectories.First();

                var dInfo = new DirectoryInfo(firstDirectories.ToLower()).Name.ToLower();
                var temp = dInfo.Substring(dInfo.IndexOf("_id_") + 4);

                var customerIdString = temp.Substring(0, temp.IndexOf("_"));

                long customerId = 0;

                long.TryParse(customerIdString, out customerId);

                return customerId > 0;

            }
            catch (Exception)
            {
                logger.Error(string.Format("file Name {0} does not requried New Parser", folderPath));
            }

            return false;
        }
    }
}