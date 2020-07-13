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
	/// <summary>Implements the static Relations variant for the entity: PackageSourceCodeDiscount. </summary>
	public partial class PackageSourceCodeDiscountRelations
	{
		/// <summary>CTor</summary>
		public PackageSourceCodeDiscountRelations()
		{
		}

		/// <summary>Gets all relations of the PackageSourceCodeDiscountEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CouponsEntityUsingSourceCodeId);
			toReturn.Add(this.PackageEntityUsingPackageId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PackageSourceCodeDiscountEntity and CouponsEntity over the m:1 relation they have, using the relation between the fields:
		/// PackageSourceCodeDiscount.SourceCodeId - Coupons.CouponId
		/// </summary>
		public virtual IEntityRelation CouponsEntityUsingSourceCodeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Coupons", false);
				relation.AddEntityFieldPair(CouponsFields.CouponId, PackageSourceCodeDiscountFields.SourceCodeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageSourceCodeDiscountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PackageSourceCodeDiscountEntity and PackageEntity over the m:1 relation they have, using the relation between the fields:
		/// PackageSourceCodeDiscount.PackageId - Package.PackageId
		/// </summary>
		public virtual IEntityRelation PackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Package", false);
				relation.AddEntityFieldPair(PackageFields.PackageId, PackageSourceCodeDiscountFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageSourceCodeDiscountEntity", true);
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
