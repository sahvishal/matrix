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
	/// <summary>Implements the static Relations variant for the entity: ChaseCampaign. </summary>
	public partial class ChaseCampaignRelations
	{
		/// <summary>CTor</summary>
		public ChaseCampaignRelations()
		{
		}

		/// <summary>Gets all relations of the ChaseCampaignEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerChaseCampaignEntityUsingChaseCampaignId);

			toReturn.Add(this.ChaseCampaignTypeEntityUsingChaseCampaignTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ChaseCampaignEntity and CustomerChaseCampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// ChaseCampaign.ChaseCampaignId - CustomerChaseCampaign.ChaseCampaignId
		/// </summary>
		public virtual IEntityRelation CustomerChaseCampaignEntityUsingChaseCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerChaseCampaign" , true);
				relation.AddEntityFieldPair(ChaseCampaignFields.ChaseCampaignId, CustomerChaseCampaignFields.ChaseCampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseCampaignEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseCampaignEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ChaseCampaignEntity and ChaseCampaignTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ChaseCampaign.ChaseCampaignTypeId - ChaseCampaignType.ChaseCampaignTypeId
		/// </summary>
		public virtual IEntityRelation ChaseCampaignTypeEntityUsingChaseCampaignTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ChaseCampaignType", false);
				relation.AddEntityFieldPair(ChaseCampaignTypeFields.ChaseCampaignTypeId, ChaseCampaignFields.ChaseCampaignTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseCampaignTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseCampaignEntity", true);
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
