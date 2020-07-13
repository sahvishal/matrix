///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:04 AM
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
	/// <summary>Implements the static Relations variant for the entity: UnableScreenReason. </summary>
	public partial class UnableScreenReasonRelations
	{
		/// <summary>CTor</summary>
		public UnableScreenReasonRelations()
		{
		}

		/// <summary>Gets all relations of the UnableScreenReasonEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AaaunableScreenReasonEntityUsingUnableScreenReasonId);
			toReturn.Add(this.AsiunableScreenReasonEntityUsingUnableScreenReasonId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between UnableScreenReasonEntity and AaaunableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// UnableScreenReason.UnableScreenReasonId - AaaunableScreenReason.UnableScreenReasonId
		/// </summary>
		public virtual IEntityRelation AaaunableScreenReasonEntityUsingUnableScreenReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AaaunableScreenReason" , true);
				relation.AddEntityFieldPair(UnableScreenReasonFields.UnableScreenReasonId, AaaunableScreenReasonFields.UnableScreenReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UnableScreenReasonEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaaunableScreenReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UnableScreenReasonEntity and AsiunableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// UnableScreenReason.UnableScreenReasonId - AsiunableScreenReason.UnableScreenReasonId
		/// </summary>
		public virtual IEntityRelation AsiunableScreenReasonEntityUsingUnableScreenReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AsiunableScreenReason" , true);
				relation.AddEntityFieldPair(UnableScreenReasonFields.UnableScreenReasonId, AsiunableScreenReasonFields.UnableScreenReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UnableScreenReasonEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AsiunableScreenReasonEntity", false);
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
