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
	/// Entity class which represents the entity 'Relationship'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class RelationshipEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ChaseOutboundEntity> _chaseOutbound;
		private EntityCollection<GuardianDetailsEntity> _guardianDetails;
		private EntityCollection<ChaseGroupEntity> _chaseGroupCollectionViaChaseOutbound;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaGuardianDetails;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaChaseOutbound;
		private EntityCollection<LookupEntity> _lookupCollectionViaChaseOutbound;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaGuardianDetails_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaGuardianDetails;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name ChaseOutbound</summary>
			public static readonly string ChaseOutbound = "ChaseOutbound";
			/// <summary>Member name GuardianDetails</summary>
			public static readonly string GuardianDetails = "GuardianDetails";
			/// <summary>Member name ChaseGroupCollectionViaChaseOutbound</summary>
			public static readonly string ChaseGroupCollectionViaChaseOutbound = "ChaseGroupCollectionViaChaseOutbound";
			/// <summary>Member name CustomerProfileCollectionViaGuardianDetails</summary>
			public static readonly string CustomerProfileCollectionViaGuardianDetails = "CustomerProfileCollectionViaGuardianDetails";
			/// <summary>Member name CustomerProfileCollectionViaChaseOutbound</summary>
			public static readonly string CustomerProfileCollectionViaChaseOutbound = "CustomerProfileCollectionViaChaseOutbound";
			/// <summary>Member name LookupCollectionViaChaseOutbound</summary>
			public static readonly string LookupCollectionViaChaseOutbound = "LookupCollectionViaChaseOutbound";
			/// <summary>Member name OrganizationRoleUserCollectionViaGuardianDetails_</summary>
			public static readonly string OrganizationRoleUserCollectionViaGuardianDetails_ = "OrganizationRoleUserCollectionViaGuardianDetails_";
			/// <summary>Member name OrganizationRoleUserCollectionViaGuardianDetails</summary>
			public static readonly string OrganizationRoleUserCollectionViaGuardianDetails = "OrganizationRoleUserCollectionViaGuardianDetails";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static RelationshipEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public RelationshipEntity():base("RelationshipEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public RelationshipEntity(IEntityFields2 fields):base("RelationshipEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this RelationshipEntity</param>
		public RelationshipEntity(IValidator validator):base("RelationshipEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="relationshipId">PK value for Relationship which data should be fetched into this Relationship object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RelationshipEntity(System.Int64 relationshipId):base("RelationshipEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.RelationshipId = relationshipId;
		}

		/// <summary> CTor</summary>
		/// <param name="relationshipId">PK value for Relationship which data should be fetched into this Relationship object</param>
		/// <param name="validator">The custom validator object for this RelationshipEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RelationshipEntity(System.Int64 relationshipId, IValidator validator):base("RelationshipEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.RelationshipId = relationshipId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected RelationshipEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_chaseOutbound = (EntityCollection<ChaseOutboundEntity>)info.GetValue("_chaseOutbound", typeof(EntityCollection<ChaseOutboundEntity>));
				_guardianDetails = (EntityCollection<GuardianDetailsEntity>)info.GetValue("_guardianDetails", typeof(EntityCollection<GuardianDetailsEntity>));
				_chaseGroupCollectionViaChaseOutbound = (EntityCollection<ChaseGroupEntity>)info.GetValue("_chaseGroupCollectionViaChaseOutbound", typeof(EntityCollection<ChaseGroupEntity>));
				_customerProfileCollectionViaGuardianDetails = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaGuardianDetails", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaChaseOutbound = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaChaseOutbound", typeof(EntityCollection<CustomerProfileEntity>));
				_lookupCollectionViaChaseOutbound = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaChaseOutbound", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaGuardianDetails_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaGuardianDetails_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaGuardianDetails = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaGuardianDetails", typeof(EntityCollection<OrganizationRoleUserEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((RelationshipFieldIndex)fieldIndex)
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

				case "ChaseOutbound":
					this.ChaseOutbound.Add((ChaseOutboundEntity)entity);
					break;
				case "GuardianDetails":
					this.GuardianDetails.Add((GuardianDetailsEntity)entity);
					break;
				case "ChaseGroupCollectionViaChaseOutbound":
					this.ChaseGroupCollectionViaChaseOutbound.IsReadOnly = false;
					this.ChaseGroupCollectionViaChaseOutbound.Add((ChaseGroupEntity)entity);
					this.ChaseGroupCollectionViaChaseOutbound.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaGuardianDetails":
					this.CustomerProfileCollectionViaGuardianDetails.IsReadOnly = false;
					this.CustomerProfileCollectionViaGuardianDetails.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaGuardianDetails.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaChaseOutbound":
					this.CustomerProfileCollectionViaChaseOutbound.IsReadOnly = false;
					this.CustomerProfileCollectionViaChaseOutbound.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaChaseOutbound.IsReadOnly = true;
					break;
				case "LookupCollectionViaChaseOutbound":
					this.LookupCollectionViaChaseOutbound.IsReadOnly = false;
					this.LookupCollectionViaChaseOutbound.Add((LookupEntity)entity);
					this.LookupCollectionViaChaseOutbound.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaGuardianDetails_":
					this.OrganizationRoleUserCollectionViaGuardianDetails_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaGuardianDetails_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaGuardianDetails_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaGuardianDetails":
					this.OrganizationRoleUserCollectionViaGuardianDetails.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaGuardianDetails.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaGuardianDetails.IsReadOnly = true;
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
			return RelationshipEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "ChaseOutbound":
					toReturn.Add(RelationshipEntity.Relations.ChaseOutboundEntityUsingRelationshipId);
					break;
				case "GuardianDetails":
					toReturn.Add(RelationshipEntity.Relations.GuardianDetailsEntityUsingRelationshipId);
					break;
				case "ChaseGroupCollectionViaChaseOutbound":
					toReturn.Add(RelationshipEntity.Relations.ChaseOutboundEntityUsingRelationshipId, "RelationshipEntity__", "ChaseOutbound_", JoinHint.None);
					toReturn.Add(ChaseOutboundEntity.Relations.ChaseGroupEntityUsingChaseGroupId, "ChaseOutbound_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaGuardianDetails":
					toReturn.Add(RelationshipEntity.Relations.GuardianDetailsEntityUsingRelationshipId, "RelationshipEntity__", "GuardianDetails_", JoinHint.None);
					toReturn.Add(GuardianDetailsEntity.Relations.CustomerProfileEntityUsingCustomerId, "GuardianDetails_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaChaseOutbound":
					toReturn.Add(RelationshipEntity.Relations.ChaseOutboundEntityUsingRelationshipId, "RelationshipEntity__", "ChaseOutbound_", JoinHint.None);
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerProfileEntityUsingCustomerId, "ChaseOutbound_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaChaseOutbound":
					toReturn.Add(RelationshipEntity.Relations.ChaseOutboundEntityUsingRelationshipId, "RelationshipEntity__", "ChaseOutbound_", JoinHint.None);
					toReturn.Add(ChaseOutboundEntity.Relations.LookupEntityUsingConfidenceScoreId, "ChaseOutbound_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaGuardianDetails_":
					toReturn.Add(RelationshipEntity.Relations.GuardianDetailsEntityUsingRelationshipId, "RelationshipEntity__", "GuardianDetails_", JoinHint.None);
					toReturn.Add(GuardianDetailsEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "GuardianDetails_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaGuardianDetails":
					toReturn.Add(RelationshipEntity.Relations.GuardianDetailsEntityUsingRelationshipId, "RelationshipEntity__", "GuardianDetails_", JoinHint.None);
					toReturn.Add(GuardianDetailsEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "GuardianDetails_", string.Empty, JoinHint.None);
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

				case "ChaseOutbound":
					this.ChaseOutbound.Add((ChaseOutboundEntity)relatedEntity);
					break;
				case "GuardianDetails":
					this.GuardianDetails.Add((GuardianDetailsEntity)relatedEntity);
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

				case "ChaseOutbound":
					base.PerformRelatedEntityRemoval(this.ChaseOutbound, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "GuardianDetails":
					base.PerformRelatedEntityRemoval(this.GuardianDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.ChaseOutbound);
			toReturn.Add(this.GuardianDetails);

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
				info.AddValue("_chaseOutbound", ((_chaseOutbound!=null) && (_chaseOutbound.Count>0) && !this.MarkedForDeletion)?_chaseOutbound:null);
				info.AddValue("_guardianDetails", ((_guardianDetails!=null) && (_guardianDetails.Count>0) && !this.MarkedForDeletion)?_guardianDetails:null);
				info.AddValue("_chaseGroupCollectionViaChaseOutbound", ((_chaseGroupCollectionViaChaseOutbound!=null) && (_chaseGroupCollectionViaChaseOutbound.Count>0) && !this.MarkedForDeletion)?_chaseGroupCollectionViaChaseOutbound:null);
				info.AddValue("_customerProfileCollectionViaGuardianDetails", ((_customerProfileCollectionViaGuardianDetails!=null) && (_customerProfileCollectionViaGuardianDetails.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaGuardianDetails:null);
				info.AddValue("_customerProfileCollectionViaChaseOutbound", ((_customerProfileCollectionViaChaseOutbound!=null) && (_customerProfileCollectionViaChaseOutbound.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaChaseOutbound:null);
				info.AddValue("_lookupCollectionViaChaseOutbound", ((_lookupCollectionViaChaseOutbound!=null) && (_lookupCollectionViaChaseOutbound.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaChaseOutbound:null);
				info.AddValue("_organizationRoleUserCollectionViaGuardianDetails_", ((_organizationRoleUserCollectionViaGuardianDetails_!=null) && (_organizationRoleUserCollectionViaGuardianDetails_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaGuardianDetails_:null);
				info.AddValue("_organizationRoleUserCollectionViaGuardianDetails", ((_organizationRoleUserCollectionViaGuardianDetails!=null) && (_organizationRoleUserCollectionViaGuardianDetails.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaGuardianDetails:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(RelationshipFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(RelationshipFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new RelationshipRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseOutbound' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GuardianDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGuardianDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GuardianDetailsFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseGroupCollectionViaChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChaseGroupCollectionViaChaseOutbound"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RelationshipFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId, "RelationshipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaGuardianDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaGuardianDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RelationshipFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId, "RelationshipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaChaseOutbound"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RelationshipFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId, "RelationshipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaChaseOutbound"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RelationshipFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId, "RelationshipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaGuardianDetails_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaGuardianDetails_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RelationshipFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId, "RelationshipEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaGuardianDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaGuardianDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RelationshipFields.RelationshipId, null, ComparisonOperator.Equal, this.RelationshipId, "RelationshipEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.RelationshipEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(RelationshipEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._chaseOutbound);
			collectionsQueue.Enqueue(this._guardianDetails);
			collectionsQueue.Enqueue(this._chaseGroupCollectionViaChaseOutbound);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaGuardianDetails);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaChaseOutbound);
			collectionsQueue.Enqueue(this._lookupCollectionViaChaseOutbound);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaGuardianDetails_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaGuardianDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._chaseOutbound = (EntityCollection<ChaseOutboundEntity>) collectionsQueue.Dequeue();
			this._guardianDetails = (EntityCollection<GuardianDetailsEntity>) collectionsQueue.Dequeue();
			this._chaseGroupCollectionViaChaseOutbound = (EntityCollection<ChaseGroupEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaGuardianDetails = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaChaseOutbound = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaChaseOutbound = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaGuardianDetails_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaGuardianDetails = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._chaseOutbound != null)
			{
				return true;
			}
			if (this._guardianDetails != null)
			{
				return true;
			}
			if (this._chaseGroupCollectionViaChaseOutbound != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaGuardianDetails != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaChaseOutbound != null)
			{
				return true;
			}
			if (this._lookupCollectionViaChaseOutbound != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaGuardianDetails_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaGuardianDetails != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GuardianDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GuardianDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaseGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("ChaseOutbound", _chaseOutbound);
			toReturn.Add("GuardianDetails", _guardianDetails);
			toReturn.Add("ChaseGroupCollectionViaChaseOutbound", _chaseGroupCollectionViaChaseOutbound);
			toReturn.Add("CustomerProfileCollectionViaGuardianDetails", _customerProfileCollectionViaGuardianDetails);
			toReturn.Add("CustomerProfileCollectionViaChaseOutbound", _customerProfileCollectionViaChaseOutbound);
			toReturn.Add("LookupCollectionViaChaseOutbound", _lookupCollectionViaChaseOutbound);
			toReturn.Add("OrganizationRoleUserCollectionViaGuardianDetails_", _organizationRoleUserCollectionViaGuardianDetails_);
			toReturn.Add("OrganizationRoleUserCollectionViaGuardianDetails", _organizationRoleUserCollectionViaGuardianDetails);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_chaseOutbound!=null)
			{
				_chaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_guardianDetails!=null)
			{
				_guardianDetails.ActiveContext = base.ActiveContext;
			}
			if(_chaseGroupCollectionViaChaseOutbound!=null)
			{
				_chaseGroupCollectionViaChaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaGuardianDetails!=null)
			{
				_customerProfileCollectionViaGuardianDetails.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaChaseOutbound!=null)
			{
				_customerProfileCollectionViaChaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaChaseOutbound!=null)
			{
				_lookupCollectionViaChaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaGuardianDetails_!=null)
			{
				_organizationRoleUserCollectionViaGuardianDetails_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaGuardianDetails!=null)
			{
				_organizationRoleUserCollectionViaGuardianDetails.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_chaseOutbound = null;
			_guardianDetails = null;
			_chaseGroupCollectionViaChaseOutbound = null;
			_customerProfileCollectionViaGuardianDetails = null;
			_customerProfileCollectionViaChaseOutbound = null;
			_lookupCollectionViaChaseOutbound = null;
			_organizationRoleUserCollectionViaGuardianDetails_ = null;
			_organizationRoleUserCollectionViaGuardianDetails = null;


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

			_fieldsCustomProperties.Add("RelationshipId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Code", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this RelationshipEntity</param>
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
		public  static RelationshipRelations Relations
		{
			get	{ return new RelationshipRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseOutbound' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseOutbound
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaseOutbound")[0], (int)Falcon.Data.EntityType.RelationshipEntity, (int)Falcon.Data.EntityType.ChaseOutboundEntity, 0, null, null, null, null, "ChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GuardianDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGuardianDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GuardianDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GuardianDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("GuardianDetails")[0], (int)Falcon.Data.EntityType.RelationshipEntity, (int)Falcon.Data.EntityType.GuardianDetailsEntity, 0, null, null, null, null, "GuardianDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseGroupCollectionViaChaseOutbound
		{
			get
			{
				IEntityRelation intermediateRelation = RelationshipEntity.Relations.ChaseOutboundEntityUsingRelationshipId;
				intermediateRelation.SetAliases(string.Empty, "ChaseOutbound_");
				return new PrefetchPathElement2(new EntityCollection<ChaseGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseGroupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RelationshipEntity, (int)Falcon.Data.EntityType.ChaseGroupEntity, 0, null, null, GetRelationsForField("ChaseGroupCollectionViaChaseOutbound"), null, "ChaseGroupCollectionViaChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaGuardianDetails
		{
			get
			{
				IEntityRelation intermediateRelation = RelationshipEntity.Relations.GuardianDetailsEntityUsingRelationshipId;
				intermediateRelation.SetAliases(string.Empty, "GuardianDetails_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RelationshipEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaGuardianDetails"), null, "CustomerProfileCollectionViaGuardianDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaChaseOutbound
		{
			get
			{
				IEntityRelation intermediateRelation = RelationshipEntity.Relations.ChaseOutboundEntityUsingRelationshipId;
				intermediateRelation.SetAliases(string.Empty, "ChaseOutbound_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RelationshipEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaChaseOutbound"), null, "CustomerProfileCollectionViaChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaChaseOutbound
		{
			get
			{
				IEntityRelation intermediateRelation = RelationshipEntity.Relations.ChaseOutboundEntityUsingRelationshipId;
				intermediateRelation.SetAliases(string.Empty, "ChaseOutbound_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RelationshipEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaChaseOutbound"), null, "LookupCollectionViaChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaGuardianDetails_
		{
			get
			{
				IEntityRelation intermediateRelation = RelationshipEntity.Relations.GuardianDetailsEntityUsingRelationshipId;
				intermediateRelation.SetAliases(string.Empty, "GuardianDetails_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RelationshipEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaGuardianDetails_"), null, "OrganizationRoleUserCollectionViaGuardianDetails_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaGuardianDetails
		{
			get
			{
				IEntityRelation intermediateRelation = RelationshipEntity.Relations.GuardianDetailsEntityUsingRelationshipId;
				intermediateRelation.SetAliases(string.Empty, "GuardianDetails_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RelationshipEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaGuardianDetails"), null, "OrganizationRoleUserCollectionViaGuardianDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return RelationshipEntity.CustomProperties;}
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
			get { return RelationshipEntity.FieldsCustomProperties;}
		}

		/// <summary> The RelationshipId property of the Entity Relationship<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRelationship"."RelationshipId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 RelationshipId
		{
			get { return (System.Int64)GetValue((int)RelationshipFieldIndex.RelationshipId, true); }
			set	{ SetValue((int)RelationshipFieldIndex.RelationshipId, value); }
		}

		/// <summary> The Code property of the Entity Relationship<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRelationship"."Code"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Code
		{
			get { return (System.String)GetValue((int)RelationshipFieldIndex.Code, true); }
			set	{ SetValue((int)RelationshipFieldIndex.Code, value); }
		}

		/// <summary> The Description property of the Entity Relationship<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRelationship"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)RelationshipFieldIndex.Description, true); }
			set	{ SetValue((int)RelationshipFieldIndex.Description, value); }
		}

		/// <summary> The Alias property of the Entity Relationship<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRelationship"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)RelationshipFieldIndex.Alias, true); }
			set	{ SetValue((int)RelationshipFieldIndex.Alias, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseOutboundEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseOutboundEntity))]
		public virtual EntityCollection<ChaseOutboundEntity> ChaseOutbound
		{
			get
			{
				if(_chaseOutbound==null)
				{
					_chaseOutbound = new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory)));
					_chaseOutbound.SetContainingEntityInfo(this, "Relationship");
				}
				return _chaseOutbound;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GuardianDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GuardianDetailsEntity))]
		public virtual EntityCollection<GuardianDetailsEntity> GuardianDetails
		{
			get
			{
				if(_guardianDetails==null)
				{
					_guardianDetails = new EntityCollection<GuardianDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GuardianDetailsEntityFactory)));
					_guardianDetails.SetContainingEntityInfo(this, "Relationship");
				}
				return _guardianDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseGroupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseGroupEntity))]
		public virtual EntityCollection<ChaseGroupEntity> ChaseGroupCollectionViaChaseOutbound
		{
			get
			{
				if(_chaseGroupCollectionViaChaseOutbound==null)
				{
					_chaseGroupCollectionViaChaseOutbound = new EntityCollection<ChaseGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseGroupEntityFactory)));
					_chaseGroupCollectionViaChaseOutbound.IsReadOnly=true;
				}
				return _chaseGroupCollectionViaChaseOutbound;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaGuardianDetails
		{
			get
			{
				if(_customerProfileCollectionViaGuardianDetails==null)
				{
					_customerProfileCollectionViaGuardianDetails = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaGuardianDetails.IsReadOnly=true;
				}
				return _customerProfileCollectionViaGuardianDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaChaseOutbound
		{
			get
			{
				if(_customerProfileCollectionViaChaseOutbound==null)
				{
					_customerProfileCollectionViaChaseOutbound = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaChaseOutbound.IsReadOnly=true;
				}
				return _customerProfileCollectionViaChaseOutbound;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaChaseOutbound
		{
			get
			{
				if(_lookupCollectionViaChaseOutbound==null)
				{
					_lookupCollectionViaChaseOutbound = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaChaseOutbound.IsReadOnly=true;
				}
				return _lookupCollectionViaChaseOutbound;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaGuardianDetails_
		{
			get
			{
				if(_organizationRoleUserCollectionViaGuardianDetails_==null)
				{
					_organizationRoleUserCollectionViaGuardianDetails_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaGuardianDetails_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaGuardianDetails_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaGuardianDetails
		{
			get
			{
				if(_organizationRoleUserCollectionViaGuardianDetails==null)
				{
					_organizationRoleUserCollectionViaGuardianDetails = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaGuardianDetails.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaGuardianDetails;
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
			get { return (int)Falcon.Data.EntityType.RelationshipEntity; }
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
