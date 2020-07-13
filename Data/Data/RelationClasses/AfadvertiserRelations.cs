///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: Afadvertiser. </summary>
	public partial class AfadvertiserRelations
	{
		/// <summary>CTor</summary>
		public AfadvertiserRelations()
		{
		}

		/// <summary>Gets all relations of the AfadvertiserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfcampaignEntityUsingAdvertiserId);

			toReturn.Add(this.AfchannelEntityUsingChannelId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AfadvertiserEntity and AfcampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// Afadvertiser.AdvertiserId - Afcampaign.AdvertiserId
		/// </summary>
		public virtual IEntityRelation AfcampaignEntityUsingAdvertiserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afcampaign" , true);
				relation.AddEntityFieldPair(AfadvertiserFields.AdvertiserId, AfcampaignFields.AdvertiserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfadvertiserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AfadvertiserEntity and AfchannelEntity over the m:1 relation they have, using the relation between the fields:
		/// Afadvertiser.ChannelId - Afchannel.ChannelId
		/// </summary>
		public virtual IEntityRelation AfchannelEntityUsingChannelId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afchannel", false);
				relation.AddEntityFieldPair(AfchannelFields.ChannelId, AfadvertiserFields.ChannelId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfchannelEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfadvertiserEntity", true);
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
