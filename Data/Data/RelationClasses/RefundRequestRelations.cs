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
	/// <summary>Implements the static Relations variant for the entity: RefundRequest. </summary>
	public partial class RefundRequestRelations
	{
		/// <summary>CTor</summary>
		public RefundRequestRelations()
		{
		}

		/// <summary>Gets all relations of the RefundRequestEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventAppointmentCancellationLogEntityUsingRefundRequestId);
			toReturn.Add(this.RefundRequestGiftCertificateEntityUsingRefundRequestId);

			toReturn.Add(this.LookupEntityUsingRequestStatus);
			toReturn.Add(this.OrderEntityUsingOrderId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingProcessedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between RefundRequestEntity and EventAppointmentCancellationLogEntity over the 1:n relation they have, using the relation between the fields:
		/// RefundRequest.RefundRequestId - EventAppointmentCancellationLog.RefundRequestId
		/// </summary>
		public virtual IEntityRelation EventAppointmentCancellationLogEntityUsingRefundRequestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentCancellationLog" , true);
				relation.AddEntityFieldPair(RefundRequestFields.RefundRequestId, EventAppointmentCancellationLogFields.RefundRequestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RefundRequestEntity and RefundRequestGiftCertificateEntity over the 1:n relation they have, using the relation between the fields:
		/// RefundRequest.RefundRequestId - RefundRequestGiftCertificate.RefundRequestId
		/// </summary>
		public virtual IEntityRelation RefundRequestGiftCertificateEntityUsingRefundRequestId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RefundRequestGiftCertificate" , true);
				relation.AddEntityFieldPair(RefundRequestFields.RefundRequestId, RefundRequestGiftCertificateFields.RefundRequestId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestGiftCertificateEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between RefundRequestEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// RefundRequest.RequestStatus - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingRequestStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, RefundRequestFields.RequestStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RefundRequestEntity and OrderEntity over the m:1 relation they have, using the relation between the fields:
		/// RefundRequest.OrderId - Order.OrderId
		/// </summary>
		public virtual IEntityRelation OrderEntityUsingOrderId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Order", false);
				relation.AddEntityFieldPair(OrderFields.OrderId, RefundRequestFields.OrderId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RefundRequestEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// RefundRequest.ProcessedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingProcessedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, RefundRequestFields.ProcessedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RefundRequestEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// RefundRequest.RequestedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, RefundRequestFields.RequestedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", true);
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
