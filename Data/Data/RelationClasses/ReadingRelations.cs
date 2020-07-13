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
	/// <summary>Implements the static Relations variant for the entity: Reading. </summary>
	public partial class ReadingRelations
	{
		/// <summary>CTor</summary>
		public ReadingRelations()
		{
		}

		/// <summary>Gets all relations of the ReadingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.FraminghamCalculationSourceEntityUsingReadingId);
			toReturn.Add(this.MedicalHistoryReadingAssosciationEntityUsingReadingId);
			toReturn.Add(this.StandardFindingTestReadingEntityUsingReadingId);
			toReturn.Add(this.TestReadingEntityUsingReadingId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ReadingEntity and FraminghamCalculationSourceEntity over the 1:n relation they have, using the relation between the fields:
		/// Reading.ReadingId - FraminghamCalculationSource.ReadingId
		/// </summary>
		public virtual IEntityRelation FraminghamCalculationSourceEntityUsingReadingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FraminghamCalculationSource" , true);
				relation.AddEntityFieldPair(ReadingFields.ReadingId, FraminghamCalculationSourceFields.ReadingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReadingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FraminghamCalculationSourceEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReadingEntity and MedicalHistoryReadingAssosciationEntity over the 1:n relation they have, using the relation between the fields:
		/// Reading.ReadingId - MedicalHistoryReadingAssosciation.ReadingId
		/// </summary>
		public virtual IEntityRelation MedicalHistoryReadingAssosciationEntityUsingReadingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicalHistoryReadingAssosciation" , true);
				relation.AddEntityFieldPair(ReadingFields.ReadingId, MedicalHistoryReadingAssosciationFields.ReadingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReadingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicalHistoryReadingAssosciationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReadingEntity and StandardFindingTestReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// Reading.ReadingId - StandardFindingTestReading.ReadingId
		/// </summary>
		public virtual IEntityRelation StandardFindingTestReadingEntityUsingReadingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StandardFindingTestReading" , true);
				relation.AddEntityFieldPair(ReadingFields.ReadingId, StandardFindingTestReadingFields.ReadingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReadingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingTestReadingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReadingEntity and TestReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// Reading.ReadingId - TestReading.ReadingId
		/// </summary>
		public virtual IEntityRelation TestReadingEntityUsingReadingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestReading" , true);
				relation.AddEntityFieldPair(ReadingFields.ReadingId, TestReadingFields.ReadingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReadingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestReadingEntity", false);
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
