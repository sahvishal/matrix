///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:41
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
	/// <summary>Implements the static Relations variant for the entity: CheckListGroup. </summary>
	public partial class CheckListGroupRelations
	{
		/// <summary>CTor</summary>
		public CheckListGroupRelations()
		{
		}

		/// <summary>Gets all relations of the CheckListGroupEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CheckListGroupEntityUsingParentId);
			toReturn.Add(this.ChecklistGroupQuestionEntityUsingGroupId);

			toReturn.Add(this.CheckListGroupEntityUsingIdParentId);
			toReturn.Add(this.LookupEntityUsingTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CheckListGroupEntity and CheckListGroupEntity over the 1:n relation they have, using the relation between the fields:
		/// CheckListGroup.Id - CheckListGroup.ParentId
		/// </summary>
		public virtual IEntityRelation CheckListGroupEntityUsingParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListGroup_" , true);
				relation.AddEntityFieldPair(CheckListGroupFields.Id, CheckListGroupFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListGroupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListGroupEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CheckListGroupEntity and ChecklistGroupQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// CheckListGroup.Id - ChecklistGroupQuestion.GroupId
		/// </summary>
		public virtual IEntityRelation ChecklistGroupQuestionEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChecklistGroupQuestion" , true);
				relation.AddEntityFieldPair(CheckListGroupFields.Id, ChecklistGroupQuestionFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListGroupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChecklistGroupQuestionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CheckListGroupEntity and CheckListGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// CheckListGroup.ParentId - CheckListGroup.Id
		/// </summary>
		public virtual IEntityRelation CheckListGroupEntityUsingIdParentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListGroup", false);
				relation.AddEntityFieldPair(CheckListGroupFields.Id, CheckListGroupFields.ParentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListGroupEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CheckListGroupEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CheckListGroup.TypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CheckListGroupFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListGroupEntity", true);
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
