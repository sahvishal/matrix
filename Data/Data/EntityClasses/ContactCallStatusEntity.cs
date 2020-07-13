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
	/// Entity class which represents the entity 'ContactCallStatus'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ContactCallStatusEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ContactCallEntity> _contactCall;
		private EntityCollection<ContactMeetingEntity> _contactMeeting;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaContactMeeting;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaContactMeeting_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaContactCall;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaContactCall_;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name ContactCall</summary>
			public static readonly string ContactCall = "ContactCall";
			/// <summary>Member name ContactMeeting</summary>
			public static readonly string ContactMeeting = "ContactMeeting";
			/// <summary>Member name OrganizationRoleUserCollectionViaContactMeeting</summary>
			public static readonly string OrganizationRoleUserCollectionViaContactMeeting = "OrganizationRoleUserCollectionViaContactMeeting";
			/// <summary>Member name OrganizationRoleUserCollectionViaContactMeeting_</summary>
			public static readonly string OrganizationRoleUserCollectionViaContactMeeting_ = "OrganizationRoleUserCollectionViaContactMeeting_";
			/// <summary>Member name OrganizationRoleUserCollectionViaContactCall</summary>
			public static readonly string OrganizationRoleUserCollectionViaContactCall = "OrganizationRoleUserCollectionViaContactCall";
			/// <summary>Member name OrganizationRoleUserCollectionViaContactCall_</summary>
			public static readonly string OrganizationRoleUserCollectionViaContactCall_ = "OrganizationRoleUserCollectionViaContactCall_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ContactCallStatusEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ContactCallStatusEntity():base("ContactCallStatusEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ContactCallStatusEntity(IEntityFields2 fields):base("ContactCallStatusEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ContactCallStatusEntity</param>
		public ContactCallStatusEntity(IValidator validator):base("ContactCallStatusEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="contactCallStatusId">PK value for ContactCallStatus which data should be fetched into this ContactCallStatus object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ContactCallStatusEntity(System.Int64 contactCallStatusId):base("ContactCallStatusEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ContactCallStatusId = contactCallStatusId;
		}

		/// <summary> CTor</summary>
		/// <param name="contactCallStatusId">PK value for ContactCallStatus which data should be fetched into this ContactCallStatus object</param>
		/// <param name="validator">The custom validator object for this ContactCallStatusEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ContactCallStatusEntity(System.Int64 contactCallStatusId, IValidator validator):base("ContactCallStatusEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ContactCallStatusId = contactCallStatusId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ContactCallStatusEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_contactCall = (EntityCollection<ContactCallEntity>)info.GetValue("_contactCall", typeof(EntityCollection<ContactCallEntity>));
				_contactMeeting = (EntityCollection<ContactMeetingEntity>)info.GetValue("_contactMeeting", typeof(EntityCollection<ContactMeetingEntity>));
				_organizationRoleUserCollectionViaContactMeeting = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaContactMeeting", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaContactMeeting_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaContactMeeting_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaContactCall = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaContactCall", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaContactCall_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaContactCall_", typeof(EntityCollection<OrganizationRoleUserEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ContactCallStatusFieldIndex)fieldIndex)
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

				case "ContactCall":
					this.ContactCall.Add((ContactCallEntity)entity);
					break;
				case "ContactMeeting":
					this.ContactMeeting.Add((ContactMeetingEntity)entity);
					break;
				case "OrganizationRoleUserCollectionViaContactMeeting":
					this.OrganizationRoleUserCollectionViaContactMeeting.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaContactMeeting.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaContactMeeting.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaContactMeeting_":
					this.OrganizationRoleUserCollectionViaContactMeeting_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaContactMeeting_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaContactMeeting_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaContactCall":
					this.OrganizationRoleUserCollectionViaContactCall.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaContactCall.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaContactCall.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaContactCall_":
					this.OrganizationRoleUserCollectionViaContactCall_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaContactCall_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaContactCall_.IsReadOnly = true;
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
			return ContactCallStatusEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "ContactCall":
					toReturn.Add(ContactCallStatusEntity.Relations.ContactCallEntityUsingContactCallStatusId);
					break;
				case "ContactMeeting":
					toReturn.Add(ContactCallStatusEntity.Relations.ContactMeetingEntityUsingContactMeetingStatusId);
					break;
				case "OrganizationRoleUserCollectionViaContactMeeting":
					toReturn.Add(ContactCallStatusEntity.Relations.ContactMeetingEntityUsingContactMeetingStatusId, "ContactCallStatusEntity__", "ContactMeeting_", JoinHint.None);
					toReturn.Add(ContactMeetingEntity.Relations.OrganizationRoleUserEntityUsingCreatedByRoleId, "ContactMeeting_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaContactMeeting_":
					toReturn.Add(ContactCallStatusEntity.Relations.ContactMeetingEntityUsingContactMeetingStatusId, "ContactCallStatusEntity__", "ContactMeeting_", JoinHint.None);
					toReturn.Add(ContactMeetingEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "ContactMeeting_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaContactCall":
					toReturn.Add(ContactCallStatusEntity.Relations.ContactCallEntityUsingContactCallStatusId, "ContactCallStatusEntity__", "ContactCall_", JoinHint.None);
					toReturn.Add(ContactCallEntity.Relations.OrganizationRoleUserEntityUsingCreatedByRoleId, "ContactCall_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaContactCall_":
					toReturn.Add(ContactCallStatusEntity.Relations.ContactCallEntityUsingContactCallStatusId, "ContactCallStatusEntity__", "ContactCall_", JoinHint.None);
					toReturn.Add(ContactCallEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "ContactCall_", string.Empty, JoinHint.None);
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

				case "ContactCall":
					this.ContactCall.Add((ContactCallEntity)relatedEntity);
					break;
				case "ContactMeeting":
					this.ContactMeeting.Add((ContactMeetingEntity)relatedEntity);
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

				case "ContactCall":
					base.PerformRelatedEntityRemoval(this.ContactCall, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ContactMeeting":
					base.PerformRelatedEntityRemoval(this.ContactMeeting, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ContactCall);
			toReturn.Add(this.ContactMeeting);

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
				info.AddValue("_contactCall", ((_contactCall!=null) && (_contactCall.Count>0) && !this.MarkedForDeletion)?_contactCall:null);
				info.AddValue("_contactMeeting", ((_contactMeeting!=null) && (_contactMeeting.Count>0) && !this.MarkedForDeletion)?_contactMeeting:null);
				info.AddValue("_organizationRoleUserCollectionViaContactMeeting", ((_organizationRoleUserCollectionViaContactMeeting!=null) && (_organizationRoleUserCollectionViaContactMeeting.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaContactMeeting:null);
				info.AddValue("_organizationRoleUserCollectionViaContactMeeting_", ((_organizationRoleUserCollectionViaContactMeeting_!=null) && (_organizationRoleUserCollectionViaContactMeeting_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaContactMeeting_:null);
				info.AddValue("_organizationRoleUserCollectionViaContactCall", ((_organizationRoleUserCollectionViaContactCall!=null) && (_organizationRoleUserCollectionViaContactCall.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaContactCall:null);
				info.AddValue("_organizationRoleUserCollectionViaContactCall_", ((_organizationRoleUserCollectionViaContactCall_!=null) && (_organizationRoleUserCollectionViaContactCall_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaContactCall_:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ContactCallStatusFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ContactCallStatusFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ContactCallStatusRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ContactCall' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactCallFields.ContactCallStatusId, null, ComparisonOperator.Equal, this.ContactCallStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ContactMeeting' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactMeeting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactMeetingFields.ContactMeetingStatusId, null, ComparisonOperator.Equal, this.ContactCallStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaContactMeeting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaContactMeeting"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactCallStatusFields.ContactCallStatusId, null, ComparisonOperator.Equal, this.ContactCallStatusId, "ContactCallStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaContactMeeting_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaContactMeeting_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactCallStatusFields.ContactCallStatusId, null, ComparisonOperator.Equal, this.ContactCallStatusId, "ContactCallStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaContactCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaContactCall"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactCallStatusFields.ContactCallStatusId, null, ComparisonOperator.Equal, this.ContactCallStatusId, "ContactCallStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaContactCall_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaContactCall_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactCallStatusFields.ContactCallStatusId, null, ComparisonOperator.Equal, this.ContactCallStatusId, "ContactCallStatusEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ContactCallStatusEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ContactCallStatusEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._contactCall);
			collectionsQueue.Enqueue(this._contactMeeting);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaContactMeeting);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaContactMeeting_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaContactCall);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaContactCall_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._contactCall = (EntityCollection<ContactCallEntity>) collectionsQueue.Dequeue();
			this._contactMeeting = (EntityCollection<ContactMeetingEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaContactMeeting = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaContactMeeting_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaContactCall = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaContactCall_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._contactCall != null)
			{
				return true;
			}
			if (this._contactMeeting != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaContactMeeting != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaContactMeeting_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaContactCall != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaContactCall_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactCallEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactMeetingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactMeetingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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

			toReturn.Add("ContactCall", _contactCall);
			toReturn.Add("ContactMeeting", _contactMeeting);
			toReturn.Add("OrganizationRoleUserCollectionViaContactMeeting", _organizationRoleUserCollectionViaContactMeeting);
			toReturn.Add("OrganizationRoleUserCollectionViaContactMeeting_", _organizationRoleUserCollectionViaContactMeeting_);
			toReturn.Add("OrganizationRoleUserCollectionViaContactCall", _organizationRoleUserCollectionViaContactCall);
			toReturn.Add("OrganizationRoleUserCollectionViaContactCall_", _organizationRoleUserCollectionViaContactCall_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_contactCall!=null)
			{
				_contactCall.ActiveContext = base.ActiveContext;
			}
			if(_contactMeeting!=null)
			{
				_contactMeeting.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaContactMeeting!=null)
			{
				_organizationRoleUserCollectionViaContactMeeting.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaContactMeeting_!=null)
			{
				_organizationRoleUserCollectionViaContactMeeting_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaContactCall!=null)
			{
				_organizationRoleUserCollectionViaContactCall.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaContactCall_!=null)
			{
				_organizationRoleUserCollectionViaContactCall_.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_contactCall = null;
			_contactMeeting = null;
			_organizationRoleUserCollectionViaContactMeeting = null;
			_organizationRoleUserCollectionViaContactMeeting_ = null;
			_organizationRoleUserCollectionViaContactCall = null;
			_organizationRoleUserCollectionViaContactCall_ = null;


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

			_fieldsCustomProperties.Add("ContactCallStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ContactCallStatusEntity</param>
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
		public  static ContactCallStatusRelations Relations
		{
			get	{ return new ContactCallStatusRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactCall' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactCall
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContactCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactCallEntityFactory))),
					(IEntityRelation)GetRelationsForField("ContactCall")[0], (int)Falcon.Data.EntityType.ContactCallStatusEntity, (int)Falcon.Data.EntityType.ContactCallEntity, 0, null, null, null, null, "ContactCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactMeeting' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactMeeting
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContactMeetingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactMeetingEntityFactory))),
					(IEntityRelation)GetRelationsForField("ContactMeeting")[0], (int)Falcon.Data.EntityType.ContactCallStatusEntity, (int)Falcon.Data.EntityType.ContactMeetingEntity, 0, null, null, null, null, "ContactMeeting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaContactMeeting
		{
			get
			{
				IEntityRelation intermediateRelation = ContactCallStatusEntity.Relations.ContactMeetingEntityUsingContactMeetingStatusId;
				intermediateRelation.SetAliases(string.Empty, "ContactMeeting_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ContactCallStatusEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaContactMeeting"), null, "OrganizationRoleUserCollectionViaContactMeeting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaContactMeeting_
		{
			get
			{
				IEntityRelation intermediateRelation = ContactCallStatusEntity.Relations.ContactMeetingEntityUsingContactMeetingStatusId;
				intermediateRelation.SetAliases(string.Empty, "ContactMeeting_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ContactCallStatusEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaContactMeeting_"), null, "OrganizationRoleUserCollectionViaContactMeeting_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaContactCall
		{
			get
			{
				IEntityRelation intermediateRelation = ContactCallStatusEntity.Relations.ContactCallEntityUsingContactCallStatusId;
				intermediateRelation.SetAliases(string.Empty, "ContactCall_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ContactCallStatusEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaContactCall"), null, "OrganizationRoleUserCollectionViaContactCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaContactCall_
		{
			get
			{
				IEntityRelation intermediateRelation = ContactCallStatusEntity.Relations.ContactCallEntityUsingContactCallStatusId;
				intermediateRelation.SetAliases(string.Empty, "ContactCall_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ContactCallStatusEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaContactCall_"), null, "OrganizationRoleUserCollectionViaContactCall_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ContactCallStatusEntity.CustomProperties;}
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
			get { return ContactCallStatusEntity.FieldsCustomProperties;}
		}

		/// <summary> The ContactCallStatusId property of the Entity ContactCallStatus<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblContactCallStatus"."ContactCallStatusID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 ContactCallStatusId
		{
			get { return (System.Int64)GetValue((int)ContactCallStatusFieldIndex.ContactCallStatusId, true); }
			set	{ SetValue((int)ContactCallStatusFieldIndex.ContactCallStatusId, value); }
		}

		/// <summary> The Status property of the Entity ContactCallStatus<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblContactCallStatus"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Status
		{
			get { return (System.String)GetValue((int)ContactCallStatusFieldIndex.Status, true); }
			set	{ SetValue((int)ContactCallStatusFieldIndex.Status, value); }
		}

		/// <summary> The IsActive property of the Entity ContactCallStatus<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblContactCallStatus"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ContactCallStatusFieldIndex.IsActive, true); }
			set	{ SetValue((int)ContactCallStatusFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactCallEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactCallEntity))]
		public virtual EntityCollection<ContactCallEntity> ContactCall
		{
			get
			{
				if(_contactCall==null)
				{
					_contactCall = new EntityCollection<ContactCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactCallEntityFactory)));
					_contactCall.SetContainingEntityInfo(this, "ContactCallStatus");
				}
				return _contactCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactMeetingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactMeetingEntity))]
		public virtual EntityCollection<ContactMeetingEntity> ContactMeeting
		{
			get
			{
				if(_contactMeeting==null)
				{
					_contactMeeting = new EntityCollection<ContactMeetingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactMeetingEntityFactory)));
					_contactMeeting.SetContainingEntityInfo(this, "ContactCallStatus");
				}
				return _contactMeeting;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaContactMeeting
		{
			get
			{
				if(_organizationRoleUserCollectionViaContactMeeting==null)
				{
					_organizationRoleUserCollectionViaContactMeeting = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaContactMeeting.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaContactMeeting;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaContactMeeting_
		{
			get
			{
				if(_organizationRoleUserCollectionViaContactMeeting_==null)
				{
					_organizationRoleUserCollectionViaContactMeeting_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaContactMeeting_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaContactMeeting_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaContactCall
		{
			get
			{
				if(_organizationRoleUserCollectionViaContactCall==null)
				{
					_organizationRoleUserCollectionViaContactCall = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaContactCall.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaContactCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaContactCall_
		{
			get
			{
				if(_organizationRoleUserCollectionViaContactCall_==null)
				{
					_organizationRoleUserCollectionViaContactCall_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaContactCall_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaContactCall_;
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
			get { return (int)Falcon.Data.EntityType.ContactCallStatusEntity; }
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
