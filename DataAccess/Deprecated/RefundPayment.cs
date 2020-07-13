using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using Falcon.App.Core.Deprecated.Utility;


namespace Falcon.DataAccess.Deprecated
{
    public class RefundPayment
    {
        private readonly string _connectionString = ConnectionHandler.GetConnectionString();

        public long SaveRefundPayment(long orderId, decimal amount, int refundMode, string notes, string checkNumber,
            long customerId, long userId, long roleId, long shellId, bool isNewCc)
        {
            var commandParameters = new List<SqlParameter>
                                        {
                                            new SqlParameter("@OrderId", SqlDbType.BigInt) {Value = orderId},
                                            new SqlParameter("@Amount", SqlDbType.Decimal) {Value = amount},
                                            new SqlParameter("@PaymentTypeId", SqlDbType.Int) {Value = refundMode},
                                            new SqlParameter("@UserId", SqlDbType.BigInt) {Value = userId},
                                            new SqlParameter("@ShellId", SqlDbType.BigInt) {Value = shellId},
                                            new SqlParameter("@RoleID", SqlDbType.Int) {Value = roleId},
                                            new SqlParameter("@CustomerId", SqlDbType.BigInt) {Value = customerId},
                                            new SqlParameter("@CheckNumber", SqlDbType.VarChar, 10)
                                                {Value = checkNumber},
                                            new SqlParameter("@returnValue", SqlDbType.BigInt)
                                                {Direction = ParameterDirection.Output},
                                            new SqlParameter("@IsNewCC", SqlDbType.Bit)
                                                {Value = isNewCc},
                                        };
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                                                              "usp_SaveRefundRequest", commandParameters.ToArray());
            return Convert.ToInt64(commandParameters.Single(cp => cp.ParameterName == "@returnValue").Value);
        }

        public long SaveCreditCardPaymentDetails(string ccNumber,int ccTypeId,long paymentId, string paymentResponse, string ccName, string cvv, bool drOrCr,DateTime expDate,long userId, long roleId, long shellId,int mode)
        {
            var commandParameters = new List<SqlParameter>
                                        {
                                            new SqlParameter("@creditcardpaymentID", SqlDbType.BigInt) {Value = 0},
                                            new SqlParameter("@creditcardnumber", SqlDbType.VarChar, 50)
                                                {Value = ccNumber},
                                            new SqlParameter("@creditcardtypeid", SqlDbType.Int) {Value = ccTypeId},
                                            new SqlParameter("@paymentid", SqlDbType.BigInt) {Value = paymentId},
                                            new SqlParameter("@paymentstatus", SqlDbType.VarChar, 50)
                                                {Value = paymentResponse},
                                            new SqlParameter("@ccname", SqlDbType.VarChar, 50) {Value = ccName},
                                            new SqlParameter("@cvv", SqlDbType.VarChar, 50) {Value = cvv},
                                            new SqlParameter("@drorcr", SqlDbType.Bit) {Value = drOrCr},
                                            new SqlParameter("@expirationdate", SqlDbType.DateTime) {Value = expDate},
                                            new SqlParameter("@userid", SqlDbType.VarChar, 100)
                                                {Value = userId.ToString()},
                                            new SqlParameter("@shell", SqlDbType.VarChar, 100)
                                                {Value = shellId.ToString()},
                                            new SqlParameter("@role", SqlDbType.VarChar, 100)
                                                {Value = roleId.ToString()},
                                            new SqlParameter("@mode", SqlDbType.Int) {Value = mode},
                                            new SqlParameter("@returnValue", SqlDbType.BigInt)
                                                {Direction = ParameterDirection.Output}
                                        };
            SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure,
                                                              "usp_savecreditcardpaymentdetails", commandParameters.ToArray());
            return Convert.ToInt64(commandParameters.Single(cp => cp.ParameterName == "@returnValue").Value);
        }
    }
}
