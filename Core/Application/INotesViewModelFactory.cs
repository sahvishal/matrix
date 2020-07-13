using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Application
{
    public interface INotesViewModelFactory
    {
        IEnumerable<NotesViewModel> GetProspectCustomerNotes(long prospectCustomerId, IEnumerable<CustomerCallNotes> prospectCustomerNotes, IEnumerable<OrderedPair<long, string>> idNamePairs);
    }
}