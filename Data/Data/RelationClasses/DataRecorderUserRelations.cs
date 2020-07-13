///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Friday, June 19, 2009 12:36:25 PM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: DataRecorderUser. </summary>
	public partial class DataRecorderUserRelations
	{
		/// <summary>CTor</summary>
		public DataRecorderUserRelations()
		{
		}

		/// <summary>Gets all relations of the DataRecorderUserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CheckEntityUsingDataRecoderModifierId);
			toReturn.Add(this.CheckEntityUsingDataRecoderCreatorId);
			toReturn.Add(this.MVEarningEntityUsingDataRecoderCreatorId);
			toReturn.Add(this.MVEarningEntityUsingDataRecoderModifierId);
			toReturn.Add(this.MVPaymentEntityUsingDataRecoderCreatorId);
			toReturn.Add(this.MVPaymentEntityUsingDataRecoderModifierId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between DataRecorderUserEntity and CheckEntity over the 1:n relation they have, using the relation between the fields:
		/// DataRecorderUser.DataRecorderUserId - Check.DataRecoderModifierId
		/// </summary>
		public virtual IEntityRelation CheckEntityUsingDataRecoderModifierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Check_" , true);
				relation.AddEntityFieldPair(DataRecorderUserFields.DataRecorderUserId, CheckFields.DataRecoderModifierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DataRecorderUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DataRecorderUserEntity and CheckEntity over the 1:n relation they have, using the relation between the fields:
		/// DataRecorderUser.DataRecorderUserId - Check.DataRecoderCreatorId
		/// </summary>
		public virtual IEntityRelation CheckEntityUsingDataRecoderCreatorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Check" , true);
				relation.AddEntityFieldPair(DataRecorderUserFields.DataRecorderUserId, CheckFields.DataRecoderCreatorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DataRecorderUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DataRecorderUserEntity and MVEarningEntity over the 1:n relation they have, using the relation between the fields:
		/// DataRecorderUser.DataRecorderUserId - MVEarning.DataRecoderCreatorId
		/// </summary>
		public virtual IEntityRelation MVEarningEntityUsingDataRecoderCreatorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Mvearning" , true);
				relation.AddEntityFieldPair(DataRecorderUserFields.DataRecorderUserId, MVEarningFields.DataRecoderCreatorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DataRecorderUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MVEarningEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DataRecorderUserEntity and MVEarningEntity over the 1:n relation they have, using the relation between the fields:
		/// DataRecorderUser.DataRecorderUserId - MVEarning.DataRecoderModifierId
		/// </summary>
		public virtual IEntityRelation MVEarningEntityUsingDataRecoderModifierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Mvearning_" , true);
				relation.AddEntityFieldPair(DataRecorderUserFields.DataRecorderUserId, MVEarningFields.DataRecoderModifierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DataRecorderUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MVEarningEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DataRecorderUserEntity and MVPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// DataRecorderUser.DataRecorderUserId - MVPayment.DataRecoderCreatorId
		/// </summary>
		public virtual IEntityRelation MVPaymentEntityUsingDataRecoderCreatorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Mvpayment" , true);
				relation.AddEntityFieldPair(DataRecorderUserFields.DataRecorderUserId, MVPaymentFields.DataRecoderCreatorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DataRecorderUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MVPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DataRecorderUserEntity and MVPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// DataRecorderUser.DataRecorderUserId - MVPayment.DataRecoderModifierId
		/// </summary>
		public virtual IEntityRelation MVPaymentEntityUsingDataRecoderModifierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Mvpayment_" , true);
				relation.AddEntityFieldPair(DataRecorderUserFields.DataRecorderUserId, MVPaymentFields.DataRecoderModifierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DataRecorderUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MVPaymentEntity", false);
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
