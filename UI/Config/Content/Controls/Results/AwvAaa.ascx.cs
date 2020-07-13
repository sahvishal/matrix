using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class AwvAaa : UserControl
    {
        public long EventId { get; set; }

        public long CustomerId { get; set; }

        protected string VersionNumber { get; set; }

        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                AwvAaa_hip.Visible = false;
                AwvAaa_chat.Visible = true;

            }
            else
            {
                AwvAaa_hip.Visible = true;
                AwvAaa_chat.Visible = false;
            }
            if (!IsPostBack) FillAllStaticGrids();
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                List<StandardFinding<decimal?>> standardFindingList;
                var settings = IoC.Resolve<ISettings>();
                if (settings.AwvAaaFindingChangeDate.HasValue)
                {
                    var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
                    var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(CustomerId, EventId);
                    if (eventCustomerResult != null && eventCustomerResult.DataRecorderMetaData.DateCreated < settings.AwvAaaFindingChangeDate.Value)
                    {
                        standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize, settings.AwvAaaFindingChangeDate.Value, true);
                    }
                    else
                    {
                        standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize, settings.AwvAaaFindingChangeDate.Value, false);
                    }
                }
                else
                {
                    standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvAAA, (int)ReadingLabels.AortaSize);
                }


                StandardFindingsAwvAaaGridView.DataSource = standardFindingList;
                StandardFindingsAwvAaaGridView.DataBind();

                var sViewStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeSaggitalView);
                AwvAaaSaggitalViewDataList.DataSource = sViewStandardFindingList;
                AwvAaaSaggitalViewDataList.DataBind();

                var tViewStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvAAA, (int)ReadingLabels.AortaRangeTransverseView);
                TransverseViewDatalist.DataSource = tViewStandardFindingList;
                TransverseViewDatalist.DataBind();

                var peakSystolicVelocityStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvAAA, (int)ReadingLabels.PeakSystolicVelocitySaggitalView);
                PeakSystolicVelocityDatalist.DataSource = peakSystolicVelocityStandardFindingList;
                PeakSystolicVelocityDatalist.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvAAA) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                //Filling Unable Screen Reason DataLists
                UnableToScreenAwvAaaDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvAaaDataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listIncidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.AwvAAA);

                IncidentalFindingsSelectedAwvAaaDataList.DataSource = listIncidentalFindings;
                IncidentalFindingsSelectedAwvAaaDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonAwvAaa.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvAaa.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvAaa.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvAaa.DataBind();
                    ddlTestNotPerformedReasonAwvAaa.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvAaa.Visible = false;
                }
            }
        }
    }
}