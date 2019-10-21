using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class list of string
/// </summary>
class ParseStringTab : List<string>
{
    /// <summary>
    /// Pars string by \t and add the string.
    /// </summary>
    /// <param name="s">The s.</param>
    public void AddString(string s)
    {
        string sq = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != '\t')
            {
                sq = sq + s[i];
            }
            if (s[i] == '\t')
            {
                this.Add(sq);
                sq = "";
            }
        }
        this.Add(sq);
    }
    /// <summary>
    /// Adds the meas string.
    /// </summary>
    /// <param name="s">The s.</param>
    public void AddMeasString(string s)
    {
        string ss = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != 44)
            {
                ss += s[i];
            }
            if (s[i] == 44)
            {
                this.Add(ss);
                ss = "";
            }
        }
    }
    /// <summary>
    /// Adds the meas string agilent4980.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <exception cref="ArgumentNullException">str</exception>
    public void AddMeasStringAgilent4980(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException(nameof(str));
        }
        string ss = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != 44)
            {
                ss += str[i];
            }
            if (str[i] == 44)
            {
                this.Add(ss);
                ss = "";
            }
        }

        string[] str_array = str.Split(',');
        this.Add(str_array[0]);
        this.Add(str_array[1]);
    }

    public void AddMeasStringAgilent4285A(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException(nameof(str));
        }
        //string ss = "";
        //for (int i = 0; i < str.Length; i++)
        //{
        //    if (str[i] != 44)
        //    {
        //        ss += str[i];
        //    }
        //    if (str[i] == 44)
        //    {
        //        this.Add(ss);
        //        ss = "";
        //    }
        //}

        string[] str_array = str.Split(',');
        this.Add(str_array[0]);
        this.Add(str_array[1]);
    }


    public void AddUMicron(string s)
    {
        string[] ss = s.Split('=');
        this.Add(ss[1]);
    }
    /// <summary>
    /// Adds the meas string agilent4980.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="InterfaceConnect">The interface connect.</param>
    public void AddMeasStringAgilent4980(string str, string InterfaceConnect)
    {

        switch (InterfaceConnect.ToUpper())
        {
            case "GPIB":
                {
                    string outstr = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] != 44)
                        {
                            outstr += str[i];
                        }
                        if (str[i] == 44)
                        {
                            this.Add(outstr);
                            outstr = "";
                        }
                    }
                    break;
                }
            case "ETHERNET":
                {
                    string[] ss = str.Split(',');
                    this.Add(ss[0]);
                    this.Add(ss[1]);
                    break;
                }
            default:
                break;
        }
    }
    /// <summary>
    /// Adds the meas string agilent4263.
    /// </summary>
    /// <param name="s">The s.</param>
    public void AddMeasStringAgilent4263(string s)
    {
        //+0,+1.08714E-09,-2.31548E-01\n
        string ss = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != 44)
            {
                ss += s[i];
            }
            if (s[i] == 44)
            {
                this.Add(ss);
                ss = "";
            }
        }
        this.Add(ss);
    }
    /// <summary>
    /// Adds the meas string wayne kerr4300.
    /// </summary>
    /// <param name="s">The s.</param>
    public void AddMeasStringWayneKerr4300(string s)
    {
        //+ 1.0782782e-12,-2.8852470e+00
        string ss = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 10)
            {
                this.Add(ss);
                ss = "";
            }
            if (s[i] != 44)
            {
                ss += s[i];
            }
            if (s[i] == 44)
            {
                this.Add(ss);
                ss = "";
            }

        }
    }

    /// <summary>
    /// Deletes the zero.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <returns></returns>
    public string DeleteZero(string s)
    {
        s = s.Substring(0, 12);
        return s;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    public void AddMeasStringWayneKerr6500B(string s)
    {
        string ss = "";
        s = s.Replace(" ", "");
        s = s.Replace("\n", "");
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != 44)
            {
                ss += s[i];
            }
            if (s[i] == 44)
            {
                this.Add(ss);
                ss = "";
            }

        }
        this.Add(ss);
    }
}

