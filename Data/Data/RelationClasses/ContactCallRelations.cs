///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: ContactCall. </summary>
	public partial class ContactCallRelations
	{
		/// <summary>CTor</summary>
		public ContactCallRelations()
		{
		}

		/// <summary>Gets all relations of the ContactCallEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCallDetailsEntityUsingCallId);

			toReturn.Add(this.ContactCallStatusEntityUsingContactCallStatusId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByRoleId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ContactCallEntity and EventCallDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// ContactCall.ContactCallId - EventCallDetails.CallId
		/// </summary>
		public virtual IEntityRelation EventCallDetailsEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCallDetails" , true);
				relation.AddEntityFieldPair(ContactCallFields.ContactCallId, EventCallDetailsFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCallDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ContactCallEntity and ContactCallStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// ContactCall.ContactCallStatusId - ContactCallStatus.ContactCallStatusId
		/// </summary>
		public virtual IEntityRelation ContactCallStatusEntityUsingContactCallStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ContactCallStatus", false);
				relation.AddEntityFieldPair(ContactCallStatusFields.ContactCallStatusId, ContactCallFields.ContactCallStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ContactCallEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// ContactCall.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ContactCallFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ContactCallEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// ContactCall.CreatedByRoleId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ContactCallFields.CreatedByRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallEntity", true);
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
