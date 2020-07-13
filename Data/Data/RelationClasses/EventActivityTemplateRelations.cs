///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
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
	/// <summary>Implements the static Relations variant for the entity: EventActivityTemplate. </summary>
	public partial class EventActivityTemplateRelations
	{
		/// <summary>CTor</summary>
		public EventActivityTemplateRelations()
		{
		}

		/// <summary>Gets all relations of the EventActivityTemplateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventActivityTemplateCallEntityUsingEventActivityTemplateId);
			toReturn.Add(this.EventActivityTemplateEmailEntityUsingEventActivityTemplateId);
			toReturn.Add(this.EventActivityTemplateHostEntityUsingEventActivityTemplateId);
			toReturn.Add(this.EventActivityTemplateMeetingEntityUsingEventActivityTemplateId);
			toReturn.Add(this.EventActivityTemplateTaskEntityUsingEventActivityTemplateId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingOrganizationRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventActivityTemplateEntity and EventActivityTemplateCallEntity over the 1:n relation they have, using the relation between the fields:
		/// EventActivityTemplate.EventActivityTemplateId - EventActivityTemplateCall.EventActivityTemplateId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateCallEntityUsingEventActivityTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateCall" , true);
				relation.AddEntityFieldPair(EventActivityTemplateFields.EventActivityTemplateId, EventActivityTemplateCallFields.EventActivityTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventActivityTemplateEntity and EventActivityTemplateEmailEntity over the 1:n relation they have, using the relation between the fields:
		/// EventActivityTemplate.EventActivityTemplateId - EventActivityTemplateEmail.EventActivityTemplateId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateEmailEntityUsingEventActivityTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateEmail" , true);
				relation.AddEntityFieldPair(EventActivityTemplateFields.EventActivityTemplateId, EventActivityTemplateEmailFields.EventActivityTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEmailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventActivityTemplateEntity and EventActivityTemplateHostEntity over the 1:n relation they have, using the relation between the fields:
		/// EventActivityTemplate.EventActivityTemplateId - EventActivityTemplateHost.EventActivityTemplateId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateHostEntityUsingEventActivityTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateHost" , true);
				relation.AddEntityFieldPair(EventActivityTemplateFields.EventActivityTemplateId, EventActivityTemplateHostFields.EventActivityTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateHostEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventActivityTemplateEntity and EventActivityTemplateMeetingEntity over the 1:n relation they have, using the relation between the fields:
		/// EventActivityTemplate.EventActivityTemplateId - EventActivityTemplateMeeting.EventActivityTemplateId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateMeetingEntityUsingEventActivityTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateMeeting" , true);
				relation.AddEntityFieldPair(EventActivityTemplateFields.EventActivityTemplateId, EventActivityTemplateMeetingFields.EventActivityTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateMeetingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventActivityTemplateEntity and EventActivityTemplateTaskEntity over the 1:n relation they have, using the relation between the fields:
		/// EventActivityTemplate.EventActivityTemplateId - EventActivityTemplateTask.EventActivityTemplateId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateTaskEntityUsingEventActivityTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateTask" , true);
				relation.AddEntityFieldPair(EventActivityTemplateFields.EventActivityTemplateId, EventActivityTemplateTaskFields.EventActivityTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateTaskEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EventActivityTemplateEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventActivityTemplate.OrganizationRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventActivityTemplateFields.OrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEntity", true);
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
