///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Tuesday, January 31, 2012 4:36:54 PM
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
	/// Entity class which represents the entity 'Image'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ImageEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<OrganizationEntity> _organization_;
		private EntityCollection<OrganizationEntity> _organization;
		private EntityCollection<AddressEntity> _addressCollectionViaOrganization_;
		private EntityCollection<AddressEntity> _addressCollectionViaOrganization;
		private EntityCollection<OrganizationTypeEntity> _organizationTypeCollectionViaOrganization_;
		private EntityCollection<OrganizationTypeEntity> _organizationTypeCollectionViaOrganization;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name Organization_</summary>
			public static readonly string Organization_ = "Organization_";
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
			/// <summary>Member name AddressCollectionViaOrganization_</summary>
			public static readonly string AddressCollectionViaOrganization_ = "AddressCollectionViaOrganization_";
			/// <summary>Member name AddressCollectionViaOrganization</summary>
			public static readonly string AddressCollectionViaOrganization = "AddressCollectionViaOrganization";
			/// <summary>Member name OrganizationTypeCollectionViaOrganization_</summary>
			public static readonly string OrganizationTypeCollectionViaOrganization_ = "OrganizationTypeCollectionViaOrganization_";
			/// <summary>Member name OrganizationTypeCollectionViaOrganization</summary>
			public static readonly string OrganizationTypeCollectionViaOrganization = "OrganizationTypeCollectionViaOrganization";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ImageEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ImageEntity():base("ImageEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ImageEntity(IEntityFields2 fields):base("ImageEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ImageEntity</param>
		public ImageEntity(IValidator validator):base("ImageEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="imageId">PK value for Image which data should be fetched into this Image object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ImageEntity(System.Int64 imageId):base("ImageEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ImageId = imageId;
		}

		/// <summary> CTor</summary>
		/// <param name="imageId">PK value for Image which data should be fetched into this Image object</param>
		/// <param name="validator">The custom validator object for this ImageEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ImageEntity(System.Int64 imageId, IValidator validator):base("ImageEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ImageId = imageId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ImageEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_organization_ = (EntityCollection<OrganizationEntity>)info.GetValue("_organization_", typeof(EntityCollection<OrganizationEntity>));
				_organization = (EntityCollection<OrganizationEntity>)info.GetValue("_organization", typeof(EntityCollection<OrganizationEntity>));
				_addressCollectionViaOrganization_ = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaOrganization_", typeof(EntityCollection<AddressEntity>));
				_addressCollectionViaOrganization = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaOrganization", typeof(EntityCollection<AddressEntity>));
				_organizationTypeCollectionViaOrganization_ = (EntityCollection<OrganizationTypeEntity>)info.GetValue("_organizationTypeCollectionViaOrganization_", typeof(EntityCollection<OrganizationTypeEntity>));
				_organizationTypeCollectionViaOrganization = (EntityCollection<OrganizationTypeEntity>)info.GetValue("_organizationTypeCollectionViaOrganization", typeof(EntityCollection<OrganizationTypeEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ImageFieldIndex)fieldIndex)
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

				case "Organization_":
					this.Organization_.Add((OrganizationEntity)entity);
					break;
				case "Organization":
					this.Organization.Add((OrganizationEntity)entity);
					break;
				case "AddressCollectionViaOrganization_":
					this.AddressCollectionViaOrganization_.IsReadOnly = false;
					this.AddressCollectionViaOrganization_.Add((AddressEntity)entity);
					this.AddressCollectionViaOrganization_.IsReadOnly = true;
					break;
				case "AddressCollectionViaOrganization":
					this.AddressCollectionViaOrganization.IsReadOnly = false;
					this.AddressCollectionViaOrganization.Add((AddressEntity)entity);
					this.AddressCollectionViaOrganization.IsReadOnly = true;
					break;
				case "OrganizationTypeCollectionViaOrganization_":
					this.OrganizationTypeCollectionViaOrganization_.IsReadOnly = false;
					this.OrganizationTypeCollectionViaOrganization_.Add((OrganizationTypeEntity)entity);
					this.OrganizationTypeCollectionViaOrganization_.IsReadOnly = true;
					break;
				case "OrganizationTypeCollectionViaOrganization":
					this.OrganizationTypeCollectionViaOrganization.IsReadOnly = false;
					this.OrganizationTypeCollectionViaOrganization.Add((OrganizationTypeEntity)entity);
					this.OrganizationTypeCollectionViaOrganization.IsReadOnly = true;
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
			return ImageEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "Organization_":
					toReturn.Add(ImageEntity.Relations.OrganizationEntityUsingTeamImageId);
					break;
				case "Organization":
					toReturn.Add(ImageEntity.Relations.OrganizationEntityUsingLogoImageId);
					break;
				case "AddressCollectionViaOrganization_":
					toReturn.Add(ImageEntity.Relations.OrganizationEntityUsingTeamImageId, "ImageEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.AddressEntityUsingBusinessAddressId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "AddressCollectionViaOrganization":
					toReturn.Add(ImageEntity.Relations.OrganizationEntityUsingLogoImageId, "ImageEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.AddressEntityUsingBusinessAddressId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "OrganizationTypeCollectionViaOrganization_":
					toReturn.Add(ImageEntity.Relations.OrganizationEntityUsingTeamImageId, "ImageEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "OrganizationTypeCollectionViaOrganization":
					toReturn.Add(ImageEntity.Relations.OrganizationEntityUsingLogoImageId, "ImageEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId, "Organization_", string.Empty, JoinHint.None);
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

				case "Organization_":
					this.Organization_.Add((OrganizationEntity)relatedEntity);
					break;
				case "Organization":
					this.Organization.Add((OrganizationEntity)relatedEntity);
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

				case "Organization_":
					base.PerformRelatedEntityRemoval(this.Organization_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Organization":
					base.PerformRelatedEntityRemoval(this.Organization, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Organization_);
			toReturn.Add(this.Organization);

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
				info.AddValue("_organization_", ((_organization_!=null) && (_organization_.Count>0) && !this.MarkedForDeletion)?_organization_:null);
				info.AddValue("_organization", ((_organization!=null) && (_organization.Count>0) && !this.MarkedForDeletion)?_organization:null);
				info.AddValue("_addressCollectionViaOrganization_", ((_addressCollectionViaOrganization_!=null) && (_addressCollectionViaOrganization_.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaOrganization_:null);
				info.AddValue("_addressCollectionViaOrganization", ((_addressCollectionViaOrganization!=null) && (_addressCollectionViaOrganization.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaOrganization:null);
				info.AddValue("_organizationTypeCollectionViaOrganization_", ((_organizationTypeCollectionViaOrganization_!=null) && (_organizationTypeCollectionViaOrganization_.Count>0) && !this.MarkedForDeletion)?_organizationTypeCollectionViaOrganization_:null);
				info.AddValue("_organizationTypeCollectionViaOrganization", ((_organizationTypeCollectionViaOrganization!=null) && (_organizationTypeCollectionViaOrganization.Count>0) && !this.MarkedForDeletion)?_organizationTypeCollectionViaOrganization:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ImageFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ImageFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ImageRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.TeamImageId, null, ComparisonOperator.Equal, this.ImageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.LogoImageId, null, ComparisonOperator.Equal, this.ImageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaOrganization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaOrganization_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ImageFields.ImageId, null, ComparisonOperator.Equal, this.ImageId, "ImageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ImageFields.ImageId, null, ComparisonOperator.Equal, this.ImageId, "ImageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationTypeCollectionViaOrganization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationTypeCollectionViaOrganization_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ImageFields.ImageId, null, ComparisonOperator.Equal, this.ImageId, "ImageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationTypeCollectionViaOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationTypeCollectionViaOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ImageFields.ImageId, null, ComparisonOperator.Equal, this.ImageId, "ImageEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ImageEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ImageEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._organization_);
			collectionsQueue.Enqueue(this._organization);
			collectionsQueue.Enqueue(this._addressCollectionViaOrganization_);
			collectionsQueue.Enqueue(this._addressCollectionViaOrganization);
			collectionsQueue.Enqueue(this._organizationTypeCollectionViaOrganization_);
			collectionsQueue.Enqueue(this._organizationTypeCollectionViaOrganization);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._organization_ = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._organization = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaOrganization_ = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaOrganization = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._organizationTypeCollectionViaOrganization_ = (EntityCollection<OrganizationTypeEntity>) collectionsQueue.Dequeue();
			this._organizationTypeCollectionViaOrganization = (EntityCollection<OrganizationTypeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._organization_ != null)
			{
				return true;
			}
			if (this._organization != null)
			{
				return true;
			}
			if (this._addressCollectionViaOrganization_ != null)
			{
				return true;
			}
			if (this._addressCollectionViaOrganization != null)
			{
				return true;
			}
			if (this._organizationTypeCollectionViaOrganization_ != null)
			{
				return true;
			}
			if (this._organizationTypeCollectionViaOrganization != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("Organization_", _organization_);
			toReturn.Add("Organization", _organization);
			toReturn.Add("AddressCollectionViaOrganization_", _addressCollectionViaOrganization_);
			toReturn.Add("AddressCollectionViaOrganization", _addressCollectionViaOrganization);
			toReturn.Add("OrganizationTypeCollectionViaOrganization_", _organizationTypeCollectionViaOrganization_);
			toReturn.Add("OrganizationTypeCollectionViaOrganization", _organizationTypeCollectionViaOrganization);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_organization_!=null)
			{
				_organization_.ActiveContext = base.ActiveContext;
			}
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaOrganization_!=null)
			{
				_addressCollectionViaOrganization_.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaOrganization!=null)
			{
				_addressCollectionViaOrganization.ActiveContext = base.ActiveContext;
			}
			if(_organizationTypeCollectionViaOrganization_!=null)
			{
				_organizationTypeCollectionViaOrganization_.ActiveContext = base.ActiveContext;
			}
			if(_organizationTypeCollectionViaOrganization!=null)
			{
				_organizationTypeCollectionViaOrganization.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_organization_ = null;
			_organization = null;
			_addressCollectionViaOrganization_ = null;
			_addressCollectionViaOrganization = null;
			_organizationTypeCollectionViaOrganization_ = null;
			_organizationTypeCollectionViaOrganization = null;


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

			_fieldsCustomProperties.Add("ImageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Title", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FileName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Height", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Width", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrgranizationRoleUserCreatorId", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ImageEntity</param>
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
		public  static ImageRelations Relations
		{
			get	{ return new ImageRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization_")[0], (int)Falcon.Data.EntityType.ImageEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.ImageEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaOrganization_
		{
			get
			{
				IEntityRelation intermediateRelation = ImageEntity.Relations.OrganizationEntityUsingTeamImageId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ImageEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaOrganization_"), null, "AddressCollectionViaOrganization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = ImageEntity.Relations.OrganizationEntityUsingLogoImageId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ImageEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaOrganization"), null, "AddressCollectionViaOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationTypeCollectionViaOrganization_
		{
			get
			{
				IEntityRelation intermediateRelation = ImageEntity.Relations.OrganizationEntityUsingTeamImageId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ImageEntity, (int)Falcon.Data.EntityType.OrganizationTypeEntity, 0, null, null, GetRelationsForField("OrganizationTypeCollectionViaOrganization_"), null, "OrganizationTypeCollectionViaOrganization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationTypeCollectionViaOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = ImageEntity.Relations.OrganizationEntityUsingLogoImageId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ImageEntity, (int)Falcon.Data.EntityType.OrganizationTypeEntity, 0, null, null, GetRelationsForField("OrganizationTypeCollectionViaOrganization"), null, "OrganizationTypeCollectionViaOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ImageEntity.CustomProperties;}
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
			get { return ImageEntity.FieldsCustomProperties;}
		}

		/// <summary> The ImageId property of the Entity Image<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblImage"."ImageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ImageId
		{
			get { return (System.Int64)GetValue((int)ImageFieldIndex.ImageId, true); }
			set	{ SetValue((int)ImageFieldIndex.ImageId, value); }
		}

		/// <summary> The Title property of the Entity Image<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblImage"."Title"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Title
		{
			get { return (System.String)GetValue((int)ImageFieldIndex.Title, true); }
			set	{ SetValue((int)ImageFieldIndex.Title, value); }
		}

		/// <summary> The FileName property of the Entity Image<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblImage"."FileName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FileName
		{
			get { return (System.String)GetValue((int)ImageFieldIndex.FileName, true); }
			set	{ SetValue((int)ImageFieldIndex.FileName, value); }
		}

		/// <summary> The Height property of the Entity Image<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblImage"."Height"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Height
		{
			get { return (Nullable<System.Int32>)GetValue((int)ImageFieldIndex.Height, false); }
			set	{ SetValue((int)ImageFieldIndex.Height, value); }
		}

		/// <summary> The Width property of the Entity Image<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblImage"."Width"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Width
		{
			get { return (Nullable<System.Int32>)GetValue((int)ImageFieldIndex.Width, false); }
			set	{ SetValue((int)ImageFieldIndex.Width, value); }
		}

		/// <summary> The DateCreated property of the Entity Image<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblImage"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ImageFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ImageFieldIndex.DateCreated, value); }
		}

		/// <summary> The OrgranizationRoleUserCreatorId property of the Entity Image<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblImage"."OrganizationRoleUserCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrgranizationRoleUserCreatorId
		{
			get { return (System.Int64)GetValue((int)ImageFieldIndex.OrgranizationRoleUserCreatorId, true); }
			set	{ SetValue((int)ImageFieldIndex.OrgranizationRoleUserCreatorId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> Organization_
		{
			get
			{
				if(_organization_==null)
				{
					_organization_ = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organization_.SetContainingEntityInfo(this, "Image_");
				}
				return _organization_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> Organization
		{
			get
			{
				if(_organization==null)
				{
					_organization = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organization.SetContainingEntityInfo(this, "Image");
				}
				return _organization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaOrganization_
		{
			get
			{
				if(_addressCollectionViaOrganization_==null)
				{
					_addressCollectionViaOrganization_ = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaOrganization_.IsReadOnly=true;
				}
				return _addressCollectionViaOrganization_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaOrganization
		{
			get
			{
				if(_addressCollectionViaOrganization==null)
				{
					_addressCollectionViaOrganization = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaOrganization.IsReadOnly=true;
				}
				return _addressCollectionViaOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationTypeEntity))]
		public virtual EntityCollection<OrganizationTypeEntity> OrganizationTypeCollectionViaOrganization_
		{
			get
			{
				if(_organizationTypeCollectionViaOrganization_==null)
				{
					_organizationTypeCollectionViaOrganization_ = new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory)));
					_organizationTypeCollectionViaOrganization_.IsReadOnly=true;
				}
				return _organizationTypeCollectionViaOrganization_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationTypeEntity))]
		public virtual EntityCollection<OrganizationTypeEntity> OrganizationTypeCollectionViaOrganization
		{
			get
			{
				if(_organizationTypeCollectionViaOrganization==null)
				{
					_organizationTypeCollectionViaOrganization = new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory)));
					_organizationTypeCollectionViaOrganization.IsReadOnly=true;
				}
				return _organizationTypeCollectionViaOrganization;
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
			get { return (int)Falcon.Data.EntityType.ImageEntity; }
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
