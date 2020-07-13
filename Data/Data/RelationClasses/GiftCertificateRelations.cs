///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
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
	/// <summary>Implements the static Relations variant for the entity: GiftCertificate. </summary>
	public partial class GiftCertificateRelations
	{
		/// <summary>CTor</summary>
		public GiftCertificateRelations()
		{
		}

		/// <summary>Gets all relations of the GiftCertificateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.GiftCertificateOrderItemEntityUsingGiftCertificateId);
			toReturn.Add(this.GiftCertificatePaymentEntityUsingGiftCertificateId);
			toReturn.Add(this.RefundRequestGiftCertificateEntityUsingGiftCertificateId);

			toReturn.Add(this.GiftCertificateTypeEntityUsingTypeId);
			toReturn.Add(this.PackageEntityUsingApplicablePackageId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GiftCertificateEntity and GiftCertificateOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// GiftCertificate.GiftCertificateId - GiftCertificateOrderItem.GiftCertificateId
		/// </summary>
		public virtual IEntityRelation GiftCertificateOrderItemEntityUsingGiftCertificateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GiftCertificateOrderItem" , true);
				relation.AddEntityFieldPair(GiftCertificateFields.GiftCertificateId, GiftCertificateOrderItemFields.GiftCertificateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GiftCertificateEntity and GiftCertificatePaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// GiftCertificate.GiftCertificateId - GiftCertificatePayment.GiftCertificateId
		/// </summary>
		public virtual IEntityRelation GiftCertificatePaymentEntityUsingGiftCertificateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GiftCertificatePayment" , true);
				relation.AddEntityFieldPair(GiftCertificateFields.GiftCertificateId, GiftCertificatePaymentFields.GiftCertificateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificatePaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GiftCertificateEntity and RefundRequestGiftCertificateEntity over the 1:n relation they have, using the relation between the fields:
		/// GiftCertificate.GiftCertificateId - RefundRequestGiftCertificate.GiftCertificateId
		/// </summary>
		public virtual IEntityRelation RefundRequestGiftCertificateEntityUsingGiftCertificateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RefundRequestGiftCertificate" , true);
				relation.AddEntityFieldPair(GiftCertificateFields.GiftCertificateId, RefundRequestGiftCertificateFields.GiftCertificateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestGiftCertificateEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GiftCertificateEntity and GiftCertificateTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// GiftCertificate.TypeId - GiftCertificateType.GiftCertificateTypeId
		/// </summary>
		public virtual IEntityRelation GiftCertificateTypeEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GiftCertificateType", false);
				relation.AddEntityFieldPair(GiftCertificateTypeFields.GiftCertificateTypeId, GiftCertificateFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GiftCertificateEntity and PackageEntity over the m:1 relation they have, using the relation between the fields:
		/// GiftCertificate.ApplicablePackageId - Package.PackageId
		/// </summary>
		public virtual IEntityRelation PackageEntityUsingApplicablePackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Package", false);
				relation.AddEntityFieldPair(PackageFields.PackageId, GiftCertificateFields.ApplicablePackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateEntity", true);
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
