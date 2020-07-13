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
	/// Entity class which represents the entity 'VwPhysicianQueueRecord'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class VwPhysicianQueueRecordEntity : CommonEntityBase, ISerializable
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
		static VwPhysicianQueueRecordEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public VwPhysicianQueueRecordEntity():base("VwPhysicianQueueRecordEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public VwPhysicianQueueRecordEntity(IEntityFields2 fields):base("VwPhysicianQueueRecordEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this VwPhysicianQueueRecordEntity</param>
		public VwPhysicianQueueRecordEntity(IValidator validator):base("VwPhysicianQueueRecordEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected VwPhysicianQueueRecordEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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
			switch((VwPhysicianQueueRecordFieldIndex)fieldIndex)
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
			return VwPhysicianQueueRecordEntity.GetRelationsForField(fieldName);
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
		public bool TestOriginalFieldValueForNull(VwPhysicianQueueRecordFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(VwPhysicianQueueRecordFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new VwPhysicianQueueRecordRelations().GetAllRelations();
		}
		




	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.VwPhysicianQueueRecordEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(VwPhysicianQueueRecordEntityFactory));
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

			_fieldsCustomProperties.Add("EventCustomerResultId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhysicianId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OverreadPhysicianId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsAtOverreadState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EvaluatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriticalMarkedByTechnician", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultSummary", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SentBackatPrimaryEval", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SentBackatOverread", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InQueuePriority", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriticalChatTest", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriticalChatDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriticalHiptest", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this VwPhysicianQueueRecordEntity</param>
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
		public  static VwPhysicianQueueRecordRelations Relations
		{
			get	{ return new VwPhysicianQueueRecordRelations(); }
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
			get { return VwPhysicianQueueRecordEntity.CustomProperties;}
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
			get { return VwPhysicianQueueRecordEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventCustomerResultId property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."EventCustomerResultId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerResultId
		{
			get { return (System.Int64)GetValue((int)VwPhysicianQueueRecordFieldIndex.EventCustomerResultId, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.EventCustomerResultId, value); }
		}

		/// <summary> The EventId property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."EventId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)VwPhysicianQueueRecordFieldIndex.EventId, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.EventId, value); }
		}

		/// <summary> The CustomerId property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."CustomerId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)VwPhysicianQueueRecordFieldIndex.CustomerId, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.CustomerId, value); }
		}

		/// <summary> The PhysicianId property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."PhysicianId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PhysicianId
		{
			get { return (System.Int64)GetValue((int)VwPhysicianQueueRecordFieldIndex.PhysicianId, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.PhysicianId, value); }
		}

		/// <summary> The OverreadPhysicianId property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."OverreadPhysicianId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OverreadPhysicianId
		{
			get { return (System.Int64)GetValue((int)VwPhysicianQueueRecordFieldIndex.OverreadPhysicianId, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.OverreadPhysicianId, value); }
		}

		/// <summary> The IsAtOverreadState property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."IsAtOverreadState"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsAtOverreadState
		{
			get { return (System.Boolean)GetValue((int)VwPhysicianQueueRecordFieldIndex.IsAtOverreadState, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.IsAtOverreadState, value); }
		}

		/// <summary> The EvaluatedByOrgRoleUserId property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."EvaluatedByOrgRoleUserId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EvaluatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)VwPhysicianQueueRecordFieldIndex.EvaluatedByOrgRoleUserId, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.EvaluatedByOrgRoleUserId, value); }
		}

		/// <summary> The CriticalMarkedByTechnician property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."CriticalMarkedByTechnician"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CriticalMarkedByTechnician
		{
			get { return (System.Boolean)GetValue((int)VwPhysicianQueueRecordFieldIndex.CriticalMarkedByTechnician, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.CriticalMarkedByTechnician, value); }
		}

		/// <summary> The ResultSummary property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."ResultSummary"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ResultSummary
		{
			get { return (System.Int64)GetValue((int)VwPhysicianQueueRecordFieldIndex.ResultSummary, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.ResultSummary, value); }
		}

		/// <summary> The SentBackatPrimaryEval property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."SentBackatPrimaryEval"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SentBackatPrimaryEval
		{
			get { return (System.Boolean)GetValue((int)VwPhysicianQueueRecordFieldIndex.SentBackatPrimaryEval, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.SentBackatPrimaryEval, value); }
		}

		/// <summary> The SentBackatOverread property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."SentBackatOverread"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SentBackatOverread
		{
			get { return (System.Boolean)GetValue((int)VwPhysicianQueueRecordFieldIndex.SentBackatOverread, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.SentBackatOverread, value); }
		}

		/// <summary> The InQueuePriority property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."InQueuePriority"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 InQueuePriority
		{
			get { return (System.Int64)GetValue((int)VwPhysicianQueueRecordFieldIndex.InQueuePriority, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.InQueuePriority, value); }
		}

		/// <summary> The UpdatedOn property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."UpdatedOn"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime UpdatedOn
		{
			get { return (System.DateTime)GetValue((int)VwPhysicianQueueRecordFieldIndex.UpdatedOn, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.UpdatedOn, value); }
		}

		/// <summary> The CriticalChatTest property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."CriticalChatTest"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CriticalChatTest
		{
			get { return (System.Int32)GetValue((int)VwPhysicianQueueRecordFieldIndex.CriticalChatTest, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.CriticalChatTest, value); }
		}

		/// <summary> The CriticalChatDate property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."CriticalChatDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CriticalChatDate
		{
			get { return (System.DateTime)GetValue((int)VwPhysicianQueueRecordFieldIndex.CriticalChatDate, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.CriticalChatDate, value); }
		}

		/// <summary> The CriticalHiptest property of the Entity VwPhysicianQueueRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "vw_PhysicianQueueRecord"."CriticalHIPTest"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CriticalHiptest
		{
			get { return (System.Int32)GetValue((int)VwPhysicianQueueRecordFieldIndex.CriticalHiptest, true); }
			set	{ SetValue((int)VwPhysicianQueueRecordFieldIndex.CriticalHiptest, value); }
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
			get { return (int)Falcon.Data.EntityType.VwPhysicianQueueRecordEntity; }
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
