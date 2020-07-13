using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class MedicalVendorMedicalVendorUserFactory : IMedicalVendorMedicalVendorUserFactory
    {
        public MedicalVendorMedicalVendorUser CreateMedicalVendorMedicalVendorUser(MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow)
        {
            if (medicalVendorInvoiceItemRow == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItemRow");
            }
            return CreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow.OrganizationRoleUserId, 
                medicalVendorInvoiceItemRow.FirstName, medicalVendorInvoiceItemRow.MiddleName, medicalVendorInvoiceItemRow.LastName);
        }

        public MedicalVendorMedicalVendorUser CreateMedicalVendorMedicalVendorUser(long medicalVendorMedicalVendorUserId, UserEntity userEntity)
        {
            if (userEntity == null)
            {
                throw new ArgumentNullException("userEntity");
            }
            return CreateMedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUserId, userEntity.FirstName,
                userEntity.MiddleName, userEntity.LastName);
        }

        public MedicalVendorMedicalVendorUser CreateMedicalVendorMedicalVendorUser(long medicalVendorMedicalVendorUserId, 
            string firstName, string middleName, string lastName)
        {
            return new MedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUserId)
            {
                Name = new Name(firstName, middleName, lastName)
            };
        }

        public MedicalVendorMedicalVendorUser CreateMedicalVendorMedicalVendorUser(MedicalVendorMedicalVendorUserRow 
            medicalVendorMedicalVendorUserRow)
        {
            if (medicalVendorMedicalVendorUserRow == null)
            {
                throw new ArgumentNullException("medicalVendorMedicalVendorUserRow");
            }
            return new MedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUserRow.OrganizationRoleUserId)
            {
                MedicalVendorId = medicalVendorMedicalVendorUserRow.OrganizationId,
                MedicalVendorName = medicalVendorMedicalVendorUserRow.MedicalVendorName,
                Name = new Name(medicalVendorMedicalVendorUserRow.FirstName, medicalVendorMedicalVendorUserRow.MiddleName, 
                    medicalVendorMedicalVendorUserRow.LastName),
                RoleName = medicalVendorMedicalVendorUserRow.RoleName
            };
        }

        public List<MedicalVendorMedicalVendorUser> CreateMedicalVendorMedicalVendorUsers
            (MedicalVendorMedicalVendorUserTypedView medicalVendorMedicalVendorUserTypedView)
        {
            if (medicalVendorMedicalVendorUserTypedView == null)
            {
                throw new ArgumentNullException("medicalVendorMedicalVendorUserTypedView");
            }
            var medicalVendorMedicalVendorUsers = new List<MedicalVendorMedicalVendorUser>();
            foreach (var medicalVendorMedicalVendorUserRow in medicalVendorMedicalVendorUserTypedView)
            {
                medicalVendorMedicalVendorUsers.Add(CreateMedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUserRow));
            }
            return medicalVendorMedicalVendorUsers;
        }
    }
}