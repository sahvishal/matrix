///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
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
	/// Entity class which represents the entity 'AfaffiliateCampaignMarketingMaterial'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AfaffiliateCampaignMarketingMaterialEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AfimpressionLogEntity> _afimpressionLog;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomer;
		private EntityCollection<AfcampaignEntity> _afcampaignCollectionViaAfimpressionLog;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaProspectCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaProspectCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaProspectCustomer;
		private AfcampaignEntity _afcampaign;
		private AfmarketingMaterialEntity _afmarketingMaterial;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Afcampaign</summary>
			public static readonly string Afcampaign = "Afcampaign";
			/// <summary>Member name AfmarketingMaterial</summary>
			public static readonly string AfmarketingMaterial = "AfmarketingMaterial";
			/// <summary>Member name AfimpressionLog</summary>
			public static readonly string AfimpressionLog = "AfimpressionLog";
			/// <summary>Member name ProspectCustomer</summary>
			public static readonly string ProspectCustomer = "ProspectCustomer";
			/// <summary>Member name AfcampaignCollectionViaAfimpressionLog</summary>
			public static readonly string AfcampaignCollectionViaAfimpressionLog = "AfcampaignCollectionViaAfimpressionLog";
			/// <summary>Member name CustomerProfileCollectionViaProspectCustomer</summary>
			public static readonly string CustomerProfileCollectionViaProspectCustomer = "CustomerProfileCollectionViaProspectCustomer";
			/// <summary>Member name LookupCollectionViaProspectCustomer</summary>
			public static readonly string LookupCollectionViaProspectCustomer = "LookupCollectionViaProspectCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaProspectCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaProspectCustomer = "OrganizationRoleUserCollectionViaProspectCustomer";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AfaffiliateCampaignMarketingMaterialEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AfaffiliateCampaignMarketingMaterialEntity():base("AfaffiliateCampaignMarketingMaterialEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AfaffiliateCampaignMarketingMaterialEntity(IEntityFields2 fields):base("AfaffiliateCampaignMarketingMaterialEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AfaffiliateCampaignMarketingMaterialEntity</param>
		public AfaffiliateCampaignMarketingMaterialEntity(IValidator validator):base("AfaffiliateCampaignMarketingMaterialEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="affiliateCampaignMarketingMaterialId">PK value for AfaffiliateCampaignMarketingMaterial which data should be fetched into this AfaffiliateCampaignMarketingMaterial object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfaffiliateCampaignMarketingMaterialEntity(System.Int64 affiliateCampaignMarketingMaterialId):base("AfaffiliateCampaignMarketingMaterialEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AffiliateCampaignMarketingMaterialId = affiliateCampaignMarketingMaterialId;
		}

		/// <summary> CTor</summary>
		/// <param name="affiliateCampaignMarketingMaterialId">PK value for AfaffiliateCampaignMarketingMaterial which data should be fetched into this AfaffiliateCampaignMarketingMaterial object</param>
		/// <param name="validator">The custom validator object for this AfaffiliateCampaignMarketingMaterialEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AfaffiliateCampaignMarketingMaterialEntity(System.Int64 affiliateCampaignMarketingMaterialId, IValidator validator):base("AfaffiliateCampaignMarketingMaterialEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AffiliateCampaignMarketingMaterialId = affiliateCampaignMarketingMaterialId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AfaffiliateCampaignMarketingMaterialEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_afimpressionLog = (EntityCollection<AfimpressionLogEntity>)info.GetValue("_afimpressionLog", typeof(EntityCollection<AfimpressionLogEntity>));
				_prospectCustomer = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomer", typeof(EntityCollection<ProspectCustomerEntity>));
				_afcampaignCollectionViaAfimpressionLog = (EntityCollection<AfcampaignEntity>)info.GetValue("_afcampaignCollectionViaAfimpressionLog", typeof(EntityCollection<AfcampaignEntity>));
				_customerProfileCollectionViaProspectCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaProspectCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_lookupCollectionViaProspectCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaProspectCustomer", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaProspectCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaProspectCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_afcampaign = (AfcampaignEntity)info.GetValue("_afcampaign", typeof(AfcampaignEntity));
				if(_afcampaign!=null)
				{
					_afcampaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_afmarketingMaterial = (AfmarketingMaterialEntity)info.GetValue("_afmarketingMaterial", typeof(AfmarketingMaterialEntity));
				if(_afmarketingMaterial!=null)
				{
					_afmarketingMaterial.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AfaffiliateCampaignMarketingMaterialFieldIndex)fieldIndex)
			{
				case AfaffiliateCampaignMarketingMaterialFieldIndex.MarketingMaterialId:
					DesetupSyncAfmarketingMaterial(true, false);
					break;
				case AfaffiliateCampaignMarketingMaterialFieldIndex.CampaignId:
					DesetupSyncAfcampaign(true, false);
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
				case "Afcampaign":
					this.Afcampaign = (AfcampaignEntity)entity;
					break;
				case "AfmarketingMaterial":
					this.AfmarketingMaterial = (AfmarketingMaterialEntity)entity;
					break;
				case "AfimpressionLog":
					this.AfimpressionLog.Add((AfimpressionLogEntity)entity);
					break;
				case "ProspectCustomer":
					this.ProspectCustomer.Add((ProspectCustomerEntity)entity);
					break;
				case "AfcampaignCollectionViaAfimpressionLog":
					this.AfcampaignCollectionViaAfimpressionLog.IsReadOnly = false;
					this.AfcampaignCollectionViaAfimpressionLog.Add((AfcampaignEntity)entity);
					this.AfcampaignCollectionViaAfimpressionLog.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaProspectCustomer":
					this.CustomerProfileCollectionViaProspectCustomer.IsReadOnly = false;
					this.CustomerProfileCollectionViaProspectCustomer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaProspectCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaProspectCustomer":
					this.LookupCollectionViaProspectCustomer.IsReadOnly = false;
					this.LookupCollectionViaProspectCustomer.Add((LookupEntity)entity);
					this.LookupCollectionViaProspectCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaProspectCustomer":
					this.OrganizationRoleUserCollectionViaProspectCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaProspectCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaProspectCustomer.IsReadOnly = true;
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
			return AfaffiliateCampaignMarketingMaterialEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Afcampaign":
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.AfcampaignEntityUsingCampaignId);
					break;
				case "AfmarketingMaterial":
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId);
					break;
				case "AfimpressionLog":
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.AfimpressionLogEntityUsingAffiliateCampaignMarketingMaterialId);
					break;
				case "ProspectCustomer":
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.ProspectCustomerEntityUsingAffiliateCampaignMarketingMaterialId);
					break;
				case "AfcampaignCollectionViaAfimpressionLog":
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.AfimpressionLogEntityUsingAffiliateCampaignMarketingMaterialId, "AfaffiliateCampaignMarketingMaterialEntity__", "AfimpressionLog_", JoinHint.None);
					toReturn.Add(AfimpressionLogEntity.Relations.AfcampaignEntityUsingAffiliateCampaignMarketingMaterialId, "AfimpressionLog_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaProspectCustomer":
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.ProspectCustomerEntityUsingAffiliateCampaignMarketingMaterialId, "AfaffiliateCampaignMarketingMaterialEntity__", "ProspectCustomer_", JoinHint.None);
					toReturn.Add(ProspectCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "ProspectCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaProspectCustomer":
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.ProspectCustomerEntityUsingAffiliateCampaignMarketingMaterialId, "AfaffiliateCampaignMarketingMaterialEntity__", "ProspectCustomer_", JoinHint.None);
					toReturn.Add(ProspectCustomerEntity.Relations.LookupEntityUsingSource, "ProspectCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaProspectCustomer":
					toReturn.Add(AfaffiliateCampaignMarketingMaterialEntity.Relations.ProspectCustomerEntityUsingAffiliateCampaignMarketingMaterialId, "AfaffiliateCampaignMarketingMaterialEntity__", "ProspectCustomer_", JoinHint.None);
					toReturn.Add(ProspectCustomerEntity.Relations.OrganizationRoleUserEntityUsingContactedBy, "ProspectCustomer_", string.Empty, JoinHint.None);
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
				case "Afcampaign":
					SetupSyncAfcampaign(relatedEntity);
					break;
				case "AfmarketingMaterial":
					SetupSyncAfmarketingMaterial(relatedEntity);
					break;
				case "AfimpressionLog":
					this.AfimpressionLog.Add((AfimpressionLogEntity)relatedEntity);
					break;
				case "ProspectCustomer":
					this.ProspectCustomer.Add((ProspectCustomerEntity)relatedEntity);
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
				case "Afcampaign":
					DesetupSyncAfcampaign(false, true);
					break;
				case "AfmarketingMaterial":
					DesetupSyncAfmarketingMaterial(false, true);
					break;
				case "AfimpressionLog":
					base.PerformRelatedEntityRemoval(this.AfimpressionLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectCustomer":
					base.PerformRelatedEntityRemoval(this.ProspectCustomer, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_afcampaign!=null)
			{
				toReturn.Add(_afcampaign);
			}
			if(_afmarketingMaterial!=null)
			{
				toReturn.Add(_afmarketingMaterial);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AfimpressionLog);
			toReturn.Add(this.ProspectCustomer);

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
				info.AddValue("_afimpressionLog", ((_afimpressionLog!=null) && (_afimpressionLog.Count>0) && !this.MarkedForDeletion)?_afimpressionLog:null);
				info.AddValue("_prospectCustomer", ((_prospectCustomer!=null) && (_prospectCustomer.Count>0) && !this.MarkedForDeletion)?_prospectCustomer:null);
				info.AddValue("_afcampaignCollectionViaAfimpressionLog", ((_afcampaignCollectionViaAfimpressionLog!=null) && (_afcampaignCollectionViaAfimpressionLog.Count>0) && !this.MarkedForDeletion)?_afcampaignCollectionViaAfimpressionLog:null);
				info.AddValue("_customerProfileCollectionViaProspectCustomer", ((_customerProfileCollectionViaProspectCustomer!=null) && (_customerProfileCollectionViaProspectCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaProspectCustomer:null);
				info.AddValue("_lookupCollectionViaProspectCustomer", ((_lookupCollectionViaProspectCustomer!=null) && (_lookupCollectionViaProspectCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaProspectCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaProspectCustomer", ((_organizationRoleUserCollectionViaProspectCustomer!=null) && (_organizationRoleUserCollectionViaProspectCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaProspectCustomer:null);
				info.AddValue("_afcampaign", (!this.MarkedForDeletion?_afcampaign:null));
				info.AddValue("_afmarketingMaterial", (!this.MarkedForDeletion?_afmarketingMaterial:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// MarketingMaterialId , CampaignId .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCMarketingMaterialIdCampaignId()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)AfaffiliateCampaignMarketingMaterialFieldIndex.MarketingMaterialId], null, ComparisonOperator.Equal));
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)AfaffiliateCampaignMarketingMaterialFieldIndex.CampaignId], null, ComparisonOperator.Equal)); 
			return filter;
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AfaffiliateCampaignMarketingMaterialFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AfaffiliateCampaignMarketingMaterialFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AfaffiliateCampaignMarketingMaterialRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfimpressionLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfimpressionLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfimpressionLogFields.AffiliateCampaignMarketingMaterialId, null, ComparisonOperator.Equal, this.AffiliateCampaignMarketingMaterialId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.AffiliateCampaignMarketingMaterialId, null, ComparisonOperator.Equal, this.AffiliateCampaignMarketingMaterialId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignCollectionViaAfimpressionLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfcampaignCollectionViaAfimpressionLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignMarketingMaterialFields.AffiliateCampaignMarketingMaterialId, null, ComparisonOperator.Equal, this.AffiliateCampaignMarketingMaterialId, "AfaffiliateCampaignMarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaProspectCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaProspectCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignMarketingMaterialFields.AffiliateCampaignMarketingMaterialId, null, ComparisonOperator.Equal, this.AffiliateCampaignMarketingMaterialId, "AfaffiliateCampaignMarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaProspectCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaProspectCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignMarketingMaterialFields.AffiliateCampaignMarketingMaterialId, null, ComparisonOperator.Equal, this.AffiliateCampaignMarketingMaterialId, "AfaffiliateCampaignMarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaProspectCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaProspectCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignMarketingMaterialFields.AffiliateCampaignMarketingMaterialId, null, ComparisonOperator.Equal, this.AffiliateCampaignMarketingMaterialId, "AfaffiliateCampaignMarketingMaterialEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Afcampaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignFields.CampaignId, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AfmarketingMaterial' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfmarketingMaterial()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfmarketingMaterialFields.MarketingMaterialId, null, ComparisonOperator.Equal, this.MarketingMaterialId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._afimpressionLog);
			collectionsQueue.Enqueue(this._prospectCustomer);
			collectionsQueue.Enqueue(this._afcampaignCollectionViaAfimpressionLog);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaProspectCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaProspectCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaProspectCustomer);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._afimpressionLog = (EntityCollection<AfimpressionLogEntity>) collectionsQueue.Dequeue();
			this._prospectCustomer = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
			this._afcampaignCollectionViaAfimpressionLog = (EntityCollection<AfcampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaProspectCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaProspectCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaProspectCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._afimpressionLog != null)
			{
				return true;
			}
			if (this._prospectCustomer != null)
			{
				return true;
			}
			if (this._afcampaignCollectionViaAfimpressionLog != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaProspectCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaProspectCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaProspectCustomer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfimpressionLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
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
			toReturn.Add("Afcampaign", _afcampaign);
			toReturn.Add("AfmarketingMaterial", _afmarketingMaterial);
			toReturn.Add("AfimpressionLog", _afimpressionLog);
			toReturn.Add("ProspectCustomer", _prospectCustomer);
			toReturn.Add("AfcampaignCollectionViaAfimpressionLog", _afcampaignCollectionViaAfimpressionLog);
			toReturn.Add("CustomerProfileCollectionViaProspectCustomer", _customerProfileCollectionViaProspectCustomer);
			toReturn.Add("LookupCollectionViaProspectCustomer", _lookupCollectionViaProspectCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaProspectCustomer", _organizationRoleUserCollectionViaProspectCustomer);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_afimpressionLog!=null)
			{
				_afimpressionLog.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomer!=null)
			{
				_prospectCustomer.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignCollectionViaAfimpressionLog!=null)
			{
				_afcampaignCollectionViaAfimpressionLog.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaProspectCustomer!=null)
			{
				_customerProfileCollectionViaProspectCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaProspectCustomer!=null)
			{
				_lookupCollectionViaProspectCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaProspectCustomer!=null)
			{
				_organizationRoleUserCollectionViaProspectCustomer.ActiveContext = base.ActiveContext;
			}
			if(_afcampaign!=null)
			{
				_afcampaign.ActiveContext = base.ActiveContext;
			}
			if(_afmarketingMaterial!=null)
			{
				_afmarketingMaterial.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_afimpressionLog = null;
			_prospectCustomer = null;
			_afcampaignCollectionViaAfimpressionLog = null;
			_customerProfileCollectionViaProspectCustomer = null;
			_lookupCollectionViaProspectCustomer = null;
			_organizationRoleUserCollectionViaProspectCustomer = null;
			_afcampaign = null;
			_afmarketingMaterial = null;

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

			_fieldsCustomProperties.Add("AffiliateCampaignMarketingMaterialId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingMaterialId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ImpressionCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClickCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsInbound", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afcampaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfcampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afcampaign, new PropertyChangedEventHandler( OnAfcampaignPropertyChanged ), "Afcampaign", AfaffiliateCampaignMarketingMaterialEntity.Relations.AfcampaignEntityUsingCampaignId, true, signalRelatedEntity, "AfaffiliateCampaignMarketingMaterial", resetFKFields, new int[] { (int)AfaffiliateCampaignMarketingMaterialFieldIndex.CampaignId } );		
			_afcampaign = null;
		}

		/// <summary> setups the sync logic for member _afcampaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfcampaign(IEntity2 relatedEntity)
		{
			if(_afcampaign!=relatedEntity)
			{
				DesetupSyncAfcampaign(true, true);
				_afcampaign = (AfcampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afcampaign, new PropertyChangedEventHandler( OnAfcampaignPropertyChanged ), "Afcampaign", AfaffiliateCampaignMarketingMaterialEntity.Relations.AfcampaignEntityUsingCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfcampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _afmarketingMaterial</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfmarketingMaterial(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afmarketingMaterial, new PropertyChangedEventHandler( OnAfmarketingMaterialPropertyChanged ), "AfmarketingMaterial", AfaffiliateCampaignMarketingMaterialEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, true, signalRelatedEntity, "AfaffiliateCampaignMarketingMaterial", resetFKFields, new int[] { (int)AfaffiliateCampaignMarketingMaterialFieldIndex.MarketingMaterialId } );		
			_afmarketingMaterial = null;
		}

		/// <summary> setups the sync logic for member _afmarketingMaterial</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfmarketingMaterial(IEntity2 relatedEntity)
		{
			if(_afmarketingMaterial!=relatedEntity)
			{
				DesetupSyncAfmarketingMaterial(true, true);
				_afmarketingMaterial = (AfmarketingMaterialEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afmarketingMaterial, new PropertyChangedEventHandler( OnAfmarketingMaterialPropertyChanged ), "AfmarketingMaterial", AfaffiliateCampaignMarketingMaterialEntity.Relations.AfmarketingMaterialEntityUsingMarketingMaterialId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfmarketingMaterialPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AfaffiliateCampaignMarketingMaterialEntity</param>
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
		public  static AfaffiliateCampaignMarketingMaterialRelations Relations
		{
			get	{ return new AfaffiliateCampaignMarketingMaterialRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfimpressionLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfimpressionLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfimpressionLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfimpressionLog")[0], (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, (int)Falcon.Data.EntityType.AfimpressionLogEntity, 0, null, null, null, null, "AfimpressionLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectCustomer")[0], (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, null, null, "ProspectCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignCollectionViaAfimpressionLog
		{
			get
			{
				IEntityRelation intermediateRelation = AfaffiliateCampaignMarketingMaterialEntity.Relations.AfimpressionLogEntityUsingAffiliateCampaignMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "AfimpressionLog_");
				return new PrefetchPathElement2(new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, GetRelationsForField("AfcampaignCollectionViaAfimpressionLog"), null, "AfcampaignCollectionViaAfimpressionLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaProspectCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AfaffiliateCampaignMarketingMaterialEntity.Relations.ProspectCustomerEntityUsingAffiliateCampaignMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "ProspectCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaProspectCustomer"), null, "CustomerProfileCollectionViaProspectCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaProspectCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AfaffiliateCampaignMarketingMaterialEntity.Relations.ProspectCustomerEntityUsingAffiliateCampaignMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "ProspectCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaProspectCustomer"), null, "LookupCollectionViaProspectCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaProspectCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AfaffiliateCampaignMarketingMaterialEntity.Relations.ProspectCustomerEntityUsingAffiliateCampaignMarketingMaterialId;
				intermediateRelation.SetAliases(string.Empty, "ProspectCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaProspectCustomer"), null, "OrganizationRoleUserCollectionViaProspectCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Afcampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Afcampaign")[0], (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, (int)Falcon.Data.EntityType.AfcampaignEntity, 0, null, null, null, null, "Afcampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfmarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfmarketingMaterial
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfmarketingMaterialEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfmarketingMaterial")[0], (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, (int)Falcon.Data.EntityType.AfmarketingMaterialEntity, 0, null, null, null, null, "AfmarketingMaterial", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AfaffiliateCampaignMarketingMaterialEntity.CustomProperties;}
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
			get { return AfaffiliateCampaignMarketingMaterialEntity.FieldsCustomProperties;}
		}

		/// <summary> The AffiliateCampaignMarketingMaterialId property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."AffiliateCampaignMarketingMaterialID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 AffiliateCampaignMarketingMaterialId
		{
			get { return (System.Int64)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.AffiliateCampaignMarketingMaterialId, true); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.AffiliateCampaignMarketingMaterialId, value); }
		}

		/// <summary> The MarketingMaterialId property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."MarketingMaterialID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MarketingMaterialId
		{
			get { return (System.Int64)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.MarketingMaterialId, true); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.MarketingMaterialId, value); }
		}

		/// <summary> The CampaignId property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."CampaignID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CampaignId
		{
			get { return (System.Int64)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.CampaignId, true); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.CampaignId, value); }
		}

		/// <summary> The ImpressionCount property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."ImpressionCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ImpressionCount
		{
			get { return (System.Int64)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.ImpressionCount, true); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.ImpressionCount, value); }
		}

		/// <summary> The ClickCount property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."ClickCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ClickCount
		{
			get { return (System.Int64)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.ClickCount, true); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.ClickCount, value); }
		}

		/// <summary> The CreatedDate property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.CreatedDate, value); }
		}

		/// <summary> The LastModifiedDate property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."LastModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.LastModifiedDate, false); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.LastModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.IsActive, true); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.IsActive, value); }
		}

		/// <summary> The IsInbound property of the Entity AfaffiliateCampaignMarketingMaterial<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "tblAFAffiliateCampaignMarketingMaterial"."IsInbound"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsInbound
		{
			get { return (System.Boolean)GetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.IsInbound, true); }
			set	{ SetValue((int)AfaffiliateCampaignMarketingMaterialFieldIndex.IsInbound, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfimpressionLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfimpressionLogEntity))]
		public virtual EntityCollection<AfimpressionLogEntity> AfimpressionLog
		{
			get
			{
				if(_afimpressionLog==null)
				{
					_afimpressionLog = new EntityCollection<AfimpressionLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfimpressionLogEntityFactory)));
					_afimpressionLog.SetContainingEntityInfo(this, "AfaffiliateCampaignMarketingMaterial");
				}
				return _afimpressionLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomer
		{
			get
			{
				if(_prospectCustomer==null)
				{
					_prospectCustomer = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomer.SetContainingEntityInfo(this, "AfaffiliateCampaignMarketingMaterial");
				}
				return _prospectCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignEntity))]
		public virtual EntityCollection<AfcampaignEntity> AfcampaignCollectionViaAfimpressionLog
		{
			get
			{
				if(_afcampaignCollectionViaAfimpressionLog==null)
				{
					_afcampaignCollectionViaAfimpressionLog = new EntityCollection<AfcampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignEntityFactory)));
					_afcampaignCollectionViaAfimpressionLog.IsReadOnly=true;
				}
				return _afcampaignCollectionViaAfimpressionLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaProspectCustomer
		{
			get
			{
				if(_customerProfileCollectionViaProspectCustomer==null)
				{
					_customerProfileCollectionViaProspectCustomer = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaProspectCustomer.IsReadOnly=true;
				}
				return _customerProfileCollectionViaProspectCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaProspectCustomer
		{
			get
			{
				if(_lookupCollectionViaProspectCustomer==null)
				{
					_lookupCollectionViaProspectCustomer = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaProspectCustomer.IsReadOnly=true;
				}
				return _lookupCollectionViaProspectCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaProspectCustomer
		{
			get
			{
				if(_organizationRoleUserCollectionViaProspectCustomer==null)
				{
					_organizationRoleUserCollectionViaProspectCustomer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaProspectCustomer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaProspectCustomer;
			}
		}

		/// <summary> Gets / sets related entity of type 'AfcampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfcampaignEntity Afcampaign
		{
			get
			{
				return _afcampaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfcampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_afcampaign != null)
						{
							_afcampaign.UnsetRelatedEntity(this, "AfaffiliateCampaignMarketingMaterial");
						}
					}
					else
					{
						if(_afcampaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AfaffiliateCampaignMarketingMaterial");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'AfmarketingMaterialEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfmarketingMaterialEntity AfmarketingMaterial
		{
			get
			{
				return _afmarketingMaterial;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfmarketingMaterial(value);
				}
				else
				{
					if(value==null)
					{
						if(_afmarketingMaterial != null)
						{
							_afmarketingMaterial.UnsetRelatedEntity(this, "AfaffiliateCampaignMarketingMaterial");
						}
					}
					else
					{
						if(_afmarketingMaterial!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "AfaffiliateCampaignMarketingMaterial");
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
			get { return (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity; }
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
