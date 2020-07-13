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
	/// <summary>Implements the static Relations variant for the entity: IncidentalFindingReadingGroup. </summary>
	public partial class IncidentalFindingReadingGroupRelations
	{
		/// <summary>CTor</summary>
		public IncidentalFindingReadingGroupRelations()
		{
		}

		/// <summary>Gets all relations of the IncidentalFindingReadingGroupEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.IncidentalFindingIncidentalFindingReadingGroupEntityUsingGroupId);
			toReturn.Add(this.IncidentalFindingReadingGroupItemEntityUsingGroupId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingReadingGroupEntity and IncidentalFindingIncidentalFindingReadingGroupEntity over the 1:n relation they have, using the relation between the fields:
		/// IncidentalFindingReadingGroup.GroupId - IncidentalFindingIncidentalFindingReadingGroup.GroupId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingIncidentalFindingReadingGroupEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IncidentalFindingIncidentalFindingReadingGroup" , true);
				relation.AddEntityFieldPair(IncidentalFindingReadingGroupFields.GroupId, IncidentalFindingIncidentalFindingReadingGroupFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingReadingGroupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingIncidentalFindingReadingGroupEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingReadingGroupEntity and IncidentalFindingReadingGroupItemEntity over the 1:n relation they have, using the relation between the fields:
		/// IncidentalFindingReadingGroup.GroupId - IncidentalFindingReadingGroupItem.GroupId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingReadingGroupItemEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IncidentalFindingReadingGroupItem" , true);
				relation.AddEntityFieldPair(IncidentalFindingReadingGroupFields.GroupId, IncidentalFindingReadingGroupItemFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingReadingGroupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingReadingGroupItemEntity", false);
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
