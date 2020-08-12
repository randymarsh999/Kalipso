using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalipso.Сalculations
{


/// <summary>
/// 
/// </summary>
    public class XMTF
    {
        /// <summary>
        /// The XMT curr temporary
        /// </summary>
        public const int xmt_curr_temp = 0;
        /// <summary>
        /// The XMT a l1
        /// </summary>
        public const int xmt_AL1 = 1;
        /// <summary>
        /// The XMT a l2
        /// </summary>
        public const int xmt_AL2 = 2;
        /// <summary>
        /// The XMT hy 1
        /// </summary>
        public const int xmt_HY_1 = 3;
        /// <summary>
        /// The XMT hy 2
        /// </summary>
        public const int xmt_HY_2 = 4;
        /// <summary>
        /// The XMT hy
        /// </summary>
        public const int xmt_HY = 5;
        /// <summary>
        /// The XMT at
        /// </summary>
        public const int xmt_At = 6;
        /// <summary>
        /// The XMT i
        /// </summary>
        public const int xmt_I = 7;
        /// <summary>
        /// The XMT p
        /// </summary>
        public const int xmt_P = 8;
        /// <summary>
        /// The XMT d
        /// </summary>
        public const int xmt_D = 9;
        /// <summary>
        /// The XMT t
        /// </summary>
        public const int xmt_t = 10;
        /// <summary>
        /// The XMT sn
        /// </summary>
        public const int xmt_Sn = 11;
        /// <summary>
        /// The XMT dp
        /// </summary>
        public const int xmt_dp = 12;
        /// <summary>
        /// The XMT p sl
        /// </summary>
        public const int xmt_P_SL = 13;
        /// <summary>
        /// The XMT p sh
        /// </summary>
        public const int xmt_P_SH = 14;
        /// <summary>
        /// The XMT pb
        /// </summary>
        public const int xmt_Pb = 15;
        /// <summary>
        /// The XMT op a
        /// </summary>
        public const int xmt_OP_A = 16;
        /// <summary>
        /// The XMT out
        /// </summary>
        public const int xmt_out = 17;
        /// <summary>
        /// The XMT out h
        /// </summary>
        public const int xmt_outH = 18;
        /// <summary>
        /// The XMT al p
        /// </summary>
        public const int xmt_AL_P = 19;
        /// <summary>
        /// The XMT cool
        /// </summary>
        public const int xmt_Cool = 20;
        /// <summary>
        /// The XMT baud
        /// </summary>
        public const int xmt_Baud = 21;
        /// <summary>
        /// The XMT addr
        /// </summary>
        public const int xmt_Addr = 22;
        /// <summary>
        /// The XMT fi lt
        /// </summary>
        public const int xmt_FILt = 23;
        /// <summary>
        /// The XMT a m
        /// </summary>
        public const int xmt_A_M = 24;
        /// <summary>
        /// The XMT lock
        /// </summary>
        public const int xmt_Lock = 25;
        /// <summary>
        /// The XMT model
        /// </summary>
        public const string xmt_model= "XMTF";
        /// <summary>
        /// Gets or sets the XMFT commands.
        /// </summary>
        /// <value>
        /// The XMFT commands.
        /// </value>
        public string[] XMFT_commands { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="XMTF"/> class.
        /// </summary>
        public XMTF()
        {
            XMFT_commands = new string[26];
            XMFT_commands[0] = "xmt_curr_temp_set";
            XMFT_commands[1] = "xmt_AL1";
            XMFT_commands[2] = "xmt_AL2";
            XMFT_commands[3] = "xmt_HY_1";
            XMFT_commands[4] = "xmt_HY_2";
            XMFT_commands[5] = "xmt_HY";
            XMFT_commands[6] = "xmt_At";
            XMFT_commands[7] = "xmt_I";
            XMFT_commands[8] = "xmt_P";
            XMFT_commands[9] = "xmt_D";
            XMFT_commands[10] = "xmt_t";
            XMFT_commands[11] = "xmt_Sn";
            XMFT_commands[12] = "xmt_dp";
            XMFT_commands[13] = "xmt_P_SL";
            XMFT_commands[14] = "xmt_P_SH";
            XMFT_commands[15] = "xmt_Pb";
            XMFT_commands[16] = "xmt_OP_A";
            XMFT_commands[17] = "xmt_out";
            XMFT_commands[18] = "xmt_outH";
            XMFT_commands[19] = "xmt_AL_P";
            XMFT_commands[20] = "xmt_Cool";
            XMFT_commands[21] = "xmt_Baud";
            XMFT_commands[22] = "xmt_Addr";
            XMFT_commands[23] = "xmt_FILt";
            XMFT_commands[24] = "xmt_A_M";
            XMFT_commands[25] = "xmt_Lock";
        }
    }

}
