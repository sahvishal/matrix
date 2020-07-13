using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Falcon.Entity.Other;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class CityStateWidget : System.Web.UI.UserControl
    {
        public string SelectedCityName
        {
            get { return _txtSearchBox.Value; }
            set { _txtSearchBox.Value = value; }
        }

        public string SelectedCityId
        {
            get { return _hdnCityId.Value; }
            set { _hdnCityId.Value = value; }
        }

        public string CountryId
        {
            get;
            set;
        }

        public string  StateId
        {
            get
            {
                return _ddlState.SelectedValue;
            }
        }

        public string StateName
        {
            get
            {
                return _ddlState.SelectedItem.Text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            var masterDal = new Falcon.DataAccess.Master.MasterDAL();

            if (string.IsNullOrEmpty(CountryId))
            {
                CountryId = masterDal.GetCountry(string.Empty, 3).FirstOrDefault().CountryID.ToString();
            }

            List<Falcon.Entity.Other.EState> states = masterDal.GetState(string.Empty, 3);

            _ddlState.Items.Clear();
            _ddlState.Items.Add(new ListItem("Select State", "0"));

            _ddlState.Items.AddRange(states.Where<EState>(state => state.Country.CountryID.ToString() == CountryId).Select<EState, ListItem>(state => new ListItem(HttpUtility.HtmlEncode(state.Name), HttpUtility.HtmlEncode(state.StateID.ToString()))).ToArray<ListItem>());
        }
    }
}