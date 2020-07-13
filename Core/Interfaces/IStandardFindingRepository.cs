using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Interfaces
{
    public interface IStandardFindingRepository
    {
        List<StandardFinding<T>> GetAllStandardFindings<T>(int testId);
        List<StandardFinding<T>> GetAllStandardFindings<T>(int testId, int readingId);
        long GetStandardFindingTestReadingIdForStandardFinding(int testId, int? readingId, long standardFindingId);
        IEnumerable<StandardFinding<T>> GetByIds<T>(IEnumerable<long> ids);
        List<StandardFinding<T>> GetAllStandardFindings<T>(int testId, int readingId, DateTime dateCreated, bool before);
    }
}