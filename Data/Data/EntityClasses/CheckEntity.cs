///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:45
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
	/// Entity class which represents the entity 'Check'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CheckEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CheckPaymentEntity> _checkPayment;
		private EntityCollection<EcheckPaymentEntity> _echeckPayment;
		private EntityCollection<MVPaymentCheckDetailsEntity> _mvpaymentCheckDetails;
		private EntityCollection<PaymentEntity> _paymentCollectionViaEcheckPayment;
		private EntityCollection<PaymentEntity> _paymentCollectionViaCheckPayment;
		private EntityCollection<PhysicianPaymentEntity> _physicianPaymentCollectionViaMvpaymentCheckDetails;
		private OrganizationRoleUserEntity _organizationRoleUser_;
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
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CheckPayment</summary>
			public static readonly string CheckPayment = "CheckPayment";
			/// <summary>Member name EcheckPayment</summary>
			public static readonly string EcheckPayment = "EcheckPayment";
			/// <summary>Member name MvpaymentCheckDetails</summary>
			public static readonly string MvpaymentCheckDetails = "MvpaymentCheckDetails";
			/// <summary>Member name PaymentCollectionViaEcheckPayment</summary>
			public static readonly string PaymentCollectionViaEcheckPayment = "PaymentCollectionViaEcheckPayment";
			/// <summary>Member name PaymentCollectionViaCheckPayment</summary>
			public static readonly string PaymentCollectionViaCheckPayment = "PaymentCollectionViaCheckPayment";
			/// <summary>Member name PhysicianPaymentCollectionViaMvpaymentCheckDetails</summary>
			public static readonly string PhysicianPaymentCollectionViaMvpaymentCheckDetails = "PhysicianPaymentCollectionViaMvpaymentCheckDetails";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CheckEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CheckEntity():base("CheckEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CheckEntity(IEntityFields2 fields):base("CheckEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CheckEntity</param>
		public CheckEntity(IValidator validator):base("CheckEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="checkId">PK value for Check which data should be fetched into this Check object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckEntity(System.Int64 checkId):base("CheckEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CheckId = checkId;
		}

		/// <summary> CTor</summary>
		/// <param name="checkId">PK value for Check which data should be fetched into this Check object</param>
		/// <param name="validator">The custom validator object for this CheckEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CheckEntity(System.Int64 checkId, IValidator validator):base("CheckEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CheckId = checkId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CheckEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_checkPayment = (EntityCollection<CheckPaymentEntity>)info.GetValue("_checkPayment", typeof(EntityCollection<CheckPaymentEntity>));
				_echeckPayment = (EntityCollection<EcheckPaymentEntity>)info.GetValue("_echeckPayment", typeof(EntityCollection<EcheckPaymentEntity>));
				_mvpaymentCheckDetails = (EntityCollection<MVPaymentCheckDetailsEntity>)info.GetValue("_mvpaymentCheckDetails", typeof(EntityCollection<MVPaymentCheckDetailsEntity>));
				_paymentCollectionViaEcheckPayment = (EntityCollection<PaymentEntity>)info.GetValue("_paymentCollectionViaEcheckPayment", typeof(EntityCollection<PaymentEntity>));
				_paymentCollectionViaCheckPayment = (EntityCollection<PaymentEntity>)info.GetValue("_paymentCollectionViaCheckPayment", typeof(EntityCollection<PaymentEntity>));
				_physicianPaymentCollectionViaMvpaymentCheckDetails = (EntityCollection<PhysicianPaymentEntity>)info.GetValue("_physicianPaymentCollectionViaMvpaymentCheckDetails", typeof(EntityCollection<PhysicianPaymentEntity>));
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CheckFieldIndex)fieldIndex)
			{
				case CheckFieldIndex.DataRecoderCreatorId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CheckFieldIndex.DataRecoderModifierId:
					DesetupSyncOrganizationRoleUser_(true, false);
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
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CheckPayment":
					this.CheckPayment.Add((CheckPaymentEntity)entity);
					break;
				case "EcheckPayment":
					this.EcheckPayment.Add((EcheckPaymentEntity)entity);
					break;
				case "MvpaymentCheckDetails":
					this.MvpaymentCheckDetails.Add((MVPaymentCheckDetailsEntity)entity);
					break;
				case "PaymentCollectionViaEcheckPayment":
					this.PaymentCollectionViaEcheckPayment.IsReadOnly = false;
					this.PaymentCollectionViaEcheckPayment.Add((PaymentEntity)entity);
					this.PaymentCollectionViaEcheckPayment.IsReadOnly = true;
					break;
				case "PaymentCollectionViaCheckPayment":
					this.PaymentCollectionViaCheckPayment.IsReadOnly = false;
					this.PaymentCollectionViaCheckPayment.Add((PaymentEntity)entity);
					this.PaymentCollectionViaCheckPayment.IsReadOnly = true;
					break;
				case "PhysicianPaymentCollectionViaMvpaymentCheckDetails":
					this.PhysicianPaymentCollectionViaMvpaymentCheckDetails.IsReadOnly = false;
					this.PhysicianPaymentCollectionViaMvpaymentCheckDetails.Add((PhysicianPaymentEntity)entity);
					this.PhysicianPaymentCollectionViaMvpaymentCheckDetails.IsReadOnly = true;
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
			return CheckEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser_":
					toReturn.Add(CheckEntity.Relations.OrganizationRoleUserEntityUsingDataRecoderModifierId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CheckEntity.Relations.OrganizationRoleUserEntityUsingDataRecoderCreatorId);
					break;
				case "CheckPayment":
					toReturn.Add(CheckEntity.Relations.CheckPaymentEntityUsingCheckId);
					break;
				case "EcheckPayment":
					toReturn.Add(CheckEntity.Relations.EcheckPaymentEntityUsingEcheckId);
					break;
				case "MvpaymentCheckDetails":
					toReturn.Add(CheckEntity.Relations.MVPaymentCheckDetailsEntityUsingCheckId);
					break;
				case "PaymentCollectionViaEcheckPayment":
					toReturn.Add(CheckEntity.Relations.EcheckPaymentEntityUsingEcheckId, "CheckEntity__", "EcheckPayment_", JoinHint.None);
					toReturn.Add(EcheckPaymentEntity.Relations.PaymentEntityUsingPaymentId, "EcheckPayment_", string.Empty, JoinHint.None);
					break;
				case "PaymentCollectionViaCheckPayment":
					toReturn.Add(CheckEntity.Relations.CheckPaymentEntityUsingCheckId, "CheckEntity__", "CheckPayment_", JoinHint.None);
					toReturn.Add(CheckPaymentEntity.Relations.PaymentEntityUsingPaymentId, "CheckPayment_", string.Empty, JoinHint.None);
					break;
				case "PhysicianPaymentCollectionViaMvpaymentCheckDetails":
					toReturn.Add(CheckEntity.Relations.MVPaymentCheckDetailsEntityUsingCheckId, "CheckEntity__", "MVPaymentCheckDetails_", JoinHint.None);
					toReturn.Add(MVPaymentCheckDetailsEntity.Relations.PhysicianPaymentEntityUsingMvpaymentId, "MVPaymentCheckDetails_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CheckPayment":
					this.CheckPayment.Add((CheckPaymentEntity)relatedEntity);
					break;
				case "EcheckPayment":
					this.EcheckPayment.Add((EcheckPaymentEntity)relatedEntity);
					break;
				case "MvpaymentCheckDetails":
					this.MvpaymentCheckDetails.Add((MVPaymentCheckDetailsEntity)relatedEntity);
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
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CheckPayment":
					base.PerformRelatedEntityRemoval(this.CheckPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EcheckPayment":
					base.PerformRelatedEntityRemoval(this.EcheckPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MvpaymentCheckDetails":
					base.PerformRelatedEntityRemoval(this.MvpaymentCheckDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
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
			toReturn.Add(this.CheckPayment);
			toReturn.Add(this.EcheckPayment);
			toReturn.Add(this.MvpaymentCheckDetails);

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
				info.AddValue("_checkPayment", ((_checkPayment!=null) && (_checkPayment.Count>0) && !this.MarkedForDeletion)?_checkPayment:null);
				info.AddValue("_echeckPayment", ((_echeckPayment!=null) && (_echeckPayment.Count>0) && !this.MarkedForDeletion)?_echeckPayment:null);
				info.AddValue("_mvpaymentCheckDetails", ((_mvpaymentCheckDetails!=null) && (_mvpaymentCheckDetails.Count>0) && !this.MarkedForDeletion)?_mvpaymentCheckDetails:null);
				info.AddValue("_paymentCollectionViaEcheckPayment", ((_paymentCollectionViaEcheckPayment!=null) && (_paymentCollectionViaEcheckPayment.Count>0) && !this.MarkedForDeletion)?_paymentCollectionViaEcheckPayment:null);
				info.AddValue("_paymentCollectionViaCheckPayment", ((_paymentCollectionViaCheckPayment!=null) && (_paymentCollectionViaCheckPayment.Count>0) && !this.MarkedForDeletion)?_paymentCollectionViaCheckPayment:null);
				info.AddValue("_physicianPaymentCollectionViaMvpaymentCheckDetails", ((_physicianPaymentCollectionViaMvpaymentCheckDetails!=null) && (_physicianPaymentCollectionViaMvpaymentCheckDetails.Count>0) && !this.MarkedForDeletion)?_physicianPaymentCollectionViaMvpaymentCheckDetails:null);
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
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
		public bool TestOriginalFieldValueForNull(CheckFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CheckFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CheckRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckPaymentFields.CheckId, null, ComparisonOperator.Equal, this.CheckId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EcheckPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEcheckPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EcheckPaymentFields.EcheckId, null, ComparisonOperator.Equal, this.CheckId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MVPaymentCheckDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMvpaymentCheckDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MVPaymentCheckDetailsFields.CheckId, null, ComparisonOperator.Equal, this.CheckId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Payment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentCollectionViaEcheckPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PaymentCollectionViaEcheckPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckFields.CheckId, null, ComparisonOperator.Equal, this.CheckId, "CheckEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Payment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentCollectionViaCheckPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PaymentCollectionViaCheckPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckFields.CheckId, null, ComparisonOperator.Equal, this.CheckId, "CheckEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianPaymentCollectionViaMvpaymentCheckDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianPaymentCollectionViaMvpaymentCheckDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckFields.CheckId, null, ComparisonOperator.Equal, this.CheckId, "CheckEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.DataRecoderModifierId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.DataRecoderCreatorId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CheckEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._checkPayment);
			collectionsQueue.Enqueue(this._echeckPayment);
			collectionsQueue.Enqueue(this._mvpaymentCheckDetails);
			collectionsQueue.Enqueue(this._paymentCollectionViaEcheckPayment);
			collectionsQueue.Enqueue(this._paymentCollectionViaCheckPayment);
			collectionsQueue.Enqueue(this._physicianPaymentCollectionViaMvpaymentCheckDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._checkPayment = (EntityCollection<CheckPaymentEntity>) collectionsQueue.Dequeue();
			this._echeckPayment = (EntityCollection<EcheckPaymentEntity>) collectionsQueue.Dequeue();
			this._mvpaymentCheckDetails = (EntityCollection<MVPaymentCheckDetailsEntity>) collectionsQueue.Dequeue();
			this._paymentCollectionViaEcheckPayment = (EntityCollection<PaymentEntity>) collectionsQueue.Dequeue();
			this._paymentCollectionViaCheckPayment = (EntityCollection<PaymentEntity>) collectionsQueue.Dequeue();
			this._physicianPaymentCollectionViaMvpaymentCheckDetails = (EntityCollection<PhysicianPaymentEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._checkPayment != null)
			{
				return true;
			}
			if (this._echeckPayment != null)
			{
				return true;
			}
			if (this._mvpaymentCheckDetails != null)
			{
				return true;
			}
			if (this._paymentCollectionViaEcheckPayment != null)
			{
				return true;
			}
			if (this._paymentCollectionViaCheckPayment != null)
			{
				return true;
			}
			if (this._physicianPaymentCollectionViaMvpaymentCheckDetails != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EcheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MVPaymentCheckDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentCheckDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPaymentEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CheckPayment", _checkPayment);
			toReturn.Add("EcheckPayment", _echeckPayment);
			toReturn.Add("MvpaymentCheckDetails", _mvpaymentCheckDetails);
			toReturn.Add("PaymentCollectionViaEcheckPayment", _paymentCollectionViaEcheckPayment);
			toReturn.Add("PaymentCollectionViaCheckPayment", _paymentCollectionViaCheckPayment);
			toReturn.Add("PhysicianPaymentCollectionViaMvpaymentCheckDetails", _physicianPaymentCollectionViaMvpaymentCheckDetails);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_checkPayment!=null)
			{
				_checkPayment.ActiveContext = base.ActiveContext;
			}
			if(_echeckPayment!=null)
			{
				_echeckPayment.ActiveContext = base.ActiveContext;
			}
			if(_mvpaymentCheckDetails!=null)
			{
				_mvpaymentCheckDetails.ActiveContext = base.ActiveContext;
			}
			if(_paymentCollectionViaEcheckPayment!=null)
			{
				_paymentCollectionViaEcheckPayment.ActiveContext = base.ActiveContext;
			}
			if(_paymentCollectionViaCheckPayment!=null)
			{
				_paymentCollectionViaCheckPayment.ActiveContext = base.ActiveContext;
			}
			if(_physicianPaymentCollectionViaMvpaymentCheckDetails!=null)
			{
				_physicianPaymentCollectionViaMvpaymentCheckDetails.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_checkPayment = null;
			_echeckPayment = null;
			_mvpaymentCheckDetails = null;
			_paymentCollectionViaEcheckPayment = null;
			_paymentCollectionViaCheckPayment = null;
			_physicianPaymentCollectionViaMvpaymentCheckDetails = null;
			_organizationRoleUser_ = null;
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

			_fieldsCustomProperties.Add("CheckId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PayableTo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Amount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoutingNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BankName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Memo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AccountNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DataRecoderCreatorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DataRecoderModifierId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsElectronic", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AccountHolderName", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CheckEntity.Relations.OrganizationRoleUserEntityUsingDataRecoderModifierId, true, signalRelatedEntity, "Check_", resetFKFields, new int[] { (int)CheckFieldIndex.DataRecoderModifierId } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CheckEntity.Relations.OrganizationRoleUserEntityUsingDataRecoderModifierId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CheckEntity.Relations.OrganizationRoleUserEntityUsingDataRecoderCreatorId, true, signalRelatedEntity, "Check", resetFKFields, new int[] { (int)CheckFieldIndex.DataRecoderCreatorId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CheckEntity.Relations.OrganizationRoleUserEntityUsingDataRecoderCreatorId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CheckEntity</param>
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
		public  static CheckRelations Relations
		{
			get	{ return new CheckRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckPayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckPaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckPayment")[0], (int)Falcon.Data.EntityType.CheckEntity, (int)Falcon.Data.EntityType.CheckPaymentEntity, 0, null, null, null, null, "CheckPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EcheckPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEcheckPayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EcheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("EcheckPayment")[0], (int)Falcon.Data.EntityType.CheckEntity, (int)Falcon.Data.EntityType.EcheckPaymentEntity, 0, null, null, null, null, "EcheckPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MVPaymentCheckDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMvpaymentCheckDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MVPaymentCheckDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MVPaymentCheckDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("MvpaymentCheckDetails")[0], (int)Falcon.Data.EntityType.CheckEntity, (int)Falcon.Data.EntityType.MVPaymentCheckDetailsEntity, 0, null, null, null, null, "MvpaymentCheckDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Payment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentCollectionViaEcheckPayment
		{
			get
			{
				IEntityRelation intermediateRelation = CheckEntity.Relations.EcheckPaymentEntityUsingEcheckId;
				intermediateRelation.SetAliases(string.Empty, "EcheckPayment_");
				return new PrefetchPathElement2(new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckEntity, (int)Falcon.Data.EntityType.PaymentEntity, 0, null, null, GetRelationsForField("PaymentCollectionViaEcheckPayment"), null, "PaymentCollectionViaEcheckPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Payment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentCollectionViaCheckPayment
		{
			get
			{
				IEntityRelation intermediateRelation = CheckEntity.Relations.CheckPaymentEntityUsingCheckId;
				intermediateRelation.SetAliases(string.Empty, "CheckPayment_");
				return new PrefetchPathElement2(new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckEntity, (int)Falcon.Data.EntityType.PaymentEntity, 0, null, null, GetRelationsForField("PaymentCollectionViaCheckPayment"), null, "PaymentCollectionViaCheckPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianPaymentCollectionViaMvpaymentCheckDetails
		{
			get
			{
				IEntityRelation intermediateRelation = CheckEntity.Relations.MVPaymentCheckDetailsEntityUsingCheckId;
				intermediateRelation.SetAliases(string.Empty, "MVPaymentCheckDetails_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPaymentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CheckEntity, (int)Falcon.Data.EntityType.PhysicianPaymentEntity, 0, null, null, GetRelationsForField("PhysicianPaymentCollectionViaMvpaymentCheckDetails"), null, "PhysicianPaymentCollectionViaMvpaymentCheckDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CheckEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CheckEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CheckEntity.CustomProperties;}
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
			get { return CheckEntity.FieldsCustomProperties;}
		}

		/// <summary> The CheckId property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."CheckID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CheckId
		{
			get { return (System.Int64)GetValue((int)CheckFieldIndex.CheckId, true); }
			set	{ SetValue((int)CheckFieldIndex.CheckId, value); }
		}

		/// <summary> The PayableTo property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."PayableTo"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PayableTo
		{
			get { return (System.String)GetValue((int)CheckFieldIndex.PayableTo, true); }
			set	{ SetValue((int)CheckFieldIndex.PayableTo, value); }
		}

		/// <summary> The Amount property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."Amount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Money, 19, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Amount
		{
			get { return (System.Decimal)GetValue((int)CheckFieldIndex.Amount, true); }
			set	{ SetValue((int)CheckFieldIndex.Amount, value); }
		}

		/// <summary> The CheckNumber property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."CheckNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CheckNumber
		{
			get { return (System.String)GetValue((int)CheckFieldIndex.CheckNumber, true); }
			set	{ SetValue((int)CheckFieldIndex.CheckNumber, value); }
		}

		/// <summary> The RoutingNumber property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."RoutingNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String RoutingNumber
		{
			get { return (System.String)GetValue((int)CheckFieldIndex.RoutingNumber, true); }
			set	{ SetValue((int)CheckFieldIndex.RoutingNumber, value); }
		}

		/// <summary> The BankName property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."BankName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BankName
		{
			get { return (System.String)GetValue((int)CheckFieldIndex.BankName, true); }
			set	{ SetValue((int)CheckFieldIndex.BankName, value); }
		}

		/// <summary> The Memo property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."Memo"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Memo
		{
			get { return (System.String)GetValue((int)CheckFieldIndex.Memo, true); }
			set	{ SetValue((int)CheckFieldIndex.Memo, value); }
		}

		/// <summary> The AccountNumber property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."AccountNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AccountNumber
		{
			get { return (System.String)GetValue((int)CheckFieldIndex.AccountNumber, true); }
			set	{ SetValue((int)CheckFieldIndex.AccountNumber, value); }
		}

		/// <summary> The CheckDate property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."CheckDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CheckDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CheckFieldIndex.CheckDate, false); }
			set	{ SetValue((int)CheckFieldIndex.CheckDate, value); }
		}

		/// <summary> The DataRecoderCreatorId property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."DataRecoderCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 DataRecoderCreatorId
		{
			get { return (System.Int64)GetValue((int)CheckFieldIndex.DataRecoderCreatorId, true); }
			set	{ SetValue((int)CheckFieldIndex.DataRecoderCreatorId, value); }
		}

		/// <summary> The DataRecoderModifierId property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."DataRecoderModifierID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DataRecoderModifierId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CheckFieldIndex.DataRecoderModifierId, false); }
			set	{ SetValue((int)CheckFieldIndex.DataRecoderModifierId, value); }
		}

		/// <summary> The DateCreated property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CheckFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CheckFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CheckFieldIndex.DateModified, false); }
			set	{ SetValue((int)CheckFieldIndex.DateModified, value); }
		}

		/// <summary> The IsElectronic property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."IsElectronic"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsElectronic
		{
			get { return (System.Boolean)GetValue((int)CheckFieldIndex.IsElectronic, true); }
			set	{ SetValue((int)CheckFieldIndex.IsElectronic, value); }
		}

		/// <summary> The AccountHolderName property of the Entity Check<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCheck"."AccountHolderName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AccountHolderName
		{
			get { return (System.String)GetValue((int)CheckFieldIndex.AccountHolderName, true); }
			set	{ SetValue((int)CheckFieldIndex.AccountHolderName, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckPaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckPaymentEntity))]
		public virtual EntityCollection<CheckPaymentEntity> CheckPayment
		{
			get
			{
				if(_checkPayment==null)
				{
					_checkPayment = new EntityCollection<CheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckPaymentEntityFactory)));
					_checkPayment.SetContainingEntityInfo(this, "Check");
				}
				return _checkPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EcheckPaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EcheckPaymentEntity))]
		public virtual EntityCollection<EcheckPaymentEntity> EcheckPayment
		{
			get
			{
				if(_echeckPayment==null)
				{
					_echeckPayment = new EntityCollection<EcheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentEntityFactory)));
					_echeckPayment.SetContainingEntityInfo(this, "Check");
				}
				return _echeckPayment;
			}
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
					_mvpaymentCheckDetails.SetContainingEntityInfo(this, "Check");
				}
				return _mvpaymentCheckDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentEntity))]
		public virtual EntityCollection<PaymentEntity> PaymentCollectionViaEcheckPayment
		{
			get
			{
				if(_paymentCollectionViaEcheckPayment==null)
				{
					_paymentCollectionViaEcheckPayment = new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory)));
					_paymentCollectionViaEcheckPayment.IsReadOnly=true;
				}
				return _paymentCollectionViaEcheckPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentEntity))]
		public virtual EntityCollection<PaymentEntity> PaymentCollectionViaCheckPayment
		{
			get
			{
				if(_paymentCollectionViaCheckPayment==null)
				{
					_paymentCollectionViaCheckPayment = new EntityCollection<PaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory)));
					_paymentCollectionViaCheckPayment.IsReadOnly=true;
				}
				return _paymentCollectionViaCheckPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianPaymentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianPaymentEntity))]
		public virtual EntityCollection<PhysicianPaymentEntity> PhysicianPaymentCollectionViaMvpaymentCheckDetails
		{
			get
			{
				if(_physicianPaymentCollectionViaMvpaymentCheckDetails==null)
				{
					_physicianPaymentCollectionViaMvpaymentCheckDetails = new EntityCollection<PhysicianPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPaymentEntityFactory)));
					_physicianPaymentCollectionViaMvpaymentCheckDetails.IsReadOnly=true;
				}
				return _physicianPaymentCollectionViaMvpaymentCheckDetails;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "Check_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Check_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Check");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Check");
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
			get { return (int)Falcon.Data.EntityType.CheckEntity; }
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
