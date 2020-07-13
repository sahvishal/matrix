///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:42
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
	/// <summary>Implements the static Relations variant for the entity: Ndc. </summary>
	public partial class NdcRelations
	{
		/// <summary>CTor</summary>
		public NdcRelations()
		{
		}

		/// <summary>Gets all relations of the NdcEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CurrentMedicationEntityUsingNdcId);
			toReturn.Add(this.EventCustomerCurrentMedicationEntityUsingNdcId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between NdcEntity and CurrentMedicationEntity over the 1:n relation they have, using the relation between the fields:
		/// Ndc.Id - CurrentMedication.NdcId
		/// </summary>
		public virtual IEntityRelation CurrentMedicationEntityUsingNdcId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CurrentMedication" , true);
				relation.AddEntityFieldPair(NdcFields.Id, CurrentMedicationFields.NdcId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NdcEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CurrentMedicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between NdcEntity and EventCustomerCurrentMedicationEntity over the 1:n relation they have, using the relation between the fields:
		/// Ndc.Id - EventCustomerCurrentMedication.NdcId
		/// </summary>
		public virtual IEntityRelation EventCustomerCurrentMedicationEntityUsingNdcId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerCurrentMedication" , true);
				relation.AddEntityFieldPair(NdcFields.Id, EventCustomerCurrentMedicationFields.NdcId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NdcEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerCurrentMedicationEntity", false);
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
