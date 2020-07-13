///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Thursday, July 21, 2011 6:44:35 PM
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
	/// Entity class which represents the entity 'MVInvoice'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MVInvoiceEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MVInvoiceItemEntity> _mvinvoiceItem;
		private EntityCollection<MVPaymentInvoiceEntity> _mvpaymentInvoice;
		private EntityCollection<MVPaymentEntity> _mvpaymentCollectionViaMvpaymentInvoice;
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
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name MvinvoiceItem</summary>
			public static readonly string MvinvoiceItem = "MvinvoiceItem";
			/// <summary>Member name MvpaymentInvoice</summary>
			public static readonly string MvpaymentInvoice = "MvpaymentInvoice";
			/// <summary>Member name MvpaymentCollectionViaMvpaymentInvoice</summary>
			public static readonly string MvpaymentCollectionViaMvpaymentInvoice = "MvpaymentCollectionViaMvpaymentInvoice";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MVInvoiceEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MVInvoiceEntity():base("MVInvoiceEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MVInvoiceEntity(IEntityFields2 fields):base("MVInvoiceEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MVInvoiceEntity</param>
		public MVInvoiceEntity(IValidator validator):base("MVInvoiceEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="mvinvoiceId">PK value for MVInvoice which data should be fetched into this MVInvoice object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MVInvoiceEntity(System.Int64 mvinvoiceId):base("MVInvoiceEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MvinvoiceId = mvinvoiceId;
		}

		/// <summary> CTor</summary>
		/// <param name="mvinvoiceId">PK value for MVInvoice which data should be fetched into this MVInvoice object</param>
		/// <param name="validator">The custom validator object for this MVInvoiceEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MVInvoiceEntity(System.Int64 mvinvoiceId, IValidator validator):base("MVInvoiceEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MvinvoiceId = mvinvoiceId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MVInvoiceEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_mvinvoiceItem = (EntityCollection<MVInvoiceItemEntity>)info.GetValue("_mvinvoiceItem", typeof(EntityCollection<MVInvoiceItemEntity>));
				_mvpaymentInvoice = (EntityCollection<MVPaymentInvoiceEntity>)info.GetValue("_mvpaymentInvoice", typeof(EntityCollection<MVPaymentInvoiceEntity>));
				_mvpaymentCollectionViaMvpaymentInvoice = (EntityCollection<MVPaymentEntity>)info.GetValue("_mvpaymentCollectionViaMvpaymentInvoice", typeof(EntityCollection<MVPaymentEntity>));
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
			switch((MVInvoiceFieldIndex)fieldIndex)
			{
				case MVInvoiceFieldIndex.OrganizationRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
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
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "MvinvoiceItem":
					this.MvinvoiceItem.Add((MVInvoiceItemEntity)entity);
					break;
				case "MvpaymentInvoice":
					this.MvpaymentInvoice.Add((MVPaymentInvoiceEntity)entity);
					break;
				case "MvpaymentCollectionViaMvpaymentInvoice":
					this.MvpaymentCollectionViaMvpaymentInvoice.IsReadOnly = false;
					this.MvpaymentCollectionViaMvpaymentInvoice.Add((MVPaymentEntity)entity);
					this.MvpaymentCollectionViaMvpaymentInvoice.IsReadOnly = true;
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
			return MVInvoiceEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser":
					toReturn.Add(MVInvoiceEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId);
					break;
				case "MvinvoiceItem":
					toReturn.Add(MVInvoiceEntity.Relations.MVInvoiceItemEntityUsingMvinvoiceId);
					break;
				case "MvpaymentInvoice":
					toReturn.Add(MVInvoiceEntity.Relations.MVPaymentInvoiceEntityUsingMvinvoiceId);
					break;
				case "MvpaymentCollectionViaMvpaymentInvoice":
					toReturn.Add(MVInvoiceEntity.Relations.MVPaymentInvoiceEntityUsingMvinvoiceId, "MVInvoiceEntity__", "MVPaymentInvoice_", JoinHint.None);
					toReturn.Add(MVPaymentInvoiceEntity.Relations.MVPaymentEntityUsingMvpaymentId, "MVPaymentInvoice_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "MvinvoiceItem":
					this.MvinvoiceItem.Add((MVInvoiceItemEntity)relatedEntity);
					break;
				case "MvpaymentInvoice":
					this.MvpaymentInvoice.Add((MVPaymentInvoiceEntity)relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "MvinvoiceItem":
					base.PerformRelatedEntityRemoval(this.MvinvoiceItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MvpaymentInvoice":
					base.PerformRelatedEntityRemoval(this.MvpaymentInvoice, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.MvinvoiceItem);
			toReturn.Add(this.MvpaymentInvoice);

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
				info.AddValue("_mvinvoiceItem", ((_mvinvoiceItem!=null) && (_mvinvoiceItem.Count>0) && !this.MarkedForDeletion)?_mvinvoiceItem:null);
				info.AddValue("_mvpaymentInvoice", ((_mvpaymentInvoice!=null) && (_mvpaymentInvoice.Count>0) && !this.MarkedForDeletion)?_mvpaymentInvoice:null);
				info.AddValue("_mvpaymentCollectionViaMvpaymentInvoice", ((_mvpaymentCollectionViaMvpaymentInvoice!=null) && (_mvpaymentCollectionViaMvpaymentInvoice.Count>0) && !this.MarkedForDeletion)?_mvpaymentCollectionViaMvpaymentInvoice:null);
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// ApprovalGuid .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCApprovalGuid()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)MVInvoiceFieldIndex.ApprovalGuid], null, ComparisonOperator.Equal)); 
			return filter;
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MVInvoiceFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MVInvoiceFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MVInvoiceRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MVInvoiceItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvinvoiceItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MVInvoiceItemFields.MvinvoiceId, null, ComparisonOperator.Equal, this.MvinvoiceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MVPaymentInvoice' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvpaymentInvoice()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MVPaymentInvoiceFields.MvinvoiceId, null, ComparisonOperator.Equal, this.MvinvoiceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MVPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvpaymentCollectionViaMvpaymentInvoice()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MvpaymentCollectionViaMvpaymentInvoice"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MVInvoiceFields.MvinvoiceId, null, ComparisonOperator.Equal, this.MvinvoiceId, "MVInvoiceEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.OrganizationRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MVInvoiceEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MVInvoiceEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._mvinvoiceItem);
			collectionsQueue.Enqueue(this._mvpaymentInvoice);
			collectionsQueue.Enqueue(this._mvpaymentCollectionViaMvpaymentInvoice);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._mvinvoiceItem = (EntityCollection<MVInvoiceItemEntity>) collectionsQueue.Dequeue();
			this._mvpaymentInvoice = (EntityCollection<MVPaymentInvoiceEntity>) collectionsQueue.Dequeue();
			this._mvpaymentCollectionViaMvpaymentInvoice = (EntityCollection<MVPaymentEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._mvinvoiceItem != null)
			{
				return true;
			}
			if (this._mvpaymentInvoice != null)
			{
				return true;
			}
			if (this._mvpaymentCollectionViaMvpaymentInvoice != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MVInvoiceItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVInvoiceItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MVPaymentInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentInvoiceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MVPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("MvinvoiceItem", _mvinvoiceItem);
			toReturn.Add("MvpaymentInvoice", _mvpaymentInvoice);
			toReturn.Add("MvpaymentCollectionViaMvpaymentInvoice", _mvpaymentCollectionViaMvpaymentInvoice);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_mvinvoiceItem!=null)
			{
				_mvinvoiceItem.ActiveContext = base.ActiveContext;
			}
			if(_mvpaymentInvoice!=null)
			{
				_mvpaymentInvoice.ActiveContext = base.ActiveContext;
			}
			if(_mvpaymentCollectionViaMvpaymentInvoice!=null)
			{
				_mvpaymentCollectionViaMvpaymentInvoice.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_mvinvoiceItem = null;
			_mvpaymentInvoice = null;
			_mvpaymentCollectionViaMvpaymentInvoice = null;
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

			_fieldsCustomProperties.Add("MvinvoiceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ApprovalGuid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ApprovalStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalVendorAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PayPeriodStartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PayPeriodEndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateGenerated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateApproved", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DatePaid", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", MVInvoiceEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, true, signalRelatedEntity, "Mvinvoice", resetFKFields, new int[] { (int)MVInvoiceFieldIndex.OrganizationRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", MVInvoiceEntity.Relations.OrganizationRoleUserEntityUsingOrganizationRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this MVInvoiceEntity</param>
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
		public  static MVInvoiceRelations Relations
		{
			get	{ return new MVInvoiceRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MVInvoiceItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvinvoiceItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MVInvoiceItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVInvoiceItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("MvinvoiceItem")[0], (int)Falcon.Data.EntityType.MVInvoiceEntity, (int)Falcon.Data.EntityType.MVInvoiceItemEntity, 0, null, null, null, null, "MvinvoiceItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MVPaymentInvoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvpaymentInvoice
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MVPaymentInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentInvoiceEntityFactory))),
					(IEntityRelation)GetRelationsForField("MvpaymentInvoice")[0], (int)Falcon.Data.EntityType.MVInvoiceEntity, (int)Falcon.Data.EntityType.MVPaymentInvoiceEntity, 0, null, null, null, null, "MvpaymentInvoice", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MVPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvpaymentCollectionViaMvpaymentInvoice
		{
			get
			{
				IEntityRelation intermediateRelation = MVInvoiceEntity.Relations.MVPaymentInvoiceEntityUsingMvinvoiceId;
				intermediateRelation.SetAliases(string.Empty, "MVPaymentInvoice_");
				return new PrefetchPathElement2(new EntityCollection<MVPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MVInvoiceEntity, (int)Falcon.Data.EntityType.MVPaymentEntity, 0, null, null, GetRelationsForField("MvpaymentCollectionViaMvpaymentInvoice"), null, "MvpaymentCollectionViaMvpaymentInvoice", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.MVInvoiceEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MVInvoiceEntity.CustomProperties;}
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
			get { return MVInvoiceEntity.FieldsCustomProperties;}
		}

		/// <summary> The MvinvoiceId property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."MVInvoiceID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MvinvoiceId
		{
			get { return (System.Int64)GetValue((int)MVInvoiceFieldIndex.MvinvoiceId, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.MvinvoiceId, value); }
		}

		/// <summary> The OrganizationRoleUserId property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."OrganizationRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationRoleUserId
		{
			get { return (System.Int64)GetValue((int)MVInvoiceFieldIndex.OrganizationRoleUserId, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.OrganizationRoleUserId, value); }
		}

		/// <summary> The OrganizationRoleUserName property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."OrganizationRoleUserName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String OrganizationRoleUserName
		{
			get { return (System.String)GetValue((int)MVInvoiceFieldIndex.OrganizationRoleUserName, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.OrganizationRoleUserName, value); }
		}

		/// <summary> The ApprovalGuid property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."ApprovalGuid"<br/>
		/// Table field type characteristics (type, precision, scale, length): UniqueIdentifier, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Guid ApprovalGuid
		{
			get { return (System.Guid)GetValue((int)MVInvoiceFieldIndex.ApprovalGuid, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.ApprovalGuid, value); }
		}

		/// <summary> The ApprovalStatus property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."ApprovalStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte ApprovalStatus
		{
			get { return (System.Byte)GetValue((int)MVInvoiceFieldIndex.ApprovalStatus, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.ApprovalStatus, value); }
		}

		/// <summary> The PaymentStatus property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."PaymentStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte PaymentStatus
		{
			get { return (System.Byte)GetValue((int)MVInvoiceFieldIndex.PaymentStatus, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.PaymentStatus, value); }
		}

		/// <summary> The MedicalVendorName property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."MedicalVendorName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String MedicalVendorName
		{
			get { return (System.String)GetValue((int)MVInvoiceFieldIndex.MedicalVendorName, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.MedicalVendorName, value); }
		}

		/// <summary> The MedicalVendorAddress property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."MedicalVendorAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String MedicalVendorAddress
		{
			get { return (System.String)GetValue((int)MVInvoiceFieldIndex.MedicalVendorAddress, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.MedicalVendorAddress, value); }
		}

		/// <summary> The PayPeriodStartDate property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."PayPeriodStartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime PayPeriodStartDate
		{
			get { return (System.DateTime)GetValue((int)MVInvoiceFieldIndex.PayPeriodStartDate, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.PayPeriodStartDate, value); }
		}

		/// <summary> The PayPeriodEndDate property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."PayPeriodEndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime PayPeriodEndDate
		{
			get { return (System.DateTime)GetValue((int)MVInvoiceFieldIndex.PayPeriodEndDate, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.PayPeriodEndDate, value); }
		}

		/// <summary> The DateGenerated property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."DateGenerated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateGenerated
		{
			get { return (System.DateTime)GetValue((int)MVInvoiceFieldIndex.DateGenerated, true); }
			set	{ SetValue((int)MVInvoiceFieldIndex.DateGenerated, value); }
		}

		/// <summary> The DateApproved property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."DateApproved"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateApproved
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MVInvoiceFieldIndex.DateApproved, false); }
			set	{ SetValue((int)MVInvoiceFieldIndex.DateApproved, value); }
		}

		/// <summary> The DatePaid property of the Entity MVInvoice<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMVInvoice"."DatePaid"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DatePaid
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MVInvoiceFieldIndex.DatePaid, false); }
			set	{ SetValue((int)MVInvoiceFieldIndex.DatePaid, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MVInvoiceItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MVInvoiceItemEntity))]
		public virtual EntityCollection<MVInvoiceItemEntity> MvinvoiceItem
		{
			get
			{
				if(_mvinvoiceItem==null)
				{
					_mvinvoiceItem = new EntityCollection<MVInvoiceItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVInvoiceItemEntityFactory)));
					_mvinvoiceItem.SetContainingEntityInfo(this, "Mvinvoice");
				}
				return _mvinvoiceItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MVPaymentInvoiceEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MVPaymentInvoiceEntity))]
		public virtual EntityCollection<MVPaymentInvoiceEntity> MvpaymentInvoice
		{
			get
			{
				if(_mvpaymentInvoice==null)
				{
					_mvpaymentInvoice = new EntityCollection<MVPaymentInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentInvoiceEntityFactory)));
					_mvpaymentInvoice.SetContainingEntityInfo(this, "Mvinvoice");
				}
				return _mvpaymentInvoice;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MVPaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MVPaymentEntity))]
		public virtual EntityCollection<MVPaymentEntity> MvpaymentCollectionViaMvpaymentInvoice
		{
			get
			{
				if(_mvpaymentCollectionViaMvpaymentInvoice==null)
				{
					_mvpaymentCollectionViaMvpaymentInvoice = new EntityCollection<MVPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentEntityFactory)));
					_mvpaymentCollectionViaMvpaymentInvoice.IsReadOnly=true;
				}
				return _mvpaymentCollectionViaMvpaymentInvoice;
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Mvinvoice");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Mvinvoice");
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
			get { return (int)Falcon.Data.EntityType.MVInvoiceEntity; }
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
