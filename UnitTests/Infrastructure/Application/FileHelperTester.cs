using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Application
{
    [TestFixture]
    public class FileHelperTester
    {
        private IFileHelper _fileHelper;

        public FileHelperTester()
        {
            DependencyRegistrar.RegisterDependencies();
            _fileHelper = IoC.Resolve<IFileHelper>();
        }
     
      [Test]
      public void AddTimeStampToFileName_AddTimeStampToFile()
      {
         var actualFileName = _fileHelper.AddTimeStampToFileName("12345.zip");

          Assert.AreEqual(26,actualFileName.Length);
      }
    }
}