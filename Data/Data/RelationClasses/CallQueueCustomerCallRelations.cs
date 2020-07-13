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
	/// <summary>Implements the static Relations variant for the entity: CallQueueCustomerCall. </summary>
	public partial class CallQueueCustomerCallRelations
	{
		/// <summary>CTor</summary>
		public CallQueueCustomerCallRelations()
		{
		}

		/// <summary>Gets all relations of the CallQueueCustomerCallEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CallQueueCustomerEntityUsingCallQueueCustomerId);
			toReturn.Add(this.CallsEntityUsingCallId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerCallEntity and CallQueueCustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomerCall.CallQueueCustomerId - CallQueueCustomer.CallQueueCustomerId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingCallQueueCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueueCustomer", false);
				relation.AddEntityFieldPair(CallQueueCustomerFields.CallQueueCustomerId, CallQueueCustomerCallFields.CallQueueCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerCallEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCustomerCallEntity and CallsEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCustomerCall.CallId - Calls.CallId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Calls", false);
				relation.AddEntityFieldPair(CallsFields.CallId, CallQueueCustomerCallFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerCallEntity", true);
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
