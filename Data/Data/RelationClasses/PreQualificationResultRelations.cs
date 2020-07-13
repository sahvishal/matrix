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
	/// <summary>Implements the static Relations variant for the entity: PreQualificationResult. </summary>
	public partial class PreQualificationResultRelations
	{
		/// <summary>CTor</summary>
		public PreQualificationResultRelations()
		{
		}

		/// <summary>Gets all relations of the PreQualificationResultEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CallsEntityUsingCallId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.LookupEntityUsingHighCholestrol);
			toReturn.Add(this.LookupEntityUsingOverWeight);
			toReturn.Add(this.LookupEntityUsingSmoker);
			toReturn.Add(this.LookupEntityUsingDiabetic);
			toReturn.Add(this.LookupEntityUsingChestPain);
			toReturn.Add(this.LookupEntityUsingAgeOverPreQualificationQuestion);
			toReturn.Add(this.LookupEntityUsingHighBloodPressure);
			toReturn.Add(this.LookupEntityUsingHeartDisease);
			toReturn.Add(this.LookupEntityUsingDiagnosedHeartProblem);
			toReturn.Add(this.TempCartEntityUsingTempCartId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and CallsEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.CallId - Calls.CallId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingCallId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Calls", false);
				relation.AddEntityFieldPair(CallsFields.CallId, PreQualificationResultFields.CallId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, PreQualificationResultFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, PreQualificationResultFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.HighCholestrol - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingHighCholestrol
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup______", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.HighCholestrol);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.OverWeight - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingOverWeight
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_______", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.OverWeight);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.Smoker - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingSmoker
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup________", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.Smoker);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.Diabetic - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDiabetic
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.Diabetic);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.ChestPain - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingChestPain
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.ChestPain);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.AgeOverPreQualificationQuestion - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingAgeOverPreQualificationQuestion
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.AgeOverPreQualificationQuestion);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.HighBloodPressure - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingHighBloodPressure
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_____", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.HighBloodPressure);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.HeartDisease - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingHeartDisease
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup____", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.HeartDisease);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.DiagnosedHeartProblem - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDiagnosedHeartProblem
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup___", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.DiagnosedHeartProblem);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PreQualificationResultEntity and TempCartEntity over the m:1 relation they have, using the relation between the fields:
		/// PreQualificationResult.TempCartId - TempCart.Id
		/// </summary>
		public virtual IEntityRelation TempCartEntityUsingTempCartId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TempCart", false);
				relation.AddEntityFieldPair(TempCartFields.Id, PreQualificationResultFields.TempCartId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", true);
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
