using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class ResultArchiveParserTester
    {
        private readonly MediaLocation _archiveLocation;

        public ResultArchiveParserTester()
        {
            DependencyRegistrar.RegisterDependencies();
            var mediaRepository = IoC.Resolve<IMediaRepository>();
            _archiveLocation = mediaRepository.GetResultArchiveMediaFileLocation(1234);
        }

        [Test]
        public void ExecuteParser()
        {

            bool hasSubDirectories = true;
            var currentPath = _archiveLocation.PhysicalPath;
            //read archive
            while (hasSubDirectories)
            {
                var dirs = Directory.GetDirectories(currentPath);
                foreach (var dir in dirs)
                {
                    if (dir.ToLower() == "biosound")
                    {
                        var biosoundParser = new BioSoundResultParser(currentPath + dir, IoC.Resolve<ISettings>(), 1234, IoC.Resolve<ILogManager>().GetLogger("Log_File_Tester"));
                        biosoundParser.Parse();
                        hasSubDirectories = false;
                    }
                }
            }
        }
        [Test]
        public void Dpn_Parser()
        {
            var dpn = new DpnParser("", 1234, IoC.Resolve<ILogManager>().GetLogger("DPN Tester"), true);
            dpn.GetMediaFromPdfFile(@"C:\Users\Admin\Desktop\batch\George Mathew.pdf", @"C:\Users\Admin\Desktop\batch\Archive\", TestType.DPN);
        }
    }
}