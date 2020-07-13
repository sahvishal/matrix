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
	/// Typed datatable for the view 'MedicalVendorInvoiceItem'.<br/><br/>
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
	public partial class MedicalVendorInvoiceItemTypedView : TypedViewBase<MedicalVendorInvoiceItemRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnOrganizationRoleUserId;
		private DataColumn _columnCustomerId;
		private DataColumn _columnFirstName;
		private DataColumn _columnMiddleName;
		private DataColumn _columnLastName;
		private DataColumn _columnReviewDate;
		private DataColumn _columnEventId;
		private DataColumn _columnEventName;
		private DataColumn _columnEventDate;
		private DataColumn _columnPodId;
		private DataColumn _columnPodName;
		private DataColumn _columnMedicalVendorAmountEarned;
		private DataColumn _columnOrganizationRoleUserAmountEarned;
		private DataColumn _columnEvaluationStartTime;
		private DataColumn _columnEvaluationEndTime;
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
		static MedicalVendorInvoiceItemTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public MedicalVendorInvoiceItemTypedView():base("MedicalVendorInvoiceItem")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MedicalVendorInvoiceItemTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all MedicalVendorInvoiceItemRow objects.</summary>
		/// <returns>Array with MedicalVendorInvoiceItemRow objects</returns>
		public new MedicalVendorInvoiceItemRow[] Select()
		{
			return (MedicalVendorInvoiceItemRow[])base.Select();
		}


		/// <summary>Gets an array of all MedicalVendorInvoiceItemRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with MedicalVendorInvoiceItemRow objects</returns>
		public new MedicalVendorInvoiceItemRow[] Select(string filterExpression)
		{
			return (MedicalVendorInvoiceItemRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all MedicalVendorInvoiceItemRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with MedicalVendorInvoiceItemRow objects</returns>
		public new MedicalVendorInvoiceItemRow[] Select(string filterExpression, string sort)
		{
			return (MedicalVendorInvoiceItemRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all MedicalVendorInvoiceItemRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with MedicalVendorInvoiceItemRow objects</returns>
		public new MedicalVendorInvoiceItemRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (MedicalVendorInvoiceItemRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new MedicalVendorInvoiceItemRow(rowBuilder);
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

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("ReviewDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventDate", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PodId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PodName", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("MedicalVendorAmountEarned", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OrganizationRoleUserAmountEarned", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EvaluationStartTime", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EvaluationEndTime", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "MedicalVendorInvoiceItem";		
			_columnOrganizationRoleUserId = new DataColumn("OrganizationRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnOrganizationRoleUserId.ReadOnly = true;
			_columnOrganizationRoleUserId.Caption = @"OrganizationRoleUserId";
			this.Columns.Add(_columnOrganizationRoleUserId);
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
			_columnReviewDate = new DataColumn("ReviewDate", typeof(System.DateTime), null, MappingType.Element);
			_columnReviewDate.ReadOnly = true;
			_columnReviewDate.Caption = @"ReviewDate";
			this.Columns.Add(_columnReviewDate);
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
			_columnPodId = new DataColumn("PodId", typeof(System.Int64), null, MappingType.Element);
			_columnPodId.ReadOnly = true;
			_columnPodId.Caption = @"PodId";
			this.Columns.Add(_columnPodId);
			_columnPodName = new DataColumn("PodName", typeof(System.String), null, MappingType.Element);
			_columnPodName.ReadOnly = true;
			_columnPodName.Caption = @"PodName";
			this.Columns.Add(_columnPodName);
			_columnMedicalVendorAmountEarned = new DataColumn("MedicalVendorAmountEarned", typeof(System.Int32), null, MappingType.Element);
			_columnMedicalVendorAmountEarned.ReadOnly = true;
			_columnMedicalVendorAmountEarned.Caption = @"MedicalVendorAmountEarned";
			this.Columns.Add(_columnMedicalVendorAmountEarned);
			_columnOrganizationRoleUserAmountEarned = new DataColumn("OrganizationRoleUserAmountEarned", typeof(System.Decimal), null, MappingType.Element);
			_columnOrganizationRoleUserAmountEarned.ReadOnly = true;
			_columnOrganizationRoleUserAmountEarned.Caption = @"OrganizationRoleUserAmountEarned";
			this.Columns.Add(_columnOrganizationRoleUserAmountEarned);
			_columnEvaluationStartTime = new DataColumn("EvaluationStartTime", typeof(System.DateTime), null, MappingType.Element);
			_columnEvaluationStartTime.ReadOnly = true;
			_columnEvaluationStartTime.Caption = @"EvaluationStartTime";
			this.Columns.Add(_columnEvaluationStartTime);
			_columnEvaluationEndTime = new DataColumn("EvaluationEndTime", typeof(System.DateTime), null, MappingType.Element);
			_columnEvaluationEndTime.ReadOnly = true;
			_columnEvaluationEndTime.Caption = @"EvaluationEndTime";
			this.Columns.Add(_columnEvaluationEndTime);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.MedicalVendorInvoiceItemTypedView);
			
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
			_columnCustomerId = this.Columns["CustomerId"];
			_columnFirstName = this.Columns["FirstName"];
			_columnMiddleName = this.Columns["MiddleName"];
			_columnLastName = this.Columns["LastName"];
			_columnReviewDate = this.Columns["ReviewDate"];
			_columnEventId = this.Columns["EventId"];
			_columnEventName = this.Columns["EventName"];
			_columnEventDate = this.Columns["EventDate"];
			_columnPodId = this.Columns["PodId"];
			_columnPodName = this.Columns["PodName"];
			_columnMedicalVendorAmountEarned = this.Columns["MedicalVendorAmountEarned"];
			_columnOrganizationRoleUserAmountEarned = this.Columns["OrganizationRoleUserAmountEarned"];
			_columnEvaluationStartTime = this.Columns["EvaluationStartTime"];
			_columnEvaluationEndTime = this.Columns["EvaluationEndTime"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.MedicalVendorInvoiceItemTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(MedicalVendorInvoiceItemRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			MedicalVendorInvoiceItemTypedView cloneToReturn = ((MedicalVendorInvoiceItemTypedView)(base.Clone()));
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
			return new MedicalVendorInvoiceItemTypedView();
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
			get { return MedicalVendorInvoiceItemTypedView.CustomProperties;}
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
			get { return MedicalVendorInvoiceItemTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public MedicalVendorInvoiceItemRow this[int index] 
		{
			get 
			{
				return ((MedicalVendorInvoiceItemRow)(this.Rows[index]));
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
		/// Returns the column object belonging to the TypedView field ReviewDate
		/// </summary>
		internal DataColumn ReviewDateColumn 
		{
			get { return _columnReviewDate; }
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
		/// Returns the column object belonging to the TypedView field PodId
		/// </summary>
		internal DataColumn PodIdColumn 
		{
			get { return _columnPodId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field PodName
		/// </summary>
		internal DataColumn PodNameColumn 
		{
			get { return _columnPodName; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field MedicalVendorAmountEarned
		/// </summary>
		internal DataColumn MedicalVendorAmountEarnedColumn 
		{
			get { return _columnMedicalVendorAmountEarned; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OrganizationRoleUserAmountEarned
		/// </summary>
		internal DataColumn OrganizationRoleUserAmountEarnedColumn 
		{
			get { return _columnOrganizationRoleUserAmountEarned; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EvaluationStartTime
		/// </summary>
		internal DataColumn EvaluationStartTimeColumn 
		{
			get { return _columnEvaluationStartTime; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EvaluationEndTime
		/// </summary>
		internal DataColumn EvaluationEndTimeColumn 
		{
			get { return _columnEvaluationEndTime; }
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
	/// Typed datarow for the typed datatable MedicalVendorInvoiceItem
	/// </summary>
	public partial class MedicalVendorInvoiceItemRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private MedicalVendorInvoiceItemTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal MedicalVendorInvoiceItemRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((MedicalVendorInvoiceItemTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field OrganizationRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."OrganizationRoleUserId"<br/>
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
		/// Gets / sets the value of the TypedView field CustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."CustomerID"<br/>
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
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."FirstName"<br/>
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
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."MiddleName"<br/>
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
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."LastName"<br/>
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
		/// Gets / sets the value of the TypedView field ReviewDate<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."ReviewDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime ReviewDate 
		{
			get 
			{
				if(IsReviewDateNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.ReviewDateColumn];
				}
			}
			set 
			{
				this[_parent.ReviewDateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field ReviewDate is NULL, false otherwise.
		/// </summary>
		public bool IsReviewDateNull() 
		{
			return IsNull(_parent.ReviewDateColumn);
		}

		/// <summary>
		/// Sets the TypedView field ReviewDate to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetReviewDateNull() 
		{
			this[_parent.ReviewDateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."EventID"<br/>
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
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."EventName"<br/>
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
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."EventDate"<br/>
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
		/// Gets / sets the value of the TypedView field PodId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."PodID"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 PodId 
		{
			get 
			{
				if(IsPodIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.PodIdColumn];
				}
			}
			set 
			{
				this[_parent.PodIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PodId is NULL, false otherwise.
		/// </summary>
		public bool IsPodIdNull() 
		{
			return IsNull(_parent.PodIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field PodId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPodIdNull() 
		{
			this[_parent.PodIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field PodName<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."PodName"<br/>
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
		/// Gets / sets the value of the TypedView field MedicalVendorAmountEarned<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."MedicalVendorAmountEarned"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 MedicalVendorAmountEarned 
		{
			get 
			{
				if(IsMedicalVendorAmountEarnedNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.MedicalVendorAmountEarnedColumn];
				}
			}
			set 
			{
				this[_parent.MedicalVendorAmountEarnedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field MedicalVendorAmountEarned is NULL, false otherwise.
		/// </summary>
		public bool IsMedicalVendorAmountEarnedNull() 
		{
			return IsNull(_parent.MedicalVendorAmountEarnedColumn);
		}

		/// <summary>
		/// Sets the TypedView field MedicalVendorAmountEarned to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetMedicalVendorAmountEarnedNull() 
		{
			this[_parent.MedicalVendorAmountEarnedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OrganizationRoleUserAmountEarned<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."OrganizationRoleUserAmountEarned"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0
		/// </remarks>
		public System.Decimal OrganizationRoleUserAmountEarned 
		{
			get 
			{
				if(IsOrganizationRoleUserAmountEarnedNull())
				{
					// return default value for this type.
					return (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal));
				}
				else
				{
					return (System.Decimal)this[_parent.OrganizationRoleUserAmountEarnedColumn];
				}
			}
			set 
			{
				this[_parent.OrganizationRoleUserAmountEarnedColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OrganizationRoleUserAmountEarned is NULL, false otherwise.
		/// </summary>
		public bool IsOrganizationRoleUserAmountEarnedNull() 
		{
			return IsNull(_parent.OrganizationRoleUserAmountEarnedColumn);
		}

		/// <summary>
		/// Sets the TypedView field OrganizationRoleUserAmountEarned to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOrganizationRoleUserAmountEarnedNull() 
		{
			this[_parent.OrganizationRoleUserAmountEarnedColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EvaluationStartTime<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."EvaluationStartTime"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime EvaluationStartTime 
		{
			get 
			{
				if(IsEvaluationStartTimeNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.EvaluationStartTimeColumn];
				}
			}
			set 
			{
				this[_parent.EvaluationStartTimeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EvaluationStartTime is NULL, false otherwise.
		/// </summary>
		public bool IsEvaluationStartTimeNull() 
		{
			return IsNull(_parent.EvaluationStartTimeColumn);
		}

		/// <summary>
		/// Sets the TypedView field EvaluationStartTime to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEvaluationStartTimeNull() 
		{
			this[_parent.EvaluationStartTimeColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EvaluationEndTime<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_MedicalVendorInvoiceItem"."EvaluationEndTime"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime EvaluationEndTime 
		{
			get 
			{
				if(IsEvaluationEndTimeNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.EvaluationEndTimeColumn];
				}
			}
			set 
			{
				this[_parent.EvaluationEndTimeColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EvaluationEndTime is NULL, false otherwise.
		/// </summary>
		public bool IsEvaluationEndTimeNull() 
		{
			return IsNull(_parent.EvaluationEndTimeColumn);
		}

		/// <summary>
		/// Sets the TypedView field EvaluationEndTime to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEvaluationEndTimeNull() 
		{
			this[_parent.EvaluationEndTimeColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
