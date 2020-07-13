///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using Falcon.Data;
using Falcon.Data.FactoryClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: EventTest. </summary>
	public partial class EventTestRelations
	{
		/// <summary>CTor</summary>
		public EventTestRelations()
		{
		}

		/// <summary>Gets all relations of the EventTestEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerOrderHistoryEntityUsingEventTestId);
			toReturn.Add(this.EventPackageTestEntityUsingEventTestId);
			toReturn.Add(this.EventTestOrderItemEntityUsingEventTestId);

			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.HafTemplateEntityUsingHafTemplateId);
			toReturn.Add(this.LookupEntityUsingResultEntryTypeId);
			toReturn.Add(this.LookupEntityUsingGroupId);
			toReturn.Add(this.LookupEntityUsingGender);
			toReturn.Add(this.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and CustomerOrderHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// EventTest.EventTestId - CustomerOrderHistory.EventTestId
		/// </summary>
		public virtual IEntityRelation CustomerOrderHistoryEntityUsingEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerOrderHistory" , true);
				relation.AddEntityFieldPair(EventTestFields.EventTestId, CustomerOrderHistoryFields.EventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerOrderHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and EventPackageTestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventTest.EventTestId - EventPackageTest.EventTestId
		/// </summary>
		public virtual IEntityRelation EventPackageTestEntityUsingEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPackageTest" , true);
				relation.AddEntityFieldPair(EventTestFields.EventTestId, EventPackageTestFields.EventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and EventTestOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// EventTest.EventTestId - EventTestOrderItem.EventTestId
		/// </summary>
		public virtual IEntityRelation EventTestOrderItemEntityUsingEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTestOrderItem" , true);
				relation.AddEntityFieldPair(EventTestFields.EventTestId, EventTestOrderItemFields.EventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestOrderItemEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventTest.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventTestFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and HafTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// EventTest.HafTemplateId - HafTemplate.HaftemplateId
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HafTemplate", false);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, EventTestFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventTest.ResultEntryTypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingResultEntryTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventTestFields.ResultEntryTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventTest.GroupId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventTestFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventTest.Gender - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventTestFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and PreQualificationTestTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// EventTest.PreQualificationQuestionTemplateId - PreQualificationTestTemplate.Id
		/// </summary>
		public virtual IEntityRelation PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PreQualificationTestTemplate", false);
				relation.AddEntityFieldPair(PreQualificationTestTemplateFields.Id, EventTestFields.PreQualificationQuestionTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventTestEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// EventTest.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, EventTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", true);
				return relation;
			}
		}

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
