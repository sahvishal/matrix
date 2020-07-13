///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:31 AM
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
	/// Entity class which represents the entity 'PrintVendorPvuser'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PrintVendorPvuserEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private PrintVendorEntity _printVendor;
		private PvuserEntity _pvuser;
		private RoleEntity _role;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name PrintVendor</summary>
			public static readonly string PrintVendor = "PrintVendor";
			/// <summary>Member name Pvuser</summary>
			public static readonly string Pvuser = "Pvuser";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PrintVendorPvuserEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PrintVendorPvuserEntity():base("PrintVendorPvuserEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PrintVendorPvuserEntity(IEntityFields2 fields):base("PrintVendorPvuserEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PrintVendorPvuserEntity</param>
		public PrintVendorPvuserEntity(IValidator validator):base("PrintVendorPvuserEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="printVendorPvuserId">PK value for PrintVendorPvuser which data should be fetched into this PrintVendorPvuser object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PrintVendorPvuserEntity(System.Int64 printVendorPvuserId):base("PrintVendorPvuserEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PrintVendorPvuserId = printVendorPvuserId;
		}

		/// <summary> CTor</summary>
		/// <param name="printVendorPvuserId">PK value for PrintVendorPvuser which data should be fetched into this PrintVendorPvuser object</param>
		/// <param name="validator">The custom validator object for this PrintVendorPvuserEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PrintVendorPvuserEntity(System.Int64 printVendorPvuserId, IValidator validator):base("PrintVendorPvuserEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PrintVendorPvuserId = printVendorPvuserId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PrintVendorPvuserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_printVendor = (PrintVendorEntity)info.GetValue("_printVendor", typeof(PrintVendorEntity));
				if(_printVendor!=null)
				{
					_printVendor.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_pvuser = (PvuserEntity)info.GetValue("_pvuser", typeof(PvuserEntity));
				if(_pvuser!=null)
				{
					_pvuser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_role = (RoleEntity)info.GetValue("_role", typeof(RoleEntity));
				if(_role!=null)
				{
					_role.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PrintVendorPvuserFieldIndex)fieldIndex)
			{
				case PrintVendorPvuserFieldIndex.PrintVendorId:
					DesetupSyncPrintVendor(true, false);
					break;
				case PrintVendorPvuserFieldIndex.PvuserId:
					DesetupSyncPvuser(true, false);
					break;
				case PrintVendorPvuserFieldIndex.RoleId:
					DesetupSyncRole(true, false);
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
				case "PrintVendor":
					this.PrintVendor = (PrintVendorEntity)entity;
					break;
				case "Pvuser":
					this.Pvuser = (PvuserEntity)entity;
					break;
				case "Role":
					this.Role = (RoleEntity)entity;
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
			return PrintVendorPvuserEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "PrintVendor":
					toReturn.Add(PrintVendorPvuserEntity.Relations.PrintVendorEntityUsingPrintVendorId);
					break;
				case "Pvuser":
					toReturn.Add(PrintVendorPvuserEntity.Relations.PvuserEntityUsingPvuserId);
					break;
				case "Role":
					toReturn.Add(PrintVendorPvuserEntity.Relations.RoleEntityUsingRoleId);
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
				case "PrintVendor":
					SetupSyncPrintVendor(relatedEntity);
					break;
				case "Pvuser":
					SetupSyncPvuser(relatedEntity);
					break;
				case "Role":
					SetupSyncRole(relatedEntity);
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
				case "PrintVendor":
					DesetupSyncPrintVendor(false, true);
					break;
				case "Pvuser":
					DesetupSyncPvuser(false, true);
					break;
				case "Role":
					DesetupSyncRole(false, true);
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
			if(_printVendor!=null)
			{
				toReturn.Add(_printVendor);
			}
			if(_pvuser!=null)
			{
				toReturn.Add(_pvuser);
			}
			if(_role!=null)
			{
				toReturn.Add(_role);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();


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


				info.AddValue("_printVendor", (!this.MarkedForDeletion?_printVendor:null));
				info.AddValue("_pvuser", (!this.MarkedForDeletion?_pvuser:null));
				info.AddValue("_role", (!this.MarkedForDeletion?_role:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PrintVendorPvuserFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PrintVendorPvuserFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PrintVendorPvuserRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PrintVendor' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPrintVendor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PrintVendorFields.PrintVendorId, null, ComparisonOperator.Equal, this.PrintVendorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Pvuser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPvuser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PvuserFields.PvuserId, null, ComparisonOperator.Equal, this.PvuserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Role' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.PrintVendorPvuserEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PrintVendorPvuserEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{


			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("PrintVendor", _printVendor);
			toReturn.Add("Pvuser", _pvuser);
			toReturn.Add("Role", _role);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_printVendor!=null)
			{
				_printVendor.ActiveContext = base.ActiveContext;
			}
			if(_pvuser!=null)
			{
				_pvuser.ActiveContext = base.ActiveContext;
			}
			if(_role!=null)
			{
				_role.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_printVendor = null;
			_pvuser = null;
			_role = null;

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

			_fieldsCustomProperties.Add("PrintVendorPvuserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintVendorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PvuserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _printVendor</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPrintVendor(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _printVendor, new PropertyChangedEventHandler( OnPrintVendorPropertyChanged ), "PrintVendor", PrintVendorPvuserEntity.Relations.PrintVendorEntityUsingPrintVendorId, true, signalRelatedEntity, "PrintVendorPvuser", resetFKFields, new int[] { (int)PrintVendorPvuserFieldIndex.PrintVendorId } );		
			_printVendor = null;
		}

		/// <summary> setups the sync logic for member _printVendor</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPrintVendor(IEntity2 relatedEntity)
		{
			if(_printVendor!=relatedEntity)
			{
				DesetupSyncPrintVendor(true, true);
				_printVendor = (PrintVendorEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _printVendor, new PropertyChangedEventHandler( OnPrintVendorPropertyChanged ), "PrintVendor", PrintVendorPvuserEntity.Relations.PrintVendorEntityUsingPrintVendorId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPrintVendorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _pvuser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPvuser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _pvuser, new PropertyChangedEventHandler( OnPvuserPropertyChanged ), "Pvuser", PrintVendorPvuserEntity.Relations.PvuserEntityUsingPvuserId, true, signalRelatedEntity, "PrintVendorPvuser", resetFKFields, new int[] { (int)PrintVendorPvuserFieldIndex.PvuserId } );		
			_pvuser = null;
		}

		/// <summary> setups the sync logic for member _pvuser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPvuser(IEntity2 relatedEntity)
		{
			if(_pvuser!=relatedEntity)
			{
				DesetupSyncPvuser(true, true);
				_pvuser = (PvuserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _pvuser, new PropertyChangedEventHandler( OnPvuserPropertyChanged ), "Pvuser", PrintVendorPvuserEntity.Relations.PvuserEntityUsingPvuserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPvuserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _role</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRole(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", PrintVendorPvuserEntity.Relations.RoleEntityUsingRoleId, true, signalRelatedEntity, "PrintVendorPvuser", resetFKFields, new int[] { (int)PrintVendorPvuserFieldIndex.RoleId } );		
			_role = null;
		}

		/// <summary> setups the sync logic for member _role</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRole(IEntity2 relatedEntity)
		{
			if(_role!=relatedEntity)
			{
				DesetupSyncRole(true, true);
				_role = (RoleEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", PrintVendorPvuserEntity.Relations.RoleEntityUsingRoleId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRolePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PrintVendorPvuserEntity</param>
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
		public  static PrintVendorPvuserRelations Relations
		{
			get	{ return new PrintVendorPvuserRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PrintVendor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPrintVendor
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PrintVendorEntityFactory))),
					(IEntityRelation)GetRelationsForField("PrintVendor")[0], (int)HealthYes.Data.EntityType.PrintVendorPvuserEntity, (int)HealthYes.Data.EntityType.PrintVendorEntity, 0, null, null, null, null, "PrintVendor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Pvuser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPvuser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PvuserEntityFactory))),
					(IEntityRelation)GetRelationsForField("Pvuser")[0], (int)HealthYes.Data.EntityType.PrintVendorPvuserEntity, (int)HealthYes.Data.EntityType.PvuserEntity, 0, null, null, null, null, "Pvuser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRole
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),
					(IEntityRelation)GetRelationsForField("Role")[0], (int)HealthYes.Data.EntityType.PrintVendorPvuserEntity, (int)HealthYes.Data.EntityType.RoleEntity, 0, null, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PrintVendorPvuserEntity.CustomProperties;}
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
			get { return PrintVendorPvuserEntity.FieldsCustomProperties;}
		}

		/// <summary> The PrintVendorPvuserId property of the Entity PrintVendorPvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPrintVendorPVUser"."PrintVendorPVUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PrintVendorPvuserId
		{
			get { return (System.Int64)GetValue((int)PrintVendorPvuserFieldIndex.PrintVendorPvuserId, true); }
			set	{ SetValue((int)PrintVendorPvuserFieldIndex.PrintVendorPvuserId, value); }
		}

		/// <summary> The PrintVendorId property of the Entity PrintVendorPvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPrintVendorPVUser"."PrintVendorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PrintVendorId
		{
			get { return (System.Int64)GetValue((int)PrintVendorPvuserFieldIndex.PrintVendorId, true); }
			set	{ SetValue((int)PrintVendorPvuserFieldIndex.PrintVendorId, value); }
		}

		/// <summary> The PvuserId property of the Entity PrintVendorPvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPrintVendorPVUser"."PVUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PvuserId
		{
			get { return (System.Int64)GetValue((int)PrintVendorPvuserFieldIndex.PvuserId, true); }
			set	{ SetValue((int)PrintVendorPvuserFieldIndex.PvuserId, value); }
		}

		/// <summary> The RoleId property of the Entity PrintVendorPvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPrintVendorPVUser"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 RoleId
		{
			get { return (System.Int64)GetValue((int)PrintVendorPvuserFieldIndex.RoleId, true); }
			set	{ SetValue((int)PrintVendorPvuserFieldIndex.RoleId, value); }
		}

		/// <summary> The IsDefault property of the Entity PrintVendorPvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPrintVendorPVUser"."IsDefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefault
		{
			get { return (System.Boolean)GetValue((int)PrintVendorPvuserFieldIndex.IsDefault, true); }
			set	{ SetValue((int)PrintVendorPvuserFieldIndex.IsDefault, value); }
		}

		/// <summary> The IsActive property of the Entity PrintVendorPvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPrintVendorPVUser"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PrintVendorPvuserFieldIndex.IsActive, true); }
			set	{ SetValue((int)PrintVendorPvuserFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity PrintVendorPvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPrintVendorPVUser"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PrintVendorPvuserFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PrintVendorPvuserFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity PrintVendorPvuser<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPrintVendorPVUser"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)PrintVendorPvuserFieldIndex.DateModified, true); }
			set	{ SetValue((int)PrintVendorPvuserFieldIndex.DateModified, value); }
		}



		/// <summary> Gets / sets related entity of type 'PrintVendorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PrintVendorEntity PrintVendor
		{
			get
			{
				return _printVendor;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPrintVendor(value);
				}
				else
				{
					if(value==null)
					{
						if(_printVendor != null)
						{
							_printVendor.UnsetRelatedEntity(this, "PrintVendorPvuser");
						}
					}
					else
					{
						if(_printVendor!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PrintVendorPvuser");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PvuserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PvuserEntity Pvuser
		{
			get
			{
				return _pvuser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPvuser(value);
				}
				else
				{
					if(value==null)
					{
						if(_pvuser != null)
						{
							_pvuser.UnsetRelatedEntity(this, "PrintVendorPvuser");
						}
					}
					else
					{
						if(_pvuser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PrintVendorPvuser");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual RoleEntity Role
		{
			get
			{
				return _role;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncRole(value);
				}
				else
				{
					if(value==null)
					{
						if(_role != null)
						{
							_role.UnsetRelatedEntity(this, "PrintVendorPvuser");
						}
					}
					else
					{
						if(_role!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PrintVendorPvuser");
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.PrintVendorPvuserEntity; }
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
