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
	/// <summary>Implements the static Relations variant for the entity: ProspectContact. </summary>
	public partial class ProspectContactRelations
	{
		/// <summary>CTor</summary>
		public ProspectContactRelations()
		{
		}

		/// <summary>Gets all relations of the ProspectContactEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ProspectContactRoleMappingEntityUsingProspectContactId);

			toReturn.Add(this.ProspectsEntityUsingProspectId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProspectContactEntity and ProspectContactRoleMappingEntity over the 1:n relation they have, using the relation between the fields:
		/// ProspectContact.ProspectContactId - ProspectContactRoleMapping.ProspectContactId
		/// </summary>
		public virtual IEntityRelation ProspectContactRoleMappingEntityUsingProspectContactId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectContactRoleMapping" , true);
				relation.AddEntityFieldPair(ProspectContactFields.ProspectContactId, ProspectContactRoleMappingFields.ProspectContactId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectContactEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectContactRoleMappingEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ProspectContactEntity and ProspectsEntity over the m:1 relation they have, using the relation between the fields:
		/// ProspectContact.ProspectId - Prospects.ProspectId
		/// </summary>
		public virtual IEntityRelation ProspectsEntityUsingProspectId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Prospects", false);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, ProspectContactFields.ProspectId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectContactEntity", true);
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
