using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class HcpEchocardiogram : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                HcpEcho_hip.Visible = false;
                HcpEcho_chat.Visible = true;

            }
            else
            {
                HcpEcho_hip.Visible = true;
                HcpEcho_chat.Visible = false;
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
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.HCPEcho) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                //Filling Unable Screen Reason DataLists
                HcpEchoUnableScreenDatalist.DataSource = listUnableScreenReasonData;
                HcpEchoUnableScreenDatalist.DataBind();

                var standardFindingRepository = new StandardFindingRepository();

                HcpEchoFindingsDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho);
                HcpEchoFindingsDatalist.DataBind();

                HcpEchoEjactionFractionFindingsDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.EstimatedEjactionFraction);
                HcpEchoEjactionFractionFindingsDatalist.DataBind();

                HcpEchoRegurgitationforAorticDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.Aortic);
                HcpEchoRegurgitationforAorticDatalist.DataBind();
                HcpEchoRegurgitationforMitralDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.Mitral);
                HcpEchoRegurgitationforMitralDatalist.DataBind();
                HcpEchoRegurgitationforPulmonicDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.Pulmonic);
                HcpEchoRegurgitationforPulmonicDatalist.DataBind();
                HcpEchoRegurgitationforTricuspidDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.Tricuspid);
                HcpEchoRegurgitationforTricuspidDatalist.DataBind();

                HcpEchoMorphologyAorticDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.AorticMorphology);
                HcpEchoMorphologyAorticDatalist.DataBind();
                HcpEchoMorphologyMitralDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.MitralMorphology);
                HcpEchoMorphologyMitralDatalist.DataBind();
                HcpEchoMorphologyPulmonicDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.PulmonicMorphology);
                HcpEchoMorphologyPulmonicDatalist.DataBind();
                HcpEchoMorphologyTricuspidDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.TricuspidMorphology);
                HcpEchoMorphologyTricuspidDatalist.DataBind();

                HcpEchoPericardialEffusionFindingDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.PericardialEffusion);
                HcpEchoPericardialEffusionFindingDatalist.DataBind();
                HcpEchoDiastolicDysfunctionFindingDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.HCPEcho, (Int32)ReadingLabels.DiastolicDysfunction);
                HcpEchoDiastolicDysfunctionFindingDatalist.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonHcpEcho.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonHcpEcho.DataTextField = "Name";
                    ddlTestNotPerformedReasonHcpEcho.DataValueField = "Id";
                    ddlTestNotPerformedReasonHcpEcho.DataBind();
                    ddlTestNotPerformedReasonHcpEcho.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonHcpEcho.Visible = false;
                }
            }
        }
    }
}