///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:42
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
	/// <summary>Implements the static Relations variant for the entity: ZipRadiusDistance. </summary>
	public partial class ZipRadiusDistanceRelations
	{
		/// <summary>CTor</summary>
		public ZipRadiusDistanceRelations()
		{
		}

		/// <summary>Gets all relations of the ZipRadiusDistanceEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ZipEntityUsingSourceZipId);
			toReturn.Add(this.ZipEntityUsingDestinationZipId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ZipRadiusDistanceEntity and ZipEntity over the m:1 relation they have, using the relation between the fields:
		/// ZipRadiusDistance.SourceZipId - Zip.ZipId
		/// </summary>
		public virtual IEntityRelation ZipEntityUsingSourceZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Zip_", false);
				relation.AddEntityFieldPair(ZipFields.ZipId, ZipRadiusDistanceFields.SourceZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipRadiusDistanceEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ZipRadiusDistanceEntity and ZipEntity over the m:1 relation they have, using the relation between the fields:
		/// ZipRadiusDistance.DestinationZipId - Zip.ZipId
		/// </summary>
		public virtual IEntityRelation ZipEntityUsingDestinationZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Zip", false);
				relation.AddEntityFieldPair(ZipFields.ZipId, ZipRadiusDistanceFields.DestinationZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipRadiusDistanceEntity", true);
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
