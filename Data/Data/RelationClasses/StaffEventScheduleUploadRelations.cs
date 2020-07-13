///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:41
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
	/// <summary>Implements the static Relations variant for the entity: StaffEventScheduleUpload. </summary>
	public partial class StaffEventScheduleUploadRelations
	{
		/// <summary>CTor</summary>
		public StaffEventScheduleUploadRelations()
		{
		}

		/// <summary>Gets all relations of the StaffEventScheduleUploadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.StaffEventScheduleUploadLogEntityUsingUploadId);

			toReturn.Add(this.FileEntityUsingLogFileId);
			toReturn.Add(this.FileEntityUsingFileId);
			toReturn.Add(this.LookupEntityUsingStatusId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUploadedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between StaffEventScheduleUploadEntity and StaffEventScheduleUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// StaffEventScheduleUpload.Id - StaffEventScheduleUploadLog.UploadId
		/// </summary>
		public virtual IEntityRelation StaffEventScheduleUploadLogEntityUsingUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StaffEventScheduleUploadLog" , true);
				relation.AddEntityFieldPair(StaffEventScheduleUploadFields.Id, StaffEventScheduleUploadLogFields.UploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadLogEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between StaffEventScheduleUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// StaffEventScheduleUpload.LogFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, StaffEventScheduleUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between StaffEventScheduleUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// StaffEventScheduleUpload.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, StaffEventScheduleUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between StaffEventScheduleUploadEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// StaffEventScheduleUpload.StatusId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, StaffEventScheduleUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between StaffEventScheduleUploadEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// StaffEventScheduleUpload.UploadedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUploadedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, StaffEventScheduleUploadFields.UploadedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", true);
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
