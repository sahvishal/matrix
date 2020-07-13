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
	/// <summary>Implements the static Relations variant for the entity: EventCustomerResultBloodLab. </summary>
	public partial class EventCustomerResultBloodLabRelations
	{
		/// <summary>CTor</summary>
		public EventCustomerResultBloodLabRelations()
		{
		}

		/// <summary>Gets all relations of the EventCustomerResultBloodLabEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();

			toReturn.Add(this.EventCustomerResultEntityUsingEventCustomerResultId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserid);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultBloodLabEntity and EventCustomerResultEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomerResultBloodLab.EventCustomerResultId - EventCustomerResult.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerResult", false);



				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, EventCustomerResultBloodLabFields.EventCustomerResultId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultBloodLabEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomerResultBloodLabEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomerResultBloodLab.CreatedByOrgRoleUserid - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultBloodLabFields.CreatedByOrgRoleUserid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultBloodLabEntity", true);
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
