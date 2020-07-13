using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface ISourceCodeRepository
    {
        SourceCode GetSourceCodeByCode(string sourceCode);
        SourceCode GetSourceCodeById(long sourceCodeId);
        SourceCode SaveSourceCode(SourceCode sourceCode);
        bool ValidateSourceCode(string sourceCode);
        bool ValidateSourceCode(string sourceCode, long id);
        bool IsSourceCodeAWorkshopSourceCode(string sourceCodeString);
        IEnumerable<SourceCode> GetSourceCodeByIds(long[] sourceCodeIds);
        void SaveSourceCodeSignupMode(IEnumerable<SignUpMode> signUpModes, long sourceCodeId);
        IEnumerable<SourceCode> GetbyFilter(SourceCodeListModelFilter filter, int pageNumber, int pageSize, out long totalRecords);
        void SetSourceCodeIsActiveState(long id, bool isActive);
        IEnumerable<OrderedPair<long, string>> GetCouponTypeIdNamepair();
        IEnumerable<SourceCode> SearchSourceCodeByName(string sourceCode);
    }
}