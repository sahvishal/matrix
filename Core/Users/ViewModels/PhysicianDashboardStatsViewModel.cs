using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Users.ViewModels
{
    public class PhysicianDashboardViewModel
    {
        public long PhysicianId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string SignaturePath { get; set; }
        public IEnumerable<Test> PermittedTests { get; set; }
        public IEnumerable<PhysicianLicesneViewModel> Licenses { get; set; }

        public PhysicianEvaluationQueueSummary PhysicianEvaluationsQueue { get; set; }
        public PhysicianEvaluationQueueSummary PhysicianOverReadsQueue { get; set; }

        public DateTime AverageTimePerEvaluation { get; set; }
    }

    public class PhysicianLicesneViewModel
    {
        public long Id { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string State { get; set; }
    }
}