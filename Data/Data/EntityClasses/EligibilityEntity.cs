///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
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
	/// Entity class which represents the entity 'Eligibility'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EligibilityEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventCustomerEligibilityEntity> _eventCustomerEligibility;
		private EntityCollection<TempCartEntity> _tempCart;
		private EntityCollection<ChargeCardEntity> _chargeCardCollectionViaTempCart;
		private EntityCollection<ChargeCardEntity> _chargeCardCollectionViaEventCustomerEligibility;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaTempCart;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerEligibility;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaTempCart;
		private InsuranceCompanyEntity _insuranceCompany;
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
			/// <summary>Member name InsuranceCompany</summary>
			public static readonly string InsuranceCompany = "InsuranceCompany";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name EventCustomerEligibility</summary>
			public static readonly string EventCustomerEligibility = "EventCustomerEligibility";
			/// <summary>Member name TempCart</summary>
			public static readonly string TempCart = "TempCart";
			/// <summary>Member name ChargeCardCollectionViaTempCart</summary>
			public static readonly string ChargeCardCollectionViaTempCart = "ChargeCardCollectionViaTempCart";
			/// <summary>Member name ChargeCardCollectionViaEventCustomerEligibility</summary>
			public static readonly string ChargeCardCollectionViaEventCustomerEligibility = "ChargeCardCollectionViaEventCustomerEligibility";
			/// <summary>Member name CustomerProfileCollectionViaTempCart</summary>
			public static readonly string CustomerProfileCollectionViaTempCart = "CustomerProfileCollectionViaTempCart";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerEligibility</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerEligibility = "EventCustomersCollectionViaEventCustomerEligibility";
			/// <summary>Member name ProspectCustomerCollectionViaTempCart</summary>
			public static readonly string ProspectCustomerCollectionViaTempCart = "ProspectCustomerCollectionViaTempCart";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EligibilityEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EligibilityEntity():base("EligibilityEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EligibilityEntity(IEntityFields2 fields):base("EligibilityEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EligibilityEntity</param>
		public EligibilityEntity(IValidator validator):base("EligibilityEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eligibilityId">PK value for Eligibility which data should be fetched into this Eligibility object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EligibilityEntity(System.Int64 eligibilityId):base("EligibilityEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EligibilityId = eligibilityId;
		}

		/// <summary> CTor</summary>
		/// <param name="eligibilityId">PK value for Eligibility which data should be fetched into this Eligibility object</param>
		/// <param name="validator">The custom validator object for this EligibilityEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EligibilityEntity(System.Int64 eligibilityId, IValidator validator):base("EligibilityEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EligibilityId = eligibilityId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EligibilityEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventCustomerEligibility = (EntityCollection<EventCustomerEligibilityEntity>)info.GetValue("_eventCustomerEligibility", typeof(EntityCollection<EventCustomerEligibilityEntity>));
				_tempCart = (EntityCollection<TempCartEntity>)info.GetValue("_tempCart", typeof(EntityCollection<TempCartEntity>));
				_chargeCardCollectionViaTempCart = (EntityCollection<ChargeCardEntity>)info.GetValue("_chargeCardCollectionViaTempCart", typeof(EntityCollection<ChargeCardEntity>));
				_chargeCardCollectionViaEventCustomerEligibility = (EntityCollection<ChargeCardEntity>)info.GetValue("_chargeCardCollectionViaEventCustomerEligibility", typeof(EntityCollection<ChargeCardEntity>));
				_customerProfileCollectionViaTempCart = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaTempCart", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaEventCustomerEligibility = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerEligibility", typeof(EntityCollection<EventCustomersEntity>));
				_prospectCustomerCollectionViaTempCart = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaTempCart", typeof(EntityCollection<ProspectCustomerEntity>));
				_insuranceCompany = (InsuranceCompanyEntity)info.GetValue("_insuranceCompany", typeof(InsuranceCompanyEntity));
				if(_insuranceCompany!=null)
				{
					_insuranceCompany.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((EligibilityFieldIndex)fieldIndex)
			{
				case EligibilityFieldIndex.InsuranceCompanyId:
					DesetupSyncInsuranceCompany(true, false);
					break;
				case EligibilityFieldIndex.CreatedByOrgRoleUserId:
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
				case "InsuranceCompany":
					this.InsuranceCompany = (InsuranceCompanyEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "EventCustomerEligibility":
					this.EventCustomerEligibility.Add((EventCustomerEligibilityEntity)entity);
					break;
				case "TempCart":
					this.TempCart.Add((TempCartEntity)entity);
					break;
				case "ChargeCardCollectionViaTempCart":
					this.ChargeCardCollectionViaTempCart.IsReadOnly = false;
					this.ChargeCardCollectionViaTempCart.Add((ChargeCardEntity)entity);
					this.ChargeCardCollectionViaTempCart.IsReadOnly = true;
					break;
				case "ChargeCardCollectionViaEventCustomerEligibility":
					this.ChargeCardCollectionViaEventCustomerEligibility.IsReadOnly = false;
					this.ChargeCardCollectionViaEventCustomerEligibility.Add((ChargeCardEntity)entity);
					this.ChargeCardCollectionViaEventCustomerEligibility.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaTempCart":
					this.CustomerProfileCollectionViaTempCart.IsReadOnly = false;
					this.CustomerProfileCollectionViaTempCart.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaTempCart.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerEligibility":
					this.EventCustomersCollectionViaEventCustomerEligibility.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerEligibility.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerEligibility.IsReadOnly = true;
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
			return EligibilityEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "InsuranceCompany":
					toReturn.Add(EligibilityEntity.Relations.InsuranceCompanyEntityUsingInsuranceCompanyId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(EligibilityEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "EventCustomerEligibility":
					toReturn.Add(EligibilityEntity.Relations.EventCustomerEligibilityEntityUsingEligibilityId);
					break;
				case "TempCart":
					toReturn.Add(EligibilityEntity.Relations.TempCartEntityUsingEligibilityId);
					break;
				case "ChargeCardCollectionViaTempCart":
					toReturn.Add(EligibilityEntity.Relations.TempCartEntityUsingEligibilityId, "EligibilityEntity__", "TempCart_", JoinHint.None);
					toReturn.Add(TempCartEntity.Relations.ChargeCardEntityUsingChargeCardId, "TempCart_", string.Empty, JoinHint.None);
					break;
				case "ChargeCardCollectionViaEventCustomerEligibility":
					toReturn.Add(EligibilityEntity.Relations.EventCustomerEligibilityEntityUsingEligibilityId, "EligibilityEntity__", "EventCustomerEligibility_", JoinHint.None);
					toReturn.Add(EventCustomerEligibilityEntity.Relations.ChargeCardEntityUsingChargeCardId, "EventCustomerEligibility_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaTempCart":
					toReturn.Add(EligibilityEntity.Relations.TempCartEntityUsingEligibilityId, "EligibilityEntity__", "TempCart_", JoinHint.None);
					toReturn.Add(TempCartEntity.Relations.CustomerProfileEntityUsingCustomerId, "TempCart_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerEligibility":
					toReturn.Add(EligibilityEntity.Relations.EventCustomerEligibilityEntityUsingEligibilityId, "EligibilityEntity__", "EventCustomerEligibility_", JoinHint.None);
					toReturn.Add(EventCustomerEligibilityEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerEligibility_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaTempCart":
					toReturn.Add(EligibilityEntity.Relations.TempCartEntityUsingEligibilityId, "EligibilityEntity__", "TempCart_", JoinHint.None);
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
				case "InsuranceCompany":
					SetupSyncInsuranceCompany(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
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
				case "InsuranceCompany":
					DesetupSyncInsuranceCompany(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
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
			if(_insuranceCompany!=null)
			{
				toReturn.Add(_insuranceCompany);
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
				info.AddValue("_eventCustomerEligibility", ((_eventCustomerEligibility!=null) && (_eventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_eventCustomerEligibility:null);
				info.AddValue("_tempCart", ((_tempCart!=null) && (_tempCart.Count>0) && !this.MarkedForDeletion)?_tempCart:null);
				info.AddValue("_chargeCardCollectionViaTempCart", ((_chargeCardCollectionViaTempCart!=null) && (_chargeCardCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_chargeCardCollectionViaTempCart:null);
				info.AddValue("_chargeCardCollectionViaEventCustomerEligibility", ((_chargeCardCollectionViaEventCustomerEligibility!=null) && (_chargeCardCollectionViaEventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_chargeCardCollectionViaEventCustomerEligibility:null);
				info.AddValue("_customerProfileCollectionViaTempCart", ((_customerProfileCollectionViaTempCart!=null) && (_customerProfileCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaTempCart:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerEligibility", ((_eventCustomersCollectionViaEventCustomerEligibility!=null) && (_eventCustomersCollectionViaEventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerEligibility:null);
				info.AddValue("_prospectCustomerCollectionViaTempCart", ((_prospectCustomerCollectionViaTempCart!=null) && (_prospectCustomerCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaTempCart:null);
				info.AddValue("_insuranceCompany", (!this.MarkedForDeletion?_insuranceCompany:null));
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
		public bool TestOriginalFieldValueForNull(EligibilityFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EligibilityFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EligibilityRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerEligibility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerEligibilityFields.EligibilityId, null, ComparisonOperator.Equal, this.EligibilityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TempCart' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.EligibilityId, null, ComparisonOperator.Equal, this.EligibilityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChargeCard' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChargeCardCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChargeCardCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EligibilityFields.EligibilityId, null, ComparisonOperator.Equal, this.EligibilityId, "EligibilityEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChargeCard' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChargeCardCollectionViaEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChargeCardCollectionViaEventCustomerEligibility"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EligibilityFields.EligibilityId, null, ComparisonOperator.Equal, this.EligibilityId, "EligibilityEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EligibilityFields.EligibilityId, null, ComparisonOperator.Equal, this.EligibilityId, "EligibilityEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerEligibility"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EligibilityFields.EligibilityId, null, ComparisonOperator.Equal, this.EligibilityId, "EligibilityEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EligibilityFields.EligibilityId, null, ComparisonOperator.Equal, this.EligibilityId, "EligibilityEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'InsuranceCompany' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInsuranceCompany()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InsuranceCompanyFields.InsuranceCompanyId, null, ComparisonOperator.Equal, this.InsuranceCompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EligibilityEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventCustomerEligibility);
			collectionsQueue.Enqueue(this._tempCart);
			collectionsQueue.Enqueue(this._chargeCardCollectionViaTempCart);
			collectionsQueue.Enqueue(this._chargeCardCollectionViaEventCustomerEligibility);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaTempCart);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerEligibility);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaTempCart);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventCustomerEligibility = (EntityCollection<EventCustomerEligibilityEntity>) collectionsQueue.Dequeue();
			this._tempCart = (EntityCollection<TempCartEntity>) collectionsQueue.Dequeue();
			this._chargeCardCollectionViaTempCart = (EntityCollection<ChargeCardEntity>) collectionsQueue.Dequeue();
			this._chargeCardCollectionViaEventCustomerEligibility = (EntityCollection<ChargeCardEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaTempCart = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerEligibility = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaTempCart = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventCustomerEligibility != null)
			{
				return true;
			}
			if (this._tempCart != null)
			{
				return true;
			}
			if (this._chargeCardCollectionViaTempCart != null)
			{
				return true;
			}
			if (this._chargeCardCollectionViaEventCustomerEligibility != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaTempCart != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerEligibility != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerEligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEligibilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
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
			toReturn.Add("InsuranceCompany", _insuranceCompany);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("EventCustomerEligibility", _eventCustomerEligibility);
			toReturn.Add("TempCart", _tempCart);
			toReturn.Add("ChargeCardCollectionViaTempCart", _chargeCardCollectionViaTempCart);
			toReturn.Add("ChargeCardCollectionViaEventCustomerEligibility", _chargeCardCollectionViaEventCustomerEligibility);
			toReturn.Add("CustomerProfileCollectionViaTempCart", _customerProfileCollectionViaTempCart);
			toReturn.Add("EventCustomersCollectionViaEventCustomerEligibility", _eventCustomersCollectionViaEventCustomerEligibility);
			toReturn.Add("ProspectCustomerCollectionViaTempCart", _prospectCustomerCollectionViaTempCart);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventCustomerEligibility!=null)
			{
				_eventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_tempCart!=null)
			{
				_tempCart.ActiveContext = base.ActiveContext;
			}
			if(_chargeCardCollectionViaTempCart!=null)
			{
				_chargeCardCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_chargeCardCollectionViaEventCustomerEligibility!=null)
			{
				_chargeCardCollectionViaEventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaTempCart!=null)
			{
				_customerProfileCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerEligibility!=null)
			{
				_eventCustomersCollectionViaEventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaTempCart!=null)
			{
				_prospectCustomerCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_insuranceCompany!=null)
			{
				_insuranceCompany.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventCustomerEligibility = null;
			_tempCart = null;
			_chargeCardCollectionViaTempCart = null;
			_chargeCardCollectionViaEventCustomerEligibility = null;
			_customerProfileCollectionViaTempCart = null;
			_eventCustomersCollectionViaEventCustomerEligibility = null;
			_prospectCustomerCollectionViaTempCart = null;
			_insuranceCompany = null;
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

			_fieldsCustomProperties.Add("EligibilityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Guid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InsuranceCompanyId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PlanName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CoPayment", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CoInsurance", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Request", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Response", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _insuranceCompany</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInsuranceCompany(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _insuranceCompany, new PropertyChangedEventHandler( OnInsuranceCompanyPropertyChanged ), "InsuranceCompany", EligibilityEntity.Relations.InsuranceCompanyEntityUsingInsuranceCompanyId, true, signalRelatedEntity, "Eligibility", resetFKFields, new int[] { (int)EligibilityFieldIndex.InsuranceCompanyId } );		
			_insuranceCompany = null;
		}

		/// <summary> setups the sync logic for member _insuranceCompany</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInsuranceCompany(IEntity2 relatedEntity)
		{
			if(_insuranceCompany!=relatedEntity)
			{
				DesetupSyncInsuranceCompany(true, true);
				_insuranceCompany = (InsuranceCompanyEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _insuranceCompany, new PropertyChangedEventHandler( OnInsuranceCompanyPropertyChanged ), "InsuranceCompany", EligibilityEntity.Relations.InsuranceCompanyEntityUsingInsuranceCompanyId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInsuranceCompanyPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EligibilityEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "Eligibility", resetFKFields, new int[] { (int)EligibilityFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EligibilityEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this EligibilityEntity</param>
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
		public  static EligibilityRelations Relations
		{
			get	{ return new EligibilityRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerEligibility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerEligibility
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerEligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEligibilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerEligibility")[0], (int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.EventCustomerEligibilityEntity, 0, null, null, null, null, "EventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("TempCart")[0], (int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.TempCartEntity, 0, null, null, null, null, "TempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChargeCard' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChargeCardCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = EligibilityEntity.Relations.TempCartEntityUsingEligibilityId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.ChargeCardEntity, 0, null, null, GetRelationsForField("ChargeCardCollectionViaTempCart"), null, "ChargeCardCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChargeCard' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChargeCardCollectionViaEventCustomerEligibility
		{
			get
			{
				IEntityRelation intermediateRelation = EligibilityEntity.Relations.EventCustomerEligibilityEntityUsingEligibilityId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerEligibility_");
				return new PrefetchPathElement2(new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.ChargeCardEntity, 0, null, null, GetRelationsForField("ChargeCardCollectionViaEventCustomerEligibility"), null, "ChargeCardCollectionViaEventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = EligibilityEntity.Relations.TempCartEntityUsingEligibilityId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaTempCart"), null, "CustomerProfileCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerEligibility
		{
			get
			{
				IEntityRelation intermediateRelation = EligibilityEntity.Relations.EventCustomerEligibilityEntityUsingEligibilityId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerEligibility_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerEligibility"), null, "EventCustomersCollectionViaEventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = EligibilityEntity.Relations.TempCartEntityUsingEligibilityId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaTempCart"), null, "ProspectCustomerCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InsuranceCompany' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInsuranceCompany
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InsuranceCompanyEntityFactory))),
					(IEntityRelation)GetRelationsForField("InsuranceCompany")[0], (int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.InsuranceCompanyEntity, 0, null, null, null, null, "InsuranceCompany", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.EligibilityEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EligibilityEntity.CustomProperties;}
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
			get { return EligibilityEntity.FieldsCustomProperties;}
		}

		/// <summary> The EligibilityId property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."EligibilityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 EligibilityId
		{
			get { return (System.Int64)GetValue((int)EligibilityFieldIndex.EligibilityId, true); }
			set	{ SetValue((int)EligibilityFieldIndex.EligibilityId, value); }
		}

		/// <summary> The Guid property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."Guid"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Guid
		{
			get { return (System.String)GetValue((int)EligibilityFieldIndex.Guid, true); }
			set	{ SetValue((int)EligibilityFieldIndex.Guid, value); }
		}

		/// <summary> The InsuranceCompanyId property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."InsuranceCompanyId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 InsuranceCompanyId
		{
			get { return (System.Int64)GetValue((int)EligibilityFieldIndex.InsuranceCompanyId, true); }
			set	{ SetValue((int)EligibilityFieldIndex.InsuranceCompanyId, value); }
		}

		/// <summary> The PlanName property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."PlanName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PlanName
		{
			get { return (System.String)GetValue((int)EligibilityFieldIndex.PlanName, true); }
			set	{ SetValue((int)EligibilityFieldIndex.PlanName, value); }
		}

		/// <summary> The GroupName property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."GroupName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GroupName
		{
			get { return (System.String)GetValue((int)EligibilityFieldIndex.GroupName, true); }
			set	{ SetValue((int)EligibilityFieldIndex.GroupName, value); }
		}

		/// <summary> The CoPayment property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."CoPayment"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal CoPayment
		{
			get { return (System.Decimal)GetValue((int)EligibilityFieldIndex.CoPayment, true); }
			set	{ SetValue((int)EligibilityFieldIndex.CoPayment, value); }
		}

		/// <summary> The CoInsurance property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."CoInsurance"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal CoInsurance
		{
			get { return (System.Decimal)GetValue((int)EligibilityFieldIndex.CoInsurance, true); }
			set	{ SetValue((int)EligibilityFieldIndex.CoInsurance, value); }
		}

		/// <summary> The Request property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."Request"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Request
		{
			get { return (System.String)GetValue((int)EligibilityFieldIndex.Request, true); }
			set	{ SetValue((int)EligibilityFieldIndex.Request, value); }
		}

		/// <summary> The Response property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."Response"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Response
		{
			get { return (System.String)GetValue((int)EligibilityFieldIndex.Response, true); }
			set	{ SetValue((int)EligibilityFieldIndex.Response, value); }
		}

		/// <summary> The DateCreated property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)EligibilityFieldIndex.DateCreated, true); }
			set	{ SetValue((int)EligibilityFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Eligibility<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEligibility"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EligibilityFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)EligibilityFieldIndex.CreatedByOrgRoleUserId, value); }
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
					_eventCustomerEligibility.SetContainingEntityInfo(this, "Eligibility");
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
					_tempCart.SetContainingEntityInfo(this, "Eligibility");
				}
				return _tempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChargeCardEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChargeCardEntity))]
		public virtual EntityCollection<ChargeCardEntity> ChargeCardCollectionViaTempCart
		{
			get
			{
				if(_chargeCardCollectionViaTempCart==null)
				{
					_chargeCardCollectionViaTempCart = new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory)));
					_chargeCardCollectionViaTempCart.IsReadOnly=true;
				}
				return _chargeCardCollectionViaTempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChargeCardEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChargeCardEntity))]
		public virtual EntityCollection<ChargeCardEntity> ChargeCardCollectionViaEventCustomerEligibility
		{
			get
			{
				if(_chargeCardCollectionViaEventCustomerEligibility==null)
				{
					_chargeCardCollectionViaEventCustomerEligibility = new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory)));
					_chargeCardCollectionViaEventCustomerEligibility.IsReadOnly=true;
				}
				return _chargeCardCollectionViaEventCustomerEligibility;
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

		/// <summary> Gets / sets related entity of type 'InsuranceCompanyEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InsuranceCompanyEntity InsuranceCompany
		{
			get
			{
				return _insuranceCompany;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInsuranceCompany(value);
				}
				else
				{
					if(value==null)
					{
						if(_insuranceCompany != null)
						{
							_insuranceCompany.UnsetRelatedEntity(this, "Eligibility");
						}
					}
					else
					{
						if(_insuranceCompany!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Eligibility");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Eligibility");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Eligibility");
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
			get { return (int)Falcon.Data.EntityType.EligibilityEntity; }
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
