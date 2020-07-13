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
	/// <summary>Implements the static Relations variant for the entity: CustomerProfileHistory. </summary>
	public partial class CustomerProfileHistoryRelations
	{
		/// <summary>CTor</summary>
		public CustomerProfileHistoryRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerProfileHistoryEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCustomersEntityUsingCustomerProfileHistoryId);

			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.LookupEntityUsingPreferredContactType);
			toReturn.Add(this.LookupEntityUsingProductTypeId);
			toReturn.Add(this.LookupEntityUsingDoNotContactUpdateSource);
			toReturn.Add(this.LookupEntityUsingMemberUploadSourceId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileHistoryEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfileHistory.Id - EventCustomers.CustomerProfileHistoryId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingCustomerProfileHistoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(CustomerProfileHistoryFields.Id, EventCustomersFields.CustomerProfileHistoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CustomerProfileHistoryEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfileHistory.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerProfileHistoryFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileHistoryEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfileHistory.PreferredContactType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPreferredContactType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup___", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileHistoryFields.PreferredContactType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileHistoryEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfileHistory.ProductTypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingProductTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileHistoryFields.ProductTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileHistoryEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfileHistory.DoNotContactUpdateSource - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDoNotContactUpdateSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileHistoryFields.DoNotContactUpdateSource);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileHistoryEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfileHistory.MemberUploadSourceId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingMemberUploadSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileHistoryFields.MemberUploadSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileHistoryEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfileHistory.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerProfileHistoryFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", true);
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
