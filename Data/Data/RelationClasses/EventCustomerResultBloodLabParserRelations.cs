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
	/// <summary>Implements the static Relations variant for the entity: EventCustomerResultBloodLabParser. </summary>
	public partial class EventCustomerResultBloodLabParserRelations
	{
		/// <summary>CTor</summary>
		public EventCustomerResultBloodLabParserRelations()
		{
		}

		/// <summary>Gets all relations of the EventCustomerResultBloodLabParserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.EventCustomerResultEntityUsingEventCustomerResultId);
			toReturn.Add(this.LookupEntityUsingBloodLabId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultBloodLabParserEntity and EventCustomerResultEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomerResultBloodLabParser.EventCustomerResultId - EventCustomerResult.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerResult", false);



				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, EventCustomerResultBloodLabParserFields.EventCustomerResultId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultBloodLabParserEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultBloodLabParserEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResultBloodLabParser.BloodLabId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingBloodLabId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventCustomerResultBloodLabParserFields.BloodLabId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultBloodLabParserEntity", true);
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
