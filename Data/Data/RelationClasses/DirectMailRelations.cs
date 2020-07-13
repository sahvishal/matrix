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
	/// <summary>Implements the static Relations variant for the entity: DirectMail. </summary>
	public partial class DirectMailRelations
	{
		/// <summary>CTor</summary>
		public DirectMailRelations()
		{
		}

		/// <summary>Gets all relations of the DirectMailEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CallUploadEntityUsingCallUploadId);
			toReturn.Add(this.CampaignEntityUsingCampaignId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.DirectMailTypeEntityUsingDirectMailTypeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingMailedBy);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between DirectMailEntity and CallUploadEntity over the m:1 relation they have, using the relation between the fields:
		/// DirectMail.CallUploadId - CallUpload.Id
		/// </summary>
		public virtual IEntityRelation CallUploadEntityUsingCallUploadId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallUpload", false);
				relation.AddEntityFieldPair(CallUploadFields.Id, DirectMailFields.CallUploadId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DirectMailEntity and CampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// DirectMail.CampaignId - Campaign.Id
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Campaign", false);
				relation.AddEntityFieldPair(CampaignFields.Id, DirectMailFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DirectMailEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// DirectMail.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, DirectMailFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DirectMailEntity and DirectMailTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// DirectMail.DirectMailTypeId - DirectMailType.Id
		/// </summary>
		public virtual IEntityRelation DirectMailTypeEntityUsingDirectMailTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DirectMailType", false);
				relation.AddEntityFieldPair(DirectMailTypeFields.Id, DirectMailFields.DirectMailTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DirectMailEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// DirectMail.MailedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingMailedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, DirectMailFields.MailedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", true);
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
