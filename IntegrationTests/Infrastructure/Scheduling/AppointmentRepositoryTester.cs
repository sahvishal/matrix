using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class AppointmentRepositoryTester
    {
        private const int ValidAppointmentId = 1;

        [SetUp]
        public void Setup()
        {
            DependencyRegistrar.RegisterDependencies();    
        }

        //[Test]
        //public void TemporarilyBookAppointmentSetStatusCorrectly()
        //{
        //    //setup            
        //    var appointmentRepository = IoC.Resolve<IAppointmentRepository>();

        //    //execute
        //    appointmentRepository.TemporarilyBookAppointment(ValidAppointmentId);
        //    var actualStatus = appointmentRepository.GetById(ValidAppointmentId).AppointmentStatus;

        //    //test
        //    Assert.AreEqual(AppointmentStatus.TemporarilyBooked, actualStatus);                        
        //}


        //[Test]
        //public void IsAppointmentTemporarilyBookedReturnsTemporarilyBookedCorrectly()
        //{
        //    //setup            
        //    var appointmentRepository = new AppointmentRepository(); // IoC.Resolve<IAppointmentRepository>();

        //    //execute
        //    var isBooked = appointmentRepository.IsAppointmentBooked(ValidAppointmentId);            

        //    //test
        //    Assert.AreEqual(true, isBooked);
        //}


        //[Test]
        //public void ReleaseTemporarilyBookedAppointmentReleasesSlotCorrectly()
        //{
        //    //setup            
        //    var appointmentRepository = new AppointmentRepository(); // IoC.Resolve<IAppointmentRepository>();

        //    //execute
        //    appointmentRepository.ReleaseTemporarilyBookedAppointments();
        //    var actualStatus = appointmentRepository.GetById(ValidAppointmentId).AppointmentStatus;

        //    //test
        //    Assert.AreEqual(AppointmentStatus.Free, actualStatus);
        //}

    }
}