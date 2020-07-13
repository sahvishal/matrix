using System;
using System.Collections.Generic;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class PpEchocardiogram : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                Ppecho_hip.Visible = false;
                Ppecho_chat.Visible = true;

            }
            else
            {
                Ppecho_hip.Visible = true;
                Ppecho_chat.Visible = false;
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
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.PPEcho) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                //Filling Unable Screen Reason DataLists
                PpEchoUnableScreenDatalist.DataSource = listUnableScreenReasonData;
                PpEchoUnableScreenDatalist.DataBind();

                var standardFindingRepository = new StandardFindingRepository();

                PpEchoFindingsDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho);
                PpEchoFindingsDatalist.DataBind();

                PpEjactionFractionFindingsDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.EstimatedEjactionFraction);
                PpEjactionFractionFindingsDatalist.DataBind();

                PpRegurgitationforAorticDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.Aortic);
                PpRegurgitationforAorticDatalist.DataBind();
                PpRegurgitationforMitralDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.Mitral);
                PpRegurgitationforMitralDatalist.DataBind();
                PpRegurgitationforPulmonicDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.Pulmonic);
                PpRegurgitationforPulmonicDatalist.DataBind();
                PpRegurgitationforTricuspidDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.Tricuspid);
                PpRegurgitationforTricuspidDatalist.DataBind();

                PpMorphologyAorticDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.AorticMorphology);
                PpMorphologyAorticDatalist.DataBind();
                PpMorphologyMitralDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.MitralMorphology);
                PpMorphologyMitralDatalist.DataBind();
                PpMorphologyPulmonicDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.PulmonicMorphology);
                PpMorphologyPulmonicDatalist.DataBind();
                PpMorphologyTricuspidDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.TricuspidMorphology);
                PpMorphologyTricuspidDatalist.DataBind();

                PpPericardialEffusionFindingDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.PericardialEffusion);
                PpPericardialEffusionFindingDatalist.DataBind();
                PpDiastolicDysfunctionFindingDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.PPEcho, (Int32)ReadingLabels.DiastolicDysfunction);
                PpDiastolicDysfunctionFindingDatalist.DataBind();

            }
        }
    }
}