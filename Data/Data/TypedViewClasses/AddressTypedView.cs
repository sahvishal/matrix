///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Thursday, April 07, 2011 1:36:32 AM
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
	/// Typed datatable for the view 'Address_'.<br/><br/>
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
	public partial class Address_TypedView : TypedViewBase<Address_Row>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private DataColumn _columnAddressId;
		private DataColumn _columnAddress1;
		private DataColumn _columnAddress2;
		private DataColumn _columnCityId;
		private DataColumn _columnCity;
		private DataColumn _columnStateId;
		private DataColumn _columnState;
		private DataColumn _columnCountryId;
		private DataColumn _columnCountry;
		private DataColumn _columnZipId;
		private DataColumn _columnZipCode;
		private DataColumn _columnPhoneNumber;
		private DataColumn _columnFax;
		private DataColumn _columnIsActive;
		private DataColumn _columnDateCreated;
		private DataColumn _columnDateModified;
		private DataColumn _columnLatitude;
		private DataColumn _columnLongitude;
		private DataColumn _columnVerificationOrgRoleUserId;
		private DataColumn _columnIsManuallyVerified;
		private DataColumn _columnUseLatLogForMapping;
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
		private const int AmountOfFields = 21;
		#endregion


		/// <summary>
		/// Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. 
		/// </summary>
		static Address_TypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public Address_TypedView():base("Address_")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected Address_TypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all Address_Row objects.</summary>
		/// <returns>Array with Address_Row objects</returns>
		public new Address_Row[] Select()
		{
			return (Address_Row[])base.Select();
		}


		/// <summary>Gets an array of all Address_Row objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with Address_Row objects</returns>
		public new Address_Row[] Select(string filterExpression)
		{
			return (Address_Row[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all Address_Row objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with Address_Row objects</returns>
		public new Address_Row[] Select(string filterExpression, string sort)
		{
			return (Address_Row[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all Address_Row objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with Address_Row objects</returns>
		public new Address_Row[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (Address_Row[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new Address_Row(rowBuilder);
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

			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Address1", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Address2", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CityId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("City", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("StateId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("State", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CountryId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Country", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("ZipId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PhoneNumber", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Fax", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Latitude", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Longitude", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("VerificationOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsManuallyVerified", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("UseLatLogForMapping", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "Address_";		
			_columnAddressId = new DataColumn("AddressId", typeof(System.Int64), null, MappingType.Element);
			_columnAddressId.ReadOnly = true;
			_columnAddressId.Caption = @"AddressId";
			this.Columns.Add(_columnAddressId);
			_columnAddress1 = new DataColumn("Address1", typeof(System.String), null, MappingType.Element);
			_columnAddress1.ReadOnly = true;
			_columnAddress1.Caption = @"Address1";
			this.Columns.Add(_columnAddress1);
			_columnAddress2 = new DataColumn("Address2", typeof(System.String), null, MappingType.Element);
			_columnAddress2.ReadOnly = true;
			_columnAddress2.Caption = @"Address2";
			this.Columns.Add(_columnAddress2);
			_columnCityId = new DataColumn("CityId", typeof(System.Int64), null, MappingType.Element);
			_columnCityId.ReadOnly = true;
			_columnCityId.Caption = @"CityId";
			this.Columns.Add(_columnCityId);
			_columnCity = new DataColumn("City", typeof(System.String), null, MappingType.Element);
			_columnCity.ReadOnly = true;
			_columnCity.Caption = @"City";
			this.Columns.Add(_columnCity);
			_columnStateId = new DataColumn("StateId", typeof(System.Int64), null, MappingType.Element);
			_columnStateId.ReadOnly = true;
			_columnStateId.Caption = @"StateId";
			this.Columns.Add(_columnStateId);
			_columnState = new DataColumn("State", typeof(System.String), null, MappingType.Element);
			_columnState.ReadOnly = true;
			_columnState.Caption = @"State";
			this.Columns.Add(_columnState);
			_columnCountryId = new DataColumn("CountryId", typeof(System.Int64), null, MappingType.Element);
			_columnCountryId.ReadOnly = true;
			_columnCountryId.Caption = @"CountryId";
			this.Columns.Add(_columnCountryId);
			_columnCountry = new DataColumn("Country", typeof(System.String), null, MappingType.Element);
			_columnCountry.ReadOnly = true;
			_columnCountry.Caption = @"Country";
			this.Columns.Add(_columnCountry);
			_columnZipId = new DataColumn("ZipId", typeof(System.Int64), null, MappingType.Element);
			_columnZipId.ReadOnly = true;
			_columnZipId.Caption = @"ZipId";
			this.Columns.Add(_columnZipId);
			_columnZipCode = new DataColumn("ZipCode", typeof(System.String), null, MappingType.Element);
			_columnZipCode.ReadOnly = true;
			_columnZipCode.Caption = @"ZipCode";
			this.Columns.Add(_columnZipCode);
			_columnPhoneNumber = new DataColumn("PhoneNumber", typeof(System.String), null, MappingType.Element);
			_columnPhoneNumber.ReadOnly = true;
			_columnPhoneNumber.Caption = @"PhoneNumber";
			this.Columns.Add(_columnPhoneNumber);
			_columnFax = new DataColumn("Fax", typeof(System.String), null, MappingType.Element);
			_columnFax.ReadOnly = true;
			_columnFax.Caption = @"Fax";
			this.Columns.Add(_columnFax);
			_columnIsActive = new DataColumn("IsActive", typeof(System.Boolean), null, MappingType.Element);
			_columnIsActive.ReadOnly = true;
			_columnIsActive.Caption = @"IsActive";
			this.Columns.Add(_columnIsActive);
			_columnDateCreated = new DataColumn("DateCreated", typeof(System.DateTime), null, MappingType.Element);
			_columnDateCreated.ReadOnly = true;
			_columnDateCreated.Caption = @"DateCreated";
			this.Columns.Add(_columnDateCreated);
			_columnDateModified = new DataColumn("DateModified", typeof(System.DateTime), null, MappingType.Element);
			_columnDateModified.ReadOnly = true;
			_columnDateModified.Caption = @"DateModified";
			this.Columns.Add(_columnDateModified);
			_columnLatitude = new DataColumn("Latitude", typeof(System.String), null, MappingType.Element);
			_columnLatitude.ReadOnly = true;
			_columnLatitude.Caption = @"Latitude";
			this.Columns.Add(_columnLatitude);
			_columnLongitude = new DataColumn("Longitude", typeof(System.String), null, MappingType.Element);
			_columnLongitude.ReadOnly = true;
			_columnLongitude.Caption = @"Longitude";
			this.Columns.Add(_columnLongitude);
			_columnVerificationOrgRoleUserId = new DataColumn("VerificationOrgRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnVerificationOrgRoleUserId.ReadOnly = true;
			_columnVerificationOrgRoleUserId.Caption = @"VerificationOrgRoleUserId";
			this.Columns.Add(_columnVerificationOrgRoleUserId);
			_columnIsManuallyVerified = new DataColumn("IsManuallyVerified", typeof(System.Boolean), null, MappingType.Element);
			_columnIsManuallyVerified.ReadOnly = true;
			_columnIsManuallyVerified.Caption = @"IsManuallyVerified";
			this.Columns.Add(_columnIsManuallyVerified);
			_columnUseLatLogForMapping = new DataColumn("UseLatLogForMapping", typeof(System.Boolean), null, MappingType.Element);
			_columnUseLatLogForMapping.ReadOnly = true;
			_columnUseLatLogForMapping.Caption = @"UseLatLogForMapping";
			this.Columns.Add(_columnUseLatLogForMapping);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.Address_TypedView);
			
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
			_columnAddressId = this.Columns["AddressId"];
			_columnAddress1 = this.Columns["Address1"];
			_columnAddress2 = this.Columns["Address2"];
			_columnCityId = this.Columns["CityId"];
			_columnCity = this.Columns["City"];
			_columnStateId = this.Columns["StateId"];
			_columnState = this.Columns["State"];
			_columnCountryId = this.Columns["CountryId"];
			_columnCountry = this.Columns["Country"];
			_columnZipId = this.Columns["ZipId"];
			_columnZipCode = this.Columns["ZipCode"];
			_columnPhoneNumber = this.Columns["PhoneNumber"];
			_columnFax = this.Columns["Fax"];
			_columnIsActive = this.Columns["IsActive"];
			_columnDateCreated = this.Columns["DateCreated"];
			_columnDateModified = this.Columns["DateModified"];
			_columnLatitude = this.Columns["Latitude"];
			_columnLongitude = this.Columns["Longitude"];
			_columnVerificationOrgRoleUserId = this.Columns["VerificationOrgRoleUserId"];
			_columnIsManuallyVerified = this.Columns["IsManuallyVerified"];
			_columnUseLatLogForMapping = this.Columns["UseLatLogForMapping"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.Address_TypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(Address_Row);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			Address_TypedView cloneToReturn = ((Address_TypedView)(base.Clone()));
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
			return new Address_TypedView();
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
			get { return Address_TypedView.CustomProperties;}
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
			get { return Address_TypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public Address_Row this[int index] 
		{
			get 
			{
				return ((Address_Row)(this.Rows[index]));
			}
		}

	
		/// <summary>
		/// Returns the column object belonging to the TypedView field AddressId
		/// </summary>
		internal DataColumn AddressIdColumn 
		{
			get { return _columnAddressId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Address1
		/// </summary>
		internal DataColumn Address1Column 
		{
			get { return _columnAddress1; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Address2
		/// </summary>
		internal DataColumn Address2Column 
		{
			get { return _columnAddress2; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CityId
		/// </summary>
		internal DataColumn CityIdColumn 
		{
			get { return _columnCityId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field City
		/// </summary>
		internal DataColumn CityColumn 
		{
			get { return _columnCity; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field StateId
		/// </summary>
		internal DataColumn StateIdColumn 
		{
			get { return _columnStateId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field State
		/// </summary>
		internal DataColumn StateColumn 
		{
			get { return _columnState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CountryId
		/// </summary>
		internal DataColumn CountryIdColumn 
		{
			get { return _columnCountryId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Country
		/// </summary>
		internal DataColumn CountryColumn 
		{
			get { return _columnCountry; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field ZipId
		/// </summary>
		internal DataColumn ZipIdColumn 
		{
			get { return _columnZipId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field ZipCode
		/// </summary>
		internal DataColumn ZipCodeColumn 
		{
			get { return _columnZipCode; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PhoneNumber
		/// </summary>
		internal DataColumn PhoneNumberColumn 
		{
			get { return _columnPhoneNumber; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Fax
		/// </summary>
		internal DataColumn FaxColumn 
		{
			get { return _columnFax; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsActive
		/// </summary>
		internal DataColumn IsActiveColumn 
		{
			get { return _columnIsActive; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field DateCreated
		/// </summary>
		internal DataColumn DateCreatedColumn 
		{
			get { return _columnDateCreated; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field DateModified
		/// </summary>
		internal DataColumn DateModifiedColumn 
		{
			get { return _columnDateModified; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Latitude
		/// </summary>
		internal DataColumn LatitudeColumn 
		{
			get { return _columnLatitude; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Longitude
		/// </summary>
		internal DataColumn LongitudeColumn 
		{
			get { return _columnLongitude; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field VerificationOrgRoleUserId
		/// </summary>
		internal DataColumn VerificationOrgRoleUserIdColumn 
		{
			get { return _columnVerificationOrgRoleUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsManuallyVerified
		/// </summary>
		internal DataColumn IsManuallyVerifiedColumn 
		{
			get { return _columnIsManuallyVerified; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field UseLatLogForMapping
		/// </summary>
		internal DataColumn UseLatLogForMappingColumn 
		{
			get { return _columnUseLatLogForMapping; }
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
	/// Typed datarow for the typed datatable Address_
	/// </summary>
	public partial class Address_Row : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private Address_TypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal Address_Row(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((Address_TypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field AddressId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."AddressID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 AddressId 
		{
			get 
			{
				if(IsAddressIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.AddressIdColumn];
				}
			}
			set 
			{
				this[_parent.AddressIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AddressId is NULL, false otherwise.
		/// </summary>
		public bool IsAddressIdNull() 
		{
			return IsNull(_parent.AddressIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field AddressId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAddressIdNull() 
		{
			this[_parent.AddressIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Address1<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."Address1"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String Address1 
		{
			get 
			{
				if(IsAddress1Null())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.Address1Column];
				}
			}
			set 
			{
				this[_parent.Address1Column] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Address1 is NULL, false otherwise.
		/// </summary>
		public bool IsAddress1Null() 
		{
			return IsNull(_parent.Address1Column);
		}

		/// <summary>
		/// Sets the TypedView field Address1 to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAddress1Null() 
		{
			this[_parent.Address1Column] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Address2<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."Address2"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String Address2 
		{
			get 
			{
				if(IsAddress2Null())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.Address2Column];
				}
			}
			set 
			{
				this[_parent.Address2Column] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Address2 is NULL, false otherwise.
		/// </summary>
		public bool IsAddress2Null() 
		{
			return IsNull(_parent.Address2Column);
		}

		/// <summary>
		/// Sets the TypedView field Address2 to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAddress2Null() 
		{
			this[_parent.Address2Column] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CityId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."CityID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 CityId 
		{
			get 
			{
				if(IsCityIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.CityIdColumn];
				}
			}
			set 
			{
				this[_parent.CityIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CityId is NULL, false otherwise.
		/// </summary>
		public bool IsCityIdNull() 
		{
			return IsNull(_parent.CityIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field CityId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCityIdNull() 
		{
			this[_parent.CityIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field City<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."City"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String City 
		{
			get 
			{
				if(IsCityNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CityColumn];
				}
			}
			set 
			{
				this[_parent.CityColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field City is NULL, false otherwise.
		/// </summary>
		public bool IsCityNull() 
		{
			return IsNull(_parent.CityColumn);
		}

		/// <summary>
		/// Sets the TypedView field City to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCityNull() 
		{
			this[_parent.CityColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field StateId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."StateID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 StateId 
		{
			get 
			{
				if(IsStateIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.StateIdColumn];
				}
			}
			set 
			{
				this[_parent.StateIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field StateId is NULL, false otherwise.
		/// </summary>
		public bool IsStateIdNull() 
		{
			return IsNull(_parent.StateIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field StateId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetStateIdNull() 
		{
			this[_parent.StateIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field State<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."State"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String State 
		{
			get 
			{
				if(IsStateNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.StateColumn];
				}
			}
			set 
			{
				this[_parent.StateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field State is NULL, false otherwise.
		/// </summary>
		public bool IsStateNull() 
		{
			return IsNull(_parent.StateColumn);
		}

		/// <summary>
		/// Sets the TypedView field State to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetStateNull() 
		{
			this[_parent.StateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CountryId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."CountryID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 CountryId 
		{
			get 
			{
				if(IsCountryIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.CountryIdColumn];
				}
			}
			set 
			{
				this[_parent.CountryIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CountryId is NULL, false otherwise.
		/// </summary>
		public bool IsCountryIdNull() 
		{
			return IsNull(_parent.CountryIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field CountryId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCountryIdNull() 
		{
			this[_parent.CountryIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Country<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."Country"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String Country 
		{
			get 
			{
				if(IsCountryNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CountryColumn];
				}
			}
			set 
			{
				this[_parent.CountryColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Country is NULL, false otherwise.
		/// </summary>
		public bool IsCountryNull() 
		{
			return IsNull(_parent.CountryColumn);
		}

		/// <summary>
		/// Sets the TypedView field Country to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCountryNull() 
		{
			this[_parent.CountryColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field ZipId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."ZipID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 ZipId 
		{
			get 
			{
				if(IsZipIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.ZipIdColumn];
				}
			}
			set 
			{
				this[_parent.ZipIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field ZipId is NULL, false otherwise.
		/// </summary>
		public bool IsZipIdNull() 
		{
			return IsNull(_parent.ZipIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field ZipId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetZipIdNull() 
		{
			this[_parent.ZipIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field ZipCode<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."ZipCode"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String ZipCode 
		{
			get 
			{
				if(IsZipCodeNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.ZipCodeColumn];
				}
			}
			set 
			{
				this[_parent.ZipCodeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field ZipCode is NULL, false otherwise.
		/// </summary>
		public bool IsZipCodeNull() 
		{
			return IsNull(_parent.ZipCodeColumn);
		}

		/// <summary>
		/// Sets the TypedView field ZipCode to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetZipCodeNull() 
		{
			this[_parent.ZipCodeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PhoneNumber<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."PhoneNumber"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String PhoneNumber 
		{
			get 
			{
				if(IsPhoneNumberNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.PhoneNumberColumn];
				}
			}
			set 
			{
				this[_parent.PhoneNumberColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PhoneNumber is NULL, false otherwise.
		/// </summary>
		public bool IsPhoneNumberNull() 
		{
			return IsNull(_parent.PhoneNumberColumn);
		}

		/// <summary>
		/// Sets the TypedView field PhoneNumber to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPhoneNumberNull() 
		{
			this[_parent.PhoneNumberColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Fax<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."Fax"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 100
		/// </remarks>
		public System.String Fax 
		{
			get 
			{
				if(IsFaxNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.FaxColumn];
				}
			}
			set 
			{
				this[_parent.FaxColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Fax is NULL, false otherwise.
		/// </summary>
		public bool IsFaxNull() 
		{
			return IsNull(_parent.FaxColumn);
		}

		/// <summary>
		/// Sets the TypedView field Fax to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetFaxNull() 
		{
			this[_parent.FaxColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsActive<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."IsActive"<br/>
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

	

		/// <summary>
		/// Gets / sets the value of the TypedView field DateCreated<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."DateCreated"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime DateCreated 
		{
			get 
			{
				if(IsDateCreatedNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.DateCreatedColumn];
				}
			}
			set 
			{
				this[_parent.DateCreatedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field DateCreated is NULL, false otherwise.
		/// </summary>
		public bool IsDateCreatedNull() 
		{
			return IsNull(_parent.DateCreatedColumn);
		}

		/// <summary>
		/// Sets the TypedView field DateCreated to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetDateCreatedNull() 
		{
			this[_parent.DateCreatedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field DateModified<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."DateModified"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime DateModified 
		{
			get 
			{
				if(IsDateModifiedNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.DateModifiedColumn];
				}
			}
			set 
			{
				this[_parent.DateModifiedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field DateModified is NULL, false otherwise.
		/// </summary>
		public bool IsDateModifiedNull() 
		{
			return IsNull(_parent.DateModifiedColumn);
		}

		/// <summary>
		/// Sets the TypedView field DateModified to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetDateModifiedNull() 
		{
			this[_parent.DateModifiedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Latitude<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."Latitude"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String Latitude 
		{
			get 
			{
				if(IsLatitudeNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.LatitudeColumn];
				}
			}
			set 
			{
				this[_parent.LatitudeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Latitude is NULL, false otherwise.
		/// </summary>
		public bool IsLatitudeNull() 
		{
			return IsNull(_parent.LatitudeColumn);
		}

		/// <summary>
		/// Sets the TypedView field Latitude to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetLatitudeNull() 
		{
			this[_parent.LatitudeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Longitude<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."Longitude"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String Longitude 
		{
			get 
			{
				if(IsLongitudeNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.LongitudeColumn];
				}
			}
			set 
			{
				this[_parent.LongitudeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Longitude is NULL, false otherwise.
		/// </summary>
		public bool IsLongitudeNull() 
		{
			return IsNull(_parent.LongitudeColumn);
		}

		/// <summary>
		/// Sets the TypedView field Longitude to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetLongitudeNull() 
		{
			this[_parent.LongitudeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field VerificationOrgRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."VerificationOrgRoleUserId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 VerificationOrgRoleUserId 
		{
			get 
			{
				if(IsVerificationOrgRoleUserIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.VerificationOrgRoleUserIdColumn];
				}
			}
			set 
			{
				this[_parent.VerificationOrgRoleUserIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field VerificationOrgRoleUserId is NULL, false otherwise.
		/// </summary>
		public bool IsVerificationOrgRoleUserIdNull() 
		{
			return IsNull(_parent.VerificationOrgRoleUserIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field VerificationOrgRoleUserId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetVerificationOrgRoleUserIdNull() 
		{
			this[_parent.VerificationOrgRoleUserIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsManuallyVerified<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."IsManuallyVerified"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean IsManuallyVerified 
		{
			get 
			{
				if(IsIsManuallyVerifiedNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.IsManuallyVerifiedColumn];
				}
			}
			set 
			{
				this[_parent.IsManuallyVerifiedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsManuallyVerified is NULL, false otherwise.
		/// </summary>
		public bool IsIsManuallyVerifiedNull() 
		{
			return IsNull(_parent.IsManuallyVerifiedColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsManuallyVerified to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsManuallyVerifiedNull() 
		{
			this[_parent.IsManuallyVerifiedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field UseLatLogForMapping<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_Address"."UseLatLogForMapping"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean UseLatLogForMapping 
		{
			get 
			{
				if(IsUseLatLogForMappingNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.UseLatLogForMappingColumn];
				}
			}
			set 
			{
				this[_parent.UseLatLogForMappingColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field UseLatLogForMapping is NULL, false otherwise.
		/// </summary>
		public bool IsUseLatLogForMappingNull() 
		{
			return IsNull(_parent.UseLatLogForMappingColumn);
		}

		/// <summary>
		/// Sets the TypedView field UseLatLogForMapping to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetUseLatLogForMappingNull() 
		{
			this[_parent.UseLatLogForMappingColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion		
	}
}
