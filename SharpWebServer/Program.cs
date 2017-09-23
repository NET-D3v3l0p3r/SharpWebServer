using SharpWebServer.Global;
using SharpWebServer.Ini;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpWebServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [STAThread]
        static void Main()
        {
            GlobalShares.INIParser = new INIParserI(@"Configuration/server.ini", INIParserI.Mode.Read);

            string[] _handler = GlobalShares.INIParser.GetValue("PlugIn", "PlugInApplications").Split('|');
            for (int i = 0; i < _handler.Length - 1; i++)
            {
                string[] _alloc = _handler[i].Split(new string[] { "->" }, StringSplitOptions.None);
                if (_alloc.Length > 1)
                    if (!File.Exists(_alloc[1]))
                    {
                        MessageBox.Show("PLUGIN FOR EXTENSION '" + _alloc[0] + "' IS MISSING!" + Environment.NewLine + "PLEASE INSTALL IT NOW!", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

            }

            var handle = GetConsoleWindow();

            if (GlobalShares.INIParser.GetValue("DEBUG", "EnableConsole").ToUpper().Equals("TRUE"))
                ShowWindow(handle, SW_SHOW);
            else if (GlobalShares.INIParser.GetValue("DEBUG", "EnableConsole").ToUpper().Equals("FALSE"))
                ShowWindow(handle, SW_HIDE);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SharpWebServer());
        }
    }
}
