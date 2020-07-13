using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Medical;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.CallQueues.Impl;
using Falcon.App.UI.Areas.CallCenter.Controllers;
using NUnit.Framework;
using Falcon.App.Infrastructure.Application.Impl;
namespace Falcon.Web.IntegrationTests.Infrastructure.CallCenter
{
    [TestFixture]
    public class CallQueueTester
    {
        private ICallQueuePollingAgent _resultCallQueuePollingAgent;
        private IUpsellCallQueueService _upsellCallQueueService;
        private ICallQueueCustomerHelper _callQueueCustomerHelper;
        private ConfirmationCallQueueService _confirmationCallQueueService;
        private ICallQueueRepository _callQueueRepository;
        private IEasiestToConvertCallQueueService _easiestToConvertCallQueueService;
        private IFillEventsCallQueueService _fillEventsCallQueueService;
        private ISystemGeneratedCallQueueCriteriaService _systemGeneratedCallQueueCriteriaService;
        private ISystemGeneratedCallQueueAssignmentRepository _systemGeneratedCallQueueAssignmentRepository;
        private IHealthPlanIncorrectPhoneExportPollingAgent _healthPlanCustomerPollingAgent;
        private IRapsUploadFileParserPollingAgent _rapsUploadFileParserPollingAgent;
        //private ILogger _logger;
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
            _resultCallQueuePollingAgent = IoC.Resolve<ICallQueuePollingAgent>();
            _upsellCallQueueService = IoC.Resolve<UpsellCallQueueService>();
            _callQueueCustomerHelper = IoC.Resolve<CallQueueCustomerHelper>();
            _confirmationCallQueueService = IoC.Resolve<ConfirmationCallQueueService>();
            _callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            _easiestToConvertCallQueueService = IoC.Resolve<IEasiestToConvertCallQueueService>();
            _fillEventsCallQueueService = IoC.Resolve<IFillEventsCallQueueService>();
            _systemGeneratedCallQueueCriteriaService = IoC.Resolve<ISystemGeneratedCallQueueCriteriaService>();
            _systemGeneratedCallQueueAssignmentRepository = IoC.Resolve<ISystemGeneratedCallQueueAssignmentRepository>();
            _healthPlanCustomerPollingAgent = IoC.Resolve<IHealthPlanIncorrectPhoneExportPollingAgent>();
            _rapsUploadFileParserPollingAgent = IoC.Resolve<IRapsUploadFileParserPollingAgent>();
            // _logger = IoC.Resolve<ILogger>();
        }

        [Test]
        public void GenerateCallqueue_Tester()
        {
            _resultCallQueuePollingAgent.SendCustomersOnCallQueue();
        }

        [Test]
        public void GenerateUpsellCallqueue_Tester()
        {
            var upsellId = 140;
            var criterias = _systemGeneratedCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(upsellId);
            criterias = criterias.Where(x => x.IsQueueGenerated == false);
            foreach (var criteria in criterias)
            {
                _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                var callQueueCustomers = _upsellCallQueueService.GetCallQueueCustomers(upsellId, criteria.Amount, criteria.NoOfDays);
                if (callQueueCustomers != null && callQueueCustomers.Any())
                {
                    _callQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(callQueueCustomers, criteria.Id);
                }

                criteria.IsQueueGenerated = true;
                criteria.LastQueueGeneratedDate = DateTime.Now;
                _systemGeneratedCallQueueCriteriaService.Save(criteria);
            }
        }
        [Test]
        public void GenerateConfirmationCallqueue_Tester()
        {
            var confirmationID = 140;
            var criterias = _systemGeneratedCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(confirmationID);
            // criterias = criterias.Where(x => x.IsQueueGenerated == true);
            foreach (var criteria in criterias)
            {
                _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                var callQueueCustomers = _confirmationCallQueueService.GetCallQueueCustomers(confirmationID, criteria.NoOfDays);
                if (callQueueCustomers != null && callQueueCustomers.Any())
                {
                    _callQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(callQueueCustomers, criteria.Id);

                }
                criteria.IsQueueGenerated = true;
                criteria.LastQueueGeneratedDate = DateTime.Now;
                _systemGeneratedCallQueueCriteriaService.Save(criteria);
            }
        }
        [Test]
        public void GenerateEasiestCallqueue_Tester()
        {
            var callQueues = _callQueueRepository.GetAll(false);
            var easy = callQueues.Where(x => x.Id == 88).First();
            var callQueueCustomers = _easiestToConvertCallQueueService.GetCallQueueCustomers(easy.Id, easy.LastQueueGeneratedDate);
            if (callQueueCustomers != null && callQueueCustomers.Any())
            {
                _callQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomers);
            }
        }
        [Test]
        public void GenerateFillEventCallqueue_Tester()
        {
            var criterias = _systemGeneratedCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(139);
            criterias = criterias.Where(x => x.IsQueueGenerated == false);
            foreach (var criteria in criterias)
            {
                _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                var callQueueCustomers = _fillEventsCallQueueService.GetCallQueueCustomers(139, criteria);
                if (callQueueCustomers != null && callQueueCustomers.Any())
                {
                    _callQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(callQueueCustomers, criteria.Id);

                }

                criteria.IsQueueGenerated = true;
                criteria.LastQueueGeneratedDate = DateTime.Now;
                _systemGeneratedCallQueueCriteriaService.Save(criteria);
            }

        }

        [Test]
        public void DeletePastEventCallQueueCustomerData_Tester()
        {
            //var callQueueCustomers = _fillEventsCallQueueService.GetCallQueueCustomers(91); ;

            //if (callQueueCustomers != null && callQueueCustomers.Any())
            //{
            //    _callQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomers);
            //}

        }
        [Test]
        public void DeleteAssignmentByCriteriaId_Tester()
        {
            _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(1);

        }

        [Test]
        public void GetName_Tester()
        {
            var mvc = Assembly.GetAssembly(typeof(CallQueueController));
            foreach (var type in mvc.GetTypes().Where(t => !t.IsAbstract && !t.IsInterface))
            {
                if (typeof(Controller).IsAssignableFrom(type))
                {
                    var methods = type.GetMethods();
                    //type.FullName.ToUpperInvariant()

                }
            }
        }

        [Test]
        public void GetHealthPlanExport_Tester()
        {
            _rapsUploadFileParserPollingAgent.PollForParsingRapsUpload();
        }
    }
}
