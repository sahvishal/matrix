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
	/// <summary>Implements the static Relations variant for the entity: State. </summary>
	public partial class StateRelations
	{
		/// <summary>CTor</summary>
		public StateRelations()
		{
		}

		/// <summary>Gets all relations of the StateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountCheckoutPhoneNumberEntityUsingStateId);
			toReturn.Add(this.AddressEntityUsingStateId);
			toReturn.Add(this.ContractEntityUsingStateId);
			toReturn.Add(this.PhysicianLabTestEntityUsingStateId);
			toReturn.Add(this.PhysicianLicenseEntityUsingStateId);

			toReturn.Add(this.CountryEntityUsingCountryId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between StateEntity and AccountCheckoutPhoneNumberEntity over the 1:n relation they have, using the relation between the fields:
		/// State.StateId - AccountCheckoutPhoneNumber.StateId
		/// </summary>
		public virtual IEntityRelation AccountCheckoutPhoneNumberEntityUsingStateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCheckoutPhoneNumber" , true);
				relation.AddEntityFieldPair(StateFields.StateId, AccountCheckoutPhoneNumberFields.StateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCheckoutPhoneNumberEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between StateEntity and AddressEntity over the 1:n relation they have, using the relation between the fields:
		/// State.StateId - Address.StateId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingStateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Address" , true);
				relation.AddEntityFieldPair(StateFields.StateId, AddressFields.StateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between StateEntity and ContractEntity over the 1:n relation they have, using the relation between the fields:
		/// State.StateId - Contract.StateId
		/// </summary>
		public virtual IEntityRelation ContractEntityUsingStateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Contract" , true);
				relation.AddEntityFieldPair(StateFields.StateId, ContractFields.StateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContractEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between StateEntity and PhysicianLabTestEntity over the 1:n relation they have, using the relation between the fields:
		/// State.StateId - PhysicianLabTest.StateId
		/// </summary>
		public virtual IEntityRelation PhysicianLabTestEntityUsingStateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianLabTest" , true);
				relation.AddEntityFieldPair(StateFields.StateId, PhysicianLabTestFields.StateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianLabTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between StateEntity and PhysicianLicenseEntity over the 1:n relation they have, using the relation between the fields:
		/// State.StateId - PhysicianLicense.StateId
		/// </summary>
		public virtual IEntityRelation PhysicianLicenseEntityUsingStateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianLicense" , true);
				relation.AddEntityFieldPair(StateFields.StateId, PhysicianLicenseFields.StateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianLicenseEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between StateEntity and CountryEntity over the m:1 relation they have, using the relation between the fields:
		/// State.CountryId - Country.CountryId
		/// </summary>
		public virtual IEntityRelation CountryEntityUsingCountryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Country", false);
				relation.AddEntityFieldPair(CountryFields.CountryId, StateFields.CountryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StateEntity", true);
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
