///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:50
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
	/// Entity class which represents the entity 'ChaseOutbound'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ChaseOutboundEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerChaseCampaignEntity> _customerChaseCampaign;
		private EntityCollection<CustomerChaseChannelEntity> _customerChaseChannel;
		private EntityCollection<CustomerChaseProductEntity> _customerChaseProduct;
		private EntityCollection<ChaseCampaignEntity> _chaseCampaignCollectionViaCustomerChaseCampaign;
		private EntityCollection<ChaseChannelLevelEntity> _chaseChannelLevelCollectionViaCustomerChaseChannel;
		private EntityCollection<ChaseProductEntity> _chaseProductCollectionViaCustomerChaseProduct;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerChaseProduct;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerChaseCampaign;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerChaseChannel;
		private ChaseGroupEntity _chaseGroup;
		private CustomerProfileEntity _customerProfile;
		private LookupEntity _lookup;
		private RelationshipEntity _relationship;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ChaseGroup</summary>
			public static readonly string ChaseGroup = "ChaseGroup";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Relationship</summary>
			public static readonly string Relationship = "Relationship";
			/// <summary>Member name CustomerChaseCampaign</summary>
			public static readonly string CustomerChaseCampaign = "CustomerChaseCampaign";
			/// <summary>Member name CustomerChaseChannel</summary>
			public static readonly string CustomerChaseChannel = "CustomerChaseChannel";
			/// <summary>Member name CustomerChaseProduct</summary>
			public static readonly string CustomerChaseProduct = "CustomerChaseProduct";
			/// <summary>Member name ChaseCampaignCollectionViaCustomerChaseCampaign</summary>
			public static readonly string ChaseCampaignCollectionViaCustomerChaseCampaign = "ChaseCampaignCollectionViaCustomerChaseCampaign";
			/// <summary>Member name ChaseChannelLevelCollectionViaCustomerChaseChannel</summary>
			public static readonly string ChaseChannelLevelCollectionViaCustomerChaseChannel = "ChaseChannelLevelCollectionViaCustomerChaseChannel";
			/// <summary>Member name ChaseProductCollectionViaCustomerChaseProduct</summary>
			public static readonly string ChaseProductCollectionViaCustomerChaseProduct = "ChaseProductCollectionViaCustomerChaseProduct";
			/// <summary>Member name CustomerProfileCollectionViaCustomerChaseProduct</summary>
			public static readonly string CustomerProfileCollectionViaCustomerChaseProduct = "CustomerProfileCollectionViaCustomerChaseProduct";
			/// <summary>Member name CustomerProfileCollectionViaCustomerChaseCampaign</summary>
			public static readonly string CustomerProfileCollectionViaCustomerChaseCampaign = "CustomerProfileCollectionViaCustomerChaseCampaign";
			/// <summary>Member name CustomerProfileCollectionViaCustomerChaseChannel</summary>
			public static readonly string CustomerProfileCollectionViaCustomerChaseChannel = "CustomerProfileCollectionViaCustomerChaseChannel";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ChaseOutboundEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ChaseOutboundEntity():base("ChaseOutboundEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ChaseOutboundEntity(IEntityFields2 fields):base("ChaseOutboundEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ChaseOutboundEntity</param>
		public ChaseOutboundEntity(IValidator validator):base("ChaseOutboundEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for ChaseOutbound which data should be fetched into this ChaseOutbound object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseOutboundEntity(System.Int64 id):base("ChaseOutboundEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for ChaseOutbound which data should be fetched into this ChaseOutbound object</param>
		/// <param name="validator">The custom validator object for this ChaseOutboundEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseOutboundEntity(System.Int64 id, IValidator validator):base("ChaseOutboundEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ChaseOutboundEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerChaseCampaign = (EntityCollection<CustomerChaseCampaignEntity>)info.GetValue("_customerChaseCampaign", typeof(EntityCollection<CustomerChaseCampaignEntity>));
				_customerChaseChannel = (EntityCollection<CustomerChaseChannelEntity>)info.GetValue("_customerChaseChannel", typeof(EntityCollection<CustomerChaseChannelEntity>));
				_customerChaseProduct = (EntityCollection<CustomerChaseProductEntity>)info.GetValue("_customerChaseProduct", typeof(EntityCollection<CustomerChaseProductEntity>));
				_chaseCampaignCollectionViaCustomerChaseCampaign = (EntityCollection<ChaseCampaignEntity>)info.GetValue("_chaseCampaignCollectionViaCustomerChaseCampaign", typeof(EntityCollection<ChaseCampaignEntity>));
				_chaseChannelLevelCollectionViaCustomerChaseChannel = (EntityCollection<ChaseChannelLevelEntity>)info.GetValue("_chaseChannelLevelCollectionViaCustomerChaseChannel", typeof(EntityCollection<ChaseChannelLevelEntity>));
				_chaseProductCollectionViaCustomerChaseProduct = (EntityCollection<ChaseProductEntity>)info.GetValue("_chaseProductCollectionViaCustomerChaseProduct", typeof(EntityCollection<ChaseProductEntity>));
				_customerProfileCollectionViaCustomerChaseProduct = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerChaseProduct", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerChaseCampaign = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerChaseCampaign", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerChaseChannel = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerChaseChannel", typeof(EntityCollection<CustomerProfileEntity>));
				_chaseGroup = (ChaseGroupEntity)info.GetValue("_chaseGroup", typeof(ChaseGroupEntity));
				if(_chaseGroup!=null)
				{
					_chaseGroup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_relationship = (RelationshipEntity)info.GetValue("_relationship", typeof(RelationshipEntity));
				if(_relationship!=null)
				{
					_relationship.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ChaseOutboundFieldIndex)fieldIndex)
			{
				case ChaseOutboundFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case ChaseOutboundFieldIndex.RelationshipId:
					DesetupSyncRelationship(true, false);
					break;
				case ChaseOutboundFieldIndex.ChaseGroupId:
					DesetupSyncChaseGroup(true, false);
					break;
				case ChaseOutboundFieldIndex.ConfidenceScoreId:
					DesetupSyncLookup(true, false);
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
				case "ChaseGroup":
					this.ChaseGroup = (ChaseGroupEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Relationship":
					this.Relationship = (RelationshipEntity)entity;
					break;
				case "CustomerChaseCampaign":
					this.CustomerChaseCampaign.Add((CustomerChaseCampaignEntity)entity);
					break;
				case "CustomerChaseChannel":
					this.CustomerChaseChannel.Add((CustomerChaseChannelEntity)entity);
					break;
				case "CustomerChaseProduct":
					this.CustomerChaseProduct.Add((CustomerChaseProductEntity)entity);
					break;
				case "ChaseCampaignCollectionViaCustomerChaseCampaign":
					this.ChaseCampaignCollectionViaCustomerChaseCampaign.IsReadOnly = false;
					this.ChaseCampaignCollectionViaCustomerChaseCampaign.Add((ChaseCampaignEntity)entity);
					this.ChaseCampaignCollectionViaCustomerChaseCampaign.IsReadOnly = true;
					break;
				case "ChaseChannelLevelCollectionViaCustomerChaseChannel":
					this.ChaseChannelLevelCollectionViaCustomerChaseChannel.IsReadOnly = false;
					this.ChaseChannelLevelCollectionViaCustomerChaseChannel.Add((ChaseChannelLevelEntity)entity);
					this.ChaseChannelLevelCollectionViaCustomerChaseChannel.IsReadOnly = true;
					break;
				case "ChaseProductCollectionViaCustomerChaseProduct":
					this.ChaseProductCollectionViaCustomerChaseProduct.IsReadOnly = false;
					this.ChaseProductCollectionViaCustomerChaseProduct.Add((ChaseProductEntity)entity);
					this.ChaseProductCollectionViaCustomerChaseProduct.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerChaseProduct":
					this.CustomerProfileCollectionViaCustomerChaseProduct.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerChaseProduct.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerChaseProduct.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerChaseCampaign":
					this.CustomerProfileCollectionViaCustomerChaseCampaign.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerChaseCampaign.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerChaseCampaign.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerChaseChannel":
					this.CustomerProfileCollectionViaCustomerChaseChannel.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerChaseChannel.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerChaseChannel.IsReadOnly = true;
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
			return ChaseOutboundEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ChaseGroup":
					toReturn.Add(ChaseOutboundEntity.Relations.ChaseGroupEntityUsingChaseGroupId);
					break;
				case "CustomerProfile":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Lookup":
					toReturn.Add(ChaseOutboundEntity.Relations.LookupEntityUsingConfidenceScoreId);
					break;
				case "Relationship":
					toReturn.Add(ChaseOutboundEntity.Relations.RelationshipEntityUsingRelationshipId);
					break;
				case "CustomerChaseCampaign":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseCampaignEntityUsingChaseOutboundId);
					break;
				case "CustomerChaseChannel":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseChannelEntityUsingChaseOutboundId);
					break;
				case "CustomerChaseProduct":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseProductEntityUsingChaseOutboundId);
					break;
				case "ChaseCampaignCollectionViaCustomerChaseCampaign":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseCampaignEntityUsingChaseOutboundId, "ChaseOutboundEntity__", "CustomerChaseCampaign_", JoinHint.None);
					toReturn.Add(CustomerChaseCampaignEntity.Relations.ChaseCampaignEntityUsingChaseCampaignId, "CustomerChaseCampaign_", string.Empty, JoinHint.None);
					break;
				case "ChaseChannelLevelCollectionViaCustomerChaseChannel":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseChannelEntityUsingChaseOutboundId, "ChaseOutboundEntity__", "CustomerChaseChannel_", JoinHint.None);
					toReturn.Add(CustomerChaseChannelEntity.Relations.ChaseChannelLevelEntityUsingChaseChannelLevelId, "CustomerChaseChannel_", string.Empty, JoinHint.None);
					break;
				case "ChaseProductCollectionViaCustomerChaseProduct":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseProductEntityUsingChaseOutboundId, "ChaseOutboundEntity__", "CustomerChaseProduct_", JoinHint.None);
					toReturn.Add(CustomerChaseProductEntity.Relations.ChaseProductEntityUsingChaseProductId, "CustomerChaseProduct_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerChaseProduct":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseProductEntityUsingChaseOutboundId, "ChaseOutboundEntity__", "CustomerChaseProduct_", JoinHint.None);
					toReturn.Add(CustomerChaseProductEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerChaseProduct_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerChaseCampaign":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseCampaignEntityUsingChaseOutboundId, "ChaseOutboundEntity__", "CustomerChaseCampaign_", JoinHint.None);
					toReturn.Add(CustomerChaseCampaignEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerChaseCampaign_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerChaseChannel":
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerChaseChannelEntityUsingChaseOutboundId, "ChaseOutboundEntity__", "CustomerChaseChannel_", JoinHint.None);
					toReturn.Add(CustomerChaseChannelEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerChaseChannel_", string.Empty, JoinHint.None);
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
				case "ChaseGroup":
					SetupSyncChaseGroup(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Relationship":
					SetupSyncRelationship(relatedEntity);
					break;
				case "CustomerChaseCampaign":
					this.CustomerChaseCampaign.Add((CustomerChaseCampaignEntity)relatedEntity);
					break;
				case "CustomerChaseChannel":
					this.CustomerChaseChannel.Add((CustomerChaseChannelEntity)relatedEntity);
					break;
				case "CustomerChaseProduct":
					this.CustomerChaseProduct.Add((CustomerChaseProductEntity)relatedEntity);
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
				case "ChaseGroup":
					DesetupSyncChaseGroup(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Relationship":
					DesetupSyncRelationship(false, true);
					break;
				case "CustomerChaseCampaign":
					base.PerformRelatedEntityRemoval(this.CustomerChaseCampaign, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerChaseChannel":
					base.PerformRelatedEntityRemoval(this.CustomerChaseChannel, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerChaseProduct":
					base.PerformRelatedEntityRemoval(this.CustomerChaseProduct, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_chaseGroup!=null)
			{
				toReturn.Add(_chaseGroup);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_relationship!=null)
			{
				toReturn.Add(_relationship);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerChaseCampaign);
			toReturn.Add(this.CustomerChaseChannel);
			toReturn.Add(this.CustomerChaseProduct);

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
				info.AddValue("_customerChaseCampaign", ((_customerChaseCampaign!=null) && (_customerChaseCampaign.Count>0) && !this.MarkedForDeletion)?_customerChaseCampaign:null);
				info.AddValue("_customerChaseChannel", ((_customerChaseChannel!=null) && (_customerChaseChannel.Count>0) && !this.MarkedForDeletion)?_customerChaseChannel:null);
				info.AddValue("_customerChaseProduct", ((_customerChaseProduct!=null) && (_customerChaseProduct.Count>0) && !this.MarkedForDeletion)?_customerChaseProduct:null);
				info.AddValue("_chaseCampaignCollectionViaCustomerChaseCampaign", ((_chaseCampaignCollectionViaCustomerChaseCampaign!=null) && (_chaseCampaignCollectionViaCustomerChaseCampaign.Count>0) && !this.MarkedForDeletion)?_chaseCampaignCollectionViaCustomerChaseCampaign:null);
				info.AddValue("_chaseChannelLevelCollectionViaCustomerChaseChannel", ((_chaseChannelLevelCollectionViaCustomerChaseChannel!=null) && (_chaseChannelLevelCollectionViaCustomerChaseChannel.Count>0) && !this.MarkedForDeletion)?_chaseChannelLevelCollectionViaCustomerChaseChannel:null);
				info.AddValue("_chaseProductCollectionViaCustomerChaseProduct", ((_chaseProductCollectionViaCustomerChaseProduct!=null) && (_chaseProductCollectionViaCustomerChaseProduct.Count>0) && !this.MarkedForDeletion)?_chaseProductCollectionViaCustomerChaseProduct:null);
				info.AddValue("_customerProfileCollectionViaCustomerChaseProduct", ((_customerProfileCollectionViaCustomerChaseProduct!=null) && (_customerProfileCollectionViaCustomerChaseProduct.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerChaseProduct:null);
				info.AddValue("_customerProfileCollectionViaCustomerChaseCampaign", ((_customerProfileCollectionViaCustomerChaseCampaign!=null) && (_customerProfileCollectionViaCustomerChaseCampaign.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerChaseCampaign:null);
				info.AddValue("_customerProfileCollectionViaCustomerChaseChannel", ((_customerProfileCollectionViaCustomerChaseChannel!=null) && (_customerProfileCollectionViaCustomerChaseChannel.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerChaseChannel:null);
				info.AddValue("_chaseGroup", (!this.MarkedForDeletion?_chaseGroup:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_relationship", (!this.MarkedForDeletion?_relationship:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ChaseOutboundFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ChaseOutboundFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ChaseOutboundRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerChaseCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerChaseCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerChaseCampaignFields.ChaseOutboundId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerChaseChannel' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerChaseChannel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerChaseChannelFields.ChaseOutboundId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerChaseProduct' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerChaseProduct()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerChaseProductFields.ChaseOutboundId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseCampaignCollectionViaCustomerChaseCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChaseCampaignCollectionViaCustomerChaseCampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaseOutboundEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseChannelLevel' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseChannelLevelCollectionViaCustomerChaseChannel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChaseChannelLevelCollectionViaCustomerChaseChannel"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaseOutboundEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseProduct' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseProductCollectionViaCustomerChaseProduct()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChaseProductCollectionViaCustomerChaseProduct"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaseOutboundEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerChaseProduct()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerChaseProduct"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaseOutboundEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerChaseCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerChaseCampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaseOutboundEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerChaseChannel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerChaseChannel"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.Id, null, ComparisonOperator.Equal, this.Id, "ChaseOutboundEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ChaseGroup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseGroupFields.ChaseGroupId, null, ComparisonOperator.Equal, this.ChaseGroupId));
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
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ConfidenceScoreId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Relationship' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRelationship()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RelationshipFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ChaseOutboundEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerChaseCampaign);
			collectionsQueue.Enqueue(this._customerChaseChannel);
			collectionsQueue.Enqueue(this._customerChaseProduct);
			collectionsQueue.Enqueue(this._chaseCampaignCollectionViaCustomerChaseCampaign);
			collectionsQueue.Enqueue(this._chaseChannelLevelCollectionViaCustomerChaseChannel);
			collectionsQueue.Enqueue(this._chaseProductCollectionViaCustomerChaseProduct);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerChaseProduct);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerChaseCampaign);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerChaseChannel);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerChaseCampaign = (EntityCollection<CustomerChaseCampaignEntity>) collectionsQueue.Dequeue();
			this._customerChaseChannel = (EntityCollection<CustomerChaseChannelEntity>) collectionsQueue.Dequeue();
			this._customerChaseProduct = (EntityCollection<CustomerChaseProductEntity>) collectionsQueue.Dequeue();
			this._chaseCampaignCollectionViaCustomerChaseCampaign = (EntityCollection<ChaseCampaignEntity>) collectionsQueue.Dequeue();
			this._chaseChannelLevelCollectionViaCustomerChaseChannel = (EntityCollection<ChaseChannelLevelEntity>) collectionsQueue.Dequeue();
			this._chaseProductCollectionViaCustomerChaseProduct = (EntityCollection<ChaseProductEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerChaseProduct = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerChaseCampaign = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerChaseChannel = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerChaseCampaign != null)
			{
				return true;
			}
			if (this._customerChaseChannel != null)
			{
				return true;
			}
			if (this._customerChaseProduct != null)
			{
				return true;
			}
			if (this._chaseCampaignCollectionViaCustomerChaseCampaign != null)
			{
				return true;
			}
			if (this._chaseChannelLevelCollectionViaCustomerChaseChannel != null)
			{
				return true;
			}
			if (this._chaseProductCollectionViaCustomerChaseProduct != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerChaseProduct != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerChaseCampaign != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerChaseChannel != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerChaseChannelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseChannelEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseProductEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaseChannelLevelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseChannelLevelEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseProductEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ChaseGroup", _chaseGroup);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Relationship", _relationship);
			toReturn.Add("CustomerChaseCampaign", _customerChaseCampaign);
			toReturn.Add("CustomerChaseChannel", _customerChaseChannel);
			toReturn.Add("CustomerChaseProduct", _customerChaseProduct);
			toReturn.Add("ChaseCampaignCollectionViaCustomerChaseCampaign", _chaseCampaignCollectionViaCustomerChaseCampaign);
			toReturn.Add("ChaseChannelLevelCollectionViaCustomerChaseChannel", _chaseChannelLevelCollectionViaCustomerChaseChannel);
			toReturn.Add("ChaseProductCollectionViaCustomerChaseProduct", _chaseProductCollectionViaCustomerChaseProduct);
			toReturn.Add("CustomerProfileCollectionViaCustomerChaseProduct", _customerProfileCollectionViaCustomerChaseProduct);
			toReturn.Add("CustomerProfileCollectionViaCustomerChaseCampaign", _customerProfileCollectionViaCustomerChaseCampaign);
			toReturn.Add("CustomerProfileCollectionViaCustomerChaseChannel", _customerProfileCollectionViaCustomerChaseChannel);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerChaseCampaign!=null)
			{
				_customerChaseCampaign.ActiveContext = base.ActiveContext;
			}
			if(_customerChaseChannel!=null)
			{
				_customerChaseChannel.ActiveContext = base.ActiveContext;
			}
			if(_customerChaseProduct!=null)
			{
				_customerChaseProduct.ActiveContext = base.ActiveContext;
			}
			if(_chaseCampaignCollectionViaCustomerChaseCampaign!=null)
			{
				_chaseCampaignCollectionViaCustomerChaseCampaign.ActiveContext = base.ActiveContext;
			}
			if(_chaseChannelLevelCollectionViaCustomerChaseChannel!=null)
			{
				_chaseChannelLevelCollectionViaCustomerChaseChannel.ActiveContext = base.ActiveContext;
			}
			if(_chaseProductCollectionViaCustomerChaseProduct!=null)
			{
				_chaseProductCollectionViaCustomerChaseProduct.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerChaseProduct!=null)
			{
				_customerProfileCollectionViaCustomerChaseProduct.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerChaseCampaign!=null)
			{
				_customerProfileCollectionViaCustomerChaseCampaign.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerChaseChannel!=null)
			{
				_customerProfileCollectionViaCustomerChaseChannel.ActiveContext = base.ActiveContext;
			}
			if(_chaseGroup!=null)
			{
				_chaseGroup.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_relationship!=null)
			{
				_relationship.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerChaseCampaign = null;
			_customerChaseChannel = null;
			_customerChaseProduct = null;
			_chaseCampaignCollectionViaCustomerChaseCampaign = null;
			_chaseChannelLevelCollectionViaCustomerChaseChannel = null;
			_chaseProductCollectionViaCustomerChaseProduct = null;
			_customerProfileCollectionViaCustomerChaseProduct = null;
			_customerProfileCollectionViaCustomerChaseCampaign = null;
			_customerProfileCollectionViaCustomerChaseChannel = null;
			_chaseGroup = null;
			_customerProfile = null;
			_lookup = null;
			_relationship = null;

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

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TenantId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IndividualId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClientId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VendorCd", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContractNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContractPersonNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConsumerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignMemberId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DistributionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SubscriberIndicator", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RelationshipId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IdentifiedIndicator", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OutboundCallIndicator", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WirelessIndicator", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PriorityCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BusinessCaseId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicareIndicator", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChaseGroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HmoLobIndicator", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReferMemberTo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClosestRetailCenter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConfidenceScoreId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LocationCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForecastedOutreachDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecordProcessDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AgentContextNameValueSet", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _chaseGroup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncChaseGroup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _chaseGroup, new PropertyChangedEventHandler( OnChaseGroupPropertyChanged ), "ChaseGroup", ChaseOutboundEntity.Relations.ChaseGroupEntityUsingChaseGroupId, true, signalRelatedEntity, "ChaseOutbound", resetFKFields, new int[] { (int)ChaseOutboundFieldIndex.ChaseGroupId } );		
			_chaseGroup = null;
		}

		/// <summary> setups the sync logic for member _chaseGroup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncChaseGroup(IEntity2 relatedEntity)
		{
			if(_chaseGroup!=relatedEntity)
			{
				DesetupSyncChaseGroup(true, true);
				_chaseGroup = (ChaseGroupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _chaseGroup, new PropertyChangedEventHandler( OnChaseGroupPropertyChanged ), "ChaseGroup", ChaseOutboundEntity.Relations.ChaseGroupEntityUsingChaseGroupId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnChaseGroupPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", ChaseOutboundEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "ChaseOutbound", resetFKFields, new int[] { (int)ChaseOutboundFieldIndex.CustomerId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", ChaseOutboundEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", ChaseOutboundEntity.Relations.LookupEntityUsingConfidenceScoreId, true, signalRelatedEntity, "ChaseOutbound", resetFKFields, new int[] { (int)ChaseOutboundFieldIndex.ConfidenceScoreId } );		
			_lookup = null;
		}

		/// <summary> setups the sync logic for member _lookup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup(IEntity2 relatedEntity)
		{
			if(_lookup!=relatedEntity)
			{
				DesetupSyncLookup(true, true);
				_lookup = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", ChaseOutboundEntity.Relations.LookupEntityUsingConfidenceScoreId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _relationship</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRelationship(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _relationship, new PropertyChangedEventHandler( OnRelationshipPropertyChanged ), "Relationship", ChaseOutboundEntity.Relations.RelationshipEntityUsingRelationshipId, true, signalRelatedEntity, "ChaseOutbound", resetFKFields, new int[] { (int)ChaseOutboundFieldIndex.RelationshipId } );		
			_relationship = null;
		}

		/// <summary> setups the sync logic for member _relationship</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRelationship(IEntity2 relatedEntity)
		{
			if(_relationship!=relatedEntity)
			{
				DesetupSyncRelationship(true, true);
				_relationship = (RelationshipEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _relationship, new PropertyChangedEventHandler( OnRelationshipPropertyChanged ), "Relationship", ChaseOutboundEntity.Relations.RelationshipEntityUsingRelationshipId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRelationshipPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ChaseOutboundEntity</param>
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
		public  static ChaseOutboundRelations Relations
		{
			get	{ return new ChaseOutboundRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerChaseCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerChaseCampaign
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseCampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerChaseCampaign")[0], (int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.CustomerChaseCampaignEntity, 0, null, null, null, null, "CustomerChaseCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerChaseChannel' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerChaseChannel
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerChaseChannelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseChannelEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerChaseChannel")[0], (int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.CustomerChaseChannelEntity, 0, null, null, null, null, "CustomerChaseChannel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerChaseProduct' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerChaseProduct
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseProductEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerChaseProduct")[0], (int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.CustomerChaseProductEntity, 0, null, null, null, null, "CustomerChaseProduct", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseCampaignCollectionViaCustomerChaseCampaign
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseOutboundEntity.Relations.CustomerChaseCampaignEntityUsingChaseOutboundId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseCampaign_");
				return new PrefetchPathElement2(new EntityCollection<ChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseCampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.ChaseCampaignEntity, 0, null, null, GetRelationsForField("ChaseCampaignCollectionViaCustomerChaseCampaign"), null, "ChaseCampaignCollectionViaCustomerChaseCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseChannelLevel' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseChannelLevelCollectionViaCustomerChaseChannel
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseOutboundEntity.Relations.CustomerChaseChannelEntityUsingChaseOutboundId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseChannel_");
				return new PrefetchPathElement2(new EntityCollection<ChaseChannelLevelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseChannelLevelEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.ChaseChannelLevelEntity, 0, null, null, GetRelationsForField("ChaseChannelLevelCollectionViaCustomerChaseChannel"), null, "ChaseChannelLevelCollectionViaCustomerChaseChannel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseProduct' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseProductCollectionViaCustomerChaseProduct
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseOutboundEntity.Relations.CustomerChaseProductEntityUsingChaseOutboundId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseProduct_");
				return new PrefetchPathElement2(new EntityCollection<ChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseProductEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.ChaseProductEntity, 0, null, null, GetRelationsForField("ChaseProductCollectionViaCustomerChaseProduct"), null, "ChaseProductCollectionViaCustomerChaseProduct", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerChaseProduct
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseOutboundEntity.Relations.CustomerChaseProductEntityUsingChaseOutboundId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseProduct_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerChaseProduct"), null, "CustomerProfileCollectionViaCustomerChaseProduct", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerChaseCampaign
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseOutboundEntity.Relations.CustomerChaseCampaignEntityUsingChaseOutboundId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseCampaign_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerChaseCampaign"), null, "CustomerProfileCollectionViaCustomerChaseCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerChaseChannel
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseOutboundEntity.Relations.CustomerChaseChannelEntityUsingChaseOutboundId;
				intermediateRelation.SetAliases(string.Empty, "CustomerChaseChannel_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerChaseChannel"), null, "CustomerProfileCollectionViaCustomerChaseChannel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseGroup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ChaseGroupEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaseGroup")[0], (int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.ChaseGroupEntity, 0, null, null, null, null, "ChaseGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Relationship' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRelationship
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RelationshipEntityFactory))),
					(IEntityRelation)GetRelationsForField("Relationship")[0], (int)Falcon.Data.EntityType.ChaseOutboundEntity, (int)Falcon.Data.EntityType.RelationshipEntity, 0, null, null, null, null, "Relationship", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ChaseOutboundEntity.CustomProperties;}
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
			get { return ChaseOutboundEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)ChaseOutboundFieldIndex.Id, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.Id, value); }
		}

		/// <summary> The CustomerId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)ChaseOutboundFieldIndex.CustomerId, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.CustomerId, value); }
		}

		/// <summary> The TenantId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."TenantId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TenantId
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.TenantId, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.TenantId, value); }
		}

		/// <summary> The IndividualId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."IndividualId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IndividualId
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.IndividualId, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.IndividualId, value); }
		}

		/// <summary> The ClientId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ClientId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ClientId
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.ClientId, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ClientId, value); }
		}

		/// <summary> The VendorCd property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."VendorCD"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VendorCd
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.VendorCd, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.VendorCd, value); }
		}

		/// <summary> The ContractNumber property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ContractNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ContractNumber
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.ContractNumber, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ContractNumber, value); }
		}

		/// <summary> The ContractPersonNumber property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ContractPersonNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ContractPersonNumber
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.ContractPersonNumber, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ContractPersonNumber, value); }
		}

		/// <summary> The ConsumerId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ConsumerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ConsumerId
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.ConsumerId, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ConsumerId, value); }
		}

		/// <summary> The CampaignMemberId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."CampaignMemberId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CampaignMemberId
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.CampaignMemberId, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.CampaignMemberId, value); }
		}

		/// <summary> The DistributionId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."DistributionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DistributionId
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.DistributionId, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.DistributionId, value); }
		}

		/// <summary> The SubscriberIndicator property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."SubscriberIndicator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SubscriberIndicator
		{
			get { return (System.Boolean)GetValue((int)ChaseOutboundFieldIndex.SubscriberIndicator, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.SubscriberIndicator, value); }
		}

		/// <summary> The RelationshipId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."RelationshipId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RelationshipId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ChaseOutboundFieldIndex.RelationshipId, false); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.RelationshipId, value); }
		}

		/// <summary> The IdentifiedIndicator property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."IdentifiedIndicator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IdentifiedIndicator
		{
			get { return (System.Boolean)GetValue((int)ChaseOutboundFieldIndex.IdentifiedIndicator, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.IdentifiedIndicator, value); }
		}

		/// <summary> The OutboundCallIndicator property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."OutboundCallIndicator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean OutboundCallIndicator
		{
			get { return (System.Boolean)GetValue((int)ChaseOutboundFieldIndex.OutboundCallIndicator, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.OutboundCallIndicator, value); }
		}

		/// <summary> The WirelessIndicator property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."WirelessIndicator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean WirelessIndicator
		{
			get { return (System.Boolean)GetValue((int)ChaseOutboundFieldIndex.WirelessIndicator, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.WirelessIndicator, value); }
		}

		/// <summary> The PriorityCode property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."PriorityCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PriorityCode
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.PriorityCode, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.PriorityCode, value); }
		}

		/// <summary> The BusinessCaseId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."BusinessCaseId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BusinessCaseId
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.BusinessCaseId, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.BusinessCaseId, value); }
		}

		/// <summary> The MedicareIndicator property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."MedicareIndicator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean MedicareIndicator
		{
			get { return (System.Boolean)GetValue((int)ChaseOutboundFieldIndex.MedicareIndicator, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.MedicareIndicator, value); }
		}

		/// <summary> The ChaseGroupId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ChaseGroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ChaseGroupId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ChaseOutboundFieldIndex.ChaseGroupId, false); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ChaseGroupId, value); }
		}

		/// <summary> The HmoLobIndicator property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."HmoLobIndicator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean HmoLobIndicator
		{
			get { return (System.Boolean)GetValue((int)ChaseOutboundFieldIndex.HmoLobIndicator, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.HmoLobIndicator, value); }
		}

		/// <summary> The ReferMemberTo property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ReferMemberTo"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ReferMemberTo
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.ReferMemberTo, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ReferMemberTo, value); }
		}

		/// <summary> The ClosestRetailCenter property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ClosestRetailCenter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ClosestRetailCenter
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.ClosestRetailCenter, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ClosestRetailCenter, value); }
		}

		/// <summary> The ConfidenceScoreId property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ConfidenceScoreId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ConfidenceScoreId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ChaseOutboundFieldIndex.ConfidenceScoreId, false); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ConfidenceScoreId, value); }
		}

		/// <summary> The LocationCode property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."LocationCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LocationCode
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.LocationCode, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.LocationCode, value); }
		}

		/// <summary> The ForecastedOutreachDate property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."ForecastedOutreachDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ForecastedOutreachDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ChaseOutboundFieldIndex.ForecastedOutreachDate, false); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.ForecastedOutreachDate, value); }
		}

		/// <summary> The RecordProcessDate property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."RecordProcessDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> RecordProcessDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ChaseOutboundFieldIndex.RecordProcessDate, false); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.RecordProcessDate, value); }
		}

		/// <summary> The AgentContextNameValueSet property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."AgentContextNameValueSet"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AgentContextNameValueSet
		{
			get { return (System.String)GetValue((int)ChaseOutboundFieldIndex.AgentContextNameValueSet, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.AgentContextNameValueSet, value); }
		}

		/// <summary> The DateCreated property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ChaseOutboundFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.DateCreated, value); }
		}

		/// <summary> The EndDate property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."EndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EndDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ChaseOutboundFieldIndex.EndDate, false); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.EndDate, value); }
		}

		/// <summary> The IsActive property of the Entity ChaseOutbound<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseOutbound"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ChaseOutboundFieldIndex.IsActive, true); }
			set	{ SetValue((int)ChaseOutboundFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerChaseCampaignEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerChaseCampaignEntity))]
		public virtual EntityCollection<CustomerChaseCampaignEntity> CustomerChaseCampaign
		{
			get
			{
				if(_customerChaseCampaign==null)
				{
					_customerChaseCampaign = new EntityCollection<CustomerChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseCampaignEntityFactory)));
					_customerChaseCampaign.SetContainingEntityInfo(this, "ChaseOutbound");
				}
				return _customerChaseCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerChaseChannelEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerChaseChannelEntity))]
		public virtual EntityCollection<CustomerChaseChannelEntity> CustomerChaseChannel
		{
			get
			{
				if(_customerChaseChannel==null)
				{
					_customerChaseChannel = new EntityCollection<CustomerChaseChannelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseChannelEntityFactory)));
					_customerChaseChannel.SetContainingEntityInfo(this, "ChaseOutbound");
				}
				return _customerChaseChannel;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerChaseProductEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerChaseProductEntity))]
		public virtual EntityCollection<CustomerChaseProductEntity> CustomerChaseProduct
		{
			get
			{
				if(_customerChaseProduct==null)
				{
					_customerChaseProduct = new EntityCollection<CustomerChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerChaseProductEntityFactory)));
					_customerChaseProduct.SetContainingEntityInfo(this, "ChaseOutbound");
				}
				return _customerChaseProduct;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseCampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseCampaignEntity))]
		public virtual EntityCollection<ChaseCampaignEntity> ChaseCampaignCollectionViaCustomerChaseCampaign
		{
			get
			{
				if(_chaseCampaignCollectionViaCustomerChaseCampaign==null)
				{
					_chaseCampaignCollectionViaCustomerChaseCampaign = new EntityCollection<ChaseCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseCampaignEntityFactory)));
					_chaseCampaignCollectionViaCustomerChaseCampaign.IsReadOnly=true;
				}
				return _chaseCampaignCollectionViaCustomerChaseCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseChannelLevelEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseChannelLevelEntity))]
		public virtual EntityCollection<ChaseChannelLevelEntity> ChaseChannelLevelCollectionViaCustomerChaseChannel
		{
			get
			{
				if(_chaseChannelLevelCollectionViaCustomerChaseChannel==null)
				{
					_chaseChannelLevelCollectionViaCustomerChaseChannel = new EntityCollection<ChaseChannelLevelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseChannelLevelEntityFactory)));
					_chaseChannelLevelCollectionViaCustomerChaseChannel.IsReadOnly=true;
				}
				return _chaseChannelLevelCollectionViaCustomerChaseChannel;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseProductEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseProductEntity))]
		public virtual EntityCollection<ChaseProductEntity> ChaseProductCollectionViaCustomerChaseProduct
		{
			get
			{
				if(_chaseProductCollectionViaCustomerChaseProduct==null)
				{
					_chaseProductCollectionViaCustomerChaseProduct = new EntityCollection<ChaseProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseProductEntityFactory)));
					_chaseProductCollectionViaCustomerChaseProduct.IsReadOnly=true;
				}
				return _chaseProductCollectionViaCustomerChaseProduct;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerChaseProduct
		{
			get
			{
				if(_customerProfileCollectionViaCustomerChaseProduct==null)
				{
					_customerProfileCollectionViaCustomerChaseProduct = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerChaseProduct.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerChaseProduct;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerChaseCampaign
		{
			get
			{
				if(_customerProfileCollectionViaCustomerChaseCampaign==null)
				{
					_customerProfileCollectionViaCustomerChaseCampaign = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerChaseCampaign.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerChaseCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerChaseChannel
		{
			get
			{
				if(_customerProfileCollectionViaCustomerChaseChannel==null)
				{
					_customerProfileCollectionViaCustomerChaseChannel = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerChaseChannel.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerChaseChannel;
			}
		}

		/// <summary> Gets / sets related entity of type 'ChaseGroupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ChaseGroupEntity ChaseGroup
		{
			get
			{
				return _chaseGroup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncChaseGroup(value);
				}
				else
				{
					if(value==null)
					{
						if(_chaseGroup != null)
						{
							_chaseGroup.UnsetRelatedEntity(this, "ChaseOutbound");
						}
					}
					else
					{
						if(_chaseGroup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChaseOutbound");
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
							_customerProfile.UnsetRelatedEntity(this, "ChaseOutbound");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChaseOutbound");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup
		{
			get
			{
				return _lookup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup != null)
						{
							_lookup.UnsetRelatedEntity(this, "ChaseOutbound");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChaseOutbound");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'RelationshipEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual RelationshipEntity Relationship
		{
			get
			{
				return _relationship;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncRelationship(value);
				}
				else
				{
					if(value==null)
					{
						if(_relationship != null)
						{
							_relationship.UnsetRelatedEntity(this, "ChaseOutbound");
						}
					}
					else
					{
						if(_relationship!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ChaseOutbound");
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
			get { return (int)Falcon.Data.EntityType.ChaseOutboundEntity; }
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
