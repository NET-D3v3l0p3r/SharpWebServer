using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SharpWebServer.WebServer.Client.Extensions
{
    public static class Extensions
    {
        public static string ReadToEndAndKeepAlive(this StreamReader sReader)
        {
            char[] buffer = new char[150];
            Console.WriteLine("READ: " + sReader.ReadBlock(buffer, 0, 150) + " CHARS!");
            return new String(buffer);

        }

        public static void InvokeAnonymous(this Form _frm, Action _action)
        {
            _frm.Invoke(_action);
        }

        public static string[] GetExtensions(string _file)
        {
            return _file.Split('.');
        }

        static int MatchCount(string _input, string _pattern)
        { 
            var s2 = _input.Replace(_pattern, "");
            return (_input.Length - s2.Length) / _pattern.Length;
        }

        /// <summary>
        /// Clears URI's with more than 1 dot's
        /// </summary>
        /// <param name="_uri"></param>
        /// <returns></returns>
        public static string ClearUri(string _uri)
        {
            if (_uri.Contains("=") && MatchCount(_uri, ".") > 1)
            {
                string[] _values = _uri.Split('=');
                string _valuesfull = "";
                for (int i = 1; i < _values.Length; i++)
                {
                    _valuesfull += "=" + _values[i].Replace(".", "$dot");
                }

                _uri = _uri.Remove(_uri.IndexOf('='), _uri.Length - _uri.IndexOf('='));
                _uri += _valuesfull;

            }
            return _uri;
        }
    }
}
