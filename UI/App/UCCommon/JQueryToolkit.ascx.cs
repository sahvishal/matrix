namespace Falcon.App.UI.App.UCCommon
{
    public partial class JQueryToolkit : System.Web.UI.UserControl
    {
        public const string INCLUDE_KEY = "IncludeJQuery";

        public bool IncludeJQueryMaskInput { get; set; }
        public bool IncludeJTemplate { get; set; }
        public bool IncludeJQueryUI { get; set; }
        public bool IncludeJQueryThickBox { get; set; }
        public bool IncludePaging { get; set; }
        public bool IncludeAjax { get; set; }
        public bool IncudeJQuerySelectable { get; set; }
        public bool IncudeJQueryJTip { get; set; }
        public bool IncudeJQueryAutoComplete { get; set; }
        public bool IncludeSexyComboBox { get; set; }
        public bool IncludeJQueryCorner { get; set; }
        public bool IncludeJQueryCookie { get; set; }
        public bool IncludeJQueryValidators { get; set; }
        public bool IncludeJQueryBounceBox { get; set; }
        public bool IncludeJQueryWaterMark { get; set; }

        protected override void OnInit(System.EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered(INCLUDE_KEY))
                //Commented this section - This script is written below the page. This is the reason JTip was not appearing in Public site
                //this.Page.ClientScript.RegisterClientScriptInclude(INCLUDE_KEY, ResolveUrl("~/App/jquery/js/jquery-1.5.1.min.js"));
            base.OnInit(e);
        }
    }
}