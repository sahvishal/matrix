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
	/// Typed datatable for the view 'CcrepMetrices'.<br/><br/>
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
	public partial class CcrepMetricesTypedView : TypedViewBase<CcrepMetricesRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnEventCustomerId;
		private DataColumn _columnEventId;
		private DataColumn _columnCustomerId;
		private DataColumn _columnRegisteredDate;
		private DataColumn _columnOrganizationRoleUserId;
		private DataColumn _columnCcrepUserId;
		private DataColumn _columnOrderId;
		private DataColumn _columnPaymentDate;
		private DataColumn _columnPaymentRecievedBy;
		private DataColumn _columnPaymentRecievedByUserId;
		private DataColumn _columnRoleId;
		private DataColumn _columnPaidAmount;
		private DataColumn _columnDiscountAmount;
		private DataColumn _columnShippingAmount;
		private DataColumn _columnOrderAmount;
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
		private const int AmountOfFields = 15;
		#endregion


		/// <summary>
		/// Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. 
		/// </summary>
		static CcrepMetricesTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public CcrepMetricesTypedView():base("CcrepMetrices")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CcrepMetricesTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all CcrepMetricesRow objects.</summary>
		/// <returns>Array with CcrepMetricesRow objects</returns>
		public new CcrepMetricesRow[] Select()
		{
			return (CcrepMetricesRow[])base.Select();
		}


		/// <summary>Gets an array of all CcrepMetricesRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with CcrepMetricesRow objects</returns>
		public new CcrepMetricesRow[] Select(string filterExpression)
		{
			return (CcrepMetricesRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all CcrepMetricesRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with CcrepMetricesRow objects</returns>
		public new CcrepMetricesRow[] Select(string filterExpression, string sort)
		{
			return (CcrepMetricesRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all CcrepMetricesRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with CcrepMetricesRow objects</returns>
		public new CcrepMetricesRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (CcrepMetricesRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new CcrepMetricesRow(rowBuilder);
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

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("RegisteredDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrganizationRoleUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CcrepUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrderId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentRecievedBy", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentRecievedByUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("RoleId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaidAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DiscountAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("ShippingAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrderAmount", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "CcrepMetrices";		
			_columnEventCustomerId = new DataColumn("EventCustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnEventCustomerId.ReadOnly = true;
			_columnEventCustomerId.Caption = @"EventCustomerId";
			this.Columns.Add(_columnEventCustomerId);
			_columnEventId = new DataColumn("EventId", typeof(System.Int64), null, MappingType.Element);
			_columnEventId.ReadOnly = true;
			_columnEventId.Caption = @"EventId";
			this.Columns.Add(_columnEventId);
			_columnCustomerId = new DataColumn("CustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerId.ReadOnly = true;
			_columnCustomerId.Caption = @"CustomerId";
			this.Columns.Add(_columnCustomerId);
			_columnRegisteredDate = new DataColumn("RegisteredDate", typeof(System.DateTime), null, MappingType.Element);
			_columnRegisteredDate.ReadOnly = true;
			_columnRegisteredDate.Caption = @"RegisteredDate";
			this.Columns.Add(_columnRegisteredDate);
			_columnOrganizationRoleUserId = new DataColumn("OrganizationRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnOrganizationRoleUserId.ReadOnly = true;
			_columnOrganizationRoleUserId.Caption = @"OrganizationRoleUserId";
			this.Columns.Add(_columnOrganizationRoleUserId);
			_columnCcrepUserId = new DataColumn("CcrepUserId", typeof(System.Int64), null, MappingType.Element);
			_columnCcrepUserId.ReadOnly = true;
			_columnCcrepUserId.Caption = @"CcrepUserId";
			this.Columns.Add(_columnCcrepUserId);
			_columnOrderId = new DataColumn("OrderId", typeof(System.Int64), null, MappingType.Element);
			_columnOrderId.ReadOnly = true;
			_columnOrderId.Caption = @"OrderId";
			this.Columns.Add(_columnOrderId);
			_columnPaymentDate = new DataColumn("PaymentDate", typeof(System.DateTime), null, MappingType.Element);
			_columnPaymentDate.ReadOnly = true;
			_columnPaymentDate.Caption = @"PaymentDate";
			this.Columns.Add(_columnPaymentDate);
			_columnPaymentRecievedBy = new DataColumn("PaymentRecievedBy", typeof(System.Int64), null, MappingType.Element);
			_columnPaymentRecievedBy.ReadOnly = true;
			_columnPaymentRecievedBy.Caption = @"PaymentRecievedBy";
			this.Columns.Add(_columnPaymentRecievedBy);
			_columnPaymentRecievedByUserId = new DataColumn("PaymentRecievedByUserId", typeof(System.Int64), null, MappingType.Element);
			_columnPaymentRecievedByUserId.ReadOnly = true;
			_columnPaymentRecievedByUserId.Caption = @"PaymentRecievedByUserId";
			this.Columns.Add(_columnPaymentRecievedByUserId);
			_columnRoleId = new DataColumn("RoleId", typeof(System.Int64), null, MappingType.Element);
			_columnRoleId.ReadOnly = true;
			_columnRoleId.Caption = @"RoleId";
			this.Columns.Add(_columnRoleId);
			_columnPaidAmount = new DataColumn("PaidAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnPaidAmount.ReadOnly = true;
			_columnPaidAmount.Caption = @"PaidAmount";
			this.Columns.Add(_columnPaidAmount);
			_columnDiscountAmount = new DataColumn("DiscountAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnDiscountAmount.ReadOnly = true;
			_columnDiscountAmount.Caption = @"DiscountAmount";
			this.Columns.Add(_columnDiscountAmount);
			_columnShippingAmount = new DataColumn("ShippingAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnShippingAmount.ReadOnly = true;
			_columnShippingAmount.Caption = @"ShippingAmount";
			this.Columns.Add(_columnShippingAmount);
			_columnOrderAmount = new DataColumn("OrderAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnOrderAmount.ReadOnly = true;
			_columnOrderAmount.Caption = @"OrderAmount";
			this.Columns.Add(_columnOrderAmount);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CcrepMetricesTypedView);
			
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
			_columnEventCustomerId = this.Columns["EventCustomerId"];
			_columnEventId = this.Columns["EventId"];
			_columnCustomerId = this.Columns["CustomerId"];
			_columnRegisteredDate = this.Columns["RegisteredDate"];
			_columnOrganizationRoleUserId = this.Columns["OrganizationRoleUserId"];
			_columnCcrepUserId = this.Columns["CcrepUserId"];
			_columnOrderId = this.Columns["OrderId"];
			_columnPaymentDate = this.Columns["PaymentDate"];
			_columnPaymentRecievedBy = this.Columns["PaymentRecievedBy"];
			_columnPaymentRecievedByUserId = this.Columns["PaymentRecievedByUserId"];
			_columnRoleId = this.Columns["RoleId"];
			_columnPaidAmount = this.Columns["PaidAmount"];
			_columnDiscountAmount = this.Columns["DiscountAmount"];
			_columnShippingAmount = this.Columns["ShippingAmount"];
			_columnOrderAmount = this.Columns["OrderAmount"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CcrepMetricesTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(CcrepMetricesRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			CcrepMetricesTypedView cloneToReturn = ((CcrepMetricesTypedView)(base.Clone()));
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
			return new CcrepMetricesTypedView();
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
			get { return CcrepMetricesTypedView.CustomProperties;}
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
			get { return CcrepMetricesTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public CcrepMetricesRow this[int index] 
		{
			get 
			{
				return ((CcrepMetricesRow)(this.Rows[index]));
			}
		}

	
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventCustomerId
		/// </summary>
		internal DataColumn EventCustomerIdColumn 
		{
			get { return _columnEventCustomerId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventId
		/// </summary>
		internal DataColumn EventIdColumn 
		{
			get { return _columnEventId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerId
		/// </summary>
		internal DataColumn CustomerIdColumn 
		{
			get { return _columnCustomerId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field RegisteredDate
		/// </summary>
		internal DataColumn RegisteredDateColumn 
		{
			get { return _columnRegisteredDate; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrganizationRoleUserId
		/// </summary>
		internal DataColumn OrganizationRoleUserIdColumn 
		{
			get { return _columnOrganizationRoleUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CcrepUserId
		/// </summary>
		internal DataColumn CcrepUserIdColumn 
		{
			get { return _columnCcrepUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrderId
		/// </summary>
		internal DataColumn OrderIdColumn 
		{
			get { return _columnOrderId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaymentDate
		/// </summary>
		internal DataColumn PaymentDateColumn 
		{
			get { return _columnPaymentDate; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaymentRecievedBy
		/// </summary>
		internal DataColumn PaymentRecievedByColumn 
		{
			get { return _columnPaymentRecievedBy; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaymentRecievedByUserId
		/// </summary>
		internal DataColumn PaymentRecievedByUserIdColumn 
		{
			get { return _columnPaymentRecievedByUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field RoleId
		/// </summary>
		internal DataColumn RoleIdColumn 
		{
			get { return _columnRoleId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaidAmount
		/// </summary>
		internal DataColumn PaidAmountColumn 
		{
			get { return _columnPaidAmount; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field DiscountAmount
		/// </summary>
		internal DataColumn DiscountAmountColumn 
		{
			get { return _columnDiscountAmount; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field ShippingAmount
		/// </summary>
		internal DataColumn ShippingAmountColumn 
		{
			get { return _columnShippingAmount; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrderAmount
		/// </summary>
		internal DataColumn OrderAmountColumn 
		{
			get { return _columnOrderAmount; }
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
	/// Typed datarow for the typed datatable CcrepMetrices
	/// </summary>
	public partial class CcrepMetricesRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private CcrepMetricesTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal CcrepMetricesRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((CcrepMetricesTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field EventCustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."EventCustomerId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 EventCustomerId 
		{
			get 
			{
				if(IsEventCustomerIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.EventCustomerIdColumn];
				}
			}
			set 
			{
				this[_parent.EventCustomerIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventCustomerId is NULL, false otherwise.
		/// </summary>
		public bool IsEventCustomerIdNull() 
		{
			return IsNull(_parent.EventCustomerIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventCustomerId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventCustomerIdNull() 
		{
			this[_parent.EventCustomerIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."EventId"<br/>
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
		/// Gets / sets the value of the TypedView field CustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."CustomerId"<br/>
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
		/// Gets / sets the value of the TypedView field RegisteredDate<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."RegisteredDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime RegisteredDate 
		{
			get 
			{
				if(IsRegisteredDateNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.RegisteredDateColumn];
				}
			}
			set 
			{
				this[_parent.RegisteredDateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field RegisteredDate is NULL, false otherwise.
		/// </summary>
		public bool IsRegisteredDateNull() 
		{
			return IsNull(_parent.RegisteredDateColumn);
		}

		/// <summary>
		/// Sets the TypedView field RegisteredDate to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetRegisteredDateNull() 
		{
			this[_parent.RegisteredDateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OrganizationRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."OrganizationRoleUserId"<br/>
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
		/// Gets / sets the value of the TypedView field CcrepUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."CCRepUserId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 CcrepUserId 
		{
			get 
			{
				if(IsCcrepUserIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.CcrepUserIdColumn];
				}
			}
			set 
			{
				this[_parent.CcrepUserIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CcrepUserId is NULL, false otherwise.
		/// </summary>
		public bool IsCcrepUserIdNull() 
		{
			return IsNull(_parent.CcrepUserIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field CcrepUserId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCcrepUserIdNull() 
		{
			this[_parent.CcrepUserIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OrderId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."OrderID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 OrderId 
		{
			get 
			{
				if(IsOrderIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.OrderIdColumn];
				}
			}
			set 
			{
				this[_parent.OrderIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OrderId is NULL, false otherwise.
		/// </summary>
		public bool IsOrderIdNull() 
		{
			return IsNull(_parent.OrderIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field OrderId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOrderIdNull() 
		{
			this[_parent.OrderIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaymentDate<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."PaymentDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime PaymentDate 
		{
			get 
			{
				if(IsPaymentDateNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.PaymentDateColumn];
				}
			}
			set 
			{
				this[_parent.PaymentDateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PaymentDate is NULL, false otherwise.
		/// </summary>
		public bool IsPaymentDateNull() 
		{
			return IsNull(_parent.PaymentDateColumn);
		}

		/// <summary>
		/// Sets the TypedView field PaymentDate to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPaymentDateNull() 
		{
			this[_parent.PaymentDateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaymentRecievedBy<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."PaymentRecievedBy"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 PaymentRecievedBy 
		{
			get 
			{
				if(IsPaymentRecievedByNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.PaymentRecievedByColumn];
				}
			}
			set 
			{
				this[_parent.PaymentRecievedByColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PaymentRecievedBy is NULL, false otherwise.
		/// </summary>
		public bool IsPaymentRecievedByNull() 
		{
			return IsNull(_parent.PaymentRecievedByColumn);
		}

		/// <summary>
		/// Sets the TypedView field PaymentRecievedBy to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPaymentRecievedByNull() 
		{
			this[_parent.PaymentRecievedByColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaymentRecievedByUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."PaymentRecievedByUserId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 PaymentRecievedByUserId 
		{
			get 
			{
				if(IsPaymentRecievedByUserIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.PaymentRecievedByUserIdColumn];
				}
			}
			set 
			{
				this[_parent.PaymentRecievedByUserIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PaymentRecievedByUserId is NULL, false otherwise.
		/// </summary>
		public bool IsPaymentRecievedByUserIdNull() 
		{
			return IsNull(_parent.PaymentRecievedByUserIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field PaymentRecievedByUserId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPaymentRecievedByUserIdNull() 
		{
			this[_parent.PaymentRecievedByUserIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field RoleId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."RoleId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 RoleId 
		{
			get 
			{
				if(IsRoleIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.RoleIdColumn];
				}
			}
			set 
			{
				this[_parent.RoleIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field RoleId is NULL, false otherwise.
		/// </summary>
		public bool IsRoleIdNull() 
		{
			return IsNull(_parent.RoleIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field RoleId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetRoleIdNull() 
		{
			this[_parent.RoleIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaidAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."PaidAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal PaidAmount 
		{
			get 
			{
				if(IsPaidAmountNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.PaidAmountColumn];
				}
			}
			set 
			{
				this[_parent.PaidAmountColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PaidAmount is NULL, false otherwise.
		/// </summary>
		public bool IsPaidAmountNull() 
		{
			return IsNull(_parent.PaidAmountColumn);
		}

		/// <summary>
		/// Sets the TypedView field PaidAmount to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPaidAmountNull() 
		{
			this[_parent.PaidAmountColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field DiscountAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."DiscountAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal DiscountAmount 
		{
			get 
			{
				if(IsDiscountAmountNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.DiscountAmountColumn];
				}
			}
			set 
			{
				this[_parent.DiscountAmountColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field DiscountAmount is NULL, false otherwise.
		/// </summary>
		public bool IsDiscountAmountNull() 
		{
			return IsNull(_parent.DiscountAmountColumn);
		}

		/// <summary>
		/// Sets the TypedView field DiscountAmount to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetDiscountAmountNull() 
		{
			this[_parent.DiscountAmountColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field ShippingAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."ShippingAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal ShippingAmount 
		{
			get 
			{
				if(IsShippingAmountNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.ShippingAmountColumn];
				}
			}
			set 
			{
				this[_parent.ShippingAmountColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field ShippingAmount is NULL, false otherwise.
		/// </summary>
		public bool IsShippingAmountNull() 
		{
			return IsNull(_parent.ShippingAmountColumn);
		}

		/// <summary>
		/// Sets the TypedView field ShippingAmount to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetShippingAmountNull() 
		{
			this[_parent.ShippingAmountColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OrderAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CCRepMetrices"."OrderAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal OrderAmount 
		{
			get 
			{
				if(IsOrderAmountNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.OrderAmountColumn];
				}
			}
			set 
			{
				this[_parent.OrderAmountColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OrderAmount is NULL, false otherwise.
		/// </summary>
		public bool IsOrderAmountNull() 
		{
			return IsNull(_parent.OrderAmountColumn);
		}

		/// <summary>
		/// Sets the TypedView field OrderAmount to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOrderAmountNull() 
		{
			this[_parent.OrderAmountColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
