using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.Entity.CallCenter;
using System.Data;
using System.Data.SqlClient;
using Falcon.App.Core.Deprecated.Utility;

namespace Falcon.DataAccess.CallCenter
{
    public class CallCenterDAL
    {
        private string connectionstring = ConnectionHandler.GetConnectionString();
       
        #region "CallCenter"
        
      
       
       
        public Int64 UpdateCall(ECall objCall)
        {
            Int64 returnvalue = new Int64();
            SqlParameter[] arParms = new SqlParameter[17];
            arParms[0] = new SqlParameter("@CallID", SqlDbType.BigInt);
            arParms[0].Value = Convert.ToInt64(objCall.CallID);
            arParms[1] = new SqlParameter("@CallCenterCallCenterUserID", SqlDbType.BigInt);
            arParms[1].Value = Convert.ToInt64(objCall.CallCenterCallCenterUserID);
            arParms[2] = new SqlParameter("@IsNewCustomer", SqlDbType.Bit);
            arParms[2].Value = objCall.IsNewCustomer;

            arParms[3] = new SqlParameter("@CallCustomerID", SqlDbType.BigInt);
            if (objCall.CalledCustomerID.ToString() == "")
                arParms[3].Value = DBNull.Value;
            else
                arParms[3].Value = Convert.ToInt64(objCall.CalledCustomerID);

            arParms[4] = new SqlParameter("@TimeCreated", SqlDbType.DateTime);
            if (objCall.TimeCreated == null || objCall.TimeCreated.ToString() == "")
                arParms[4].Value = DBNull.Value;
            else
                arParms[4].Value = Convert.ToDateTime(objCall.TimeCreated);

            arParms[5] = new SqlParameter("@TimeEnd", SqlDbType.DateTime);
            if (objCall.TimeEnd == null || objCall.TimeEnd.ToString() == "")
                arParms[5].Value = DBNull.Value;
            else
                arParms[5].Value = Convert.ToDateTime(objCall.TimeEnd);

            arParms[6] = new SqlParameter("@CallStatus", SqlDbType.VarChar, 500);
            if (objCall.CallStatus == null)
                arParms[6].Value = DBNull.Value;
            else
                arParms[6].Value = objCall.CallStatus;

            arParms[7] = new SqlParameter("@DateCreated", SqlDbType.DateTime);
            if (objCall.DateCreated == null || objCall.DateCreated.ToString() == "")
                arParms[7].Value = DBNull.Value;
            else
                arParms[7].Value = Convert.ToDateTime(objCall.DateCreated);

            arParms[8] = new SqlParameter("@DateModified", SqlDbType.DateTime);
            if (objCall.DateModified == null || objCall.DateModified.ToString() == "")
                arParms[8].Value = DBNull.Value;
            else
                arParms[8].Value = Convert.ToDateTime(objCall.DateModified);

            arParms[9] = new SqlParameter("@returnCallID", SqlDbType.BigInt);
            arParms[9].Direction = ParameterDirection.Output;

            arParms[10] = new SqlParameter("@CallBackNumber", SqlDbType.VarChar, 100);
            if (objCall.CallBackNumber == null)
                arParms[10].Value = DBNull.Value;
            else
                arParms[10].Value = objCall.CallBackNumber;

            arParms[11]=new SqlParameter("@IncomingPhoneLine",SqlDbType.VarChar,50);
            if (objCall.IncomingPhoneLine == null || objCall.IncomingPhoneLine.ToString() == "")
                arParms[11].Value = DBNull.Value;
            else
                arParms[11].Value=objCall.IncomingPhoneLine;

            arParms[12] = new SqlParameter("@CallersPhoneNumber", SqlDbType.VarChar, 50);
            if (objCall.CallersPhoneNumber == null || objCall.CallersPhoneNumber.ToString() == "")
                arParms[12].Value = DBNull.Value;
            else
                arParms[12].Value = objCall.CallersPhoneNumber;

            arParms[13] = new SqlParameter("@EventID", SqlDbType.BigInt);
            if (objCall.EventID > 0)
                arParms[13].Value = Convert.ToInt64(objCall.EventID);
            else
                arParms[13].Value = DBNull.Value;

            arParms[14] = new SqlParameter("@SourceCode", SqlDbType.VarChar, 50);
            if (objCall.SourceCode == null || objCall.SourceCode.ToString() == "")
                arParms[14].Value = DBNull.Value;
            else
                arParms[14].Value = objCall.SourceCode;

            // Begin Added OutBound Fields[Viranjay]
            arParms[15] = new SqlParameter("@OutBound", SqlDbType.Bit);
            arParms[15].Value = objCall.OutBound;

            arParms[16] = new SqlParameter("@status", SqlDbType.BigInt);
            if (objCall.Status > 0)
                arParms[16].Value = objCall.Status;
            else
                arParms[16].Value = CallStatus.Initiated;

            // End Added OutBound Fields[Viranjay]
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_updatecallinfo", arParms);
            returnvalue = (Int64)arParms[9].Value;
            return returnvalue;
        }


        public List<ECall> GetCalls(Int64 intCCRepID, Int16 inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = intCCRepID;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring,  "usp_getcalls", arParms);
            List<ECall> objCalls = new List<ECall>();
            objCalls = ParseCallsDataSet(tempdataset);
            return objCalls;
        }
        private List<ECall> ParseCallsDataSet(DataSet dtsCalls)
        {
            List<ECall> objCalls = new List<ECall>();

            for (int count = 0; count < dtsCalls.Tables[0].Rows.Count; count++)
            {
                try
                {
                    ECall objCall = new ECall();
                    objCall.CallCenterCallCenterUserID = Convert.ToInt32(dtsCalls.Tables[0].Rows[count]["CallCenterCallCenterUserID"]);
                    //objCall.CalledUserID = Convert.ToInt32(dtsCalls.Tables[0].Rows[count]["CalledCustomerID"]);
                    objCall.CallID = Convert.ToInt32(dtsCalls.Tables[0].Rows[count]["CallID"]);
                    objCall.CallStatus = Convert.ToString(dtsCalls.Tables[0].Rows[count]["CallStatus"]);
                    objCall.DateCreated = Convert.ToString(dtsCalls.Tables[0].Rows[count]["DateCreated"]);
                    objCall.DateModified = Convert.ToString(dtsCalls.Tables[0].Rows[count]["DateModified"]);
                    //objCall.EventID = Convert.ToInt32(dtsCalls.Tables[0].Rows[count]["EventID"]);
                    //objCall.IsNewCustomer = Convert.ToBoolean(dtsCalls.Tables[0].Rows[count]["IsNewCustomer"]);
                    objCall.TimeCreated = Convert.ToString(dtsCalls.Tables[0].Rows[count]["TimeCreated"]);
                    objCall.TimeEnd = Convert.ToString(dtsCalls.Tables[0].Rows[count]["TimeEnd"]);

                    
                    dtsCalls.Tables[1].DefaultView.RowFilter = "CallID =" + objCall.CallID;


                    if (dtsCalls.Tables[1].DefaultView.Count > 0)
                    {
                        List<ECallCenterNotes> objCallNotes = new List<ECallCenterNotes>();
                        DataView dvCallNotes = dtsCalls.Tables[1].DefaultView;
                        int icount = 0;
                        while (icount < dvCallNotes.Count)
                        {
                            ECallCenterNotes objCallNote = new ECallCenterNotes();
                            objCallNote.Notes = Convert.ToString(dvCallNotes[icount]["Notes"]);
                            objCallNote.CallCenterNotesID = Convert.ToInt32(dvCallNotes[icount]["CallCenterNotesID"]);
                            
                            objCallNotes.Add(objCallNote);
                            icount++;
                        }
                        objCall.CallNotes = objCallNotes;
                    }
                    if (dtsCalls.Tables[2] != null)
                    {
                        if (dtsCalls.Tables[2].Rows[0]["TotalCalls"] != DBNull.Value)
                        {
                            objCall.TotalCalls = Convert.ToInt32(dtsCalls.Tables[2].Rows[0]["TotalCalls"]);
                        }
                        else
                        {
                            objCall.TotalCalls = 0;
                        }
                    }


                    objCalls.Add(objCall);
                }
                catch
                {
                }
            }
            return objCalls;
        }


#endregion

        # region "CallCenterCallCenterUser"

        public bool VerifySourceCode(string sourceCode)
        {
            SqlParameter[] arPrams = new SqlParameter[2];

            arPrams[0] = new SqlParameter("@SourceCode", SqlDbType.VarChar, 50);
            arPrams[0].Value = sourceCode;

            arPrams[1] = new SqlParameter("@IsSourceCodeValid", SqlDbType.Bit);
            arPrams[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteScalar(connectionstring, CommandType.StoredProcedure, "usp_VerifySourceCode", arPrams);
            bool returnValue = Convert.ToBoolean(arPrams[1].Value);
            return returnValue;
        }
        #endregion
     
        # region "ScriptType"
        public Int64 SaveScriptType(EScriptType scripttype, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@scripttypeid", SqlDbType.BigInt);
            arParms[0].Value = scripttype.ScriptTypeID;
            arParms[1] = new SqlParameter("@scripttypename", SqlDbType.VarChar, 500);
            arParms[1].Value = scripttype.ScriptName;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = scripttype.Description;
            arParms[3] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[3].Value = Mode;

            arParms[4] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savescripttype", arParms);
            return (Int64)arParms[4].Value;
        }
        public Int64 SaveScriptType(String scripttypeID, int Mode)
        {
            
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@scripttypeid", SqlDbType.VarChar, 3000);
            arParms[0].Value = scripttypeID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removescripttype", arParms);
            return (Int64)arParms[2].Value;
        }
        public List<EScriptType> GetScriptType(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getscripttype", arParms);

            List<EScriptType> returnScriptType = new List<EScriptType>();
            returnScriptType = ParseScriptTypeDataSet(tempdataset);
            return returnScriptType;
        }
        private List<EScriptType> ParseScriptTypeDataSet(DataSet scripttypeDataSet)
        {
            List<EScriptType> returnScriptType = new List<EScriptType>();

            for (int count = 0; count < scripttypeDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EScriptType scripttype = new EScriptType();
                    scripttype.Active = Convert.ToBoolean(scripttypeDataSet.Tables[0].Rows[count]["IsActive"]);
                    scripttype.ScriptTypeID = Convert.ToInt32(scripttypeDataSet.Tables[0].Rows[count]["ScriptTypeID"]);
                    scripttype.Description = Convert.ToString(scripttypeDataSet.Tables[0].Rows[count]["Description"]);
                    scripttype.ScriptName = Convert.ToString(scripttypeDataSet.Tables[0].Rows[count]["ScriptName"]);
                    returnScriptType.Add(scripttype);
                }
                catch
                {
                }
            }
            return returnScriptType;
        }
        #endregion

        #region "Script"
        public Int64 SaveScript(EScript Script, int Mode)
        {
            SqlParameter[] arParms = new SqlParameter[8];
            arParms[0] = new SqlParameter("@scriptid", SqlDbType.BigInt);
            arParms[0].Value = Script.ScriptID;
            arParms[1] = new SqlParameter("@scriptname", SqlDbType.VarChar, 500);
            arParms[1].Value = Script.Name;
            arParms[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            arParms[2].Value = Script.Description;
            arParms[3] = new SqlParameter("@scripttext", SqlDbType.VarChar, 1000);
            arParms[3].Value = Script.ScriptText;
            arParms[4] = new SqlParameter("@scripttypeid", SqlDbType.BigInt);
            arParms[4].Value = Script.ScriptType.ScriptTypeID;
            arParms[5] = new SqlParameter("@isdefault", SqlDbType.Bit);
            arParms[5].Value = Script.Default;
            arParms[6] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[6].Value = Mode;

            arParms[7] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_savescript", arParms);
            return (Int64)arParms[7].Value;
        }

        public Int64 SaveScript(String ScriptID, int Mode)
        {
            
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@scriptid", SqlDbType.VarChar, 3000);
            arParms[0].Value = ScriptID;
            arParms[1] = new SqlParameter("@rowstate", SqlDbType.TinyInt);
            arParms[1].Value = Mode;
            arParms[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt);
            arParms[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "usp_removescript", arParms);
            return  (Int64)arParms[2].Value;
            
        }
        public List<EScript> GetScript(String filterString, int inputMode)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@filterString", SqlDbType.VarChar, 500);
            arParms[0].Value = filterString;
            arParms[1] = new SqlParameter("@mode", SqlDbType.TinyInt);
            arParms[1].Value = inputMode;
            DataSet tempdataset = new DataSet();
            tempdataset = SqlHelper.ExecuteDataset(connectionstring, "usp_getscript", arParms);

            List<EScript> returnScript = new List<EScript>();
            returnScript = ParseScriptDataSet(tempdataset);
            return returnScript;
        }
        private List<EScript> ParseScriptDataSet(DataSet scriptDataSet)
        {
            List<EScript> returnScript = new List<EScript>();

            for (int count = 0; count < scriptDataSet.Tables[0].Rows.Count; count++)
            {
                try
                {
                    EScript script = new EScript();
                    EScriptType scripttype = new EScriptType();
                    scripttype.ScriptTypeID = Convert.ToInt32(scriptDataSet.Tables[0].Rows[count]["ScriptTypeID"]);
                    scripttype.ScriptName = Convert.ToString(scriptDataSet.Tables[0].Rows[count]["ScriptTypeName"]);
                    script.Active = Convert.ToBoolean(scriptDataSet.Tables[0].Rows[count]["IsActive"]);
                    script.Default = Convert.ToBoolean(scriptDataSet.Tables[0].Rows[count]["IsDefault"]);
                    script.ScriptID = Convert.ToInt32(scriptDataSet.Tables[0].Rows[count]["ScriptID"]);
                    script.Description = Convert.ToString(scriptDataSet.Tables[0].Rows[count]["Description"]);
                    script.ScriptText = Convert.ToString(scriptDataSet.Tables[0].Rows[count]["ScriptText"]);
                    script.Name = Convert.ToString(scriptDataSet.Tables[0].Rows[count]["Name"]);
                    script.ScriptType = scripttype;
                    returnScript.Add(script);
                }
                catch(Exception)
                {
                }
            }
            return returnScript;
        }
        #endregion
    }
}
