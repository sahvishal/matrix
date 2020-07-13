using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class AwvEcho : UserControl
    {
        public long EventId { get; set; }

        public long CustomerId { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                awvEcho_hip.Visible = false;
                awvEcho_chat.Visible = true;

            }
            else
            {
                awvEcho_hip.Visible = true;
                awvEcho_chat.Visible = false;
            }
            FillAllStaticGridsEcho();
        }

        public void FillAllStaticGridsEcho()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvEcho) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                //Filling Unable Screen Reason DataLists
                AwvEchoUnableScreenDatalist.DataSource = listUnableScreenReasonData;
                AwvEchoUnableScreenDatalist.DataBind();

                var standardFindingRepository = new StandardFindingRepository();

                AwvEchoFindingsDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho);
                AwvEchoFindingsDatalist.DataBind();

                var settings = IoC.Resolve<ISettings>();
                List<StandardFinding<int>> standardFindingList;

                if (settings.AwvEchoFindingChangeDate.HasValue)
                {
                    var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
                    var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(CustomerId, EventId);
                    if (eventCustomerResult != null && eventCustomerResult.DataRecorderMetaData.DateCreated < settings.AwvEchoFindingChangeDate.Value)
                    {
                        standardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvEcho, (int)ReadingLabels.EstimatedEjactionFraction, settings.AwvEchoFindingChangeDate.Value, true);
                    }
                    else
                    {
                        standardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvEcho, (int)ReadingLabels.EstimatedEjactionFraction, settings.AwvEchoFindingChangeDate.Value, false);
                    }
                }
                else
                {
                    standardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvEcho, (int)ReadingLabels.EstimatedEjactionFraction);
                }

                AwvEchoEjactionFractionFindingsDatalist.DataSource = standardFindingList;
                AwvEchoEjactionFractionFindingsDatalist.DataBind();

                AwvEchoRegurgitationforAorticDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.Aortic);
                AwvEchoRegurgitationforAorticDatalist.DataBind();
                AwvEchoRegurgitationforMitralDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.Mitral);
                AwvEchoRegurgitationforMitralDatalist.DataBind();
                AwvEchoRegurgitationforPulmonicDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.Pulmonic);
                AwvEchoRegurgitationforPulmonicDatalist.DataBind();
                AwvEchoRegurgitationforTricuspidDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.Tricuspid);
                AwvEchoRegurgitationforTricuspidDatalist.DataBind();

                AwvEchoMorphologyAorticDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.AorticMorphology);
                AwvEchoMorphologyAorticDatalist.DataBind();
                AwvEchoMorphologyMitralDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.MitralMorphology);
                AwvEchoMorphologyMitralDatalist.DataBind();
                AwvEchoMorphologyPulmonicDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.PulmonicMorphology);
                AwvEchoMorphologyPulmonicDatalist.DataBind();
                AwvEchoMorphologyTricuspidDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.TricuspidMorphology);
                AwvEchoMorphologyTricuspidDatalist.DataBind();

                AwvEchoPericardialEffusionFindingDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.PericardialEffusion);
                AwvEchoPericardialEffusionFindingDatalist.DataBind();
                AwvEchoDiastolicDysfunctionFindingDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEcho, (Int32)ReadingLabels.DiastolicDysfunction);
                AwvEchoDiastolicDysfunctionFindingDatalist.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonAwvEcho.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvEcho.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvEcho.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvEcho.DataBind();
                    ddlTestNotPerformedReasonAwvEcho.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvEcho.Visible = false;
                }
            }
        }
    }
}