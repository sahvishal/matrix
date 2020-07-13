///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:40
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
	/// <summary>Implements the static Relations variant for the entity: EventAccountTestHcpcsCode. </summary>
	public partial class EventAccountTestHcpcsCodeRelations
	{
		/// <summary>CTor</summary>
		public EventAccountTestHcpcsCodeRelations()
		{
		}

		/// <summary>Gets all relations of the EventAccountTestHcpcsCodeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.OrganizationEntityUsingAccountId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.TestHcpcsCodeEntityUsingTestHcpcsCodeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EventAccountTestHcpcsCodeEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAccountTestHcpcsCode.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventAccountTestHcpcsCodeFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAccountTestHcpcsCodeEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAccountTestHcpcsCode.AccountId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, EventAccountTestHcpcsCodeFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAccountTestHcpcsCodeEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAccountTestHcpcsCode.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAccountTestHcpcsCodeFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAccountTestHcpcsCodeEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAccountTestHcpcsCode.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAccountTestHcpcsCodeFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventAccountTestHcpcsCodeEntity and TestHcpcsCodeEntity over the m:1 relation they have, using the relation between the fields:
		/// EventAccountTestHcpcsCode.TestHcpcsCodeId - TestHcpcsCode.Id
		/// </summary>
		public virtual IEntityRelation TestHcpcsCodeEntityUsingTestHcpcsCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TestHcpcsCode", false);
				relation.AddEntityFieldPair(TestHcpcsCodeFields.Id, EventAccountTestHcpcsCodeFields.TestHcpcsCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", true);
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
