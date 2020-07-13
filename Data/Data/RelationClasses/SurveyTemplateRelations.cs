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
	/// <summary>Implements the static Relations variant for the entity: SurveyTemplate. </summary>
	public partial class SurveyTemplateRelations
	{
		/// <summary>CTor</summary>
		public SurveyTemplateRelations()
		{
		}

		/// <summary>Gets all relations of the SurveyTemplateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountEntityUsingSurveyTemplateId);
			toReturn.Add(this.EventSurveyTemplateEntityUsingSurveyTemplateId);
			toReturn.Add(this.SurveyTemplateQuestionEntityUsingTemplateId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SurveyTemplateEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// SurveyTemplate.Id - Account.SurveyTemplateId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingSurveyTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account" , true);
				relation.AddEntityFieldPair(SurveyTemplateFields.Id, AccountFields.SurveyTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SurveyTemplateEntity and EventSurveyTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// SurveyTemplate.Id - EventSurveyTemplate.SurveyTemplateId
		/// </summary>
		public virtual IEntityRelation EventSurveyTemplateEntityUsingSurveyTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventSurveyTemplate" , true);
				relation.AddEntityFieldPair(SurveyTemplateFields.Id, EventSurveyTemplateFields.SurveyTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSurveyTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SurveyTemplateEntity and SurveyTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// SurveyTemplate.Id - SurveyTemplateQuestion.TemplateId
		/// </summary>
		public virtual IEntityRelation SurveyTemplateQuestionEntityUsingTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyTemplateQuestion" , true);
				relation.AddEntityFieldPair(SurveyTemplateFields.Id, SurveyTemplateQuestionFields.TemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateQuestionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between SurveyTemplateEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// SurveyTemplate.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SurveyTemplateFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SurveyTemplateEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// SurveyTemplate.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SurveyTemplateFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", true);
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
