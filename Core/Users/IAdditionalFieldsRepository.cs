using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Users
{
    public interface IAdditionalFieldsRepository
    {
        IEnumerable<AdditionalFields> GetAll(); 
    }
}
