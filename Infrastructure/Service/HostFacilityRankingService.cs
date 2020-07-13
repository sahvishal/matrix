using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories.Host;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Users.Repositories;

namespace Falcon.App.Infrastructure.Service
{
    public class HostFacilityRankingService : IHostFacilityRankingService
    {
        private readonly IHostFacilityRankingRepository _hostFacilityRankingRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IRoleRepository _roleRepository;

        public HostFacilityRankingService()
        {
            _hostFacilityRankingRepository = new HostFacilityRankingRepository();
            _hostRepository = new HostRepository();
            _roleRepository = new RoleRepository();
        }

        public HostFacilityViability GetHostFacilityRankingByHSC(long hostId)
        {
            return _hostFacilityRankingRepository.GetHostFacilityRanking((long)Roles.SalesRep, hostId).LastOrDefault();
        }

        public HostFacilityViability GetHostFacilityRankingByTechnician(long hostId)
        {
            return _hostFacilityRankingRepository.GetHostFacilityRanking((long)Roles.Technician, hostId).LastOrDefault();
        }

        public HostFacilityViability GetHostFacilityRankingByFranchisee(long hostId)
        {
            return _hostFacilityRankingRepository.GetHostFacilityRanking((long)Roles.FranchiseeAdmin, hostId).LastOrDefault();
        }

        public HostFacilityViability SaveHostFacilityRanking(HostFacilityViability hostFacilityViability)
        {
            if (hostFacilityViability.CreatedBy.RoleId == (long)Roles.SalesRep)
            {
                var hostFacilityViabilityforHsc = GetHostFacilityRankingByHSC(hostFacilityViability.HostId);
                if (hostFacilityViabilityforHsc != null)
                {
                    if (hostFacilityViabilityforHsc.InternetAccess == hostFacilityViability.InternetAccess
                        && hostFacilityViabilityforHsc.NumberOfPlugPoints == hostFacilityViability.NumberOfPlugPoints
                        && hostFacilityViabilityforHsc.RoomNeedsCleared == hostFacilityViability.RoomNeedsCleared
                        && hostFacilityViabilityforHsc.RoomSize == hostFacilityViability.RoomSize
                        && hostFacilityViabilityforHsc.CreatedBy.Id == hostFacilityViability.CreatedBy.Id)
                        hostFacilityViability.Id = hostFacilityViabilityforHsc.Id;
                }
            }

            return _hostFacilityRankingRepository.Save(hostFacilityViability);
        }

        public HostFacilityViability GetHostFacilityViabilityforEventWizard(long hostId)
        {
            var hostFacilityViabilitybyHsc = GetHostFacilityRankingByHSC(hostId);
            var hostFacilityViabilitybyFranchisee = GetHostFacilityRankingByFranchisee(hostId);

            if (hostFacilityViabilitybyFranchisee == null && hostFacilityViabilitybyHsc == null) return null;

            if (hostFacilityViabilitybyFranchisee == null)
            {
                hostFacilityViabilitybyHsc.Ranking = null;
                hostFacilityViabilitybyHsc.Notes = "";
                return hostFacilityViabilitybyHsc;
            }
            else if (hostFacilityViabilitybyHsc == null)
            {
                return hostFacilityViabilitybyFranchisee;
            }


            hostFacilityViabilitybyHsc.Ranking = hostFacilityViabilitybyFranchisee.Ranking;
            hostFacilityViabilitybyHsc.Notes = hostFacilityViabilitybyFranchisee.Notes;
            return hostFacilityViabilitybyHsc;
        }

        public List<HostImage> GetHostFacilityImages(long hostId)
        {
            var hostImages = _hostRepository.GetHostImages(hostId);
            var hostFacilityImages = hostImages.FindAll(hostImage => hostImage.ImageType == HostImageType.HostInfrastructure);
            return hostFacilityImages;
        }

        public List<HostImage> GetHostFacilityImagesbyTechnician(long hostId)
        {
            var hostImages = GetHostFacilityImages(hostId);
            if (hostImages == null || hostImages.Count < 1) return null;
            var hostImagesByTechnician = hostImages.FindAll(hostImage => GetParentRoleIdByRoleId(hostImage.UploadedBy.RoleId) == (long)Roles.Technician);
            return hostImagesByTechnician;
        }

        public List<HostImage> GetHostFacilityImagesbyHSC(long hostId)
        {
            var hostImages = GetHostFacilityImages(hostId);
            if (hostImages == null || hostImages.Count < 1) return null;
            var hostImagesByHSC = hostImages.FindAll(hostImage => GetParentRoleIdByRoleId(hostImage.UploadedBy.RoleId) == (long)Roles.SalesRep);
            return hostImagesByHSC;
        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }

    }
}
