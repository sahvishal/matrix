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
	/// Typed datatable for the view 'CustomerOrderBasicInfo'.<br/><br/>
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
	public partial class CustomerOrderBasicInfoTypedView : TypedViewBase<CustomerOrderBasicInfoRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnEventCustomerId;
		private DataColumn _columnOrderId;
		private DataColumn _columnOrderDetailId;
		private DataColumn _columnCustomerId;
		private DataColumn _columnFirstName;
		private DataColumn _columnMiddleName;
		private DataColumn _columnLastName;
		private DataColumn _columnEmail1;
		private DataColumn _columnPhone;
		private DataColumn _columnEventSignupDate;
		private DataColumn _columnEventSignupRoleId;
		private DataColumn _columnAppointmentId;
		private DataColumn _columnAppointmentStartTime;
		private DataColumn _columnAppointmentEndTime;
		private DataColumn _columnNoshow;
		private DataColumn _columnHipaastatus;
		private DataColumn _columnEventPackageId;
		private DataColumn _columnEventName;
		private DataColumn _columnEventDate;
		private DataColumn _columnEventId;
		private DataColumn _columnFranchiseeName;
		private DataColumn _columnOrganizationName;
		private DataColumn _columnHostAddress;
		private DataColumn _columnHostState;
		private DataColumn _columnHostCity;
		private DataColumn _columnHostZip;
		private DataColumn _columnLatitude;
		private DataColumn _columnLongitude;
		private DataColumn _columnIsManuallyVerified;
		private DataColumn _columnUseLatLogForMapping;
		private DataColumn _columnCheckinTime;
		private DataColumn _columnCheckoutTime;
		private DataColumn _columnLeftWithoutScreeningReasonId;
		private DataColumn _columnPackagePrice;
		private DataColumn _columnEffectiveCost;
		private DataColumn _columnPackageName;
		private DataColumn _columnPackageId;
		private DataColumn _columnAdditionalTest;
		private DataColumn _columnEventSignupMarketingSource;
		private DataColumn _columnEventStatus;
		private DataColumn _columnSourceCodeId;
		private DataColumn _columnSourceCode;
		private DataColumn _columnSourceCodeAmount;
		private DataColumn _columnShippingCost;
		private DataColumn _columnCreditCard;
		private DataColumn _columnCheck;
		private DataColumn _columnEcheck;
		private DataColumn _columnCash;
		private DataColumn _columnGc;
		private DataColumn _columnIsAuthorized;
		private DataColumn _columnCustomerEventTestId;
		private DataColumn _columnIsResultPdfgenerated;
		private DataColumn _columnIsPdfgenerated;
		private DataColumn _columnIsResultReady;
		private DataColumn _columnIsColoractelResultReady;
		private DataColumn _columnTestStatus;
		private DataColumn _columnAaatestEvaluation;
		private DataColumn _columnAsitestEvaluation;
		private DataColumn _columnCarotidTestEvaluation;
		private DataColumn _columnOsteoTestEvaluation;
		private DataColumn _columnPadtestEvaluation;
		private DataColumn _columnEkgtestEvaluation;
		private DataColumn _columnLipidTestEvaluation;
		private DataColumn _columnLiverTestEvaluation;
		private DataColumn _columnFraminghamTestEvaluation;
		private DataColumn _columnAaapartialState;
		private DataColumn _columnAsipartialState;
		private DataColumn _columnCarotidPartialState;
		private DataColumn _columnOsteoPartialState;
		private DataColumn _columnPadpartialState;
		private DataColumn _columnEkgpartialState;
		private DataColumn _columnLipidPartialState;
		private DataColumn _columnLiverPartialState;
		private DataColumn _columnFraminghamPartialState;
		private DataColumn _columnEventCount;
		private DataColumn _columnScheduledByOrgRoleUserId;
		private DataColumn _columnAppointBlockReason;
		private DataColumn _columnUserCreatedOn;
		private DataColumn _columnCustomerHealthInfo;
		private DataColumn _columnIsRegistered;
		private DataColumn _columnIsTestAttended;
		private DataColumn _columnIsPaid;
		private DataColumn _columnIsShippingApplied;
		private DataColumn _columnPartnerRelease;
		private DataColumn _columnInsurancePayment;
		private DataColumn _columnAwvVisitId;
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
		private const int AmountOfFields = 86;
		#endregion


		/// <summary>
		/// Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. 
		/// </summary>
		static CustomerOrderBasicInfoTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public CustomerOrderBasicInfoTypedView():base("CustomerOrderBasicInfo")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CustomerOrderBasicInfoTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all CustomerOrderBasicInfoRow objects.</summary>
		/// <returns>Array with CustomerOrderBasicInfoRow objects</returns>
		public new CustomerOrderBasicInfoRow[] Select()
		{
			return (CustomerOrderBasicInfoRow[])base.Select();
		}


		/// <summary>Gets an array of all CustomerOrderBasicInfoRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with CustomerOrderBasicInfoRow objects</returns>
		public new CustomerOrderBasicInfoRow[] Select(string filterExpression)
		{
			return (CustomerOrderBasicInfoRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all CustomerOrderBasicInfoRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with CustomerOrderBasicInfoRow objects</returns>
		public new CustomerOrderBasicInfoRow[] Select(string filterExpression, string sort)
		{
			return (CustomerOrderBasicInfoRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all CustomerOrderBasicInfoRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with CustomerOrderBasicInfoRow objects</returns>
		public new CustomerOrderBasicInfoRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (CustomerOrderBasicInfoRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new CustomerOrderBasicInfoRow(rowBuilder);
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

			_fieldsCustomProperties.Add("OrderId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrderDetailId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Email1", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Phone", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventSignupDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventSignupRoleId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AppointmentId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AppointmentStartTime", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AppointmentEndTime", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Noshow", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Hipaastatus", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventPackageId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FranchiseeName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrganizationName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("HostAddress", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("HostState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("HostCity", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("HostZip", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Latitude", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Longitude", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsManuallyVerified", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("UseLatLogForMapping", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CheckinTime", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CheckoutTime", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LeftWithoutScreeningReasonId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PackagePrice", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EffectiveCost", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PackageName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PackageId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AdditionalTest", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventSignupMarketingSource", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventStatus", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SourceCodeId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SourceCode", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("SourceCodeAmount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("ShippingCost", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CreditCard", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Check", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Echeck", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Cash", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("Gc", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsAuthorized", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsResultPdfgenerated", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsPdfgenerated", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsResultReady", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsColoractelResultReady", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("TestStatus", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AaatestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AsitestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CarotidTestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OsteoTestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PadtestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EkgtestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LipidTestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LiverTestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FraminghamTestEvaluation", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AaapartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AsipartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CarotidPartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OsteoPartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PadpartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EkgpartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LipidPartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LiverPartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FraminghamPartialState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventCount", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("ScheduledByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AppointBlockReason", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("UserCreatedOn", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerHealthInfo", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsRegistered", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsTestAttended", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsPaid", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsShippingApplied", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PartnerRelease", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("InsurancePayment", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("AwvVisitId", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "CustomerOrderBasicInfo";		
			_columnEventCustomerId = new DataColumn("EventCustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnEventCustomerId.ReadOnly = true;
			_columnEventCustomerId.Caption = @"EventCustomerId";
			this.Columns.Add(_columnEventCustomerId);
			_columnOrderId = new DataColumn("OrderId", typeof(System.Int64), null, MappingType.Element);
			_columnOrderId.ReadOnly = true;
			_columnOrderId.Caption = @"OrderId";
			this.Columns.Add(_columnOrderId);
			_columnOrderDetailId = new DataColumn("OrderDetailId", typeof(System.Int64), null, MappingType.Element);
			_columnOrderDetailId.ReadOnly = true;
			_columnOrderDetailId.Caption = @"OrderDetailId";
			this.Columns.Add(_columnOrderDetailId);
			_columnCustomerId = new DataColumn("CustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerId.ReadOnly = true;
			_columnCustomerId.Caption = @"CustomerId";
			this.Columns.Add(_columnCustomerId);
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
			_columnEmail1 = new DataColumn("Email1", typeof(System.String), null, MappingType.Element);
			_columnEmail1.ReadOnly = true;
			_columnEmail1.Caption = @"Email1";
			this.Columns.Add(_columnEmail1);
			_columnPhone = new DataColumn("Phone", typeof(System.String), null, MappingType.Element);
			_columnPhone.ReadOnly = true;
			_columnPhone.Caption = @"Phone";
			this.Columns.Add(_columnPhone);
			_columnEventSignupDate = new DataColumn("EventSignupDate", typeof(System.DateTime), null, MappingType.Element);
			_columnEventSignupDate.ReadOnly = true;
			_columnEventSignupDate.Caption = @"EventSignupDate";
			this.Columns.Add(_columnEventSignupDate);
			_columnEventSignupRoleId = new DataColumn("EventSignupRoleId", typeof(System.Int64), null, MappingType.Element);
			_columnEventSignupRoleId.ReadOnly = true;
			_columnEventSignupRoleId.Caption = @"EventSignupRoleId";
			this.Columns.Add(_columnEventSignupRoleId);
			_columnAppointmentId = new DataColumn("AppointmentId", typeof(System.Int64), null, MappingType.Element);
			_columnAppointmentId.ReadOnly = true;
			_columnAppointmentId.Caption = @"AppointmentId";
			this.Columns.Add(_columnAppointmentId);
			_columnAppointmentStartTime = new DataColumn("AppointmentStartTime", typeof(System.DateTime), null, MappingType.Element);
			_columnAppointmentStartTime.ReadOnly = true;
			_columnAppointmentStartTime.Caption = @"AppointmentStartTime";
			this.Columns.Add(_columnAppointmentStartTime);
			_columnAppointmentEndTime = new DataColumn("AppointmentEndTime", typeof(System.DateTime), null, MappingType.Element);
			_columnAppointmentEndTime.ReadOnly = true;
			_columnAppointmentEndTime.Caption = @"AppointmentEndTime";
			this.Columns.Add(_columnAppointmentEndTime);
			_columnNoshow = new DataColumn("Noshow", typeof(System.Boolean), null, MappingType.Element);
			_columnNoshow.ReadOnly = true;
			_columnNoshow.Caption = @"Noshow";
			this.Columns.Add(_columnNoshow);
			_columnHipaastatus = new DataColumn("Hipaastatus", typeof(System.Int16), null, MappingType.Element);
			_columnHipaastatus.ReadOnly = true;
			_columnHipaastatus.Caption = @"Hipaastatus";
			this.Columns.Add(_columnHipaastatus);
			_columnEventPackageId = new DataColumn("EventPackageId", typeof(System.Int64), null, MappingType.Element);
			_columnEventPackageId.ReadOnly = true;
			_columnEventPackageId.Caption = @"EventPackageId";
			this.Columns.Add(_columnEventPackageId);
			_columnEventName = new DataColumn("EventName", typeof(System.String), null, MappingType.Element);
			_columnEventName.ReadOnly = true;
			_columnEventName.Caption = @"EventName";
			this.Columns.Add(_columnEventName);
			_columnEventDate = new DataColumn("EventDate", typeof(System.DateTime), null, MappingType.Element);
			_columnEventDate.ReadOnly = true;
			_columnEventDate.Caption = @"EventDate";
			this.Columns.Add(_columnEventDate);
			_columnEventId = new DataColumn("EventId", typeof(System.Int64), null, MappingType.Element);
			_columnEventId.ReadOnly = true;
			_columnEventId.Caption = @"EventId";
			this.Columns.Add(_columnEventId);
			_columnFranchiseeName = new DataColumn("FranchiseeName", typeof(System.String), null, MappingType.Element);
			_columnFranchiseeName.ReadOnly = true;
			_columnFranchiseeName.Caption = @"FranchiseeName";
			this.Columns.Add(_columnFranchiseeName);
			_columnOrganizationName = new DataColumn("OrganizationName", typeof(System.String), null, MappingType.Element);
			_columnOrganizationName.ReadOnly = true;
			_columnOrganizationName.Caption = @"OrganizationName";
			this.Columns.Add(_columnOrganizationName);
			_columnHostAddress = new DataColumn("HostAddress", typeof(System.String), null, MappingType.Element);
			_columnHostAddress.ReadOnly = true;
			_columnHostAddress.Caption = @"HostAddress";
			this.Columns.Add(_columnHostAddress);
			_columnHostState = new DataColumn("HostState", typeof(System.String), null, MappingType.Element);
			_columnHostState.ReadOnly = true;
			_columnHostState.Caption = @"HostState";
			this.Columns.Add(_columnHostState);
			_columnHostCity = new DataColumn("HostCity", typeof(System.String), null, MappingType.Element);
			_columnHostCity.ReadOnly = true;
			_columnHostCity.Caption = @"HostCity";
			this.Columns.Add(_columnHostCity);
			_columnHostZip = new DataColumn("HostZip", typeof(System.String), null, MappingType.Element);
			_columnHostZip.ReadOnly = true;
			_columnHostZip.Caption = @"HostZip";
			this.Columns.Add(_columnHostZip);
			_columnLatitude = new DataColumn("Latitude", typeof(System.String), null, MappingType.Element);
			_columnLatitude.ReadOnly = true;
			_columnLatitude.Caption = @"Latitude";
			this.Columns.Add(_columnLatitude);
			_columnLongitude = new DataColumn("Longitude", typeof(System.String), null, MappingType.Element);
			_columnLongitude.ReadOnly = true;
			_columnLongitude.Caption = @"Longitude";
			this.Columns.Add(_columnLongitude);
			_columnIsManuallyVerified = new DataColumn("IsManuallyVerified", typeof(System.Boolean), null, MappingType.Element);
			_columnIsManuallyVerified.ReadOnly = true;
			_columnIsManuallyVerified.Caption = @"IsManuallyVerified";
			this.Columns.Add(_columnIsManuallyVerified);
			_columnUseLatLogForMapping = new DataColumn("UseLatLogForMapping", typeof(System.Boolean), null, MappingType.Element);
			_columnUseLatLogForMapping.ReadOnly = true;
			_columnUseLatLogForMapping.Caption = @"UseLatLogForMapping";
			this.Columns.Add(_columnUseLatLogForMapping);
			_columnCheckinTime = new DataColumn("CheckinTime", typeof(System.DateTime), null, MappingType.Element);
			_columnCheckinTime.ReadOnly = true;
			_columnCheckinTime.Caption = @"CheckinTime";
			this.Columns.Add(_columnCheckinTime);
			_columnCheckoutTime = new DataColumn("CheckoutTime", typeof(System.DateTime), null, MappingType.Element);
			_columnCheckoutTime.ReadOnly = true;
			_columnCheckoutTime.Caption = @"CheckoutTime";
			this.Columns.Add(_columnCheckoutTime);
			_columnLeftWithoutScreeningReasonId = new DataColumn("LeftWithoutScreeningReasonId", typeof(System.Int64), null, MappingType.Element);
			_columnLeftWithoutScreeningReasonId.ReadOnly = true;
			_columnLeftWithoutScreeningReasonId.Caption = @"LeftWithoutScreeningReasonId";
			this.Columns.Add(_columnLeftWithoutScreeningReasonId);
			_columnPackagePrice = new DataColumn("PackagePrice", typeof(System.Decimal), null, MappingType.Element);
			_columnPackagePrice.ReadOnly = true;
			_columnPackagePrice.Caption = @"PackagePrice";
			this.Columns.Add(_columnPackagePrice);
			_columnEffectiveCost = new DataColumn("EffectiveCost", typeof(System.Decimal), null, MappingType.Element);
			_columnEffectiveCost.ReadOnly = true;
			_columnEffectiveCost.Caption = @"EffectiveCost";
			this.Columns.Add(_columnEffectiveCost);
			_columnPackageName = new DataColumn("PackageName", typeof(System.String), null, MappingType.Element);
			_columnPackageName.ReadOnly = true;
			_columnPackageName.Caption = @"PackageName";
			this.Columns.Add(_columnPackageName);
			_columnPackageId = new DataColumn("PackageId", typeof(System.Int64), null, MappingType.Element);
			_columnPackageId.ReadOnly = true;
			_columnPackageId.Caption = @"PackageId";
			this.Columns.Add(_columnPackageId);
			_columnAdditionalTest = new DataColumn("AdditionalTest", typeof(System.String), null, MappingType.Element);
			_columnAdditionalTest.ReadOnly = true;
			_columnAdditionalTest.Caption = @"AdditionalTest";
			this.Columns.Add(_columnAdditionalTest);
			_columnEventSignupMarketingSource = new DataColumn("EventSignupMarketingSource", typeof(System.String), null, MappingType.Element);
			_columnEventSignupMarketingSource.ReadOnly = true;
			_columnEventSignupMarketingSource.Caption = @"EventSignupMarketingSource";
			this.Columns.Add(_columnEventSignupMarketingSource);
			_columnEventStatus = new DataColumn("EventStatus", typeof(System.Int32), null, MappingType.Element);
			_columnEventStatus.ReadOnly = true;
			_columnEventStatus.Caption = @"EventStatus";
			this.Columns.Add(_columnEventStatus);
			_columnSourceCodeId = new DataColumn("SourceCodeId", typeof(System.Int64), null, MappingType.Element);
			_columnSourceCodeId.ReadOnly = true;
			_columnSourceCodeId.Caption = @"SourceCodeId";
			this.Columns.Add(_columnSourceCodeId);
			_columnSourceCode = new DataColumn("SourceCode", typeof(System.String), null, MappingType.Element);
			_columnSourceCode.ReadOnly = true;
			_columnSourceCode.Caption = @"SourceCode";
			this.Columns.Add(_columnSourceCode);
			_columnSourceCodeAmount = new DataColumn("SourceCodeAmount", typeof(System.Decimal), null, MappingType.Element);
			_columnSourceCodeAmount.ReadOnly = true;
			_columnSourceCodeAmount.Caption = @"SourceCodeAmount";
			this.Columns.Add(_columnSourceCodeAmount);
			_columnShippingCost = new DataColumn("ShippingCost", typeof(System.Decimal), null, MappingType.Element);
			_columnShippingCost.ReadOnly = true;
			_columnShippingCost.Caption = @"ShippingCost";
			this.Columns.Add(_columnShippingCost);
			_columnCreditCard = new DataColumn("CreditCard", typeof(System.Decimal), null, MappingType.Element);
			_columnCreditCard.ReadOnly = true;
			_columnCreditCard.Caption = @"CreditCard";
			this.Columns.Add(_columnCreditCard);
			_columnCheck = new DataColumn("Check", typeof(System.Decimal), null, MappingType.Element);
			_columnCheck.ReadOnly = true;
			_columnCheck.Caption = @"Check";
			this.Columns.Add(_columnCheck);
			_columnEcheck = new DataColumn("Echeck", typeof(System.Decimal), null, MappingType.Element);
			_columnEcheck.ReadOnly = true;
			_columnEcheck.Caption = @"Echeck";
			this.Columns.Add(_columnEcheck);
			_columnCash = new DataColumn("Cash", typeof(System.Decimal), null, MappingType.Element);
			_columnCash.ReadOnly = true;
			_columnCash.Caption = @"Cash";
			this.Columns.Add(_columnCash);
			_columnGc = new DataColumn("Gc", typeof(System.Decimal), null, MappingType.Element);
			_columnGc.ReadOnly = true;
			_columnGc.Caption = @"Gc";
			this.Columns.Add(_columnGc);
			_columnIsAuthorized = new DataColumn("IsAuthorized", typeof(System.Int32), null, MappingType.Element);
			_columnIsAuthorized.ReadOnly = true;
			_columnIsAuthorized.Caption = @"IsAuthorized";
			this.Columns.Add(_columnIsAuthorized);
			_columnCustomerEventTestId = new DataColumn("CustomerEventTestId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerEventTestId.ReadOnly = true;
			_columnCustomerEventTestId.Caption = @"CustomerEventTestId";
			this.Columns.Add(_columnCustomerEventTestId);
			_columnIsResultPdfgenerated = new DataColumn("IsResultPdfgenerated", typeof(System.Boolean), null, MappingType.Element);
			_columnIsResultPdfgenerated.ReadOnly = true;
			_columnIsResultPdfgenerated.Caption = @"IsResultPdfgenerated";
			this.Columns.Add(_columnIsResultPdfgenerated);
			_columnIsPdfgenerated = new DataColumn("IsPdfgenerated", typeof(System.Boolean), null, MappingType.Element);
			_columnIsPdfgenerated.ReadOnly = true;
			_columnIsPdfgenerated.Caption = @"IsPdfgenerated";
			this.Columns.Add(_columnIsPdfgenerated);
			_columnIsResultReady = new DataColumn("IsResultReady", typeof(System.Int32), null, MappingType.Element);
			_columnIsResultReady.ReadOnly = true;
			_columnIsResultReady.Caption = @"IsResultReady";
			this.Columns.Add(_columnIsResultReady);
			_columnIsColoractelResultReady = new DataColumn("IsColoractelResultReady", typeof(System.Int32), null, MappingType.Element);
			_columnIsColoractelResultReady.ReadOnly = true;
			_columnIsColoractelResultReady.Caption = @"IsColoractelResultReady";
			this.Columns.Add(_columnIsColoractelResultReady);
			_columnTestStatus = new DataColumn("TestStatus", typeof(System.Int32), null, MappingType.Element);
			_columnTestStatus.ReadOnly = true;
			_columnTestStatus.Caption = @"TestStatus";
			this.Columns.Add(_columnTestStatus);
			_columnAaatestEvaluation = new DataColumn("AaatestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnAaatestEvaluation.ReadOnly = true;
			_columnAaatestEvaluation.Caption = @"AaatestEvaluation";
			this.Columns.Add(_columnAaatestEvaluation);
			_columnAsitestEvaluation = new DataColumn("AsitestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnAsitestEvaluation.ReadOnly = true;
			_columnAsitestEvaluation.Caption = @"AsitestEvaluation";
			this.Columns.Add(_columnAsitestEvaluation);
			_columnCarotidTestEvaluation = new DataColumn("CarotidTestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnCarotidTestEvaluation.ReadOnly = true;
			_columnCarotidTestEvaluation.Caption = @"CarotidTestEvaluation";
			this.Columns.Add(_columnCarotidTestEvaluation);
			_columnOsteoTestEvaluation = new DataColumn("OsteoTestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnOsteoTestEvaluation.ReadOnly = true;
			_columnOsteoTestEvaluation.Caption = @"OsteoTestEvaluation";
			this.Columns.Add(_columnOsteoTestEvaluation);
			_columnPadtestEvaluation = new DataColumn("PadtestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnPadtestEvaluation.ReadOnly = true;
			_columnPadtestEvaluation.Caption = @"PadtestEvaluation";
			this.Columns.Add(_columnPadtestEvaluation);
			_columnEkgtestEvaluation = new DataColumn("EkgtestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnEkgtestEvaluation.ReadOnly = true;
			_columnEkgtestEvaluation.Caption = @"EkgtestEvaluation";
			this.Columns.Add(_columnEkgtestEvaluation);
			_columnLipidTestEvaluation = new DataColumn("LipidTestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnLipidTestEvaluation.ReadOnly = true;
			_columnLipidTestEvaluation.Caption = @"LipidTestEvaluation";
			this.Columns.Add(_columnLipidTestEvaluation);
			_columnLiverTestEvaluation = new DataColumn("LiverTestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnLiverTestEvaluation.ReadOnly = true;
			_columnLiverTestEvaluation.Caption = @"LiverTestEvaluation";
			this.Columns.Add(_columnLiverTestEvaluation);
			_columnFraminghamTestEvaluation = new DataColumn("FraminghamTestEvaluation", typeof(System.Int32), null, MappingType.Element);
			_columnFraminghamTestEvaluation.ReadOnly = true;
			_columnFraminghamTestEvaluation.Caption = @"FraminghamTestEvaluation";
			this.Columns.Add(_columnFraminghamTestEvaluation);
			_columnAaapartialState = new DataColumn("AaapartialState", typeof(System.Int32), null, MappingType.Element);
			_columnAaapartialState.ReadOnly = true;
			_columnAaapartialState.Caption = @"AaapartialState";
			this.Columns.Add(_columnAaapartialState);
			_columnAsipartialState = new DataColumn("AsipartialState", typeof(System.Int32), null, MappingType.Element);
			_columnAsipartialState.ReadOnly = true;
			_columnAsipartialState.Caption = @"AsipartialState";
			this.Columns.Add(_columnAsipartialState);
			_columnCarotidPartialState = new DataColumn("CarotidPartialState", typeof(System.Int32), null, MappingType.Element);
			_columnCarotidPartialState.ReadOnly = true;
			_columnCarotidPartialState.Caption = @"CarotidPartialState";
			this.Columns.Add(_columnCarotidPartialState);
			_columnOsteoPartialState = new DataColumn("OsteoPartialState", typeof(System.Int32), null, MappingType.Element);
			_columnOsteoPartialState.ReadOnly = true;
			_columnOsteoPartialState.Caption = @"OsteoPartialState";
			this.Columns.Add(_columnOsteoPartialState);
			_columnPadpartialState = new DataColumn("PadpartialState", typeof(System.Int32), null, MappingType.Element);
			_columnPadpartialState.ReadOnly = true;
			_columnPadpartialState.Caption = @"PadpartialState";
			this.Columns.Add(_columnPadpartialState);
			_columnEkgpartialState = new DataColumn("EkgpartialState", typeof(System.Int32), null, MappingType.Element);
			_columnEkgpartialState.ReadOnly = true;
			_columnEkgpartialState.Caption = @"EkgpartialState";
			this.Columns.Add(_columnEkgpartialState);
			_columnLipidPartialState = new DataColumn("LipidPartialState", typeof(System.Int32), null, MappingType.Element);
			_columnLipidPartialState.ReadOnly = true;
			_columnLipidPartialState.Caption = @"LipidPartialState";
			this.Columns.Add(_columnLipidPartialState);
			_columnLiverPartialState = new DataColumn("LiverPartialState", typeof(System.Int32), null, MappingType.Element);
			_columnLiverPartialState.ReadOnly = true;
			_columnLiverPartialState.Caption = @"LiverPartialState";
			this.Columns.Add(_columnLiverPartialState);
			_columnFraminghamPartialState = new DataColumn("FraminghamPartialState", typeof(System.Int32), null, MappingType.Element);
			_columnFraminghamPartialState.ReadOnly = true;
			_columnFraminghamPartialState.Caption = @"FraminghamPartialState";
			this.Columns.Add(_columnFraminghamPartialState);
			_columnEventCount = new DataColumn("EventCount", typeof(System.Int32), null, MappingType.Element);
			_columnEventCount.ReadOnly = true;
			_columnEventCount.Caption = @"EventCount";
			this.Columns.Add(_columnEventCount);
			_columnScheduledByOrgRoleUserId = new DataColumn("ScheduledByOrgRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnScheduledByOrgRoleUserId.ReadOnly = true;
			_columnScheduledByOrgRoleUserId.Caption = @"ScheduledByOrgRoleUserId";
			this.Columns.Add(_columnScheduledByOrgRoleUserId);
			_columnAppointBlockReason = new DataColumn("AppointBlockReason", typeof(System.String), null, MappingType.Element);
			_columnAppointBlockReason.ReadOnly = true;
			_columnAppointBlockReason.Caption = @"AppointBlockReason";
			this.Columns.Add(_columnAppointBlockReason);
			_columnUserCreatedOn = new DataColumn("UserCreatedOn", typeof(System.DateTime), null, MappingType.Element);
			_columnUserCreatedOn.ReadOnly = true;
			_columnUserCreatedOn.Caption = @"UserCreatedOn";
			this.Columns.Add(_columnUserCreatedOn);
			_columnCustomerHealthInfo = new DataColumn("CustomerHealthInfo", typeof(System.Int32), null, MappingType.Element);
			_columnCustomerHealthInfo.ReadOnly = true;
			_columnCustomerHealthInfo.Caption = @"CustomerHealthInfo";
			this.Columns.Add(_columnCustomerHealthInfo);
			_columnIsRegistered = new DataColumn("IsRegistered", typeof(System.Int32), null, MappingType.Element);
			_columnIsRegistered.ReadOnly = true;
			_columnIsRegistered.Caption = @"IsRegistered";
			this.Columns.Add(_columnIsRegistered);
			_columnIsTestAttended = new DataColumn("IsTestAttended", typeof(System.Int32), null, MappingType.Element);
			_columnIsTestAttended.ReadOnly = true;
			_columnIsTestAttended.Caption = @"IsTestAttended";
			this.Columns.Add(_columnIsTestAttended);
			_columnIsPaid = new DataColumn("IsPaid", typeof(System.Int32), null, MappingType.Element);
			_columnIsPaid.ReadOnly = true;
			_columnIsPaid.Caption = @"IsPaid";
			this.Columns.Add(_columnIsPaid);
			_columnIsShippingApplied = new DataColumn("IsShippingApplied", typeof(System.Int32), null, MappingType.Element);
			_columnIsShippingApplied.ReadOnly = true;
			_columnIsShippingApplied.Caption = @"IsShippingApplied";
			this.Columns.Add(_columnIsShippingApplied);
			_columnPartnerRelease = new DataColumn("PartnerRelease", typeof(System.Int16), null, MappingType.Element);
			_columnPartnerRelease.ReadOnly = true;
			_columnPartnerRelease.Caption = @"PartnerRelease";
			this.Columns.Add(_columnPartnerRelease);
			_columnInsurancePayment = new DataColumn("InsurancePayment", typeof(System.Decimal), null, MappingType.Element);
			_columnInsurancePayment.ReadOnly = true;
			_columnInsurancePayment.Caption = @"InsurancePayment";
			this.Columns.Add(_columnInsurancePayment);
			_columnAwvVisitId = new DataColumn("AwvVisitId", typeof(System.Int64), null, MappingType.Element);
			_columnAwvVisitId.ReadOnly = true;
			_columnAwvVisitId.Caption = @"AwvVisitId";
			this.Columns.Add(_columnAwvVisitId);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CustomerOrderBasicInfoTypedView);
			
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
			_columnOrderId = this.Columns["OrderId"];
			_columnOrderDetailId = this.Columns["OrderDetailId"];
			_columnCustomerId = this.Columns["CustomerId"];
			_columnFirstName = this.Columns["FirstName"];
			_columnMiddleName = this.Columns["MiddleName"];
			_columnLastName = this.Columns["LastName"];
			_columnEmail1 = this.Columns["Email1"];
			_columnPhone = this.Columns["Phone"];
			_columnEventSignupDate = this.Columns["EventSignupDate"];
			_columnEventSignupRoleId = this.Columns["EventSignupRoleId"];
			_columnAppointmentId = this.Columns["AppointmentId"];
			_columnAppointmentStartTime = this.Columns["AppointmentStartTime"];
			_columnAppointmentEndTime = this.Columns["AppointmentEndTime"];
			_columnNoshow = this.Columns["Noshow"];
			_columnHipaastatus = this.Columns["Hipaastatus"];
			_columnEventPackageId = this.Columns["EventPackageId"];
			_columnEventName = this.Columns["EventName"];
			_columnEventDate = this.Columns["EventDate"];
			_columnEventId = this.Columns["EventId"];
			_columnFranchiseeName = this.Columns["FranchiseeName"];
			_columnOrganizationName = this.Columns["OrganizationName"];
			_columnHostAddress = this.Columns["HostAddress"];
			_columnHostState = this.Columns["HostState"];
			_columnHostCity = this.Columns["HostCity"];
			_columnHostZip = this.Columns["HostZip"];
			_columnLatitude = this.Columns["Latitude"];
			_columnLongitude = this.Columns["Longitude"];
			_columnIsManuallyVerified = this.Columns["IsManuallyVerified"];
			_columnUseLatLogForMapping = this.Columns["UseLatLogForMapping"];
			_columnCheckinTime = this.Columns["CheckinTime"];
			_columnCheckoutTime = this.Columns["CheckoutTime"];
			_columnLeftWithoutScreeningReasonId = this.Columns["LeftWithoutScreeningReasonId"];
			_columnPackagePrice = this.Columns["PackagePrice"];
			_columnEffectiveCost = this.Columns["EffectiveCost"];
			_columnPackageName = this.Columns["PackageName"];
			_columnPackageId = this.Columns["PackageId"];
			_columnAdditionalTest = this.Columns["AdditionalTest"];
			_columnEventSignupMarketingSource = this.Columns["EventSignupMarketingSource"];
			_columnEventStatus = this.Columns["EventStatus"];
			_columnSourceCodeId = this.Columns["SourceCodeId"];
			_columnSourceCode = this.Columns["SourceCode"];
			_columnSourceCodeAmount = this.Columns["SourceCodeAmount"];
			_columnShippingCost = this.Columns["ShippingCost"];
			_columnCreditCard = this.Columns["CreditCard"];
			_columnCheck = this.Columns["Check"];
			_columnEcheck = this.Columns["Echeck"];
			_columnCash = this.Columns["Cash"];
			_columnGc = this.Columns["Gc"];
			_columnIsAuthorized = this.Columns["IsAuthorized"];
			_columnCustomerEventTestId = this.Columns["CustomerEventTestId"];
			_columnIsResultPdfgenerated = this.Columns["IsResultPdfgenerated"];
			_columnIsPdfgenerated = this.Columns["IsPdfgenerated"];
			_columnIsResultReady = this.Columns["IsResultReady"];
			_columnIsColoractelResultReady = this.Columns["IsColoractelResultReady"];
			_columnTestStatus = this.Columns["TestStatus"];
			_columnAaatestEvaluation = this.Columns["AaatestEvaluation"];
			_columnAsitestEvaluation = this.Columns["AsitestEvaluation"];
			_columnCarotidTestEvaluation = this.Columns["CarotidTestEvaluation"];
			_columnOsteoTestEvaluation = this.Columns["OsteoTestEvaluation"];
			_columnPadtestEvaluation = this.Columns["PadtestEvaluation"];
			_columnEkgtestEvaluation = this.Columns["EkgtestEvaluation"];
			_columnLipidTestEvaluation = this.Columns["LipidTestEvaluation"];
			_columnLiverTestEvaluation = this.Columns["LiverTestEvaluation"];
			_columnFraminghamTestEvaluation = this.Columns["FraminghamTestEvaluation"];
			_columnAaapartialState = this.Columns["AaapartialState"];
			_columnAsipartialState = this.Columns["AsipartialState"];
			_columnCarotidPartialState = this.Columns["CarotidPartialState"];
			_columnOsteoPartialState = this.Columns["OsteoPartialState"];
			_columnPadpartialState = this.Columns["PadpartialState"];
			_columnEkgpartialState = this.Columns["EkgpartialState"];
			_columnLipidPartialState = this.Columns["LipidPartialState"];
			_columnLiverPartialState = this.Columns["LiverPartialState"];
			_columnFraminghamPartialState = this.Columns["FraminghamPartialState"];
			_columnEventCount = this.Columns["EventCount"];
			_columnScheduledByOrgRoleUserId = this.Columns["ScheduledByOrgRoleUserId"];
			_columnAppointBlockReason = this.Columns["AppointBlockReason"];
			_columnUserCreatedOn = this.Columns["UserCreatedOn"];
			_columnCustomerHealthInfo = this.Columns["CustomerHealthInfo"];
			_columnIsRegistered = this.Columns["IsRegistered"];
			_columnIsTestAttended = this.Columns["IsTestAttended"];
			_columnIsPaid = this.Columns["IsPaid"];
			_columnIsShippingApplied = this.Columns["IsShippingApplied"];
			_columnPartnerRelease = this.Columns["PartnerRelease"];
			_columnInsurancePayment = this.Columns["InsurancePayment"];
			_columnAwvVisitId = this.Columns["AwvVisitId"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CustomerOrderBasicInfoTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(CustomerOrderBasicInfoRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			CustomerOrderBasicInfoTypedView cloneToReturn = ((CustomerOrderBasicInfoTypedView)(base.Clone()));
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
			return new CustomerOrderBasicInfoTypedView();
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
			get { return CustomerOrderBasicInfoTypedView.CustomProperties;}
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
			get { return CustomerOrderBasicInfoTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public CustomerOrderBasicInfoRow this[int index] 
		{
			get 
			{
				return ((CustomerOrderBasicInfoRow)(this.Rows[index]));
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
		/// Returns the column object belonging to the TypedView field OrderId
		/// </summary>
		internal DataColumn OrderIdColumn 
		{
			get { return _columnOrderId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrderDetailId
		/// </summary>
		internal DataColumn OrderDetailIdColumn 
		{
			get { return _columnOrderDetailId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerId
		/// </summary>
		internal DataColumn CustomerIdColumn 
		{
			get { return _columnCustomerId; }
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
		/// Returns the column object belonging to the TypedView field Email1
		/// </summary>
		internal DataColumn Email1Column 
		{
			get { return _columnEmail1; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Phone
		/// </summary>
		internal DataColumn PhoneColumn 
		{
			get { return _columnPhone; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventSignupDate
		/// </summary>
		internal DataColumn EventSignupDateColumn 
		{
			get { return _columnEventSignupDate; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventSignupRoleId
		/// </summary>
		internal DataColumn EventSignupRoleIdColumn 
		{
			get { return _columnEventSignupRoleId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AppointmentId
		/// </summary>
		internal DataColumn AppointmentIdColumn 
		{
			get { return _columnAppointmentId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AppointmentStartTime
		/// </summary>
		internal DataColumn AppointmentStartTimeColumn 
		{
			get { return _columnAppointmentStartTime; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AppointmentEndTime
		/// </summary>
		internal DataColumn AppointmentEndTimeColumn 
		{
			get { return _columnAppointmentEndTime; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Noshow
		/// </summary>
		internal DataColumn NoshowColumn 
		{
			get { return _columnNoshow; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Hipaastatus
		/// </summary>
		internal DataColumn HipaastatusColumn 
		{
			get { return _columnHipaastatus; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventPackageId
		/// </summary>
		internal DataColumn EventPackageIdColumn 
		{
			get { return _columnEventPackageId; }
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
		/// Returns the column object belonging to the TypedView field EventId
		/// </summary>
		internal DataColumn EventIdColumn 
		{
			get { return _columnEventId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field FranchiseeName
		/// </summary>
		internal DataColumn FranchiseeNameColumn 
		{
			get { return _columnFranchiseeName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrganizationName
		/// </summary>
		internal DataColumn OrganizationNameColumn 
		{
			get { return _columnOrganizationName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field HostAddress
		/// </summary>
		internal DataColumn HostAddressColumn 
		{
			get { return _columnHostAddress; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field HostState
		/// </summary>
		internal DataColumn HostStateColumn 
		{
			get { return _columnHostState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field HostCity
		/// </summary>
		internal DataColumn HostCityColumn 
		{
			get { return _columnHostCity; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field HostZip
		/// </summary>
		internal DataColumn HostZipColumn 
		{
			get { return _columnHostZip; }
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
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CheckinTime
		/// </summary>
		internal DataColumn CheckinTimeColumn 
		{
			get { return _columnCheckinTime; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CheckoutTime
		/// </summary>
		internal DataColumn CheckoutTimeColumn 
		{
			get { return _columnCheckoutTime; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field LeftWithoutScreeningReasonId
		/// </summary>
		internal DataColumn LeftWithoutScreeningReasonIdColumn 
		{
			get { return _columnLeftWithoutScreeningReasonId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PackagePrice
		/// </summary>
		internal DataColumn PackagePriceColumn 
		{
			get { return _columnPackagePrice; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EffectiveCost
		/// </summary>
		internal DataColumn EffectiveCostColumn 
		{
			get { return _columnEffectiveCost; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PackageName
		/// </summary>
		internal DataColumn PackageNameColumn 
		{
			get { return _columnPackageName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PackageId
		/// </summary>
		internal DataColumn PackageIdColumn 
		{
			get { return _columnPackageId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AdditionalTest
		/// </summary>
		internal DataColumn AdditionalTestColumn 
		{
			get { return _columnAdditionalTest; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventSignupMarketingSource
		/// </summary>
		internal DataColumn EventSignupMarketingSourceColumn 
		{
			get { return _columnEventSignupMarketingSource; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventStatus
		/// </summary>
		internal DataColumn EventStatusColumn 
		{
			get { return _columnEventStatus; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field SourceCodeId
		/// </summary>
		internal DataColumn SourceCodeIdColumn 
		{
			get { return _columnSourceCodeId; }
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
		/// Returns the column object belonging to the TypedView field ShippingCost
		/// </summary>
		internal DataColumn ShippingCostColumn 
		{
			get { return _columnShippingCost; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CreditCard
		/// </summary>
		internal DataColumn CreditCardColumn 
		{
			get { return _columnCreditCard; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Check
		/// </summary>
		internal DataColumn CheckColumn 
		{
			get { return _columnCheck; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Echeck
		/// </summary>
		internal DataColumn EcheckColumn 
		{
			get { return _columnEcheck; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Cash
		/// </summary>
		internal DataColumn CashColumn 
		{
			get { return _columnCash; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field Gc
		/// </summary>
		internal DataColumn GcColumn 
		{
			get { return _columnGc; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsAuthorized
		/// </summary>
		internal DataColumn IsAuthorizedColumn 
		{
			get { return _columnIsAuthorized; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerEventTestId
		/// </summary>
		internal DataColumn CustomerEventTestIdColumn 
		{
			get { return _columnCustomerEventTestId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsResultPdfgenerated
		/// </summary>
		internal DataColumn IsResultPdfgeneratedColumn 
		{
			get { return _columnIsResultPdfgenerated; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsPdfgenerated
		/// </summary>
		internal DataColumn IsPdfgeneratedColumn 
		{
			get { return _columnIsPdfgenerated; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsResultReady
		/// </summary>
		internal DataColumn IsResultReadyColumn 
		{
			get { return _columnIsResultReady; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsColoractelResultReady
		/// </summary>
		internal DataColumn IsColoractelResultReadyColumn 
		{
			get { return _columnIsColoractelResultReady; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field TestStatus
		/// </summary>
		internal DataColumn TestStatusColumn 
		{
			get { return _columnTestStatus; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AaatestEvaluation
		/// </summary>
		internal DataColumn AaatestEvaluationColumn 
		{
			get { return _columnAaatestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AsitestEvaluation
		/// </summary>
		internal DataColumn AsitestEvaluationColumn 
		{
			get { return _columnAsitestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CarotidTestEvaluation
		/// </summary>
		internal DataColumn CarotidTestEvaluationColumn 
		{
			get { return _columnCarotidTestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OsteoTestEvaluation
		/// </summary>
		internal DataColumn OsteoTestEvaluationColumn 
		{
			get { return _columnOsteoTestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PadtestEvaluation
		/// </summary>
		internal DataColumn PadtestEvaluationColumn 
		{
			get { return _columnPadtestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EkgtestEvaluation
		/// </summary>
		internal DataColumn EkgtestEvaluationColumn 
		{
			get { return _columnEkgtestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field LipidTestEvaluation
		/// </summary>
		internal DataColumn LipidTestEvaluationColumn 
		{
			get { return _columnLipidTestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field LiverTestEvaluation
		/// </summary>
		internal DataColumn LiverTestEvaluationColumn 
		{
			get { return _columnLiverTestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field FraminghamTestEvaluation
		/// </summary>
		internal DataColumn FraminghamTestEvaluationColumn 
		{
			get { return _columnFraminghamTestEvaluation; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AaapartialState
		/// </summary>
		internal DataColumn AaapartialStateColumn 
		{
			get { return _columnAaapartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AsipartialState
		/// </summary>
		internal DataColumn AsipartialStateColumn 
		{
			get { return _columnAsipartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CarotidPartialState
		/// </summary>
		internal DataColumn CarotidPartialStateColumn 
		{
			get { return _columnCarotidPartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OsteoPartialState
		/// </summary>
		internal DataColumn OsteoPartialStateColumn 
		{
			get { return _columnOsteoPartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PadpartialState
		/// </summary>
		internal DataColumn PadpartialStateColumn 
		{
			get { return _columnPadpartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EkgpartialState
		/// </summary>
		internal DataColumn EkgpartialStateColumn 
		{
			get { return _columnEkgpartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field LipidPartialState
		/// </summary>
		internal DataColumn LipidPartialStateColumn 
		{
			get { return _columnLipidPartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field LiverPartialState
		/// </summary>
		internal DataColumn LiverPartialStateColumn 
		{
			get { return _columnLiverPartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field FraminghamPartialState
		/// </summary>
		internal DataColumn FraminghamPartialStateColumn 
		{
			get { return _columnFraminghamPartialState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventCount
		/// </summary>
		internal DataColumn EventCountColumn 
		{
			get { return _columnEventCount; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field ScheduledByOrgRoleUserId
		/// </summary>
		internal DataColumn ScheduledByOrgRoleUserIdColumn 
		{
			get { return _columnScheduledByOrgRoleUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AppointBlockReason
		/// </summary>
		internal DataColumn AppointBlockReasonColumn 
		{
			get { return _columnAppointBlockReason; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field UserCreatedOn
		/// </summary>
		internal DataColumn UserCreatedOnColumn 
		{
			get { return _columnUserCreatedOn; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field CustomerHealthInfo
		/// </summary>
		internal DataColumn CustomerHealthInfoColumn 
		{
			get { return _columnCustomerHealthInfo; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsRegistered
		/// </summary>
		internal DataColumn IsRegisteredColumn 
		{
			get { return _columnIsRegistered; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsTestAttended
		/// </summary>
		internal DataColumn IsTestAttendedColumn 
		{
			get { return _columnIsTestAttended; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsPaid
		/// </summary>
		internal DataColumn IsPaidColumn 
		{
			get { return _columnIsPaid; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsShippingApplied
		/// </summary>
		internal DataColumn IsShippingAppliedColumn 
		{
			get { return _columnIsShippingApplied; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PartnerRelease
		/// </summary>
		internal DataColumn PartnerReleaseColumn 
		{
			get { return _columnPartnerRelease; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field InsurancePayment
		/// </summary>
		internal DataColumn InsurancePaymentColumn 
		{
			get { return _columnInsurancePayment; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field AwvVisitId
		/// </summary>
		internal DataColumn AwvVisitIdColumn 
		{
			get { return _columnAwvVisitId; }
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
	/// Typed datarow for the typed datatable CustomerOrderBasicInfo
	/// </summary>
	public partial class CustomerOrderBasicInfoRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private CustomerOrderBasicInfoTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal CustomerOrderBasicInfoRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((CustomerOrderBasicInfoTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field EventCustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventCustomerID"<br/>
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
		/// Gets / sets the value of the TypedView field OrderId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."OrderID"<br/>
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
		/// Gets / sets the value of the TypedView field OrderDetailId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."OrderDetailID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 OrderDetailId 
		{
			get 
			{
				if(IsOrderDetailIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.OrderDetailIdColumn];
				}
			}
			set 
			{
				this[_parent.OrderDetailIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OrderDetailId is NULL, false otherwise.
		/// </summary>
		public bool IsOrderDetailIdNull() 
		{
			return IsNull(_parent.OrderDetailIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field OrderDetailId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOrderDetailIdNull() 
		{
			this[_parent.OrderDetailIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."CustomerID"<br/>
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
		/// Gets / sets the value of the TypedView field FirstName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."FirstName"<br/>
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
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."MiddleName"<br/>
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
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."LastName"<br/>
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
		/// Gets / sets the value of the TypedView field Email1<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."Email1"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 100
		/// </remarks>
		public System.String Email1 
		{
			get 
			{
				if(IsEmail1Null())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.Email1Column];
				}
			}
			set 
			{
				this[_parent.Email1Column] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Email1 is NULL, false otherwise.
		/// </summary>
		public bool IsEmail1Null() 
		{
			return IsNull(_parent.Email1Column);
		}

		/// <summary>
		/// Sets the TypedView field Email1 to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEmail1Null() 
		{
			this[_parent.Email1Column] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Phone<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."Phone"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 50
		/// </remarks>
		public System.String Phone 
		{
			get 
			{
				if(IsPhoneNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.PhoneColumn];
				}
			}
			set 
			{
				this[_parent.PhoneColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Phone is NULL, false otherwise.
		/// </summary>
		public bool IsPhoneNull() 
		{
			return IsNull(_parent.PhoneColumn);
		}

		/// <summary>
		/// Sets the TypedView field Phone to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPhoneNull() 
		{
			this[_parent.PhoneColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventSignupDate<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventSignupDate"<br/>
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
		/// Gets / sets the value of the TypedView field EventSignupRoleId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventSignupRoleId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 EventSignupRoleId 
		{
			get 
			{
				if(IsEventSignupRoleIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.EventSignupRoleIdColumn];
				}
			}
			set 
			{
				this[_parent.EventSignupRoleIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventSignupRoleId is NULL, false otherwise.
		/// </summary>
		public bool IsEventSignupRoleIdNull() 
		{
			return IsNull(_parent.EventSignupRoleIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventSignupRoleId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventSignupRoleIdNull() 
		{
			this[_parent.EventSignupRoleIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AppointmentId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."AppointmentID"<br/>
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
		/// Gets / sets the value of the TypedView field AppointmentStartTime<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."AppointmentStartTime"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime AppointmentStartTime 
		{
			get 
			{
				if(IsAppointmentStartTimeNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.AppointmentStartTimeColumn];
				}
			}
			set 
			{
				this[_parent.AppointmentStartTimeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AppointmentStartTime is NULL, false otherwise.
		/// </summary>
		public bool IsAppointmentStartTimeNull() 
		{
			return IsNull(_parent.AppointmentStartTimeColumn);
		}

		/// <summary>
		/// Sets the TypedView field AppointmentStartTime to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAppointmentStartTimeNull() 
		{
			this[_parent.AppointmentStartTimeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AppointmentEndTime<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."AppointmentEndTime"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime AppointmentEndTime 
		{
			get 
			{
				if(IsAppointmentEndTimeNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.AppointmentEndTimeColumn];
				}
			}
			set 
			{
				this[_parent.AppointmentEndTimeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AppointmentEndTime is NULL, false otherwise.
		/// </summary>
		public bool IsAppointmentEndTimeNull() 
		{
			return IsNull(_parent.AppointmentEndTimeColumn);
		}

		/// <summary>
		/// Sets the TypedView field AppointmentEndTime to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAppointmentEndTimeNull() 
		{
			this[_parent.AppointmentEndTimeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Noshow<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."Noshow"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean Noshow 
		{
			get 
			{
				if(IsNoshowNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.NoshowColumn];
				}
			}
			set 
			{
				this[_parent.NoshowColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Noshow is NULL, false otherwise.
		/// </summary>
		public bool IsNoshowNull() 
		{
			return IsNull(_parent.NoshowColumn);
		}

		/// <summary>
		/// Sets the TypedView field Noshow to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetNoshowNull() 
		{
			this[_parent.NoshowColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Hipaastatus<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."HIPAAStatus"<br/>
		/// View field characteristics (type, precision, scale, length): SmallInt, 5, 0, 0
		/// </remarks>
		public System.Int16 Hipaastatus 
		{
			get 
			{
				if(IsHipaastatusNull())
				{
					// return default value for this type.
					return (System.Int16)TypeDefaultValue.GetDefaultValue(typeof(System.Int16));
				}
				else
				{
					return (System.Int16)this[_parent.HipaastatusColumn];
				}
			}
			set 
			{
				this[_parent.HipaastatusColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Hipaastatus is NULL, false otherwise.
		/// </summary>
		public bool IsHipaastatusNull() 
		{
			return IsNull(_parent.HipaastatusColumn);
		}

		/// <summary>
		/// Sets the TypedView field Hipaastatus to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetHipaastatusNull() 
		{
			this[_parent.HipaastatusColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventPackageId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventPackageID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 EventPackageId 
		{
			get 
			{
				if(IsEventPackageIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.EventPackageIdColumn];
				}
			}
			set 
			{
				this[_parent.EventPackageIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventPackageId is NULL, false otherwise.
		/// </summary>
		public bool IsEventPackageIdNull() 
		{
			return IsNull(_parent.EventPackageIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventPackageId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventPackageIdNull() 
		{
			this[_parent.EventPackageIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventName"<br/>
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
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventDate"<br/>
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
		/// Gets / sets the value of the TypedView field EventId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventID"<br/>
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
		/// Gets / sets the value of the TypedView field FranchiseeName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."FranchiseeName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 512
		/// </remarks>
		public System.String FranchiseeName 
		{
			get 
			{
				if(IsFranchiseeNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.FranchiseeNameColumn];
				}
			}
			set 
			{
				this[_parent.FranchiseeNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field FranchiseeName is NULL, false otherwise.
		/// </summary>
		public bool IsFranchiseeNameNull() 
		{
			return IsNull(_parent.FranchiseeNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field FranchiseeName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetFranchiseeNameNull() 
		{
			this[_parent.FranchiseeNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OrganizationName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."OrganizationName"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String OrganizationName 
		{
			get 
			{
				if(IsOrganizationNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.OrganizationNameColumn];
				}
			}
			set 
			{
				this[_parent.OrganizationNameColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OrganizationName is NULL, false otherwise.
		/// </summary>
		public bool IsOrganizationNameNull() 
		{
			return IsNull(_parent.OrganizationNameColumn);
		}

		/// <summary>
		/// Sets the TypedView field OrganizationName to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOrganizationNameNull() 
		{
			this[_parent.OrganizationNameColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field HostAddress<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."HostAddress"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String HostAddress 
		{
			get 
			{
				if(IsHostAddressNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.HostAddressColumn];
				}
			}
			set 
			{
				this[_parent.HostAddressColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field HostAddress is NULL, false otherwise.
		/// </summary>
		public bool IsHostAddressNull() 
		{
			return IsNull(_parent.HostAddressColumn);
		}

		/// <summary>
		/// Sets the TypedView field HostAddress to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetHostAddressNull() 
		{
			this[_parent.HostAddressColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field HostState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."HostState"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String HostState 
		{
			get 
			{
				if(IsHostStateNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.HostStateColumn];
				}
			}
			set 
			{
				this[_parent.HostStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field HostState is NULL, false otherwise.
		/// </summary>
		public bool IsHostStateNull() 
		{
			return IsNull(_parent.HostStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field HostState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetHostStateNull() 
		{
			this[_parent.HostStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field HostCity<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."HostCity"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String HostCity 
		{
			get 
			{
				if(IsHostCityNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.HostCityColumn];
				}
			}
			set 
			{
				this[_parent.HostCityColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field HostCity is NULL, false otherwise.
		/// </summary>
		public bool IsHostCityNull() 
		{
			return IsNull(_parent.HostCityColumn);
		}

		/// <summary>
		/// Sets the TypedView field HostCity to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetHostCityNull() 
		{
			this[_parent.HostCityColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field HostZip<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."HostZip"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String HostZip 
		{
			get 
			{
				if(IsHostZipNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.HostZipColumn];
				}
			}
			set 
			{
				this[_parent.HostZipColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field HostZip is NULL, false otherwise.
		/// </summary>
		public bool IsHostZipNull() 
		{
			return IsNull(_parent.HostZipColumn);
		}

		/// <summary>
		/// Sets the TypedView field HostZip to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetHostZipNull() 
		{
			this[_parent.HostZipColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Latitude<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."Latitude"<br/>
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
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."Longitude"<br/>
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
		/// Gets / sets the value of the TypedView field IsManuallyVerified<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsManuallyVerified"<br/>
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
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."UseLatLogForMapping"<br/>
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

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CheckinTime<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."CheckinTime"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime CheckinTime 
		{
			get 
			{
				if(IsCheckinTimeNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.CheckinTimeColumn];
				}
			}
			set 
			{
				this[_parent.CheckinTimeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CheckinTime is NULL, false otherwise.
		/// </summary>
		public bool IsCheckinTimeNull() 
		{
			return IsNull(_parent.CheckinTimeColumn);
		}

		/// <summary>
		/// Sets the TypedView field CheckinTime to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCheckinTimeNull() 
		{
			this[_parent.CheckinTimeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CheckoutTime<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."CheckoutTime"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime CheckoutTime 
		{
			get 
			{
				if(IsCheckoutTimeNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.CheckoutTimeColumn];
				}
			}
			set 
			{
				this[_parent.CheckoutTimeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CheckoutTime is NULL, false otherwise.
		/// </summary>
		public bool IsCheckoutTimeNull() 
		{
			return IsNull(_parent.CheckoutTimeColumn);
		}

		/// <summary>
		/// Sets the TypedView field CheckoutTime to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCheckoutTimeNull() 
		{
			this[_parent.CheckoutTimeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field LeftWithoutScreeningReasonId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."LeftWithoutScreeningReasonId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 LeftWithoutScreeningReasonId 
		{
			get 
			{
				if(IsLeftWithoutScreeningReasonIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.LeftWithoutScreeningReasonIdColumn];
				}
			}
			set 
			{
				this[_parent.LeftWithoutScreeningReasonIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field LeftWithoutScreeningReasonId is NULL, false otherwise.
		/// </summary>
		public bool IsLeftWithoutScreeningReasonIdNull() 
		{
			return IsNull(_parent.LeftWithoutScreeningReasonIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field LeftWithoutScreeningReasonId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetLeftWithoutScreeningReasonIdNull() 
		{
			this[_parent.LeftWithoutScreeningReasonIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PackagePrice<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."PackagePrice"<br/>
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

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EffectiveCost<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EffectiveCost"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal EffectiveCost 
		{
			get 
			{
				if(IsEffectiveCostNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.EffectiveCostColumn];
				}
			}
			set 
			{
				this[_parent.EffectiveCostColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EffectiveCost is NULL, false otherwise.
		/// </summary>
		public bool IsEffectiveCostNull() 
		{
			return IsNull(_parent.EffectiveCostColumn);
		}

		/// <summary>
		/// Sets the TypedView field EffectiveCost to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEffectiveCostNull() 
		{
			this[_parent.EffectiveCostColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PackageName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."PackageName"<br/>
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
		/// Gets / sets the value of the TypedView field PackageId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."PackageID"<br/>
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
		/// Gets / sets the value of the TypedView field AdditionalTest<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."AdditionalTest"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 2000
		/// </remarks>
		public System.String AdditionalTest 
		{
			get 
			{
				if(IsAdditionalTestNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.AdditionalTestColumn];
				}
			}
			set 
			{
				this[_parent.AdditionalTestColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AdditionalTest is NULL, false otherwise.
		/// </summary>
		public bool IsAdditionalTestNull() 
		{
			return IsNull(_parent.AdditionalTestColumn);
		}

		/// <summary>
		/// Sets the TypedView field AdditionalTest to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAdditionalTestNull() 
		{
			this[_parent.AdditionalTestColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventSignupMarketingSource<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventSignupMarketingSource"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 500
		/// </remarks>
		public System.String EventSignupMarketingSource 
		{
			get 
			{
				if(IsEventSignupMarketingSourceNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.EventSignupMarketingSourceColumn];
				}
			}
			set 
			{
				this[_parent.EventSignupMarketingSourceColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventSignupMarketingSource is NULL, false otherwise.
		/// </summary>
		public bool IsEventSignupMarketingSourceNull() 
		{
			return IsNull(_parent.EventSignupMarketingSourceColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventSignupMarketingSource to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventSignupMarketingSourceNull() 
		{
			this[_parent.EventSignupMarketingSourceColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventStatus<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventStatus"<br/>
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
		/// Gets / sets the value of the TypedView field SourceCodeId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."SourceCodeID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 SourceCodeId 
		{
			get 
			{
				if(IsSourceCodeIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.SourceCodeIdColumn];
				}
			}
			set 
			{
				this[_parent.SourceCodeIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field SourceCodeId is NULL, false otherwise.
		/// </summary>
		public bool IsSourceCodeIdNull() 
		{
			return IsNull(_parent.SourceCodeIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field SourceCodeId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetSourceCodeIdNull() 
		{
			this[_parent.SourceCodeIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field SourceCode<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."SourceCode"<br/>
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
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."SourceCodeAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
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
		/// Gets / sets the value of the TypedView field ShippingCost<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."ShippingCost"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal ShippingCost 
		{
			get 
			{
				if(IsShippingCostNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.ShippingCostColumn];
				}
			}
			set 
			{
				this[_parent.ShippingCostColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field ShippingCost is NULL, false otherwise.
		/// </summary>
		public bool IsShippingCostNull() 
		{
			return IsNull(_parent.ShippingCostColumn);
		}

		/// <summary>
		/// Sets the TypedView field ShippingCost to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetShippingCostNull() 
		{
			this[_parent.ShippingCostColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CreditCard<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."CreditCard"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal CreditCard 
		{
			get 
			{
				if(IsCreditCardNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.CreditCardColumn];
				}
			}
			set 
			{
				this[_parent.CreditCardColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CreditCard is NULL, false otherwise.
		/// </summary>
		public bool IsCreditCardNull() 
		{
			return IsNull(_parent.CreditCardColumn);
		}

		/// <summary>
		/// Sets the TypedView field CreditCard to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCreditCardNull() 
		{
			this[_parent.CreditCardColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Check<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."Check"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal Check 
		{
			get 
			{
				if(IsCheckNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.CheckColumn];
				}
			}
			set 
			{
				this[_parent.CheckColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Check is NULL, false otherwise.
		/// </summary>
		public bool IsCheckNull() 
		{
			return IsNull(_parent.CheckColumn);
		}

		/// <summary>
		/// Sets the TypedView field Check to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCheckNull() 
		{
			this[_parent.CheckColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Echeck<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."ECheck"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal Echeck 
		{
			get 
			{
				if(IsEcheckNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.EcheckColumn];
				}
			}
			set 
			{
				this[_parent.EcheckColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Echeck is NULL, false otherwise.
		/// </summary>
		public bool IsEcheckNull() 
		{
			return IsNull(_parent.EcheckColumn);
		}

		/// <summary>
		/// Sets the TypedView field Echeck to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEcheckNull() 
		{
			this[_parent.EcheckColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Cash<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."Cash"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal Cash 
		{
			get 
			{
				if(IsCashNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.CashColumn];
				}
			}
			set 
			{
				this[_parent.CashColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Cash is NULL, false otherwise.
		/// </summary>
		public bool IsCashNull() 
		{
			return IsNull(_parent.CashColumn);
		}

		/// <summary>
		/// Sets the TypedView field Cash to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCashNull() 
		{
			this[_parent.CashColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field Gc<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."GC"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal Gc 
		{
			get 
			{
				if(IsGcNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.GcColumn];
				}
			}
			set 
			{
				this[_parent.GcColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field Gc is NULL, false otherwise.
		/// </summary>
		public bool IsGcNull() 
		{
			return IsNull(_parent.GcColumn);
		}

		/// <summary>
		/// Sets the TypedView field Gc to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetGcNull() 
		{
			this[_parent.GcColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsAuthorized<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsAuthorized"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 IsAuthorized 
		{
			get 
			{
				if(IsIsAuthorizedNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.IsAuthorizedColumn];
				}
			}
			set 
			{
				this[_parent.IsAuthorizedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsAuthorized is NULL, false otherwise.
		/// </summary>
		public bool IsIsAuthorizedNull() 
		{
			return IsNull(_parent.IsAuthorizedColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsAuthorized to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsAuthorizedNull() 
		{
			this[_parent.IsAuthorizedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerEventTestId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."CustomerEventTestID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 CustomerEventTestId 
		{
			get 
			{
				if(IsCustomerEventTestIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.CustomerEventTestIdColumn];
				}
			}
			set 
			{
				this[_parent.CustomerEventTestIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CustomerEventTestId is NULL, false otherwise.
		/// </summary>
		public bool IsCustomerEventTestIdNull() 
		{
			return IsNull(_parent.CustomerEventTestIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field CustomerEventTestId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCustomerEventTestIdNull() 
		{
			this[_parent.CustomerEventTestIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsResultPdfgenerated<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsResultPDFGenerated"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean IsResultPdfgenerated 
		{
			get 
			{
				if(IsIsResultPdfgeneratedNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.IsResultPdfgeneratedColumn];
				}
			}
			set 
			{
				this[_parent.IsResultPdfgeneratedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsResultPdfgenerated is NULL, false otherwise.
		/// </summary>
		public bool IsIsResultPdfgeneratedNull() 
		{
			return IsNull(_parent.IsResultPdfgeneratedColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsResultPdfgenerated to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsResultPdfgeneratedNull() 
		{
			this[_parent.IsResultPdfgeneratedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsPdfgenerated<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsPDFGenerated"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0
		/// </remarks>
		public System.Boolean IsPdfgenerated 
		{
			get 
			{
				if(IsIsPdfgeneratedNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.IsPdfgeneratedColumn];
				}
			}
			set 
			{
				this[_parent.IsPdfgeneratedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsPdfgenerated is NULL, false otherwise.
		/// </summary>
		public bool IsIsPdfgeneratedNull() 
		{
			return IsNull(_parent.IsPdfgeneratedColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsPdfgenerated to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsPdfgeneratedNull() 
		{
			this[_parent.IsPdfgeneratedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsResultReady<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsResultReady"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 IsResultReady 
		{
			get 
			{
				if(IsIsResultReadyNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.IsResultReadyColumn];
				}
			}
			set 
			{
				this[_parent.IsResultReadyColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsResultReady is NULL, false otherwise.
		/// </summary>
		public bool IsIsResultReadyNull() 
		{
			return IsNull(_parent.IsResultReadyColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsResultReady to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsResultReadyNull() 
		{
			this[_parent.IsResultReadyColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsColoractelResultReady<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsColoractelResultReady"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 IsColoractelResultReady 
		{
			get 
			{
				if(IsIsColoractelResultReadyNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.IsColoractelResultReadyColumn];
				}
			}
			set 
			{
				this[_parent.IsColoractelResultReadyColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsColoractelResultReady is NULL, false otherwise.
		/// </summary>
		public bool IsIsColoractelResultReadyNull() 
		{
			return IsNull(_parent.IsColoractelResultReadyColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsColoractelResultReady to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsColoractelResultReadyNull() 
		{
			this[_parent.IsColoractelResultReadyColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field TestStatus<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."TestStatus"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 TestStatus 
		{
			get 
			{
				if(IsTestStatusNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.TestStatusColumn];
				}
			}
			set 
			{
				this[_parent.TestStatusColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field TestStatus is NULL, false otherwise.
		/// </summary>
		public bool IsTestStatusNull() 
		{
			return IsNull(_parent.TestStatusColumn);
		}

		/// <summary>
		/// Sets the TypedView field TestStatus to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetTestStatusNull() 
		{
			this[_parent.TestStatusColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AaatestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."AAATestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 AaatestEvaluation 
		{
			get 
			{
				if(IsAaatestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.AaatestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.AaatestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AaatestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsAaatestEvaluationNull() 
		{
			return IsNull(_parent.AaatestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field AaatestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAaatestEvaluationNull() 
		{
			this[_parent.AaatestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AsitestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."ASITestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 AsitestEvaluation 
		{
			get 
			{
				if(IsAsitestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.AsitestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.AsitestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AsitestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsAsitestEvaluationNull() 
		{
			return IsNull(_parent.AsitestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field AsitestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAsitestEvaluationNull() 
		{
			this[_parent.AsitestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CarotidTestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."CarotidTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 CarotidTestEvaluation 
		{
			get 
			{
				if(IsCarotidTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.CarotidTestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.CarotidTestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CarotidTestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsCarotidTestEvaluationNull() 
		{
			return IsNull(_parent.CarotidTestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field CarotidTestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCarotidTestEvaluationNull() 
		{
			this[_parent.CarotidTestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OsteoTestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."OsteoTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 OsteoTestEvaluation 
		{
			get 
			{
				if(IsOsteoTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.OsteoTestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.OsteoTestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OsteoTestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsOsteoTestEvaluationNull() 
		{
			return IsNull(_parent.OsteoTestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field OsteoTestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOsteoTestEvaluationNull() 
		{
			this[_parent.OsteoTestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PadtestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."PADTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 PadtestEvaluation 
		{
			get 
			{
				if(IsPadtestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.PadtestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.PadtestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PadtestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsPadtestEvaluationNull() 
		{
			return IsNull(_parent.PadtestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field PadtestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPadtestEvaluationNull() 
		{
			this[_parent.PadtestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EkgtestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EKGTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 EkgtestEvaluation 
		{
			get 
			{
				if(IsEkgtestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.EkgtestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.EkgtestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EkgtestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsEkgtestEvaluationNull() 
		{
			return IsNull(_parent.EkgtestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field EkgtestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEkgtestEvaluationNull() 
		{
			this[_parent.EkgtestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field LipidTestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."LipidTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 LipidTestEvaluation 
		{
			get 
			{
				if(IsLipidTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.LipidTestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.LipidTestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field LipidTestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsLipidTestEvaluationNull() 
		{
			return IsNull(_parent.LipidTestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field LipidTestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetLipidTestEvaluationNull() 
		{
			this[_parent.LipidTestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field LiverTestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."LiverTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 LiverTestEvaluation 
		{
			get 
			{
				if(IsLiverTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.LiverTestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.LiverTestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field LiverTestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsLiverTestEvaluationNull() 
		{
			return IsNull(_parent.LiverTestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field LiverTestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetLiverTestEvaluationNull() 
		{
			this[_parent.LiverTestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field FraminghamTestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."FraminghamTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 FraminghamTestEvaluation 
		{
			get 
			{
				if(IsFraminghamTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.FraminghamTestEvaluationColumn];
				}
			}
			set 
			{
				this[_parent.FraminghamTestEvaluationColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field FraminghamTestEvaluation is NULL, false otherwise.
		/// </summary>
		public bool IsFraminghamTestEvaluationNull() 
		{
			return IsNull(_parent.FraminghamTestEvaluationColumn);
		}

		/// <summary>
		/// Sets the TypedView field FraminghamTestEvaluation to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetFraminghamTestEvaluationNull() 
		{
			this[_parent.FraminghamTestEvaluationColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AaapartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."AAAPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 AaapartialState 
		{
			get 
			{
				if(IsAaapartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.AaapartialStateColumn];
				}
			}
			set 
			{
				this[_parent.AaapartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AaapartialState is NULL, false otherwise.
		/// </summary>
		public bool IsAaapartialStateNull() 
		{
			return IsNull(_parent.AaapartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field AaapartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAaapartialStateNull() 
		{
			this[_parent.AaapartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AsipartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."ASIPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 AsipartialState 
		{
			get 
			{
				if(IsAsipartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.AsipartialStateColumn];
				}
			}
			set 
			{
				this[_parent.AsipartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AsipartialState is NULL, false otherwise.
		/// </summary>
		public bool IsAsipartialStateNull() 
		{
			return IsNull(_parent.AsipartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field AsipartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAsipartialStateNull() 
		{
			this[_parent.AsipartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CarotidPartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."CarotidPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 CarotidPartialState 
		{
			get 
			{
				if(IsCarotidPartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.CarotidPartialStateColumn];
				}
			}
			set 
			{
				this[_parent.CarotidPartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CarotidPartialState is NULL, false otherwise.
		/// </summary>
		public bool IsCarotidPartialStateNull() 
		{
			return IsNull(_parent.CarotidPartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field CarotidPartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCarotidPartialStateNull() 
		{
			this[_parent.CarotidPartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OsteoPartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."OsteoPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 OsteoPartialState 
		{
			get 
			{
				if(IsOsteoPartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.OsteoPartialStateColumn];
				}
			}
			set 
			{
				this[_parent.OsteoPartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OsteoPartialState is NULL, false otherwise.
		/// </summary>
		public bool IsOsteoPartialStateNull() 
		{
			return IsNull(_parent.OsteoPartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field OsteoPartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOsteoPartialStateNull() 
		{
			this[_parent.OsteoPartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PadpartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."PADPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 PadpartialState 
		{
			get 
			{
				if(IsPadpartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.PadpartialStateColumn];
				}
			}
			set 
			{
				this[_parent.PadpartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PadpartialState is NULL, false otherwise.
		/// </summary>
		public bool IsPadpartialStateNull() 
		{
			return IsNull(_parent.PadpartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field PadpartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPadpartialStateNull() 
		{
			this[_parent.PadpartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EkgpartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EKGPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 EkgpartialState 
		{
			get 
			{
				if(IsEkgpartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.EkgpartialStateColumn];
				}
			}
			set 
			{
				this[_parent.EkgpartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EkgpartialState is NULL, false otherwise.
		/// </summary>
		public bool IsEkgpartialStateNull() 
		{
			return IsNull(_parent.EkgpartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field EkgpartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEkgpartialStateNull() 
		{
			this[_parent.EkgpartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field LipidPartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."LipidPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 LipidPartialState 
		{
			get 
			{
				if(IsLipidPartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.LipidPartialStateColumn];
				}
			}
			set 
			{
				this[_parent.LipidPartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field LipidPartialState is NULL, false otherwise.
		/// </summary>
		public bool IsLipidPartialStateNull() 
		{
			return IsNull(_parent.LipidPartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field LipidPartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetLipidPartialStateNull() 
		{
			this[_parent.LipidPartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field LiverPartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."LiverPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 LiverPartialState 
		{
			get 
			{
				if(IsLiverPartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.LiverPartialStateColumn];
				}
			}
			set 
			{
				this[_parent.LiverPartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field LiverPartialState is NULL, false otherwise.
		/// </summary>
		public bool IsLiverPartialStateNull() 
		{
			return IsNull(_parent.LiverPartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field LiverPartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetLiverPartialStateNull() 
		{
			this[_parent.LiverPartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field FraminghamPartialState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."FraminghamPartialState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 FraminghamPartialState 
		{
			get 
			{
				if(IsFraminghamPartialStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.FraminghamPartialStateColumn];
				}
			}
			set 
			{
				this[_parent.FraminghamPartialStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field FraminghamPartialState is NULL, false otherwise.
		/// </summary>
		public bool IsFraminghamPartialStateNull() 
		{
			return IsNull(_parent.FraminghamPartialStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field FraminghamPartialState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetFraminghamPartialStateNull() 
		{
			this[_parent.FraminghamPartialStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventCount<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."EventCount"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 EventCount 
		{
			get 
			{
				if(IsEventCountNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.EventCountColumn];
				}
			}
			set 
			{
				this[_parent.EventCountColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventCount is NULL, false otherwise.
		/// </summary>
		public bool IsEventCountNull() 
		{
			return IsNull(_parent.EventCountColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventCount to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventCountNull() 
		{
			this[_parent.EventCountColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field ScheduledByOrgRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."ScheduledByOrgRoleUserId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 ScheduledByOrgRoleUserId 
		{
			get 
			{
				if(IsScheduledByOrgRoleUserIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.ScheduledByOrgRoleUserIdColumn];
				}
			}
			set 
			{
				this[_parent.ScheduledByOrgRoleUserIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field ScheduledByOrgRoleUserId is NULL, false otherwise.
		/// </summary>
		public bool IsScheduledByOrgRoleUserIdNull() 
		{
			return IsNull(_parent.ScheduledByOrgRoleUserIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field ScheduledByOrgRoleUserId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetScheduledByOrgRoleUserIdNull() 
		{
			this[_parent.ScheduledByOrgRoleUserIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AppointBlockReason<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."AppointBlockReason"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 1
		/// </remarks>
		public System.String AppointBlockReason 
		{
			get 
			{
				if(IsAppointBlockReasonNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.AppointBlockReasonColumn];
				}
			}
			set 
			{
				this[_parent.AppointBlockReasonColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AppointBlockReason is NULL, false otherwise.
		/// </summary>
		public bool IsAppointBlockReasonNull() 
		{
			return IsNull(_parent.AppointBlockReasonColumn);
		}

		/// <summary>
		/// Sets the TypedView field AppointBlockReason to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAppointBlockReasonNull() 
		{
			this[_parent.AppointBlockReasonColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field UserCreatedOn<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."UserCreatedOn"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime UserCreatedOn 
		{
			get 
			{
				if(IsUserCreatedOnNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.UserCreatedOnColumn];
				}
			}
			set 
			{
				this[_parent.UserCreatedOnColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field UserCreatedOn is NULL, false otherwise.
		/// </summary>
		public bool IsUserCreatedOnNull() 
		{
			return IsNull(_parent.UserCreatedOnColumn);
		}

		/// <summary>
		/// Sets the TypedView field UserCreatedOn to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetUserCreatedOnNull() 
		{
			this[_parent.UserCreatedOnColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field CustomerHealthInfo<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."CustomerHealthInfo"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 CustomerHealthInfo 
		{
			get 
			{
				if(IsCustomerHealthInfoNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.CustomerHealthInfoColumn];
				}
			}
			set 
			{
				this[_parent.CustomerHealthInfoColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field CustomerHealthInfo is NULL, false otherwise.
		/// </summary>
		public bool IsCustomerHealthInfoNull() 
		{
			return IsNull(_parent.CustomerHealthInfoColumn);
		}

		/// <summary>
		/// Sets the TypedView field CustomerHealthInfo to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetCustomerHealthInfoNull() 
		{
			this[_parent.CustomerHealthInfoColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsRegistered<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsRegistered"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 IsRegistered 
		{
			get 
			{
				if(IsIsRegisteredNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.IsRegisteredColumn];
				}
			}
			set 
			{
				this[_parent.IsRegisteredColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsRegistered is NULL, false otherwise.
		/// </summary>
		public bool IsIsRegisteredNull() 
		{
			return IsNull(_parent.IsRegisteredColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsRegistered to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsRegisteredNull() 
		{
			this[_parent.IsRegisteredColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsTestAttended<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsTestAttended"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 IsTestAttended 
		{
			get 
			{
				if(IsIsTestAttendedNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.IsTestAttendedColumn];
				}
			}
			set 
			{
				this[_parent.IsTestAttendedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsTestAttended is NULL, false otherwise.
		/// </summary>
		public bool IsIsTestAttendedNull() 
		{
			return IsNull(_parent.IsTestAttendedColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsTestAttended to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsTestAttendedNull() 
		{
			this[_parent.IsTestAttendedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsPaid<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."IsPaid"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 IsPaid 
		{
			get 
			{
				if(IsIsPaidNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.IsPaidColumn];
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
		/// Gets / sets the value of the TypedView field IsShippingApplied<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."isShippingApplied"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 IsShippingApplied 
		{
			get 
			{
				if(IsIsShippingAppliedNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.IsShippingAppliedColumn];
				}
			}
			set 
			{
				this[_parent.IsShippingAppliedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsShippingApplied is NULL, false otherwise.
		/// </summary>
		public bool IsIsShippingAppliedNull() 
		{
			return IsNull(_parent.IsShippingAppliedColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsShippingApplied to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsShippingAppliedNull() 
		{
			this[_parent.IsShippingAppliedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PartnerRelease<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."PartnerRelease"<br/>
		/// View field characteristics (type, precision, scale, length): SmallInt, 5, 0, 0
		/// </remarks>
		public System.Int16 PartnerRelease 
		{
			get 
			{
				if(IsPartnerReleaseNull())
				{
					// return default value for this type.
					return (System.Int16)TypeDefaultValue.GetDefaultValue(typeof(System.Int16));
				}
				else
				{
					return (System.Int16)this[_parent.PartnerReleaseColumn];
				}
			}
			set 
			{
				this[_parent.PartnerReleaseColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PartnerRelease is NULL, false otherwise.
		/// </summary>
		public bool IsPartnerReleaseNull() 
		{
			return IsNull(_parent.PartnerReleaseColumn);
		}

		/// <summary>
		/// Sets the TypedView field PartnerRelease to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPartnerReleaseNull() 
		{
			this[_parent.PartnerReleaseColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field InsurancePayment<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."InsurancePayment"<br/>
		/// View field characteristics (type, precision, scale, length): Decimal, 38, 2, 0
		/// </remarks>
		public System.Decimal InsurancePayment 
		{
			get 
			{
				if(IsInsurancePaymentNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.InsurancePaymentColumn];
				}
			}
			set 
			{
				this[_parent.InsurancePaymentColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field InsurancePayment is NULL, false otherwise.
		/// </summary>
		public bool IsInsurancePaymentNull() 
		{
			return IsNull(_parent.InsurancePaymentColumn);
		}

		/// <summary>
		/// Sets the TypedView field InsurancePayment to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetInsurancePaymentNull() 
		{
			this[_parent.InsurancePaymentColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field AwvVisitId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_CustomerOrderBasicInfo"."AwvVisitId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 AwvVisitId 
		{
			get 
			{
				if(IsAwvVisitIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.AwvVisitIdColumn];
				}
			}
			set 
			{
				this[_parent.AwvVisitIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field AwvVisitId is NULL, false otherwise.
		/// </summary>
		public bool IsAwvVisitIdNull() 
		{
			return IsNull(_parent.AwvVisitIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field AwvVisitId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetAwvVisitIdNull() 
		{
			this[_parent.AwvVisitIdColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
