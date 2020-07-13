using System;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IGenerateKynLipidService
    {
        void GenerateLipidResult(string saveFilePath, long eventCustomerId);
        void GenerateKynResult(string saveFilePath, long eventCustomerId);
        void GenerateKynXMlforCustomer(EventCustomer eventCustomer, long eventId, DateTime EventDate, string corpCode, bool generatekynXml = true);
    }
}
