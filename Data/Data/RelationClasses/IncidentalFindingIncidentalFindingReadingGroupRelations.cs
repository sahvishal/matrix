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
	/// <summary>Implements the static Relations variant for the entity: IncidentalFindingIncidentalFindingReadingGroup. </summary>
	public partial class IncidentalFindingIncidentalFindingReadingGroupRelations
	{
		/// <summary>CTor</summary>
		public IncidentalFindingIncidentalFindingReadingGroupRelations()
		{
		}

		/// <summary>Gets all relations of the IncidentalFindingIncidentalFindingReadingGroupEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.IncidentalFindingReadingGroupEntityUsingGroupId);
			toReturn.Add(this.IncidentalFindingsEntityUsingIncidentalFindingId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingIncidentalFindingReadingGroupEntity and IncidentalFindingReadingGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// IncidentalFindingIncidentalFindingReadingGroup.GroupId - IncidentalFindingReadingGroup.GroupId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingReadingGroupEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindingReadingGroup", false);
				relation.AddEntityFieldPair(IncidentalFindingReadingGroupFields.GroupId, IncidentalFindingIncidentalFindingReadingGroupFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingReadingGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingIncidentalFindingReadingGroupEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between IncidentalFindingIncidentalFindingReadingGroupEntity and IncidentalFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// IncidentalFindingIncidentalFindingReadingGroup.IncidentalFindingId - IncidentalFindings.IncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingsEntityUsingIncidentalFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindings", false);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, IncidentalFindingIncidentalFindingReadingGroupFields.IncidentalFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingIncidentalFindingReadingGroupEntity", true);
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
