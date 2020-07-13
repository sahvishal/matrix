using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.Impl
{
    public class CustomMultipartFormDataStreamProvider : MultipartStreamProvider
    {
        private readonly NameValueCollection _formData = new NameValueCollection();
        private readonly List<HttpContent> _fileContents = new List<HttpContent>();

        private readonly Collection<bool> _isFormData = new Collection<bool>();

        public NameValueCollection FormData
        {
            get { return _formData; }
        }

        public List<HttpContent> Files
        {
            get { return _fileContents; }
        }

        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            var contentDisposition = headers.ContentDisposition;
            if (contentDisposition != null)
            {
                _isFormData.Add(String.IsNullOrEmpty(contentDisposition.FileName));
                return new MemoryStream();
            }

            throw new InvalidOperationException(string.Format("Did not find required '{0}' header field in MIME multipart body part..", "Content-Disposition"));
        }

        public override async Task ExecutePostProcessingAsync()
        {
            for (var index = 0; index < Contents.Count; index++)
            {
                if (_isFormData[index])
                {
                    var formContent = Contents[index];
                    var contentDisposition = formContent.Headers.ContentDisposition;
                    var formFieldName = UnquoteToken(contentDisposition.Name) ?? String.Empty;

                    var formFieldValue = await formContent.ReadAsStringAsync();
                    FormData.Add(formFieldName, formFieldValue);
                }
                else
                {
                    _fileContents.Add(Contents[index]);
                }
            }
        }

        private static string UnquoteToken(string token)
        {
            if (String.IsNullOrWhiteSpace(token))
            {
                return token;
            }

            if (token.StartsWith("\"", StringComparison.Ordinal) && token.EndsWith("\"", StringComparison.Ordinal) && token.Length > 1)
            {
                return token.Substring(1, token.Length - 2);
            }

            return token;
        }
    }
}