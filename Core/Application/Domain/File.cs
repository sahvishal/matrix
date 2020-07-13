using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Application.Domain
{
    public class File : DomainObjectBase
    {
        public string Path { get; set; }
        public decimal FileSize { get; set; }
        public FileType Type { get; set; }
        public bool IsArchived { get; set; }

        public DateTime UploadedOn { get; set; }
        public OrganizationRoleUser UploadedBy { get; set; }

        public File()
        { }

        public File(long id)
            : base(id)
        { }
    }

    public enum FileType
    {
        Image = 46,
        Document = 47,
        FlatFiles = 48,
        Video = 51,
        Compressed = 88,
        Pdf = 182,
        Csv = 265,
        Txt = 422
    }

}
