using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class PhoneNumberUpdateUploadHelper : IPhoneNumberUpdateUploadHelper
    {
        public string CheckAllColumnExist(string[] givenList)
        {
            //var columns = "CUSTOMERID,FIRSTNAME,LASTNAME,DOB,MEMBERID,NEWPHONENUMBER,PHONETYPE";
            const string columns = PhoneNumberUpdateUploadLogColumn.CustomerId + "," +
                                   PhoneNumberUpdateUploadLogColumn.FirstName + "," +
                                   PhoneNumberUpdateUploadLogColumn.LastName + "," +
                                   PhoneNumberUpdateUploadLogColumn.DOB + "," +
                                   PhoneNumberUpdateUploadLogColumn.MemberId + "," +
                                   PhoneNumberUpdateUploadLogColumn.PhoneNumber + "," +
                                   PhoneNumberUpdateUploadLogColumn.PhoneType;
            string[] checkList = columns.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            var list = checkList.Except(givenList,StringComparer.CurrentCultureIgnoreCase);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

    }
}
