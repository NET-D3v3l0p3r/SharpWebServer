using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using System.Net;
using System.Net.Sockets;
using System.IO;
using SharpWebServer.Global;
using System.Diagnostics;

namespace SharpWebServer.WebServer.PlugIn
{
    public class PlugInManager
    {
        public string PlugInFolder { get; set; }
        public string[] PlugInExtensions { get; set; }

        public Dictionary<string, string> PlugInHandler = new Dictionary<string, string>();

        public PlugInManager()
        {
            PlugInFolder = GlobalShares.INIParser.GetValue("PlugIn", "PlugInFolder");
            PlugInExtensions = GlobalShares.INIParser.GetValue("PlugIn", "PlugInExtensions").Split(';');

            string[] _handler = GlobalShares.INIParser.GetValue("PlugIn", "PlugInApplications").Split('|');
            for (int i = 0; i < _handler.Length - 1; i++)
            {
                string[] _alloc = _handler[i].Split(new string[] { "->" }, StringSplitOptions.None);
                if (_alloc.Length > 1)
                    PlugInHandler.Add(_alloc[0], _alloc[1]);
            }

        }

        public bool HandlePlugIn(string _uri)
        {
            //TODO : FIX DOUBLE POINT!
            string _extension = Path.GetExtension(_uri).Replace(".", "");
            if (_extension.Contains("?"))
                _extension = _extension.Remove(_extension.IndexOf('?'), _extension.Length - _extension.IndexOf('?'));

            for (int i = 0; i < PlugInExtensions.Length - 1; i++)
                if (_extension.Equals(PlugInExtensions[i]))
                    return true;


            return false;

        }

        public byte[] PullPlugInData(string _uri, string _args)
        {
            byte[] _data = new byte[0];
            string _extension = Path.GetExtension(_uri).Replace(".", "");
            if (_extension.Contains("?"))
                _extension = _extension.Remove(_extension.IndexOf('?'), _extension.Length - _extension.IndexOf('?'));
            foreach (var _k in PlugInHandler)
            {
                if (_k.Key.Equals(_extension))
                {
                    Process Process = new System.Diagnostics.Process();
                    Process.StartInfo.WorkingDirectory = GlobalShares.INIParser.GetValue("HTTP", "PublicFolder");
                    Process.StartInfo.FileName = _k.Value;
                    Process.StartInfo.Arguments = _args.Replace("$dot", ".");
                    Process.StartInfo.UseShellExecute = false;
                    Process.StartInfo.RedirectStandardOutput = true;
                    Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start();
                    string _output = Process.StandardOutput.ReadToEnd();
                    _data = ASCIIEncoding.ASCII.GetBytes(_output);
                }
            }

            return _data;
        }
    }
}
