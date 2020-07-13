///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:55
// Code is generated using templates: SD.TemplateBindings.SqlServerSpecific.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlClient;

namespace Falcon.Data.Sql
{
	/// <summary>
	/// Class which contains the static logic to execute action stored procedures in the database.
	/// </summary>
	public partial class ActionProcedures
	{
		/// <summary>
		/// private CTor so no instance can be created.
		/// </summary>
		private ActionProcedures()
		{
		}

	
		/// <summary>
		/// Delegate definition for stored procedure 'usp_AFGenerateAffiliateCommission' to be used in combination of a UnitOfWork2 object. 
		/// </summary>
		public delegate int GenerateAffiliateCommissionCallBack(System.Int64 eventCustomerId, DataAccessAdapter adapter);

		/// <summary>
		/// Calls stored procedure 'usp_AFGenerateAffiliateCommission'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="eventCustomerId">Input parameter of stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int GenerateAffiliateCommission(System.Int64 eventCustomerId)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return GenerateAffiliateCommission(eventCustomerId,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'usp_AFGenerateAffiliateCommission'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="eventCustomerId">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int GenerateAffiliateCommission(System.Int64 eventCustomerId, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[1];
			parameters[0] = new SqlParameter("@EventCustomerID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, eventCustomerId);

			int toReturn = adapter.CallActionStoredProcedure("[Falcon].[dbo].[usp_AFGenerateAffiliateCommission]", parameters);

			return toReturn;
		}
		

		/// <summary>
		/// Calls stored procedure 'usp_AFGenerateAffiliateCommission'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="eventCustomerId">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int GenerateAffiliateCommission(System.Int64 eventCustomerId, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return GenerateAffiliateCommission(eventCustomerId, ref returnValue, adapter);
			}
		}

		
		/// <summary>
		/// Calls stored procedure 'usp_AFGenerateAffiliateCommission'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="eventCustomerId">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int GenerateAffiliateCommission(System.Int64 eventCustomerId, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[1 + 1];
			parameters[0] = new SqlParameter("@EventCustomerID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, eventCustomerId);

			parameters[1] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			int toReturn = adapter.CallActionStoredProcedure("[Falcon].[dbo].[usp_AFGenerateAffiliateCommission]", parameters);

			
			returnValue = (int)parameters[1].Value;
			return toReturn;
		}
	

		/// <summary>
		/// Delegate definition for stored procedure 'usp_AFSaveEventAffiliate' to be used in combination of a UnitOfWork2 object. 
		/// </summary>
		public delegate int SaveEventAffiliateCallBack(System.Int64 eventcustomerid, System.Int64 callid, ref System.Int64 returnvalue, DataAccessAdapter adapter);

		/// <summary>
		/// Calls stored procedure 'usp_AFSaveEventAffiliate'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="eventcustomerid">Input parameter of stored procedure</param>
		/// <param name="callid">Input parameter of stored procedure</param>
		/// <param name="returnvalue">InputOutput parameter of stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int SaveEventAffiliate(System.Int64 eventcustomerid, System.Int64 callid, ref System.Int64 returnvalue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return SaveEventAffiliate(eventcustomerid, callid, ref returnvalue,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'usp_AFSaveEventAffiliate'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="eventcustomerid">Input parameter of stored procedure</param>
		/// <param name="callid">Input parameter of stored procedure</param>
		/// <param name="returnvalue">InputOutput parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int SaveEventAffiliate(System.Int64 eventcustomerid, System.Int64 callid, ref System.Int64 returnvalue, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[3];
			parameters[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, eventcustomerid);
			parameters[1] = new SqlParameter("@callid", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, callid);
			parameters[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt, 0, ParameterDirection.InputOutput, true, 19, 0, "",  DataRowVersion.Current, returnvalue);
			int toReturn = adapter.CallActionStoredProcedure("[Falcon].[dbo].[usp_AFSaveEventAffiliate]", parameters);
			if(parameters[2].Value!=System.DBNull.Value)
			{
				returnvalue = (System.Int64)parameters[2].Value;
			}
			return toReturn;
		}
		

		/// <summary>
		/// Calls stored procedure 'usp_AFSaveEventAffiliate'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="eventcustomerid">Input parameter of stored procedure</param>
		/// <param name="callid">Input parameter of stored procedure</param>
		/// <param name="returnvalue">InputOutput parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int SaveEventAffiliate(System.Int64 eventcustomerid, System.Int64 callid, ref System.Int64 returnvalue, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return SaveEventAffiliate(eventcustomerid, callid, ref returnvalue, ref returnValue, adapter);
			}
		}

		
		/// <summary>
		/// Calls stored procedure 'usp_AFSaveEventAffiliate'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="eventcustomerid">Input parameter of stored procedure</param>
		/// <param name="callid">Input parameter of stored procedure</param>
		/// <param name="returnvalue">InputOutput parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int SaveEventAffiliate(System.Int64 eventcustomerid, System.Int64 callid, ref System.Int64 returnvalue, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[3 + 1];
			parameters[0] = new SqlParameter("@eventcustomerid", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, eventcustomerid);
			parameters[1] = new SqlParameter("@callid", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, callid);
			parameters[2] = new SqlParameter("@returnvalue", SqlDbType.BigInt, 0, ParameterDirection.InputOutput, true, 19, 0, "",  DataRowVersion.Current, returnvalue);
			parameters[3] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			int toReturn = adapter.CallActionStoredProcedure("[Falcon].[dbo].[usp_AFSaveEventAffiliate]", parameters);
			if(parameters[2].Value!=System.DBNull.Value)
			{
				returnvalue = (System.Int64)parameters[2].Value;
			}
			
			returnValue = (int)parameters[3].Value;
			return toReturn;
		}
	

		#region Included Code

		#endregion
	}
}
