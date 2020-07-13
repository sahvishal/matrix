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
	/// <summary>Implements the static Relations variant for the entity: ScheduleTemplateFranchiseeAccess. </summary>
	public partial class ScheduleTemplateFranchiseeAccessRelations
	{
		/// <summary>CTor</summary>
		public ScheduleTemplateFranchiseeAccessRelations()
		{
		}

		/// <summary>Gets all relations of the ScheduleTemplateFranchiseeAccessEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.OrganizationEntityUsingOrganizationId);
			toReturn.Add(this.ScheduleTemplateEntityUsingScheduleTemplateId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ScheduleTemplateFranchiseeAccessEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// ScheduleTemplateFranchiseeAccess.OrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, ScheduleTemplateFranchiseeAccessFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScheduleTemplateFranchiseeAccessEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ScheduleTemplateFranchiseeAccessEntity and ScheduleTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// ScheduleTemplateFranchiseeAccess.ScheduleTemplateId - ScheduleTemplate.ScheduleTemplateId
		/// </summary>
		public virtual IEntityRelation ScheduleTemplateEntityUsingScheduleTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ScheduleTemplate", false);
				relation.AddEntityFieldPair(ScheduleTemplateFields.ScheduleTemplateId, ScheduleTemplateFranchiseeAccessFields.ScheduleTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScheduleTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScheduleTemplateFranchiseeAccessEntity", true);
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
