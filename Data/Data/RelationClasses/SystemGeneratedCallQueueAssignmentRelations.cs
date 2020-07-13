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
	/// <summary>Implements the static Relations variant for the entity: SystemGeneratedCallQueueAssignment. </summary>
	public partial class SystemGeneratedCallQueueAssignmentRelations
	{
		/// <summary>CTor</summary>
		public SystemGeneratedCallQueueAssignmentRelations()
		{
		}

		/// <summary>Gets all relations of the SystemGeneratedCallQueueAssignmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CallQueueEntityUsingCallQueueId);
			toReturn.Add(this.CallQueueCustomerEntityUsingCallQueueCustomerId);
			toReturn.Add(this.SystemGeneratedCallQueueCriteriaEntityUsingCriteriaId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between SystemGeneratedCallQueueAssignmentEntity and CallQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemGeneratedCallQueueAssignment.CallQueueId - CallQueue.CallQueueId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingCallQueueId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueue", false);
				relation.AddEntityFieldPair(CallQueueFields.CallQueueId, SystemGeneratedCallQueueAssignmentFields.CallQueueId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SystemGeneratedCallQueueAssignmentEntity and CallQueueCustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemGeneratedCallQueueAssignment.CallQueueCustomerId - CallQueueCustomer.CallQueueCustomerId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingCallQueueCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CallQueueCustomer", false);
				relation.AddEntityFieldPair(CallQueueCustomerFields.CallQueueCustomerId, SystemGeneratedCallQueueAssignmentFields.CallQueueCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SystemGeneratedCallQueueAssignmentEntity and SystemGeneratedCallQueueCriteriaEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemGeneratedCallQueueAssignment.CriteriaId - SystemGeneratedCallQueueCriteria.Id
		/// </summary>
		public virtual IEntityRelation SystemGeneratedCallQueueCriteriaEntityUsingCriteriaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SystemGeneratedCallQueueCriteria", false);
				relation.AddEntityFieldPair(SystemGeneratedCallQueueCriteriaFields.Id, SystemGeneratedCallQueueAssignmentFields.CriteriaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueAssignmentEntity", true);
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
