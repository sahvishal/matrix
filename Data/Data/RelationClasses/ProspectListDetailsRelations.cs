///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
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
	/// <summary>Implements the static Relations variant for the entity: ProspectListDetails. </summary>
	public partial class ProspectListDetailsRelations
	{
		/// <summary>CTor</summary>
		public ProspectListDetailsRelations()
		{
		}

		/// <summary>Gets all relations of the ProspectListDetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.MarketingPrintOrderProspectListMappingEntityUsingProspectFileId);
			toReturn.Add(this.ProspectFaliureReportEntityUsingProspectListId);
			toReturn.Add(this.ProspectsEntityUsingProspectListId);

			toReturn.Add(this.OrganizationEntityUsingOrganizationId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProspectListDetailsEntity and MarketingPrintOrderProspectListMappingEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectListDetails.ProspectFileId - MarketingPrintOrderProspectListMapping.ProspectFileId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderProspectListMappingEntityUsingProspectFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrderProspectListMapping" , true);
				relation.AddEntityFieldPair(ProspectListDetailsFields.ProspectFileId, MarketingPrintOrderProspectListMappingFields.ProspectFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectListDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderProspectListMappingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectListDetailsEntity and ProspectFaliureReportEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectListDetails.ProspectFileId - ProspectFaliureReport.ProspectListId
		/// </summary>
		public virtual IEntityRelation ProspectFaliureReportEntityUsingProspectListId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectFaliureReport" , true);
				relation.AddEntityFieldPair(ProspectListDetailsFields.ProspectFileId, ProspectFaliureReportFields.ProspectListId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectListDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectFaliureReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectListDetailsEntity and ProspectsEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectListDetails.ProspectFileId - Prospects.ProspectListId
		/// </summary>
		public virtual IEntityRelation ProspectsEntityUsingProspectListId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Prospects" , true);
				relation.AddEntityFieldPair(ProspectListDetailsFields.ProspectFileId, ProspectsFields.ProspectListId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectListDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ProspectListDetailsEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectListDetails.OrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, ProspectListDetailsFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectListDetailsEntity", true);
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
