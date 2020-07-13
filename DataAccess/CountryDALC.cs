using System;
using System.Collections.Generic;
using System.Text;


using BMSEntity;
using System.Data;
using System.Data.SqlClient;
 
 
namespace BMSDataAccess
{
    public sealed class CountryDALC
    {
        private static string connectionstring = "";

        public static bool SaveCountry(Country Country, int mode)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@countryid", SqlDbType.BigInt);
            arParms[0].Value = Country.CountryID;
            arParms[1] = new SqlParameter("@countryname", SqlDbType.VarChar,500 );
            arParms[1].Value = Country.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = Country.Description ;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = mode;
            int returnvalue = SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_setcountry", arParms);
            return true; 
        }
    }
}
