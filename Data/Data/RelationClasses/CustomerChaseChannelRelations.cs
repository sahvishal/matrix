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
	/// <summary>Implements the static Relations variant for the entity: CustomerChaseChannel. </summary>
	public partial class CustomerChaseChannelRelations
	{
		/// <summary>CTor</summary>
		public CustomerChaseChannelRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerChaseChannelEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ChaseChannelLevelEntityUsingChaseChannelLevelId);
			toReturn.Add(this.ChaseOutboundEntityUsingChaseOutboundId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CustomerChaseChannelEntity and ChaseChannelLevelEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerChaseChannel.ChaseChannelLevelId - ChaseChannelLevel.ChaseChannelLevelId
		/// </summary>
		public virtual IEntityRelation ChaseChannelLevelEntityUsingChaseChannelLevelId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ChaseChannelLevel", false);
				relation.AddEntityFieldPair(ChaseChannelLevelFields.ChaseChannelLevelId, CustomerChaseChannelFields.ChaseChannelLevelId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseChannelLevelEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseChannelEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerChaseChannelEntity and ChaseOutboundEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerChaseChannel.ChaseOutboundId - ChaseOutbound.Id
		/// </summary>
		public virtual IEntityRelation ChaseOutboundEntityUsingChaseOutboundId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ChaseOutbound", false);
				relation.AddEntityFieldPair(ChaseOutboundFields.Id, CustomerChaseChannelFields.ChaseOutboundId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseChannelEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerChaseChannelEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerChaseChannel.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerChaseChannelFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseChannelEntity", true);
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
