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
	/// <summary>Implements the static Relations variant for the entity: CallUpload. </summary>
	public partial class CallUploadRelations
	{
		/// <summary>CTor</summary>
		public CallUploadRelations()
		{
		}

		/// <summary>Gets all relations of the CallUploadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallUploadLogEntityUsingCallUploadId);
			toReturn.Add(this.DirectMailEntityUsingCallUploadId);

			toReturn.Add(this.FileEntityUsingLogFileId);
			toReturn.Add(this.FileEntityUsingFileId);
			toReturn.Add(this.LookupEntityUsingStatusId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUploadedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CallUploadEntity and CallUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// CallUpload.Id - CallUploadLog.CallUploadId
		/// </summary>
		public virtual IEntityRelation CallUploadLogEntityUsingCallUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallUploadLog" , true);
				relation.AddEntityFieldPair(CallUploadFields.Id, CallUploadLogFields.CallUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallUploadEntity and DirectMailEntity over the 1:n relation they have, using the relation between the fields:
		/// CallUpload.Id - DirectMail.CallUploadId
		/// </summary>
		public virtual IEntityRelation DirectMailEntityUsingCallUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DirectMail" , true);
				relation.AddEntityFieldPair(CallUploadFields.Id, DirectMailFields.CallUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CallUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// CallUpload.LogFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, CallUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// CallUpload.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, CallUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallUploadEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CallUpload.StatusId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallUploadEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallUpload.UploadedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", true);
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
