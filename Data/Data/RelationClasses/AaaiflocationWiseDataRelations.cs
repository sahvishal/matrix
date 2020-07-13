///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:06 AM
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
	/// <summary>Implements the static Relations variant for the entity: AaaiflocationWiseData. </summary>
	public partial class AaaiflocationWiseDataRelations
	{
		/// <summary>CTor</summary>
		public AaaiflocationWiseDataRelations()
		{
		}

		/// <summary>Gets all relations of the AaaiflocationWiseDataEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.AaatestIncidentalFindingsEntityUsingAaatestIncidentalFindingsId);
			toReturn.Add(this.IflocationMasterEntityUsingIflocationMasterId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AaaiflocationWiseDataEntity and AaatestIncidentalFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// AaaiflocationWiseData.AaatestIncidentalFindingsId - AaatestIncidentalFindings.AaatestIncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation AaatestIncidentalFindingsEntityUsingAaatestIncidentalFindingsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AaatestIncidentalFindings", false);
				relation.AddEntityFieldPair(AaatestIncidentalFindingsFields.AaatestIncidentalFindingsId, AaaiflocationWiseDataFields.AaatestIncidentalFindingsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaatestIncidentalFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaaiflocationWiseDataEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AaaiflocationWiseDataEntity and IflocationMasterEntity over the m:1 relation they have, using the relation between the fields:
		/// AaaiflocationWiseData.IflocationMasterId - IflocationMaster.LocationId
		/// </summary>
		public virtual IEntityRelation IflocationMasterEntityUsingIflocationMasterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IflocationMaster", false);
				relation.AddEntityFieldPair(IflocationMasterFields.LocationId, AaaiflocationWiseDataFields.IflocationMasterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IflocationMasterEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AaaiflocationWiseDataEntity", true);
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
