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
    public partial class Echocardiogram : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                echo_hip.Visible = false;
                echo_chat.Visible = true;

            }
            else
            {
                echo_hip.Visible = true;
                echo_chat.Visible = false;
            }
            FillAllStaticGridsEcho();
            echoPhysicianRepeatStudy.Style.Add(HtmlTextWriterStyle.Display, ShowHideRepeatStudyCheckBox ? "block" : "none");
            echoOtherModalitiesAdditionalImages.Style.Add(HtmlTextWriterStyle.Display, !ShowHideRepeatStudyCheckBox ? "block" : "none");
        }

        public bool ShowHideRepeatStudyCheckBox { get; set; }

        public void FillAllStaticGridsEcho()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Echocardiogram) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                //Filling Unable Screen Reason DataLists
                EchoUnableScreenDatalist.DataSource = listUnableScreenReasonData;
                EchoUnableScreenDatalist.DataBind();

                var standardFindingRepository = new StandardFindingRepository();

                EchoFindingsDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram);
                EchoFindingsDatalist.DataBind();

                EjactionFractionFindingsDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.EstimatedEjactionFraction);
                EjactionFractionFindingsDatalist.DataBind();

                RegurgitationforAorticDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.Aortic);
                RegurgitationforAorticDatalist.DataBind();
                RegurgitationforMitralDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.Mitral);
                RegurgitationforMitralDatalist.DataBind();
                RegurgitationforPulmonicDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.Pulmonic);
                RegurgitationforPulmonicDatalist.DataBind();
                RegurgitationforTricuspidDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.Tricuspid);
                RegurgitationforTricuspidDatalist.DataBind();

                MorphologyAorticDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.AorticMorphology);
                MorphologyAorticDatalist.DataBind();
                MorphologyMitralDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.MitralMorphology);
                MorphologyMitralDatalist.DataBind();
                MorphologyPulmonicDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.PulmonicMorphology);
                MorphologyPulmonicDatalist.DataBind();
                MorphologyTricuspidDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.TricuspidMorphology);
                MorphologyTricuspidDatalist.DataBind();

                PericardialEffusionFindingDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.PericardialEffusion);
                PericardialEffusionFindingDatalist.DataBind();
                DiastolicDysfunctionFindingDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Echocardiogram, (Int32)ReadingLabels.DiastolicDysfunction);
                DiastolicDysfunctionFindingDatalist.DataBind();
            }

        }
    }
}