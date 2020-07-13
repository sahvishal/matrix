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
	/// <summary>Implements the static Relations variant for the entity: HafTemplate. </summary>
	public partial class HafTemplateRelations
	{
		/// <summary>CTor</summary>
		public HafTemplateRelations()
		{
		}

		/// <summary>Gets all relations of the HafTemplateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountEntityUsingClinicalQuestionTemplateId);
			toReturn.Add(this.ClinicalTestQualificationCriteriaEntityUsingTemplateId);
			toReturn.Add(this.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId);
			toReturn.Add(this.EventPackageDetailsEntityUsingHafTemplateId);
			toReturn.Add(this.EventsEntityUsingHafTemplateId);
			toReturn.Add(this.EventTestEntityUsingHafTemplateId);
			toReturn.Add(this.HafTemplateQuestionEntityUsingHaftemplateId);
			toReturn.Add(this.HospitalPartnerEntityUsingHafTemplateId);
			toReturn.Add(this.PackageEntityUsingHafTemplateId);
			toReturn.Add(this.TestEntityUsingHafTemplateId);

			toReturn.Add(this.LookupEntityUsingCategory);
			toReturn.Add(this.LookupEntityUsingType);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - Account.ClinicalQuestionTemplateId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingClinicalQuestionTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, AccountFields.ClinicalQuestionTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and ClinicalTestQualificationCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - ClinicalTestQualificationCriteria.TemplateId
		/// </summary>
		public virtual IEntityRelation ClinicalTestQualificationCriteriaEntityUsingTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClinicalTestQualificationCriteria" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, ClinicalTestQualificationCriteriaFields.TemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClinicalTestQualificationCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and CustomerClinicalQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - CustomerClinicalQuestionAnswer.ClinicalQuestionTemplateId
		/// </summary>
		public virtual IEntityRelation CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerClinicalQuestionAnswer" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, CustomerClinicalQuestionAnswerFields.ClinicalQuestionTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerClinicalQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and EventPackageDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - EventPackageDetails.HafTemplateId
		/// </summary>
		public virtual IEntityRelation EventPackageDetailsEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPackageDetails" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, EventPackageDetailsFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - Events.HafTemplateId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, EventsFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and EventTestEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - EventTest.HafTemplateId
		/// </summary>
		public virtual IEntityRelation EventTestEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTest" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, EventTestFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and HafTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - HafTemplateQuestion.HaftemplateId
		/// </summary>
		public virtual IEntityRelation HafTemplateQuestionEntityUsingHaftemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HafTemplateQuestion" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, HafTemplateQuestionFields.HaftemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and HospitalPartnerEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - HospitalPartner.HafTemplateId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartner" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, HospitalPartnerFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and PackageEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - Package.HafTemplateId
		/// </summary>
		public virtual IEntityRelation PackageEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Package" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, PackageFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and TestEntity over the 1:n relation they have, using the relation between the fields:
		/// HafTemplate.HaftemplateId - Test.HafTemplateId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Test" , true);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, TestFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HafTemplate.Category - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingCategory
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HafTemplateFields.Category);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HafTemplate.Type - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HafTemplateFields.Type);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// HafTemplate.ModifiedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HafTemplateFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HafTemplateEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// HafTemplate.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HafTemplateFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", true);
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
