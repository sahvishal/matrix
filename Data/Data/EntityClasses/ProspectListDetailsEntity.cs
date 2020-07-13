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
	/// Entity class which represents the entity 'ProspectListDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProspectListDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MarketingPrintOrderProspectListMappingEntity> _marketingPrintOrderProspectListMapping;
		private EntityCollection<ProspectFaliureReportEntity> _prospectFaliureReport;
		private EntityCollection<ProspectsEntity> _prospects;
		private EntityCollection<AddressEntity> _addressCollectionViaProspects;
		private EntityCollection<MarketingPrintOrderItemEntity> _marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaProspects;
		private EntityCollection<ProspectTypeEntity> _prospectTypeCollectionViaProspects;
		private OrganizationEntity _organization;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
			/// <summary>Member name MarketingPrintOrderProspectListMapping</summary>
			public static readonly string MarketingPrintOrderProspectListMapping = "MarketingPrintOrderProspectListMapping";
			/// <summary>Member name ProspectFaliureReport</summary>
			public static readonly string ProspectFaliureReport = "ProspectFaliureReport";
			/// <summary>Member name Prospects</summary>
			public static readonly string Prospects = "Prospects";
			/// <summary>Member name AddressCollectionViaProspects</summary>
			public static readonly string AddressCollectionViaProspects = "AddressCollectionViaProspects";
			/// <summary>Member name MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping</summary>
			public static readonly string MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping = "MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping";
			/// <summary>Member name OrganizationRoleUserCollectionViaProspects</summary>
			public static readonly string OrganizationRoleUserCollectionViaProspects = "OrganizationRoleUserCollectionViaProspects";
			/// <summary>Member name ProspectTypeCollectionViaProspects</summary>
			public static readonly string ProspectTypeCollectionViaProspects = "ProspectTypeCollectionViaProspects";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ProspectListDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ProspectListDetailsEntity():base("ProspectListDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ProspectListDetailsEntity(IEntityFields2 fields):base("ProspectListDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ProspectListDetailsEntity</param>
		public ProspectListDetailsEntity(IValidator validator):base("ProspectListDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="prospectFileId">PK value for ProspectListDetails which data should be fetched into this ProspectListDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectListDetailsEntity(System.Int64 prospectFileId):base("ProspectListDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ProspectFileId = prospectFileId;
		}

		/// <summary> CTor</summary>
		/// <param name="prospectFileId">PK value for ProspectListDetails which data should be fetched into this ProspectListDetails object</param>
		/// <param name="validator">The custom validator object for this ProspectListDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectListDetailsEntity(System.Int64 prospectFileId, IValidator validator):base("ProspectListDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ProspectFileId = prospectFileId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ProspectListDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_marketingPrintOrderProspectListMapping = (EntityCollection<MarketingPrintOrderProspectListMappingEntity>)info.GetValue("_marketingPrintOrderProspectListMapping", typeof(EntityCollection<MarketingPrintOrderProspectListMappingEntity>));
				_prospectFaliureReport = (EntityCollection<ProspectFaliureReportEntity>)info.GetValue("_prospectFaliureReport", typeof(EntityCollection<ProspectFaliureReportEntity>));
				_prospects = (EntityCollection<ProspectsEntity>)info.GetValue("_prospects", typeof(EntityCollection<ProspectsEntity>));
				_addressCollectionViaProspects = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaProspects", typeof(EntityCollection<AddressEntity>));
				_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping = (EntityCollection<MarketingPrintOrderItemEntity>)info.GetValue("_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping", typeof(EntityCollection<MarketingPrintOrderItemEntity>));
				_organizationRoleUserCollectionViaProspects = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaProspects", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectTypeCollectionViaProspects = (EntityCollection<ProspectTypeEntity>)info.GetValue("_prospectTypeCollectionViaProspects", typeof(EntityCollection<ProspectTypeEntity>));
				_organization = (OrganizationEntity)info.GetValue("_organization", typeof(OrganizationEntity));
				if(_organization!=null)
				{
					_organization.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ProspectListDetailsFieldIndex)fieldIndex)
			{
				case ProspectListDetailsFieldIndex.OrganizationId:
					DesetupSyncOrganization(true, false);
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
				case "Organization":
					this.Organization = (OrganizationEntity)entity;
					break;
				case "MarketingPrintOrderProspectListMapping":
					this.MarketingPrintOrderProspectListMapping.Add((MarketingPrintOrderProspectListMappingEntity)entity);
					break;
				case "ProspectFaliureReport":
					this.ProspectFaliureReport.Add((ProspectFaliureReportEntity)entity);
					break;
				case "Prospects":
					this.Prospects.Add((ProspectsEntity)entity);
					break;
				case "AddressCollectionViaProspects":
					this.AddressCollectionViaProspects.IsReadOnly = false;
					this.AddressCollectionViaProspects.Add((AddressEntity)entity);
					this.AddressCollectionViaProspects.IsReadOnly = true;
					break;
				case "MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping":
					this.MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping.IsReadOnly = false;
					this.MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping.Add((MarketingPrintOrderItemEntity)entity);
					this.MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaProspects":
					this.OrganizationRoleUserCollectionViaProspects.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaProspects.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaProspects.IsReadOnly = true;
					break;
				case "ProspectTypeCollectionViaProspects":
					this.ProspectTypeCollectionViaProspects.IsReadOnly = false;
					this.ProspectTypeCollectionViaProspects.Add((ProspectTypeEntity)entity);
					this.ProspectTypeCollectionViaProspects.IsReadOnly = true;
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
			return ProspectListDetailsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Organization":
					toReturn.Add(ProspectListDetailsEntity.Relations.OrganizationEntityUsingOrganizationId);
					break;
				case "MarketingPrintOrderProspectListMapping":
					toReturn.Add(ProspectListDetailsEntity.Relations.MarketingPrintOrderProspectListMappingEntityUsingProspectFileId);
					break;
				case "ProspectFaliureReport":
					toReturn.Add(ProspectListDetailsEntity.Relations.ProspectFaliureReportEntityUsingProspectListId);
					break;
				case "Prospects":
					toReturn.Add(ProspectListDetailsEntity.Relations.ProspectsEntityUsingProspectListId);
					break;
				case "AddressCollectionViaProspects":
					toReturn.Add(ProspectListDetailsEntity.Relations.ProspectsEntityUsingProspectListId, "ProspectListDetailsEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.AddressEntityUsingAddressId, "Prospects_", string.Empty, JoinHint.None);
					break;
				case "MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping":
					toReturn.Add(ProspectListDetailsEntity.Relations.MarketingPrintOrderProspectListMappingEntityUsingProspectFileId, "ProspectListDetailsEntity__", "MarketingPrintOrderProspectListMapping_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderProspectListMappingEntity.Relations.MarketingPrintOrderItemEntityUsingMarketingPrintOrderItemId, "MarketingPrintOrderProspectListMapping_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaProspects":
					toReturn.Add(ProspectListDetailsEntity.Relations.ProspectsEntityUsingProspectListId, "ProspectListDetailsEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, "Prospects_", string.Empty, JoinHint.None);
					break;
				case "ProspectTypeCollectionViaProspects":
					toReturn.Add(ProspectListDetailsEntity.Relations.ProspectsEntityUsingProspectListId, "ProspectListDetailsEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.ProspectTypeEntityUsingProspectTypeId, "Prospects_", string.Empty, JoinHint.None);
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
				case "Organization":
					SetupSyncOrganization(relatedEntity);
					break;
				case "MarketingPrintOrderProspectListMapping":
					this.MarketingPrintOrderProspectListMapping.Add((MarketingPrintOrderProspectListMappingEntity)relatedEntity);
					break;
				case "ProspectFaliureReport":
					this.ProspectFaliureReport.Add((ProspectFaliureReportEntity)relatedEntity);
					break;
				case "Prospects":
					this.Prospects.Add((ProspectsEntity)relatedEntity);
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
				case "Organization":
					DesetupSyncOrganization(false, true);
					break;
				case "MarketingPrintOrderProspectListMapping":
					base.PerformRelatedEntityRemoval(this.MarketingPrintOrderProspectListMapping, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectFaliureReport":
					base.PerformRelatedEntityRemoval(this.ProspectFaliureReport, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Prospects":
					base.PerformRelatedEntityRemoval(this.Prospects, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organization!=null)
			{
				toReturn.Add(_organization);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.MarketingPrintOrderProspectListMapping);
			toReturn.Add(this.ProspectFaliureReport);
			toReturn.Add(this.Prospects);

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
				info.AddValue("_marketingPrintOrderProspectListMapping", ((_marketingPrintOrderProspectListMapping!=null) && (_marketingPrintOrderProspectListMapping.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderProspectListMapping:null);
				info.AddValue("_prospectFaliureReport", ((_prospectFaliureReport!=null) && (_prospectFaliureReport.Count>0) && !this.MarkedForDeletion)?_prospectFaliureReport:null);
				info.AddValue("_prospects", ((_prospects!=null) && (_prospects.Count>0) && !this.MarkedForDeletion)?_prospects:null);
				info.AddValue("_addressCollectionViaProspects", ((_addressCollectionViaProspects!=null) && (_addressCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaProspects:null);
				info.AddValue("_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping", ((_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping!=null) && (_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping:null);
				info.AddValue("_organizationRoleUserCollectionViaProspects", ((_organizationRoleUserCollectionViaProspects!=null) && (_organizationRoleUserCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaProspects:null);
				info.AddValue("_prospectTypeCollectionViaProspects", ((_prospectTypeCollectionViaProspects!=null) && (_prospectTypeCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_prospectTypeCollectionViaProspects:null);
				info.AddValue("_organization", (!this.MarkedForDeletion?_organization:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ProspectListDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ProspectListDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ProspectListDetailsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrderProspectListMapping' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderProspectListMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderProspectListMappingFields.ProspectFileId, null, ComparisonOperator.Equal, this.ProspectFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectFaliureReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectFaliureReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectFaliureReportFields.ProspectListId, null, ComparisonOperator.Equal, this.ProspectFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectListId, null, ComparisonOperator.Equal, this.ProspectFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectListDetailsFields.ProspectFileId, null, ComparisonOperator.Equal, this.ProspectFileId, "ProspectListDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectListDetailsFields.ProspectFileId, null, ComparisonOperator.Equal, this.ProspectFileId, "ProspectListDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectListDetailsFields.ProspectFileId, null, ComparisonOperator.Equal, this.ProspectFileId, "ProspectListDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectTypeCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectTypeCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectListDetailsFields.ProspectFileId, null, ComparisonOperator.Equal, this.ProspectFileId, "ProspectListDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Organization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ProspectListDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._marketingPrintOrderProspectListMapping);
			collectionsQueue.Enqueue(this._prospectFaliureReport);
			collectionsQueue.Enqueue(this._prospects);
			collectionsQueue.Enqueue(this._addressCollectionViaProspects);
			collectionsQueue.Enqueue(this._marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaProspects);
			collectionsQueue.Enqueue(this._prospectTypeCollectionViaProspects);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._marketingPrintOrderProspectListMapping = (EntityCollection<MarketingPrintOrderProspectListMappingEntity>) collectionsQueue.Dequeue();
			this._prospectFaliureReport = (EntityCollection<ProspectFaliureReportEntity>) collectionsQueue.Dequeue();
			this._prospects = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaProspects = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping = (EntityCollection<MarketingPrintOrderItemEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaProspects = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectTypeCollectionViaProspects = (EntityCollection<ProspectTypeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._marketingPrintOrderProspectListMapping != null)
			{
				return true;
			}
			if (this._prospectFaliureReport != null)
			{
				return true;
			}
			if (this._prospects != null)
			{
				return true;
			}
			if (this._addressCollectionViaProspects != null)
			{
				return true;
			}
			if (this._marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaProspects != null)
			{
				return true;
			}
			if (this._prospectTypeCollectionViaProspects != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderProspectListMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderProspectListMappingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectFaliureReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectFaliureReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectTypeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Organization", _organization);
			toReturn.Add("MarketingPrintOrderProspectListMapping", _marketingPrintOrderProspectListMapping);
			toReturn.Add("ProspectFaliureReport", _prospectFaliureReport);
			toReturn.Add("Prospects", _prospects);
			toReturn.Add("AddressCollectionViaProspects", _addressCollectionViaProspects);
			toReturn.Add("MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping", _marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping);
			toReturn.Add("OrganizationRoleUserCollectionViaProspects", _organizationRoleUserCollectionViaProspects);
			toReturn.Add("ProspectTypeCollectionViaProspects", _prospectTypeCollectionViaProspects);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_marketingPrintOrderProspectListMapping!=null)
			{
				_marketingPrintOrderProspectListMapping.ActiveContext = base.ActiveContext;
			}
			if(_prospectFaliureReport!=null)
			{
				_prospectFaliureReport.ActiveContext = base.ActiveContext;
			}
			if(_prospects!=null)
			{
				_prospects.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaProspects!=null)
			{
				_addressCollectionViaProspects.ActiveContext = base.ActiveContext;
			}
			if(_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping!=null)
			{
				_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaProspects!=null)
			{
				_organizationRoleUserCollectionViaProspects.ActiveContext = base.ActiveContext;
			}
			if(_prospectTypeCollectionViaProspects!=null)
			{
				_prospectTypeCollectionViaProspects.ActiveContext = base.ActiveContext;
			}
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_marketingPrintOrderProspectListMapping = null;
			_prospectFaliureReport = null;
			_prospects = null;
			_addressCollectionViaProspects = null;
			_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping = null;
			_organizationRoleUserCollectionViaProspects = null;
			_prospectTypeCollectionViaProspects = null;
			_organization = null;

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

			_fieldsCustomProperties.Add("ProspectFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FileName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ListName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ListSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ListType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LogList", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FileSize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UploadTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Assigned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", ProspectListDetailsEntity.Relations.OrganizationEntityUsingOrganizationId, true, signalRelatedEntity, "ProspectListDetails", resetFKFields, new int[] { (int)ProspectListDetailsFieldIndex.OrganizationId } );		
			_organization = null;
		}

		/// <summary> setups the sync logic for member _organization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganization(IEntity2 relatedEntity)
		{
			if(_organization!=relatedEntity)
			{
				DesetupSyncOrganization(true, true);
				_organization = (OrganizationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", ProspectListDetailsEntity.Relations.OrganizationEntityUsingOrganizationId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ProspectListDetailsEntity</param>
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
		public  static ProspectListDetailsRelations Relations
		{
			get	{ return new ProspectListDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrderProspectListMapping' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrderProspectListMapping
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingPrintOrderProspectListMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderProspectListMappingEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingPrintOrderProspectListMapping")[0], (int)Falcon.Data.EntityType.ProspectListDetailsEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderProspectListMappingEntity, 0, null, null, null, null, "MarketingPrintOrderProspectListMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectFaliureReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectFaliureReport
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectFaliureReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectFaliureReportEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectFaliureReport")[0], (int)Falcon.Data.EntityType.ProspectListDetailsEntity, (int)Falcon.Data.EntityType.ProspectFaliureReportEntity, 0, null, null, null, null, "ProspectFaliureReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspects
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Prospects")[0], (int)Falcon.Data.EntityType.ProspectListDetailsEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, null, null, "Prospects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectListDetailsEntity.Relations.ProspectsEntityUsingProspectListId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectListDetailsEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaProspects"), null, "AddressCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectListDetailsEntity.Relations.MarketingPrintOrderProspectListMappingEntityUsingProspectFileId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrderProspectListMapping_");
				return new PrefetchPathElement2(new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectListDetailsEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderItemEntity, 0, null, null, GetRelationsForField("MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping"), null, "MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectListDetailsEntity.Relations.ProspectsEntityUsingProspectListId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectListDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaProspects"), null, "OrganizationRoleUserCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectTypeCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectListDetailsEntity.Relations.ProspectsEntityUsingProspectListId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<ProspectTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectListDetailsEntity, (int)Falcon.Data.EntityType.ProspectTypeEntity, 0, null, null, GetRelationsForField("ProspectTypeCollectionViaProspects"), null, "ProspectTypeCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.ProspectListDetailsEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ProspectListDetailsEntity.CustomProperties;}
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
			get { return ProspectListDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The ProspectFileId property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."ProspectFileID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ProspectFileId
		{
			get { return (System.Int64)GetValue((int)ProspectListDetailsFieldIndex.ProspectFileId, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.ProspectFileId, value); }
		}

		/// <summary> The FileName property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."FileName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FileName
		{
			get { return (System.String)GetValue((int)ProspectListDetailsFieldIndex.FileName, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.FileName, value); }
		}

		/// <summary> The DateCreated property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ProspectListDetailsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectListDetailsFieldIndex.DateModified, false); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsActive
		{
			get { return (Nullable<System.Boolean>)GetValue((int)ProspectListDetailsFieldIndex.IsActive, false); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.IsActive, value); }
		}

		/// <summary> The ListName property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."ListName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ListName
		{
			get { return (System.String)GetValue((int)ProspectListDetailsFieldIndex.ListName, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.ListName, value); }
		}

		/// <summary> The ListSource property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."ListSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ListSource
		{
			get { return (System.String)GetValue((int)ProspectListDetailsFieldIndex.ListSource, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.ListSource, value); }
		}

		/// <summary> The ListType property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."ListType"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ListType
		{
			get { return (Nullable<System.Int32>)GetValue((int)ProspectListDetailsFieldIndex.ListType, false); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.ListType, value); }
		}

		/// <summary> The AddedBy property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."AddedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AddedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectListDetailsFieldIndex.AddedBy, false); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.AddedBy, value); }
		}

		/// <summary> The ModifiedBy property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectListDetailsFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The LogList property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."LOG_LIST"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LogList
		{
			get { return (System.String)GetValue((int)ProspectListDetailsFieldIndex.LogList, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.LogList, value); }
		}

		/// <summary> The RoleId property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."RoleId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> RoleId
		{
			get { return (Nullable<System.Int32>)GetValue((int)ProspectListDetailsFieldIndex.RoleId, false); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.RoleId, value); }
		}

		/// <summary> The FileSize property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."FileSize"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FileSize
		{
			get { return (System.String)GetValue((int)ProspectListDetailsFieldIndex.FileSize, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.FileSize, value); }
		}

		/// <summary> The UploadTime property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."UploadTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String UploadTime
		{
			get { return (System.String)GetValue((int)ProspectListDetailsFieldIndex.UploadTime, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.UploadTime, value); }
		}

		/// <summary> The Assigned property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."Assigned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> Assigned
		{
			get { return (Nullable<System.Boolean>)GetValue((int)ProspectListDetailsFieldIndex.Assigned, false); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.Assigned, value); }
		}

		/// <summary> The OrganizationId property of the Entity ProspectListDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectListDetails"."OrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationId
		{
			get { return (System.Int64)GetValue((int)ProspectListDetailsFieldIndex.OrganizationId, true); }
			set	{ SetValue((int)ProspectListDetailsFieldIndex.OrganizationId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderProspectListMappingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderProspectListMappingEntity))]
		public virtual EntityCollection<MarketingPrintOrderProspectListMappingEntity> MarketingPrintOrderProspectListMapping
		{
			get
			{
				if(_marketingPrintOrderProspectListMapping==null)
				{
					_marketingPrintOrderProspectListMapping = new EntityCollection<MarketingPrintOrderProspectListMappingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderProspectListMappingEntityFactory)));
					_marketingPrintOrderProspectListMapping.SetContainingEntityInfo(this, "ProspectListDetails");
				}
				return _marketingPrintOrderProspectListMapping;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectFaliureReportEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectFaliureReportEntity))]
		public virtual EntityCollection<ProspectFaliureReportEntity> ProspectFaliureReport
		{
			get
			{
				if(_prospectFaliureReport==null)
				{
					_prospectFaliureReport = new EntityCollection<ProspectFaliureReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectFaliureReportEntityFactory)));
					_prospectFaliureReport.SetContainingEntityInfo(this, "ProspectListDetails");
				}
				return _prospectFaliureReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> Prospects
		{
			get
			{
				if(_prospects==null)
				{
					_prospects = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospects.SetContainingEntityInfo(this, "ProspectListDetails");
				}
				return _prospects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaProspects
		{
			get
			{
				if(_addressCollectionViaProspects==null)
				{
					_addressCollectionViaProspects = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaProspects.IsReadOnly=true;
				}
				return _addressCollectionViaProspects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderItemEntity))]
		public virtual EntityCollection<MarketingPrintOrderItemEntity> MarketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping
		{
			get
			{
				if(_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping==null)
				{
					_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping = new EntityCollection<MarketingPrintOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderItemEntityFactory)));
					_marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping.IsReadOnly=true;
				}
				return _marketingPrintOrderItemCollectionViaMarketingPrintOrderProspectListMapping;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaProspects
		{
			get
			{
				if(_organizationRoleUserCollectionViaProspects==null)
				{
					_organizationRoleUserCollectionViaProspects = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaProspects.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaProspects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectTypeEntity))]
		public virtual EntityCollection<ProspectTypeEntity> ProspectTypeCollectionViaProspects
		{
			get
			{
				if(_prospectTypeCollectionViaProspects==null)
				{
					_prospectTypeCollectionViaProspects = new EntityCollection<ProspectTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectTypeEntityFactory)));
					_prospectTypeCollectionViaProspects.IsReadOnly=true;
				}
				return _prospectTypeCollectionViaProspects;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationEntity Organization
		{
			get
			{
				return _organization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganization(value);
				}
				else
				{
					if(value==null)
					{
						if(_organization != null)
						{
							_organization.UnsetRelatedEntity(this, "ProspectListDetails");
						}
					}
					else
					{
						if(_organization!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ProspectListDetails");
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
			get { return (int)Falcon.Data.EntityType.ProspectListDetailsEntity; }
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
