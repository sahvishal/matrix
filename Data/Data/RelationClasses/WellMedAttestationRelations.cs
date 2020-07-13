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
	/// <summary>Implements the static Relations variant for the entity: WellMedAttestation. </summary>
	public partial class WellMedAttestationRelations
	{
		/// <summary>CTor</summary>
		public WellMedAttestationRelations()
		{
		}

		/// <summary>Gets all relations of the WellMedAttestationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.EventCustomerResultEntityUsingEventCustomerResultId);
			toReturn.Add(this.FileEntityUsingProviderSignatureFileId);
			toReturn.Add(this.LookupEntityUsingStatusId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between WellMedAttestationEntity and EventCustomerResultEntity over the m:1 relation they have, using the relation between the fields:
		/// WellMedAttestation.EventCustomerResultId - EventCustomerResult.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventCustomerResult", false);
				relation.AddEntityFieldPair(EventCustomerResultFields.EventCustomerResultId, WellMedAttestationFields.EventCustomerResultId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WellMedAttestationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between WellMedAttestationEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// WellMedAttestation.ProviderSignatureFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingProviderSignatureFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, WellMedAttestationFields.ProviderSignatureFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WellMedAttestationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between WellMedAttestationEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// WellMedAttestation.StatusId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, WellMedAttestationFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WellMedAttestationEntity", true);
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
