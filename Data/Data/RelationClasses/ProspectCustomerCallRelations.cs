///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: ProspectCustomerCall. </summary>
	public partial class ProspectCustomerCallRelations
	{
		/// <summary>CTor</summary>
		public ProspectCustomerCallRelations()
		{
		}

		/// <summary>Gets all relations of the ProspectCustomerCallEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CallsEntityUsingCallId);
			toReturn.Add(this.ProspectCustomerEntityUsingProspectCustomerId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerCallEntity and CallsEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectCustomerCall.CallId - Calls.CallId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Calls", false);
				relation.AddEntityFieldPair(CallsFields.CallId, ProspectCustomerCallFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerCallEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProspectCustomerCallEntity and ProspectCustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectCustomerCall.ProspectCustomerId - ProspectCustomer.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectCustomer", false);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, ProspectCustomerCallFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerCallEntity", true);
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
