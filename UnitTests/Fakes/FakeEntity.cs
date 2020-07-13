using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Web.UnitTests.Fakes
{
    // Public instead of internal due to generics requiring access.
    public class FakeEntity : EntityBase2
    {
        public long Id { get; set; }

        public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
        {
            throw new NotImplementedException();
        }

        public override List<IEntityRelation> GetAllRelations()
        {
            throw new NotImplementedException();
        }

        public override RelationCollection GetRelationsForFieldOfType(string fieldName)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> CustomPropertiesOfType
        {
            get { throw new NotImplementedException(); }
        }

        public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
        {
            get { throw new NotImplementedException(); }
        }

        public override Dictionary<string, object> GetRelatedData()
        {
            throw new NotImplementedException();
        }

        public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
        {
            throw new NotImplementedException();
        }

        public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
        {
            throw new NotImplementedException();
        }

        public override List<IEntity2> GetDependingRelatedEntities()
        {
            throw new NotImplementedException();
        }

        public override List<IEntity2> GetDependentRelatedEntities()
        {
            throw new NotImplementedException();
        }

        public override List<IEntityCollection2> GetMemberEntityCollections()
        {
            throw new NotImplementedException();
        }
    }
}