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
	/// <summary>Implements the static Relations variant for the entity: StandardFinding. </summary>
	public partial class StandardFindingRelations
	{
		/// <summary>CTor</summary>
		public StandardFindingRelations()
		{
		}

		/// <summary>Gets all relations of the StandardFindingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.StandardFindingTestReadingEntityUsingStandardFindingId);

			toReturn.Add(this.LookupEntityUsingPathwayRecommendation);
			toReturn.Add(this.LookupEntityUsingResultInterpretation);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between StandardFindingEntity and StandardFindingTestReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// StandardFinding.StandardFindingId - StandardFindingTestReading.StandardFindingId
		/// </summary>
		public virtual IEntityRelation StandardFindingTestReadingEntityUsingStandardFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StandardFindingTestReading" , true);
				relation.AddEntityFieldPair(StandardFindingFields.StandardFindingId, StandardFindingTestReadingFields.StandardFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between StandardFindingEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// StandardFinding.PathwayRecommendation - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPathwayRecommendation
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, StandardFindingFields.PathwayRecommendation);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between StandardFindingEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// StandardFinding.ResultInterpretation - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingResultInterpretation
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, StandardFindingFields.ResultInterpretation);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingEntity", true);
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
