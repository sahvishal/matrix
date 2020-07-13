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
	/// <summary>Implements the static Relations variant for the entity: TestMedia. </summary>
	public partial class TestMediaRelations
	{
		/// <summary>CTor</summary>
		public TestMediaRelations()
		{
		}

		/// <summary>Gets all relations of the TestMediaEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.FileEntityUsingFileId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between TestMediaEntity and CustomerEventScreeningTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// TestMedia.CustomerEventScreeningTestId - CustomerEventScreeningTests.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventScreeningTests", false);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, TestMediaFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestMediaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TestMediaEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// TestMedia.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, TestMediaFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestMediaEntity", true);
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
