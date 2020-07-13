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
	/// <summary>Implements the static Relations variant for the entity: CallQueueCriteria. </summary>
	public partial class CallQueueCriteriaRelations
	{
		/// <summary>CTor</summary>
		public CallQueueCriteriaRelations()
		{
		}

		/// <summary>Gets all relations of the CallQueueCriteriaEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueCustomerEntityUsingCallQueueCriteriaId);

			toReturn.Add(this.CallQueueEntityUsingCallQueueId);
			toReturn.Add(this.CriteriaEntityUsingCriteriaId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CallQueueCriteriaEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// CallQueueCriteria.CallQueueCriteriaId - CallQueueCustomer.CallQueueCriteriaId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingCallQueueCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(CallQueueCriteriaFields.CallQueueCriteriaId, CallQueueCustomerFields.CallQueueCriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCriteriaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CallQueueCriteriaEntity and CallQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCriteria.CallQueueId - CallQueue.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueue", false);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, CallQueueCriteriaFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCriteriaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CallQueueCriteriaEntity and CriteriaEntity over the m:1 relation they have, using the relation between the fields:
		/// CallQueueCriteria.CriteriaId - Criteria.CriteriaId
		/// </summary>
		public virtual IEntityRelation CriteriaEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Criteria", false);
				relation.AddEntityFieldPair(CriteriaFields.CriteriaId, CallQueueCriteriaFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CriteriaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCriteriaEntity", true);
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
