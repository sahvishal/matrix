using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IKynHealthAssessmentFactory
    {
        TestResult GetLipidTestResultDomain(KynHealthAssessmentEditModel model, LipidTestResult inpersistence, long uploadedby, bool isNewResultFlow);
        BasicBiometric GetBasicTestResultBiometricDomain(KynHealthAssessmentEditModel model, BasicBiometric inpersistence, long uploadedby);
        Customer GetCustomerDomain(KynHealthAssessmentEditModel model, Customer inpersistence, long uploadedby);

        TestResult GetAsiTestResultDomain(KynHealthAssessmentEditModel model, ASITestResult inpersistence, long uploadedby, bool isNewResultFlow);

        TestResult GetKynTestResultDomain(KynHealthAssessmentEditModel model, TestResult inpersistence, long uploadedby, long testTypeId, bool isNewResultFlow);

        KynLabValues GetKynLabValues(KynHealthAssessmentEditModel model);

        TestResult GetAwvLipidTestResultDomain(KynHealthAssessmentEditModel model, AwvLipidTestResult inpersistence, long uploadedby, bool isNewResultFlow);

        TestResult GetAwvGlucoseTestResultDomain(KynHealthAssessmentEditModel model, AwvGlucoseTestResult inpersistence, long uploadedby, bool isNewResultFlow);

        TestResult GetCholesterolTestResultDomain(KynHealthAssessmentEditModel model, CholesterolTestResult inpersistence, long uploadedby, bool isNewResultFlow);

        TestResult GetDiabetesTestResultDomain(KynHealthAssessmentEditModel model, DiabetesTestResult inpersistence, long uploadedby, bool isNewResultFlow);

        TestResult GetHypertensionTestResultDomain(KynHealthAssessmentEditModel model, HypertensionTestResult inpersistence, long uploadedby, bool isNewResultFlow);

        TestResult GetHemaglobinA1CTestResultDomain(KynHealthAssessmentEditModel model, HemaglobinA1CTestResult inpersistence, long uploadedby, bool isNewResultFlow);

        TestResult GetAwvHemaglobinTestResultDomain(KynHealthAssessmentEditModel model, AwvHemaglobinTestResult inpersistence, long uploadedby, bool isNewResultFlow);

        TestResult GetMyBioCheckAssessmentTestResultDomain(KynHealthAssessmentEditModel model, MyBioAssessmentTestResult inpersistence, long uploadedby, bool isNewResultFlow);
    }
}