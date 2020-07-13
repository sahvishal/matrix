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
	/// Typed datatable for the view 'MedicalVendorEarningCustomer'.<br/><br/>
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
	public partial class MedicalVendorEarningCustomerTypedView : TypedViewBase<MedicalVendorEarningCustomerRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnCustomerId;
		private DataColumn _columnEventId;
		private DataColumn _columnOrganizationId;
		private DataColumn _columnOrganizationRoleUserId;
		private DataColumn _columnMvamountEarned;
		private DataColumn _columnEvaluationDate;
		private DataColumn _columnCustomerFirstName;
		private DataColumn _columnCustomerMiddleName;
		private DataColumn _columnCustomerLastName;
		private DataColumn _columnPhysicianFirstName;
		private DataColumn _columnPhysicianMiddleName;
		private DataColumn _columnPhysicianLastName;
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
		private const int AmountOfFields = 12;
		#endregion


		/// <summary>
		/// Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. 
		/// </summary>
		static MedicalVendorEarningCustomerTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public MedicalVendorEarningCustomerTypedView():base("MedicalVendorEarningCustomer")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MedicalVendorEarningCustomerTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all MedicalVendorEarningCustomerRow objects.</summary>
		/// <returns>Array with MedicalVendorEarningCustomerRow objects</returns>
		public new MedicalVendorEarningCustomerRow[] Select()
		{
			return (MedicalVendorEarningCustomerRow[])base.Select();
		}


		/// <summary>Gets an array of all MedicalVendorEarningCustomerRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with MedicalVendorEarningCustomerRow objects</returns>
		public new MedicalVendorEarningCustomerRow[] Select(string filterExpression)
		{
			return (MedicalVendorEarningCustomerRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all MedicalVendorEarningCustomerRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with MedicalVendorEarningCustomerRow objects</returns>
		public new MedicalVendorEarningCustomerRow[] Select(string filterExpression, string sort)
		{
			return (MedicalVendorEarningCustomerRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all MedicalVendorEarningCustomerRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with MedicalVendorEarningCustomerRow objects</returns>
		public new MedicalVendorEarningCustomerRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (MedicalVendorEarningCustomerRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new MedicalVendorEarningCustomerRow(rowBuilder);
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

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrganizationRoleUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("MvamountEarned", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EvaluationDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerFirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerMiddleName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerLastName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PhysicianFirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PhysicianMiddleName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PhysicianLastName", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "MedicalVendorEarningCustomer";		
			_columnCustomerId = new DataColumn("CustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerId.ReadOnly = true;
			_columnCustomerId.Caption = @"CustomerId";
			this.Columns.Add(_columnCustomerId);
			_columnEventId = new DataColumn("EventId", typeof(System.Int64), null, MappingType.Element);
			_columnEventId.ReadOnly = true;
			_columnEventId.Caption = @"EventId";
			this.Columns.Add(_columnEventId);
			_columnOrganizationId = new DataColumn("OrganizationId", typeof(System.Int64), null, MappingType.Element);
			_columnOrganizationId.ReadOnly = true;
			_columnOrganizationId.Caption = @"OrganizationId";
			this.Columns.Add(_columnOrganizationId);
			_columnOrganizationRoleUserId = new DataColumn("OrganizationRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnOrganizationRoleUserId.ReadOnly = true;
			_columnOrganizationRoleUserId.Caption = @"OrganizationRoleUserId";
			this.Columns.Add(_columnOrganizationRoleUserId);
			_columnMvamountEarned = new DataColumn("MvamountEarned", typeof(System.Decimal), null, MappingType.Element);
			_columnMvamountEarned.ReadOnly = true;
			_columnMvamountEarned.Caption = @"MvamountEarned";
			this.Columns.Add(_columnMvamountEarned);
			_columnEvaluationDate = new DataColumn("EvaluationDate", typeof(System.DateTime), null, MappingType.Element);
			_columnEvaluationDate.ReadOnly = true;
			_columnEvaluationDate.Caption = @"EvaluationDate";
			this.Columns.Add(_columnEvaluationDate);
			_columnCustomerFirstName = new DataColumn("CustomerFirstName", typeof(System.String), null, MappingType.Element);
			_columnCustomerFirstName.ReadOnly = true;
			_columnCustomerFirstName.Caption = @"CustomerFirstName";
			this.Columns.Add(_columnCustomerFirstName);
			_columnCustomerMiddleName = new DataColumn("CustomerMiddleName", typeof(System.String), null, MappingType.Element);
			_columnCustomerMiddleName.ReadOnly = true;
			_columnCustomerMiddleName.Caption = @"CustomerMiddleName";
			this.Columns.Add(_columnCustomerMiddleName);
			_columnCustomerLastName = new DataColumn("CustomerLastName", typeof(System.String), null, MappingType.Element);
			_columnCustomerLastName.ReadOnly = true;
			_columnCustomerLastName.Caption = @"CustomerLastName";
			this.Columns.Add(_columnCustomerLastName);
			_columnPhysicianFirstName = new DataColumn("PhysicianFirstName", typeof(System.String), null, MappingType.Element);
			_columnPhysicianFirstName.ReadOnly = true;
			_columnPhysicianFirstName.Caption = @"PhysicianFirstName";
			this.Columns.Add(_columnPhysicianFirstName);
			_columnPhysicianMiddleName = new DataColumn("PhysicianMiddleName", typeof(System.String), null, MappingType.Element);
			_columnPhysicianMiddleName.ReadOnly = true;
			_columnPhysicianMiddleName.Caption = @"PhysicianMiddleName";
			this.Columns.Add(_columnPhysicianMiddleName);
			_columnPhysicianLastName = new DataColumn("PhysicianLastName", typeof(System.String), null, MappingType.Element);
			_columnPhysicianLastName.ReadOnly = true;
			_columnPhysicianLastName.Caption = @"PhysicianLastName";
			this.Columns.Add(_columnPhysicianLastName);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.MedicalVendorEarningCustomerTypedView);
			
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
			_columnCustomerId = this.Columns["CustomerId"];
			_columnEventId = this.Columns["EventId"];
			_columnOrganizationId = this.Columns["OrganizationId"];
			_columnOrganizationRoleUserId = this.Columns["OrganizationRoleUserId"];
			_columnMvamountEarned = this.Columns["MvamountEarned"];
			_columnEvaluationDate = this.Columns["EvaluationDate"];
			_columnCustomerFirstName = this.Columns["CustomerFirstName"];
			_columnCustomerMiddleName = this.Columns["CustomerMiddleName"];
			_columnCustomerLastName = this.Columns["CustomerLastName"];
			_columnPhysicianFirstName = this.Columns["PhysicianFirstName"];
			_columnPhysicianMiddleName = this.Columns["PhysicianMiddleName"];
			_columnPhysicianLastName = this.Columns["PhysicianLastName"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.MedicalVendorEarningCustomerTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(MedicalVendorEarningCustomerRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			MedicalVendorEarningCustomerTypedView cloneToReturn = ((MedicalVendorEarningCustomerTypedView)(base.Clone()));
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
			return new MedicalVendorEarningCustomerTypedView();
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
			get { return MedicalVendorEarningCustomerTypedView.CustomProperties;}
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
			get { return MedicalVendorEarningCustomerTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public MedicalVendorEarningCustomerRow this[int index] 
		{
			get 
			{
				return ((MedicalVendorEarningCustomerRow)(this.Rows[index]));
			}
		}

	
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerId
		/// </summary>
		internal DataColumn CustomerIdColumn 
		{
			get { return _columnCustomerId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventId
		/// </summary>
		internal DataColumn EventIdColumn 
		{
			get { return _columnEventId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrganizationId
		/// </summary>
		internal DataColumn OrganizationIdColumn 
		{
			get { return _columnOrganizationId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrganizationRoleUserId
		/// </summary>
		internal DataColumn OrganizationRoleUserIdColumn 
		{
			get { return _columnOrganizationRoleUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field MvamountEarned
		/// </summary>
		internal DataColumn MvamountEarnedColumn 
		{
			get { return _columnMvamountEarned; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EvaluationDate
		/// </summary>
		internal DataColumn EvaluationDateColumn 
		{
			get { return _columnEvaluationDate; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerFirstName
		/// </summary>
		internal DataColumn CustomerFirstNameColumn 
		{
			get { return _columnCustomerFirstName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerMiddleName
		/// </summary>
		internal DataColumn CustomerMiddleNameColumn 
		{
			get { return _columnCustomerMiddleName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerLastName
		/// </summary>
		internal DataColumn CustomerLastNameColumn 
		{
			get { return _columnCustomerLastName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PhysicianFirstName
		/// </summary>
		internal DataColumn PhysicianFirstNameColumn 
		{
			get { return _columnPhysicianFirstName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PhysicianMiddleName
		/// </summary>
		internal DataColumn PhysicianMiddleNameColumn 
		{
			get { return _columnPhysicianMiddleName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PhysicianLastName
		/// </summary>
		internal DataColumn PhysicianLastNameColumn 
		{
			get { return _columnPhysicianLastName; }
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
	/// Typed datarow for the typed datatable MedicalVendorEarningCustomer
	/// </summary>
	public partial class MedicalVendorEarningCustomerRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private MedicalVendorEarningCustomerTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal MedicalVendorEarningCustomerRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((MedicalVendorEarningCustomerTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."CustomerID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 CustomerId 
		{
			get 
			{
				if(IsCustomerIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.CustomerIdColumn];
				}
			}
			set 
			{
				this[_parent.CustomerIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CustomerId is NULL, false otherwise.
		/// </summary>
		public bool IsCustomerIdNull() 
		{
			return IsNull(_parent.CustomerIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field CustomerId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCustomerIdNull() 
		{
			this[_parent.CustomerIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."EventId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 EventId 
		{
			get 
			{
				if(IsEventIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.EventIdColumn];
				}
			}
			set 
			{
				this[_parent.EventIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventId is NULL, false otherwise.
		/// </summary>
		public bool IsEventIdNull() 
		{
			return IsNull(_parent.EventIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventIdNull() 
		{
			this[_parent.EventIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OrganizationId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."OrganizationId"<br/>
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
		/// Gets / sets the value of the TypedView field OrganizationRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."OrganizationRoleUserId"<br/>
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
		/// Gets / sets the value of the TypedView field MvamountEarned<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."MVAmountEarned"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal MvamountEarned 
		{
			get 
			{
				if(IsMvamountEarnedNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.MvamountEarnedColumn];
				}
			}
			set 
			{
				this[_parent.MvamountEarnedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field MvamountEarned is NULL, false otherwise.
		/// </summary>
		public bool IsMvamountEarnedNull() 
		{
			return IsNull(_parent.MvamountEarnedColumn);
		}

		/// <summary>
		/// Sets the TypedView field MvamountEarned to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetMvamountEarnedNull() 
		{
			this[_parent.MvamountEarnedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EvaluationDate<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."EvaluationDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime EvaluationDate 
		{
			get 
			{
				if(IsEvaluationDateNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.EvaluationDateColumn];
				}
			}
			set 
			{
				this[_parent.EvaluationDateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EvaluationDate is NULL, false otherwise.
		/// </summary>
		public bool IsEvaluationDateNull() 
		{
			return IsNull(_parent.EvaluationDateColumn);
		}

		/// <summary>
		/// Sets the TypedView field EvaluationDate to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEvaluationDateNull() 
		{
			this[_parent.EvaluationDateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerFirstName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."CustomerFirstName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String CustomerFirstName 
		{
			get 
			{
				if(IsCustomerFirstNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CustomerFirstNameColumn];
				}
			}
			set 
			{
				this[_parent.CustomerFirstNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CustomerFirstName is NULL, false otherwise.
		/// </summary>
		public bool IsCustomerFirstNameNull() 
		{
			return IsNull(_parent.CustomerFirstNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field CustomerFirstName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCustomerFirstNameNull() 
		{
			this[_parent.CustomerFirstNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerMiddleName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."CustomerMiddleName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String CustomerMiddleName 
		{
			get 
			{
				if(IsCustomerMiddleNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CustomerMiddleNameColumn];
				}
			}
			set 
			{
				this[_parent.CustomerMiddleNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CustomerMiddleName is NULL, false otherwise.
		/// </summary>
		public bool IsCustomerMiddleNameNull() 
		{
			return IsNull(_parent.CustomerMiddleNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field CustomerMiddleName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCustomerMiddleNameNull() 
		{
			this[_parent.CustomerMiddleNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerLastName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."CustomerLastName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String CustomerLastName 
		{
			get 
			{
				if(IsCustomerLastNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CustomerLastNameColumn];
				}
			}
			set 
			{
				this[_parent.CustomerLastNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CustomerLastName is NULL, false otherwise.
		/// </summary>
		public bool IsCustomerLastNameNull() 
		{
			return IsNull(_parent.CustomerLastNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field CustomerLastName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCustomerLastNameNull() 
		{
			this[_parent.CustomerLastNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PhysicianFirstName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."PhysicianFirstName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String PhysicianFirstName 
		{
			get 
			{
				if(IsPhysicianFirstNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.PhysicianFirstNameColumn];
				}
			}
			set 
			{
				this[_parent.PhysicianFirstNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PhysicianFirstName is NULL, false otherwise.
		/// </summary>
		public bool IsPhysicianFirstNameNull() 
		{
			return IsNull(_parent.PhysicianFirstNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field PhysicianFirstName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPhysicianFirstNameNull() 
		{
			this[_parent.PhysicianFirstNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PhysicianMiddleName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."PhysicianMiddleName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String PhysicianMiddleName 
		{
			get 
			{
				if(IsPhysicianMiddleNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.PhysicianMiddleNameColumn];
				}
			}
			set 
			{
				this[_parent.PhysicianMiddleNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PhysicianMiddleName is NULL, false otherwise.
		/// </summary>
		public bool IsPhysicianMiddleNameNull() 
		{
			return IsNull(_parent.PhysicianMiddleNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field PhysicianMiddleName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPhysicianMiddleNameNull() 
		{
			this[_parent.PhysicianMiddleNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PhysicianLastName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorEarningCustomer"."PhysicianLastName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String PhysicianLastName 
		{
			get 
			{
				if(IsPhysicianLastNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.PhysicianLastNameColumn];
				}
			}
			set 
			{
				this[_parent.PhysicianLastNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PhysicianLastName is NULL, false otherwise.
		/// </summary>
		public bool IsPhysicianLastNameNull() 
		{
			return IsNull(_parent.PhysicianLastNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field PhysicianLastName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPhysicianLastNameNull() 
		{
			this[_parent.PhysicianLastNameColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
