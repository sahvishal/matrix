///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:07 AM
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
	/// <summary>Implements the static Relations variant for the entity: Afcreative. </summary>
	public partial class AfcreativeRelations
	{
		/// <summary>CTor</summary>
		public AfcreativeRelations()
		{
		}

		/// <summary>Gets all relations of the AfcreativeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfcampaignCreativeEntityUsingCreativeId);

			toReturn.Add(this.AfcreativeFormatEntityUsingCreativeFormatId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AfcreativeEntity and AfcampaignCreativeEntity over the 1:n relation they have, using the relation between the fields:
		/// Afcreative.CreativeId - AfcampaignCreative.CreativeId
		/// </summary>
		public virtual IEntityRelation AfcampaignCreativeEntityUsingCreativeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AfcampaignCreative" , true);
				relation.AddEntityFieldPair(AfcreativeFields.CreativeId, AfcampaignCreativeFields.CreativeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcreativeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignCreativeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AfcreativeEntity and AfcreativeFormatEntity over the m:1 relation they have, using the relation between the fields:
		/// Afcreative.CreativeFormatId - AfcreativeFormat.CreativeFormatId
		/// </summary>
		public virtual IEntityRelation AfcreativeFormatEntityUsingCreativeFormatId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfcreativeFormat", false);
				relation.AddEntityFieldPair(AfcreativeFormatFields.CreativeFormatId, AfcreativeFields.CreativeFormatId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcreativeFormatEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcreativeEntity", true);
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
