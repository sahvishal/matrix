///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
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
	/// <summary>Implements the static Relations variant for the entity: ClickConversion. </summary>
	public partial class ClickConversionRelations
	{
		/// <summary>CTor</summary>
		public ClickConversionRelations()
		{
		}

		/// <summary>Gets all relations of the ClickConversionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ClickLogEntityUsingClickId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.EventCustomersEntityUsingEventCustomerId);
			toReturn.Add(this.ProspectCustomerEntityUsingProspectCustomerId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ClickConversionEntity and ClickLogEntity over the m:1 relation they have, using the relation between the fields:
		/// ClickConversion.ClickId - ClickLog.ClickId
		/// </summary>
		public virtual IEntityRelation ClickLogEntityUsingClickId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ClickLog", false);
				relation.AddEntityFieldPair(ClickLogFields.ClickId, ClickConversionFields.ClickId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickLogEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickConversionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ClickConversionEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// ClickConversion.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ClickConversionFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickConversionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ClickConversionEntity and EventCustomersEntity over the m:1 relation they have, using the relation between the fields:
		/// ClickConversion.EventCustomerId - EventCustomers.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomers", false);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ClickConversionFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickConversionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ClickConversionEntity and ProspectCustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// ClickConversion.ProspectCustomerId - ProspectCustomer.ProspectCustomerId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerEntityUsingProspectCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ProspectCustomer", false);
				relation.AddEntityFieldPair(ProspectCustomerFields.ProspectCustomerId, ClickConversionFields.ProspectCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickConversionEntity", true);
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
