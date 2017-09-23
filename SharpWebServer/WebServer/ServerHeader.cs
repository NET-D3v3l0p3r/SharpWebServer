using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWebServer.WebServer
{
    public class ServerHeader
    {
        public string Header { get; private set; }
        public string HTTPVersion { get; set; }

        public string WWWFolder { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }

        public string ServerConfigExtensions { get; set; }

        public void GetContentType(string _file_extension)
        {
            string[] _Extensions = File.ReadAllLines(ServerConfigExtensions);

            foreach (var _extension in _Extensions)
            {
                string[] _alloc = _extension.Split('=');
                if (_alloc[1].Equals("." + _file_extension))
                {
                    ContentType = _alloc[0];
                    break;
                }
            }
        }

        public override string ToString()
        {
            return 
@"
HTTP/" + HTTPVersion + @"
Content-Length: " + ContentLength + @"
Content-Type: " + ContentType + @"
";
        
        }
    }
}
