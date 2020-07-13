using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ICheckListTemplateService
    {
        CheckListTemplateEditModel SaveTemplate(CheckListTemplateEditModel model, long organizationRoleUserId);
        CheckListTemplateEditModel GetbyId(long id);
        CheckListFormEditModel ViewTemplate(long templateId);
    }
}