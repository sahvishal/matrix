using System.IO;
using Falcon.App.Core.Application;
using Zen.Barcode;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class BarCodeGenerator : IBarCodeGenerator
    {
        private const int BarHeight = 25;
        private const int BarWidth = 1;

        public byte[] GenerateCode39WithoutCheckSum(string plainText)
        {
            var code39BarcodeDraw = BarcodeDrawFactory.Code39WithoutChecksum;
            System.Drawing.Image outputImage = code39BarcodeDraw.Draw(plainText, BarHeight);
            var mem = new MemoryStream();
            outputImage.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);

            outputImage.Dispose();

            var byteArray = mem.ToArray();
            mem.Dispose();

            return byteArray;
        }

        public byte[] GenerateCode128WithoutCheckSum(string plainText)
        {
            var code128WithChecksum = BarcodeDrawFactory.Code128WithChecksum;
            System.Drawing.Image outputImage = code128WithChecksum.Draw(plainText, BarHeight, BarWidth);
            var mem = new MemoryStream();
            outputImage.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);

            outputImage.Dispose();

            var byteArray = mem.ToArray();
            mem.Dispose();

            return byteArray;
        }
    }
}