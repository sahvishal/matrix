///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:44
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
	/// Entity class which represents the entity 'PhysicianMaster'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PhysicianMasterEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerPrimaryCarePhysicianEntity> _customerPrimaryCarePhysician;
		private EntityCollection<AddressEntity> _addressCollectionViaCustomerPrimaryCarePhysician;
		private EntityCollection<AddressEntity> _addressCollectionViaCustomerPrimaryCarePhysician_;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerPrimaryCarePhysician;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerPrimaryCarePhysician;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name CustomerPrimaryCarePhysician</summary>
			public static readonly string CustomerPrimaryCarePhysician = "CustomerPrimaryCarePhysician";
			/// <summary>Member name AddressCollectionViaCustomerPrimaryCarePhysician</summary>
			public static readonly string AddressCollectionViaCustomerPrimaryCarePhysician = "AddressCollectionViaCustomerPrimaryCarePhysician";
			/// <summary>Member name AddressCollectionViaCustomerPrimaryCarePhysician_</summary>
			public static readonly string AddressCollectionViaCustomerPrimaryCarePhysician_ = "AddressCollectionViaCustomerPrimaryCarePhysician_";
			/// <summary>Member name CustomerProfileCollectionViaCustomerPrimaryCarePhysician</summary>
			public static readonly string CustomerProfileCollectionViaCustomerPrimaryCarePhysician = "CustomerProfileCollectionViaCustomerPrimaryCarePhysician";
			/// <summary>Member name LookupCollectionViaCustomerPrimaryCarePhysician</summary>
			public static readonly string LookupCollectionViaCustomerPrimaryCarePhysician = "LookupCollectionViaCustomerPrimaryCarePhysician";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PhysicianMasterEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PhysicianMasterEntity():base("PhysicianMasterEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PhysicianMasterEntity(IEntityFields2 fields):base("PhysicianMasterEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PhysicianMasterEntity</param>
		public PhysicianMasterEntity(IValidator validator):base("PhysicianMasterEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="physicianMasterId">PK value for PhysicianMaster which data should be fetched into this PhysicianMaster object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianMasterEntity(System.Int64 physicianMasterId):base("PhysicianMasterEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PhysicianMasterId = physicianMasterId;
		}

		/// <summary> CTor</summary>
		/// <param name="physicianMasterId">PK value for PhysicianMaster which data should be fetched into this PhysicianMaster object</param>
		/// <param name="validator">The custom validator object for this PhysicianMasterEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PhysicianMasterEntity(System.Int64 physicianMasterId, IValidator validator):base("PhysicianMasterEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PhysicianMasterId = physicianMasterId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PhysicianMasterEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerPrimaryCarePhysician = (EntityCollection<CustomerPrimaryCarePhysicianEntity>)info.GetValue("_customerPrimaryCarePhysician", typeof(EntityCollection<CustomerPrimaryCarePhysicianEntity>));
				_addressCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaCustomerPrimaryCarePhysician", typeof(EntityCollection<AddressEntity>));
				_addressCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaCustomerPrimaryCarePhysician_", typeof(EntityCollection<AddressEntity>));
				_customerProfileCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerPrimaryCarePhysician", typeof(EntityCollection<CustomerProfileEntity>));
				_lookupCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerPrimaryCarePhysician", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__", typeof(EntityCollection<OrganizationRoleUserEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((PhysicianMasterFieldIndex)fieldIndex)
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

				case "CustomerPrimaryCarePhysician":
					this.CustomerPrimaryCarePhysician.Add((CustomerPrimaryCarePhysicianEntity)entity);
					break;
				case "AddressCollectionViaCustomerPrimaryCarePhysician":
					this.AddressCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.AddressCollectionViaCustomerPrimaryCarePhysician.Add((AddressEntity)entity);
					this.AddressCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "AddressCollectionViaCustomerPrimaryCarePhysician_":
					this.AddressCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = false;
					this.AddressCollectionViaCustomerPrimaryCarePhysician_.Add((AddressEntity)entity);
					this.AddressCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerPrimaryCarePhysician":
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerPrimaryCarePhysician":
					this.LookupCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.LookupCollectionViaCustomerPrimaryCarePhysician.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.IsReadOnly = true;
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
			return PhysicianMasterEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "CustomerPrimaryCarePhysician":
					toReturn.Add(PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId);
					break;
				case "AddressCollectionViaCustomerPrimaryCarePhysician":
					toReturn.Add(PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId, "PhysicianMasterEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.AddressEntityUsingPcpaddress, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "AddressCollectionViaCustomerPrimaryCarePhysician_":
					toReturn.Add(PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId, "PhysicianMasterEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.AddressEntityUsingMailingAddressId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerPrimaryCarePhysician":
					toReturn.Add(PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId, "PhysicianMasterEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerPrimaryCarePhysician":
					toReturn.Add(PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId, "PhysicianMasterEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.LookupEntityUsingSource, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician":
					toReturn.Add(PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId, "PhysicianMasterEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrganizationRoleUserId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_":
					toReturn.Add(PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId, "PhysicianMasterEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__":
					toReturn.Add(PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId, "PhysicianMasterEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
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

				case "CustomerPrimaryCarePhysician":
					this.CustomerPrimaryCarePhysician.Add((CustomerPrimaryCarePhysicianEntity)relatedEntity);
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

				case "CustomerPrimaryCarePhysician":
					base.PerformRelatedEntityRemoval(this.CustomerPrimaryCarePhysician, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CustomerPrimaryCarePhysician);

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
				info.AddValue("_customerPrimaryCarePhysician", ((_customerPrimaryCarePhysician!=null) && (_customerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_customerPrimaryCarePhysician:null);
				info.AddValue("_addressCollectionViaCustomerPrimaryCarePhysician", ((_addressCollectionViaCustomerPrimaryCarePhysician!=null) && (_addressCollectionViaCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaCustomerPrimaryCarePhysician:null);
				info.AddValue("_addressCollectionViaCustomerPrimaryCarePhysician_", ((_addressCollectionViaCustomerPrimaryCarePhysician_!=null) && (_addressCollectionViaCustomerPrimaryCarePhysician_.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaCustomerPrimaryCarePhysician_:null);
				info.AddValue("_customerProfileCollectionViaCustomerPrimaryCarePhysician", ((_customerProfileCollectionViaCustomerPrimaryCarePhysician!=null) && (_customerProfileCollectionViaCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerPrimaryCarePhysician:null);
				info.AddValue("_lookupCollectionViaCustomerPrimaryCarePhysician", ((_lookupCollectionViaCustomerPrimaryCarePhysician!=null) && (_lookupCollectionViaCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerPrimaryCarePhysician:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PhysicianMasterFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PhysicianMasterFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PhysicianMasterRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerPrimaryCarePhysician' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerPrimaryCarePhysicianFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianMasterFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId, "PhysicianMasterEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaCustomerPrimaryCarePhysician_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaCustomerPrimaryCarePhysician_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianMasterFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId, "PhysicianMasterEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianMasterFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId, "PhysicianMasterEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianMasterFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId, "PhysicianMasterEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianMasterFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId, "PhysicianMasterEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianMasterFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId, "PhysicianMasterEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianMasterFields.PhysicianMasterId, null, ComparisonOperator.Equal, this.PhysicianMasterId, "PhysicianMasterEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PhysicianMasterEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PhysicianMasterEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._addressCollectionViaCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._addressCollectionViaCustomerPrimaryCarePhysician_);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerPrimaryCarePhysician = (EntityCollection<CustomerPrimaryCarePhysicianEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._addressCollectionViaCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._addressCollectionViaCustomerPrimaryCarePhysician_ != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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

			toReturn.Add("CustomerPrimaryCarePhysician", _customerPrimaryCarePhysician);
			toReturn.Add("AddressCollectionViaCustomerPrimaryCarePhysician", _addressCollectionViaCustomerPrimaryCarePhysician);
			toReturn.Add("AddressCollectionViaCustomerPrimaryCarePhysician_", _addressCollectionViaCustomerPrimaryCarePhysician_);
			toReturn.Add("CustomerProfileCollectionViaCustomerPrimaryCarePhysician", _customerProfileCollectionViaCustomerPrimaryCarePhysician);
			toReturn.Add("LookupCollectionViaCustomerPrimaryCarePhysician", _lookupCollectionViaCustomerPrimaryCarePhysician);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerPrimaryCarePhysician!=null)
			{
				_customerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaCustomerPrimaryCarePhysician!=null)
			{
				_addressCollectionViaCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaCustomerPrimaryCarePhysician_!=null)
			{
				_addressCollectionViaCustomerPrimaryCarePhysician_.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerPrimaryCarePhysician!=null)
			{
				_customerProfileCollectionViaCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerPrimaryCarePhysician!=null)
			{
				_lookupCollectionViaCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerPrimaryCarePhysician = null;
			_addressCollectionViaCustomerPrimaryCarePhysician = null;
			_addressCollectionViaCustomerPrimaryCarePhysician_ = null;
			_customerProfileCollectionViaCustomerPrimaryCarePhysician = null;
			_lookupCollectionViaCustomerPrimaryCarePhysician = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = null;


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

			_fieldsCustomProperties.Add("PhysicianMasterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Npi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrefixText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SuffixText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CredentialText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PracticeAddress1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PracticeAddress2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PracticeCity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PracticeState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PracticeZip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PracticePhone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PracticeFax", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsImported", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingAddress1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingAddress2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingCity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MailingZip", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PhysicianMasterEntity</param>
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
		public  static PhysicianMasterRelations Relations
		{
			get	{ return new PhysicianMasterRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerPrimaryCarePhysician' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerPrimaryCarePhysician
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerPrimaryCarePhysician")[0], (int)Falcon.Data.EntityType.PhysicianMasterEntity, (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, 0, null, null, null, null, "CustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianMasterEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaCustomerPrimaryCarePhysician"), null, "AddressCollectionViaCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianMasterEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaCustomerPrimaryCarePhysician_"), null, "AddressCollectionViaCustomerPrimaryCarePhysician_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianMasterEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerPrimaryCarePhysician"), null, "CustomerProfileCollectionViaCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianMasterEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerPrimaryCarePhysician"), null, "LookupCollectionViaCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianMasterEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianMasterEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__
		{
			get
			{
				IEntityRelation intermediateRelation = PhysicianMasterEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPhysicianMasterId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PhysicianMasterEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PhysicianMasterEntity.CustomProperties;}
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
			get { return PhysicianMasterEntity.FieldsCustomProperties;}
		}

		/// <summary> The PhysicianMasterId property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PhysicianMasterID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PhysicianMasterId
		{
			get { return (System.Int64)GetValue((int)PhysicianMasterFieldIndex.PhysicianMasterId, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PhysicianMasterId, value); }
		}

		/// <summary> The Npi property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."NPI"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Npi
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.Npi, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.Npi, value); }
		}

		/// <summary> The LastName property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.LastName, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.LastName, value); }
		}

		/// <summary> The FirstName property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.FirstName, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."MiddleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.MiddleName, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.MiddleName, value); }
		}

		/// <summary> The PrefixText property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PrefixText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PrefixText
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.PrefixText, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PrefixText, value); }
		}

		/// <summary> The SuffixText property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."SuffixText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SuffixText
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.SuffixText, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.SuffixText, value); }
		}

		/// <summary> The CredentialText property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."CredentialText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CredentialText
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.CredentialText, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.CredentialText, value); }
		}

		/// <summary> The PracticeAddress1 property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PracticeAddress1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PracticeAddress1
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.PracticeAddress1, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PracticeAddress1, value); }
		}

		/// <summary> The PracticeAddress2 property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PracticeAddress2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PracticeAddress2
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.PracticeAddress2, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PracticeAddress2, value); }
		}

		/// <summary> The PracticeCity property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PracticeCity"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PracticeCity
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.PracticeCity, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PracticeCity, value); }
		}

		/// <summary> The PracticeState property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PracticeState"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PracticeState
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.PracticeState, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PracticeState, value); }
		}

		/// <summary> The PracticeZip property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PracticeZip"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PracticeZip
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.PracticeZip, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PracticeZip, value); }
		}

		/// <summary> The PracticePhone property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PracticePhone"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PracticePhone
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.PracticePhone, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PracticePhone, value); }
		}

		/// <summary> The PracticeFax property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."PracticeFax"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PracticeFax
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.PracticeFax, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.PracticeFax, value); }
		}

		/// <summary> The DateCreated property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PhysicianMasterFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PhysicianMasterFieldIndex.DateModified, false); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.DateModified, value); }
		}

		/// <summary> The IsImported property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."IsImported"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsImported
		{
			get { return (System.Boolean)GetValue((int)PhysicianMasterFieldIndex.IsImported, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.IsImported, value); }
		}

		/// <summary> The IsActive property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PhysicianMasterFieldIndex.IsActive, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.IsActive, value); }
		}

		/// <summary> The MailingAddress1 property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."MailingAddress1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MailingAddress1
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.MailingAddress1, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.MailingAddress1, value); }
		}

		/// <summary> The MailingAddress2 property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."MailingAddress2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MailingAddress2
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.MailingAddress2, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.MailingAddress2, value); }
		}

		/// <summary> The MailingCity property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."MailingCity"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 225<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MailingCity
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.MailingCity, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.MailingCity, value); }
		}

		/// <summary> The MailingState property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."MailingState"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 225<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MailingState
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.MailingState, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.MailingState, value); }
		}

		/// <summary> The MailingZip property of the Entity PhysicianMaster<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPhysicianMaster"."MailingZip"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MailingZip
		{
			get { return (System.String)GetValue((int)PhysicianMasterFieldIndex.MailingZip, true); }
			set	{ SetValue((int)PhysicianMasterFieldIndex.MailingZip, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerPrimaryCarePhysicianEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerPrimaryCarePhysicianEntity))]
		public virtual EntityCollection<CustomerPrimaryCarePhysicianEntity> CustomerPrimaryCarePhysician
		{
			get
			{
				if(_customerPrimaryCarePhysician==null)
				{
					_customerPrimaryCarePhysician = new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory)));
					_customerPrimaryCarePhysician.SetContainingEntityInfo(this, "PhysicianMaster");
				}
				return _customerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				if(_addressCollectionViaCustomerPrimaryCarePhysician==null)
				{
					_addressCollectionViaCustomerPrimaryCarePhysician = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _addressCollectionViaCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				if(_addressCollectionViaCustomerPrimaryCarePhysician_==null)
				{
					_addressCollectionViaCustomerPrimaryCarePhysician_ = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly=true;
				}
				return _addressCollectionViaCustomerPrimaryCarePhysician_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				if(_customerProfileCollectionViaCustomerPrimaryCarePhysician==null)
				{
					_customerProfileCollectionViaCustomerPrimaryCarePhysician = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				if(_lookupCollectionViaCustomerPrimaryCarePhysician==null)
				{
					_lookupCollectionViaCustomerPrimaryCarePhysician = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__;
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
			get { return (int)Falcon.Data.EntityType.PhysicianMasterEntity; }
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
