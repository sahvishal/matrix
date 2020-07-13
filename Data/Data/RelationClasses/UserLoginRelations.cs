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
	/// <summary>Implements the static Relations variant for the entity: UserLogin. </summary>
	public partial class UserLoginRelations
	{
		/// <summary>CTor</summary>
		public UserLoginRelations()
		{
		}

		/// <summary>Gets all relations of the UserLoginEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.PasswordChangelogEntityUsingUserLoginId);
			toReturn.Add(this.SafeComputerHistoryEntityUsingUserLoginId);
			toReturn.Add(this.LoginOtpEntityUsingUserLoginId);
			toReturn.Add(this.LoginSettingsEntityUsingUserLoginId);
			toReturn.Add(this.UserEntityUsingUserLoginId);

			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between UserLoginEntity and PasswordChangelogEntity over the 1:n relation they have, using the relation between the fields:
		/// UserLogin.UserLoginId - PasswordChangelog.UserLoginId
		/// </summary>
		public virtual IEntityRelation PasswordChangelogEntityUsingUserLoginId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PasswordChangelog" , true);
				relation.AddEntityFieldPair(UserLoginFields.UserLoginId, PasswordChangelogFields.UserLoginId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserLoginEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PasswordChangelogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserLoginEntity and SafeComputerHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// UserLogin.UserLoginId - SafeComputerHistory.UserLoginId
		/// </summary>
		public virtual IEntityRelation SafeComputerHistoryEntityUsingUserLoginId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SafeComputerHistory" , true);
				relation.AddEntityFieldPair(UserLoginFields.UserLoginId, SafeComputerHistoryFields.UserLoginId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserLoginEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SafeComputerHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserLoginEntity and LoginOtpEntity over the 1:1 relation they have, using the relation between the fields:
		/// UserLogin.UserLoginId - LoginOtp.UserLoginId
		/// </summary>
		public virtual IEntityRelation LoginOtpEntityUsingUserLoginId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "LoginOtp", true);

				relation.AddEntityFieldPair(UserLoginFields.UserLoginId, LoginOtpFields.UserLoginId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserLoginEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LoginOtpEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserLoginEntity and LoginSettingsEntity over the 1:1 relation they have, using the relation between the fields:
		/// UserLogin.UserLoginId - LoginSettings.UserLoginId
		/// </summary>
		public virtual IEntityRelation LoginSettingsEntityUsingUserLoginId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "LoginSettings", true);

				relation.AddEntityFieldPair(UserLoginFields.UserLoginId, LoginSettingsFields.UserLoginId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserLoginEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LoginSettingsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserLoginEntity and UserEntity over the 1:1 relation they have, using the relation between the fields:
		/// UserLogin.UserLoginId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUserLoginId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "User", false);



				relation.AddEntityFieldPair(UserFields.UserId, UserLoginFields.UserLoginId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserLoginEntity", true);
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
