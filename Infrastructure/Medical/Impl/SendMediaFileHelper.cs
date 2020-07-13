using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using System;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SendMediaFileHelper : ISendMediaFileHelper
    {
        private readonly ISettings _settings;

        public SendMediaFileHelper(ISettings settings)
        {
            _settings = settings;
        }

        private const string Spiro = "MIR";
        private const string PAD = "QUANTAFLO";
        private const string AAA = "Esaote";
        private const string LEAD = "Esaote";
        private const string ECHO = "Esaote";
        private const string EKG = "Nasiff";
        private const string Osteo = "GE_Healthcare";
        private const string Mammo = "NovaRad";
        private const string DRS = "IRIS";
        private const string DPN = "NeuroMetrix_Inc";
        private const string A1C = "PTS";
        private const string Lipid = "PTS";
        private const string FocAttestation = "FocAttestation";
        private const string Chaperone = "Chaperone";

        public OrderedPair<string, string> GetSftpFileAndFolder(CorporateAccount account, Customer customer, Event eventData, string test, string fileExtension, bool convertFileType = false)
        {
            var testType = (TestType)Enum.Parse(typeof(TestType), test);

            Falcon.App.Core.OrderedPair<string, string> pathAndTestAlias = null;

            if (!TestGroup.FormType.Contains(test))
                pathAndTestAlias = GetMediaPathandTestAlias(testType);
            else
                pathAndTestAlias = GetFormTypeMediaPathAndFormName((PatientFormType)Enum.Parse(typeof(PatientFormType), test));

            var clientId = (account == null || string.IsNullOrWhiteSpace(account.ClientId)) ? "No_ClientId" : account.ClientId;
            var eventDate = eventData.EventDate.ToString("MMddyyyy");
            var acesId = string.IsNullOrWhiteSpace(customer.AcesId) ? "NoAcesId_" + customer.CustomerId : customer.AcesId;
            var lastName = (customer.Name.LastName).Replace(" ", string.Empty);

            string fileName = string.Format("MB_{0}_{1}_{2}_{3}_{4}{5}", clientId, lastName, acesId, pathAndTestAlias.FirstValue, eventDate, fileExtension);

            if (convertFileType)
            {
                fileName = string.Format("MB_{0}_{1}_{2}_{3}_{4}.pdf", clientId, lastName, acesId, pathAndTestAlias.FirstValue, eventDate);
            }

            var destinationPath = string.Format(_settings.SendTestMediaFilesClientLocation, pathAndTestAlias.SecondValue);

            if (testType == TestType.FocAttestation)
            {
                var memberClientId = (customer == null || string.IsNullOrWhiteSpace(customer.InsuranceId)) ? "No_MemberClientId" : customer.InsuranceId;
                if (account.Id == _settings.WellmedAccountId)
                {
                    fileName = string.Format("{0}_{1}_{2}_{3}.pdf", acesId, memberClientId, eventData.EventDate.ToString("yyyy"), "FOC");
                    destinationPath = _settings.WellmedFlFocPath;
                }

                if (account.Id == _settings.WellmedTxAccountId)
                {
                    fileName = string.Format("{0}_{1}_{2}_{3}.pdf", acesId, memberClientId, eventData.EventDate.ToString("yyyy"), "FOC");
                    destinationPath = _settings.WellmedTxFocPath;
                }
            }

            return new OrderedPair<string, string>() { FirstValue = fileName, SecondValue = destinationPath };
        }

        private OrderedPair<string, string> GetMediaPathandTestAlias(TestType testType)
        {
            var retString = new OrderedPair<string, string>();
            switch (testType)
            {
                case TestType.Spiro:
                case TestType.AwvSpiro:
                    retString.FirstValue = "Spiro";
                    retString.SecondValue = Spiro;
                    break;

                case TestType.PAD:
                case TestType.AwvABI:
                case TestType.FloChecABI:
                case TestType.QuantaFloABI:
                    retString.FirstValue = "PAD";
                    retString.SecondValue = PAD;
                    break;

                case TestType.DPN:
                case TestType.DiabeticNeuropathy:
                    retString.FirstValue = "Nerve";
                    retString.SecondValue = DPN;
                    break;

                case TestType.AAA:
                case TestType.AwvAAA:
                    retString.FirstValue = "AAA";
                    retString.SecondValue = AAA;
                    break;

                case TestType.Lead:
                    retString.FirstValue = "LEAD";
                    retString.SecondValue = LEAD;
                    break;

                case TestType.Echocardiogram:
                case TestType.AwvEcho:
                    retString.FirstValue = "ECHO";
                    retString.SecondValue = ECHO;
                    break;

                case TestType.EKG:
                case TestType.AwvEkg:
                    retString.FirstValue = "EKG";
                    retString.SecondValue = EKG;
                    break;

                case TestType.Osteoporosis:
                case TestType.AwvBoneMass:
                    retString.FirstValue = "BoneDensity";
                    retString.SecondValue = Osteo;
                    break;

                case TestType.Mammogram:
                    retString.FirstValue = "Mammogram";
                    retString.SecondValue = Mammo;
                    break;

                case TestType.DiabeticRetinopathy:
                    retString.FirstValue = "Eye";
                    retString.SecondValue = DRS;
                    break;

                case TestType.A1C:
                    retString.FirstValue = "Blood";
                    retString.SecondValue = A1C;
                    break;

                case TestType.Lipid:
                case TestType.AwvLipid:
                    retString.FirstValue = "Lipid";
                    retString.SecondValue = Lipid;
                    break;

                case TestType.FocAttestation:
                    retString.FirstValue = testType.ToString();
                    retString.SecondValue = FocAttestation;
                    break;

                default:
                    retString.FirstValue = testType.ToString();
                    retString.SecondValue = testType.ToString();
                    break;
            }
            return retString;
        }

        private OrderedPair<string, string> GetFormTypeMediaPathAndFormName(PatientFormType formType)
        {
            var retString = new OrderedPair<string, string>();
            switch (formType)
            {
                case PatientFormType.Chaperone:
                    retString.FirstValue = "Chaperone";
                    retString.SecondValue = Chaperone;
                    break;

                default:
                    retString.FirstValue = formType.ToString();
                    retString.SecondValue = formType.ToString();
                    break;
            }
            return retString;
        }
    }
}
