using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IKynLabValuesRepository
    {
        KynLabValues Get(long eventCustomerResultId, long testId);
        KynLabValues Save(KynLabValues domain, long orgRoleUserId);
        IEnumerable<MedicareKynResultEditModel> GetRecentKynLabValuesForMedicareSync(DateTime exportFromTime, string tagAlias);
    }
}
