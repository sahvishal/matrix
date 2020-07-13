using System;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales.Domain
{
    public class Task : Activity
    {
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}