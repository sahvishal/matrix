///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:21 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: ResultOrder. </summary>
	public partial class ResultOrderRelations
	{
		/// <summary>CTor</summary>
		public ResultOrderRelations()
		{
		}

		/// <summary>Gets all relations of the ResultOrderEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.OrderShippingInformationEntityUsingOrderShippingInformationId);
			toReturn.Add(this.ResultOrderCatalogEntityUsingResultCatalogId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ResultOrderEntity and OrderShippingInformationEntity over the m:1 relation they have, using the relation between the fields:
		/// ResultOrder.OrderShippingInformationId - OrderShippingInformation.OrderShippingInformationId
		/// </summary>
		public virtual IEntityRelation OrderShippingInformationEntityUsingOrderShippingInformationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrderShippingInformation", false);
				relation.AddEntityFieldPair(OrderShippingInformationFields.OrderShippingInformationId, ResultOrderFields.OrderShippingInformationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderShippingInformationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultOrderEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ResultOrderEntity and ResultOrderCatalogEntity over the m:1 relation they have, using the relation between the fields:
		/// ResultOrder.ResultCatalogId - ResultOrderCatalog.ResultOrderCatalogId
		/// </summary>
		public virtual IEntityRelation ResultOrderCatalogEntityUsingResultCatalogId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ResultOrderCatalog", false);
				relation.AddEntityFieldPair(ResultOrderCatalogFields.ResultOrderCatalogId, ResultOrderFields.ResultCatalogId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultOrderCatalogEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultOrderEntity", true);
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
