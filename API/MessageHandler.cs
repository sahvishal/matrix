using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Falcon.App.Core.Application.Impl;

namespace API
{
    public class MessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return bool.Parse(ConfigurationManager.AppSettings["IsDevEnvironment"])
                            ? base.SendAsync(request, cancellationToken)
                            : base.SendAsync(DecryptedRequestStream(request), cancellationToken).ContinueWith((task => EncryptResponseMessage(task.Result)), cancellationToken);
        }

        private HttpResponseMessage EncryptResponseMessage(HttpResponseMessage response)
        {
            var content = response.Content as ObjectContent;

            if (content == null) return response;

            var key = GetResponseEncrypted(content.ReadAsStringAsync().Result);
            response.Content = new StringContent(key);

            return response;
        }

        private HttpRequestMessage DecryptedRequestStream(HttpRequestMessage request)
        {
            var mOriginalContentHeaders =
                            request.Content.Headers.Where(header => !header.Key.Equals("Content-Length"))
                                .ToDictionary(header => header.Key, header => header.Value.First());
            var newStream = new MemoryStream();
            var streamReader = new StreamReader(request.Content.ReadAsStreamAsync().Result);

            var streamWriter = new StreamWriter(newStream);
            streamWriter.Write(GetDecrptedRequest(streamReader.ReadToEnd()));
            streamWriter.Flush();

            newStream.Seek(0, SeekOrigin.Begin);

            request.Content = new StreamContent(newStream);

            foreach (var header in mOriginalContentHeaders)
            {
                request.Content.Headers.Add(header.Key, header.Value);
            }

            return request;
        }

        private string GetResponseEncrypted(string toEncrypt)
        {
            var dcService = new ApiCryptographyService();

            return dcService.Encrypt(toEncrypt);
        }

        private string GetDecrptedRequest(string encrypted)
        {
            var dcService = new ApiCryptographyService();

            var decryptedString = dcService.Decrypt(encrypted);

            return decryptedString;
        }
    }
}