using System;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Sales;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.EntityClasses;
using System.Linq;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Repositories
{
    // TODO: This class needs refactoring, this is done just for deleting an activity type.
    // TODO: This will be an abstract type which will be inherited by each activity type specific repository.
    public class ActivityRepository : PersistenceRepository, IActivityRepository
    {
        
        public bool DeleteActivity(ActivityType activityType, long activityId)
        {
            switch (activityType)
            {
                case ActivityType.Task:
                    return DeleteTask(activityId);
                case ActivityType.Call:
                    return DeleteContactCall(activityId);
                case ActivityType.Meeting:
                    return DeleteContactMeeting(activityId);
                default:
                    throw new NotSupportedException(string.Format("The ActivityType {0} is not yet supported.",
                                                                  activityType));
            }
        }

        private bool DeleteTask(long taskId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(TaskDetailsFields.TaskId == taskId);
                var taskDetailsEntity = new TaskDetailsEntity(taskId) {IsActive = false};

                if (myAdapter.UpdateEntitiesDirectly(taskDetailsEntity,bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        private bool DeleteContactCall(long contactCallId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(ContactCallFields.ContactCallId == contactCallId);
                var contactCallEntity = new ContactCallEntity(contactCallId) { IsActive = false };

                if (myAdapter.UpdateEntitiesDirectly(contactCallEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        private bool DeleteContactMeeting(long contactMeetingId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket(ContactMeetingFields.ContactMeetingId == contactMeetingId);
                var contactMeetingEntity = new ContactMeetingEntity(contactMeetingId) { IsActive = false };

                if (myAdapter.UpdateEntitiesDirectly(contactMeetingEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        public bool MarkActivity(ActivityType activityType, long activityId,bool markActivity)
        {
            switch (activityType)
            {
                case ActivityType.Task:
                    return MarkTask(activityId, markActivity);
                case ActivityType.Call:
                    return MarkCall(activityId, markActivity);
                case ActivityType.Meeting:
                    return MarkMeeting(activityId, markActivity);
                default:
                    throw new NotSupportedException(string.Format("The ActivityType {0} is not yet supported.",
                               activityType));
            }
        }

        private bool MarkTask(long taskId, bool markActivity)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                long taskStatusId;
                if (markActivity)
                    taskStatusId = linqMetaData.TaskStatusTypes.Where(tastStatusType => tastStatusType.Name == "Completed").Select(p => p.TaskStatusId).FirstOrDefault();
                else
                    taskStatusId = linqMetaData.TaskStatusTypes.Where(tastStatusType => tastStatusType.Name == "In Progress").Select(p => p.TaskStatusId).FirstOrDefault();

                IRelationPredicateBucket bucket = new RelationPredicateBucket(TaskDetailsFields.TaskId == taskId);
                var taskDetailsEntity = new TaskDetailsEntity(taskId) {DateModified=DateTime.Now,TaskStatusId = taskStatusId };

                if (myAdapter.UpdateEntitiesDirectly(taskDetailsEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }

        private bool MarkCall(long callId, bool markActivity)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                long callStatusId;
                if (markActivity)
                    callStatusId = linqMetaData.ContactCallStatus.Where(callStatus => callStatus.Status == "Held").Select(p => p.ContactCallStatusId).FirstOrDefault();
                else
                    callStatusId = linqMetaData.ContactCallStatus.Where(callStatus => callStatus.Status == "Planned").Select(p => p.ContactCallStatusId).FirstOrDefault();

                IRelationPredicateBucket bucket = new RelationPredicateBucket(ContactCallFields.ContactCallId == callId);
                var contactCallEntity = new ContactCallEntity(callId) { DateModified = DateTime.Now, ContactCallStatusId = callStatusId };

                if (myAdapter.UpdateEntitiesDirectly(contactCallEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }
        private bool MarkMeeting(long meetingId, bool markActivity)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                long meetingStatusId;
                if (markActivity)
                    meetingStatusId = linqMetaData.ContactCallStatus.Where(callStatus => callStatus.Status == "Held").Select(p => p.ContactCallStatusId).FirstOrDefault();
                else
                    meetingStatusId = linqMetaData.ContactCallStatus.Where(callStatus => callStatus.Status == "Planned").Select(p => p.ContactCallStatusId).FirstOrDefault();

                IRelationPredicateBucket bucket = new RelationPredicateBucket(ContactMeetingFields.ContactMeetingId == meetingId);
                var contactMeetingEntity = new ContactMeetingEntity(meetingId) { DateModified = DateTime.Now, ContactMeetingStatusId = meetingStatusId };

                if (myAdapter.UpdateEntitiesDirectly(contactMeetingEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
            return true;
        }
    }
}