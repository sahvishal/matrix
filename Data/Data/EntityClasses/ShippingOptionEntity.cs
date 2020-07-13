///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'ShippingOption'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ShippingOptionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<HospitalPartnerShippingOptionEntity> _hospitalPartnerShippingOption;
		private EntityCollection<ProductShippingOptionEntity> _productShippingOption;
		private EntityCollection<ShippingDetailEntity> _shippingDetail;
		private EntityCollection<ShippingOptionOrderItemEntity> _shippingOptionOrderItem;
		private EntityCollection<ShippingOptionSourceCodeDiscountEntity> _shippingOptionSourceCodeDiscount;
		private EntityCollection<AddressEntity> _addressCollectionViaShippingDetail;
		private EntityCollection<CouponsEntity> _couponsCollectionViaShippingOptionSourceCodeDiscount;
		private EntityCollection<HospitalPartnerEntity> _hospitalPartnerCollectionViaHospitalPartnerShippingOption;
		private EntityCollection<OrderItemEntity> _orderItemCollectionViaShippingOptionOrderItem;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaShippingDetail;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaShippingDetail_;
		private EntityCollection<ProductEntity> _productCollectionViaProductShippingOption;
		private CarrierEntity _carrier;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Carrier</summary>
			public static readonly string Carrier = "Carrier";
			/// <summary>Member name HospitalPartnerShippingOption</summary>
			public static readonly string HospitalPartnerShippingOption = "HospitalPartnerShippingOption";
			/// <summary>Member name ProductShippingOption</summary>
			public static readonly string ProductShippingOption = "ProductShippingOption";
			/// <summary>Member name ShippingDetail</summary>
			public static readonly string ShippingDetail = "ShippingDetail";
			/// <summary>Member name ShippingOptionOrderItem</summary>
			public static readonly string ShippingOptionOrderItem = "ShippingOptionOrderItem";
			/// <summary>Member name ShippingOptionSourceCodeDiscount</summary>
			public static readonly string ShippingOptionSourceCodeDiscount = "ShippingOptionSourceCodeDiscount";
			/// <summary>Member name AddressCollectionViaShippingDetail</summary>
			public static readonly string AddressCollectionViaShippingDetail = "AddressCollectionViaShippingDetail";
			/// <summary>Member name CouponsCollectionViaShippingOptionSourceCodeDiscount</summary>
			public static readonly string CouponsCollectionViaShippingOptionSourceCodeDiscount = "CouponsCollectionViaShippingOptionSourceCodeDiscount";
			/// <summary>Member name HospitalPartnerCollectionViaHospitalPartnerShippingOption</summary>
			public static readonly string HospitalPartnerCollectionViaHospitalPartnerShippingOption = "HospitalPartnerCollectionViaHospitalPartnerShippingOption";
			/// <summary>Member name OrderItemCollectionViaShippingOptionOrderItem</summary>
			public static readonly string OrderItemCollectionViaShippingOptionOrderItem = "OrderItemCollectionViaShippingOptionOrderItem";
			/// <summary>Member name OrganizationRoleUserCollectionViaShippingDetail</summary>
			public static readonly string OrganizationRoleUserCollectionViaShippingDetail = "OrganizationRoleUserCollectionViaShippingDetail";
			/// <summary>Member name OrganizationRoleUserCollectionViaShippingDetail_</summary>
			public static readonly string OrganizationRoleUserCollectionViaShippingDetail_ = "OrganizationRoleUserCollectionViaShippingDetail_";
			/// <summary>Member name ProductCollectionViaProductShippingOption</summary>
			public static readonly string ProductCollectionViaProductShippingOption = "ProductCollectionViaProductShippingOption";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ShippingOptionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ShippingOptionEntity():base("ShippingOptionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ShippingOptionEntity(IEntityFields2 fields):base("ShippingOptionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ShippingOptionEntity</param>
		public ShippingOptionEntity(IValidator validator):base("ShippingOptionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="shippingOptionId">PK value for ShippingOption which data should be fetched into this ShippingOption object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ShippingOptionEntity(System.Int64 shippingOptionId):base("ShippingOptionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ShippingOptionId = shippingOptionId;
		}

		/// <summary> CTor</summary>
		/// <param name="shippingOptionId">PK value for ShippingOption which data should be fetched into this ShippingOption object</param>
		/// <param name="validator">The custom validator object for this ShippingOptionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ShippingOptionEntity(System.Int64 shippingOptionId, IValidator validator):base("ShippingOptionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ShippingOptionId = shippingOptionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ShippingOptionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_hospitalPartnerShippingOption = (EntityCollection<HospitalPartnerShippingOptionEntity>)info.GetValue("_hospitalPartnerShippingOption", typeof(EntityCollection<HospitalPartnerShippingOptionEntity>));
				_productShippingOption = (EntityCollection<ProductShippingOptionEntity>)info.GetValue("_productShippingOption", typeof(EntityCollection<ProductShippingOptionEntity>));
				_shippingDetail = (EntityCollection<ShippingDetailEntity>)info.GetValue("_shippingDetail", typeof(EntityCollection<ShippingDetailEntity>));
				_shippingOptionOrderItem = (EntityCollection<ShippingOptionOrderItemEntity>)info.GetValue("_shippingOptionOrderItem", typeof(EntityCollection<ShippingOptionOrderItemEntity>));
				_shippingOptionSourceCodeDiscount = (EntityCollection<ShippingOptionSourceCodeDiscountEntity>)info.GetValue("_shippingOptionSourceCodeDiscount", typeof(EntityCollection<ShippingOptionSourceCodeDiscountEntity>));
				_addressCollectionViaShippingDetail = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaShippingDetail", typeof(EntityCollection<AddressEntity>));
				_couponsCollectionViaShippingOptionSourceCodeDiscount = (EntityCollection<CouponsEntity>)info.GetValue("_couponsCollectionViaShippingOptionSourceCodeDiscount", typeof(EntityCollection<CouponsEntity>));
				_hospitalPartnerCollectionViaHospitalPartnerShippingOption = (EntityCollection<HospitalPartnerEntity>)info.GetValue("_hospitalPartnerCollectionViaHospitalPartnerShippingOption", typeof(EntityCollection<HospitalPartnerEntity>));
				_orderItemCollectionViaShippingOptionOrderItem = (EntityCollection<OrderItemEntity>)info.GetValue("_orderItemCollectionViaShippingOptionOrderItem", typeof(EntityCollection<OrderItemEntity>));
				_organizationRoleUserCollectionViaShippingDetail = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaShippingDetail", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaShippingDetail_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaShippingDetail_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_productCollectionViaProductShippingOption = (EntityCollection<ProductEntity>)info.GetValue("_productCollectionViaProductShippingOption", typeof(EntityCollection<ProductEntity>));
				_carrier = (CarrierEntity)info.GetValue("_carrier", typeof(CarrierEntity));
				if(_carrier!=null)
				{
					_carrier.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ShippingOptionFieldIndex)fieldIndex)
			{
				case ShippingOptionFieldIndex.CarrierId:
					DesetupSyncCarrier(true, false);
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
				case "Carrier":
					this.Carrier = (CarrierEntity)entity;
					break;
				case "HospitalPartnerShippingOption":
					this.HospitalPartnerShippingOption.Add((HospitalPartnerShippingOptionEntity)entity);
					break;
				case "ProductShippingOption":
					this.ProductShippingOption.Add((ProductShippingOptionEntity)entity);
					break;
				case "ShippingDetail":
					this.ShippingDetail.Add((ShippingDetailEntity)entity);
					break;
				case "ShippingOptionOrderItem":
					this.ShippingOptionOrderItem.Add((ShippingOptionOrderItemEntity)entity);
					break;
				case "ShippingOptionSourceCodeDiscount":
					this.ShippingOptionSourceCodeDiscount.Add((ShippingOptionSourceCodeDiscountEntity)entity);
					break;
				case "AddressCollectionViaShippingDetail":
					this.AddressCollectionViaShippingDetail.IsReadOnly = false;
					this.AddressCollectionViaShippingDetail.Add((AddressEntity)entity);
					this.AddressCollectionViaShippingDetail.IsReadOnly = true;
					break;
				case "CouponsCollectionViaShippingOptionSourceCodeDiscount":
					this.CouponsCollectionViaShippingOptionSourceCodeDiscount.IsReadOnly = false;
					this.CouponsCollectionViaShippingOptionSourceCodeDiscount.Add((CouponsEntity)entity);
					this.CouponsCollectionViaShippingOptionSourceCodeDiscount.IsReadOnly = true;
					break;
				case "HospitalPartnerCollectionViaHospitalPartnerShippingOption":
					this.HospitalPartnerCollectionViaHospitalPartnerShippingOption.IsReadOnly = false;
					this.HospitalPartnerCollectionViaHospitalPartnerShippingOption.Add((HospitalPartnerEntity)entity);
					this.HospitalPartnerCollectionViaHospitalPartnerShippingOption.IsReadOnly = true;
					break;
				case "OrderItemCollectionViaShippingOptionOrderItem":
					this.OrderItemCollectionViaShippingOptionOrderItem.IsReadOnly = false;
					this.OrderItemCollectionViaShippingOptionOrderItem.Add((OrderItemEntity)entity);
					this.OrderItemCollectionViaShippingOptionOrderItem.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaShippingDetail":
					this.OrganizationRoleUserCollectionViaShippingDetail.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaShippingDetail.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaShippingDetail.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaShippingDetail_":
					this.OrganizationRoleUserCollectionViaShippingDetail_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaShippingDetail_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaShippingDetail_.IsReadOnly = true;
					break;
				case "ProductCollectionViaProductShippingOption":
					this.ProductCollectionViaProductShippingOption.IsReadOnly = false;
					this.ProductCollectionViaProductShippingOption.Add((ProductEntity)entity);
					this.ProductCollectionViaProductShippingOption.IsReadOnly = true;
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
			return ShippingOptionEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Carrier":
					toReturn.Add(ShippingOptionEntity.Relations.CarrierEntityUsingCarrierId);
					break;
				case "HospitalPartnerShippingOption":
					toReturn.Add(ShippingOptionEntity.Relations.HospitalPartnerShippingOptionEntityUsingShippingOptionId);
					break;
				case "ProductShippingOption":
					toReturn.Add(ShippingOptionEntity.Relations.ProductShippingOptionEntityUsingShippingOptionId);
					break;
				case "ShippingDetail":
					toReturn.Add(ShippingOptionEntity.Relations.ShippingDetailEntityUsingShippingOptionId);
					break;
				case "ShippingOptionOrderItem":
					toReturn.Add(ShippingOptionEntity.Relations.ShippingOptionOrderItemEntityUsingShippingOptionId);
					break;
				case "ShippingOptionSourceCodeDiscount":
					toReturn.Add(ShippingOptionEntity.Relations.ShippingOptionSourceCodeDiscountEntityUsingShippingOptionId);
					break;
				case "AddressCollectionViaShippingDetail":
					toReturn.Add(ShippingOptionEntity.Relations.ShippingDetailEntityUsingShippingOptionId, "ShippingOptionEntity__", "ShippingDetail_", JoinHint.None);
					toReturn.Add(ShippingDetailEntity.Relations.AddressEntityUsingShippingAddressId, "ShippingDetail_", string.Empty, JoinHint.None);
					break;
				case "CouponsCollectionViaShippingOptionSourceCodeDiscount":
					toReturn.Add(ShippingOptionEntity.Relations.ShippingOptionSourceCodeDiscountEntityUsingShippingOptionId, "ShippingOptionEntity__", "ShippingOptionSourceCodeDiscount_", JoinHint.None);
					toReturn.Add(ShippingOptionSourceCodeDiscountEntity.Relations.CouponsEntityUsingSourceCodeId, "ShippingOptionSourceCodeDiscount_", string.Empty, JoinHint.None);
					break;
				case "HospitalPartnerCollectionViaHospitalPartnerShippingOption":
					toReturn.Add(ShippingOptionEntity.Relations.HospitalPartnerShippingOptionEntityUsingShippingOptionId, "ShippingOptionEntity__", "HospitalPartnerShippingOption_", JoinHint.None);
					toReturn.Add(HospitalPartnerShippingOptionEntity.Relations.HospitalPartnerEntityUsingHospitalPartnerId, "HospitalPartnerShippingOption_", string.Empty, JoinHint.None);
					break;
				case "OrderItemCollectionViaShippingOptionOrderItem":
					toReturn.Add(ShippingOptionEntity.Relations.ShippingOptionOrderItemEntityUsingShippingOptionId, "ShippingOptionEntity__", "ShippingOptionOrderItem_", JoinHint.None);
					toReturn.Add(ShippingOptionOrderItemEntity.Relations.OrderItemEntityUsingOrderItemId, "ShippingOptionOrderItem_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaShippingDetail":
					toReturn.Add(ShippingOptionEntity.Relations.ShippingDetailEntityUsingShippingOptionId, "ShippingOptionEntity__", "ShippingDetail_", JoinHint.None);
					toReturn.Add(ShippingDetailEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ShippingDetail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaShippingDetail_":
					toReturn.Add(ShippingOptionEntity.Relations.ShippingDetailEntityUsingShippingOptionId, "ShippingOptionEntity__", "ShippingDetail_", JoinHint.None);
					toReturn.Add(ShippingDetailEntity.Relations.OrganizationRoleUserEntityUsingShippedByOrgRoleUserId, "ShippingDetail_", string.Empty, JoinHint.None);
					break;
				case "ProductCollectionViaProductShippingOption":
					toReturn.Add(ShippingOptionEntity.Relations.ProductShippingOptionEntityUsingShippingOptionId, "ShippingOptionEntity__", "ProductShippingOption_", JoinHint.None);
					toReturn.Add(ProductShippingOptionEntity.Relations.ProductEntityUsingProductId, "ProductShippingOption_", string.Empty, JoinHint.None);
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
				case "Carrier":
					SetupSyncCarrier(relatedEntity);
					break;
				case "HospitalPartnerShippingOption":
					this.HospitalPartnerShippingOption.Add((HospitalPartnerShippingOptionEntity)relatedEntity);
					break;
				case "ProductShippingOption":
					this.ProductShippingOption.Add((ProductShippingOptionEntity)relatedEntity);
					break;
				case "ShippingDetail":
					this.ShippingDetail.Add((ShippingDetailEntity)relatedEntity);
					break;
				case "ShippingOptionOrderItem":
					this.ShippingOptionOrderItem.Add((ShippingOptionOrderItemEntity)relatedEntity);
					break;
				case "ShippingOptionSourceCodeDiscount":
					this.ShippingOptionSourceCodeDiscount.Add((ShippingOptionSourceCodeDiscountEntity)relatedEntity);
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
				case "Carrier":
					DesetupSyncCarrier(false, true);
					break;
				case "HospitalPartnerShippingOption":
					base.PerformRelatedEntityRemoval(this.HospitalPartnerShippingOption, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProductShippingOption":
					base.PerformRelatedEntityRemoval(this.ProductShippingOption, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ShippingDetail":
					base.PerformRelatedEntityRemoval(this.ShippingDetail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ShippingOptionOrderItem":
					base.PerformRelatedEntityRemoval(this.ShippingOptionOrderItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ShippingOptionSourceCodeDiscount":
					base.PerformRelatedEntityRemoval(this.ShippingOptionSourceCodeDiscount, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_carrier!=null)
			{
				toReturn.Add(_carrier);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.HospitalPartnerShippingOption);
			toReturn.Add(this.ProductShippingOption);
			toReturn.Add(this.ShippingDetail);
			toReturn.Add(this.ShippingOptionOrderItem);
			toReturn.Add(this.ShippingOptionSourceCodeDiscount);

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
				info.AddValue("_hospitalPartnerShippingOption", ((_hospitalPartnerShippingOption!=null) && (_hospitalPartnerShippingOption.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerShippingOption:null);
				info.AddValue("_productShippingOption", ((_productShippingOption!=null) && (_productShippingOption.Count>0) && !this.MarkedForDeletion)?_productShippingOption:null);
				info.AddValue("_shippingDetail", ((_shippingDetail!=null) && (_shippingDetail.Count>0) && !this.MarkedForDeletion)?_shippingDetail:null);
				info.AddValue("_shippingOptionOrderItem", ((_shippingOptionOrderItem!=null) && (_shippingOptionOrderItem.Count>0) && !this.MarkedForDeletion)?_shippingOptionOrderItem:null);
				info.AddValue("_shippingOptionSourceCodeDiscount", ((_shippingOptionSourceCodeDiscount!=null) && (_shippingOptionSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_shippingOptionSourceCodeDiscount:null);
				info.AddValue("_addressCollectionViaShippingDetail", ((_addressCollectionViaShippingDetail!=null) && (_addressCollectionViaShippingDetail.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaShippingDetail:null);
				info.AddValue("_couponsCollectionViaShippingOptionSourceCodeDiscount", ((_couponsCollectionViaShippingOptionSourceCodeDiscount!=null) && (_couponsCollectionViaShippingOptionSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_couponsCollectionViaShippingOptionSourceCodeDiscount:null);
				info.AddValue("_hospitalPartnerCollectionViaHospitalPartnerShippingOption", ((_hospitalPartnerCollectionViaHospitalPartnerShippingOption!=null) && (_hospitalPartnerCollectionViaHospitalPartnerShippingOption.Count>0) && !this.MarkedForDeletion)?_hospitalPartnerCollectionViaHospitalPartnerShippingOption:null);
				info.AddValue("_orderItemCollectionViaShippingOptionOrderItem", ((_orderItemCollectionViaShippingOptionOrderItem!=null) && (_orderItemCollectionViaShippingOptionOrderItem.Count>0) && !this.MarkedForDeletion)?_orderItemCollectionViaShippingOptionOrderItem:null);
				info.AddValue("_organizationRoleUserCollectionViaShippingDetail", ((_organizationRoleUserCollectionViaShippingDetail!=null) && (_organizationRoleUserCollectionViaShippingDetail.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaShippingDetail:null);
				info.AddValue("_organizationRoleUserCollectionViaShippingDetail_", ((_organizationRoleUserCollectionViaShippingDetail_!=null) && (_organizationRoleUserCollectionViaShippingDetail_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaShippingDetail_:null);
				info.AddValue("_productCollectionViaProductShippingOption", ((_productCollectionViaProductShippingOption!=null) && (_productCollectionViaProductShippingOption.Count>0) && !this.MarkedForDeletion)?_productCollectionViaProductShippingOption:null);
				info.AddValue("_carrier", (!this.MarkedForDeletion?_carrier:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ShippingOptionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ShippingOptionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ShippingOptionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartnerShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerShippingOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProductShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductShippingOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProductShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingDetailFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOptionOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionOrderItemFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOptionSourceCodeDiscount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionSourceCodeDiscountFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaShippingDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaShippingDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId, "ShippingOptionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponsCollectionViaShippingOptionSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CouponsCollectionViaShippingOptionSourceCodeDiscount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId, "ShippingOptionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartner' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerCollectionViaHospitalPartnerShippingOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HospitalPartnerCollectionViaHospitalPartnerShippingOption"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId, "ShippingOptionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItemCollectionViaShippingOptionOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderItemCollectionViaShippingOptionOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId, "ShippingOptionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaShippingDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaShippingDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId, "ShippingOptionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaShippingDetail_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaShippingDetail_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId, "ShippingOptionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Product' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProductCollectionViaProductShippingOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProductCollectionViaProductShippingOption"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingOptionFields.ShippingOptionId, null, ComparisonOperator.Equal, this.ShippingOptionId, "ShippingOptionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Carrier' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCarrier()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CarrierFields.CarrierId, null, ComparisonOperator.Equal, this.CarrierId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ShippingOptionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._hospitalPartnerShippingOption);
			collectionsQueue.Enqueue(this._productShippingOption);
			collectionsQueue.Enqueue(this._shippingDetail);
			collectionsQueue.Enqueue(this._shippingOptionOrderItem);
			collectionsQueue.Enqueue(this._shippingOptionSourceCodeDiscount);
			collectionsQueue.Enqueue(this._addressCollectionViaShippingDetail);
			collectionsQueue.Enqueue(this._couponsCollectionViaShippingOptionSourceCodeDiscount);
			collectionsQueue.Enqueue(this._hospitalPartnerCollectionViaHospitalPartnerShippingOption);
			collectionsQueue.Enqueue(this._orderItemCollectionViaShippingOptionOrderItem);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaShippingDetail);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaShippingDetail_);
			collectionsQueue.Enqueue(this._productCollectionViaProductShippingOption);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._hospitalPartnerShippingOption = (EntityCollection<HospitalPartnerShippingOptionEntity>) collectionsQueue.Dequeue();
			this._productShippingOption = (EntityCollection<ProductShippingOptionEntity>) collectionsQueue.Dequeue();
			this._shippingDetail = (EntityCollection<ShippingDetailEntity>) collectionsQueue.Dequeue();
			this._shippingOptionOrderItem = (EntityCollection<ShippingOptionOrderItemEntity>) collectionsQueue.Dequeue();
			this._shippingOptionSourceCodeDiscount = (EntityCollection<ShippingOptionSourceCodeDiscountEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaShippingDetail = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._couponsCollectionViaShippingOptionSourceCodeDiscount = (EntityCollection<CouponsEntity>) collectionsQueue.Dequeue();
			this._hospitalPartnerCollectionViaHospitalPartnerShippingOption = (EntityCollection<HospitalPartnerEntity>) collectionsQueue.Dequeue();
			this._orderItemCollectionViaShippingOptionOrderItem = (EntityCollection<OrderItemEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaShippingDetail = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaShippingDetail_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._productCollectionViaProductShippingOption = (EntityCollection<ProductEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._hospitalPartnerShippingOption != null)
			{
				return true;
			}
			if (this._productShippingOption != null)
			{
				return true;
			}
			if (this._shippingDetail != null)
			{
				return true;
			}
			if (this._shippingOptionOrderItem != null)
			{
				return true;
			}
			if (this._shippingOptionSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._addressCollectionViaShippingDetail != null)
			{
				return true;
			}
			if (this._couponsCollectionViaShippingOptionSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._hospitalPartnerCollectionViaHospitalPartnerShippingOption != null)
			{
				return true;
			}
			if (this._orderItemCollectionViaShippingOptionOrderItem != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaShippingDetail != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaShippingDetail_ != null)
			{
				return true;
			}
			if (this._productCollectionViaProductShippingOption != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerShippingOptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductShippingOptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingOptionOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingOptionSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionSourceCodeDiscountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Carrier", _carrier);
			toReturn.Add("HospitalPartnerShippingOption", _hospitalPartnerShippingOption);
			toReturn.Add("ProductShippingOption", _productShippingOption);
			toReturn.Add("ShippingDetail", _shippingDetail);
			toReturn.Add("ShippingOptionOrderItem", _shippingOptionOrderItem);
			toReturn.Add("ShippingOptionSourceCodeDiscount", _shippingOptionSourceCodeDiscount);
			toReturn.Add("AddressCollectionViaShippingDetail", _addressCollectionViaShippingDetail);
			toReturn.Add("CouponsCollectionViaShippingOptionSourceCodeDiscount", _couponsCollectionViaShippingOptionSourceCodeDiscount);
			toReturn.Add("HospitalPartnerCollectionViaHospitalPartnerShippingOption", _hospitalPartnerCollectionViaHospitalPartnerShippingOption);
			toReturn.Add("OrderItemCollectionViaShippingOptionOrderItem", _orderItemCollectionViaShippingOptionOrderItem);
			toReturn.Add("OrganizationRoleUserCollectionViaShippingDetail", _organizationRoleUserCollectionViaShippingDetail);
			toReturn.Add("OrganizationRoleUserCollectionViaShippingDetail_", _organizationRoleUserCollectionViaShippingDetail_);
			toReturn.Add("ProductCollectionViaProductShippingOption", _productCollectionViaProductShippingOption);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_hospitalPartnerShippingOption!=null)
			{
				_hospitalPartnerShippingOption.ActiveContext = base.ActiveContext;
			}
			if(_productShippingOption!=null)
			{
				_productShippingOption.ActiveContext = base.ActiveContext;
			}
			if(_shippingDetail!=null)
			{
				_shippingDetail.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionOrderItem!=null)
			{
				_shippingOptionOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionSourceCodeDiscount!=null)
			{
				_shippingOptionSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaShippingDetail!=null)
			{
				_addressCollectionViaShippingDetail.ActiveContext = base.ActiveContext;
			}
			if(_couponsCollectionViaShippingOptionSourceCodeDiscount!=null)
			{
				_couponsCollectionViaShippingOptionSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerCollectionViaHospitalPartnerShippingOption!=null)
			{
				_hospitalPartnerCollectionViaHospitalPartnerShippingOption.ActiveContext = base.ActiveContext;
			}
			if(_orderItemCollectionViaShippingOptionOrderItem!=null)
			{
				_orderItemCollectionViaShippingOptionOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaShippingDetail!=null)
			{
				_organizationRoleUserCollectionViaShippingDetail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaShippingDetail_!=null)
			{
				_organizationRoleUserCollectionViaShippingDetail_.ActiveContext = base.ActiveContext;
			}
			if(_productCollectionViaProductShippingOption!=null)
			{
				_productCollectionViaProductShippingOption.ActiveContext = base.ActiveContext;
			}
			if(_carrier!=null)
			{
				_carrier.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_hospitalPartnerShippingOption = null;
			_productShippingOption = null;
			_shippingDetail = null;
			_shippingOptionOrderItem = null;
			_shippingOptionSourceCodeDiscount = null;
			_addressCollectionViaShippingDetail = null;
			_couponsCollectionViaShippingOptionSourceCodeDiscount = null;
			_hospitalPartnerCollectionViaHospitalPartnerShippingOption = null;
			_orderItemCollectionViaShippingOptionOrderItem = null;
			_organizationRoleUserCollectionViaShippingDetail = null;
			_organizationRoleUserCollectionViaShippingDetail_ = null;
			_productCollectionViaProductShippingOption = null;
			_carrier = null;

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

			_fieldsCustomProperties.Add("ShippingOptionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Type", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CarrierId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Price", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CostToCompany", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Disclaimer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShippableToPobox", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForOrderDisplayHtmlString", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _carrier</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCarrier(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _carrier, new PropertyChangedEventHandler( OnCarrierPropertyChanged ), "Carrier", ShippingOptionEntity.Relations.CarrierEntityUsingCarrierId, true, signalRelatedEntity, "ShippingOption", resetFKFields, new int[] { (int)ShippingOptionFieldIndex.CarrierId } );		
			_carrier = null;
		}

		/// <summary> setups the sync logic for member _carrier</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCarrier(IEntity2 relatedEntity)
		{
			if(_carrier!=relatedEntity)
			{
				DesetupSyncCarrier(true, true);
				_carrier = (CarrierEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _carrier, new PropertyChangedEventHandler( OnCarrierPropertyChanged ), "Carrier", ShippingOptionEntity.Relations.CarrierEntityUsingCarrierId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCarrierPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ShippingOptionEntity</param>
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
		public  static ShippingOptionRelations Relations
		{
			get	{ return new ShippingOptionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartnerShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerShippingOption
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HospitalPartnerShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerShippingOptionEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalPartnerShippingOption")[0], (int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.HospitalPartnerShippingOptionEntity, 0, null, null, null, null, "HospitalPartnerShippingOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProductShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProductShippingOption
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProductShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductShippingOptionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProductShippingOption")[0], (int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.ProductShippingOptionEntity, 0, null, null, null, null, "ProductShippingOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("ShippingDetail")[0], (int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.ShippingDetailEntity, 0, null, null, null, null, "ShippingDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOptionOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ShippingOptionOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("ShippingOptionOrderItem")[0], (int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.ShippingOptionOrderItemEntity, 0, null, null, null, null, "ShippingOptionOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOptionSourceCodeDiscount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionSourceCodeDiscount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ShippingOptionSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionSourceCodeDiscountEntityFactory))),
					(IEntityRelation)GetRelationsForField("ShippingOptionSourceCodeDiscount")[0], (int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.ShippingOptionSourceCodeDiscountEntity, 0, null, null, null, null, "ShippingOptionSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaShippingDetail
		{
			get
			{
				IEntityRelation intermediateRelation = ShippingOptionEntity.Relations.ShippingDetailEntityUsingShippingOptionId;
				intermediateRelation.SetAliases(string.Empty, "ShippingDetail_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaShippingDetail"), null, "AddressCollectionViaShippingDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponsCollectionViaShippingOptionSourceCodeDiscount
		{
			get
			{
				IEntityRelation intermediateRelation = ShippingOptionEntity.Relations.ShippingOptionSourceCodeDiscountEntityUsingShippingOptionId;
				intermediateRelation.SetAliases(string.Empty, "ShippingOptionSourceCodeDiscount_");
				return new PrefetchPathElement2(new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.CouponsEntity, 0, null, null, GetRelationsForField("CouponsCollectionViaShippingOptionSourceCodeDiscount"), null, "CouponsCollectionViaShippingOptionSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartner' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerCollectionViaHospitalPartnerShippingOption
		{
			get
			{
				IEntityRelation intermediateRelation = ShippingOptionEntity.Relations.HospitalPartnerShippingOptionEntityUsingShippingOptionId;
				intermediateRelation.SetAliases(string.Empty, "HospitalPartnerShippingOption_");
				return new PrefetchPathElement2(new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.HospitalPartnerEntity, 0, null, null, GetRelationsForField("HospitalPartnerCollectionViaHospitalPartnerShippingOption"), null, "HospitalPartnerCollectionViaHospitalPartnerShippingOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItemCollectionViaShippingOptionOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = ShippingOptionEntity.Relations.ShippingOptionOrderItemEntityUsingShippingOptionId;
				intermediateRelation.SetAliases(string.Empty, "ShippingOptionOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, GetRelationsForField("OrderItemCollectionViaShippingOptionOrderItem"), null, "OrderItemCollectionViaShippingOptionOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaShippingDetail
		{
			get
			{
				IEntityRelation intermediateRelation = ShippingOptionEntity.Relations.ShippingDetailEntityUsingShippingOptionId;
				intermediateRelation.SetAliases(string.Empty, "ShippingDetail_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaShippingDetail"), null, "OrganizationRoleUserCollectionViaShippingDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaShippingDetail_
		{
			get
			{
				IEntityRelation intermediateRelation = ShippingOptionEntity.Relations.ShippingDetailEntityUsingShippingOptionId;
				intermediateRelation.SetAliases(string.Empty, "ShippingDetail_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaShippingDetail_"), null, "OrganizationRoleUserCollectionViaShippingDetail_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Product' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProductCollectionViaProductShippingOption
		{
			get
			{
				IEntityRelation intermediateRelation = ShippingOptionEntity.Relations.ProductShippingOptionEntityUsingShippingOptionId;
				intermediateRelation.SetAliases(string.Empty, "ProductShippingOption_");
				return new PrefetchPathElement2(new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.ProductEntity, 0, null, null, GetRelationsForField("ProductCollectionViaProductShippingOption"), null, "ProductCollectionViaProductShippingOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Carrier' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCarrier
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CarrierEntityFactory))),
					(IEntityRelation)GetRelationsForField("Carrier")[0], (int)Falcon.Data.EntityType.ShippingOptionEntity, (int)Falcon.Data.EntityType.CarrierEntity, 0, null, null, null, null, "Carrier", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ShippingOptionEntity.CustomProperties;}
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
			get { return ShippingOptionEntity.FieldsCustomProperties;}
		}

		/// <summary> The ShippingOptionId property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."ShippingOptionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ShippingOptionId
		{
			get { return (System.Int64)GetValue((int)ShippingOptionFieldIndex.ShippingOptionId, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.ShippingOptionId, value); }
		}

		/// <summary> The Type property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."Type"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte Type
		{
			get { return (System.Byte)GetValue((int)ShippingOptionFieldIndex.Type, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.Type, value); }
		}

		/// <summary> The CarrierId property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."CarrierID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CarrierId
		{
			get { return (System.Int64)GetValue((int)ShippingOptionFieldIndex.CarrierId, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.CarrierId, value); }
		}

		/// <summary> The Description property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ShippingOptionFieldIndex.Description, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.Description, value); }
		}

		/// <summary> The Price property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."Price"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Price
		{
			get { return (System.Decimal)GetValue((int)ShippingOptionFieldIndex.Price, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.Price, value); }
		}

		/// <summary> The CostToCompany property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."CostToCompany"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal CostToCompany
		{
			get { return (System.Decimal)GetValue((int)ShippingOptionFieldIndex.CostToCompany, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.CostToCompany, value); }
		}

		/// <summary> The Disclaimer property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."Disclaimer"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Disclaimer
		{
			get { return (System.String)GetValue((int)ShippingOptionFieldIndex.Disclaimer, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.Disclaimer, value); }
		}

		/// <summary> The ShippableToPobox property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."ShippableToPOBox"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShippableToPobox
		{
			get { return (System.Boolean)GetValue((int)ShippingOptionFieldIndex.ShippableToPobox, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.ShippableToPobox, value); }
		}

		/// <summary> The IsActive property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ShippingOptionFieldIndex.IsActive, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ShippingOptionFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ShippingOptionFieldIndex.DateModified, false); }
			set	{ SetValue((int)ShippingOptionFieldIndex.DateModified, value); }
		}

		/// <summary> The Name property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ShippingOptionFieldIndex.Name, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.Name, value); }
		}

		/// <summary> The ForOrderDisplayHtmlString property of the Entity ShippingOption<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblShippingOption"."ForOrderDisplayHtmlString"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ForOrderDisplayHtmlString
		{
			get { return (System.String)GetValue((int)ShippingOptionFieldIndex.ForOrderDisplayHtmlString, true); }
			set	{ SetValue((int)ShippingOptionFieldIndex.ForOrderDisplayHtmlString, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerShippingOptionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerShippingOptionEntity))]
		public virtual EntityCollection<HospitalPartnerShippingOptionEntity> HospitalPartnerShippingOption
		{
			get
			{
				if(_hospitalPartnerShippingOption==null)
				{
					_hospitalPartnerShippingOption = new EntityCollection<HospitalPartnerShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerShippingOptionEntityFactory)));
					_hospitalPartnerShippingOption.SetContainingEntityInfo(this, "ShippingOption");
				}
				return _hospitalPartnerShippingOption;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProductShippingOptionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProductShippingOptionEntity))]
		public virtual EntityCollection<ProductShippingOptionEntity> ProductShippingOption
		{
			get
			{
				if(_productShippingOption==null)
				{
					_productShippingOption = new EntityCollection<ProductShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductShippingOptionEntityFactory)));
					_productShippingOption.SetContainingEntityInfo(this, "ShippingOption");
				}
				return _productShippingOption;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingDetailEntity))]
		public virtual EntityCollection<ShippingDetailEntity> ShippingDetail
		{
			get
			{
				if(_shippingDetail==null)
				{
					_shippingDetail = new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory)));
					_shippingDetail.SetContainingEntityInfo(this, "ShippingOption");
				}
				return _shippingDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionOrderItemEntity))]
		public virtual EntityCollection<ShippingOptionOrderItemEntity> ShippingOptionOrderItem
		{
			get
			{
				if(_shippingOptionOrderItem==null)
				{
					_shippingOptionOrderItem = new EntityCollection<ShippingOptionOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionOrderItemEntityFactory)));
					_shippingOptionOrderItem.SetContainingEntityInfo(this, "ShippingOption");
				}
				return _shippingOptionOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionSourceCodeDiscountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionSourceCodeDiscountEntity))]
		public virtual EntityCollection<ShippingOptionSourceCodeDiscountEntity> ShippingOptionSourceCodeDiscount
		{
			get
			{
				if(_shippingOptionSourceCodeDiscount==null)
				{
					_shippingOptionSourceCodeDiscount = new EntityCollection<ShippingOptionSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionSourceCodeDiscountEntityFactory)));
					_shippingOptionSourceCodeDiscount.SetContainingEntityInfo(this, "ShippingOption");
				}
				return _shippingOptionSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaShippingDetail
		{
			get
			{
				if(_addressCollectionViaShippingDetail==null)
				{
					_addressCollectionViaShippingDetail = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaShippingDetail.IsReadOnly=true;
				}
				return _addressCollectionViaShippingDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponsEntity))]
		public virtual EntityCollection<CouponsEntity> CouponsCollectionViaShippingOptionSourceCodeDiscount
		{
			get
			{
				if(_couponsCollectionViaShippingOptionSourceCodeDiscount==null)
				{
					_couponsCollectionViaShippingOptionSourceCodeDiscount = new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory)));
					_couponsCollectionViaShippingOptionSourceCodeDiscount.IsReadOnly=true;
				}
				return _couponsCollectionViaShippingOptionSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerEntity))]
		public virtual EntityCollection<HospitalPartnerEntity> HospitalPartnerCollectionViaHospitalPartnerShippingOption
		{
			get
			{
				if(_hospitalPartnerCollectionViaHospitalPartnerShippingOption==null)
				{
					_hospitalPartnerCollectionViaHospitalPartnerShippingOption = new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory)));
					_hospitalPartnerCollectionViaHospitalPartnerShippingOption.IsReadOnly=true;
				}
				return _hospitalPartnerCollectionViaHospitalPartnerShippingOption;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderItemEntity))]
		public virtual EntityCollection<OrderItemEntity> OrderItemCollectionViaShippingOptionOrderItem
		{
			get
			{
				if(_orderItemCollectionViaShippingOptionOrderItem==null)
				{
					_orderItemCollectionViaShippingOptionOrderItem = new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory)));
					_orderItemCollectionViaShippingOptionOrderItem.IsReadOnly=true;
				}
				return _orderItemCollectionViaShippingOptionOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaShippingDetail
		{
			get
			{
				if(_organizationRoleUserCollectionViaShippingDetail==null)
				{
					_organizationRoleUserCollectionViaShippingDetail = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaShippingDetail.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaShippingDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaShippingDetail_
		{
			get
			{
				if(_organizationRoleUserCollectionViaShippingDetail_==null)
				{
					_organizationRoleUserCollectionViaShippingDetail_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaShippingDetail_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaShippingDetail_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProductEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProductEntity))]
		public virtual EntityCollection<ProductEntity> ProductCollectionViaProductShippingOption
		{
			get
			{
				if(_productCollectionViaProductShippingOption==null)
				{
					_productCollectionViaProductShippingOption = new EntityCollection<ProductEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProductEntityFactory)));
					_productCollectionViaProductShippingOption.IsReadOnly=true;
				}
				return _productCollectionViaProductShippingOption;
			}
		}

		/// <summary> Gets / sets related entity of type 'CarrierEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CarrierEntity Carrier
		{
			get
			{
				return _carrier;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCarrier(value);
				}
				else
				{
					if(value==null)
					{
						if(_carrier != null)
						{
							_carrier.UnsetRelatedEntity(this, "ShippingOption");
						}
					}
					else
					{
						if(_carrier!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ShippingOption");
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
			get { return (int)Falcon.Data.EntityType.ShippingOptionEntity; }
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
