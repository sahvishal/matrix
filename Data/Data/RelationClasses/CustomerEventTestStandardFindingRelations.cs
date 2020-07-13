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
	/// <summary>Implements the static Relations variant for the entity: CustomerEventTestStandardFinding. </summary>
	public partial class CustomerEventTestStandardFindingRelations
	{
		/// <summary>CTor</summary>
		public CustomerEventTestStandardFindingRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerEventTestStandardFindingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.StandardFindingTestReadingEntityUsingStandardFindingTestReadingId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CustomerEventTestStandardFindingEntity and CustomerEventScreeningTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventTestStandardFinding.CustomerEventScreeningTestId - CustomerEventScreeningTests.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventScreeningTests", false);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventTestStandardFindingFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStandardFindingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerEventTestStandardFindingEntity and StandardFindingTestReadingEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventTestStandardFinding.StandardFindingTestReadingId - StandardFindingTestReading.StandardFindingTestReadingId
		/// </summary>
		public virtual IEntityRelation StandardFindingTestReadingEntityUsingStandardFindingTestReadingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "StandardFindingTestReading", false);
				relation.AddEntityFieldPair(StandardFindingTestReadingFields.StandardFindingTestReadingId, CustomerEventTestStandardFindingFields.StandardFindingTestReadingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStandardFindingEntity", true);
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
