///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:40 AM
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

using HealthYes.Data;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.TypedViewClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>
	/// Typed datatable for the view 'EventPackagePaymentInfo'.<br/><br/>
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
	public partial class EventPackagePaymentInfoTypedView : TypedViewBase<EventPackagePaymentInfoRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnEventId;
		private DataColumn _columnEventName;
		private DataColumn _columnEventDate;
		private DataColumn _columnEventStatus;
		private DataColumn _columnAddress1;
		private DataColumn _columnAddress2;
		private DataColumn _columnCityName;
		private DataColumn _columnStateName;
		private DataColumn _columnZipCode;
		private DataColumn _columnAppointmentId;
		private DataColumn _columnAppointmentTime;
		private DataColumn _columnPackageName;
		private DataColumn _columnPackageCost;
		private DataColumn _columnPackageId;
		private DataColumn _columnEventCustomerId;
		private DataColumn _columnSourceCode;
		private DataColumn _columnSourceCodeAmount;
		private DataColumn _columnFirstName;
		private DataColumn _columnMiddleName;
		private DataColumn _columnLastName;
		private DataColumn _columnCustomerId;
		private DataColumn _columnPaymentTotalAmount;
		private DataColumn _columnPaymentNet;
		private DataColumn _columnPaidAmount;
		private DataColumn _columnUnpaidAmount;
		private DataColumn _columnDrOrCr;
		private DataColumn _columnPaymentTypeId;
		private DataColumn _columnPaymentType;
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
		private const int AmountOfFields = 28;
		#endregion


		/// <summary>
		/// Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. 
		/// </summary>
		static EventPackagePaymentInfoTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public EventPackagePaymentInfoTypedView():base("EventPackagePaymentInfo")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EventPackagePaymentInfoTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all EventPackagePaymentInfoRow objects.</summary>
		/// <returns>Array with EventPackagePaymentInfoRow objects</returns>
		public new EventPackagePaymentInfoRow[] Select()
		{
			return (EventPackagePaymentInfoRow[])base.Select();
		}


		/// <summary>Gets an array of all EventPackagePaymentInfoRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with EventPackagePaymentInfoRow objects</returns>
		public new EventPackagePaymentInfoRow[] Select(string filterExpression)
		{
			return (EventPackagePaymentInfoRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all EventPackagePaymentInfoRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with EventPackagePaymentInfoRow objects</returns>
		public new EventPackagePaymentInfoRow[] Select(string filterExpression, string sort)
		{
			return (EventPackagePaymentInfoRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all EventPackagePaymentInfoRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with EventPackagePaymentInfoRow objects</returns>
		public new EventPackagePaymentInfoRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (EventPackagePaymentInfoRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new EventPackagePaymentInfoRow(rowBuilder);
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

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventStatus", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Address1", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Address2", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CityName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("StateName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AppointmentId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AppointmentTime", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PackageName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PackageCost", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PackageId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SourceCode", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SourceCodeAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentTotalAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentNet", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaidAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("UnpaidAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DrOrCr", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentTypeId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentType", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "EventPackagePaymentInfo";		
			_columnEventId = new DataColumn("EventId", typeof(System.Int64), null, MappingType.Element);
			_columnEventId.ReadOnly = true;
			_columnEventId.Caption = @"EventId";
			this.Columns.Add(_columnEventId);
			_columnEventName = new DataColumn("EventName", typeof(System.String), null, MappingType.Element);
			_columnEventName.ReadOnly = true;
			_columnEventName.Caption = @"EventName";
			this.Columns.Add(_columnEventName);
			_columnEventDate = new DataColumn("EventDate", typeof(System.DateTime), null, MappingType.Element);
			_columnEventDate.ReadOnly = true;
			_columnEventDate.Caption = @"EventDate";
			this.Columns.Add(_columnEventDate);
			_columnEventStatus = new DataColumn("EventStatus", typeof(System.Int32), null, MappingType.Element);
			_columnEventStatus.ReadOnly = true;
			_columnEventStatus.Caption = @"EventStatus";
			this.Columns.Add(_columnEventStatus);
			_columnAddress1 = new DataColumn("Address1", typeof(System.String), null, MappingType.Element);
			_columnAddress1.ReadOnly = true;
			_columnAddress1.Caption = @"Address1";
			this.Columns.Add(_columnAddress1);
			_columnAddress2 = new DataColumn("Address2", typeof(System.String), null, MappingType.Element);
			_columnAddress2.ReadOnly = true;
			_columnAddress2.Caption = @"Address2";
			this.Columns.Add(_columnAddress2);
			_columnCityName = new DataColumn("CityName", typeof(System.String), null, MappingType.Element);
			_columnCityName.ReadOnly = true;
			_columnCityName.Caption = @"CityName";
			this.Columns.Add(_columnCityName);
			_columnStateName = new DataColumn("StateName", typeof(System.String), null, MappingType.Element);
			_columnStateName.ReadOnly = true;
			_columnStateName.Caption = @"StateName";
			this.Columns.Add(_columnStateName);
			_columnZipCode = new DataColumn("ZipCode", typeof(System.String), null, MappingType.Element);
			_columnZipCode.ReadOnly = true;
			_columnZipCode.Caption = @"ZipCode";
			this.Columns.Add(_columnZipCode);
			_columnAppointmentId = new DataColumn("AppointmentId", typeof(System.Int64), null, MappingType.Element);
			_columnAppointmentId.ReadOnly = true;
			_columnAppointmentId.Caption = @"AppointmentId";
			this.Columns.Add(_columnAppointmentId);
			_columnAppointmentTime = new DataColumn("AppointmentTime", typeof(System.DateTime), null, MappingType.Element);
			_columnAppointmentTime.ReadOnly = true;
			_columnAppointmentTime.Caption = @"AppointmentTime";
			this.Columns.Add(_columnAppointmentTime);
			_columnPackageName = new DataColumn("PackageName", typeof(System.String), null, MappingType.Element);
			_columnPackageName.ReadOnly = true;
			_columnPackageName.Caption = @"PackageName";
			this.Columns.Add(_columnPackageName);
			_columnPackageCost = new DataColumn("PackageCost", typeof(System.Decimal), null, MappingType.Element);
			_columnPackageCost.ReadOnly = true;
			_columnPackageCost.Caption = @"PackageCost";
			this.Columns.Add(_columnPackageCost);
			_columnPackageId = new DataColumn("PackageId", typeof(System.Int64), null, MappingType.Element);
			_columnPackageId.ReadOnly = true;
			_columnPackageId.Caption = @"PackageId";
			this.Columns.Add(_columnPackageId);
			_columnEventCustomerId = new DataColumn("EventCustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnEventCustomerId.ReadOnly = true;
			_columnEventCustomerId.Caption = @"EventCustomerId";
			this.Columns.Add(_columnEventCustomerId);
			_columnSourceCode = new DataColumn("SourceCode", typeof(System.String), null, MappingType.Element);
			_columnSourceCode.ReadOnly = true;
			_columnSourceCode.Caption = @"SourceCode";
			this.Columns.Add(_columnSourceCode);
			_columnSourceCodeAmount = new DataColumn("SourceCodeAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnSourceCodeAmount.ReadOnly = true;
			_columnSourceCodeAmount.Caption = @"SourceCodeAmount";
			this.Columns.Add(_columnSourceCodeAmount);
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
			_columnCustomerId = new DataColumn("CustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerId.ReadOnly = true;
			_columnCustomerId.Caption = @"CustomerId";
			this.Columns.Add(_columnCustomerId);
			_columnPaymentTotalAmount = new DataColumn("PaymentTotalAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnPaymentTotalAmount.ReadOnly = true;
			_columnPaymentTotalAmount.Caption = @"PaymentTotalAmount";
			this.Columns.Add(_columnPaymentTotalAmount);
			_columnPaymentNet = new DataColumn("PaymentNet", typeof(System.Decimal), null, MappingType.Element);
			_columnPaymentNet.ReadOnly = true;
			_columnPaymentNet.Caption = @"PaymentNet";
			this.Columns.Add(_columnPaymentNet);
			_columnPaidAmount = new DataColumn("PaidAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnPaidAmount.ReadOnly = true;
			_columnPaidAmount.Caption = @"PaidAmount";
			this.Columns.Add(_columnPaidAmount);
			_columnUnpaidAmount = new DataColumn("UnpaidAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnUnpaidAmount.ReadOnly = true;
			_columnUnpaidAmount.Caption = @"UnpaidAmount";
			this.Columns.Add(_columnUnpaidAmount);
			_columnDrOrCr = new DataColumn("DrOrCr", typeof(System.Boolean), null, MappingType.Element);
			_columnDrOrCr.ReadOnly = true;
			_columnDrOrCr.Caption = @"DrOrCr";
			this.Columns.Add(_columnDrOrCr);
			_columnPaymentTypeId = new DataColumn("PaymentTypeId", typeof(System.Int64), null, MappingType.Element);
			_columnPaymentTypeId.ReadOnly = true;
			_columnPaymentTypeId.Caption = @"PaymentTypeId";
			this.Columns.Add(_columnPaymentTypeId);
			_columnPaymentType = new DataColumn("PaymentType", typeof(System.String), null, MappingType.Element);
			_columnPaymentType.ReadOnly = true;
			_columnPaymentType.Caption = @"PaymentType";
			this.Columns.Add(_columnPaymentType);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.EventPackagePaymentInfoTypedView);
			
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
			_columnEventId = this.Columns["EventId"];
			_columnEventName = this.Columns["EventName"];
			_columnEventDate = this.Columns["EventDate"];
			_columnEventStatus = this.Columns["EventStatus"];
			_columnAddress1 = this.Columns["Address1"];
			_columnAddress2 = this.Columns["Address2"];
			_columnCityName = this.Columns["CityName"];
			_columnStateName = this.Columns["StateName"];
			_columnZipCode = this.Columns["ZipCode"];
			_columnAppointmentId = this.Columns["AppointmentId"];
			_columnAppointmentTime = this.Columns["AppointmentTime"];
			_columnPackageName = this.Columns["PackageName"];
			_columnPackageCost = this.Columns["PackageCost"];
			_columnPackageId = this.Columns["PackageId"];
			_columnEventCustomerId = this.Columns["EventCustomerId"];
			_columnSourceCode = this.Columns["SourceCode"];
			_columnSourceCodeAmount = this.Columns["SourceCodeAmount"];
			_columnFirstName = this.Columns["FirstName"];
			_columnMiddleName = this.Columns["MiddleName"];
			_columnLastName = this.Columns["LastName"];
			_columnCustomerId = this.Columns["CustomerId"];
			_columnPaymentTotalAmount = this.Columns["PaymentTotalAmount"];
			_columnPaymentNet = this.Columns["PaymentNet"];
			_columnPaidAmount = this.Columns["PaidAmount"];
			_columnUnpaidAmount = this.Columns["UnpaidAmount"];
			_columnDrOrCr = this.Columns["DrOrCr"];
			_columnPaymentTypeId = this.Columns["PaymentTypeId"];
			_columnPaymentType = this.Columns["PaymentType"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.EventPackagePaymentInfoTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(EventPackagePaymentInfoRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			EventPackagePaymentInfoTypedView cloneToReturn = ((EventPackagePaymentInfoTypedView)(base.Clone()));
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
			return new EventPackagePaymentInfoTypedView();
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
			get { return EventPackagePaymentInfoTypedView.CustomProperties;}
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
			get { return EventPackagePaymentInfoTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public EventPackagePaymentInfoRow this[int index] 
		{
			get 
			{
				return ((EventPackagePaymentInfoRow)(this.Rows[index]));
			}
		}

	
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventId
		/// </summary>
		internal DataColumn EventIdColumn 
		{
			get { return _columnEventId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventName
		/// </summary>
		internal DataColumn EventNameColumn 
		{
			get { return _columnEventName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventDate
		/// </summary>
		internal DataColumn EventDateColumn 
		{
			get { return _columnEventDate; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventStatus
		/// </summary>
		internal DataColumn EventStatusColumn 
		{
			get { return _columnEventStatus; }
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
		/// Returns the column object belonging to the TypedView field CityName
		/// </summary>
		internal DataColumn CityNameColumn 
		{
			get { return _columnCityName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field StateName
		/// </summary>
		internal DataColumn StateNameColumn 
		{
			get { return _columnStateName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field ZipCode
		/// </summary>
		internal DataColumn ZipCodeColumn 
		{
			get { return _columnZipCode; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AppointmentId
		/// </summary>
		internal DataColumn AppointmentIdColumn 
		{
			get { return _columnAppointmentId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AppointmentTime
		/// </summary>
		internal DataColumn AppointmentTimeColumn 
		{
			get { return _columnAppointmentTime; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PackageName
		/// </summary>
		internal DataColumn PackageNameColumn 
		{
			get { return _columnPackageName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PackageCost
		/// </summary>
		internal DataColumn PackageCostColumn 
		{
			get { return _columnPackageCost; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PackageId
		/// </summary>
		internal DataColumn PackageIdColumn 
		{
			get { return _columnPackageId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventCustomerId
		/// </summary>
		internal DataColumn EventCustomerIdColumn 
		{
			get { return _columnEventCustomerId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field SourceCode
		/// </summary>
		internal DataColumn SourceCodeColumn 
		{
			get { return _columnSourceCode; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field SourceCodeAmount
		/// </summary>
		internal DataColumn SourceCodeAmountColumn 
		{
			get { return _columnSourceCodeAmount; }
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
		/// Returns the column object belonging to the TypedView field CustomerId
		/// </summary>
		internal DataColumn CustomerIdColumn 
		{
			get { return _columnCustomerId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaymentTotalAmount
		/// </summary>
		internal DataColumn PaymentTotalAmountColumn 
		{
			get { return _columnPaymentTotalAmount; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaymentNet
		/// </summary>
		internal DataColumn PaymentNetColumn 
		{
			get { return _columnPaymentNet; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaidAmount
		/// </summary>
		internal DataColumn PaidAmountColumn 
		{
			get { return _columnPaidAmount; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field UnpaidAmount
		/// </summary>
		internal DataColumn UnpaidAmountColumn 
		{
			get { return _columnUnpaidAmount; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field DrOrCr
		/// </summary>
		internal DataColumn DrOrCrColumn 
		{
			get { return _columnDrOrCr; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaymentTypeId
		/// </summary>
		internal DataColumn PaymentTypeIdColumn 
		{
			get { return _columnPaymentTypeId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaymentType
		/// </summary>
		internal DataColumn PaymentTypeColumn 
		{
			get { return _columnPaymentType; }
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
	/// Typed datarow for the typed datatable EventPackagePaymentInfo
	/// </summary>
	public partial class EventPackagePaymentInfoRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EventPackagePaymentInfoTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal EventPackagePaymentInfoRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((EventPackagePaymentInfoTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field EventId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."EventId"<br/>
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
		/// Gets / sets the value of the TypedView field EventName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."EventName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String EventName 
		{
			get 
			{
				if(IsEventNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.EventNameColumn];
				}
			}
			set 
			{
				this[_parent.EventNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventName is NULL, false otherwise.
		/// </summary>
		public bool IsEventNameNull() 
		{
			return IsNull(_parent.EventNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventNameNull() 
		{
			this[_parent.EventNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventDate<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."EventDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime EventDate 
		{
			get 
			{
				if(IsEventDateNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.EventDateColumn];
				}
			}
			set 
			{
				this[_parent.EventDateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventDate is NULL, false otherwise.
		/// </summary>
		public bool IsEventDateNull() 
		{
			return IsNull(_parent.EventDateColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventDate to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventDateNull() 
		{
			this[_parent.EventDateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventStatus<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."EventStatus"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 EventStatus 
		{
			get 
			{
				if(IsEventStatusNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.EventStatusColumn];
				}
			}
			set 
			{
				this[_parent.EventStatusColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventStatus is NULL, false otherwise.
		/// </summary>
		public bool IsEventStatusNull() 
		{
			return IsNull(_parent.EventStatusColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventStatus to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventStatusNull() 
		{
			this[_parent.EventStatusColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Address1<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."Address1"<br/>
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
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."Address2"<br/>
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
		/// Gets / sets the value of the TypedView field CityName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."CityName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String CityName 
		{
			get 
			{
				if(IsCityNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CityNameColumn];
				}
			}
			set 
			{
				this[_parent.CityNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CityName is NULL, false otherwise.
		/// </summary>
		public bool IsCityNameNull() 
		{
			return IsNull(_parent.CityNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field CityName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCityNameNull() 
		{
			this[_parent.CityNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field StateName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."StateName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String StateName 
		{
			get 
			{
				if(IsStateNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.StateNameColumn];
				}
			}
			set 
			{
				this[_parent.StateNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field StateName is NULL, false otherwise.
		/// </summary>
		public bool IsStateNameNull() 
		{
			return IsNull(_parent.StateNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field StateName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetStateNameNull() 
		{
			this[_parent.StateNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field ZipCode<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."ZipCode"<br/>
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
		/// Gets / sets the value of the TypedView field AppointmentId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."AppointmentId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 AppointmentId 
		{
			get 
			{
				if(IsAppointmentIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.AppointmentIdColumn];
				}
			}
			set 
			{
				this[_parent.AppointmentIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AppointmentId is NULL, false otherwise.
		/// </summary>
		public bool IsAppointmentIdNull() 
		{
			return IsNull(_parent.AppointmentIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field AppointmentId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAppointmentIdNull() 
		{
			this[_parent.AppointmentIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AppointmentTime<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."AppointmentTime"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime AppointmentTime 
		{
			get 
			{
				if(IsAppointmentTimeNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.AppointmentTimeColumn];
				}
			}
			set 
			{
				this[_parent.AppointmentTimeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AppointmentTime is NULL, false otherwise.
		/// </summary>
		public bool IsAppointmentTimeNull() 
		{
			return IsNull(_parent.AppointmentTimeColumn);
		}

		/// <summary>
		/// Sets the TypedView field AppointmentTime to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAppointmentTimeNull() 
		{
			this[_parent.AppointmentTimeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PackageName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."PackageName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String PackageName 
		{
			get 
			{
				if(IsPackageNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.PackageNameColumn];
				}
			}
			set 
			{
				this[_parent.PackageNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PackageName is NULL, false otherwise.
		/// </summary>
		public bool IsPackageNameNull() 
		{
			return IsNull(_parent.PackageNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field PackageName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPackageNameNull() 
		{
			this[_parent.PackageNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PackageCost<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."PackageCost"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 18, 2, 0
		/// </remarks>
		public System.Decimal PackageCost 
		{
			get 
			{
				if(IsPackageCostNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.PackageCostColumn];
				}
			}
			set 
			{
				this[_parent.PackageCostColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PackageCost is NULL, false otherwise.
		/// </summary>
		public bool IsPackageCostNull() 
		{
			return IsNull(_parent.PackageCostColumn);
		}

		/// <summary>
		/// Sets the TypedView field PackageCost to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPackageCostNull() 
		{
			this[_parent.PackageCostColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PackageId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."PackageId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 PackageId 
		{
			get 
			{
				if(IsPackageIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.PackageIdColumn];
				}
			}
			set 
			{
				this[_parent.PackageIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PackageId is NULL, false otherwise.
		/// </summary>
		public bool IsPackageIdNull() 
		{
			return IsNull(_parent.PackageIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field PackageId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPackageIdNull() 
		{
			this[_parent.PackageIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventCustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."EventCustomerId"<br/>
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
		/// Gets / sets the value of the TypedView field SourceCode<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."SourceCode"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String SourceCode 
		{
			get 
			{
				if(IsSourceCodeNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.SourceCodeColumn];
				}
			}
			set 
			{
				this[_parent.SourceCodeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field SourceCode is NULL, false otherwise.
		/// </summary>
		public bool IsSourceCodeNull() 
		{
			return IsNull(_parent.SourceCodeColumn);
		}

		/// <summary>
		/// Sets the TypedView field SourceCode to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetSourceCodeNull() 
		{
			this[_parent.SourceCodeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field SourceCodeAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."SourceCodeAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 18, 2, 0
		/// </remarks>
		public System.Decimal SourceCodeAmount 
		{
			get 
			{
				if(IsSourceCodeAmountNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.SourceCodeAmountColumn];
				}
			}
			set 
			{
				this[_parent.SourceCodeAmountColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field SourceCodeAmount is NULL, false otherwise.
		/// </summary>
		public bool IsSourceCodeAmountNull() 
		{
			return IsNull(_parent.SourceCodeAmountColumn);
		}

		/// <summary>
		/// Sets the TypedView field SourceCodeAmount to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetSourceCodeAmountNull() 
		{
			this[_parent.SourceCodeAmountColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field FirstName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."FirstName"<br/>
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
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."MiddleName"<br/>
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
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."LastName"<br/>
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
		/// Gets / sets the value of the TypedView field CustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."CustomerId"<br/>
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
		/// Gets / sets the value of the TypedView field PaymentTotalAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."PaymentTotalAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 18, 2, 0
		/// </remarks>
		public System.Decimal PaymentTotalAmount 
		{
			get 
			{
				if(IsPaymentTotalAmountNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.PaymentTotalAmountColumn];
				}
			}
			set 
			{
				this[_parent.PaymentTotalAmountColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PaymentTotalAmount is NULL, false otherwise.
		/// </summary>
		public bool IsPaymentTotalAmountNull() 
		{
			return IsNull(_parent.PaymentTotalAmountColumn);
		}

		/// <summary>
		/// Sets the TypedView field PaymentTotalAmount to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPaymentTotalAmountNull() 
		{
			this[_parent.PaymentTotalAmountColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaymentNet<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."PaymentNet"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 18, 2, 0
		/// </remarks>
		public System.Decimal PaymentNet 
		{
			get 
			{
				if(IsPaymentNetNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.PaymentNetColumn];
				}
			}
			set 
			{
				this[_parent.PaymentNetColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PaymentNet is NULL, false otherwise.
		/// </summary>
		public bool IsPaymentNetNull() 
		{
			return IsNull(_parent.PaymentNetColumn);
		}

		/// <summary>
		/// Sets the TypedView field PaymentNet to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPaymentNetNull() 
		{
			this[_parent.PaymentNetColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaidAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."PaidAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 18, 2, 0
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
		/// Gets / sets the value of the TypedView field UnpaidAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."UnpaidAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 18, 2, 0
		/// </remarks>
		public System.Decimal UnpaidAmount 
		{
			get 
			{
				if(IsUnpaidAmountNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.UnpaidAmountColumn];
				}
			}
			set 
			{
				this[_parent.UnpaidAmountColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field UnpaidAmount is NULL, false otherwise.
		/// </summary>
		public bool IsUnpaidAmountNull() 
		{
			return IsNull(_parent.UnpaidAmountColumn);
		}

		/// <summary>
		/// Sets the TypedView field UnpaidAmount to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetUnpaidAmountNull() 
		{
			this[_parent.UnpaidAmountColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field DrOrCr<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."DrOrCr"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean DrOrCr 
		{
			get 
			{
				if(IsDrOrCrNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.DrOrCrColumn];
				}
			}
			set 
			{
				this[_parent.DrOrCrColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field DrOrCr is NULL, false otherwise.
		/// </summary>
		public bool IsDrOrCrNull() 
		{
			return IsNull(_parent.DrOrCrColumn);
		}

		/// <summary>
		/// Sets the TypedView field DrOrCr to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetDrOrCrNull() 
		{
			this[_parent.DrOrCrColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaymentTypeId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."PaymentTypeID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 PaymentTypeId 
		{
			get 
			{
				if(IsPaymentTypeIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.PaymentTypeIdColumn];
				}
			}
			set 
			{
				this[_parent.PaymentTypeIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PaymentTypeId is NULL, false otherwise.
		/// </summary>
		public bool IsPaymentTypeIdNull() 
		{
			return IsNull(_parent.PaymentTypeIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field PaymentTypeId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPaymentTypeIdNull() 
		{
			this[_parent.PaymentTypeIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaymentType<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_EventPackagePaymentInfo"."PaymentType"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String PaymentType 
		{
			get 
			{
				if(IsPaymentTypeNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.PaymentTypeColumn];
				}
			}
			set 
			{
				this[_parent.PaymentTypeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PaymentType is NULL, false otherwise.
		/// </summary>
		public bool IsPaymentTypeNull() 
		{
			return IsNull(_parent.PaymentTypeColumn);
		}

		/// <summary>
		/// Sets the TypedView field PaymentType to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPaymentTypeNull() 
		{
			this[_parent.PaymentTypeColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
