using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Scheduling;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Scheduling.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class PollForAppointmentReminderViaSmsTester
    {
        private IPollForAppointmentReminderViaSms _appointmentReminderViaSmsPollingAgent;
        private IHealthPlanCallQueuePollingAgent _healthPlanCallQueuePollingAgent;
        private INoShowCallQueuePollingAgent _noShowCallQueuePollingAgent;
        private ICallRoundCallQueuePollingAgent _callRoundCallQueuePollingAgent;
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

        }

        [Test]
        public void AppointmentReminderViaSmsTester()
        {
            _appointmentReminderViaSmsPollingAgent = IoC.Resolve<PollForAppointmentReminderViaSms>();
            _appointmentReminderViaSmsPollingAgent.PollforSendingAppointmentReminderViaSms();
        }


        [Test]
        public void HealthPlanCallQueuePollingAgentTester()
        {
            _healthPlanCallQueuePollingAgent = IoC.Resolve<IHealthPlanCallQueuePollingAgent>();
            _healthPlanCallQueuePollingAgent.PollForHealthPlanCallQueue();
        }

        [Test]
        public void HealthPlanNoShowPollingAgentTester()
        {
            _noShowCallQueuePollingAgent = IoC.Resolve<INoShowCallQueuePollingAgent>();
            _noShowCallQueuePollingAgent.PollForCallQueue();
        }
          [Test]
        public void CallRoundCallQueuePollingAgentTester()
        {
            _callRoundCallQueuePollingAgent = IoC.Resolve<ICallRoundCallQueuePollingAgent>();
            _callRoundCallQueuePollingAgent.PollForCallQueue();
        }

    }
}