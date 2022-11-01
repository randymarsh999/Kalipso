using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
/// <summary>
/// 
/// </summary>
public class PiezoParameters
{

    #region Sample geometry
    /// <summary>
    /// Gets or sets the thicknes.
    /// </summary>
    /// <value>
    /// The thicknes.
    /// </value>
    public double thicknes { get; set; }
    /// <summary>
    /// Gets or sets the diametr.
    /// </summary>
    /// <value>
    /// The diametr.
    /// </value>
    public double diametr { get; set; }
    /// <summary>
    /// Gets or sets the xi0.
    /// </summary>
    /// <value>
    /// The xi0.
    /// </value>
    public List<double> Xi0 { get; set; }
    #endregion

    #region Frequency        
    /// <summary>
    /// Gets or sets the measuring frequency.
    /// </summary>
    /// <value>
    /// The measuring frequency.
    /// </value>
    public int MeasuringFrequency { get; set; }
    /// <summary>
    /// Gets or sets the list freq.
    /// </summary>
    /// <value>
    /// The list freq.
    /// </value>
    public string[] ListFreq { get; set; }
    /// <summary>
    /// Gets or sets the fr1.
    /// </summary>
    /// <value>
    /// The FR1.
    /// </value>
    public int fr1 { get; set; }
    /// <summary>
    /// Gets or sets the fa1.
    /// </summary>
    /// <value>
    /// The fa1.
    /// </value>
    public int fa1 { get; set; }
    /// <summary>
    /// Gets or sets the FR3.
    /// </summary>
    /// <value>
    /// The FR3.
    /// </value>
    public int fr3 { get; set; }
    /// <summary>
    /// Gets or sets the fa3.
    /// </summary>
    /// <value>
    /// The fa3.
    /// </value>
    public int fa3 { get; set; }
    /// <summary>
    /// Gets or sets the FR5.
    /// </summary>
    /// <value>
    /// The FR5.
    /// </value>
    public int fr5 { get; set; }
    /// <summary>
    /// Gets or sets the fa5.
    /// </summary>
    /// <value>
    /// The fa5.
    /// </value>
    public int fa5 { get; set; }
    #endregion

    #region Resist

    /// <summary>
    /// Gets or sets the r fr1.
    /// </summary>
    /// <value>
    /// The r FR1.
    /// </value>
    public double R_fr1 { get; set; }
    /// <summary>
    /// Gets or sets the R for fa1.
    /// </summary>
    /// <value>
    /// The r fa1.
    /// </value>
    public double R_fa1 { get; set; }
    /// <summary>
    /// Gets or sets the R for fr3.
    /// </summary>
    /// <value>
    /// The r FR3.
    /// </value>
    public double R_fr3 { get; set; }
    /// <summary>
    /// Gets or sets the R fa3.
    /// </summary>
    /// <value>
    /// The r fa3.
    /// </value>
    public double R_fa3 { get; set; }
    /// <summary>
    /// Gets or sets the r for fr5.
    /// </summary>
    /// <value>
    /// The r fr5.
    /// </value>
    public double R_fr5 { get; set; }
    /// <summary>
    /// Gets or sets the R for fa5.
    /// </summary>
    /// <value>
    /// The r fa5.
    /// </value>
    public double R_fa5 { get; set; }

    #endregion

    #region Cycle Values
    /// <summary>
    /// Gets or sets the heating.
    /// </summary>
    /// <value>
    /// The heating.
    /// </value>
    public string heating { get; set; }
    /// <summary>
    /// Gets or sets the cooling.
    /// </summary>
    /// <value>
    /// The cooling.
    /// </value>
    public string cooling { get; set; }
    /// <summary>
    /// Gets or sets the cycle count.
    /// </summary>
    /// <value>
    /// The cycle count.
    /// </value>
    public int cycleCount { get; set; }
    /// <summary>
    /// Gets or sets the new cycle temperature.
    /// </summary>
    /// <value>
    /// The new cycle temperature.
    /// </value>
    public double NewCycleTemperature { get; set; }
    /// <summary>
    /// Gets or sets the cycle current number.
    /// </summary>
    /// <value>
    /// The cycle current number.
    /// </value>
    public int cycleCurrentNum { get; set; }
    /// <summary>
    /// Gets or sets the steps for different measurments.
    /// </summary>
    /// <value>
    /// The steps.
    /// </value>
    public int Steps { get; set; }

    /// <summary>
    /// Gets or sets the current step at reversive measuring.
    /// </summary>
    /// <value>
    /// The current step.
    /// </value>
    public int CurrentStep { get; set; }
    /// <summary>
    /// Gets or sets the next current step.
    /// </summary>
    /// <value>
    /// The next current step.
    /// </value>
    public int NextCurrentStep { get; set; }
    #endregion  

    #region BiasU

    /// <summary>
    /// Gets or sets the LST.
    /// </summary>
    /// <value>
    /// The LST.
    /// </value>
    public List<string> lstUave { get; set; }
    /// <summary>
    /// Gets or sets the ListVoltage
    /// </summary>
    public string[] ListVoltage { get; set; }
    /// <summary>
    /// Gets or sets the bias Umax.
    /// </summary>
    /// <value>
    /// The bias umax.
    /// </value>
    public double BiasUmax { get; set; }
    /// <summary>
    /// Gets or sets the bias Umin.
    /// </summary>
    /// <value>
    /// The bias umin.
    /// </value>
    public double BiasUmin { get; set; }
    /// <summary>
    /// Gets or sets the bias Ucurrent.
    /// </summary>
    /// <value>
    /// The bias u current.
    /// </value>
    public double BiasUCurrent { get; set; }
    /// <summary>
    /// Gets or sets the bias h current.
    /// </summary>
    /// <value>
    /// The bias h current.
    /// </value>
    public double BiasHCurrent { get; set; }
    /// <summary>
    /// Gets or sets the bias u avarege.
    /// </summary>
    /// <value>
    /// The bias u avarege.
    /// </value>
    public double BiasUAvarege { get; set; }
    /// <summary>
    /// Gets or sets the cel sel bias u.
    /// </summary>
    /// <value>
    /// The cel sel bias u.
    /// </value>
    public int CelSelBiasU { get; set; }
    #endregion

    #region Temperature
    /// <summary>
    /// Gets or sets the temperature step.
    /// </summary>
    /// <value>
    /// The temperature step.
    /// </value>
    public double TemperatureStep { get; set; }
    /// <summary>
    /// Gets or sets the temperature1.
    /// </summary>
    /// <value>
    /// The temperature1.
    /// </value>
    public double Temperature1 { get; set; }
    /// <summary>
    /// Gets or sets the temperature2.
    /// </summary>
    /// <value>
    /// The temperature2.
    /// </value>
    public double Temperature2 { get; set; }
    /// <summary>
    /// Gets or sets the temperature3.
    /// </summary>
    /// <value>
    /// The temperature3.
    /// </value>
    public double Temperature3 { get; set; }
    /// <summary>
    /// Gets or sets the temperature reserv.
    /// </summary>
    /// <value>
    /// The temperature reserv.
    /// </value>
    public double TemperatureReserv { get; set; }

    #endregion

    #region Time&Timers
    /// <summary>
    /// Gets or sets the avarage inc time.
    /// </summary>
    /// <value>
    /// The avarage inc time.
    /// </value>
    public double AvarageIncTime { get; set; }
    /// <summary>
    /// Gets or sets the time meas.
    /// </summary>
    /// <value>
    /// The time meas.
    /// </value>
    public double TimeMeas { get; set; }

    /// <summary>
    /// Gets or sets the list timer.
    /// </summary>
    /// <value>
    /// The list timer.
    /// </value>
    public string[] ListTimer { get; set; }
    /// <summary>
    /// Gets or sets the voltage list.
    /// </summary>
    /// <value>
    /// The voltage list.
    /// </value>
    public int CurrentTimeStep { get; set; }
    /// <summary>
    /// Gets or sets the current time.
    /// </summary>
    /// <value>
    /// The current time.
    /// </value>
    public double CurrentTime { get; set; }

    /// <summary>
    /// Gets or sets the time start u.
    /// </summary>
    /// <value>
    /// The time start u.
    /// </value>
    public int TimeStartU { get; set; }
    /// <summary>
    /// Gets or sets the time period u.
    /// </summary>
    /// <value>
    /// The time period u.
    /// </value>
    public int TimePeriodU { get; set; }
    /// <summary>
    /// Gets or sets the time current u.
    /// </summary>
    /// <value>
    /// The time current u.
    /// </value>
    public int TimeCurrentU { get; set; }
    /// <summary>
    /// Gets or sets the sleep time.
    /// </summary>
    /// <value>
    /// The sleep time.
    /// </value>
    public int SleepTime { get; set; }
    /// <summary>
    /// Period of meas
    /// </summary>
    public int TimePeriod { get; set; }
    /// <summary>
    /// Start time
    /// </summary>
    public int TimeStart { get; set; }
    /// <summary>
    /// The time coef
    /// </summary>
    public double timeCoef { get; set; }
    #endregion

    #region Agilent4980
    //Agilent4980        
    /// <summary>
    /// Gets or sets the freq agilent4980.
    /// </summary>
    /// <value>
    /// The freq agilent4980.
    /// </value>
    public string FreqAgilent4980 { get; set; }
    /// <summary>
    /// Gets or sets the trig agilent4980.
    /// </summary>
    /// <value>
    /// The trig agilent4980.
    /// </value>
    public string TrigAgilent4980 { get; set; }
    /// <summary>
    /// Gets or sets the fetch agilent4980.
    /// </summary>
    /// <value>
    /// The fetch agilent4980.
    /// </value>
    public string FetchAgilent4980 { get; set; }
    /// <summary>
    /// Gets or sets the bias agilent4980.
    /// </summary>
    /// <value>
    /// The bias agilent4980.
    /// </value>
    public string BiasAgilent4980 { get; set; }
    #endregion

    #region Agilent4263
    /// <summary>
    /// Gets or sets the freq agilent4263.
    /// </summary>
    /// <value>
    /// The freq agilent4263.
    /// </value>
    public string FreqAgilent4263 { get; set; }
    /// <summary>
    /// Gets or sets the sens function agilent4263.
    /// </summary>
    /// <value>
    /// The sens function agilent4263.
    /// </value>
    public string SensFuncAgilent4263 { get; set; }
    /// <summary>
    /// Gets or sets the trig ext agilent4263.
    /// </summary>
    /// <value>
    /// The trig ext agilent4263.
    /// </value>
    public string TrigExtAgilent4263 { get; set; }
    /// <summary>
    /// Gets or sets the trig bus agilent4263.
    /// </summary>
    /// <value>
    /// The trig bus agilent4263.
    /// </value>
    public string TrigBusAgilent4263 { get; set; }
    /// <summary>
    /// Gets or sets the fetch agilent4263.
    /// </summary>
    /// <value>
    /// The fetch agilent4263.
    /// </value>
    public string FetchAgilent4263 { get; set; }
    /// <summary>
    /// Gets or sets the function agilent4263 CH1.
    /// </summary>
    /// <value>
    /// The function agilent4263 CH1.
    /// </value>
    public string FuncAgilent4263Ch1 { get; set; }
    //+  CP        
    /// <summary>
    /// Gets or sets the function agilent4263 CH2.
    /// </summary>
    /// <value>
    /// The function agilent4263 CH2.
    /// </value>
    public string FuncAgilent4263Ch2 { get; set; }
    //+  D        
    /// <summary>
    /// Gets or sets the trig fetch agilent4263.
    /// </summary>
    /// <value>
    /// The trig fetch agilent4263.
    /// </value>
    public string TrigFetchAgilent4263 { get; set; }
    /// <summary>
    /// Gets or sets the form agilent4263.
    /// </summary>
    /// <value>
    /// The form agilent4263.
    /// </value>
    public string FormAgilent4263 { get; set; }
    #endregion

    #region WayneKerr6500B
    /// <summary>
    /// Gets or sets the RLC wayne kerr.
    /// </summary>
    /// <value>
    /// The RLC wayne kerr.
    /// </value>
    public string RLCWayneKerr6500B { get; set; }
    /// <summary>
    /// Gets or sets the freq wayne kerr.
    /// </summary>
    /// <value>
    /// The freq wayne kerr.
    /// </value>
    public string FreqWayneKerr6500B { get; set; }
    /// <summary>
    /// Gets or sets the trig wayne kerr6500 b.
    /// </summary>
    /// <value>
    /// The trig wayne kerr6500 b.
    /// </value>
    public string TrigWayneKerr6500B { get; set; }
    /// <summary>
    /// Gets or sets the bias wayne kerr6500 b.
    /// </summary>
    /// <value>
    /// The bias wayne kerr6500 b.
    /// </value>
    public string BiasWayneKerr6500B { get; set; }
    #endregion

    #region WayneKerr4300
    /// <summary>
    /// Gets or sets the freq wayne kerr4300.
    /// </summary>
    /// <value>
    /// The freq wayne kerr4300.
    /// </value>
    public string FreqWayneKerr4300 { get; set; }
    /// <summary>
    /// Gets or sets the trig wayne kerr4300.
    /// </summary>
    /// <value>
    /// The trig wayne kerr4300.
    /// </value>
    public string TrigWayneKerr4300 { get; set; }
    /// <summary>
    /// Gets or sets the RLC wayne kerr4300 1.
    /// </summary>
    /// <value>
    /// The RLC wayne kerr4300 1.
    /// </value>
    public string RLCWayneKerr4300_1 { get; set; }
    /// <summary>
    /// Gets or sets the RLC wayne kerr4300 2.
    /// </summary>
    /// <value>
    /// The RLC wayne kerr4300 2.
    /// </value>
    public string RLCWayneKerr4300_2 { get; set; }
    #endregion

    #region Agilent4285
    /// <summary>
    /// Gets or sets the freq agilent4285.
    /// </summary>
    /// <value>
    /// The freq agilent4285.
    /// </value>
    public string FreqAgilent4285 { get; set; }
    /// <summary>
    /// Gets or sets the function agilent4285.
    /// </summary>
    /// <value>
    /// The function agilent4285.
    /// </value>
    public string FuncAgilent4285 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string TrigAgilent4285Ext { get; set; }
    /// <summary>
    /// Gets or sets the trig agilent4285.
    /// </summary>
    /// <value>
    /// The trig agilent4285.
    /// </value>
    public string TrigAgilent4285 { get; set; }
    /// <summary>
    /// Gets or sets the fetch agilent4285.
    /// </summary>
    /// <value>
    /// The fetch agilent4285.
    /// </value>
    public string FetchAgilent4285 { get; set; }

    #endregion

    #region Dielectric paramaters
    /// <summary>
    /// Real part of dielectric constant
    /// </summary>
    public double e_re { get; set; }

    public double es_re { get; set; }
    public double ep_re { get; set; }

    /// <summary>
    /// Imaginary part of dielectric constant
    /// </summary>
    public double e_im { get; set; }
    public double es_im { get; set; }
    public double ep_im { get; set; }
    /// <summary>
    /// Capacitance from LCR-meter
    /// </summary>
    public double C_pf { get; set;}
    /// <summary>
    /// 
    /// </summary>
    public double Cs_pf { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double Cp_pf { get; set; }
    /// <summary>
    /// Tangent angle
    /// </summary>
    public double tgd { get; set; }
    /// <summary>
    /// Value A from LCR-meter
    /// </summary>
    public double valA { get; set; }
    /// <summary>
    /// Value B from LCR-meter
    /// </summary>
    public double valB { get; set; }
    #endregion


    #region E7-20
    /// <summary>
    /// bufer of LCR E7_20
    /// </summary>
    public byte[] bufE7_20 = new byte[22];
    /// <summary>
    /// 1 parameter LCR E7_20
    /// </summary>
    public double param1_E7_20 { get; set; }
    /// <summary>
    /// multiplier of parameter1 LCR E7_20
    /// </summary>
    public int multiplier1_E7_20 { get; set; }
    /// <summary>
    /// 2 parameter LCR E7_20
    /// </summary>
    public double param2_E7_20 { get; set; }
    /// <summary>
    /// multiplier of parameter1 LCR E7_20
    /// </summary>
    public int multilier2_E7_20 { get; set; }
    /// <summary>
    /// level of measuring
    /// </summary>
    public double Level_E7_20 { get; set; }
    /// <summary>
    /// frequency of E7_20
    /// </summary>
    public int frequencyE7_20 { get; set; }

    #endregion

    #region E7-28

    public int e7_28_dev_address { get; set; }
    /// <summary>
    /// 64 – Получить имя прибора
    /// 65 - Включить АВП	(0хAA,65)
    /// 66 - Выключить АВП	(0хAA,66)
    /// РС:	(0хAA,67, f4,f3,f2,f1) ;	ПРИБОР: (0хAA,67)
    /// Где: f1,f2,f3,f4 – 4 байта целого числа;
    /// 70 – Установить смещение РС: (0хAA, 70, U1, U0); ПРИБОР: (0хAA, 70) 
    ///         Где: U1, U0 – 2 байта целого (int16) числа * 10
    /// 71 – Сброс в состояние по умолчанию РС:	(0хAA, 71); ПРИБОР:	(0хAA, 71)
    /// 72 – Выдача полной измеряемой информации
    /// РС:	(0хAA, 72): 1. РС:  (0хAA, 72, 0) – измерение не закончено
    ///         2. ПРИБОР:  (0хAA [0], 72[1], flags [2], mode [3], 
    ///         slow [4], diap [5], Uсм1 [6], Uсм0 [7],  
    ///         f3…f0 [8-11], Z3…Z0 [12-15], φ3…φ0 [16-19])
    ///         Flags(биты): 
    ///         0-АВП;
    ///         1-Ток(не используется);
    ///         2-Перегрузка;
    ///         3-Автовыбор параметра;
    ///         4-Схема замещения(1-пар, 0-посл.)
    ///         7-цикл измерения завершен.
    ///         mode: параметр, изменяемый клавиатурой (функциональными клавишами F1-F4): F1 … 3- F4
    ///         slow: скорость измерения:  0-быстро; 1-норма; 2-усредение по 10
    ///         diap: диапазон измерения:
    ///         0 - 10МОм
    ///         1 - 1МОм
    ///         2 – 100кОм
    ///         3 – 10кОм
    ///         4 – 1кОм
    ///         5 – 100Ом
    ///         6 – 10Ом
    ///         7 – 1Ом
    ///         Uсм1..Uсм0 – 2 байта 16-разрядного (int16) целого числа (смещение*10)
    ///         f3…f0 – 4 байта(int32) целого числа(рабочая частота)
    ///         Z3…Z0 – 4 байта(float) вещественного числа(модуль комплексного сопротив-ления для последовательной схемы замещения.)
    ///         φ 3… φ 0 – 4 байта(float) вещественного числа(фазовый угол для последова-тельной схемы замещения.)
    /// </summary>
    public int e7_28_command { get; set; }
    /// <summary>
    /// 0-АВП; 
    /// 1-Ток(не используется); 
    /// 2-Перегрузка; 
    /// 3-Автовыбор параметра; 
    /// 4-Схема замещения(1-пар, 0-посл.) 
    /// 7-цикл измерения завершен.
    /// </summary>
    public string e7_28_flags { get; set; }
    /// parameter changed by the keyboard (function keys F1-F4)
    /// </summary>
    public int e7_28_mode { get; set; }
    /// <summary>
    /// measurment speed 
    /// </summary>
    public int e7_28_slow { get; set; }
    /// <summary>
    /// range of measurment
    /// </summary>
    public int e7_28_diap { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Int16 e7_28_biasU { get; set; }

    #endregion

#region dielectrics variables
    /// <summary>
    /// Impedance
    /// </summary>
    public float var_Z { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public float var_angleZ { get; set; }
    /// <summary>
    /// 
    /// </summary>

    public double var_angleY { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_absY { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Rs { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Xs { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Gs { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Bs { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Gp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Xp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Bp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Rp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Cs { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Cp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Lp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Ls { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_Q { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double var_tg { get; set; }
    #endregion


    #region GPIB        
    /// <summary>
    /// Gets or sets the fetch gpib devices.
    /// </summary>
    /// <value>
    /// The fetch gpib devices.
    /// </value>
    public string FetchGPIBDevices { get; set; }
    #endregion

    #region FileName
    //File name for saving        
    /// <summary>
    /// Gets or sets the file name save temporary meas.
    /// </summary>
    /// <value>
    /// The file name save temporary meas.
    /// </value>
    public string FileNameSaveTempMeas { get; set; }
    /// <summary>
    /// Gets or sets the file name save temporary meas database.
    /// </summary>
    /// <value>
    /// The file name save temporary meas database.
    /// </value>
    public string FileNameSaveTempMeasDB { get; set; }
    /// <summary>
    /// Gets or sets the file name save temporary meas database log.
    /// </summary>
    /// <value>
    /// The file name save temporary meas database log.
    /// </value>
    public string FileNameSaveTempMeasDBLog { get; set; }
    /// <summary>
    /// Gets or sets the file name save temporary meas log.
    /// </summary>
    /// <value>
    /// The file name save temporary meas log.
    /// </value>
    public string FileNameSaveTempMeasLog { get; set; }

    /// <summary>
    /// Gets or sets the type of the open sorting.
    /// </summary>
    /// <value>
    /// The type of the open sorting.
    /// </value>
    public string OpenSortingType { get; set; }
    /// <summary>
    /// Gets or sets the type of the save sorting.
    /// </summary>
    /// <value>
    /// The type of the save sorting.
    /// </value>
    public string SaveSortingType { get; set; }

    #endregion

    #region DBValues
    /// <summary>
    /// Data base sql command
    /// </summary>
    public string DB_SQL_CMD { get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="PiezoParameters" /> class.
    /// </summary>
    /// <value>
    /// The database server.
    /// </value>
    public string DBServer { set; get; }
    /// <summary>
    /// Gets or sets the database port.
    /// </summary>
    /// <value>
    /// The database port.
    /// </value>
    public string DBPort { set; get; }
    /// <summary>
    /// Gets or sets the database user identifier.
    /// </summary>
    /// <value>
    /// The database user identifier.
    /// </value>
    public string DBUserId { set; get; }
    /// <summary>
    /// Gets or sets the database password.
    /// </summary>
    /// <value>
    /// The database password.
    /// </value>
    public string DBPassword { set; get; }
    /// <summary>
    /// Gets or sets the d bname.
    /// </summary>
    /// <value>
    /// The d bname.
    /// </value>
    public string DBname { set; get; }
    /// <summary>
    /// Gets or sets a value indicating whether [database connected].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [database connected]; otherwise, <c>false</c>.
    /// </value>
    public bool DBConnected { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether [DBSQL success].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [DBSQL success]; otherwise, <c>false</c>.
    /// </value>
    public bool DBSQLSuccess { get; set; }
    /// <summary>
    /// Gets or sets the DBSQL connction string.
    /// </summary>
    /// <value>
    /// The DBSQL connction string.
    /// </value>
    public string DBSQLConnctionString { get; set; }
    /// <summary>
    /// Gets or sets the name of the database table.
    /// </summary>
    /// <value>
    /// The name of the database table.
    /// </value>
    public string DBTableName { get; set; }
    #endregion

    #region ColName
    private List<string> col { get; set; }
    /// <summary>
    /// Gets or sets the col1.
    /// </summary>
    /// <value>
    /// The col1.
    /// </value>
    public string col1 { get; set; }
    /// <summary>
    /// Gets or sets the col2.
    /// </summary>
    /// <value>
    /// The col2.
    /// </value>
    public string col2 { get; set; }
    /// <summary>
    /// Gets or sets the col3.
    /// </summary>
    /// <value>
    /// The col3.
    /// </value>
    public string col3 { get; set; }
    /// <summary>
    /// Gets or sets the col4.
    /// </summary>
    /// <value>
    /// The col4.
    /// </value>
    public string col4 { get; set; }
    /// <summary>
    /// Gets or sets the col5.
    /// </summary>
    /// <value>
    /// The col5.
    /// </value>
    public string col5 { get; set; }
    /// <summary>
    /// Gets or sets the col6.
    /// </summary>
    /// <value>
    /// The col6.
    /// </value>
    public string col6 { get; set; }
    /// <summary>
    /// Gets or sets the col7.
    /// </summary>
    /// <value>
    /// The col7.
    /// </value>
    public string col7 { get; set; }
    /// <summary>
    /// Gets or sets the col8.
    /// </summary>
    /// <value>
    /// The col8.
    /// </value>
    public string col8 { get; set; }
    /// <summary>
    /// Gets or sets the col9.
    /// </summary>
    /// <value>
    /// The col9.
    /// </value>
    public string col9 { get; set; }
    /// <summary>
    /// Gets or sets the col10.
    /// </summary>
    /// <value>
    /// The col10.
    /// </value>
    public string col10 { get; set; }
    /// <summary>
    /// Gets or sets the col11.
    /// </summary>
    /// <value>
    /// The col11.
    /// </value>
    public string col11 { get; set; }
    /// <summary>
    /// Gets or sets the col12.
    /// </summary>
    /// <value>
    /// The col12.
    /// </value>
    public string col12 { get; set; }
    /// <summary>
    /// Gets or sets the col13.
    /// </summary>
    /// <value>
    /// The col13.
    /// </value>
    public string col13 { get; set; }

    #endregion


    #region vars for DB
    /// <summary>
    /// 
    /// </summary>
    public string composition { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string id_sample { get; set; }
    #endregion




    struct Active_Meas_Device 
    {
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        public int DeviceID { get; set; }
        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        public string DeviceName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Active_Meas_Device"/> is measuring.
        /// </summary>
        /// <value>
        ///   <c>true</c> if measuring; otherwise, <c>false</c>.
        /// </value>
        public bool make_measutrment { get; set;}
        /// <summary>
        /// Sets the information.
        /// </summary>
        /// <param name="deviceIdentificator">The device identificator.</param>
        /// <param name="DeviceName">Name of the device.</param>
        /// <param name="meas">if set to <c>true</c> [meas].</param>
        public void SetInfo(int deviceIdentificator, string DevName, bool measuring)
        {
            DeviceID = deviceIdentificator;
            DeviceName = DevName;
            make_measutrment = measuring;
        }
    }

    public struct DeviceTimersStruct
    {
        /// <summary>
        /// The timer
        /// </summary>
        public Timer Timer;
        /// <summary>
        /// The device identifier
        /// </summary>
        public int DeviceID;
        /// <summary>
        /// Sets the sata.
        /// </summary>
        /// <param name="timer">The timer.</param>
        /// <param name="id">The identifier.</param>
        public void SetSata(Timer timer, int id)
        {
            Timer = timer;
            DeviceID = id;
        }
    }
    public DeviceTimersStruct [] DeviceTimers = new DeviceTimersStruct[10];
    /// <summary>
    /// Gets or sets the cel sel.
    /// </summary>
    /// <value>
    /// The cel sel.
    /// </value>
    public int CelSel { get; set; }
    /// <summary>
    /// Gets or sets the cel sel piezo.
    /// </summary>
    /// <value>
    /// The cel sel piezo.
    /// </value>
    public int CelSelPiezo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int CelSelTemp { get; set; }
    
    /// <summary>
    /// Gets or sets the number of regularization    
    /// </summary>
    /// <value>
    /// The rho.
    /// </value>
    /// 
    public double RHO { get; set; } //number of regularization           
    /// <summary>
    /// Gets or sets the ip address.
    /// </summary>
    /// <value>
    /// The ip address.
    /// </value>
    public string IpAddress { get; set; }
    /// <summary>
    /// Gets or sets the CBF (number of basis functions).
    /// </summary>
    /// <value>
    /// The CBF.
    /// </value>
    public int CBF { get; set; }

    /// <summary>
    /// Gets or sets the temporary.
    /// </summary>
    /// <value>
    /// The temporary.
    /// </value>
    public double Temp { get; set; }
    /// <summary>
    /// Gets or sets the LCR model.
    /// </summary>
    /// <value>
    /// The LCR model.
    /// </value>
    public string LCR_model { get; set; }

    /// <summary>
    /// Gets or sets the current time rev.
    /// </summary>
    /// <value>
    /// The current time rev.
    /// </value>
    public int TimerReversive { get; set; }
    /// <summary>
    /// Gets or sets the direction.
    /// </summary>
    /// <value>
    /// The direction.
    /// </value>
    public string Direction { get; set; }
    /// <summary>
    /// Gets or sets the polarity.
    /// </summary>
    /// <value>
    /// The polarity.
    /// </value>
    public string Polarity { get; set; }
    /// <summary>
    /// Gets or sets the polarity positive.
    /// </summary>
    /// <value>
    /// The polarity positive.
    /// </value>
    public string PolarityPositive { get; set; }
    /// <summary>
    /// Gets or sets the polarity negative.
    /// </summary>
    /// <value>
    /// The polarity negative.
    /// </value>
    public string PolarityNegative { get; set; }
    /// <summary>
    /// Gets or sets the step reversive long.
    /// </summary>
    /// <value>
    /// The step reversive long.
    /// </value>
    public Int32 StepReversiveLong { get; set; }
    /// <summary>
    /// Gets or sets the col.
    /// </summary>
    /// <value>
    /// The col.
    /// </value>
    public List<string> Col { get => col; set => col = value; }

    /// <summary>
    /// Gets or sets the array u.
    /// </summary>
    /// <value>
    /// The array u.
    /// </value>
    public int[] array_u { get; set; }
    /// <summary>
    /// Gets or sets the array f fr.
    /// </summary>
    /// <value>
    /// The array f fr.
    /// </value>
    public int[] array_f_fr { get; set; }
    /// <summary>
    /// Gets or sets the array f dispersion.
    /// </summary>
    /// <value>
    /// The array f dispersion.
    /// </value>
    public int[] array_f_dispersion { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="PiezoParameters"/> is hand.
    /// </summary>
    /// <value>
    ///   <c>true</c> if hand; otherwise, <c>false</c>.
    /// </value>
    public bool hand { get; set; }
    /// <summary>
    /// Constructor
    /// </summary>
    public PiezoParameters()
    {
        IpAddress = "127.0.0.1";
        TimerReversive = 0;
        CurrentStep = 0;
        NextCurrentStep = 1;
        Direction = "Heating";

        PolarityNegative = "negative";
        PolarityPositive = "positive";

        Polarity = PolarityPositive;
        thicknes = 0.1;
        diametr = 1.000;
        MeasuringFrequency = 1000;
        fr1 = 0;
        fa1 = 0;
        fr3 = 0;
        fa3 = 0;
        fr5 = 0;
        fa5 = 0;
        R_fr1 = 0;
        R_fa1 = 0;
        R_fr3 = 0;
        R_fa3 = 0;
        R_fa5 = 0;
        TimeMeas = 0;
        cycleCount = 40;
        NewCycleTemperature = 345;
        cycleCurrentNum = 1;
        #region biasU
        BiasUmax = 0;
        BiasUCurrent = 0;
        BiasUmin = 0;

        BiasUAvarege = 0;
        #endregion


        TimeStartU = 1;
        TimePeriodU = 1;
        TimeCurrentU = 1;

        TemperatureStep = 0;
        Temperature1 = 0;
        Temperature2 = 0;
        Temperature3 = 0;
        TemperatureReserv = 300;
        SleepTime = 0;
        CelSel = 0;
        CelSelPiezo = 0;
        RHO = 2.5; //number of regularization        
        CBF = 60; // number of basis functions

        LCR_model = "";
        //WayneKerr6500B
        RLCWayneKerr6500B = ":METER:FUNC:";
        FreqWayneKerr6500B = ":METER:FREQ ";
        TrigWayneKerr6500B = ":METER:TRIG";
        BiasWayneKerr6500B = ":METER:BIAS";

        //WayneKerr4300
        RLCWayneKerr4300_1 = ":MEAS:FUNC1 ";
        RLCWayneKerr4300_1 = ":MEAS:FUNC2 ";
        TrigWayneKerr4300 = ":MEAS:TRIG";
        FreqWayneKerr4300 = ":MEAS:FREQ ";

        //Agilent4980
        FreqAgilent4980 = "FREQ ";
        TrigAgilent4980 = "*TRIG";
        FetchAgilent4980 = "fetch?";
        BiasAgilent4980 = ":BIAS:VOLTage ";
        //Agilent4263
        FreqAgilent4263 = ":SOUR:FREQ ";
        SensFuncAgilent4263 = ":SENS:FUNC 'FADM'";
        TrigExtAgilent4263 = ":TRIG:SOUR EXT";
        TrigBusAgilent4263 = ":TRIG:SOUR BUS";
        FetchAgilent4263 = "FETCh?";
        FuncAgilent4263Ch1 = ":CALC1:FORM "; //+  CP        
        FuncAgilent4263Ch2 = ":CALC2:FORM "; //+  D        
        TrigFetchAgilent4263 = ":TRIG;FETCh?";
        FormAgilent4263 = ":FORM ";
        //Agilent4285
        FreqAgilent4285 = "FREQ ";
        FuncAgilent4285 = "FUNC:IMP "; //+  CPQ        
        TrigAgilent4285Ext = "TRIG:SOUR EXT";
        TrigAgilent4285 = "TRIG;";
        FetchAgilent4285 = "FETCh?;";
        //Agilent
        FetchGPIBDevices = "FETCh?";

        //File Data
        FileNameSaveTempMeas = "";
        FileNameSaveTempMeasDB = "";
        FileNameSaveTempMeasDBLog = "";
        FileNameSaveTempMeasLog = "";
        OpenSortingType = "Simple";
        SaveSortingType = "Excel";

        DBServer = "";
        DBPort = "";
        DBUserId = "";
        DBPassword = "";
        DBname = "";
        DBSQLConnctionString = "";
        DBConnected = false;
        DBSQLSuccess = false;
        DBTableName = "";

        StepReversiveLong = 0;

        heating = "Heating";
        cooling = "Cooling";

        CurrentTimeStep = 0;
        CurrentTime = 0;
        AvarageIncTime = 0.13244;
        timeCoef = 0.001;
        Xi0 = new List<double>(1000);
        hand = true;
    }
}

