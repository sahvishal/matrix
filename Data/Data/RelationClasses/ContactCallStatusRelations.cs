///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: ContactCallStatus. </summary>
	public partial class ContactCallStatusRelations
	{
		/// <summary>CTor</summary>
		public ContactCallStatusRelations()
		{
		}

		/// <summary>Gets all relations of the ContactCallStatusEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ContactCallEntityUsingContactCallStatusId);
			toReturn.Add(this.ContactMeetingEntityUsingContactMeetingStatusId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ContactCallStatusEntity and ContactCallEntity over the 1:n relation they have, using the relation between the fields:
		/// ContactCallStatus.ContactCallStatusId - ContactCall.ContactCallStatusId
		/// </summary>
		public virtual IEntityRelation ContactCallEntityUsingContactCallStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactCall" , true);
				relation.AddEntityFieldPair(ContactCallStatusFields.ContactCallStatusId, ContactCallFields.ContactCallStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ContactCallStatusEntity and ContactMeetingEntity over the 1:n relation they have, using the relation between the fields:
		/// ContactCallStatus.ContactCallStatusId - ContactMeeting.ContactMeetingStatusId
		/// </summary>
		public virtual IEntityRelation ContactMeetingEntityUsingContactMeetingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactMeeting" , true);
				relation.AddEntityFieldPair(ContactCallStatusFields.ContactCallStatusId, ContactMeetingFields.ContactMeetingStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactMeetingEntity", false);
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
