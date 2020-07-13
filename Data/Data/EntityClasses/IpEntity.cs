///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:30 AM
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
using HealthYes.Data;
using HealthYes.Data.HelperClasses;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'Ip'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class IpEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<IpcityEntity> _ipcity;
		private EntityCollection<IpcountryEntity> _ipcountry;
		private EntityCollection<IpstateEntity> _ipstate;
		private EntityCollection<LocationDetailsEntity> _locationDetails;
		private EntityCollection<CityEntity> _cityCollectionViaLocationDetails;
		private EntityCollection<CityEntity> _cityCollectionViaIpcity;
		private EntityCollection<CountryEntity> _countryCollectionViaLocationDetails;
		private EntityCollection<CountryEntity> _countryCollectionViaIpcountry;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name Ipcity</summary>
			public static readonly string Ipcity = "Ipcity";
			/// <summary>Member name Ipcountry</summary>
			public static readonly string Ipcountry = "Ipcountry";
			/// <summary>Member name Ipstate</summary>
			public static readonly string Ipstate = "Ipstate";
			/// <summary>Member name LocationDetails</summary>
			public static readonly string LocationDetails = "LocationDetails";
			/// <summary>Member name CityCollectionViaLocationDetails</summary>
			public static readonly string CityCollectionViaLocationDetails = "CityCollectionViaLocationDetails";
			/// <summary>Member name CityCollectionViaIpcity</summary>
			public static readonly string CityCollectionViaIpcity = "CityCollectionViaIpcity";
			/// <summary>Member name CountryCollectionViaLocationDetails</summary>
			public static readonly string CountryCollectionViaLocationDetails = "CountryCollectionViaLocationDetails";
			/// <summary>Member name CountryCollectionViaIpcountry</summary>
			public static readonly string CountryCollectionViaIpcountry = "CountryCollectionViaIpcountry";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static IpEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public IpEntity():base("IpEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public IpEntity(IEntityFields2 fields):base("IpEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this IpEntity</param>
		public IpEntity(IValidator validator):base("IpEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="ipid">PK value for Ip which data should be fetched into this Ip object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public IpEntity(System.Int64 ipid):base("IpEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Ipid = ipid;
		}

		/// <summary> CTor</summary>
		/// <param name="ipid">PK value for Ip which data should be fetched into this Ip object</param>
		/// <param name="validator">The custom validator object for this IpEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public IpEntity(System.Int64 ipid, IValidator validator):base("IpEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Ipid = ipid;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected IpEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_ipcity = (EntityCollection<IpcityEntity>)info.GetValue("_ipcity", typeof(EntityCollection<IpcityEntity>));
				_ipcountry = (EntityCollection<IpcountryEntity>)info.GetValue("_ipcountry", typeof(EntityCollection<IpcountryEntity>));
				_ipstate = (EntityCollection<IpstateEntity>)info.GetValue("_ipstate", typeof(EntityCollection<IpstateEntity>));
				_locationDetails = (EntityCollection<LocationDetailsEntity>)info.GetValue("_locationDetails", typeof(EntityCollection<LocationDetailsEntity>));
				_cityCollectionViaLocationDetails = (EntityCollection<CityEntity>)info.GetValue("_cityCollectionViaLocationDetails", typeof(EntityCollection<CityEntity>));
				_cityCollectionViaIpcity = (EntityCollection<CityEntity>)info.GetValue("_cityCollectionViaIpcity", typeof(EntityCollection<CityEntity>));
				_countryCollectionViaLocationDetails = (EntityCollection<CountryEntity>)info.GetValue("_countryCollectionViaLocationDetails", typeof(EntityCollection<CountryEntity>));
				_countryCollectionViaIpcountry = (EntityCollection<CountryEntity>)info.GetValue("_countryCollectionViaIpcountry", typeof(EntityCollection<CountryEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((IpFieldIndex)fieldIndex)
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

				case "Ipcity":
					this.Ipcity.Add((IpcityEntity)entity);
					break;
				case "Ipcountry":
					this.Ipcountry.Add((IpcountryEntity)entity);
					break;
				case "Ipstate":
					this.Ipstate.Add((IpstateEntity)entity);
					break;
				case "LocationDetails":
					this.LocationDetails.Add((LocationDetailsEntity)entity);
					break;
				case "CityCollectionViaLocationDetails":
					this.CityCollectionViaLocationDetails.IsReadOnly = false;
					this.CityCollectionViaLocationDetails.Add((CityEntity)entity);
					this.CityCollectionViaLocationDetails.IsReadOnly = true;
					break;
				case "CityCollectionViaIpcity":
					this.CityCollectionViaIpcity.IsReadOnly = false;
					this.CityCollectionViaIpcity.Add((CityEntity)entity);
					this.CityCollectionViaIpcity.IsReadOnly = true;
					break;
				case "CountryCollectionViaLocationDetails":
					this.CountryCollectionViaLocationDetails.IsReadOnly = false;
					this.CountryCollectionViaLocationDetails.Add((CountryEntity)entity);
					this.CountryCollectionViaLocationDetails.IsReadOnly = true;
					break;
				case "CountryCollectionViaIpcountry":
					this.CountryCollectionViaIpcountry.IsReadOnly = false;
					this.CountryCollectionViaIpcountry.Add((CountryEntity)entity);
					this.CountryCollectionViaIpcountry.IsReadOnly = true;
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
			return IpEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "Ipcity":
					toReturn.Add(IpEntity.Relations.IpcityEntityUsingIpid);
					break;
				case "Ipcountry":
					toReturn.Add(IpEntity.Relations.IpcountryEntityUsingIpid);
					break;
				case "Ipstate":
					toReturn.Add(IpEntity.Relations.IpstateEntityUsingIpid);
					break;
				case "LocationDetails":
					toReturn.Add(IpEntity.Relations.LocationDetailsEntityUsingIpid);
					break;
				case "CityCollectionViaLocationDetails":
					toReturn.Add(IpEntity.Relations.LocationDetailsEntityUsingIpid, "IpEntity__", "LocationDetails_", JoinHint.None);
					toReturn.Add(LocationDetailsEntity.Relations.CityEntityUsingCityId, "LocationDetails_", string.Empty, JoinHint.None);
					break;
				case "CityCollectionViaIpcity":
					toReturn.Add(IpEntity.Relations.IpcityEntityUsingIpid, "IpEntity__", "Ipcity_", JoinHint.None);
					toReturn.Add(IpcityEntity.Relations.CityEntityUsingCityId, "Ipcity_", string.Empty, JoinHint.None);
					break;
				case "CountryCollectionViaLocationDetails":
					toReturn.Add(IpEntity.Relations.LocationDetailsEntityUsingIpid, "IpEntity__", "LocationDetails_", JoinHint.None);
					toReturn.Add(LocationDetailsEntity.Relations.CountryEntityUsingCountryId, "LocationDetails_", string.Empty, JoinHint.None);
					break;
				case "CountryCollectionViaIpcountry":
					toReturn.Add(IpEntity.Relations.IpcountryEntityUsingIpid, "IpEntity__", "Ipcountry_", JoinHint.None);
					toReturn.Add(IpcountryEntity.Relations.CountryEntityUsingCountryId, "Ipcountry_", string.Empty, JoinHint.None);
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

				case "Ipcity":
					this.Ipcity.Add((IpcityEntity)relatedEntity);
					break;
				case "Ipcountry":
					this.Ipcountry.Add((IpcountryEntity)relatedEntity);
					break;
				case "Ipstate":
					this.Ipstate.Add((IpstateEntity)relatedEntity);
					break;
				case "LocationDetails":
					this.LocationDetails.Add((LocationDetailsEntity)relatedEntity);
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

				case "Ipcity":
					base.PerformRelatedEntityRemoval(this.Ipcity, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Ipcountry":
					base.PerformRelatedEntityRemoval(this.Ipcountry, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Ipstate":
					base.PerformRelatedEntityRemoval(this.Ipstate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "LocationDetails":
					base.PerformRelatedEntityRemoval(this.LocationDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Ipcity);
			toReturn.Add(this.Ipcountry);
			toReturn.Add(this.Ipstate);
			toReturn.Add(this.LocationDetails);

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
				info.AddValue("_ipcity", ((_ipcity!=null) && (_ipcity.Count>0) && !this.MarkedForDeletion)?_ipcity:null);
				info.AddValue("_ipcountry", ((_ipcountry!=null) && (_ipcountry.Count>0) && !this.MarkedForDeletion)?_ipcountry:null);
				info.AddValue("_ipstate", ((_ipstate!=null) && (_ipstate.Count>0) && !this.MarkedForDeletion)?_ipstate:null);
				info.AddValue("_locationDetails", ((_locationDetails!=null) && (_locationDetails.Count>0) && !this.MarkedForDeletion)?_locationDetails:null);
				info.AddValue("_cityCollectionViaLocationDetails", ((_cityCollectionViaLocationDetails!=null) && (_cityCollectionViaLocationDetails.Count>0) && !this.MarkedForDeletion)?_cityCollectionViaLocationDetails:null);
				info.AddValue("_cityCollectionViaIpcity", ((_cityCollectionViaIpcity!=null) && (_cityCollectionViaIpcity.Count>0) && !this.MarkedForDeletion)?_cityCollectionViaIpcity:null);
				info.AddValue("_countryCollectionViaLocationDetails", ((_countryCollectionViaLocationDetails!=null) && (_countryCollectionViaLocationDetails.Count>0) && !this.MarkedForDeletion)?_countryCollectionViaLocationDetails:null);
				info.AddValue("_countryCollectionViaIpcountry", ((_countryCollectionViaIpcountry!=null) && (_countryCollectionViaIpcountry.Count>0) && !this.MarkedForDeletion)?_countryCollectionViaIpcountry:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(IpFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(IpFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new IpRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Ipcity' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIpcity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IpcityFields.Ipid, null, ComparisonOperator.Equal, this.Ipid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Ipcountry' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIpcountry()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IpcountryFields.Ipid, null, ComparisonOperator.Equal, this.Ipid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Ipstate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIpstate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IpstateFields.Ipid, null, ComparisonOperator.Equal, this.Ipid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LocationDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLocationDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LocationDetailsFields.Ipid, null, ComparisonOperator.Equal, this.Ipid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'City' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCityCollectionViaLocationDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CityCollectionViaLocationDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IpFields.Ipid, null, ComparisonOperator.Equal, this.Ipid, "IpEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'City' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCityCollectionViaIpcity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CityCollectionViaIpcity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IpFields.Ipid, null, ComparisonOperator.Equal, this.Ipid, "IpEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Country' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryCollectionViaLocationDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CountryCollectionViaLocationDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IpFields.Ipid, null, ComparisonOperator.Equal, this.Ipid, "IpEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Country' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryCollectionViaIpcountry()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CountryCollectionViaIpcountry"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IpFields.Ipid, null, ComparisonOperator.Equal, this.Ipid, "IpEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.IpEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(IpEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._ipcity);
			collectionsQueue.Enqueue(this._ipcountry);
			collectionsQueue.Enqueue(this._ipstate);
			collectionsQueue.Enqueue(this._locationDetails);
			collectionsQueue.Enqueue(this._cityCollectionViaLocationDetails);
			collectionsQueue.Enqueue(this._cityCollectionViaIpcity);
			collectionsQueue.Enqueue(this._countryCollectionViaLocationDetails);
			collectionsQueue.Enqueue(this._countryCollectionViaIpcountry);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._ipcity = (EntityCollection<IpcityEntity>) collectionsQueue.Dequeue();
			this._ipcountry = (EntityCollection<IpcountryEntity>) collectionsQueue.Dequeue();
			this._ipstate = (EntityCollection<IpstateEntity>) collectionsQueue.Dequeue();
			this._locationDetails = (EntityCollection<LocationDetailsEntity>) collectionsQueue.Dequeue();
			this._cityCollectionViaLocationDetails = (EntityCollection<CityEntity>) collectionsQueue.Dequeue();
			this._cityCollectionViaIpcity = (EntityCollection<CityEntity>) collectionsQueue.Dequeue();
			this._countryCollectionViaLocationDetails = (EntityCollection<CountryEntity>) collectionsQueue.Dequeue();
			this._countryCollectionViaIpcountry = (EntityCollection<CountryEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._ipcity != null)
			{
				return true;
			}
			if (this._ipcountry != null)
			{
				return true;
			}
			if (this._ipstate != null)
			{
				return true;
			}
			if (this._locationDetails != null)
			{
				return true;
			}
			if (this._cityCollectionViaLocationDetails != null)
			{
				return true;
			}
			if (this._cityCollectionViaIpcity != null)
			{
				return true;
			}
			if (this._countryCollectionViaLocationDetails != null)
			{
				return true;
			}
			if (this._countryCollectionViaIpcountry != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IpcityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpcityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IpcountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpcountryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IpstateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpstateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LocationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("Ipcity", _ipcity);
			toReturn.Add("Ipcountry", _ipcountry);
			toReturn.Add("Ipstate", _ipstate);
			toReturn.Add("LocationDetails", _locationDetails);
			toReturn.Add("CityCollectionViaLocationDetails", _cityCollectionViaLocationDetails);
			toReturn.Add("CityCollectionViaIpcity", _cityCollectionViaIpcity);
			toReturn.Add("CountryCollectionViaLocationDetails", _countryCollectionViaLocationDetails);
			toReturn.Add("CountryCollectionViaIpcountry", _countryCollectionViaIpcountry);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_ipcity!=null)
			{
				_ipcity.ActiveContext = base.ActiveContext;
			}
			if(_ipcountry!=null)
			{
				_ipcountry.ActiveContext = base.ActiveContext;
			}
			if(_ipstate!=null)
			{
				_ipstate.ActiveContext = base.ActiveContext;
			}
			if(_locationDetails!=null)
			{
				_locationDetails.ActiveContext = base.ActiveContext;
			}
			if(_cityCollectionViaLocationDetails!=null)
			{
				_cityCollectionViaLocationDetails.ActiveContext = base.ActiveContext;
			}
			if(_cityCollectionViaIpcity!=null)
			{
				_cityCollectionViaIpcity.ActiveContext = base.ActiveContext;
			}
			if(_countryCollectionViaLocationDetails!=null)
			{
				_countryCollectionViaLocationDetails.ActiveContext = base.ActiveContext;
			}
			if(_countryCollectionViaIpcountry!=null)
			{
				_countryCollectionViaIpcountry.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_ipcity = null;
			_ipcountry = null;
			_ipstate = null;
			_locationDetails = null;
			_cityCollectionViaLocationDetails = null;
			_cityCollectionViaIpcity = null;
			_countryCollectionViaLocationDetails = null;
			_countryCollectionViaIpcountry = null;


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

			_fieldsCustomProperties.Add("Ipid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ipaddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this IpEntity</param>
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
		public  static IpRelations Relations
		{
			get	{ return new IpRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Ipcity' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIpcity
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<IpcityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpcityEntityFactory))),
					(IEntityRelation)GetRelationsForField("Ipcity")[0], (int)HealthYes.Data.EntityType.IpEntity, (int)HealthYes.Data.EntityType.IpcityEntity, 0, null, null, null, null, "Ipcity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Ipcountry' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIpcountry
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<IpcountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpcountryEntityFactory))),
					(IEntityRelation)GetRelationsForField("Ipcountry")[0], (int)HealthYes.Data.EntityType.IpEntity, (int)HealthYes.Data.EntityType.IpcountryEntity, 0, null, null, null, null, "Ipcountry", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Ipstate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIpstate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<IpstateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpstateEntityFactory))),
					(IEntityRelation)GetRelationsForField("Ipstate")[0], (int)HealthYes.Data.EntityType.IpEntity, (int)HealthYes.Data.EntityType.IpstateEntity, 0, null, null, null, null, "Ipstate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'LocationDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLocationDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<LocationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("LocationDetails")[0], (int)HealthYes.Data.EntityType.IpEntity, (int)HealthYes.Data.EntityType.LocationDetailsEntity, 0, null, null, null, null, "LocationDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'City' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCityCollectionViaLocationDetails
		{
			get
			{
				IEntityRelation intermediateRelation = IpEntity.Relations.LocationDetailsEntityUsingIpid;
				intermediateRelation.SetAliases(string.Empty, "LocationDetails_");
				return new PrefetchPathElement2(new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.IpEntity, (int)HealthYes.Data.EntityType.CityEntity, 0, null, null, GetRelationsForField("CityCollectionViaLocationDetails"), null, "CityCollectionViaLocationDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'City' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCityCollectionViaIpcity
		{
			get
			{
				IEntityRelation intermediateRelation = IpEntity.Relations.IpcityEntityUsingIpid;
				intermediateRelation.SetAliases(string.Empty, "Ipcity_");
				return new PrefetchPathElement2(new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.IpEntity, (int)HealthYes.Data.EntityType.CityEntity, 0, null, null, GetRelationsForField("CityCollectionViaIpcity"), null, "CityCollectionViaIpcity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Country' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryCollectionViaLocationDetails
		{
			get
			{
				IEntityRelation intermediateRelation = IpEntity.Relations.LocationDetailsEntityUsingIpid;
				intermediateRelation.SetAliases(string.Empty, "LocationDetails_");
				return new PrefetchPathElement2(new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.IpEntity, (int)HealthYes.Data.EntityType.CountryEntity, 0, null, null, GetRelationsForField("CountryCollectionViaLocationDetails"), null, "CountryCollectionViaLocationDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Country' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryCollectionViaIpcountry
		{
			get
			{
				IEntityRelation intermediateRelation = IpEntity.Relations.IpcountryEntityUsingIpid;
				intermediateRelation.SetAliases(string.Empty, "Ipcountry_");
				return new PrefetchPathElement2(new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.IpEntity, (int)HealthYes.Data.EntityType.CountryEntity, 0, null, null, GetRelationsForField("CountryCollectionViaIpcountry"), null, "CountryCollectionViaIpcountry", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return IpEntity.CustomProperties;}
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
			get { return IpEntity.FieldsCustomProperties;}
		}

		/// <summary> The Ipid property of the Entity Ip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIP"."IPID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Ipid
		{
			get { return (System.Int64)GetValue((int)IpFieldIndex.Ipid, true); }
			set	{ SetValue((int)IpFieldIndex.Ipid, value); }
		}

		/// <summary> The Ipaddress property of the Entity Ip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIP"."IPAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Ipaddress
		{
			get { return (System.String)GetValue((int)IpFieldIndex.Ipaddress, true); }
			set	{ SetValue((int)IpFieldIndex.Ipaddress, value); }
		}

		/// <summary> The Description property of the Entity Ip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIP"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)IpFieldIndex.Description, true); }
			set	{ SetValue((int)IpFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity Ip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIP"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)IpFieldIndex.DateCreated, true); }
			set	{ SetValue((int)IpFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Ip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIP"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)IpFieldIndex.DateModified, true); }
			set	{ SetValue((int)IpFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity Ip<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblIP"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)IpFieldIndex.IsActive, true); }
			set	{ SetValue((int)IpFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IpcityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IpcityEntity))]
		public virtual EntityCollection<IpcityEntity> Ipcity
		{
			get
			{
				if(_ipcity==null)
				{
					_ipcity = new EntityCollection<IpcityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpcityEntityFactory)));
					_ipcity.SetContainingEntityInfo(this, "Ip");
				}
				return _ipcity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IpcountryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IpcountryEntity))]
		public virtual EntityCollection<IpcountryEntity> Ipcountry
		{
			get
			{
				if(_ipcountry==null)
				{
					_ipcountry = new EntityCollection<IpcountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpcountryEntityFactory)));
					_ipcountry.SetContainingEntityInfo(this, "Ip");
				}
				return _ipcountry;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IpstateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IpstateEntity))]
		public virtual EntityCollection<IpstateEntity> Ipstate
		{
			get
			{
				if(_ipstate==null)
				{
					_ipstate = new EntityCollection<IpstateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IpstateEntityFactory)));
					_ipstate.SetContainingEntityInfo(this, "Ip");
				}
				return _ipstate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LocationDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LocationDetailsEntity))]
		public virtual EntityCollection<LocationDetailsEntity> LocationDetails
		{
			get
			{
				if(_locationDetails==null)
				{
					_locationDetails = new EntityCollection<LocationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationDetailsEntityFactory)));
					_locationDetails.SetContainingEntityInfo(this, "Ip");
				}
				return _locationDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CityEntity))]
		public virtual EntityCollection<CityEntity> CityCollectionViaLocationDetails
		{
			get
			{
				if(_cityCollectionViaLocationDetails==null)
				{
					_cityCollectionViaLocationDetails = new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory)));
					_cityCollectionViaLocationDetails.IsReadOnly=true;
				}
				return _cityCollectionViaLocationDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CityEntity))]
		public virtual EntityCollection<CityEntity> CityCollectionViaIpcity
		{
			get
			{
				if(_cityCollectionViaIpcity==null)
				{
					_cityCollectionViaIpcity = new EntityCollection<CityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory)));
					_cityCollectionViaIpcity.IsReadOnly=true;
				}
				return _cityCollectionViaIpcity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CountryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CountryEntity))]
		public virtual EntityCollection<CountryEntity> CountryCollectionViaLocationDetails
		{
			get
			{
				if(_countryCollectionViaLocationDetails==null)
				{
					_countryCollectionViaLocationDetails = new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory)));
					_countryCollectionViaLocationDetails.IsReadOnly=true;
				}
				return _countryCollectionViaLocationDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CountryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CountryEntity))]
		public virtual EntityCollection<CountryEntity> CountryCollectionViaIpcountry
		{
			get
			{
				if(_countryCollectionViaIpcountry==null)
				{
					_countryCollectionViaIpcountry = new EntityCollection<CountryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory)));
					_countryCollectionViaIpcountry.IsReadOnly=true;
				}
				return _countryCollectionViaIpcountry;
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.IpEntity; }
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
