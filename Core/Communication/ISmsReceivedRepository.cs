using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication
{
    public interface ISmsReceivedRepository
    {
        SmsReceived SaveSmsReceived(SmsReceived smsReceived);
        IEnumerable<SmsReceived> GetSmsReceived(long customerId);
        IEnumerable<SmsReceived> GetSmsReceived(string phoneNumber);
    }
}