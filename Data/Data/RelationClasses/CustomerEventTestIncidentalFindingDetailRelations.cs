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
	/// <summary>Implements the static Relations variant for the entity: CustomerEventTestIncidentalFindingDetail. </summary>
	public partial class CustomerEventTestIncidentalFindingDetailRelations
	{
		/// <summary>CTor</summary>
		public CustomerEventTestIncidentalFindingDetailRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerEventTestIncidentalFindingDetailEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerEventTestIncidentalFindingEntityUsingCustomerEventTestIncidentalFindingId);
			toReturn.Add(this.IncidentalFindingReadingGroupItemEntityUsingGroupItemId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CustomerEventTestIncidentalFindingDetailEntity and CustomerEventTestIncidentalFindingEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventTestIncidentalFindingDetail.CustomerEventTestIncidentalFindingId - CustomerEventTestIncidentalFinding.CustomerEventTestIncidentalFindingId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestIncidentalFindingEntityUsingCustomerEventTestIncidentalFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventTestIncidentalFinding", false);
				relation.AddEntityFieldPair(CustomerEventTestIncidentalFindingFields.CustomerEventTestIncidentalFindingId, CustomerEventTestIncidentalFindingDetailFields.CustomerEventTestIncidentalFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingDetailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerEventTestIncidentalFindingDetailEntity and IncidentalFindingReadingGroupItemEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventTestIncidentalFindingDetail.GroupItemId - IncidentalFindingReadingGroupItem.GroupItemId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingReadingGroupItemEntityUsingGroupItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindingReadingGroupItem", false);
				relation.AddEntityFieldPair(IncidentalFindingReadingGroupItemFields.GroupItemId, CustomerEventTestIncidentalFindingDetailFields.GroupItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingReadingGroupItemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingDetailEntity", true);
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
