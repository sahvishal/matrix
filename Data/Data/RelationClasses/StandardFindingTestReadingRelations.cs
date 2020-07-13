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
	/// <summary>Implements the static Relations variant for the entity: StandardFindingTestReading. </summary>
	public partial class StandardFindingTestReadingRelations
	{
		/// <summary>CTor</summary>
		public StandardFindingTestReadingRelations()
		{
		}

		/// <summary>Gets all relations of the StandardFindingTestReadingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerEventReadingEntityUsingStandardFindingTestReadingId);
			toReturn.Add(this.CustomerEventTestStandardFindingEntityUsingStandardFindingTestReadingId);

			toReturn.Add(this.ReadingEntityUsingReadingId);
			toReturn.Add(this.StandardFindingEntityUsingStandardFindingId);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between StandardFindingTestReadingEntity and CustomerEventReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// StandardFindingTestReading.StandardFindingTestReadingId - CustomerEventReading.StandardFindingTestReadingId
		/// </summary>
		public virtual IEntityRelation CustomerEventReadingEntityUsingStandardFindingTestReadingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventReading" , true);
				relation.AddEntityFieldPair(StandardFindingTestReadingFields.StandardFindingTestReadingId, CustomerEventReadingFields.StandardFindingTestReadingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventReadingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between StandardFindingTestReadingEntity and CustomerEventTestStandardFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// StandardFindingTestReading.StandardFindingTestReadingId - CustomerEventTestStandardFinding.StandardFindingTestReadingId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestStandardFindingEntityUsingStandardFindingTestReadingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestStandardFinding" , true);
				relation.AddEntityFieldPair(StandardFindingTestReadingFields.StandardFindingTestReadingId, CustomerEventTestStandardFindingFields.StandardFindingTestReadingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStandardFindingEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between StandardFindingTestReadingEntity and ReadingEntity over the m:1 relation they have, using the relation between the fields:
		/// StandardFindingTestReading.ReadingId - Reading.ReadingId
		/// </summary>
		public virtual IEntityRelation ReadingEntityUsingReadingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Reading", false);
				relation.AddEntityFieldPair(ReadingFields.ReadingId, StandardFindingTestReadingFields.ReadingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReadingEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between StandardFindingTestReadingEntity and StandardFindingEntity over the m:1 relation they have, using the relation between the fields:
		/// StandardFindingTestReading.StandardFindingId - StandardFinding.StandardFindingId
		/// </summary>
		public virtual IEntityRelation StandardFindingEntityUsingStandardFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "StandardFinding", false);
				relation.AddEntityFieldPair(StandardFindingFields.StandardFindingId, StandardFindingTestReadingFields.StandardFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between StandardFindingTestReadingEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// StandardFindingTestReading.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, StandardFindingTestReadingFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", true);
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
