using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace SharpWebServer.Ini
{
    //Programmed by φConst
    public class INIParserI
    {
        public string Path { get; set; }

        public enum Mode
        {
            Write,
            Read,
            Edit
        }

        public string TotalContent { get; private set; }
        public string[] Lines { get; private set; }

        private Mode _Mode;
        private StringBuilder StringBuilder;

        public INIParserI(string _path, Mode _mode)
        {
            Path = _path;
            _Mode = _mode;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[*] Loading INIParser.");

            switch (_Mode)
            {
                case Mode.Read:
                    TotalContent = File.ReadAllText(Path);

                    // VALIDATE INI

                    if (!TotalContent.Contains("=") || !TotalContent.Contains("[") || !TotalContent.Contains("]") || (!TotalContent.Contains("[") && !TotalContent.Contains("]")))
                        throw new Exception("This file seems to be invalid!");

                    Lines = TotalContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    StringBuilder = new StringBuilder(TotalContent);

                    ___PrepareINI();
                    break;

                case Mode.Write:
                    StringBuilder = new StringBuilder(TotalContent);

                    StringBuilder.Append("[*] Created with INIParser");
                    StringBuilder.Append(Environment.NewLine);
                    StringBuilder.Append("[*] Date: " + DateTime.Now);
                    StringBuilder.Append(Environment.NewLine);

                    Lines = StringBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    break;
            }
        }

        private void ___PrepareINI()
        {
            List<string> NewLines = new List<string>();
            for (int i = 0; i < Lines.Length; i++)
            {
                string _line = Lines[i];

                if(!_line.Contains("[") || !_line.Contains("]"))
                {
                    if (_line.Contains("="))
                    {
                        string _left = _line.Split('=')[0];
                        string _right = _line.Split('=')[1];

                        char[] _leftc = _left.ToCharArray();
                        for (int x = _leftc.Length - 1; x >= 0; x--)
                        {
                            if (_leftc[x] == ' ')
                                _left = _left.Remove(x, 1).Insert(x, "#");
                            else break;
                        }

                        _left = _left.Replace("#", "");


                        char[] _rightc = _right.ToCharArray();
                        for (int x = 0; x < _rightc.Length; x++)
                        {
                            if (_rightc[x] == ' ')
                                _right = _right.Remove(x, 1).Insert(x, "#");
                            else break;
                        }
                        _right = _right.Replace("#", "");

                        NewLines.Add(_left + "=" + _right);


                    }
                }
                else
                    NewLines.Add(_line);



            }

            Lines = NewLines.ToArray();
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var _line in Lines)
            {
                Console.WriteLine(_line);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[*] INIParser loaded!");
        }

        public void AddSection(string _name)
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                string _line = Lines[i];
                if (_line.Contains("["))
                {
                    string _Section = _line.Split('[')[1].Replace("]", "");
                    if (_Section.Equals(_name))
                        return;
                }
            }
            var Copy = new string[Lines.Length + 1];
            Array.Copy(Lines, Copy, Lines.Length);
            Copy[Copy.Length - 1] = "[" + _name + "]";
            Lines = Copy;
            File.WriteAllLines(Path, Copy);
        }
        public void AddKeyValueToSection(string _section, string _key, string _value)
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                string _line = Lines[i];
                if (_line.Contains("["))
                {
                    string _Section = _line.Split('[')[1].Replace("]", "");
                    if (_Section.Equals(_section))
                    {

                        for (int j = i + 1; j < Lines.Length; j++)
                        {
                            if (Lines[j].Split('=')[0].Equals(_key))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("[*] INIParser: KEY_ALREADY_USED");
                                return;
                            }
                        }

                        var Copy = new string[Lines.Length + 1];
                        Array.Copy(Lines, Copy, Lines.Length);
                        Copy[Copy.Length - 1] = _key + "=" + _value;
                        Lines = Copy;

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("[*] INIParser: KEY_VALUE_PAIR_ADDED");

                        break;
                    }
                }
            }
        }

        public string GetValue(string _section, string _key)
        {
            string _value = "-1";
            bool _section_found = false;
            for (int i = 0; i < Lines.Length; i++)
            {
                string _line = Lines[i];
                if (!_section_found)
                {
                    if (_line.Contains("["))
                    {
                        string _Section = _line.Split('[')[1].Replace("]", "");
                        if (_Section.Equals(_section))
                            _section_found = true;
                        
                    }
                }
                else
                {
                    if (!_line.Contains("["))
                    {
                        if (_line.Split('=')[0].Equals(_key))
                        {
                            _value = _line.Split('=')[1];
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("[*] INIParser: KEY_FOUND=" + _value);
                        }
                    }
                    else _section_found = false;
                }
            }

            return _value;
        }

        public void EditValue(string _section, string _key, string _n_value)
        {
            bool _section_found = false;
            for (int i = 0; i < Lines.Length; i++)
            {
                string _line = Lines[i];
                if (!_section_found)
                {
                    if (_line.Contains("["))
                    {
                        string _Section = _line.Split('[')[1].Replace("]", "");
                        if (_Section.Equals(_section))
                            _section_found = true;
                        
                    }
                }
                else
                {
                    if (!_line.Contains("["))
                    {
                        if (_line.Split('=')[0].Equals(_key))
                        {
                            Lines[i] = _line.Replace(_line.Split('=')[1], _n_value);

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("[*] INIParser: KEY_EDITED");
                        }
                    }
                    else _section_found = false;
                }
            }

            File.WriteAllLines(Path, Lines); 

        }
    }
}
