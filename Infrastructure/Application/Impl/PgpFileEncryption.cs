using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class PgpFileEncryption : IPgpFileEncryption
    {
        public void EncryptFile(string outputFileName, string inputFileName, string encKeyFileName)
        {
            var encKey = ReadPublicKey(encKeyFileName);

            using (Stream output = File.Create(outputFileName))
            {
                EncryptFile(output, inputFileName, encKey, true, true);
            }
        }

        private void EncryptFile(Stream outputStream, string fileName, PgpPublicKey encKey, bool armor, bool withIntegrityCheck)
        {
            if (armor)
            {
                outputStream = new ArmoredOutputStream(outputStream);
            }

            try
            {
                var cPk = new PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag.Cast5, withIntegrityCheck, new SecureRandom());

                cPk.AddMethod(encKey);

                Stream cOut = cPk.Open(outputStream, new byte[1 << 16]);

                var comData = new PgpCompressedDataGenerator(CompressionAlgorithmTag.Zip);

                PgpUtilities.WriteFileToLiteralData(comData.Open(cOut), PgpLiteralData.Binary, new FileInfo(fileName), new byte[1 << 16]);

                comData.Close();

                cOut.Close();

                if (armor)
                {
                    outputStream.Close();
                }
            }
            catch (PgpException e)
            {
                var underlyingException = e.InnerException;
                if (underlyingException != null)
                {
                    throw e.InnerException;
                }

                throw;
            }
        }

        private PgpPublicKey ReadPublicKey(string fileName)
        {
            using (Stream keyIn = File.OpenRead(fileName))
            {
                return ReadPublicKey(keyIn);
            }
        }

        private PgpPublicKey ReadPublicKey(Stream input)
        {
            var pgpPub = new PgpPublicKeyRingBundle(PgpUtilities.GetDecoderStream(input));

            foreach (PgpPublicKeyRing keyRing in pgpPub.GetKeyRings())
            {
                foreach (PgpPublicKey key in keyRing.GetPublicKeys())
                {
                    if (key.IsEncryptionKey)
                    {
                        return key;
                    }
                }
            }

            throw new ArgumentException("Can't find encryption key in key ring.");
        }

    }
}
