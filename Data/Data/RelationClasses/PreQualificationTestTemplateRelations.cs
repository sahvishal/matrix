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
	/// <summary>Implements the static Relations variant for the entity: PreQualificationTestTemplate. </summary>
	public partial class PreQualificationTestTemplateRelations
	{
		/// <summary>CTor</summary>
		public PreQualificationTestTemplateRelations()
		{
		}

		/// <summary>Gets all relations of the PreQualificationTestTemplateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventTestEntityUsingPreQualificationQuestionTemplateId);
			toReturn.Add(this.PreQualificationTemplateDependentTestEntityUsingTemplateId);
			toReturn.Add(this.PreQualificationTemplateQuestionEntityUsingTemplateId);
			toReturn.Add(this.TestEntityUsingPreQualificationQuestionTemplateId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingUpdatedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between PreQualificationTestTemplateEntity and EventTestEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationTestTemplate.Id - EventTest.PreQualificationQuestionTemplateId
		/// </summary>
		public virtual IEntityRelation EventTestEntityUsingPreQualificationQuestionTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTest" , true);
				relation.AddEntityFieldPair(PreQualificationTestTemplateFields.Id, EventTestFields.PreQualificationQuestionTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PreQualificationTestTemplateEntity and PreQualificationTemplateDependentTestEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationTestTemplate.Id - PreQualificationTemplateDependentTest.TemplateId
		/// </summary>
		public virtual IEntityRelation PreQualificationTemplateDependentTestEntityUsingTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationTemplateDependentTest" , true);
				relation.AddEntityFieldPair(PreQualificationTestTemplateFields.Id, PreQualificationTemplateDependentTestFields.TemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTemplateDependentTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PreQualificationTestTemplateEntity and PreQualificationTemplateQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationTestTemplate.Id - PreQualificationTemplateQuestion.TemplateId
		/// </summary>
		public virtual IEntityRelation PreQualificationTemplateQuestionEntityUsingTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationTemplateQuestion" , true);
				relation.AddEntityFieldPair(PreQualificationTestTemplateFields.Id, PreQualificationTemplateQuestionFields.TemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTemplateQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between PreQualificationTestTemplateEntity and TestEntity over the 1:n relation they have, using the relation between the fields:
		/// PreQualificationTestTemplate.Id - Test.PreQualificationQuestionTemplateId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingPreQualificationQuestionTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Test_" , true);
				relation.AddEntityFieldPair(PreQualificationTestTemplateFields.Id, TestFields.PreQualificationQuestionTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between PreQualificationTestTemplateEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationTestTemplate.UpdatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreQualificationTestTemplateFields.UpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationTestTemplateEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationTestTemplate.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreQualificationTestTemplateFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationTestTemplateEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationTestTemplate.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, PreQualificationTestTemplateFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", true);
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
