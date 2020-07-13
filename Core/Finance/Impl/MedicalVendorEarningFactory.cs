using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Finance.Impl
{
    public class MedicalVendorEarningFactory : IMedicalVendorEarningFactory
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public MedicalVendorEarningFactory()
            : this(new DataRecorderMetaDataFactory())
        {}

        public MedicalVendorEarningFactory(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        public MedicalVendorEarning CreateMedicalVendorEarning(MedicalVendorEarningAggregate 
            medicalVendorEarningAggregate, long dataRecorderCreatorId, DateTime dateCreated)
        {
            if (medicalVendorEarningAggregate == null)
            {
                throw new ArgumentNullException("medicalVendorEarningAggregate");
            }

            return new MedicalVendorEarning
            {
                OrganizationRoleUserId = medicalVendorEarningAggregate.MedicalVendorMedicalVendorUserId,
                MedicalVendorUserEventTestLockId = medicalVendorEarningAggregate.
                MedicalVendorUserEventTestLockId,
                MedicalVendorUserAmountEarned = medicalVendorEarningAggregate.
                MedicalVendorMedicalVendorUserAmountEarned,
                DataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(dataRecorderCreatorId, dateCreated),
            };
        }
    }
}