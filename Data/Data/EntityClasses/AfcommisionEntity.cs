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
	/// Entity class which represents the entity 'Afcommision'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AfcommisionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private AfaffiliateCampaignEntity _afaffiliateCampaign;
		private AffiliateProfileEntity _affiliateProfile;
		private AfpaymentEntity _afpayment;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AfaffiliateCampaign</summary>
			public static readonly string AfaffiliateCampaign = "AfaffiliateCampaign";
			/// <summary>Member name AffiliateProfile</summary>
			public static readonly string AffiliateProfile = "AffiliateProfile";
			/// <summary>Member name Afpayment</summary>
			public static readonly string Afpayment = "Afpayment";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AfcommisionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AfcommisionEntity():base("AfcommisionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AfcommisionEntity(IEntityFields2 fields):base("AfcommisionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AfcommisionEntity</param>
		public AfcommisionEntity(IValidator validator):base("AfcommisionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="commisionId">PK value for Afcommision which data should be fetched into this Afcommision object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfcommisionEntity(System.Int64 commisionId):base("AfcommisionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CommisionId = commisionId;
		}

		/// <summary> CTor</summary>
		/// <param name="commisionId">PK value for Afcommision which data should be fetched into this Afcommision object</param>
		/// <param name="validator">The custom validator object for this AfcommisionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfcommisionEntity(System.Int64 commisionId, IValidator validator):base("AfcommisionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CommisionId = commisionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AfcommisionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_afaffiliateCampaign = (AfaffiliateCampaignEntity)info.GetValue("_afaffiliateCampaign", typeof(AfaffiliateCampaignEntity));
				if(_afaffiliateCampaign!=null)
				{
					_afaffiliateCampaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_affiliateProfile = (AffiliateProfileEntity)info.GetValue("_affiliateProfile", typeof(AffiliateProfileEntity));
				if(_affiliateProfile!=null)
				{
					_affiliateProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_afpayment = (AfpaymentEntity)info.GetValue("_afpayment", typeof(AfpaymentEntity));
				if(_afpayment!=null)
				{
					_afpayment.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AfcommisionFieldIndex)fieldIndex)
			{
				case AfcommisionFieldIndex.AffiliateId:
					DesetupSyncAffiliateProfile(true, false);
					break;
				case AfcommisionFieldIndex.AffiliateCampaignId:
					DesetupSyncAfaffiliateCampaign(true, false);
					break;
				case AfcommisionFieldIndex.PaymentId:
					DesetupSyncAfpayment(true, false);
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
				case "AfaffiliateCampaign":
					this.AfaffiliateCampaign = (AfaffiliateCampaignEntity)entity;
					break;
				case "AffiliateProfile":
					this.AffiliateProfile = (AffiliateProfileEntity)entity;
					break;
				case "Afpayment":
					this.Afpayment = (AfpaymentEntity)entity;
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
			return AfcommisionEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AfaffiliateCampaign":
					toReturn.Add(AfcommisionEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId);
					break;
				case "AffiliateProfile":
					toReturn.Add(AfcommisionEntity.Relations.AffiliateProfileEntityUsingAffiliateId);
					break;
				case "Afpayment":
					toReturn.Add(AfcommisionEntity.Relations.AfpaymentEntityUsingPaymentId);
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
				case "AfaffiliateCampaign":
					SetupSyncAfaffiliateCampaign(relatedEntity);
					break;
				case "AffiliateProfile":
					SetupSyncAffiliateProfile(relatedEntity);
					break;
				case "Afpayment":
					SetupSyncAfpayment(relatedEntity);
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
				case "AfaffiliateCampaign":
					DesetupSyncAfaffiliateCampaign(false, true);
					break;
				case "AffiliateProfile":
					DesetupSyncAffiliateProfile(false, true);
					break;
				case "Afpayment":
					DesetupSyncAfpayment(false, true);
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
			if(_afaffiliateCampaign!=null)
			{
				toReturn.Add(_afaffiliateCampaign);
			}
			if(_affiliateProfile!=null)
			{
				toReturn.Add(_affiliateProfile);
			}
			if(_afpayment!=null)
			{
				toReturn.Add(_afpayment);
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


				info.AddValue("_afaffiliateCampaign", (!this.MarkedForDeletion?_afaffiliateCampaign:null));
				info.AddValue("_affiliateProfile", (!this.MarkedForDeletion?_affiliateProfile:null));
				info.AddValue("_afpayment", (!this.MarkedForDeletion?_afpayment:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AfcommisionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AfcommisionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AfcommisionRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignFields.AffiliateCampaignId, null, ComparisonOperator.Equal, this.AffiliateCampaignId));
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

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Afpayment' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfpayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfpaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AfcommisionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AfcommisionEntityFactory));
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
			toReturn.Add("AfaffiliateCampaign", _afaffiliateCampaign);
			toReturn.Add("AffiliateProfile", _affiliateProfile);
			toReturn.Add("Afpayment", _afpayment);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_afaffiliateCampaign!=null)
			{
				_afaffiliateCampaign.ActiveContext = base.ActiveContext;
			}
			if(_affiliateProfile!=null)
			{
				_affiliateProfile.ActiveContext = base.ActiveContext;
			}
			if(_afpayment!=null)
			{
				_afpayment.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_afaffiliateCampaign = null;
			_affiliateProfile = null;
			_afpayment = null;

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

			_fieldsCustomProperties.Add("CommisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateCampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Commision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsParentAffilateCommision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPaid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SaleAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPaymentConfirm", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afaffiliateCampaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfaffiliateCampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afaffiliateCampaign, new PropertyChangedEventHandler( OnAfaffiliateCampaignPropertyChanged ), "AfaffiliateCampaign", AfcommisionEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, true, signalRelatedEntity, "Afcommision", resetFKFields, new int[] { (int)AfcommisionFieldIndex.AffiliateCampaignId } );		
			_afaffiliateCampaign = null;
		}

		/// <summary> setups the sync logic for member _afaffiliateCampaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfaffiliateCampaign(IEntity2 relatedEntity)
		{
			if(_afaffiliateCampaign!=relatedEntity)
			{
				DesetupSyncAfaffiliateCampaign(true, true);
				_afaffiliateCampaign = (AfaffiliateCampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afaffiliateCampaign, new PropertyChangedEventHandler( OnAfaffiliateCampaignPropertyChanged ), "AfaffiliateCampaign", AfcommisionEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfaffiliateCampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _affiliateProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAffiliateProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _affiliateProfile, new PropertyChangedEventHandler( OnAffiliateProfilePropertyChanged ), "AffiliateProfile", AfcommisionEntity.Relations.AffiliateProfileEntityUsingAffiliateId, true, signalRelatedEntity, "Afcommision", resetFKFields, new int[] { (int)AfcommisionFieldIndex.AffiliateId } );		
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
				base.PerformSetupSyncRelatedEntity( _affiliateProfile, new PropertyChangedEventHandler( OnAffiliateProfilePropertyChanged ), "AffiliateProfile", AfcommisionEntity.Relations.AffiliateProfileEntityUsingAffiliateId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _afpayment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfpayment(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afpayment, new PropertyChangedEventHandler( OnAfpaymentPropertyChanged ), "Afpayment", AfcommisionEntity.Relations.AfpaymentEntityUsingPaymentId, true, signalRelatedEntity, "Afcommision", resetFKFields, new int[] { (int)AfcommisionFieldIndex.PaymentId } );		
			_afpayment = null;
		}

		/// <summary> setups the sync logic for member _afpayment</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfpayment(IEntity2 relatedEntity)
		{
			if(_afpayment!=relatedEntity)
			{
				DesetupSyncAfpayment(true, true);
				_afpayment = (AfpaymentEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afpayment, new PropertyChangedEventHandler( OnAfpaymentPropertyChanged ), "Afpayment", AfcommisionEntity.Relations.AfpaymentEntityUsingPaymentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfpaymentPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AfcommisionEntity</param>
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
		public  static AfcommisionRelations Relations
		{
			get	{ return new AfcommisionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfaffiliateCampaign")[0], (int)Falcon.Data.EntityType.AfcommisionEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, null, null, "AfaffiliateCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("AffiliateProfile")[0], (int)Falcon.Data.EntityType.AfcommisionEntity, (int)Falcon.Data.EntityType.AffiliateProfileEntity, 0, null, null, null, null, "AffiliateProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afpayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfpayment
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfpaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afpayment")[0], (int)Falcon.Data.EntityType.AfcommisionEntity, (int)Falcon.Data.EntityType.AfpaymentEntity, 0, null, null, null, null, "Afpayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AfcommisionEntity.CustomProperties;}
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
			get { return AfcommisionEntity.FieldsCustomProperties;}
		}

		/// <summary> The CommisionId property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."CommisionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CommisionId
		{
			get { return (System.Int64)GetValue((int)AfcommisionFieldIndex.CommisionId, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.CommisionId, value); }
		}

		/// <summary> The AffiliateId property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."AffiliateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AffiliateId
		{
			get { return (System.Int64)GetValue((int)AfcommisionFieldIndex.AffiliateId, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.AffiliateId, value); }
		}

		/// <summary> The AffiliateCampaignId property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."AffiliateCampaignID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AffiliateCampaignId
		{
			get { return (System.Int64)GetValue((int)AfcommisionFieldIndex.AffiliateCampaignId, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.AffiliateCampaignId, value); }
		}

		/// <summary> The EventCustomerId property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."EventCustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerId
		{
			get { return (System.Int64)GetValue((int)AfcommisionFieldIndex.EventCustomerId, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The Commision property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."Commision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Commision
		{
			get { return (System.Decimal)GetValue((int)AfcommisionFieldIndex.Commision, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.Commision, value); }
		}

		/// <summary> The IsParentAffilateCommision property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."IsParentAffilateCommision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsParentAffilateCommision
		{
			get { return (System.Boolean)GetValue((int)AfcommisionFieldIndex.IsParentAffilateCommision, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.IsParentAffilateCommision, value); }
		}

		/// <summary> The Notes property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)AfcommisionFieldIndex.Notes, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.Notes, value); }
		}

		/// <summary> The CreatedDate property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfcommisionFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)AfcommisionFieldIndex.CreatedDate, value); }
		}

		/// <summary> The LastModifiedDate property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."LastModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfcommisionFieldIndex.LastModifiedDate, false); }
			set	{ SetValue((int)AfcommisionFieldIndex.LastModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AfcommisionFieldIndex.IsActive, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.IsActive, value); }
		}

		/// <summary> The IsPaid property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."IsPaid"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPaid
		{
			get { return (System.Boolean)GetValue((int)AfcommisionFieldIndex.IsPaid, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.IsPaid, value); }
		}

		/// <summary> The SaleAmount property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."SaleAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> SaleAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AfcommisionFieldIndex.SaleAmount, false); }
			set	{ SetValue((int)AfcommisionFieldIndex.SaleAmount, value); }
		}

		/// <summary> The PaymentId property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."PaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PaymentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AfcommisionFieldIndex.PaymentId, false); }
			set	{ SetValue((int)AfcommisionFieldIndex.PaymentId, value); }
		}

		/// <summary> The IsPaymentConfirm property of the Entity Afcommision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFCommision"."IsPaymentConfirm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPaymentConfirm
		{
			get { return (System.Boolean)GetValue((int)AfcommisionFieldIndex.IsPaymentConfirm, true); }
			set	{ SetValue((int)AfcommisionFieldIndex.IsPaymentConfirm, value); }
		}



		/// <summary> Gets / sets related entity of type 'AfaffiliateCampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfaffiliateCampaignEntity AfaffiliateCampaign
		{
			get
			{
				return _afaffiliateCampaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfaffiliateCampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_afaffiliateCampaign != null)
						{
							_afaffiliateCampaign.UnsetRelatedEntity(this, "Afcommision");
						}
					}
					else
					{
						if(_afaffiliateCampaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afcommision");
						}
					}
				}
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
							_affiliateProfile.UnsetRelatedEntity(this, "Afcommision");
						}
					}
					else
					{
						if(_affiliateProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afcommision");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AfpaymentEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfpaymentEntity Afpayment
		{
			get
			{
				return _afpayment;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfpayment(value);
				}
				else
				{
					if(value==null)
					{
						if(_afpayment != null)
						{
							_afpayment.UnsetRelatedEntity(this, "Afcommision");
						}
					}
					else
					{
						if(_afpayment!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Afcommision");
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
			get { return (int)Falcon.Data.EntityType.AfcommisionEntity; }
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
