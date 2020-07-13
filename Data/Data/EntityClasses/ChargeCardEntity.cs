///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'ChargeCard'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ChargeCardEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ChargeCardPaymentEntity> _chargeCardPayment;
		private EntityCollection<EventCustomerEligibilityEntity> _eventCustomerEligibility;
		private EntityCollection<TempCartEntity> _tempCart;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaTempCart;
		private EntityCollection<EligibilityEntity> _eligibilityCollectionViaTempCart;
		private EntityCollection<EligibilityEntity> _eligibilityCollectionViaEventCustomerEligibility;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerEligibility;
		private EntityCollection<PaymentEntity> _paymentCollectionViaChargeCardPayment;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaTempCart;
		private CreditCardTypeEntity _creditCardType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CreditCardType</summary>
			public static readonly string CreditCardType = "CreditCardType";
			/// <summary>Member name ChargeCardPayment</summary>
			public static readonly string ChargeCardPayment = "ChargeCardPayment";
			/// <summary>Member name EventCustomerEligibility</summary>
			public static readonly string EventCustomerEligibility = "EventCustomerEligibility";
			/// <summary>Member name TempCart</summary>
			public static readonly string TempCart = "TempCart";
			/// <summary>Member name CustomerProfileCollectionViaTempCart</summary>
			public static readonly string CustomerProfileCollectionViaTempCart = "CustomerProfileCollectionViaTempCart";
			/// <summary>Member name EligibilityCollectionViaTempCart</summary>
			public static readonly string EligibilityCollectionViaTempCart = "EligibilityCollectionViaTempCart";
			/// <summary>Member name EligibilityCollectionViaEventCustomerEligibility</summary>
			public static readonly string EligibilityCollectionViaEventCustomerEligibility = "EligibilityCollectionViaEventCustomerEligibility";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerEligibility</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerEligibility = "EventCustomersCollectionViaEventCustomerEligibility";
			/// <summary>Member name PaymentCollectionViaChargeCardPayment</summary>
			public static readonly string PaymentCollectionViaChargeCardPayment = "PaymentCollectionViaChargeCardPayment";
			/// <summary>Member name ProspectCustomerCollectionViaTempCart</summary>
			public static readonly string ProspectCustomerCollectionViaTempCart = "ProspectCustomerCollectionViaTempCart";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ChargeCardEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ChargeCardEntity():base("ChargeCardEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ChargeCardEntity(IEntityFields2 fields):base("ChargeCardEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ChargeCardEntity</param>
		public ChargeCardEntity(IValidator validator):base("ChargeCardEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="chargeCardId">PK value for ChargeCard which data should be fetched into this ChargeCard object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChargeCardEntity(System.Int64 chargeCardId):base("ChargeCardEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ChargeCardId = chargeCardId;
		}

		/// <summary> CTor</summary>
		/// <param name="chargeCardId">PK value for ChargeCard which data should be fetched into this ChargeCard object</param>
		/// <param name="validator">The custom validator object for this ChargeCardEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChargeCardEntity(System.Int64 chargeCardId, IValidator validator):base("ChargeCardEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ChargeCardId = chargeCardId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ChargeCardEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_chargeCardPayment = (EntityCollection<ChargeCardPaymentEntity>)info.GetValue("_chargeCardPayment", typeof(EntityCollection<ChargeCardPaymentEntity>));
				_eventCustomerEligibility = (EntityCollection<EventCustomerEligibilityEntity>)info.GetValue("_eventCustomerEligibility", typeof(EntityCollection<EventCustomerEligibilityEntity>));
				_tempCart = (EntityCollection<TempCartEntity>)info.GetValue("_tempCart", typeof(EntityCollection<TempCartEntity>));
				_customerProfileCollectionViaTempCart = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaTempCart", typeof(EntityCollection<CustomerProfileEntity>));
				_eligibilityCollectionViaTempCart = (EntityCollection<EligibilityEntity>)info.GetValue("_eligibilityCollectionViaTempCart", typeof(EntityCollection<EligibilityEntity>));
				_eligibilityCollectionViaEventCustomerEligibility = (EntityCollection<EligibilityEntity>)info.GetValue("_eligibilityCollectionViaEventCustomerEligibility", typeof(EntityCollection<EligibilityEntity>));
				_eventCustomersCollectionViaEventCustomerEligibility = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerEligibility", typeof(EntityCollection<EventCustomersEntity>));
				_paymentCollectionViaChargeCardPayment = (EntityCollection<PaymentEntity>)info.GetValue("_paymentCollectionViaChargeCardPayment", typeof(EntityCollection<PaymentEntity>));
				_prospectCustomerCollectionViaTempCart = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaTempCart", typeof(EntityCollection<ProspectCustomerEntity>));
				_creditCardType = (CreditCardTypeEntity)info.GetValue("_creditCardType", typeof(CreditCardTypeEntity));
				if(_creditCardType!=null)
				{
					_creditCardType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ChargeCardFieldIndex)fieldIndex)
			{
				case ChargeCardFieldIndex.TypeId:
					DesetupSyncCreditCardType(true, false);
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
				case "CreditCardType":
					this.CreditCardType = (CreditCardTypeEntity)entity;
					break;
				case "ChargeCardPayment":
					this.ChargeCardPayment.Add((ChargeCardPaymentEntity)entity);
					break;
				case "EventCustomerEligibility":
					this.EventCustomerEligibility.Add((EventCustomerEligibilityEntity)entity);
					break;
				case "TempCart":
					this.TempCart.Add((TempCartEntity)entity);
					break;
				case "CustomerProfileCollectionViaTempCart":
					this.CustomerProfileCollectionViaTempCart.IsReadOnly = false;
					this.CustomerProfileCollectionViaTempCart.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaTempCart.IsReadOnly = true;
					break;
				case "EligibilityCollectionViaTempCart":
					this.EligibilityCollectionViaTempCart.IsReadOnly = false;
					this.EligibilityCollectionViaTempCart.Add((EligibilityEntity)entity);
					this.EligibilityCollectionViaTempCart.IsReadOnly = true;
					break;
				case "EligibilityCollectionViaEventCustomerEligibility":
					this.EligibilityCollectionViaEventCustomerEligibility.IsReadOnly = false;
					this.EligibilityCollectionViaEventCustomerEligibility.Add((EligibilityEntity)entity);
					this.EligibilityCollectionViaEventCustomerEligibility.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerEligibility":
					this.EventCustomersCollectionViaEventCustomerEligibility.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerEligibility.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerEligibility.IsReadOnly = true;
					break;
				case "PaymentCollectionViaChargeCardPayment":
					this.PaymentCollectionViaChargeCardPayment.IsReadOnly = false;
					this.PaymentCollectionViaChargeCardPayment.Add((PaymentEntity)entity);
					this.PaymentCollectionViaChargeCardPayment.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaTempCart":
					this.ProspectCustomerCollectionViaTempCart.IsReadOnly = false;
					this.ProspectCustomerCollectionViaTempCart.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaTempCart.IsReadOnly = true;
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
			return ChargeCardEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CreditCardType":
					toReturn.Add(ChargeCardEntity.Relations.CreditCardTypeEntityUsingTypeId);
					break;
				case "ChargeCardPayment":
					toReturn.Add(ChargeCardEntity.Relations.ChargeCardPaymentEntityUsingChargeCardId);
					break;
				case "EventCustomerEligibility":
					toReturn.Add(ChargeCardEntity.Relations.EventCustomerEligibilityEntityUsingChargeCardId);
					break;
				case "TempCart":
					toReturn.Add(ChargeCardEntity.Relations.TempCartEntityUsingChargeCardId);
					break;
				case "CustomerProfileCollectionViaTempCart":
					toReturn.Add(ChargeCardEntity.Relations.TempCartEntityUsingChargeCardId, "ChargeCardEntity__", "TempCart_", JoinHint.None);
					toReturn.Add(TempCartEntity.Relations.CustomerProfileEntityUsingCustomerId, "TempCart_", string.Empty, JoinHint.None);
					break;
				case "EligibilityCollectionViaTempCart":
					toReturn.Add(ChargeCardEntity.Relations.TempCartEntityUsingChargeCardId, "ChargeCardEntity__", "TempCart_", JoinHint.None);
					toReturn.Add(TempCartEntity.Relations.EligibilityEntityUsingEligibilityId, "TempCart_", string.Empty, JoinHint.None);
					break;
				case "EligibilityCollectionViaEventCustomerEligibility":
					toReturn.Add(ChargeCardEntity.Relations.EventCustomerEligibilityEntityUsingChargeCardId, "ChargeCardEntity__", "EventCustomerEligibility_", JoinHint.None);
					toReturn.Add(EventCustomerEligibilityEntity.Relations.EligibilityEntityUsingEligibilityId, "EventCustomerEligibility_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerEligibility":
					toReturn.Add(ChargeCardEntity.Relations.EventCustomerEligibilityEntityUsingChargeCardId, "ChargeCardEntity__", "EventCustomerEligibility_", JoinHint.None);
					toReturn.Add(EventCustomerEligibilityEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerEligibility_", string.Empty, JoinHint.None);
					break;
				case "PaymentCollectionViaChargeCardPayment":
					toReturn.Add(ChargeCardEntity.Relations.ChargeCardPaymentEntityUsingChargeCardId, "ChargeCardEntity__", "ChargeCardPayment_", JoinHint.None);
					toReturn.Add(ChargeCardPaymentEntity.Relations.PaymentEntityUsingPaymentId, "ChargeCardPayment_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaTempCart":
					toReturn.Add(ChargeCardEntity.Relations.TempCartEntityUsingChargeCardId, "ChargeCardEntity__", "TempCart_", JoinHint.None);
					toReturn.Add(TempCartEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "TempCart_", string.Empty, JoinHint.None);
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
				case "CreditCardType":
					SetupSyncCreditCardType(relatedEntity);
					break;
				case "ChargeCardPayment":
					this.ChargeCardPayment.Add((ChargeCardPaymentEntity)relatedEntity);
					break;
				case "EventCustomerEligibility":
					this.EventCustomerEligibility.Add((EventCustomerEligibilityEntity)relatedEntity);
					break;
				case "TempCart":
					this.TempCart.Add((TempCartEntity)relatedEntity);
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
				case "CreditCardType":
					DesetupSyncCreditCardType(false, true);
					break;
				case "ChargeCardPayment":
					base.PerformRelatedEntityRemoval(this.ChargeCardPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerEligibility":
					base.PerformRelatedEntityRemoval(this.EventCustomerEligibility, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TempCart":
					base.PerformRelatedEntityRemoval(this.TempCart, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_creditCardType!=null)
			{
				toReturn.Add(_creditCardType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ChargeCardPayment);
			toReturn.Add(this.EventCustomerEligibility);
			toReturn.Add(this.TempCart);

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
				info.AddValue("_chargeCardPayment", ((_chargeCardPayment!=null) && (_chargeCardPayment.Count>0) && !this.MarkedForDeletion)?_chargeCardPayment:null);
				info.AddValue("_eventCustomerEligibility", ((_eventCustomerEligibility!=null) && (_eventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_eventCustomerEligibility:null);
				info.AddValue("_tempCart", ((_tempCart!=null) && (_tempCart.Count>0) && !this.MarkedForDeletion)?_tempCart:null);
				info.AddValue("_customerProfileCollectionViaTempCart", ((_customerProfileCollectionViaTempCart!=null) && (_customerProfileCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaTempCart:null);
				info.AddValue("_eligibilityCollectionViaTempCart", ((_eligibilityCollectionViaTempCart!=null) && (_eligibilityCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_eligibilityCollectionViaTempCart:null);
				info.AddValue("_eligibilityCollectionViaEventCustomerEligibility", ((_eligibilityCollectionViaEventCustomerEligibility!=null) && (_eligibilityCollectionViaEventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_eligibilityCollectionViaEventCustomerEligibility:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerEligibility", ((_eventCustomersCollectionViaEventCustomerEligibility!=null) && (_eventCustomersCollectionViaEventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerEligibility:null);
				info.AddValue("_paymentCollectionViaChargeCardPayment", ((_paymentCollectionViaChargeCardPayment!=null) && (_paymentCollectionViaChargeCardPayment.Count>0) && !this.MarkedForDeletion)?_paymentCollectionViaChargeCardPayment:null);
				info.AddValue("_prospectCustomerCollectionViaTempCart", ((_prospectCustomerCollectionViaTempCart!=null) && (_prospectCustomerCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaTempCart:null);
				info.AddValue("_creditCardType", (!this.MarkedForDeletion?_creditCardType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ChargeCardFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ChargeCardFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ChargeCardRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChargeCardPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChargeCardPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardPaymentFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerEligibility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerEligibilityFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TempCart' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId, "ChargeCardEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Eligibility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEligibilityCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EligibilityCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId, "ChargeCardEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Eligibility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEligibilityCollectionViaEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EligibilityCollectionViaEventCustomerEligibility"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId, "ChargeCardEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerEligibility"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId, "ChargeCardEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Payment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentCollectionViaChargeCardPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PaymentCollectionViaChargeCardPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId, "ChargeCardEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId, "ChargeCardEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CreditCardType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCreditCardType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CreditCardTypeFields.CreditCardTypeId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ChargeCardEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._chargeCardPayment);
			collectionsQueue.Enqueue(this._eventCustomerEligibility);
			collectionsQueue.Enqueue(this._tempCart);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaTempCart);
			collectionsQueue.Enqueue(this._eligibilityCollectionViaTempCart);
			collectionsQueue.Enqueue(this._eligibilityCollectionViaEventCustomerEligibility);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerEligibility);
			collectionsQueue.Enqueue(this._paymentCollectionViaChargeCardPayment);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaTempCart);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._chargeCardPayment = (EntityCollection<ChargeCardPaymentEntity>) collectionsQueue.Dequeue();
			this._eventCustomerEligibility = (EntityCollection<EventCustomerEligibilityEntity>) collectionsQueue.Dequeue();
			this._tempCart = (EntityCollection<TempCartEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaTempCart = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eligibilityCollectionViaTempCart = (EntityCollection<EligibilityEntity>) collectionsQueue.Dequeue();
			this._eligibilityCollectionViaEventCustomerEligibility = (EntityCollection<EligibilityEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerEligibility = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._paymentCollectionViaChargeCardPayment = (EntityCollection<PaymentEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaTempCart = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._chargeCardPayment != null)
			{
				return true;
			}
			if (this._eventCustomerEligibility != null)
			{
				return true;
			}
			if (this._tempCart != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaTempCart != null)
			{
				return true;
			}
			if (this._eligibilityCollectionViaTempCart != null)
			{
				return true;
			}
			if (this._eligibilityCollectionViaEventCustomerEligibility != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerEligibility != null)
			{
				return true;
			}
			if (this._paymentCollectionViaChargeCardPayment != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaTempCart != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChargeCardPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerEligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEligibilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CreditCardType", _creditCardType);
			toReturn.Add("ChargeCardPayment", _chargeCardPayment);
			toReturn.Add("EventCustomerEligibility", _eventCustomerEligibility);
			toReturn.Add("TempCart", _tempCart);
			toReturn.Add("CustomerProfileCollectionViaTempCart", _customerProfileCollectionViaTempCart);
			toReturn.Add("EligibilityCollectionViaTempCart", _eligibilityCollectionViaTempCart);
			toReturn.Add("EligibilityCollectionViaEventCustomerEligibility", _eligibilityCollectionViaEventCustomerEligibility);
			toReturn.Add("EventCustomersCollectionViaEventCustomerEligibility", _eventCustomersCollectionViaEventCustomerEligibility);
			toReturn.Add("PaymentCollectionViaChargeCardPayment", _paymentCollectionViaChargeCardPayment);
			toReturn.Add("ProspectCustomerCollectionViaTempCart", _prospectCustomerCollectionViaTempCart);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_chargeCardPayment!=null)
			{
				_chargeCardPayment.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerEligibility!=null)
			{
				_eventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_tempCart!=null)
			{
				_tempCart.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaTempCart!=null)
			{
				_customerProfileCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_eligibilityCollectionViaTempCart!=null)
			{
				_eligibilityCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_eligibilityCollectionViaEventCustomerEligibility!=null)
			{
				_eligibilityCollectionViaEventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerEligibility!=null)
			{
				_eventCustomersCollectionViaEventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_paymentCollectionViaChargeCardPayment!=null)
			{
				_paymentCollectionViaChargeCardPayment.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaTempCart!=null)
			{
				_prospectCustomerCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_creditCardType!=null)
			{
				_creditCardType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_chargeCardPayment = null;
			_eventCustomerEligibility = null;
			_tempCart = null;
			_customerProfileCollectionViaTempCart = null;
			_eligibilityCollectionViaTempCart = null;
			_eligibilityCollectionViaEventCustomerEligibility = null;
			_eventCustomersCollectionViaEventCustomerEligibility = null;
			_paymentCollectionViaChargeCardPayment = null;
			_prospectCustomerCollectionViaTempCart = null;
			_creditCardType = null;

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

			_fieldsCustomProperties.Add("ChargeCardId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NameOnCard", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Number", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ExpirationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Cvv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CardIssuer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDebitCard", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserCreatorId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _creditCardType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCreditCardType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _creditCardType, new PropertyChangedEventHandler( OnCreditCardTypePropertyChanged ), "CreditCardType", ChargeCardEntity.Relations.CreditCardTypeEntityUsingTypeId, true, signalRelatedEntity, "ChargeCard", resetFKFields, new int[] { (int)ChargeCardFieldIndex.TypeId } );		
			_creditCardType = null;
		}

		/// <summary> setups the sync logic for member _creditCardType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCreditCardType(IEntity2 relatedEntity)
		{
			if(_creditCardType!=relatedEntity)
			{
				DesetupSyncCreditCardType(true, true);
				_creditCardType = (CreditCardTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _creditCardType, new PropertyChangedEventHandler( OnCreditCardTypePropertyChanged ), "CreditCardType", ChargeCardEntity.Relations.CreditCardTypeEntityUsingTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCreditCardTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ChargeCardEntity</param>
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
		public  static ChargeCardRelations Relations
		{
			get	{ return new ChargeCardRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChargeCardPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChargeCardPayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChargeCardPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardPaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChargeCardPayment")[0], (int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.ChargeCardPaymentEntity, 0, null, null, null, null, "ChargeCardPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerEligibility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerEligibility
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerEligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEligibilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerEligibility")[0], (int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.EventCustomerEligibilityEntity, 0, null, null, null, null, "EventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TempCart' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTempCart
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory))),
					(IEntityRelation)GetRelationsForField("TempCart")[0], (int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.TempCartEntity, 0, null, null, null, null, "TempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = ChargeCardEntity.Relations.TempCartEntityUsingChargeCardId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaTempCart"), null, "CustomerProfileCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Eligibility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEligibilityCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = ChargeCardEntity.Relations.TempCartEntityUsingChargeCardId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.EligibilityEntity, 0, null, null, GetRelationsForField("EligibilityCollectionViaTempCart"), null, "EligibilityCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Eligibility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEligibilityCollectionViaEventCustomerEligibility
		{
			get
			{
				IEntityRelation intermediateRelation = ChargeCardEntity.Relations.EventCustomerEligibilityEntityUsingChargeCardId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerEligibility_");
				return new PrefetchPathElement2(new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.EligibilityEntity, 0, null, null, GetRelationsForField("EligibilityCollectionViaEventCustomerEligibility"), null, "EligibilityCollectionViaEventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerEligibility
		{
			get
			{
				IEntityRelation intermediateRelation = ChargeCardEntity.Relations.EventCustomerEligibilityEntityUsingChargeCardId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerEligibility_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerEligibility"), null, "EventCustomersCollectionViaEventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Payment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentCollectionViaChargeCardPayment
		{
			get
			{
				IEntityRelation intermediateRelation = ChargeCardEntity.Relations.ChargeCardPaymentEntityUsingChargeCardId;
				intermediateRelation.SetAliases(string.Empty, "ChargeCardPayment_");
				return new PrefetchPathElement2(new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.PaymentEntity, 0, null, null, GetRelationsForField("PaymentCollectionViaChargeCardPayment"), null, "PaymentCollectionViaChargeCardPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = ChargeCardEntity.Relations.TempCartEntityUsingChargeCardId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaTempCart"), null, "ProspectCustomerCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CreditCardType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCreditCardType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CreditCardTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("CreditCardType")[0], (int)Falcon.Data.EntityType.ChargeCardEntity, (int)Falcon.Data.EntityType.CreditCardTypeEntity, 0, null, null, null, null, "CreditCardType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ChargeCardEntity.CustomProperties;}
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
			get { return ChargeCardEntity.FieldsCustomProperties;}
		}

		/// <summary> The ChargeCardId property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."ChargeCardID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ChargeCardId
		{
			get { return (System.Int64)GetValue((int)ChargeCardFieldIndex.ChargeCardId, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.ChargeCardId, value); }
		}

		/// <summary> The NameOnCard property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."NameOnCard"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String NameOnCard
		{
			get { return (System.String)GetValue((int)ChargeCardFieldIndex.NameOnCard, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.NameOnCard, value); }
		}

		/// <summary> The Number property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."Number"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Number
		{
			get { return (System.String)GetValue((int)ChargeCardFieldIndex.Number, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.Number, value); }
		}

		/// <summary> The TypeId property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."TypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)ChargeCardFieldIndex.TypeId, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.TypeId, value); }
		}

		/// <summary> The ExpirationDate property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."ExpirationDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ExpirationDate
		{
			get { return (System.DateTime)GetValue((int)ChargeCardFieldIndex.ExpirationDate, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.ExpirationDate, value); }
		}

		/// <summary> The Cvv property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."CVV"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Cvv
		{
			get { return (System.String)GetValue((int)ChargeCardFieldIndex.Cvv, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.Cvv, value); }
		}

		/// <summary> The CardIssuer property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."CardIssuer"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CardIssuer
		{
			get { return (System.String)GetValue((int)ChargeCardFieldIndex.CardIssuer, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.CardIssuer, value); }
		}

		/// <summary> The IsDebitCard property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."IsDebitCard"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDebitCard
		{
			get { return (System.Boolean)GetValue((int)ChargeCardFieldIndex.IsDebitCard, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.IsDebitCard, value); }
		}

		/// <summary> The DateCreated property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ChargeCardFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.DateCreated, value); }
		}

		/// <summary> The OrganizationRoleUserCreatorId property of the Entity ChargeCard<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChargeCard"."OrganizationRoleUserCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationRoleUserCreatorId
		{
			get { return (System.Int64)GetValue((int)ChargeCardFieldIndex.OrganizationRoleUserCreatorId, true); }
			set	{ SetValue((int)ChargeCardFieldIndex.OrganizationRoleUserCreatorId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChargeCardPaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChargeCardPaymentEntity))]
		public virtual EntityCollection<ChargeCardPaymentEntity> ChargeCardPayment
		{
			get
			{
				if(_chargeCardPayment==null)
				{
					_chargeCardPayment = new EntityCollection<ChargeCardPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardPaymentEntityFactory)));
					_chargeCardPayment.SetContainingEntityInfo(this, "ChargeCard");
				}
				return _chargeCardPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerEligibilityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerEligibilityEntity))]
		public virtual EntityCollection<EventCustomerEligibilityEntity> EventCustomerEligibility
		{
			get
			{
				if(_eventCustomerEligibility==null)
				{
					_eventCustomerEligibility = new EntityCollection<EventCustomerEligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEligibilityEntityFactory)));
					_eventCustomerEligibility.SetContainingEntityInfo(this, "ChargeCard");
				}
				return _eventCustomerEligibility;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TempCartEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TempCartEntity))]
		public virtual EntityCollection<TempCartEntity> TempCart
		{
			get
			{
				if(_tempCart==null)
				{
					_tempCart = new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory)));
					_tempCart.SetContainingEntityInfo(this, "ChargeCard");
				}
				return _tempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaTempCart
		{
			get
			{
				if(_customerProfileCollectionViaTempCart==null)
				{
					_customerProfileCollectionViaTempCart = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaTempCart.IsReadOnly=true;
				}
				return _customerProfileCollectionViaTempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EligibilityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EligibilityEntity))]
		public virtual EntityCollection<EligibilityEntity> EligibilityCollectionViaTempCart
		{
			get
			{
				if(_eligibilityCollectionViaTempCart==null)
				{
					_eligibilityCollectionViaTempCart = new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory)));
					_eligibilityCollectionViaTempCart.IsReadOnly=true;
				}
				return _eligibilityCollectionViaTempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EligibilityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EligibilityEntity))]
		public virtual EntityCollection<EligibilityEntity> EligibilityCollectionViaEventCustomerEligibility
		{
			get
			{
				if(_eligibilityCollectionViaEventCustomerEligibility==null)
				{
					_eligibilityCollectionViaEventCustomerEligibility = new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory)));
					_eligibilityCollectionViaEventCustomerEligibility.IsReadOnly=true;
				}
				return _eligibilityCollectionViaEventCustomerEligibility;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerEligibility
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerEligibility==null)
				{
					_eventCustomersCollectionViaEventCustomerEligibility = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerEligibility.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerEligibility;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentEntity))]
		public virtual EntityCollection<PaymentEntity> PaymentCollectionViaChargeCardPayment
		{
			get
			{
				if(_paymentCollectionViaChargeCardPayment==null)
				{
					_paymentCollectionViaChargeCardPayment = new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory)));
					_paymentCollectionViaChargeCardPayment.IsReadOnly=true;
				}
				return _paymentCollectionViaChargeCardPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomerCollectionViaTempCart
		{
			get
			{
				if(_prospectCustomerCollectionViaTempCart==null)
				{
					_prospectCustomerCollectionViaTempCart = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomerCollectionViaTempCart.IsReadOnly=true;
				}
				return _prospectCustomerCollectionViaTempCart;
			}
		}

		/// <summary> Gets / sets related entity of type 'CreditCardTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CreditCardTypeEntity CreditCardType
		{
			get
			{
				return _creditCardType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCreditCardType(value);
				}
				else
				{
					if(value==null)
					{
						if(_creditCardType != null)
						{
							_creditCardType.UnsetRelatedEntity(this, "ChargeCard");
						}
					}
					else
					{
						if(_creditCardType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChargeCard");
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
			get { return (int)Falcon.Data.EntityType.ChargeCardEntity; }
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
