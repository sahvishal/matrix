///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:15 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: PrintVendorPvuser. </summary>
	public partial class PrintVendorPvuserRelations
	{
		/// <summary>CTor</summary>
		public PrintVendorPvuserRelations()
		{
		}

		/// <summary>Gets all relations of the PrintVendorPvuserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.PrintVendorEntityUsingPrintVendorId);
			toReturn.Add(this.PvuserEntityUsingPvuserId);
			toReturn.Add(this.RoleEntityUsingRoleId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PrintVendorPvuserEntity and PrintVendorEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintVendorPvuser.PrintVendorId - PrintVendor.PrintVendorId
		/// </summary>
		public virtual IEntityRelation PrintVendorEntityUsingPrintVendorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PrintVendor", false);
				relation.AddEntityFieldPair(PrintVendorFields.PrintVendorId, PrintVendorPvuserFields.PrintVendorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintVendorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintVendorPvuserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintVendorPvuserEntity and PvuserEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintVendorPvuser.PvuserId - Pvuser.PvuserId
		/// </summary>
		public virtual IEntityRelation PvuserEntityUsingPvuserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Pvuser", false);
				relation.AddEntityFieldPair(PvuserFields.PvuserId, PrintVendorPvuserFields.PvuserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PvuserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintVendorPvuserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PrintVendorPvuserEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// PrintVendorPvuser.RoleId - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, PrintVendorPvuserFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintVendorPvuserEntity", true);
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
