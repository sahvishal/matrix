using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallCenterNotesRepository
    {
        IEnumerable<CallCenterNotes> GetByCallIds(IEnumerable<long> callIds);
        CallCenterNotes Save(CallCenterNotes call);
        CallCenterNotes GetByCallId(long callId);
        IEnumerable<CallCenterNotes> GetCallCenterNotesByCallId(long callId);
    }
}
