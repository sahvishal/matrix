using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Application.Impl
{
    [DefaultImplementation]
    public class NotesViewModelFactory : INotesViewModelFactory
    {
        public IEnumerable<NotesViewModel> GetProspectCustomerNotes(long prospectCustomerId, IEnumerable<CustomerCallNotes> prospectCustomerNotes, IEnumerable<OrderedPair<long, string>> idNamePairs)
        {
            var notes = prospectCustomerNotes.Where(pcn => pcn.ProspectCustomerId == prospectCustomerId).Select(pcn => pcn).ToArray();

            if (notes.Count() > 0)
            {
                return (from note in notes
                        let idNamePair = idNamePairs.Where(inp => inp.FirstValue == note.DataRecorderMetaData.DataRecorderCreator.Id).Single()
                        select new NotesViewModel
                        {
                            Note = note.Notes,
                            CreatedByUser = idNamePair.SecondValue,
                            EnteredOn = note.DataRecorderMetaData.DateCreated
                        }).ToArray();
            }
            return null;
        }
    }
}
