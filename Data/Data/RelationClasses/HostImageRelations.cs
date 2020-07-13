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
	/// <summary>Implements the static Relations variant for the entity: HostImage. </summary>
	public partial class HostImageRelations
	{
		/// <summary>CTor</summary>
		public HostImageRelations()
		{
		}

		/// <summary>Gets all relations of the HostImageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.FileEntityUsingImageId);
			toReturn.Add(this.LookupEntityUsingHostImageType);
			toReturn.Add(this.ProspectsEntityUsingHostId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between HostImageEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// HostImage.ImageId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingImageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, HostImageFields.ImageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostImageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostImageEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// HostImage.HostImageType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingHostImageType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostImageFields.HostImageType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostImageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between HostImageEntity and ProspectsEntity over the m:1 relation they have, using the relation between the fields:
		/// HostImage.HostId - Prospects.ProspectId
		/// </summary>
		public virtual IEntityRelation ProspectsEntityUsingHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Prospects", false);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, HostImageFields.HostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostImageEntity", true);
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
