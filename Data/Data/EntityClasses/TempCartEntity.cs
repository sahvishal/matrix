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
	/// Entity class which represents the entity 'TempCart'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TempCartEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<PreQualificationResultEntity> _preQualificationResult;
		private EntityCollection<CallsEntity> _callsCollectionViaPreQualificationResult;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaPreQualificationResult;
		private EntityCollection<EventsEntity> _eventsCollectionViaPreQualificationResult;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult_______;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult________;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult______;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult__;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult_;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult___;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult_____;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationResult____;
		private ChargeCardEntity _chargeCard;
		private CustomerProfileEntity _customerProfile;
		private EligibilityEntity _eligibility;
		private ProspectCustomerEntity _prospectCustomer;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ChargeCard</summary>
			public static readonly string ChargeCard = "ChargeCard";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Eligibility</summary>
			public static readonly string Eligibility = "Eligibility";
			/// <summary>Member name ProspectCustomer</summary>
			public static readonly string ProspectCustomer = "ProspectCustomer";
			/// <summary>Member name PreQualificationResult</summary>
			public static readonly string PreQualificationResult = "PreQualificationResult";
			/// <summary>Member name CallsCollectionViaPreQualificationResult</summary>
			public static readonly string CallsCollectionViaPreQualificationResult = "CallsCollectionViaPreQualificationResult";
			/// <summary>Member name CustomerProfileCollectionViaPreQualificationResult</summary>
			public static readonly string CustomerProfileCollectionViaPreQualificationResult = "CustomerProfileCollectionViaPreQualificationResult";
			/// <summary>Member name EventsCollectionViaPreQualificationResult</summary>
			public static readonly string EventsCollectionViaPreQualificationResult = "EventsCollectionViaPreQualificationResult";
			/// <summary>Member name LookupCollectionViaPreQualificationResult_______</summary>
			public static readonly string LookupCollectionViaPreQualificationResult_______ = "LookupCollectionViaPreQualificationResult_______";
			/// <summary>Member name LookupCollectionViaPreQualificationResult________</summary>
			public static readonly string LookupCollectionViaPreQualificationResult________ = "LookupCollectionViaPreQualificationResult________";
			/// <summary>Member name LookupCollectionViaPreQualificationResult</summary>
			public static readonly string LookupCollectionViaPreQualificationResult = "LookupCollectionViaPreQualificationResult";
			/// <summary>Member name LookupCollectionViaPreQualificationResult______</summary>
			public static readonly string LookupCollectionViaPreQualificationResult______ = "LookupCollectionViaPreQualificationResult______";
			/// <summary>Member name LookupCollectionViaPreQualificationResult__</summary>
			public static readonly string LookupCollectionViaPreQualificationResult__ = "LookupCollectionViaPreQualificationResult__";
			/// <summary>Member name LookupCollectionViaPreQualificationResult_</summary>
			public static readonly string LookupCollectionViaPreQualificationResult_ = "LookupCollectionViaPreQualificationResult_";
			/// <summary>Member name LookupCollectionViaPreQualificationResult___</summary>
			public static readonly string LookupCollectionViaPreQualificationResult___ = "LookupCollectionViaPreQualificationResult___";
			/// <summary>Member name LookupCollectionViaPreQualificationResult_____</summary>
			public static readonly string LookupCollectionViaPreQualificationResult_____ = "LookupCollectionViaPreQualificationResult_____";
			/// <summary>Member name LookupCollectionViaPreQualificationResult____</summary>
			public static readonly string LookupCollectionViaPreQualificationResult____ = "LookupCollectionViaPreQualificationResult____";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TempCartEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TempCartEntity():base("TempCartEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TempCartEntity(IEntityFields2 fields):base("TempCartEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TempCartEntity</param>
		public TempCartEntity(IValidator validator):base("TempCartEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for TempCart which data should be fetched into this TempCart object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TempCartEntity(System.Int64 id):base("TempCartEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for TempCart which data should be fetched into this TempCart object</param>
		/// <param name="validator">The custom validator object for this TempCartEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TempCartEntity(System.Int64 id, IValidator validator):base("TempCartEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TempCartEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_preQualificationResult = (EntityCollection<PreQualificationResultEntity>)info.GetValue("_preQualificationResult", typeof(EntityCollection<PreQualificationResultEntity>));
				_callsCollectionViaPreQualificationResult = (EntityCollection<CallsEntity>)info.GetValue("_callsCollectionViaPreQualificationResult", typeof(EntityCollection<CallsEntity>));
				_customerProfileCollectionViaPreQualificationResult = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaPreQualificationResult", typeof(EntityCollection<CustomerProfileEntity>));
				_eventsCollectionViaPreQualificationResult = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaPreQualificationResult", typeof(EntityCollection<EventsEntity>));
				_lookupCollectionViaPreQualificationResult_______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult_______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult________ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult________", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult_____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult_____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationResult____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationResult____", typeof(EntityCollection<LookupEntity>));
				_chargeCard = (ChargeCardEntity)info.GetValue("_chargeCard", typeof(ChargeCardEntity));
				if(_chargeCard!=null)
				{
					_chargeCard.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eligibility = (EligibilityEntity)info.GetValue("_eligibility", typeof(EligibilityEntity));
				if(_eligibility!=null)
				{
					_eligibility.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_prospectCustomer = (ProspectCustomerEntity)info.GetValue("_prospectCustomer", typeof(ProspectCustomerEntity));
				if(_prospectCustomer!=null)
				{
					_prospectCustomer.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TempCartFieldIndex)fieldIndex)
			{
				case TempCartFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case TempCartFieldIndex.ProspectCustomerId:
					DesetupSyncProspectCustomer(true, false);
					break;
				case TempCartFieldIndex.EligibilityId:
					DesetupSyncEligibility(true, false);
					break;
				case TempCartFieldIndex.ChargeCardId:
					DesetupSyncChargeCard(true, false);
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
				case "ChargeCard":
					this.ChargeCard = (ChargeCardEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Eligibility":
					this.Eligibility = (EligibilityEntity)entity;
					break;
				case "ProspectCustomer":
					this.ProspectCustomer = (ProspectCustomerEntity)entity;
					break;
				case "PreQualificationResult":
					this.PreQualificationResult.Add((PreQualificationResultEntity)entity);
					break;
				case "CallsCollectionViaPreQualificationResult":
					this.CallsCollectionViaPreQualificationResult.IsReadOnly = false;
					this.CallsCollectionViaPreQualificationResult.Add((CallsEntity)entity);
					this.CallsCollectionViaPreQualificationResult.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaPreQualificationResult":
					this.CustomerProfileCollectionViaPreQualificationResult.IsReadOnly = false;
					this.CustomerProfileCollectionViaPreQualificationResult.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaPreQualificationResult.IsReadOnly = true;
					break;
				case "EventsCollectionViaPreQualificationResult":
					this.EventsCollectionViaPreQualificationResult.IsReadOnly = false;
					this.EventsCollectionViaPreQualificationResult.Add((EventsEntity)entity);
					this.EventsCollectionViaPreQualificationResult.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult_______":
					this.LookupCollectionViaPreQualificationResult_______.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult_______.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult_______.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult________":
					this.LookupCollectionViaPreQualificationResult________.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult________.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult________.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult":
					this.LookupCollectionViaPreQualificationResult.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult______":
					this.LookupCollectionViaPreQualificationResult______.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult______.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult______.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult__":
					this.LookupCollectionViaPreQualificationResult__.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult__.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult__.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult_":
					this.LookupCollectionViaPreQualificationResult_.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult_.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult_.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult___":
					this.LookupCollectionViaPreQualificationResult___.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult___.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult___.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult_____":
					this.LookupCollectionViaPreQualificationResult_____.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult_____.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult_____.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationResult____":
					this.LookupCollectionViaPreQualificationResult____.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationResult____.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationResult____.IsReadOnly = true;
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
			return TempCartEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ChargeCard":
					toReturn.Add(TempCartEntity.Relations.ChargeCardEntityUsingChargeCardId);
					break;
				case "CustomerProfile":
					toReturn.Add(TempCartEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Eligibility":
					toReturn.Add(TempCartEntity.Relations.EligibilityEntityUsingEligibilityId);
					break;
				case "ProspectCustomer":
					toReturn.Add(TempCartEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId);
					break;
				case "PreQualificationResult":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId);
					break;
				case "CallsCollectionViaPreQualificationResult":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.CallsEntityUsingCallId, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaPreQualificationResult":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.CustomerProfileEntityUsingCustomerId, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaPreQualificationResult":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.EventsEntityUsingEventId, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult_______":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingOverWeight, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult________":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingSmoker, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingAgeOverPreQualificationQuestion, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult______":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHighCholestrol, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult__":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingDiabetic, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult_":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingChestPain, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult___":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingDiagnosedHeartProblem, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult_____":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHighBloodPressure, "PreQualificationResult_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationResult____":
					toReturn.Add(TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId, "TempCartEntity__", "PreQualificationResult_", JoinHint.None);
					toReturn.Add(PreQualificationResultEntity.Relations.LookupEntityUsingHeartDisease, "PreQualificationResult_", string.Empty, JoinHint.None);
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
				case "ChargeCard":
					SetupSyncChargeCard(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Eligibility":
					SetupSyncEligibility(relatedEntity);
					break;
				case "ProspectCustomer":
					SetupSyncProspectCustomer(relatedEntity);
					break;
				case "PreQualificationResult":
					this.PreQualificationResult.Add((PreQualificationResultEntity)relatedEntity);
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
				case "ChargeCard":
					DesetupSyncChargeCard(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Eligibility":
					DesetupSyncEligibility(false, true);
					break;
				case "ProspectCustomer":
					DesetupSyncProspectCustomer(false, true);
					break;
				case "PreQualificationResult":
					base.PerformRelatedEntityRemoval(this.PreQualificationResult, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_chargeCard!=null)
			{
				toReturn.Add(_chargeCard);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_eligibility!=null)
			{
				toReturn.Add(_eligibility);
			}
			if(_prospectCustomer!=null)
			{
				toReturn.Add(_prospectCustomer);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.PreQualificationResult);

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
				info.AddValue("_preQualificationResult", ((_preQualificationResult!=null) && (_preQualificationResult.Count>0) && !this.MarkedForDeletion)?_preQualificationResult:null);
				info.AddValue("_callsCollectionViaPreQualificationResult", ((_callsCollectionViaPreQualificationResult!=null) && (_callsCollectionViaPreQualificationResult.Count>0) && !this.MarkedForDeletion)?_callsCollectionViaPreQualificationResult:null);
				info.AddValue("_customerProfileCollectionViaPreQualificationResult", ((_customerProfileCollectionViaPreQualificationResult!=null) && (_customerProfileCollectionViaPreQualificationResult.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaPreQualificationResult:null);
				info.AddValue("_eventsCollectionViaPreQualificationResult", ((_eventsCollectionViaPreQualificationResult!=null) && (_eventsCollectionViaPreQualificationResult.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaPreQualificationResult:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult_______", ((_lookupCollectionViaPreQualificationResult_______!=null) && (_lookupCollectionViaPreQualificationResult_______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult_______:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult________", ((_lookupCollectionViaPreQualificationResult________!=null) && (_lookupCollectionViaPreQualificationResult________.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult________:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult", ((_lookupCollectionViaPreQualificationResult!=null) && (_lookupCollectionViaPreQualificationResult.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult______", ((_lookupCollectionViaPreQualificationResult______!=null) && (_lookupCollectionViaPreQualificationResult______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult______:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult__", ((_lookupCollectionViaPreQualificationResult__!=null) && (_lookupCollectionViaPreQualificationResult__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult__:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult_", ((_lookupCollectionViaPreQualificationResult_!=null) && (_lookupCollectionViaPreQualificationResult_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult_:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult___", ((_lookupCollectionViaPreQualificationResult___!=null) && (_lookupCollectionViaPreQualificationResult___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult___:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult_____", ((_lookupCollectionViaPreQualificationResult_____!=null) && (_lookupCollectionViaPreQualificationResult_____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult_____:null);
				info.AddValue("_lookupCollectionViaPreQualificationResult____", ((_lookupCollectionViaPreQualificationResult____!=null) && (_lookupCollectionViaPreQualificationResult____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationResult____:null);
				info.AddValue("_chargeCard", (!this.MarkedForDeletion?_chargeCard:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_eligibility", (!this.MarkedForDeletion?_eligibility:null));
				info.AddValue("_prospectCustomer", (!this.MarkedForDeletion?_prospectCustomer:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TempCartFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TempCartFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TempCartRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationResult' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationResultFields.TempCartId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallsCollectionViaPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallsCollectionViaPreQualificationResult"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaPreQualificationResult"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaPreQualificationResult"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationResult____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationResult____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.Id, null, ComparisonOperator.Equal, this.Id, "TempCartEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ChargeCard' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChargeCard()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardFields.ChargeCardId, null, ComparisonOperator.Equal, this.ChargeCardId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Eligibility' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EligibilityFields.EligibilityId, null, ComparisonOperator.Equal, this.EligibilityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TempCartEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._preQualificationResult);
			collectionsQueue.Enqueue(this._callsCollectionViaPreQualificationResult);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaPreQualificationResult);
			collectionsQueue.Enqueue(this._eventsCollectionViaPreQualificationResult);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult_______);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult________);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult______);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult__);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult_);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult___);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult_____);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationResult____);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._preQualificationResult = (EntityCollection<PreQualificationResultEntity>) collectionsQueue.Dequeue();
			this._callsCollectionViaPreQualificationResult = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaPreQualificationResult = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaPreQualificationResult = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult_______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult________ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult_____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationResult____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._preQualificationResult != null)
			{
				return true;
			}
			if (this._callsCollectionViaPreQualificationResult != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaPreQualificationResult != null)
			{
				return true;
			}
			if (this._eventsCollectionViaPreQualificationResult != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult_______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult________ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult_____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationResult____ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationResultEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ChargeCard", _chargeCard);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Eligibility", _eligibility);
			toReturn.Add("ProspectCustomer", _prospectCustomer);
			toReturn.Add("PreQualificationResult", _preQualificationResult);
			toReturn.Add("CallsCollectionViaPreQualificationResult", _callsCollectionViaPreQualificationResult);
			toReturn.Add("CustomerProfileCollectionViaPreQualificationResult", _customerProfileCollectionViaPreQualificationResult);
			toReturn.Add("EventsCollectionViaPreQualificationResult", _eventsCollectionViaPreQualificationResult);
			toReturn.Add("LookupCollectionViaPreQualificationResult_______", _lookupCollectionViaPreQualificationResult_______);
			toReturn.Add("LookupCollectionViaPreQualificationResult________", _lookupCollectionViaPreQualificationResult________);
			toReturn.Add("LookupCollectionViaPreQualificationResult", _lookupCollectionViaPreQualificationResult);
			toReturn.Add("LookupCollectionViaPreQualificationResult______", _lookupCollectionViaPreQualificationResult______);
			toReturn.Add("LookupCollectionViaPreQualificationResult__", _lookupCollectionViaPreQualificationResult__);
			toReturn.Add("LookupCollectionViaPreQualificationResult_", _lookupCollectionViaPreQualificationResult_);
			toReturn.Add("LookupCollectionViaPreQualificationResult___", _lookupCollectionViaPreQualificationResult___);
			toReturn.Add("LookupCollectionViaPreQualificationResult_____", _lookupCollectionViaPreQualificationResult_____);
			toReturn.Add("LookupCollectionViaPreQualificationResult____", _lookupCollectionViaPreQualificationResult____);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_preQualificationResult!=null)
			{
				_preQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_callsCollectionViaPreQualificationResult!=null)
			{
				_callsCollectionViaPreQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaPreQualificationResult!=null)
			{
				_customerProfileCollectionViaPreQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaPreQualificationResult!=null)
			{
				_eventsCollectionViaPreQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult_______!=null)
			{
				_lookupCollectionViaPreQualificationResult_______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult________!=null)
			{
				_lookupCollectionViaPreQualificationResult________.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult!=null)
			{
				_lookupCollectionViaPreQualificationResult.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult______!=null)
			{
				_lookupCollectionViaPreQualificationResult______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult__!=null)
			{
				_lookupCollectionViaPreQualificationResult__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult_!=null)
			{
				_lookupCollectionViaPreQualificationResult_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult___!=null)
			{
				_lookupCollectionViaPreQualificationResult___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult_____!=null)
			{
				_lookupCollectionViaPreQualificationResult_____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationResult____!=null)
			{
				_lookupCollectionViaPreQualificationResult____.ActiveContext = base.ActiveContext;
			}
			if(_chargeCard!=null)
			{
				_chargeCard.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_eligibility!=null)
			{
				_eligibility.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomer!=null)
			{
				_prospectCustomer.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_preQualificationResult = null;
			_callsCollectionViaPreQualificationResult = null;
			_customerProfileCollectionViaPreQualificationResult = null;
			_eventsCollectionViaPreQualificationResult = null;
			_lookupCollectionViaPreQualificationResult_______ = null;
			_lookupCollectionViaPreQualificationResult________ = null;
			_lookupCollectionViaPreQualificationResult = null;
			_lookupCollectionViaPreQualificationResult______ = null;
			_lookupCollectionViaPreQualificationResult__ = null;
			_lookupCollectionViaPreQualificationResult_ = null;
			_lookupCollectionViaPreQualificationResult___ = null;
			_lookupCollectionViaPreQualificationResult_____ = null;
			_lookupCollectionViaPreQualificationResult____ = null;
			_chargeCard = null;
			_customerProfile = null;
			_eligibility = null;
			_prospectCustomer = null;

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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Guid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventPackageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SourceCodeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProductId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Shippingid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentMode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PaymentAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPaymentSuccessful", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsHafFilled", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EntryPage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ExitPage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ipaddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScreenResolution", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Browser", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsCompleted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsExistingCustomer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LoginAtempt", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShippingAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InvitationCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CorpCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Radius", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsUsedAppointmentSlotExpiryExtension", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InChainAppointmentSlots", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreliminarySelectedTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dob", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Version", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EligibilityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChargeCardId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _chargeCard</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChargeCard(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _chargeCard, new PropertyChangedEventHandler( OnChargeCardPropertyChanged ), "ChargeCard", TempCartEntity.Relations.ChargeCardEntityUsingChargeCardId, true, signalRelatedEntity, "TempCart", resetFKFields, new int[] { (int)TempCartFieldIndex.ChargeCardId } );		
			_chargeCard = null;
		}

		/// <summary> setups the sync logic for member _chargeCard</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncChargeCard(IEntity2 relatedEntity)
		{
			if(_chargeCard!=relatedEntity)
			{
				DesetupSyncChargeCard(true, true);
				_chargeCard = (ChargeCardEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _chargeCard, new PropertyChangedEventHandler( OnChargeCardPropertyChanged ), "ChargeCard", TempCartEntity.Relations.ChargeCardEntityUsingChargeCardId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChargeCardPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", TempCartEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "TempCart", resetFKFields, new int[] { (int)TempCartFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", TempCartEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eligibility</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEligibility(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eligibility, new PropertyChangedEventHandler( OnEligibilityPropertyChanged ), "Eligibility", TempCartEntity.Relations.EligibilityEntityUsingEligibilityId, true, signalRelatedEntity, "TempCart", resetFKFields, new int[] { (int)TempCartFieldIndex.EligibilityId } );		
			_eligibility = null;
		}

		/// <summary> setups the sync logic for member _eligibility</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEligibility(IEntity2 relatedEntity)
		{
			if(_eligibility!=relatedEntity)
			{
				DesetupSyncEligibility(true, true);
				_eligibility = (EligibilityEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eligibility, new PropertyChangedEventHandler( OnEligibilityPropertyChanged ), "Eligibility", TempCartEntity.Relations.EligibilityEntityUsingEligibilityId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEligibilityPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _prospectCustomer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProspectCustomer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _prospectCustomer, new PropertyChangedEventHandler( OnProspectCustomerPropertyChanged ), "ProspectCustomer", TempCartEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, true, signalRelatedEntity, "TempCart", resetFKFields, new int[] { (int)TempCartFieldIndex.ProspectCustomerId } );		
			_prospectCustomer = null;
		}

		/// <summary> setups the sync logic for member _prospectCustomer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProspectCustomer(IEntity2 relatedEntity)
		{
			if(_prospectCustomer!=relatedEntity)
			{
				DesetupSyncProspectCustomer(true, true);
				_prospectCustomer = (ProspectCustomerEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _prospectCustomer, new PropertyChangedEventHandler( OnProspectCustomerPropertyChanged ), "ProspectCustomer", TempCartEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProspectCustomerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TempCartEntity</param>
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
		public  static TempCartRelations Relations
		{
			get	{ return new TempCartRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationResult' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationResult
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreQualificationResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationResultEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationResult")[0], (int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.PreQualificationResultEntity, 0, null, null, null, null, "PreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallsCollectionViaPreQualificationResult
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, GetRelationsForField("CallsCollectionViaPreQualificationResult"), null, "CallsCollectionViaPreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaPreQualificationResult
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaPreQualificationResult"), null, "CustomerProfileCollectionViaPreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaPreQualificationResult
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaPreQualificationResult"), null, "EventsCollectionViaPreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult_______
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult_______"), null, "LookupCollectionViaPreQualificationResult_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult________
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult________"), null, "LookupCollectionViaPreQualificationResult________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult"), null, "LookupCollectionViaPreQualificationResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult______
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult______"), null, "LookupCollectionViaPreQualificationResult______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult__
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult__"), null, "LookupCollectionViaPreQualificationResult__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult_
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult_"), null, "LookupCollectionViaPreQualificationResult_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult___
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult___"), null, "LookupCollectionViaPreQualificationResult___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult_____
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult_____"), null, "LookupCollectionViaPreQualificationResult_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationResult____
		{
			get
			{
				IEntityRelation intermediateRelation = TempCartEntity.Relations.PreQualificationResultEntityUsingTempCartId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationResult_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationResult____"), null, "LookupCollectionViaPreQualificationResult____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChargeCard' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChargeCard
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChargeCard")[0], (int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.ChargeCardEntity, 0, null, null, null, null, "ChargeCard", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Eligibility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEligibility
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("Eligibility")[0], (int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.EligibilityEntity, 0, null, null, null, null, "Eligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectCustomer")[0], (int)Falcon.Data.EntityType.TempCartEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, null, null, "ProspectCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TempCartEntity.CustomProperties;}
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
			get { return TempCartEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)TempCartFieldIndex.Id, true); }
			set	{ SetValue((int)TempCartFieldIndex.Id, value); }
		}

		/// <summary> The Guid property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."Guid"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Guid
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.Guid, true); }
			set	{ SetValue((int)TempCartFieldIndex.Guid, value); }
		}

		/// <summary> The ZipCode property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."ZipCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ZipCode
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.ZipCode, true); }
			set	{ SetValue((int)TempCartFieldIndex.ZipCode, value); }
		}

		/// <summary> The EventId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."EventId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EventId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.EventId, false); }
			set	{ SetValue((int)TempCartFieldIndex.EventId, value); }
		}

		/// <summary> The CustomerId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.CustomerId, false); }
			set	{ SetValue((int)TempCartFieldIndex.CustomerId, value); }
		}

		/// <summary> The ProspectCustomerId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."ProspectCustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProspectCustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.ProspectCustomerId, false); }
			set	{ SetValue((int)TempCartFieldIndex.ProspectCustomerId, value); }
		}

		/// <summary> The AppointmentId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."AppointmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AppointmentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.AppointmentId, false); }
			set	{ SetValue((int)TempCartFieldIndex.AppointmentId, value); }
		}

		/// <summary> The EventPackageId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."EventPackageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EventPackageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.EventPackageId, false); }
			set	{ SetValue((int)TempCartFieldIndex.EventPackageId, value); }
		}

		/// <summary> The SourceCodeId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."SourceCodeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SourceCodeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.SourceCodeId, false); }
			set	{ SetValue((int)TempCartFieldIndex.SourceCodeId, value); }
		}

		/// <summary> The TestId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."TestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TestId
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.TestId, true); }
			set	{ SetValue((int)TempCartFieldIndex.TestId, value); }
		}

		/// <summary> The ProductId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."ProductId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ProductId
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.ProductId, true); }
			set	{ SetValue((int)TempCartFieldIndex.ProductId, value); }
		}

		/// <summary> The Shippingid property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."Shippingid"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Shippingid
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.Shippingid, false); }
			set	{ SetValue((int)TempCartFieldIndex.Shippingid, value); }
		}

		/// <summary> The PaymentMode property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."PaymentMode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PaymentMode
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.PaymentMode, true); }
			set	{ SetValue((int)TempCartFieldIndex.PaymentMode, value); }
		}

		/// <summary> The PaymentAmount property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."PaymentAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> PaymentAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)TempCartFieldIndex.PaymentAmount, false); }
			set	{ SetValue((int)TempCartFieldIndex.PaymentAmount, value); }
		}

		/// <summary> The IsPaymentSuccessful property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."IsPaymentSuccessful"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsPaymentSuccessful
		{
			get { return (Nullable<System.Boolean>)GetValue((int)TempCartFieldIndex.IsPaymentSuccessful, false); }
			set	{ SetValue((int)TempCartFieldIndex.IsPaymentSuccessful, value); }
		}

		/// <summary> The IsHafFilled property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."IsHafFilled"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsHafFilled
		{
			get { return (Nullable<System.Boolean>)GetValue((int)TempCartFieldIndex.IsHafFilled, false); }
			set	{ SetValue((int)TempCartFieldIndex.IsHafFilled, value); }
		}

		/// <summary> The EntryPage property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."EntryPage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EntryPage
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.EntryPage, true); }
			set	{ SetValue((int)TempCartFieldIndex.EntryPage, value); }
		}

		/// <summary> The ExitPage property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."ExitPage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ExitPage
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.ExitPage, true); }
			set	{ SetValue((int)TempCartFieldIndex.ExitPage, value); }
		}

		/// <summary> The Ipaddress property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."IPAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Ipaddress
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.Ipaddress, true); }
			set	{ SetValue((int)TempCartFieldIndex.Ipaddress, value); }
		}

		/// <summary> The ScreenResolution property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."ScreenResolution"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ScreenResolution
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.ScreenResolution, true); }
			set	{ SetValue((int)TempCartFieldIndex.ScreenResolution, value); }
		}

		/// <summary> The Browser property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."Browser"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Browser
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.Browser, true); }
			set	{ SetValue((int)TempCartFieldIndex.Browser, value); }
		}

		/// <summary> The IsCompleted property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."IsCompleted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsCompleted
		{
			get { return (System.Boolean)GetValue((int)TempCartFieldIndex.IsCompleted, true); }
			set	{ SetValue((int)TempCartFieldIndex.IsCompleted, value); }
		}

		/// <summary> The IsExistingCustomer property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."IsExistingCustomer"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsExistingCustomer
		{
			get { return (System.Boolean)GetValue((int)TempCartFieldIndex.IsExistingCustomer, true); }
			set	{ SetValue((int)TempCartFieldIndex.IsExistingCustomer, value); }
		}

		/// <summary> The LoginAtempt property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."LoginAttempt"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 LoginAtempt
		{
			get { return (System.Int32)GetValue((int)TempCartFieldIndex.LoginAtempt, true); }
			set	{ SetValue((int)TempCartFieldIndex.LoginAtempt, value); }
		}

		/// <summary> The DateCreated property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)TempCartFieldIndex.DateCreated, true); }
			set	{ SetValue((int)TempCartFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TempCartFieldIndex.DateModified, false); }
			set	{ SetValue((int)TempCartFieldIndex.DateModified, value); }
		}

		/// <summary> The ShippingAddressId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."ShippingAddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ShippingAddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.ShippingAddressId, false); }
			set	{ SetValue((int)TempCartFieldIndex.ShippingAddressId, value); }
		}

		/// <summary> The InvitationCode property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."InvitationCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String InvitationCode
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.InvitationCode, true); }
			set	{ SetValue((int)TempCartFieldIndex.InvitationCode, value); }
		}

		/// <summary> The CorpCode property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."CorpCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CorpCode
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.CorpCode, true); }
			set	{ SetValue((int)TempCartFieldIndex.CorpCode, value); }
		}

		/// <summary> The Radius property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."Radius"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Radius
		{
			get { return (Nullable<System.Decimal>)GetValue((int)TempCartFieldIndex.Radius, false); }
			set	{ SetValue((int)TempCartFieldIndex.Radius, value); }
		}

		/// <summary> The IsUsedAppointmentSlotExpiryExtension property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."IsUsedAppointmentSlotExpiryExtension"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsUsedAppointmentSlotExpiryExtension
		{
			get { return (Nullable<System.Boolean>)GetValue((int)TempCartFieldIndex.IsUsedAppointmentSlotExpiryExtension, false); }
			set	{ SetValue((int)TempCartFieldIndex.IsUsedAppointmentSlotExpiryExtension, value); }
		}

		/// <summary> The MarketingSource property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."MarketingSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MarketingSource
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.MarketingSource, true); }
			set	{ SetValue((int)TempCartFieldIndex.MarketingSource, value); }
		}

		/// <summary> The InChainAppointmentSlots property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."InChainAppointmentSlots"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String InChainAppointmentSlots
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.InChainAppointmentSlots, true); }
			set	{ SetValue((int)TempCartFieldIndex.InChainAppointmentSlots, value); }
		}

		/// <summary> The PreliminarySelectedTime property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."PreliminarySelectedTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> PreliminarySelectedTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TempCartFieldIndex.PreliminarySelectedTime, false); }
			set	{ SetValue((int)TempCartFieldIndex.PreliminarySelectedTime, value); }
		}

		/// <summary> The Gender property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Gender
		{
			get { return (System.String)GetValue((int)TempCartFieldIndex.Gender, true); }
			set	{ SetValue((int)TempCartFieldIndex.Gender, value); }
		}

		/// <summary> The Dob property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."Dob"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Dob
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TempCartFieldIndex.Dob, false); }
			set	{ SetValue((int)TempCartFieldIndex.Dob, value); }
		}

		/// <summary> The Version property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."Version"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Version
		{
			get { return (System.Int32)GetValue((int)TempCartFieldIndex.Version, true); }
			set	{ SetValue((int)TempCartFieldIndex.Version, value); }
		}

		/// <summary> The EligibilityId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."EligibilityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EligibilityId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.EligibilityId, false); }
			set	{ SetValue((int)TempCartFieldIndex.EligibilityId, value); }
		}

		/// <summary> The ChargeCardId property of the Entity TempCart<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTempCart"."ChargeCardId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ChargeCardId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TempCartFieldIndex.ChargeCardId, false); }
			set	{ SetValue((int)TempCartFieldIndex.ChargeCardId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationResultEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationResultEntity))]
		public virtual EntityCollection<PreQualificationResultEntity> PreQualificationResult
		{
			get
			{
				if(_preQualificationResult==null)
				{
					_preQualificationResult = new EntityCollection<PreQualificationResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationResultEntityFactory)));
					_preQualificationResult.SetContainingEntityInfo(this, "TempCart");
				}
				return _preQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallsEntity))]
		public virtual EntityCollection<CallsEntity> CallsCollectionViaPreQualificationResult
		{
			get
			{
				if(_callsCollectionViaPreQualificationResult==null)
				{
					_callsCollectionViaPreQualificationResult = new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory)));
					_callsCollectionViaPreQualificationResult.IsReadOnly=true;
				}
				return _callsCollectionViaPreQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaPreQualificationResult
		{
			get
			{
				if(_customerProfileCollectionViaPreQualificationResult==null)
				{
					_customerProfileCollectionViaPreQualificationResult = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaPreQualificationResult.IsReadOnly=true;
				}
				return _customerProfileCollectionViaPreQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaPreQualificationResult
		{
			get
			{
				if(_eventsCollectionViaPreQualificationResult==null)
				{
					_eventsCollectionViaPreQualificationResult = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaPreQualificationResult.IsReadOnly=true;
				}
				return _eventsCollectionViaPreQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult_______
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult_______==null)
				{
					_lookupCollectionViaPreQualificationResult_______ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult_______.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult________
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult________==null)
				{
					_lookupCollectionViaPreQualificationResult________ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult________.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult==null)
				{
					_lookupCollectionViaPreQualificationResult = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult______
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult______==null)
				{
					_lookupCollectionViaPreQualificationResult______ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult______.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult__
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult__==null)
				{
					_lookupCollectionViaPreQualificationResult__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult__.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult_
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult_==null)
				{
					_lookupCollectionViaPreQualificationResult_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult_.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult___
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult___==null)
				{
					_lookupCollectionViaPreQualificationResult___ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult___.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult_____
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult_____==null)
				{
					_lookupCollectionViaPreQualificationResult_____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult_____.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationResult____
		{
			get
			{
				if(_lookupCollectionViaPreQualificationResult____==null)
				{
					_lookupCollectionViaPreQualificationResult____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationResult____.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationResult____;
			}
		}

		/// <summary> Gets / sets related entity of type 'ChargeCardEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ChargeCardEntity ChargeCard
		{
			get
			{
				return _chargeCard;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncChargeCard(value);
				}
				else
				{
					if(value==null)
					{
						if(_chargeCard != null)
						{
							_chargeCard.UnsetRelatedEntity(this, "TempCart");
						}
					}
					else
					{
						if(_chargeCard!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TempCart");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "TempCart");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TempCart");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EligibilityEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EligibilityEntity Eligibility
		{
			get
			{
				return _eligibility;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEligibility(value);
				}
				else
				{
					if(value==null)
					{
						if(_eligibility != null)
						{
							_eligibility.UnsetRelatedEntity(this, "TempCart");
						}
					}
					else
					{
						if(_eligibility!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TempCart");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ProspectCustomerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ProspectCustomerEntity ProspectCustomer
		{
			get
			{
				return _prospectCustomer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProspectCustomer(value);
				}
				else
				{
					if(value==null)
					{
						if(_prospectCustomer != null)
						{
							_prospectCustomer.UnsetRelatedEntity(this, "TempCart");
						}
					}
					else
					{
						if(_prospectCustomer!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TempCart");
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
			get { return (int)Falcon.Data.EntityType.TempCartEntity; }
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
