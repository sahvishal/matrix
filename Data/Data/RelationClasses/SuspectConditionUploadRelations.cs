///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:42
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
	/// <summary>Implements the static Relations variant for the entity: SuspectConditionUpload. </summary>
	public partial class SuspectConditionUploadRelations
	{
		/// <summary>CTor</summary>
		public SuspectConditionUploadRelations()
		{
		}

		/// <summary>Gets all relations of the SuspectConditionUploadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.SuspectConditionEntityUsingSuspectConditionUploadId);
			toReturn.Add(this.SuspectConditionUploadLogEntityUsingSuspectConditionUploadId);

			toReturn.Add(this.FileEntityUsingLogFileId);
			toReturn.Add(this.FileEntityUsingFileId);
			toReturn.Add(this.LookupEntityUsingStatusId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUploadedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SuspectConditionUploadEntity and SuspectConditionEntity over the 1:n relation they have, using the relation between the fields:
		/// SuspectConditionUpload.Id - SuspectCondition.SuspectConditionUploadId
		/// </summary>
		public virtual IEntityRelation SuspectConditionEntityUsingSuspectConditionUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SuspectCondition" , true);
				relation.AddEntityFieldPair(SuspectConditionUploadFields.Id, SuspectConditionFields.SuspectConditionUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SuspectConditionUploadEntity and SuspectConditionUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// SuspectConditionUpload.Id - SuspectConditionUploadLog.SuspectConditionUploadId
		/// </summary>
		public virtual IEntityRelation SuspectConditionUploadLogEntityUsingSuspectConditionUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SuspectConditionUploadLog" , true);
				relation.AddEntityFieldPair(SuspectConditionUploadFields.Id, SuspectConditionUploadLogFields.SuspectConditionUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadLogEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between SuspectConditionUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// SuspectConditionUpload.LogFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, SuspectConditionUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SuspectConditionUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// SuspectConditionUpload.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, SuspectConditionUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SuspectConditionUploadEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// SuspectConditionUpload.StatusId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, SuspectConditionUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SuspectConditionUploadEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// SuspectConditionUpload.UploadedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SuspectConditionUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", true);
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
