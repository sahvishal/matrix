using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation]
    public class RapsService : IRapsService
    {
        private readonly IRapsUploadRepository _rapsUploadRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public RapsService(IRapsUploadRepository rapsUploadRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _rapsUploadRepository = rapsUploadRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public IEnumerable<RapsUploadModel> GetUploadList(int pageNumber, int pageSize, RapsUploadListModelFilter filter,
            out int totalRecords)
        {

            var list = _rapsUploadRepository.GetUploadList(pageNumber, pageSize, filter, out totalRecords).ToArray();
            var uploadByIds = list.Select(c => c.UploadedBy).Distinct().ToArray();

            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair = null;

            if (uploadByIds != null && uploadByIds.Any())
            {
                uploadedbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(uploadByIds).ToArray();
            }
            foreach (var rapsUploadModel in list)
            { 
                if (uploadedbyAgentNameIdPair != null && uploadedbyAgentNameIdPair.Any())
                {
                    rapsUploadModel.UploadedName = uploadedbyAgentNameIdPair.Single(ap => ap.FirstValue == rapsUploadModel.UploadedBy).SecondValue;
                }
                
            }
            return list;
        }
    }
}
