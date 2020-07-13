using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class GmsCallParserHelper : IGmsCallParserHelper
    {
        public const string CustomerId = "Customer ID";
        public const string FirstName = "First Name";
        public const string MiddleName = "Middle Name";
        public const string LastName = "Last Name";
        public const string Email = "Email";
        public const string PhoneHome = "Phone Home";
        public const string PhoneOffice = "Phone Office";
        public const string PhoneCell = "Phone Cell";
        public const string AddressLine1 = "Address Line1";
        public const string AddressLine2 = "Address Line2";
        public const string City = "City";
        public const string State = "State";
        public const string Zip = "Zip";
        public const string MemberId = "Member ID";
        public const string HealthPlan = "Health Plan";
        public const string CallerId = "Caller ID";
        public const string CallDisposition = "CALL DISP";
        public const string CallDate = "CALL DATE";
        public const string CallTime = "CALL TIME";

        public static string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private long ConvertToLong(string customerIdString)
        {
            long customerId;
            long.TryParse(customerIdString, out customerId);

            return customerId;

        }

        public string CheckForColumns(DataRow row)
        {
            var sb = new List<string>();

            try
            {
                GetRowValue(row, CustomerId);
            }
            catch (Exception)
            {
                sb.Add(CustomerId);
            }

            try
            {
                GetRowValue(row, FirstName);
            }
            catch (Exception)
            {
                sb.Add(FirstName);
            }

            try
            {
                GetRowValue(row, MiddleName);
            }
            catch (Exception)
            {
                sb.Add(MiddleName);
            }

            try
            {
                GetRowValue(row, LastName);
            }
            catch (Exception)
            {
                sb.Add(LastName);
            }

            try
            {
                GetRowValue(row, Email);
            }
            catch (Exception)
            {
                sb.Add(Email);
            }

            try
            {
                GetRowValue(row, PhoneHome);
            }
            catch (Exception)
            {
                sb.Add(PhoneHome);
            }

            try
            {
                GetRowValue(row, PhoneOffice);
            }
            catch (Exception)
            {
                sb.Add(PhoneOffice);
            }

            try
            {
                GetRowValue(row, PhoneCell);
            }
            catch (Exception)
            {
                sb.Add(PhoneCell);
            }

            try
            {
                GetRowValue(row, AddressLine1);
            }
            catch (Exception)
            {
                sb.Add(AddressLine1);
            }

            try
            {
                GetRowValue(row, AddressLine2);
            }
            catch (Exception)
            {
                sb.Add(AddressLine2);
            }

            try
            {
                GetRowValue(row, City);
            }
            catch (Exception)
            {
                sb.Add(City);
            }

            try
            {
                GetRowValue(row, State);
            }
            catch (Exception)
            {
                sb.Add(State);
            }

            try
            {
                GetRowValue(row, Zip);
            }
            catch (Exception)
            {
                sb.Add(Zip);
            }

            try
            {
                GetRowValue(row, MemberId);
            }
            catch (Exception)
            {
                sb.Add(MemberId);
            }

            try
            {
                GetRowValue(row, HealthPlan);
            }
            catch (Exception)
            {
                sb.Add(HealthPlan);
            }

            try
            {
                GetRowValue(row, CallerId);
            }
            catch (Exception)
            {
                sb.Add(CallerId);
            }

            try
            {
                GetRowValue(row, CallDisposition);
            }
            catch (Exception)
            {
                sb.Add(CallDisposition);
            }

            try
            {
                GetRowValue(row, CallDate);
            }
            catch (Exception)
            {
                sb.Add(CallDate);
            }

            try
            {
                GetRowValue(row, CallTime);
            }
            catch (Exception)
            {
                sb.Add(CallTime);
            }

            var missingHeaders = string.Empty;

            if (sb.Any())
                missingHeaders = string.Join(",", sb);

            return missingHeaders;
        }

        public GmsDialerCallModel GetGmsDialerCallModel(DataRow row)
        {
            var model = new GmsDialerCallModel
            {
                CustomerId = GetRowValue(row, CustomerId),
                FirstName = GetRowValue(row, FirstName),
                MiddleName = GetRowValue(row, MiddleName),
                LastName = GetRowValue(row, LastName),
                Email = GetRowValue(row, Email),
                PhoneHome = GetRowValue(row, PhoneHome),
                PhoneOffice = GetRowValue(row, PhoneOffice),
                PhoneCell = GetRowValue(row, PhoneCell),
                AddressLine1 = GetRowValue(row, AddressLine1),
                AddressLine2 = GetRowValue(row, AddressLine2),
                City = GetRowValue(row, City),
                State = GetRowValue(row, State),
                Zip = GetRowValue(row, Zip),
                MemberId = GetRowValue(row, MemberId),
                HealthPlan = GetRowValue(row, HealthPlan),
                CallerId = GetRowValue(row, CallerId),
                CallDisposition = GetRowValue(row, CallDisposition),
                CallDate = GetRowValue(row, CallDate),
                CallTime = GetRowValue(row, CallTime)

            };

            return model;
        }

    }
}
