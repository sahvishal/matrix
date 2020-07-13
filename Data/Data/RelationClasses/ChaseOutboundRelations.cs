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
	/// <summary>Implements the static Relations variant for the entity: ChaseOutbound. </summary>
	public partial class ChaseOutboundRelations
	{
		/// <summary>CTor</summary>
		public ChaseOutboundRelations()
		{
		}

		/// <summary>Gets all relations of the ChaseOutboundEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerChaseCampaignEntityUsingChaseOutboundId);
			toReturn.Add(this.CustomerChaseChannelEntityUsingChaseOutboundId);
			toReturn.Add(this.CustomerChaseProductEntityUsingChaseOutboundId);

			toReturn.Add(this.ChaseGroupEntityUsingChaseGroupId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.LookupEntityUsingConfidenceScoreId);
			toReturn.Add(this.RelationshipEntityUsingRelationshipId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ChaseOutboundEntity and CustomerChaseCampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// ChaseOutbound.Id - CustomerChaseCampaign.ChaseOutboundId
		/// </summary>
		public virtual IEntityRelation CustomerChaseCampaignEntityUsingChaseOutboundId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerChaseCampaign" , true);
				relation.AddEntityFieldPair(ChaseOutboundFields.Id, CustomerChaseCampaignFields.ChaseOutboundId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseCampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ChaseOutboundEntity and CustomerChaseChannelEntity over the 1:n relation they have, using the relation between the fields:
		/// ChaseOutbound.Id - CustomerChaseChannel.ChaseOutboundId
		/// </summary>
		public virtual IEntityRelation CustomerChaseChannelEntityUsingChaseOutboundId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerChaseChannel" , true);
				relation.AddEntityFieldPair(ChaseOutboundFields.Id, CustomerChaseChannelFields.ChaseOutboundId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseChannelEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ChaseOutboundEntity and CustomerChaseProductEntity over the 1:n relation they have, using the relation between the fields:
		/// ChaseOutbound.Id - CustomerChaseProduct.ChaseOutboundId
		/// </summary>
		public virtual IEntityRelation CustomerChaseProductEntityUsingChaseOutboundId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerChaseProduct" , true);
				relation.AddEntityFieldPair(ChaseOutboundFields.Id, CustomerChaseProductFields.ChaseOutboundId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseProductEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ChaseOutboundEntity and ChaseGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// ChaseOutbound.ChaseGroupId - ChaseGroup.ChaseGroupId
		/// </summary>
		public virtual IEntityRelation ChaseGroupEntityUsingChaseGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ChaseGroup", false);
				relation.AddEntityFieldPair(ChaseGroupFields.ChaseGroupId, ChaseOutboundFields.ChaseGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ChaseOutboundEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// ChaseOutbound.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ChaseOutboundFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ChaseOutboundEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// ChaseOutbound.ConfidenceScoreId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingConfidenceScoreId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, ChaseOutboundFields.ConfidenceScoreId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ChaseOutboundEntity and RelationshipEntity over the m:1 relation they have, using the relation between the fields:
		/// ChaseOutbound.RelationshipId - Relationship.RelationshipId
		/// </summary>
		public virtual IEntityRelation RelationshipEntityUsingRelationshipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Relationship", false);
				relation.AddEntityFieldPair(RelationshipFields.RelationshipId, ChaseOutboundFields.RelationshipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RelationshipEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", true);
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
