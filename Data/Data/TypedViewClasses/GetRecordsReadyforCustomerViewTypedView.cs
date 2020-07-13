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
	/// Typed datatable for the view 'GetRecordsReadyforCustomerView'.<br/><br/>
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
	public partial class GetRecordsReadyforCustomerViewTypedView : TypedViewBase<GetRecordsReadyforCustomerViewRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnEventCustomerId;
		private DataColumn _columnCustomerEventTestId;
		private DataColumn _columnCustomerId;
		private DataColumn _columnEventId;
		private DataColumn _columnAaatestEvaluation;
		private DataColumn _columnAsitestEvaluation;
		private DataColumn _columnCarotidTestEvaluation;
		private DataColumn _columnOsteoTestEvaluation;
		private DataColumn _columnPadtestEvaluation;
		private DataColumn _columnEkgtestEvaluation;
		private DataColumn _columnLipidTestEvaluation;
		private DataColumn _columnLiverTestEvaluation;
		private DataColumn _columnFraminghamTestEvaluation;
		private DataColumn _columnIsPdfgenerated;
		private DataColumn _columnIsResultPdfgenerated;
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
		static GetRecordsReadyforCustomerViewTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public GetRecordsReadyforCustomerViewTypedView():base("GetRecordsReadyforCustomerView")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected GetRecordsReadyforCustomerViewTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all GetRecordsReadyforCustomerViewRow objects.</summary>
		/// <returns>Array with GetRecordsReadyforCustomerViewRow objects</returns>
		public new GetRecordsReadyforCustomerViewRow[] Select()
		{
			return (GetRecordsReadyforCustomerViewRow[])base.Select();
		}


		/// <summary>Gets an array of all GetRecordsReadyforCustomerViewRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with GetRecordsReadyforCustomerViewRow objects</returns>
		public new GetRecordsReadyforCustomerViewRow[] Select(string filterExpression)
		{
			return (GetRecordsReadyforCustomerViewRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all GetRecordsReadyforCustomerViewRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with GetRecordsReadyforCustomerViewRow objects</returns>
		public new GetRecordsReadyforCustomerViewRow[] Select(string filterExpression, string sort)
		{
			return (GetRecordsReadyforCustomerViewRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all GetRecordsReadyforCustomerViewRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with GetRecordsReadyforCustomerViewRow objects</returns>
		public new GetRecordsReadyforCustomerViewRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (GetRecordsReadyforCustomerViewRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new GetRecordsReadyforCustomerViewRow(rowBuilder);
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

			_fieldsCustomProperties.Add("CustomerEventTestId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
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

			_fieldsCustomProperties.Add("IsPdfgenerated", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsResultPdfgenerated", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "GetRecordsReadyforCustomerView";		
			_columnEventCustomerId = new DataColumn("EventCustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnEventCustomerId.ReadOnly = true;
			_columnEventCustomerId.Caption = @"EventCustomerId";
			this.Columns.Add(_columnEventCustomerId);
			_columnCustomerEventTestId = new DataColumn("CustomerEventTestId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerEventTestId.ReadOnly = true;
			_columnCustomerEventTestId.Caption = @"CustomerEventTestId";
			this.Columns.Add(_columnCustomerEventTestId);
			_columnCustomerId = new DataColumn("CustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerId.ReadOnly = true;
			_columnCustomerId.Caption = @"CustomerId";
			this.Columns.Add(_columnCustomerId);
			_columnEventId = new DataColumn("EventId", typeof(System.Int64), null, MappingType.Element);
			_columnEventId.ReadOnly = true;
			_columnEventId.Caption = @"EventId";
			this.Columns.Add(_columnEventId);
			_columnAaatestEvaluation = new DataColumn("AaatestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnAaatestEvaluation.ReadOnly = true;
			_columnAaatestEvaluation.Caption = @"AaatestEvaluation";
			this.Columns.Add(_columnAaatestEvaluation);
			_columnAsitestEvaluation = new DataColumn("AsitestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnAsitestEvaluation.ReadOnly = true;
			_columnAsitestEvaluation.Caption = @"AsitestEvaluation";
			this.Columns.Add(_columnAsitestEvaluation);
			_columnCarotidTestEvaluation = new DataColumn("CarotidTestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnCarotidTestEvaluation.ReadOnly = true;
			_columnCarotidTestEvaluation.Caption = @"CarotidTestEvaluation";
			this.Columns.Add(_columnCarotidTestEvaluation);
			_columnOsteoTestEvaluation = new DataColumn("OsteoTestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnOsteoTestEvaluation.ReadOnly = true;
			_columnOsteoTestEvaluation.Caption = @"OsteoTestEvaluation";
			this.Columns.Add(_columnOsteoTestEvaluation);
			_columnPadtestEvaluation = new DataColumn("PadtestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnPadtestEvaluation.ReadOnly = true;
			_columnPadtestEvaluation.Caption = @"PadtestEvaluation";
			this.Columns.Add(_columnPadtestEvaluation);
			_columnEkgtestEvaluation = new DataColumn("EkgtestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnEkgtestEvaluation.ReadOnly = true;
			_columnEkgtestEvaluation.Caption = @"EkgtestEvaluation";
			this.Columns.Add(_columnEkgtestEvaluation);
			_columnLipidTestEvaluation = new DataColumn("LipidTestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnLipidTestEvaluation.ReadOnly = true;
			_columnLipidTestEvaluation.Caption = @"LipidTestEvaluation";
			this.Columns.Add(_columnLipidTestEvaluation);
			_columnLiverTestEvaluation = new DataColumn("LiverTestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnLiverTestEvaluation.ReadOnly = true;
			_columnLiverTestEvaluation.Caption = @"LiverTestEvaluation";
			this.Columns.Add(_columnLiverTestEvaluation);
			_columnFraminghamTestEvaluation = new DataColumn("FraminghamTestEvaluation", typeof(System.Byte), null, MappingType.Element);
			_columnFraminghamTestEvaluation.ReadOnly = true;
			_columnFraminghamTestEvaluation.Caption = @"FraminghamTestEvaluation";
			this.Columns.Add(_columnFraminghamTestEvaluation);
			_columnIsPdfgenerated = new DataColumn("IsPdfgenerated", typeof(System.Boolean), null, MappingType.Element);
			_columnIsPdfgenerated.ReadOnly = true;
			_columnIsPdfgenerated.Caption = @"IsPdfgenerated";
			this.Columns.Add(_columnIsPdfgenerated);
			_columnIsResultPdfgenerated = new DataColumn("IsResultPdfgenerated", typeof(System.Boolean), null, MappingType.Element);
			_columnIsResultPdfgenerated.ReadOnly = true;
			_columnIsResultPdfgenerated.Caption = @"IsResultPdfgenerated";
			this.Columns.Add(_columnIsResultPdfgenerated);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.GetRecordsReadyforCustomerViewTypedView);
			
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
			_columnCustomerEventTestId = this.Columns["CustomerEventTestId"];
			_columnCustomerId = this.Columns["CustomerId"];
			_columnEventId = this.Columns["EventId"];
			_columnAaatestEvaluation = this.Columns["AaatestEvaluation"];
			_columnAsitestEvaluation = this.Columns["AsitestEvaluation"];
			_columnCarotidTestEvaluation = this.Columns["CarotidTestEvaluation"];
			_columnOsteoTestEvaluation = this.Columns["OsteoTestEvaluation"];
			_columnPadtestEvaluation = this.Columns["PadtestEvaluation"];
			_columnEkgtestEvaluation = this.Columns["EkgtestEvaluation"];
			_columnLipidTestEvaluation = this.Columns["LipidTestEvaluation"];
			_columnLiverTestEvaluation = this.Columns["LiverTestEvaluation"];
			_columnFraminghamTestEvaluation = this.Columns["FraminghamTestEvaluation"];
			_columnIsPdfgenerated = this.Columns["IsPdfgenerated"];
			_columnIsResultPdfgenerated = this.Columns["IsResultPdfgenerated"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.GetRecordsReadyforCustomerViewTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(GetRecordsReadyforCustomerViewRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			GetRecordsReadyforCustomerViewTypedView cloneToReturn = ((GetRecordsReadyforCustomerViewTypedView)(base.Clone()));
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
			return new GetRecordsReadyforCustomerViewTypedView();
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
			get { return GetRecordsReadyforCustomerViewTypedView.CustomProperties;}
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
			get { return GetRecordsReadyforCustomerViewTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public GetRecordsReadyforCustomerViewRow this[int index] 
		{
			get 
			{
				return ((GetRecordsReadyforCustomerViewRow)(this.Rows[index]));
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
		/// Returns the column object belonging to the TypedView field CustomerEventTestId
		/// </summary>
		internal DataColumn CustomerEventTestIdColumn 
		{
			get { return _columnCustomerEventTestId; }
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
		/// Returns the column object belonging to the TypedView field IsPdfgenerated
		/// </summary>
		internal DataColumn IsPdfgeneratedColumn 
		{
			get { return _columnIsPdfgenerated; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsResultPdfgenerated
		/// </summary>
		internal DataColumn IsResultPdfgeneratedColumn 
		{
			get { return _columnIsResultPdfgenerated; }
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
	/// Typed datarow for the typed datatable GetRecordsReadyforCustomerView
	/// </summary>
	public partial class GetRecordsReadyforCustomerViewRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private GetRecordsReadyforCustomerViewTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal GetRecordsReadyforCustomerViewRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((GetRecordsReadyforCustomerViewTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field EventCustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."EventCustomerID"<br/>
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
		/// Gets / sets the value of the TypedView field CustomerEventTestId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."CustomerEventTestID"<br/>
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
		/// Gets / sets the value of the TypedView field CustomerId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."CustomerID"<br/>
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."EventID"<br/>
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
		/// Gets / sets the value of the TypedView field AaatestEvaluation<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."AAATestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte AaatestEvaluation 
		{
			get 
			{
				if(IsAaatestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.AaatestEvaluationColumn];
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."ASITestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte AsitestEvaluation 
		{
			get 
			{
				if(IsAsitestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.AsitestEvaluationColumn];
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."CarotidTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte CarotidTestEvaluation 
		{
			get 
			{
				if(IsCarotidTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.CarotidTestEvaluationColumn];
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."OsteoTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte OsteoTestEvaluation 
		{
			get 
			{
				if(IsOsteoTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.OsteoTestEvaluationColumn];
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."PADTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte PadtestEvaluation 
		{
			get 
			{
				if(IsPadtestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.PadtestEvaluationColumn];
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."EKGTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte EkgtestEvaluation 
		{
			get 
			{
				if(IsEkgtestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.EkgtestEvaluationColumn];
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."LipidTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte LipidTestEvaluation 
		{
			get 
			{
				if(IsLipidTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.LipidTestEvaluationColumn];
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."LiverTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte LiverTestEvaluation 
		{
			get 
			{
				if(IsLiverTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.LiverTestEvaluationColumn];
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
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."FraminghamTestEvaluation"<br/>
		/// View field characteristics (type, precision, scale, length): TinyInt, 3, 0, 0
		/// </remarks>
		public System.Byte FraminghamTestEvaluation 
		{
			get 
			{
				if(IsFraminghamTestEvaluationNull())
				{
					// return default value for this type.
					return (System.Byte)TypeDefaultValue.GetDefaultValue(typeof(System.Byte));
				}
				else
				{
					return (System.Byte)this[_parent.FraminghamTestEvaluationColumn];
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
		/// Gets / sets the value of the TypedView field IsPdfgenerated<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."IsPDFGenerated"<br/>
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
		/// Gets / sets the value of the TypedView field IsResultPdfgenerated<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_GetRecordsReadyforCustomerView"."IsResultPDFGenerated"<br/>
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

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion		
	}
}
