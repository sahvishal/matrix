using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface IGmsCallParserHelper
    {
        string CheckForColumns(DataRow row);
        GmsDialerCallModel GetGmsDialerCallModel(DataRow row);
    }
}
