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
	/// <summary>Implements the static Relations variant for the entity: Relationship. </summary>
	public partial class RelationshipRelations
	{
		/// <summary>CTor</summary>
		public RelationshipRelations()
		{
		}

		/// <summary>Gets all relations of the RelationshipEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ChaseOutboundEntityUsingRelationshipId);
			toReturn.Add(this.GuardianDetailsEntityUsingRelationshipId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between RelationshipEntity and ChaseOutboundEntity over the 1:n relation they have, using the relation between the fields:
		/// Relationship.RelationshipId - ChaseOutbound.RelationshipId
		/// </summary>
		public virtual IEntityRelation ChaseOutboundEntityUsingRelationshipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaseOutbound" , true);
				relation.AddEntityFieldPair(RelationshipFields.RelationshipId, ChaseOutboundFields.RelationshipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RelationshipEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RelationshipEntity and GuardianDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Relationship.RelationshipId - GuardianDetails.RelationshipId
		/// </summary>
		public virtual IEntityRelation GuardianDetailsEntityUsingRelationshipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GuardianDetails" , true);
				relation.AddEntityFieldPair(RelationshipFields.RelationshipId, GuardianDetailsFields.RelationshipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RelationshipEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GuardianDetailsEntity", false);
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
