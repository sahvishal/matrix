using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using openDicom.File;
using openDicom.Registry;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class DicomExtractor : IDicomExtractor
    {
        private DataElementDictionary _dataElementDictionary;
        private UidDictionary _uidDictionary;
        private readonly ILogger _logger;

        public DicomExtractor(ILogger logger)
        {
            _dataElementDictionary = new DataElementDictionary();
            _uidDictionary = new UidDictionary();
            _logger = logger;

            string path = Assembly.GetExecutingAssembly().Location;
            var fileInfo = new FileInfo(path);
            string dir = fileInfo.DirectoryName;

            _dataElementDictionary.LoadFrom(dir + "/dicom-elements-2007.dic", DictionaryFileFormat.BinaryFile);

            _uidDictionary.LoadFrom(dir + "/dicom-uids-2007.dic", DictionaryFileFormat.BinaryFile);

        }
        
        public void ProcessFiles(string folderPath)
        {
            if (!Directory.Exists(folderPath)) return;

            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                try
                {
                    PerformExtraction(filePath);
                }
                catch(Exception ex)
                {
                    _logger.Error(string.Concat("\nException caused while extracting Dicoms from File-Path [", filePath , "]. \n\tStack Trace: " + ex.StackTrace));
                }
            }
        }

        public string GetDirectoryContainingDicomFiles(string folderPath)
        {
            if (Directory.GetFiles(folderPath).Select(IsDicomFile).Any(result => result))
            {
                return folderPath;
            }

            foreach (var folder in Directory.GetDirectories(folderPath))
            {
                var path = GetDirectoryContainingDicomFiles(folder);
                if (!string.IsNullOrEmpty(path)) return path;
            }

            return string.Empty;
        }


        public IEnumerable<string> GetDirectoriesContainingDicomFiles(string folderPath)
        {
            var directories = new List<string>();
            if (Directory.GetFiles(folderPath).Select(IsDicomFile).Any(result => result))
            {
                directories.Add(folderPath);
            }

            foreach (var folder in Directory.GetDirectories(folderPath))
            {
                var directoriesContainingDicomFiles = GetDirectoriesContainingDicomFiles(folder);
                if (directoriesContainingDicomFiles != null && directoriesContainingDicomFiles.Count() > 0) directories.AddRange(directoriesContainingDicomFiles);
            }

            return directories;
        }


        private static bool IsDicomFile(string filePath)
        {
            if (DicomFile.IsDicomFile(filePath))
                return true;

            if (AcrNemaFile.IsAcrNemaFile(filePath))
                return true;

            return false;
        }

        private static void PerformExtraction(string filePath)
        {
            AcrNemaFile file;
            if (DicomFile.IsDicomFile(filePath))
                file = new DicomFile(filePath, false);
            else if (AcrNemaFile.IsAcrNemaFile(filePath))
                file = new AcrNemaFile(filePath, false);
            else
                return;

            string filename = new FileInfo(filePath).Name;
            string fileFolder = Directory.GetParent(filePath) + "\\" + filename + "_dicom";

            if (!Directory.Exists(fileFolder))
                Directory.CreateDirectory(fileFolder);

            ExtractDataandSave(fileFolder, file);

        }

        private static void ExtractDataandSave(string folderName, AcrNemaFile file)
        {
            var b = new XmlFile(file, true);
            b.SaveTo(folderName + "//XML_WithoutPD.xml");

            if (!file.HasPixelData) return;

            var pixelData = file.PixelData;

            int count = 0;

            foreach (var item in pixelData.ToBytesArray())
            {
                count++;
                try
                {
                    var ms = new MemoryStream(item);
                    Image img = Image.FromStream(ms);
                    img.Save(folderName + "//Image" + count + ".jpg");
                    img.Dispose();
                }
                catch
                {
                    count--;
                }

            }
        }
    }
}