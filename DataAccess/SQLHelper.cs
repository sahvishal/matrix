using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using Falcon.App.Core.Deprecated.Utility;


namespace Falcon.DataAccess
{
	/// <summary>
	/// The SqlHelper class is intended to encapsulate high performance, scalable best practices for 
	/// common uses of SqlClient.
	/// </summary>
	public sealed class SqlHelper
	{
        
		#region private utility methods & constructors
        private static string configConnectionString = ConnectionHandler.GetConnectionString();
		//Since this class provides only static methods, make the default constructor private to prevent 
		//instances from being created with "new SqlHelper()".
		private SqlHelper() {}



		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// 
		/// This method will assign a value of DbNull to any parameter with a direction of
		/// InputOutput and a value of null.  
		/// 
		/// This behavior will prevent default values from being used, but
		/// this will be the less common case than an intended pure output parameter (derived as InputOutput)
		/// where the user provided no input value.
		/// </summary>
		/// <param name="command">The command to which the parameters will be added</param>
		/// <param name="commandParameters">an array of SqlParameters tho be added to command</param>
		private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
		{
			foreach (SqlParameter p in commandParameters)
			{
				//check for derived output value with no value assigned
				if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
				{
					p.Value = DBNull.Value;
				}
				
				command.Parameters.Add(p);
			}
		}

		/// <summary>
		/// This method assigns an array of values to an array of SqlParameters.
		/// </summary>
		/// <param name="commandParameters">array of SqlParameters to be assigned values</param>
		/// <param name="parameterValues">array of objects holding the values to be assigned</param>
		private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
		{
			if ((commandParameters == null) || (parameterValues == null)) 
			{
				//do nothing if we get no data
				return;
			}

			// we must have the same number of values as we pave parameters to put them in
			if (commandParameters.Length != parameterValues.Length)
			{
				throw new ArgumentException("Parameter count does not match Parameter Value count.");
			}

			//iterate through the SqlParameters, assigning the values from the corresponding position in the 
			//value array
			for (int i = 0, j = commandParameters.Length; i < j; i++)
			{
				commandParameters[i].Value = parameterValues[i];
			}
		}

		/// <summary>
		/// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
		/// to the provided command.
		/// </summary>
		/// <param name="command">the SqlCommand to be prepared</param>
		/// <param name="connection">a valid SqlConnection, on which to execute this command</param>
		/// <param name="transaction">a valid SqlTransaction, or 'null'</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParameters to be associated with the command or 'null' if no parameters are required</param>
		private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
		{
			//if the provided connection is not open, we will open it
			if (connection.State != ConnectionState.Open)
			{
				connection.Open();
			}

			//associate the connection with the command
			command.Connection = connection;

			//set the command text (stored procedure name or SQL statement)
			command.CommandText = commandText;

			//if we were provided a transaction, assign it.
			if (transaction != null)
			{
				command.Transaction = transaction;
			}

			//set the command type
			command.CommandType = commandType;

			//attach the command parameters if they are provided
			if (commandParameters != null)
			{
				AttachParameters(command, commandParameters);
			}

			return;
		}


		#endregion private utility methods & constructors

		#region ExecuteNonQuery

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
            return ExecuteNonQuery(configConnectionString, commandType, commandText, (SqlParameter[])null);
		}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			//create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(configConnectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a SqlCommand (that returns no resultset) against the database specified in 
		/// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, "PublishOrders", 24, 36);
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="spName">the name of the stored prcedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of SqlParameters
				return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
		}

        ///// <summary>
        ///// Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlConnection. 
        ///// </summary>
        ///// <remarks>
        ///// e.g.:  
        /////  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
        ///// </remarks>
        ///// <param name="connection">a valid SqlConnection</param>
        ///// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        ///// <param name="commandText">the stored procedure name or T-SQL command</param>
        ///// <returns>an int representing the number of rows affected by the command</returns>
        //public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
        //{
        //    //pass through the call providing null for the set of SqlParameters
        //    return ExecuteNonQuery(connection, commandType, commandText, (SqlParameter[])null);
        //}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) against the specified SqlConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{	
			//create a command and prepare it for execution
			SqlCommand cmd = new SqlCommand();
			PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            int retval = 0;
			//finally, execute the command.
            try
            {
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception) 
            {

            }
            finally
            {
            }
			
			// detach the SqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
			return retval;
		}

        ///// <summary>
        ///// Execute a stored procedure via a SqlCommand (that returns no resultset) against the specified SqlConnection 
        ///// using the provided parameter values.  This method will query the database to discover the parameters for the 
        ///// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
        ///// </summary>
        ///// <remarks>
        ///// This method provides no access to output parameters or the stored procedure's return value parameter.
        ///// 
        ///// e.g.:  
        /////  int result = ExecuteNonQuery(conn, "PublishOrders", 24, 36);
        ///// </remarks>
        ///// <param name="connection">a valid SqlConnection</param>
        ///// <param name="spName">the name of the stored procedure</param>
        ///// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
        ///// <returns>an int representing the number of rows affected by the command</returns>
        //public static int ExecuteNonQuery(SqlConnection connection, string spName, params object[] parameterValues)
        //{
        //    //if we receive parameter values, we need to figure out where they go
        //    if ((parameterValues != null) && (parameterValues.Length > 0)) 
        //    {
        //        //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
        //        SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

        //        //assign the provided values to these parameters based on parameter order
        //        AssignParameterValues(commandParameters, parameterValues);

        //        //call the overload that takes an array of SqlParameters
        //        return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
        //    }
        //        //otherwise we can just call the SP without params
        //    else 
        //    {
        //        return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
        //    }
        //}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="transaction">a valid SqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteNonQuery(transaction, commandType, commandText, (SqlParameter[])null);
		}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) against the specified SqlTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid SqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			SqlCommand cmd = new SqlCommand();
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
			
			int retval = 0;
            //finally, execute the command.
            try
            {
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                var message=ex.Message;
            }
            finally
            {
            }
			
			// detach the SqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
			return retval;
		}

		/// <summary>
		/// Execute a stored procedure via a SqlCommand (that returns no resultset) against the specified 
		/// SqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, trans, "PublishOrders", 24, 36);
		/// </remarks>
		/// <param name="transaction">a valid SqlTransaction</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of SqlParameters
				return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
		}


		#endregion ExecuteNonQuery

		#region ExecuteDataSet

        ///// <summary>
        ///// Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
        ///// using the provided parameters.
        ///// </summary>
        ///// <remarks>
        ///// e.g.:  
        /////  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
        ///// </remarks>
        ///// <param name="connectionString">a valid connection string for a SqlConnection</param>
        ///// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        ///// <param name="commandText">the stored procedure name or T-SQL command</param>
        ///// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        ///// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, string commandText, params SqlParameter[] commandParameters)
		{
			//create & open a SqlConnection, and dispose of it after we are done.
			using (SqlConnection cn = new SqlConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
                return ExecuteDataset(cn, CommandType.StoredProcedure, commandText, commandParameters);
			}
		}
        
		/// <summary>
		/// Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		private static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
			PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
			
			//create the DataAdapter & DataSet
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();

			//fill the DataSet using default values for DataTable names, etc.
			da.Fill(ds);
			
			// detach the SqlParameters from the command object, so they can be used again.			
			cmd.Parameters.Clear();
			
			//return the dataset
			return ds;						
		}
		
		#endregion ExecuteDataSet
		
		#region ExecuteReader

		#endregion ExecuteReader

		#region ExecuteScalar
        
		/// <summary>
		/// Execute a SqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			//create & open a SqlConnection, and dispose of it after we are done.
			using (SqlConnection cn = new SqlConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteScalar(cn, commandType, commandText, commandParameters);
			}
		}
        
		/// <summary>
		/// Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			SqlCommand cmd = new SqlCommand();
			PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
			
			//execute the command & return the results
			object retval = cmd.ExecuteScalar();
			
			// detach the SqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
			return retval;
			
		}
        
		#endregion ExecuteScalar	

		#region ExecuteXmlReader

        

		#endregion ExecuteXmlReader
	}

	/// <summary>
	/// SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
	/// ability to discover parameters for stored procedures at run-time.
	/// </summary>
	public sealed class SqlHelperParameterCache
	{
		#region private methods, variables, and constructors

		//Since this class provides only static methods, make the default constructor private to prevent 
		//instances from being created with "new SqlHelperParameterCache()".
		private SqlHelperParameterCache() {}

		private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

		/// <summary>
		/// resolve at run time the appropriate set of SqlParameters for a stored procedure
		/// </summary>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="includeReturnValueParameter">whether or not to include their return value parameter</param>
		/// <returns></returns>
		private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			using (SqlConnection cn = new SqlConnection(connectionString)) 
			using (SqlCommand cmd = new SqlCommand(spName,cn))
			{
				cn.Open();
				cmd.CommandType = CommandType.StoredProcedure;

				SqlCommandBuilder.DeriveParameters(cmd);

				if (!includeReturnValueParameter) 
				{
					cmd.Parameters.RemoveAt(0);
				}

				SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];;

				cmd.Parameters.CopyTo(discoveredParameters, 0);

				return discoveredParameters;
			}
		}

		//deep copy of cached SqlParameter array
		private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
		{
			SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

			for (int i = 0, j = originalParameters.Length; i < j; i++)
			{
				clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
			}

			return clonedParameters;
		}

		#endregion private methods, variables, and constructors

		#region caching functions

		/// <summary>
		/// add parameter array to the cache
		/// </summary>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters to be cached</param>
		public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
		{
			string hashKey = connectionString + ":" + commandText;

			paramCache[hashKey] = commandParameters;
		}

		/// <summary>
		/// retrieve a parameter array from the cache
		/// </summary>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an array of SqlParamters</returns>
		public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			string hashKey = connectionString + ":" + commandText;

			SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];
			
			if (cachedParameters == null)
			{			
				return null;
			}
			else
			{
				return CloneParameters(cachedParameters);
			}
		}

		#endregion caching functions

		#region Parameter Discovery Functions

		/// <summary>
		/// Retrieves the set of SqlParameters appropriate for the stored procedure
		/// </summary>
		/// <remarks>
		/// This method will query the database for this information, and then store it in a cache for future requests.
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <returns>an array of SqlParameters</returns>
		public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
		{
			return GetSpParameterSet(connectionString, spName, false);
		}

		/// <summary>
		/// Retrieves the set of SqlParameters appropriate for the stored procedure
		/// </summary>
		/// <remarks>
		/// This method will query the database for this information, and then store it in a cache for future requests.
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="includeReturnValueParameter">a bool value indicating whether the return value parameter should be included in the results</param>
		/// <returns>an array of SqlParameters</returns>
		public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter":"");

			SqlParameter[] cachedParameters;
			
			cachedParameters = (SqlParameter[])paramCache[hashKey];

			if (cachedParameters == null)
			{			
				cachedParameters = (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter));
			}
			
			return CloneParameters(cachedParameters);
		}

		#endregion Parameter Discovery Functions

	}
}
