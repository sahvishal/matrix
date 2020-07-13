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
	/// Entity class which represents the entity 'Afpayment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AfpaymentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AfcommisionEntity> _afcommision;
		private EntityCollection<AfaffiliateCampaignEntity> _afaffiliateCampaignCollectionViaAfcommision;
		private EntityCollection<AffiliateProfileEntity> _affiliateProfileCollectionViaAfcommision;
		private AffiliateProfileEntity _affiliateProfile;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AffiliateProfile</summary>
			public static readonly string AffiliateProfile = "AffiliateProfile";
			/// <summary>Member name Afcommision</summary>
			public static readonly string Afcommision = "Afcommision";
			/// <summary>Member name AfaffiliateCampaignCollectionViaAfcommision</summary>
			public static readonly string AfaffiliateCampaignCollectionViaAfcommision = "AfaffiliateCampaignCollectionViaAfcommision";
			/// <summary>Member name AffiliateProfileCollectionViaAfcommision</summary>
			public static readonly string AffiliateProfileCollectionViaAfcommision = "AffiliateProfileCollectionViaAfcommision";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AfpaymentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AfpaymentEntity():base("AfpaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AfpaymentEntity(IEntityFields2 fields):base("AfpaymentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AfpaymentEntity</param>
		public AfpaymentEntity(IValidator validator):base("AfpaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="paymentId">PK value for Afpayment which data should be fetched into this Afpayment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfpaymentEntity(System.Int64 paymentId):base("AfpaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PaymentId = paymentId;
		}

		/// <summary> CTor</summary>
		/// <param name="paymentId">PK value for Afpayment which data should be fetched into this Afpayment object</param>
		/// <param name="validator">The custom validator object for this AfpaymentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfpaymentEntity(System.Int64 paymentId, IValidator validator):base("AfpaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PaymentId = paymentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AfpaymentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_afcommision = (EntityCollection<AfcommisionEntity>)info.GetValue("_afcommision", typeof(EntityCollection<AfcommisionEntity>));
				_afaffiliateCampaignCollectionViaAfcommision = (EntityCollection<AfaffiliateCampaignEntity>)info.GetValue("_afaffiliateCampaignCollectionViaAfcommision", typeof(EntityCollection<AfaffiliateCampaignEntity>));
				_affiliateProfileCollectionViaAfcommision = (EntityCollection<AffiliateProfileEntity>)info.GetValue("_affiliateProfileCollectionViaAfcommision", typeof(EntityCollection<AffiliateProfileEntity>));
				_affiliateProfile = (AffiliateProfileEntity)info.GetValue("_affiliateProfile", typeof(AffiliateProfileEntity));
				if(_affiliateProfile!=null)
				{
					_affiliateProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AfpaymentFieldIndex)fieldIndex)
			{
				case AfpaymentFieldIndex.AffiliateId:
					DesetupSyncAffiliateProfile(true, false);
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
				case "AffiliateProfile":
					this.AffiliateProfile = (AffiliateProfileEntity)entity;
					break;
				case "Afcommision":
					this.Afcommision.Add((AfcommisionEntity)entity);
					break;
				case "AfaffiliateCampaignCollectionViaAfcommision":
					this.AfaffiliateCampaignCollectionViaAfcommision.IsReadOnly = false;
					this.AfaffiliateCampaignCollectionViaAfcommision.Add((AfaffiliateCampaignEntity)entity);
					this.AfaffiliateCampaignCollectionViaAfcommision.IsReadOnly = true;
					break;
				case "AffiliateProfileCollectionViaAfcommision":
					this.AffiliateProfileCollectionViaAfcommision.IsReadOnly = false;
					this.AffiliateProfileCollectionViaAfcommision.Add((AffiliateProfileEntity)entity);
					this.AffiliateProfileCollectionViaAfcommision.IsReadOnly = true;
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
			return AfpaymentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AffiliateProfile":
					toReturn.Add(AfpaymentEntity.Relations.AffiliateProfileEntityUsingAffiliateId);
					break;
				case "Afcommision":
					toReturn.Add(AfpaymentEntity.Relations.AfcommisionEntityUsingPaymentId);
					break;
				case "AfaffiliateCampaignCollectionViaAfcommision":
					toReturn.Add(AfpaymentEntity.Relations.AfcommisionEntityUsingPaymentId, "AfpaymentEntity__", "Afcommision_", JoinHint.None);
					toReturn.Add(AfcommisionEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, "Afcommision_", string.Empty, JoinHint.None);
					break;
				case "AffiliateProfileCollectionViaAfcommision":
					toReturn.Add(AfpaymentEntity.Relations.AfcommisionEntityUsingPaymentId, "AfpaymentEntity__", "Afcommision_", JoinHint.None);
					toReturn.Add(AfcommisionEntity.Relations.AffiliateProfileEntityUsingAffiliateId, "Afcommision_", string.Empty, JoinHint.None);
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
				case "AffiliateProfile":
					SetupSyncAffiliateProfile(relatedEntity);
					break;
				case "Afcommision":
					this.Afcommision.Add((AfcommisionEntity)relatedEntity);
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
				case "AffiliateProfile":
					DesetupSyncAffiliateProfile(false, true);
					break;
				case "Afcommision":
					base.PerformRelatedEntityRemoval(this.Afcommision, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_affiliateProfile!=null)
			{
				toReturn.Add(_affiliateProfile);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Afcommision);

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
				info.AddValue("_afcommision", ((_afcommision!=null) && (_afcommision.Count>0) && !this.MarkedForDeletion)?_afcommision:null);
				info.AddValue("_afaffiliateCampaignCollectionViaAfcommision", ((_afaffiliateCampaignCollectionViaAfcommision!=null) && (_afaffiliateCampaignCollectionViaAfcommision.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignCollectionViaAfcommision:null);
				info.AddValue("_affiliateProfileCollectionViaAfcommision", ((_affiliateProfileCollectionViaAfcommision!=null) && (_affiliateProfileCollectionViaAfcommision.Count>0) && !this.MarkedForDeletion)?_affiliateProfileCollectionViaAfcommision:null);
				info.AddValue("_affiliateProfile", (!this.MarkedForDeletion?_affiliateProfile:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AfpaymentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AfpaymentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AfpaymentRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcommision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcommision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcommisionFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignCollectionViaAfcommision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfaffiliateCampaignCollectionViaAfcommision"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfpaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "AfpaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AffiliateProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAffiliateProfileCollectionViaAfcommision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AffiliateProfileCollectionViaAfcommision"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfpaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "AfpaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AffiliateProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAffiliateProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AffiliateProfileFields.AffiliateId, null, ComparisonOperator.Equal, this.AffiliateId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AfpaymentEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AfpaymentEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._afcommision);
			collectionsQueue.Enqueue(this._afaffiliateCampaignCollectionViaAfcommision);
			collectionsQueue.Enqueue(this._affiliateProfileCollectionViaAfcommision);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._afcommision = (EntityCollection<AfcommisionEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaignCollectionViaAfcommision = (EntityCollection<AfaffiliateCampaignEntity>) collectionsQueue.Dequeue();
			this._affiliateProfileCollectionViaAfcommision = (EntityCollection<AffiliateProfileEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._afcommision != null)
			{
				return true;
			}
			if (this._afaffiliateCampaignCollectionViaAfcommision != null)
			{
				return true;
			}
			if (this._affiliateProfileCollectionViaAfcommision != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcommisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcommisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AffiliateProfile", _affiliateProfile);
			toReturn.Add("Afcommision", _afcommision);
			toReturn.Add("AfaffiliateCampaignCollectionViaAfcommision", _afaffiliateCampaignCollectionViaAfcommision);
			toReturn.Add("AffiliateProfileCollectionViaAfcommision", _affiliateProfileCollectionViaAfcommision);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_afcommision!=null)
			{
				_afcommision.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaignCollectionViaAfcommision!=null)
			{
				_afaffiliateCampaignCollectionViaAfcommision.ActiveContext = base.ActiveContext;
			}
			if(_affiliateProfileCollectionViaAfcommision!=null)
			{
				_affiliateProfileCollectionViaAfcommision.ActiveContext = base.ActiveContext;
			}
			if(_affiliateProfile!=null)
			{
				_affiliateProfile.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_afcommision = null;
			_afaffiliateCampaignCollectionViaAfcommision = null;
			_affiliateProfileCollectionViaAfcommision = null;
			_affiliateProfile = null;

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

			_fieldsCustomProperties.Add("PaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Amount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CommisionStartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CommisionEndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliatePaymentMethod", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentMode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvoiceNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NameOnCheck", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _affiliateProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAffiliateProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _affiliateProfile, new PropertyChangedEventHandler( OnAffiliateProfilePropertyChanged ), "AffiliateProfile", AfpaymentEntity.Relations.AffiliateProfileEntityUsingAffiliateId, true, signalRelatedEntity, "Afpayment", resetFKFields, new int[] { (int)AfpaymentFieldIndex.AffiliateId } );		
			_affiliateProfile = null;
		}

		/// <summary> setups the sync logic for member _affiliateProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAffiliateProfile(IEntity2 relatedEntity)
		{
			if(_affiliateProfile!=relatedEntity)
			{
				DesetupSyncAffiliateProfile(true, true);
				_affiliateProfile = (AffiliateProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _affiliateProfile, new PropertyChangedEventHandler( OnAffiliateProfilePropertyChanged ), "AffiliateProfile", AfpaymentEntity.Relations.AffiliateProfileEntityUsingAffiliateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAffiliateProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AfpaymentEntity</param>
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
		public  static AfpaymentRelations Relations
		{
			get	{ return new AfpaymentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcommision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcommision
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfcommisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcommisionEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afcommision")[0], (int)Falcon.Data.EntityType.AfpaymentEntity, (int)Falcon.Data.EntityType.AfcommisionEntity, 0, null, null, null, null, "Afcommision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignCollectionViaAfcommision
		{
			get
			{
				IEntityRelation intermediateRelation = AfpaymentEntity.Relations.AfcommisionEntityUsingPaymentId;
				intermediateRelation.SetAliases(string.Empty, "Afcommision_");
				return new PrefetchPathElement2(new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfpaymentEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, GetRelationsForField("AfaffiliateCampaignCollectionViaAfcommision"), null, "AfaffiliateCampaignCollectionViaAfcommision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AffiliateProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAffiliateProfileCollectionViaAfcommision
		{
			get
			{
				IEntityRelation intermediateRelation = AfpaymentEntity.Relations.AfcommisionEntityUsingPaymentId;
				intermediateRelation.SetAliases(string.Empty, "Afcommision_");
				return new PrefetchPathElement2(new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfpaymentEntity, (int)Falcon.Data.EntityType.AffiliateProfileEntity, 0, null, null, GetRelationsForField("AffiliateProfileCollectionViaAfcommision"), null, "AffiliateProfileCollectionViaAfcommision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AffiliateProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAffiliateProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("AffiliateProfile")[0], (int)Falcon.Data.EntityType.AfpaymentEntity, (int)Falcon.Data.EntityType.AffiliateProfileEntity, 0, null, null, null, null, "AffiliateProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AfpaymentEntity.CustomProperties;}
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
			get { return AfpaymentEntity.FieldsCustomProperties;}
		}

		/// <summary> The PaymentId property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."PaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PaymentId
		{
			get { return (System.Int64)GetValue((int)AfpaymentFieldIndex.PaymentId, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.PaymentId, value); }
		}

		/// <summary> The AffiliateId property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."AffiliateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AffiliateId
		{
			get { return (System.Int64)GetValue((int)AfpaymentFieldIndex.AffiliateId, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.AffiliateId, value); }
		}

		/// <summary> The Amount property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."Amount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Amount
		{
			get { return (System.Decimal)GetValue((int)AfpaymentFieldIndex.Amount, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.Amount, value); }
		}

		/// <summary> The PaymentDate property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."PaymentDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> PaymentDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfpaymentFieldIndex.PaymentDate, false); }
			set	{ SetValue((int)AfpaymentFieldIndex.PaymentDate, value); }
		}

		/// <summary> The CommisionStartDate property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."CommisionStartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CommisionStartDate
		{
			get { return (System.DateTime)GetValue((int)AfpaymentFieldIndex.CommisionStartDate, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.CommisionStartDate, value); }
		}

		/// <summary> The CommisionEndDate property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."CommisionEndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CommisionEndDate
		{
			get { return (System.DateTime)GetValue((int)AfpaymentFieldIndex.CommisionEndDate, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.CommisionEndDate, value); }
		}

		/// <summary> The AffiliatePaymentMethod property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."AffiliatePaymentMethod"<br/>
		/// Table field type characteristics (type, precision, scale, length): NChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AffiliatePaymentMethod
		{
			get { return (System.String)GetValue((int)AfpaymentFieldIndex.AffiliatePaymentMethod, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.AffiliatePaymentMethod, value); }
		}

		/// <summary> The PaymentMode property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."PaymentMode"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PaymentMode
		{
			get { return (Nullable<System.Int32>)GetValue((int)AfpaymentFieldIndex.PaymentMode, false); }
			set	{ SetValue((int)AfpaymentFieldIndex.PaymentMode, value); }
		}

		/// <summary> The Notes property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)AfpaymentFieldIndex.Notes, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.Notes, value); }
		}

		/// <summary> The CreatedDate property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfpaymentFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)AfpaymentFieldIndex.CreatedDate, value); }
		}

		/// <summary> The LastModifiedDate property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."LastModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfpaymentFieldIndex.LastModifiedDate, false); }
			set	{ SetValue((int)AfpaymentFieldIndex.LastModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AfpaymentFieldIndex.IsActive, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.IsActive, value); }
		}

		/// <summary> The InvoiceNumber property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."InvoiceNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String InvoiceNumber
		{
			get { return (System.String)GetValue((int)AfpaymentFieldIndex.InvoiceNumber, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.InvoiceNumber, value); }
		}

		/// <summary> The CheckNumber property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."CheckNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CheckNumber
		{
			get { return (System.String)GetValue((int)AfpaymentFieldIndex.CheckNumber, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.CheckNumber, value); }
		}

		/// <summary> The NameOnCheck property of the Entity Afpayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFPayment"."NameOnCheck"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String NameOnCheck
		{
			get { return (System.String)GetValue((int)AfpaymentFieldIndex.NameOnCheck, true); }
			set	{ SetValue((int)AfpaymentFieldIndex.NameOnCheck, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcommisionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcommisionEntity))]
		public virtual EntityCollection<AfcommisionEntity> Afcommision
		{
			get
			{
				if(_afcommision==null)
				{
					_afcommision = new EntityCollection<AfcommisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcommisionEntityFactory)));
					_afcommision.SetContainingEntityInfo(this, "Afpayment");
				}
				return _afcommision;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfaffiliateCampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfaffiliateCampaignEntity))]
		public virtual EntityCollection<AfaffiliateCampaignEntity> AfaffiliateCampaignCollectionViaAfcommision
		{
			get
			{
				if(_afaffiliateCampaignCollectionViaAfcommision==null)
				{
					_afaffiliateCampaignCollectionViaAfcommision = new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory)));
					_afaffiliateCampaignCollectionViaAfcommision.IsReadOnly=true;
				}
				return _afaffiliateCampaignCollectionViaAfcommision;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AffiliateProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AffiliateProfileEntity))]
		public virtual EntityCollection<AffiliateProfileEntity> AffiliateProfileCollectionViaAfcommision
		{
			get
			{
				if(_affiliateProfileCollectionViaAfcommision==null)
				{
					_affiliateProfileCollectionViaAfcommision = new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory)));
					_affiliateProfileCollectionViaAfcommision.IsReadOnly=true;
				}
				return _affiliateProfileCollectionViaAfcommision;
			}
		}

		/// <summary> Gets / sets related entity of type 'AffiliateProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AffiliateProfileEntity AffiliateProfile
		{
			get
			{
				return _affiliateProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAffiliateProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_affiliateProfile != null)
						{
							_affiliateProfile.UnsetRelatedEntity(this, "Afpayment");
						}
					}
					else
					{
						if(_affiliateProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afpayment");
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
			get { return (int)Falcon.Data.EntityType.AfpaymentEntity; }
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
