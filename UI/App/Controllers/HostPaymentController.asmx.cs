using System;
using System.Web.Services;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Finance.Repositories;
using Falcon.App.Infrastructure.Repositories.Host;
using Falcon.App.Infrastructure.Sales.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class HostPaymentController : WebService
    {

        private readonly IHostPaymentRepository _hostPaymentRepository = new HostPaymentRepository();
        private readonly IHostPaymentTransactionRepository _hostPaymentTransactionRepository = new HostPaymentTransactionRepository();
        private readonly IHostRepository _hostRepository = new HostRepository();
        private readonly IHostDeositRepository _hostDepositRepository = new HostDepositRepository();

        [WebMethod (EnableSession = true)]
        public bool UpdateHostPaymentStatusAndNotes(long hostPaymentId, decimal amount, int hostPaymentStatus,int hostPaymentType, string notes,string paymentDate,long organizationRoleUserId,long hostId,string taxIdNumber,bool isDeposit)
        {
            DateTime transactionDate = DateTime.Now;
            int hostPaymentStatusOld = hostPaymentStatus;
            if (!string.IsNullOrEmpty(paymentDate))
            {
                transactionDate = Convert.ToDateTime(paymentDate);
            }

            try
            {
                HostDeposit hostDepositInfo = null;
                HostPayment hostPaymentInfo = null;
                HostPaymentStatus currentPaymentStatus;

                if (isDeposit)
                {
                    hostDepositInfo = _hostDepositRepository.GetByHostDepositById(hostPaymentId);
                    if (hostDepositInfo != null && hostDepositInfo.DepositApplicablityMode == DepositType.Refunded && hostPaymentStatus == (int)HostPaymentStatus.Paid)
                    {
                        hostPaymentStatus = (int)HostPaymentStatus.Receivable;
                    }
                    currentPaymentStatus = hostDepositInfo != null ? hostDepositInfo.Status : HostPaymentStatus.Pending;
                }
                else
                {
                    hostPaymentInfo = _hostPaymentRepository.GetHostPaymentById(hostPaymentId);
                    currentPaymentStatus = hostPaymentInfo != null ? hostPaymentInfo.Status : HostPaymentStatus.Pending;
                }

                //using (var transaction = new TransactionScope())
                //{
                // Update Host Payment    
                _hostPaymentRepository.UpdateHostPaymentStatusAndNotes(hostPaymentId, amount, hostPaymentStatus);

                if (hostPaymentStatusOld == (int)HostPaymentStatus.Paid || hostPaymentStatusOld == (int)HostPaymentStatus.Refunded)
                {
                    var hostPaymentTransaction = new HostPaymentTransaction()
                    {
                        HostPaymentId = hostPaymentId,
                        TransactionType = (HostPaymentStatus)hostPaymentStatusOld,
                        TransactionMethod = (HostPaymentType)hostPaymentType,
                        Amount = amount,
                        Notes = notes,
                        TransactionDate = transactionDate,
                        TransactionRecordedBy = organizationRoleUserId > 0
                                                    ? new OrganizationRoleUser(
                                                          organizationRoleUserId)
                                                    : null
                    };

                    var hostPaymentTransactionExisting =
                        _hostPaymentTransactionRepository.GetByIdAndStatus(hostPaymentId, hostPaymentStatusOld);
                    if (hostPaymentTransactionExisting == null)
                    {
                        if ((hostPaymentStatusOld == (int)HostPaymentStatus.Paid &&
                             currentPaymentStatus != HostPaymentStatus.Paid) ||
                            (hostPaymentStatusOld == (int)HostPaymentStatus.Refunded &&
                             currentPaymentStatus != HostPaymentStatus.Refunded)
                            )
                        {
                            _hostPaymentTransactionRepository.Save(hostPaymentTransaction);
                        }
                    }
                    else
                    {
                        if ((hostPaymentStatusOld == (int)HostPaymentStatus.Paid &&
                             currentPaymentStatus != HostPaymentStatus.Paid) ||
                            (hostPaymentStatusOld == (int)HostPaymentStatus.Refunded &&
                             currentPaymentStatus != HostPaymentStatus.Refunded)
                            )
                        {
                            _hostPaymentTransactionRepository.UpdateHostPaymentTransactionByIdAndStatus(
                                hostPaymentTransaction);
                        }

                    }
                }
                // delete (Paid to Pending(Delete Paid))
                if ((currentPaymentStatus == HostPaymentStatus.Paid) && (hostPaymentStatusOld == (int)HostPaymentStatus.Pending))
                {
                    _hostPaymentTransactionRepository.DeleteByIdAndStatus(hostPaymentId, currentPaymentStatus);
                }
                // delete (Refunded to Paid (Delete Refunded))
                else if ((currentPaymentStatus == HostPaymentStatus.Refunded) && (hostPaymentStatusOld == (int)HostPaymentStatus.Paid))
                {
                    _hostPaymentTransactionRepository.DeleteByIdAndStatus(hostPaymentId, currentPaymentStatus);
                }

                // delete (Refunded to Pending (Both records))
                //else if ((currentPaymentStatus == HostPaymentStatus.Refunded) && (hostPaymentStatus == (int)HostPaymentStatus.Pending))
                //    {
                //        _hostPaymentTransactionRepository.DeleteByIdAndStatus(hostPaymentId, currentPaymentStatus);
                //        _hostPaymentTransactionRepository.DeleteByIdAndStatus(hostPaymentId, HostPaymentStatus.Paid);
                //    }

                if (!string.IsNullOrEmpty(taxIdNumber))
                {
                    _hostRepository.UpdateHostTaxIdNumber(hostId, taxIdNumber);
                }
                //transaction.Complete();
                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
