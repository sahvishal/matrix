///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:08 AM
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
	/// <summary>Implements the static Relations variant for the entity: CarotidArteryTestFindings. </summary>
	public partial class CarotidArteryTestFindingsRelations
	{
		/// <summary>CTor</summary>
		public CarotidArteryTestFindingsRelations()
		{
		}

		/// <summary>Gets all relations of the CarotidArteryTestFindingsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CarotidArteryTestResultsEntityUsingRcarotidArteryTestFindingsId);
			toReturn.Add(this.CarotidArteryTestResultsEntityUsingLcarotidArteryTestFindingsId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestFindingsEntity and CarotidArteryTestResultsEntity over the 1:n relation they have, using the relation between the fields:
		/// CarotidArteryTestFindings.CarotidArteryTestFindingsId - CarotidArteryTestResults.RcarotidArteryTestFindingsId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestResultsEntityUsingRcarotidArteryTestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CarotidArteryTestResults_" , true);
				relation.AddEntityFieldPair(CarotidArteryTestFindingsFields.CarotidArteryTestFindingsId, CarotidArteryTestResultsFields.RcarotidArteryTestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestFindingsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CarotidArteryTestFindingsEntity and CarotidArteryTestResultsEntity over the 1:n relation they have, using the relation between the fields:
		/// CarotidArteryTestFindings.CarotidArteryTestFindingsId - CarotidArteryTestResults.LcarotidArteryTestFindingsId
		/// </summary>
		public virtual IEntityRelation CarotidArteryTestResultsEntityUsingLcarotidArteryTestFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CarotidArteryTestResults" , true);
				relation.AddEntityFieldPair(CarotidArteryTestFindingsFields.CarotidArteryTestFindingsId, CarotidArteryTestResultsFields.LcarotidArteryTestFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestFindingsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CarotidArteryTestResultsEntity", false);
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
