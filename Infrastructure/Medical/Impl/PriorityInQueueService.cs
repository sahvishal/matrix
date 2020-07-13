using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Impl
{

    [DefaultImplementation]
    public class PriorityInQueueService : IPriorityInQueueService
    {
        private readonly INotesRepository _notesRepository;
        private readonly IPriorityInQueueRepository _priorityInQueueRepository;

        public PriorityInQueueService(INotesRepository notesRepository, IPriorityInQueueRepository priorityInQueueRepository)
        {
            _notesRepository = notesRepository;
            _priorityInQueueRepository = priorityInQueueRepository;
        }

        public bool UpdatePriorityinQueue(PriorityInQueueEditModel model, long createdByOrgRoleUserId)
        {
            var piq = _priorityInQueueRepository.GetByEventCustomerResultId(model.EventCustomerResultId);
            if (model.IsPriorityInQueue)
            {
                if (piq != null)
                {
                    if (piq.NoteId == null) return true;
                    var noteObj = _notesRepository.Get(piq.NoteId.Value);
                    if (noteObj.Text != model.Note)
                    {
                        noteObj.Text = model.Note;
                        _notesRepository.Save(noteObj);
                    }
                    return true;
                }
                var metaData = new DataRecorderMetaData(createdByOrgRoleUserId, DateTime.Now, DateTime.Now);
                var newNote = new Notes() { Text = model.Note, DataRecorderMetaData = metaData };
                newNote = _notesRepository.Save(newNote);

                piq = new PriorityInQueue
                {
                    EventCustomerResultId = model.EventCustomerResultId,
                    NoteId = newNote.Id,
                    CreatedByOrgRoleUserId = createdByOrgRoleUserId,
                    ModifiedByOrgRoleUserId = createdByOrgRoleUserId,
                    InQueuePriority = _priorityInQueueRepository.GetMaxPriorityInQueue(),
                    IsActive = true
                };

                piq.DateCreated = piq.DateModified = DateTime.Now;
                _priorityInQueueRepository.Save(piq);
            }
            else
            {
                //var piq = _priorityInQueueRepository.GetByEventCustomerResultId(model.EventCustomerResultId);
                if (piq != null)
                {
                    piq.InQueuePriority = 0;
                    piq.IsActive = false;
                    piq.DateModified = DateTime.Now;
                    piq.ModifiedByOrgRoleUserId = createdByOrgRoleUserId;
                    _priorityInQueueRepository.Save(piq);
                }
            }
            return true;
        }

        public bool RemovePriorityInQueue(long eventCustomerResultId, long createdByOrgRoleUserId)
        {
            var model = new PriorityInQueueEditModel
            {
                EventCustomerResultId = eventCustomerResultId,
                IsPriorityInQueue = false
            };

            UpdatePriorityinQueue(model, createdByOrgRoleUserId);
            return true;
        }
    }
}
