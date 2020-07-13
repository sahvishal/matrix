using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class EventArchiveStatsFactory : IEventArchiveStatsFactory
    {
        public ListModelBase<EventArchiveStatsViewModel, EventArchiveStatsFilter> Create(IEnumerable<ResultArchive> resultArchives, IEnumerable<Event> events, IEnumerable<File> files, IEnumerable<Pod> pods,
            IEnumerable<OrderedPair<long, string>> userIdNamePairs)
        {
            var collection = new List<EventArchiveStatsViewModel>();

            foreach (var upload in resultArchives)
            {
                var theEvent = events.SingleOrDefault(e => e.Id == upload.EventId);
                var eventPods = pods.Where(p => theEvent.PodIds.Contains(p.Id)).ToArray();
                var file = files.SingleOrDefault(f => f.Id == upload.FileId);
                var userIdNamepair = userIdNamePairs.SingleOrDefault(p => p.FirstValue == resultArchives.Where(r => r.Id == upload.Id).Select(r => r.UploadedByOrgRoleUserId).SingleOrDefault());

                var uploadTimeString = "NA";
                if (upload.UploadEndTime.HasValue)
                {
                    var uploadTime = (upload.UploadEndTime.Value - upload.UploadStartTime);
                    if (uploadTime.Hours > 0)
                        uploadTimeString = uploadTime.Hours + " h " + uploadTime.Minutes + " mims";
                    else if (uploadTime.Minutes > 0)
                        uploadTimeString = uploadTime.Minutes + " mins " + uploadTime.Seconds + " secs";
                    else if (uploadTime.Seconds >= 0)
                        uploadTimeString = uploadTime.Seconds + " secs";
                }

                var fileSizeString = string.Empty;
                if (upload.FileId.HasValue && file != null)
                {
                    var fileSize = file.FileSize;
                    if (fileSize > 1024 * 1024)
                    {
                        fileSize = fileSize / (1024 * 1024);
                        fileSizeString = fileSize.ToString("0.00") + " MB";
                    }
                    else if (fileSize > 1024)
                    {
                        fileSize = fileSize / 1024;
                        fileSizeString = fileSize.ToString("0.00") + " KB";
                    }
                    else
                    {
                        fileSizeString = fileSize.ToString("0.00") + " Bytes";
                    }
                }

                collection.Add(new EventArchiveStatsViewModel
                {
                    Id = upload.Id,
                    ArchiveName = upload.FileId.HasValue && file != null ? file.Path : "",
                    FileSize = fileSizeString,
                    EventId = upload.EventId,
                    EventName = theEvent.Name,
                    EventDate = theEvent.EventDate,
                    PodName = string.Join(", ", eventPods.Select(ep => ep.Name)),
                    UploadStartTime = upload.UploadStartTime,
                    UploadEndTime = upload.UploadEndTime,
                    TimeTaken = uploadTimeString,
                    ParseStartTime = upload.ParseStartTime,
                    ParseEndTime = upload.ParseEndTime,
                    CustomerRecordsFound = upload.CustomerRecordsFound,
                    UploadedBy = userIdNamepair != null ? userIdNamepair.SecondValue : "",
                    UploadStatus = (upload.Status == ResultArchiveUploadStatus.Uploading || upload.Status == ResultArchiveUploadStatus.UploadFailed) ? upload.Status.GetDescription() : ResultArchiveUploadStatus.Uploaded.GetDescription()
                });
            }

            return new EventArchiveStatsListModel
            {
                Collection = collection
            };
        }
    }
}
