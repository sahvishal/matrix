///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:06 AM
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
	/// <summary>Implements the static Relations variant for the entity: AaaunableScreenReason. </summary>
	public partial class AaaunableScreenReasonRelations
	{
		/// <summary>CTor</summary>
		public AaaunableScreenReasonRelations()
		{
		}

		/// <summary>Gets all relations of the AaaunableScreenReasonEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AaatestResultsEntityUsingAaatestId);
			toReturn.Add(this.UnableScreenReasonEntityUsingUnableScreenReasonId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AaaunableScreenReasonEntity and AaatestResultsEntity over the m:1 relation they have, using the relation between the fields:
		/// AaaunableScreenReason.AaatestId - AaatestResults.AaatestId
		/// </summary>
		public virtual IEntityRelation AaatestResultsEntityUsingAaatestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AaatestResults", false);
				relation.AddEntityFieldPair(AaatestResultsFields.AaatestId, AaaunableScreenReasonFields.AaatestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestResultsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaaunableScreenReasonEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AaaunableScreenReasonEntity and UnableScreenReasonEntity over the m:1 relation they have, using the relation between the fields:
		/// AaaunableScreenReason.UnableScreenReasonId - UnableScreenReason.UnableScreenReasonId
		/// </summary>
		public virtual IEntityRelation UnableScreenReasonEntityUsingUnableScreenReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UnableScreenReason", false);
				relation.AddEntityFieldPair(UnableScreenReasonFields.UnableScreenReasonId, AaaunableScreenReasonFields.UnableScreenReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UnableScreenReasonEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaaunableScreenReasonEntity", true);
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
