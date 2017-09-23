using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpWebServer.LogIn
{
    public class LogInManager
    {
        public string LogInHost { get; set; }
        public int Port { get; set; }

        private WebClient __WebClient = new WebClient();

        public bool RequestStatus()
        {
            try
            {
                return __WebClient.DownloadString("http://" + LogInHost + ":" + Port + "/login.php?Mode=REQUEST_STATUS").Contains("1");
            }
            catch
            {
                return false;
            }//2010
        }

        public bool LogIn(string _id, string _pin)
        {
            try
            {
                return
                    __WebClient.DownloadString("http://" + LogInHost + ":" + Port + "/login.php?Mode=LOGIN&ID=" + _id + "&PIN=" + CalculateMD5Hash(_pin)).Contains("SUCCESS");
            }
            catch
            {
                return false;
            }
        }


        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToUpper();
        }
        
    }
}
