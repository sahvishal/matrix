﻿using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AAATestResult : TestResult
    {
        public ResultReading<decimal?> AortaSize { get; set; }
        public ResultReading<bool?> Fusiform { get; set; }
        public ResultReading<bool?> Saccular { get; set; }
        public ResultReading<bool> AorticDissection { get; set; }
        public ResultReading<bool> Plaque { get; set; }
        public ResultReading<bool> Thrombus { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public StandardFinding<decimal?> Finding { get; set; }

        public List<StandardFinding<int>> AortaRangeSaggitalView { get; set; }
        public OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>> TransverseView { get; set; }
        public List<StandardFinding<int>> AortaRangeTransverseView { get; set; }

        public List<ResultMedia> ResultImages { get; set; }

        public ResultReading<bool> ConsiderOtherModalities { get; set; }
        public ResultReading<bool> AdditionalImagesNeeded { get; set; }

        public AAATestResult()
            : this(0)
        { }

        public AAATestResult(long id)
            : base(id)
        { TestType = TestType.AAA; }
    }
}