﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
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
	/// <summary>Implements the static Relations variant for the entity: PhysicianCustomerAssignment. </summary>
	public partial class PhysicianCustomerAssignmentRelations
	{
		/// <summary>CTor</summary>
		public PhysicianCustomerAssignmentRelations()
		{
		}

		/// <summary>Gets all relations of the PhysicianCustomerAssignmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.PhysicianProfileEntityUsingPhysicianId);
			toReturn.Add(this.PhysicianProfileEntityUsingOverReadPhysicianId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PhysicianCustomerAssignmentEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianCustomerAssignment.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, PhysicianCustomerAssignmentFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianCustomerAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianCustomerAssignmentEntity and PhysicianProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianCustomerAssignment.PhysicianId - PhysicianProfile.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianProfileEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianProfile_", false);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianCustomerAssignmentFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianCustomerAssignmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PhysicianCustomerAssignmentEntity and PhysicianProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// PhysicianCustomerAssignment.OverReadPhysicianId - PhysicianProfile.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianProfileEntityUsingOverReadPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PhysicianProfile", false);
				relation.AddEntityFieldPair(PhysicianProfileFields.PhysicianId, PhysicianCustomerAssignmentFields.OverReadPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianCustomerAssignmentEntity", true);
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
