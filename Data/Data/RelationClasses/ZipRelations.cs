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
	/// <summary>Implements the static Relations variant for the entity: Zip. </summary>
	public partial class ZipRelations
	{
		/// <summary>CTor</summary>
		public ZipRelations()
		{
		}

		/// <summary>Gets all relations of the ZipEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountEventZipSubstituteEntityUsingZipId);
			toReturn.Add(this.AddressEntityUsingZipId);
			toReturn.Add(this.EventZipEntityUsingZipId);
			toReturn.Add(this.TerritoryZipEntityUsingZipId);
			toReturn.Add(this.ZipRadiusDistanceEntityUsingSourceZipId);
			toReturn.Add(this.ZipRadiusDistanceEntityUsingDestinationZipId);

			toReturn.Add(this.CityEntityUsingCityId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ZipEntity and AccountEventZipSubstituteEntity over the 1:n relation they have, using the relation between the fields:
		/// Zip.ZipId - AccountEventZipSubstitute.ZipId
		/// </summary>
		public virtual IEntityRelation AccountEventZipSubstituteEntityUsingZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountEventZipSubstitute" , true);
				relation.AddEntityFieldPair(ZipFields.ZipId, AccountEventZipSubstituteFields.ZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEventZipSubstituteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ZipEntity and AddressEntity over the 1:n relation they have, using the relation between the fields:
		/// Zip.ZipId - Address.ZipId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Address" , true);
				relation.AddEntityFieldPair(ZipFields.ZipId, AddressFields.ZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ZipEntity and EventZipEntity over the 1:n relation they have, using the relation between the fields:
		/// Zip.ZipId - EventZip.ZipId
		/// </summary>
		public virtual IEntityRelation EventZipEntityUsingZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventZip" , true);
				relation.AddEntityFieldPair(ZipFields.ZipId, EventZipFields.ZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventZipEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ZipEntity and TerritoryZipEntity over the 1:n relation they have, using the relation between the fields:
		/// Zip.ZipId - TerritoryZip.ZipId
		/// </summary>
		public virtual IEntityRelation TerritoryZipEntityUsingZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TerritoryZip" , true);
				relation.AddEntityFieldPair(ZipFields.ZipId, TerritoryZipFields.ZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryZipEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ZipEntity and ZipRadiusDistanceEntity over the 1:n relation they have, using the relation between the fields:
		/// Zip.ZipId - ZipRadiusDistance.SourceZipId
		/// </summary>
		public virtual IEntityRelation ZipRadiusDistanceEntityUsingSourceZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ZipRadiusDistance_" , true);
				relation.AddEntityFieldPair(ZipFields.ZipId, ZipRadiusDistanceFields.SourceZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipRadiusDistanceEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ZipEntity and ZipRadiusDistanceEntity over the 1:n relation they have, using the relation between the fields:
		/// Zip.ZipId - ZipRadiusDistance.DestinationZipId
		/// </summary>
		public virtual IEntityRelation ZipRadiusDistanceEntityUsingDestinationZipId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ZipRadiusDistance" , true);
				relation.AddEntityFieldPair(ZipFields.ZipId, ZipRadiusDistanceFields.DestinationZipId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipRadiusDistanceEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ZipEntity and CityEntity over the m:1 relation they have, using the relation between the fields:
		/// Zip.CityId - City.CityId
		/// </summary>
		public virtual IEntityRelation CityEntityUsingCityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "City", false);
				relation.AddEntityFieldPair(CityFields.CityId, ZipFields.CityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ZipEntity", true);
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
