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
	/// <summary>Implements the static Relations variant for the entity: CriticalQuestion. </summary>
	public partial class CriticalQuestionRelations
	{
		/// <summary>CTor</summary>
		public CriticalQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the CriticalQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EventCustomerCriticalQuestionEntityUsingQuestionId);

			toReturn.Add(this.LookupEntityUsingControlType);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CriticalQuestionEntity and EventCustomerCriticalQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// CriticalQuestion.Id - EventCustomerCriticalQuestion.QuestionId
		/// </summary>
		public virtual IEntityRelation EventCustomerCriticalQuestionEntityUsingQuestionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerCriticalQuestion" , true);
				relation.AddEntityFieldPair(CriticalQuestionFields.Id, EventCustomerCriticalQuestionFields.QuestionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CriticalQuestionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerCriticalQuestionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CriticalQuestionEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CriticalQuestion.ControlType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingControlType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CriticalQuestionFields.ControlType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CriticalQuestionEntity", true);
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
