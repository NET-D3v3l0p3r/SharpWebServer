using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWebServer.WebServer
{
    public class ServerErrors
    {
        public enum ServerErrorsEnums
        {
            NotSupported,
            NotSupportedYet,
            Outdated,
            NoError
        }

        public static ServerErrorsEnums GetError(string _uri)
        {
            //if (_uri.Contains("."))
            //    if (_uri.Split('.')[1].Equals("php"))
            //        return ServerErrorsEnums.NotSupportedYet;

            if (_uri.Length > 55)
                return ServerErrorsEnums.NotSupported;
            return ServerErrorsEnums.NoError;

        }
    }
}
