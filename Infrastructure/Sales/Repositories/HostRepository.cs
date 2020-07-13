using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Factories.Hosts;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Sales.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation(Interface = typeof(IHostRepository))]
    public class HostRepository : PersistenceRepository, IHostRepository
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IHostFactory _hostFactory;

        public HostRepository()
            : this(new AddressRepository(), new HostFactory())
        { }

        public HostRepository(IAddressRepository addressRepository, IHostFactory hostFactory)
        {
            _addressRepository = addressRepository;
            _hostFactory = hostFactory;
        }

        public List<RegistrationMode> GetEventTypesForHost(long hostId)
        {
            IEnumerable<long> eventTypeIds;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                eventTypeIds = linqMetaData.EventType.
                    Join(linqMetaData.Events, et => et.EventTypeId, e => e.EventTypeId, (et, e) => new { et, e }).
                    Join(linqMetaData.HostEventDetails, @a => @a.e.EventId, hed => hed.EventId, (@a, hed) => new { @a, hed }).
                    Where(@b => @b.hed.HostId == hostId).Distinct().
                    Select(@b => @b.@a.et.EventTypeId).ToList();
            }
            return eventTypeIds.Select(eti => (RegistrationMode)eti).ToList();
        }

        public Host GetHostForEvent(long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var prospects =
                    from p in
                        linqMetaData.Prospects.WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails))
                    join hostEvent in linqMetaData.HostEventDetails on p.ProspectId equals
                        hostEvent.HostId
                    where eventId == hostEvent.EventId
                    select p;

                var prospect = prospects.SingleOrDefault();

                if (prospect == null)
                    throw new ObjectNotFoundInPersistenceException<Host>();

                if (!prospect.AddressId.HasValue)
                    throw new InvalidAddressException("Address", "HostAddress");

                var address = _addressRepository.GetAddress(prospect.AddressId.Value);
                var mailingAddress = prospect.AddressIdmailling.HasValue ? _addressRepository.GetAddress(prospect.AddressIdmailling.Value) : null;

                return _hostFactory.CreateHost(prospect, address, mailingAddress);
            }
        }

        public List<Host> GetEventHosts(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var prospects =
                    (from prospect in
                         linqMetaData.Prospects.WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails))
                     join hostEvent in linqMetaData.HostEventDetails on prospect.ProspectId equals
                         hostEvent.HostId
                     where eventIds.Contains(hostEvent.EventId)
                     select prospect).ToArray();

                var addresses = _addressRepository.GetAddresses(prospects.Where(p => p.AddressId.HasValue).Select(p => p.AddressId.Value).ToList());
                var mailingAddresses = _addressRepository.GetAddresses(prospects.Where(p => p.AddressIdmailling.HasValue).Select(p => p.AddressIdmailling.Value).ToList());

                return _hostFactory.CreateHosts(prospects.ToList(), addresses, mailingAddresses);
            }
        }

        public bool UpdateHostTaxIdNumber(long hostId, string taxIdNumber)
        {
            var host = new ProspectsEntity(hostId) { TaxIdNumber = taxIdNumber };
            IRelationPredicateBucket relationPredicateBucket =
                new RelationPredicateBucket(ProspectsFields.ProspectId == hostId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(host, relationPredicateBucket) > 0;
            }
        }

        public string GetTaxIdNumber(long hostId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var taxIdNumber =
                    linqMetaData.Prospects.Where(prospect => prospect.ProspectId == hostId && prospect.IsHost == true).
                        SingleOrDefault().TaxIdNumber;
                return taxIdNumber;
            }
        }

        public OrderedPair<string, string> GetCallCenterandTechnicianNotesforgivenHost(long hostId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return (from notes in linqMetaData.HostNotes
                        where notes.HostId == hostId
                        select
                            new OrderedPair<string, string>(notes.CallCenterInstructions,
                                                            notes.TechnicianInstructions)).FirstOrDefault();
            }
        }

        public bool SaveHostImages(long hostId, List<HostImage> hostImages)
        {
            EntityCollection<FileEntity> fileEntities = new EntityCollection<FileEntity>();

            hostImages.ForEach(hostImage =>
                {
                    var hostImageEntities = new EntityCollection<HostImageEntity>();
                    hostImageEntities.Add(new HostImageEntity()
                    {
                        HostId = hostId,
                        IsNew = true,
                        HostImageType = hostImage.ImageType.PersistenceLayerId
                    });

                    // TODO: To move this code in the mapper class. Currently in QA branch, will do in main trunk.
                    fileEntities.Add(new FileEntity(0)
                    {
                        Path = hostImage.Path,
                        Size = hostImage.FileSize,
                        Type = (long)hostImage.Type,
                        CreatedDate = DateTime.Now,
                        CreatedBy = hostImage.UploadedBy.Id,
                        IsNew = true
                    });

                    fileEntities.Last().HostImage.AddRange(hostImageEntities);
                });

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (myAdapter.SaveEntityCollection(fileEntities, false, true) <= 0)
                {
                    throw new PersistenceFailureException();
                }
            }

            return true;
        }

        public bool UpdateHostImages(long hostId, List<HostImage> hostImages)
        {
            bool isSucceeded = false;
            hostImages.ForEach(hostImage =>
            {
                var hostImageEntity = new HostImageEntity() { HostImageType = hostImage.ImageType.PersistenceLayerId };

                IRelationPredicateBucket relationPredicateBucket =
                    new RelationPredicateBucket(HostImageFields.HostId == hostId);

                relationPredicateBucket.PredicateExpression.AddWithAnd(HostImageFields.ImageId == hostImage.Id);

                using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    isSucceeded = myAdapter.UpdateEntitiesDirectly(hostImageEntity, relationPredicateBucket) > 0;
                }
            });

            return isSucceeded;
        }

        public List<HostImage> GetHostImages(long hostId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var listHostImages = linqMetaData.HostImage.WithPath(prefetchPath => prefetchPath.Prefetch(hostImage => hostImage.File)).
                    Where(hostImage => hostImage.HostId == hostId).ToList();

                // TODO: To be moved in the host factory, when setting the Host Domain Object
                var hostImages = new List<HostImage>();
                if (listHostImages != null && listHostImages.Count > 0)
                {
                    listHostImages.ForEach(hostImageEntity =>
                    {
                        var fileEntity = hostImageEntity.File;

                        hostImages.Add(new HostImage(hostImageEntity.ImageId)
                        {
                            Path = fileEntity.Path,
                            UploadedBy = new OrganizationRoleUserRepository().GetOrganizationRoleUser(fileEntity.CreatedBy),
                            UploadedOn = fileEntity.CreatedDate,
                            ImageType = HostImageType.HostImageTypes.Find(imageType => imageType.PersistenceLayerId == hostImageEntity.HostImageType)
                        });
                    });
                }
                return hostImages;
            }
        }

        public bool DeleteHostImages(long hostId, List<long> imageIds)
        {
            IRelationPredicateBucket relationPredicateBucketHostImages =
                new RelationPredicateBucket(HostImageFields.HostId == hostId);

            relationPredicateBucketHostImages.PredicateExpression.AddWithAnd(HostImageFields.ImageId == imageIds);

            bool isSucceeded = false;

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                isSucceeded = myAdapter.DeleteEntitiesDirectly(typeof(HostImageEntity), relationPredicateBucketHostImages) > 0;
            }

            if (isSucceeded)
            {
                IRelationPredicateBucket relationPredicateBucketFile =
                    new RelationPredicateBucket(FileFields.FileId == imageIds);

                using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    isSucceeded = myAdapter.DeleteEntitiesDirectly(typeof(FileEntity), relationPredicateBucketFile) > 0;
                }
            }

            return isSucceeded;
        }

        public IEnumerable<string> GetScreenedEventHostNames(string prefixText)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return
                    (from e in linqMetaData.Events
                     join he in linqMetaData.HostEventDetails on e.EventId equals he.EventId
                     join p in linqMetaData.Prospects on he.HostId equals p.ProspectId
                     where p.OrganizationName.Contains(prefixText)
                     select p.OrganizationName
                    ).ToArray();
            }
        }

        public Host GetHostById(long id)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var prospect =
                    (from p in linqMetaData.Prospects
                     where p.ProspectId == id
                     select p).SingleOrDefault();

                if (prospect == null)
                    throw new ObjectNotFoundInPersistenceException<Host>();

                if (!prospect.AddressId.HasValue)
                    throw new InvalidAddressException("Address", "HostAddress");

                var address = _addressRepository.GetAddress(prospect.AddressId.Value);
                var mailingAddress = prospect.AddressIdmailling.HasValue && prospect.AddressIdmailling.Value > 0 ? _addressRepository.GetAddress(prospect.AddressIdmailling.Value) : null;

                return _hostFactory.CreateHost(prospect, address, mailingAddress);
            }
        }

        public Host GetProspectById(long id)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var prospect =
                    (from p in linqMetaData.Prospects
                     where p.ProspectId == id
                     select p).SingleOrDefault();

                if (prospect == null)
                    throw new ObjectNotFoundInPersistenceException<Host>();


                var mailingAddress = prospect.AddressIdmailling.HasValue && prospect.AddressIdmailling.Value > 0 ? _addressRepository.GetAddress(prospect.AddressIdmailling.Value) : null;

                return _hostFactory.CreateHost(prospect, null, mailingAddress);
            }
        }

        public Host CreateHost(Host host)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = _hostFactory.CreateHostEntity(host);
                adapter.SaveEntity(entity, true);
                if (host.Id <= 0)
                {
                    var prospectDetailEntity = new ProspectDetailsEntity
                                                   {
                                                       ProspectId = entity.ProspectId,
                                                       IsActive = true,
                                                       DateCreated = DateTime.Now
                                                   };
                    adapter.SaveEntity(prospectDetailEntity);
                }
                host.Id = entity.ProspectId;
                return host;
            }
        }

        public bool DeleteHost(long hostId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(ProspectDetailsFields.ProspectId == hostId);
                adapter.DeleteEntitiesDirectly("ProspectDetailsEntity", bucket);

                bucket = new RelationPredicateBucket(ProspectsFields.ProspectId == hostId);
                return adapter.DeleteEntitiesDirectly("ProspectsEntity", bucket) > 0 ? true : false;
            }
        }

        public bool IsHostAttachedWithEvent(long hostId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from hed in linqMetaData.HostEventDetails where hed.HostId == hostId select hed.EventId).Any();

            }
        }

        public List<Host> SearchHostByName(string name)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var prospects =
                     (from p in linqMetaData.Prospects
                      where p.OrganizationName.Contains(name) && p.IsHost == true
                      select p);
                var hostList = new List<Host>();
                foreach (var prospectsEntity in prospects)
                {
                    var prospect = _hostFactory.CreateHost(prospectsEntity, null, null);
                    hostList.Add(prospect);
                }
                return hostList;
            }
        }

        public List<Host> SearchProspectByName(string name)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var prospects =
                    (from p in linqMetaData.Prospects
                     where p.OrganizationName.Contains(name) && p.IsHost == false
                     select p);
                var hostList = new List<Host>();
                foreach (var prospectsEntity in prospects)
                {
                    var prospect = _hostFactory.CreateHost(prospectsEntity, null, null);
                    hostList.Add(prospect);
                }
                return hostList;
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetHostZipId(IEnumerable<long> hostIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from p in linqMetaData.Prospects
                        join a in linqMetaData.Address on p.AddressId equals a.AddressId
                        join z in linqMetaData.Zip on a.ZipId equals z.ZipId
                        where hostIds.Contains(p.ProspectId)
                        select new OrderedPair<long, long>(p.ProspectId, z.ZipId)).ToArray();
            }
        }


        public List<Host> GetEventHostByHostIds(IEnumerable<long> hostIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var prospects =
                    (from prospect in linqMetaData.Prospects.WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails))
                     where hostIds.Contains(prospect.ProspectId)
                     select prospect).ToArray();

                var addresses = _addressRepository.GetAddresses(prospects.Where(p => p.AddressId.HasValue).Select(p => p.AddressId.Value).ToList());
                var mailingAddresses = _addressRepository.GetAddresses(prospects.Where(p => p.AddressIdmailling.HasValue).Select(p => p.AddressIdmailling.Value).ToList());

                return _hostFactory.CreateHosts(prospects.ToList(), addresses, mailingAddresses);
            }
        }

        public IEnumerable<Host> GetHostsForFutureHealthPlanEvents(long accountId, DateTime fromDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var healthPlanEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == accountId select ea.EventId);

                var prospects = (from h in linqMetaData.Prospects
                                 join eh in linqMetaData.HostEventDetails on h.ProspectId equals eh.HostId
                                 join e in linqMetaData.Events on eh.EventId equals e.EventId
                                 where healthPlanEventIds.Contains(e.EventId)
                                 && e.EventDate >= fromDate
                                 && e.IsActive && e.EventStatus == (long)EventStatus.Active
                                 select h);

                var addresses = _addressRepository.GetAddresses(prospects.Where(p => p.AddressId.HasValue).Select(p => p.AddressId.Value).ToList());
                var mailingAddresses = _addressRepository.GetAddresses(prospects.Where(p => p.AddressIdmailling.HasValue).Select(p => p.AddressIdmailling.Value).ToList());

                return _hostFactory.CreateHosts(prospects.ToList(), addresses, mailingAddresses);
            }
        }
    }
}