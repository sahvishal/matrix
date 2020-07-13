using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated.Utility;

namespace Falcon.DataAccess.Deprecated
{
    public class ShippingPaymentDetailsRepository
    {
        private readonly string _connectionString = ConnectionHandler.GetConnectionString();

        // This method is written here because we dont have a mapping table 
        // for event customer id and shipping detail id in llbl gen entity classes.
        // TODO: Once temporary table is removed and shipping detail table has 
        // TODO: mapping with order table this method will not be used.

        public List<string> GetShippingDetailsByEventCustomerId(long eventCustomerId)
        {
            var commandParameters = new List<SqlParameter>
                                        {
                                            new SqlParameter("@EventCustomerId", SqlDbType.BigInt)
                                                {Value = eventCustomerId}
                                        };
            DataSet shippingDetails = SqlHelper.ExecuteDataset(_connectionString, "usp_getShippingOption", commandParameters.ToArray());
            if (shippingDetails == null || shippingDetails.Tables.Count == 0)
            {
                throw new EmptyCollectionException();
            }

            return shippingDetails.Tables.Cast<DataTable>().Single().Rows.Cast<DataRow>().Select(
                row => row["Name"].ToString()).ToList();
        }
    }
}
