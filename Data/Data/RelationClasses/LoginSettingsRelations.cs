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
	/// <summary>Implements the static Relations variant for the entity: LoginSettings. </summary>
	public partial class LoginSettingsRelations
	{
		/// <summary>CTor</summary>
		public LoginSettingsRelations()
		{
		}

		/// <summary>Gets all relations of the LoginSettingsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.UserLoginEntityUsingUserLoginId);
			toReturn.Add(this.LookupEntityUsingAuthenticationModeId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between LoginSettingsEntity and UserLoginEntity over the 1:1 relation they have, using the relation between the fields:
		/// LoginSettings.UserLoginId - UserLogin.UserLoginId
		/// </summary>
		public virtual IEntityRelation UserLoginEntityUsingUserLoginId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "UserLogin", false);



				relation.AddEntityFieldPair(UserLoginFields.UserLoginId, LoginSettingsFields.UserLoginId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserLoginEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LoginSettingsEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LoginSettingsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// LoginSettings.AuthenticationModeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingAuthenticationModeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, LoginSettingsFields.AuthenticationModeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LoginSettingsEntity", true);
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
