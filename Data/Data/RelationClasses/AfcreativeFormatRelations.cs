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
	/// <summary>Implements the static Relations variant for the entity: AfcreativeFormat. </summary>
	public partial class AfcreativeFormatRelations
	{
		/// <summary>CTor</summary>
		public AfcreativeFormatRelations()
		{
		}

		/// <summary>Gets all relations of the AfcreativeFormatEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AfcreativeEntityUsingCreativeFormatId);

			toReturn.Add(this.AfchannelEntityUsingChannelId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AfcreativeFormatEntity and AfcreativeEntity over the 1:n relation they have, using the relation between the fields:
		/// AfcreativeFormat.CreativeFormatId - Afcreative.CreativeFormatId
		/// </summary>
		public virtual IEntityRelation AfcreativeEntityUsingCreativeFormatId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afcreative" , true);
				relation.AddEntityFieldPair(AfcreativeFormatFields.CreativeFormatId, AfcreativeFields.CreativeFormatId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcreativeFormatEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcreativeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between AfcreativeFormatEntity and AfchannelEntity over the m:1 relation they have, using the relation between the fields:
		/// AfcreativeFormat.ChannelId - Afchannel.ChannelId
		/// </summary>
		public virtual IEntityRelation AfchannelEntityUsingChannelId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Afchannel", false);
				relation.AddEntityFieldPair(AfchannelFields.ChannelId, AfcreativeFormatFields.ChannelId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfchannelEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcreativeFormatEntity", true);
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
