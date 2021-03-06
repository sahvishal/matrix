﻿///////////////////////////////////////////////////////////////
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
	/// Entity class which represents the entity 'VwCallQueueCustomerCriteraAssignmentForStats'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class VwCallQueueCustomerCriteraAssignmentForStatsEntity : CommonEntityBase, ISerializable
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
		static VwCallQueueCustomerCriteraAssignmentForStatsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public VwCallQueueCustomerCriteraAssignmentForStatsEntity():base("VwCallQueueCustomerCriteraAssignmentForStatsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public VwCallQueueCustomerCriteraAssignmentForStatsEntity(IEntityFields2 fields):base("VwCallQueueCustomerCriteraAssignmentForStatsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this VwCallQueueCustomerCriteraAssignmentForStatsEntity</param>
		public VwCallQueueCustomerCriteraAssignmentForStatsEntity(IValidator validator):base("VwCallQueueCustomerCriteraAssignmentForStatsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected VwCallQueueCustomerCriteraAssignmentForStatsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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
			switch((VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex)fieldIndex)
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
			return VwCallQueueCustomerCriteraAssignmentForStatsEntity.GetRelationsForField(fieldName);
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
		public bool TestOriginalFieldValueForNull(VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new VwCallQueueCustomerCriteraAssignmentForStatsRelations().GetAllRelations();
		}
		




	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.VwCallQueueCustomerCriteraAssignmentForStatsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(VwCallQueueCustomerCriteraAssignmentForStatsEntityFactory));
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

			_fieldsCustomProperties.Add("CallQueueCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriteriaId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallQueueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Attempts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HealthPlanId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventIds", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsLanguageBarrier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Disposition", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentCancellationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsEligble", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActivityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHome", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsIncorrectPhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallBackRequestedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactUpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactUpdateSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageBarrierMarkedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncorrectPhoneNumberMarkedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoShowDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TargetedYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTargeted", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this VwCallQueueCustomerCriteraAssignmentForStatsEntity</param>
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
		public  static VwCallQueueCustomerCriteraAssignmentForStatsRelations Relations
		{
			get	{ return new VwCallQueueCustomerCriteraAssignmentForStatsRelations(); }
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
			get { return VwCallQueueCustomerCriteraAssignmentForStatsEntity.CustomProperties;}
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
			get { return VwCallQueueCustomerCriteraAssignmentForStatsEntity.FieldsCustomProperties;}
		}

		/// <summary> The CallQueueCustomerId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CallQueueCustomerId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallQueueCustomerId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallQueueCustomerId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallQueueCustomerId, value); }
		}

		/// <summary> The CriteriaId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CriteriaId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CriteriaId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CriteriaId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CriteriaId, value); }
		}

		/// <summary> The CallQueueId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CallQueueId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallQueueId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallQueueId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallQueueId, value); }
		}

		/// <summary> The CustomerId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CustomerId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CustomerId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CustomerId, value); }
		}

		/// <summary> The Status property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."Status"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Status
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.Status, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.Status, value); }
		}

		/// <summary> The Attempts property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."Attempts"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Attempts
		{
			get { return (System.Int32)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.Attempts, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.Attempts, value); }
		}

		/// <summary> The IsActive property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."IsActive"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsActive, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."DateCreated"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DateCreated, value); }
		}

		/// <summary> The CallDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CallDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CallDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallDate, value); }
		}

		/// <summary> The CallCount property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CallCount"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallCount
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallCount, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallCount, value); }
		}

		/// <summary> The ZipId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."ZipId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ZipId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.ZipId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.ZipId, value); }
		}

		/// <summary> The DateModified property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."DateModified"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DateModified, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DateModified, value); }
		}

		/// <summary> The HealthPlanId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."HealthPlanId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HealthPlanId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.HealthPlanId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.HealthPlanId, value); }
		}

		/// <summary> The CampaignId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CampaignId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CampaignId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CampaignId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CampaignId, value); }
		}

		/// <summary> The EventIds property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."EventIds"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EventIds
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.EventIds, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.EventIds, value); }
		}

		/// <summary> The FirstName property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."FirstName"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.FirstName, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."MiddleName"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.MiddleName, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."LastName"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.LastName, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.LastName, value); }
		}

		/// <summary> The ZipCode property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."ZipCode"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ZipCode
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.ZipCode, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.ZipCode, value); }
		}

		/// <summary> The IsLanguageBarrier property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."IsLanguageBarrier"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsLanguageBarrier
		{
			get { return (System.Boolean)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsLanguageBarrier, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsLanguageBarrier, value); }
		}

		/// <summary> The CallStatus property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CallStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallStatus
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallStatus, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallStatus, value); }
		}

		/// <summary> The ContactedDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."ContactedDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ContactedDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.ContactedDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.ContactedDate, value); }
		}

		/// <summary> The Disposition property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."Disposition"<br/>
		/// View field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 400<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Disposition
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.Disposition, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.Disposition, value); }
		}

		/// <summary> The AppointmentDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."AppointmentDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime AppointmentDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.AppointmentDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.AppointmentDate, value); }
		}

		/// <summary> The AppointmentCancellationDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."AppointmentCancellationDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime AppointmentCancellationDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.AppointmentCancellationDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.AppointmentCancellationDate, value); }
		}

		/// <summary> The IsEligble property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."IsEligble"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsEligble
		{
			get { return (System.Boolean)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsEligble, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsEligble, value); }
		}

		/// <summary> The ActivityId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."ActivityId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ActivityId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.ActivityId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.ActivityId, value); }
		}

		/// <summary> The PhoneCell property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."PhoneCell"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneHome property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."PhoneHome"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.PhoneHome, value); }
		}

		/// <summary> The PhoneOffice property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."PhoneOffice"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The IsIncorrectPhoneNumber property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."IsIncorrectPhoneNumber"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsIncorrectPhoneNumber
		{
			get { return (System.Boolean)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsIncorrectPhoneNumber, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsIncorrectPhoneNumber, value); }
		}

		/// <summary> The DoNotContactTypeId property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."DoNotContactTypeId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 DoNotContactTypeId
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DoNotContactTypeId, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DoNotContactTypeId, value); }
		}

		/// <summary> The CallBackRequestedDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."CallBackRequestedDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CallBackRequestedDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallBackRequestedDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.CallBackRequestedDate, value); }
		}

		/// <summary> The DoNotContactUpdateDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."DoNotContactUpdateDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DoNotContactUpdateDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DoNotContactUpdateDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DoNotContactUpdateDate, value); }
		}

		/// <summary> The DoNotContactUpdateSource property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."DoNotContactUpdateSource"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 DoNotContactUpdateSource
		{
			get { return (System.Int64)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DoNotContactUpdateSource, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.DoNotContactUpdateSource, value); }
		}

		/// <summary> The LanguageBarrierMarkedDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."LanguageBarrierMarkedDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime LanguageBarrierMarkedDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.LanguageBarrierMarkedDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.LanguageBarrierMarkedDate, value); }
		}

		/// <summary> The IncorrectPhoneNumberMarkedDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."IncorrectPhoneNumberMarkedDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime IncorrectPhoneNumberMarkedDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IncorrectPhoneNumberMarkedDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IncorrectPhoneNumberMarkedDate, value); }
		}

		/// <summary> The NoShowDate property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."NoShowDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime NoShowDate
		{
			get { return (System.DateTime)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.NoShowDate, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.NoShowDate, value); }
		}

		/// <summary> The TargetedYear property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."TargetedYear"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 TargetedYear
		{
			get { return (System.Int32)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.TargetedYear, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.TargetedYear, value); }
		}

		/// <summary> The IsTargeted property of the Entity VwCallQueueCustomerCriteraAssignmentForStats<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_CallQueueCustomerCriteraAssignmentForStats"."IsTargeted"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTargeted
		{
			get { return (System.Boolean)GetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsTargeted, true); }
			set	{ SetValue((int)VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex.IsTargeted, value); }
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
			get { return (int)Falcon.Data.EntityType.VwCallQueueCustomerCriteraAssignmentForStatsEntity; }
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
