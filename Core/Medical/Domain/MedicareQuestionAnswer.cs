using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class MedicareQuestionAnswer : DomainObjectBase
    {
        public long EventCustomerId { get; set; }
        public long QuestionId { get; set; }
        public string Answer { get; set; }
        public DateTime CreateOn { get; set; }
        public long CreateBy { get; set; }
    }
}