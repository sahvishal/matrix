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
	/// <summary>Implements the static Relations variant for the entity: Check. </summary>
	public partial class CheckRelations
	{
		/// <summary>CTor</summary>
		public CheckRelations()
		{
		}

		/// <summary>Gets all relations of the CheckEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CheckPaymentEntityUsingCheckId);
			toReturn.Add(this.EcheckPaymentEntityUsingEcheckId);
			toReturn.Add(this.MVPaymentCheckDetailsEntityUsingCheckId);

			toReturn.Add(this.OrganizationRoleUserEntityUsingDataRecoderModifierId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingDataRecoderCreatorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CheckEntity and CheckPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Check.CheckId - CheckPayment.CheckId
		/// </summary>
		public virtual IEntityRelation CheckPaymentEntityUsingCheckId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckPayment" , true);
				relation.AddEntityFieldPair(CheckFields.CheckId, CheckPaymentFields.CheckId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CheckEntity and EcheckPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Check.CheckId - EcheckPayment.EcheckId
		/// </summary>
		public virtual IEntityRelation EcheckPaymentEntityUsingEcheckId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EcheckPayment" , true);
				relation.AddEntityFieldPair(CheckFields.CheckId, EcheckPaymentFields.EcheckId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EcheckPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CheckEntity and MVPaymentCheckDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Check.CheckId - MVPaymentCheckDetails.CheckId
		/// </summary>
		public virtual IEntityRelation MVPaymentCheckDetailsEntityUsingCheckId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MvpaymentCheckDetails" , true);
				relation.AddEntityFieldPair(CheckFields.CheckId, MVPaymentCheckDetailsFields.CheckId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MVPaymentCheckDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CheckEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Check.DataRecoderModifierId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingDataRecoderModifierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CheckFields.DataRecoderModifierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CheckEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Check.DataRecoderCreatorId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingDataRecoderCreatorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CheckFields.DataRecoderCreatorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", true);
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
