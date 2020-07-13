using System;
using System.Collections.Generic;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Pulmonary : System.Web.UI.UserControl
    {
        public bool IsResultEntrybyChat { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FillAllStaticGrids();
        }

        public void FillAllStaticGrids()
        {
            IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
            var standardFindingList = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.PulmonaryFunction);

            StandardFindingPulmonaryGridView.DataSource = standardFindingList;
            StandardFindingPulmonaryGridView.DataBind();

            IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.PulmonaryFunction) ?? new List<UnableScreenReason>() { new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } }; ;

            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
            //Filling Unable Screen Reason DataLists
            UnableToScreenPulmonaryDataList.DataSource = listUnableScreenReasonData;
            UnableToScreenPulmonaryDataList.DataBind();
        }
    }
}