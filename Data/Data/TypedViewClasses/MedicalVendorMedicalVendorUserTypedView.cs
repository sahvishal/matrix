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
	/// Typed datatable for the view 'MedicalVendorMedicalVendorUser'.<br/><br/>
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
	public partial class MedicalVendorMedicalVendorUserTypedView : TypedViewBase<MedicalVendorMedicalVendorUserRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnOrganizationRoleUserId;
		private DataColumn _columnOrganizationId;
		private DataColumn _columnMedicalVendorName;
		private DataColumn _columnRoleName;
		private DataColumn _columnFirstName;
		private DataColumn _columnMiddleName;
		private DataColumn _columnLastName;
		private DataColumn _columnIsActive;
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
		private const int AmountOfFields = 8;
		#endregion


		/// <summary>
		/// Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. 
		/// </summary>
		static MedicalVendorMedicalVendorUserTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public MedicalVendorMedicalVendorUserTypedView():base("MedicalVendorMedicalVendorUser")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MedicalVendorMedicalVendorUserTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all MedicalVendorMedicalVendorUserRow objects.</summary>
		/// <returns>Array with MedicalVendorMedicalVendorUserRow objects</returns>
		public new MedicalVendorMedicalVendorUserRow[] Select()
		{
			return (MedicalVendorMedicalVendorUserRow[])base.Select();
		}


		/// <summary>Gets an array of all MedicalVendorMedicalVendorUserRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with MedicalVendorMedicalVendorUserRow objects</returns>
		public new MedicalVendorMedicalVendorUserRow[] Select(string filterExpression)
		{
			return (MedicalVendorMedicalVendorUserRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all MedicalVendorMedicalVendorUserRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with MedicalVendorMedicalVendorUserRow objects</returns>
		public new MedicalVendorMedicalVendorUserRow[] Select(string filterExpression, string sort)
		{
			return (MedicalVendorMedicalVendorUserRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all MedicalVendorMedicalVendorUserRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with MedicalVendorMedicalVendorUserRow objects</returns>
		public new MedicalVendorMedicalVendorUserRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (MedicalVendorMedicalVendorUserRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new MedicalVendorMedicalVendorUserRow(rowBuilder);
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

			_fieldsCustomProperties.Add("MedicalVendorName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("RoleName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "MedicalVendorMedicalVendorUser";		
			_columnOrganizationRoleUserId = new DataColumn("OrganizationRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnOrganizationRoleUserId.ReadOnly = true;
			_columnOrganizationRoleUserId.Caption = @"OrganizationRoleUserId";
			this.Columns.Add(_columnOrganizationRoleUserId);
			_columnOrganizationId = new DataColumn("OrganizationId", typeof(System.Int64), null, MappingType.Element);
			_columnOrganizationId.ReadOnly = true;
			_columnOrganizationId.Caption = @"OrganizationId";
			this.Columns.Add(_columnOrganizationId);
			_columnMedicalVendorName = new DataColumn("MedicalVendorName", typeof(System.String), null, MappingType.Element);
			_columnMedicalVendorName.ReadOnly = true;
			_columnMedicalVendorName.Caption = @"MedicalVendorName";
			this.Columns.Add(_columnMedicalVendorName);
			_columnRoleName = new DataColumn("RoleName", typeof(System.String), null, MappingType.Element);
			_columnRoleName.ReadOnly = true;
			_columnRoleName.Caption = @"RoleName";
			this.Columns.Add(_columnRoleName);
			_columnFirstName = new DataColumn("FirstName", typeof(System.String), null, MappingType.Element);
			_columnFirstName.ReadOnly = true;
			_columnFirstName.Caption = @"FirstName";
			this.Columns.Add(_columnFirstName);
			_columnMiddleName = new DataColumn("MiddleName", typeof(System.String), null, MappingType.Element);
			_columnMiddleName.ReadOnly = true;
			_columnMiddleName.Caption = @"MiddleName";
			this.Columns.Add(_columnMiddleName);
			_columnLastName = new DataColumn("LastName", typeof(System.String), null, MappingType.Element);
			_columnLastName.ReadOnly = true;
			_columnLastName.Caption = @"LastName";
			this.Columns.Add(_columnLastName);
			_columnIsActive = new DataColumn("IsActive", typeof(System.Boolean), null, MappingType.Element);
			_columnIsActive.ReadOnly = true;
			_columnIsActive.Caption = @"IsActive";
			this.Columns.Add(_columnIsActive);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.MedicalVendorMedicalVendorUserTypedView);
			
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
			_columnMedicalVendorName = this.Columns["MedicalVendorName"];
			_columnRoleName = this.Columns["RoleName"];
			_columnFirstName = this.Columns["FirstName"];
			_columnMiddleName = this.Columns["MiddleName"];
			_columnLastName = this.Columns["LastName"];
			_columnIsActive = this.Columns["IsActive"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.MedicalVendorMedicalVendorUserTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(MedicalVendorMedicalVendorUserRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			MedicalVendorMedicalVendorUserTypedView cloneToReturn = ((MedicalVendorMedicalVendorUserTypedView)(base.Clone()));
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
			return new MedicalVendorMedicalVendorUserTypedView();
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
			get { return MedicalVendorMedicalVendorUserTypedView.CustomProperties;}
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
			get { return MedicalVendorMedicalVendorUserTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public MedicalVendorMedicalVendorUserRow this[int index] 
		{
			get 
			{
				return ((MedicalVendorMedicalVendorUserRow)(this.Rows[index]));
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
		/// Returns the column object belonging to the TypedView field MedicalVendorName
		/// </summary>
		internal DataColumn MedicalVendorNameColumn 
		{
			get { return _columnMedicalVendorName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field RoleName
		/// </summary>
		internal DataColumn RoleNameColumn 
		{
			get { return _columnRoleName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field FirstName
		/// </summary>
		internal DataColumn FirstNameColumn 
		{
			get { return _columnFirstName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field MiddleName
		/// </summary>
		internal DataColumn MiddleNameColumn 
		{
			get { return _columnMiddleName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field LastName
		/// </summary>
		internal DataColumn LastNameColumn 
		{
			get { return _columnLastName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsActive
		/// </summary>
		internal DataColumn IsActiveColumn 
		{
			get { return _columnIsActive; }
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
	/// Typed datarow for the typed datatable MedicalVendorMedicalVendorUser
	/// </summary>
	public partial class MedicalVendorMedicalVendorUserRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private MedicalVendorMedicalVendorUserTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal MedicalVendorMedicalVendorUserRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((MedicalVendorMedicalVendorUserTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field OrganizationRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorMedicalVendorUser"."OrganizationRoleUserId"<br/>
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
		/// Mapped on view field: "vw_MedicalVendorMedicalVendorUser"."OrganizationId"<br/>
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
		/// Gets / sets the value of the TypedView field MedicalVendorName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorMedicalVendorUser"."MedicalVendorName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 512
		/// </remarks>
		public System.String MedicalVendorName 
		{
			get 
			{
				if(IsMedicalVendorNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.MedicalVendorNameColumn];
				}
			}
			set 
			{
				this[_parent.MedicalVendorNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field MedicalVendorName is NULL, false otherwise.
		/// </summary>
		public bool IsMedicalVendorNameNull() 
		{
			return IsNull(_parent.MedicalVendorNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field MedicalVendorName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetMedicalVendorNameNull() 
		{
			this[_parent.MedicalVendorNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field RoleName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorMedicalVendorUser"."RoleName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 512
		/// </remarks>
		public System.String RoleName 
		{
			get 
			{
				if(IsRoleNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.RoleNameColumn];
				}
			}
			set 
			{
				this[_parent.RoleNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field RoleName is NULL, false otherwise.
		/// </summary>
		public bool IsRoleNameNull() 
		{
			return IsNull(_parent.RoleNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field RoleName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetRoleNameNull() 
		{
			this[_parent.RoleNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field FirstName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorMedicalVendorUser"."FirstName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String FirstName 
		{
			get 
			{
				if(IsFirstNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.FirstNameColumn];
				}
			}
			set 
			{
				this[_parent.FirstNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field FirstName is NULL, false otherwise.
		/// </summary>
		public bool IsFirstNameNull() 
		{
			return IsNull(_parent.FirstNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field FirstName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetFirstNameNull() 
		{
			this[_parent.FirstNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field MiddleName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorMedicalVendorUser"."MiddleName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String MiddleName 
		{
			get 
			{
				if(IsMiddleNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.MiddleNameColumn];
				}
			}
			set 
			{
				this[_parent.MiddleNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field MiddleName is NULL, false otherwise.
		/// </summary>
		public bool IsMiddleNameNull() 
		{
			return IsNull(_parent.MiddleNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field MiddleName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetMiddleNameNull() 
		{
			this[_parent.MiddleNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field LastName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorMedicalVendorUser"."LastName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String LastName 
		{
			get 
			{
				if(IsLastNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.LastNameColumn];
				}
			}
			set 
			{
				this[_parent.LastNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field LastName is NULL, false otherwise.
		/// </summary>
		public bool IsLastNameNull() 
		{
			return IsNull(_parent.LastNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field LastName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetLastNameNull() 
		{
			this[_parent.LastNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsActive<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorMedicalVendorUser"."IsActive"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean IsActive 
		{
			get 
			{
				if(IsIsActiveNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.IsActiveColumn];
				}
			}
			set 
			{
				this[_parent.IsActiveColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsActive is NULL, false otherwise.
		/// </summary>
		public bool IsIsActiveNull() 
		{
			return IsNull(_parent.IsActiveColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsActive to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsActiveNull() 
		{
			this[_parent.IsActiveColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
