﻿using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class EhrRevertToNpReviewViewModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public string UserName { get; set; }
        public string RoleAlias { get; set; }
    }
}