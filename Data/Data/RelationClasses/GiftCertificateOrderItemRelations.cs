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
	/// <summary>Implements the static Relations variant for the entity: GiftCertificateOrderItem. </summary>
	public partial class GiftCertificateOrderItemRelations
	{
		/// <summary>CTor</summary>
		public GiftCertificateOrderItemRelations()
		{
		}

		/// <summary>Gets all relations of the GiftCertificateOrderItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.GiftCertificateEntityUsingGiftCertificateId);
			toReturn.Add(this.OrderItemEntityUsingOrderItemId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between GiftCertificateOrderItemEntity and GiftCertificateEntity over the m:1 relation they have, using the relation between the fields:
		/// GiftCertificateOrderItem.GiftCertificateId - GiftCertificate.GiftCertificateId
		/// </summary>
		public virtual IEntityRelation GiftCertificateEntityUsingGiftCertificateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GiftCertificate", false);
				relation.AddEntityFieldPair(GiftCertificateFields.GiftCertificateId, GiftCertificateOrderItemFields.GiftCertificateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateOrderItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GiftCertificateOrderItemEntity and OrderItemEntity over the m:1 relation they have, using the relation between the fields:
		/// GiftCertificateOrderItem.OrderItemId - OrderItem.OrderItemId
		/// </summary>
		public virtual IEntityRelation OrderItemEntityUsingOrderItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrderItem", false);
				relation.AddEntityFieldPair(OrderItemFields.OrderItemId, GiftCertificateOrderItemFields.OrderItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderItemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GiftCertificateOrderItemEntity", true);
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
