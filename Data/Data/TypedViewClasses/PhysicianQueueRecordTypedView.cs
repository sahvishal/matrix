///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Tuesday, March 27, 2012 6:54:40 PM
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
	/// Typed datatable for the view 'PhysicianQueueRecord'.<br/><br/>
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
	public partial class PhysicianQueueRecordTypedView : TypedViewBase<PhysicianQueueRecordRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private DataColumn _columnEventCustomerResultId;
		private DataColumn _columnEventId;
		private DataColumn _columnCustomerId;
		private DataColumn _columnPhysicianId;
		private DataColumn _columnOverreadPhysicianId;
		private DataColumn _columnIsAtOverreadState;
		private DataColumn _columnEvaluatedByOrgRoleUserId;
		private DataColumn _columnUpdatedOn;
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
		static PhysicianQueueRecordTypedView()
		{
			SetupCustomPropertyHashtables();
		}
		

		/// <summary>
		/// CTor
		/// </summary>
		public PhysicianQueueRecordTypedView():base("PhysicianQueueRecord")
		{
			InitClass();
		}
		
		
#if !CF	
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected PhysicianQueueRecordTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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


		/// <summary>Gets an array of all PhysicianQueueRecordRow objects.</summary>
		/// <returns>Array with PhysicianQueueRecordRow objects</returns>
		public new PhysicianQueueRecordRow[] Select()
		{
			return (PhysicianQueueRecordRow[])base.Select();
		}


		/// <summary>Gets an array of all PhysicianQueueRecordRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with PhysicianQueueRecordRow objects</returns>
		public new PhysicianQueueRecordRow[] Select(string filterExpression)
		{
			return (PhysicianQueueRecordRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all PhysicianQueueRecordRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with PhysicianQueueRecordRow objects</returns>
		public new PhysicianQueueRecordRow[] Select(string filterExpression, string sort)
		{
			return (PhysicianQueueRecordRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all PhysicianQueueRecordRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with PhysicianQueueRecordRow objects</returns>
		public new PhysicianQueueRecordRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (PhysicianQueueRecordRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>
		/// Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.
		/// </summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new PhysicianQueueRecordRow(rowBuilder);
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

			_fieldsCustomProperties.Add("EventCustomerResultId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("PhysicianId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("OverreadPhysicianId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("IsAtOverreadState", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("EvaluatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Hashtable();

			_fieldsCustomProperties.Add("UpdatedOn", fieldHashtable);			
		}


		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "PhysicianQueueRecord";		
			_columnEventCustomerResultId = new DataColumn("EventCustomerResultId", typeof(System.Int64), null, MappingType.Element);
			_columnEventCustomerResultId.ReadOnly = true;
			_columnEventCustomerResultId.Caption = @"EventCustomerResultId";
			this.Columns.Add(_columnEventCustomerResultId);
			_columnEventId = new DataColumn("EventId", typeof(System.Int64), null, MappingType.Element);
			_columnEventId.ReadOnly = true;
			_columnEventId.Caption = @"EventId";
			this.Columns.Add(_columnEventId);
			_columnCustomerId = new DataColumn("CustomerId", typeof(System.Int64), null, MappingType.Element);
			_columnCustomerId.ReadOnly = true;
			_columnCustomerId.Caption = @"CustomerId";
			this.Columns.Add(_columnCustomerId);
			_columnPhysicianId = new DataColumn("PhysicianId", typeof(System.Int64), null, MappingType.Element);
			_columnPhysicianId.ReadOnly = true;
			_columnPhysicianId.Caption = @"PhysicianId";
			this.Columns.Add(_columnPhysicianId);
			_columnOverreadPhysicianId = new DataColumn("OverreadPhysicianId", typeof(System.Int64), null, MappingType.Element);
			_columnOverreadPhysicianId.ReadOnly = true;
			_columnOverreadPhysicianId.Caption = @"OverreadPhysicianId";
			this.Columns.Add(_columnOverreadPhysicianId);
			_columnIsAtOverreadState = new DataColumn("IsAtOverreadState", typeof(System.Int32), null, MappingType.Element);
			_columnIsAtOverreadState.ReadOnly = true;
			_columnIsAtOverreadState.Caption = @"IsAtOverreadState";
			this.Columns.Add(_columnIsAtOverreadState);
			_columnEvaluatedByOrgRoleUserId = new DataColumn("EvaluatedByOrgRoleUserId", typeof(System.Int64), null, MappingType.Element);
			_columnEvaluatedByOrgRoleUserId.ReadOnly = true;
			_columnEvaluatedByOrgRoleUserId.Caption = @"EvaluatedByOrgRoleUserId";
			this.Columns.Add(_columnEvaluatedByOrgRoleUserId);
			_columnUpdatedOn = new DataColumn("UpdatedOn", typeof(System.DateTime), null, MappingType.Element);
			_columnUpdatedOn.ReadOnly = true;
			_columnUpdatedOn.Caption = @"UpdatedOn";
			this.Columns.Add(_columnUpdatedOn);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.PhysicianQueueRecordTypedView);
			
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
			_columnEventCustomerResultId = this.Columns["EventCustomerResultId"];
			_columnEventId = this.Columns["EventId"];
			_columnCustomerId = this.Columns["CustomerId"];
			_columnPhysicianId = this.Columns["PhysicianId"];
			_columnOverreadPhysicianId = this.Columns["OverreadPhysicianId"];
			_columnIsAtOverreadState = this.Columns["IsAtOverreadState"];
			_columnEvaluatedByOrgRoleUserId = this.Columns["EvaluatedByOrgRoleUserId"];
			_columnUpdatedOn = this.Columns["UpdatedOn"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.PhysicianQueueRecordTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			
		}


		/// <summary>
		/// Return the type of the typed datarow
		/// </summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(PhysicianQueueRecordRow);
		}


		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			PhysicianQueueRecordTypedView cloneToReturn = ((PhysicianQueueRecordTypedView)(base.Clone()));
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
			return new PhysicianQueueRecordTypedView();
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
			get { return PhysicianQueueRecordTypedView.CustomProperties;}
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
			get { return PhysicianQueueRecordTypedView.FieldsCustomProperties;}
		}

		/// <summary>
		/// Indexer of this strong typed view
		/// </summary>
		public PhysicianQueueRecordRow this[int index] 
		{
			get 
			{
				return ((PhysicianQueueRecordRow)(this.Rows[index]));
			}
		}

	
		/// <summary>
		/// Returns the column object belonging to the TypedView field EventCustomerResultId
		/// </summary>
		internal DataColumn EventCustomerResultIdColumn 
		{
			get { return _columnEventCustomerResultId; }
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
		/// Returns the column object belonging to the TypedView field PhysicianId
		/// </summary>
		internal DataColumn PhysicianIdColumn 
		{
			get { return _columnPhysicianId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field OverreadPhysicianId
		/// </summary>
		internal DataColumn OverreadPhysicianIdColumn 
		{
			get { return _columnOverreadPhysicianId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field IsAtOverreadState
		/// </summary>
		internal DataColumn IsAtOverreadStateColumn 
		{
			get { return _columnIsAtOverreadState; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field EvaluatedByOrgRoleUserId
		/// </summary>
		internal DataColumn EvaluatedByOrgRoleUserIdColumn 
		{
			get { return _columnEvaluatedByOrgRoleUserId; }
		}
    
		/// <summary>
		/// Returns the column object belonging to the TypedView field UpdatedOn
		/// </summary>
		internal DataColumn UpdatedOnColumn 
		{
			get { return _columnUpdatedOn; }
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
	/// Typed datarow for the typed datatable PhysicianQueueRecord
	/// </summary>
	public partial class PhysicianQueueRecordRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private PhysicianQueueRecordTypedView	_parent;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal PhysicianQueueRecordRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((PhysicianQueueRecordTypedView)(this.Table));
		}


		#region Class Property Declarations
	
		/// <summary>
		/// Gets / sets the value of the TypedView field EventCustomerResultId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_PhysicianQueueRecord"."EventCustomerResultId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 EventCustomerResultId 
		{
			get 
			{
				if(IsEventCustomerResultIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.EventCustomerResultIdColumn];
				}
			}
			set 
			{
				this[_parent.EventCustomerResultIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EventCustomerResultId is NULL, false otherwise.
		/// </summary>
		public bool IsEventCustomerResultIdNull() 
		{
			return IsNull(_parent.EventCustomerResultIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field EventCustomerResultId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEventCustomerResultIdNull() 
		{
			this[_parent.EventCustomerResultIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EventId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_PhysicianQueueRecord"."EventId"<br/>
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
		/// Mapped on view field: "vw_PhysicianQueueRecord"."CustomerId"<br/>
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
		/// Gets / sets the value of the TypedView field PhysicianId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_PhysicianQueueRecord"."PhysicianId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 PhysicianId 
		{
			get 
			{
				if(IsPhysicianIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.PhysicianIdColumn];
				}
			}
			set 
			{
				this[_parent.PhysicianIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field PhysicianId is NULL, false otherwise.
		/// </summary>
		public bool IsPhysicianIdNull() 
		{
			return IsNull(_parent.PhysicianIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field PhysicianId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetPhysicianIdNull() 
		{
			this[_parent.PhysicianIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field OverreadPhysicianId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_PhysicianQueueRecord"."OverreadPhysicianId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 OverreadPhysicianId 
		{
			get 
			{
				if(IsOverreadPhysicianIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.OverreadPhysicianIdColumn];
				}
			}
			set 
			{
				this[_parent.OverreadPhysicianIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field OverreadPhysicianId is NULL, false otherwise.
		/// </summary>
		public bool IsOverreadPhysicianIdNull() 
		{
			return IsNull(_parent.OverreadPhysicianIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field OverreadPhysicianId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetOverreadPhysicianIdNull() 
		{
			this[_parent.OverreadPhysicianIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field IsAtOverreadState<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_PhysicianQueueRecord"."IsAtOverreadState"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0
		/// </remarks>
		public System.Int32 IsAtOverreadState 
		{
			get 
			{
				if(IsIsAtOverreadStateNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.IsAtOverreadStateColumn];
				}
			}
			set 
			{
				this[_parent.IsAtOverreadStateColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field IsAtOverreadState is NULL, false otherwise.
		/// </summary>
		public bool IsIsAtOverreadStateNull() 
		{
			return IsNull(_parent.IsAtOverreadStateColumn);
		}

		/// <summary>
		/// Sets the TypedView field IsAtOverreadState to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetIsAtOverreadStateNull() 
		{
			this[_parent.IsAtOverreadStateColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field EvaluatedByOrgRoleUserId<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_PhysicianQueueRecord"."EvaluatedByOrgRoleUserId"<br/>
		/// View field characteristics (type, precision, scale, length): BigInt, 19, 0, 0
		/// </remarks>
		public System.Int64 EvaluatedByOrgRoleUserId 
		{
			get 
			{
				if(IsEvaluatedByOrgRoleUserIdNull())
				{
					// return default value for this type.
					return (System.Int64)TypeDefaultValue.GetDefaultValue(typeof(System.Int64));
				}
				else
				{
					return (System.Int64)this[_parent.EvaluatedByOrgRoleUserIdColumn];
				}
			}
			set 
			{
				this[_parent.EvaluatedByOrgRoleUserIdColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field EvaluatedByOrgRoleUserId is NULL, false otherwise.
		/// </summary>
		public bool IsEvaluatedByOrgRoleUserIdNull() 
		{
			return IsNull(_parent.EvaluatedByOrgRoleUserIdColumn);
		}

		/// <summary>
		/// Sets the TypedView field EvaluatedByOrgRoleUserId to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetEvaluatedByOrgRoleUserIdNull() 
		{
			this[_parent.EvaluatedByOrgRoleUserIdColumn] = System.Convert.DBNull;
		}

	

		/// <summary>
		/// Gets / sets the value of the TypedView field UpdatedOn<br/><br/>
		/// 
		/// </summary>
		/// <remarks>
		/// Mapped on view field: "vw_PhysicianQueueRecord"."UpdatedOn"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0
		/// </remarks>
		public System.DateTime UpdatedOn 
		{
			get 
			{
				if(IsUpdatedOnNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.UpdatedOnColumn];
				}
			}
			set 
			{
				this[_parent.UpdatedOnColumn] = value;
			}
		}

		/// <summary>
		/// Returns true if the TypedView field UpdatedOn is NULL, false otherwise.
		/// </summary>
		public bool IsUpdatedOnNull() 
		{
			return IsNull(_parent.UpdatedOnColumn);
		}

		/// <summary>
		/// Sets the TypedView field UpdatedOn to NULL. Not recommended; a typed list should be used
		/// as a readonly object.
		/// </summary>
    	public void SetUpdatedOnNull() 
		{
			this[_parent.UpdatedOnColumn] = System.Convert.DBNull;
		}

	
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion		
	}
}
