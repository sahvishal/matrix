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
	/// <summary>Implements the static Relations variant for the entity: TestUnableScreenReason. </summary>
	public partial class TestUnableScreenReasonRelations
	{
		/// <summary>CTor</summary>
		public TestUnableScreenReasonRelations()
		{
		}

		/// <summary>Gets all relations of the TestUnableScreenReasonEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerEventUnableScreenReasonEntityUsingTestUnableScreenReasonId);

			toReturn.Add(this.LookupEntityUsingUnableScreenReasonId);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TestUnableScreenReasonEntity and CustomerEventUnableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// TestUnableScreenReason.TestUnableScreenReasonId - CustomerEventUnableScreenReason.TestUnableScreenReasonId
		/// </summary>
		public virtual IEntityRelation CustomerEventUnableScreenReasonEntityUsingTestUnableScreenReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventUnableScreenReason" , true);
				relation.AddEntityFieldPair(TestUnableScreenReasonFields.TestUnableScreenReasonId, CustomerEventUnableScreenReasonFields.TestUnableScreenReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestUnableScreenReasonEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventUnableScreenReasonEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TestUnableScreenReasonEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// TestUnableScreenReason.UnableScreenReasonId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingUnableScreenReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestUnableScreenReasonFields.UnableScreenReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestUnableScreenReasonEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestUnableScreenReasonEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// TestUnableScreenReason.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, TestUnableScreenReasonFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestUnableScreenReasonEntity", true);
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
