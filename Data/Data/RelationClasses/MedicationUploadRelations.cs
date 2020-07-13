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
	/// <summary>Implements the static Relations variant for the entity: MedicationUpload. </summary>
	public partial class MedicationUploadRelations
	{
		/// <summary>CTor</summary>
		public MedicationUploadRelations()
		{
		}

		/// <summary>Gets all relations of the MedicationUploadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.MedicationUploadLogEntityUsingMedicationUploadId);

			toReturn.Add(this.FileEntityUsingLogFileId);
			toReturn.Add(this.FileEntityUsingFileId);
			toReturn.Add(this.LookupEntityUsingStatusId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUploadedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MedicationUploadEntity and MedicationUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// MedicationUpload.Id - MedicationUploadLog.MedicationUploadId
		/// </summary>
		public virtual IEntityRelation MedicationUploadLogEntityUsingMedicationUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicationUploadLog" , true);
				relation.AddEntityFieldPair(MedicationUploadFields.Id, MedicationUploadLogFields.MedicationUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadLogEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MedicationUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicationUpload.LogFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, MedicationUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicationUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicationUpload.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, MedicationUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicationUploadEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicationUpload.StatusId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, MedicationUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MedicationUploadEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// MedicationUpload.UploadedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, MedicationUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", true);
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
