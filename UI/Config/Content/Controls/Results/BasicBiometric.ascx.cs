using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class BasicBiometric : System.Web.UI.UserControl
    {

        protected bool ShowBasicBiometric
        {
            get
            {
                var configRepository = IoC.Resolve<IConfigurationSettingRepository>();
                var val = configRepository.GetConfigurationValue(ConfigurationSettingName.ShowBasicBiometric);

                bool showBasicBiometric = true;

                Boolean.TryParse(val, out showBasicBiometric);

                return showBasicBiometric;
            }
        }

        public bool ShowByCutOffDate { get; set; }

        public bool Disabled { get; set; }
        public bool EnableAbnormalBp { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // BasicBiometricDiv.Visible = ShowBasicBiometric;
            if (ShowBasicBiometric && ShowByCutOffDate)
            {
                BasicBiometricDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
        }
    }
}