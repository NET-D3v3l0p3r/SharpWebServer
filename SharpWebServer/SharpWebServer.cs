using SharpWebServer.Global;
using SharpWebServer.Ini;
using SharpWebServer.LogIn;
using SharpWebServer.WebServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpWebServer
{
    public partial class SharpWebServer : Form
    {

        public SharpWebServer()
        {
            InitializeComponent();
        }

        public delegate void InvokeI();
        public InvokeI Invoker;

        private Webserver _Server;
        private LogInManager _LogIn;

        private void SharpWebServer_Load(object sender, EventArgs e)
        {
            _LogIn = new LogInManager();

            _LogIn.LogInHost = "winsockets.hol.es";
            _LogIn.Port = 80;

            tab_cntrl.TabPages.Remove(tabPage1);
            //tab_cntrl.TabPages.Remove(tabPage2);
            //tab_cntrl.TabPages.Remove(tabPage3);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[*] Application: LOADED");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[*] API: PULLING_DATA");
            //__ListenAvaibiliyLogIn();

            //JUMP TO TBID
            this.Activate();
            SendKeys.Send("{TAB}");

            Reload();

        }

        public void Reload()
        {
            inipair.Items.Clear();
            blacklist.Items.Clear();

            // LOAD CONFIGURATION DATA
            iniPath.Text = Application.StartupPath + @"\Configuration\server.ini";
            inipair.Items.AddRange(File.ReadAllLines(iniPath.Text));

            string[] _IPs = File.ReadAllLines(GlobalShares.INIParser.GetValue("DOS_PROTECTION", "BlackList"));
            blacklist.Items.AddRange(_IPs);

            icopath.Text = Application.StartupPath + @"\" + GlobalShares.INIParser.GetValue("HTTP", "PublicFolder") + @"\favicon.ico";
            favicon.Image = new Bitmap(icopath.Text);

        }

        private void __ListenAvaibiliyLogIn()
        {
            Thread __0 = new Thread(new ThreadStart(() =>
            {
                bool _Run = true;
                while (_Run)
                {
                    var _Status = _LogIn.RequestStatus();
                    logInStatus.Text = _Status ? "LogIn-Server: Online" : "LogIn-Server: Offline";

                    this.Invoker += new InvokeI(() =>
                    {
                        tbId.Enabled = tbPin.Enabled = logIn.Enabled = _Status;
                    });

                    this.Invoke(this.Invoker);

                    if (_Status)
                    {
                        _Run = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[*] API: SERVER_AVAIBLE");
                    }

                    Thread.Sleep(15000);
                }
            }));

            __0.SetApartmentState(ApartmentState.STA);
            __0.Start();
        }

        private void SharpWebServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Server != null)
            {
                Webserver.KeepListening = false;
                // SEND REQUEST TO SERVER TO SHUTDOWN

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[*] APPLICATION: SHUTTING_DOWN");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[*] APPLICATION: THIS COMMAND CAN TOOK OVER 3 SECONDS!");

                TcpClient _ExitClient = new TcpClient("192.168.0.215", _Server.IPeP.Port);
            }
            else Environment.Exit(Environment.ExitCode);
        }

        private void logIn_Click(object sender, EventArgs e)
        {
            if (!_LogIn.LogIn(tbId.Text, tbPin.Text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[*] API: PERMISSION DENIED");
                login_ttp.Text = "Log in: Access denied.";
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[*] API: LOGIN_SUCCEED");
                login_ttp.Text = "Log in: Access granted.";
                tab_cntrl.TabPages.Remove(tabPage1);
                tab_cntrl.TabPages.Add(tabPage2);
                tab_cntrl.TabPages.Add(tabPage3);
            }

        }

        private void tbId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                tbPin.Focus();
            }

        }

        private void tbPin_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                logIn.Focus();
            }

        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void runbttn_Click(object sender, EventArgs e)
        {
            if (runbttn.Text.Equals("Start"))
            {
                _Server = new Webserver(this);
                _Server.Run();

                runbttn.Text = "Stop";
            }

            else
            {
                Webserver.KeepListening = false;
                // SEND REQUEST TO SERVER TO SHUTDOWN

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[*] APPLICATION: SHUTTING_DOWN");

                TcpClient _ExitClient = new TcpClient("192.168.0.215", _Server.IPeP.Port);
                _Server = null;
                runbttn.Text = "Start";
            }

        }

        private void clrbttn_Click(object sender, EventArgs e)
        {
            logLB.Items.Clear();
        }

        private void inibttn_Click(object sender, EventArgs e)
        {
            OpenFileDialog _openFile = new OpenFileDialog();
            _openFile.Filter = "*(.ini)|*.ini";
            _openFile.ShowDialog();

            if (string.IsNullOrEmpty(_openFile.FileName))
                return;
            if (iniPath.Text.Equals(_openFile.FileName))
                return;

            iniPath.Text = _openFile.FileName;
            GlobalShares.INIParser = new INIParserI(iniPath.Text, INIParserI.Mode.Read);

            Reload();
        }

        private void inipair_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            if (inipair.SelectedIndex < 0)
                return;
            string _item = inipair.Items[inipair.SelectedIndex] + "";
            if (_item.Contains("[") || _item.Contains("]"))
                return;

            string _section = "";

            for (int i = inipair.SelectedIndex; i >= 0; i--)
            {
                string _line = inipair.Items[i] + "";
                if (_line.Contains("[") || _line.Contains("]"))
                {
                    _section = _line.Replace("[", "").Replace("]", "");
                    break;
                }
            }

            GlobalShares.INIParser.EditValue(_section, _item.Split('=')[0], Microsoft.VisualBasic.Interaction.InputBox("[EDIT]" + _item.Split('=')[0] + "="));

            inipair.Items.Clear();
            foreach (var _pair in File.ReadAllLines(iniPath.Text))
            {
                inipair.Items.Add(_pair);
            }

            if (MessageBox.Show("It is recommended to restart to apply ini!" + Environment.NewLine + "Restart?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);
                this.Close();
            }

        }

        private void icobttn_Click(object sender, EventArgs e)
        {
            OpenFileDialog _openFile = new OpenFileDialog();
            _openFile.Filter = "PNG(*.png)|*.png|JPG(*.jpg)|*.jpg|ICO(*.ico)|*.ico";
            _openFile.ShowDialog();

            if (string.IsNullOrEmpty(_openFile.FileName))
                return;
            if (icopath.Text.Equals(_openFile.FileName))
                return;

            icopath.Text = _openFile.FileName;
            favicon.Image.Dispose();

            byte[] _Icon = File.ReadAllBytes(icopath.Text);
            File.WriteAllBytes(GlobalShares.INIParser.GetValue("HTTP", "PublicFolder") + @"\favicon.ico", _Icon);

            Reload();

        }

        private void blacklist_DoubleClick(object sender, EventArgs e)
        {
            if (blacklist.SelectedIndex == -1)
                return;
            string _ip = blacklist.Items[blacklist.SelectedIndex] + "";

            if (MessageBox.Show("Are You sure you want to delete " + _ip + " from the blacklist?", "Sure?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            blacklist.Items.Remove(_ip);
            File.WriteAllLines(GlobalShares.INIParser.GetValue("DOS_PROTECTION", "BlackList"), blacklist.Items.Cast<string>().ToArray());
            blacklist.Items.Clear();
            string[] _IPs = File.ReadAllLines(GlobalShares.INIParser.GetValue("DOS_PROTECTION", "BlackList"));
            blacklist.Items.AddRange(_IPs);

            if (MessageBox.Show("It is recommended to restart to apply ini!" + Environment.NewLine + "Restart?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);
                this.Close();
            }
        }
    }
}
