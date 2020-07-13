///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
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
	/// Entity class which represents the entity 'Afadvertiser'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AfadvertiserEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AfcampaignEntity> _afcampaign;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAfcampaign_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAfcampaign;
		private AfchannelEntity _afchannel;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Afchannel</summary>
			public static readonly string Afchannel = "Afchannel";
			/// <summary>Member name Afcampaign</summary>
			public static readonly string Afcampaign = "Afcampaign";
			/// <summary>Member name OrganizationRoleUserCollectionViaAfcampaign_</summary>
			public static readonly string OrganizationRoleUserCollectionViaAfcampaign_ = "OrganizationRoleUserCollectionViaAfcampaign_";
			/// <summary>Member name OrganizationRoleUserCollectionViaAfcampaign</summary>
			public static readonly string OrganizationRoleUserCollectionViaAfcampaign = "OrganizationRoleUserCollectionViaAfcampaign";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AfadvertiserEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AfadvertiserEntity():base("AfadvertiserEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AfadvertiserEntity(IEntityFields2 fields):base("AfadvertiserEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AfadvertiserEntity</param>
		public AfadvertiserEntity(IValidator validator):base("AfadvertiserEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="advertiserId">PK value for Afadvertiser which data should be fetched into this Afadvertiser object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfadvertiserEntity(System.Int64 advertiserId):base("AfadvertiserEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AdvertiserId = advertiserId;
		}

		/// <summary> CTor</summary>
		/// <param name="advertiserId">PK value for Afadvertiser which data should be fetched into this Afadvertiser object</param>
		/// <param name="validator">The custom validator object for this AfadvertiserEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfadvertiserEntity(System.Int64 advertiserId, IValidator validator):base("AfadvertiserEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AdvertiserId = advertiserId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AfadvertiserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_afcampaign = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaign", typeof(EntityCollection<AfcampaignEntity>));
				_organizationRoleUserCollectionViaAfcampaign_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAfcampaign_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAfcampaign = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAfcampaign", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_afchannel = (AfchannelEntity)info.GetValue("_afchannel", typeof(AfchannelEntity));
				if(_afchannel!=null)
				{
					_afchannel.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AfadvertiserFieldIndex)fieldIndex)
			{
				case AfadvertiserFieldIndex.ChannelId:
					DesetupSyncAfchannel(true, false);
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
				case "Afchannel":
					this.Afchannel = (AfchannelEntity)entity;
					break;
				case "Afcampaign":
					this.Afcampaign.Add((AfcampaignEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaAfcampaign_":
					this.OrganizationRoleUserCollectionViaAfcampaign_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAfcampaign_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAfcampaign_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAfcampaign":
					this.OrganizationRoleUserCollectionViaAfcampaign.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAfcampaign.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAfcampaign.IsReadOnly = true;
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
			return AfadvertiserEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Afchannel":
					toReturn.Add(AfadvertiserEntity.Relations.AfchannelEntityUsingChannelId);
					break;
				case "Afcampaign":
					toReturn.Add(AfadvertiserEntity.Relations.AfcampaignEntityUsingAdvertiserId);
					break;
				case "OrganizationRoleUserCollectionViaAfcampaign_":
					toReturn.Add(AfadvertiserEntity.Relations.AfcampaignEntityUsingAdvertiserId, "AfadvertiserEntity__", "Afcampaign_", JoinHint.None);
					toReturn.Add(AfcampaignEntity.Relations.OrganizationRoleUserEntityUsingRoleId, "Afcampaign_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAfcampaign":
					toReturn.Add(AfadvertiserEntity.Relations.AfcampaignEntityUsingAdvertiserId, "AfadvertiserEntity__", "Afcampaign_", JoinHint.None);
					toReturn.Add(AfcampaignEntity.Relations.OrganizationRoleUserEntityUsingShellId, "Afcampaign_", string.Empty, JoinHint.None);
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
				case "Afchannel":
					SetupSyncAfchannel(relatedEntity);
					break;
				case "Afcampaign":
					this.Afcampaign.Add((AfcampaignEntity)relatedEntity);
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
				case "Afchannel":
					DesetupSyncAfchannel(false, true);
					break;
				case "Afcampaign":
					base.PerformRelatedEntityRemoval(this.Afcampaign, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_afchannel!=null)
			{
				toReturn.Add(_afchannel);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Afcampaign);

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
				info.AddValue("_afcampaign", ((_afcampaign!=null) && (_afcampaign.Count>0) && !this.MarkedForDeletion)?_afcampaign:null);
				info.AddValue("_organizationRoleUserCollectionViaAfcampaign_", ((_organizationRoleUserCollectionViaAfcampaign_!=null) && (_organizationRoleUserCollectionViaAfcampaign_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAfcampaign_:null);
				info.AddValue("_organizationRoleUserCollectionViaAfcampaign", ((_organizationRoleUserCollectionViaAfcampaign!=null) && (_organizationRoleUserCollectionViaAfcampaign.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAfcampaign:null);
				info.AddValue("_afchannel", (!this.MarkedForDeletion?_afchannel:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AfadvertiserFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AfadvertiserFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AfadvertiserRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.AdvertiserId, null, ComparisonOperator.Equal, this.AdvertiserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAfcampaign_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAfcampaign_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfadvertiserFields.AdvertiserId, null, ComparisonOperator.Equal, this.AdvertiserId, "AfadvertiserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAfcampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAfcampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfadvertiserFields.AdvertiserId, null, ComparisonOperator.Equal, this.AdvertiserId, "AfadvertiserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Afchannel' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfchannel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfchannelFields.ChannelId, null, ComparisonOperator.Equal, this.ChannelId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AfadvertiserEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AfadvertiserEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._afcampaign);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAfcampaign_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAfcampaign);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._afcampaign = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAfcampaign_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAfcampaign = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._afcampaign != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAfcampaign_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAfcampaign != null)
			{
				return true;
			}
			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Afchannel", _afchannel);
			toReturn.Add("Afcampaign", _afcampaign);
			toReturn.Add("OrganizationRoleUserCollectionViaAfcampaign_", _organizationRoleUserCollectionViaAfcampaign_);
			toReturn.Add("OrganizationRoleUserCollectionViaAfcampaign", _organizationRoleUserCollectionViaAfcampaign);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_afcampaign!=null)
			{
				_afcampaign.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAfcampaign_!=null)
			{
				_organizationRoleUserCollectionViaAfcampaign_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAfcampaign!=null)
			{
				_organizationRoleUserCollectionViaAfcampaign.ActiveContext = base.ActiveContext;
			}
			if(_afchannel!=null)
			{
				_afchannel.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_afcampaign = null;
			_organizationRoleUserCollectionViaAfcampaign_ = null;
			_organizationRoleUserCollectionViaAfcampaign = null;
			_afchannel = null;

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

			_fieldsCustomProperties.Add("AdvertiserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdvertiserName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChannelId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afchannel</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfchannel(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afchannel, new PropertyChangedEventHandler( OnAfchannelPropertyChanged ), "Afchannel", AfadvertiserEntity.Relations.AfchannelEntityUsingChannelId, true, signalRelatedEntity, "Afadvertiser", resetFKFields, new int[] { (int)AfadvertiserFieldIndex.ChannelId } );		
			_afchannel = null;
		}

		/// <summary> setups the sync logic for member _afchannel</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfchannel(IEntity2 relatedEntity)
		{
			if(_afchannel!=relatedEntity)
			{
				DesetupSyncAfchannel(true, true);
				_afchannel = (AfchannelEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afchannel, new PropertyChangedEventHandler( OnAfchannelPropertyChanged ), "Afchannel", AfadvertiserEntity.Relations.AfchannelEntityUsingChannelId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfchannelPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AfadvertiserEntity</param>
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
		public  static AfadvertiserRelations Relations
		{
			get	{ return new AfadvertiserRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaign
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afcampaign")[0], (int)Falcon.Data.EntityType.AfadvertiserEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, null, null, "Afcampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAfcampaign_
		{
			get
			{
				IEntityRelation intermediateRelation = AfadvertiserEntity.Relations.AfcampaignEntityUsingAdvertiserId;
				intermediateRelation.SetAliases(string.Empty, "Afcampaign_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfadvertiserEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAfcampaign_"), null, "OrganizationRoleUserCollectionViaAfcampaign_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAfcampaign
		{
			get
			{
				IEntityRelation intermediateRelation = AfadvertiserEntity.Relations.AfcampaignEntityUsingAdvertiserId;
				intermediateRelation.SetAliases(string.Empty, "Afcampaign_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfadvertiserEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAfcampaign"), null, "OrganizationRoleUserCollectionViaAfcampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afchannel' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfchannel
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfchannelEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afchannel")[0], (int)Falcon.Data.EntityType.AfadvertiserEntity, (int)Falcon.Data.EntityType.AfchannelEntity, 0, null, null, null, null, "Afchannel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AfadvertiserEntity.CustomProperties;}
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
			get { return AfadvertiserEntity.FieldsCustomProperties;}
		}

		/// <summary> The AdvertiserId property of the Entity Afadvertiser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAdvertiser"."AdvertiserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 AdvertiserId
		{
			get { return (System.Int64)GetValue((int)AfadvertiserFieldIndex.AdvertiserId, true); }
			set	{ SetValue((int)AfadvertiserFieldIndex.AdvertiserId, value); }
		}

		/// <summary> The AdvertiserName property of the Entity Afadvertiser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAdvertiser"."AdvertiserName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String AdvertiserName
		{
			get { return (System.String)GetValue((int)AfadvertiserFieldIndex.AdvertiserName, true); }
			set	{ SetValue((int)AfadvertiserFieldIndex.AdvertiserName, value); }
		}

		/// <summary> The ChannelId property of the Entity Afadvertiser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAdvertiser"."ChannelID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ChannelId
		{
			get { return (System.Int64)GetValue((int)AfadvertiserFieldIndex.ChannelId, true); }
			set	{ SetValue((int)AfadvertiserFieldIndex.ChannelId, value); }
		}

		/// <summary> The CreatedDate property of the Entity Afadvertiser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAdvertiser"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfadvertiserFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)AfadvertiserFieldIndex.CreatedDate, value); }
		}

		/// <summary> The LastModifiedDate property of the Entity Afadvertiser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAdvertiser"."LastModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfadvertiserFieldIndex.LastModifiedDate, false); }
			set	{ SetValue((int)AfadvertiserFieldIndex.LastModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity Afadvertiser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAdvertiser"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AfadvertiserFieldIndex.IsActive, true); }
			set	{ SetValue((int)AfadvertiserFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> Afcampaign
		{
			get
			{
				if(_afcampaign==null)
				{
					_afcampaign = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaign.SetContainingEntityInfo(this, "Afadvertiser");
				}
				return _afcampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAfcampaign_
		{
			get
			{
				if(_organizationRoleUserCollectionViaAfcampaign_==null)
				{
					_organizationRoleUserCollectionViaAfcampaign_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAfcampaign_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAfcampaign_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAfcampaign
		{
			get
			{
				if(_organizationRoleUserCollectionViaAfcampaign==null)
				{
					_organizationRoleUserCollectionViaAfcampaign = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAfcampaign.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAfcampaign;
			}
		}

		/// <summary> Gets / sets related entity of type 'AfchannelEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfchannelEntity Afchannel
		{
			get
			{
				return _afchannel;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfchannel(value);
				}
				else
				{
					if(value==null)
					{
						if(_afchannel != null)
						{
							_afchannel.UnsetRelatedEntity(this, "Afadvertiser");
						}
					}
					else
					{
						if(_afchannel!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afadvertiser");
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
			get { return (int)Falcon.Data.EntityType.AfadvertiserEntity; }
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
