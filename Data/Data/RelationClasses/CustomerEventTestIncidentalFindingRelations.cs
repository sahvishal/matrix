///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
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
	/// <summary>Implements the static Relations variant for the entity: CustomerEventTestIncidentalFinding. </summary>
	public partial class CustomerEventTestIncidentalFindingRelations
	{
		/// <summary>CTor</summary>
		public CustomerEventTestIncidentalFindingRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerEventTestIncidentalFindingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerEventTestIncidentalFindingDetailEntityUsingCustomerEventTestIncidentalFindingId);

			toReturn.Add(this.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId);
			toReturn.Add(this.IncidentalFindingsEntityUsingIncidentalFindingId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerEventTestIncidentalFindingEntity and CustomerEventTestIncidentalFindingDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerEventTestIncidentalFinding.CustomerEventTestIncidentalFindingId - CustomerEventTestIncidentalFindingDetail.CustomerEventTestIncidentalFindingId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestIncidentalFindingDetailEntityUsingCustomerEventTestIncidentalFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestIncidentalFindingDetail" , true);
				relation.AddEntityFieldPair(CustomerEventTestIncidentalFindingFields.CustomerEventTestIncidentalFindingId, CustomerEventTestIncidentalFindingDetailFields.CustomerEventTestIncidentalFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingDetailEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CustomerEventTestIncidentalFindingEntity and CustomerEventScreeningTestsEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventTestIncidentalFinding.CustomerEventScreeningTestId - CustomerEventScreeningTests.CustomerEventScreeningTestId
		/// </summary>
		public virtual IEntityRelation CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerEventScreeningTests", false);
				relation.AddEntityFieldPair(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, CustomerEventTestIncidentalFindingFields.CustomerEventScreeningTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventScreeningTestsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerEventTestIncidentalFindingEntity and IncidentalFindingsEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerEventTestIncidentalFinding.IncidentalFindingId - IncidentalFindings.IncidentalFindingsId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingsEntityUsingIncidentalFindingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "IncidentalFindings", false);
				relation.AddEntityFieldPair(IncidentalFindingsFields.IncidentalFindingsId, CustomerEventTestIncidentalFindingFields.IncidentalFindingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestIncidentalFindingEntity", true);
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
