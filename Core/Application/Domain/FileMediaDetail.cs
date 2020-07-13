using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Application.Domain
{
    public class FileMediaDetail : DomainObjectBase
    {
        public string FilePathName { get; set; }
        public Byte[] TransactionContext { get; set; }
    }
}
