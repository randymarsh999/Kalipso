using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalipso.Сalculations
{
    #region freq mode




    //public enum ListFreqMode
    //{
    //    [field: Description("OEM")]
    //    f_s = "Step",
    //    f_auto,
    //    f_lg,
    //    f_p,
    //    f_a_l,
    //    f_l,
    //    f_h
    //}


    #endregion


    public static class Constants
    {
        #region DataBase constants
        public const string DBConnectionString = "";
        public const string DBConnectionIp = "";
        public const string DBConnectionLogin = "";
        #endregion

        #region standart information
        /// <summary>
        /// temporary id
        /// </summary>
        public const string id = "id";
        /// <summary>
        /// ID section
        /// </summary>
        public const string id_section = "id_section";
        /// <summary>
        /// Composition
        /// </summary>
        public const string composition = "composition";
        /// <summary>
        /// Id of sample
        /// </summary>
        public const string id_sample = "id_sample";
        /// <summary>
        /// Sintering temperature
        /// </summary>
        public const string Tsint = "Tsint_K";
        /// <summary>
        /// Diamentr
        /// </summary>
        public const string d_cm = "d_cm";
        /// <summary>
        /// Height
        /// </summary>
        public const string h_cm = "h_cm";
        /// <summary>
        /// Temperature in Kelvin 
        /// </summary>
        public const string T_K = "T_K";
        /// <summary>
        /// Coolin/Heating - Direction
        /// </summary>
        public const string direction = "Direction";
        /// <summary>
        /// Magnitude of electric field 
        /// </summary>
        public const string Ubias = "Ubias_V";
        /// <summary>
        /// Magnitude of magnetic field 
        /// </summary>
        public const string Hbias = "Hbias_T";
        /// <summary>
        /// current cycle - Cycle
        /// </summary>
        public const string CycleNum = "Cycle";
        /// <summary>
        /// Current PC date
        /// </summary>
        public const string CurDate = "Date";
        /// <summary>
        /// Current PC time
        /// </summary>
        public const string CurTime = "Time";
        /// <summary>
        /// Operator Name
        /// </summary>
        public const string Operator = "operator";
        /// <summary>
        /// timer of current measurment
        /// </summary>
        public const string cur_timer = "Timer";
        /// <summary>
        /// Meas type
        /// </summary>
        public const string meas_type = "Meas_type";
        /// <summary>
        /// Step
        /// </summary>
        public const string step = "Step";
        /// <summary>
        /// Field polarity
        /// </summary>
        public const string polarity = "Polarity";
        /// <summary>
        /// solid state crystal/ thin film/ ceramic
        /// </summary>
        public const string solid_state = "solid_state";
        /// <summary>
        /// Commments
        /// </summary>
        public const string comments = "comments";
        /// <summary>
        /// Current measurment type
        /// </summary>
        public const string current_meas_type = "current_meas_type"; //10001- dispersion code
        #endregion

        #region  measurment data dielectic spectoscopy
        /// <summary>
        /// Experimental density 
        /// </summary>
        public const string ro_exp = "ro_exp";
        /// <summary>
        /// Дoss tangent
        /// </summary>
        public const string tgd = "tgd";
        /// <summary>
        /// Frequency
        /// </summary>
        public const string f = "f_Hz";
        /// <summary>
        /// Quality factor
        /// </summary>
        public const string Q = "q";
        /// <summary>
        /// Capacitance series circuit
        /// </summary>
        public const string Cs = "Cs_pF";
        /// <summary>
        /// Capacitance parallel circuit
        /// </summary>
        public const string Cp = "Cp_pF";
        /// <summary>
        /// Real part of dielectric constant
        /// </summary>
        public const string e_re = "e_re";

        public const string ep_re = "ep_re";
        public const string es_re = "es_re";
        
        
        /// <summary>
        /// Loss tangent multiplied by 1e2
        /// </summary>
        public const string tgd2 = "tgd1e2";
        /// <summary>
        /// Imaginary part of dielectric constant
        /// </summary>
        public const string e_im = "e_im";
        /// <summary>
        /// 
        /// </summary>
        public const string es_im = "es_im";
        /// <summary>
        /// 
        /// </summary>
        public const string ep_im = "ep_im";
        /// <summary>
        /// Сonductivity
        /// </summary>
        public const string Y = "Y";
        /// <summary>
        /// Angle of series circuit
        /// </summary>
        public const string angZ = "angle_z";
        /// <summary>
        /// Angle of parallel circuit
        /// </summary>
        public const string angY = "angle_y";
        /// <summary>
        /// Modul of Z
        /// </summary>
        public const string abs_Z = "abs_z";
        /// <summary>
        /// Module of angle parallel circuit
        /// </summary>
        public const string abs_Y = "abs_y";
        /// <summary>
        /// Resistance of series circuit 
        /// </summary>
        public const string Rs = "rs";
        /// <summary>
        /// 
        /// </summary>
        public const string Xs = "xs";
        /// <summary>
        /// 
        /// </summary>
        public const string Gs = "gs";
        /// <summary>
        /// 
        /// </summary>
        public const string Bs = "bs";
        /// <summary>
        /// 
        /// </summary>
        public const string Gp = "gp";
        /// <summary>
        /// 
        /// </summary>
        public const string Bp = "bp";
        /// <summary>
        /// 
        /// </summary>
        public const string Xp = "xp";
        /// <summary>
        /// 
        /// </summary>
        public const string Rp = "rp";
        /// <summary>
        /// 
        /// </summary>
        public const string L = "l";
        /// <summary>
        /// 
        /// </summary>
        public const string Lp = "lp";
        /// <summary>
        /// 
        /// </summary>
        public const string Ls = "ls";
        /// <summary>
        /// 
        /// </summary>
        public const string Uin_voltm = "Uin_voltmeter";
        /// <summary>
        /// 
        /// </summary>
        public const string conv_c = "conv_coef";

        #endregion

        #region mechanical expansion of the sample
        /// <summary>
        /// Xi
        /// </summary>
        public const string xi = "Xi";
        /// <summary>
        /// Uout_V
        /// </summary>
        public const string uout = "Uout_V";

        public const string Ubias_V_conv = "Ubias_V_conv";
        /// <summary>
        /// 
        /// </summary>
        public const string E_field_tension = "E_kV_Div_cm";
        /// <summary>
        /// 
        /// </summary>
        public const string k_coef = "k_10_E_4";
        /// <summary>
        /// 
        /// </summary>
        public const string d33rev_m = "d33rev_m_V";
        /// <summary>
        /// 
        /// </summary>
        public const string d33rev = "d33rev";
        #endregion

        #region connect type
        public const string connect_type0 = "GPIB";
        public const string connect_type1 = "COM";
        public const string connect_type2 = "ETHERNET";
        public const string connect_type3 = "USB";

        public static string[] connect_types =
        {
            connect_type0,
            connect_type1,
            connect_type2,
            connect_type3
        };
        #endregion


        #region export to data base list
        public const string export_type_DB1 = "None";
        public const string export_type_DB2 = "Export to DB parallel";
        public const string export_type_DB3 = "Export to DB(only)";
        public static string[] export_types_DB =
        {
            export_type_DB1,
            export_type_DB2,
            export_type_DB3
        };

        #endregion

        #region measurment type
        /// <summary>
        /// Auto
        /// </summary>
        public const string M1 = "Auto";
        /// <summary>
        /// Man
        /// </summary>
        public const string M2 = "Man";
        /// <summary>
        /// Cycle
        /// </summary>
        public const string M3 = "Cycle";
        /// <summary>
        /// Cycle_ramp
        /// </summary>
        public const string M4 = "Cycle_ramp";
        /// <summary>
        /// Cycle_rampC(dU)_man
        /// </summary>
        public const string M5 = "Cycle_rampC(dU)_man";
        /// <summary>
        /// C(dU)_auto
        /// </summary>
        public const string M6 = "C(dU)_auto";
        /// <summary>
        /// C(dU)_relaxation
        /// </summary>
        public const string M7 = "C(dU)_relaxation";
        /// <summary>
        /// C(dU, dt, df)_relaxation_(law from file)
        /// </summary>
        public const string M8 = "C(dU, dt, df)_relaxation_(law from file)";
        /// <summary>
        /// C(dU_df_dT)
        /// </summary>
        public const string M9 = "C(dU_df_dT)";
        /// <summary>
        /// Piezo
        /// </summary>
        public const string M10 = "Piezo";
        /// <summary>
        /// Ramp
        /// </summary>
        public const string M11 = "Ramp";
        /// <summary>
        /// C(dU)_auto_reversive
        /// </summary>
        public const string M12 = "C(dU)_auto_reversive";
        /// <summary>
        /// C(dU)_hand_reversive
        /// </summary>
        public const string M13 = "C(dU)_hand_reversive";
        /// <summary>
        /// C(dU_dt)_auto_reversive
        /// </summary>
        public const string M14 = "C(dU_dt)_auto_reversive";
        /// <summary>
        /// C(dU_dT)_auto_reversive
        /// </summary>
        public const string M15 = "C(dU_dT)";
        /// <summary>
        /// dt(dU)
        /// </summary>
        public const string M16 = "dt(dU)";
        /// <summary>
        /// dt(dU&dT)
        /// </summary>
        public const string M17 = "dt(dU&dT)";
        /// <summary>
        /// d33Rev_Auto
        /// </summary>
        public const string M18 = "d33Rev_Auto";
        /// <summary>
        /// d33Rev
        /// </summary>
        public const string M19 = "d33Rev";
        /// <summary>
        /// Magnit_hand
        /// </summary>
        public const string M20 = "Magnit_hand";
        /// <summary>
        /// CTE
        /// </summary>
        public const string M21 = "CTE";
        /// <summary>
        /// CTE_S33_fr
        /// </summary>
        public const string M22 = "CTE_S33_fr";
        /// <summary>
        /// C(dU)_man
        /// </summary>
        public const string M23 = "C(dU)_man";

        public static string[] MeasurmentTypes = {
            M1,
            M2,
            M3,
            M4,
            M5,
            M6,
            M23,
            M7,
            M8,
            M9,
            M10,
            M11,
            M12,
            M13,
            M14,
            M15,
            M16,
            M17,
            M18,
            M19,
            M20,
            M21,
            M22
        };
        #endregion

        #region fill frequency type
        public const string f_s = "Step";
        public const string f_auto = "Auto from generated list";
        public const string f_lg = "Logarithm";
        public const string f_p = "Piezo";
        public const string f_a_l = "Auto from your list";
        public const string f_l = "From loading list";
        public const string f_h = "f1_f3";

        public static string[] freqTypes = {
            f_s,
            f_auto,
            f_lg,
            f_p,
            f_a_l,
            f_l,
            f_h
        };
        #endregion

        #region temperature controller
        /// <summary>
        /// Varta 703I
        /// </summary>
        public const string T_model1 = "Varta";
        /// <summary>
        /// XMFT
        /// </summary>
        public const string T_model2 = "XMFT";
        /// <summary>
        /// List of termocontrollers
        /// </summary>
        public static string[] TemperatureControllerModel = {
            T_model1,
            T_model2

        };
        #endregion

        #region Measurment device model
        /// <summary>
        /// Agilent4980A
        /// </summary>
        public const string M_model0 = "Agilent4980A";
        /// <summary>
        /// Agilent4285A
        /// </summary>
        public const string M_model1 = "Agilent4285A";
        /// <summary>
        /// Agilent4263B
        /// </summary>
        public const string M_model2 = "Agilent4263B";
        /// <summary>
        /// Agilent34401A
        /// </summary>
        public const string M_model3 = "Agilent34401A";
        /// <summary>
        /// WayneKerr6500B
        /// </summary>
        public const string M_model4 = "WayneKerr6500B";
        /// <summary>
        /// WayneKerr4300
        /// </summary>
        public const string M_model5 = "WayneKerr4300";
        /// <summary>
        /// E7-20
        /// </summary>
        public const string M_model6 = "E7-20";
        /// <summary>
        /// E7-28"
        /// </summary>
        public const string M_model7 = "E7-28";

        public static string[] MeasModel = {
        M_model0,
        M_model1,
        M_model2,
        M_model3,
        M_model4,
        M_model5,
        M_model6,
        M_model7
        };

        #endregion

    }
}
