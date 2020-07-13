///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:49
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
	/// Entity class which represents the entity 'AccessControlObject'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AccessControlObjectEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccessControlObjectEntity> _accessControlObject_;
		private EntityCollection<AccessControlObjectUrlEntity> _accessControlObjectUrl;
		private EntityCollection<AccessObjectScopeOptionEntity> _accessObjectScopeOption;
		private EntityCollection<RoleAccessControlObjectEntity> _roleAccessControlObject;
		private EntityCollection<RolePermisibleAccessControlObjectEntity> _rolePermisibleAccessControlObject;
		private EntityCollection<LookupEntity> _lookupCollectionViaRoleAccessControlObject;
		private EntityCollection<LookupEntity> _lookupCollectionViaRoleAccessControlObject_;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccessObjectScopeOption;
		private EntityCollection<RoleEntity> _roleCollectionViaRolePermisibleAccessControlObject;
		private EntityCollection<RoleEntity> _roleCollectionViaRoleAccessControlObject;
		private AccessControlObjectEntity _accessControlObject;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AccessControlObject</summary>
			public static readonly string AccessControlObject = "AccessControlObject";
			/// <summary>Member name AccessControlObject_</summary>
			public static readonly string AccessControlObject_ = "AccessControlObject_";
			/// <summary>Member name AccessControlObjectUrl</summary>
			public static readonly string AccessControlObjectUrl = "AccessControlObjectUrl";
			/// <summary>Member name AccessObjectScopeOption</summary>
			public static readonly string AccessObjectScopeOption = "AccessObjectScopeOption";
			/// <summary>Member name RoleAccessControlObject</summary>
			public static readonly string RoleAccessControlObject = "RoleAccessControlObject";
			/// <summary>Member name RolePermisibleAccessControlObject</summary>
			public static readonly string RolePermisibleAccessControlObject = "RolePermisibleAccessControlObject";
			/// <summary>Member name LookupCollectionViaRoleAccessControlObject</summary>
			public static readonly string LookupCollectionViaRoleAccessControlObject = "LookupCollectionViaRoleAccessControlObject";
			/// <summary>Member name LookupCollectionViaRoleAccessControlObject_</summary>
			public static readonly string LookupCollectionViaRoleAccessControlObject_ = "LookupCollectionViaRoleAccessControlObject_";
			/// <summary>Member name LookupCollectionViaAccessObjectScopeOption</summary>
			public static readonly string LookupCollectionViaAccessObjectScopeOption = "LookupCollectionViaAccessObjectScopeOption";
			/// <summary>Member name RoleCollectionViaRolePermisibleAccessControlObject</summary>
			public static readonly string RoleCollectionViaRolePermisibleAccessControlObject = "RoleCollectionViaRolePermisibleAccessControlObject";
			/// <summary>Member name RoleCollectionViaRoleAccessControlObject</summary>
			public static readonly string RoleCollectionViaRoleAccessControlObject = "RoleCollectionViaRoleAccessControlObject";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AccessControlObjectEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AccessControlObjectEntity():base("AccessControlObjectEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AccessControlObjectEntity(IEntityFields2 fields):base("AccessControlObjectEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AccessControlObjectEntity</param>
		public AccessControlObjectEntity(IValidator validator):base("AccessControlObjectEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for AccessControlObject which data should be fetched into this AccessControlObject object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AccessControlObjectEntity(System.Int64 id):base("AccessControlObjectEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for AccessControlObject which data should be fetched into this AccessControlObject object</param>
		/// <param name="validator">The custom validator object for this AccessControlObjectEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AccessControlObjectEntity(System.Int64 id, IValidator validator):base("AccessControlObjectEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AccessControlObjectEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accessControlObject_ = (EntityCollection<AccessControlObjectEntity>)info.GetValue("_accessControlObject_", typeof(EntityCollection<AccessControlObjectEntity>));
				_accessControlObjectUrl = (EntityCollection<AccessControlObjectUrlEntity>)info.GetValue("_accessControlObjectUrl", typeof(EntityCollection<AccessControlObjectUrlEntity>));
				_accessObjectScopeOption = (EntityCollection<AccessObjectScopeOptionEntity>)info.GetValue("_accessObjectScopeOption", typeof(EntityCollection<AccessObjectScopeOptionEntity>));
				_roleAccessControlObject = (EntityCollection<RoleAccessControlObjectEntity>)info.GetValue("_roleAccessControlObject", typeof(EntityCollection<RoleAccessControlObjectEntity>));
				_rolePermisibleAccessControlObject = (EntityCollection<RolePermisibleAccessControlObjectEntity>)info.GetValue("_rolePermisibleAccessControlObject", typeof(EntityCollection<RolePermisibleAccessControlObjectEntity>));
				_lookupCollectionViaRoleAccessControlObject = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaRoleAccessControlObject", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaRoleAccessControlObject_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaRoleAccessControlObject_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccessObjectScopeOption = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccessObjectScopeOption", typeof(EntityCollection<LookupEntity>));
				_roleCollectionViaRolePermisibleAccessControlObject = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaRolePermisibleAccessControlObject", typeof(EntityCollection<RoleEntity>));
				_roleCollectionViaRoleAccessControlObject = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaRoleAccessControlObject", typeof(EntityCollection<RoleEntity>));
				_accessControlObject = (AccessControlObjectEntity)info.GetValue("_accessControlObject", typeof(AccessControlObjectEntity));
				if(_accessControlObject!=null)
				{
					_accessControlObject.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AccessControlObjectFieldIndex)fieldIndex)
			{
				case AccessControlObjectFieldIndex.ParentId:
					DesetupSyncAccessControlObject(true, false);
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
				case "AccessControlObject":
					this.AccessControlObject = (AccessControlObjectEntity)entity;
					break;
				case "AccessControlObject_":
					this.AccessControlObject_.Add((AccessControlObjectEntity)entity);
					break;
				case "AccessControlObjectUrl":
					this.AccessControlObjectUrl.Add((AccessControlObjectUrlEntity)entity);
					break;
				case "AccessObjectScopeOption":
					this.AccessObjectScopeOption.Add((AccessObjectScopeOptionEntity)entity);
					break;
				case "RoleAccessControlObject":
					this.RoleAccessControlObject.Add((RoleAccessControlObjectEntity)entity);
					break;
				case "RolePermisibleAccessControlObject":
					this.RolePermisibleAccessControlObject.Add((RolePermisibleAccessControlObjectEntity)entity);
					break;
				case "LookupCollectionViaRoleAccessControlObject":
					this.LookupCollectionViaRoleAccessControlObject.IsReadOnly = false;
					this.LookupCollectionViaRoleAccessControlObject.Add((LookupEntity)entity);
					this.LookupCollectionViaRoleAccessControlObject.IsReadOnly = true;
					break;
				case "LookupCollectionViaRoleAccessControlObject_":
					this.LookupCollectionViaRoleAccessControlObject_.IsReadOnly = false;
					this.LookupCollectionViaRoleAccessControlObject_.Add((LookupEntity)entity);
					this.LookupCollectionViaRoleAccessControlObject_.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccessObjectScopeOption":
					this.LookupCollectionViaAccessObjectScopeOption.IsReadOnly = false;
					this.LookupCollectionViaAccessObjectScopeOption.Add((LookupEntity)entity);
					this.LookupCollectionViaAccessObjectScopeOption.IsReadOnly = true;
					break;
				case "RoleCollectionViaRolePermisibleAccessControlObject":
					this.RoleCollectionViaRolePermisibleAccessControlObject.IsReadOnly = false;
					this.RoleCollectionViaRolePermisibleAccessControlObject.Add((RoleEntity)entity);
					this.RoleCollectionViaRolePermisibleAccessControlObject.IsReadOnly = true;
					break;
				case "RoleCollectionViaRoleAccessControlObject":
					this.RoleCollectionViaRoleAccessControlObject.IsReadOnly = false;
					this.RoleCollectionViaRoleAccessControlObject.Add((RoleEntity)entity);
					this.RoleCollectionViaRoleAccessControlObject.IsReadOnly = true;
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
			return AccessControlObjectEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AccessControlObject":
					toReturn.Add(AccessControlObjectEntity.Relations.AccessControlObjectEntityUsingIdParentId);
					break;
				case "AccessControlObject_":
					toReturn.Add(AccessControlObjectEntity.Relations.AccessControlObjectEntityUsingParentId);
					break;
				case "AccessControlObjectUrl":
					toReturn.Add(AccessControlObjectEntity.Relations.AccessControlObjectUrlEntityUsingAccessControlObjectId);
					break;
				case "AccessObjectScopeOption":
					toReturn.Add(AccessControlObjectEntity.Relations.AccessObjectScopeOptionEntityUsingAccessControlObjectId);
					break;
				case "RoleAccessControlObject":
					toReturn.Add(AccessControlObjectEntity.Relations.RoleAccessControlObjectEntityUsingAccessControlObjectId);
					break;
				case "RolePermisibleAccessControlObject":
					toReturn.Add(AccessControlObjectEntity.Relations.RolePermisibleAccessControlObjectEntityUsingAccessControlObjectId);
					break;
				case "LookupCollectionViaRoleAccessControlObject":
					toReturn.Add(AccessControlObjectEntity.Relations.RoleAccessControlObjectEntityUsingAccessControlObjectId, "AccessControlObjectEntity__", "RoleAccessControlObject_", JoinHint.None);
					toReturn.Add(RoleAccessControlObjectEntity.Relations.LookupEntityUsingPermissionTypeId, "RoleAccessControlObject_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaRoleAccessControlObject_":
					toReturn.Add(AccessControlObjectEntity.Relations.RoleAccessControlObjectEntityUsingAccessControlObjectId, "AccessControlObjectEntity__", "RoleAccessControlObject_", JoinHint.None);
					toReturn.Add(RoleAccessControlObjectEntity.Relations.LookupEntityUsingScopeId, "RoleAccessControlObject_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccessObjectScopeOption":
					toReturn.Add(AccessControlObjectEntity.Relations.AccessObjectScopeOptionEntityUsingAccessControlObjectId, "AccessControlObjectEntity__", "AccessObjectScopeOption_", JoinHint.None);
					toReturn.Add(AccessObjectScopeOptionEntity.Relations.LookupEntityUsingScopeId, "AccessObjectScopeOption_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaRolePermisibleAccessControlObject":
					toReturn.Add(AccessControlObjectEntity.Relations.RolePermisibleAccessControlObjectEntityUsingAccessControlObjectId, "AccessControlObjectEntity__", "RolePermisibleAccessControlObject_", JoinHint.None);
					toReturn.Add(RolePermisibleAccessControlObjectEntity.Relations.RoleEntityUsingRoleId, "RolePermisibleAccessControlObject_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaRoleAccessControlObject":
					toReturn.Add(AccessControlObjectEntity.Relations.RoleAccessControlObjectEntityUsingAccessControlObjectId, "AccessControlObjectEntity__", "RoleAccessControlObject_", JoinHint.None);
					toReturn.Add(RoleAccessControlObjectEntity.Relations.RoleEntityUsingRoleId, "RoleAccessControlObject_", string.Empty, JoinHint.None);
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
				case "AccessControlObject":
					SetupSyncAccessControlObject(relatedEntity);
					break;
				case "AccessControlObject_":
					this.AccessControlObject_.Add((AccessControlObjectEntity)relatedEntity);
					break;
				case "AccessControlObjectUrl":
					this.AccessControlObjectUrl.Add((AccessControlObjectUrlEntity)relatedEntity);
					break;
				case "AccessObjectScopeOption":
					this.AccessObjectScopeOption.Add((AccessObjectScopeOptionEntity)relatedEntity);
					break;
				case "RoleAccessControlObject":
					this.RoleAccessControlObject.Add((RoleAccessControlObjectEntity)relatedEntity);
					break;
				case "RolePermisibleAccessControlObject":
					this.RolePermisibleAccessControlObject.Add((RolePermisibleAccessControlObjectEntity)relatedEntity);
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
				case "AccessControlObject":
					DesetupSyncAccessControlObject(false, true);
					break;
				case "AccessControlObject_":
					base.PerformRelatedEntityRemoval(this.AccessControlObject_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccessControlObjectUrl":
					base.PerformRelatedEntityRemoval(this.AccessControlObjectUrl, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccessObjectScopeOption":
					base.PerformRelatedEntityRemoval(this.AccessObjectScopeOption, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleAccessControlObject":
					base.PerformRelatedEntityRemoval(this.RoleAccessControlObject, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RolePermisibleAccessControlObject":
					base.PerformRelatedEntityRemoval(this.RolePermisibleAccessControlObject, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_accessControlObject!=null)
			{
				toReturn.Add(_accessControlObject);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AccessControlObject_);
			toReturn.Add(this.AccessControlObjectUrl);
			toReturn.Add(this.AccessObjectScopeOption);
			toReturn.Add(this.RoleAccessControlObject);
			toReturn.Add(this.RolePermisibleAccessControlObject);

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
				info.AddValue("_accessControlObject_", ((_accessControlObject_!=null) && (_accessControlObject_.Count>0) && !this.MarkedForDeletion)?_accessControlObject_:null);
				info.AddValue("_accessControlObjectUrl", ((_accessControlObjectUrl!=null) && (_accessControlObjectUrl.Count>0) && !this.MarkedForDeletion)?_accessControlObjectUrl:null);
				info.AddValue("_accessObjectScopeOption", ((_accessObjectScopeOption!=null) && (_accessObjectScopeOption.Count>0) && !this.MarkedForDeletion)?_accessObjectScopeOption:null);
				info.AddValue("_roleAccessControlObject", ((_roleAccessControlObject!=null) && (_roleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_roleAccessControlObject:null);
				info.AddValue("_rolePermisibleAccessControlObject", ((_rolePermisibleAccessControlObject!=null) && (_rolePermisibleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_rolePermisibleAccessControlObject:null);
				info.AddValue("_lookupCollectionViaRoleAccessControlObject", ((_lookupCollectionViaRoleAccessControlObject!=null) && (_lookupCollectionViaRoleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaRoleAccessControlObject:null);
				info.AddValue("_lookupCollectionViaRoleAccessControlObject_", ((_lookupCollectionViaRoleAccessControlObject_!=null) && (_lookupCollectionViaRoleAccessControlObject_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaRoleAccessControlObject_:null);
				info.AddValue("_lookupCollectionViaAccessObjectScopeOption", ((_lookupCollectionViaAccessObjectScopeOption!=null) && (_lookupCollectionViaAccessObjectScopeOption.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccessObjectScopeOption:null);
				info.AddValue("_roleCollectionViaRolePermisibleAccessControlObject", ((_roleCollectionViaRolePermisibleAccessControlObject!=null) && (_roleCollectionViaRolePermisibleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaRolePermisibleAccessControlObject:null);
				info.AddValue("_roleCollectionViaRoleAccessControlObject", ((_roleCollectionViaRoleAccessControlObject!=null) && (_roleCollectionViaRoleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaRoleAccessControlObject:null);
				info.AddValue("_accessControlObject", (!this.MarkedForDeletion?_accessControlObject:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AccessControlObjectFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AccessControlObjectFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AccessControlObjectRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccessControlObject' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccessControlObject_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessControlObjectFields.ParentId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccessControlObjectUrl' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccessControlObjectUrl()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessControlObjectUrlFields.AccessControlObjectId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccessObjectScopeOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccessObjectScopeOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessObjectScopeOptionFields.AccessControlObjectId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RoleAccessControlObject' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleAccessControlObjectFields.AccessControlObjectId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RolePermisibleAccessControlObject' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRolePermisibleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RolePermisibleAccessControlObjectFields.AccessControlObjectId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaRoleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaRoleAccessControlObject"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessControlObjectFields.Id, null, ComparisonOperator.Equal, this.Id, "AccessControlObjectEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaRoleAccessControlObject_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaRoleAccessControlObject_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessControlObjectFields.Id, null, ComparisonOperator.Equal, this.Id, "AccessControlObjectEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccessObjectScopeOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccessObjectScopeOption"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessControlObjectFields.Id, null, ComparisonOperator.Equal, this.Id, "AccessControlObjectEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaRolePermisibleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaRolePermisibleAccessControlObject"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessControlObjectFields.Id, null, ComparisonOperator.Equal, this.Id, "AccessControlObjectEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaRoleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaRoleAccessControlObject"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessControlObjectFields.Id, null, ComparisonOperator.Equal, this.Id, "AccessControlObjectEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AccessControlObject' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccessControlObjectFields.Id, null, ComparisonOperator.Equal, this.ParentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AccessControlObjectEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accessControlObject_);
			collectionsQueue.Enqueue(this._accessControlObjectUrl);
			collectionsQueue.Enqueue(this._accessObjectScopeOption);
			collectionsQueue.Enqueue(this._roleAccessControlObject);
			collectionsQueue.Enqueue(this._rolePermisibleAccessControlObject);
			collectionsQueue.Enqueue(this._lookupCollectionViaRoleAccessControlObject);
			collectionsQueue.Enqueue(this._lookupCollectionViaRoleAccessControlObject_);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccessObjectScopeOption);
			collectionsQueue.Enqueue(this._roleCollectionViaRolePermisibleAccessControlObject);
			collectionsQueue.Enqueue(this._roleCollectionViaRoleAccessControlObject);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accessControlObject_ = (EntityCollection<AccessControlObjectEntity>) collectionsQueue.Dequeue();
			this._accessControlObjectUrl = (EntityCollection<AccessControlObjectUrlEntity>) collectionsQueue.Dequeue();
			this._accessObjectScopeOption = (EntityCollection<AccessObjectScopeOptionEntity>) collectionsQueue.Dequeue();
			this._roleAccessControlObject = (EntityCollection<RoleAccessControlObjectEntity>) collectionsQueue.Dequeue();
			this._rolePermisibleAccessControlObject = (EntityCollection<RolePermisibleAccessControlObjectEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaRoleAccessControlObject = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaRoleAccessControlObject_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccessObjectScopeOption = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaRolePermisibleAccessControlObject = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaRoleAccessControlObject = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accessControlObject_ != null)
			{
				return true;
			}
			if (this._accessControlObjectUrl != null)
			{
				return true;
			}
			if (this._accessObjectScopeOption != null)
			{
				return true;
			}
			if (this._roleAccessControlObject != null)
			{
				return true;
			}
			if (this._rolePermisibleAccessControlObject != null)
			{
				return true;
			}
			if (this._lookupCollectionViaRoleAccessControlObject != null)
			{
				return true;
			}
			if (this._lookupCollectionViaRoleAccessControlObject_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccessObjectScopeOption != null)
			{
				return true;
			}
			if (this._roleCollectionViaRolePermisibleAccessControlObject != null)
			{
				return true;
			}
			if (this._roleCollectionViaRoleAccessControlObject != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccessControlObjectUrlEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectUrlEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccessObjectScopeOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessObjectScopeOptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleAccessControlObjectEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RolePermisibleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RolePermisibleAccessControlObjectEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AccessControlObject", _accessControlObject);
			toReturn.Add("AccessControlObject_", _accessControlObject_);
			toReturn.Add("AccessControlObjectUrl", _accessControlObjectUrl);
			toReturn.Add("AccessObjectScopeOption", _accessObjectScopeOption);
			toReturn.Add("RoleAccessControlObject", _roleAccessControlObject);
			toReturn.Add("RolePermisibleAccessControlObject", _rolePermisibleAccessControlObject);
			toReturn.Add("LookupCollectionViaRoleAccessControlObject", _lookupCollectionViaRoleAccessControlObject);
			toReturn.Add("LookupCollectionViaRoleAccessControlObject_", _lookupCollectionViaRoleAccessControlObject_);
			toReturn.Add("LookupCollectionViaAccessObjectScopeOption", _lookupCollectionViaAccessObjectScopeOption);
			toReturn.Add("RoleCollectionViaRolePermisibleAccessControlObject", _roleCollectionViaRolePermisibleAccessControlObject);
			toReturn.Add("RoleCollectionViaRoleAccessControlObject", _roleCollectionViaRoleAccessControlObject);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accessControlObject_!=null)
			{
				_accessControlObject_.ActiveContext = base.ActiveContext;
			}
			if(_accessControlObjectUrl!=null)
			{
				_accessControlObjectUrl.ActiveContext = base.ActiveContext;
			}
			if(_accessObjectScopeOption!=null)
			{
				_accessObjectScopeOption.ActiveContext = base.ActiveContext;
			}
			if(_roleAccessControlObject!=null)
			{
				_roleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_rolePermisibleAccessControlObject!=null)
			{
				_rolePermisibleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaRoleAccessControlObject!=null)
			{
				_lookupCollectionViaRoleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaRoleAccessControlObject_!=null)
			{
				_lookupCollectionViaRoleAccessControlObject_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccessObjectScopeOption!=null)
			{
				_lookupCollectionViaAccessObjectScopeOption.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaRolePermisibleAccessControlObject!=null)
			{
				_roleCollectionViaRolePermisibleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaRoleAccessControlObject!=null)
			{
				_roleCollectionViaRoleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_accessControlObject!=null)
			{
				_accessControlObject.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_accessControlObject_ = null;
			_accessControlObjectUrl = null;
			_accessObjectScopeOption = null;
			_roleAccessControlObject = null;
			_rolePermisibleAccessControlObject = null;
			_lookupCollectionViaRoleAccessControlObject = null;
			_lookupCollectionViaRoleAccessControlObject_ = null;
			_lookupCollectionViaAccessObjectScopeOption = null;
			_roleCollectionViaRolePermisibleAccessControlObject = null;
			_roleCollectionViaRoleAccessControlObject = null;
			_accessControlObject = null;

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

			_fieldsCustomProperties.Add("Title", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisplayOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsRequired", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _accessControlObject</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAccessControlObject(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _accessControlObject, new PropertyChangedEventHandler( OnAccessControlObjectPropertyChanged ), "AccessControlObject", AccessControlObjectEntity.Relations.AccessControlObjectEntityUsingIdParentId, true, signalRelatedEntity, "AccessControlObject_", resetFKFields, new int[] { (int)AccessControlObjectFieldIndex.ParentId } );		
			_accessControlObject = null;
		}

		/// <summary> setups the sync logic for member _accessControlObject</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAccessControlObject(IEntity2 relatedEntity)
		{
			if(_accessControlObject!=relatedEntity)
			{
				DesetupSyncAccessControlObject(true, true);
				_accessControlObject = (AccessControlObjectEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _accessControlObject, new PropertyChangedEventHandler( OnAccessControlObjectPropertyChanged ), "AccessControlObject", AccessControlObjectEntity.Relations.AccessControlObjectEntityUsingIdParentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAccessControlObjectPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AccessControlObjectEntity</param>
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
		public  static AccessControlObjectRelations Relations
		{
			get	{ return new AccessControlObjectRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccessControlObject' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccessControlObject_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccessControlObject_")[0], (int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.AccessControlObjectEntity, 0, null, null, null, null, "AccessControlObject_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccessControlObjectUrl' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccessControlObjectUrl
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccessControlObjectUrlEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectUrlEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccessControlObjectUrl")[0], (int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.AccessControlObjectUrlEntity, 0, null, null, null, null, "AccessControlObjectUrl", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccessObjectScopeOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccessObjectScopeOption
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccessObjectScopeOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessObjectScopeOptionEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccessObjectScopeOption")[0], (int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.AccessObjectScopeOptionEntity, 0, null, null, null, null, "AccessObjectScopeOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RoleAccessControlObject' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleAccessControlObject
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RoleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleAccessControlObjectEntityFactory))),
					(IEntityRelation)GetRelationsForField("RoleAccessControlObject")[0], (int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.RoleAccessControlObjectEntity, 0, null, null, null, null, "RoleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RolePermisibleAccessControlObject' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRolePermisibleAccessControlObject
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RolePermisibleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RolePermisibleAccessControlObjectEntityFactory))),
					(IEntityRelation)GetRelationsForField("RolePermisibleAccessControlObject")[0], (int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.RolePermisibleAccessControlObjectEntity, 0, null, null, null, null, "RolePermisibleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaRoleAccessControlObject
		{
			get
			{
				IEntityRelation intermediateRelation = AccessControlObjectEntity.Relations.RoleAccessControlObjectEntityUsingAccessControlObjectId;
				intermediateRelation.SetAliases(string.Empty, "RoleAccessControlObject_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaRoleAccessControlObject"), null, "LookupCollectionViaRoleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaRoleAccessControlObject_
		{
			get
			{
				IEntityRelation intermediateRelation = AccessControlObjectEntity.Relations.RoleAccessControlObjectEntityUsingAccessControlObjectId;
				intermediateRelation.SetAliases(string.Empty, "RoleAccessControlObject_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaRoleAccessControlObject_"), null, "LookupCollectionViaRoleAccessControlObject_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccessObjectScopeOption
		{
			get
			{
				IEntityRelation intermediateRelation = AccessControlObjectEntity.Relations.AccessObjectScopeOptionEntityUsingAccessControlObjectId;
				intermediateRelation.SetAliases(string.Empty, "AccessObjectScopeOption_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccessObjectScopeOption"), null, "LookupCollectionViaAccessObjectScopeOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaRolePermisibleAccessControlObject
		{
			get
			{
				IEntityRelation intermediateRelation = AccessControlObjectEntity.Relations.RolePermisibleAccessControlObjectEntityUsingAccessControlObjectId;
				intermediateRelation.SetAliases(string.Empty, "RolePermisibleAccessControlObject_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaRolePermisibleAccessControlObject"), null, "RoleCollectionViaRolePermisibleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaRoleAccessControlObject
		{
			get
			{
				IEntityRelation intermediateRelation = AccessControlObjectEntity.Relations.RoleAccessControlObjectEntityUsingAccessControlObjectId;
				intermediateRelation.SetAliases(string.Empty, "RoleAccessControlObject_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaRoleAccessControlObject"), null, "RoleCollectionViaRoleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccessControlObject' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccessControlObject
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccessControlObject")[0], (int)Falcon.Data.EntityType.AccessControlObjectEntity, (int)Falcon.Data.EntityType.AccessControlObjectEntity, 0, null, null, null, null, "AccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AccessControlObjectEntity.CustomProperties;}
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
			get { return AccessControlObjectEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity AccessControlObject<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccessControlObject"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)AccessControlObjectFieldIndex.Id, true); }
			set	{ SetValue((int)AccessControlObjectFieldIndex.Id, value); }
		}

		/// <summary> The Title property of the Entity AccessControlObject<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccessControlObject"."Title"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Title
		{
			get { return (System.String)GetValue((int)AccessControlObjectFieldIndex.Title, true); }
			set	{ SetValue((int)AccessControlObjectFieldIndex.Title, value); }
		}

		/// <summary> The Description property of the Entity AccessControlObject<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccessControlObject"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)AccessControlObjectFieldIndex.Description, true); }
			set	{ SetValue((int)AccessControlObjectFieldIndex.Description, value); }
		}

		/// <summary> The ParentId property of the Entity AccessControlObject<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccessControlObject"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccessControlObjectFieldIndex.ParentId, false); }
			set	{ SetValue((int)AccessControlObjectFieldIndex.ParentId, value); }
		}

		/// <summary> The DisplayOrder property of the Entity AccessControlObject<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccessControlObject"."DisplayOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DisplayOrder
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccessControlObjectFieldIndex.DisplayOrder, false); }
			set	{ SetValue((int)AccessControlObjectFieldIndex.DisplayOrder, value); }
		}

		/// <summary> The IsRequired property of the Entity AccessControlObject<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccessControlObject"."IsRequired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsRequired
		{
			get { return (System.Boolean)GetValue((int)AccessControlObjectFieldIndex.IsRequired, true); }
			set	{ SetValue((int)AccessControlObjectFieldIndex.IsRequired, value); }
		}

		/// <summary> The Alias property of the Entity AccessControlObject<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccessControlObject"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)AccessControlObjectFieldIndex.Alias, true); }
			set	{ SetValue((int)AccessControlObjectFieldIndex.Alias, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccessControlObjectEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccessControlObjectEntity))]
		public virtual EntityCollection<AccessControlObjectEntity> AccessControlObject_
		{
			get
			{
				if(_accessControlObject_==null)
				{
					_accessControlObject_ = new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory)));
					_accessControlObject_.SetContainingEntityInfo(this, "AccessControlObject");
				}
				return _accessControlObject_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccessControlObjectUrlEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccessControlObjectUrlEntity))]
		public virtual EntityCollection<AccessControlObjectUrlEntity> AccessControlObjectUrl
		{
			get
			{
				if(_accessControlObjectUrl==null)
				{
					_accessControlObjectUrl = new EntityCollection<AccessControlObjectUrlEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectUrlEntityFactory)));
					_accessControlObjectUrl.SetContainingEntityInfo(this, "AccessControlObject");
				}
				return _accessControlObjectUrl;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccessObjectScopeOptionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccessObjectScopeOptionEntity))]
		public virtual EntityCollection<AccessObjectScopeOptionEntity> AccessObjectScopeOption
		{
			get
			{
				if(_accessObjectScopeOption==null)
				{
					_accessObjectScopeOption = new EntityCollection<AccessObjectScopeOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessObjectScopeOptionEntityFactory)));
					_accessObjectScopeOption.SetContainingEntityInfo(this, "AccessControlObject");
				}
				return _accessObjectScopeOption;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleAccessControlObjectEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleAccessControlObjectEntity))]
		public virtual EntityCollection<RoleAccessControlObjectEntity> RoleAccessControlObject
		{
			get
			{
				if(_roleAccessControlObject==null)
				{
					_roleAccessControlObject = new EntityCollection<RoleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleAccessControlObjectEntityFactory)));
					_roleAccessControlObject.SetContainingEntityInfo(this, "AccessControlObject");
				}
				return _roleAccessControlObject;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RolePermisibleAccessControlObjectEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RolePermisibleAccessControlObjectEntity))]
		public virtual EntityCollection<RolePermisibleAccessControlObjectEntity> RolePermisibleAccessControlObject
		{
			get
			{
				if(_rolePermisibleAccessControlObject==null)
				{
					_rolePermisibleAccessControlObject = new EntityCollection<RolePermisibleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RolePermisibleAccessControlObjectEntityFactory)));
					_rolePermisibleAccessControlObject.SetContainingEntityInfo(this, "AccessControlObject");
				}
				return _rolePermisibleAccessControlObject;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaRoleAccessControlObject
		{
			get
			{
				if(_lookupCollectionViaRoleAccessControlObject==null)
				{
					_lookupCollectionViaRoleAccessControlObject = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaRoleAccessControlObject.IsReadOnly=true;
				}
				return _lookupCollectionViaRoleAccessControlObject;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaRoleAccessControlObject_
		{
			get
			{
				if(_lookupCollectionViaRoleAccessControlObject_==null)
				{
					_lookupCollectionViaRoleAccessControlObject_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaRoleAccessControlObject_.IsReadOnly=true;
				}
				return _lookupCollectionViaRoleAccessControlObject_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaAccessObjectScopeOption
		{
			get
			{
				if(_lookupCollectionViaAccessObjectScopeOption==null)
				{
					_lookupCollectionViaAccessObjectScopeOption = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaAccessObjectScopeOption.IsReadOnly=true;
				}
				return _lookupCollectionViaAccessObjectScopeOption;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaRolePermisibleAccessControlObject
		{
			get
			{
				if(_roleCollectionViaRolePermisibleAccessControlObject==null)
				{
					_roleCollectionViaRolePermisibleAccessControlObject = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaRolePermisibleAccessControlObject.IsReadOnly=true;
				}
				return _roleCollectionViaRolePermisibleAccessControlObject;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaRoleAccessControlObject
		{
			get
			{
				if(_roleCollectionViaRoleAccessControlObject==null)
				{
					_roleCollectionViaRoleAccessControlObject = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaRoleAccessControlObject.IsReadOnly=true;
				}
				return _roleCollectionViaRoleAccessControlObject;
			}
		}

		/// <summary> Gets / sets related entity of type 'AccessControlObjectEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AccessControlObjectEntity AccessControlObject
		{
			get
			{
				return _accessControlObject;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAccessControlObject(value);
				}
				else
				{
					if(value==null)
					{
						if(_accessControlObject != null)
						{
							_accessControlObject.UnsetRelatedEntity(this, "AccessControlObject_");
						}
					}
					else
					{
						if(_accessControlObject!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AccessControlObject_");
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
			get { return (int)Falcon.Data.EntityType.AccessControlObjectEntity; }
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
