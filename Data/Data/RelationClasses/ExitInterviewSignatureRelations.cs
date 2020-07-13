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
	/// <summary>Implements the static Relations variant for the entity: ExitInterviewSignature. </summary>
	public partial class ExitInterviewSignatureRelations
	{
		/// <summary>CTor</summary>
		public ExitInterviewSignatureRelations()
		{
		}

		/// <summary>Gets all relations of the ExitInterviewSignatureEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CheckListQuestionEntityUsingQuestionId);
			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.FileEntityUsingSignatureFileId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ExitInterviewSignatureEntity and CheckListQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// ExitInterviewSignature.QuestionId - CheckListQuestion.Id
		/// </summary>
		public virtual IEntityRelation CheckListQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListQuestion", false);
				relation.AddEntityFieldPair(CheckListQuestionFields.Id, ExitInterviewSignatureFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewSignatureEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ExitInterviewSignatureEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// ExitInterviewSignature.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ExitInterviewSignatureFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewSignatureEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ExitInterviewSignatureEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// ExitInterviewSignature.SignatureFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, ExitInterviewSignatureFields.SignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewSignatureEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ExitInterviewSignatureEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// ExitInterviewSignature.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ExitInterviewSignatureFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewSignatureEntity", true);
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
