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
	/// <summary>Implements the static Relations variant for the entity: HealthPlanCallQueueCriteria. </summary>
	public partial class HealthPlanCallQueueCriteriaRelations
	{
		/// <summary>CTor</summary>
		public HealthPlanCallQueueCriteriaRelations()
		{
		}

		/// <summary>Gets all relations of the HealthPlanCallQueueCriteriaEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId);
			toReturn.Add(this.FillEventCallQueueCriteriaAssignmentEntityUsingCriteriaId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaAssignmentEntityUsingCriteriaId);
			toReturn.Add(this.HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId);
			toReturn.Add(this.HealthPlanCriteriaAssignmentUploadEntityUsingCriteriaId);
			toReturn.Add(this.HealthPlanCriteriaDirectMailEntityUsingCriteriaId);
			toReturn.Add(this.HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId);
			toReturn.Add(this.HealthPlanFillEventCallQueueEntityUsingCriteriaId);
			toReturn.Add(this.LanguageBarrierCallQueueCriteriaAssignmentEntityUsingCriteriaId);
			toReturn.Add(this.MailRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId);
			toReturn.Add(this.NoShowCallQueueCriteriaAssignmentEntityUsingCriteriaId);
			toReturn.Add(this.UncontactedCustomerCallQueueCriteriaAssignmentEntityUsingCriteriaId);

			toReturn.Add(this.AccountEntityUsingHealthPlanId);
			toReturn.Add(this.CallQueueEntityUsingCallQueueId);
			toReturn.Add(this.CampaignEntityUsingCampaignId);
			toReturn.Add(this.LanguageEntityUsingLanguageId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and CallRoundCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - CallRoundCallQueueCriteriaAssignment.CriteriaId
		/// </summary>
		public virtual IEntityRelation CallRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallRoundCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, CallRoundCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and FillEventCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - FillEventCallQueueCriteriaAssignment.CriteriaId
		/// </summary>
		public virtual IEntityRelation FillEventCallQueueCriteriaAssignmentEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FillEventCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, FillEventCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FillEventCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and HealthPlanCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - HealthPlanCallQueueCriteriaAssignment.CriteriaId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaAssignmentEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, HealthPlanCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and HealthPlanCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - HealthPlanCriteriaAssignment.HealthPlanCriteriaId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and HealthPlanCriteriaAssignmentUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - HealthPlanCriteriaAssignmentUpload.CriteriaId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaAssignmentUploadEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaAssignmentUpload" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, HealthPlanCriteriaAssignmentUploadFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and HealthPlanCriteriaDirectMailEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - HealthPlanCriteriaDirectMail.CriteriaId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaDirectMailEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaDirectMail" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, HealthPlanCriteriaDirectMailFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaDirectMailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and HealthPlanCriteriaTeamAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - HealthPlanCriteriaTeamAssignment.HealthPlanCriteriaId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaTeamAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, HealthPlanCriteriaTeamAssignmentFields.HealthPlanCriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaTeamAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and HealthPlanFillEventCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - HealthPlanFillEventCallQueue.CriteriaId
		/// </summary>
		public virtual IEntityRelation HealthPlanFillEventCallQueueEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanFillEventCallQueue" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, HealthPlanFillEventCallQueueFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanFillEventCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and LanguageBarrierCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - LanguageBarrierCallQueueCriteriaAssignment.CriteriaId
		/// </summary>
		public virtual IEntityRelation LanguageBarrierCallQueueCriteriaAssignmentEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LanguageBarrierCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, LanguageBarrierCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and MailRoundCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - MailRoundCallQueueCriteriaAssignment.CriteriaId
		/// </summary>
		public virtual IEntityRelation MailRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MailRoundCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, MailRoundCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MailRoundCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and NoShowCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - NoShowCallQueueCriteriaAssignment.CriteriaId
		/// </summary>
		public virtual IEntityRelation NoShowCallQueueCriteriaAssignmentEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NoShowCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, NoShowCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoShowCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and UncontactedCustomerCallQueueCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.Id - UncontactedCustomerCallQueueCriteriaAssignment.CriteriaId
		/// </summary>
		public virtual IEntityRelation UncontactedCustomerCallQueueCriteriaAssignmentEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UncontactedCustomerCallQueueCriteriaAssignment" , true);
				relation.AddEntityFieldPair(HealthPlanCallQueueCriteriaFields.Id, UncontactedCustomerCallQueueCriteriaAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UncontactedCustomerCallQueueCriteriaAssignmentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and AccountEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.HealthPlanId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Account", false);
				relation.AddEntityFieldPair(AccountFields.AccountId, HealthPlanCallQueueCriteriaFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and CallQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.CallQueueId - CallQueue.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueue", false);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, HealthPlanCallQueueCriteriaFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and CampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.CampaignId - Campaign.Id
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Campaign", false);
				relation.AddEntityFieldPair(CampaignFields.Id, HealthPlanCallQueueCriteriaFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and LanguageEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.LanguageId - Language.Id
		/// </summary>
		public virtual IEntityRelation LanguageEntityUsingLanguageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Language", false);
				relation.AddEntityFieldPair(LanguageFields.Id, HealthPlanCallQueueCriteriaFields.LanguageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCallQueueCriteriaFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanCallQueueCriteriaEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanCallQueueCriteria.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser__", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCallQueueCriteriaFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", true);
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
