using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using System.Net;
using System.Net.Sockets;
using System.IO;
using SharpWebServer.Global;

namespace SharpWebServer.WebServer.Client.Extensions
{
    public class DoSProtection
    {
        public int MaxTimeSpanConnection { get; set; }
        public int MaxPardons { get; set; }
        public int MaxRefuseTime { get; set; }

        public Dictionary<string, PotenciallyDoSClient> IPList = new Dictionary<string, PotenciallyDoSClient>();
        public List<string> IPBlackList = new List<string>();

        private Stopwatch _StopWatch = new Stopwatch();

        public DoSProtection()
        {
            string[] _IPs = File.ReadAllLines(GlobalShares.INIParser.GetValue("DOS_PROTECTION", "BlackList"));
            IPBlackList = new List<string>(_IPs);
        }

        public void Begin()
        {
            _StopWatch = new Stopwatch();
            _StopWatch.Start();
        }

        public bool End(TcpClient _client)
        {
            string _Ip = _client.Client.RemoteEndPoint.ToString().Split(':')[0];
            if (IPBlackList.Exists(p => p.Equals(_Ip)))
                return true;

            if (!IPList.Keys.ToList().Exists(p => p.Equals(_Ip)))
            {
                PotenciallyDoSClient _Client = new PotenciallyDoSClient();
                _Client.Analyze();
                _Client.MaxTimeSpan = MaxTimeSpanConnection;
                _Client.MaxPardons = MaxPardons;
                IPList.Add(_Ip, _Client);
                return false;
            }
            else
            {
                var _Handler = IPList[_Ip];
                bool _status = _Handler.Analyze();
                IPList[_Ip] = _Handler;

                if (_status)
                {
                    IPBlackList.Add(_Ip);
                    File.AppendAllText(GlobalShares.INIParser.GetValue("DOS_PROTECTION", "BlackList"), _Ip + Environment.NewLine);
                    Webserver.__Handler.Invoker += new SharpWebServer.InvokeI(()=>
                    {
                        Webserver.__Handler.Reload();
                    });

                    Webserver.__Handler.Invoke(Webserver.__Handler.Invoker);

                    return true;
                }
                else
                {
                    var _Handler0 = IPList[_Ip];
                    _Handler0.Stopwatch.Reset();
                    _Handler0.Stopwatch.Start();
                    IPList[_Ip] = _Handler;
                    return false;
                }


            }
        }

    }
}




