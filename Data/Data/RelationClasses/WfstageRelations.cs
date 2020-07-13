///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:13 AM
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
	/// <summary>Implements the static Relations variant for the entity: Wfstage. </summary>
	public partial class WfstageRelations
	{
		/// <summary>CTor</summary>
		public WfstageRelations()
		{
		}

		/// <summary>Gets all relations of the WfstageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.WfsequenceEntityUsingWfstageId);
			toReturn.Add(this.WfstageActivityEntityUsingWfstageId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between WfstageEntity and WfsequenceEntity over the 1:n relation they have, using the relation between the fields:
		/// Wfstage.WfstageId - Wfsequence.WfstageId
		/// </summary>
		public virtual IEntityRelation WfsequenceEntityUsingWfstageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Wfsequence" , true);
				relation.AddEntityFieldPair(WfstageFields.WfstageId, WfsequenceFields.WfstageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfsequenceEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between WfstageEntity and WfstageActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// Wfstage.WfstageId - WfstageActivity.WfstageId
		/// </summary>
		public virtual IEntityRelation WfstageActivityEntityUsingWfstageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "WfstageActivity" , true);
				relation.AddEntityFieldPair(WfstageFields.WfstageId, WfstageActivityFields.WfstageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WfstageActivityEntity", false);
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
