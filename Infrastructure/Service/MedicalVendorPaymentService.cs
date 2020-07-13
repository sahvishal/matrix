using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Users.Repositories;

namespace Falcon.App.Infrastructure.Service
{
    public class MedicalVendorPaymentService : IMedicalVendorPaymentService
    {
        private readonly IMedicalVendorRepository _medicalVendorRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IMedicalVendorInvoiceItemRepository _medicalVendorInvoiceItemRepository;
        private readonly IMedicalVendorInvoiceFactory _medicalVendorInvoiceFactory;

        public MedicalVendorPaymentService()
            : this (new MedicalVendorRepository(), new PhysicianRepository(), 
                new MedicalVendorInvoiceItemRepository(), new MedicalVendorInvoiceFactory())
        {}

        public MedicalVendorPaymentService(IMedicalVendorRepository medicalVendorRepository,
            IPhysicianRepository physicianRepository, 
            IMedicalVendorInvoiceItemRepository medicalVendorInvoiceItemRepository,
            IMedicalVendorInvoiceFactory medicalVendorInvoiceFactory)
        {
            _medicalVendorRepository = medicalVendorRepository;
            _physicianRepository = physicianRepository;
            _medicalVendorInvoiceItemRepository = medicalVendorInvoiceItemRepository;
            _medicalVendorInvoiceFactory = medicalVendorInvoiceFactory;
        }

        public List<PhysicianInvoice> GenerateInvoicesForMedicalVendor(long medicalVendorId, DateTime payPeriodStartDate,
            DateTime payPeriodEndDate)
        {
            var organizationRoleUserIds = _physicianRepository.GetAllPhysicianIdsforaMedicalVendor(medicalVendorId);

            var medicalVendorInvoices = new List<PhysicianInvoice>();
            foreach (long organizationRoleUserId in organizationRoleUserIds)
            {
                PhysicianInvoice medicalVendorInvoice = GenerateInvoice(medicalVendorId,
                    organizationRoleUserId, payPeriodStartDate, payPeriodEndDate);
                if (medicalVendorInvoice != null)
                {
                    medicalVendorInvoices.Add(medicalVendorInvoice);
                }
            }
            return medicalVendorInvoices;
        }

        public PhysicianInvoice GenerateInvoice(long medicalVendorId, long physicianId, 
            DateTime payPeriodStartDate, DateTime payPeriodEndDate)
        {
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemRepository.
                GetMedicalVendorInvoiceItems(physicianId, payPeriodStartDate, payPeriodEndDate);
            if (medicalVendorInvoiceItems.IsEmpty())
            {
                return null;
            }
            Physician physician =
                _physicianRepository.GetPhysician(physicianId);
            MedicalVendor medicalVendor = _medicalVendorRepository.GetMedicalVendor(medicalVendorId);

            return _medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice(medicalVendor, 
                physician, medicalVendorInvoiceItems, payPeriodStartDate, payPeriodEndDate);
        }
    }
}