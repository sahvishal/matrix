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
	/// <summary>Implements the static Relations variant for the entity: CorporateUpload. </summary>
	public partial class CorporateUploadRelations
	{
		/// <summary>CTor</summary>
		public CorporateUploadRelations()
		{
		}

		/// <summary>Gets all relations of the CorporateUploadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerOrderHistoryEntityUsingUploadId);
			toReturn.Add(this.MemberUploadLogEntityUsingCorporateUploadId);
			toReturn.Add(this.MemberUploadParseDetailEntityUsingCorporateUploadId);

			toReturn.Add(this.AccountEntityUsingAccountId);
			toReturn.Add(this.FileEntityUsingLogFileId);
			toReturn.Add(this.FileEntityUsingFileId);
			toReturn.Add(this.FileEntityUsingAdjustOrderLogFileId);
			toReturn.Add(this.LookupEntityUsingSourceId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingUploadedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and CustomerOrderHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// CorporateUpload.Id - CustomerOrderHistory.UploadId
		/// </summary>
		public virtual IEntityRelation CustomerOrderHistoryEntityUsingUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerOrderHistory" , true);
				relation.AddEntityFieldPair(CorporateUploadFields.Id, CustomerOrderHistoryFields.UploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerOrderHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and MemberUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// CorporateUpload.Id - MemberUploadLog.CorporateUploadId
		/// </summary>
		public virtual IEntityRelation MemberUploadLogEntityUsingCorporateUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MemberUploadLog" , true);
				relation.AddEntityFieldPair(CorporateUploadFields.Id, MemberUploadLogFields.CorporateUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MemberUploadLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and MemberUploadParseDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// CorporateUpload.Id - MemberUploadParseDetail.CorporateUploadId
		/// </summary>
		public virtual IEntityRelation MemberUploadParseDetailEntityUsingCorporateUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MemberUploadParseDetail" , true);
				relation.AddEntityFieldPair(CorporateUploadFields.Id, MemberUploadParseDetailFields.CorporateUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MemberUploadParseDetailEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and AccountEntity over the m:1 relation they have, using the relation between the fields:
		/// CorporateUpload.AccountId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Account", false);
				relation.AddEntityFieldPair(AccountFields.AccountId, CorporateUploadFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// CorporateUpload.LogFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, CorporateUploadFields.LogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// CorporateUpload.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, CorporateUploadFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// CorporateUpload.AdjustOrderLogFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingAdjustOrderLogFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File__", false);
				relation.AddEntityFieldPair(FileFields.FileId, CorporateUploadFields.AdjustOrderLogFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CorporateUpload.SourceId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CorporateUploadFields.SourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CorporateUploadEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CorporateUpload.UploadedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CorporateUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", true);
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
