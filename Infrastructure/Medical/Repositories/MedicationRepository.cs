using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;
using Falcon.App.Core.Medicare.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class MedicationRepository : PersistenceRepository, IMedicationRepository
    {
        private readonly ISettings _settings;

        public MedicationRepository(ISettings settings)
        {
            _settings = settings;
        }

        public Medication SaveMedication(Medication domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Medication, MedicationEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Medication");

                return Mapper.Map<MedicationEntity, Medication>(entity);
            }
        }

        public IEnumerable<Medication> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.Medication
                              where h.CustomerId == customerId && h.IsActive
                              select h).ToArray();


                return Mapper.Map<IEnumerable<MedicationEntity>, IEnumerable<Medication>>(entity);
            }
        }

        /// <summary>
        /// Used only for sync , do not use it.
        /// </summary>
        /// <param name="lastMaxIdColumn"></param>
        /// /// <param name="customerId"></param>
        /// <returns>List of Medication with isSynced false and DateCreated cutoff date (configurable)</returns>
        public IEnumerable<Medication> GetMedicationForSync(long lastMaxIdColumn, long? customerId = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.Medication
                              where h.IsSynced == false
                              && h.DateCreated.Date >= DateTime.Today.AddDays(-_settings.CustomerForMedicationSyncCutoffDays).Date
                              && h.Id > lastMaxIdColumn
                              && (customerId == null || h.CustomerId == customerId)
                              orderby h.Id
                              select h).Take(100).ToArray();

                return Mapper.Map<IEnumerable<MedicationEntity>, IEnumerable<Medication>>(entity);
            }
        }

        public IEnumerable<Medication> GetByCustomerIdAndServiceDate(long customerId, DateTime serviceDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.Medication
                              where h.CustomerId == customerId && h.ServiceDate >= serviceDate && h.ServiceDate < serviceDate.AddDays(1)
                              && h.IsActive
                              select h).ToArray();

                return Mapper.Map<IEnumerable<MedicationEntity>, IEnumerable<Medication>>(entity);
            }
        }

        public void SaveMedications(IEnumerable<Medication> domainList, long orgRoleUserId)
        {
            foreach (var medication in domainList)
            {
                medication.DateCreated = DateTime.Now;
                medication.CreatedBy = orgRoleUserId;
                SaveMedication(medication);
            }
        }

        public void UpdateMedications(IEnumerable<Medication> models, long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                foreach (var medication in models)
                {
                    var entity = new MedicationEntity();
                    entity.ProprietaryName = medication.ProprietaryName;
                    entity.ServiceDate = medication.ServiceDate;
                    entity.Dose = medication.Dose;
                    entity.Unit = medication.Unit;
                    entity.Frequency = medication.Frequency;
                    entity.IsPrescribed = medication.IsPrescribed;
                    entity.IsOtc = medication.IsOtc;
                    entity.Indication = medication.Indication;
                    entity.ModifiedBy = orgRoleUserId;
                    entity.DateModified = DateTime.Now;
                    entity.IsSynced = medication.IsSynced;
                    //entity.IsManual = medication.IsManual;

                    var relationPredicateBucket = new RelationPredicateBucket((MedicationFields.Id == medication.Id));
                    adapter.UpdateEntitiesDirectly(entity, relationPredicateBucket);
                }
            }
        }

        public void MarkForDelete(long customerId, long orgRoleUserId, long[] medicationIdNotToDelete)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var medicationIds = (from h in linqMetaData.Medication
                                     where h.CustomerId == customerId //&& h.ServiceDate >= serviceDate && h.ServiceDate < serviceDate.AddDays(1)
                                     && !medicationIdNotToDelete.Contains(h.Id)
                                     select h.Id).ToArray();

                var relationPredicateBucket = new RelationPredicateBucket((MedicationFields.Id == medicationIds));
                adapter.UpdateEntitiesDirectly(new MedicationEntity { IsActive = false, DateModified = DateTime.Now, ModifiedBy = orgRoleUserId }, relationPredicateBucket);
            }
        }

    }
}
