///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:13 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: HostContacts. </summary>
	public partial class HostContactsRelations
	{
		/// <summary>CTor</summary>
		public HostContactsRelations()
		{
		}

		/// <summary>Gets all relations of the HostContactsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.HostsEntityUsingContactId2);
			toReturn.Add(this.HostsEntityUsingContactId1);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between HostContactsEntity and HostsEntity over the 1:n relation they have, using the relation between the fields:
		/// HostContacts.ContactId - Hosts.ContactId2
		/// </summary>
		public virtual IEntityRelation HostsEntityUsingContactId2
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Hosts_" , true);
				relation.AddEntityFieldPair(HostContactsFields.ContactId, HostsFields.ContactId2);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostContactsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HostContactsEntity and HostsEntity over the 1:n relation they have, using the relation between the fields:
		/// HostContacts.ContactId - Hosts.ContactId1
		/// </summary>
		public virtual IEntityRelation HostsEntityUsingContactId1
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Hosts" , true);
				relation.AddEntityFieldPair(HostContactsFields.ContactId, HostsFields.ContactId1);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostContactsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostsEntity", false);
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
