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
	/// <summary>Implements the static Relations variant for the entity: EventPackageDetails. </summary>
	public partial class EventPackageDetailsRelations
	{
		/// <summary>CTor</summary>
		public EventPackageDetailsRelations()
		{
		}

		/// <summary>Gets all relations of the EventPackageDetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerOrderHistoryEntityUsingEventPackageId);
			toReturn.Add(this.EventPackageOrderItemEntityUsingEventPackageId);
			toReturn.Add(this.EventPackageTestEntityUsingEventPackageId);
			toReturn.Add(this.EventPaymentDetailsEntityUsingEventPackageId);

			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.HafTemplateEntityUsingHafTemplateId);
			toReturn.Add(this.LookupEntityUsingGender);
			toReturn.Add(this.PackageEntityUsingPackageId);
			toReturn.Add(this.PodRoomEntityUsingPodRoomId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and CustomerOrderHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// EventPackageDetails.EventPackageId - CustomerOrderHistory.EventPackageId
		/// </summary>
		public virtual IEntityRelation CustomerOrderHistoryEntityUsingEventPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerOrderHistory" , true);
				relation.AddEntityFieldPair(EventPackageDetailsFields.EventPackageId, CustomerOrderHistoryFields.EventPackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerOrderHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and EventPackageOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// EventPackageDetails.EventPackageId - EventPackageOrderItem.EventPackageId
		/// </summary>
		public virtual IEntityRelation EventPackageOrderItemEntityUsingEventPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPackageOrderItem" , true);
				relation.AddEntityFieldPair(EventPackageDetailsFields.EventPackageId, EventPackageOrderItemFields.EventPackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and EventPackageTestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventPackageDetails.EventPackageId - EventPackageTest.EventPackageId
		/// </summary>
		public virtual IEntityRelation EventPackageTestEntityUsingEventPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPackageTest" , true);
				relation.AddEntityFieldPair(EventPackageDetailsFields.EventPackageId, EventPackageTestFields.EventPackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and EventPaymentDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// EventPackageDetails.EventPackageId - EventPaymentDetails.EventPackageId
		/// </summary>
		public virtual IEntityRelation EventPaymentDetailsEntityUsingEventPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPaymentDetails" , true);
				relation.AddEntityFieldPair(EventPackageDetailsFields.EventPackageId, EventPaymentDetailsFields.EventPackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPaymentDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPackageDetails.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventPackageDetailsFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and HafTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPackageDetails.HafTemplateId - HafTemplate.HaftemplateId
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingHafTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HafTemplate", false);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, EventPackageDetailsFields.HafTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPackageDetails.Gender - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventPackageDetailsFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and PackageEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPackageDetails.PackageId - Package.PackageId
		/// </summary>
		public virtual IEntityRelation PackageEntityUsingPackageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Package", false);
				relation.AddEntityFieldPair(PackageFields.PackageId, EventPackageDetailsFields.PackageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventPackageDetailsEntity and PodRoomEntity over the m:1 relation they have, using the relation between the fields:
		/// EventPackageDetails.PodRoomId - PodRoom.PodRoomId
		/// </summary>
		public virtual IEntityRelation PodRoomEntityUsingPodRoomId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PodRoom", false);
				relation.AddEntityFieldPair(PodRoomFields.PodRoomId, EventPackageDetailsFields.PodRoomId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodRoomEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", true);
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
