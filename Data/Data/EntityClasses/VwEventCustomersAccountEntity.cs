///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:50
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
	/// Entity class which represents the entity 'VwEventCustomersAccount'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class VwEventCustomersAccountEntity : CommonEntityBase, ISerializable
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
		static VwEventCustomersAccountEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public VwEventCustomersAccountEntity():base("VwEventCustomersAccountEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public VwEventCustomersAccountEntity(IEntityFields2 fields):base("VwEventCustomersAccountEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this VwEventCustomersAccountEntity</param>
		public VwEventCustomersAccountEntity(IValidator validator):base("VwEventCustomersAccountEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected VwEventCustomersAccountEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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
			switch((VwEventCustomersAccountFieldIndex)fieldIndex)
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
			return VwEventCustomersAccountEntity.GetRelationsForField(fieldName);
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
		public bool TestOriginalFieldValueForNull(VwEventCustomersAccountFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(VwEventCustomersAccountFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new VwEventCustomersAccountRelations().GetAllRelations();
		}
		




	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.VwEventCustomersAccountEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(VwEventCustomersAccountEntityFactory));
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

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPaymentOnline", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestConducted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BMailReports", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoShow", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OfflineCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateCampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SignInSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdvocateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Hipaastatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClickId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PartnerRelease", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HospitalFacilityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Abnstatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpconsentStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InsuranceReleaseStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LeftWithoutScreeningReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AwvVisitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableTexting", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsGiftCertificateDelivered", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GiftCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PatientDetailId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AccountId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsAppointmentConfirmed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConfirmedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreferredContactType", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this VwEventCustomersAccountEntity</param>
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
		public  static VwEventCustomersAccountRelations Relations
		{
			get	{ return new VwEventCustomersAccountRelations(); }
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
			get { return VwEventCustomersAccountEntity.CustomProperties;}
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
			get { return VwEventCustomersAccountEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventCustomerId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."EventCustomerID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.EventCustomerId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The EventId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."EventID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.EventId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.EventId, value); }
		}

		/// <summary> The CustomerId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."CustomerID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.CustomerId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.CustomerId, value); }
		}

		/// <summary> The IsPaymentOnline property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."IsPaymentOnline"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPaymentOnline
		{
			get { return (System.Boolean)GetValue((int)VwEventCustomersAccountFieldIndex.IsPaymentOnline, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.IsPaymentOnline, value); }
		}

		/// <summary> The AppointmentId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."AppointmentId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AppointmentId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.AppointmentId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.AppointmentId, value); }
		}

		/// <summary> The IsTestConducted property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."IsTestConducted"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTestConducted
		{
			get { return (System.Boolean)GetValue((int)VwEventCustomersAccountFieldIndex.IsTestConducted, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.IsTestConducted, value); }
		}

		/// <summary> The BMailReports property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."bMailReports"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BMailReports
		{
			get { return (System.Boolean)GetValue((int)VwEventCustomersAccountFieldIndex.BMailReports, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.BMailReports, value); }
		}

		/// <summary> The Notes property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."Notes"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)VwEventCustomersAccountFieldIndex.Notes, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.Notes, value); }
		}

		/// <summary> The NoShow property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."NoShow"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean NoShow
		{
			get { return (System.Boolean)GetValue((int)VwEventCustomersAccountFieldIndex.NoShow, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.NoShow, value); }
		}

		/// <summary> The DateCreated property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."DateCreated"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)VwEventCustomersAccountFieldIndex.DateCreated, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.DateCreated, value); }
		}

		/// <summary> The OfflineCustomerId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."OfflineCustomerID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OfflineCustomerId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.OfflineCustomerId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.OfflineCustomerId, value); }
		}

		/// <summary> The AffiliateCampaignId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."AffiliateCampaignID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AffiliateCampaignId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.AffiliateCampaignId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.AffiliateCampaignId, value); }
		}

		/// <summary> The SignInSource property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."SignInSource"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String SignInSource
		{
			get { return (System.String)GetValue((int)VwEventCustomersAccountFieldIndex.SignInSource, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.SignInSource, value); }
		}

		/// <summary> The AdvocateId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."AdvocateID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AdvocateId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.AdvocateId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.AdvocateId, value); }
		}

		/// <summary> The Hipaastatus property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."HIPAAStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Hipaastatus
		{
			get { return (System.Int16)GetValue((int)VwEventCustomersAccountFieldIndex.Hipaastatus, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.Hipaastatus, value); }
		}

		/// <summary> The MarketingSource property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."MarketingSource"<br/>
		/// View field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String MarketingSource
		{
			get { return (System.String)GetValue((int)VwEventCustomersAccountFieldIndex.MarketingSource, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.MarketingSource, value); }
		}

		/// <summary> The ClickId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."ClickID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ClickId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.ClickId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.ClickId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."CreatedByOrgRoleUserId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The PartnerRelease property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."PartnerRelease"<br/>
		/// View field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 PartnerRelease
		{
			get { return (System.Int16)GetValue((int)VwEventCustomersAccountFieldIndex.PartnerRelease, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.PartnerRelease, value); }
		}

		/// <summary> The HospitalFacilityId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."HospitalFacilityId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HospitalFacilityId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.HospitalFacilityId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.HospitalFacilityId, value); }
		}

		/// <summary> The Abnstatus property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."ABNStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Abnstatus
		{
			get { return (System.Int16)GetValue((int)VwEventCustomersAccountFieldIndex.Abnstatus, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.Abnstatus, value); }
		}

		/// <summary> The PcpconsentStatus property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."PCPConsentStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 PcpconsentStatus
		{
			get { return (System.Int16)GetValue((int)VwEventCustomersAccountFieldIndex.PcpconsentStatus, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.PcpconsentStatus, value); }
		}

		/// <summary> The InsuranceReleaseStatus property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."InsuranceReleaseStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 InsuranceReleaseStatus
		{
			get { return (System.Int16)GetValue((int)VwEventCustomersAccountFieldIndex.InsuranceReleaseStatus, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.InsuranceReleaseStatus, value); }
		}

		/// <summary> The CampaignId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."CampaignId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CampaignId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.CampaignId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.CampaignId, value); }
		}

		/// <summary> The LeftWithoutScreeningReasonId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."LeftWithoutScreeningReasonId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LeftWithoutScreeningReasonId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.LeftWithoutScreeningReasonId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.LeftWithoutScreeningReasonId, value); }
		}

		/// <summary> The AwvVisitId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."AwvVisitId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AwvVisitId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.AwvVisitId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.AwvVisitId, value); }
		}

		/// <summary> The EnableTexting property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."EnableTexting"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnableTexting
		{
			get { return (System.Boolean)GetValue((int)VwEventCustomersAccountFieldIndex.EnableTexting, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.EnableTexting, value); }
		}

		/// <summary> The IsGiftCertificateDelivered property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."IsGiftCertificateDelivered"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsGiftCertificateDelivered
		{
			get { return (System.Boolean)GetValue((int)VwEventCustomersAccountFieldIndex.IsGiftCertificateDelivered, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.IsGiftCertificateDelivered, value); }
		}

		/// <summary> The GiftCode property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."GiftCode"<br/>
		/// View field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 512<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String GiftCode
		{
			get { return (System.String)GetValue((int)VwEventCustomersAccountFieldIndex.GiftCode, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.GiftCode, value); }
		}

		/// <summary> The PatientDetailId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."PatientDetailId"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PatientDetailId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.PatientDetailId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.PatientDetailId, value); }
		}

		/// <summary> The EventDate property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."EventDate"<br/>
		/// View field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime EventDate
		{
			get { return (System.DateTime)GetValue((int)VwEventCustomersAccountFieldIndex.EventDate, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.EventDate, value); }
		}

		/// <summary> The EventStatus property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."EventStatus"<br/>
		/// View field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EventStatus
		{
			get { return (System.Int32)GetValue((int)VwEventCustomersAccountFieldIndex.EventStatus, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.EventStatus, value); }
		}

		/// <summary> The EventTypeId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."EventTypeID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventTypeId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.EventTypeId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.EventTypeId, value); }
		}

		/// <summary> The AccountId property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."AccountID"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AccountId
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.AccountId, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.AccountId, value); }
		}

		/// <summary> The IsAppointmentConfirmed property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."IsAppointmentConfirmed"<br/>
		/// View field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsAppointmentConfirmed
		{
			get { return (System.Boolean)GetValue((int)VwEventCustomersAccountFieldIndex.IsAppointmentConfirmed, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.IsAppointmentConfirmed, value); }
		}

		/// <summary> The ConfirmedBy property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."ConfirmedBy"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ConfirmedBy
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.ConfirmedBy, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.ConfirmedBy, value); }
		}

		/// <summary> The PreferredContactType property of the Entity VwEventCustomersAccount<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  view field: "Vw_EventCustomersAccount"."PreferredContactType"<br/>
		/// View field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// View field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PreferredContactType
		{
			get { return (System.Int64)GetValue((int)VwEventCustomersAccountFieldIndex.PreferredContactType, true); }
			set	{ SetValue((int)VwEventCustomersAccountFieldIndex.PreferredContactType, value); }
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
			get { return (int)Falcon.Data.EntityType.VwEventCustomersAccountEntity; }
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
