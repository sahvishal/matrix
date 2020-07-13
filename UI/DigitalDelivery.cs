 using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;

namespace Falcon.App.UI
{
    public enum LogonType
    {
        LOGON32_LOGON_INTERACTIVE = 2,
        LOGON32_LOGON_NETWORK = 3,
        LOGON32_LOGON_BATCH = 4,
        LOGON32_LOGON_SERVICE = 5,
        LOGON32_LOGON_UNLOCK = 7,
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8,	// Only for Win2K or higher
        LOGON32_LOGON_NEW_CREDENTIALS = 9		// Only for Win2K or higher
    };

    public enum LogonProvider
    {
        LOGON32_PROVIDER_DEFAULT = 0,
        LOGON32_PROVIDER_WINNT35 = 1,
        LOGON32_PROVIDER_WINNT40 = 2,
        LOGON32_PROVIDER_WINNT50 = 3
    };

    class SecuUtil32
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, ref IntPtr tokenHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr existingTokenHandle,
            int securityImpersonationLevel, ref IntPtr duplicateTokenHandle);
    }
    public partial class DigitalDelivery
    {
        public DigitalDelivery()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static WindowsImpersonationContext ImpersonateUser(string strDomain,
                                             string strLogin,
                                             string strPwd,
                                             LogonType logonType,
                                             LogonProvider logonProvider)
        {
            var tokenHandle = new IntPtr(0);
            var dupeTokenHandle = new IntPtr(0);
            try
            {
                const int securityImpersonation = 2;

                tokenHandle = IntPtr.Zero;
                dupeTokenHandle = IntPtr.Zero;

                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = SecuUtil32.LogonUser(
                    strLogin,
                    strDomain,
                    strPwd,
                    (int)logonType,
                    (int)logonProvider,
                    ref tokenHandle);
                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    string strErr = String.Format("LogonUser failed with error code : {0}", ret);
                    throw new ApplicationException(strErr, null);
                }

                bool retVal = SecuUtil32.DuplicateToken(tokenHandle, securityImpersonation, ref dupeTokenHandle);
                if (false == retVal)
                {
                    SecuUtil32.CloseHandle(tokenHandle);
                    throw new ApplicationException("Failed to duplicate token", null);
                }

                // The token that is passed to the following constructor must 
                // be a primary token in order to use it for impersonation.
                var newId = new WindowsIdentity(dupeTokenHandle);
                var impersonatedUser = newId.Impersonate();

                return impersonatedUser;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
