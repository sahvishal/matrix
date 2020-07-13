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
	/// Entity class which represents the entity 'Payment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PaymentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CashPaymentEntity> _cashPayment;
		private EntityCollection<ChargeCardPaymentEntity> _chargeCardPayment;
		private EntityCollection<CheckPaymentEntity> _checkPayment;
		private EntityCollection<EcheckPaymentEntity> _echeckPayment;
		private EntityCollection<GiftCertificatePaymentEntity> _giftCertificatePayment;
		private EntityCollection<InsurancePaymentEntity> _insurancePayment;
		private EntityCollection<PaymentOrderEntity> _paymentOrder;
		private EntityCollection<TestOrderItemEntity> _testOrderItem;
		private EntityCollection<ChargeCardEntity> _chargeCardCollectionViaChargeCardPayment;
		private EntityCollection<CheckEntity> _checkCollectionViaEcheckPayment;
		private EntityCollection<CheckEntity> _checkCollectionViaCheckPayment;
		private EntityCollection<GiftCertificateEntity> _giftCertificateCollectionViaGiftCertificatePayment;
		private EntityCollection<OrderEntity> _orderCollectionViaPaymentOrder;
		private EntityCollection<OrderDetailEntity> _orderDetailCollectionViaTestOrderItem;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name CashPayment</summary>
			public static readonly string CashPayment = "CashPayment";
			/// <summary>Member name ChargeCardPayment</summary>
			public static readonly string ChargeCardPayment = "ChargeCardPayment";
			/// <summary>Member name CheckPayment</summary>
			public static readonly string CheckPayment = "CheckPayment";
			/// <summary>Member name EcheckPayment</summary>
			public static readonly string EcheckPayment = "EcheckPayment";
			/// <summary>Member name GiftCertificatePayment</summary>
			public static readonly string GiftCertificatePayment = "GiftCertificatePayment";
			/// <summary>Member name InsurancePayment</summary>
			public static readonly string InsurancePayment = "InsurancePayment";
			/// <summary>Member name PaymentOrder</summary>
			public static readonly string PaymentOrder = "PaymentOrder";
			/// <summary>Member name TestOrderItem</summary>
			public static readonly string TestOrderItem = "TestOrderItem";
			/// <summary>Member name ChargeCardCollectionViaChargeCardPayment</summary>
			public static readonly string ChargeCardCollectionViaChargeCardPayment = "ChargeCardCollectionViaChargeCardPayment";
			/// <summary>Member name CheckCollectionViaEcheckPayment</summary>
			public static readonly string CheckCollectionViaEcheckPayment = "CheckCollectionViaEcheckPayment";
			/// <summary>Member name CheckCollectionViaCheckPayment</summary>
			public static readonly string CheckCollectionViaCheckPayment = "CheckCollectionViaCheckPayment";
			/// <summary>Member name GiftCertificateCollectionViaGiftCertificatePayment</summary>
			public static readonly string GiftCertificateCollectionViaGiftCertificatePayment = "GiftCertificateCollectionViaGiftCertificatePayment";
			/// <summary>Member name OrderCollectionViaPaymentOrder</summary>
			public static readonly string OrderCollectionViaPaymentOrder = "OrderCollectionViaPaymentOrder";
			/// <summary>Member name OrderDetailCollectionViaTestOrderItem</summary>
			public static readonly string OrderDetailCollectionViaTestOrderItem = "OrderDetailCollectionViaTestOrderItem";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PaymentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PaymentEntity():base("PaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PaymentEntity(IEntityFields2 fields):base("PaymentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PaymentEntity</param>
		public PaymentEntity(IValidator validator):base("PaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="paymentId">PK value for Payment which data should be fetched into this Payment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PaymentEntity(System.Int64 paymentId):base("PaymentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.PaymentId = paymentId;
		}

		/// <summary> CTor</summary>
		/// <param name="paymentId">PK value for Payment which data should be fetched into this Payment object</param>
		/// <param name="validator">The custom validator object for this PaymentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PaymentEntity(System.Int64 paymentId, IValidator validator):base("PaymentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.PaymentId = paymentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PaymentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_cashPayment = (EntityCollection<CashPaymentEntity>)info.GetValue("_cashPayment", typeof(EntityCollection<CashPaymentEntity>));
				_chargeCardPayment = (EntityCollection<ChargeCardPaymentEntity>)info.GetValue("_chargeCardPayment", typeof(EntityCollection<ChargeCardPaymentEntity>));
				_checkPayment = (EntityCollection<CheckPaymentEntity>)info.GetValue("_checkPayment", typeof(EntityCollection<CheckPaymentEntity>));
				_echeckPayment = (EntityCollection<EcheckPaymentEntity>)info.GetValue("_echeckPayment", typeof(EntityCollection<EcheckPaymentEntity>));
				_giftCertificatePayment = (EntityCollection<GiftCertificatePaymentEntity>)info.GetValue("_giftCertificatePayment", typeof(EntityCollection<GiftCertificatePaymentEntity>));
				_insurancePayment = (EntityCollection<InsurancePaymentEntity>)info.GetValue("_insurancePayment", typeof(EntityCollection<InsurancePaymentEntity>));
				_paymentOrder = (EntityCollection<PaymentOrderEntity>)info.GetValue("_paymentOrder", typeof(EntityCollection<PaymentOrderEntity>));
				_testOrderItem = (EntityCollection<TestOrderItemEntity>)info.GetValue("_testOrderItem", typeof(EntityCollection<TestOrderItemEntity>));
				_chargeCardCollectionViaChargeCardPayment = (EntityCollection<ChargeCardEntity>)info.GetValue("_chargeCardCollectionViaChargeCardPayment", typeof(EntityCollection<ChargeCardEntity>));
				_checkCollectionViaEcheckPayment = (EntityCollection<CheckEntity>)info.GetValue("_checkCollectionViaEcheckPayment", typeof(EntityCollection<CheckEntity>));
				_checkCollectionViaCheckPayment = (EntityCollection<CheckEntity>)info.GetValue("_checkCollectionViaCheckPayment", typeof(EntityCollection<CheckEntity>));
				_giftCertificateCollectionViaGiftCertificatePayment = (EntityCollection<GiftCertificateEntity>)info.GetValue("_giftCertificateCollectionViaGiftCertificatePayment", typeof(EntityCollection<GiftCertificateEntity>));
				_orderCollectionViaPaymentOrder = (EntityCollection<OrderEntity>)info.GetValue("_orderCollectionViaPaymentOrder", typeof(EntityCollection<OrderEntity>));
				_orderDetailCollectionViaTestOrderItem = (EntityCollection<OrderDetailEntity>)info.GetValue("_orderDetailCollectionViaTestOrderItem", typeof(EntityCollection<OrderDetailEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((PaymentFieldIndex)fieldIndex)
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

				case "CashPayment":
					this.CashPayment.Add((CashPaymentEntity)entity);
					break;
				case "ChargeCardPayment":
					this.ChargeCardPayment.Add((ChargeCardPaymentEntity)entity);
					break;
				case "CheckPayment":
					this.CheckPayment.Add((CheckPaymentEntity)entity);
					break;
				case "EcheckPayment":
					this.EcheckPayment.Add((EcheckPaymentEntity)entity);
					break;
				case "GiftCertificatePayment":
					this.GiftCertificatePayment.Add((GiftCertificatePaymentEntity)entity);
					break;
				case "InsurancePayment":
					this.InsurancePayment.Add((InsurancePaymentEntity)entity);
					break;
				case "PaymentOrder":
					this.PaymentOrder.Add((PaymentOrderEntity)entity);
					break;
				case "TestOrderItem":
					this.TestOrderItem.Add((TestOrderItemEntity)entity);
					break;
				case "ChargeCardCollectionViaChargeCardPayment":
					this.ChargeCardCollectionViaChargeCardPayment.IsReadOnly = false;
					this.ChargeCardCollectionViaChargeCardPayment.Add((ChargeCardEntity)entity);
					this.ChargeCardCollectionViaChargeCardPayment.IsReadOnly = true;
					break;
				case "CheckCollectionViaEcheckPayment":
					this.CheckCollectionViaEcheckPayment.IsReadOnly = false;
					this.CheckCollectionViaEcheckPayment.Add((CheckEntity)entity);
					this.CheckCollectionViaEcheckPayment.IsReadOnly = true;
					break;
				case "CheckCollectionViaCheckPayment":
					this.CheckCollectionViaCheckPayment.IsReadOnly = false;
					this.CheckCollectionViaCheckPayment.Add((CheckEntity)entity);
					this.CheckCollectionViaCheckPayment.IsReadOnly = true;
					break;
				case "GiftCertificateCollectionViaGiftCertificatePayment":
					this.GiftCertificateCollectionViaGiftCertificatePayment.IsReadOnly = false;
					this.GiftCertificateCollectionViaGiftCertificatePayment.Add((GiftCertificateEntity)entity);
					this.GiftCertificateCollectionViaGiftCertificatePayment.IsReadOnly = true;
					break;
				case "OrderCollectionViaPaymentOrder":
					this.OrderCollectionViaPaymentOrder.IsReadOnly = false;
					this.OrderCollectionViaPaymentOrder.Add((OrderEntity)entity);
					this.OrderCollectionViaPaymentOrder.IsReadOnly = true;
					break;
				case "OrderDetailCollectionViaTestOrderItem":
					this.OrderDetailCollectionViaTestOrderItem.IsReadOnly = false;
					this.OrderDetailCollectionViaTestOrderItem.Add((OrderDetailEntity)entity);
					this.OrderDetailCollectionViaTestOrderItem.IsReadOnly = true;
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
			return PaymentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "CashPayment":
					toReturn.Add(PaymentEntity.Relations.CashPaymentEntityUsingPaymentId);
					break;
				case "ChargeCardPayment":
					toReturn.Add(PaymentEntity.Relations.ChargeCardPaymentEntityUsingPaymentId);
					break;
				case "CheckPayment":
					toReturn.Add(PaymentEntity.Relations.CheckPaymentEntityUsingPaymentId);
					break;
				case "EcheckPayment":
					toReturn.Add(PaymentEntity.Relations.EcheckPaymentEntityUsingPaymentId);
					break;
				case "GiftCertificatePayment":
					toReturn.Add(PaymentEntity.Relations.GiftCertificatePaymentEntityUsingPaymentId);
					break;
				case "InsurancePayment":
					toReturn.Add(PaymentEntity.Relations.InsurancePaymentEntityUsingPaymentId);
					break;
				case "PaymentOrder":
					toReturn.Add(PaymentEntity.Relations.PaymentOrderEntityUsingPaymentId);
					break;
				case "TestOrderItem":
					toReturn.Add(PaymentEntity.Relations.TestOrderItemEntityUsingTestId);
					break;
				case "ChargeCardCollectionViaChargeCardPayment":
					toReturn.Add(PaymentEntity.Relations.ChargeCardPaymentEntityUsingPaymentId, "PaymentEntity__", "ChargeCardPayment_", JoinHint.None);
					toReturn.Add(ChargeCardPaymentEntity.Relations.ChargeCardEntityUsingChargeCardId, "ChargeCardPayment_", string.Empty, JoinHint.None);
					break;
				case "CheckCollectionViaEcheckPayment":
					toReturn.Add(PaymentEntity.Relations.EcheckPaymentEntityUsingPaymentId, "PaymentEntity__", "EcheckPayment_", JoinHint.None);
					toReturn.Add(EcheckPaymentEntity.Relations.CheckEntityUsingEcheckId, "EcheckPayment_", string.Empty, JoinHint.None);
					break;
				case "CheckCollectionViaCheckPayment":
					toReturn.Add(PaymentEntity.Relations.CheckPaymentEntityUsingPaymentId, "PaymentEntity__", "CheckPayment_", JoinHint.None);
					toReturn.Add(CheckPaymentEntity.Relations.CheckEntityUsingCheckId, "CheckPayment_", string.Empty, JoinHint.None);
					break;
				case "GiftCertificateCollectionViaGiftCertificatePayment":
					toReturn.Add(PaymentEntity.Relations.GiftCertificatePaymentEntityUsingPaymentId, "PaymentEntity__", "GiftCertificatePayment_", JoinHint.None);
					toReturn.Add(GiftCertificatePaymentEntity.Relations.GiftCertificateEntityUsingGiftCertificateId, "GiftCertificatePayment_", string.Empty, JoinHint.None);
					break;
				case "OrderCollectionViaPaymentOrder":
					toReturn.Add(PaymentEntity.Relations.PaymentOrderEntityUsingPaymentId, "PaymentEntity__", "PaymentOrder_", JoinHint.None);
					toReturn.Add(PaymentOrderEntity.Relations.OrderEntityUsingOrderId, "PaymentOrder_", string.Empty, JoinHint.None);
					break;
				case "OrderDetailCollectionViaTestOrderItem":
					toReturn.Add(PaymentEntity.Relations.TestOrderItemEntityUsingTestId, "PaymentEntity__", "TestOrderItem_", JoinHint.None);
					toReturn.Add(TestOrderItemEntity.Relations.OrderDetailEntityUsingOrderItemId, "TestOrderItem_", string.Empty, JoinHint.None);
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

				case "CashPayment":
					this.CashPayment.Add((CashPaymentEntity)relatedEntity);
					break;
				case "ChargeCardPayment":
					this.ChargeCardPayment.Add((ChargeCardPaymentEntity)relatedEntity);
					break;
				case "CheckPayment":
					this.CheckPayment.Add((CheckPaymentEntity)relatedEntity);
					break;
				case "EcheckPayment":
					this.EcheckPayment.Add((EcheckPaymentEntity)relatedEntity);
					break;
				case "GiftCertificatePayment":
					this.GiftCertificatePayment.Add((GiftCertificatePaymentEntity)relatedEntity);
					break;
				case "InsurancePayment":
					this.InsurancePayment.Add((InsurancePaymentEntity)relatedEntity);
					break;
				case "PaymentOrder":
					this.PaymentOrder.Add((PaymentOrderEntity)relatedEntity);
					break;
				case "TestOrderItem":
					this.TestOrderItem.Add((TestOrderItemEntity)relatedEntity);
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

				case "CashPayment":
					base.PerformRelatedEntityRemoval(this.CashPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ChargeCardPayment":
					base.PerformRelatedEntityRemoval(this.ChargeCardPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CheckPayment":
					base.PerformRelatedEntityRemoval(this.CheckPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EcheckPayment":
					base.PerformRelatedEntityRemoval(this.EcheckPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "GiftCertificatePayment":
					base.PerformRelatedEntityRemoval(this.GiftCertificatePayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "InsurancePayment":
					base.PerformRelatedEntityRemoval(this.InsurancePayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PaymentOrder":
					base.PerformRelatedEntityRemoval(this.PaymentOrder, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestOrderItem":
					base.PerformRelatedEntityRemoval(this.TestOrderItem, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CashPayment);
			toReturn.Add(this.ChargeCardPayment);
			toReturn.Add(this.CheckPayment);
			toReturn.Add(this.EcheckPayment);
			toReturn.Add(this.GiftCertificatePayment);
			toReturn.Add(this.InsurancePayment);
			toReturn.Add(this.PaymentOrder);
			toReturn.Add(this.TestOrderItem);

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
				info.AddValue("_cashPayment", ((_cashPayment!=null) && (_cashPayment.Count>0) && !this.MarkedForDeletion)?_cashPayment:null);
				info.AddValue("_chargeCardPayment", ((_chargeCardPayment!=null) && (_chargeCardPayment.Count>0) && !this.MarkedForDeletion)?_chargeCardPayment:null);
				info.AddValue("_checkPayment", ((_checkPayment!=null) && (_checkPayment.Count>0) && !this.MarkedForDeletion)?_checkPayment:null);
				info.AddValue("_echeckPayment", ((_echeckPayment!=null) && (_echeckPayment.Count>0) && !this.MarkedForDeletion)?_echeckPayment:null);
				info.AddValue("_giftCertificatePayment", ((_giftCertificatePayment!=null) && (_giftCertificatePayment.Count>0) && !this.MarkedForDeletion)?_giftCertificatePayment:null);
				info.AddValue("_insurancePayment", ((_insurancePayment!=null) && (_insurancePayment.Count>0) && !this.MarkedForDeletion)?_insurancePayment:null);
				info.AddValue("_paymentOrder", ((_paymentOrder!=null) && (_paymentOrder.Count>0) && !this.MarkedForDeletion)?_paymentOrder:null);
				info.AddValue("_testOrderItem", ((_testOrderItem!=null) && (_testOrderItem.Count>0) && !this.MarkedForDeletion)?_testOrderItem:null);
				info.AddValue("_chargeCardCollectionViaChargeCardPayment", ((_chargeCardCollectionViaChargeCardPayment!=null) && (_chargeCardCollectionViaChargeCardPayment.Count>0) && !this.MarkedForDeletion)?_chargeCardCollectionViaChargeCardPayment:null);
				info.AddValue("_checkCollectionViaEcheckPayment", ((_checkCollectionViaEcheckPayment!=null) && (_checkCollectionViaEcheckPayment.Count>0) && !this.MarkedForDeletion)?_checkCollectionViaEcheckPayment:null);
				info.AddValue("_checkCollectionViaCheckPayment", ((_checkCollectionViaCheckPayment!=null) && (_checkCollectionViaCheckPayment.Count>0) && !this.MarkedForDeletion)?_checkCollectionViaCheckPayment:null);
				info.AddValue("_giftCertificateCollectionViaGiftCertificatePayment", ((_giftCertificateCollectionViaGiftCertificatePayment!=null) && (_giftCertificateCollectionViaGiftCertificatePayment.Count>0) && !this.MarkedForDeletion)?_giftCertificateCollectionViaGiftCertificatePayment:null);
				info.AddValue("_orderCollectionViaPaymentOrder", ((_orderCollectionViaPaymentOrder!=null) && (_orderCollectionViaPaymentOrder.Count>0) && !this.MarkedForDeletion)?_orderCollectionViaPaymentOrder:null);
				info.AddValue("_orderDetailCollectionViaTestOrderItem", ((_orderDetailCollectionViaTestOrderItem!=null) && (_orderDetailCollectionViaTestOrderItem.Count>0) && !this.MarkedForDeletion)?_orderDetailCollectionViaTestOrderItem:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PaymentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PaymentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PaymentRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CashPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCashPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CashPaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChargeCardPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChargeCardPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChargeCardPaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckPaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EcheckPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEcheckPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EcheckPaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificatePayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificatePayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GiftCertificatePaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InsurancePayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInsurancePayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InsurancePaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PaymentOrder' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPaymentOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentOrderFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestOrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestOrderItemFields.TestId, null, ComparisonOperator.Equal, this.PaymentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChargeCard' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChargeCardCollectionViaChargeCardPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChargeCardCollectionViaChargeCardPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "PaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Check' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckCollectionViaEcheckPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckCollectionViaEcheckPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "PaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Check' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckCollectionViaCheckPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckCollectionViaCheckPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "PaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificateCollectionViaGiftCertificatePayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("GiftCertificateCollectionViaGiftCertificatePayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "PaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Order' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderCollectionViaPaymentOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderCollectionViaPaymentOrder"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "PaymentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderDetailCollectionViaTestOrderItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderDetailCollectionViaTestOrderItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PaymentFields.PaymentId, null, ComparisonOperator.Equal, this.PaymentId, "PaymentEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PaymentEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PaymentEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._cashPayment);
			collectionsQueue.Enqueue(this._chargeCardPayment);
			collectionsQueue.Enqueue(this._checkPayment);
			collectionsQueue.Enqueue(this._echeckPayment);
			collectionsQueue.Enqueue(this._giftCertificatePayment);
			collectionsQueue.Enqueue(this._insurancePayment);
			collectionsQueue.Enqueue(this._paymentOrder);
			collectionsQueue.Enqueue(this._testOrderItem);
			collectionsQueue.Enqueue(this._chargeCardCollectionViaChargeCardPayment);
			collectionsQueue.Enqueue(this._checkCollectionViaEcheckPayment);
			collectionsQueue.Enqueue(this._checkCollectionViaCheckPayment);
			collectionsQueue.Enqueue(this._giftCertificateCollectionViaGiftCertificatePayment);
			collectionsQueue.Enqueue(this._orderCollectionViaPaymentOrder);
			collectionsQueue.Enqueue(this._orderDetailCollectionViaTestOrderItem);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._cashPayment = (EntityCollection<CashPaymentEntity>) collectionsQueue.Dequeue();
			this._chargeCardPayment = (EntityCollection<ChargeCardPaymentEntity>) collectionsQueue.Dequeue();
			this._checkPayment = (EntityCollection<CheckPaymentEntity>) collectionsQueue.Dequeue();
			this._echeckPayment = (EntityCollection<EcheckPaymentEntity>) collectionsQueue.Dequeue();
			this._giftCertificatePayment = (EntityCollection<GiftCertificatePaymentEntity>) collectionsQueue.Dequeue();
			this._insurancePayment = (EntityCollection<InsurancePaymentEntity>) collectionsQueue.Dequeue();
			this._paymentOrder = (EntityCollection<PaymentOrderEntity>) collectionsQueue.Dequeue();
			this._testOrderItem = (EntityCollection<TestOrderItemEntity>) collectionsQueue.Dequeue();
			this._chargeCardCollectionViaChargeCardPayment = (EntityCollection<ChargeCardEntity>) collectionsQueue.Dequeue();
			this._checkCollectionViaEcheckPayment = (EntityCollection<CheckEntity>) collectionsQueue.Dequeue();
			this._checkCollectionViaCheckPayment = (EntityCollection<CheckEntity>) collectionsQueue.Dequeue();
			this._giftCertificateCollectionViaGiftCertificatePayment = (EntityCollection<GiftCertificateEntity>) collectionsQueue.Dequeue();
			this._orderCollectionViaPaymentOrder = (EntityCollection<OrderEntity>) collectionsQueue.Dequeue();
			this._orderDetailCollectionViaTestOrderItem = (EntityCollection<OrderDetailEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._cashPayment != null)
			{
				return true;
			}
			if (this._chargeCardPayment != null)
			{
				return true;
			}
			if (this._checkPayment != null)
			{
				return true;
			}
			if (this._echeckPayment != null)
			{
				return true;
			}
			if (this._giftCertificatePayment != null)
			{
				return true;
			}
			if (this._insurancePayment != null)
			{
				return true;
			}
			if (this._paymentOrder != null)
			{
				return true;
			}
			if (this._testOrderItem != null)
			{
				return true;
			}
			if (this._chargeCardCollectionViaChargeCardPayment != null)
			{
				return true;
			}
			if (this._checkCollectionViaEcheckPayment != null)
			{
				return true;
			}
			if (this._checkCollectionViaCheckPayment != null)
			{
				return true;
			}
			if (this._giftCertificateCollectionViaGiftCertificatePayment != null)
			{
				return true;
			}
			if (this._orderCollectionViaPaymentOrder != null)
			{
				return true;
			}
			if (this._orderDetailCollectionViaTestOrderItem != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CashPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CashPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChargeCardPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EcheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificatePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificatePaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InsurancePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InsurancePaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PaymentOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentOrderEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestOrderItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("CashPayment", _cashPayment);
			toReturn.Add("ChargeCardPayment", _chargeCardPayment);
			toReturn.Add("CheckPayment", _checkPayment);
			toReturn.Add("EcheckPayment", _echeckPayment);
			toReturn.Add("GiftCertificatePayment", _giftCertificatePayment);
			toReturn.Add("InsurancePayment", _insurancePayment);
			toReturn.Add("PaymentOrder", _paymentOrder);
			toReturn.Add("TestOrderItem", _testOrderItem);
			toReturn.Add("ChargeCardCollectionViaChargeCardPayment", _chargeCardCollectionViaChargeCardPayment);
			toReturn.Add("CheckCollectionViaEcheckPayment", _checkCollectionViaEcheckPayment);
			toReturn.Add("CheckCollectionViaCheckPayment", _checkCollectionViaCheckPayment);
			toReturn.Add("GiftCertificateCollectionViaGiftCertificatePayment", _giftCertificateCollectionViaGiftCertificatePayment);
			toReturn.Add("OrderCollectionViaPaymentOrder", _orderCollectionViaPaymentOrder);
			toReturn.Add("OrderDetailCollectionViaTestOrderItem", _orderDetailCollectionViaTestOrderItem);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_cashPayment!=null)
			{
				_cashPayment.ActiveContext = base.ActiveContext;
			}
			if(_chargeCardPayment!=null)
			{
				_chargeCardPayment.ActiveContext = base.ActiveContext;
			}
			if(_checkPayment!=null)
			{
				_checkPayment.ActiveContext = base.ActiveContext;
			}
			if(_echeckPayment!=null)
			{
				_echeckPayment.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificatePayment!=null)
			{
				_giftCertificatePayment.ActiveContext = base.ActiveContext;
			}
			if(_insurancePayment!=null)
			{
				_insurancePayment.ActiveContext = base.ActiveContext;
			}
			if(_paymentOrder!=null)
			{
				_paymentOrder.ActiveContext = base.ActiveContext;
			}
			if(_testOrderItem!=null)
			{
				_testOrderItem.ActiveContext = base.ActiveContext;
			}
			if(_chargeCardCollectionViaChargeCardPayment!=null)
			{
				_chargeCardCollectionViaChargeCardPayment.ActiveContext = base.ActiveContext;
			}
			if(_checkCollectionViaEcheckPayment!=null)
			{
				_checkCollectionViaEcheckPayment.ActiveContext = base.ActiveContext;
			}
			if(_checkCollectionViaCheckPayment!=null)
			{
				_checkCollectionViaCheckPayment.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificateCollectionViaGiftCertificatePayment!=null)
			{
				_giftCertificateCollectionViaGiftCertificatePayment.ActiveContext = base.ActiveContext;
			}
			if(_orderCollectionViaPaymentOrder!=null)
			{
				_orderCollectionViaPaymentOrder.ActiveContext = base.ActiveContext;
			}
			if(_orderDetailCollectionViaTestOrderItem!=null)
			{
				_orderDetailCollectionViaTestOrderItem.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_cashPayment = null;
			_chargeCardPayment = null;
			_checkPayment = null;
			_echeckPayment = null;
			_giftCertificatePayment = null;
			_insurancePayment = null;
			_paymentOrder = null;
			_testOrderItem = null;
			_chargeCardCollectionViaChargeCardPayment = null;
			_checkCollectionViaEcheckPayment = null;
			_checkCollectionViaCheckPayment = null;
			_giftCertificateCollectionViaGiftCertificatePayment = null;
			_orderCollectionViaPaymentOrder = null;
			_orderDetailCollectionViaTestOrderItem = null;


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

			_fieldsCustomProperties.Add("PaymentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationRoleUserCreatorId", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PaymentEntity</param>
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
		public  static PaymentRelations Relations
		{
			get	{ return new PaymentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CashPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCashPayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CashPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CashPaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CashPayment")[0], (int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.CashPaymentEntity, 0, null, null, null, null, "CashPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChargeCardPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChargeCardPayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChargeCardPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardPaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChargeCardPayment")[0], (int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.ChargeCardPaymentEntity, 0, null, null, null, null, "ChargeCardPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckPayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckPaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckPayment")[0], (int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.CheckPaymentEntity, 0, null, null, null, null, "CheckPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EcheckPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEcheckPayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EcheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("EcheckPayment")[0], (int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.EcheckPaymentEntity, 0, null, null, null, null, "EcheckPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificatePayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificatePayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GiftCertificatePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificatePaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("GiftCertificatePayment")[0], (int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.GiftCertificatePaymentEntity, 0, null, null, null, null, "GiftCertificatePayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InsurancePayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInsurancePayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InsurancePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InsurancePaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("InsurancePayment")[0], (int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.InsurancePaymentEntity, 0, null, null, null, null, "InsurancePayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PaymentOrder' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPaymentOrder
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PaymentOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentOrderEntityFactory))),
					(IEntityRelation)GetRelationsForField("PaymentOrder")[0], (int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.PaymentOrderEntity, 0, null, null, null, null, "PaymentOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestOrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestOrderItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestOrderItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestOrderItem")[0], (int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.TestOrderItemEntity, 0, null, null, null, null, "TestOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChargeCard' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChargeCardCollectionViaChargeCardPayment
		{
			get
			{
				IEntityRelation intermediateRelation = PaymentEntity.Relations.ChargeCardPaymentEntityUsingPaymentId;
				intermediateRelation.SetAliases(string.Empty, "ChargeCardPayment_");
				return new PrefetchPathElement2(new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.ChargeCardEntity, 0, null, null, GetRelationsForField("ChargeCardCollectionViaChargeCardPayment"), null, "ChargeCardCollectionViaChargeCardPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Check' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckCollectionViaEcheckPayment
		{
			get
			{
				IEntityRelation intermediateRelation = PaymentEntity.Relations.EcheckPaymentEntityUsingPaymentId;
				intermediateRelation.SetAliases(string.Empty, "EcheckPayment_");
				return new PrefetchPathElement2(new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.CheckEntity, 0, null, null, GetRelationsForField("CheckCollectionViaEcheckPayment"), null, "CheckCollectionViaEcheckPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Check' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckCollectionViaCheckPayment
		{
			get
			{
				IEntityRelation intermediateRelation = PaymentEntity.Relations.CheckPaymentEntityUsingPaymentId;
				intermediateRelation.SetAliases(string.Empty, "CheckPayment_");
				return new PrefetchPathElement2(new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.CheckEntity, 0, null, null, GetRelationsForField("CheckCollectionViaCheckPayment"), null, "CheckCollectionViaCheckPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificateCollectionViaGiftCertificatePayment
		{
			get
			{
				IEntityRelation intermediateRelation = PaymentEntity.Relations.GiftCertificatePaymentEntityUsingPaymentId;
				intermediateRelation.SetAliases(string.Empty, "GiftCertificatePayment_");
				return new PrefetchPathElement2(new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.GiftCertificateEntity, 0, null, null, GetRelationsForField("GiftCertificateCollectionViaGiftCertificatePayment"), null, "GiftCertificateCollectionViaGiftCertificatePayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Order' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderCollectionViaPaymentOrder
		{
			get
			{
				IEntityRelation intermediateRelation = PaymentEntity.Relations.PaymentOrderEntityUsingPaymentId;
				intermediateRelation.SetAliases(string.Empty, "PaymentOrder_");
				return new PrefetchPathElement2(new EntityCollection<OrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.OrderEntity, 0, null, null, GetRelationsForField("OrderCollectionViaPaymentOrder"), null, "OrderCollectionViaPaymentOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderDetailCollectionViaTestOrderItem
		{
			get
			{
				IEntityRelation intermediateRelation = PaymentEntity.Relations.TestOrderItemEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "TestOrderItem_");
				return new PrefetchPathElement2(new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PaymentEntity, (int)Falcon.Data.EntityType.OrderDetailEntity, 0, null, null, GetRelationsForField("OrderDetailCollectionViaTestOrderItem"), null, "OrderDetailCollectionViaTestOrderItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PaymentEntity.CustomProperties;}
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
			get { return PaymentEntity.FieldsCustomProperties;}
		}

		/// <summary> The PaymentId property of the Entity Payment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPayment"."PaymentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 PaymentId
		{
			get { return (System.Int64)GetValue((int)PaymentFieldIndex.PaymentId, true); }
			set	{ SetValue((int)PaymentFieldIndex.PaymentId, value); }
		}

		/// <summary> The Notes property of the Entity Payment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPayment"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)PaymentFieldIndex.Notes, true); }
			set	{ SetValue((int)PaymentFieldIndex.Notes, value); }
		}

		/// <summary> The DateCreated property of the Entity Payment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPayment"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)PaymentFieldIndex.DateCreated, true); }
			set	{ SetValue((int)PaymentFieldIndex.DateCreated, value); }
		}

		/// <summary> The OrganizationRoleUserCreatorId property of the Entity Payment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPayment"."OrganizationRoleUserCreatorID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationRoleUserCreatorId
		{
			get { return (System.Int64)GetValue((int)PaymentFieldIndex.OrganizationRoleUserCreatorId, true); }
			set	{ SetValue((int)PaymentFieldIndex.OrganizationRoleUserCreatorId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CashPaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CashPaymentEntity))]
		public virtual EntityCollection<CashPaymentEntity> CashPayment
		{
			get
			{
				if(_cashPayment==null)
				{
					_cashPayment = new EntityCollection<CashPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CashPaymentEntityFactory)));
					_cashPayment.SetContainingEntityInfo(this, "Payment");
				}
				return _cashPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChargeCardPaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChargeCardPaymentEntity))]
		public virtual EntityCollection<ChargeCardPaymentEntity> ChargeCardPayment
		{
			get
			{
				if(_chargeCardPayment==null)
				{
					_chargeCardPayment = new EntityCollection<ChargeCardPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardPaymentEntityFactory)));
					_chargeCardPayment.SetContainingEntityInfo(this, "Payment");
				}
				return _chargeCardPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckPaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckPaymentEntity))]
		public virtual EntityCollection<CheckPaymentEntity> CheckPayment
		{
			get
			{
				if(_checkPayment==null)
				{
					_checkPayment = new EntityCollection<CheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckPaymentEntityFactory)));
					_checkPayment.SetContainingEntityInfo(this, "Payment");
				}
				return _checkPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EcheckPaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EcheckPaymentEntity))]
		public virtual EntityCollection<EcheckPaymentEntity> EcheckPayment
		{
			get
			{
				if(_echeckPayment==null)
				{
					_echeckPayment = new EntityCollection<EcheckPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EcheckPaymentEntityFactory)));
					_echeckPayment.SetContainingEntityInfo(this, "Payment");
				}
				return _echeckPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GiftCertificatePaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GiftCertificatePaymentEntity))]
		public virtual EntityCollection<GiftCertificatePaymentEntity> GiftCertificatePayment
		{
			get
			{
				if(_giftCertificatePayment==null)
				{
					_giftCertificatePayment = new EntityCollection<GiftCertificatePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificatePaymentEntityFactory)));
					_giftCertificatePayment.SetContainingEntityInfo(this, "Payment");
				}
				return _giftCertificatePayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InsurancePaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InsurancePaymentEntity))]
		public virtual EntityCollection<InsurancePaymentEntity> InsurancePayment
		{
			get
			{
				if(_insurancePayment==null)
				{
					_insurancePayment = new EntityCollection<InsurancePaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InsurancePaymentEntityFactory)));
					_insurancePayment.SetContainingEntityInfo(this, "Payment");
				}
				return _insurancePayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PaymentOrderEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PaymentOrderEntity))]
		public virtual EntityCollection<PaymentOrderEntity> PaymentOrder
		{
			get
			{
				if(_paymentOrder==null)
				{
					_paymentOrder = new EntityCollection<PaymentOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PaymentOrderEntityFactory)));
					_paymentOrder.SetContainingEntityInfo(this, "Payment");
				}
				return _paymentOrder;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestOrderItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestOrderItemEntity))]
		public virtual EntityCollection<TestOrderItemEntity> TestOrderItem
		{
			get
			{
				if(_testOrderItem==null)
				{
					_testOrderItem = new EntityCollection<TestOrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestOrderItemEntityFactory)));
					_testOrderItem.SetContainingEntityInfo(this, "Payment");
				}
				return _testOrderItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChargeCardEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChargeCardEntity))]
		public virtual EntityCollection<ChargeCardEntity> ChargeCardCollectionViaChargeCardPayment
		{
			get
			{
				if(_chargeCardCollectionViaChargeCardPayment==null)
				{
					_chargeCardCollectionViaChargeCardPayment = new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory)));
					_chargeCardCollectionViaChargeCardPayment.IsReadOnly=true;
				}
				return _chargeCardCollectionViaChargeCardPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckEntity))]
		public virtual EntityCollection<CheckEntity> CheckCollectionViaEcheckPayment
		{
			get
			{
				if(_checkCollectionViaEcheckPayment==null)
				{
					_checkCollectionViaEcheckPayment = new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory)));
					_checkCollectionViaEcheckPayment.IsReadOnly=true;
				}
				return _checkCollectionViaEcheckPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckEntity))]
		public virtual EntityCollection<CheckEntity> CheckCollectionViaCheckPayment
		{
			get
			{
				if(_checkCollectionViaCheckPayment==null)
				{
					_checkCollectionViaCheckPayment = new EntityCollection<CheckEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckEntityFactory)));
					_checkCollectionViaCheckPayment.IsReadOnly=true;
				}
				return _checkCollectionViaCheckPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GiftCertificateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GiftCertificateEntity))]
		public virtual EntityCollection<GiftCertificateEntity> GiftCertificateCollectionViaGiftCertificatePayment
		{
			get
			{
				if(_giftCertificateCollectionViaGiftCertificatePayment==null)
				{
					_giftCertificateCollectionViaGiftCertificatePayment = new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory)));
					_giftCertificateCollectionViaGiftCertificatePayment.IsReadOnly=true;
				}
				return _giftCertificateCollectionViaGiftCertificatePayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderEntity))]
		public virtual EntityCollection<OrderEntity> OrderCollectionViaPaymentOrder
		{
			get
			{
				if(_orderCollectionViaPaymentOrder==null)
				{
					_orderCollectionViaPaymentOrder = new EntityCollection<OrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory)));
					_orderCollectionViaPaymentOrder.IsReadOnly=true;
				}
				return _orderCollectionViaPaymentOrder;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderDetailEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderDetailEntity))]
		public virtual EntityCollection<OrderDetailEntity> OrderDetailCollectionViaTestOrderItem
		{
			get
			{
				if(_orderDetailCollectionViaTestOrderItem==null)
				{
					_orderDetailCollectionViaTestOrderItem = new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory)));
					_orderDetailCollectionViaTestOrderItem.IsReadOnly=true;
				}
				return _orderDetailCollectionViaTestOrderItem;
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
			get { return (int)Falcon.Data.EntityType.PaymentEntity; }
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
