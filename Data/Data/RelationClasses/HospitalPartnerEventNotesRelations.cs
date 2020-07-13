///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:40
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
	/// <summary>Implements the static Relations variant for the entity: HospitalPartnerEventNotes. </summary>
	public partial class HospitalPartnerEventNotesRelations
	{
		/// <summary>CTor</summary>
		public HospitalPartnerEventNotesRelations()
		{
		}

		/// <summary>Gets all relations of the HospitalPartnerEventNotesEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.NotesDetailsEntityUsingNotesId);
			toReturn.Add(this.EventsEntityUsingEventId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEventNotesEntity and NotesDetailsEntity over the 1:1 relation they have, using the relation between the fields:
		/// HospitalPartnerEventNotes.NotesId - NotesDetails.NoteId
		/// </summary>
		public virtual IEntityRelation NotesDetailsEntityUsingNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "NotesDetails", false);



				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, HospitalPartnerEventNotesFields.NotesId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEventNotesEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HospitalPartnerEventNotesEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// HospitalPartnerEventNotes.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, HospitalPartnerEventNotesFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerEventNotesEntity", true);
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
