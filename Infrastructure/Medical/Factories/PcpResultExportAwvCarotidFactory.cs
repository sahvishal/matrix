using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportAwvCarotidFactory : IPcpResultExportAwvCarotidFactory
    {
        public PcpResultExportModel SetAwvCarotidData(PcpResultExportModel model, AwvCarotidTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.RightResultReadings != null)
            {
                if (testResult.RightResultReadings.Finding != null)
                    model.CarotidRightResult = testResult.RightResultReadings.Finding.Label;

                //CCA Proximal
                if (testResult.RightResultReadings.CCAProximalPSV != null && testResult.RightResultReadings.CCAProximalPSV.Reading != null)
                    model.CarotidRightCcaProximalPsv = testResult.RightResultReadings.CCAProximalPSV.Reading.Value.ToString("00.00");

                if (testResult.RightResultReadings.CCAProximalEDV != null && testResult.RightResultReadings.CCAProximalEDV.Reading != null)
                    model.CarotidRightCcaProximalEdv = testResult.RightResultReadings.CCAProximalEDV.Reading.Value.ToString("00.00");

                //CCA Distal
                if (testResult.RightResultReadings.CCADistalPSV != null && testResult.RightResultReadings.CCADistalPSV.Reading != null)
                    model.CarotidRightCcaDistalPsv = testResult.RightResultReadings.CCADistalPSV.Reading.Value.ToString("00.00");

                if (testResult.RightResultReadings.CCADistalEDV != null && testResult.RightResultReadings.CCADistalEDV.Reading != null)
                    model.CarotidRightCcaDistalEdv = testResult.RightResultReadings.CCADistalEDV.Reading.Value.ToString("00.00");

                //Bulb
                if (testResult.RightResultReadings.BulbPSV != null && testResult.RightResultReadings.BulbPSV.Reading != null)
                    model.CarotidRightBulbPsv = testResult.RightResultReadings.BulbPSV.Reading.Value.ToString("00.00");

                if (testResult.RightResultReadings.BulbEDV != null && testResult.RightResultReadings.BulbEDV.Reading != null)
                    model.CarotidRightBulbEdv = testResult.RightResultReadings.BulbEDV.Reading.Value.ToString("00.00");

                //Ext Carotid Art
                if (testResult.RightResultReadings.ExtCarotidArtPSV != null && testResult.RightResultReadings.ExtCarotidArtPSV.Reading != null)
                    model.CarotidRightExtCarotidArtPsv = testResult.RightResultReadings.ExtCarotidArtPSV.Reading.Value.ToString("00.00");

                //ICA Proximal
                if (testResult.RightResultReadings.ICAProximalPSV != null && testResult.RightResultReadings.ICAProximalPSV.Reading != null)
                    model.CarotidRightIcaProximalPsv = testResult.RightResultReadings.ICAProximalPSV.Reading.Value.ToString("00.00");

                if (testResult.RightResultReadings.ICAProximalEDV != null && testResult.RightResultReadings.ICAProximalEDV.Reading != null)
                    model.CarotidRightIcaProximalEdv = testResult.RightResultReadings.ICAProximalEDV.Reading.Value.ToString("00.00");

                //ICA Distal
                if (testResult.RightResultReadings.ICADistalPSV != null && testResult.RightResultReadings.ICADistalPSV.Reading != null)
                    model.CarotidRightIcaDistalPsv = testResult.RightResultReadings.ICADistalPSV.Reading.Value.ToString("00.00");

                if (testResult.RightResultReadings.ICADistalEDV != null && testResult.RightResultReadings.ICADistalEDV.Reading != null)
                    model.CarotidRightIcaDistalEdv = testResult.RightResultReadings.ICADistalEDV.Reading.Value.ToString("00.00");

                //Vertebral Art
                if (testResult.RightResultReadings.VertebralArtPSV != null && testResult.RightResultReadings.VertebralArtPSV.Reading != null)
                    model.CarotidRightVertebralArtPsv = testResult.RightResultReadings.VertebralArtPSV.Reading.Value.ToString("00.00");

                if (testResult.RightResultReadings.VertebralArtEDV != null && testResult.RightResultReadings.VertebralArtEDV.Reading != null)
                    model.CarotidRightVertebralArtEdv = testResult.RightResultReadings.VertebralArtEDV.Reading.Value.ToString("00.00");

            }

            if (testResult.LeftResultReadings != null)
            {
                if (testResult.LeftResultReadings.Finding != null)
                    model.CarotidLeftResult = testResult.LeftResultReadings.Finding.Label;

                //CCA Proximal
                if (testResult.LeftResultReadings.CCAProximalPSV != null && testResult.LeftResultReadings.CCAProximalPSV.Reading != null)
                    model.CarotidLeftCcaProximalPsv = testResult.LeftResultReadings.CCAProximalPSV.Reading.Value.ToString("00.00");

                if (testResult.LeftResultReadings.CCAProximalEDV != null && testResult.LeftResultReadings.CCAProximalEDV.Reading != null)
                    model.CarotidLeftCcaProximalEdv = testResult.LeftResultReadings.CCAProximalEDV.Reading.Value.ToString("00.00");

                //CCA Distal
                if (testResult.LeftResultReadings.CCADistalPSV != null && testResult.LeftResultReadings.CCADistalPSV.Reading != null)
                    model.CarotidLeftCcaDistalPsv = testResult.LeftResultReadings.CCADistalPSV.Reading.Value.ToString("00.00");

                if (testResult.LeftResultReadings.CCADistalEDV != null && testResult.LeftResultReadings.CCADistalEDV.Reading != null)
                    model.CarotidLeftCcaDistalEdv = testResult.LeftResultReadings.CCADistalEDV.Reading.Value.ToString("00.00");

                //Bulb
                if (testResult.LeftResultReadings.BulbPSV != null && testResult.LeftResultReadings.BulbPSV.Reading != null)
                    model.CarotidLeftBulbPsv = testResult.LeftResultReadings.BulbPSV.Reading.Value.ToString("00.00");

                if (testResult.LeftResultReadings.BulbEDV != null && testResult.LeftResultReadings.BulbEDV.Reading != null)
                    model.CarotidLeftBulbEdv = testResult.LeftResultReadings.BulbEDV.Reading.Value.ToString("00.00");

                //Ext Carotid Art
                if (testResult.LeftResultReadings.ExtCarotidArtPSV != null && testResult.LeftResultReadings.ExtCarotidArtPSV.Reading != null)
                    model.CarotidLeftExtCarotidArtPsv = testResult.LeftResultReadings.ExtCarotidArtPSV.Reading.Value.ToString("00.00");

                //ICA Proximal
                if (testResult.LeftResultReadings.ICAProximalPSV != null && testResult.LeftResultReadings.ICAProximalPSV.Reading != null)
                    model.CarotidLeftIcaProximalPsv = testResult.LeftResultReadings.ICAProximalPSV.Reading.Value.ToString("00.00");

                if (testResult.LeftResultReadings.ICAProximalEDV != null && testResult.LeftResultReadings.ICAProximalEDV.Reading != null)
                    model.CarotidLeftIcaProximalEdv = testResult.LeftResultReadings.ICAProximalEDV.Reading.Value.ToString("00.00");

                //ICA Distal
                if (testResult.LeftResultReadings.ICADistalPSV != null && testResult.LeftResultReadings.ICADistalPSV.Reading != null)
                    model.CarotidLeftIcaDistalPsv = testResult.LeftResultReadings.ICADistalPSV.Reading.Value.ToString("00.00");

                if (testResult.LeftResultReadings.ICADistalEDV != null && testResult.LeftResultReadings.ICADistalEDV.Reading != null)
                    model.CarotidLeftIcaDistalEdv = testResult.LeftResultReadings.ICADistalEDV.Reading.Value.ToString("00.00");

                //Vertebral Art
                if (testResult.LeftResultReadings.VertebralArtPSV != null && testResult.LeftResultReadings.VertebralArtPSV.Reading != null)
                    model.CarotidLeftVertebralArtPsv = testResult.LeftResultReadings.VertebralArtPSV.Reading.Value.ToString("00.00");

                if (testResult.LeftResultReadings.VertebralArtEDV != null && testResult.LeftResultReadings.VertebralArtEDV.Reading != null)
                    model.CarotidLeftVertebralArtEdv = testResult.LeftResultReadings.VertebralArtEDV.Reading.Value.ToString("00.00");
            }

            model.CarotidLowVelocityRica = testResult.LowVelocityRica != null ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
            model.CarotidLowVelocityLica = testResult.LowVelocityLica != null ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            model.CarotidTechnicallyLimitedButReadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable, useBlankValue);
            model.CarotidRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy, useBlankValue);

            model.CarotidUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.CarotidCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.CarotidCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.CarotidPhysicianNotes = testResult.PhysicianInterpretation.Remarks;


            return model;

        }
    }
}
