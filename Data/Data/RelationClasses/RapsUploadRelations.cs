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
	/// <summary>Implements the static Relations variant for the entity: RapsUpload. </summary>
	public partial class RapsUploadRelations
	{
		/// <summary>CTor</summary>
		public RapsUploadRelations()
		{
		}

		/// <summary>Gets all relations of the RapsUploadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.RapsEntityUsingRapsUploadId);
			toReturn.Add(this.RapsUploadLogEntityUsingRapsUploadId);

			toReturn.Add(this.FileEntityUsingLogFileId);
			toReturn.Add(this.FileEntityUsingFileId);
			toReturn.Add(this.LookupEntityUsingStatusId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUploadedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between RapsUploadEntity and RapsEntity over the 1:n relation they have, using the relation between the fields:
		/// RapsUpload.Id - Raps.RapsUploadId
		/// </summary>
		public virtual IEntityRelation RapsEntityUsingRapsUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Raps" , true);
				relation.AddEntityFieldPair(RapsUploadFields.Id, RapsFields.RapsUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RapsUploadEntity and RapsUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// RapsUpload.Id - RapsUploadLog.RapsUploadId
		/// </summary>
		public virtual IEntityRelation RapsUploadLogEntityUsingRapsUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RapsUploadLog" , true);
				relation.AddEntityFieldPair(RapsUploadFields.Id, RapsUploadLogFields.RapsUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadLogEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between RapsUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// RapsUpload.LogFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, RapsUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RapsUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// RapsUpload.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, RapsUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RapsUploadEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// RapsUpload.StatusId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, RapsUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RapsUploadEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// RapsUpload.UploadedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, RapsUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", true);
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
