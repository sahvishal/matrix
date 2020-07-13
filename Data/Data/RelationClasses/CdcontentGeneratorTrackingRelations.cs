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
	/// <summary>Implements the static Relations variant for the entity: CdcontentGeneratorTracking. </summary>
	public partial class CdcontentGeneratorTrackingRelations
	{
		/// <summary>CTor</summary>
		public CdcontentGeneratorTrackingRelations()
		{
		}

		/// <summary>Gets all relations of the CdcontentGeneratorTrackingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventCustomerResultEntityUsingEventCustomerResultId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingDownloadedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CdcontentGeneratorTrackingEntity and EventCustomerResultEntity over the m:1 relation they have, using the relation between the fields:
		/// CdcontentGeneratorTracking.EventCustomerResultId - EventCustomerResult.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomerResult", false);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, CdcontentGeneratorTrackingFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CdcontentGeneratorTrackingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CdcontentGeneratorTrackingEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CdcontentGeneratorTracking.DownloadedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingDownloadedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CdcontentGeneratorTrackingFields.DownloadedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CdcontentGeneratorTrackingEntity", true);
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
