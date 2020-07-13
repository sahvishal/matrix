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
	/// <summary>Implements the static Relations variant for the entity: Prospects. </summary>
	public partial class ProspectsRelations
	{
		/// <summary>CTor</summary>
		public ProspectsRelations()
		{
		}

		/// <summary>Gets all relations of the ProspectsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountEntityUsingConvertedHostId);
			toReturn.Add(this.HostEventDetailsEntityUsingHostId);
			toReturn.Add(this.HostFacilityRankingEntityUsingHostId);
			toReturn.Add(this.HostImageEntityUsingHostId);
			toReturn.Add(this.HostPaymentEntityUsingHostId);
			toReturn.Add(this.ProspectActivityDetailsEntityUsingProspectId);
			toReturn.Add(this.ProspectCallDetailsEntityUsingProspectsId);
			toReturn.Add(this.ProspectContactEntityUsingProspectId);
			toReturn.Add(this.HostNotesEntityUsingHostId);
			toReturn.Add(this.AddressEntityUsingAddressId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingOrgRoleUserId);
			toReturn.Add(this.ProspectListDetailsEntityUsingProspectListId);
			toReturn.Add(this.ProspectTypeEntityUsingProspectTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// Prospects.ProspectId - Account.ConvertedHostId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingConvertedHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account" , true);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, AccountFields.ConvertedHostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and HostEventDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Prospects.ProspectId - HostEventDetails.HostId
		/// </summary>
		public virtual IEntityRelation HostEventDetailsEntityUsingHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostEventDetails" , true);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, HostEventDetailsFields.HostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostEventDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and HostFacilityRankingEntity over the 1:n relation they have, using the relation between the fields:
		/// Prospects.ProspectId - HostFacilityRanking.HostId
		/// </summary>
		public virtual IEntityRelation HostFacilityRankingEntityUsingHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostFacilityRanking" , true);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, HostFacilityRankingFields.HostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and HostImageEntity over the 1:n relation they have, using the relation between the fields:
		/// Prospects.ProspectId - HostImage.HostId
		/// </summary>
		public virtual IEntityRelation HostImageEntityUsingHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostImage" , true);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, HostImageFields.HostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostImageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and HostPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Prospects.ProspectId - HostPayment.HostId
		/// </summary>
		public virtual IEntityRelation HostPaymentEntityUsingHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPayment" , true);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, HostPaymentFields.HostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and ProspectActivityDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Prospects.ProspectId - ProspectActivityDetails.ProspectId
		/// </summary>
		public virtual IEntityRelation ProspectActivityDetailsEntityUsingProspectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectActivityDetails" , true);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, ProspectActivityDetailsFields.ProspectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectActivityDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and ProspectCallDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Prospects.ProspectId - ProspectCallDetails.ProspectsId
		/// </summary>
		public virtual IEntityRelation ProspectCallDetailsEntityUsingProspectsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectCallDetails" , true);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, ProspectCallDetailsFields.ProspectsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCallDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and ProspectContactEntity over the 1:n relation they have, using the relation between the fields:
		/// Prospects.ProspectId - ProspectContact.ProspectId
		/// </summary>
		public virtual IEntityRelation ProspectContactEntityUsingProspectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectContact" , true);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, ProspectContactFields.ProspectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectContactEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and HostNotesEntity over the 1:1 relation they have, using the relation between the fields:
		/// Prospects.ProspectId - HostNotes.HostId
		/// </summary>
		public virtual IEntityRelation HostNotesEntityUsingHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "HostNotes", true);

				relation.AddEntityFieldPair(ProspectsFields.ProspectId, HostNotesFields.HostId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostNotesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// Prospects.AddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, ProspectsFields.AddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// Prospects.OrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ProspectsFields.OrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and ProspectListDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// Prospects.ProspectListId - ProspectListDetails.ProspectFileId
		/// </summary>
		public virtual IEntityRelation ProspectListDetailsEntityUsingProspectListId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectListDetails", false);
				relation.AddEntityFieldPair(ProspectListDetailsFields.ProspectFileId, ProspectsFields.ProspectListId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectListDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectsEntity and ProspectTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Prospects.ProspectTypeId - ProspectType.ProspectTypeId
		/// </summary>
		public virtual IEntityRelation ProspectTypeEntityUsingProspectTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectType", false);
				relation.AddEntityFieldPair(ProspectTypeFields.ProspectTypeId, ProspectsFields.ProspectTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", true);
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
