using System;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Domain
{
    public class DataRecorderMetaData
    {
        public OrganizationRoleUser DataRecorderCreator { get; set; }
        public OrganizationRoleUser DataRecorderModifier { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public DataRecorderMetaData(OrganizationRoleUser organizationRoleUser, DateTime dateCreated, DateTime? dateModified)
        {
            DataRecorderCreator = organizationRoleUser;
            DataRecorderModifier = organizationRoleUser;
            DateCreated = dateCreated;
            DateModified = dateModified;
        }

        public DataRecorderMetaData(long dataRecoderOrgRoleId, DateTime dateCreated, DateTime? dateModified)
        {
            var dataRecoder = new OrganizationRoleUser(dataRecoderOrgRoleId);
            DataRecorderCreator = dataRecoder;
            DataRecorderModifier = dataRecoder;
            DateCreated = dateCreated;
            DateModified = dateModified;
        }
        public DataRecorderMetaData()
        {
            
        }
    }
}