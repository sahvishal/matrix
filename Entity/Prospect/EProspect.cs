using System;
using System.Collections.Generic;
using System.Text;

using Falcon.Entity.User;

using System.Runtime.Serialization;

namespace Falcon.Entity.Prospect
{
   
    public class EProspect:User.EUser
    {
        private string prospectID;
        
        public string ProspectID
        {
            get { return prospectID; }
            set { prospectID = value; }
        }
	
    }
}
