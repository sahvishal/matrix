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
	/// <summary>Implements the static Relations variant for the entity: ResultArchiveUploadLog. </summary>
	public partial class ResultArchiveUploadLogRelations
	{
		/// <summary>CTor</summary>
		public ResultArchiveUploadLogRelations()
		{
		}

		/// <summary>Gets all relations of the ResultArchiveUploadLogEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.ResultArchiveUploadEntityUsingResultArchiveUploadId);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ResultArchiveUploadLogEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// ResultArchiveUploadLog.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ResultArchiveUploadLogFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultArchiveUploadLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ResultArchiveUploadLogEntity and ResultArchiveUploadEntity over the m:1 relation they have, using the relation between the fields:
		/// ResultArchiveUploadLog.ResultArchiveUploadId - ResultArchiveUpload.ResultArchiveUploadId
		/// </summary>
		public virtual IEntityRelation ResultArchiveUploadEntityUsingResultArchiveUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ResultArchiveUpload", false);
				relation.AddEntityFieldPair(ResultArchiveUploadFields.ResultArchiveUploadId, ResultArchiveUploadLogFields.ResultArchiveUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultArchiveUploadEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultArchiveUploadLogEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ResultArchiveUploadLogEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// ResultArchiveUploadLog.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, ResultArchiveUploadLogFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultArchiveUploadLogEntity", true);
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
