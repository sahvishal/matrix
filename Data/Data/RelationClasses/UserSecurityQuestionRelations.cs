///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
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
	/// <summary>Implements the static Relations variant for the entity: UserSecurityQuestion. </summary>
	public partial class UserSecurityQuestionRelations
	{
		/// <summary>CTor</summary>
		public UserSecurityQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the UserSecurityQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.SecurityQuestionEntityUsingQuestion3);
			toReturn.Add(this.SecurityQuestionEntityUsingQuestion2);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between UserSecurityQuestionEntity and SecurityQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// UserSecurityQuestion.Question3 - SecurityQuestion.SecurityQuestionId
		/// </summary>
		public virtual IEntityRelation SecurityQuestionEntityUsingQuestion3
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SecurityQuestion_", false);
				relation.AddEntityFieldPair(SecurityQuestionFields.SecurityQuestionId, UserSecurityQuestionFields.Question3);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SecurityQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserSecurityQuestionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between UserSecurityQuestionEntity and SecurityQuestionEntity over the m:1 relation they have, using the relation between the fields:
		/// UserSecurityQuestion.Question2 - SecurityQuestion.SecurityQuestionId
		/// </summary>
		public virtual IEntityRelation SecurityQuestionEntityUsingQuestion2
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SecurityQuestion", false);
				relation.AddEntityFieldPair(SecurityQuestionFields.SecurityQuestionId, UserSecurityQuestionFields.Question2);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SecurityQuestionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserSecurityQuestionEntity", true);
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
