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
	/// <summary>Implements the static Relations variant for the entity: AccountAdditionalFields. </summary>
	public partial class AccountAdditionalFieldsRelations
	{
		/// <summary>CTor</summary>
		public AccountAdditionalFieldsRelations()
		{
		}

		/// <summary>Gets all relations of the AccountAdditionalFieldsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AccountEntityUsingAccountId);
			toReturn.Add(this.AdditionalFieldsEntityUsingAdditionalFieldId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AccountAdditionalFieldsEntity and AccountEntity over the m:1 relation they have, using the relation between the fields:
		/// AccountAdditionalFields.AccountId - Account.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Account", false);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountAdditionalFieldsFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountAdditionalFieldsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountAdditionalFieldsEntity and AdditionalFieldsEntity over the m:1 relation they have, using the relation between the fields:
		/// AccountAdditionalFields.AdditionalFieldId - AdditionalFields.Id
		/// </summary>
		public virtual IEntityRelation AdditionalFieldsEntityUsingAdditionalFieldId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AdditionalFields", false);
				relation.AddEntityFieldPair(AdditionalFieldsFields.Id, AccountAdditionalFieldsFields.AdditionalFieldId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AdditionalFieldsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountAdditionalFieldsEntity", true);
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
