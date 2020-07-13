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
	/// <summary>Implements the static Relations variant for the entity: EmailTemplateMacro. </summary>
	public partial class EmailTemplateMacroRelations
	{
		/// <summary>CTor</summary>
		public EmailTemplateMacroRelations()
		{
		}

		/// <summary>Gets all relations of the EmailTemplateMacroEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EmailTemplateEntityUsingEmailTemplateId);
			toReturn.Add(this.TemplateMacroEntityUsingTemplateMacroId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EmailTemplateMacroEntity and EmailTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// EmailTemplateMacro.EmailTemplateId - EmailTemplate.EmailTemplateId
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingEmailTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EmailTemplate", false);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, EmailTemplateMacroFields.EmailTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateMacroEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EmailTemplateMacroEntity and TemplateMacroEntity over the m:1 relation they have, using the relation between the fields:
		/// EmailTemplateMacro.TemplateMacroId - TemplateMacro.Id
		/// </summary>
		public virtual IEntityRelation TemplateMacroEntityUsingTemplateMacroId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TemplateMacro", false);
				relation.AddEntityFieldPair(TemplateMacroFields.Id, EmailTemplateMacroFields.TemplateMacroId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TemplateMacroEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateMacroEntity", true);
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
