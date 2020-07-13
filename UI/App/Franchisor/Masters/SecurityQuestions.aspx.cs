using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.DataAccess.Master;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
using Falcon.Entity.Other;

public partial class Franchisor_Masters_SecurityQuestions : System.Web.UI.Page
{
    /// <summary>
    /// post back of page is checked.all the active SecurityQuestion from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "SecurityQuestion";
        errordiv.InnerHtml = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("SecurityQuestion");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortDir"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchSecurityQuestion(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetSecurityQuestion();
            }
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrsqelemclientid", "'" + grdSecurityQuestion.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrsqelemclientid", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrsqelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrsqelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrsqelemclientid", "'" + hfSecurityQuestionID.ClientID + "'");

    }

    /// <summary>
    /// This method searches for the SecurityQuestion by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchSecurityQuestion(string searchtext)
    {

        MasterDAL masterDal = new MasterDAL();
        System.Collections.Generic.List<Falcon.Entity.Other.ESecurityQuestion> listSecurityQuestions = masterDal.GetSecurityQuestion(searchtext, 2);

        Falcon.Entity.Other.ESecurityQuestion[] securityquestion = null;
        if (listSecurityQuestions != null)
            securityquestion = listSecurityQuestions.ToArray();


        //SecurityQuestionService service = new SecurityQuestionService();
        //HealthYes.Web.UI.SecurityQuestionService.ESecurityQuestion[] securityquestion;
        //securityquestion = service.GetSecurityQuestionByName(searchtext);

        DataTable dtSecurityQuestion = new DataTable();
        dtSecurityQuestion.Columns.Add("SecurityQuestionID", typeof(Int32));
        dtSecurityQuestion.Columns.Add("name");
        dtSecurityQuestion.Columns.Add("description");
        dtSecurityQuestion.Columns.Add("active");

        if (securityquestion != null)
        {
            for (int icount = 0; icount < securityquestion.Length; icount++)
            {
                if (securityquestion[icount].Active.ToString().Equals("True"))
                {
                    dtSecurityQuestion.Rows.Add(new object[] { securityquestion[icount].SecurityQuestionID, securityquestion[icount].Name, securityquestion[icount].Description, "Active" });
                }
                else
                    dtSecurityQuestion.Rows.Add(new object[] { securityquestion[icount].SecurityQuestionID, securityquestion[icount].Name, securityquestion[icount].Description, "Deactivated" });
            }
        }

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
        {
            dtSecurityQuestion.DefaultView.Sort = "name desc";
        }
        else
        {
            dtSecurityQuestion.DefaultView.Sort = "name asc";
        }
        dtSecurityQuestion = dtSecurityQuestion.DefaultView.ToTable();

        grdSecurityQuestion.DataSource = dtSecurityQuestion;
        ViewState["DSGRID"] = dtSecurityQuestion;
        grdSecurityQuestion.DataBind();

        txtName.Text = "";
        txtDescription.Text = "";
        hfSecurityQuestionID.Value = "";
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the SecurityQuestions. 
    /// </summary>
    private void GetSecurityQuestion()
    {
        MasterDAL masterDal = new MasterDAL();
        System.Collections.Generic.List<Falcon.Entity.Other.ESecurityQuestion> listSecurityQuestions = masterDal.GetSecurityQuestion(string.Empty, 0);

        Falcon.Entity.Other.ESecurityQuestion[] securityquestion = null;
        if (listSecurityQuestions != null)
            securityquestion = listSecurityQuestions.ToArray();

        //SecurityQuestionService service = new SecurityQuestionService();
        //HealthYes.Web.UI.SecurityQuestionService.ESecurityQuestion[] securityquestion;
        //securityquestion = service.GetAllSecurityQuestion();

        DataTable dtSecurityQuestion = new DataTable();
        dtSecurityQuestion.Columns.Add("SecurityQuestionID");
        dtSecurityQuestion.Columns.Add("name");
        dtSecurityQuestion.Columns.Add("description");
        dtSecurityQuestion.Columns.Add("active");

        if(securityquestion != null)
        {
            for (int icount = 0; icount < securityquestion.Length; icount++)
            {
                if (securityquestion[icount].Active.ToString().Equals("True"))
                {
                    dtSecurityQuestion.Rows.Add(new object[] { securityquestion[icount].SecurityQuestionID, securityquestion[icount].Name, securityquestion[icount].Description, "Active" });
                }
                else
                    dtSecurityQuestion.Rows.Add(new object[] { securityquestion[icount].SecurityQuestionID, securityquestion[icount].Name, securityquestion[icount].Description, "Deactivated" });
            }
        }

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
        {
            dtSecurityQuestion.DefaultView.Sort = "name desc";
        }
        else
        {
            dtSecurityQuestion.DefaultView.Sort = "name asc";
        }
        dtSecurityQuestion = dtSecurityQuestion.DefaultView.ToTable();

        grdSecurityQuestion.DataSource = dtSecurityQuestion;
        ViewState["DSGRID"] = dtSecurityQuestion;
        grdSecurityQuestion.DataBind();

        txtName.Text = "";
        txtDescription.Text = "";
        hfSecurityQuestionID.Value = "";
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the SecurityQuestion which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateSecurityQuestion()
    {
        MasterDAL masterDal = new MasterDAL();
        var securityquestion = new ESecurityQuestion();

        securityquestion.Description = txtDescription.Text;
        securityquestion.Name = txtName.Text;

        securityquestion.Active = true;
        Int64 returnresult;
        if (hfSecurityQuestionID.Value.ToString().Equals(""))
        {
            returnresult = masterDal.SaveSecurityQuestion(securityquestion, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }
            //service.AddSecurityQuestion(securityquestion, usershellmodulerole1, out returnresult, out temp);
        }
        else
        {
            securityquestion.SecurityQuestionID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdSecurityQuestion.Rows[Convert.ToInt32(hfSecurityQuestionID.Value)].DataItemIndex]["SecurityQuestionID"]);
            returnresult = masterDal.SaveSecurityQuestion(securityquestion, Convert.ToInt32(EOperationMode.Update));
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }

            //service.UpdateSecurityQuestion(securityquestion, usershellmodulerole1, out returnresult, out temp);
        }
        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        hfSecurityQuestionID.Value = "";
        GetSecurityQuestion();

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateSecurityQuestion 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateSecurityQuestion();

        this.ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used to delete the selected SecurityQuestion(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        MasterDAL masterDal = new MasterDAL();
        var securityQuestions = GetSelectedSecurityQuestion();


        if (securityQuestions.Length > 0)
        {
            returnresult = masterDal.SaveSecurityQuestion(securityQuestions, Convert.ToInt32(EOperationMode.Delete));
            if (returnresult == 0)
            {
                returnresult = 9999992;
            }

            GetSecurityQuestion();
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfSecurityQuestionID.Value = "";
        }
    }

    /// <summary>
    /// Gets the selected security question.
    /// </summary>
    /// <returns></returns>
    private string GetSelectedSecurityQuestion()
    {
        string strSelectedQuestion = "";

        for (int i = 0; i < grdSecurityQuestion.Rows.Count; i++)
        {
            HtmlInputCheckBox chkSecurityQuestionSelecter = new HtmlInputCheckBox();
            chkSecurityQuestionSelecter = (HtmlInputCheckBox)grdSecurityQuestion.Rows[i].FindControl("chkRowChild");
            if (chkSecurityQuestionSelecter.Checked == true)
            {
                strSelectedQuestion = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdSecurityQuestion.Rows[i].DataItemIndex]["SecurityQuestionID"]).ToString() + ", ";
            }
        }
        if (strSelectedQuestion.Length > 0)
            strSelectedQuestion = strSelectedQuestion.Remove(strSelectedQuestion.LastIndexOf(", "));

        return strSelectedQuestion;
    }

    /// <summary>
    /// this method is used for deactivating the selected SecurityQuestion(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        MasterDAL masterDal = new MasterDAL();
        var securityQuestions = GetSelectedSecurityQuestion();
        
        if (securityQuestions.Length > 0)
        {
            returnresult = masterDal.SaveSecurityQuestion(securityQuestions, Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfSecurityQuestionID.Value = "";
            GetSecurityQuestion();
        }
    }

    /// <summary>
    /// this method is used for activating the selected SecurityQuestion(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        
        var securityQuestions = GetSelectedSecurityQuestion();
        
        if (securityQuestions.Length > 0)
        {
            MasterDAL masterDal = new MasterDAL();
            returnresult = masterDal.SaveSecurityQuestion(securityQuestions, Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfSecurityQuestionID.Value = "";
            GetSecurityQuestion();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdSecurityQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                chktemprow.Attributes["onClick"] = "checkallboxes()";
            }
        }
    }

    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdSecurityQuestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdSecurityQuestion.PageIndex = e.NewPageIndex;
        grdSecurityQuestion.DataSource = (DataTable)ViewState["DSGRID"];
        grdSecurityQuestion.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit Security Question";
        this.ModalPopupExtender.Show();
    }

    /// <summary>
    /// this method is used to close the modular popup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdSecurityQuestion_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtSecurityQuestions = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtSecurityQuestions.DefaultView.Sort = "name desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        else
        {
            dtSecurityQuestions.DefaultView.Sort = "name asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        dtSecurityQuestions = dtSecurityQuestions.DefaultView.ToTable();
        grdSecurityQuestion.DataSource = dtSecurityQuestions;
        grdSecurityQuestion.DataBind();
        ViewState["DSGRID"] = dtSecurityQuestions;

    }

}
