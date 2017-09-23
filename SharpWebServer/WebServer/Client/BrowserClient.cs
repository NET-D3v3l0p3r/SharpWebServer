using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharpWebServer.WebServer.Client.Extensions;
using SharpWebServer.Ini;
using System.Drawing;
using SharpWebServer.Global;
using SharpWebServer.WebServer.PlugIn;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;

namespace SharpWebServer.WebServer.Client
{
    public class BrowserClient
    {
        private StreamReader StreamReader;
        private StreamWriter StreamWriter;

        private BinaryWriter BinaryWriter;

        private PlugInManager PlugInManager;

        private string __RequestedDataPath;
        private byte[] __RequestedDataBuffer;


        public TcpClient WebClient { get; set; }
        public ServerHeader ServerHeader { get; set; }

        public BrowserClient(TcpClient client, ServerHeader _server_header)
        {
            WebClient = client;
            ServerHeader = _server_header;

            StreamReader = new StreamReader(WebClient.GetStream());
            StreamWriter = new StreamWriter(WebClient.GetStream());
            BinaryWriter = new BinaryWriter(WebClient.GetStream());

            PlugInManager = new PlugIn.PlugInManager();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[*] Server: CLIENT CONNECTED");

            Receive(); // Receive header 

        }

        private void Receive()
        {
            //TODO: REPLACE ALL URI'S WITH MORE THAN 1 DOT'S WITH &URI_DOT!

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[*] Server: PULLING_CLIENT_HEADER");
            string rawClientHeader = StreamReader.ReadToEndAndKeepAlive();
            //Parse rawClientHeader to ClientHeader
            if (rawClientHeader.Equals(""))
                return;

            try
            {
                __RequestedDataPath = rawClientHeader.Split(' ')[1];
            }
            catch
            {
                EndResponse();
                return;
            }
            if (__RequestedDataPath.Length == 1)
                // REQUEST PATH IS / ~ THEREFORE INDEX
                __RequestedDataPath = "/" + GlobalShares.INIParser.GetValue("HTTP", "Index"); //TODO ; PARSE INI
            string _Uri = ServerHeader.WWWFolder + __RequestedDataPath.Replace("/", @"/");

            _Uri = Extensions.Extensions.ClearUri(_Uri);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[*] Server: PULLING_REQUEST=" + _Uri);

            string _full = "";
            if (_Uri.Contains("?"))
                _full = _Uri.Remove(_Uri.IndexOf('?'), _Uri.Length - _Uri.IndexOf('?'));
            else _full = _Uri;
            if ((!File.Exists(_full) || ServerErrors.GetError(_full) != ServerErrors.ServerErrorsEnums.NoError))
            {

                switch (ServerErrors.GetError(_Uri))
                {
                    case ServerErrors.ServerErrorsEnums.NotSupportedYet:
                        __RequestedDataBuffer = File.ReadAllBytes(ServerHeader.WWWFolder + @"/" + GlobalShares.INIParser.GetValue("Errors", "Error_php"));
                        break;

                    case ServerErrors.ServerErrorsEnums.NoError:
                        __RequestedDataBuffer = File.ReadAllBytes(ServerHeader.WWWFolder + @"/" + GlobalShares.INIParser.GetValue("Errors", "Error_404"));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[*] Server: USER_REQUEST_404");
                        break;
                    case ServerErrors.ServerErrorsEnums.NotSupported:
                        __RequestedDataBuffer = File.ReadAllBytes(ServerHeader.WWWFolder + @"/" + GlobalShares.INIParser.GetValue("Errors", "Error_php"));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[*] Server: USER_REQUEST_404");
                        break;
                }


            }
            else
            {

                // PASS URI TO PLUGIN-MANAGER AND DETERMINE WHETHER AN APPLICATION IS ALLOCATED TO IT [SOLVED]
                if (PlugInManager.HandlePlugIn(_Uri))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[*] Server: RUNNING_PLUGIN");

                    string _extension = Path.GetExtension(_Uri).Replace(".", "");
                    if (_extension.Contains("?"))
                        _extension = _extension.Remove(_extension.IndexOf('?'), _extension.Length - _extension.IndexOf('?'));
                    if (_extension == "php")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("[*] PlugIn: RUNNING_PHP_EXE");

                        Webserver.__Handler.InvokeAnonymous(delegate
                        {
                            Webserver.__Handler.logLB.Items.Add("[*] RUNNING HYPERTEXT PREPROCESSOR!");
                            Webserver.__Handler.logLB.TopIndex = Webserver.__Handler.logLB.Items.Count - 1;
                        });

                        string _get_arguments = "";
                        if (!_Uri.Contains("?"))
                            _Uri += "?";

                        _get_arguments = _Uri.Remove(0, _Uri.IndexOf('?') + 1).Replace('&', ' ');
                        __RequestedDataBuffer = PlugInManager.PullPlugInData(_Uri, "-f " + _Uri.Remove(_Uri.IndexOf('?'), _Uri.Length - _Uri.IndexOf('?')).Replace(GlobalShares.INIParser.GetValue("HTTP", "PublicFolder") + @"/", "") + " " + _get_arguments);
                    }
                }
                else
                {

                    __RequestedDataBuffer = File.ReadAllBytes(_Uri);
                    //if (_Uri.Contains(".ico")) // FIX ACCESS-VIOLATION
                    //    __RequestedDataBuffer = File.ReadAllBytes(_Uri);
                    //else
                    //{
                    //    using (var _file = MemoryMappedFile.CreateFromFile(_Uri))
                    //    {
                    //        Stream _requestFileStream = _file.CreateViewStream();
                    //        using (var _memoryStream = new MemoryStream())
                    //        {

                    //            Console.ForegroundColor = ConsoleColor.Red;
                    //            Console.WriteLine("[*] SERVER: USING MEMORYMAPPEDSTREAM");

                    //            _requestFileStream.CopyTo(_memoryStream);
                    //            __RequestedDataBuffer = _memoryStream.ToArray();

                    //            _memoryStream.Close();
                    //            _requestFileStream.Close();
                    //            _file.Dispose();
                    //        }
                    //    }
                    //    //Webserver.FreeMemory(2); // Dangerous
                    //}
                }
            /*
             * FATAL PROBLEM:
             * MEMORY-LACK! [SOLVED; BUT DANGEROUS]
             */
            }
            
            
            BeginResponse(!File.Exists(_Uri) ? "error" : "");
            Send(__RequestedDataBuffer);
            EndResponse();
        }

        private void Send(byte[] _buffer)
        {
            Webserver.__Handler.InvokeAnonymous(delegate
            {
                Webserver.__Handler.serverStatus.Text = "WORKING...";
                Webserver.__Handler.serverStatus.Image = new Bitmap("configuration/etc/icons/orange.png");
            });

            try
            {

                Webserver.__Handler.InvokeAnonymous(delegate
                {
                    Webserver.__Handler.logLB.Items.Add("[*] SENDING_FILE(LENGTH): " + _buffer.Length);
                    Webserver.__Handler.logLB.TopIndex = Webserver.__Handler.logLB.Items.Count - 1;
                });

                BinaryWriter.Write(_buffer);
                BinaryWriter.Flush();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[*] Server: SENT_FILE");
            }
            catch(Exception ex)
            {
 
                Webserver.__Handler.InvokeAnonymous(delegate
                {
                    Webserver.__Handler.serverStatus.Text = "ERROR...";
                    Webserver.__Handler.serverStatus.Image = new Bitmap("configuration/etc/icons/red.png");
                });

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[*] Server: ERROR");
                Console.WriteLine("[*][*] " + ex.Message);
                return;
            }

            Webserver.__Handler.InvokeAnonymous(delegate
            {
                Webserver.__Handler.serverStatus.Text = "Ready";
                Webserver.__Handler.serverStatus.Image = new Bitmap("configuration/etc/icons/green.png");
            });
        }

        private void BeginResponse(string _message)
        {
            ServerHeader.HTTPVersion = GlobalShares.INIParser.GetValue("HTTP", "Version");
            ServerHeader.ContentLength = __RequestedDataBuffer.Length;

            if (_message != "error" && __RequestedDataPath.Split('.').Length > 1)
                ServerHeader.GetContentType(__RequestedDataPath.Split('.')[1]);
            else ServerHeader.ContentType = "text/html";

            
            Webserver.__Handler.InvokeAnonymous(delegate
            {
                Webserver.__Handler.logLB.Items.Add("[*] SENDING_HEADER");
                Webserver.__Handler.logLB.TopIndex = Webserver.__Handler.logLB.Items.Count - 1;
            });

            

            StreamWriter.WriteLine(ServerHeader.ToString());
            StreamWriter.Flush();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[*] Server: SENT_SERVER_HEADER");
        }

        public void EndResponse()
        {
            WebClient.Close();

            StreamReader.Close();
            StreamWriter.Close();
            BinaryWriter.Close();

            StreamReader.Dispose();
            StreamWriter.Dispose();
            BinaryWriter.Dispose();

            __RequestedDataBuffer = new byte[0];
            __RequestedDataPath = "";

            ServerHeader = null;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[*] Server: DONE!");

        }


    }
}
