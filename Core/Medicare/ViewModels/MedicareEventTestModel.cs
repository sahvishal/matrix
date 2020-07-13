using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareEventTestModel
    { 
        public long EventId { get; set; }
        public List<OrderedPair<String,String>> TestAliases { get; set; }
    }
}
