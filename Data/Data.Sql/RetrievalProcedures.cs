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
using SD.LLBLGen.Pro.ORMSupportClasses;
namespace Falcon.Data.Sql
{
	/// <summary>
	/// Class which contains the static logic to execute retrieval stored procedures in the database.
	/// </summary>
	public partial class RetrievalProcedures
	{
		/// <summary>
		/// private CTor so no instance can be created.
		/// </summary>
		private RetrievalProcedures()
		{
		}

	
		/// <summary>
		/// Calls stored procedure 'usp_getShippingDetailInfo'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="rowIndex">Input parameter of stored procedure</param>
		/// <param name="pageSize">Input parameter of stored procedure</param>
		/// <param name="status">Input parameter of stored procedure</param>
		/// <param name="shippingOptionId">Input parameter of stored procedure</param>
		/// <param name="eventId">Input parameter of stored procedure</param>
		/// <param name="podId">Input parameter of stored procedure</param>
		/// <param name="startDate">Input parameter of stored procedure</param>
		/// <param name="endDate">Input parameter of stored procedure</param>
		/// <param name="isResultReady">Input parameter of stored procedure</param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet GetShippingDetailInfo(System.Int32 rowIndex, System.Int32 pageSize, System.Int32 status, System.Int32 shippingOptionId, System.Int64 eventId, System.Int32 podId, System.String startDate, System.String endDate, System.Boolean isResultReady)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return GetShippingDetailInfo(rowIndex, pageSize, status, shippingOptionId, eventId, podId, startDate, endDate, isResultReady,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'usp_getShippingDetailInfo'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="rowIndex">Input parameter of stored procedure</param>
		/// <param name="pageSize">Input parameter of stored procedure</param>
		/// <param name="status">Input parameter of stored procedure</param>
		/// <param name="shippingOptionId">Input parameter of stored procedure</param>
		/// <param name="eventId">Input parameter of stored procedure</param>
		/// <param name="podId">Input parameter of stored procedure</param>
		/// <param name="startDate">Input parameter of stored procedure</param>
		/// <param name="endDate">Input parameter of stored procedure</param>
		/// <param name="isResultReady">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet GetShippingDetailInfo(System.Int32 rowIndex, System.Int32 pageSize, System.Int32 status, System.Int32 shippingOptionId, System.Int64 eventId, System.Int32 podId, System.String startDate, System.String endDate, System.Boolean isResultReady, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[9];
			parameters[0] = new SqlParameter("@RowIndex", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, rowIndex);
			parameters[1] = new SqlParameter("@PageSize", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, pageSize);
			parameters[2] = new SqlParameter("@Status", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, status);
			parameters[3] = new SqlParameter("@ShippingOptionID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, shippingOptionId);
			parameters[4] = new SqlParameter("@EventID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, eventId);
			parameters[5] = new SqlParameter("@PodID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, podId);
			parameters[6] = new SqlParameter("@StartDate", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, startDate);
			parameters[7] = new SqlParameter("@EndDate", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, endDate);
			parameters[8] = new SqlParameter("@IsResultReady", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, isResultReady);

			DataSet toReturn = new DataSet("GetShippingDetailInfo");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[Falcon].[dbo].[usp_getShippingDetailInfo]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'usp_getShippingDetailInfo'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="rowIndex">Input parameter of stored procedure</param>
		/// <param name="pageSize">Input parameter of stored procedure</param>
		/// <param name="status">Input parameter of stored procedure</param>
		/// <param name="shippingOptionId">Input parameter of stored procedure</param>
		/// <param name="eventId">Input parameter of stored procedure</param>
		/// <param name="podId">Input parameter of stored procedure</param>
		/// <param name="startDate">Input parameter of stored procedure</param>
		/// <param name="endDate">Input parameter of stored procedure</param>
		/// <param name="isResultReady">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet GetShippingDetailInfo(System.Int32 rowIndex, System.Int32 pageSize, System.Int32 status, System.Int32 shippingOptionId, System.Int64 eventId, System.Int32 podId, System.String startDate, System.String endDate, System.Boolean isResultReady, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return GetShippingDetailInfo(rowIndex, pageSize, status, shippingOptionId, eventId, podId, startDate, endDate, isResultReady, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'usp_getShippingDetailInfo'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="rowIndex">Input parameter of stored procedure</param>
		/// <param name="pageSize">Input parameter of stored procedure</param>
		/// <param name="status">Input parameter of stored procedure</param>
		/// <param name="shippingOptionId">Input parameter of stored procedure</param>
		/// <param name="eventId">Input parameter of stored procedure</param>
		/// <param name="podId">Input parameter of stored procedure</param>
		/// <param name="startDate">Input parameter of stored procedure</param>
		/// <param name="endDate">Input parameter of stored procedure</param>
		/// <param name="isResultReady">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet GetShippingDetailInfo(System.Int32 rowIndex, System.Int32 pageSize, System.Int32 status, System.Int32 shippingOptionId, System.Int64 eventId, System.Int32 podId, System.String startDate, System.String endDate, System.Boolean isResultReady, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[9 + 1];
			parameters[0] = new SqlParameter("@RowIndex", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, rowIndex);
			parameters[1] = new SqlParameter("@PageSize", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, pageSize);
			parameters[2] = new SqlParameter("@Status", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, status);
			parameters[3] = new SqlParameter("@ShippingOptionID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, shippingOptionId);
			parameters[4] = new SqlParameter("@EventID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, eventId);
			parameters[5] = new SqlParameter("@PodID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, podId);
			parameters[6] = new SqlParameter("@StartDate", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, startDate);
			parameters[7] = new SqlParameter("@EndDate", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, endDate);
			parameters[8] = new SqlParameter("@IsResultReady", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, isResultReady);

			parameters[9] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataSet toReturn = new DataSet("GetShippingDetailInfo");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[Falcon].[dbo].[usp_getShippingDetailInfo]", parameters, toReturn);


			returnValue = (int)parameters[9].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'usp_getShippingDetailInfo'.
		/// 
		/// </summary>
		/// <param name="rowIndex">Input parameter of stored procedure</param>
		/// <param name="pageSize">Input parameter of stored procedure</param>
		/// <param name="status">Input parameter of stored procedure</param>
		/// <param name="shippingOptionId">Input parameter of stored procedure</param>
		/// <param name="eventId">Input parameter of stored procedure</param>
		/// <param name="podId">Input parameter of stored procedure</param>
		/// <param name="startDate">Input parameter of stored procedure</param>
		/// <param name="endDate">Input parameter of stored procedure</param>
		/// <param name="isResultReady">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetGetShippingDetailInfoCallAsQuery( System.Int32 rowIndex, System.Int32 pageSize, System.Int32 status, System.Int32 shippingOptionId, System.Int64 eventId, System.Int32 podId, System.String startDate, System.String endDate, System.Boolean isResultReady)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[Falcon].[dbo].[usp_getShippingDetailInfo]" ) );
			toReturn.Parameters.Add(new SqlParameter("@RowIndex", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, rowIndex));
			toReturn.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, pageSize));
			toReturn.Parameters.Add(new SqlParameter("@Status", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, status));
			toReturn.Parameters.Add(new SqlParameter("@ShippingOptionID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, shippingOptionId));
			toReturn.Parameters.Add(new SqlParameter("@EventID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, eventId));
			toReturn.Parameters.Add(new SqlParameter("@PodID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, podId));
			toReturn.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, startDate));
			toReturn.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, endDate));
			toReturn.Parameters.Add(new SqlParameter("@IsResultReady", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, isResultReady));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		#region Included Code

		#endregion
	}
}
