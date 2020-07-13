using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class Footer : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            YearLiteral.Text = DateTime.Today.Year.ToString();

            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumberLiteral.Text = systemInformationRepository.GetSystemVersionNumber();
        }
    }
}