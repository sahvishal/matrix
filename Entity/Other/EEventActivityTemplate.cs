using System;
using System.Collections.Generic;

namespace Falcon.Entity.Other
{
    public class EEventActivityTemplate
    {
        
        public Int64 EventActivityTemplateID { get; set; }        
        
        public string Name { get; set; }
        
        public List<Int64> ListHostIDs { get; set; }
        
        public List<EEventActivityTemplateActivity> ListActivities { get; set; }
        
        public bool IsActive { get; set; }
        
        public string DateCreated { get; set; }
        
        public string DateModified { get; set; }
        
    }

}
