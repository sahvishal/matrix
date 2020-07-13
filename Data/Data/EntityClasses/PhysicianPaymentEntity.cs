///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'PhysicianPayment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PhysicianPaymentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MVPaymentCheckDetailsEntity> _mvpaymentCheckDetails;
		private EntityCollection<PhysicianPaymentInvoiceEntity> _physicianPaymentInvoice;
		private EntityCollection<CheckEntity> _checkCollectionViaMvpaymentCheckDetails;
		private EntityCollection<PhysicianInvoiceEntity> _physicianInvoiceCollectionViaPhysicianPaymentInvoice;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name MvpaymentCheckDetails</summary>
			public static readonly string MvpaymentCheckDetails = "MvpaymentCheckDetails";
			/// <summary>Member name PhysicianPaymentInvoice</summary>
			public static readonly string PhysicianPaymentInvoice = "PhysicianPaymentInvoice";
			/// <summary>Member name CheckCollectionViaMvpaymentCheckDetails</summary>
			public static readonly string CheckCollectionViaMvpaymentCheckDetails = "CheckCollectionViaMvpaymentCheckDetails";
			/// <summary>Member name PhysicianInvoiceCollectionViaPhysicianPaymentInvoice</summary>
			public static readonly string PhysicianInvoiceCollectionViaPhysicianPaymentInvoice = "PhysicianInvoiceCollectionViaPhysicianPaymentInvoice";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PhysicianPaymentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PhysicianPaymentEntity():base("PhysicianPaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PhysicianPaymentEntity(IEntityFields2 fields):base("PhysicianPaymentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PhysicianPaymentEntity</param>
		public PhysicianPaymentEntity(IValidator validator):base("PhysicianPaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="physicianPaymentId">PK value for PhysicianPayment which data should be fetched into this PhysicianPayment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianPaymentEntity(System.Int64 physicianPaymentId):base("PhysicianPaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PhysicianPaymentId = physicianPaymentId;
		}

		/// <summary> CTor</summary>
		/// <param name="physicianPaymentId">PK value for PhysicianPayment which data should be fetched into this PhysicianPayment object</param>
		/// <param name="validator">The custom validator object for this PhysicianPaymentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianPaymentEntity(System.Int64 physicianPaymentId, IValidator validator):base("PhysicianPaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PhysicianPaymentId = physicianPaymentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PhysicianPaymentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_mvpaymentCheckDetails = (EntityCollection<MVPaymentCheckDetailsEntity>)info.GetValue("_mvpaymentCheckDetails", typeof(EntityCollection<MVPaymentCheckDetailsEntity>));
				_physicianPaymentInvoice = (EntityCollection<PhysicianPaymentInvoiceEntity>)info.GetValue("_physicianPaymentInvoice", typeof(EntityCollection<PhysicianPaymentInvoiceEntity>));
				_checkCollectionViaMvpaymentCheckDetails = (EntityCollection<CheckEntity>)info.GetValue("_checkCollectionViaMvpaymentCheckDetails", typeof(EntityCollection<CheckEntity>));
				_physicianInvoiceCollectionViaPhysicianPaymentInvoice = (EntityCollection<PhysicianInvoiceEntity>)info.GetValue("_physicianInvoiceCollectionViaPhysicianPaymentInvoice", typeof(EntityCollection<PhysicianInvoiceEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((PhysicianPaymentFieldIndex)fieldIndex)
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

				case "MvpaymentCheckDetails":
					this.MvpaymentCheckDetails.Add((MVPaymentCheckDetailsEntity)entity);
					break;
				case "PhysicianPaymentInvoice":
					this.PhysicianPaymentInvoice.Add((PhysicianPaymentInvoiceEntity)entity);
					break;
				case "CheckCollectionViaMvpaymentCheckDetails":
					this.CheckCollectionViaMvpaymentCheckDetails.IsReadOnly = false;
					this.CheckCollectionViaMvpaymentCheckDetails.Add((CheckEntity)entity);
					this.CheckCollectionViaMvpaymentCheckDetails.IsReadOnly = true;
					break;
				case "PhysicianInvoiceCollectionViaPhysicianPaymentInvoice":
					this.PhysicianInvoiceCollectionViaPhysicianPaymentInvoice.IsReadOnly = false;
					this.PhysicianInvoiceCollectionViaPhysicianPaymentInvoice.Add((PhysicianInvoiceEntity)entity);
					this.PhysicianInvoiceCollectionViaPhysicianPaymentInvoice.IsReadOnly = true;
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
			return PhysicianPaymentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "MvpaymentCheckDetails":
					toReturn.Add(PhysicianPaymentEntity.Relations.MVPaymentCheckDetailsEntityUsingMvpaymentId);
					break;
				case "PhysicianPaymentInvoice":
					toReturn.Add(PhysicianPaymentEntity.Relations.PhysicianPaymentInvoiceEntityUsingPhysicianPaymentId);
					break;
				case "CheckCollectionViaMvpaymentCheckDetails":
					toReturn.Add(PhysicianPaymentEntity.Relations.MVPaymentCheckDetailsEntityUsingMvpaymentId, "PhysicianPaymentEntity__", "MVPaymentCheckDetails_", JoinHint.None);
					toReturn.Add(MVPaymentCheckDetailsEntity.Relations.CheckEntityUsingCheckId, "MVPaymentCheckDetails_", string.Empty, JoinHint.None);
					break;
				case "PhysicianInvoiceCollectionViaPhysicianPaymentInvoice":
					toReturn.Add(PhysicianPaymentEntity.Relations.PhysicianPaymentInvoiceEntityUsingPhysicianPaymentId, "PhysicianPaymentEntity__", "PhysicianPaymentInvoice_", JoinHint.None);
					toReturn.Add(PhysicianPaymentInvoiceEntity.Relations.PhysicianInvoiceEntityUsingPhysicianInvoiceId, "PhysicianPaymentInvoice_", string.Empty, JoinHint.None);
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

				case "MvpaymentCheckDetails":
					this.MvpaymentCheckDetails.Add((MVPaymentCheckDetailsEntity)relatedEntity);
					break;
				case "PhysicianPaymentInvoice":
					this.PhysicianPaymentInvoice.Add((PhysicianPaymentInvoiceEntity)relatedEntity);
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

				case "MvpaymentCheckDetails":
					base.PerformRelatedEntityRemoval(this.MvpaymentCheckDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianPaymentInvoice":
					base.PerformRelatedEntityRemoval(this.PhysicianPaymentInvoice, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.MvpaymentCheckDetails);
			toReturn.Add(this.PhysicianPaymentInvoice);

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
				info.AddValue("_mvpaymentCheckDetails", ((_mvpaymentCheckDetails!=null) && (_mvpaymentCheckDetails.Count>0) && !this.MarkedForDeletion)?_mvpaymentCheckDetails:null);
				info.AddValue("_physicianPaymentInvoice", ((_physicianPaymentInvoice!=null) && (_physicianPaymentInvoice.Count>0) && !this.MarkedForDeletion)?_physicianPaymentInvoice:null);
				info.AddValue("_checkCollectionViaMvpaymentCheckDetails", ((_checkCollectionViaMvpaymentCheckDetails!=null) && (_checkCollectionViaMvpaymentCheckDetails.Count>0) && !this.MarkedForDeletion)?_checkCollectionViaMvpaymentCheckDetails:null);
				info.AddValue("_physicianInvoiceCollectionViaPhysicianPaymentInvoice", ((_physicianInvoiceCollectionViaPhysicianPaymentInvoice!=null) && (_physicianInvoiceCollectionViaPhysicianPaymentInvoice.Count>0) && !this.MarkedForDeletion)?_physicianInvoiceCollectionViaPhysicianPaymentInvoice:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PhysicianPaymentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PhysicianPaymentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PhysicianPaymentRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MVPaymentCheckDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvpaymentCheckDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MVPaymentCheckDetailsFields.MvpaymentId, null, ComparisonOperator.Equal, this.PhysicianPaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianPaymentInvoice' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianPaymentInvoice()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianPaymentInvoiceFields.PhysicianPaymentId, null, ComparisonOperator.Equal, this.PhysicianPaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Check' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckCollectionViaMvpaymentCheckDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckCollectionViaMvpaymentCheckDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianPaymentFields.PhysicianPaymentId, null, ComparisonOperator.Equal, this.PhysicianPaymentId, "PhysicianPaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianInvoice' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianInvoiceCollectionViaPhysicianPaymentInvoice()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianInvoiceCollectionViaPhysicianPaymentInvoice"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianPaymentFields.PhysicianPaymentId, null, ComparisonOperator.Equal, this.PhysicianPaymentId, "PhysicianPaymentEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PhysicianPaymentEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPaymentEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._mvpaymentCheckDetails);
			collectionsQueue.Enqueue(this._physicianPaymentInvoice);
			collectionsQueue.Enqueue(this._checkCollectionViaMvpaymentCheckDetails);
			collectionsQueue.Enqueue(this._physicianInvoiceCollectionViaPhysicianPaymentInvoice);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._mvpaymentCheckDetails = (EntityCollection<MVPaymentCheckDetailsEntity>) collectionsQueue.Dequeue();
			this._physicianPaymentInvoice = (EntityCollection<PhysicianPaymentInvoiceEntity>) collectionsQueue.Dequeue();
			this._checkCollectionViaMvpaymentCheckDetails = (EntityCollection<CheckEntity>) collectionsQueue.Dequeue();
			this._physicianInvoiceCollectionViaPhysicianPaymentInvoice = (EntityCollection<PhysicianInvoiceEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._mvpaymentCheckDetails != null)
			{
				return true;
			}
			if (this._physicianPaymentInvoice != null)
			{
				return true;
			}
			if (this._checkCollectionViaMvpaymentCheckDetails != null)
			{
				return true;
			}
			if (this._physicianInvoiceCollectionViaPhysicianPaymentInvoice != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MVPaymentCheckDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentCheckDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianPaymentInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPaymentInvoiceEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("MvpaymentCheckDetails", _mvpaymentCheckDetails);
			toReturn.Add("PhysicianPaymentInvoice", _physicianPaymentInvoice);
			toReturn.Add("CheckCollectionViaMvpaymentCheckDetails", _checkCollectionViaMvpaymentCheckDetails);
			toReturn.Add("PhysicianInvoiceCollectionViaPhysicianPaymentInvoice", _physicianInvoiceCollectionViaPhysicianPaymentInvoice);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_mvpaymentCheckDetails!=null)
			{
				_mvpaymentCheckDetails.ActiveContext = base.ActiveContext;
			}
			if(_physicianPaymentInvoice!=null)
			{
				_physicianPaymentInvoice.ActiveContext = base.ActiveContext;
			}
			if(_checkCollectionViaMvpaymentCheckDetails!=null)
			{
				_checkCollectionViaMvpaymentCheckDetails.ActiveContext = base.ActiveContext;
			}
			if(_physicianInvoiceCollectionViaPhysicianPaymentInvoice!=null)
			{
				_physicianInvoiceCollectionViaPhysicianPaymentInvoice.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_mvpaymentCheckDetails = null;
			_physicianPaymentInvoice = null;
			_checkCollectionViaMvpaymentCheckDetails = null;
			_physicianInvoiceCollectionViaPhysicianPaymentInvoice = null;


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

			_fieldsCustomProperties.Add("PhysicianPaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReferenceNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DataRecoderCreatorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DataRecoderModifierId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModifed", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PhysicianPaymentEntity</param>
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
		public  static PhysicianPaymentRelations Relations
		{
			get	{ return new PhysicianPaymentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MVPaymentCheckDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvpaymentCheckDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MVPaymentCheckDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentCheckDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("MvpaymentCheckDetails")[0], (int)Falcon.Data.EntityType.PhysicianPaymentEntity, (int)Falcon.Data.EntityType.MVPaymentCheckDetailsEntity, 0, null, null, null, null, "MvpaymentCheckDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianPaymentInvoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianPaymentInvoice
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianPaymentInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPaymentInvoiceEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianPaymentInvoice")[0], (int)Falcon.Data.EntityType.PhysicianPaymentEntity, (int)Falcon.Data.EntityType.PhysicianPaymentInvoiceEntity, 0, null, null, null, null, "PhysicianPaymentInvoice", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Check' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckCollectionViaMvpaymentCheckDetails
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianPaymentEntity.Relations.MVPaymentCheckDetailsEntityUsingMvpaymentId;
				intermediateRelation.SetAliases(string.Empty, "MVPaymentCheckDetails_");
				return new PrefetchPathElement2(new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianPaymentEntity, (int)Falcon.Data.EntityType.CheckEntity, 0, null, null, GetRelationsForField("CheckCollectionViaMvpaymentCheckDetails"), null, "CheckCollectionViaMvpaymentCheckDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianInvoice' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianInvoiceCollectionViaPhysicianPaymentInvoice
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianPaymentEntity.Relations.PhysicianPaymentInvoiceEntityUsingPhysicianPaymentId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianPaymentInvoice_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianPaymentEntity, (int)Falcon.Data.EntityType.PhysicianInvoiceEntity, 0, null, null, GetRelationsForField("PhysicianInvoiceCollectionViaPhysicianPaymentInvoice"), null, "PhysicianInvoiceCollectionViaPhysicianPaymentInvoice", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PhysicianPaymentEntity.CustomProperties;}
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
			get { return PhysicianPaymentEntity.FieldsCustomProperties;}
		}

		/// <summary> The PhysicianPaymentId property of the Entity PhysicianPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianPayment"."PhysicianPaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 PhysicianPaymentId
		{
			get { return (System.Int64)GetValue((int)PhysicianPaymentFieldIndex.PhysicianPaymentId, true); }
			set	{ SetValue((int)PhysicianPaymentFieldIndex.PhysicianPaymentId, value); }
		}

		/// <summary> The ReferenceNumber property of the Entity PhysicianPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianPayment"."ReferenceNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ReferenceNumber
		{
			get { return (System.String)GetValue((int)PhysicianPaymentFieldIndex.ReferenceNumber, true); }
			set	{ SetValue((int)PhysicianPaymentFieldIndex.ReferenceNumber, value); }
		}

		/// <summary> The PaymentStatus property of the Entity PhysicianPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianPayment"."PaymentStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte PaymentStatus
		{
			get { return (System.Byte)GetValue((int)PhysicianPaymentFieldIndex.PaymentStatus, true); }
			set	{ SetValue((int)PhysicianPaymentFieldIndex.PaymentStatus, value); }
		}

		/// <summary> The Notes property of the Entity PhysicianPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianPayment"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)PhysicianPaymentFieldIndex.Notes, true); }
			set	{ SetValue((int)PhysicianPaymentFieldIndex.Notes, value); }
		}

		/// <summary> The DataRecoderCreatorId property of the Entity PhysicianPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianPayment"."DataRecoderCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 DataRecoderCreatorId
		{
			get { return (System.Int64)GetValue((int)PhysicianPaymentFieldIndex.DataRecoderCreatorId, true); }
			set	{ SetValue((int)PhysicianPaymentFieldIndex.DataRecoderCreatorId, value); }
		}

		/// <summary> The DataRecoderModifierId property of the Entity PhysicianPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianPayment"."DataRecoderModifierID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DataRecoderModifierId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PhysicianPaymentFieldIndex.DataRecoderModifierId, false); }
			set	{ SetValue((int)PhysicianPaymentFieldIndex.DataRecoderModifierId, value); }
		}

		/// <summary> The DateCreated property of the Entity PhysicianPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianPayment"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PhysicianPaymentFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PhysicianPaymentFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModifed property of the Entity PhysicianPayment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianPayment"."DateModifed"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModifed
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PhysicianPaymentFieldIndex.DateModifed, false); }
			set	{ SetValue((int)PhysicianPaymentFieldIndex.DateModifed, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MVPaymentCheckDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MVPaymentCheckDetailsEntity))]
		public virtual EntityCollection<MVPaymentCheckDetailsEntity> MvpaymentCheckDetails
		{
			get
			{
				if(_mvpaymentCheckDetails==null)
				{
					_mvpaymentCheckDetails = new EntityCollection<MVPaymentCheckDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentCheckDetailsEntityFactory)));
					_mvpaymentCheckDetails.SetContainingEntityInfo(this, "PhysicianPayment");
				}
				return _mvpaymentCheckDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianPaymentInvoiceEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianPaymentInvoiceEntity))]
		public virtual EntityCollection<PhysicianPaymentInvoiceEntity> PhysicianPaymentInvoice
		{
			get
			{
				if(_physicianPaymentInvoice==null)
				{
					_physicianPaymentInvoice = new EntityCollection<PhysicianPaymentInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPaymentInvoiceEntityFactory)));
					_physicianPaymentInvoice.SetContainingEntityInfo(this, "PhysicianPayment");
				}
				return _physicianPaymentInvoice;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckEntity))]
		public virtual EntityCollection<CheckEntity> CheckCollectionViaMvpaymentCheckDetails
		{
			get
			{
				if(_checkCollectionViaMvpaymentCheckDetails==null)
				{
					_checkCollectionViaMvpaymentCheckDetails = new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory)));
					_checkCollectionViaMvpaymentCheckDetails.IsReadOnly=true;
				}
				return _checkCollectionViaMvpaymentCheckDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianInvoiceEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianInvoiceEntity))]
		public virtual EntityCollection<PhysicianInvoiceEntity> PhysicianInvoiceCollectionViaPhysicianPaymentInvoice
		{
			get
			{
				if(_physicianInvoiceCollectionViaPhysicianPaymentInvoice==null)
				{
					_physicianInvoiceCollectionViaPhysicianPaymentInvoice = new EntityCollection<PhysicianInvoiceEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianInvoiceEntityFactory)));
					_physicianInvoiceCollectionViaPhysicianPaymentInvoice.IsReadOnly=true;
				}
				return _physicianInvoiceCollectionViaPhysicianPaymentInvoice;
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
			get { return (int)Falcon.Data.EntityType.PhysicianPaymentEntity; }
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
