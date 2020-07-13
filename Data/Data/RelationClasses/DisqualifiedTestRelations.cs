///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:42
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
	/// <summary>Implements the static Relations variant for the entity: DisqualifiedTest. </summary>
	public partial class DisqualifiedTestRelations
	{
		/// <summary>CTor</summary>
		public DisqualifiedTestRelations()
		{
		}

		/// <summary>Gets all relations of the DisqualifiedTestEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUpdatedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.PreQualificationQuestionEntityUsingQuestionId);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between DisqualifiedTestEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// DisqualifiedTest.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, DisqualifiedTestFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DisqualifiedTestEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// DisqualifiedTest.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, DisqualifiedTestFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DisqualifiedTestEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// DisqualifiedTest.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, DisqualifiedTestFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DisqualifiedTestEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// DisqualifiedTest.UpdatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, DisqualifiedTestFields.UpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DisqualifiedTestEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// DisqualifiedTest.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, DisqualifiedTestFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DisqualifiedTestEntity and PreQualificationQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// DisqualifiedTest.QuestionId - PreQualificationQuestion.Id
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PreQualificationQuestion", false);
				relation.AddEntityFieldPair(PreQualificationQuestionFields.Id, DisqualifiedTestFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DisqualifiedTestEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// DisqualifiedTest.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, DisqualifiedTestFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", true);
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
