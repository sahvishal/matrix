using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    public class EventStaffAssignmentService : IEventStaffAssignmentService
    {
        private readonly IEventStaffAssignmentRepository _eventStaffAssignmentRepository;
        private readonly IRepository<EventStaffAssignment> _repository;
        private readonly IPodStaffAssignmentRepository _podStaffAssignmentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventRoleRepository _eventRoleRepository;
        private readonly IStaffEventScheduleUploadRepository _staffEventScheduleUploadRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IStaffEventScheduleUploadListModelFactory _staffEventScheduleUploadListModelFactory;
        private readonly IPodRepository _podRepository;
        private readonly ISessionContext _sessionContext;
        private readonly ISystemUserInfoRepository _systemUserInfoRepository;

        public EventStaffAssignmentService(
                                           IEventStaffAssignmentRepository eventStaffAssignmentRepository,
                                           IRepository<EventStaffAssignment> repository,
                                           IPodStaffAssignmentRepository podStaffAssignmentRepository,
                                           IOrganizationRoleUserRepository organizationRoleUserRepository,
                                           IEventRoleRepository eventRoleRepository, IStaffEventScheduleUploadRepository staffEventScheduleUploadRepository,
                                           IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository,
                                           IStaffEventScheduleUploadListModelFactory staffEventScheduleUploadListModelFactory,
                                           IPodRepository podRepository, ISessionContext sessionContext, ISystemUserInfoRepository systemUserInfoRepository)
        {

            _eventStaffAssignmentRepository = eventStaffAssignmentRepository;
            _repository = repository;
            _podStaffAssignmentRepository = podStaffAssignmentRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventRoleRepository = eventRoleRepository;
            _staffEventScheduleUploadRepository = staffEventScheduleUploadRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _staffEventScheduleUploadListModelFactory = staffEventScheduleUploadListModelFactory;
            _podRepository = podRepository;
            _sessionContext = sessionContext;
            _systemUserInfoRepository = systemUserInfoRepository;
        }


        public EventStaffAssignmentEditModel Save(EventStaffAssignmentEditModel eventStaffAssignmentEditModel)
        {

            var eventStaff = eventStaffAssignmentEditModel.EventStaffAssignements;
            var savedAssignments = AssignStaffToEvent(eventStaffAssignmentEditModel.Event.Id, eventStaffAssignmentEditModel.Event.Pods.First().FirstValue, eventStaffAssignmentEditModel.ScheduledByOrgRoleId, eventStaff);
            eventStaffAssignmentEditModel.EventStaffAssignements = Mapper.Map<List<EventStaffAssignment>, IEnumerable<EventStaffBasicInfoModel>>(savedAssignments);
            return eventStaffAssignmentEditModel;

        }

        public void Save(long eventId, long podId, long scheduledByOrgRoleId, IEnumerable<EventStaffBasicInfoModel> eventStaff)
        {
            AssignStaffToEvent(eventId, podId, scheduledByOrgRoleId, eventStaff);
        }

        private List<EventStaffAssignment> AssignStaffToEvent(long eventId, long podId, long assignedByOrgRoleId, IEnumerable<EventStaffBasicInfoModel> eventStaff)
        {
            var savedAssignments = new List<EventStaffAssignment>();
            _eventStaffAssignmentRepository.DeleteFor(eventId);
            foreach (var staffAssignment in eventStaff)
            {
                var eventStaffAssignment = Mapper.Map<EventStaffBasicInfoModel, EventStaffAssignment>(staffAssignment);
                if (eventStaffAssignment.ActualStaffOrgRoleUserId <= 0)
                    eventStaffAssignment.ActualStaffOrgRoleUserId = null;
                eventStaffAssignment.EventId = eventId;
                eventStaffAssignment.PodId = podId; //is this right, why are we saving pod with event assignment, maybe assigned to differnt pod?   
                eventStaffAssignment.DataRecorderMetaData = new DataRecorderMetaData(assignedByOrgRoleId, DateTime.Now, null);
                savedAssignments.Add(_repository.Save(eventStaffAssignment));
            }
            return savedAssignments;
        }

        public IEnumerable<EventStaffBasicInfoModel> GetEventStaffBasicInfoModel(long eventId, IEnumerable<OrderedPair<long, string>> eventPods, IEnumerable<EventStaffAssignment> eventStaffAssignments,
            IEnumerable<StaffEventRole> eventRoles, IEnumerable<PodStaff> podsStaffs, out bool isDefault)
        {
            bool isDef = false;

            var output = eventPods.SelectMany(x =>
            {
                var orgRoleUserIdEventRoles = eventStaffAssignments.Where(m => m.PodId == x.FirstValue).Select(m => new OrderedPair<long, long>(m.ScheduledStaffOrgRoleUserId, m.StaffEventRoleId));

                if (orgRoleUserIdEventRoles.Count() < 1)
                {
                    var defaultStaffAssignments = podsStaffs.Where(ps => ps.PodId == x.FirstValue).Select(ps => ps).ToArray();
                    orgRoleUserIdEventRoles = defaultStaffAssignments.Select(dsa => new OrderedPair<long, long>(dsa.OrganizationRoleUserId, dsa.EventRoleId));

                    isDef = true;

                    if (orgRoleUserIdEventRoles.Count() < 1) return new List<EventStaffBasicInfoModel>();
                }

                return GetStaffBasicModels(orgRoleUserIdEventRoles, eventRoles, x.FirstValue);
            }).ToArray();

            isDefault = isDef; // Assigned in predicate for select many, which executes here only. 
            // Had to do this because compiler doesn't allow out params to be assigned in anonymus methods

            return output;
        }

        private IEnumerable<EventStaffBasicInfoModel> GetStaffBasicModels(IEnumerable<OrderedPair<long, long>> orgRoleUserIdEventRoles, IEnumerable<StaffEventRole> eventRoles, long podId)
        {
            IEnumerable<OrderedPair<long, string>> nameIdPairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIdEventRoles.Select(x => x.FirstValue).ToArray());

            IEnumerable<OrderedPair<long, string>> idEmployeeIdPairs = _systemUserInfoRepository.GetIdEmployeeIdPairofUsers(orgRoleUserIdEventRoles.Select(x => x.FirstValue).ToArray());
            return orgRoleUserIdEventRoles.Select(oru =>
            {
                var fullName = nameIdPairs.Where(x => x.FirstValue == oru.FirstValue).First().SecondValue;
                var idEmployeeIdPair = idEmployeeIdPairs.FirstOrDefault(x => x.FirstValue == oru.FirstValue);
                return new EventStaffBasicInfoModel
                {
                    PodId = podId,
                    ScheduledStaffOrgRoleUserId = oru.FirstValue,
                    FullName = fullName,
                    EventRoleId = oru.SecondValue,
                    EventRole = eventRoles.Where(er => er.Id == oru.SecondValue).Select(er => er.Name).First(),
                    EmployeeId = idEmployeeIdPair != null ? idEmployeeIdPair.SecondValue : ""
                };
            }).ToArray();

        }

        public void SavePodDefaultTeamToEventStaff(long eventId, List<long> podIds, long scheduledByOrgRoleId)
        {
            var eventRoles = _eventRoleRepository.GetAllActiveRoles();
            var eventStaff = _eventStaffAssignmentRepository.GetForEvent(eventId);
            if (eventStaff != null && eventStaff.Count() > 0)
            {
                var removedPodIds = eventStaff.Where(es => !podIds.Contains(es.PodId)).Select(es => es.PodId).Distinct().ToList();
                if (removedPodIds.Count > 0)
                {
                    foreach (var podId in removedPodIds)
                    {
                        _eventStaffAssignmentRepository.DeleteFor(eventId, podId);
                    }
                }

                var currentPodIds = eventStaff.Select(es => es.PodId).Distinct().ToList();
                var newPodIds = podIds.Where(p => !currentPodIds.Contains(p)).Select(p => p).ToList();
                if (newPodIds.Count > 0)
                {
                    foreach (var newPodId in newPodIds)
                    {
                        var defaultStaffAssignments = _podStaffAssignmentRepository.GetPodSatff(newPodId);
                        var eventStaffBasicinfo = GetStaffBasicModels(defaultStaffAssignments.Select(dsa => new OrderedPair<long, long>(dsa.OrganizationRoleUserId, dsa.EventRoleId)), eventRoles, newPodId);
                        Save(eventId, newPodId, scheduledByOrgRoleId, eventStaffBasicinfo);
                    }
                }
            }
            else
            {
                if (podIds.Count > 0)
                {
                    foreach (var podId in podIds)
                    {
                        var defaultStaffAssignments = _podStaffAssignmentRepository.GetPodSatff(podId);
                        var eventStaffBasicinfo = GetStaffBasicModels(defaultStaffAssignments.Select(dsa => new OrderedPair<long, long>(dsa.OrganizationRoleUserId, dsa.EventRoleId)), eventRoles, podId);
                        Save(eventId, podId, scheduledByOrgRoleId, eventStaffBasicinfo);
                    }
                }
            }
        }

        public StaffEventScheduleUploadListModel GetStaffEventScheduleUploadDetails(int pageNumber, int pageSize, StaffEventScheduleUploadModelFilter filter, out int totalRecords)
        {
            var staffEventUploads = (IReadOnlyCollection<StaffEventScheduleUpload>)_staffEventScheduleUploadRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);

            if (staffEventUploads == null || !staffEventUploads.Any()) return null;

            var successfileIds = staffEventUploads.Select(s => s.FileId).ToArray();
            var failedfileIds = staffEventUploads.Where(x => x.LogFileId.HasValue).Select(s => s.LogFileId.Value).ToArray();
            var fileIds = successfileIds.Concat(failedfileIds).ToArray();

            IEnumerable<FileModel> fileModels = null;
            if (fileIds != null && fileIds.Any())
            {
                var files = _fileRepository.GetByIds(fileIds);

                if (files != null && files.Any())
                {
                    fileModels = GetFileModelFromFile(files, _mediaRepository.GetStaffScheduleUploadMediaFileLocation());
                }
            }
            var eligibilityUploadByIds = staffEventUploads.Select(c => c.UploadedByOrgRoleUserId).ToArray();
            IEnumerable<OrderedPair<long, string>> uploadedbyNameIdPair = null;
            uploadedbyNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(eligibilityUploadByIds).ToArray();

            return _staffEventScheduleUploadListModelFactory.Create(fileModels, staffEventUploads, uploadedbyNameIdPair);
        }

        private IEnumerable<FileModel> GetFileModelFromFile(IEnumerable<File> files, MediaLocation location)
        {
            var collection = new List<FileModel>();
            files.ToList().ForEach(f =>
            {
                var fileModel = new FileModel
                {
                    Id = f.Id,
                    Caption = Path.GetFileNameWithoutExtension(f.Path),
                    FileName = f.Path,
                    FileSize = f.FileSize,
                    FileType = (long)f.Type,
                    PhisicalPath = f.Path,
                    UploadedBy = f.UploadedBy.Id,
                    Url = location.Url
                };
                collection.Add(fileModel);
            });
            return collection;
        }

        public EventStaffAssignmentListModel GetforStaffCalendar(bool isCurrentRoleTechnician, EventStaffAssignmentListModelFilter filter = null)
        {
            if (filter == null || filter.Year == 0 || filter.Month < 1)
            {
                if (isCurrentRoleTechnician)
                {
                    filter = new EventStaffAssignmentListModelFilter(DateTime.Today) { StaffId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId };
                }
                else
                {
                    long podId = _podRepository.GetFirstImmediateEventPodId();
                    filter = new EventStaffAssignmentListModelFilter(DateTime.Today) { PodId = podId };
                }
            }
            var model = new EventStaffAssignmentListModel(filter);
            if (filter.PodId > 0)
            {
                var pod = ((IUniqueItemRepository<Pod>)_podRepository).GetById(filter.PodId);
                model.SelectedPod = pod.Name;
            }

            if (filter.StaffId > 0)
            {
                var nameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(new[] { filter.StaffId }).ToArray().FirstOrDefault();
                if (nameIdPair != null) model.SelectedStaff = nameIdPair.SecondValue;
            }
            return model;
        }
    }
}