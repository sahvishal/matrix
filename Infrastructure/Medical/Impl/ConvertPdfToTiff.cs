using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using WebSupergoo.ABCpdf10;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ConvertPdfToTiff : IConvertPdfToTiff
    {

        public void SavePdfAsTiffImage(string source, string destinationForTiff)
        {
            Doc theDoc = null;
            try
            {
                theDoc = new Doc();
                theDoc.Read(source);

                // set up the rendering parameters

                theDoc.Rendering.ColorSpace = XRendering.ColorSpaceType.Gray;

                theDoc.Rendering.BitsPerChannel = 8;

                theDoc.Rendering.DotsPerInch = 200;

                var pageCount = theDoc.PageCount;

                for (int pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                {

                    theDoc.PageNumber = pageNumber;

                    theDoc.Rect.String = theDoc.CropBox.String;

                    theDoc.Rendering.SaveAppend = (pageNumber != 1);

                    theDoc.Rendering.SaveCompression = XRendering.Compression.LZW;

                    theDoc.Rendering.Save(destinationForTiff);

                }

            }
            finally
            {
                theDoc.Clear();
                theDoc.Dispose();
            }

        }
    }
}