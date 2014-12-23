using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace CodeX.DesktopTool
{
    public static class Utility
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("https://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
