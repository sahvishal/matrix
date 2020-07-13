///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:53
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
#if !CF
using System.Runtime.Serialization;
#endif

using Falcon.Data;
using Falcon.Data.FactoryClasses;
using Falcon.Data.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.TypedViewClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>
	/// Typed datatable for the view 'MedicalVendorEarningInfo'.<br/><br/>
	/// 
	/// </summary>
	/// <remarks>
	/// The code doesn't support any changing of data. Users who do that are on their own.
	/// It also doesn't support any event throwing. This view should be used as a base for readonly databinding
	/// or dataview construction.
	/// </remarks>
#if !CF
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
#endif	
	public partial class MedicalVendorEarningInfoTypedView : TypedViewBase<MedicalVendorEarningInfoRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnOrganizationRoleUserId;
		private DataColumn _columnOrganizationId;
		private DataColumn _columnPhysicianAmountEarned;
		private IEntityFields2	_fields;
		
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		#endregion

		#region Class Constants
		/// <summary>
		/// The amount of fields in the resultset.
		/// </summary>
		private const int AmountOfFields = 3;
		#endregion


		/// <summary>
		/// Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. 
		/// </summary>
		static MedicalVendorEarningInfoTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public MedicalVendorEarningInfoTypedView():base("MedicalVendorEarningInfo")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MedicalVendorEarningInfoTypedView(SerializationInfo info, StreamingContext context):base(info, context)
		{
			if (SerializationHelper.Optimization == SerializationOptimization.None)
			{
				InitMembers();
			}
		}
#endif		
		
		/// <summary>
		/// Gets the IEntityFields2 collection of fields of this typed view. Use this method in combination with the FetchTypedView() methods in 
		/// DataAccessAdapter.
		/// </summary>
		/// <returns>Ready to use IEntityFields2 collection object.</returns>
		public virtual IEntityFields2 GetFieldsInfo()
		{
			return _fields;
		}


		/// <summary>Gets an array of all MedicalVendorEarningInfoRow objects.</summary>
		/// <returns>Array with MedicalVendorEarningInfoRow objects</returns>
		public new MedicalVendorEarningInfoRow[] Select()
		{
			return (MedicalVendorEarningInfoRow[])base.Select();
		}


		/// <summary>Gets an array of all MedicalVendorEarningInfoRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with MedicalVendorEarningInfoRow objects</returns>
		public new MedicalVendorEarningInfoRow[] Select(string filterExpression)
		{
			return (MedicalVendorEarningInfoRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all MedicalVendorEarningInfoRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with MedicalVendorEarningInfoRow objects</returns>
		public new MedicalVendorEarningInfoRow[] Select(string filterExpression, string sort)
		{
			return (MedicalVendorEarningInfoRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all MedicalVendorEarningInfoRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with MedicalVendorEarningInfoRow objects</returns>
		public new MedicalVendorEarningInfoRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (MedicalVendorEarningInfoRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new MedicalVendorEarningInfoRow(rowBuilder);
		}


		/// <summary>
		/// Initializes the hashtables for the typed view type and typed view field custom properties. 
		/// </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Hashtable();
			_fieldsCustomProperties = new Hashtable();

			Hashtable fieldHashtable = null;
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrganizationRoleUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PhysicianAmountEarned", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "MedicalVendorEarningInfo";		
			_columnOrganizationRoleUserId = new DataColumn("OrganizationRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnOrganizationRoleUserId.ReadOnly = true;
			_columnOrganizationRoleUserId.Caption = @"OrganizationRoleUserId";
			this.Columns.Add(_columnOrganizationRoleUserId);
			_columnOrganizationId = new DataColumn("OrganizationId", typeof(System.Int64), null, MappingType.Element);
			_columnOrganizationId.ReadOnly = true;
			_columnOrganizationId.Caption = @"OrganizationId";
			this.Columns.Add(_columnOrganizationId);
			_columnPhysicianAmountEarned = new DataColumn("PhysicianAmountEarned", typeof(System.Decimal), null, MappingType.Element);
			_columnPhysicianAmountEarned.ReadOnly = true;
			_columnPhysicianAmountEarned.Caption = @"PhysicianAmountEarned";
			this.Columns.Add(_columnPhysicianAmountEarned);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.MedicalVendorEarningInfoTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call _fields.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}


		/// <summary>
		/// Initializes the members, after a clone action.
		/// </summary>
		private void InitMembers()
		{
			_columnOrganizationRoleUserId = this.Columns["OrganizationRoleUserId"];
			_columnOrganizationId = this.Columns["OrganizationId"];
			_columnPhysicianAmountEarned = this.Columns["PhysicianAmountEarned"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.MedicalVendorEarningInfoTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(MedicalVendorEarningInfoRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			MedicalVendorEarningInfoTypedView cloneToReturn = ((MedicalVendorEarningInfoTypedView)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}

#if !CF			
		/// <summary>
		/// Creates a new instance of the DataTable class.
		/// </summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new MedicalVendorEarningInfoTypedView();
		}
#endif

		#region Class Property Declarations
		/// <summary>
		/// Returns the amount of rows in this typed view.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public int Count 
		{
			get 
			{
				return this.Rows.Count;
			}
		}
		
		/// <summary>
		/// The custom properties for this TypedView type.
		/// </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary>
		/// The custom properties for the type of this TypedView instance.
		/// </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[System.ComponentModel.Browsable(false)]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return MedicalVendorEarningInfoTypedView.CustomProperties;}
		}

		/// <summary>
		/// The custom properties for the fields of this TypedView type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. 
		/// </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary>
		/// The custom properties for the fields of the type of this TypedView instance. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. 
		/// </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[System.ComponentModel.Browsable(false)]
		public virtual Hashtable FieldsCustomPropertiesOfType
		{
			get { return MedicalVendorEarningInfoTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public MedicalVendorEarningInfoRow this[int index] 
		{
			get 
			{
				return ((MedicalVendorEarningInfoRow)(this.Rows[index]));
			}
		}

	
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrganizationRoleUserId
		/// </summary>
		internal DataColumn OrganizationRoleUserIdColumn 
		{
			get { return _columnOrganizationRoleUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrganizationId
		/// </summary>
		internal DataColumn OrganizationIdColumn 
		{
			get { return _columnOrganizationId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PhysicianAmountEarned
		/// </summary>
		internal DataColumn PhysicianAmountEarnedColumn 
		{
			get { return _columnPhysicianAmountEarned; }
		}
    
		
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalColumnProperties
		// __LLBLGENPRO_USER_CODE_REGION_END
 		#endregion

		#region Custom TypedView code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included Code

		#endregion
	}


	/// <summary>
	/// Typed datarow for the typed datatable MedicalVendorEarningInfo
	/// </summary>
	public partial class MedicalVendorEarningInfoRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private MedicalVendorEarningInfoTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal MedicalVendorEarningInfoRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((MedicalVendorEarningInfoTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field OrganizationRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningInfo"."OrganizationRoleUserId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 OrganizationRoleUserId 
		{
			get 
			{
				if(IsOrganizationRoleUserIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.OrganizationRoleUserIdColumn];
				}
			}
			set 
			{
				this[_parent.OrganizationRoleUserIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OrganizationRoleUserId is NULL, false otherwise.
		/// </summary>
		public bool IsOrganizationRoleUserIdNull() 
		{
			return IsNull(_parent.OrganizationRoleUserIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field OrganizationRoleUserId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOrganizationRoleUserIdNull() 
		{
			this[_parent.OrganizationRoleUserIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OrganizationId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningInfo"."OrganizationId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 OrganizationId 
		{
			get 
			{
				if(IsOrganizationIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.OrganizationIdColumn];
				}
			}
			set 
			{
				this[_parent.OrganizationIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OrganizationId is NULL, false otherwise.
		/// </summary>
		public bool IsOrganizationIdNull() 
		{
			return IsNull(_parent.OrganizationIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field OrganizationId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOrganizationIdNull() 
		{
			this[_parent.OrganizationIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PhysicianAmountEarned<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningInfo"."PhysicianAmountEarned"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 18, 2, 0
		/// </remarks>
		public System.Decimal PhysicianAmountEarned 
		{
			get 
			{
				if(IsPhysicianAmountEarnedNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.PhysicianAmountEarnedColumn];
				}
			}
			set 
			{
				this[_parent.PhysicianAmountEarnedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PhysicianAmountEarned is NULL, false otherwise.
		/// </summary>
		public bool IsPhysicianAmountEarnedNull() 
		{
			return IsNull(_parent.PhysicianAmountEarnedColumn);
		}

		/// <summary>
		/// Sets the TypedView field PhysicianAmountEarned to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPhysicianAmountEarnedNull() 
		{
			this[_parent.PhysicianAmountEarnedColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
