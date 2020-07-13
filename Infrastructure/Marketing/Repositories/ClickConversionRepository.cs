using System;
using System.Linq;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Marketing.Repositories
{
    // A prospective customer has filled out some information.
    // A customer has signed up for an account.
    // An event customer has signed up for and paid for an event.
    public class ClickConversionRepository
        : PersistenceRepository, IClickConversionRepository
    {
        public void SaveProspectConversion(long clickId, long prospectCustomerId)
        {
            if (prospectCustomerId == 0 || clickId == 0)
                return;
            
            var cce = new ClickConversionEntity
            {
                ClickId = clickId,
                ProspectCustomerId = prospectCustomerId
            };            

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(cce))
                {
                    throw new PersistenceFailureException(
                        string.Format("Could not save conversion for click #{0}, prospect #{1}.", clickId, prospectCustomerId)
                    );
                }
            }
        }        

        public void SaveEventCustomerConversion(long prospectCustomerId, long eventCustomerId)
        {
            UpdateConversion(prospectCustomerId, c => c.EventCustomerId = eventCustomerId );
        }

        public void SaveCustomerConversion(long prospectCustomerId, long customerId)
        {
            UpdateConversion(prospectCustomerId, c => c.CustomerId = customerId);
        }

        public void UpdateConversion(long prospectCustomerId, Func<ClickConversionEntity, long?> func )
        {
            var clickConversions = new EntityCollection<ClickConversionEntity>();

            IRelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(ClickConversionFields.ProspectCustomerId == prospectCustomerId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(clickConversions, bucket);

                if (clickConversions.Count == 1)
                {
                    var clickConversion = clickConversions.Single();
                    func(clickConversion);
                    adapter.SaveEntity(clickConversion);
                }
            }
        }
    }
}