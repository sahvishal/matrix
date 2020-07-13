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
	/// <summary>Implements the static Relations variant for the entity: EmailTemplate. </summary>
	public partial class EmailTemplateRelations
	{
		/// <summary>CTor</summary>
		public EmailTemplateRelations()
		{
		}

		/// <summary>Gets all relations of the EmailTemplateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountEntityUsingPcpCoverLetterTemplateId);
			toReturn.Add(this.AccountEntityUsingReminderSmsTemplateId);
			toReturn.Add(this.AccountEntityUsingConfirmationSmsTemplateId);
			toReturn.Add(this.AccountEntityUsingMemberCoverLetterTemplateId);
			toReturn.Add(this.EmailTemplateMacroEntityUsingEmailTemplateId);

			toReturn.Add(this.LookupEntityUsingCoverLetterTypeLookupId);
			toReturn.Add(this.LookupEntityUsingTemplateType);
			toReturn.Add(this.NotificationTypeEntityUsingNotificationTypeId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// EmailTemplate.EmailTemplateId - Account.PcpCoverLetterTemplateId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingPcpCoverLetterTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account__" , true);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, AccountFields.PcpCoverLetterTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// EmailTemplate.EmailTemplateId - Account.ReminderSmsTemplateId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingReminderSmsTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account___" , true);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, AccountFields.ReminderSmsTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// EmailTemplate.EmailTemplateId - Account.ConfirmationSmsTemplateId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingConfirmationSmsTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account" , true);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, AccountFields.ConfirmationSmsTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// EmailTemplate.EmailTemplateId - Account.MemberCoverLetterTemplateId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingMemberCoverLetterTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account_" , true);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, AccountFields.MemberCoverLetterTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and EmailTemplateMacroEntity over the 1:n relation they have, using the relation between the fields:
		/// EmailTemplate.EmailTemplateId - EmailTemplateMacro.EmailTemplateId
		/// </summary>
		public virtual IEntityRelation EmailTemplateMacroEntityUsingEmailTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EmailTemplateMacro" , true);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, EmailTemplateMacroFields.EmailTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateMacroEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EmailTemplate.CoverLetterTypeLookupId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingCoverLetterTypeLookupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EmailTemplateFields.CoverLetterTypeLookupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EmailTemplate.TemplateType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTemplateType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EmailTemplateFields.TemplateType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and NotificationTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// EmailTemplate.NotificationTypeId - NotificationType.NotificationTypeId
		/// </summary>
		public virtual IEntityRelation NotificationTypeEntityUsingNotificationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotificationType", false);
				relation.AddEntityFieldPair(NotificationTypeFields.NotificationTypeId, EmailTemplateFields.NotificationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EmailTemplateEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EmailTemplate.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EmailTemplateFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", true);
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
