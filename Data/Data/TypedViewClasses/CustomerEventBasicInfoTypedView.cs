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
	/// Typed datatable for the view 'CustomerEventBasicInfo'.<br/><br/>
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
	public partial class CustomerEventBasicInfoTypedView : TypedViewBase<CustomerEventBasicInfoRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnCustomerId;
		private DataColumn _columnEventCustomerId;
		private DataColumn _columnFirstName;
		private DataColumn _columnLastName;
		private DataColumn _columnSignUpMarketingSource;
		private DataColumn _columnCustomerSignupMode;
		private DataColumn _columnEventSignupMode;
		private DataColumn _columnEventSignupDate;
		private DataColumn _columnEventId;
		private DataColumn _columnEventName;
		private DataColumn _columnEventDate;
		private DataColumn _columnCustomerSignupDate;
		private DataColumn _columnPackageName;
		private DataColumn _columnPodName;
		private DataColumn _columnAssignedToOrgRoleUserId;
		private DataColumn _columnPaymentTotalAmount;
		private DataColumn _columnIsPaid;
		private DataColumn _columnDrOrCr;
		private DataColumn _columnCouponCode;
		private DataColumn _columnIncomingPhoneLine;
		private DataColumn _columnCallersPhoneNumber;
		private DataColumn _columnCallStatus;
		private DataColumn _columnIsPodActive;
		private DataColumn _columnSalesRepFirstName;
		private DataColumn _columnSalesRepMiddleName;
		private DataColumn _columnSalesRepLastName;
		private DataColumn _columnMarketingSource;
		private DataColumn _columnHomeAddressId;
		private DataColumn _columnAddress1;
		private DataColumn _columnAddress2;
		private DataColumn _columnCityId;
		private DataColumn _columnCity;
		private DataColumn _columnStateId;
		private DataColumn _columnState;
		private DataColumn _columnZipId;
		private DataColumn _columnZipCode;
		private DataColumn _columnPaidAmount;
		private DataColumn _columnUnpaidAmount;
		private DataColumn _columnPaymentNet;
		private DataColumn _columnEventStatus;
		private DataColumn _columnPackagePrice;
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
		private const int AmountOfFields = 41;
		#endregion


		/// <summary>
		/// Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. 
		/// </summary>
		static CustomerEventBasicInfoTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public CustomerEventBasicInfoTypedView():base("CustomerEventBasicInfo")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CustomerEventBasicInfoTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all CustomerEventBasicInfoRow objects.</summary>
		/// <returns>Array with CustomerEventBasicInfoRow objects</returns>
		public new CustomerEventBasicInfoRow[] Select()
		{
			return (CustomerEventBasicInfoRow[])base.Select();
		}


		/// <summary>Gets an array of all CustomerEventBasicInfoRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with CustomerEventBasicInfoRow objects</returns>
		public new CustomerEventBasicInfoRow[] Select(string filterExpression)
		{
			return (CustomerEventBasicInfoRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all CustomerEventBasicInfoRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with CustomerEventBasicInfoRow objects</returns>
		public new CustomerEventBasicInfoRow[] Select(string filterExpression, string sort)
		{
			return (CustomerEventBasicInfoRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all CustomerEventBasicInfoRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with CustomerEventBasicInfoRow objects</returns>
		public new CustomerEventBasicInfoRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (CustomerEventBasicInfoRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new CustomerEventBasicInfoRow(rowBuilder);
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

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SignUpMarketingSource", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerSignupMode", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventSignupMode", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventSignupDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerSignupDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PackageName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PodName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AssignedToOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentTotalAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsPaid", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("DrOrCr", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CouponCode", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IncomingPhoneLine", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CallersPhoneNumber", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CallStatus", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsPodActive", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SalesRepFirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SalesRepMiddleName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SalesRepLastName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("MarketingSource", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("HomeAddressId", fieldHashtable);
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

			_fieldsCustomProperties.Add("ZipId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaidAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("UnpaidAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PaymentNet", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventStatus", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PackagePrice", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "CustomerEventBasicInfo";		
			_columnCustomerId = new DataColumn("CustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerId.ReadOnly = true;
			_columnCustomerId.Caption = @"CustomerId";
			this.Columns.Add(_columnCustomerId);
			_columnEventCustomerId = new DataColumn("EventCustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnEventCustomerId.ReadOnly = true;
			_columnEventCustomerId.Caption = @"EventCustomerId";
			this.Columns.Add(_columnEventCustomerId);
			_columnFirstName = new DataColumn("FirstName", typeof(System.String), null, MappingType.Element);
			_columnFirstName.ReadOnly = true;
			_columnFirstName.Caption = @"FirstName";
			this.Columns.Add(_columnFirstName);
			_columnLastName = new DataColumn("LastName", typeof(System.String), null, MappingType.Element);
			_columnLastName.ReadOnly = true;
			_columnLastName.Caption = @"LastName";
			this.Columns.Add(_columnLastName);
			_columnSignUpMarketingSource = new DataColumn("SignUpMarketingSource", typeof(System.String), null, MappingType.Element);
			_columnSignUpMarketingSource.ReadOnly = true;
			_columnSignUpMarketingSource.Caption = @"SignUpMarketingSource";
			this.Columns.Add(_columnSignUpMarketingSource);
			_columnCustomerSignupMode = new DataColumn("CustomerSignupMode", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerSignupMode.ReadOnly = true;
			_columnCustomerSignupMode.Caption = @"CustomerSignupMode";
			this.Columns.Add(_columnCustomerSignupMode);
			_columnEventSignupMode = new DataColumn("EventSignupMode", typeof(System.Int64), null, MappingType.Element);
			_columnEventSignupMode.ReadOnly = true;
			_columnEventSignupMode.Caption = @"EventSignupMode";
			this.Columns.Add(_columnEventSignupMode);
			_columnEventSignupDate = new DataColumn("EventSignupDate", typeof(System.DateTime), null, MappingType.Element);
			_columnEventSignupDate.ReadOnly = true;
			_columnEventSignupDate.Caption = @"EventSignupDate";
			this.Columns.Add(_columnEventSignupDate);
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
			_columnCustomerSignupDate = new DataColumn("CustomerSignupDate", typeof(System.DateTime), null, MappingType.Element);
			_columnCustomerSignupDate.ReadOnly = true;
			_columnCustomerSignupDate.Caption = @"CustomerSignupDate";
			this.Columns.Add(_columnCustomerSignupDate);
			_columnPackageName = new DataColumn("PackageName", typeof(System.String), null, MappingType.Element);
			_columnPackageName.ReadOnly = true;
			_columnPackageName.Caption = @"PackageName";
			this.Columns.Add(_columnPackageName);
			_columnPodName = new DataColumn("PodName", typeof(System.String), null, MappingType.Element);
			_columnPodName.ReadOnly = true;
			_columnPodName.Caption = @"PodName";
			this.Columns.Add(_columnPodName);
			_columnAssignedToOrgRoleUserId = new DataColumn("AssignedToOrgRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnAssignedToOrgRoleUserId.ReadOnly = true;
			_columnAssignedToOrgRoleUserId.Caption = @"AssignedToOrgRoleUserId";
			this.Columns.Add(_columnAssignedToOrgRoleUserId);
			_columnPaymentTotalAmount = new DataColumn("PaymentTotalAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnPaymentTotalAmount.ReadOnly = true;
			_columnPaymentTotalAmount.Caption = @"PaymentTotalAmount";
			this.Columns.Add(_columnPaymentTotalAmount);
			_columnIsPaid = new DataColumn("IsPaid", typeof(System.Boolean), null, MappingType.Element);
			_columnIsPaid.ReadOnly = true;
			_columnIsPaid.Caption = @"IsPaid";
			this.Columns.Add(_columnIsPaid);
			_columnDrOrCr = new DataColumn("DrOrCr", typeof(System.Boolean), null, MappingType.Element);
			_columnDrOrCr.ReadOnly = true;
			_columnDrOrCr.Caption = @"DrOrCr";
			this.Columns.Add(_columnDrOrCr);
			_columnCouponCode = new DataColumn("CouponCode", typeof(System.String), null, MappingType.Element);
			_columnCouponCode.ReadOnly = true;
			_columnCouponCode.Caption = @"CouponCode";
			this.Columns.Add(_columnCouponCode);
			_columnIncomingPhoneLine = new DataColumn("IncomingPhoneLine", typeof(System.String), null, MappingType.Element);
			_columnIncomingPhoneLine.ReadOnly = true;
			_columnIncomingPhoneLine.Caption = @"IncomingPhoneLine";
			this.Columns.Add(_columnIncomingPhoneLine);
			_columnCallersPhoneNumber = new DataColumn("CallersPhoneNumber", typeof(System.String), null, MappingType.Element);
			_columnCallersPhoneNumber.ReadOnly = true;
			_columnCallersPhoneNumber.Caption = @"CallersPhoneNumber";
			this.Columns.Add(_columnCallersPhoneNumber);
			_columnCallStatus = new DataColumn("CallStatus", typeof(System.String), null, MappingType.Element);
			_columnCallStatus.ReadOnly = true;
			_columnCallStatus.Caption = @"CallStatus";
			this.Columns.Add(_columnCallStatus);
			_columnIsPodActive = new DataColumn("IsPodActive", typeof(System.Boolean), null, MappingType.Element);
			_columnIsPodActive.ReadOnly = true;
			_columnIsPodActive.Caption = @"IsPodActive";
			this.Columns.Add(_columnIsPodActive);
			_columnSalesRepFirstName = new DataColumn("SalesRepFirstName", typeof(System.String), null, MappingType.Element);
			_columnSalesRepFirstName.ReadOnly = true;
			_columnSalesRepFirstName.Caption = @"SalesRepFirstName";
			this.Columns.Add(_columnSalesRepFirstName);
			_columnSalesRepMiddleName = new DataColumn("SalesRepMiddleName", typeof(System.String), null, MappingType.Element);
			_columnSalesRepMiddleName.ReadOnly = true;
			_columnSalesRepMiddleName.Caption = @"SalesRepMiddleName";
			this.Columns.Add(_columnSalesRepMiddleName);
			_columnSalesRepLastName = new DataColumn("SalesRepLastName", typeof(System.String), null, MappingType.Element);
			_columnSalesRepLastName.ReadOnly = true;
			_columnSalesRepLastName.Caption = @"SalesRepLastName";
			this.Columns.Add(_columnSalesRepLastName);
			_columnMarketingSource = new DataColumn("MarketingSource", typeof(System.String), null, MappingType.Element);
			_columnMarketingSource.ReadOnly = true;
			_columnMarketingSource.Caption = @"MarketingSource";
			this.Columns.Add(_columnMarketingSource);
			_columnHomeAddressId = new DataColumn("HomeAddressId", typeof(System.Int64), null, MappingType.Element);
			_columnHomeAddressId.ReadOnly = true;
			_columnHomeAddressId.Caption = @"HomeAddressId";
			this.Columns.Add(_columnHomeAddressId);
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
			_columnZipId = new DataColumn("ZipId", typeof(System.Int64), null, MappingType.Element);
			_columnZipId.ReadOnly = true;
			_columnZipId.Caption = @"ZipId";
			this.Columns.Add(_columnZipId);
			_columnZipCode = new DataColumn("ZipCode", typeof(System.String), null, MappingType.Element);
			_columnZipCode.ReadOnly = true;
			_columnZipCode.Caption = @"ZipCode";
			this.Columns.Add(_columnZipCode);
			_columnPaidAmount = new DataColumn("PaidAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnPaidAmount.ReadOnly = true;
			_columnPaidAmount.Caption = @"PaidAmount";
			this.Columns.Add(_columnPaidAmount);
			_columnUnpaidAmount = new DataColumn("UnpaidAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnUnpaidAmount.ReadOnly = true;
			_columnUnpaidAmount.Caption = @"UnpaidAmount";
			this.Columns.Add(_columnUnpaidAmount);
			_columnPaymentNet = new DataColumn("PaymentNet", typeof(System.Decimal), null, MappingType.Element);
			_columnPaymentNet.ReadOnly = true;
			_columnPaymentNet.Caption = @"PaymentNet";
			this.Columns.Add(_columnPaymentNet);
			_columnEventStatus = new DataColumn("EventStatus", typeof(System.Int32), null, MappingType.Element);
			_columnEventStatus.ReadOnly = true;
			_columnEventStatus.Caption = @"EventStatus";
			this.Columns.Add(_columnEventStatus);
			_columnPackagePrice = new DataColumn("PackagePrice", typeof(System.Decimal), null, MappingType.Element);
			_columnPackagePrice.ReadOnly = true;
			_columnPackagePrice.Caption = @"PackagePrice";
			this.Columns.Add(_columnPackagePrice);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CustomerEventBasicInfoTypedView);
			
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
			_columnEventCustomerId = this.Columns["EventCustomerId"];
			_columnFirstName = this.Columns["FirstName"];
			_columnLastName = this.Columns["LastName"];
			_columnSignUpMarketingSource = this.Columns["SignUpMarketingSource"];
			_columnCustomerSignupMode = this.Columns["CustomerSignupMode"];
			_columnEventSignupMode = this.Columns["EventSignupMode"];
			_columnEventSignupDate = this.Columns["EventSignupDate"];
			_columnEventId = this.Columns["EventId"];
			_columnEventName = this.Columns["EventName"];
			_columnEventDate = this.Columns["EventDate"];
			_columnCustomerSignupDate = this.Columns["CustomerSignupDate"];
			_columnPackageName = this.Columns["PackageName"];
			_columnPodName = this.Columns["PodName"];
			_columnAssignedToOrgRoleUserId = this.Columns["AssignedToOrgRoleUserId"];
			_columnPaymentTotalAmount = this.Columns["PaymentTotalAmount"];
			_columnIsPaid = this.Columns["IsPaid"];
			_columnDrOrCr = this.Columns["DrOrCr"];
			_columnCouponCode = this.Columns["CouponCode"];
			_columnIncomingPhoneLine = this.Columns["IncomingPhoneLine"];
			_columnCallersPhoneNumber = this.Columns["CallersPhoneNumber"];
			_columnCallStatus = this.Columns["CallStatus"];
			_columnIsPodActive = this.Columns["IsPodActive"];
			_columnSalesRepFirstName = this.Columns["SalesRepFirstName"];
			_columnSalesRepMiddleName = this.Columns["SalesRepMiddleName"];
			_columnSalesRepLastName = this.Columns["SalesRepLastName"];
			_columnMarketingSource = this.Columns["MarketingSource"];
			_columnHomeAddressId = this.Columns["HomeAddressId"];
			_columnAddress1 = this.Columns["Address1"];
			_columnAddress2 = this.Columns["Address2"];
			_columnCityId = this.Columns["CityId"];
			_columnCity = this.Columns["City"];
			_columnStateId = this.Columns["StateId"];
			_columnState = this.Columns["State"];
			_columnZipId = this.Columns["ZipId"];
			_columnZipCode = this.Columns["ZipCode"];
			_columnPaidAmount = this.Columns["PaidAmount"];
			_columnUnpaidAmount = this.Columns["UnpaidAmount"];
			_columnPaymentNet = this.Columns["PaymentNet"];
			_columnEventStatus = this.Columns["EventStatus"];
			_columnPackagePrice = this.Columns["PackagePrice"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CustomerEventBasicInfoTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(CustomerEventBasicInfoRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			CustomerEventBasicInfoTypedView cloneToReturn = ((CustomerEventBasicInfoTypedView)(base.Clone()));
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
			return new CustomerEventBasicInfoTypedView();
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
			get { return CustomerEventBasicInfoTypedView.CustomProperties;}
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
			get { return CustomerEventBasicInfoTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public CustomerEventBasicInfoRow this[int index] 
		{
			get 
			{
				return ((CustomerEventBasicInfoRow)(this.Rows[index]));
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
		/// Returns the column object belonging to the TypedView field EventCustomerId
		/// </summary>
		internal DataColumn EventCustomerIdColumn 
		{
			get { return _columnEventCustomerId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field FirstName
		/// </summary>
		internal DataColumn FirstNameColumn 
		{
			get { return _columnFirstName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field LastName
		/// </summary>
		internal DataColumn LastNameColumn 
		{
			get { return _columnLastName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field SignUpMarketingSource
		/// </summary>
		internal DataColumn SignUpMarketingSourceColumn 
		{
			get { return _columnSignUpMarketingSource; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerSignupMode
		/// </summary>
		internal DataColumn CustomerSignupModeColumn 
		{
			get { return _columnCustomerSignupMode; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventSignupMode
		/// </summary>
		internal DataColumn EventSignupModeColumn 
		{
			get { return _columnEventSignupMode; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventSignupDate
		/// </summary>
		internal DataColumn EventSignupDateColumn 
		{
			get { return _columnEventSignupDate; }
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
		/// Returns the column object belonging to the TypedView field CustomerSignupDate
		/// </summary>
		internal DataColumn CustomerSignupDateColumn 
		{
			get { return _columnCustomerSignupDate; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PackageName
		/// </summary>
		internal DataColumn PackageNameColumn 
		{
			get { return _columnPackageName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PodName
		/// </summary>
		internal DataColumn PodNameColumn 
		{
			get { return _columnPodName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AssignedToOrgRoleUserId
		/// </summary>
		internal DataColumn AssignedToOrgRoleUserIdColumn 
		{
			get { return _columnAssignedToOrgRoleUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PaymentTotalAmount
		/// </summary>
		internal DataColumn PaymentTotalAmountColumn 
		{
			get { return _columnPaymentTotalAmount; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsPaid
		/// </summary>
		internal DataColumn IsPaidColumn 
		{
			get { return _columnIsPaid; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field DrOrCr
		/// </summary>
		internal DataColumn DrOrCrColumn 
		{
			get { return _columnDrOrCr; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CouponCode
		/// </summary>
		internal DataColumn CouponCodeColumn 
		{
			get { return _columnCouponCode; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IncomingPhoneLine
		/// </summary>
		internal DataColumn IncomingPhoneLineColumn 
		{
			get { return _columnIncomingPhoneLine; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CallersPhoneNumber
		/// </summary>
		internal DataColumn CallersPhoneNumberColumn 
		{
			get { return _columnCallersPhoneNumber; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CallStatus
		/// </summary>
		internal DataColumn CallStatusColumn 
		{
			get { return _columnCallStatus; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsPodActive
		/// </summary>
		internal DataColumn IsPodActiveColumn 
		{
			get { return _columnIsPodActive; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field SalesRepFirstName
		/// </summary>
		internal DataColumn SalesRepFirstNameColumn 
		{
			get { return _columnSalesRepFirstName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field SalesRepMiddleName
		/// </summary>
		internal DataColumn SalesRepMiddleNameColumn 
		{
			get { return _columnSalesRepMiddleName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field SalesRepLastName
		/// </summary>
		internal DataColumn SalesRepLastNameColumn 
		{
			get { return _columnSalesRepLastName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field MarketingSource
		/// </summary>
		internal DataColumn MarketingSourceColumn 
		{
			get { return _columnMarketingSource; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field HomeAddressId
		/// </summary>
		internal DataColumn HomeAddressIdColumn 
		{
			get { return _columnHomeAddressId; }
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
		/// Returns the column object belonging to the TypedView field PaymentNet
		/// </summary>
		internal DataColumn PaymentNetColumn 
		{
			get { return _columnPaymentNet; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventStatus
		/// </summary>
		internal DataColumn EventStatusColumn 
		{
			get { return _columnEventStatus; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PackagePrice
		/// </summary>
		internal DataColumn PackagePriceColumn 
		{
			get { return _columnPackagePrice; }
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
	/// Typed datarow for the typed datatable CustomerEventBasicInfo
	/// </summary>
	public partial class CustomerEventBasicInfoRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private CustomerEventBasicInfoTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal CustomerEventBasicInfoRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((CustomerEventBasicInfoTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."CustomerID"<br/>
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
		/// Gets / sets the value of the TypedView field EventCustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."EventCustomerID"<br/>
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
		/// Gets / sets the value of the TypedView field FirstName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."FirstName"<br/>
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
		/// Gets / sets the value of the TypedView field LastName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."LastName"<br/>
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
		/// Gets / sets the value of the TypedView field SignUpMarketingSource<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."SignUpMarketingSource"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String SignUpMarketingSource 
		{
			get 
			{
				if(IsSignUpMarketingSourceNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.SignUpMarketingSourceColumn];
				}
			}
			set 
			{
				this[_parent.SignUpMarketingSourceColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field SignUpMarketingSource is NULL, false otherwise.
		/// </summary>
		public bool IsSignUpMarketingSourceNull() 
		{
			return IsNull(_parent.SignUpMarketingSourceColumn);
		}

		/// <summary>
		/// Sets the TypedView field SignUpMarketingSource to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetSignUpMarketingSourceNull() 
		{
			this[_parent.SignUpMarketingSourceColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerSignupMode<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."CustomerSignupMode"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 CustomerSignupMode 
		{
			get 
			{
				if(IsCustomerSignupModeNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.CustomerSignupModeColumn];
				}
			}
			set 
			{
				this[_parent.CustomerSignupModeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CustomerSignupMode is NULL, false otherwise.
		/// </summary>
		public bool IsCustomerSignupModeNull() 
		{
			return IsNull(_parent.CustomerSignupModeColumn);
		}

		/// <summary>
		/// Sets the TypedView field CustomerSignupMode to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCustomerSignupModeNull() 
		{
			this[_parent.CustomerSignupModeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventSignupMode<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."EventSignupMode"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 EventSignupMode 
		{
			get 
			{
				if(IsEventSignupModeNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.EventSignupModeColumn];
				}
			}
			set 
			{
				this[_parent.EventSignupModeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventSignupMode is NULL, false otherwise.
		/// </summary>
		public bool IsEventSignupModeNull() 
		{
			return IsNull(_parent.EventSignupModeColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventSignupMode to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventSignupModeNull() 
		{
			this[_parent.EventSignupModeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventSignupDate<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."EventSignupDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime EventSignupDate 
		{
			get 
			{
				if(IsEventSignupDateNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.EventSignupDateColumn];
				}
			}
			set 
			{
				this[_parent.EventSignupDateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventSignupDate is NULL, false otherwise.
		/// </summary>
		public bool IsEventSignupDateNull() 
		{
			return IsNull(_parent.EventSignupDateColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventSignupDate to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventSignupDateNull() 
		{
			this[_parent.EventSignupDateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."EventID"<br/>
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."EventName"<br/>
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."EventDate"<br/>
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
		/// Gets / sets the value of the TypedView field CustomerSignupDate<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."CustomerSignupDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime CustomerSignupDate 
		{
			get 
			{
				if(IsCustomerSignupDateNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.CustomerSignupDateColumn];
				}
			}
			set 
			{
				this[_parent.CustomerSignupDateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CustomerSignupDate is NULL, false otherwise.
		/// </summary>
		public bool IsCustomerSignupDateNull() 
		{
			return IsNull(_parent.CustomerSignupDateColumn);
		}

		/// <summary>
		/// Sets the TypedView field CustomerSignupDate to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCustomerSignupDateNull() 
		{
			this[_parent.CustomerSignupDateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PackageName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."PackageName"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647
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
		/// Gets / sets the value of the TypedView field PodName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."PodName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String PodName 
		{
			get 
			{
				if(IsPodNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.PodNameColumn];
				}
			}
			set 
			{
				this[_parent.PodNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PodName is NULL, false otherwise.
		/// </summary>
		public bool IsPodNameNull() 
		{
			return IsNull(_parent.PodNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field PodName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPodNameNull() 
		{
			this[_parent.PodNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AssignedToOrgRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."AssignedToOrgRoleUserId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 AssignedToOrgRoleUserId 
		{
			get 
			{
				if(IsAssignedToOrgRoleUserIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.AssignedToOrgRoleUserIdColumn];
				}
			}
			set 
			{
				this[_parent.AssignedToOrgRoleUserIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AssignedToOrgRoleUserId is NULL, false otherwise.
		/// </summary>
		public bool IsAssignedToOrgRoleUserIdNull() 
		{
			return IsNull(_parent.AssignedToOrgRoleUserIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field AssignedToOrgRoleUserId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAssignedToOrgRoleUserIdNull() 
		{
			this[_parent.AssignedToOrgRoleUserIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PaymentTotalAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."PaymentTotalAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
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
		/// Gets / sets the value of the TypedView field IsPaid<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."IsPaid"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean IsPaid 
		{
			get 
			{
				if(IsIsPaidNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.IsPaidColumn];
				}
			}
			set 
			{
				this[_parent.IsPaidColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsPaid is NULL, false otherwise.
		/// </summary>
		public bool IsIsPaidNull() 
		{
			return IsNull(_parent.IsPaidColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsPaid to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsPaidNull() 
		{
			this[_parent.IsPaidColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field DrOrCr<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."DrOrCr"<br/>
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
		/// Gets / sets the value of the TypedView field CouponCode<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."CouponCode"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String CouponCode 
		{
			get 
			{
				if(IsCouponCodeNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CouponCodeColumn];
				}
			}
			set 
			{
				this[_parent.CouponCodeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CouponCode is NULL, false otherwise.
		/// </summary>
		public bool IsCouponCodeNull() 
		{
			return IsNull(_parent.CouponCodeColumn);
		}

		/// <summary>
		/// Sets the TypedView field CouponCode to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCouponCodeNull() 
		{
			this[_parent.CouponCodeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IncomingPhoneLine<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."IncomingPhoneLine"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String IncomingPhoneLine 
		{
			get 
			{
				if(IsIncomingPhoneLineNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.IncomingPhoneLineColumn];
				}
			}
			set 
			{
				this[_parent.IncomingPhoneLineColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IncomingPhoneLine is NULL, false otherwise.
		/// </summary>
		public bool IsIncomingPhoneLineNull() 
		{
			return IsNull(_parent.IncomingPhoneLineColumn);
		}

		/// <summary>
		/// Sets the TypedView field IncomingPhoneLine to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIncomingPhoneLineNull() 
		{
			this[_parent.IncomingPhoneLineColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CallersPhoneNumber<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."CallersPhoneNumber"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String CallersPhoneNumber 
		{
			get 
			{
				if(IsCallersPhoneNumberNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CallersPhoneNumberColumn];
				}
			}
			set 
			{
				this[_parent.CallersPhoneNumberColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CallersPhoneNumber is NULL, false otherwise.
		/// </summary>
		public bool IsCallersPhoneNumberNull() 
		{
			return IsNull(_parent.CallersPhoneNumberColumn);
		}

		/// <summary>
		/// Sets the TypedView field CallersPhoneNumber to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCallersPhoneNumberNull() 
		{
			this[_parent.CallersPhoneNumberColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CallStatus<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."CallStatus"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String CallStatus 
		{
			get 
			{
				if(IsCallStatusNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.CallStatusColumn];
				}
			}
			set 
			{
				this[_parent.CallStatusColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CallStatus is NULL, false otherwise.
		/// </summary>
		public bool IsCallStatusNull() 
		{
			return IsNull(_parent.CallStatusColumn);
		}

		/// <summary>
		/// Sets the TypedView field CallStatus to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCallStatusNull() 
		{
			this[_parent.CallStatusColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsPodActive<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."IsPodActive"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean IsPodActive 
		{
			get 
			{
				if(IsIsPodActiveNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.IsPodActiveColumn];
				}
			}
			set 
			{
				this[_parent.IsPodActiveColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsPodActive is NULL, false otherwise.
		/// </summary>
		public bool IsIsPodActiveNull() 
		{
			return IsNull(_parent.IsPodActiveColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsPodActive to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsPodActiveNull() 
		{
			this[_parent.IsPodActiveColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field SalesRepFirstName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."SalesRepFirstName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String SalesRepFirstName 
		{
			get 
			{
				if(IsSalesRepFirstNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.SalesRepFirstNameColumn];
				}
			}
			set 
			{
				this[_parent.SalesRepFirstNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field SalesRepFirstName is NULL, false otherwise.
		/// </summary>
		public bool IsSalesRepFirstNameNull() 
		{
			return IsNull(_parent.SalesRepFirstNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field SalesRepFirstName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetSalesRepFirstNameNull() 
		{
			this[_parent.SalesRepFirstNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field SalesRepMiddleName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."SalesRepMiddleName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String SalesRepMiddleName 
		{
			get 
			{
				if(IsSalesRepMiddleNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.SalesRepMiddleNameColumn];
				}
			}
			set 
			{
				this[_parent.SalesRepMiddleNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field SalesRepMiddleName is NULL, false otherwise.
		/// </summary>
		public bool IsSalesRepMiddleNameNull() 
		{
			return IsNull(_parent.SalesRepMiddleNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field SalesRepMiddleName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetSalesRepMiddleNameNull() 
		{
			this[_parent.SalesRepMiddleNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field SalesRepLastName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."SalesRepLastName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String SalesRepLastName 
		{
			get 
			{
				if(IsSalesRepLastNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.SalesRepLastNameColumn];
				}
			}
			set 
			{
				this[_parent.SalesRepLastNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field SalesRepLastName is NULL, false otherwise.
		/// </summary>
		public bool IsSalesRepLastNameNull() 
		{
			return IsNull(_parent.SalesRepLastNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field SalesRepLastName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetSalesRepLastNameNull() 
		{
			this[_parent.SalesRepLastNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field MarketingSource<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."MarketingSource"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String MarketingSource 
		{
			get 
			{
				if(IsMarketingSourceNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.MarketingSourceColumn];
				}
			}
			set 
			{
				this[_parent.MarketingSourceColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field MarketingSource is NULL, false otherwise.
		/// </summary>
		public bool IsMarketingSourceNull() 
		{
			return IsNull(_parent.MarketingSourceColumn);
		}

		/// <summary>
		/// Sets the TypedView field MarketingSource to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetMarketingSourceNull() 
		{
			this[_parent.MarketingSourceColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field HomeAddressId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."HomeAddressID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 HomeAddressId 
		{
			get 
			{
				if(IsHomeAddressIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.HomeAddressIdColumn];
				}
			}
			set 
			{
				this[_parent.HomeAddressIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field HomeAddressId is NULL, false otherwise.
		/// </summary>
		public bool IsHomeAddressIdNull() 
		{
			return IsNull(_parent.HomeAddressIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field HomeAddressId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetHomeAddressIdNull() 
		{
			this[_parent.HomeAddressIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Address1<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."Address1"<br/>
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."Address2"<br/>
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."CityID"<br/>
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."City"<br/>
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."StateID"<br/>
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."State"<br/>
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
		/// Gets / sets the value of the TypedView field ZipId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."ZipID"<br/>
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."ZipCode"<br/>
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
		/// Gets / sets the value of the TypedView field PaidAmount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."PaidAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 38, 2, 0
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
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."UnpaidAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 38, 2, 0
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
		/// Gets / sets the value of the TypedView field PaymentNet<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."PaymentNet"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
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
		/// Gets / sets the value of the TypedView field EventStatus<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."EventStatus"<br/>
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
		/// Gets / sets the value of the TypedView field PackagePrice<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerEventBasicInfo"."PackagePrice"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal PackagePrice 
		{
			get 
			{
				if(IsPackagePriceNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.PackagePriceColumn];
				}
			}
			set 
			{
				this[_parent.PackagePriceColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PackagePrice is NULL, false otherwise.
		/// </summary>
		public bool IsPackagePriceNull() 
		{
			return IsNull(_parent.PackagePriceColumn);
		}

		/// <summary>
		/// Sets the TypedView field PackagePrice to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPackagePriceNull() 
		{
			this[_parent.PackagePriceColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
