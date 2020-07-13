///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:41
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
	/// <summary>Implements the static Relations variant for the entity: HealthPlanCriteriaAssignmentUpload. </summary>
	public partial class HealthPlanCriteriaAssignmentUploadRelations
	{
		/// <summary>CTor</summary>
		public HealthPlanCriteriaAssignmentUploadRelations()
		{
		}

		/// <summary>Gets all relations of the HealthPlanCriteriaAssignmentUploadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.FileEntityUsingFileId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingCriteriaId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUploadedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HealthPlanCriteriaAssignmentUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCriteriaAssignmentUpload.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, HealthPlanCriteriaAssignmentUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanCriteriaAssignmentUploadEntity and HealthPlanCallQueueCriteriaEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCriteriaAssignmentUpload.CriteriaId - HealthPlanCallQueueCriteria.Id
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HealthPlanCallQueueCriteria", false);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, HealthPlanCriteriaAssignmentUploadFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanCriteriaAssignmentUploadEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCriteriaAssignmentUpload.UploadedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUploadedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCriteriaAssignmentUploadFields.UploadedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentUploadEntity", true);
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
