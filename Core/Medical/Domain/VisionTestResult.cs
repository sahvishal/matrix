using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class VisionTestResult : TestResult
    {
        public ResultReading<bool?> BothEyesLeftUpperQuadrant { get; set; }
        public ResultReading<bool?> BothEyesLeftLowerQuadrant { get; set; }
        public ResultReading<bool?> BothEyesRightUpperQuadrant { get; set; }
        public ResultReading<bool?> BothEyesRightLowerQuadrant { get; set; }

        public ResultReading<bool?> RightEyeLeftUpperQuadrant { get; set; }
        public ResultReading<bool?> RightEyeLeftLowerQuadrant { get; set; }
        public ResultReading<bool?> RightEyeRightUpperQuadrant { get; set; }
        public ResultReading<bool?> RightEyeRightLowerQuadrant { get; set; }

        public ResultReading<bool?> LeftEyeLeftUpperQuadrant { get; set; }
        public ResultReading<bool?> LeftEyeLeftLowerQuadrant { get; set; }
        public ResultReading<bool?> LeftEyeRightUpperQuadrant { get; set; }
        public ResultReading<bool?> LeftEyeRightLowerQuadrant { get; set; }


        public ResultReading<int?> RightEyeCylindrical { get; set; }
        public ResultReading<int?> RightEyeSpherical { get; set; }

        public ResultReading<int?> LeftEyeCylindrical { get; set; }
        public ResultReading<int?> LeftEyeSpherical { get; set; }

         public VisionTestResult() : this(0) { }

         public VisionTestResult(long id)
            : base(id)
        {
            TestType = TestType.Vision;
        }
    }
}