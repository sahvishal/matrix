///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:52
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
	/// Entity class which represents the entity 'MemberUploadParseDetail'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MemberUploadParseDetailEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CorporateUploadEntity _corporateUpload;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CorporateUpload</summary>
			public static readonly string CorporateUpload = "CorporateUpload";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MemberUploadParseDetailEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MemberUploadParseDetailEntity():base("MemberUploadParseDetailEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MemberUploadParseDetailEntity(IEntityFields2 fields):base("MemberUploadParseDetailEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MemberUploadParseDetailEntity</param>
		public MemberUploadParseDetailEntity(IValidator validator):base("MemberUploadParseDetailEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for MemberUploadParseDetail which data should be fetched into this MemberUploadParseDetail object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MemberUploadParseDetailEntity(System.Int64 id):base("MemberUploadParseDetailEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for MemberUploadParseDetail which data should be fetched into this MemberUploadParseDetail object</param>
		/// <param name="validator">The custom validator object for this MemberUploadParseDetailEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MemberUploadParseDetailEntity(System.Int64 id, IValidator validator):base("MemberUploadParseDetailEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MemberUploadParseDetailEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_corporateUpload = (CorporateUploadEntity)info.GetValue("_corporateUpload", typeof(CorporateUploadEntity));
				if(_corporateUpload!=null)
				{
					_corporateUpload.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MemberUploadParseDetailFieldIndex)fieldIndex)
			{
				case MemberUploadParseDetailFieldIndex.CorporateUploadId:
					DesetupSyncCorporateUpload(true, false);
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
				case "CorporateUpload":
					this.CorporateUpload = (CorporateUploadEntity)entity;
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
			return MemberUploadParseDetailEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CorporateUpload":
					toReturn.Add(MemberUploadParseDetailEntity.Relations.CorporateUploadEntityUsingCorporateUploadId);
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
				case "CorporateUpload":
					SetupSyncCorporateUpload(relatedEntity);
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
				case "CorporateUpload":
					DesetupSyncCorporateUpload(false, true);
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
			if(_corporateUpload!=null)
			{
				toReturn.Add(_corporateUpload);
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


				info.AddValue("_corporateUpload", (!this.MarkedForDeletion?_corporateUpload:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MemberUploadParseDetailFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MemberUploadParseDetailFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MemberUploadParseDetailRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CorporateUpload' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCorporateUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.Id, null, ComparisonOperator.Equal, this.CorporateUploadId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MemberUploadParseDetailEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MemberUploadParseDetailEntityFactory));
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
			toReturn.Add("CorporateUpload", _corporateUpload);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_corporateUpload!=null)
			{
				_corporateUpload.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_corporateUpload = null;

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

			_fieldsCustomProperties.Add("CorporateUploadId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MemberId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dob", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AlternateEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHome", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Address1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Address2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("City", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("State", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Zip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Hicn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpFirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpLastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpPhone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpFax", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpAddress1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpAddress2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpCity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpZip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpNpi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreApprovedTest", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsEligible", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TargetYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Language", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Lab", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Copay", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicareAdvantagePlanName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Lpi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Market", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Mrn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IcdCodes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreApprovedPackage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreApprovedPackageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpmailingAddress1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpmailingAddress2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpmailingCity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpmailingState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpmailingZip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CurrentMedication", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CurrentMedicationSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdditionalField1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdditionalField2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdditionalField3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdditionalField4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Activity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PredictedZip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Mbi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingMemberId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingMemberPlan", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingMemberPlanYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WarmTransferAllowed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WarmTransferYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AcesId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EligibilityYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ErrorMessage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSuccessful", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dnc", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProductType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AcesClientId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _corporateUpload</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCorporateUpload(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _corporateUpload, new PropertyChangedEventHandler( OnCorporateUploadPropertyChanged ), "CorporateUpload", MemberUploadParseDetailEntity.Relations.CorporateUploadEntityUsingCorporateUploadId, true, signalRelatedEntity, "MemberUploadParseDetail", resetFKFields, new int[] { (int)MemberUploadParseDetailFieldIndex.CorporateUploadId } );		
			_corporateUpload = null;
		}

		/// <summary> setups the sync logic for member _corporateUpload</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCorporateUpload(IEntity2 relatedEntity)
		{
			if(_corporateUpload!=relatedEntity)
			{
				DesetupSyncCorporateUpload(true, true);
				_corporateUpload = (CorporateUploadEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _corporateUpload, new PropertyChangedEventHandler( OnCorporateUploadPropertyChanged ), "CorporateUpload", MemberUploadParseDetailEntity.Relations.CorporateUploadEntityUsingCorporateUploadId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCorporateUploadPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MemberUploadParseDetailEntity</param>
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
		public  static MemberUploadParseDetailRelations Relations
		{
			get	{ return new MemberUploadParseDetailRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CorporateUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCorporateUpload
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))),
					(IEntityRelation)GetRelationsForField("CorporateUpload")[0], (int)Falcon.Data.EntityType.MemberUploadParseDetailEntity, (int)Falcon.Data.EntityType.CorporateUploadEntity, 0, null, null, null, null, "CorporateUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MemberUploadParseDetailEntity.CustomProperties;}
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
			get { return MemberUploadParseDetailEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)MemberUploadParseDetailFieldIndex.Id, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Id, value); }
		}

		/// <summary> The CorporateUploadId property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."CorporateUploadId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CorporateUploadId
		{
			get { return (System.Int64)GetValue((int)MemberUploadParseDetailFieldIndex.CorporateUploadId, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.CorporateUploadId, value); }
		}

		/// <summary> The CustomerId property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MemberUploadParseDetailFieldIndex.CustomerId, false); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.CustomerId, value); }
		}

		/// <summary> The MemberId property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."MemberID"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MemberId
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.MemberId, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.MemberId, value); }
		}

		/// <summary> The FirstName property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.FirstName, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."MiddleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.MiddleName, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.LastName, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.LastName, value); }
		}

		/// <summary> The Gender property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Gender
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Gender, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Gender, value); }
		}

		/// <summary> The Dob property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Dob"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Dob
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Dob, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Dob, value); }
		}

		/// <summary> The Email property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Email, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Email, value); }
		}

		/// <summary> The AlternateEmail property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."AlternateEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AlternateEmail
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.AlternateEmail, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.AlternateEmail, value); }
		}

		/// <summary> The PhoneCell property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PhoneCell"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneHome property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PhoneHome"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PhoneHome, value); }
		}

		/// <summary> The Address1 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Address1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Address1
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Address1, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Address1, value); }
		}

		/// <summary> The Address2 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Address2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Address2
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Address2, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Address2, value); }
		}

		/// <summary> The City property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."City"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String City
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.City, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.City, value); }
		}

		/// <summary> The State property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."State"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String State
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.State, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.State, value); }
		}

		/// <summary> The Zip property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Zip"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Zip
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Zip, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Zip, value); }
		}

		/// <summary> The Hicn property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Hicn"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Hicn
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Hicn, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Hicn, value); }
		}

		/// <summary> The PcpFirstName property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpFirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpFirstName
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpFirstName, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpFirstName, value); }
		}

		/// <summary> The PcpLastName property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpLastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpLastName
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpLastName, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpLastName, value); }
		}

		/// <summary> The PcpPhone property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpPhone"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpPhone
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpPhone, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpPhone, value); }
		}

		/// <summary> The PcpFax property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpFax"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpFax
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpFax, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpFax, value); }
		}

		/// <summary> The PcpEmail property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpEmail
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpEmail, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpEmail, value); }
		}

		/// <summary> The PcpAddress1 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpAddress1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpAddress1
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpAddress1, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpAddress1, value); }
		}

		/// <summary> The PcpAddress2 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpAddress2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpAddress2
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpAddress2, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpAddress2, value); }
		}

		/// <summary> The PcpCity property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpCity"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpCity
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpCity, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpCity, value); }
		}

		/// <summary> The PcpState property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpState"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpState
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpState, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpState, value); }
		}

		/// <summary> The PcpZip property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpZip"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpZip
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpZip, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpZip, value); }
		}

		/// <summary> The PcpNpi property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PcpNpi"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpNpi
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpNpi, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpNpi, value); }
		}

		/// <summary> The PreApprovedTest property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PreApprovedTest"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PreApprovedTest
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PreApprovedTest, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PreApprovedTest, value); }
		}

		/// <summary> The IsEligible property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."IsEligible"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IsEligible
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.IsEligible, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.IsEligible, value); }
		}

		/// <summary> The TargetYear property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."TargetYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TargetYear
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.TargetYear, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.TargetYear, value); }
		}

		/// <summary> The Language property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Language"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Language
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Language, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Language, value); }
		}

		/// <summary> The Lab property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Lab"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Lab
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Lab, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Lab, value); }
		}

		/// <summary> The Copay property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Copay"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Copay
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Copay, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Copay, value); }
		}

		/// <summary> The MedicareAdvantagePlanName property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."MedicareAdvantagePlanName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MedicareAdvantagePlanName
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.MedicareAdvantagePlanName, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.MedicareAdvantagePlanName, value); }
		}

		/// <summary> The Lpi property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Lpi"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Lpi
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Lpi, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Lpi, value); }
		}

		/// <summary> The Market property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Market"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Market
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Market, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Market, value); }
		}

		/// <summary> The Mrn property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Mrn"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Mrn
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Mrn, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Mrn, value); }
		}

		/// <summary> The GroupName property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."GroupName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GroupName
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.GroupName, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.GroupName, value); }
		}

		/// <summary> The IcdCodes property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."IcdCodes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IcdCodes
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.IcdCodes, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.IcdCodes, value); }
		}

		/// <summary> The PreApprovedPackage property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PreApprovedPackage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PreApprovedPackage
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PreApprovedPackage, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PreApprovedPackage, value); }
		}

		/// <summary> The PreApprovedPackageId property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PreApprovedPackageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PreApprovedPackageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MemberUploadParseDetailFieldIndex.PreApprovedPackageId, false); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PreApprovedPackageId, value); }
		}

		/// <summary> The PcpmailingAddress1 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PCPMailingAddress1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpmailingAddress1
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingAddress1, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingAddress1, value); }
		}

		/// <summary> The PcpmailingAddress2 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PCPMailingAddress2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpmailingAddress2
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingAddress2, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingAddress2, value); }
		}

		/// <summary> The PcpmailingCity property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PCPMailingCity"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpmailingCity
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingCity, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingCity, value); }
		}

		/// <summary> The PcpmailingState property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PCPMailingState"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpmailingState
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingState, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingState, value); }
		}

		/// <summary> The PcpmailingZip property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PCPMailingZip"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PcpmailingZip
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingZip, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PcpmailingZip, value); }
		}

		/// <summary> The CurrentMedication property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."CurrentMedication"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CurrentMedication
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.CurrentMedication, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.CurrentMedication, value); }
		}

		/// <summary> The CurrentMedicationSource property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."CurrentMedicationSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CurrentMedicationSource
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.CurrentMedicationSource, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.CurrentMedicationSource, value); }
		}

		/// <summary> The AdditionalField1 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."AdditionalField1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AdditionalField1
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.AdditionalField1, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.AdditionalField1, value); }
		}

		/// <summary> The AdditionalField2 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."AdditionalField2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AdditionalField2
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.AdditionalField2, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.AdditionalField2, value); }
		}

		/// <summary> The AdditionalField3 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."AdditionalField3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AdditionalField3
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.AdditionalField3, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.AdditionalField3, value); }
		}

		/// <summary> The AdditionalField4 property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."AdditionalField4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AdditionalField4
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.AdditionalField4, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.AdditionalField4, value); }
		}

		/// <summary> The Activity property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Activity"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Activity
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Activity, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Activity, value); }
		}

		/// <summary> The PredictedZip property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."PredictedZip"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PredictedZip
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.PredictedZip, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.PredictedZip, value); }
		}

		/// <summary> The Mbi property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."Mbi"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Mbi
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Mbi, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Mbi, value); }
		}

		/// <summary> The BillingMemberId property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."BillingMemberId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingMemberId
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.BillingMemberId, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.BillingMemberId, value); }
		}

		/// <summary> The BillingMemberPlan property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."BillingMemberPlan"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingMemberPlan
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.BillingMemberPlan, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.BillingMemberPlan, value); }
		}

		/// <summary> The BillingMemberPlanYear property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."BillingMemberPlanYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingMemberPlanYear
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.BillingMemberPlanYear, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.BillingMemberPlanYear, value); }
		}

		/// <summary> The WarmTransferAllowed property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."WarmTransferAllowed"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String WarmTransferAllowed
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.WarmTransferAllowed, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.WarmTransferAllowed, value); }
		}

		/// <summary> The WarmTransferYear property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."WarmTransferYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String WarmTransferYear
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.WarmTransferYear, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.WarmTransferYear, value); }
		}

		/// <summary> The AcesId property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."AcesId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AcesId
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.AcesId, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.AcesId, value); }
		}

		/// <summary> The EligibilityYear property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."EligibilityYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EligibilityYear
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.EligibilityYear, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.EligibilityYear, value); }
		}

		/// <summary> The ErrorMessage property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."ErrorMessage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ErrorMessage
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.ErrorMessage, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.ErrorMessage, value); }
		}

		/// <summary> The IsSuccessful property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."IsSuccessful"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSuccessful
		{
			get { return (System.Boolean)GetValue((int)MemberUploadParseDetailFieldIndex.IsSuccessful, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.IsSuccessful, value); }
		}

		/// <summary> The Dnc property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."DNC"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Dnc
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.Dnc, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.Dnc, value); }
		}

		/// <summary> The ProductType property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."ProductType"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ProductType
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.ProductType, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.ProductType, value); }
		}

		/// <summary> The AcesClientId property of the Entity MemberUploadParseDetail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMemberUploadParseDetail"."AcesClientId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AcesClientId
		{
			get { return (System.String)GetValue((int)MemberUploadParseDetailFieldIndex.AcesClientId, true); }
			set	{ SetValue((int)MemberUploadParseDetailFieldIndex.AcesClientId, value); }
		}



		/// <summary> Gets / sets related entity of type 'CorporateUploadEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CorporateUploadEntity CorporateUpload
		{
			get
			{
				return _corporateUpload;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCorporateUpload(value);
				}
				else
				{
					if(value==null)
					{
						if(_corporateUpload != null)
						{
							_corporateUpload.UnsetRelatedEntity(this, "MemberUploadParseDetail");
						}
					}
					else
					{
						if(_corporateUpload!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MemberUploadParseDetail");
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
			get { return (int)Falcon.Data.EntityType.MemberUploadParseDetailEntity; }
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
