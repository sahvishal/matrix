using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical
{
    public interface ILipidParserHelper
    {
        CompoundResultReading<int?> GetReading(string reading, ReadingLabels label,TestType testType, ref string errorSummary);
        CompoundResultReading<string> GetReading(string reading, ReadingLabels label, ref decimal? value, TestType testType, ref string errorSummary);
        CompoundResultReading<string> GetHdlReading(string reading, long customerId, ref decimal? value, TestType testType, ref string errorSummary);
        CompoundResultReading<decimal?> GetHdlTclRatio(decimal? hdl, decimal? tchol, TestType testType, ref string errorSummary);
        void SetLogger(ILogger logger);
    }
}