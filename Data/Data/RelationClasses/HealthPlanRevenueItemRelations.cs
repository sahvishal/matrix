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
	/// <summary>Implements the static Relations variant for the entity: HealthPlanRevenueItem. </summary>
	public partial class HealthPlanRevenueItemRelations
	{
		/// <summary>CTor</summary>
		public HealthPlanRevenueItemRelations()
		{
		}

		/// <summary>Gets all relations of the HealthPlanRevenueItemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.HealthPlanRevenueEntityUsingHealthPlanRevenueId);
			toReturn.Add(this.PackageEntityUsingPackageId);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HealthPlanRevenueItemEntity and HealthPlanRevenueEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanRevenueItem.HealthPlanRevenueId - HealthPlanRevenue.Id
		/// </summary>
		public virtual IEntityRelation HealthPlanRevenueEntityUsingHealthPlanRevenueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HealthPlanRevenue", false);
				relation.AddEntityFieldPair(HealthPlanRevenueFields.Id, HealthPlanRevenueItemFields.HealthPlanRevenueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanRevenueItemEntity and PackageEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanRevenueItem.PackageId - Package.PackageId
		/// </summary>
		public virtual IEntityRelation PackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Package", false);
				relation.AddEntityFieldPair(PackageFields.PackageId, HealthPlanRevenueItemFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueItemEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HealthPlanRevenueItemEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// HealthPlanRevenueItem.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, HealthPlanRevenueItemFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueItemEntity", true);
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
