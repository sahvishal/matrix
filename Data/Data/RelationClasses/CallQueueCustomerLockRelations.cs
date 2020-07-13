///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:41
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
	/// <summary>Implements the static Relations variant for the entity: CallQueueCustomerLock. </summary>
	public partial class CallQueueCustomerLockRelations
	{
		/// <summary>CTor</summary>
		public CallQueueCustomerLockRelations()
		{
		}

		/// <summary>Gets all relations of the CallQueueCustomerLockEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.CallQueueCustomerEntityUsingCallQueueCustomerId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedBy);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerLockEntity and CallQueueCustomerEntity over the 1:1 relation they have, using the relation between the fields:
		/// CallQueueCustomerLock.CallQueueCustomerId - CallQueueCustomer.CallQueueCustomerId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingCallQueueCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CallQueueCustomer", false);



				relation.AddEntityFieldPair(CallQueueCustomerFields.CallQueueCustomerId, CallQueueCustomerLockFields.CallQueueCustomerId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerLockEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerLockEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomerLock.CreatedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomerLockFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerLockEntity", true);
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
