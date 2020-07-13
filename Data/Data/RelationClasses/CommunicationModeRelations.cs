﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
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
	/// <summary>Implements the static Relations variant for the entity: CommunicationMode. </summary>
	public partial class CommunicationModeRelations
	{
		/// <summary>CTor</summary>
		public CommunicationModeRelations()
		{
		}

		/// <summary>Gets all relations of the CommunicationModeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventsEntityUsingCommunicationModeId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CommunicationModeEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// CommunicationMode.CommunicationModeId - Events.CommunicationModeId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingCommunicationModeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events" , true);
				relation.AddEntityFieldPair(CommunicationModeFields.CommunicationModeId, EventsFields.CommunicationModeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CommunicationModeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
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