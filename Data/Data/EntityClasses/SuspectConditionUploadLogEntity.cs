///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:51
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
	/// Entity class which represents the entity 'SuspectConditionUploadLog'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SuspectConditionUploadLogEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private SuspectConditionUploadEntity _suspectConditionUpload;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name SuspectConditionUpload</summary>
			public static readonly string SuspectConditionUpload = "SuspectConditionUpload";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SuspectConditionUploadLogEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public SuspectConditionUploadLogEntity():base("SuspectConditionUploadLogEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SuspectConditionUploadLogEntity(IEntityFields2 fields):base("SuspectConditionUploadLogEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SuspectConditionUploadLogEntity</param>
		public SuspectConditionUploadLogEntity(IValidator validator):base("SuspectConditionUploadLogEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SuspectConditionUploadLog which data should be fetched into this SuspectConditionUploadLog object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SuspectConditionUploadLogEntity(System.Int64 id):base("SuspectConditionUploadLogEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SuspectConditionUploadLog which data should be fetched into this SuspectConditionUploadLog object</param>
		/// <param name="validator">The custom validator object for this SuspectConditionUploadLogEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SuspectConditionUploadLogEntity(System.Int64 id, IValidator validator):base("SuspectConditionUploadLogEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected SuspectConditionUploadLogEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_suspectConditionUpload = (SuspectConditionUploadEntity)info.GetValue("_suspectConditionUpload", typeof(SuspectConditionUploadEntity));
				if(_suspectConditionUpload!=null)
				{
					_suspectConditionUpload.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((SuspectConditionUploadLogFieldIndex)fieldIndex)
			{
				case SuspectConditionUploadLogFieldIndex.SuspectConditionUploadId:
					DesetupSyncSuspectConditionUpload(true, false);
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
				case "SuspectConditionUpload":
					this.SuspectConditionUpload = (SuspectConditionUploadEntity)entity;
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
			return SuspectConditionUploadLogEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "SuspectConditionUpload":
					toReturn.Add(SuspectConditionUploadLogEntity.Relations.SuspectConditionUploadEntityUsingSuspectConditionUploadId);
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
				case "SuspectConditionUpload":
					SetupSyncSuspectConditionUpload(relatedEntity);
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
				case "SuspectConditionUpload":
					DesetupSyncSuspectConditionUpload(false, true);
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
			if(_suspectConditionUpload!=null)
			{
				toReturn.Add(_suspectConditionUpload);
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


				info.AddValue("_suspectConditionUpload", (!this.MarkedForDeletion?_suspectConditionUpload:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(SuspectConditionUploadLogFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(SuspectConditionUploadLogFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new SuspectConditionUploadLogRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'SuspectConditionUpload' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSuspectConditionUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SuspectConditionUploadFields.Id, null, ComparisonOperator.Equal, this.SuspectConditionUploadId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.SuspectConditionUploadLogEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(SuspectConditionUploadLogEntityFactory));
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
			toReturn.Add("SuspectConditionUpload", _suspectConditionUpload);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_suspectConditionUpload!=null)
			{
				_suspectConditionUpload.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_suspectConditionUpload = null;

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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SuspectConditionUploadId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gmpi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SubscriberId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MemberName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dob", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Icdcode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Icddesc", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IcdcodeVersion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Hcc", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Hccdesc", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureAction", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureLocation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureReasonDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureReferenceDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SectionName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSuccessFull", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ErrorMessage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MemberId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _suspectConditionUpload</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSuspectConditionUpload(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _suspectConditionUpload, new PropertyChangedEventHandler( OnSuspectConditionUploadPropertyChanged ), "SuspectConditionUpload", SuspectConditionUploadLogEntity.Relations.SuspectConditionUploadEntityUsingSuspectConditionUploadId, true, signalRelatedEntity, "SuspectConditionUploadLog", resetFKFields, new int[] { (int)SuspectConditionUploadLogFieldIndex.SuspectConditionUploadId } );		
			_suspectConditionUpload = null;
		}

		/// <summary> setups the sync logic for member _suspectConditionUpload</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSuspectConditionUpload(IEntity2 relatedEntity)
		{
			if(_suspectConditionUpload!=relatedEntity)
			{
				DesetupSyncSuspectConditionUpload(true, true);
				_suspectConditionUpload = (SuspectConditionUploadEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _suspectConditionUpload, new PropertyChangedEventHandler( OnSuspectConditionUploadPropertyChanged ), "SuspectConditionUpload", SuspectConditionUploadLogEntity.Relations.SuspectConditionUploadEntityUsingSuspectConditionUploadId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSuspectConditionUploadPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this SuspectConditionUploadLogEntity</param>
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
		public  static SuspectConditionUploadLogRelations Relations
		{
			get	{ return new SuspectConditionUploadLogRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SuspectConditionUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSuspectConditionUpload
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SuspectConditionUploadEntityFactory))),
					(IEntityRelation)GetRelationsForField("SuspectConditionUpload")[0], (int)Falcon.Data.EntityType.SuspectConditionUploadLogEntity, (int)Falcon.Data.EntityType.SuspectConditionUploadEntity, 0, null, null, null, null, "SuspectConditionUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return SuspectConditionUploadLogEntity.CustomProperties;}
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
			get { return SuspectConditionUploadLogEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)SuspectConditionUploadLogFieldIndex.Id, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.Id, value); }
		}

		/// <summary> The SuspectConditionUploadId property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."SuspectConditionUploadId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SuspectConditionUploadId
		{
			get { return (System.Int64)GetValue((int)SuspectConditionUploadLogFieldIndex.SuspectConditionUploadId, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.SuspectConditionUploadId, value); }
		}

		/// <summary> The Gmpi property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."GMPI"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 25<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Gmpi
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.Gmpi, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.Gmpi, value); }
		}

		/// <summary> The SubscriberId property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."SubscriberID"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SubscriberId
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.SubscriberId, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.SubscriberId, value); }
		}

		/// <summary> The MemberName property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."MemberName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MemberName
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.MemberName, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.MemberName, value); }
		}

		/// <summary> The Dob property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."DOB"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 25<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Dob
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.Dob, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.Dob, value); }
		}

		/// <summary> The Icdcode property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."ICDCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Icdcode
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.Icdcode, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.Icdcode, value); }
		}

		/// <summary> The Icddesc property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."ICDDesc"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Icddesc
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.Icddesc, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.Icddesc, value); }
		}

		/// <summary> The IcdcodeVersion property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."ICDCodeVersion"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IcdcodeVersion
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.IcdcodeVersion, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.IcdcodeVersion, value); }
		}

		/// <summary> The Hcc property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."HCC"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Hcc
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.Hcc, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.Hcc, value); }
		}

		/// <summary> The Hccdesc property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."HCCDesc"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Hccdesc
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.Hccdesc, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.Hccdesc, value); }
		}

		/// <summary> The CaptureAction property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."CaptureAction"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CaptureAction
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.CaptureAction, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.CaptureAction, value); }
		}

		/// <summary> The CaptureLocation property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."CaptureLocation"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CaptureLocation
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.CaptureLocation, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.CaptureLocation, value); }
		}

		/// <summary> The CaptureReasonDescription property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."CaptureReasonDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CaptureReasonDescription
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.CaptureReasonDescription, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.CaptureReasonDescription, value); }
		}

		/// <summary> The CaptureReferenceDate property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."CaptureReferenceDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 25<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CaptureReferenceDate
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.CaptureReferenceDate, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.CaptureReferenceDate, value); }
		}

		/// <summary> The SectionName property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."SectionName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SectionName
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.SectionName, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.SectionName, value); }
		}

		/// <summary> The IsSuccessFull property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."IsSuccessFull"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSuccessFull
		{
			get { return (System.Boolean)GetValue((int)SuspectConditionUploadLogFieldIndex.IsSuccessFull, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.IsSuccessFull, value); }
		}

		/// <summary> The ErrorMessage property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."ErrorMessage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ErrorMessage
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.ErrorMessage, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.ErrorMessage, value); }
		}

		/// <summary> The MemberId property of the Entity SuspectConditionUploadLog<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblSuspectConditionUploadLog"."MemberId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MemberId
		{
			get { return (System.String)GetValue((int)SuspectConditionUploadLogFieldIndex.MemberId, true); }
			set	{ SetValue((int)SuspectConditionUploadLogFieldIndex.MemberId, value); }
		}



		/// <summary> Gets / sets related entity of type 'SuspectConditionUploadEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual SuspectConditionUploadEntity SuspectConditionUpload
		{
			get
			{
				return _suspectConditionUpload;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSuspectConditionUpload(value);
				}
				else
				{
					if(value==null)
					{
						if(_suspectConditionUpload != null)
						{
							_suspectConditionUpload.UnsetRelatedEntity(this, "SuspectConditionUploadLog");
						}
					}
					else
					{
						if(_suspectConditionUpload!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "SuspectConditionUploadLog");
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
			get { return (int)Falcon.Data.EntityType.SuspectConditionUploadLogEntity; }
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
