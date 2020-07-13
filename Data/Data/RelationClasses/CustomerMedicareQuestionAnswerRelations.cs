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
	/// <summary>Implements the static Relations variant for the entity: CustomerMedicareQuestionAnswer. </summary>
	public partial class CustomerMedicareQuestionAnswerRelations
	{
		/// <summary>CTor</summary>
		public CustomerMedicareQuestionAnswerRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerMedicareQuestionAnswerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.MedicareQuestionEntityUsingQuestionId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreateBy);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CustomerMedicareQuestionAnswerEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerMedicareQuestionAnswer.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CustomerMedicareQuestionAnswerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerMedicareQuestionAnswerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerMedicareQuestionAnswerEntity and MedicareQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerMedicareQuestionAnswer.QuestionId - MedicareQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation MedicareQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MedicareQuestion", false);
				relation.AddEntityFieldPair(MedicareQuestionFields.QuestionId, CustomerMedicareQuestionAnswerFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerMedicareQuestionAnswerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerMedicareQuestionAnswerEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerMedicareQuestionAnswer.CreateBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreateBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerMedicareQuestionAnswerFields.CreateBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerMedicareQuestionAnswerEntity", true);
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
