///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:49
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
	/// Entity class which represents the entity 'DirectMail'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class DirectMailEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CallUploadEntity _callUpload;
		private CampaignEntity _campaign;
		private CustomerProfileEntity _customerProfile;
		private DirectMailTypeEntity _directMailType;
		private OrganizationRoleUserEntity _organizationRoleUser;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CallUpload</summary>
			public static readonly string CallUpload = "CallUpload";
			/// <summary>Member name Campaign</summary>
			public static readonly string Campaign = "Campaign";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name DirectMailType</summary>
			public static readonly string DirectMailType = "DirectMailType";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static DirectMailEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public DirectMailEntity():base("DirectMailEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public DirectMailEntity(IEntityFields2 fields):base("DirectMailEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this DirectMailEntity</param>
		public DirectMailEntity(IValidator validator):base("DirectMailEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for DirectMail which data should be fetched into this DirectMail object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public DirectMailEntity(System.Int64 id):base("DirectMailEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for DirectMail which data should be fetched into this DirectMail object</param>
		/// <param name="validator">The custom validator object for this DirectMailEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public DirectMailEntity(System.Int64 id, IValidator validator):base("DirectMailEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected DirectMailEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_callUpload = (CallUploadEntity)info.GetValue("_callUpload", typeof(CallUploadEntity));
				if(_callUpload!=null)
				{
					_callUpload.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_campaign = (CampaignEntity)info.GetValue("_campaign", typeof(CampaignEntity));
				if(_campaign!=null)
				{
					_campaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_directMailType = (DirectMailTypeEntity)info.GetValue("_directMailType", typeof(DirectMailTypeEntity));
				if(_directMailType!=null)
				{
					_directMailType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((DirectMailFieldIndex)fieldIndex)
			{
				case DirectMailFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case DirectMailFieldIndex.MailedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case DirectMailFieldIndex.CallUploadId:
					DesetupSyncCallUpload(true, false);
					break;
				case DirectMailFieldIndex.CampaignId:
					DesetupSyncCampaign(true, false);
					break;
				case DirectMailFieldIndex.DirectMailTypeId:
					DesetupSyncDirectMailType(true, false);
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
				case "CallUpload":
					this.CallUpload = (CallUploadEntity)entity;
					break;
				case "Campaign":
					this.Campaign = (CampaignEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "DirectMailType":
					this.DirectMailType = (DirectMailTypeEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
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
			return DirectMailEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CallUpload":
					toReturn.Add(DirectMailEntity.Relations.CallUploadEntityUsingCallUploadId);
					break;
				case "Campaign":
					toReturn.Add(DirectMailEntity.Relations.CampaignEntityUsingCampaignId);
					break;
				case "CustomerProfile":
					toReturn.Add(DirectMailEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "DirectMailType":
					toReturn.Add(DirectMailEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(DirectMailEntity.Relations.OrganizationRoleUserEntityUsingMailedBy);
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
				case "CallUpload":
					SetupSyncCallUpload(relatedEntity);
					break;
				case "Campaign":
					SetupSyncCampaign(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "DirectMailType":
					SetupSyncDirectMailType(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
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
				case "CallUpload":
					DesetupSyncCallUpload(false, true);
					break;
				case "Campaign":
					DesetupSyncCampaign(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "DirectMailType":
					DesetupSyncDirectMailType(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
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
			if(_callUpload!=null)
			{
				toReturn.Add(_callUpload);
			}
			if(_campaign!=null)
			{
				toReturn.Add(_campaign);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_directMailType!=null)
			{
				toReturn.Add(_directMailType);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
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


				info.AddValue("_callUpload", (!this.MarkedForDeletion?_callUpload:null));
				info.AddValue("_campaign", (!this.MarkedForDeletion?_campaign:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_directMailType", (!this.MarkedForDeletion?_directMailType:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(DirectMailFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(DirectMailFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new DirectMailRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CallUpload' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallUploadFields.Id, null, ComparisonOperator.Equal, this.CallUploadId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Campaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DirectMailType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDirectMailType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailTypeFields.Id, null, ComparisonOperator.Equal, this.DirectMailTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.MailedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.DirectMailEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory));
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
			toReturn.Add("CallUpload", _callUpload);
			toReturn.Add("Campaign", _campaign);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("DirectMailType", _directMailType);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_callUpload!=null)
			{
				_callUpload.ActiveContext = base.ActiveContext;
			}
			if(_campaign!=null)
			{
				_campaign.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_directMailType!=null)
			{
				_directMailType.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_callUpload = null;
			_campaign = null;
			_customerProfile = null;
			_directMailType = null;
			_organizationRoleUser = null;

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

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallUploadId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DirectMailTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsInvalidAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _callUpload</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallUpload(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callUpload, new PropertyChangedEventHandler( OnCallUploadPropertyChanged ), "CallUpload", DirectMailEntity.Relations.CallUploadEntityUsingCallUploadId, true, signalRelatedEntity, "DirectMail", resetFKFields, new int[] { (int)DirectMailFieldIndex.CallUploadId } );		
			_callUpload = null;
		}

		/// <summary> setups the sync logic for member _callUpload</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallUpload(IEntity2 relatedEntity)
		{
			if(_callUpload!=relatedEntity)
			{
				DesetupSyncCallUpload(true, true);
				_callUpload = (CallUploadEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callUpload, new PropertyChangedEventHandler( OnCallUploadPropertyChanged ), "CallUpload", DirectMailEntity.Relations.CallUploadEntityUsingCallUploadId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallUploadPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _campaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", DirectMailEntity.Relations.CampaignEntityUsingCampaignId, true, signalRelatedEntity, "DirectMail", resetFKFields, new int[] { (int)DirectMailFieldIndex.CampaignId } );		
			_campaign = null;
		}

		/// <summary> setups the sync logic for member _campaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCampaign(IEntity2 relatedEntity)
		{
			if(_campaign!=relatedEntity)
			{
				DesetupSyncCampaign(true, true);
				_campaign = (CampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", DirectMailEntity.Relations.CampaignEntityUsingCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", DirectMailEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "DirectMail", resetFKFields, new int[] { (int)DirectMailFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", DirectMailEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _directMailType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDirectMailType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _directMailType, new PropertyChangedEventHandler( OnDirectMailTypePropertyChanged ), "DirectMailType", DirectMailEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId, true, signalRelatedEntity, "DirectMail", resetFKFields, new int[] { (int)DirectMailFieldIndex.DirectMailTypeId } );		
			_directMailType = null;
		}

		/// <summary> setups the sync logic for member _directMailType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDirectMailType(IEntity2 relatedEntity)
		{
			if(_directMailType!=relatedEntity)
			{
				DesetupSyncDirectMailType(true, true);
				_directMailType = (DirectMailTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _directMailType, new PropertyChangedEventHandler( OnDirectMailTypePropertyChanged ), "DirectMailType", DirectMailEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDirectMailTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", DirectMailEntity.Relations.OrganizationRoleUserEntityUsingMailedBy, true, signalRelatedEntity, "DirectMail", resetFKFields, new int[] { (int)DirectMailFieldIndex.MailedBy } );		
			_organizationRoleUser = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser(true, true);
				_organizationRoleUser = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", DirectMailEntity.Relations.OrganizationRoleUserEntityUsingMailedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this DirectMailEntity</param>
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
		public  static DirectMailRelations Relations
		{
			get	{ return new DirectMailRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallUpload
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallUpload")[0], (int)Falcon.Data.EntityType.DirectMailEntity, (int)Falcon.Data.EntityType.CallUploadEntity, 0, null, null, null, null, "CallUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Campaign")[0], (int)Falcon.Data.EntityType.DirectMailEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, null, null, "Campaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.DirectMailEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DirectMailType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDirectMailType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("DirectMailType")[0], (int)Falcon.Data.EntityType.DirectMailEntity, (int)Falcon.Data.EntityType.DirectMailTypeEntity, 0, null, null, null, null, "DirectMailType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.DirectMailEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return DirectMailEntity.CustomProperties;}
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
			get { return DirectMailEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)DirectMailFieldIndex.Id, true); }
			set	{ SetValue((int)DirectMailFieldIndex.Id, value); }
		}

		/// <summary> The CustomerId property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)DirectMailFieldIndex.CustomerId, true); }
			set	{ SetValue((int)DirectMailFieldIndex.CustomerId, value); }
		}

		/// <summary> The MailDate property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."MailDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime MailDate
		{
			get { return (System.DateTime)GetValue((int)DirectMailFieldIndex.MailDate, true); }
			set	{ SetValue((int)DirectMailFieldIndex.MailDate, value); }
		}

		/// <summary> The MailedBy property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."MailedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MailedBy
		{
			get { return (System.Int64)GetValue((int)DirectMailFieldIndex.MailedBy, true); }
			set	{ SetValue((int)DirectMailFieldIndex.MailedBy, value); }
		}

		/// <summary> The CallUploadId property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."CallUploadId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallUploadId
		{
			get { return (System.Int64)GetValue((int)DirectMailFieldIndex.CallUploadId, true); }
			set	{ SetValue((int)DirectMailFieldIndex.CallUploadId, value); }
		}

		/// <summary> The CampaignId property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."CampaignId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CampaignId
		{
			get { return (Nullable<System.Int64>)GetValue((int)DirectMailFieldIndex.CampaignId, false); }
			set	{ SetValue((int)DirectMailFieldIndex.CampaignId, value); }
		}

		/// <summary> The DirectMailTypeId property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."DirectMailTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DirectMailTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)DirectMailFieldIndex.DirectMailTypeId, false); }
			set	{ SetValue((int)DirectMailFieldIndex.DirectMailTypeId, value); }
		}

		/// <summary> The IsInvalidAddress property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."IsInvalidAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsInvalidAddress
		{
			get { return (Nullable<System.Boolean>)GetValue((int)DirectMailFieldIndex.IsInvalidAddress, false); }
			set	{ SetValue((int)DirectMailFieldIndex.IsInvalidAddress, value); }
		}

		/// <summary> The Notes property of the Entity DirectMail<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblDirectMail"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)DirectMailFieldIndex.Notes, true); }
			set	{ SetValue((int)DirectMailFieldIndex.Notes, value); }
		}



		/// <summary> Gets / sets related entity of type 'CallUploadEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallUploadEntity CallUpload
		{
			get
			{
				return _callUpload;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallUpload(value);
				}
				else
				{
					if(value==null)
					{
						if(_callUpload != null)
						{
							_callUpload.UnsetRelatedEntity(this, "DirectMail");
						}
					}
					else
					{
						if(_callUpload!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "DirectMail");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CampaignEntity Campaign
		{
			get
			{
				return _campaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_campaign != null)
						{
							_campaign.UnsetRelatedEntity(this, "DirectMail");
						}
					}
					else
					{
						if(_campaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "DirectMail");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "DirectMail");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "DirectMail");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DirectMailTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DirectMailTypeEntity DirectMailType
		{
			get
			{
				return _directMailType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDirectMailType(value);
				}
				else
				{
					if(value==null)
					{
						if(_directMailType != null)
						{
							_directMailType.UnsetRelatedEntity(this, "DirectMail");
						}
					}
					else
					{
						if(_directMailType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "DirectMail");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser
		{
			get
			{
				return _organizationRoleUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser != null)
						{
							_organizationRoleUser.UnsetRelatedEntity(this, "DirectMail");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "DirectMail");
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
			get { return (int)Falcon.Data.EntityType.DirectMailEntity; }
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
