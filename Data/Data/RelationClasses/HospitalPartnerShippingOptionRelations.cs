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
	/// <summary>Implements the static Relations variant for the entity: HospitalPartnerShippingOption. </summary>
	public partial class HospitalPartnerShippingOptionRelations
	{
		/// <summary>CTor</summary>
		public HospitalPartnerShippingOptionRelations()
		{
		}

		/// <summary>Gets all relations of the HospitalPartnerShippingOptionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.HospitalPartnerEntityUsingHospitalPartnerId);
			toReturn.Add(this.ShippingOptionEntityUsingShippingOptionId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerShippingOptionEntity and HospitalPartnerEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerShippingOption.HospitalPartnerId - HospitalPartner.HospitalPartnerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerEntityUsingHospitalPartnerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HospitalPartner", false);
				relation.AddEntityFieldPair(HospitalPartnerFields.HospitalPartnerId, HospitalPartnerShippingOptionFields.HospitalPartnerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerShippingOptionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerShippingOptionEntity and ShippingOptionEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerShippingOption.ShippingOptionId - ShippingOption.ShippingOptionId
		/// </summary>
		public virtual IEntityRelation ShippingOptionEntityUsingShippingOptionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShippingOption", false);
				relation.AddEntityFieldPair(ShippingOptionFields.ShippingOptionId, HospitalPartnerShippingOptionFields.ShippingOptionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingOptionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerShippingOptionEntity", true);
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
