using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class App_MarketingPartner_CalculateService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn=new SqlConnection();
        SqlCommand cmd=new SqlCommand();
        try
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            cn = new SqlConnection(strConnectionString);
            cn.Open();
            cmd = new SqlCommand("usp_AFGenerateCommissionforCPMCampaign", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(typeof(string), "bujscode", "alert('Done');", true);
        }
        catch (Exception)
        {

        }
        finally
        {
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
        }
    }
}