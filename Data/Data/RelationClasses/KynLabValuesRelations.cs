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
	/// <summary>Implements the static Relations variant for the entity: KynLabValues. </summary>
	public partial class KynLabValuesRelations
	{
		/// <summary>CTor</summary>
		public KynLabValuesRelations()
		{
		}

		/// <summary>Gets all relations of the KynLabValuesEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventCustomerResultEntityUsingEventCustomerResultId);
			toReturn.Add(this.LookupEntityUsingFastingStatus);
			toReturn.Add(this.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.TestEntityUsingTestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between KynLabValuesEntity and EventCustomerResultEntity over the m:1 relation they have, using the relation between the fields:
		/// KynLabValues.EventCustomerResultId - EventCustomerResult.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomerResult", false);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, KynLabValuesFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between KynLabValuesEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// KynLabValues.FastingStatus - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingFastingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, KynLabValuesFields.FastingStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between KynLabValuesEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// KynLabValues.ModifiedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, KynLabValuesFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between KynLabValuesEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// KynLabValues.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, KynLabValuesFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between KynLabValuesEntity and TestEntity over the m:1 relation they have, using the relation between the fields:
		/// KynLabValues.TestId - Test.TestId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Test", false);
				relation.AddEntityFieldPair(TestFields.TestId, KynLabValuesFields.TestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", true);
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
