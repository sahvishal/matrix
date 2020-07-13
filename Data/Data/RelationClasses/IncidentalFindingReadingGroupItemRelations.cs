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
	/// <summary>Implements the static Relations variant for the entity: IncidentalFindingReadingGroupItem. </summary>
	public partial class IncidentalFindingReadingGroupItemRelations
	{
		/// <summary>CTor</summary>
		public IncidentalFindingReadingGroupItemRelations()
		{
		}

		/// <summary>Gets all relations of the IncidentalFindingReadingGroupItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerEventTestIncidentalFindingDetailEntityUsingGroupItemId);

			toReturn.Add(this.IncidentalFindingReadingGroupEntityUsingGroupId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingReadingGroupItemEntity and CustomerEventTestIncidentalFindingDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// IncidentalFindingReadingGroupItem.GroupItemId - CustomerEventTestIncidentalFindingDetail.GroupItemId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestIncidentalFindingDetailEntityUsingGroupItemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestIncidentalFindingDetail" , true);
				relation.AddEntityFieldPair(IncidentalFindingReadingGroupItemFields.GroupItemId, CustomerEventTestIncidentalFindingDetailFields.GroupItemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingReadingGroupItemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingDetailEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingReadingGroupItemEntity and IncidentalFindingReadingGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// IncidentalFindingReadingGroupItem.GroupId - IncidentalFindingReadingGroup.GroupId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingReadingGroupEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindingReadingGroup", false);
				relation.AddEntityFieldPair(IncidentalFindingReadingGroupFields.GroupId, IncidentalFindingReadingGroupItemFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingReadingGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingReadingGroupItemEntity", true);
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
