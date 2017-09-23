using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using System.Net;
using System.Net.Sockets;

using SharpWebServer.WebServer.Client;
using System.Windows.Forms;
using SharpWebServer.Ini;
using System.Drawing;
using SharpWebServer.Global;
using SharpWebServer.WebServer.Client.Extensions;
using System.IO;
using System.Diagnostics;

namespace SharpWebServer.WebServer
{
    public class Webserver
    {
        private TcpListener _Listener;
        private Thread __Thread0;

        public static SharpWebServer __Handler;

        public IPEndPoint IPeP { get; set; }
        public ServerHeader ServerHeader { get; set; }

        public static bool KeepListening { get; set; }

        public string ServerIni { get; set; }

        public Webserver(SharpWebServer _handler)
        {

            try
            {
                Console.WriteLine("IP=" + GlobalShares.INIParser.GetValue("General", "Host"));
                Console.WriteLine("PORT=" + GlobalShares.INIParser.GetValue("General", "Port"));
                IPeP = new IPEndPoint(IPAddress.Parse(GlobalShares.INIParser.GetValue("General", "Host")), int.Parse(GlobalShares.INIParser.GetValue("General", "Port")));
      
                _Listener = new TcpListener(IPeP);
            }
            catch(Exception ex)
            {
                Console.WriteLine("FATAL: " + ex.Message);
            }
            __Handler = _handler;
            
 
            ServerHeader = new ServerHeader();

            ServerHeader.WWWFolder = GlobalShares.INIParser.GetValue("HTTP", "PublicFolder");
            ServerHeader.ServerConfigExtensions = GlobalShares.INIParser.GetValue("HTTP", "Extensions");

        }

        public void Run()
        {
            KeepListening = true;
            __Thread0 = new Thread(new ThreadStart( async () =>
            {
                try
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[*] Server: STARTING");
                    _Listener.Start();
                }
                catch(Exception ex)
                {
                    Webserver.__Handler.InvokeAnonymous(delegate
                    {
                        Webserver.__Handler.serverStatus.Text = "ERROR: COULD NOT START SERVER: " + ex.Message;
                        Webserver.__Handler.serverStatus.Image = new Bitmap("configuration/etc/icons/red.png");
                    });
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[*] Server: RUNNING");

                Webserver.__Handler.InvokeAnonymous(delegate
                {
                    __Handler.serverStatus.Text = "Ready (" + IPeP.Address.MapToIPv4() + ":" + IPeP.Port + ")";
                    __Handler.serverStatus.Image = new Bitmap("configuration/etc/icons/green.png");
                });

                try
                {
                    Webserver.__Handler.InvokeAnonymous(delegate
                    {
                        Webserver.__Handler.logLB.Items.Add("[*] STARTED: " + DateTime.Now);
                        Webserver.__Handler.logLB.TopIndex = Webserver.__Handler.logLB.Items.Count - 1;
                    });
                }
                catch { }

                DoSProtection __dos = new DoSProtection();
                __dos.MaxTimeSpanConnection = int.Parse(GlobalShares.INIParser.GetValue("DOS_PROTECTION", "MaxTimeSpanConnection"));
                __dos.MaxPardons = int.Parse(GlobalShares.INIParser.GetValue("DOS_PROTECTION", "MaxPardons"));

                Thread __Thread1 = null;
                do
                {
                    __dos.Begin();
                    TcpClient _Client = await _Listener.AcceptTcpClientAsync();
                    if (__dos.End(_Client))
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[*] DoS-Protection: CONNECTION_REFUSED=" + _Client.Client.RemoteEndPoint.ToString());
                        try
                        {
                            Webserver.__Handler.InvokeAnonymous(delegate
                            {
                                Webserver.__Handler.logLB.Items.Add("[*] CONNECTION REFUSED: " + _Client.Client.RemoteEndPoint.ToString());
                                Webserver.__Handler.logLB.TopIndex = Webserver.__Handler.logLB.Items.Count - 1;
                            });
                        }
                        catch { }
                    }
                    else
                    {
                        
                        try
                        {
                            Webserver.__Handler.InvokeAnonymous(delegate
                            {
                                Webserver.__Handler.logLB.Items.Add("[*] CONNECTION: " + _Client.Client.RemoteEndPoint.ToString());
                                Webserver.__Handler.logLB.TopIndex = Webserver.__Handler.logLB.Items.Count - 1;
                            });
                        }
                        catch { }

                        //PROBLEMATICAL : DETERMINE WHETER (D)DOS OR NOT! [SOLVED]
                        __Thread1 = new Thread(new ParameterizedThreadStart((object _c) =>
                        {
                            TcpClient _RequestClient = (TcpClient)_c;
                            Client.BrowserClient _Handler = new Client.BrowserClient(_RequestClient, ServerHeader);
                        }));
                        __Thread1.Start(_Client);
                    }

                } while (KeepListening);
                _Listener.Stop();
                __Thread0.Abort();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[*] APPLICATION: SERVER_CLOSED");


            }));

            __Thread0.Start();
        }

        public void Restart()
        {
            Webserver.__Handler.InvokeAnonymous(delegate
            {
                Webserver.__Handler.runbttn.PerformClick();
                Webserver.__Handler.runbttn.PerformClick();
            });
        }


    }
}
