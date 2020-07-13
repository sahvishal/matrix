///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Thursday, July 21, 2011 6:44:34 PM
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
	/// Entity class which represents the entity 'MVInvoiceItem'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MVInvoiceItemEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private MVInvoiceEntity _mvinvoice;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Mvinvoice</summary>
			public static readonly string Mvinvoice = "Mvinvoice";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MVInvoiceItemEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MVInvoiceItemEntity():base("MVInvoiceItemEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MVInvoiceItemEntity(IEntityFields2 fields):base("MVInvoiceItemEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MVInvoiceItemEntity</param>
		public MVInvoiceItemEntity(IValidator validator):base("MVInvoiceItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="mvinvoiceItemId">PK value for MVInvoiceItem which data should be fetched into this MVInvoiceItem object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MVInvoiceItemEntity(System.Int64 mvinvoiceItemId):base("MVInvoiceItemEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MvinvoiceItemId = mvinvoiceItemId;
		}

		/// <summary> CTor</summary>
		/// <param name="mvinvoiceItemId">PK value for MVInvoiceItem which data should be fetched into this MVInvoiceItem object</param>
		/// <param name="validator">The custom validator object for this MVInvoiceItemEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MVInvoiceItemEntity(System.Int64 mvinvoiceItemId, IValidator validator):base("MVInvoiceItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MvinvoiceItemId = mvinvoiceItemId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MVInvoiceItemEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_mvinvoice = (MVInvoiceEntity)info.GetValue("_mvinvoice", typeof(MVInvoiceEntity));
				if(_mvinvoice!=null)
				{
					_mvinvoice.AfterSave+=new EventHandler(OnEntityAfterSave);
				}

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((MVInvoiceItemFieldIndex)fieldIndex)
			{
				case MVInvoiceItemFieldIndex.MvinvoiceId:
					DesetupSyncMvinvoice(true, false);
					break;
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
				case "Mvinvoice":
					this.Mvinvoice = (MVInvoiceEntity)entity;
					break;



				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return MVInvoiceItemEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Mvinvoice":
					toReturn.Add(MVInvoiceItemEntity.Relations.MVInvoiceEntityUsingMvinvoiceId);
					break;



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
				case "Mvinvoice":
					SetupSyncMvinvoice(relatedEntity);
					break;


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
				case "Mvinvoice":
					DesetupSyncMvinvoice(false, true);
					break;


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
			if(_mvinvoice!=null)
			{
				toReturn.Add(_mvinvoice);
			}

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


				info.AddValue("_mvinvoice", (!this.MarkedForDeletion?_mvinvoice:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MVInvoiceItemFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MVInvoiceItemFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MVInvoiceItemRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MVInvoice' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvinvoice()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MVInvoiceFields.MvinvoiceId, null, ComparisonOperator.Equal, this.MvinvoiceId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MVInvoiceItemEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MVInvoiceItemEntityFactory));
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
			toReturn.Add("Mvinvoice", _mvinvoice);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_mvinvoice!=null)
			{
				_mvinvoice.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_mvinvoice = null;

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

			_fieldsCustomProperties.Add("MvinvoiceItemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MvinvoiceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReviewDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PodName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PackageName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorAmountEarned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserAmountEarned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluationStartTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluationEndTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PodId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _mvinvoice</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMvinvoice(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mvinvoice, new PropertyChangedEventHandler( OnMvinvoicePropertyChanged ), "Mvinvoice", MVInvoiceItemEntity.Relations.MVInvoiceEntityUsingMvinvoiceId, true, signalRelatedEntity, "MvinvoiceItem", resetFKFields, new int[] { (int)MVInvoiceItemFieldIndex.MvinvoiceId } );		
			_mvinvoice = null;
		}

		/// <summary> setups the sync logic for member _mvinvoice</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMvinvoice(IEntity2 relatedEntity)
		{
			if(_mvinvoice!=relatedEntity)
			{
				DesetupSyncMvinvoice(true, true);
				_mvinvoice = (MVInvoiceEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _mvinvoice, new PropertyChangedEventHandler( OnMvinvoicePropertyChanged ), "Mvinvoice", MVInvoiceItemEntity.Relations.MVInvoiceEntityUsingMvinvoiceId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMvinvoicePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MVInvoiceItemEntity</param>
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
		public  static MVInvoiceItemRelations Relations
		{
			get	{ return new MVInvoiceItemRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MVInvoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvinvoice
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MVInvoiceEntityFactory))),
					(IEntityRelation)GetRelationsForField("Mvinvoice")[0], (int)Falcon.Data.EntityType.MVInvoiceItemEntity, (int)Falcon.Data.EntityType.MVInvoiceEntity, 0, null, null, null, null, "Mvinvoice", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MVInvoiceItemEntity.CustomProperties;}
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
			get { return MVInvoiceItemEntity.FieldsCustomProperties;}
		}

		/// <summary> The MvinvoiceItemId property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."MVInvoiceItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MvinvoiceItemId
		{
			get { return (System.Int64)GetValue((int)MVInvoiceItemFieldIndex.MvinvoiceItemId, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.MvinvoiceItemId, value); }
		}

		/// <summary> The MvinvoiceId property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."MVInvoiceID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MvinvoiceId
		{
			get { return (System.Int64)GetValue((int)MVInvoiceItemFieldIndex.MvinvoiceId, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.MvinvoiceId, value); }
		}

		/// <summary> The EventId property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)MVInvoiceItemFieldIndex.EventId, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.EventId, value); }
		}

		/// <summary> The CustomerId property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)MVInvoiceItemFieldIndex.CustomerId, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.CustomerId, value); }
		}

		/// <summary> The ReviewDate property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."ReviewDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ReviewDate
		{
			get { return (System.DateTime)GetValue((int)MVInvoiceItemFieldIndex.ReviewDate, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.ReviewDate, value); }
		}

		/// <summary> The EventDate property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."EventDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime EventDate
		{
			get { return (System.DateTime)GetValue((int)MVInvoiceItemFieldIndex.EventDate, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.EventDate, value); }
		}

		/// <summary> The PodName property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."PodName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PodName
		{
			get { return (System.String)GetValue((int)MVInvoiceItemFieldIndex.PodName, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.PodName, value); }
		}

		/// <summary> The EventName property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."EventName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EventName
		{
			get { return (System.String)GetValue((int)MVInvoiceItemFieldIndex.EventName, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.EventName, value); }
		}

		/// <summary> The CustomerName property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."CustomerName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CustomerName
		{
			get { return (System.String)GetValue((int)MVInvoiceItemFieldIndex.CustomerName, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.CustomerName, value); }
		}

		/// <summary> The PackageName property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."PackageName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PackageName
		{
			get { return (System.String)GetValue((int)MVInvoiceItemFieldIndex.PackageName, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.PackageName, value); }
		}

		/// <summary> The MedicalVendorAmountEarned property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."MedicalVendorAmountEarned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal MedicalVendorAmountEarned
		{
			get { return (System.Decimal)GetValue((int)MVInvoiceItemFieldIndex.MedicalVendorAmountEarned, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.MedicalVendorAmountEarned, value); }
		}

		/// <summary> The OrganizationRoleUserAmountEarned property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."OrganizationRoleUserAmountEarned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal OrganizationRoleUserAmountEarned
		{
			get { return (System.Decimal)GetValue((int)MVInvoiceItemFieldIndex.OrganizationRoleUserAmountEarned, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.OrganizationRoleUserAmountEarned, value); }
		}

		/// <summary> The EvaluationStartTime property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."EvaluationStartTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EvaluationStartTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MVInvoiceItemFieldIndex.EvaluationStartTime, false); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.EvaluationStartTime, value); }
		}

		/// <summary> The EvaluationEndTime property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."EvaluationEndTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EvaluationEndTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MVInvoiceItemFieldIndex.EvaluationEndTime, false); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.EvaluationEndTime, value); }
		}

		/// <summary> The PodId property of the Entity MVInvoiceItem<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoiceItem"."PodId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PodId
		{
			get { return (System.Int64)GetValue((int)MVInvoiceItemFieldIndex.PodId, true); }
			set	{ SetValue((int)MVInvoiceItemFieldIndex.PodId, value); }
		}



		/// <summary> Gets / sets related entity of type 'MVInvoiceEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MVInvoiceEntity Mvinvoice
		{
			get
			{
				return _mvinvoice;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMvinvoice(value);
				}
				else
				{
					if(value==null)
					{
						if(_mvinvoice != null)
						{
							_mvinvoice.UnsetRelatedEntity(this, "MvinvoiceItem");
						}
					}
					else
					{
						if(_mvinvoice!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MvinvoiceItem");
						}
					}
				}
			}
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
			get { return (int)Falcon.Data.EntityType.MVInvoiceItemEntity; }
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
