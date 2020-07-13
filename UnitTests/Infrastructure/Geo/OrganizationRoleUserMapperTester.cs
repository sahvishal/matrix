using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Geo
{
    [TestFixture]
    public class OrganizationRoleUserMapperTester
    {
        private readonly IMapper<OrganizationRoleUser, OrganizationRoleUserEntity> _mapper = 
            new OrganizationRoleUserMapper();

        [Test]
        public void MapMapsEntityIdsToCorrectProperties()
        {
            var organizationRoleUserEntity = new OrganizationRoleUserEntity(1) 
                                                 {UserId = 2, RoleId = 3, OrganizationId = 4};
            
            OrganizationRoleUser organizationRoleUser = _mapper.Map(organizationRoleUserEntity);

            Assert.AreEqual(organizationRoleUserEntity.OrganizationRoleUserId, organizationRoleUser.Id);
            Assert.AreEqual(organizationRoleUserEntity.UserId, organizationRoleUser.UserId);
            Assert.AreEqual(organizationRoleUserEntity.RoleId, organizationRoleUser.RoleId);
            Assert.AreEqual(organizationRoleUserEntity.OrganizationId, organizationRoleUser.OrganizationId);
        }

        [Test]
        public void MapMapsIdsToCorrectProperties()
        {
            const long expectedUserId = 1;
            const long expectedRoleId = 2;
            const long expectedOrganizationId = 3;

            var organizationRoleUser = new OrganizationRoleUser(expectedUserId, expectedRoleId,
                expectedOrganizationId);

            OrganizationRoleUserEntity organizationRoleUserEntity = _mapper.Map(organizationRoleUser);

            Assert.AreEqual(expectedUserId, organizationRoleUserEntity.UserId);
            Assert.AreEqual(expectedRoleId, organizationRoleUserEntity.RoleId);
            Assert.AreEqual(expectedOrganizationId, organizationRoleUserEntity.OrganizationId);
        }
    }
}