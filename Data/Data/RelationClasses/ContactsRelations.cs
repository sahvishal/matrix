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
	/// <summary>Implements the static Relations variant for the entity: Contacts. </summary>
	public partial class ContactsRelations
	{
		/// <summary>CTor</summary>
		public ContactsRelations()
		{
		}

		/// <summary>Gets all relations of the ContactsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ContactFranchiseeAccessEntityUsingContactId);
			toReturn.Add(this.ContactNotesEntityUsingContactId);

			toReturn.Add(this.ContactTypeEntityUsingContactTypeId);
			toReturn.Add(this.RoleEntityUsingModifiedRoleId);
			toReturn.Add(this.RoleEntityUsingAddedRoleId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ContactsEntity and ContactFranchiseeAccessEntity over the 1:n relation they have, using the relation between the fields:
		/// Contacts.ContactId - ContactFranchiseeAccess.ContactId
		/// </summary>
		public virtual IEntityRelation ContactFranchiseeAccessEntityUsingContactId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactFranchiseeAccess" , true);
				relation.AddEntityFieldPair(ContactsFields.ContactId, ContactFranchiseeAccessFields.ContactId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactFranchiseeAccessEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ContactsEntity and ContactNotesEntity over the 1:n relation they have, using the relation between the fields:
		/// Contacts.ContactId - ContactNotes.ContactId
		/// </summary>
		public virtual IEntityRelation ContactNotesEntityUsingContactId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactNotes" , true);
				relation.AddEntityFieldPair(ContactsFields.ContactId, ContactNotesFields.ContactId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactNotesEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ContactsEntity and ContactTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Contacts.ContactTypeId - ContactType.ContactTypeId
		/// </summary>
		public virtual IEntityRelation ContactTypeEntityUsingContactTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ContactType", false);
				relation.AddEntityFieldPair(ContactTypeFields.ContactTypeId, ContactsFields.ContactTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ContactsEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// Contacts.ModifiedRoleId - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingModifiedRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role_", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, ContactsFields.ModifiedRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ContactsEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// Contacts.AddedRoleId - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingAddedRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, ContactsFields.AddedRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactsEntity", true);
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
