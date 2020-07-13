using System;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Marketing;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.Linq;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Linq;

namespace Falcon.App.Infrastructure.Repositories
{
    public class IncomingPhoneNumberResolverRule : PersistenceRepository, IIncomingPhoneNumberResolverRule
    {
        public IncomingPhoneNumberResolverRule(){}

        public IncomingPhoneNumberResolverRule(IPersistenceLayer persistenceLayer)
            : base(persistenceLayer)
        { }

        public string GetPhoneNumber(MarketingMaterialType printMaterial, AdvocateType advocateType)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var bucket = new RelationPredicateBucket(IncomingPhoneNumberResolverRuleFields.MarketingMaterialTypeId == (long) printMaterial);
                bucket.PredicateExpression.Add(IncomingPhoneNumberResolverRuleFields.AdvocateTypeId == advocateType);
                try
                {
                    var phoneNumber =
                        linqMetaData.IncomingPhoneNumberResolverRule.Where(
                            p =>
                            p.MarketingMaterialTypeId == (long) printMaterial && p.AdvocateTypeId == (long) advocateType)
                            .
                            Select(phone => phone.PhoneNumber).SingleOrDefault();
                    return phoneNumber;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }

            }
        }
    }
}