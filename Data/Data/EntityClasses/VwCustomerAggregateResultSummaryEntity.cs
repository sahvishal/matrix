///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using Falcon.Data;
using Falcon.Data.HelperClasses;
using Falcon.Data.FactoryClasses;
using Falcon.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'VwCustomerAggregateResultSummary'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class VwCustomerAggregateResultSummaryEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations




		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{




		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static VwCustomerAggregateResultSummaryEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public VwCustomerAggregateResultSummaryEntity():base("VwCustomerAggregateResultSummaryEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public VwCustomerAggregateResultSummaryEntity(IEntityFields2 fields):base("VwCustomerAggregateResultSummaryEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this VwCustomerAggregateResultSummaryEntity</param>
		public VwCustomerAggregateResultSummaryEntity(IValidator validator):base("VwCustomerAggregateResultSummaryEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected VwCustomerAggregateResultSummaryEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{




				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((VwCustomerAggregateResultSummaryFieldIndex)fieldIndex)
			{
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
				
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{




				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return VwCustomerAggregateResultSummaryEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{




				default:

					break;				
			}
			return toReturn;
		}
#if !CF
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));


				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{



				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{



				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();


			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{




			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(VwCustomerAggregateResultSummaryFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(VwCustomerAggregateResultSummaryFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new VwCustomerAggregateResultSummaryRelations().GetAllRelations();
		}
		




	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.VwCustomerAggregateResultSummaryEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(VwCustomerAggregateResultSummaryEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{


			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();




			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{




		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{





			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoShow", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HiPaastatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PartnerRelease", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultSummary", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultStatusUpdatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultSummaryOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dob", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHome", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CorporateAccountId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HospitalPartnerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HospitalPartnerStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HospitalPartnerStatusOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HospitalPartnerLastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShippingStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShipmentDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InitialCallDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HospitalFacilityId", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this VwCustomerAggregateResultSummaryEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static VwCustomerAggregateResultSummaryRelations Relations
		{
			get	{ return new VwCustomerAggregateResultSummaryRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}





		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return VwCustomerAggregateResultSummaryEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return VwCustomerAggregateResultSummaryEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventCustomerId property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."EventCustomerId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerId
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.EventCustomerId, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The NoShow property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."NoShow"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean NoShow
		{
			get { return (System.Boolean)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.NoShow, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.NoShow, value); }
		}

		/// <summary> The HiPaastatus property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."HiPAAStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 HiPaastatus
		{
			get { return (System.Int16)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HiPaastatus, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HiPaastatus, value); }
		}

		/// <summary> The PartnerRelease property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."PartnerRelease"<br/>
		/// View field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 PartnerRelease
		{
			get { return (System.Int16)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.PartnerRelease, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.PartnerRelease, value); }
		}

		/// <summary> The CustomerId property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."CustomerId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.CustomerId, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.CustomerId, value); }
		}

		/// <summary> The AppointmentId property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."AppointmentId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AppointmentId
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.AppointmentId, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.AppointmentId, value); }
		}

		/// <summary> The ResultState property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."ResultState"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ResultState
		{
			get { return (System.Int32)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ResultState, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ResultState, value); }
		}

		/// <summary> The ResultSummary property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."ResultSummary"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ResultSummary
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ResultSummary, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ResultSummary, value); }
		}

		/// <summary> The ResultStatusUpdatedDate property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."ResultStatusUpdatedDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ResultStatusUpdatedDate
		{
			get { return (System.DateTime)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ResultStatusUpdatedDate, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ResultStatusUpdatedDate, value); }
		}

		/// <summary> The ResultSummaryOrder property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."ResultSummaryOrder"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ResultSummaryOrder
		{
			get { return (System.Int32)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ResultSummaryOrder, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ResultSummaryOrder, value); }
		}

		/// <summary> The EventId property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."EventId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.EventId, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.EventId, value); }
		}

		/// <summary> The EventDate property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."EventDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime EventDate
		{
			get { return (System.DateTime)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.EventDate, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.EventDate, value); }
		}

		/// <summary> The EventTypeId property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."EventTypeId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventTypeId
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.EventTypeId, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.EventTypeId, value); }
		}

		/// <summary> The FirstName property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."FirstName"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.FirstName, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."MiddleName"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.MiddleName, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."LastName"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.LastName, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.LastName, value); }
		}

		/// <summary> The Dob property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."DOB"<br/>
		/// View field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime Dob
		{
			get { return (System.DateTime)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.Dob, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.Dob, value); }
		}

		/// <summary> The PhoneHome property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."PhoneHome"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.PhoneHome, value); }
		}

		/// <summary> The PhoneCell property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."PhoneCell"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneOffice property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."PhoneOffice"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The CorporateAccountId property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."CorporateAccountId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CorporateAccountId
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.CorporateAccountId, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.CorporateAccountId, value); }
		}

		/// <summary> The HospitalPartnerId property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."HospitalPartnerId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HospitalPartnerId
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalPartnerId, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalPartnerId, value); }
		}

		/// <summary> The HospitalPartnerStatus property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."HospitalPartnerStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HospitalPartnerStatus
		{
			get { return (System.Int32)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalPartnerStatus, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalPartnerStatus, value); }
		}

		/// <summary> The HospitalPartnerStatusOrder property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."HospitalPartnerStatusOrder"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 HospitalPartnerStatusOrder
		{
			get { return (System.Int32)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalPartnerStatusOrder, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalPartnerStatusOrder, value); }
		}

		/// <summary> The HospitalPartnerLastModifiedDate property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."HospitalPartnerLastModifiedDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime HospitalPartnerLastModifiedDate
		{
			get { return (System.DateTime)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalPartnerLastModifiedDate, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalPartnerLastModifiedDate, value); }
		}

		/// <summary> The ShippingStatus property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."ShippingStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ShippingStatus
		{
			get { return (System.Int32)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ShippingStatus, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ShippingStatus, value); }
		}

		/// <summary> The ShipmentDate property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."ShipmentDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ShipmentDate
		{
			get { return (System.DateTime)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ShipmentDate, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.ShipmentDate, value); }
		}

		/// <summary> The InitialCallDate property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."InitialCallDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime InitialCallDate
		{
			get { return (System.DateTime)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.InitialCallDate, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.InitialCallDate, value); }
		}

		/// <summary> The HospitalFacilityId property of the Entity VwCustomerAggregateResultSummary<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_CustomerAggregateResultSummary"."HospitalFacilityId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HospitalFacilityId
		{
			get { return (System.Int64)GetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalFacilityId, true); }
			set	{ SetValue((int)VwCustomerAggregateResultSummaryFieldIndex.HospitalFacilityId, value); }
		}




	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the Falcon.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)Falcon.Data.EntityType.VwCustomerAggregateResultSummaryEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
