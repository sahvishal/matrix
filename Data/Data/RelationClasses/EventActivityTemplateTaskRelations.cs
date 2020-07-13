///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: EventActivityTemplateTask. </summary>
	public partial class EventActivityTemplateTaskRelations
	{
		/// <summary>CTor</summary>
		public EventActivityTemplateTaskRelations()
		{
		}

		/// <summary>Gets all relations of the EventActivityTemplateTaskEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventActivityTemplateEntityUsingEventActivityTemplateId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingResponsibleOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EventActivityTemplateTaskEntity and EventActivityTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// EventActivityTemplateTask.EventActivityTemplateId - EventActivityTemplate.EventActivityTemplateId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateEntityUsingEventActivityTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventActivityTemplate", false);
				relation.AddEntityFieldPair(EventActivityTemplateFields.EventActivityTemplateId, EventActivityTemplateTaskFields.EventActivityTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateTaskEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventActivityTemplateTaskEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventActivityTemplateTask.ResponsibleOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingResponsibleOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventActivityTemplateTaskFields.ResponsibleOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateTaskEntity", true);
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
