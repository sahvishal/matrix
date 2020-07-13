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
	/// <summary>Implements the static Relations variant for the entity: CriticalCustomerCommunicationRecord. </summary>
	public partial class CriticalCustomerCommunicationRecordRelations
	{
		/// <summary>CTor</summary>
		public CriticalCustomerCommunicationRecordRelations()
		{
		}

		/// <summary>Gets all relations of the CriticalCustomerCommunicationRecordEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.NotesDetailsEntityUsingNoteId);
			toReturn.Add(this.EventCustomerResultEntityUsingEventCustomerResultId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between CriticalCustomerCommunicationRecordEntity and NotesDetailsEntity over the 1:1 relation they have, using the relation between the fields:
		/// CriticalCustomerCommunicationRecord.NoteId - NotesDetails.NoteId
		/// </summary>
		public virtual IEntityRelation NotesDetailsEntityUsingNoteId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "NotesDetails", false);



				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, CriticalCustomerCommunicationRecordFields.NoteId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CriticalCustomerCommunicationRecordEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CriticalCustomerCommunicationRecordEntity and EventCustomerResultEntity over the m:1 relation they have, using the relation between the fields:
		/// CriticalCustomerCommunicationRecord.EventCustomerResultId - EventCustomerResult.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomerResult", false);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, CriticalCustomerCommunicationRecordFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CriticalCustomerCommunicationRecordEntity", true);
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
