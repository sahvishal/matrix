﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: EventPackageTest. </summary>
	public partial class EventPackageTestRelations
	{
		/// <summary>CTor</summary>
		public EventPackageTestRelations()
		{
		}

		/// <summary>Gets all relations of the EventPackageTestEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventPackageDetailsEntityUsingEventPackageId);
			toReturn.Add(this.EventTestEntityUsingEventTestId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EventPackageTestEntity and EventPackageDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPackageTest.EventPackageId - EventPackageDetails.EventPackageId
		/// </summary>
		public virtual IEntityRelation EventPackageDetailsEntityUsingEventPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventPackageDetails", false);
				relation.AddEntityFieldPair(EventPackageDetailsFields.EventPackageId, EventPackageTestFields.EventPackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageTestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventPackageTestEntity and EventTestEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPackageTest.EventTestId - EventTest.EventTestId
		/// </summary>
		public virtual IEntityRelation EventTestEntityUsingEventTestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventTest", false);
				relation.AddEntityFieldPair(EventTestFields.EventTestId, EventPackageTestFields.EventTestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageTestEntity", true);
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