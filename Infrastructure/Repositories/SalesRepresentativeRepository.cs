using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class SalesRepresentativeRepository : PersistenceRepository, ISalesRepresentativeRepository
    {
        private readonly ISalesRepresentativeFactory _salesRepresentativeFactory;
        private readonly IUserRepository<User> _userRepository;

        public SalesRepresentativeRepository()
        {
            _userRepository = new UserRepository<User>();
            _salesRepresentativeFactory = new SalesRepresentativeFactory();
        }

        public SalesRepresentativeRepository(IPersistenceLayer persistenceLayer, ISalesRepresentativeFactory 
            salesRepresentativeFactory, IUserRepository<User> userRepository)
            : base(persistenceLayer)
        {
            _salesRepresentativeFactory = salesRepresentativeFactory;
            _userRepository = userRepository;
        }

        public List<SalesRepresentative> GetSalesRepresentativesForFranchisee(long organizationId)
        {
            var franchiseeFranchiseeUserView = new FranchiseeFranchiseeUserTypedView();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(FranchiseeFranchiseeUserFields.IsActive == true);
            bucket.PredicateExpression.Add(FranchiseeFranchiseeUserFields.OrganizationId == organizationId);
            bucket.PredicateExpression.Add(FranchiseeFranchiseeUserFields.RoleId == Roles.SalesRep);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(franchiseeFranchiseeUserView, bucket, false);
            }

            List<long> userIds = franchiseeFranchiseeUserView.AsEnumerable().Select(ffuv => ffuv.UserId).ToList();
            List<User> users = _userRepository.GetActiveSystemUsers(userIds);
            return _salesRepresentativeFactory.CreateSalesRepresentatives(franchiseeFranchiseeUserView, users);
        }

        public  List<SalesRepresentative> GetAllSalesRepresentatives()
        {
            var franchiseeFranchiseeUserView = new FranchiseeFranchiseeUserTypedView();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(FranchiseeFranchiseeUserFields.IsActive == true);
            bucket.PredicateExpression.Add(FranchiseeFranchiseeUserFields.RoleId == Roles.SalesRep);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(franchiseeFranchiseeUserView, bucket, false);
            }

            if (franchiseeFranchiseeUserView.AsEnumerable().Count() < 1) return null; // Might need to throw an exception

            List<long> userIds = franchiseeFranchiseeUserView.AsEnumerable().Select(ffuv => ffuv.UserId).ToList();
            List<User> users = _userRepository.GetUsers(userIds);
            return _salesRepresentativeFactory.CreateSalesRepresentatives(franchiseeFranchiseeUserView, users);
        }
    }
}