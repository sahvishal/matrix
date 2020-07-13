using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using System.Data;
using IPaymentInstrumentRepository = Falcon.App.Core.Finance.IPaymentInstrumentRepository;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MedicalVendorPaymentRepository : PersistenceRepository, IMedicalVendorPaymentRepository
    {
        private readonly IMapper<MedicalVendorPayment, PhysicianPaymentEntity> _mapper;
        private readonly IPaymentInstrumentRepository _paymentInstrumentRepository;
        private readonly IValidator<MedicalVendorPayment> _validator;

        public MedicalVendorPaymentRepository()
            : this (new SqlPersistenceLayer(), 
            new CombinedPaymentInstrumentRepository(),
            new Validator<MedicalVendorPayment>(new MedicalVendorPaymentValidationRuleFactory()),
            new MedicalVendorPaymentMapper(new DataRecorderMetaDataFactory()))
        { }

        public MedicalVendorPaymentRepository(IPersistenceLayer persistenceLayer,     
            IPaymentInstrumentRepository paymentInstrumentRepository, 
            IValidator<MedicalVendorPayment> validator, 
            IMapper<MedicalVendorPayment, PhysicianPaymentEntity> mapper)
            : base(persistenceLayer)
        {
            _paymentInstrumentRepository = paymentInstrumentRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public MedicalVendorPayment GetMedicalVendorPayment(int medicalVendorPaymentId)
        {
            var physicianPaymentEntity = new PhysicianPaymentEntity(medicalVendorPaymentId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.FetchEntity(physicianPaymentEntity))
                {
                    throw new ObjectNotFoundInPersistenceException<MedicalVendorPayment>
                        (medicalVendorPaymentId);
                }
            }
            var paymentInstruments = _paymentInstrumentRepository.
                GetPaymentInstrumentsForPayment(medicalVendorPaymentId);
            MedicalVendorPayment medicalVendorPayment = _mapper.Map(physicianPaymentEntity);
            medicalVendorPayment.PaymentInstruments = paymentInstruments;
            return medicalVendorPayment;
        }

        public void MakePayment(MedicalVendorPayment medicalVendorPayment, List<long>     
            medicalVendorInvoiceIdsToApplyPaymentTo)
        {
            if (medicalVendorPayment == null)
            {
                throw new ArgumentNullException("medicalVendorPayment");
            }
            if (medicalVendorInvoiceIdsToApplyPaymentTo == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceIdsToApplyPaymentTo");
            }
            if (medicalVendorPayment.PaymentInstruments.Count == 0 ||
                medicalVendorInvoiceIdsToApplyPaymentTo.Count == 0)
            {
                throw new EmptyCollectionException();
            }

            if (!_validator.IsValid(medicalVendorPayment))
            {
                throw new InvalidObjectException<MedicalVendorPayment>(_validator);
            }

            PhysicianPaymentEntity medicalVendorPaymentEntity = _mapper.Map(medicalVendorPayment);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.StartTransaction(IsolationLevel.ReadCommitted, 
                    "MedicalVendorPaymentRepository.MakePayment");
                try
                {
                    // Persist payment.
                    if (!myAdapter.SaveEntity(medicalVendorPaymentEntity, true))
                    {
                        throw new PersistenceFailureException();
                    }

                    // Persist payment instrument(s) & associate with payment.
                    foreach (Check check in medicalVendorPayment.PaymentInstruments)
                    {
                        long? dataRecoderModifierId = null;
                        if (check.DataRecorderMetaData.DataRecorderModifier != null)
                        {
                            dataRecoderModifierId = check.DataRecorderMetaData.DataRecorderModifier.Id;
                        }
                        var checkEntity = new CheckEntity
                        {
                            AccountNumber = check.AccountNumber,
                            CheckNumber = check.CheckNumber,
                            RoutingNumber = check.RoutingNumber,
                            BankName = check.BankName,
                            Memo = check.Memo,
                            DataRecoderCreatorId = check.DataRecorderMetaData.DataRecorderCreator.Id,
                            DateCreated = check.DataRecorderMetaData.DateCreated,
                            DataRecoderModifierId = dataRecoderModifierId,
                            DateModified = check.DataRecorderMetaData.DateModified,
                            Amount = check.Amount,
                            PayableTo = check.PayableTo,
                            CheckDate = check.CheckDate
                        };
                        if (!myAdapter.SaveEntity(checkEntity, true))
                        {
                            throw new PersistenceFailureException();
                        }
                        var paymentCheckDetailEntity = new MVPaymentCheckDetailsEntity(checkEntity.CheckId,
                            medicalVendorPaymentEntity.PhysicianPaymentId);
                        if (!myAdapter.SaveEntity(paymentCheckDetailEntity))
                        {
                            throw new PersistenceFailureException();
                        }
                    }

                    // Associate payment with invoice(s).
                    long medicalVendorPaymentId = medicalVendorPaymentEntity.PhysicianPaymentId;
                    var medicalVendorPaymentInvoiceEntities = 
                        new EntityCollection<PhysicianPaymentInvoiceEntity>();
                    foreach (var medicalVendorInvoiceId in medicalVendorInvoiceIdsToApplyPaymentTo)
                    {
                        medicalVendorPaymentInvoiceEntities.Add(new PhysicianPaymentInvoiceEntity
                            (medicalVendorPaymentId, medicalVendorInvoiceId));
                    }
                    myAdapter.SaveEntityCollection(medicalVendorPaymentInvoiceEntities);
                    myAdapter.Commit();
                }
                catch (Exception)
                {
                    myAdapter.Rollback();
                    throw;
                }
            }
        }
    }
}