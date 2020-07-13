using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class SystemVersion : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            SystemVersionLiteral.Text = systemInformationRepository.GetSystemVersionNumber();
        }
    }
}