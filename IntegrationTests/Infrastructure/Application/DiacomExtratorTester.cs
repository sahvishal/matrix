using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
     [TestFixture]
    public class DiacomExtratorTester
    {
         private IDicomExtractor _diacomExtractor;
         private IMovieMaker _movieMaker;
         [SetUp]
         public void SetUp()
         {
             DependencyRegistrar.RegisterDependencies();
             var logger = IoC.Resolve<ILogManager>().GetLogger("Log_File_Tester");
             _diacomExtractor = new DicomExtractor(logger);
             _movieMaker = new MovieMaker(Assembly.GetExecutingAssembly().Location, logger);
         }

         [Test]
         public void GeneratePdfBasicTest()
         {
             const string tempPath = @"C:\Temp\Diacom\_C161947";

             _diacomExtractor.ProcessFiles(tempPath);
         }

         [Test]
         public void GenerateMoviefromImageGroupTest()
         {
             const string tempPath = @"D:\Project Docs\ResultArchives\24031\FRONT ROOM\ge\GEMS_IMG\2011_AUG\08\DiacomExtract\B88FCE02\";

             _movieMaker.GenerateMoviefromImageGroup(tempPath, tempPath);
         }

         [Test]
         public void GenerateFlvfromAviTest()
         {
             const string aviPath = @"D:\Project Docs\ResultArchives\24031\BACK ROOM\biosound\EKBATANI_SHAWN\20110808154617\EKBATANI_SHAWN_20110808154617_1548200.avi";
             const string destinationPath = @"D:\Project Docs\ResultArchives\24031\BACK ROOM\biosound\EKBATANI_SHAWN\20110808154617\";

             _movieMaker.GenerateMoviefromAvi(aviPath, destinationPath);
         }
    }
}