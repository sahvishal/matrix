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
	/// <summary>Implements the static Relations variant for the entity: ExportableReportsQueue. </summary>
	public partial class ExportableReportsQueueRelations
	{
		/// <summary>CTor</summary>
		public ExportableReportsQueueRelations()
		{
		}

		/// <summary>Gets all relations of the ExportableReportsQueueEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ExportableReportsEntityUsingReportId);
			toReturn.Add(this.FileEntityUsingFileId);
			toReturn.Add(this.LookupEntityUsingStatusId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingRequestedBy);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ExportableReportsQueueEntity and ExportableReportsEntity over the m:1 relation they have, using the relation between the fields:
		/// ExportableReportsQueue.ReportId - ExportableReports.Id
		/// </summary>
		public virtual IEntityRelation ExportableReportsEntityUsingReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ExportableReports", false);
				relation.AddEntityFieldPair(ExportableReportsFields.Id, ExportableReportsQueueFields.ReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExportableReportsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExportableReportsQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ExportableReportsQueueEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// ExportableReportsQueue.FileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, ExportableReportsQueueFields.FileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExportableReportsQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ExportableReportsQueueEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// ExportableReportsQueue.StatusId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, ExportableReportsQueueFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExportableReportsQueueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ExportableReportsQueueEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// ExportableReportsQueue.RequestedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingRequestedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ExportableReportsQueueFields.RequestedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExportableReportsQueueEntity", true);
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
