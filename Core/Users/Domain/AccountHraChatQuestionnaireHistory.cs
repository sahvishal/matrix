using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Users.Domain
{
    public class AccountHraChatQuestionnaireHistory : DomainObjectBase
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long QuestionnaireType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
