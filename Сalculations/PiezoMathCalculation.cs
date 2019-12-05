using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


    class PiezoMathCalculation
    {
        /// <summary>
        /// The sigma array
        /// </summary>
        private double[] sigma;
        /// <summary>
        /// Gets or sets the sigmaper.
        /// </summary>
        /// <value>
        /// The sigmaper.
        /// </value>
        private double sigmaper { get; set; }
        /// <summary>
        /// The nu array
        /// </summary>
        double[] nu;
        /// <summary>
        /// Gets or sets the nuper.
        /// </summary>
        /// <value>
        /// The nuper.
        /// </value>
        private double nuper { get; set; }
        /// <summary>
        /// The beta array
        /// </summary>
        private double[] beta;
        /// <summary>
        /// The xi
        /// </summary>
        private double[] Xi;
        /// <summary>
        /// The u micron out
        /// </summary>
        private double[] UMicronOut { get; set; }
        /// <summary>
        /// Gets or sets the betaper.
        /// </summary>
        /// <value>
        /// The betaper.
        /// </value>
        private double betaper { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PiezoMathCalculation"/> class.
        /// </summary>
        public PiezoMathCalculation()
        {
            SetSigmaMas();
            SetNuMas();
            SetBetaMas();

        }
        /// <summary>
        /// Maximums the value from array.
        /// </summary>
        /// <param name="array_in">The array.</param>
        /// <returns>Max double value from array</returns>
        public double MaxValFromArray(double[] array_in)
        {
            double max = array_in[0];
            for (int i = 0; i < array_in.Length; i++)
            {
                if (max < array_in[i])
                {
                    max = array_in[i];
                }
            }
            return max;
        }
        /// <summary>
        /// Minimums the value from array.
        /// </summary>
        /// <param name="array_in">The array in.</param>
        /// <returns>Min double value from array</returns>
        public double MinValFromArray(double[] array_in)
        {
            double min = array_in[0];
            for (int i = 0; i < array_in.Length; i++)
            {
                if (min < array_in[i])
                {
                    min = array_in[i];
                }
            }
            return min;
        }
        /// <summary>
        /// Minimum number of element from array.
        /// </summary>
        /// <param name="array_in">The array in.</param>
        /// <returns></returns>
        public double MinNumFromArray(double[] array_in)
        {
            double min = array_in[0];
            int j = 0;
            for (int i = 0; i < array_in.Length; i++)
            {
                if (min < array_in[i])
                {
                    j = i;
                }
            }
            return j;
        }
        /// <summary>
        /// Maximum number of element from array.
        /// </summary>
        /// <param name="array_in">The array in.</param>
        /// <returns></returns>
        public double MaxNumFromArray(double[] array_in)
        {
            double max = array_in[0];
            int j = 0;
            for (int i = 0; i < array_in.Length; i++)
            {
                if (max < array_in[i])
                {
                    j = i;
                }
            }
            return j;
        }
        /// <summary>
        /// Find the frequences for measurments from range.
        /// </summary>
        /// <returns>Frequency array</returns>
        public double[] FindFreqs(int start, int end, int pointC)
        {
            double[] freqs = new double[pointC];
            int x = (end - start) / pointC;
            freqs[0] = start;
            for (int i = 1; i < pointC; i++)
            {
                freqs[i] += x;
            }
            return freqs;
        }
        /// <summary>
        /// Sets the sigma mas.
        /// </summary>
        public void SetSigmaMas()
        {
            //задание массива для сигма
            sigma = new double[460];
            double p = 0.001;
            for (int i = 0; i < sigma.Length; i++)
            {
                sigma[i] = 0.139 + p;
                p = p + 0.001;
            }
        }

        public void SetUMicronOutMas()
        {
            int masSize = 2003;
            UMicronOut = new double[masSize];

            int i = 1;
            ++i; UMicronOut[i] = 0.9164;
            ++i; UMicronOut[i] = 0.915894;
            ++i; UMicronOut[i] = 0.915388;
            ++i; UMicronOut[i] = 0.914882;
            ++i; UMicronOut[i] = 0.914376;
            ++i; UMicronOut[i] = 0.91387;
            ++i; UMicronOut[i] = 0.913364;
            ++i; UMicronOut[i] = 0.912858;
            ++i; UMicronOut[i] = 0.912352;
            ++i; UMicronOut[i] = 0.911846;
            ++i; UMicronOut[i] = 0.91134;
            ++i; UMicronOut[i] = 0.910834;
            ++i; UMicronOut[i] = 0.910328;
            ++i; UMicronOut[i] = 0.909822;
            ++i; UMicronOut[i] = 0.909316;
            ++i; UMicronOut[i] = 0.90881;
            ++i; UMicronOut[i] = 0.908304;
            ++i; UMicronOut[i] = 0.907798;
            ++i; UMicronOut[i] = 0.907292;
            ++i; UMicronOut[i] = 0.906786;
            ++i; UMicronOut[i] = 0.90628;
            ++i; UMicronOut[i] = 0.905774;
            ++i; UMicronOut[i] = 0.905268;
            ++i; UMicronOut[i] = 0.904762;
            ++i; UMicronOut[i] = 0.904256;
            ++i; UMicronOut[i] = 0.90375;
            ++i; UMicronOut[i] = 0.903244;
            ++i; UMicronOut[i] = 0.902738;
            ++i; UMicronOut[i] = 0.902232;
            ++i; UMicronOut[i] = 0.901726;
            ++i; UMicronOut[i] = 0.90122;
            ++i; UMicronOut[i] = 0.900714;
            ++i; UMicronOut[i] = 0.900207;
            ++i; UMicronOut[i] = 0.899701;
            ++i; UMicronOut[i] = 0.899195;
            ++i; UMicronOut[i] = 0.898689;
            ++i; UMicronOut[i] = 0.898183;
            ++i; UMicronOut[i] = 0.897677;
            ++i; UMicronOut[i] = 0.897171;
            ++i; UMicronOut[i] = 0.896665;
            ++i; UMicronOut[i] = 0.896159;
            ++i; UMicronOut[i] = 0.895653;
            ++i; UMicronOut[i] = 0.895147;
            ++i; UMicronOut[i] = 0.894641;
            ++i; UMicronOut[i] = 0.894135;
            ++i; UMicronOut[i] = 0.893629;
            ++i; UMicronOut[i] = 0.893123;
            ++i; UMicronOut[i] = 0.892617;
            ++i; UMicronOut[i] = 0.892111;
            ++i; UMicronOut[i] = 0.891605;
            ++i; UMicronOut[i] = 0.891099;
            ++i; UMicronOut[i] = 0.890593;
            ++i; UMicronOut[i] = 0.890087;
            ++i; UMicronOut[i] = 0.889581;
            ++i; UMicronOut[i] = 0.889075;
            ++i; UMicronOut[i] = 0.888569;
            ++i; UMicronOut[i] = 0.888063;
            ++i; UMicronOut[i] = 0.887557;
            ++i; UMicronOut[i] = 0.887051;
            ++i; UMicronOut[i] = 0.886545;
            ++i; UMicronOut[i] = 0.886039;
            ++i; UMicronOut[i] = 0.885533;
            ++i; UMicronOut[i] = 0.885027;
            ++i; UMicronOut[i] = 0.884521;
            ++i; UMicronOut[i] = 0.884015;
            ++i; UMicronOut[i] = 0.883509;
            ++i; UMicronOut[i] = 0.883003;
            ++i; UMicronOut[i] = 0.882497;
            ++i; UMicronOut[i] = 0.881991;
            ++i; UMicronOut[i] = 0.881485;
            ++i; UMicronOut[i] = 0.880979;
            ++i; UMicronOut[i] = 0.880473;
            ++i; UMicronOut[i] = 0.879967;
            ++i; UMicronOut[i] = 0.879461;
            ++i; UMicronOut[i] = 0.878955;
            ++i; UMicronOut[i] = 0.878449;
            ++i; UMicronOut[i] = 0.877943;
            ++i; UMicronOut[i] = 0.877437;
            ++i; UMicronOut[i] = 0.876931;
            ++i; UMicronOut[i] = 0.876425;
            ++i; UMicronOut[i] = 0.875919;
            ++i; UMicronOut[i] = 0.875413;
            ++i; UMicronOut[i] = 0.874907;
            ++i; UMicronOut[i] = 0.874401;
            ++i; UMicronOut[i] = 0.873895;
            ++i; UMicronOut[i] = 0.873389;
            ++i; UMicronOut[i] = 0.872883;
            ++i; UMicronOut[i] = 0.872377;
            ++i; UMicronOut[i] = 0.871871;
            ++i; UMicronOut[i] = 0.871365;
            ++i; UMicronOut[i] = 0.870859;
            ++i; UMicronOut[i] = 0.870353;
            ++i; UMicronOut[i] = 0.869847;
            ++i; UMicronOut[i] = 0.869341;
            ++i; UMicronOut[i] = 0.868835;
            ++i; UMicronOut[i] = 0.868329;
            ++i; UMicronOut[i] = 0.867823;
            ++i; UMicronOut[i] = 0.867317;
            ++i; UMicronOut[i] = 0.866811;
            ++i; UMicronOut[i] = 0.866305;
            ++i; UMicronOut[i] = 0.865799;
            ++i; UMicronOut[i] = 0.865293;
            ++i; UMicronOut[i] = 0.864787;
            ++i; UMicronOut[i] = 0.864281;
            ++i; UMicronOut[i] = 0.863775;
            ++i; UMicronOut[i] = 0.863269;
            ++i; UMicronOut[i] = 0.862763;
            ++i; UMicronOut[i] = 0.862257;
            ++i; UMicronOut[i] = 0.861751;
            ++i; UMicronOut[i] = 0.861245;
            ++i; UMicronOut[i] = 0.860739;
            ++i; UMicronOut[i] = 0.860233;
            ++i; UMicronOut[i] = 0.859727;
            ++i; UMicronOut[i] = 0.859221;
            ++i; UMicronOut[i] = 0.858715;
            ++i; UMicronOut[i] = 0.858209;
            ++i; UMicronOut[i] = 0.857703;
            ++i; UMicronOut[i] = 0.857197;
            ++i; UMicronOut[i] = 0.856691;
            ++i; UMicronOut[i] = 0.856185;
            ++i; UMicronOut[i] = 0.855679;
            ++i; UMicronOut[i] = 0.855173;
            ++i; UMicronOut[i] = 0.854667;
            ++i; UMicronOut[i] = 0.854161;
            ++i; UMicronOut[i] = 0.853655;
            ++i; UMicronOut[i] = 0.853149;
            ++i; UMicronOut[i] = 0.852643;
            ++i; UMicronOut[i] = 0.852137;
            ++i; UMicronOut[i] = 0.851631;
            ++i; UMicronOut[i] = 0.851125;
            ++i; UMicronOut[i] = 0.850619;
            ++i; UMicronOut[i] = 0.850113;
            ++i; UMicronOut[i] = 0.849607;
            ++i; UMicronOut[i] = 0.849101;
            ++i; UMicronOut[i] = 0.848595;
            ++i; UMicronOut[i] = 0.848089;
            ++i; UMicronOut[i] = 0.847583;
            ++i; UMicronOut[i] = 0.847077;
            ++i; UMicronOut[i] = 0.846571;
            ++i; UMicronOut[i] = 0.846065;
            ++i; UMicronOut[i] = 0.845559;
            ++i; UMicronOut[i] = 0.845053;
            ++i; UMicronOut[i] = 0.844547;
            ++i; UMicronOut[i] = 0.844041;
            ++i; UMicronOut[i] = 0.843535;
            ++i; UMicronOut[i] = 0.843029;
            ++i; UMicronOut[i] = 0.842523;
            ++i; UMicronOut[i] = 0.842017;
            ++i; UMicronOut[i] = 0.841511;
            ++i; UMicronOut[i] = 0.841005;
            ++i; UMicronOut[i] = 0.840499;
            ++i; UMicronOut[i] = 0.839993;
            ++i; UMicronOut[i] = 0.839487;
            ++i; UMicronOut[i] = 0.838981;
            ++i; UMicronOut[i] = 0.838475;
            ++i; UMicronOut[i] = 0.837969;
            ++i; UMicronOut[i] = 0.837463;
            ++i; UMicronOut[i] = 0.836957;
            ++i; UMicronOut[i] = 0.836451;
            ++i; UMicronOut[i] = 0.835945;
            ++i; UMicronOut[i] = 0.8354385;
            ++i; UMicronOut[i] = 0.834933;
            ++i; UMicronOut[i] = 0.834427;
            ++i; UMicronOut[i] = 0.833921;
            ++i; UMicronOut[i] = 0.833415;
            ++i; UMicronOut[i] = 0.8329085;
            ++i; UMicronOut[i] = 0.832403;
            ++i; UMicronOut[i] = 0.831897;
            ++i; UMicronOut[i] = 0.831391;
            ++i; UMicronOut[i] = 0.830885;
            ++i; UMicronOut[i] = 0.8303785;
            ++i; UMicronOut[i] = 0.829873;
            ++i; UMicronOut[i] = 0.829367;
            ++i; UMicronOut[i] = 0.828861;
            ++i; UMicronOut[i] = 0.828355;
            ++i; UMicronOut[i] = 0.8278485;
            ++i; UMicronOut[i] = 0.827343;
            ++i; UMicronOut[i] = 0.826837;
            ++i; UMicronOut[i] = 0.826331;
            ++i; UMicronOut[i] = 0.825825;
            ++i; UMicronOut[i] = 0.8253185;
            ++i; UMicronOut[i] = 0.824813;
            ++i; UMicronOut[i] = 0.824307;
            ++i; UMicronOut[i] = 0.823801;
            ++i; UMicronOut[i] = 0.823295;
            ++i; UMicronOut[i] = 0.8227885;
            ++i; UMicronOut[i] = 0.822283;
            ++i; UMicronOut[i] = 0.821777;
            ++i; UMicronOut[i] = 0.821271;
            ++i; UMicronOut[i] = 0.820765;
            ++i; UMicronOut[i] = 0.8202585;
            ++i; UMicronOut[i] = 0.819753;
            ++i; UMicronOut[i] = 0.819247;
            ++i; UMicronOut[i] = 0.818741;
            ++i; UMicronOut[i] = 0.818235;
            ++i; UMicronOut[i] = 0.8177285;
            ++i; UMicronOut[i] = 0.817223;
            ++i; UMicronOut[i] = 0.816717;
            ++i; UMicronOut[i] = 0.816211;
            ++i; UMicronOut[i] = 0.815705;
            ++i; UMicronOut[i] = 0.81515;
            ++i; UMicronOut[i] = 0.814693;
            ++i; UMicronOut[i] = 0.814187;
            ++i; UMicronOut[i] = 0.813681;
            ++i; UMicronOut[i] = 0.813175;
            ++i; UMicronOut[i] = 0.8126685;
            ++i; UMicronOut[i] = 0.812163;
            ++i; UMicronOut[i] = 0.811657;
            ++i; UMicronOut[i] = 0.811151;
            ++i; UMicronOut[i] = 0.810645;
            ++i; UMicronOut[i] = 0.8101385;
            ++i; UMicronOut[i] = 0.809633;
            ++i; UMicronOut[i] = 0.809127;
            ++i; UMicronOut[i] = 0.808621;
            ++i; UMicronOut[i] = 0.808115;
            ++i; UMicronOut[i] = 0.8076085;
            ++i; UMicronOut[i] = 0.807103;
            ++i; UMicronOut[i] = 0.806597;
            ++i; UMicronOut[i] = 0.806091;
            ++i; UMicronOut[i] = 0.805585;
            ++i; UMicronOut[i] = 0.8050785;
            ++i; UMicronOut[i] = 0.804573;
            ++i; UMicronOut[i] = 0.804067;
            ++i; UMicronOut[i] = 0.803561;
            ++i; UMicronOut[i] = 0.803055;
            ++i; UMicronOut[i] = 0.8025485;
            ++i; UMicronOut[i] = 0.802043;
            ++i; UMicronOut[i] = 0.801537;
            ++i; UMicronOut[i] = 0.801031;
            ++i; UMicronOut[i] = 0.800525;
            ++i; UMicronOut[i] = 0.800018;
            ++i; UMicronOut[i] = 0.799513;
            ++i; UMicronOut[i] = 0.799007;
            ++i; UMicronOut[i] = 0.798501;
            ++i; UMicronOut[i] = 0.797995;
            ++i; UMicronOut[i] = 0.797488;
            ++i; UMicronOut[i] = 0.796983;
            ++i; UMicronOut[i] = 0.796477;
            ++i; UMicronOut[i] = 0.795971;
            ++i; UMicronOut[i] = 0.795465;
            ++i; UMicronOut[i] = 0.794958;
            ++i; UMicronOut[i] = 0.794453;
            ++i; UMicronOut[i] = 0.793947;
            ++i; UMicronOut[i] = 0.793441;
            ++i; UMicronOut[i] = 0.792935;
            ++i; UMicronOut[i] = 0.792428;
            ++i; UMicronOut[i] = 0.791923;
            ++i; UMicronOut[i] = 0.791417;
            ++i; UMicronOut[i] = 0.790911;
            ++i; UMicronOut[i] = 0.790405;
            ++i; UMicronOut[i] = 0.7898;
            ++i; UMicronOut[i] = 0.789393;
            ++i; UMicronOut[i] = 0.788887;
            ++i; UMicronOut[i] = 0.788381;
            ++i; UMicronOut[i] = 0.787875;
            ++i; UMicronOut[i] = 0.787368;
            ++i; UMicronOut[i] = 0.786863;
            ++i; UMicronOut[i] = 0.786357;
            ++i; UMicronOut[i] = 0.785851;
            ++i; UMicronOut[i] = 0.785345;
            ++i; UMicronOut[i] = 0.784838;
            ++i; UMicronOut[i] = 0.784333;
            ++i; UMicronOut[i] = 0.783827;
            ++i; UMicronOut[i] = 0.783321;
            ++i; UMicronOut[i] = 0.782815;
            ++i; UMicronOut[i] = 0.782308;
            ++i; UMicronOut[i] = 0.781803;
            ++i; UMicronOut[i] = 0.781297;
            ++i; UMicronOut[i] = 0.780791;
            ++i; UMicronOut[i] = 0.780285;
            ++i; UMicronOut[i] = 0.779778;
            ++i; UMicronOut[i] = 0.779273;
            ++i; UMicronOut[i] = 0.778767;
            ++i; UMicronOut[i] = 0.778261;
            ++i; UMicronOut[i] = 0.777755;
            ++i; UMicronOut[i] = 0.777248;
            ++i; UMicronOut[i] = 0.776743;
            ++i; UMicronOut[i] = 0.776237;
            ++i; UMicronOut[i] = 0.775731;
            ++i; UMicronOut[i] = 0.775225;
            ++i; UMicronOut[i] = 0.774718;
            ++i; UMicronOut[i] = 0.774213;
            ++i; UMicronOut[i] = 0.773707;
            ++i; UMicronOut[i] = 0.773201;
            ++i; UMicronOut[i] = 0.772695;
            ++i; UMicronOut[i] = 0.772188;
            ++i; UMicronOut[i] = 0.771683;
            ++i; UMicronOut[i] = 0.771177;
            ++i; UMicronOut[i] = 0.770671;
            ++i; UMicronOut[i] = 0.770165;
            ++i; UMicronOut[i] = 0.769658;
            ++i; UMicronOut[i] = 0.769153;
            ++i; UMicronOut[i] = 0.768647;
            ++i; UMicronOut[i] = 0.768141;
            ++i; UMicronOut[i] = 0.767635;
            ++i; UMicronOut[i] = 0.7671275;
            ++i; UMicronOut[i] = 0.766623;
            ++i; UMicronOut[i] = 0.766117;
            ++i; UMicronOut[i] = 0.765611;
            ++i; UMicronOut[i] = 0.765105;
            ++i; UMicronOut[i] = 0.7645975;
            ++i; UMicronOut[i] = 0.764093;
            ++i; UMicronOut[i] = 0.763587;
            ++i; UMicronOut[i] = 0.763081;
            ++i; UMicronOut[i] = 0.762575;
            ++i; UMicronOut[i] = 0.7620675;
            ++i; UMicronOut[i] = 0.761563;
            ++i; UMicronOut[i] = 0.761057;
            ++i; UMicronOut[i] = 0.760551;
            ++i; UMicronOut[i] = 0.760045;
            ++i; UMicronOut[i] = 0.7595375;
            ++i; UMicronOut[i] = 0.759033;
            ++i; UMicronOut[i] = 0.758527;
            ++i; UMicronOut[i] = 0.758021;
            ++i; UMicronOut[i] = 0.757515;
            ++i; UMicronOut[i] = 0.7570075;
            ++i; UMicronOut[i] = 0.756503;
            ++i; UMicronOut[i] = 0.755997;
            ++i; UMicronOut[i] = 0.755491;
            ++i; UMicronOut[i] = 0.754985;
            ++i; UMicronOut[i] = 0.7544775;
            ++i; UMicronOut[i] = 0.753973;
            ++i; UMicronOut[i] = 0.753467;
            ++i; UMicronOut[i] = 0.752961;
            ++i; UMicronOut[i] = 0.752455;
            ++i; UMicronOut[i] = 0.7519475;
            ++i; UMicronOut[i] = 0.751443;
            ++i; UMicronOut[i] = 0.750937;
            ++i; UMicronOut[i] = 0.750431;
            ++i; UMicronOut[i] = 0.749925;
            ++i; UMicronOut[i] = 0.7494175;
            ++i; UMicronOut[i] = 0.748913;
            ++i; UMicronOut[i] = 0.748407;
            ++i; UMicronOut[i] = 0.747901;
            ++i; UMicronOut[i] = 0.747395;
            ++i; UMicronOut[i] = 0.7468875;
            ++i; UMicronOut[i] = 0.746383;
            ++i; UMicronOut[i] = 0.745877;
            ++i; UMicronOut[i] = 0.745371;
            ++i; UMicronOut[i] = 0.744865;
            ++i; UMicronOut[i] = 0.7443575;
            ++i; UMicronOut[i] = 0.743853;
            ++i; UMicronOut[i] = 0.743347;
            ++i; UMicronOut[i] = 0.742841;
            ++i; UMicronOut[i] = 0.742335;
            ++i; UMicronOut[i] = 0.7418275;
            ++i; UMicronOut[i] = 0.741323;
            ++i; UMicronOut[i] = 0.740817;
            ++i; UMicronOut[i] = 0.740311;
            ++i; UMicronOut[i] = 0.739805;
            ++i; UMicronOut[i] = 0.739297;
            ++i; UMicronOut[i] = 0.738793;
            ++i; UMicronOut[i] = 0.738287;
            ++i; UMicronOut[i] = 0.737781;
            ++i; UMicronOut[i] = 0.737275;
            ++i; UMicronOut[i] = 0.736767;
            ++i; UMicronOut[i] = 0.736263;
            ++i; UMicronOut[i] = 0.735757;
            ++i; UMicronOut[i] = 0.735251;
            ++i; UMicronOut[i] = 0.734745;
            ++i; UMicronOut[i] = 0.734237;
            ++i; UMicronOut[i] = 0.733733;
            ++i; UMicronOut[i] = 0.733227;
            ++i; UMicronOut[i] = 0.732721;
            ++i; UMicronOut[i] = 0.732215;
            ++i; UMicronOut[i] = 0.731707;
            ++i; UMicronOut[i] = 0.731203;
            ++i; UMicronOut[i] = 0.730697;
            ++i; UMicronOut[i] = 0.730191;
            ++i; UMicronOut[i] = 0.729685;
            ++i; UMicronOut[i] = 0.729177;
            ++i; UMicronOut[i] = 0.728673;
            ++i; UMicronOut[i] = 0.728167;
            ++i; UMicronOut[i] = 0.727661;
            ++i; UMicronOut[i] = 0.727155;
            ++i; UMicronOut[i] = 0.726647;
            ++i; UMicronOut[i] = 0.726143;
            ++i; UMicronOut[i] = 0.725637;
            ++i; UMicronOut[i] = 0.725131;
            ++i; UMicronOut[i] = 0.724625;
            ++i; UMicronOut[i] = 0.724117;
            ++i; UMicronOut[i] = 0.723613;
            ++i; UMicronOut[i] = 0.723107;
            ++i; UMicronOut[i] = 0.722601;
            ++i; UMicronOut[i] = 0.722095;
            ++i; UMicronOut[i] = 0.721587;
            ++i; UMicronOut[i] = 0.721083;
            ++i; UMicronOut[i] = 0.720577;
            ++i; UMicronOut[i] = 0.720071;
            ++i; UMicronOut[i] = 0.719565;
            ++i; UMicronOut[i] = 0.719057;
            ++i; UMicronOut[i] = 0.718553;
            ++i; UMicronOut[i] = 0.718047;
            ++i; UMicronOut[i] = 0.717541;
            ++i; UMicronOut[i] = 0.717035;
            ++i; UMicronOut[i] = 0.716527;
            ++i; UMicronOut[i] = 0.716023;
            ++i; UMicronOut[i] = 0.715517;
            ++i; UMicronOut[i] = 0.715011;
            ++i; UMicronOut[i] = 0.714505;
            ++i; UMicronOut[i] = 0.713997;
            ++i; UMicronOut[i] = 0.713493;
            ++i; UMicronOut[i] = 0.712987;
            ++i; UMicronOut[i] = 0.712481;
            ++i; UMicronOut[i] = 0.711975;
            ++i; UMicronOut[i] = 0.711467;
            ++i; UMicronOut[i] = 0.710963;
            ++i; UMicronOut[i] = 0.710457;
            ++i; UMicronOut[i] = 0.709951;
            ++i; UMicronOut[i] = 0.709445;
            ++i; UMicronOut[i] = 0.708937;
            ++i; UMicronOut[i] = 0.708433;
            ++i; UMicronOut[i] = 0.707927;
            ++i; UMicronOut[i] = 0.707421;
            ++i; UMicronOut[i] = 0.706915;
            ++i; UMicronOut[i] = 0.706407;
            ++i; UMicronOut[i] = 0.705903;
            ++i; UMicronOut[i] = 0.705397;
            ++i; UMicronOut[i] = 0.704891;
            ++i; UMicronOut[i] = 0.704385;
            ++i; UMicronOut[i] = 0.7038765;
            ++i; UMicronOut[i] = 0.703373;
            ++i; UMicronOut[i] = 0.702867;
            ++i; UMicronOut[i] = 0.702361;
            ++i; UMicronOut[i] = 0.701855;
            ++i; UMicronOut[i] = 0.7013465;
            ++i; UMicronOut[i] = 0.700843;
            ++i; UMicronOut[i] = 0.700337;
            ++i; UMicronOut[i] = 0.699831;
            ++i; UMicronOut[i] = 0.699325;
            ++i; UMicronOut[i] = 0.6988164;
            ++i; UMicronOut[i] = 0.698313;
            ++i; UMicronOut[i] = 0.697807;
            ++i; UMicronOut[i] = 0.697301;
            ++i; UMicronOut[i] = 0.696795;
            ++i; UMicronOut[i] = 0.6962865;
            ++i; UMicronOut[i] = 0.695783;
            ++i; UMicronOut[i] = 0.695277;
            ++i; UMicronOut[i] = 0.694771;
            ++i; UMicronOut[i] = 0.694265;
            ++i; UMicronOut[i] = 0.6937565;
            ++i; UMicronOut[i] = 0.693253;
            ++i; UMicronOut[i] = 0.692747;
            ++i; UMicronOut[i] = 0.692241;
            ++i; UMicronOut[i] = 0.691735;
            ++i; UMicronOut[i] = 0.6912265;
            ++i; UMicronOut[i] = 0.690723;
            ++i; UMicronOut[i] = 0.690217;
            ++i; UMicronOut[i] = 0.689711;
            ++i; UMicronOut[i] = 0.689205;
            ++i; UMicronOut[i] = 0.6886965;
            ++i; UMicronOut[i] = 0.688193;
            ++i; UMicronOut[i] = 0.687687;
            ++i; UMicronOut[i] = 0.687181;
            ++i; UMicronOut[i] = 0.686675;
            ++i; UMicronOut[i] = 0.6861665;
            ++i; UMicronOut[i] = 0.685663;
            ++i; UMicronOut[i] = 0.685157;
            ++i; UMicronOut[i] = 0.684651;
            ++i; UMicronOut[i] = 0.684145;
            ++i; UMicronOut[i] = 0.6836365;
            ++i; UMicronOut[i] = 0.683133;
            ++i; UMicronOut[i] = 0.682627;
            ++i; UMicronOut[i] = 0.682121;
            ++i; UMicronOut[i] = 0.681615;
            ++i; UMicronOut[i] = 0.6811065;
            ++i; UMicronOut[i] = 0.680603;
            ++i; UMicronOut[i] = 0.680097;
            ++i; UMicronOut[i] = 0.679591;
            ++i; UMicronOut[i] = 0.679085;
            ++i; UMicronOut[i] = 0.6785765;
            ++i; UMicronOut[i] = 0.678073;
            ++i; UMicronOut[i] = 0.677567;
            ++i; UMicronOut[i] = 0.677061;
            ++i; UMicronOut[i] = 0.676555;
            ++i; UMicronOut[i] = 0.6760465;
            ++i; UMicronOut[i] = 0.675543;
            ++i; UMicronOut[i] = 0.675037;
            ++i; UMicronOut[i] = 0.674531;
            ++i; UMicronOut[i] = 0.674025;
            ++i; UMicronOut[i] = 0.673519;
            ++i; UMicronOut[i] = 0.673013;
            ++i; UMicronOut[i] = 0.672507;
            ++i; UMicronOut[i] = 0.672001;
            ++i; UMicronOut[i] = 0.671495;
            ++i; UMicronOut[i] = 0.670989;
            ++i; UMicronOut[i] = 0.670483;
            ++i; UMicronOut[i] = 0.669977;
            ++i; UMicronOut[i] = 0.669471;
            ++i; UMicronOut[i] = 0.668965;
            ++i; UMicronOut[i] = 0.668456;
            ++i; UMicronOut[i] = 0.667953;
            ++i; UMicronOut[i] = 0.667447;
            ++i; UMicronOut[i] = 0.666941;
            ++i; UMicronOut[i] = 0.666435;
            ++i; UMicronOut[i] = 0.665929;
            ++i; UMicronOut[i] = 0.665423;
            ++i; UMicronOut[i] = 0.664917;
            ++i; UMicronOut[i] = 0.664411;
            ++i; UMicronOut[i] = 0.663905;
            ++i; UMicronOut[i] = 0.663399;
            ++i; UMicronOut[i] = 0.662893;
            ++i; UMicronOut[i] = 0.662387;
            ++i; UMicronOut[i] = 0.661881;
            ++i; UMicronOut[i] = 0.661375;
            ++i; UMicronOut[i] = 0.660869;
            ++i; UMicronOut[i] = 0.660363;
            ++i; UMicronOut[i] = 0.659857;
            ++i; UMicronOut[i] = 0.659351;
            ++i; UMicronOut[i] = 0.658845;
            ++i; UMicronOut[i] = 0.658339;
            ++i; UMicronOut[i] = 0.657833;
            ++i; UMicronOut[i] = 0.657327;
            ++i; UMicronOut[i] = 0.656821;
            ++i; UMicronOut[i] = 0.656315;
            ++i; UMicronOut[i] = 0.655809;
            ++i; UMicronOut[i] = 0.655303;
            ++i; UMicronOut[i] = 0.654797;
            ++i; UMicronOut[i] = 0.654291;
            ++i; UMicronOut[i] = 0.653785;
            ++i; UMicronOut[i] = 0.653279;
            ++i; UMicronOut[i] = 0.652773;
            ++i; UMicronOut[i] = 0.652267;
            ++i; UMicronOut[i] = 0.651761;
            ++i; UMicronOut[i] = 0.651255;
            ++i; UMicronOut[i] = 0.650746;
            ++i; UMicronOut[i] = 0.650243;
            ++i; UMicronOut[i] = 0.649737;
            ++i; UMicronOut[i] = 0.649231;
            ++i; UMicronOut[i] = 0.648725;
            ++i; UMicronOut[i] = 0.648219;
            ++i; UMicronOut[i] = 0.647713;
            ++i; UMicronOut[i] = 0.647207;
            ++i; UMicronOut[i] = 0.646701;
            ++i; UMicronOut[i] = 0.646195;
            ++i; UMicronOut[i] = 0.645689;
            ++i; UMicronOut[i] = 0.645183;
            ++i; UMicronOut[i] = 0.644677;
            ++i; UMicronOut[i] = 0.644171;
            ++i; UMicronOut[i] = 0.643665;
            ++i; UMicronOut[i] = 0.643156;
            ++i; UMicronOut[i] = 0.642653;
            ++i; UMicronOut[i] = 0.642147;
            ++i; UMicronOut[i] = 0.641641;
            ++i; UMicronOut[i] = 0.641135;
            ++i; UMicronOut[i] = 0.640624;
            ++i; UMicronOut[i] = 0.640123;
            ++i; UMicronOut[i] = 0.639617;
            ++i; UMicronOut[i] = 0.639111;
            ++i; UMicronOut[i] = 0.638605;
            ++i; UMicronOut[i] = 0.638094;
            ++i; UMicronOut[i] = 0.637593;
            ++i; UMicronOut[i] = 0.637087;
            ++i; UMicronOut[i] = 0.636581;
            ++i; UMicronOut[i] = 0.636075;
            ++i; UMicronOut[i] = 0.635564;
            ++i; UMicronOut[i] = 0.635063;
            ++i; UMicronOut[i] = 0.634557;
            ++i; UMicronOut[i] = 0.634051;
            ++i; UMicronOut[i] = 0.633545;
            ++i; UMicronOut[i] = 0.633034;
            ++i; UMicronOut[i] = 0.632533;
            ++i; UMicronOut[i] = 0.632027;
            ++i; UMicronOut[i] = 0.631521;
            ++i; UMicronOut[i] = 0.631015;
            ++i; UMicronOut[i] = 0.630504;
            ++i; UMicronOut[i] = 0.630003;
            ++i; UMicronOut[i] = 0.629497;
            ++i; UMicronOut[i] = 0.628991;
            ++i; UMicronOut[i] = 0.628485;
            ++i; UMicronOut[i] = 0.627974;
            ++i; UMicronOut[i] = 0.627473;
            ++i; UMicronOut[i] = 0.626967;
            ++i; UMicronOut[i] = 0.626461;
            ++i; UMicronOut[i] = 0.625955;
            ++i; UMicronOut[i] = 0.625444;
            ++i; UMicronOut[i] = 0.624943;
            ++i; UMicronOut[i] = 0.624437;
            ++i; UMicronOut[i] = 0.623931;
            ++i; UMicronOut[i] = 0.623425;
            ++i; UMicronOut[i] = 0.622914;
            ++i; UMicronOut[i] = 0.622413;
            ++i; UMicronOut[i] = 0.621907;
            ++i; UMicronOut[i] = 0.621401;
            ++i; UMicronOut[i] = 0.620895;
            ++i; UMicronOut[i] = 0.620384;
            ++i; UMicronOut[i] = 0.619883;
            ++i; UMicronOut[i] = 0.619377;
            ++i; UMicronOut[i] = 0.618871;
            ++i; UMicronOut[i] = 0.618365;
            ++i; UMicronOut[i] = 0.617854;
            ++i; UMicronOut[i] = 0.617353;
            ++i; UMicronOut[i] = 0.616847;
            ++i; UMicronOut[i] = 0.616341;
            ++i; UMicronOut[i] = 0.615835;
            ++i; UMicronOut[i] = 0.615324;
            ++i; UMicronOut[i] = 0.614823;
            ++i; UMicronOut[i] = 0.614317;
            ++i; UMicronOut[i] = 0.613811;
            ++i; UMicronOut[i] = 0.613305;
            ++i; UMicronOut[i] = 0.612794;
            ++i; UMicronOut[i] = 0.612293;
            ++i; UMicronOut[i] = 0.611787;
            ++i; UMicronOut[i] = 0.611281;
            ++i; UMicronOut[i] = 0.610775;
            ++i; UMicronOut[i] = 0.610264;
            ++i; UMicronOut[i] = 0.609763;
            ++i; UMicronOut[i] = 0.609257;
            ++i; UMicronOut[i] = 0.608751;
            ++i; UMicronOut[i] = 0.608245;
            ++i; UMicronOut[i] = 0.607734;
            ++i; UMicronOut[i] = 0.607233;
            ++i; UMicronOut[i] = 0.606727;
            ++i; UMicronOut[i] = 0.606221;
            ++i; UMicronOut[i] = 0.605715;
            ++i; UMicronOut[i] = 0.6052049;
            ++i; UMicronOut[i] = 0.604703;
            ++i; UMicronOut[i] = 0.604197;
            ++i; UMicronOut[i] = 0.603691;
            ++i; UMicronOut[i] = 0.603185;
            ++i; UMicronOut[i] = 0.6026749;
            ++i; UMicronOut[i] = 0.602173;
            ++i; UMicronOut[i] = 0.601667;
            ++i; UMicronOut[i] = 0.601161;
            ++i; UMicronOut[i] = 0.600655;
            ++i; UMicronOut[i] = 0.6001449;
            ++i; UMicronOut[i] = 0.599643;
            ++i; UMicronOut[i] = 0.599137;
            ++i; UMicronOut[i] = 0.598631;
            ++i; UMicronOut[i] = 0.598125;
            ++i; UMicronOut[i] = 0.5976149;
            ++i; UMicronOut[i] = 0.597113;
            ++i; UMicronOut[i] = 0.596607;
            ++i; UMicronOut[i] = 0.596101;
            ++i; UMicronOut[i] = 0.595595;
            ++i; UMicronOut[i] = 0.5950849;
            ++i; UMicronOut[i] = 0.594583;
            ++i; UMicronOut[i] = 0.594077;
            ++i; UMicronOut[i] = 0.593571;
            ++i; UMicronOut[i] = 0.593065;
            ++i; UMicronOut[i] = 0.5925549;
            ++i; UMicronOut[i] = 0.592053;
            ++i; UMicronOut[i] = 0.591547;
            ++i; UMicronOut[i] = 0.591041;
            ++i; UMicronOut[i] = 0.590535;
            ++i; UMicronOut[i] = 0.5900249;
            ++i; UMicronOut[i] = 0.589523;
            ++i; UMicronOut[i] = 0.589017;
            ++i; UMicronOut[i] = 0.588511;
            ++i; UMicronOut[i] = 0.588005;
            ++i; UMicronOut[i] = 0.5874949;
            ++i; UMicronOut[i] = 0.586993;
            ++i; UMicronOut[i] = 0.586487;
            ++i; UMicronOut[i] = 0.585981;
            ++i; UMicronOut[i] = 0.585475;
            ++i; UMicronOut[i] = 0.5849649;
            ++i; UMicronOut[i] = 0.584463;
            ++i; UMicronOut[i] = 0.583957;
            ++i; UMicronOut[i] = 0.583451;
            ++i; UMicronOut[i] = 0.582945;
            ++i; UMicronOut[i] = 0.5824349;
            ++i; UMicronOut[i] = 0.581933;
            ++i; UMicronOut[i] = 0.581427;
            ++i; UMicronOut[i] = 0.580921;
            ++i; UMicronOut[i] = 0.580415;
            ++i; UMicronOut[i] = 0.5799049;
            ++i; UMicronOut[i] = 0.579403;
            ++i; UMicronOut[i] = 0.578897;
            ++i; UMicronOut[i] = 0.578391;
            ++i; UMicronOut[i] = 0.577885;
            ++i; UMicronOut[i] = 0.5773744;
            ++i; UMicronOut[i] = 0.576873;
            ++i; UMicronOut[i] = 0.576367;
            ++i; UMicronOut[i] = 0.575861;
            ++i; UMicronOut[i] = 0.575355;
            ++i; UMicronOut[i] = 0.5748444;
            ++i; UMicronOut[i] = 0.574343;
            ++i; UMicronOut[i] = 0.573837;
            ++i; UMicronOut[i] = 0.573331;
            ++i; UMicronOut[i] = 0.572825;
            ++i; UMicronOut[i] = 0.5723144;
            ++i; UMicronOut[i] = 0.571813;
            ++i; UMicronOut[i] = 0.571307;
            ++i; UMicronOut[i] = 0.570801;
            ++i; UMicronOut[i] = 0.570295;
            ++i; UMicronOut[i] = 0.5697844;
            ++i; UMicronOut[i] = 0.569283;
            ++i; UMicronOut[i] = 0.568777;
            ++i; UMicronOut[i] = 0.568271;
            ++i; UMicronOut[i] = 0.567765;
            ++i; UMicronOut[i] = 0.5672544;
            ++i; UMicronOut[i] = 0.566753;
            ++i; UMicronOut[i] = 0.566247;
            ++i; UMicronOut[i] = 0.565741;
            ++i; UMicronOut[i] = 0.565235;
            ++i; UMicronOut[i] = 0.5647244;
            ++i; UMicronOut[i] = 0.564223;
            ++i; UMicronOut[i] = 0.563717;
            ++i; UMicronOut[i] = 0.563211;
            ++i; UMicronOut[i] = 0.562705;
            ++i; UMicronOut[i] = 0.5621944;
            ++i; UMicronOut[i] = 0.561693;
            ++i; UMicronOut[i] = 0.561187;
            ++i; UMicronOut[i] = 0.560681;
            ++i; UMicronOut[i] = 0.560175;
            ++i; UMicronOut[i] = 0.5596644;
            ++i; UMicronOut[i] = 0.559163;
            ++i; UMicronOut[i] = 0.558657;
            ++i; UMicronOut[i] = 0.558151;
            ++i; UMicronOut[i] = 0.557645;
            ++i; UMicronOut[i] = 0.5571344;
            ++i; UMicronOut[i] = 0.556633;
            ++i; UMicronOut[i] = 0.556127;
            ++i; UMicronOut[i] = 0.555621;
            ++i; UMicronOut[i] = 0.555115;
            ++i; UMicronOut[i] = 0.5546044;
            ++i; UMicronOut[i] = 0.554103;
            ++i; UMicronOut[i] = 0.553597;
            ++i; UMicronOut[i] = 0.553091;
            ++i; UMicronOut[i] = 0.552585;
            ++i; UMicronOut[i] = 0.5520744;
            ++i; UMicronOut[i] = 0.551573;
            ++i; UMicronOut[i] = 0.551067;
            ++i; UMicronOut[i] = 0.550561;
            ++i; UMicronOut[i] = 0.550055;
            ++i; UMicronOut[i] = 0.5495444;
            ++i; UMicronOut[i] = 0.549043;
            ++i; UMicronOut[i] = 0.548537;
            ++i; UMicronOut[i] = 0.548031;
            ++i; UMicronOut[i] = 0.547525;
            ++i; UMicronOut[i] = 0.5470144;
            ++i; UMicronOut[i] = 0.546513;
            ++i; UMicronOut[i] = 0.546007;
            ++i; UMicronOut[i] = 0.545501;
            ++i; UMicronOut[i] = 0.544995;
            ++i; UMicronOut[i] = 0.5444844;
            ++i; UMicronOut[i] = 0.543983;
            ++i; UMicronOut[i] = 0.543477;
            ++i; UMicronOut[i] = 0.542971;
            ++i; UMicronOut[i] = 0.542465;
            ++i; UMicronOut[i] = 0.5419539;
            ++i; UMicronOut[i] = 0.541453;
            ++i; UMicronOut[i] = 0.540947;
            ++i; UMicronOut[i] = 0.540441;
            ++i; UMicronOut[i] = 0.539935;
            ++i; UMicronOut[i] = 0.5394239;
            ++i; UMicronOut[i] = 0.538923;
            ++i; UMicronOut[i] = 0.538417;
            ++i; UMicronOut[i] = 0.537911;
            ++i; UMicronOut[i] = 0.537405;
            ++i; UMicronOut[i] = 0.5368939;
            ++i; UMicronOut[i] = 0.536393;
            ++i; UMicronOut[i] = 0.535887;
            ++i; UMicronOut[i] = 0.535381;
            ++i; UMicronOut[i] = 0.534875;
            ++i; UMicronOut[i] = 0.5343639;
            ++i; UMicronOut[i] = 0.533863;
            ++i; UMicronOut[i] = 0.533357;
            ++i; UMicronOut[i] = 0.532851;
            ++i; UMicronOut[i] = 0.532345;
            ++i; UMicronOut[i] = 0.5318339;
            ++i; UMicronOut[i] = 0.531333;
            ++i; UMicronOut[i] = 0.530827;
            ++i; UMicronOut[i] = 0.530321;
            ++i; UMicronOut[i] = 0.529815;
            ++i; UMicronOut[i] = 0.5293039;
            ++i; UMicronOut[i] = 0.528803;
            ++i; UMicronOut[i] = 0.528297;
            ++i; UMicronOut[i] = 0.527791;
            ++i; UMicronOut[i] = 0.527285;
            ++i; UMicronOut[i] = 0.5267739;
            ++i; UMicronOut[i] = 0.526273;
            ++i; UMicronOut[i] = 0.525767;
            ++i; UMicronOut[i] = 0.525261;
            ++i; UMicronOut[i] = 0.524755;
            ++i; UMicronOut[i] = 0.5242439;
            ++i; UMicronOut[i] = 0.523743;
            ++i; UMicronOut[i] = 0.523237;
            ++i; UMicronOut[i] = 0.522731;
            ++i; UMicronOut[i] = 0.522225;
            ++i; UMicronOut[i] = 0.5217139;
            ++i; UMicronOut[i] = 0.521213;
            ++i; UMicronOut[i] = 0.520707;
            ++i; UMicronOut[i] = 0.520201;
            ++i; UMicronOut[i] = 0.519695;
            ++i; UMicronOut[i] = 0.5191839;
            ++i; UMicronOut[i] = 0.518683;
            ++i; UMicronOut[i] = 0.518177;
            ++i; UMicronOut[i] = 0.517671;
            ++i; UMicronOut[i] = 0.517165;
            ++i; UMicronOut[i] = 0.5166539;
            ++i; UMicronOut[i] = 0.516153;
            ++i; UMicronOut[i] = 0.515647;
            ++i; UMicronOut[i] = 0.515141;
            ++i; UMicronOut[i] = 0.514635;
            ++i; UMicronOut[i] = 0.5141239;
            ++i; UMicronOut[i] = 0.513623;
            ++i; UMicronOut[i] = 0.513117;
            ++i; UMicronOut[i] = 0.512611;
            ++i; UMicronOut[i] = 0.512105;
            ++i; UMicronOut[i] = 0.5115934;
            ++i; UMicronOut[i] = 0.511093;
            ++i; UMicronOut[i] = 0.510587;
            ++i; UMicronOut[i] = 0.510081;
            ++i; UMicronOut[i] = 0.509575;
            ++i; UMicronOut[i] = 0.5090634;
            ++i; UMicronOut[i] = 0.508563;
            ++i; UMicronOut[i] = 0.508057;
            ++i; UMicronOut[i] = 0.507551;
            ++i; UMicronOut[i] = 0.507045;
            ++i; UMicronOut[i] = 0.5065334;
            ++i; UMicronOut[i] = 0.506033;
            ++i; UMicronOut[i] = 0.505527;
            ++i; UMicronOut[i] = 0.505021;
            ++i; UMicronOut[i] = 0.504515;
            ++i; UMicronOut[i] = 0.5040034;
            ++i; UMicronOut[i] = 0.503503;
            ++i; UMicronOut[i] = 0.502997;
            ++i; UMicronOut[i] = 0.502491;
            ++i; UMicronOut[i] = 0.501985;
            ++i; UMicronOut[i] = 0.5014734;
            ++i; UMicronOut[i] = 0.500973;
            ++i; UMicronOut[i] = 0.500467;
            ++i; UMicronOut[i] = 0.499961;
            ++i; UMicronOut[i] = 0.499455;
            ++i; UMicronOut[i] = 0.4989434;
            ++i; UMicronOut[i] = 0.498443;
            ++i; UMicronOut[i] = 0.497937;
            ++i; UMicronOut[i] = 0.497431;
            ++i; UMicronOut[i] = 0.496925;
            ++i; UMicronOut[i] = 0.4964134;
            ++i; UMicronOut[i] = 0.495913;
            ++i; UMicronOut[i] = 0.495407;
            ++i; UMicronOut[i] = 0.494901;
            ++i; UMicronOut[i] = 0.494395;
            ++i; UMicronOut[i] = 0.4938834;
            ++i; UMicronOut[i] = 0.493383;
            ++i; UMicronOut[i] = 0.492877;
            ++i; UMicronOut[i] = 0.492371;
            ++i; UMicronOut[i] = 0.491865;
            ++i; UMicronOut[i] = 0.4913534;
            ++i; UMicronOut[i] = 0.490853;
            ++i; UMicronOut[i] = 0.490347;
            ++i; UMicronOut[i] = 0.489841;
            ++i; UMicronOut[i] = 0.489335;
            ++i; UMicronOut[i] = 0.4888234;
            ++i; UMicronOut[i] = 0.488323;
            ++i; UMicronOut[i] = 0.487817;
            ++i; UMicronOut[i] = 0.487311;
            ++i; UMicronOut[i] = 0.486805;
            ++i; UMicronOut[i] = 0.4862934;
            ++i; UMicronOut[i] = 0.485793;
            ++i; UMicronOut[i] = 0.485287;
            ++i; UMicronOut[i] = 0.484781;
            ++i; UMicronOut[i] = 0.484275;
            ++i; UMicronOut[i] = 0.4837634;
            ++i; UMicronOut[i] = 0.483263;
            ++i; UMicronOut[i] = 0.482757;
            ++i; UMicronOut[i] = 0.482251;
            ++i; UMicronOut[i] = 0.481745;
            ++i; UMicronOut[i] = 0.4812334;
            ++i; UMicronOut[i] = 0.480733;
            ++i; UMicronOut[i] = 0.480227;
            ++i; UMicronOut[i] = 0.479721;
            ++i; UMicronOut[i] = 0.479215;
            ++i; UMicronOut[i] = 0.4787029;
            ++i; UMicronOut[i] = 0.478203;
            ++i; UMicronOut[i] = 0.477697;
            ++i; UMicronOut[i] = 0.477191;
            ++i; UMicronOut[i] = 0.476685;
            ++i; UMicronOut[i] = 0.4761729;
            ++i; UMicronOut[i] = 0.475673;
            ++i; UMicronOut[i] = 0.475167;
            ++i; UMicronOut[i] = 0.474661;
            ++i; UMicronOut[i] = 0.474155;
            ++i; UMicronOut[i] = 0.4736429;
            ++i; UMicronOut[i] = 0.473143;
            ++i; UMicronOut[i] = 0.472637;
            ++i; UMicronOut[i] = 0.472131;
            ++i; UMicronOut[i] = 0.471625;
            ++i; UMicronOut[i] = 0.4711129;
            ++i; UMicronOut[i] = 0.470613;
            ++i; UMicronOut[i] = 0.470107;
            ++i; UMicronOut[i] = 0.469601;
            ++i; UMicronOut[i] = 0.469095;
            ++i; UMicronOut[i] = 0.4685829;
            ++i; UMicronOut[i] = 0.468083;
            ++i; UMicronOut[i] = 0.467577;
            ++i; UMicronOut[i] = 0.467071;
            ++i; UMicronOut[i] = 0.466565;
            ++i; UMicronOut[i] = 0.4660529;
            ++i; UMicronOut[i] = 0.465553;
            ++i; UMicronOut[i] = 0.465047;
            ++i; UMicronOut[i] = 0.464541;
            ++i; UMicronOut[i] = 0.464035;
            ++i; UMicronOut[i] = 0.4635229;
            ++i; UMicronOut[i] = 0.463023;
            ++i; UMicronOut[i] = 0.462517;
            ++i; UMicronOut[i] = 0.462011;
            ++i; UMicronOut[i] = 0.461505;
            ++i; UMicronOut[i] = 0.4609929;
            ++i; UMicronOut[i] = 0.460493;
            ++i; UMicronOut[i] = 0.459987;
            ++i; UMicronOut[i] = 0.459481;
            ++i; UMicronOut[i] = 0.458975;
            ++i; UMicronOut[i] = 0.4584629;
            ++i; UMicronOut[i] = 0.457963;
            ++i; UMicronOut[i] = 0.457457;
            ++i; UMicronOut[i] = 0.456951;
            ++i; UMicronOut[i] = 0.456445;
            ++i; UMicronOut[i] = 0.4559329;
            ++i; UMicronOut[i] = 0.455433;
            ++i; UMicronOut[i] = 0.454927;
            ++i; UMicronOut[i] = 0.454421;
            ++i; UMicronOut[i] = 0.453915;
            ++i; UMicronOut[i] = 0.4534029;
            ++i; UMicronOut[i] = 0.452903;
            ++i; UMicronOut[i] = 0.452397;
            ++i; UMicronOut[i] = 0.451891;
            ++i; UMicronOut[i] = 0.451385;
            ++i; UMicronOut[i] = 0.4508729;
            ++i; UMicronOut[i] = 0.450373;
            ++i; UMicronOut[i] = 0.449867;
            ++i; UMicronOut[i] = 0.449361;
            ++i; UMicronOut[i] = 0.448855;
            ++i; UMicronOut[i] = 0.4483429;
            ++i; UMicronOut[i] = 0.447843;
            ++i; UMicronOut[i] = 0.447337;
            ++i; UMicronOut[i] = 0.446831;
            ++i; UMicronOut[i] = 0.446325;
            ++i; UMicronOut[i] = 0.4458124;
            ++i; UMicronOut[i] = 0.445313;
            ++i; UMicronOut[i] = 0.444807;
            ++i; UMicronOut[i] = 0.444301;
            ++i; UMicronOut[i] = 0.443795;
            ++i; UMicronOut[i] = 0.4432824;
            ++i; UMicronOut[i] = 0.442783;
            ++i; UMicronOut[i] = 0.442277;
            ++i; UMicronOut[i] = 0.441771;
            ++i; UMicronOut[i] = 0.441265;
            ++i; UMicronOut[i] = 0.4407524;
            ++i; UMicronOut[i] = 0.440253;
            ++i; UMicronOut[i] = 0.439747;
            ++i; UMicronOut[i] = 0.439241;
            ++i; UMicronOut[i] = 0.438735;
            ++i; UMicronOut[i] = 0.4382224;
            ++i; UMicronOut[i] = 0.437723;
            ++i; UMicronOut[i] = 0.437217;
            ++i; UMicronOut[i] = 0.436711;
            ++i; UMicronOut[i] = 0.436205;
            ++i; UMicronOut[i] = 0.4356924;
            ++i; UMicronOut[i] = 0.435193;
            ++i; UMicronOut[i] = 0.434687;
            ++i; UMicronOut[i] = 0.434181;
            ++i; UMicronOut[i] = 0.433675;
            ++i; UMicronOut[i] = 0.4331624;
            ++i; UMicronOut[i] = 0.432663;
            ++i; UMicronOut[i] = 0.432157;
            ++i; UMicronOut[i] = 0.431651;
            ++i; UMicronOut[i] = 0.431145;
            ++i; UMicronOut[i] = 0.4306324;
            ++i; UMicronOut[i] = 0.430133;
            ++i; UMicronOut[i] = 0.429627;
            ++i; UMicronOut[i] = 0.429121;
            ++i; UMicronOut[i] = 0.428615;
            ++i; UMicronOut[i] = 0.4281024;
            ++i; UMicronOut[i] = 0.427603;
            ++i; UMicronOut[i] = 0.427097;
            ++i; UMicronOut[i] = 0.426591;
            ++i; UMicronOut[i] = 0.426085;
            ++i; UMicronOut[i] = 0.4255724;
            ++i; UMicronOut[i] = 0.425073;
            ++i; UMicronOut[i] = 0.424567;
            ++i; UMicronOut[i] = 0.424061;
            ++i; UMicronOut[i] = 0.423555;
            ++i; UMicronOut[i] = 0.4230424;
            ++i; UMicronOut[i] = 0.422543;
            ++i; UMicronOut[i] = 0.422037;
            ++i; UMicronOut[i] = 0.421531;
            ++i; UMicronOut[i] = 0.421025;
            ++i; UMicronOut[i] = 0.4205124;
            ++i; UMicronOut[i] = 0.420013;
            ++i; UMicronOut[i] = 0.419507;
            ++i; UMicronOut[i] = 0.419001;
            ++i; UMicronOut[i] = 0.418495;
            ++i; UMicronOut[i] = 0.4179824;
            ++i; UMicronOut[i] = 0.417483;
            ++i; UMicronOut[i] = 0.416977;
            ++i; UMicronOut[i] = 0.416471;
            ++i; UMicronOut[i] = 0.415965;
            ++i; UMicronOut[i] = 0.4154524;
            ++i; UMicronOut[i] = 0.414953;
            ++i; UMicronOut[i] = 0.414447;
            ++i; UMicronOut[i] = 0.413941;
            ++i; UMicronOut[i] = 0.413435;
            ++i; UMicronOut[i] = 0.4129219;
            ++i; UMicronOut[i] = 0.412423;
            ++i; UMicronOut[i] = 0.411917;
            ++i; UMicronOut[i] = 0.411411;
            ++i; UMicronOut[i] = 0.410905;
            ++i; UMicronOut[i] = 0.4103919;
            ++i; UMicronOut[i] = 0.409893;
            ++i; UMicronOut[i] = 0.409387;
            ++i; UMicronOut[i] = 0.408881;
            ++i; UMicronOut[i] = 0.408375;
            ++i; UMicronOut[i] = 0.4078619;
            ++i; UMicronOut[i] = 0.407363;
            ++i; UMicronOut[i] = 0.406857;
            ++i; UMicronOut[i] = 0.406351;
            ++i; UMicronOut[i] = 0.405845;
            ++i; UMicronOut[i] = 0.4053319;
            ++i; UMicronOut[i] = 0.404833;
            ++i; UMicronOut[i] = 0.404327;
            ++i; UMicronOut[i] = 0.403821;
            ++i; UMicronOut[i] = 0.403315;
            ++i; UMicronOut[i] = 0.4028019;
            ++i; UMicronOut[i] = 0.402303;
            ++i; UMicronOut[i] = 0.401797;
            ++i; UMicronOut[i] = 0.401291;
            ++i; UMicronOut[i] = 0.400785;
            ++i; UMicronOut[i] = 0.4002719;
            ++i; UMicronOut[i] = 0.399773;
            ++i; UMicronOut[i] = 0.399267;
            ++i; UMicronOut[i] = 0.398761;
            ++i; UMicronOut[i] = 0.398255;
            ++i; UMicronOut[i] = 0.3977419;
            ++i; UMicronOut[i] = 0.397243;
            ++i; UMicronOut[i] = 0.396737;
            ++i; UMicronOut[i] = 0.396231;
            ++i; UMicronOut[i] = 0.395725;
            ++i; UMicronOut[i] = 0.3952119;
            ++i; UMicronOut[i] = 0.394713;
            ++i; UMicronOut[i] = 0.394207;
            ++i; UMicronOut[i] = 0.393701;
            ++i; UMicronOut[i] = 0.393195;
            ++i; UMicronOut[i] = 0.3926819;
            ++i; UMicronOut[i] = 0.392183;
            ++i; UMicronOut[i] = 0.391677;
            ++i; UMicronOut[i] = 0.391171;
            ++i; UMicronOut[i] = 0.390665;
            ++i; UMicronOut[i] = 0.3901519;
            ++i; UMicronOut[i] = 0.389653;
            ++i; UMicronOut[i] = 0.389147;
            ++i; UMicronOut[i] = 0.388641;
            ++i; UMicronOut[i] = 0.388135;
            ++i; UMicronOut[i] = 0.3876219;
            ++i; UMicronOut[i] = 0.387123;
            ++i; UMicronOut[i] = 0.386617;
            ++i; UMicronOut[i] = 0.386111;
            ++i; UMicronOut[i] = 0.385605;
            ++i; UMicronOut[i] = 0.3850919;
            ++i; UMicronOut[i] = 0.384593;
            ++i; UMicronOut[i] = 0.384087;
            ++i; UMicronOut[i] = 0.383581;
            ++i; UMicronOut[i] = 0.383075;
            ++i; UMicronOut[i] = 0.3825619;
            ++i; UMicronOut[i] = 0.382063;
            ++i; UMicronOut[i] = 0.381557;
            ++i; UMicronOut[i] = 0.381051;
            ++i; UMicronOut[i] = 0.380545;
            ++i; UMicronOut[i] = 0.3800314;
            ++i; UMicronOut[i] = 0.379533;
            ++i; UMicronOut[i] = 0.379027;
            ++i; UMicronOut[i] = 0.378521;
            ++i; UMicronOut[i] = 0.378015;
            ++i; UMicronOut[i] = 0.3775014;
            ++i; UMicronOut[i] = 0.377003;
            ++i; UMicronOut[i] = 0.376497;
            ++i; UMicronOut[i] = 0.375991;
            ++i; UMicronOut[i] = 0.375485;
            ++i; UMicronOut[i] = 0.3749714;
            ++i; UMicronOut[i] = 0.374473;
            ++i; UMicronOut[i] = 0.373967;
            ++i; UMicronOut[i] = 0.373461;
            ++i; UMicronOut[i] = 0.372955;
            ++i; UMicronOut[i] = 0.3724414;
            ++i; UMicronOut[i] = 0.371943;
            ++i; UMicronOut[i] = 0.371437;
            ++i; UMicronOut[i] = 0.370931;
            ++i; UMicronOut[i] = 0.370425;
            ++i; UMicronOut[i] = 0.3699114;
            ++i; UMicronOut[i] = 0.369413;
            ++i; UMicronOut[i] = 0.368907;
            ++i; UMicronOut[i] = 0.368401;
            ++i; UMicronOut[i] = 0.367895;
            ++i; UMicronOut[i] = 0.3673814;
            ++i; UMicronOut[i] = 0.366883;
            ++i; UMicronOut[i] = 0.366377;
            ++i; UMicronOut[i] = 0.365871;
            ++i; UMicronOut[i] = 0.365365;
            ++i; UMicronOut[i] = 0.3648514;
            ++i; UMicronOut[i] = 0.364353;
            ++i; UMicronOut[i] = 0.363847;
            ++i; UMicronOut[i] = 0.363341;
            ++i; UMicronOut[i] = 0.362835;
            ++i; UMicronOut[i] = 0.3623214;
            ++i; UMicronOut[i] = 0.361823;
            ++i; UMicronOut[i] = 0.361317;
            ++i; UMicronOut[i] = 0.360811;
            ++i; UMicronOut[i] = 0.360305;
            ++i; UMicronOut[i] = 0.3597914;
            ++i; UMicronOut[i] = 0.359293;
            ++i; UMicronOut[i] = 0.358787;
            ++i; UMicronOut[i] = 0.358281;
            ++i; UMicronOut[i] = 0.357775;
            ++i; UMicronOut[i] = 0.3572614;
            ++i; UMicronOut[i] = 0.356763;
            ++i; UMicronOut[i] = 0.356257;
            ++i; UMicronOut[i] = 0.355751;
            ++i; UMicronOut[i] = 0.355245;
            ++i; UMicronOut[i] = 0.3547314;
            ++i; UMicronOut[i] = 0.354233;
            ++i; UMicronOut[i] = 0.353727;
            ++i; UMicronOut[i] = 0.353221;
            ++i; UMicronOut[i] = 0.352715;
            ++i; UMicronOut[i] = 0.3522014;
            ++i; UMicronOut[i] = 0.351703;
            ++i; UMicronOut[i] = 0.351197;
            ++i; UMicronOut[i] = 0.350691;
            ++i; UMicronOut[i] = 0.350185;
            ++i; UMicronOut[i] = 0.3496709;
            ++i; UMicronOut[i] = 0.349173;
            ++i; UMicronOut[i] = 0.348667;
            ++i; UMicronOut[i] = 0.348161;
            ++i; UMicronOut[i] = 0.347655;
            ++i; UMicronOut[i] = 0.3471409;
            ++i; UMicronOut[i] = 0.346643;
            ++i; UMicronOut[i] = 0.346137;
            ++i; UMicronOut[i] = 0.345631;
            ++i; UMicronOut[i] = 0.345125;
            ++i; UMicronOut[i] = 0.3446109;
            ++i; UMicronOut[i] = 0.344113;
            ++i; UMicronOut[i] = 0.343607;
            ++i; UMicronOut[i] = 0.343101;
            ++i; UMicronOut[i] = 0.342595;
            ++i; UMicronOut[i] = 0.3420809;
            ++i; UMicronOut[i] = 0.341583;
            ++i; UMicronOut[i] = 0.341077;
            ++i; UMicronOut[i] = 0.340571;
            ++i; UMicronOut[i] = 0.340065;
            ++i; UMicronOut[i] = 0.3395509;
            ++i; UMicronOut[i] = 0.339053;
            ++i; UMicronOut[i] = 0.338547;
            ++i; UMicronOut[i] = 0.338041;
            ++i; UMicronOut[i] = 0.337535;
            ++i; UMicronOut[i] = 0.3370209;
            ++i; UMicronOut[i] = 0.336523;
            ++i; UMicronOut[i] = 0.336017;
            ++i; UMicronOut[i] = 0.335511;
            ++i; UMicronOut[i] = 0.335005;
            ++i; UMicronOut[i] = 0.3344909;
            ++i; UMicronOut[i] = 0.333993;
            ++i; UMicronOut[i] = 0.333487;
            ++i; UMicronOut[i] = 0.332981;
            ++i; UMicronOut[i] = 0.332475;
            ++i; UMicronOut[i] = 0.3319609;
            ++i; UMicronOut[i] = 0.331463;
            ++i; UMicronOut[i] = 0.330957;
            ++i; UMicronOut[i] = 0.330451;
            ++i; UMicronOut[i] = 0.329945;
            ++i; UMicronOut[i] = 0.3294309;
            ++i; UMicronOut[i] = 0.328933;
            ++i; UMicronOut[i] = 0.328427;
            ++i; UMicronOut[i] = 0.327921;
            ++i; UMicronOut[i] = 0.327415;
            ++i; UMicronOut[i] = 0.3269009;
            ++i; UMicronOut[i] = 0.326403;
            ++i; UMicronOut[i] = 0.325897;
            ++i; UMicronOut[i] = 0.325391;
            ++i; UMicronOut[i] = 0.324885;
            ++i; UMicronOut[i] = 0.3243709;
            ++i; UMicronOut[i] = 0.323873;
            ++i; UMicronOut[i] = 0.323367;
            ++i; UMicronOut[i] = 0.322861;
            ++i; UMicronOut[i] = 0.322355;
            ++i; UMicronOut[i] = 0.3218409;
            ++i; UMicronOut[i] = 0.321343;
            ++i; UMicronOut[i] = 0.320837;
            ++i; UMicronOut[i] = 0.320331;
            ++i; UMicronOut[i] = 0.319825;
            ++i; UMicronOut[i] = 0.3193109;
            ++i; UMicronOut[i] = 0.318813;
            ++i; UMicronOut[i] = 0.318307;
            ++i; UMicronOut[i] = 0.317801;
            ++i; UMicronOut[i] = 0.317295;
            ++i; UMicronOut[i] = 0.3167804;
            ++i; UMicronOut[i] = 0.316283;
            ++i; UMicronOut[i] = 0.315777;
            ++i; UMicronOut[i] = 0.315271;
            ++i; UMicronOut[i] = 0.314765;
            ++i; UMicronOut[i] = 0.3142504;
            ++i; UMicronOut[i] = 0.313753;
            ++i; UMicronOut[i] = 0.313247;
            ++i; UMicronOut[i] = 0.312741;
            ++i; UMicronOut[i] = 0.312235;
            ++i; UMicronOut[i] = 0.3117204;
            ++i; UMicronOut[i] = 0.311223;
            ++i; UMicronOut[i] = 0.310717;
            ++i; UMicronOut[i] = 0.310211;
            ++i; UMicronOut[i] = 0.309705;
            ++i; UMicronOut[i] = 0.3091904;
            ++i; UMicronOut[i] = 0.308693;
            ++i; UMicronOut[i] = 0.308187;
            ++i; UMicronOut[i] = 0.307681;
            ++i; UMicronOut[i] = 0.307175;
            ++i; UMicronOut[i] = 0.3066604;
            ++i; UMicronOut[i] = 0.306163;
            ++i; UMicronOut[i] = 0.305657;
            ++i; UMicronOut[i] = 0.305151;
            ++i; UMicronOut[i] = 0.304645;
            ++i; UMicronOut[i] = 0.3041304;
            ++i; UMicronOut[i] = 0.303633;
            ++i; UMicronOut[i] = 0.303127;
            ++i; UMicronOut[i] = 0.302621;
            ++i; UMicronOut[i] = 0.302115;
            ++i; UMicronOut[i] = 0.3016004;
            ++i; UMicronOut[i] = 0.301103;
            ++i; UMicronOut[i] = 0.300597;
            ++i; UMicronOut[i] = 0.300091;
            ++i; UMicronOut[i] = 0.299585;
            ++i; UMicronOut[i] = 0.2990704;
            ++i; UMicronOut[i] = 0.298573;
            ++i; UMicronOut[i] = 0.298067;
            ++i; UMicronOut[i] = 0.297561;
            ++i; UMicronOut[i] = 0.297055;
            ++i; UMicronOut[i] = 0.2965404;
            ++i; UMicronOut[i] = 0.296043;
            ++i; UMicronOut[i] = 0.295537;
            ++i; UMicronOut[i] = 0.295031;
            ++i; UMicronOut[i] = 0.294525;
            ++i; UMicronOut[i] = 0.2940104;
            ++i; UMicronOut[i] = 0.293513;
            ++i; UMicronOut[i] = 0.293007;
            ++i; UMicronOut[i] = 0.292501;
            ++i; UMicronOut[i] = 0.291995;
            ++i; UMicronOut[i] = 0.2914804;
            ++i; UMicronOut[i] = 0.290983;
            ++i; UMicronOut[i] = 0.290477;
            ++i; UMicronOut[i] = 0.289971;
            ++i; UMicronOut[i] = 0.289465;
            ++i; UMicronOut[i] = 0.2889504;
            ++i; UMicronOut[i] = 0.288453;
            ++i; UMicronOut[i] = 0.287947;
            ++i; UMicronOut[i] = 0.287441;
            ++i; UMicronOut[i] = 0.286935;
            ++i; UMicronOut[i] = 0.2864204;
            ++i; UMicronOut[i] = 0.285923;
            ++i; UMicronOut[i] = 0.285417;
            ++i; UMicronOut[i] = 0.284911;
            ++i; UMicronOut[i] = 0.284405;
            ++i; UMicronOut[i] = 0.2838899;
            ++i; UMicronOut[i] = 0.283393;
            ++i; UMicronOut[i] = 0.282887;
            ++i; UMicronOut[i] = 0.282381;
            ++i; UMicronOut[i] = 0.281875;
            ++i; UMicronOut[i] = 0.2813699;
            ++i; UMicronOut[i] = 0.280863;
            ++i; UMicronOut[i] = 0.280357;
            ++i; UMicronOut[i] = 0.279851;
            ++i; UMicronOut[i] = 0.279345;
            ++i; UMicronOut[i] = 0.2788399;
            ++i; UMicronOut[i] = 0.278333;
            ++i; UMicronOut[i] = 0.277827;
            ++i; UMicronOut[i] = 0.277321;
            ++i; UMicronOut[i] = 0.276815;
            ++i; UMicronOut[i] = 0.2763099;
            ++i; UMicronOut[i] = 0.275803;
            ++i; UMicronOut[i] = 0.275297;
            ++i; UMicronOut[i] = 0.274791;
            ++i; UMicronOut[i] = 0.274285;
            ++i; UMicronOut[i] = 0.2737799;
            ++i; UMicronOut[i] = 0.273273;
            ++i; UMicronOut[i] = 0.272767;
            ++i; UMicronOut[i] = 0.272261;
            ++i; UMicronOut[i] = 0.271755;
            ++i; UMicronOut[i] = 0.2712499;
            ++i; UMicronOut[i] = 0.270743;
            ++i; UMicronOut[i] = 0.270237;
            ++i; UMicronOut[i] = 0.269731;
            ++i; UMicronOut[i] = 0.269225;
            ++i; UMicronOut[i] = 0.2687199;
            ++i; UMicronOut[i] = 0.268213;
            ++i; UMicronOut[i] = 0.267707;
            ++i; UMicronOut[i] = 0.267201;
            ++i; UMicronOut[i] = 0.266695;
            ++i; UMicronOut[i] = 0.2661899;
            ++i; UMicronOut[i] = 0.265683;
            ++i; UMicronOut[i] = 0.265177;
            ++i; UMicronOut[i] = 0.264671;
            ++i; UMicronOut[i] = 0.264165;
            ++i; UMicronOut[i] = 0.2636599;
            ++i; UMicronOut[i] = 0.263153;
            ++i; UMicronOut[i] = 0.262647;
            ++i; UMicronOut[i] = 0.262141;
            ++i; UMicronOut[i] = 0.261635;
            ++i; UMicronOut[i] = 0.2611299;
            ++i; UMicronOut[i] = 0.260623;
            ++i; UMicronOut[i] = 0.260117;
            ++i; UMicronOut[i] = 0.259611;
            ++i; UMicronOut[i] = 0.259105;
            ++i; UMicronOut[i] = 0.2585899;
            ++i; UMicronOut[i] = 0.258093;
            ++i; UMicronOut[i] = 0.257587;
            ++i; UMicronOut[i] = 0.257081;
            ++i; UMicronOut[i] = 0.256575;
            ++i; UMicronOut[i] = 0.2560699;
            ++i; UMicronOut[i] = 0.255563;
            ++i; UMicronOut[i] = 0.255057;
            ++i; UMicronOut[i] = 0.254551;
            ++i; UMicronOut[i] = 0.254045;
            ++i; UMicronOut[i] = 0.2535399;
            ++i; UMicronOut[i] = 0.253033;
            ++i; UMicronOut[i] = 0.252527;
            ++i; UMicronOut[i] = 0.252021;
            ++i; UMicronOut[i] = 0.251515;
            ++i; UMicronOut[i] = 0.2510094;
            ++i; UMicronOut[i] = 0.250503;
            ++i; UMicronOut[i] = 0.249997;
            ++i; UMicronOut[i] = 0.249491;
            ++i; UMicronOut[i] = 0.248985;
            ++i; UMicronOut[i] = 0.2484794;
            ++i; UMicronOut[i] = 0.247973;
            ++i; UMicronOut[i] = 0.247467;
            ++i; UMicronOut[i] = 0.246961;
            ++i; UMicronOut[i] = 0.246455;
            ++i; UMicronOut[i] = 0.2459494;
            ++i; UMicronOut[i] = 0.245443;
            ++i; UMicronOut[i] = 0.244937;
            ++i; UMicronOut[i] = 0.244431;
            ++i; UMicronOut[i] = 0.243925;
            ++i; UMicronOut[i] = 0.2434194;
            ++i; UMicronOut[i] = 0.242913;
            ++i; UMicronOut[i] = 0.242407;
            ++i; UMicronOut[i] = 0.241901;
            ++i; UMicronOut[i] = 0.241395;
            ++i; UMicronOut[i] = 0.2408894;
            ++i; UMicronOut[i] = 0.240383;
            ++i; UMicronOut[i] = 0.239877;
            ++i; UMicronOut[i] = 0.239371;
            ++i; UMicronOut[i] = 0.238865;
            ++i; UMicronOut[i] = 0.2383594;
            ++i; UMicronOut[i] = 0.237853;
            ++i; UMicronOut[i] = 0.237347;
            ++i; UMicronOut[i] = 0.236841;
            ++i; UMicronOut[i] = 0.236335;
            ++i; UMicronOut[i] = 0.2358294;
            ++i; UMicronOut[i] = 0.235323;
            ++i; UMicronOut[i] = 0.234817;
            ++i; UMicronOut[i] = 0.234311;
            ++i; UMicronOut[i] = 0.233805;
            ++i; UMicronOut[i] = 0.2332894;
            ++i; UMicronOut[i] = 0.232793;
            ++i; UMicronOut[i] = 0.232287;
            ++i; UMicronOut[i] = 0.231781;
            ++i; UMicronOut[i] = 0.231275;
            ++i; UMicronOut[i] = 0.2307694;
            ++i; UMicronOut[i] = 0.230263;
            ++i; UMicronOut[i] = 0.229757;
            ++i; UMicronOut[i] = 0.229251;
            ++i; UMicronOut[i] = 0.228745;
            ++i; UMicronOut[i] = 0.2282394;
            ++i; UMicronOut[i] = 0.227733;
            ++i; UMicronOut[i] = 0.227227;
            ++i; UMicronOut[i] = 0.226721;
            ++i; UMicronOut[i] = 0.226215;
            ++i; UMicronOut[i] = 0.2257094;
            ++i; UMicronOut[i] = 0.225203;
            ++i; UMicronOut[i] = 0.224697;
            ++i; UMicronOut[i] = 0.224191;
            ++i; UMicronOut[i] = 0.223685;
            ++i; UMicronOut[i] = 0.2231794;
            ++i; UMicronOut[i] = 0.222673;
            ++i; UMicronOut[i] = 0.222167;
            ++i; UMicronOut[i] = 0.221661;
            ++i; UMicronOut[i] = 0.221155;
            ++i; UMicronOut[i] = 0.2206494;
            ++i; UMicronOut[i] = 0.220143;
            ++i; UMicronOut[i] = 0.219637;
            ++i; UMicronOut[i] = 0.219131;
            ++i; UMicronOut[i] = 0.218625;
            ++i; UMicronOut[i] = 0.2181189;
            ++i; UMicronOut[i] = 0.217613;
            ++i; UMicronOut[i] = 0.217107;
            ++i; UMicronOut[i] = 0.216601;
            ++i; UMicronOut[i] = 0.216095;
            ++i; UMicronOut[i] = 0.2155889;
            ++i; UMicronOut[i] = 0.215083;
            ++i; UMicronOut[i] = 0.214577;
            ++i; UMicronOut[i] = 0.214071;
            ++i; UMicronOut[i] = 0.213565;
            ++i; UMicronOut[i] = 0.2130589;
            ++i; UMicronOut[i] = 0.212553;
            ++i; UMicronOut[i] = 0.212047;
            ++i; UMicronOut[i] = 0.211541;
            ++i; UMicronOut[i] = 0.211035;
            ++i; UMicronOut[i] = 0.2105289;
            ++i; UMicronOut[i] = 0.210023;
            ++i; UMicronOut[i] = 0.209517;
            ++i; UMicronOut[i] = 0.209011;
            ++i; UMicronOut[i] = 0.208505;
            ++i; UMicronOut[i] = 0.20789;
            ++i; UMicronOut[i] = 0.207493;
            ++i; UMicronOut[i] = 0.206987;
            ++i; UMicronOut[i] = 0.206481;
            ++i; UMicronOut[i] = 0.205975;
            ++i; UMicronOut[i] = 0.2054689;
            ++i; UMicronOut[i] = 0.204963;
            ++i; UMicronOut[i] = 0.204457;
            ++i; UMicronOut[i] = 0.203951;
            ++i; UMicronOut[i] = 0.203445;
            ++i; UMicronOut[i] = 0.2029389;
            ++i; UMicronOut[i] = 0.202433;
            ++i; UMicronOut[i] = 0.201927;
            ++i; UMicronOut[i] = 0.201421;
            ++i; UMicronOut[i] = 0.200915;
            ++i; UMicronOut[i] = 0.2004089;
            ++i; UMicronOut[i] = 0.199903;
            ++i; UMicronOut[i] = 0.199397;
            ++i; UMicronOut[i] = 0.198891;
            ++i; UMicronOut[i] = 0.198385;
            ++i; UMicronOut[i] = 0.1978789;
            ++i; UMicronOut[i] = 0.197373;
            ++i; UMicronOut[i] = 0.196867;
            ++i; UMicronOut[i] = 0.196361;
            ++i; UMicronOut[i] = 0.195855;
            ++i; UMicronOut[i] = 0.1953489;
            ++i; UMicronOut[i] = 0.194843;
            ++i; UMicronOut[i] = 0.194337;
            ++i; UMicronOut[i] = 0.193831;
            ++i; UMicronOut[i] = 0.193325;
            ++i; UMicronOut[i] = 0.1928189;
            ++i; UMicronOut[i] = 0.192313;
            ++i; UMicronOut[i] = 0.191807;
            ++i; UMicronOut[i] = 0.191301;
            ++i; UMicronOut[i] = 0.190795;
            ++i; UMicronOut[i] = 0.1902889;
            ++i; UMicronOut[i] = 0.189783;
            ++i; UMicronOut[i] = 0.189277;
            ++i; UMicronOut[i] = 0.188771;
            ++i; UMicronOut[i] = 0.188265;
            ++i; UMicronOut[i] = 0.1877584;
            ++i; UMicronOut[i] = 0.187253;
            ++i; UMicronOut[i] = 0.186747;
            ++i; UMicronOut[i] = 0.186241;
            ++i; UMicronOut[i] = 0.185735;
            ++i; UMicronOut[i] = 0.1852284;
            ++i; UMicronOut[i] = 0.184723;
            ++i; UMicronOut[i] = 0.184217;
            ++i; UMicronOut[i] = 0.183711;
            ++i; UMicronOut[i] = 0.183205;
            ++i; UMicronOut[i] = 0.1826884;
            ++i; UMicronOut[i] = 0.182193;
            ++i; UMicronOut[i] = 0.181687;
            ++i; UMicronOut[i] = 0.181181;
            ++i; UMicronOut[i] = 0.180675;
            ++i; UMicronOut[i] = 0.1801684;
            ++i; UMicronOut[i] = 0.179663;
            ++i; UMicronOut[i] = 0.179157;
            ++i; UMicronOut[i] = 0.178651;
            ++i; UMicronOut[i] = 0.178145;
            ++i; UMicronOut[i] = 0.1776384;
            ++i; UMicronOut[i] = 0.177133;
            ++i; UMicronOut[i] = 0.176627;
            ++i; UMicronOut[i] = 0.176121;
            ++i; UMicronOut[i] = 0.175615;
            ++i; UMicronOut[i] = 0.1751084;
            ++i; UMicronOut[i] = 0.174603;
            ++i; UMicronOut[i] = 0.174097;
            ++i; UMicronOut[i] = 0.173591;
            ++i; UMicronOut[i] = 0.173085;
            ++i; UMicronOut[i] = 0.1725784;
            ++i; UMicronOut[i] = 0.172073;
            ++i; UMicronOut[i] = 0.171567;
            ++i; UMicronOut[i] = 0.171061;
            ++i; UMicronOut[i] = 0.170555;
            ++i; UMicronOut[i] = 0.1700484;
            ++i; UMicronOut[i] = 0.169543;
            ++i; UMicronOut[i] = 0.169037;
            ++i; UMicronOut[i] = 0.168531;
            ++i; UMicronOut[i] = 0.168025;
            ++i; UMicronOut[i] = 0.1675184;
            ++i; UMicronOut[i] = 0.167013;
            ++i; UMicronOut[i] = 0.166507;
            ++i; UMicronOut[i] = 0.166001;
            ++i; UMicronOut[i] = 0.165495;
            ++i; UMicronOut[i] = 0.1649884;
            ++i; UMicronOut[i] = 0.164483;
            ++i; UMicronOut[i] = 0.163977;
            ++i; UMicronOut[i] = 0.163471;
            ++i; UMicronOut[i] = 0.162965;
            ++i; UMicronOut[i] = 0.1624584;
            ++i; UMicronOut[i] = 0.161953;
            ++i; UMicronOut[i] = 0.161447;
            ++i; UMicronOut[i] = 0.160941;
            ++i; UMicronOut[i] = 0.160435;
            ++i; UMicronOut[i] = 0.1599284;
            ++i; UMicronOut[i] = 0.159423;
            ++i; UMicronOut[i] = 0.158917;
            ++i; UMicronOut[i] = 0.158411;
            ++i; UMicronOut[i] = 0.157905;
            ++i; UMicronOut[i] = 0.1573884;
            ++i; UMicronOut[i] = 0.156893;
            ++i; UMicronOut[i] = 0.156387;
            ++i; UMicronOut[i] = 0.155881;
            ++i; UMicronOut[i] = 0.155375;
            ++i; UMicronOut[i] = 0.1548679;
            ++i; UMicronOut[i] = 0.154363;
            ++i; UMicronOut[i] = 0.153857;
            ++i; UMicronOut[i] = 0.153351;
            ++i; UMicronOut[i] = 0.152845;
            ++i; UMicronOut[i] = 0.1523379;
            ++i; UMicronOut[i] = 0.151833;
            ++i; UMicronOut[i] = 0.151327;
            ++i; UMicronOut[i] = 0.150821;
            ++i; UMicronOut[i] = 0.150315;
            ++i; UMicronOut[i] = 0.1498079;
            ++i; UMicronOut[i] = 0.149303;
            ++i; UMicronOut[i] = 0.148797;
            ++i; UMicronOut[i] = 0.148291;
            ++i; UMicronOut[i] = 0.147785;
            ++i; UMicronOut[i] = 0.1472779;
            ++i; UMicronOut[i] = 0.146773;
            ++i; UMicronOut[i] = 0.146267;
            ++i; UMicronOut[i] = 0.145761;
            ++i; UMicronOut[i] = 0.145255;
            ++i; UMicronOut[i] = 0.1447479;
            ++i; UMicronOut[i] = 0.144243;
            ++i; UMicronOut[i] = 0.143737;
            ++i; UMicronOut[i] = 0.143231;
            ++i; UMicronOut[i] = 0.142725;
            ++i; UMicronOut[i] = 0.1422179;
            ++i; UMicronOut[i] = 0.141713;
            ++i; UMicronOut[i] = 0.141207;
            ++i; UMicronOut[i] = 0.140701;
            ++i; UMicronOut[i] = 0.140195;
            ++i; UMicronOut[i] = 0.1396879;
            ++i; UMicronOut[i] = 0.139183;
            ++i; UMicronOut[i] = 0.138677;
            ++i; UMicronOut[i] = 0.138171;
            ++i; UMicronOut[i] = 0.137665;
            ++i; UMicronOut[i] = 0.1371579;
            ++i; UMicronOut[i] = 0.136653;
            ++i; UMicronOut[i] = 0.136147;
            ++i; UMicronOut[i] = 0.135641;
            ++i; UMicronOut[i] = 0.135135;
            ++i; UMicronOut[i] = 0.1346279;
            ++i; UMicronOut[i] = 0.134123;
            ++i; UMicronOut[i] = 0.133617;
            ++i; UMicronOut[i] = 0.133111;
            ++i; UMicronOut[i] = 0.132605;
            ++i; UMicronOut[i] = 0.1320879;
            ++i; UMicronOut[i] = 0.131593;
            ++i; UMicronOut[i] = 0.131087;
            ++i; UMicronOut[i] = 0.130581;
            ++i; UMicronOut[i] = 0.130075;
            ++i; UMicronOut[i] = 0.1295679;
            ++i; UMicronOut[i] = 0.129063;
            ++i; UMicronOut[i] = 0.128557;
            ++i; UMicronOut[i] = 0.128051;
            ++i; UMicronOut[i] = 0.127545;
            ++i; UMicronOut[i] = 0.1270379;
            ++i; UMicronOut[i] = 0.126533;
            ++i; UMicronOut[i] = 0.126027;
            ++i; UMicronOut[i] = 0.125521;
            ++i; UMicronOut[i] = 0.125015;
            ++i; UMicronOut[i] = 0.1245079;
            ++i; UMicronOut[i] = 0.124003;
            ++i; UMicronOut[i] = 0.123497;
            ++i; UMicronOut[i] = 0.122991;
            ++i; UMicronOut[i] = 0.122485;
            ++i; UMicronOut[i] = 0.1219773;
            ++i; UMicronOut[i] = 0.121473;
            ++i; UMicronOut[i] = 0.120967;
            ++i; UMicronOut[i] = 0.120461;
            ++i; UMicronOut[i] = 0.119955;
            ++i; UMicronOut[i] = 0.1194473;
            ++i; UMicronOut[i] = 0.118943;
            ++i; UMicronOut[i] = 0.118437;
            ++i; UMicronOut[i] = 0.117931;
            ++i; UMicronOut[i] = 0.117425;
            ++i; UMicronOut[i] = 0.1169174;
            ++i; UMicronOut[i] = 0.116413;
            ++i; UMicronOut[i] = 0.115907;
            ++i; UMicronOut[i] = 0.115401;
            ++i; UMicronOut[i] = 0.114895;
            ++i; UMicronOut[i] = 0.1143873;
            ++i; UMicronOut[i] = 0.113883;
            ++i; UMicronOut[i] = 0.113377;
            ++i; UMicronOut[i] = 0.112871;
            ++i; UMicronOut[i] = 0.112365;
            ++i; UMicronOut[i] = 0.1118574;
            ++i; UMicronOut[i] = 0.111353;
            ++i; UMicronOut[i] = 0.110847;
            ++i; UMicronOut[i] = 0.110341;
            ++i; UMicronOut[i] = 0.109835;
            ++i; UMicronOut[i] = 0.1093273;
            ++i; UMicronOut[i] = 0.108823;
            ++i; UMicronOut[i] = 0.108317;
            ++i; UMicronOut[i] = 0.107811;
            ++i; UMicronOut[i] = 0.107305;
            ++i; UMicronOut[i] = 0.1067873;
            ++i; UMicronOut[i] = 0.106293;
            ++i; UMicronOut[i] = 0.105787;
            ++i; UMicronOut[i] = 0.105281;
            ++i; UMicronOut[i] = 0.104775;
            ++i; UMicronOut[i] = 0.1042673;
            ++i; UMicronOut[i] = 0.103763;
            ++i; UMicronOut[i] = 0.103257;
            ++i; UMicronOut[i] = 0.102751;
            ++i; UMicronOut[i] = 0.102245;
            ++i; UMicronOut[i] = 0.1017374;
            ++i; UMicronOut[i] = 0.101233;
            ++i; UMicronOut[i] = 0.100727;
            ++i; UMicronOut[i] = 0.100221;
            ++i; UMicronOut[i] = 0.0997155;
            ++i; UMicronOut[i] = 0.09920735;
            ++i; UMicronOut[i] = 0.0987035;
            ++i; UMicronOut[i] = 0.0981975;
            ++i; UMicronOut[i] = 0.0976915;
            ++i; UMicronOut[i] = 0.0971855;
            ++i; UMicronOut[i] = 0.09667735;
            ++i; UMicronOut[i] = 0.0961735;
            ++i; UMicronOut[i] = 0.0956675;
            ++i; UMicronOut[i] = 0.0951615;
            ++i; UMicronOut[i] = 0.0946555;
            ++i; UMicronOut[i] = 0.09414735;
            ++i; UMicronOut[i] = 0.0936435;
            ++i; UMicronOut[i] = 0.0931375;
            ++i; UMicronOut[i] = 0.0926315;
            ++i; UMicronOut[i] = 0.0921255;
            ++i; UMicronOut[i] = 0.09161735;
            ++i; UMicronOut[i] = 0.0911135;
            ++i; UMicronOut[i] = 0.0906079;
            ++i; UMicronOut[i] = 0.0901019;
            ++i; UMicronOut[i] = 0.0895959;
            ++i; UMicronOut[i] = 0.08908685;
            ++i; UMicronOut[i] = 0.0885839;
            ++i; UMicronOut[i] = 0.0880779;
            ++i; UMicronOut[i] = 0.0875719;
            ++i; UMicronOut[i] = 0.0870659;
            ++i; UMicronOut[i] = 0.08655684;
            ++i; UMicronOut[i] = 0.0860539;
            ++i; UMicronOut[i] = 0.0855479;
            ++i; UMicronOut[i] = 0.0850419;
            ++i; UMicronOut[i] = 0.0845359;
            ++i; UMicronOut[i] = 0.08402684;
            ++i; UMicronOut[i] = 0.0835239;
            ++i; UMicronOut[i] = 0.0830179;
            ++i; UMicronOut[i] = 0.0825119;
            ++i; UMicronOut[i] = 0.0820059;
            ++i; UMicronOut[i] = 0.08148684;
            ++i; UMicronOut[i] = 0.0809939;
            ++i; UMicronOut[i] = 0.0804879;
            ++i; UMicronOut[i] = 0.0799819;
            ++i; UMicronOut[i] = 0.0794759;
            ++i; UMicronOut[i] = 0.07896684;
            ++i; UMicronOut[i] = 0.0784639;
            ++i; UMicronOut[i] = 0.0779579;
            ++i; UMicronOut[i] = 0.0774519;
            ++i; UMicronOut[i] = 0.0769459;
            ++i; UMicronOut[i] = 0.07643684;
            ++i; UMicronOut[i] = 0.0759339;
            ++i; UMicronOut[i] = 0.0754279;
            ++i; UMicronOut[i] = 0.0749219;
            ++i; UMicronOut[i] = 0.0744159;
            ++i; UMicronOut[i] = 0.07390684;
            ++i; UMicronOut[i] = 0.0734039;
            ++i; UMicronOut[i] = 0.0728979;
            ++i; UMicronOut[i] = 0.0723919;
            ++i; UMicronOut[i] = 0.0718859;
            ++i; UMicronOut[i] = 0.07137685;
            ++i; UMicronOut[i] = 0.0708739;
            ++i; UMicronOut[i] = 0.0703679;
            ++i; UMicronOut[i] = 0.0698619;
            ++i; UMicronOut[i] = 0.0693559;
            ++i; UMicronOut[i] = 0.06884684;
            ++i; UMicronOut[i] = 0.0683439;
            ++i; UMicronOut[i] = 0.0678379;
            ++i; UMicronOut[i] = 0.0673319;
            ++i; UMicronOut[i] = 0.0668259;
            ++i; UMicronOut[i] = 0.06631684;
            ++i; UMicronOut[i] = 0.0658139;
            ++i; UMicronOut[i] = 0.0653079;
            ++i; UMicronOut[i] = 0.0648019;
            ++i; UMicronOut[i] = 0.0642959;
            ++i; UMicronOut[i] = 0.06378684;
            ++i; UMicronOut[i] = 0.0632839;
            ++i; UMicronOut[i] = 0.0627779;
            ++i; UMicronOut[i] = 0.0622719;
            ++i; UMicronOut[i] = 0.0617659;
            ++i; UMicronOut[i] = 0.06125684;
            ++i; UMicronOut[i] = 0.0607539;
            ++i; UMicronOut[i] = 0.0602479;
            ++i; UMicronOut[i] = 0.0597419;
            ++i; UMicronOut[i] = 0.0592359;
            ++i; UMicronOut[i] = 0.05872684;
            ++i; UMicronOut[i] = 0.0582239;
            ++i; UMicronOut[i] = 0.0577179;
            ++i; UMicronOut[i] = 0.0572119;
            ++i; UMicronOut[i] = 0.0567059;
            ++i; UMicronOut[i] = 0.05618634;
            ++i; UMicronOut[i] = 0.0556939;
            ++i; UMicronOut[i] = 0.0551879;
            ++i; UMicronOut[i] = 0.0546819;
            ++i; UMicronOut[i] = 0.0541759;
            ++i; UMicronOut[i] = 0.05366634;
            ++i; UMicronOut[i] = 0.0531639;
            ++i; UMicronOut[i] = 0.0526579;
            ++i; UMicronOut[i] = 0.0521519;
            ++i; UMicronOut[i] = 0.0516459;
            ++i; UMicronOut[i] = 0.05113634;
            ++i; UMicronOut[i] = 0.0506339;
            ++i; UMicronOut[i] = 0.0501279;
            ++i; UMicronOut[i] = 0.0496219;
            ++i; UMicronOut[i] = 0.0491159;
            ++i; UMicronOut[i] = 0.04860634;
            ++i; UMicronOut[i] = 0.0481039;
            ++i; UMicronOut[i] = 0.0475979;
            ++i; UMicronOut[i] = 0.0470919;
            ++i; UMicronOut[i] = 0.0465859;
            ++i; UMicronOut[i] = 0.04607634;
            ++i; UMicronOut[i] = 0.0455739;
            ++i; UMicronOut[i] = 0.0450679;
            ++i; UMicronOut[i] = 0.0445619;
            ++i; UMicronOut[i] = 0.0440559;
            ++i; UMicronOut[i] = 0.04354634;
            ++i; UMicronOut[i] = 0.0430439;
            ++i; UMicronOut[i] = 0.0425379;
            ++i; UMicronOut[i] = 0.0420319;
            ++i; UMicronOut[i] = 0.0415259;
            ++i; UMicronOut[i] = 0.04101634;
            ++i; UMicronOut[i] = 0.0405139;
            ++i; UMicronOut[i] = 0.0400079;
            ++i; UMicronOut[i] = 0.0395019;
            ++i; UMicronOut[i] = 0.0389959;
            ++i; UMicronOut[i] = 0.03848634;
            ++i; UMicronOut[i] = 0.0379839;
            ++i; UMicronOut[i] = 0.0374779;
            ++i; UMicronOut[i] = 0.0369719;
            ++i; UMicronOut[i] = 0.0364659;
            ++i; UMicronOut[i] = 0.03595634;
            ++i; UMicronOut[i] = 0.0354539;
            ++i; UMicronOut[i] = 0.0349479;
            ++i; UMicronOut[i] = 0.0344419;
            ++i; UMicronOut[i] = 0.0339359;
            ++i; UMicronOut[i] = 0.03342634;
            ++i; UMicronOut[i] = 0.0329239;
            ++i; UMicronOut[i] = 0.0324179;
            ++i; UMicronOut[i] = 0.0319119;
            ++i; UMicronOut[i] = 0.0314059;
            ++i; UMicronOut[i] = 0.03088634;
            ++i; UMicronOut[i] = 0.0303939;
            ++i; UMicronOut[i] = 0.0298879;
            ++i; UMicronOut[i] = 0.0293819;
            ++i; UMicronOut[i] = 0.0288759;
            ++i; UMicronOut[i] = 0.02836634;
            ++i; UMicronOut[i] = 0.0278639;
            ++i; UMicronOut[i] = 0.0273579;
            ++i; UMicronOut[i] = 0.0268519;
            ++i; UMicronOut[i] = 0.0263459;
            ++i; UMicronOut[i] = 0.0258383;
            ++i; UMicronOut[i] = 0.025333;
            ++i; UMicronOut[i] = 0.024827;
            ++i; UMicronOut[i] = 0.024321;
            ++i; UMicronOut[i] = 0.023815;
            ++i; UMicronOut[i] = 0.0233083;
            ++i; UMicronOut[i] = 0.022803;
            ++i; UMicronOut[i] = 0.022297;
            ++i; UMicronOut[i] = 0.021791;
            ++i; UMicronOut[i] = 0.021285;
            ++i; UMicronOut[i] = 0.0207783;
            ++i; UMicronOut[i] = 0.020273;
            ++i; UMicronOut[i] = 0.019767;
            ++i; UMicronOut[i] = 0.019261;
            ++i; UMicronOut[i] = 0.018755;
            ++i; UMicronOut[i] = 0.0182483;
            ++i; UMicronOut[i] = 0.017743;
            ++i; UMicronOut[i] = 0.017237;
            ++i; UMicronOut[i] = 0.016731;
            ++i; UMicronOut[i] = 0.016225;
            ++i; UMicronOut[i] = 0.0157183;
            ++i; UMicronOut[i] = 0.015213;
            ++i; UMicronOut[i] = 0.014707;
            ++i; UMicronOut[i] = 0.014201;
            ++i; UMicronOut[i] = 0.013695;
            ++i; UMicronOut[i] = 0.0131883;
            ++i; UMicronOut[i] = 0.012683;
            ++i; UMicronOut[i] = 0.012177;
            ++i; UMicronOut[i] = 0.011671;
            ++i; UMicronOut[i] = 0.011165;
            ++i; UMicronOut[i] = 0.0106583;
            ++i; UMicronOut[i] = 0.010153;
            ++i; UMicronOut[i] = 0.0096471;
            ++i; UMicronOut[i] = 0.0091411;
            ++i; UMicronOut[i] = 0.0086351;
            ++i; UMicronOut[i] = 0.00812831;
            ++i; UMicronOut[i] = 0.0076231;
            ++i; UMicronOut[i] = 0.0071171;
            ++i; UMicronOut[i] = 0.0066111;
            ++i; UMicronOut[i] = 0.0061051;
            ++i; UMicronOut[i] = 0.005585832;
            ++i; UMicronOut[i] = 0.0050931;
            ++i; UMicronOut[i] = 0.0045872;
            ++i; UMicronOut[i] = 0.0040811;
            ++i; UMicronOut[i] = 0.0035752;
            ++i; UMicronOut[i] = 0.00306831;
            ++i; UMicronOut[i] = 0.0025632;
            ++i; UMicronOut[i] = 0.0020571;
            ++i; UMicronOut[i] = 0.0015511;
            ++i; UMicronOut[i] = 0.0010451;
            ++i; UMicronOut[i] = 0.000538307;
            ++i; UMicronOut[i] = 0.00003314;
            ++i; UMicronOut[i] = -0.000472;
            ++i; UMicronOut[i] = -0.000978;
            ++i; UMicronOut[i] = -0.001484;
            ++i; UMicronOut[i] = -0.001990;
            ++i; UMicronOut[i] = -0.002496;
            ++i; UMicronOut[i] = -0.003002;
            ++i; UMicronOut[i] = -0.003508;
            ++i; UMicronOut[i] = -0.004014;
            ++i; UMicronOut[i] = -0.004520;
            ++i; UMicronOut[i] = -0.005026;
            ++i; UMicronOut[i] = -0.005532;
            ++i; UMicronOut[i] = -0.006038;
            ++i; UMicronOut[i] = -0.006544;
            ++i; UMicronOut[i] = -0.007050;
            ++i; UMicronOut[i] = -0.007556;
            ++i; UMicronOut[i] = -0.008062;
            ++i; UMicronOut[i] = -0.008568;
            ++i; UMicronOut[i] = -0.009074;
            ++i; UMicronOut[i] = -0.009580;
            ++i; UMicronOut[i] = -0.010086;
            ++i; UMicronOut[i] = -0.010592;
            ++i; UMicronOut[i] = -0.011098;
            ++i; UMicronOut[i] = -0.011604;
            ++i; UMicronOut[i] = -0.012110;
            ++i; UMicronOut[i] = -0.012616;
            ++i; UMicronOut[i] = -0.013122;
            ++i; UMicronOut[i] = -0.013628;
            ++i; UMicronOut[i] = -0.014134;
            ++i; UMicronOut[i] = -0.014640;
            ++i; UMicronOut[i] = -0.015146;
            ++i; UMicronOut[i] = -0.015652;
            ++i; UMicronOut[i] = -0.016158;
            ++i; UMicronOut[i] = -0.016664;
            ++i; UMicronOut[i] = -0.017170;
            ++i; UMicronOut[i] = -0.017676;
            ++i; UMicronOut[i] = -0.018182;
            ++i; UMicronOut[i] = -0.018688;
            ++i; UMicronOut[i] = -0.019194;
            ++i; UMicronOut[i] = -0.019700;
            ++i; UMicronOut[i] = -0.020206;
            ++i; UMicronOut[i] = -0.020712;
            ++i; UMicronOut[i] = -0.021218;
            ++i; UMicronOut[i] = -0.021724;
            ++i; UMicronOut[i] = -0.022230;
            ++i; UMicronOut[i] = -0.022736;
            ++i; UMicronOut[i] = -0.023242;
            ++i; UMicronOut[i] = -0.023748;
            ++i; UMicronOut[i] = -0.024254;
            ++i; UMicronOut[i] = -0.024760;
            ++i; UMicronOut[i] = -0.025266;
            ++i; UMicronOut[i] = -0.025772;
            ++i; UMicronOut[i] = -0.026278;
            ++i; UMicronOut[i] = -0.026784;
            ++i; UMicronOut[i] = -0.027290;
            ++i; UMicronOut[i] = -0.027796;
            ++i; UMicronOut[i] = -0.028302;
            ++i; UMicronOut[i] = -0.028808;
            ++i; UMicronOut[i] = -0.029314;
            ++i; UMicronOut[i] = -0.029820;
            ++i; UMicronOut[i] = -0.030326;
            ++i; UMicronOut[i] = -0.030832;
            ++i; UMicronOut[i] = -0.031338;
            ++i; UMicronOut[i] = -0.031844;
            ++i; UMicronOut[i] = -0.032350;
            ++i; UMicronOut[i] = -0.032856;
            ++i; UMicronOut[i] = -0.033362;
            ++i; UMicronOut[i] = -0.033868;
            ++i; UMicronOut[i] = -0.034374;
            ++i; UMicronOut[i] = -0.034880;
            ++i; UMicronOut[i] = -0.035386;
            ++i; UMicronOut[i] = -0.035892;
            ++i; UMicronOut[i] = -0.036398;
            ++i; UMicronOut[i] = -0.036904;
            ++i; UMicronOut[i] = -0.037410;
            ++i; UMicronOut[i] = -0.037916;
            ++i; UMicronOut[i] = -0.038422;
            ++i; UMicronOut[i] = -0.038928;
            ++i; UMicronOut[i] = -0.039434;
            ++i; UMicronOut[i] = -0.039940;
            ++i; UMicronOut[i] = -0.040446;
            ++i; UMicronOut[i] = -0.040952;
            ++i; UMicronOut[i] = -0.041458;
            ++i; UMicronOut[i] = -0.041964;
            ++i; UMicronOut[i] = -0.042470;
            ++i; UMicronOut[i] = -0.042976;
            ++i; UMicronOut[i] = -0.043482;
            ++i; UMicronOut[i] = -0.043988;
            ++i; UMicronOut[i] = -0.044494;
            ++i; UMicronOut[i] = -0.045000;
            ++i; UMicronOut[i] = -0.045506;
            ++i; UMicronOut[i] = -0.046012;
            ++i; UMicronOut[i] = -0.046518;
            ++i; UMicronOut[i] = -0.047024;
            ++i; UMicronOut[i] = -0.047530;
            ++i; UMicronOut[i] = -0.048036;
            ++i; UMicronOut[i] = -0.048542;
            ++i; UMicronOut[i] = -0.049048;
            ++i; UMicronOut[i] = -0.049554;
            ++i; UMicronOut[i] = -0.050060;
            ++i; UMicronOut[i] = -0.050566;
            ++i; UMicronOut[i] = -0.051072;
            ++i; UMicronOut[i] = -0.051578;
            ++i; UMicronOut[i] = -0.052084;
            ++i; UMicronOut[i] = -0.052590;
            ++i; UMicronOut[i] = -0.053096;
            ++i; UMicronOut[i] = -0.053602;
            ++i; UMicronOut[i] = -0.054108;
            ++i; UMicronOut[i] = -0.054614;
            ++i; UMicronOut[i] = -0.055120;
            ++i; UMicronOut[i] = -0.055626;
            ++i; UMicronOut[i] = -0.056132;
            ++i; UMicronOut[i] = -0.056638;
            ++i; UMicronOut[i] = -0.057144;
            ++i; UMicronOut[i] = -0.057650;
            ++i; UMicronOut[i] = -0.058156;
            ++i; UMicronOut[i] = -0.058662;
            ++i; UMicronOut[i] = -0.059168;
            ++i; UMicronOut[i] = -0.059674;
            ++i; UMicronOut[i] = -0.060180;
            ++i; UMicronOut[i] = -0.060686;
            ++i; UMicronOut[i] = -0.061192;
            ++i; UMicronOut[i] = -0.061698;
            ++i; UMicronOut[i] = -0.062204;
            ++i; UMicronOut[i] = -0.062710;
            ++i; UMicronOut[i] = -0.063216;
            ++i; UMicronOut[i] = -0.063722;
            ++i; UMicronOut[i] = -0.064228;
            ++i; UMicronOut[i] = -0.064734;
            ++i; UMicronOut[i] = -0.065240;
            ++i; UMicronOut[i] = -0.065746;
            ++i; UMicronOut[i] = -0.066252;
            ++i; UMicronOut[i] = -0.066758;
            ++i; UMicronOut[i] = -0.067264;
            ++i; UMicronOut[i] = -0.067770;
            ++i; UMicronOut[i] = -0.068276;
            ++i; UMicronOut[i] = -0.068782;
            ++i; UMicronOut[i] = -0.069288;
            ++i; UMicronOut[i] = -0.069794;
            ++i; UMicronOut[i] = -0.070300;
            ++i; UMicronOut[i] = -0.070806;
            ++i; UMicronOut[i] = -0.071312;
            ++i; UMicronOut[i] = -0.071818;
            ++i; UMicronOut[i] = -0.072324;
            ++i; UMicronOut[i] = -0.072830;
            ++i; UMicronOut[i] = -0.073336;
            ++i; UMicronOut[i] = -0.073842;
            ++i; UMicronOut[i] = -0.074348;
            ++i; UMicronOut[i] = -0.074854;
            ++i; UMicronOut[i] = -0.075360;
            ++i; UMicronOut[i] = -0.075866;
            ++i; UMicronOut[i] = -0.076372;
            ++i; UMicronOut[i] = -0.076878;
            ++i; UMicronOut[i] = -0.077384;
            ++i; UMicronOut[i] = -0.077890;
            ++i; UMicronOut[i] = -0.078396;
            ++i; UMicronOut[i] = -0.078902;
            ++i; UMicronOut[i] = -0.079408;
            ++i; UMicronOut[i] = -0.079914;
            ++i; UMicronOut[i] = -0.080420;
            ++i; UMicronOut[i] = -0.080926;
            ++i; UMicronOut[i] = -0.081432;
            ++i; UMicronOut[i] = -0.081938;
            ++i; UMicronOut[i] = -0.082444;
            ++i; UMicronOut[i] = -0.082950;
            ++i; UMicronOut[i] = -0.083456;
            ++i; UMicronOut[i] = -0.083962;
            ++i; UMicronOut[i] = -0.084468;
            ++i; UMicronOut[i] = -0.084974;
            ++i; UMicronOut[i] = -0.085480;
            ++i; UMicronOut[i] = -0.085986;
            ++i; UMicronOut[i] = -0.086492;
            ++i; UMicronOut[i] = -0.086998;
            ++i; UMicronOut[i] = -0.087504;
            ++i; UMicronOut[i] = -0.088010;
            ++i; UMicronOut[i] = -0.088516;
            ++i; UMicronOut[i] = -0.089022;
            ++i; UMicronOut[i] = -0.089528;
            ++i; UMicronOut[i] = -0.090034;
            ++i; UMicronOut[i] = -0.090540;
            ++i; UMicronOut[i] = -0.091046;
            ++i; UMicronOut[i] = -0.091552;
            ++i; UMicronOut[i] = -0.092058;
            ++i; UMicronOut[i] = -0.092564;
            ++i; UMicronOut[i] = -0.093070;
            ++i; UMicronOut[i] = -0.093576;
            ++i; UMicronOut[i] = -0.094082;
            ++i; UMicronOut[i] = -0.094588;
            ++i; UMicronOut[i] = -0.095094;
            ++i; UMicronOut[i] = -0.0956;
        }
        /// <summary>
        /// Sets the xi mas.
        /// </summary>
        public void SetXiMas()
        {
            int masSize = 2003;
            Xi = new double[masSize];
            int i = 1;
            ++i; Xi[i] = 20;
            ++i; Xi[i] = 19.99;
            ++i; Xi[i] = 19.98;
            ++i; Xi[i] = 19.97;
            ++i; Xi[i] = 19.96;
            ++i; Xi[i] = 19.95;
            ++i; Xi[i] = 19.94;
            ++i; Xi[i] = 19.93;
            ++i; Xi[i] = 19.92;
            ++i; Xi[i] = 19.91;
            ++i; Xi[i] = 19.9;
            ++i; Xi[i] = 19.89;
            ++i; Xi[i] = 19.88;
            ++i; Xi[i] = 19.87;
            ++i; Xi[i] = 19.86;
            ++i; Xi[i] = 19.85;
            ++i; Xi[i] = 19.84;
            ++i; Xi[i] = 19.83;
            ++i; Xi[i] = 19.82;
            ++i; Xi[i] = 19.81;
            ++i; Xi[i] = 19.8;
            ++i; Xi[i] = 19.79;
            ++i; Xi[i] = 19.78;
            ++i; Xi[i] = 19.77;
            ++i; Xi[i] = 19.76;
            ++i; Xi[i] = 19.75;
            ++i; Xi[i] = 19.74;
            ++i; Xi[i] = 19.73;
            ++i; Xi[i] = 19.72;
            ++i; Xi[i] = 19.71;
            ++i; Xi[i] = 19.7;
            ++i; Xi[i] = 19.69;
            ++i; Xi[i] = 19.6799999999999;
            ++i; Xi[i] = 19.6699999999999;
            ++i; Xi[i] = 19.6599999999999;
            ++i; Xi[i] = 19.6499999999999;
            ++i; Xi[i] = 19.6399999999999;
            ++i; Xi[i] = 19.6299999999999;
            ++i; Xi[i] = 19.6199999999999;
            ++i; Xi[i] = 19.6099999999999;
            ++i; Xi[i] = 19.5999999999999;
            ++i; Xi[i] = 19.5899999999999;
            ++i; Xi[i] = 19.5799999999999;
            ++i; Xi[i] = 19.5699999999999;
            ++i; Xi[i] = 19.5599999999999;
            ++i; Xi[i] = 19.5499999999999;
            ++i; Xi[i] = 19.5399999999999;
            ++i; Xi[i] = 19.5299999999999;
            ++i; Xi[i] = 19.5199999999999;
            ++i; Xi[i] = 19.5099999999999;
            ++i; Xi[i] = 19.4999999999999;
            ++i; Xi[i] = 19.4899999999999;
            ++i; Xi[i] = 19.4799999999999;
            ++i; Xi[i] = 19.4699999999999;
            ++i; Xi[i] = 19.4599999999999;
            ++i; Xi[i] = 19.4499999999999;
            ++i; Xi[i] = 19.4399999999999;
            ++i; Xi[i] = 19.4299999999999;
            ++i; Xi[i] = 19.4199999999999;
            ++i; Xi[i] = 19.4099999999999;
            ++i; Xi[i] = 19.3999999999999;
            ++i; Xi[i] = 19.3899999999999;
            ++i; Xi[i] = 19.3799999999999;
            ++i; Xi[i] = 19.3699999999999;
            ++i; Xi[i] = 19.3599999999999;
            ++i; Xi[i] = 19.3499999999999;
            ++i; Xi[i] = 19.3399999999999;
            ++i; Xi[i] = 19.3299999999999;
            ++i; Xi[i] = 19.3199999999999;
            ++i; Xi[i] = 19.3099999999999;
            ++i; Xi[i] = 19.2999999999999;
            ++i; Xi[i] = 19.2899999999999;
            ++i; Xi[i] = 19.2799999999999;
            ++i; Xi[i] = 19.2699999999999;
            ++i; Xi[i] = 19.2599999999999;
            ++i; Xi[i] = 19.2499999999999;
            ++i; Xi[i] = 19.2399999999999;
            ++i; Xi[i] = 19.2299999999999;
            ++i; Xi[i] = 19.2199999999999;
            ++i; Xi[i] = 19.2099999999999;
            ++i; Xi[i] = 19.1999999999999;
            ++i; Xi[i] = 19.1899999999999;
            ++i; Xi[i] = 19.1799999999999;
            ++i; Xi[i] = 19.1699999999999;
            ++i; Xi[i] = 19.1599999999999;
            ++i; Xi[i] = 19.1499999999999;
            ++i; Xi[i] = 19.1399999999999;
            ++i; Xi[i] = 19.1299999999999;
            ++i; Xi[i] = 19.1199999999999;
            ++i; Xi[i] = 19.1099999999999;
            ++i; Xi[i] = 19.0999999999999;
            ++i; Xi[i] = 19.0899999999999;
            ++i; Xi[i] = 19.0799999999999;
            ++i; Xi[i] = 19.0699999999999;
            ++i; Xi[i] = 19.0599999999999;
            ++i; Xi[i] = 19.0499999999999;
            ++i; Xi[i] = 19.0399999999998;
            ++i; Xi[i] = 19.0299999999998;
            ++i; Xi[i] = 19.0199999999998;
            ++i; Xi[i] = 19.0099999999998;
            ++i; Xi[i] = 18.9999999999998;
            ++i; Xi[i] = 18.9899999999998;
            ++i; Xi[i] = 18.9799999999998;
            ++i; Xi[i] = 18.9699999999998;
            ++i; Xi[i] = 18.9599999999998;
            ++i; Xi[i] = 18.9499999999998;
            ++i; Xi[i] = 18.9399999999998;
            ++i; Xi[i] = 18.9299999999998;
            ++i; Xi[i] = 18.9199999999998;
            ++i; Xi[i] = 18.9099999999998;
            ++i; Xi[i] = 18.8999999999998;
            ++i; Xi[i] = 18.8899999999998;
            ++i; Xi[i] = 18.8799999999998;
            ++i; Xi[i] = 18.8699999999998;
            ++i; Xi[i] = 18.8599999999998;
            ++i; Xi[i] = 18.8499999999998;
            ++i; Xi[i] = 18.8399999999998;
            ++i; Xi[i] = 18.8299999999998;
            ++i; Xi[i] = 18.8199999999998;
            ++i; Xi[i] = 18.8099999999998;
            ++i; Xi[i] = 18.7999999999998;
            ++i; Xi[i] = 18.7899999999998;
            ++i; Xi[i] = 18.7799999999998;
            ++i; Xi[i] = 18.7699999999998;
            ++i; Xi[i] = 18.7599999999998;
            ++i; Xi[i] = 18.7499999999998;
            ++i; Xi[i] = 18.7399999999998;
            ++i; Xi[i] = 18.7299999999998;
            ++i; Xi[i] = 18.7199999999998;
            ++i; Xi[i] = 18.7099999999998;
            ++i; Xi[i] = 18.6999999999998;
            ++i; Xi[i] = 18.6899999999998;
            ++i; Xi[i] = 18.6799999999998;
            ++i; Xi[i] = 18.6699999999998;
            ++i; Xi[i] = 18.6599999999998;
            ++i; Xi[i] = 18.6499999999998;
            ++i; Xi[i] = 18.6399999999998;
            ++i; Xi[i] = 18.6299999999998;
            ++i; Xi[i] = 18.6199999999998;
            ++i; Xi[i] = 18.6099999999998;
            ++i; Xi[i] = 18.5999999999998;
            ++i; Xi[i] = 18.5899999999998;
            ++i; Xi[i] = 18.5799999999998;
            ++i; Xi[i] = 18.5699999999998;
            ++i; Xi[i] = 18.5599999999998;
            ++i; Xi[i] = 18.5499999999998;
            ++i; Xi[i] = 18.5399999999998;
            ++i; Xi[i] = 18.5299999999998;
            ++i; Xi[i] = 18.5199999999998;
            ++i; Xi[i] = 18.5099999999998;
            ++i; Xi[i] = 18.4999999999998;
            ++i; Xi[i] = 18.4899999999998;
            ++i; Xi[i] = 18.4799999999998;
            ++i; Xi[i] = 18.4699999999998;
            ++i; Xi[i] = 18.4599999999998;
            ++i; Xi[i] = 18.4499999999998;
            ++i; Xi[i] = 18.4399999999998;
            ++i; Xi[i] = 18.4299999999998;
            ++i; Xi[i] = 18.4199999999997;
            ++i; Xi[i] = 18.4099999999998;
            ++i; Xi[i] = 18.3999999999997;
            ++i; Xi[i] = 18.3899999999998;
            ++i; Xi[i] = 18.3799999999998;
            ++i; Xi[i] = 18.3699999999997;
            ++i; Xi[i] = 18.3599999999997;
            ++i; Xi[i] = 18.3499999999997;
            ++i; Xi[i] = 18.3399999999997;
            ++i; Xi[i] = 18.3299999999997;
            ++i; Xi[i] = 18.3199999999997;
            ++i; Xi[i] = 18.3099999999997;
            ++i; Xi[i] = 18.2999999999997;
            ++i; Xi[i] = 18.2899999999997;
            ++i; Xi[i] = 18.2799999999997;
            ++i; Xi[i] = 18.2699999999997;
            ++i; Xi[i] = 18.2599999999997;
            ++i; Xi[i] = 18.2499999999997;
            ++i; Xi[i] = 18.2399999999997;
            ++i; Xi[i] = 18.2299999999997;
            ++i; Xi[i] = 18.2199999999997;
            ++i; Xi[i] = 18.2099999999997;
            ++i; Xi[i] = 18.1999999999997;
            ++i; Xi[i] = 18.1899999999997;
            ++i; Xi[i] = 18.1799999999997;
            ++i; Xi[i] = 18.1699999999997;
            ++i; Xi[i] = 18.1599999999997;
            ++i; Xi[i] = 18.1499999999997;
            ++i; Xi[i] = 18.1399999999997;
            ++i; Xi[i] = 18.1299999999997;
            ++i; Xi[i] = 18.1199999999997;
            ++i; Xi[i] = 18.1099999999997;
            ++i; Xi[i] = 18.0999999999997;
            ++i; Xi[i] = 18.0899999999997;
            ++i; Xi[i] = 18.0799999999997;
            ++i; Xi[i] = 18.0699999999997;
            ++i; Xi[i] = 18.0599999999997;
            ++i; Xi[i] = 18.0499999999997;
            ++i; Xi[i] = 18.0399999999997;
            ++i; Xi[i] = 18.0299999999997;
            ++i; Xi[i] = 18.0199999999997;
            ++i; Xi[i] = 18.0099999999997;
            ++i; Xi[i] = 17.9999999999997;
            ++i; Xi[i] = 17.9899999999997;
            ++i; Xi[i] = 17.9799999999997;
            ++i; Xi[i] = 17.9699999999997;
            ++i; Xi[i] = 17.9599999999997;
            ++i; Xi[i] = 17.9499999999997;
            ++i; Xi[i] = 17.9399999999997;
            ++i; Xi[i] = 17.9299999999997;
            ++i; Xi[i] = 17.9199999999997;
            ++i; Xi[i] = 17.9099999999997;
            ++i; Xi[i] = 17.8999999999997;
            ++i; Xi[i] = 17.8899999999997;
            ++i; Xi[i] = 17.8799999999997;
            ++i; Xi[i] = 17.8699999999997;
            ++i; Xi[i] = 17.8599999999997;
            ++i; Xi[i] = 17.8499999999997;
            ++i; Xi[i] = 17.8399999999997;
            ++i; Xi[i] = 17.8299999999997;
            ++i; Xi[i] = 17.8199999999997;
            ++i; Xi[i] = 17.8099999999997;
            ++i; Xi[i] = 17.7999999999997;
            ++i; Xi[i] = 17.7899999999997;
            ++i; Xi[i] = 17.7799999999996;
            ++i; Xi[i] = 17.7699999999997;
            ++i; Xi[i] = 17.7599999999996;
            ++i; Xi[i] = 17.7499999999997;
            ++i; Xi[i] = 17.7399999999997;
            ++i; Xi[i] = 17.7299999999996;
            ++i; Xi[i] = 17.7199999999996;
            ++i; Xi[i] = 17.7099999999996;
            ++i; Xi[i] = 17.6999999999996;
            ++i; Xi[i] = 17.6899999999996;
            ++i; Xi[i] = 17.6799999999996;
            ++i; Xi[i] = 17.6699999999996;
            ++i; Xi[i] = 17.6599999999996;
            ++i; Xi[i] = 17.6499999999996;
            ++i; Xi[i] = 17.6399999999996;
            ++i; Xi[i] = 17.6299999999996;
            ++i; Xi[i] = 17.6199999999996;
            ++i; Xi[i] = 17.6099999999996;
            ++i; Xi[i] = 17.5999999999996;
            ++i; Xi[i] = 17.5899999999996;
            ++i; Xi[i] = 17.5799999999996;
            ++i; Xi[i] = 17.5699999999996;
            ++i; Xi[i] = 17.5599999999996;
            ++i; Xi[i] = 17.5499999999996;
            ++i; Xi[i] = 17.5399999999996;
            ++i; Xi[i] = 17.5299999999996;
            ++i; Xi[i] = 17.5199999999996;
            ++i; Xi[i] = 17.5099999999996;
            ++i; Xi[i] = 17.4999999999996;
            ++i; Xi[i] = 17.4899999999996;
            ++i; Xi[i] = 17.4799999999996;
            ++i; Xi[i] = 17.4699999999996;
            ++i; Xi[i] = 17.4599999999996;
            ++i; Xi[i] = 17.4499999999996;
            ++i; Xi[i] = 17.4399999999996;
            ++i; Xi[i] = 17.4299999999996;
            ++i; Xi[i] = 17.4199999999996;
            ++i; Xi[i] = 17.4099999999996;
            ++i; Xi[i] = 17.3999999999996;
            ++i; Xi[i] = 17.3899999999996;
            ++i; Xi[i] = 17.3799999999996;
            ++i; Xi[i] = 17.3699999999996;
            ++i; Xi[i] = 17.3599999999996;
            ++i; Xi[i] = 17.3499999999996;
            ++i; Xi[i] = 17.3399999999996;
            ++i; Xi[i] = 17.3299999999996;
            ++i; Xi[i] = 17.3199999999996;
            ++i; Xi[i] = 17.3099999999996;
            ++i; Xi[i] = 17.2999999999996;
            ++i; Xi[i] = 17.2899999999996;
            ++i; Xi[i] = 17.2799999999996;
            ++i; Xi[i] = 17.2699999999996;
            ++i; Xi[i] = 17.2599999999996;
            ++i; Xi[i] = 17.2499999999996;
            ++i; Xi[i] = 17.2399999999996;
            ++i; Xi[i] = 17.2299999999996;
            ++i; Xi[i] = 17.2199999999996;
            ++i; Xi[i] = 17.2099999999996;
            ++i; Xi[i] = 17.1999999999996;
            ++i; Xi[i] = 17.1899999999996;
            ++i; Xi[i] = 17.1799999999996;
            ++i; Xi[i] = 17.1699999999996;
            ++i; Xi[i] = 17.1599999999996;
            ++i; Xi[i] = 17.1499999999996;
            ++i; Xi[i] = 17.1399999999995;
            ++i; Xi[i] = 17.1299999999996;
            ++i; Xi[i] = 17.1199999999995;
            ++i; Xi[i] = 17.1099999999996;
            ++i; Xi[i] = 17.0999999999996;
            ++i; Xi[i] = 17.0899999999995;
            ++i; Xi[i] = 17.0799999999995;
            ++i; Xi[i] = 17.0699999999995;
            ++i; Xi[i] = 17.0599999999995;
            ++i; Xi[i] = 17.0499999999995;
            ++i; Xi[i] = 17.0399999999995;
            ++i; Xi[i] = 17.0299999999995;
            ++i; Xi[i] = 17.0199999999995;
            ++i; Xi[i] = 17.0099999999995;
            ++i; Xi[i] = 16.9999999999995;
            ++i; Xi[i] = 16.9899999999995;
            ++i; Xi[i] = 16.9799999999995;
            ++i; Xi[i] = 16.9699999999995;
            ++i; Xi[i] = 16.9599999999995;
            ++i; Xi[i] = 16.9499999999995;
            ++i; Xi[i] = 16.9399999999995;
            ++i; Xi[i] = 16.9299999999995;
            ++i; Xi[i] = 16.9199999999995;
            ++i; Xi[i] = 16.9099999999995;
            ++i; Xi[i] = 16.8999999999995;
            ++i; Xi[i] = 16.8899999999995;
            ++i; Xi[i] = 16.8799999999995;
            ++i; Xi[i] = 16.8699999999995;
            ++i; Xi[i] = 16.8599999999995;
            ++i; Xi[i] = 16.8499999999995;
            ++i; Xi[i] = 16.8399999999995;
            ++i; Xi[i] = 16.8299999999995;
            ++i; Xi[i] = 16.8199999999995;
            ++i; Xi[i] = 16.8099999999995;
            ++i; Xi[i] = 16.7999999999995;
            ++i; Xi[i] = 16.7899999999995;
            ++i; Xi[i] = 16.7799999999995;
            ++i; Xi[i] = 16.7699999999995;
            ++i; Xi[i] = 16.7599999999995;
            ++i; Xi[i] = 16.7499999999995;
            ++i; Xi[i] = 16.7399999999995;
            ++i; Xi[i] = 16.7299999999995;
            ++i; Xi[i] = 16.7199999999995;
            ++i; Xi[i] = 16.7099999999995;
            ++i; Xi[i] = 16.6999999999995;
            ++i; Xi[i] = 16.6899999999995;
            ++i; Xi[i] = 16.6799999999995;
            ++i; Xi[i] = 16.6699999999995;
            ++i; Xi[i] = 16.6599999999995;
            ++i; Xi[i] = 16.6499999999995;
            ++i; Xi[i] = 16.6399999999995;
            ++i; Xi[i] = 16.6299999999995;
            ++i; Xi[i] = 16.6199999999995;
            ++i; Xi[i] = 16.6099999999995;
            ++i; Xi[i] = 16.5999999999995;
            ++i; Xi[i] = 16.5899999999995;
            ++i; Xi[i] = 16.5799999999995;
            ++i; Xi[i] = 16.5699999999995;
            ++i; Xi[i] = 16.5599999999995;
            ++i; Xi[i] = 16.5499999999995;
            ++i; Xi[i] = 16.5399999999995;
            ++i; Xi[i] = 16.5299999999995;
            ++i; Xi[i] = 16.5199999999995;
            ++i; Xi[i] = 16.5099999999995;
            ++i; Xi[i] = 16.4999999999994;
            ++i; Xi[i] = 16.4899999999995;
            ++i; Xi[i] = 16.4799999999994;
            ++i; Xi[i] = 16.4699999999995;
            ++i; Xi[i] = 16.4599999999995;
            ++i; Xi[i] = 16.4499999999994;
            ++i; Xi[i] = 16.4399999999994;
            ++i; Xi[i] = 16.4299999999994;
            ++i; Xi[i] = 16.4199999999994;
            ++i; Xi[i] = 16.4099999999994;
            ++i; Xi[i] = 16.3999999999994;
            ++i; Xi[i] = 16.3899999999994;
            ++i; Xi[i] = 16.3799999999994;
            ++i; Xi[i] = 16.3699999999994;
            ++i; Xi[i] = 16.3599999999994;
            ++i; Xi[i] = 16.3499999999994;
            ++i; Xi[i] = 16.3399999999994;
            ++i; Xi[i] = 16.3299999999994;
            ++i; Xi[i] = 16.3199999999994;
            ++i; Xi[i] = 16.3099999999994;
            ++i; Xi[i] = 16.2999999999994;
            ++i; Xi[i] = 16.2899999999994;
            ++i; Xi[i] = 16.2799999999994;
            ++i; Xi[i] = 16.2699999999994;
            ++i; Xi[i] = 16.2599999999994;
            ++i; Xi[i] = 16.2499999999994;
            ++i; Xi[i] = 16.2399999999994;
            ++i; Xi[i] = 16.2299999999994;
            ++i; Xi[i] = 16.2199999999994;
            ++i; Xi[i] = 16.2099999999994;
            ++i; Xi[i] = 16.1999999999994;
            ++i; Xi[i] = 16.1899999999994;
            ++i; Xi[i] = 16.1799999999994;
            ++i; Xi[i] = 16.1699999999994;
            ++i; Xi[i] = 16.1599999999994;
            ++i; Xi[i] = 16.1499999999994;
            ++i; Xi[i] = 16.1399999999994;
            ++i; Xi[i] = 16.1299999999994;
            ++i; Xi[i] = 16.1199999999994;
            ++i; Xi[i] = 16.1099999999994;
            ++i; Xi[i] = 16.0999999999994;
            ++i; Xi[i] = 16.0899999999994;
            ++i; Xi[i] = 16.0799999999994;
            ++i; Xi[i] = 16.0699999999994;
            ++i; Xi[i] = 16.0599999999994;
            ++i; Xi[i] = 16.0499999999994;
            ++i; Xi[i] = 16.0399999999994;
            ++i; Xi[i] = 16.0299999999994;
            ++i; Xi[i] = 16.0199999999994;
            ++i; Xi[i] = 16.0099999999994;
            ++i; Xi[i] = 15.9999999999994;
            ++i; Xi[i] = 15.9899999999994;
            ++i; Xi[i] = 15.9799999999994;
            ++i; Xi[i] = 15.9699999999994;
            ++i; Xi[i] = 15.9599999999994;
            ++i; Xi[i] = 15.9499999999994;
            ++i; Xi[i] = 15.9399999999994;
            ++i; Xi[i] = 15.9299999999994;
            ++i; Xi[i] = 15.9199999999994;
            ++i; Xi[i] = 15.9099999999994;
            ++i; Xi[i] = 15.8999999999994;
            ++i; Xi[i] = 15.8899999999994;
            ++i; Xi[i] = 15.8799999999994;
            ++i; Xi[i] = 15.8699999999994;
            ++i; Xi[i] = 15.8599999999993;
            ++i; Xi[i] = 15.8499999999994;
            ++i; Xi[i] = 15.8399999999993;
            ++i; Xi[i] = 15.8299999999993;
            ++i; Xi[i] = 15.8199999999994;
            ++i; Xi[i] = 15.8099999999994;
            ++i; Xi[i] = 15.7999999999993;
            ++i; Xi[i] = 15.7899999999993;
            ++i; Xi[i] = 15.7799999999993;
            ++i; Xi[i] = 15.7699999999993;
            ++i; Xi[i] = 15.7599999999993;
            ++i; Xi[i] = 15.7499999999993;
            ++i; Xi[i] = 15.7399999999993;
            ++i; Xi[i] = 15.7299999999993;
            ++i; Xi[i] = 15.7199999999993;
            ++i; Xi[i] = 15.7099999999993;
            ++i; Xi[i] = 15.6999999999993;
            ++i; Xi[i] = 15.6899999999993;
            ++i; Xi[i] = 15.6799999999993;
            ++i; Xi[i] = 15.6699999999993;
            ++i; Xi[i] = 15.6599999999993;
            ++i; Xi[i] = 15.6499999999993;
            ++i; Xi[i] = 15.6399999999993;
            ++i; Xi[i] = 15.6299999999993;
            ++i; Xi[i] = 15.6199999999993;
            ++i; Xi[i] = 15.6099999999993;
            ++i; Xi[i] = 15.5999999999993;
            ++i; Xi[i] = 15.5899999999993;
            ++i; Xi[i] = 15.5799999999993;
            ++i; Xi[i] = 15.5699999999993;
            ++i; Xi[i] = 15.5599999999993;
            ++i; Xi[i] = 15.5499999999993;
            ++i; Xi[i] = 15.5399999999993;
            ++i; Xi[i] = 15.5299999999993;
            ++i; Xi[i] = 15.5199999999993;
            ++i; Xi[i] = 15.5099999999993;
            ++i; Xi[i] = 15.4999999999993;
            ++i; Xi[i] = 15.4899999999993;
            ++i; Xi[i] = 15.4799999999993;
            ++i; Xi[i] = 15.4699999999993;
            ++i; Xi[i] = 15.4599999999993;
            ++i; Xi[i] = 15.4499999999993;
            ++i; Xi[i] = 15.4399999999993;
            ++i; Xi[i] = 15.4299999999993;
            ++i; Xi[i] = 15.4199999999993;
            ++i; Xi[i] = 15.4099999999993;
            ++i; Xi[i] = 15.3999999999993;
            ++i; Xi[i] = 15.3899999999993;
            ++i; Xi[i] = 15.3799999999993;
            ++i; Xi[i] = 15.3699999999993;
            ++i; Xi[i] = 15.3599999999993;
            ++i; Xi[i] = 15.3499999999993;
            ++i; Xi[i] = 15.3399999999993;
            ++i; Xi[i] = 15.3299999999993;
            ++i; Xi[i] = 15.3199999999993;
            ++i; Xi[i] = 15.3099999999993;
            ++i; Xi[i] = 15.2999999999993;
            ++i; Xi[i] = 15.2899999999993;
            ++i; Xi[i] = 15.2799999999993;
            ++i; Xi[i] = 15.2699999999993;
            ++i; Xi[i] = 15.2599999999993;
            ++i; Xi[i] = 15.2499999999993;
            ++i; Xi[i] = 15.2399999999993;
            ++i; Xi[i] = 15.2299999999993;
            ++i; Xi[i] = 15.2199999999992;
            ++i; Xi[i] = 15.2099999999993;
            ++i; Xi[i] = 15.1999999999992;
            ++i; Xi[i] = 15.1899999999992;
            ++i; Xi[i] = 15.1799999999993;
            ++i; Xi[i] = 15.1699999999992;
            ++i; Xi[i] = 15.1599999999992;
            ++i; Xi[i] = 15.1499999999992;
            ++i; Xi[i] = 15.1399999999992;
            ++i; Xi[i] = 15.1299999999992;
            ++i; Xi[i] = 15.1199999999992;
            ++i; Xi[i] = 15.1099999999992;
            ++i; Xi[i] = 15.0999999999992;
            ++i; Xi[i] = 15.0899999999992;
            ++i; Xi[i] = 15.0799999999992;
            ++i; Xi[i] = 15.0699999999992;
            ++i; Xi[i] = 15.0599999999992;
            ++i; Xi[i] = 15.0499999999992;
            ++i; Xi[i] = 15.0399999999992;
            ++i; Xi[i] = 15.0299999999992;
            ++i; Xi[i] = 15.0199999999992;
            ++i; Xi[i] = 15.0099999999992;
            ++i; Xi[i] = 14.9999999999992;
            ++i; Xi[i] = 14.9899999999992;
            ++i; Xi[i] = 14.9799999999992;
            ++i; Xi[i] = 14.9699999999992;
            ++i; Xi[i] = 14.9599999999992;
            ++i; Xi[i] = 14.9499999999992;
            ++i; Xi[i] = 14.9399999999992;
            ++i; Xi[i] = 14.9299999999992;
            ++i; Xi[i] = 14.9199999999992;
            ++i; Xi[i] = 14.9099999999992;
            ++i; Xi[i] = 14.8999999999992;
            ++i; Xi[i] = 14.8899999999992;
            ++i; Xi[i] = 14.8799999999992;
            ++i; Xi[i] = 14.8699999999992;
            ++i; Xi[i] = 14.8599999999992;
            ++i; Xi[i] = 14.8499999999992;
            ++i; Xi[i] = 14.8399999999992;
            ++i; Xi[i] = 14.8299999999992;
            ++i; Xi[i] = 14.8199999999992;
            ++i; Xi[i] = 14.8099999999992;
            ++i; Xi[i] = 14.7999999999992;
            ++i; Xi[i] = 14.7899999999992;
            ++i; Xi[i] = 14.7799999999992;
            ++i; Xi[i] = 14.7699999999992;
            ++i; Xi[i] = 14.7599999999992;
            ++i; Xi[i] = 14.7499999999992;
            ++i; Xi[i] = 14.7399999999992;
            ++i; Xi[i] = 14.7299999999992;
            ++i; Xi[i] = 14.7199999999992;
            ++i; Xi[i] = 14.7099999999992;
            ++i; Xi[i] = 14.6999999999992;
            ++i; Xi[i] = 14.6899999999992;
            ++i; Xi[i] = 14.6799999999992;
            ++i; Xi[i] = 14.6699999999992;
            ++i; Xi[i] = 14.6599999999992;
            ++i; Xi[i] = 14.6499999999992;
            ++i; Xi[i] = 14.6399999999992;
            ++i; Xi[i] = 14.6299999999992;
            ++i; Xi[i] = 14.6199999999992;
            ++i; Xi[i] = 14.6099999999992;
            ++i; Xi[i] = 14.5999999999992;
            ++i; Xi[i] = 14.5899999999992;
            ++i; Xi[i] = 14.5799999999991;
            ++i; Xi[i] = 14.5699999999992;
            ++i; Xi[i] = 14.5599999999991;
            ++i; Xi[i] = 14.5499999999991;
            ++i; Xi[i] = 14.5399999999992;
            ++i; Xi[i] = 14.5299999999991;
            ++i; Xi[i] = 14.5199999999991;
            ++i; Xi[i] = 14.5099999999991;
            ++i; Xi[i] = 14.4999999999991;
            ++i; Xi[i] = 14.4899999999991;
            ++i; Xi[i] = 14.4799999999991;
            ++i; Xi[i] = 14.4699999999991;
            ++i; Xi[i] = 14.4599999999991;
            ++i; Xi[i] = 14.4499999999991;
            ++i; Xi[i] = 14.4399999999991;
            ++i; Xi[i] = 14.4299999999991;
            ++i; Xi[i] = 14.4199999999991;
            ++i; Xi[i] = 14.4099999999991;
            ++i; Xi[i] = 14.3999999999991;
            ++i; Xi[i] = 14.3899999999991;
            ++i; Xi[i] = 14.3799999999991;
            ++i; Xi[i] = 14.3699999999991;
            ++i; Xi[i] = 14.3599999999991;
            ++i; Xi[i] = 14.3499999999991;
            ++i; Xi[i] = 14.3399999999991;
            ++i; Xi[i] = 14.3299999999991;
            ++i; Xi[i] = 14.3199999999991;
            ++i; Xi[i] = 14.3099999999991;
            ++i; Xi[i] = 14.2999999999991;
            ++i; Xi[i] = 14.2899999999991;
            ++i; Xi[i] = 14.2799999999991;
            ++i; Xi[i] = 14.2699999999991;
            ++i; Xi[i] = 14.2599999999991;
            ++i; Xi[i] = 14.2499999999991;
            ++i; Xi[i] = 14.2399999999991;
            ++i; Xi[i] = 14.2299999999991;
            ++i; Xi[i] = 14.2199999999991;
            ++i; Xi[i] = 14.2099999999991;
            ++i; Xi[i] = 14.1999999999991;
            ++i; Xi[i] = 14.1899999999991;
            ++i; Xi[i] = 14.1799999999991;
            ++i; Xi[i] = 14.1699999999991;
            ++i; Xi[i] = 14.1599999999991;
            ++i; Xi[i] = 14.1499999999991;
            ++i; Xi[i] = 14.1399999999991;
            ++i; Xi[i] = 14.1299999999991;
            ++i; Xi[i] = 14.1199999999991;
            ++i; Xi[i] = 14.1099999999991;
            ++i; Xi[i] = 14.0999999999991;
            ++i; Xi[i] = 14.0899999999991;
            ++i; Xi[i] = 14.0799999999991;
            ++i; Xi[i] = 14.0699999999991;
            ++i; Xi[i] = 14.0599999999991;
            ++i; Xi[i] = 14.0499999999991;
            ++i; Xi[i] = 14.0399999999991;
            ++i; Xi[i] = 14.0299999999991;
            ++i; Xi[i] = 14.0199999999991;
            ++i; Xi[i] = 14.0099999999991;
            ++i; Xi[i] = 13.9999999999991;
            ++i; Xi[i] = 13.9899999999991;
            ++i; Xi[i] = 13.9799999999991;
            ++i; Xi[i] = 13.9699999999991;
            ++i; Xi[i] = 13.9599999999991;
            ++i; Xi[i] = 13.9499999999991;
            ++i; Xi[i] = 13.939999999999;
            ++i; Xi[i] = 13.9299999999991;
            ++i; Xi[i] = 13.919999999999;
            ++i; Xi[i] = 13.909999999999;
            ++i; Xi[i] = 13.8999999999991;
            ++i; Xi[i] = 13.889999999999;
            ++i; Xi[i] = 13.879999999999;
            ++i; Xi[i] = 13.869999999999;
            ++i; Xi[i] = 13.859999999999;
            ++i; Xi[i] = 13.849999999999;
            ++i; Xi[i] = 13.839999999999;
            ++i; Xi[i] = 13.829999999999;
            ++i; Xi[i] = 13.819999999999;
            ++i; Xi[i] = 13.809999999999;
            ++i; Xi[i] = 13.799999999999;
            ++i; Xi[i] = 13.789999999999;
            ++i; Xi[i] = 13.779999999999;
            ++i; Xi[i] = 13.769999999999;
            ++i; Xi[i] = 13.759999999999;
            ++i; Xi[i] = 13.749999999999;
            ++i; Xi[i] = 13.739999999999;
            ++i; Xi[i] = 13.729999999999;
            ++i; Xi[i] = 13.719999999999;
            ++i; Xi[i] = 13.709999999999;
            ++i; Xi[i] = 13.699999999999;
            ++i; Xi[i] = 13.689999999999;
            ++i; Xi[i] = 13.679999999999;
            ++i; Xi[i] = 13.669999999999;
            ++i; Xi[i] = 13.659999999999;
            ++i; Xi[i] = 13.649999999999;
            ++i; Xi[i] = 13.639999999999;
            ++i; Xi[i] = 13.629999999999;
            ++i; Xi[i] = 13.619999999999;
            ++i; Xi[i] = 13.609999999999;
            ++i; Xi[i] = 13.599999999999;
            ++i; Xi[i] = 13.589999999999;
            ++i; Xi[i] = 13.579999999999;
            ++i; Xi[i] = 13.569999999999;
            ++i; Xi[i] = 13.559999999999;
            ++i; Xi[i] = 13.549999999999;
            ++i; Xi[i] = 13.539999999999;
            ++i; Xi[i] = 13.529999999999;
            ++i; Xi[i] = 13.519999999999;
            ++i; Xi[i] = 13.509999999999;
            ++i; Xi[i] = 13.499999999999;
            ++i; Xi[i] = 13.489999999999;
            ++i; Xi[i] = 13.479999999999;
            ++i; Xi[i] = 13.469999999999;
            ++i; Xi[i] = 13.459999999999;
            ++i; Xi[i] = 13.449999999999;
            ++i; Xi[i] = 13.439999999999;
            ++i; Xi[i] = 13.429999999999;
            ++i; Xi[i] = 13.419999999999;
            ++i; Xi[i] = 13.409999999999;
            ++i; Xi[i] = 13.399999999999;
            ++i; Xi[i] = 13.389999999999;
            ++i; Xi[i] = 13.379999999999;
            ++i; Xi[i] = 13.369999999999;
            ++i; Xi[i] = 13.359999999999;
            ++i; Xi[i] = 13.349999999999;
            ++i; Xi[i] = 13.339999999999;
            ++i; Xi[i] = 13.329999999999;
            ++i; Xi[i] = 13.319999999999;
            ++i; Xi[i] = 13.309999999999;
            ++i; Xi[i] = 13.2999999999989;
            ++i; Xi[i] = 13.289999999999;
            ++i; Xi[i] = 13.2799999999989;
            ++i; Xi[i] = 13.2699999999989;
            ++i; Xi[i] = 13.2599999999989;
            ++i; Xi[i] = 13.2499999999989;
            ++i; Xi[i] = 13.2399999999989;
            ++i; Xi[i] = 13.2299999999989;
            ++i; Xi[i] = 13.2199999999989;
            ++i; Xi[i] = 13.2099999999989;
            ++i; Xi[i] = 13.1999999999989;
            ++i; Xi[i] = 13.1899999999989;
            ++i; Xi[i] = 13.1799999999989;
            ++i; Xi[i] = 13.1699999999989;
            ++i; Xi[i] = 13.1599999999989;
            ++i; Xi[i] = 13.1499999999989;
            ++i; Xi[i] = 13.1399999999989;
            ++i; Xi[i] = 13.1299999999989;
            ++i; Xi[i] = 13.1199999999989;
            ++i; Xi[i] = 13.1099999999989;
            ++i; Xi[i] = 13.0999999999989;
            ++i; Xi[i] = 13.0899999999989;
            ++i; Xi[i] = 13.0799999999989;
            ++i; Xi[i] = 13.0699999999989;
            ++i; Xi[i] = 13.0599999999989;
            ++i; Xi[i] = 13.0499999999989;
            ++i; Xi[i] = 13.0399999999989;
            ++i; Xi[i] = 13.0299999999989;
            ++i; Xi[i] = 13.0199999999989;
            ++i; Xi[i] = 13.0099999999989;
            ++i; Xi[i] = 12.9999999999989;
            ++i; Xi[i] = 12.9899999999989;
            ++i; Xi[i] = 12.9799999999989;
            ++i; Xi[i] = 12.9699999999989;
            ++i; Xi[i] = 12.9599999999989;
            ++i; Xi[i] = 12.9499999999989;
            ++i; Xi[i] = 12.9399999999989;
            ++i; Xi[i] = 12.9299999999989;
            ++i; Xi[i] = 12.9199999999989;
            ++i; Xi[i] = 12.9099999999989;
            ++i; Xi[i] = 12.8999999999989;
            ++i; Xi[i] = 12.8899999999989;
            ++i; Xi[i] = 12.8799999999989;
            ++i; Xi[i] = 12.8699999999989;
            ++i; Xi[i] = 12.8599999999989;
            ++i; Xi[i] = 12.8499999999989;
            ++i; Xi[i] = 12.8399999999989;
            ++i; Xi[i] = 12.8299999999989;
            ++i; Xi[i] = 12.8199999999989;
            ++i; Xi[i] = 12.8099999999989;
            ++i; Xi[i] = 12.7999999999989;
            ++i; Xi[i] = 12.7899999999989;
            ++i; Xi[i] = 12.7799999999989;
            ++i; Xi[i] = 12.7699999999989;
            ++i; Xi[i] = 12.7599999999989;
            ++i; Xi[i] = 12.7499999999989;
            ++i; Xi[i] = 12.7399999999989;
            ++i; Xi[i] = 12.7299999999989;
            ++i; Xi[i] = 12.7199999999989;
            ++i; Xi[i] = 12.7099999999989;
            ++i; Xi[i] = 12.6999999999989;
            ++i; Xi[i] = 12.6899999999989;
            ++i; Xi[i] = 12.6799999999989;
            ++i; Xi[i] = 12.6699999999989;
            ++i; Xi[i] = 12.6599999999988;
            ++i; Xi[i] = 12.6499999999989;
            ++i; Xi[i] = 12.6399999999988;
            ++i; Xi[i] = 12.6299999999988;
            ++i; Xi[i] = 12.6199999999988;
            ++i; Xi[i] = 12.6099999999988;
            ++i; Xi[i] = 12.5999999999988;
            ++i; Xi[i] = 12.5899999999988;
            ++i; Xi[i] = 12.5799999999988;
            ++i; Xi[i] = 12.5699999999988;
            ++i; Xi[i] = 12.5599999999988;
            ++i; Xi[i] = 12.5499999999988;
            ++i; Xi[i] = 12.5399999999988;
            ++i; Xi[i] = 12.5299999999988;
            ++i; Xi[i] = 12.5199999999988;
            ++i; Xi[i] = 12.5099999999988;
            ++i; Xi[i] = 12.4999999999988;
            ++i; Xi[i] = 12.4899999999988;
            ++i; Xi[i] = 12.4799999999988;
            ++i; Xi[i] = 12.4699999999988;
            ++i; Xi[i] = 12.4599999999988;
            ++i; Xi[i] = 12.4499999999988;
            ++i; Xi[i] = 12.4399999999988;
            ++i; Xi[i] = 12.4299999999988;
            ++i; Xi[i] = 12.4199999999988;
            ++i; Xi[i] = 12.4099999999988;
            ++i; Xi[i] = 12.3999999999988;
            ++i; Xi[i] = 12.3899999999988;
            ++i; Xi[i] = 12.3799999999988;
            ++i; Xi[i] = 12.3699999999988;
            ++i; Xi[i] = 12.3599999999988;
            ++i; Xi[i] = 12.3499999999988;
            ++i; Xi[i] = 12.3399999999988;
            ++i; Xi[i] = 12.3299999999988;
            ++i; Xi[i] = 12.3199999999988;
            ++i; Xi[i] = 12.3099999999988;
            ++i; Xi[i] = 12.2999999999988;
            ++i; Xi[i] = 12.2899999999988;
            ++i; Xi[i] = 12.2799999999988;
            ++i; Xi[i] = 12.2699999999988;
            ++i; Xi[i] = 12.2599999999988;
            ++i; Xi[i] = 12.2499999999988;
            ++i; Xi[i] = 12.2399999999988;
            ++i; Xi[i] = 12.2299999999988;
            ++i; Xi[i] = 12.2199999999988;
            ++i; Xi[i] = 12.2099999999988;
            ++i; Xi[i] = 12.1999999999988;
            ++i; Xi[i] = 12.1899999999988;
            ++i; Xi[i] = 12.1799999999988;
            ++i; Xi[i] = 12.1699999999988;
            ++i; Xi[i] = 12.1599999999988;
            ++i; Xi[i] = 12.1499999999988;
            ++i; Xi[i] = 12.1399999999988;
            ++i; Xi[i] = 12.1299999999988;
            ++i; Xi[i] = 12.1199999999988;
            ++i; Xi[i] = 12.1099999999988;
            ++i; Xi[i] = 12.0999999999988;
            ++i; Xi[i] = 12.0899999999988;
            ++i; Xi[i] = 12.0799999999988;
            ++i; Xi[i] = 12.0699999999988;
            ++i; Xi[i] = 12.0599999999988;
            ++i; Xi[i] = 12.0499999999988;
            ++i; Xi[i] = 12.0399999999988;
            ++i; Xi[i] = 12.0299999999988;
            ++i; Xi[i] = 12.0199999999987;
            ++i; Xi[i] = 12.0099999999988;
            ++i; Xi[i] = 11.9999999999987;
            ++i; Xi[i] = 11.9899999999987;
            ++i; Xi[i] = 11.9799999999987;
            ++i; Xi[i] = 11.9699999999987;
            ++i; Xi[i] = 11.9599999999987;
            ++i; Xi[i] = 11.9499999999987;
            ++i; Xi[i] = 11.9399999999987;
            ++i; Xi[i] = 11.9299999999987;
            ++i; Xi[i] = 11.9199999999987;
            ++i; Xi[i] = 11.9099999999987;
            ++i; Xi[i] = 11.8999999999987;
            ++i; Xi[i] = 11.8899999999987;
            ++i; Xi[i] = 11.8799999999987;
            ++i; Xi[i] = 11.8699999999987;
            ++i; Xi[i] = 11.8599999999987;
            ++i; Xi[i] = 11.8499999999987;
            ++i; Xi[i] = 11.8399999999987;
            ++i; Xi[i] = 11.8299999999987;
            ++i; Xi[i] = 11.8199999999987;
            ++i; Xi[i] = 11.8099999999987;
            ++i; Xi[i] = 11.7999999999987;
            ++i; Xi[i] = 11.7899999999987;
            ++i; Xi[i] = 11.7799999999987;
            ++i; Xi[i] = 11.7699999999987;
            ++i; Xi[i] = 11.7599999999987;
            ++i; Xi[i] = 11.7499999999987;
            ++i; Xi[i] = 11.7399999999987;
            ++i; Xi[i] = 11.7299999999987;
            ++i; Xi[i] = 11.7199999999987;
            ++i; Xi[i] = 11.7099999999987;
            ++i; Xi[i] = 11.6999999999987;
            ++i; Xi[i] = 11.6899999999987;
            ++i; Xi[i] = 11.6799999999987;
            ++i; Xi[i] = 11.6699999999987;
            ++i; Xi[i] = 11.6599999999987;
            ++i; Xi[i] = 11.6499999999987;
            ++i; Xi[i] = 11.6399999999987;
            ++i; Xi[i] = 11.6299999999987;
            ++i; Xi[i] = 11.6199999999987;
            ++i; Xi[i] = 11.6099999999987;
            ++i; Xi[i] = 11.5999999999987;
            ++i; Xi[i] = 11.5899999999987;
            ++i; Xi[i] = 11.5799999999987;
            ++i; Xi[i] = 11.5699999999987;
            ++i; Xi[i] = 11.5599999999987;
            ++i; Xi[i] = 11.5499999999987;
            ++i; Xi[i] = 11.5399999999987;
            ++i; Xi[i] = 11.5299999999987;
            ++i; Xi[i] = 11.5199999999987;
            ++i; Xi[i] = 11.5099999999987;
            ++i; Xi[i] = 11.4999999999987;
            ++i; Xi[i] = 11.4899999999987;
            ++i; Xi[i] = 11.4799999999987;
            ++i; Xi[i] = 11.4699999999987;
            ++i; Xi[i] = 11.4599999999987;
            ++i; Xi[i] = 11.4499999999987;
            ++i; Xi[i] = 11.4399999999987;
            ++i; Xi[i] = 11.4299999999987;
            ++i; Xi[i] = 11.4199999999987;
            ++i; Xi[i] = 11.4099999999987;
            ++i; Xi[i] = 11.3999999999987;
            ++i; Xi[i] = 11.3899999999987;
            ++i; Xi[i] = 11.3799999999987;
            ++i; Xi[i] = 11.3699999999986;
            ++i; Xi[i] = 11.3599999999986;
            ++i; Xi[i] = 11.3499999999986;
            ++i; Xi[i] = 11.3399999999986;
            ++i; Xi[i] = 11.3299999999986;
            ++i; Xi[i] = 11.3199999999986;
            ++i; Xi[i] = 11.3099999999986;
            ++i; Xi[i] = 11.2999999999986;
            ++i; Xi[i] = 11.2899999999986;
            ++i; Xi[i] = 11.2799999999986;
            ++i; Xi[i] = 11.2699999999986;
            ++i; Xi[i] = 11.2599999999986;
            ++i; Xi[i] = 11.2499999999986;
            ++i; Xi[i] = 11.2399999999986;
            ++i; Xi[i] = 11.2299999999986;
            ++i; Xi[i] = 11.2199999999986;
            ++i; Xi[i] = 11.2099999999986;
            ++i; Xi[i] = 11.1999999999986;
            ++i; Xi[i] = 11.1899999999986;
            ++i; Xi[i] = 11.1799999999986;
            ++i; Xi[i] = 11.1699999999986;
            ++i; Xi[i] = 11.1599999999986;
            ++i; Xi[i] = 11.1499999999986;
            ++i; Xi[i] = 11.1399999999986;
            ++i; Xi[i] = 11.1299999999986;
            ++i; Xi[i] = 11.1199999999986;
            ++i; Xi[i] = 11.1099999999986;
            ++i; Xi[i] = 11.0999999999986;
            ++i; Xi[i] = 11.0899999999986;
            ++i; Xi[i] = 11.0799999999986;
            ++i; Xi[i] = 11.0699999999986;
            ++i; Xi[i] = 11.0599999999986;
            ++i; Xi[i] = 11.0499999999986;
            ++i; Xi[i] = 11.0399999999986;
            ++i; Xi[i] = 11.0299999999986;
            ++i; Xi[i] = 11.0199999999986;
            ++i; Xi[i] = 11.0099999999986;
            ++i; Xi[i] = 10.9999999999986;
            ++i; Xi[i] = 10.9899999999986;
            ++i; Xi[i] = 10.9799999999986;
            ++i; Xi[i] = 10.9699999999986;
            ++i; Xi[i] = 10.9599999999986;
            ++i; Xi[i] = 10.9499999999986;
            ++i; Xi[i] = 10.9399999999986;
            ++i; Xi[i] = 10.9299999999986;
            ++i; Xi[i] = 10.9199999999986;
            ++i; Xi[i] = 10.9099999999986;
            ++i; Xi[i] = 10.8999999999986;
            ++i; Xi[i] = 10.8899999999986;
            ++i; Xi[i] = 10.8799999999986;
            ++i; Xi[i] = 10.8699999999986;
            ++i; Xi[i] = 10.8599999999986;
            ++i; Xi[i] = 10.8499999999986;
            ++i; Xi[i] = 10.8399999999986;
            ++i; Xi[i] = 10.8299999999986;
            ++i; Xi[i] = 10.8199999999986;
            ++i; Xi[i] = 10.8099999999986;
            ++i; Xi[i] = 10.7999999999986;
            ++i; Xi[i] = 10.7899999999986;
            ++i; Xi[i] = 10.7799999999986;
            ++i; Xi[i] = 10.7699999999986;
            ++i; Xi[i] = 10.7599999999986;
            ++i; Xi[i] = 10.7499999999986;
            ++i; Xi[i] = 10.7399999999986;
            ++i; Xi[i] = 10.7299999999985;
            ++i; Xi[i] = 10.7199999999985;
            ++i; Xi[i] = 10.7099999999985;
            ++i; Xi[i] = 10.6999999999985;
            ++i; Xi[i] = 10.6899999999985;
            ++i; Xi[i] = 10.6799999999985;
            ++i; Xi[i] = 10.6699999999985;
            ++i; Xi[i] = 10.6599999999985;
            ++i; Xi[i] = 10.6499999999985;
            ++i; Xi[i] = 10.6399999999985;
            ++i; Xi[i] = 10.6299999999985;
            ++i; Xi[i] = 10.6199999999985;
            ++i; Xi[i] = 10.6099999999985;
            ++i; Xi[i] = 10.5999999999985;
            ++i; Xi[i] = 10.5899999999985;
            ++i; Xi[i] = 10.5799999999985;
            ++i; Xi[i] = 10.5699999999985;
            ++i; Xi[i] = 10.5599999999985;
            ++i; Xi[i] = 10.5499999999985;
            ++i; Xi[i] = 10.5399999999985;
            ++i; Xi[i] = 10.5299999999985;
            ++i; Xi[i] = 10.5199999999985;
            ++i; Xi[i] = 10.5099999999985;
            ++i; Xi[i] = 10.4999999999985;
            ++i; Xi[i] = 10.4899999999985;
            ++i; Xi[i] = 10.4799999999985;
            ++i; Xi[i] = 10.4699999999985;
            ++i; Xi[i] = 10.4599999999985;
            ++i; Xi[i] = 10.4499999999985;
            ++i; Xi[i] = 10.4399999999985;
            ++i; Xi[i] = 10.4299999999985;
            ++i; Xi[i] = 10.4199999999985;
            ++i; Xi[i] = 10.4099999999985;
            ++i; Xi[i] = 10.3999999999985;
            ++i; Xi[i] = 10.3899999999985;
            ++i; Xi[i] = 10.3799999999985;
            ++i; Xi[i] = 10.3699999999985;
            ++i; Xi[i] = 10.3599999999985;
            ++i; Xi[i] = 10.3499999999985;
            ++i; Xi[i] = 10.3399999999985;
            ++i; Xi[i] = 10.3299999999985;
            ++i; Xi[i] = 10.3199999999985;
            ++i; Xi[i] = 10.3099999999985;
            ++i; Xi[i] = 10.2999999999985;
            ++i; Xi[i] = 10.2899999999985;
            ++i; Xi[i] = 10.2799999999985;
            ++i; Xi[i] = 10.2699999999985;
            ++i; Xi[i] = 10.2599999999985;
            ++i; Xi[i] = 10.2499999999985;
            ++i; Xi[i] = 10.2399999999985;
            ++i; Xi[i] = 10.2299999999985;
            ++i; Xi[i] = 10.2199999999985;
            ++i; Xi[i] = 10.2099999999985;
            ++i; Xi[i] = 10.1999999999985;
            ++i; Xi[i] = 10.1899999999985;
            ++i; Xi[i] = 10.1799999999985;
            ++i; Xi[i] = 10.1699999999985;
            ++i; Xi[i] = 10.1599999999985;
            ++i; Xi[i] = 10.1499999999985;
            ++i; Xi[i] = 10.1399999999985;
            ++i; Xi[i] = 10.1299999999985;
            ++i; Xi[i] = 10.1199999999985;
            ++i; Xi[i] = 10.1099999999985;
            ++i; Xi[i] = 10.0999999999985;
            ++i; Xi[i] = 10.0899999999985;
            ++i; Xi[i] = 10.0799999999984;
            ++i; Xi[i] = 10.0699999999984;
            ++i; Xi[i] = 10.0599999999984;
            ++i; Xi[i] = 10.0499999999984;
            ++i; Xi[i] = 10.0399999999984;
            ++i; Xi[i] = 10.0299999999984;
            ++i; Xi[i] = 10.0199999999984;
            ++i; Xi[i] = 10.0099999999984;
            ++i; Xi[i] = 9.9999999999984;
            ++i; Xi[i] = 9.9899999999984;
            ++i; Xi[i] = 9.9799999999984;
            ++i; Xi[i] = 9.9699999999984;
            ++i; Xi[i] = 9.9599999999984;
            ++i; Xi[i] = 9.9499999999984;
            ++i; Xi[i] = 9.9399999999984;
            ++i; Xi[i] = 9.9299999999984;
            ++i; Xi[i] = 9.9199999999984;
            ++i; Xi[i] = 9.9099999999984;
            ++i; Xi[i] = 9.8999999999984;
            ++i; Xi[i] = 9.8899999999984;
            ++i; Xi[i] = 9.8799999999984;
            ++i; Xi[i] = 9.8699999999984;
            ++i; Xi[i] = 9.8599999999984;
            ++i; Xi[i] = 9.8499999999984;
            ++i; Xi[i] = 9.8399999999984;
            ++i; Xi[i] = 9.8299999999984;
            ++i; Xi[i] = 9.8199999999984;
            ++i; Xi[i] = 9.8099999999984;
            ++i; Xi[i] = 9.7999999999984;
            ++i; Xi[i] = 9.7899999999984;
            ++i; Xi[i] = 9.7799999999984;
            ++i; Xi[i] = 9.7699999999984;
            ++i; Xi[i] = 9.7599999999984;
            ++i; Xi[i] = 9.7499999999984;
            ++i; Xi[i] = 9.7399999999984;
            ++i; Xi[i] = 9.7299999999984;
            ++i; Xi[i] = 9.7199999999984;
            ++i; Xi[i] = 9.7099999999984;
            ++i; Xi[i] = 9.6999999999984;
            ++i; Xi[i] = 9.6899999999984;
            ++i; Xi[i] = 9.6799999999984;
            ++i; Xi[i] = 9.6699999999984;
            ++i; Xi[i] = 9.6599999999984;
            ++i; Xi[i] = 9.6499999999984;
            ++i; Xi[i] = 9.6399999999984;
            ++i; Xi[i] = 9.6299999999984;
            ++i; Xi[i] = 9.6199999999984;
            ++i; Xi[i] = 9.6099999999984;
            ++i; Xi[i] = 9.5999999999984;
            ++i; Xi[i] = 9.5899999999984;
            ++i; Xi[i] = 9.5799999999984;
            ++i; Xi[i] = 9.5699999999984;
            ++i; Xi[i] = 9.5599999999984;
            ++i; Xi[i] = 9.5499999999984;
            ++i; Xi[i] = 9.5399999999984;
            ++i; Xi[i] = 9.5299999999984;
            ++i; Xi[i] = 9.5199999999984;
            ++i; Xi[i] = 9.5099999999984;
            ++i; Xi[i] = 9.4999999999984;
            ++i; Xi[i] = 9.4899999999984;
            ++i; Xi[i] = 9.4799999999984;
            ++i; Xi[i] = 9.4699999999984;
            ++i; Xi[i] = 9.4599999999984;
            ++i; Xi[i] = 9.4499999999984;
            ++i; Xi[i] = 9.4399999999983;
            ++i; Xi[i] = 9.4299999999983;
            ++i; Xi[i] = 9.4199999999983;
            ++i; Xi[i] = 9.4099999999983;
            ++i; Xi[i] = 9.3999999999983;
            ++i; Xi[i] = 9.3899999999983;
            ++i; Xi[i] = 9.3799999999983;
            ++i; Xi[i] = 9.3699999999983;
            ++i; Xi[i] = 9.3599999999983;
            ++i; Xi[i] = 9.3499999999983;
            ++i; Xi[i] = 9.3399999999983;
            ++i; Xi[i] = 9.3299999999983;
            ++i; Xi[i] = 9.3199999999983;
            ++i; Xi[i] = 9.3099999999983;
            ++i; Xi[i] = 9.2999999999983;
            ++i; Xi[i] = 9.2899999999983;
            ++i; Xi[i] = 9.2799999999983;
            ++i; Xi[i] = 9.2699999999983;
            ++i; Xi[i] = 9.2599999999983;
            ++i; Xi[i] = 9.2499999999983;
            ++i; Xi[i] = 9.2399999999983;
            ++i; Xi[i] = 9.2299999999983;
            ++i; Xi[i] = 9.2199999999983;
            ++i; Xi[i] = 9.2099999999983;
            ++i; Xi[i] = 9.1999999999983;
            ++i; Xi[i] = 9.1899999999983;
            ++i; Xi[i] = 9.1799999999983;
            ++i; Xi[i] = 9.1699999999983;
            ++i; Xi[i] = 9.1599999999983;
            ++i; Xi[i] = 9.1499999999983;
            ++i; Xi[i] = 9.1399999999983;
            ++i; Xi[i] = 9.1299999999983;
            ++i; Xi[i] = 9.1199999999983;
            ++i; Xi[i] = 9.1099999999983;
            ++i; Xi[i] = 9.0999999999983;
            ++i; Xi[i] = 9.0899999999983;
            ++i; Xi[i] = 9.0799999999983;
            ++i; Xi[i] = 9.0699999999983;
            ++i; Xi[i] = 9.0599999999983;
            ++i; Xi[i] = 9.0499999999983;
            ++i; Xi[i] = 9.0399999999983;
            ++i; Xi[i] = 9.0299999999983;
            ++i; Xi[i] = 9.0199999999983;
            ++i; Xi[i] = 9.0099999999983;
            ++i; Xi[i] = 8.9999999999983;
            ++i; Xi[i] = 8.9899999999983;
            ++i; Xi[i] = 8.9799999999983;
            ++i; Xi[i] = 8.9699999999983;
            ++i; Xi[i] = 8.9599999999983;
            ++i; Xi[i] = 8.9499999999983;
            ++i; Xi[i] = 8.9399999999983;
            ++i; Xi[i] = 8.9299999999983;
            ++i; Xi[i] = 8.9199999999983;
            ++i; Xi[i] = 8.9099999999983;
            ++i; Xi[i] = 8.8999999999983;
            ++i; Xi[i] = 8.8899999999983;
            ++i; Xi[i] = 8.8799999999983;
            ++i; Xi[i] = 8.8699999999983;
            ++i; Xi[i] = 8.8599999999983;
            ++i; Xi[i] = 8.8499999999983;
            ++i; Xi[i] = 8.8399999999983;
            ++i; Xi[i] = 8.8299999999983;
            ++i; Xi[i] = 8.8199999999983;
            ++i; Xi[i] = 8.8099999999983;
            ++i; Xi[i] = 8.7999999999982;
            ++i; Xi[i] = 8.7899999999982;
            ++i; Xi[i] = 8.7799999999982;
            ++i; Xi[i] = 8.7699999999982;
            ++i; Xi[i] = 8.7599999999982;
            ++i; Xi[i] = 8.7499999999982;
            ++i; Xi[i] = 8.7399999999982;
            ++i; Xi[i] = 8.7299999999982;
            ++i; Xi[i] = 8.7199999999982;
            ++i; Xi[i] = 8.7099999999982;
            ++i; Xi[i] = 8.6999999999982;
            ++i; Xi[i] = 8.6899999999982;
            ++i; Xi[i] = 8.6799999999982;
            ++i; Xi[i] = 8.6699999999982;
            ++i; Xi[i] = 8.6599999999982;
            ++i; Xi[i] = 8.6499999999982;
            ++i; Xi[i] = 8.6399999999982;
            ++i; Xi[i] = 8.6299999999982;
            ++i; Xi[i] = 8.6199999999982;
            ++i; Xi[i] = 8.6099999999982;
            ++i; Xi[i] = 8.5999999999982;
            ++i; Xi[i] = 8.5899999999982;
            ++i; Xi[i] = 8.5799999999982;
            ++i; Xi[i] = 8.5699999999982;
            ++i; Xi[i] = 8.5599999999982;
            ++i; Xi[i] = 8.5499999999982;
            ++i; Xi[i] = 8.5399999999982;
            ++i; Xi[i] = 8.5299999999982;
            ++i; Xi[i] = 8.5199999999982;
            ++i; Xi[i] = 8.5099999999982;
            ++i; Xi[i] = 8.4999999999982;
            ++i; Xi[i] = 8.4899999999982;
            ++i; Xi[i] = 8.4799999999982;
            ++i; Xi[i] = 8.4699999999982;
            ++i; Xi[i] = 8.4599999999982;
            ++i; Xi[i] = 8.4499999999982;
            ++i; Xi[i] = 8.4399999999982;
            ++i; Xi[i] = 8.4299999999982;
            ++i; Xi[i] = 8.4199999999982;
            ++i; Xi[i] = 8.4099999999982;
            ++i; Xi[i] = 8.3999999999982;
            ++i; Xi[i] = 8.3899999999982;
            ++i; Xi[i] = 8.3799999999982;
            ++i; Xi[i] = 8.3699999999982;
            ++i; Xi[i] = 8.3599999999982;
            ++i; Xi[i] = 8.3499999999982;
            ++i; Xi[i] = 8.3399999999982;
            ++i; Xi[i] = 8.3299999999982;
            ++i; Xi[i] = 8.3199999999982;
            ++i; Xi[i] = 8.3099999999982;
            ++i; Xi[i] = 8.2999999999982;
            ++i; Xi[i] = 8.2899999999982;
            ++i; Xi[i] = 8.2799999999982;
            ++i; Xi[i] = 8.2699999999982;
            ++i; Xi[i] = 8.2599999999982;
            ++i; Xi[i] = 8.2499999999982;
            ++i; Xi[i] = 8.2399999999982;
            ++i; Xi[i] = 8.2299999999982;
            ++i; Xi[i] = 8.2199999999982;
            ++i; Xi[i] = 8.2099999999982;
            ++i; Xi[i] = 8.1999999999982;
            ++i; Xi[i] = 8.1899999999982;
            ++i; Xi[i] = 8.1799999999982;
            ++i; Xi[i] = 8.1699999999982;
            ++i; Xi[i] = 8.1599999999981;
            ++i; Xi[i] = 8.1499999999981;
            ++i; Xi[i] = 8.1399999999981;
            ++i; Xi[i] = 8.1299999999981;
            ++i; Xi[i] = 8.1199999999981;
            ++i; Xi[i] = 8.1099999999981;
            ++i; Xi[i] = 8.0999999999981;
            ++i; Xi[i] = 8.0899999999981;
            ++i; Xi[i] = 8.0799999999981;
            ++i; Xi[i] = 8.0699999999981;
            ++i; Xi[i] = 8.0599999999981;
            ++i; Xi[i] = 8.0499999999981;
            ++i; Xi[i] = 8.0399999999981;
            ++i; Xi[i] = 8.0299999999981;
            ++i; Xi[i] = 8.0199999999981;
            ++i; Xi[i] = 8.0099999999981;
            ++i; Xi[i] = 7.9999999999981;
            ++i; Xi[i] = 7.9899999999981;
            ++i; Xi[i] = 7.9799999999981;
            ++i; Xi[i] = 7.9699999999981;
            ++i; Xi[i] = 7.9599999999981;
            ++i; Xi[i] = 7.9499999999981;
            ++i; Xi[i] = 7.9399999999981;
            ++i; Xi[i] = 7.9299999999981;
            ++i; Xi[i] = 7.9199999999981;
            ++i; Xi[i] = 7.9099999999981;
            ++i; Xi[i] = 7.8999999999981;
            ++i; Xi[i] = 7.8899999999981;
            ++i; Xi[i] = 7.8799999999981;
            ++i; Xi[i] = 7.8699999999981;
            ++i; Xi[i] = 7.8599999999981;
            ++i; Xi[i] = 7.8499999999981;
            ++i; Xi[i] = 7.8399999999981;
            ++i; Xi[i] = 7.8299999999981;
            ++i; Xi[i] = 7.8199999999981;
            ++i; Xi[i] = 7.8099999999981;
            ++i; Xi[i] = 7.7999999999981;
            ++i; Xi[i] = 7.7899999999981;
            ++i; Xi[i] = 7.7799999999981;
            ++i; Xi[i] = 7.7699999999981;
            ++i; Xi[i] = 7.7599999999981;
            ++i; Xi[i] = 7.7499999999981;
            ++i; Xi[i] = 7.7399999999981;
            ++i; Xi[i] = 7.7299999999981;
            ++i; Xi[i] = 7.7199999999981;
            ++i; Xi[i] = 7.7099999999981;
            ++i; Xi[i] = 7.6999999999981;
            ++i; Xi[i] = 7.6899999999981;
            ++i; Xi[i] = 7.6799999999981;
            ++i; Xi[i] = 7.6699999999981;
            ++i; Xi[i] = 7.6599999999981;
            ++i; Xi[i] = 7.6499999999981;
            ++i; Xi[i] = 7.6399999999981;
            ++i; Xi[i] = 7.6299999999981;
            ++i; Xi[i] = 7.6199999999981;
            ++i; Xi[i] = 7.6099999999981;
            ++i; Xi[i] = 7.5999999999981;
            ++i; Xi[i] = 7.5899999999981;
            ++i; Xi[i] = 7.5799999999981;
            ++i; Xi[i] = 7.5699999999981;
            ++i; Xi[i] = 7.5599999999981;
            ++i; Xi[i] = 7.5499999999981;
            ++i; Xi[i] = 7.5399999999981;
            ++i; Xi[i] = 7.5299999999981;
            ++i; Xi[i] = 7.519999999998;
            ++i; Xi[i] = 7.509999999998;
            ++i; Xi[i] = 7.499999999998;
            ++i; Xi[i] = 7.489999999998;
            ++i; Xi[i] = 7.479999999998;
            ++i; Xi[i] = 7.469999999998;
            ++i; Xi[i] = 7.459999999998;
            ++i; Xi[i] = 7.449999999998;
            ++i; Xi[i] = 7.439999999998;
            ++i; Xi[i] = 7.429999999998;
            ++i; Xi[i] = 7.419999999998;
            ++i; Xi[i] = 7.409999999998;
            ++i; Xi[i] = 7.399999999998;
            ++i; Xi[i] = 7.389999999998;
            ++i; Xi[i] = 7.379999999998;
            ++i; Xi[i] = 7.369999999998;
            ++i; Xi[i] = 7.359999999998;
            ++i; Xi[i] = 7.349999999998;
            ++i; Xi[i] = 7.339999999998;
            ++i; Xi[i] = 7.329999999998;
            ++i; Xi[i] = 7.319999999998;
            ++i; Xi[i] = 7.309999999998;
            ++i; Xi[i] = 7.299999999998;
            ++i; Xi[i] = 7.289999999998;
            ++i; Xi[i] = 7.279999999998;
            ++i; Xi[i] = 7.269999999998;
            ++i; Xi[i] = 7.259999999998;
            ++i; Xi[i] = 7.249999999998;
            ++i; Xi[i] = 7.239999999998;
            ++i; Xi[i] = 7.229999999998;
            ++i; Xi[i] = 7.219999999998;
            ++i; Xi[i] = 7.209999999998;
            ++i; Xi[i] = 7.199999999998;
            ++i; Xi[i] = 7.189999999998;
            ++i; Xi[i] = 7.179999999998;
            ++i; Xi[i] = 7.169999999998;
            ++i; Xi[i] = 7.159999999998;
            ++i; Xi[i] = 7.149999999998;
            ++i; Xi[i] = 7.139999999998;
            ++i; Xi[i] = 7.129999999998;
            ++i; Xi[i] = 7.119999999998;
            ++i; Xi[i] = 7.109999999998;
            ++i; Xi[i] = 7.099999999998;
            ++i; Xi[i] = 7.089999999998;
            ++i; Xi[i] = 7.079999999998;
            ++i; Xi[i] = 7.069999999998;
            ++i; Xi[i] = 7.059999999998;
            ++i; Xi[i] = 7.049999999998;
            ++i; Xi[i] = 7.039999999998;
            ++i; Xi[i] = 7.029999999998;
            ++i; Xi[i] = 7.019999999998;
            ++i; Xi[i] = 7.009999999998;
            ++i; Xi[i] = 6.999999999998;
            ++i; Xi[i] = 6.989999999998;
            ++i; Xi[i] = 6.979999999998;
            ++i; Xi[i] = 6.969999999998;
            ++i; Xi[i] = 6.959999999998;
            ++i; Xi[i] = 6.949999999998;
            ++i; Xi[i] = 6.939999999998;
            ++i; Xi[i] = 6.929999999998;
            ++i; Xi[i] = 6.919999999998;
            ++i; Xi[i] = 6.909999999998;
            ++i; Xi[i] = 6.899999999998;
            ++i; Xi[i] = 6.889999999998;
            ++i; Xi[i] = 6.8799999999979;
            ++i; Xi[i] = 6.8699999999979;
            ++i; Xi[i] = 6.8599999999979;
            ++i; Xi[i] = 6.8499999999979;
            ++i; Xi[i] = 6.8399999999979;
            ++i; Xi[i] = 6.8299999999979;
            ++i; Xi[i] = 6.8199999999979;
            ++i; Xi[i] = 6.8099999999979;
            ++i; Xi[i] = 6.7999999999979;
            ++i; Xi[i] = 6.7899999999979;
            ++i; Xi[i] = 6.7799999999979;
            ++i; Xi[i] = 6.7699999999979;
            ++i; Xi[i] = 6.7599999999979;
            ++i; Xi[i] = 6.7499999999979;
            ++i; Xi[i] = 6.7399999999979;
            ++i; Xi[i] = 6.7299999999979;
            ++i; Xi[i] = 6.7199999999979;
            ++i; Xi[i] = 6.7099999999979;
            ++i; Xi[i] = 6.6999999999979;
            ++i; Xi[i] = 6.6899999999979;
            ++i; Xi[i] = 6.6799999999979;
            ++i; Xi[i] = 6.6699999999979;
            ++i; Xi[i] = 6.6599999999979;
            ++i; Xi[i] = 6.6499999999979;
            ++i; Xi[i] = 6.6399999999979;
            ++i; Xi[i] = 6.6299999999979;
            ++i; Xi[i] = 6.6199999999979;
            ++i; Xi[i] = 6.6099999999979;
            ++i; Xi[i] = 6.5999999999979;
            ++i; Xi[i] = 6.5899999999979;
            ++i; Xi[i] = 6.5799999999979;
            ++i; Xi[i] = 6.5699999999979;
            ++i; Xi[i] = 6.5599999999979;
            ++i; Xi[i] = 6.5499999999979;
            ++i; Xi[i] = 6.5399999999979;
            ++i; Xi[i] = 6.5299999999979;
            ++i; Xi[i] = 6.5199999999979;
            ++i; Xi[i] = 6.5099999999979;
            ++i; Xi[i] = 6.4999999999979;
            ++i; Xi[i] = 6.4899999999979;
            ++i; Xi[i] = 6.4799999999979;
            ++i; Xi[i] = 6.4699999999979;
            ++i; Xi[i] = 6.4599999999979;
            ++i; Xi[i] = 6.4499999999979;
            ++i; Xi[i] = 6.4399999999979;
            ++i; Xi[i] = 6.4299999999979;
            ++i; Xi[i] = 6.4199999999979;
            ++i; Xi[i] = 6.4099999999979;
            ++i; Xi[i] = 6.3999999999979;
            ++i; Xi[i] = 6.3899999999979;
            ++i; Xi[i] = 6.3799999999979;
            ++i; Xi[i] = 6.3699999999979;
            ++i; Xi[i] = 6.3599999999979;
            ++i; Xi[i] = 6.3499999999979;
            ++i; Xi[i] = 6.3399999999979;
            ++i; Xi[i] = 6.3299999999979;
            ++i; Xi[i] = 6.3199999999979;
            ++i; Xi[i] = 6.3099999999979;
            ++i; Xi[i] = 6.2999999999979;
            ++i; Xi[i] = 6.2899999999979;
            ++i; Xi[i] = 6.2799999999979;
            ++i; Xi[i] = 6.2699999999979;
            ++i; Xi[i] = 6.2599999999979;
            ++i; Xi[i] = 6.2499999999979;
            ++i; Xi[i] = 6.2399999999978;
            ++i; Xi[i] = 6.2299999999978;
            ++i; Xi[i] = 6.2199999999978;
            ++i; Xi[i] = 6.2099999999978;
            ++i; Xi[i] = 6.1999999999978;
            ++i; Xi[i] = 6.1899999999978;
            ++i; Xi[i] = 6.1799999999978;
            ++i; Xi[i] = 6.1699999999978;
            ++i; Xi[i] = 6.1599999999978;
            ++i; Xi[i] = 6.1499999999978;
            ++i; Xi[i] = 6.1399999999978;
            ++i; Xi[i] = 6.1299999999978;
            ++i; Xi[i] = 6.1199999999978;
            ++i; Xi[i] = 6.1099999999978;
            ++i; Xi[i] = 6.0999999999978;
            ++i; Xi[i] = 6.0899999999978;
            ++i; Xi[i] = 6.0799999999978;
            ++i; Xi[i] = 6.0699999999978;
            ++i; Xi[i] = 6.0599999999978;
            ++i; Xi[i] = 6.0499999999978;
            ++i; Xi[i] = 6.0399999999978;
            ++i; Xi[i] = 6.0299999999978;
            ++i; Xi[i] = 6.0199999999978;
            ++i; Xi[i] = 6.0099999999978;
            ++i; Xi[i] = 5.9999999999978;
            ++i; Xi[i] = 5.9899999999978;
            ++i; Xi[i] = 5.9799999999978;
            ++i; Xi[i] = 5.9699999999978;
            ++i; Xi[i] = 5.9599999999978;
            ++i; Xi[i] = 5.9499999999978;
            ++i; Xi[i] = 5.9399999999978;
            ++i; Xi[i] = 5.9299999999978;
            ++i; Xi[i] = 5.9199999999978;
            ++i; Xi[i] = 5.9099999999978;
            ++i; Xi[i] = 5.8999999999978;
            ++i; Xi[i] = 5.8899999999978;
            ++i; Xi[i] = 5.8799999999978;
            ++i; Xi[i] = 5.8699999999978;
            ++i; Xi[i] = 5.8599999999978;
            ++i; Xi[i] = 5.8499999999978;
            ++i; Xi[i] = 5.8399999999978;
            ++i; Xi[i] = 5.8299999999978;
            ++i; Xi[i] = 5.8199999999978;
            ++i; Xi[i] = 5.8099999999978;
            ++i; Xi[i] = 5.7999999999978;
            ++i; Xi[i] = 5.7899999999978;
            ++i; Xi[i] = 5.7799999999978;
            ++i; Xi[i] = 5.7699999999978;
            ++i; Xi[i] = 5.7599999999978;
            ++i; Xi[i] = 5.7499999999978;
            ++i; Xi[i] = 5.7399999999978;
            ++i; Xi[i] = 5.7299999999978;
            ++i; Xi[i] = 5.7199999999978;
            ++i; Xi[i] = 5.7099999999978;
            ++i; Xi[i] = 5.6999999999978;
            ++i; Xi[i] = 5.6899999999978;
            ++i; Xi[i] = 5.6799999999978;
            ++i; Xi[i] = 5.6699999999978;
            ++i; Xi[i] = 5.6599999999978;
            ++i; Xi[i] = 5.6499999999978;
            ++i; Xi[i] = 5.6399999999978;
            ++i; Xi[i] = 5.6299999999978;
            ++i; Xi[i] = 5.6199999999978;
            ++i; Xi[i] = 5.6099999999978;
            ++i; Xi[i] = 5.5999999999977;
            ++i; Xi[i] = 5.5899999999977;
            ++i; Xi[i] = 5.5799999999977;
            ++i; Xi[i] = 5.5699999999977;
            ++i; Xi[i] = 5.5599999999977;
            ++i; Xi[i] = 5.5499999999977;
            ++i; Xi[i] = 5.5399999999977;
            ++i; Xi[i] = 5.5299999999977;
            ++i; Xi[i] = 5.5199999999977;
            ++i; Xi[i] = 5.5099999999977;
            ++i; Xi[i] = 5.4999999999977;
            ++i; Xi[i] = 5.4899999999977;
            ++i; Xi[i] = 5.4799999999977;
            ++i; Xi[i] = 5.4699999999977;
            ++i; Xi[i] = 5.4599999999977;
            ++i; Xi[i] = 5.4499999999977;
            ++i; Xi[i] = 5.4399999999977;
            ++i; Xi[i] = 5.4299999999977;
            ++i; Xi[i] = 5.4199999999977;
            ++i; Xi[i] = 5.4099999999977;
            ++i; Xi[i] = 5.3999999999977;
            ++i; Xi[i] = 5.3899999999977;
            ++i; Xi[i] = 5.3799999999977;
            ++i; Xi[i] = 5.3699999999977;
            ++i; Xi[i] = 5.3599999999977;
            ++i; Xi[i] = 5.3499999999977;
            ++i; Xi[i] = 5.3399999999977;
            ++i; Xi[i] = 5.3299999999977;
            ++i; Xi[i] = 5.3199999999977;
            ++i; Xi[i] = 5.3099999999977;
            ++i; Xi[i] = 5.2999999999977;
            ++i; Xi[i] = 5.2899999999977;
            ++i; Xi[i] = 5.2799999999977;
            ++i; Xi[i] = 5.2699999999977;
            ++i; Xi[i] = 5.2599999999977;
            ++i; Xi[i] = 5.2499999999977;
            ++i; Xi[i] = 5.2399999999977;
            ++i; Xi[i] = 5.2299999999977;
            ++i; Xi[i] = 5.2199999999977;
            ++i; Xi[i] = 5.2099999999977;
            ++i; Xi[i] = 5.1999999999977;
            ++i; Xi[i] = 5.1899999999977;
            ++i; Xi[i] = 5.1799999999977;
            ++i; Xi[i] = 5.1699999999977;
            ++i; Xi[i] = 5.1599999999977;
            ++i; Xi[i] = 5.1499999999977;
            ++i; Xi[i] = 5.1399999999977;
            ++i; Xi[i] = 5.1299999999977;
            ++i; Xi[i] = 5.1199999999977;
            ++i; Xi[i] = 5.1099999999977;
            ++i; Xi[i] = 5.0999999999977;
            ++i; Xi[i] = 5.0899999999977;
            ++i; Xi[i] = 5.0799999999977;
            ++i; Xi[i] = 5.0699999999977;
            ++i; Xi[i] = 5.0599999999977;
            ++i; Xi[i] = 5.0499999999977;
            ++i; Xi[i] = 5.0399999999977;
            ++i; Xi[i] = 5.0299999999977;
            ++i; Xi[i] = 5.0199999999977;
            ++i; Xi[i] = 5.0099999999977;
            ++i; Xi[i] = 4.9999999999977;
            ++i; Xi[i] = 4.9899999999977;
            ++i; Xi[i] = 4.9799999999977;
            ++i; Xi[i] = 4.9699999999977;
            ++i; Xi[i] = 4.9599999999976;
            ++i; Xi[i] = 4.9499999999976;
            ++i; Xi[i] = 4.9399999999976;
            ++i; Xi[i] = 4.9299999999976;
            ++i; Xi[i] = 4.9199999999976;
            ++i; Xi[i] = 4.9099999999976;
            ++i; Xi[i] = 4.8999999999976;
            ++i; Xi[i] = 4.8899999999976;
            ++i; Xi[i] = 4.8799999999976;
            ++i; Xi[i] = 4.8699999999976;
            ++i; Xi[i] = 4.8599999999976;
            ++i; Xi[i] = 4.8499999999976;
            ++i; Xi[i] = 4.8399999999976;
            ++i; Xi[i] = 4.8299999999976;
            ++i; Xi[i] = 4.8199999999976;
            ++i; Xi[i] = 4.8099999999976;
            ++i; Xi[i] = 4.7999999999976;
            ++i; Xi[i] = 4.7899999999976;
            ++i; Xi[i] = 4.7799999999976;
            ++i; Xi[i] = 4.7699999999976;
            ++i; Xi[i] = 4.7599999999976;
            ++i; Xi[i] = 4.7499999999976;
            ++i; Xi[i] = 4.7399999999976;
            ++i; Xi[i] = 4.7299999999976;
            ++i; Xi[i] = 4.7199999999976;
            ++i; Xi[i] = 4.7099999999976;
            ++i; Xi[i] = 4.6999999999976;
            ++i; Xi[i] = 4.6899999999976;
            ++i; Xi[i] = 4.6799999999976;
            ++i; Xi[i] = 4.6699999999976;
            ++i; Xi[i] = 4.6599999999976;
            ++i; Xi[i] = 4.6499999999976;
            ++i; Xi[i] = 4.6399999999976;
            ++i; Xi[i] = 4.6299999999976;
            ++i; Xi[i] = 4.6199999999976;
            ++i; Xi[i] = 4.6099999999976;
            ++i; Xi[i] = 4.5999999999976;
            ++i; Xi[i] = 4.5899999999976;
            ++i; Xi[i] = 4.5799999999976;
            ++i; Xi[i] = 4.5699999999976;
            ++i; Xi[i] = 4.5599999999976;
            ++i; Xi[i] = 4.5499999999976;
            ++i; Xi[i] = 4.5399999999976;
            ++i; Xi[i] = 4.5299999999976;
            ++i; Xi[i] = 4.5199999999976;
            ++i; Xi[i] = 4.5099999999976;
            ++i; Xi[i] = 4.4999999999976;
            ++i; Xi[i] = 4.4899999999976;
            ++i; Xi[i] = 4.4799999999976;
            ++i; Xi[i] = 4.4699999999976;
            ++i; Xi[i] = 4.4599999999976;
            ++i; Xi[i] = 4.4499999999976;
            ++i; Xi[i] = 4.4399999999976;
            ++i; Xi[i] = 4.4299999999976;
            ++i; Xi[i] = 4.4199999999976;
            ++i; Xi[i] = 4.4099999999976;
            ++i; Xi[i] = 4.3999999999976;
            ++i; Xi[i] = 4.3899999999976;
            ++i; Xi[i] = 4.3799999999976;
            ++i; Xi[i] = 4.3699999999976;
            ++i; Xi[i] = 4.3599999999976;
            ++i; Xi[i] = 4.3499999999976;
            ++i; Xi[i] = 4.3399999999976;
            ++i; Xi[i] = 4.3299999999976;
            ++i; Xi[i] = 4.3199999999975;
            ++i; Xi[i] = 4.3099999999975;
            ++i; Xi[i] = 4.2999999999975;
            ++i; Xi[i] = 4.2899999999975;
            ++i; Xi[i] = 4.2799999999975;
            ++i; Xi[i] = 4.2699999999975;
            ++i; Xi[i] = 4.2599999999975;
            ++i; Xi[i] = 4.2499999999975;
            ++i; Xi[i] = 4.2399999999975;
            ++i; Xi[i] = 4.2299999999975;
            ++i; Xi[i] = 4.2199999999975;
            ++i; Xi[i] = 4.2099999999975;
            ++i; Xi[i] = 4.1999999999975;
            ++i; Xi[i] = 4.1899999999975;
            ++i; Xi[i] = 4.1799999999975;
            ++i; Xi[i] = 4.1699999999975;
            ++i; Xi[i] = 4.1599999999975;
            ++i; Xi[i] = 4.1499999999975;
            ++i; Xi[i] = 4.1399999999975;
            ++i; Xi[i] = 4.1299999999975;
            ++i; Xi[i] = 4.1199999999975;
            ++i; Xi[i] = 4.1099999999975;
            ++i; Xi[i] = 4.0999999999975;
            ++i; Xi[i] = 4.0899999999975;
            ++i; Xi[i] = 4.0799999999975;
            ++i; Xi[i] = 4.0699999999975;
            ++i; Xi[i] = 4.0599999999975;
            ++i; Xi[i] = 4.0499999999975;
            ++i; Xi[i] = 4.0399999999975;
            ++i; Xi[i] = 4.0299999999975;
            ++i; Xi[i] = 4.0199999999975;
            ++i; Xi[i] = 4.0099999999975;
            ++i; Xi[i] = 3.9999999999975;
            ++i; Xi[i] = 3.9899999999975;
            ++i; Xi[i] = 3.9799999999975;
            ++i; Xi[i] = 3.9699999999975;
            ++i; Xi[i] = 3.9599999999975;
            ++i; Xi[i] = 3.9499999999975;
            ++i; Xi[i] = 3.9399999999975;
            ++i; Xi[i] = 3.9299999999975;
            ++i; Xi[i] = 3.9199999999975;
            ++i; Xi[i] = 3.9099999999975;
            ++i; Xi[i] = 3.8999999999975;
            ++i; Xi[i] = 3.8899999999975;
            ++i; Xi[i] = 3.8799999999975;
            ++i; Xi[i] = 3.8699999999975;
            ++i; Xi[i] = 3.8599999999975;
            ++i; Xi[i] = 3.8499999999975;
            ++i; Xi[i] = 3.8399999999975;
            ++i; Xi[i] = 3.8299999999975;
            ++i; Xi[i] = 3.8199999999975;
            ++i; Xi[i] = 3.8099999999975;
            ++i; Xi[i] = 3.7999999999975;
            ++i; Xi[i] = 3.7899999999975;
            ++i; Xi[i] = 3.7799999999975;
            ++i; Xi[i] = 3.7699999999975;
            ++i; Xi[i] = 3.7599999999975;
            ++i; Xi[i] = 3.7499999999975;
            ++i; Xi[i] = 3.7399999999975;
            ++i; Xi[i] = 3.7299999999975;
            ++i; Xi[i] = 3.7199999999975;
            ++i; Xi[i] = 3.7099999999975;
            ++i; Xi[i] = 3.6999999999975;
            ++i; Xi[i] = 3.6899999999975;
            ++i; Xi[i] = 3.6799999999974;
            ++i; Xi[i] = 3.6699999999974;
            ++i; Xi[i] = 3.6599999999974;
            ++i; Xi[i] = 3.6499999999974;
            ++i; Xi[i] = 3.6399999999974;
            ++i; Xi[i] = 3.6299999999974;
            ++i; Xi[i] = 3.6199999999974;
            ++i; Xi[i] = 3.6099999999974;
            ++i; Xi[i] = 3.5999999999974;
            ++i; Xi[i] = 3.5899999999974;
            ++i; Xi[i] = 3.5799999999974;
            ++i; Xi[i] = 3.5699999999974;
            ++i; Xi[i] = 3.5599999999974;
            ++i; Xi[i] = 3.5499999999974;
            ++i; Xi[i] = 3.5399999999974;
            ++i; Xi[i] = 3.5299999999974;
            ++i; Xi[i] = 3.5199999999974;
            ++i; Xi[i] = 3.5099999999974;
            ++i; Xi[i] = 3.4999999999974;
            ++i; Xi[i] = 3.4899999999974;
            ++i; Xi[i] = 3.4799999999974;
            ++i; Xi[i] = 3.4699999999974;
            ++i; Xi[i] = 3.4599999999974;
            ++i; Xi[i] = 3.4499999999974;
            ++i; Xi[i] = 3.4399999999974;
            ++i; Xi[i] = 3.4299999999974;
            ++i; Xi[i] = 3.4199999999974;
            ++i; Xi[i] = 3.4099999999974;
            ++i; Xi[i] = 3.3999999999974;
            ++i; Xi[i] = 3.3899999999974;
            ++i; Xi[i] = 3.3799999999974;
            ++i; Xi[i] = 3.3699999999974;
            ++i; Xi[i] = 3.3599999999974;
            ++i; Xi[i] = 3.3499999999974;
            ++i; Xi[i] = 3.3399999999974;
            ++i; Xi[i] = 3.3299999999974;
            ++i; Xi[i] = 3.3199999999974;
            ++i; Xi[i] = 3.3099999999974;
            ++i; Xi[i] = 3.2999999999974;
            ++i; Xi[i] = 3.2899999999974;
            ++i; Xi[i] = 3.2799999999974;
            ++i; Xi[i] = 3.2699999999974;
            ++i; Xi[i] = 3.2599999999974;
            ++i; Xi[i] = 3.2499999999974;
            ++i; Xi[i] = 3.2399999999974;
            ++i; Xi[i] = 3.2299999999974;
            ++i; Xi[i] = 3.2199999999974;
            ++i; Xi[i] = 3.2099999999974;
            ++i; Xi[i] = 3.1999999999974;
            ++i; Xi[i] = 3.1899999999974;
            ++i; Xi[i] = 3.1799999999974;
            ++i; Xi[i] = 3.1699999999974;
            ++i; Xi[i] = 3.1599999999974;
            ++i; Xi[i] = 3.1499999999974;
            ++i; Xi[i] = 3.1399999999974;
            ++i; Xi[i] = 3.1299999999974;
            ++i; Xi[i] = 3.1199999999974;
            ++i; Xi[i] = 3.1099999999974;
            ++i; Xi[i] = 3.0999999999974;
            ++i; Xi[i] = 3.0899999999974;
            ++i; Xi[i] = 3.0799999999974;
            ++i; Xi[i] = 3.0699999999974;
            ++i; Xi[i] = 3.0599999999974;
            ++i; Xi[i] = 3.0499999999974;
            ++i; Xi[i] = 3.0399999999973;
            ++i; Xi[i] = 3.0299999999973;
            ++i; Xi[i] = 3.0199999999973;
            ++i; Xi[i] = 3.0099999999973;
            ++i; Xi[i] = 2.9999999999973;
            ++i; Xi[i] = 2.9899999999973;
            ++i; Xi[i] = 2.9799999999973;
            ++i; Xi[i] = 2.9699999999973;
            ++i; Xi[i] = 2.9599999999973;
            ++i; Xi[i] = 2.9499999999973;
            ++i; Xi[i] = 2.9399999999973;
            ++i; Xi[i] = 2.9299999999973;
            ++i; Xi[i] = 2.9199999999973;
            ++i; Xi[i] = 2.9099999999973;
            ++i; Xi[i] = 2.8999999999973;
            ++i; Xi[i] = 2.8899999999973;
            ++i; Xi[i] = 2.8799999999973;
            ++i; Xi[i] = 2.8699999999973;
            ++i; Xi[i] = 2.8599999999973;
            ++i; Xi[i] = 2.8499999999973;
            ++i; Xi[i] = 2.8399999999973;
            ++i; Xi[i] = 2.8299999999973;
            ++i; Xi[i] = 2.8199999999973;
            ++i; Xi[i] = 2.8099999999973;
            ++i; Xi[i] = 2.7999999999973;
            ++i; Xi[i] = 2.7899999999973;
            ++i; Xi[i] = 2.7799999999973;
            ++i; Xi[i] = 2.7699999999973;
            ++i; Xi[i] = 2.7599999999973;
            ++i; Xi[i] = 2.7499999999973;
            ++i; Xi[i] = 2.7399999999973;
            ++i; Xi[i] = 2.7299999999973;
            ++i; Xi[i] = 2.7199999999973;
            ++i; Xi[i] = 2.7099999999973;
            ++i; Xi[i] = 2.6999999999973;
            ++i; Xi[i] = 2.6899999999973;
            ++i; Xi[i] = 2.6799999999973;
            ++i; Xi[i] = 2.6699999999973;
            ++i; Xi[i] = 2.6599999999973;
            ++i; Xi[i] = 2.6499999999973;
            ++i; Xi[i] = 2.6399999999973;
            ++i; Xi[i] = 2.6299999999973;
            ++i; Xi[i] = 2.6199999999973;
            ++i; Xi[i] = 2.6099999999973;
            ++i; Xi[i] = 2.5999999999973;
            ++i; Xi[i] = 2.5899999999973;
            ++i; Xi[i] = 2.5799999999973;
            ++i; Xi[i] = 2.5699999999973;
            ++i; Xi[i] = 2.5599999999973;
            ++i; Xi[i] = 2.5499999999973;
            ++i; Xi[i] = 2.5399999999973;
            ++i; Xi[i] = 2.5299999999973;
            ++i; Xi[i] = 2.5199999999973;
            ++i; Xi[i] = 2.5099999999973;
            ++i; Xi[i] = 2.4999999999973;
            ++i; Xi[i] = 2.4899999999973;
            ++i; Xi[i] = 2.4799999999973;
            ++i; Xi[i] = 2.4699999999973;
            ++i; Xi[i] = 2.4599999999973;
            ++i; Xi[i] = 2.4499999999973;
            ++i; Xi[i] = 2.4399999999973;
            ++i; Xi[i] = 2.4299999999973;
            ++i; Xi[i] = 2.4199999999973;
            ++i; Xi[i] = 2.4099999999973;
            ++i; Xi[i] = 2.3999999999972;
            ++i; Xi[i] = 2.3899999999972;
            ++i; Xi[i] = 2.3799999999972;
            ++i; Xi[i] = 2.3699999999972;
            ++i; Xi[i] = 2.3599999999972;
            ++i; Xi[i] = 2.3499999999972;
            ++i; Xi[i] = 2.3399999999972;
            ++i; Xi[i] = 2.3299999999972;
            ++i; Xi[i] = 2.3199999999972;
            ++i; Xi[i] = 2.3099999999972;
            ++i; Xi[i] = 2.2999999999972;
            ++i; Xi[i] = 2.2899999999972;
            ++i; Xi[i] = 2.2799999999972;
            ++i; Xi[i] = 2.2699999999972;
            ++i; Xi[i] = 2.2599999999972;
            ++i; Xi[i] = 2.2499999999972;
            ++i; Xi[i] = 2.2399999999972;
            ++i; Xi[i] = 2.2299999999972;
            ++i; Xi[i] = 2.2199999999972;
            ++i; Xi[i] = 2.2099999999972;
            ++i; Xi[i] = 2.1999999999972;
            ++i; Xi[i] = 2.1899999999972;
            ++i; Xi[i] = 2.1799999999972;
            ++i; Xi[i] = 2.1699999999972;
            ++i; Xi[i] = 2.1599999999972;
            ++i; Xi[i] = 2.1499999999972;
            ++i; Xi[i] = 2.1399999999972;
            ++i; Xi[i] = 2.1299999999972;
            ++i; Xi[i] = 2.1199999999972;
            ++i; Xi[i] = 2.1099999999972;
            ++i; Xi[i] = 2.0999999999972;
            ++i; Xi[i] = 2.0899999999972;
            ++i; Xi[i] = 2.0799999999972;
            ++i; Xi[i] = 2.0699999999972;
            ++i; Xi[i] = 2.0599999999972;
            ++i; Xi[i] = 2.0499999999972;
            ++i; Xi[i] = 2.0399999999972;
            ++i; Xi[i] = 2.0299999999972;
            ++i; Xi[i] = 2.0199999999972;
            ++i; Xi[i] = 2.0099999999972;
            ++i; Xi[i] = 1.9999999999972;
            ++i; Xi[i] = 1.9899999999972;
            ++i; Xi[i] = 1.9799999999972;
            ++i; Xi[i] = 1.9699999999972;
            ++i; Xi[i] = 1.9599999999972;
            ++i; Xi[i] = 1.9499999999972;
            ++i; Xi[i] = 1.9399999999972;
            ++i; Xi[i] = 1.9299999999972;
            ++i; Xi[i] = 1.9199999999972;
            ++i; Xi[i] = 1.9099999999972;
            ++i; Xi[i] = 1.8999999999972;
            ++i; Xi[i] = 1.8899999999972;
            ++i; Xi[i] = 1.8799999999972;
            ++i; Xi[i] = 1.8699999999972;
            ++i; Xi[i] = 1.8599999999972;
            ++i; Xi[i] = 1.8499999999972;
            ++i; Xi[i] = 1.8399999999972;
            ++i; Xi[i] = 1.8299999999972;
            ++i; Xi[i] = 1.8199999999972;
            ++i; Xi[i] = 1.8099999999972;
            ++i; Xi[i] = 1.7999999999972;
            ++i; Xi[i] = 1.7899999999972;
            ++i; Xi[i] = 1.7799999999972;
            ++i; Xi[i] = 1.7699999999972;
            ++i; Xi[i] = 1.7599999999971;
            ++i; Xi[i] = 1.7499999999971;
            ++i; Xi[i] = 1.7399999999971;
            ++i; Xi[i] = 1.7299999999971;
            ++i; Xi[i] = 1.7199999999971;
            ++i; Xi[i] = 1.7099999999971;
            ++i; Xi[i] = 1.6999999999971;
            ++i; Xi[i] = 1.6899999999971;
            ++i; Xi[i] = 1.6799999999971;
            ++i; Xi[i] = 1.6699999999971;
            ++i; Xi[i] = 1.6599999999971;
            ++i; Xi[i] = 1.6499999999971;
            ++i; Xi[i] = 1.6399999999971;
            ++i; Xi[i] = 1.6299999999971;
            ++i; Xi[i] = 1.6199999999971;
            ++i; Xi[i] = 1.6099999999971;
            ++i; Xi[i] = 1.5999999999971;
            ++i; Xi[i] = 1.5899999999971;
            ++i; Xi[i] = 1.5799999999971;
            ++i; Xi[i] = 1.5699999999971;
            ++i; Xi[i] = 1.5599999999971;
            ++i; Xi[i] = 1.5499999999971;
            ++i; Xi[i] = 1.5399999999971;
            ++i; Xi[i] = 1.5299999999971;
            ++i; Xi[i] = 1.5199999999971;
            ++i; Xi[i] = 1.5099999999971;
            ++i; Xi[i] = 1.4999999999971;
            ++i; Xi[i] = 1.4899999999971;
            ++i; Xi[i] = 1.4799999999971;
            ++i; Xi[i] = 1.4699999999971;
            ++i; Xi[i] = 1.4599999999971;
            ++i; Xi[i] = 1.4499999999971;
            ++i; Xi[i] = 1.4399999999971;
            ++i; Xi[i] = 1.4299999999971;
            ++i; Xi[i] = 1.4199999999971;
            ++i; Xi[i] = 1.4099999999971;
            ++i; Xi[i] = 1.3999999999971;
            ++i; Xi[i] = 1.3899999999971;
            ++i; Xi[i] = 1.3799999999971;
            ++i; Xi[i] = 1.3699999999971;
            ++i; Xi[i] = 1.3599999999971;
            ++i; Xi[i] = 1.3499999999971;
            ++i; Xi[i] = 1.3399999999971;
            ++i; Xi[i] = 1.3299999999971;
            ++i; Xi[i] = 1.3199999999971;
            ++i; Xi[i] = 1.3099999999971;
            ++i; Xi[i] = 1.2999999999971;
            ++i; Xi[i] = 1.2899999999971;
            ++i; Xi[i] = 1.2799999999971;
            ++i; Xi[i] = 1.2699999999971;
            ++i; Xi[i] = 1.2599999999971;
            ++i; Xi[i] = 1.2499999999971;
            ++i; Xi[i] = 1.2399999999971;
            ++i; Xi[i] = 1.2299999999971;
            ++i; Xi[i] = 1.2199999999971;
            ++i; Xi[i] = 1.2099999999971;
            ++i; Xi[i] = 1.1999999999971;
            ++i; Xi[i] = 1.1899999999971;
            ++i; Xi[i] = 1.1799999999971;
            ++i; Xi[i] = 1.1699999999971;
            ++i; Xi[i] = 1.1599999999971;
            ++i; Xi[i] = 1.1499999999971;
            ++i; Xi[i] = 1.1399999999971;
            ++i; Xi[i] = 1.1299999999971;
            ++i; Xi[i] = 1.119999999997;
            ++i; Xi[i] = 1.109999999997;
            ++i; Xi[i] = 1.099999999997;
            ++i; Xi[i] = 1.089999999997;
            ++i; Xi[i] = 1.079999999997;
            ++i; Xi[i] = 1.069999999997;
            ++i; Xi[i] = 1.059999999997;
            ++i; Xi[i] = 1.049999999997;
            ++i; Xi[i] = 1.039999999997;
            ++i; Xi[i] = 1.029999999997;
            ++i; Xi[i] = 1.019999999997;
            ++i; Xi[i] = 1.009999999997;
            ++i; Xi[i] = 0.999999999997002;
            ++i; Xi[i] = 0.989999999997;
            ++i; Xi[i] = 0.979999999996998;
            ++i; Xi[i] = 0.969999999997;
            ++i; Xi[i] = 0.959999999996999;
            ++i; Xi[i] = 0.949999999997001;
            ++i; Xi[i] = 0.939999999996999;
            ++i; Xi[i] = 0.929999999997001;
            ++i; Xi[i] = 0.919999999997;
            ++i; Xi[i] = 0.909999999997002;
            ++i; Xi[i] = 0.899999999997;
            ++i; Xi[i] = 0.889999999996999;
            ++i; Xi[i] = 0.879999999997001;
            ++i; Xi[i] = 0.869999999996999;
            ++i; Xi[i] = 0.859999999997001;
            ++i; Xi[i] = 0.849999999996999;
            ++i; Xi[i] = 0.839999999997001;
            ++i; Xi[i] = 0.829999999997;
            ++i; Xi[i] = 0.819999999996998;
            ++i; Xi[i] = 0.809999999997;
            ++i; Xi[i] = 0.799999999996999;
            ++i; Xi[i] = 0.789999999997001;
            ++i; Xi[i] = 0.779999999996999;
            ++i; Xi[i] = 0.769999999997001;
            ++i; Xi[i] = 0.759999999997;
            ++i; Xi[i] = 0.749999999997002;
            ++i; Xi[i] = 0.739999999997;
            ++i; Xi[i] = 0.729999999996998;
            ++i; Xi[i] = 0.719999999997;
            ++i; Xi[i] = 0.709999999996999;
            ++i; Xi[i] = 0.699999999997001;
            ++i; Xi[i] = 0.689999999996999;
            ++i; Xi[i] = 0.679999999997001;
            ++i; Xi[i] = 0.669999999997;
            ++i; Xi[i] = 0.659999999997002;
            ++i; Xi[i] = 0.649999999997;
            ++i; Xi[i] = 0.639999999996999;
            ++i; Xi[i] = 0.629999999997001;
            ++i; Xi[i] = 0.619999999996999;
            ++i; Xi[i] = 0.609999999997001;
            ++i; Xi[i] = 0.599999999996999;
            ++i; Xi[i] = 0.589999999997001;
            ++i; Xi[i] = 0.579999999997;
            ++i; Xi[i] = 0.569999999996998;
            ++i; Xi[i] = 0.559999999997;
            ++i; Xi[i] = 0.549999999996999;
            ++i; Xi[i] = 0.539999999997001;
            ++i; Xi[i] = 0.529999999996999;
            ++i; Xi[i] = 0.519999999997001;
            ++i; Xi[i] = 0.509999999997;
            ++i; Xi[i] = 0.499999999997002;
            ++i; Xi[i] = 0.489999999997;
            ++i; Xi[i] = 0.479999999996899;
            ++i; Xi[i] = 0.469999999996901;
            ++i; Xi[i] = 0.459999999996899;
            ++i; Xi[i] = 0.449999999996901;
            ++i; Xi[i] = 0.4399999999969;
            ++i; Xi[i] = 0.429999999996902;
            ++i; Xi[i] = 0.4199999999969;
            ++i; Xi[i] = 0.409999999996899;
            ++i; Xi[i] = 0.399999999996901;
            ++i; Xi[i] = 0.389999999996899;
            ++i; Xi[i] = 0.379999999996901;
            ++i; Xi[i] = 0.369999999996899;
            ++i; Xi[i] = 0.359999999996901;
            ++i; Xi[i] = 0.3499999999969;
            ++i; Xi[i] = 0.339999999996898;
            ++i; Xi[i] = 0.3299999999969;
            ++i; Xi[i] = 0.319999999996899;
            ++i; Xi[i] = 0.309999999996901;
            ++i; Xi[i] = 0.299999999996899;
            ++i; Xi[i] = 0.289999999996901;
            ++i; Xi[i] = 0.2799999999969;
            ++i; Xi[i] = 0.269999999996902;
            ++i; Xi[i] = 0.2599999999969;
            ++i; Xi[i] = 0.249999999996898;
            ++i; Xi[i] = 0.2399999999969;
            ++i; Xi[i] = 0.229999999996899;
            ++i; Xi[i] = 0.219999999996901;
            ++i; Xi[i] = 0.209999999996899;
            ++i; Xi[i] = 0.199999999996901;
            ++i; Xi[i] = 0.1899999999969;
            ++i; Xi[i] = 0.179999999996902;
            ++i; Xi[i] = 0.1699999999969;
            ++i; Xi[i] = 0.159999999996899;
            ++i; Xi[i] = 0.149999999996901;
            ++i; Xi[i] = 0.139999999996899;
            ++i; Xi[i] = 0.129999999996901;
            ++i; Xi[i] = 0.119999999996899;
            ++i; Xi[i] = 0.109999999996901;
            ++i; Xi[i] = 0.0999999999968999;
            ++i; Xi[i] = 0.0899999999968983;
            ++i; Xi[i] = 0.0799999999969003;
            ++i; Xi[i] = 0.0699999999968988;
            ++i; Xi[i] = 0.05;
            ++i; Xi[i] = 0.04;
            ++i; Xi[i] = 0.03;
            ++i; Xi[i] = 0.02;
            ++i; Xi[i] = 0.01;
            ++i; Xi[i] = 0.00;
            ++i; Xi[i] = 0;
        }
        /// <summary>
        /// Finds the umicron.
        /// </summary>
        /// <param name="Uin">The uin.</param>
        /// <returns></returns>
        public int FindUmicron(double Uin)
        {
            double min;
            int c = 0;
            SetUMicronOutMas();
            for (int i = 0; i < UMicronOut.Length; i++)
            {
                min = UMicronOut[i] / Uin;
                if (min > 0.99 && min < 1.01)
                {
                    c = i;
                }
            }
            return c;
        }

    public double XiVal_1(double Uin)
    {
        //return 19.5047 * Uin +2.8923;
        return 19.411155 * Uin + 2.98926;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Uin"></param>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    public double XiVal_Law_linear(double Uin,double A, double B)
    {
        //return 19.5047 * Uin +2.8923;
        return A * Uin + B;
    }

    public double XiVal(int i)
        {
            SetXiMas();
            return Xi[i];
        }

        /// <summary>
        /// Sets the nu mas.
        /// </summary>
        public void SetNuMas()
        {
            int masSize = 462;
            nu = new double[masSize];
            int i = 1;
            nu[i] = 1.94359;
            ++i; nu[i] = 1.94429;
            ++i; nu[i] = 1.94498;
            ++i; nu[i] = 1.94567;
            ++i; nu[i] = 1.94637;
            ++i; nu[i] = 1.94706;
            ++i; nu[i] = 1.94775;
            ++i; nu[i] = 1.94844;
            ++i; nu[i] = 1.94914;
            ++i; nu[i] = 1.94983;
            ++i; nu[i] = 1.95052;
            ++i; nu[i] = 1.95121;
            ++i; nu[i] = 1.95190;
            ++i; nu[i] = 1.95260;
            ++i; nu[i] = 1.95309;
            ++i; nu[i] = 1.95394;
            ++i; nu[i] = 1.95465;
            ++i; nu[i] = 1.95533;
            ++i; nu[i] = 1.95602;
            ++i; nu[i] = 1.95670;
            ++i; nu[i] = 1.95739;
            ++i; nu[i] = 1.95807;
            ++i; nu[i] = 1.95876;
            ++i; nu[i] = 1.95944;
            ++i; nu[i] = 1.96013;
            ++i; nu[i] = 1.96081;
            ++i; nu[i] = 1.96149;
            ++i; nu[i] = 1.96218;
            ++i; nu[i] = 1.96286;
            ++i; nu[i] = 1.96354;
            ++i; nu[i] = 1.96422;
            ++i; nu[i] = 1.96490;
            ++i; nu[i] = 1.96558;
            ++i; nu[i] = 1.96626;
            ++i; nu[i] = 1.96694;
            ++i; nu[i] = 1.96761;
            ++i; nu[i] = 1.96829;
            ++i; nu[i] = 1.96897;
            ++i; nu[i] = 1.96965;
            ++i; nu[i] = 1.97032;
            ++i; nu[i] = 1.97100;
            ++i; nu[i] = 1.97167;
            ++i; nu[i] = 1.97235;
            ++i; nu[i] = 1.97302;
            ++i; nu[i] = 1.97370;
            ++i; nu[i] = 1.97437;
            ++i; nu[i] = 1.97504;
            ++i; nu[i] = 1.97572;
            ++i; nu[i] = 1.97639;
            ++i; nu[i] = 1.97706;
            ++i; nu[i] = 1.97773;
            ++i; nu[i] = 1.97840;
            ++i; nu[i] = 1.97907;
            ++i; nu[i] = 1.97974;
            ++i; nu[i] = 1.98041;
            ++i; nu[i] = 1.98108;
            ++i; nu[i] = 1.98175;
            ++i; nu[i] = 1.98242;
            ++i; nu[i] = 1.98309;
            ++i; nu[i] = 1.98375;
            ++i; nu[i] = 1.98442;
            ++i; nu[i] = 1.98509;
            ++i; nu[i] = 1.98575;
            ++i; nu[i] = 1.98642;
            ++i; nu[i] = 1.98708;
            ++i; nu[i] = 1.98774;
            ++i; nu[i] = 1.98841;
            ++i; nu[i] = 1.98907;
            ++i; nu[i] = 1.98974;
            ++i; nu[i] = 1.99040;
            ++i; nu[i] = 1.99106;
            ++i; nu[i] = 1.99172;
            ++i; nu[i] = 1.99238;
            ++i; nu[i] = 1.99304;
            ++i; nu[i] = 1.99370;
            ++i; nu[i] = 1.99436;
            ++i; nu[i] = 1.99503;
            ++i; nu[i] = 1.99568;
            ++i; nu[i] = 1.99634;
            ++i; nu[i] = 1.99700;
            ++i; nu[i] = 1.99766;
            ++i; nu[i] = 1.99832;
            ++i; nu[i] = 1.99897;
            ++i; nu[i] = 1.99963;
            ++i; nu[i] = 2.00028;
            ++i; nu[i] = 2.00094;
            ++i; nu[i] = 2.00160;
            ++i; nu[i] = 2.00225;
            ++i; nu[i] = 2.00290;
            ++i; nu[i] = 2.00356;
            ++i; nu[i] = 2.00421;
            ++i; nu[i] = 2.00486;
            ++i; nu[i] = 2.00551;
            ++i; nu[i] = 2.00616;
            ++i; nu[i] = 2.00681;
            ++i; nu[i] = 2.00746;
            ++i; nu[i] = 2.00811;
            ++i; nu[i] = 2.00876;
            ++i; nu[i] = 2.00941;
            ++i; nu[i] = 2.01006;
            ++i; nu[i] = 2.01071;
            ++i; nu[i] = 2.01136;
            ++i; nu[i] = 2.01201;
            ++i; nu[i] = 2.01265;
            ++i; nu[i] = 2.01330;
            ++i; nu[i] = 2.01395;
            ++i; nu[i] = 2.01460;
            ++i; nu[i] = 2.01525;
            ++i; nu[i] = 2.01589;
            ++i; nu[i] = 2.01635;
            ++i; nu[i] = 2.01718;
            ++i; nu[i] = 2.01782;
            ++i; nu[i] = 2.01847;
            ++i; nu[i] = 2.01911;
            ++i; nu[i] = 2.01975;
            ++i; nu[i] = 2.02039;
            ++i; nu[i] = 2.02104;
            ++i; nu[i] = 2.02168;
            ++i; nu[i] = 2.02232;
            ++i; nu[i] = 2.02296;
            ++i; nu[i] = 2.02360;
            ++i; nu[i] = 2.02424;
            ++i; nu[i] = 2.02488;
            ++i; nu[i] = 2.02552;
            ++i; nu[i] = 2.02616;
            ++i; nu[i] = 2.02679;
            ++i; nu[i] = 2.02743;
            ++i; nu[i] = 2.02807;
            ++i; nu[i] = 2.02871;
            ++i; nu[i] = 2.02934;
            ++i; nu[i] = 2.02998;
            ++i; nu[i] = 2.03061;
            ++i; nu[i] = 2.03125;
            ++i; nu[i] = 2.03188;
            ++i; nu[i] = 2.03252;
            ++i; nu[i] = 2.03315;
            ++i; nu[i] = 2.03378;
            ++i; nu[i] = 2.03442;
            ++i; nu[i] = 2.03505;
            ++i; nu[i] = 2.03568;
            ++i; nu[i] = 2.03631;
            ++i; nu[i] = 2.03694;
            ++i; nu[i] = 2.03757;
            ++i; nu[i] = 2.03820;
            ++i; nu[i] = 2.03883;
            ++i; nu[i] = 2.03946;
            ++i; nu[i] = 2.04009;
            ++i; nu[i] = 2.04072;
            ++i; nu[i] = 2.04135;
            ++i; nu[i] = 2.04197;
            ++i; nu[i] = 2.04260;
            ++i; nu[i] = 2.04323;
            ++i; nu[i] = 2.04385;
            ++i; nu[i] = 2.04448;
            ++i; nu[i] = 2.04511;
            ++i; nu[i] = 2.04573;
            ++i; nu[i] = 2.04637;
            ++i; nu[i] = 2.04699;
            ++i; nu[i] = 2.04761;
            ++i; nu[i] = 2.04824;
            ++i; nu[i] = 2.04886;
            ++i; nu[i] = 2.04948;
            ++i; nu[i] = 2.05011;
            ++i; nu[i] = 2.05073;
            ++i; nu[i] = 2.05135;
            ++i; nu[i] = 2.05197;
            ++i; nu[i] = 2.05259;
            ++i; nu[i] = 2.05321;
            ++i; nu[i] = 2.05383;
            ++i; nu[i] = 2.05445;
            ++i; nu[i] = 2.05507;
            ++i; nu[i] = 2.05569;
            ++i; nu[i] = 2.05631;
            ++i; nu[i] = 2.05692;
            ++i; nu[i] = 2.05754;
            ++i; nu[i] = 2.05816;
            ++i; nu[i] = 2.05878;
            ++i; nu[i] = 2.05939;
            ++i; nu[i] = 2.06001;
            ++i; nu[i] = 2.06062;
            ++i; nu[i] = 2.06124;
            ++i; nu[i] = 2.06185;
            ++i; nu[i] = 2.06247;
            ++i; nu[i] = 2.06308;
            ++i; nu[i] = 2.06370;
            ++i; nu[i] = 2.06431;
            ++i; nu[i] = 2.06492;
            ++i; nu[i] = 2.06553;
            ++i; nu[i] = 2.06615;
            ++i; nu[i] = 2.06676;
            ++i; nu[i] = 2.06737;
            ++i; nu[i] = 2.06798;
            ++i; nu[i] = 2.06859;
            ++i; nu[i] = 2.06920;
            ++i; nu[i] = 2.06981;
            ++i; nu[i] = 2.07042;
            ++i; nu[i] = 2.07103;
            ++i; nu[i] = 2.07164;
            ++i; nu[i] = 2.07225;
            ++i; nu[i] = 2.07285;
            ++i; nu[i] = 2.07346;
            ++i; nu[i] = 2.07407;
            ++i; nu[i] = 2.07467;
            ++i; nu[i] = 2.07528;
            ++i; nu[i] = 2.07588;
            ++i; nu[i] = 2.07649;
            ++i; nu[i] = 2.07709;
            ++i; nu[i] = 2.07770;
            ++i; nu[i] = 2.07830;
            ++i; nu[i] = 2.07891;
            ++i; nu[i] = 2.07951;
            ++i; nu[i] = 2.08011;
            ++i; nu[i] = 2.08072;
            ++i; nu[i] = 2.08132;
            ++i; nu[i] = 2.08191;
            ++i; nu[i] = 2.08252;
            ++i; nu[i] = 2.08316;
            ++i; nu[i] = 2.08375;
            ++i; nu[i] = 2.08433;
            ++i; nu[i] = 2.08493;
            ++i; nu[i] = 2.08553;
            ++i; nu[i] = 2.08613;
            ++i; nu[i] = 2.08673;
            ++i; nu[i] = 2.08733;
            ++i; nu[i] = 2.08792;
            ++i; nu[i] = 2.08852;
            ++i; nu[i] = 2.08912;
            ++i; nu[i] = 2.08971;
            ++i; nu[i] = 2.09031;
            ++i; nu[i] = 2.09090;
            ++i; nu[i] = 2.09150;
            ++i; nu[i] = 2.09209;
            ++i; nu[i] = 2.09269;
            ++i; nu[i] = 2.09328;
            ++i; nu[i] = 2.09388;
            ++i; nu[i] = 2.09447;
            ++i; nu[i] = 2.09507;
            ++i; nu[i] = 2.09566;
            ++i; nu[i] = 2.09625;
            ++i; nu[i] = 2.09685;
            ++i; nu[i] = 2.09744;
            ++i; nu[i] = 2.09803;
            ++i; nu[i] = 2.09862;
            ++i; nu[i] = 2.09921;
            ++i; nu[i] = 2.09980;
            ++i; nu[i] = 2.10039;
            ++i; nu[i] = 2.10098;
            ++i; nu[i] = 2.10157;
            ++i; nu[i] = 2.10216;
            ++i; nu[i] = 2.10275;
            ++i; nu[i] = 2.10344;
            ++i; nu[i] = 2.10393;
            ++i; nu[i] = 2.10451;
            ++i; nu[i] = 2.10510;
            ++i; nu[i] = 2.10569;
            ++i; nu[i] = 2.10627;
            ++i; nu[i] = 2.10686;
            ++i; nu[i] = 2.10744;
            ++i; nu[i] = 2.10803;
            ++i; nu[i] = 2.10861;
            ++i; nu[i] = 2.10920;
            ++i; nu[i] = 2.10978;
            ++i; nu[i] = 2.11037;
            ++i; nu[i] = 2.11095;
            ++i; nu[i] = 2.11153;
            ++i; nu[i] = 2.11212;
            ++i; nu[i] = 2.11270;
            ++i; nu[i] = 2.11328;
            ++i; nu[i] = 2.11397;
            ++i; nu[i] = 2.11445;
            ++i; nu[i] = 2.11503;
            ++i; nu[i] = 2.11561;
            ++i; nu[i] = 2.11619;
            ++i; nu[i] = 2.11677;
            ++i; nu[i] = 2.11735;
            ++i; nu[i] = 2.11793;
            ++i; nu[i] = 2.11851;
            ++i; nu[i] = 2.11909;
            ++i; nu[i] = 2.11967;
            ++i; nu[i] = 2.12024;
            ++i; nu[i] = 2.12082;
            ++i; nu[i] = 2.12140;
            ++i; nu[i] = 2.12197;
            ++i; nu[i] = 2.12255;
            ++i; nu[i] = 2.12312;
            ++i; nu[i] = 2.12370;
            ++i; nu[i] = 2.12427;
            ++i; nu[i] = 2.12485;
            ++i; nu[i] = 2.12542;
            ++i; nu[i] = 2.12600;
            ++i; nu[i] = 2.12657;
            ++i; nu[i] = 2.12714;
            ++i; nu[i] = 2.12772;
            ++i; nu[i] = 2.12829;
            ++i; nu[i] = 2.12886;
            ++i; nu[i] = 2.12943;
            ++i; nu[i] = 2.13001;
            ++i; nu[i] = 2.13058;
            ++i; nu[i] = 2.13115;
            ++i; nu[i] = 2.13172;
            ++i; nu[i] = 2.13229;
            ++i; nu[i] = 2.13286;
            ++i; nu[i] = 2.13343;
            ++i; nu[i] = 2.13400;
            ++i; nu[i] = 2.13457;
            ++i; nu[i] = 2.13514;
            ++i; nu[i] = 2.13571;
            ++i; nu[i] = 2.13627;
            ++i; nu[i] = 2.13684;
            ++i; nu[i] = 2.13741;
            ++i; nu[i] = 2.13798;
            ++i; nu[i] = 2.13855;
            ++i; nu[i] = 2.13912;
            ++i; nu[i] = 2.13969;
            ++i; nu[i] = 2.14027;
            ++i; nu[i] = 2.14018;
            ++i; nu[i] = 2.14137;
            ++i; nu[i] = 2.14193;
            ++i; nu[i] = 2.14249;
            ++i; nu[i] = 2.14306;
            ++i; nu[i] = 2.14362;
            ++i; nu[i] = 2.14418;
            ++i; nu[i] = 2.14475;
            ++i; nu[i] = 2.14531;
            ++i; nu[i] = 2.14587;
            ++i; nu[i] = 2.14643;
            ++i; nu[i] = 2.14700;
            ++i; nu[i] = 2.14756;
            ++i; nu[i] = 2.14812;
            ++i; nu[i] = 2.14868;
            ++i; nu[i] = 2.14924;
            ++i; nu[i] = 2.14980;
            ++i; nu[i] = 2.15036;
            ++i; nu[i] = 2.15092;
            ++i; nu[i] = 2.15148;
            ++i; nu[i] = 2.15203;
            ++i; nu[i] = 2.15259;
            ++i; nu[i] = 2.15315;
            ++i; nu[i] = 2.15371;
            ++i; nu[i] = 2.15426;
            ++i; nu[i] = 2.15482;
            ++i; nu[i] = 2.15537;
            ++i; nu[i] = 2.15593;
            ++i; nu[i] = 2.15649;
            ++i; nu[i] = 2.15704;
            ++i; nu[i] = 2.15760;
            ++i; nu[i] = 2.15815;
            ++i; nu[i] = 2.15870;
            ++i; nu[i] = 2.15925;
            ++i; nu[i] = 2.15981;
            ++i; nu[i] = 2.16036;
            ++i; nu[i] = 2.16091;
            ++i; nu[i] = 2.16147;
            ++i; nu[i] = 2.16202;
            ++i; nu[i] = 2.16257;
            ++i; nu[i] = 2.16312;
            ++i; nu[i] = 2.16368;
            ++i; nu[i] = 2.16423;
            ++i; nu[i] = 2.16478;
            ++i; nu[i] = 2.16533;
            ++i; nu[i] = 2.16588;
            ++i; nu[i] = 2.16643;
            ++i; nu[i] = 2.16698;
            ++i; nu[i] = 2.16753;
            ++i; nu[i] = 2.16808;
            ++i; nu[i] = 2.16862;
            ++i; nu[i] = 2.16917;
            ++i; nu[i] = 2.16972;
            ++i; nu[i] = 2.17027;
            ++i; nu[i] = 2.17081;
            ++i; nu[i] = 2.17136;
            ++i; nu[i] = 2.17191;
            ++i; nu[i] = 2.17245;
            ++i; nu[i] = 2.17299;
            ++i; nu[i] = 2.17354;
            ++i; nu[i] = 2.17408;
            ++i; nu[i] = 2.17463;
            ++i; nu[i] = 2.17518;
            ++i; nu[i] = 2.17571;
            ++i; nu[i] = 2.17626;
            ++i; nu[i] = 2.17680;
            ++i; nu[i] = 2.17734;
            ++i; nu[i] = 2.17789;
            ++i; nu[i] = 2.17843;
            ++i; nu[i] = 2.17897;
            ++i; nu[i] = 2.17952;
            ++i; nu[i] = 2.18006;
            ++i; nu[i] = 2.18060;
            ++i; nu[i] = 2.18114;
            ++i; nu[i] = 2.18168;
            ++i; nu[i] = 2.18222;
            ++i; nu[i] = 2.18276;
            ++i; nu[i] = 2.18330;
            ++i; nu[i] = 2.18384;
            ++i; nu[i] = 2.18438;
            ++i; nu[i] = 2.18491;
            ++i; nu[i] = 2.18545;
            ++i; nu[i] = 2.18599;
            ++i; nu[i] = 2.18653;
            ++i; nu[i] = 2.18706;
            ++i; nu[i] = 2.18760;
            ++i; nu[i] = 2.18814;
            ++i; nu[i] = 2.18867;
            ++i; nu[i] = 2.18921;
            ++i; nu[i] = 2.18974;
            ++i; nu[i] = 2.19028;
            ++i; nu[i] = 2.19081;
            ++i; nu[i] = 2.19135;
            ++i; nu[i] = 2.19188;
            ++i; nu[i] = 2.19241;
            ++i; nu[i] = 2.19295;
            ++i; nu[i] = 2.19348;
            ++i; nu[i] = 2.19402;
            ++i; nu[i] = 2.19455;
            ++i; nu[i] = 2.19508;
            ++i; nu[i] = 2.19561;
            ++i; nu[i] = 2.19614;
            ++i; nu[i] = 2.19668;
            ++i; nu[i] = 2.19721;
            ++i; nu[i] = 2.19774;
            ++i; nu[i] = 2.19827;
            ++i; nu[i] = 2.19880;
            ++i; nu[i] = 2.19933;
            ++i; nu[i] = 2.19986;
            ++i; nu[i] = 2.20039;
            ++i; nu[i] = 2.20093;
            ++i; nu[i] = 2.20144;
            ++i; nu[i] = 2.20197;
            ++i; nu[i] = 2.20249;
            ++i; nu[i] = 2.20302;
            ++i; nu[i] = 2.20355;
            ++i; nu[i] = 2.20408;
            ++i; nu[i] = 2.20460;
            ++i; nu[i] = 2.20513;
            ++i; nu[i] = 2.20566;
            ++i; nu[i] = 2.20619;
            ++i; nu[i] = 2.20671;
            ++i; nu[i] = 2.20723;
            ++i; nu[i] = 2.20776;
            ++i; nu[i] = 2.20828;
            ++i; nu[i] = 2.20881;
            ++i; nu[i] = 2.20933;
            ++i; nu[i] = 2.20986;
            ++i; nu[i] = 2.21038;
            ++i; nu[i] = 2.21091;
            ++i; nu[i] = 2.21143;
            ++i; nu[i] = 2.21194;
            ++i; nu[i] = 2.21247;
            ++i; nu[i] = 2.21299;
            ++i; nu[i] = 2.21351;
            ++i; nu[i] = 2.21403;
            ++i; nu[i] = 2.21455;
            ++i; nu[i] = 2.21507;
            ++i; nu[i] = 2.21559;
            ++i; nu[i] = 2.21611;
            ++i; nu[i] = 2.21663;
            ++i; nu[i] = 2.21715;
            ++i; nu[i] = 2.21767;
            ++i; nu[i] = 2.21819;
            ++i; nu[i] = 2.21871;
            ++i; nu[i] = 2.21923;

        }
        /// <summary>
        /// Set beta array
        /// </summary>
        public void SetBetaMas()
        {
            int MasSize = 462; ;
            int i = 0;
            beta = new double[MasSize];
            beta[i] = 2.75705;
            ++i; beta[i] = 2.75617;
            ++i; beta[i] = 2.75528;
            ++i; beta[i] = 2.75440;
            ++i; beta[i] = 2.75352;
            ++i; beta[i] = 2.75264;
            ++i; beta[i] = 2.75176;
            ++i; beta[i] = 2.75089;
            ++i; beta[i] = 2.75001;
            ++i; beta[i] = 2.74913;
            ++i; beta[i] = 2.74826;
            ++i; beta[i] = 2.74739;
            ++i; beta[i] = 2.74652;
            ++i; beta[i] = 2.74565;
            ++i; beta[i] = 2.74478;
            ++i; beta[i] = 2.74391;
            ++i; beta[i] = 2.74304;
            ++i; beta[i] = 2.74218;
            ++i; beta[i] = 2.74131;
            ++i; beta[i] = 2.74045;
            ++i; beta[i] = 2.73959;
            ++i; beta[i] = 2.73873;
            ++i; beta[i] = 2.73787;
            ++i; beta[i] = 2.73702;
            ++i; beta[i] = 2.73616;
            ++i; beta[i] = 2.73530;
            ++i; beta[i] = 2.73445;
            ++i; beta[i] = 2.73360;
            ++i; beta[i] = 2.73275;
            ++i; beta[i] = 2.73190;
            ++i; beta[i] = 2.73105;
            ++i; beta[i] = 2.73020;
            ++i; beta[i] = 2.72936;
            ++i; beta[i] = 2.72851;
            ++i; beta[i] = 2.72767;
            ++i; beta[i] = 2.72682;
            ++i; beta[i] = 2.72598;
            ++i; beta[i] = 2.72514;
            ++i; beta[i] = 2.72430;
            ++i; beta[i] = 2.72347;
            ++i; beta[i] = 2.72263;
            ++i; beta[i] = 2.72180;
            ++i; beta[i] = 2.72096;
            ++i; beta[i] = 2.72013;
            ++i; beta[i] = 2.71930;
            ++i; beta[i] = 2.71847;
            ++i; beta[i] = 2.71765;
            ++i; beta[i] = 2.71682;
            ++i; beta[i] = 2.71599;
            ++i; beta[i] = 2.71516;
            ++i; beta[i] = 2.71434;
            ++i; beta[i] = 2.71352;
            ++i; beta[i] = 2.71270;
            ++i; beta[i] = 2.71187;
            ++i; beta[i] = 2.71105;
            ++i; beta[i] = 2.71024;
            ++i; beta[i] = 2.70942;
            ++i; beta[i] = 2.70860;
            ++i; beta[i] = 2.70779;
            ++i; beta[i] = 2.70697;
            ++i; beta[i] = 2.70616;
            ++i; beta[i] = 2.70535;
            ++i; beta[i] = 2.70454;
            ++i; beta[i] = 2.70373;
            ++i; beta[i] = 2.70292;
            ++i; beta[i] = 2.70212;
            ++i; beta[i] = 2.70131;
            ++i; beta[i] = 2.70051;
            ++i; beta[i] = 2.69970;
            ++i; beta[i] = 2.69890;
            ++i; beta[i] = 2.69810;
            ++i; beta[i] = 2.69730;
            ++i; beta[i] = 2.69650;
            ++i; beta[i] = 2.69571;
            ++i; beta[i] = 2.69491;
            ++i; beta[i] = 2.69412;
            ++i; beta[i] = 2.69332;
            ++i; beta[i] = 2.69253;
            ++i; beta[i] = 2.69174;
            ++i; beta[i] = 2.69095;
            ++i; beta[i] = 2.69016;
            ++i; beta[i] = 2.68937;
            ++i; beta[i] = 2.68858;
            ++i; beta[i] = 2.68780;
            ++i; beta[i] = 2.68730;
            ++i; beta[i] = 2.68622;
            ++i; beta[i] = 2.68544;
            ++i; beta[i] = 2.68466;
            ++i; beta[i] = 2.68388;
            ++i; beta[i] = 2.68310;
            ++i; beta[i] = 2.68232;
            ++i; beta[i] = 2.68154;
            ++i; beta[i] = 2.68077;
            ++i; beta[i] = 2.67999;
            ++i; beta[i] = 2.67922;
            ++i; beta[i] = 2.67845;
            ++i; beta[i] = 2.67767;
            ++i; beta[i] = 2.67691;
            ++i; beta[i] = 2.67614;
            ++i; beta[i] = 2.67537;
            ++i; beta[i] = 2.67460;
            ++i; beta[i] = 2.67383;
            ++i; beta[i] = 2.67307;
            ++i; beta[i] = 2.67230;
            ++i; beta[i] = 2.67154;
            ++i; beta[i] = 2.67078;
            ++i; beta[i] = 2.67002;
            ++i; beta[i] = 2.66926;
            ++i; beta[i] = 2.66850;
            ++i; beta[i] = 2.66774;
            ++i; beta[i] = 2.66698;
            ++i; beta[i] = 2.66622;
            ++i; beta[i] = 2.66547;
            ++i; beta[i] = 2.66472;
            ++i; beta[i] = 2.66396;
            ++i; beta[i] = 2.66321;
            ++i; beta[i] = 2.66246;
            ++i; beta[i] = 2.66171;
            ++i; beta[i] = 2.66096;
            ++i; beta[i] = 2.66022;
            ++i; beta[i] = 2.65947;
            ++i; beta[i] = 2.65872;
            ++i; beta[i] = 2.65798;
            ++i; beta[i] = 2.65724;
            ++i; beta[i] = 2.65649;
            ++i; beta[i] = 2.65575;
            ++i; beta[i] = 2.65501;
            ++i; beta[i] = 2.65427;
            ++i; beta[i] = 2.65353;
            ++i; beta[i] = 2.65280;
            ++i; beta[i] = 2.65206;
            ++i; beta[i] = 2.65132;
            ++i; beta[i] = 2.65059;
            ++i; beta[i] = 2.64986;
            ++i; beta[i] = 2.64912;
            ++i; beta[i] = 2.64839;
            ++i; beta[i] = 2.64766;
            ++i; beta[i] = 2.64693;
            ++i; beta[i] = 2.64620;
            ++i; beta[i] = 2.64548;
            ++i; beta[i] = 2.64475;
            ++i; beta[i] = 2.64402;
            ++i; beta[i] = 2.64330;
            ++i; beta[i] = 2.64258;
            ++i; beta[i] = 2.64185;
            ++i; beta[i] = 2.64113;
            ++i; beta[i] = 2.64041;
            ++i; beta[i] = 2.63969;
            ++i; beta[i] = 2.63897;
            ++i; beta[i] = 2.63826;
            ++i; beta[i] = 2.63754;
            ++i; beta[i] = 2.63683;
            ++i; beta[i] = 2.63611;
            ++i; beta[i] = 2.63540;
            ++i; beta[i] = 2.63469;
            ++i; beta[i] = 2.63397;
            ++i; beta[i] = 2.63326;
            ++i; beta[i] = 2.63255;
            ++i; beta[i] = 2.63184;
            ++i; beta[i] = 2.63114;
            ++i; beta[i] = 2.63043;
            ++i; beta[i] = 2.62972;
            ++i; beta[i] = 2.62902;
            ++i; beta[i] = 2.62831;
            ++i; beta[i] = 2.62761;
            ++i; beta[i] = 2.62691;
            ++i; beta[i] = 2.62621;
            ++i; beta[i] = 2.62551;
            ++i; beta[i] = 2.62481;
            ++i; beta[i] = 2.62411;
            ++i; beta[i] = 2.62341;
            ++i; beta[i] = 2.62271;
            ++i; beta[i] = 2.62202;
            ++i; beta[i] = 2.62132;
            ++i; beta[i] = 2.62063;
            ++i; beta[i] = 2.61993;
            ++i; beta[i] = 2.61924;
            ++i; beta[i] = 2.61855;
            ++i; beta[i] = 2.61786;
            ++i; beta[i] = 2.61717;
            ++i; beta[i] = 2.61648;
            ++i; beta[i] = 2.61579;
            ++i; beta[i] = 2.61511;
            ++i; beta[i] = 2.61442;
            ++i; beta[i] = 2.61374;
            ++i; beta[i] = 2.61305;
            ++i; beta[i] = 2.61237;
            ++i; beta[i] = 2.61169;
            ++i; beta[i] = 2.61101;
            ++i; beta[i] = 2.61033;
            ++i; beta[i] = 2.60965;
            ++i; beta[i] = 2.60897;
            ++i; beta[i] = 2.60830;
            ++i; beta[i] = 2.60762;
            ++i; beta[i] = 2.60694;
            ++i; beta[i] = 2.60627;
            ++i; beta[i] = 2.60560;
            ++i; beta[i] = 2.60492;
            ++i; beta[i] = 2.60425;
            ++i; beta[i] = 2.60358;
            ++i; beta[i] = 2.60291;
            ++i; beta[i] = 2.60224;
            ++i; beta[i] = 2.60157;
            ++i; beta[i] = 2.60090;
            ++i; beta[i] = 2.60024;
            ++i; beta[i] = 2.59957;
            ++i; beta[i] = 2.59890;
            ++i; beta[i] = 2.59824;
            ++i; beta[i] = 2.59757;
            ++i; beta[i] = 2.59691;
            ++i; beta[i] = 2.59625;
            ++i; beta[i] = 2.59559;
            ++i; beta[i] = 2.59493;
            ++i; beta[i] = 2.59427;
            ++i; beta[i] = 2.59361;
            ++i; beta[i] = 2.59296;
            ++i; beta[i] = 2.59230;
            ++i; beta[i] = 2.59164;
            ++i; beta[i] = 2.59099;
            ++i; beta[i] = 2.59033;
            ++i; beta[i] = 2.58968;
            ++i; beta[i] = 2.58903;
            ++i; beta[i] = 2.58838;
            ++i; beta[i] = 2.58772;
            ++i; beta[i] = 2.58707;
            ++i; beta[i] = 2.58642;
            ++i; beta[i] = 2.58578;
            ++i; beta[i] = 2.58513;
            ++i; beta[i] = 2.58448;
            ++i; beta[i] = 2.58384;
            ++i; beta[i] = 2.58319;
            ++i; beta[i] = 2.58255;
            ++i; beta[i] = 2.58190;
            ++i; beta[i] = 2.58126;
            ++i; beta[i] = 2.58062;
            ++i; beta[i] = 2.57998;
            ++i; beta[i] = 2.59934;
            ++i; beta[i] = 2.57870;
            ++i; beta[i] = 2.57806;
            ++i; beta[i] = 2.57743;
            ++i; beta[i] = 2.57679;
            ++i; beta[i] = 2.57615;
            ++i; beta[i] = 2.57552;
            ++i; beta[i] = 2.57489;
            ++i; beta[i] = 2.57425;
            ++i; beta[i] = 2.57362;
            ++i; beta[i] = 2.57299;
            ++i; beta[i] = 2.57236;
            ++i; beta[i] = 2.57173;
            ++i; beta[i] = 2.57110;
            ++i; beta[i] = 2.57047;
            ++i; beta[i] = 2.56984;
            ++i; beta[i] = 2.56921;
            ++i; beta[i] = 2.56859;
            ++i; beta[i] = 2.56796;
            ++i; beta[i] = 2.56734;
            ++i; beta[i] = 2.56672;
            ++i; beta[i] = 2.56610;
            ++i; beta[i] = 2.56546;
            ++i; beta[i] = 2.56484;
            ++i; beta[i] = 2.56422;
            ++i; beta[i] = 2.56360;
            ++i; beta[i] = 2.56298;
            ++i; beta[i] = 2.56236;
            ++i; beta[i] = 2.56175;
            ++i; beta[i] = 2.56113;
            ++i; beta[i] = 2.56051;
            ++i; beta[i] = 2.55990;
            ++i; beta[i] = 2.55929;
            ++i; beta[i] = 2.55867;
            ++i; beta[i] = 2.55806;
            ++i; beta[i] = 2.55745;
            ++i; beta[i] = 2.55684;
            ++i; beta[i] = 2.55622;
            ++i; beta[i] = 2.55561;
            ++i; beta[i] = 2.55501;
            ++i; beta[i] = 2.55440;
            ++i; beta[i] = 2.55379;
            ++i; beta[i] = 2.55318;
            ++i; beta[i] = 2.55258;
            ++i; beta[i] = 2.55197;
            ++i; beta[i] = 2.55137;
            ++i; beta[i] = 2.55076;
            ++i; beta[i] = 2.55016;
            ++i; beta[i] = 2.54956;
            ++i; beta[i] = 2.54896;
            ++i; beta[i] = 2.54836;
            ++i; beta[i] = 2.54776;
            ++i; beta[i] = 2.54716;
            ++i; beta[i] = 2.54656;
            ++i; beta[i] = 2.54596;
            ++i; beta[i] = 2.54536;
            ++i; beta[i] = 2.54477;
            ++i; beta[i] = 2.54417;
            ++i; beta[i] = 2.54358;
            ++i; beta[i] = 2.54298;
            ++i; beta[i] = 2.54239;
            ++i; beta[i] = 2.54179;
            ++i; beta[i] = 2.54120;
            ++i; beta[i] = 2.54061;
            ++i; beta[i] = 2.54002;
            ++i; beta[i] = 2.53943;
            ++i; beta[i] = 2.53884;
            ++i; beta[i] = 2.53825;
            ++i; beta[i] = 2.53767;
            ++i; beta[i] = 2.53708;
            ++i; beta[i] = 2.53650;
            ++i; beta[i] = 2.53591;
            ++i; beta[i] = 2.53533;
            ++i; beta[i] = 2.53474;
            ++i; beta[i] = 2.53416;
            ++i; beta[i] = 2.53358;
            ++i; beta[i] = 2.53300;
            ++i; beta[i] = 2.53242;
            ++i; beta[i] = 2.53184;
            ++i; beta[i] = 2.53126;
            ++i; beta[i] = 2.53068;
            ++i; beta[i] = 2.53010;
            ++i; beta[i] = 2.52952;
            ++i; beta[i] = 2.52895;
            ++i; beta[i] = 2.52837;
            ++i; beta[i] = 2.52779;
            ++i; beta[i] = 2.52722;
            ++i; beta[i] = 2.52665;
            ++i; beta[i] = 2.52607;
            ++i; beta[i] = 2.52550;
            ++i; beta[i] = 2.52493;
            ++i; beta[i] = 2.52435;
            ++i; beta[i] = 2.52378;
            ++i; beta[i] = 2.52321;
            ++i; beta[i] = 2.52264;
            ++i; beta[i] = 2.52207;
            ++i; beta[i] = 2.52151;
            ++i; beta[i] = 2.52094;
            ++i; beta[i] = 2.52037;
            ++i; beta[i] = 2.51981;
            ++i; beta[i] = 2.51924;
            ++i; beta[i] = 2.51868;
            ++i; beta[i] = 2.51812;
            ++i; beta[i] = 2.51755;
            ++i; beta[i] = 2.51699;
            ++i; beta[i] = 2.51643;
            ++i; beta[i] = 2.51587;
            ++i; beta[i] = 2.51531;
            ++i; beta[i] = 2.51475;
            ++i; beta[i] = 2.51419;
            ++i; beta[i] = 2.51363;
            ++i; beta[i] = 2.51307;
            ++i; beta[i] = 2.51251;
            ++i; beta[i] = 2.51196;
            ++i; beta[i] = 2.51140;
            ++i; beta[i] = 2.51085;
            ++i; beta[i] = 2.51029;
            ++i; beta[i] = 2.50973;
            ++i; beta[i] = 2.50918;
            ++i; beta[i] = 2.50868;
            ++i; beta[i] = 2.50811;
            ++i; beta[i] = 2.50754;
            ++i; beta[i] = 2.50699;
            ++i; beta[i] = 2.50644;
            ++i; beta[i] = 2.50589;
            ++i; beta[i] = 2.50534;
            ++i; beta[i] = 2.50479;
            ++i; beta[i] = 2.50425;
            ++i; beta[i] = 2.50370;
            ++i; beta[i] = 2.50315;
            ++i; beta[i] = 2.50261;
            ++i; beta[i] = 2.50206;
            ++i; beta[i] = 2.50152;
            ++i; beta[i] = 2.50097;
            ++i; beta[i] = 2.50043;
            ++i; beta[i] = 2.49989;
            ++i; beta[i] = 2.49935;
            ++i; beta[i] = 2.49881;
            ++i; beta[i] = 2.49827;
            ++i; beta[i] = 2.49733;
            ++i; beta[i] = 2.49719;
            ++i; beta[i] = 2.49665;
            ++i; beta[i] = 2.49611;
            ++i; beta[i] = 2.49558;
            ++i; beta[i] = 2.49504;
            ++i; beta[i] = 2.49451;
            ++i; beta[i] = 2.49397;
            ++i; beta[i] = 2.49344;
            ++i; beta[i] = 2.49290;
            ++i; beta[i] = 2.49237;
            ++i; beta[i] = 2.49183;
            ++i; beta[i] = 2.49131;
            ++i; beta[i] = 2.49078;
            ++i; beta[i] = 2.49025;
            ++i; beta[i] = 2.48972;
            ++i; beta[i] = 2.48919;
            ++i; beta[i] = 2.48866;
            ++i; beta[i] = 2.48813;
            ++i; beta[i] = 2.48761;
            ++i; beta[i] = 2.48708;
            ++i; beta[i] = 2.48655;
            ++i; beta[i] = 2.48602;
            ++i; beta[i] = 2.48550;
            ++i; beta[i] = 2.48497;
            ++i; beta[i] = 2.48445;
            ++i; beta[i] = 2.48393;
            ++i; beta[i] = 2.48340;
            ++i; beta[i] = 2.48288;
            ++i; beta[i] = 2.48236;
            ++i; beta[i] = 2.48184;
            ++i; beta[i] = 2.48132;
            ++i; beta[i] = 2.48080;
            ++i; beta[i] = 2.48029;
            ++i; beta[i] = 2.47977;
            ++i; beta[i] = 2.47925;
            ++i; beta[i] = 2.47873;
            ++i; beta[i] = 2.47822;
            ++i; beta[i] = 2.47770;
            ++i; beta[i] = 2.47719;
            ++i; beta[i] = 2.47667;
            ++i; beta[i] = 2.47616;
            ++i; beta[i] = 2.47565;
            ++i; beta[i] = 2.47513;
            ++i; beta[i] = 2.47462;
            ++i; beta[i] = 2.47411;
            ++i; beta[i] = 2.47360;
            ++i; beta[i] = 2.47309;
            ++i; beta[i] = 2.47258;
            ++i; beta[i] = 2.47207;
            ++i; beta[i] = 2.47156;
            ++i; beta[i] = 2.47105;
            ++i; beta[i] = 2.47055;
            ++i; beta[i] = 2.47004;
            ++i; beta[i] = 2.46953;
            ++i; beta[i] = 2.46903;
            ++i; beta[i] = 2.46853;
            ++i; beta[i] = 2.46802;
            ++i; beta[i] = 2.46752;
            ++i; beta[i] = 2.46701;
            ++i; beta[i] = 2.46651;
            ++i; beta[i] = 2.46601;
            ++i; beta[i] = 2.46551;
            ++i; beta[i] = 2.46501;
            ++i; beta[i] = 2.46451;
            ++i; beta[i] = 2.46401;
            ++i; beta[i] = 2.46351;
            ++i; beta[i] = 2.46301;
            ++i; beta[i] = 2.46251;
            ++i; beta[i] = 2.46202;
            ++i; beta[i] = 2.46152;
            ++i; beta[i] = 2.46102;
            ++i; beta[i] = 2.46053;
            ++i; beta[i] = 2.46003;
            ++i; beta[i] = 2.45954;
            ++i; beta[i] = 2.45904;
            ++i; beta[i] = 2.45855;
            ++i; beta[i] = 2.45805;
            ++i; beta[i] = 2.45756;
            ++i; beta[i] = 2.45707;
            ++i; beta[i] = 2.45658;
            ++i; beta[i] = 2.45609;
            ++i; beta[i] = 2.45560;
            ++i; beta[i] = 2.45511;
            ++i; beta[i] = 2.45462;
            ++i; beta[i] = 2.45413;
        }
        /// <summary>
        /// Calculate P
        /// </summary>
        /// <param name="Pnper"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double P(double Pnper, double y)
        {
        if (y != 0)
            {
            return (Pnper / y);
            }
        MessageBox.Show("y must be !=0");
        return 0;
        }
        /// <summary>
        /// Calc squer of samples the specified diameter.
        /// </summary>
        /// <param name="diameter">The diameter.</param>
        /// <returns></returns>
        public double S(double diameter)
        {
            return (3.14 * Math.Pow(diameter, 2) / 4);
        }
        /// <summary>
        /// Расчет модуля g31
        /// </summary>
        /// <param name="d31"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public double g31(double d31, int epsilon)
        {
            double x = ((d31 * 1E-12) / (epsilon * 8.85 * 1E-12));
            return (x * 1e3);
        }
        /// <summary>
        /// Расчет модуля g33
        /// </summary>
        /// <param name="d33">пьезомодуль d33</param>
        /// <param name="epsilon">Эпсилон</param>
        /// <returns></returns>
        public double g33(int d33, int epsilon)
        {
            double x = ((d33 * 1E-12) / (epsilon * 8.85 * 1E-12));
            return (x * 1e3);
        }
        /// <summary>
        /// Calculation of dielectric permeability
        /// </summary>
        /// <param name="t">thicknes</param>
        /// <param name="c">capacity</param>
        /// <param name="d">diameter</param>
        /// <returns></returns>
        public double dielpron(double t, double d, double c)
        {
            double x = (14.4 * c * t) / (Math.Pow(d, 2));
            return Math.Round(x, 3);
        }
        /// <summary>
        /// e_re the re.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="d">The d.</param>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        public double e_re(double t, double d, double c)
        {
            double x = (14.4 * c * t) / (Math.Pow(d, 2));
            return Math.Round(x, 3);
        }
        /// <summary>
        /// es the im.
        /// </summary>
        /// <param name="e_re">The e re.</param>
        /// <param name="tgd">The TGD.</param>
        /// <returns></returns>
        public double e_im(double e_re, double tgd)
        {
            double x = e_re * tgd;
            return Math.Round(x, 3);
        }
        /// <summary>
        /// Calculation of small values Kp
        /// </summary>
        /// <param name="fr">resonanse frequency</param>
        /// <param name="fa">anti-resonance frequency</param>
        /// <param name="Uvihr">Voltage on resonanse</param>
        /// <param name="Uviha">Voltage on anti-resonanse</param>
        /// <returns></returns>
        public double Kp_small(double fr, double fa, double Uvihr, double Uviha)
        {
            double p, q, t;
            p = (Uvihr - Uviha) / (Uvihr + Uviha);
            q = 0.4 * fr;
            t = fa - fr;
            return 1 / Math.Sqrt(1 + (q / (t * p)));
        }
        /// <summary>
        /// Calculation of Kp the specified.
        /// </summary>
        /// <param name="fr1">The fr.</param>
        /// <param name="fa1">The fa.</param>
        /// <param name="fr3">The fa.</param>
        /// <returns></returns>
        public double Kp(int fr1,
                        int fa1,
                        int fr3)
        {
            int i = 0;
            bool found = false;
            double p, q, t;

            betaper = Betta(fr1, fr3);
            if (betaper >= beta[0] && betaper <= beta[beta.Length])
            {
                MessageBox.Show("Исправьте частоту 3 обертона " + fr3.ToString());
                return 0;
            }
            else
            {
                do
                {
                    if (betaper <= beta[i] && betaper >= beta[i + 1])
                    {
                        sigmaper = sigma[i];
                        nuper = nu[i];
                        found = true;
                    }
                    else i++;
                } while (found != true);

            }
            p = Math.Pow(nu[i], 2) - 1 + Math.Pow(sigma[i], 2);
            q = 2.0 * (1.0 + sigma[i]);
            t = 1.0 - (Math.Pow(fr1, 2) / Math.Pow(fa1, 2));
            return Math.Sqrt((p / q) * t);
        }
        /// <summary>
        /// Calculation of Kt
        /// </summary>
        /// <param name="fr5">The fr5.</param>
        /// <param name="fa5">The fa5.</param>
        /// <returns></returns>
        public double Kt(int fr5, int fa5)
        {
            return Math.Sqrt(1 / ((0.405 / ((fa5 - fr5) / fr5)) + 0.81));
        }
        //===========================================================================	        
        /// <summary>
        /// Calculate d33/sqr(e33t_e0)
        /// </summary>
        /// <param name="d33">The d33.</param>
        /// <param name="e0">The e0.</param>
        /// <returns></returns>
        public double d33_re_sqr_e33(int d33, int e0)
        {
            return (double)d33 / Math.Sqrt(e0);
        }
        //===========================================================================		
        /// <summary>
        /// Calculate Bettas
        /// </summary>
        /// <param name="fr">The fr.</param>
        /// <param name="fr3">The fr3 frequency of third  oberton</param>
        /// <returns></returns>
        public double Betta(int fr, int fr3)
        {
            return (double)fr3 / fr;
        }
        //===========================================================================
        /// <summary>
        /// Calculation d31
        /// </summary>
        /// <param name="eps">The eps.</param>
        /// <param name="ro">The ro.</param>
        /// <param name="Kp">The kp.</param>
        /// <param name="d">The d.</param>
        /// <param name="fr1">The fr.</param>
        /// <returns></returns>
        public double d31(double eps, double ro, double Kp, double d, int fr1)
        {
            double g, t;
            t = (0.188 * 2 * Kp * 1E-5) / (d * fr1);
            g = Math.Sqrt(eps / ro);
            return (t * g * 1e12);
        }
        /// <summary>
        /// Robrnarezs the specified ru1.
        /// </summary>
        /// <param name="ru1">The ru1.</param>
        /// <param name="ru2">The ru2.</param>
        /// <param name="rn">The rn.</param>
        /// <returns></returns>
        public double Robrnarez(double ru1,
                        double ru2,
                        double rn)
        {
            return (((ru1 / ru2) - 1) * rn);
        }
        /// <summary>
        /// Calculation of  Q-factor for small values
        /// </summary>
        /// <param name="fr1">resonance frequency</param>
        /// <param name="fa1">anti-resonance frequency</param>
        /// <param name="emk">capacity</param>
        /// <param name="ru1"></param>
        /// <param name="ru2"></param>
        /// <param name="rn"></param>
        /// <returns>Qmeh_small</returns>
        public int Qmeh_small(double fr1,
                   double fa1,
                   double emk,
                   double ru1,
                   double ru2,
                   double rn)
        {
            double t, p, r, e;
            double pi = 3.14;
            t = Math.Pow(fa1, 2) * 1E12;
            r = (((ru1 / ru2) - 1) * rn);
            e = Math.Pow(fa1, 2) - Math.Pow(fr1, 2);
            p = 2 * pi * r * emk * fr1 * e;
            return (int)(t / p);
        }
        /// <summary>
        /// Calculation Q-factor
        /// </summary>
        /// <param name="fr1">The fr1.</param>
        /// <param name="fa1">The fa1.</param>
        /// <param name="emk">The capacity</param>
        /// <param name="Rr">The Rr.</param>
        /// <returns>Qm</returns>
        public int Qm(int fr1, int fa1,
                   double emk,
                   double Rr)
        {
            double t, p, e;
            double pi = 3.14;
            t = Math.Pow(fa1, 2) * 1E12;
            e = Math.Pow(fa1, 2) - Math.Pow(fr1, 2);
            p = 2 * pi * Rr * emk * fr1 * e;
            return (int)(t / p);
        }
        /// <summary>
        /// Calculate Y11e
        /// </summary>
        /// <param name="fr1">The FR1.</param>
        /// <param name="d">The d.</param>
        /// <param name="ro">The ro.</param>
        /// <returns></returns>
        public double Y11E(int fr1,
                     double d,
                     double ro)
        {
            double x, t, rad;
            double pi = 3.14;
            rad = d / 2;
            x = (0.4 * Math.Pow(pi, 2)) / (Math.Pow(nuper, 2));
            t = Math.Pow(fr1, 2) * Math.Pow(rad, 2) * ro * (1 - (Math.Pow(sigmaper, 2)));
            return ((x * t) * 1E-11);
        }
        /// <summary>
        /// Calculation of V1E.
        /// </summary>
        /// <param name="d">The r.</param>
        /// <param name="fr1">The FR1.</param>
        /// <returns></returns>
        public double V1E(double d, int fr1)
        {
            double pi = 3.14;
            double p, t, e;
            p = (pi * d * fr1);
            t = Math.Sqrt(1 - (Math.Pow(sigmaper, 2)));
            e = 100 * nuper;
            p = t * p;
            p = p / e;
            return (p * 1E-3);
        }
        /// <summary>
        /// Udelobemelsoprs the specified soprizol.
        /// </summary>
        /// <param name="soprizol">The soprizol.</param>
        /// <param name="d">The d.</param>
        /// <param name="h">The h.</param>
        /// <returns></returns>
        double Udelobemelsopr(double soprizol,
                             double d,
                             double h)
        {
            double pi = 3.14;
            d = pi * (Math.Pow(d, 2));
            return ((soprizol * d) / (4 * h));
        }
        /// <summary>
        /// Calculatuion Tangense.
        /// </summary>
        /// <param name="tangens">The tangens.</param>
        /// <returns></returns>
        public double tgdE2(double tangens)
        {
            double x = tangens * 1e2;
            return Math.Round(x, 3);
        }
        /// <summary>
        /// Finds the maximum value from array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public double FindMaxValFromArray(double[] array)
        {
            double max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
        /// <summary>
        /// Finds the index of maximum value from array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public int FindIndexOfMaxValFromArray(double[] array)
        {
            double max = array[0];
            int maxI = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxI = i;
                }
            }
            return maxI;
        }
        /// <summary>
        /// Converts the uafter divider.
        /// </summary>
        /// <param name="u">The u.</param>
        /// <returns></returns>
        public double ConvertUafterDivider(double u)
        {
            double temp = u * 949.8;
            return temp;
        }
        /// <summary>
        /// Finds the index of maximum value from array interval.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="begin">The begin.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        public int FindIndexOfMaxValFromArrayInterval(double[] array, int begin, int end)
        {
            if (begin > array.GetLength(0))
            {
                MessageBox.Show("You must chek interval (begin)");
            }
            if (begin > array.GetLength(0))
            {
                MessageBox.Show("You must chek interval (end)");
            }

            double max = array[begin];
            int maxI = 0;
            try
            {
                for (int i = begin; i < end; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                        maxI = i;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return maxI;
        }
        /// <summary>
        /// Finds the index of minimum value from array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public int FindIndexOfMinValFromArray(double[] array)
        {
            double max = array[0];
            int minI = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < max)
                {
                    max = array[i];
                    minI = i;
                }
            }
            return minI;
        }
        /// <summary>
        /// Finds the minimum value from array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public double FindMinValFromArray(double[] array)
        {
            double min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
        /// <summary>
        /// Disperions the depth.
        /// </summary>
        /// <param name="e_e0_f_min">The e_e0 f minimum.</param>
        /// <param name="e_e0_f_max">The e e f maximum.</param>
        /// <returns></returns>
        public double DisperionDepth(double e_e0_f_min, double e_e0_f_max)
        {
            return ((e_e0_f_min - e_e0_f_max) / e_e0_f_min) * 100;
        }
        /// <summary>
        /// Degradations the degree.
        /// </summary>
        /// <param name="eroom">The eroom.</param>
        /// <param name="e_transition">The e transition.</param>
        /// <param name="Tm">The tm.</param>
        /// <param name="T1">The t1.</param>
        /// <param name="e1">The e1.</param>
        /// <returns></returns>
        public double DegradationDegree(double eroom, double e_transition, int Tm, int T1, double e1)
        {
            return 0;
        }
        /// <summary>
        /// Tilt the of line.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="y2">The y2.</param>
        /// <returns>Tan(f)</returns>
        public double TiltOfLine(double x1, double x2, double y1, double y2)
        {
            return (y2 - y1) / (x2 - x1);
        }
        /// <summary>
        /// Newtons the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="n">The n.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public double Newton(double t, int n, double[] x, double[] y)
        {
            double res = y[0], F, den;
            int i, j, k;
            for (i = 1; i < n; i++)
            {
                F = 0;
                for (j = 0; j <= i; j++)
                {
                    den = 1;
                    for (k = 0; k <= i; k++)
                    {
                        if (k != j) den *= (x[j] - x[k]);
                    }
                    F += y[j] / den;
                }
                for (k = 0; k < i; k++) F *= (t - x[k]);
                res += F;
            }
            return res;
        }
        /// <summary>
        /// Converts the celcius to kelvin.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <returns>temperature</returns>
        public double ConvertCelciusToKelvin(int temperature)
        {
            return Convert.ToDouble(temperature) + 273.16;
        }
        /// <summary>
        /// Converts the celcius to kelvin.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <returns>temperature</returns>
        public double ConvertCelciusToKelvin(double temperature)
        {
            return temperature + 273.16;
        }
        /// <summary>
        /// Converts the celcius to kelvin.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <returns>
        /// temperature
        /// </returns>
        public double ConvertCelciusToKelvin(string temperature)
        {
            return Convert.ToDouble(temperature) + 273.16;
        }

        public string ReplaceCommonEscapeSequences(string command)
        {
            return command.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        /// <summary>
        /// Byteses to float.
        /// </summary>
        /// <param name="inpt">The inpt.</param>
        /// <returns></returns>
        public double BytesToFloat(Byte[] inpt)
        {
            double result = 0;
            int Mnt, Pos, i;
            if (inpt[0] >= 128)
                return (-999);//ошибочное число

            Pos = inpt[0] >> 2;
            Mnt = inpt[0] - Pos * 4;

            if (Mnt == 0)
            {
                if (inpt[1] >= 128)
                {
                    result = -1 * (inpt[1] - 128);
                }
                else result = inpt[1];
            }

            if (Mnt == 1)
            {
                if (inpt[1] >= 128)
                    result = -1 * ((inpt[1] - 128) * 256 + inpt[2]);
                else result = inpt[1] * 256 + inpt[2];
            }

            if (Mnt == 2)
            {
                if (inpt[1] >= 128)
                    result = -1 * ((inpt[1] - 128) * 65536 + inpt[2] * 256 + inpt[3]);
                else result = inpt[1] * 65536 + inpt[2] * 256 + inpt[3];
            }

            if (Mnt == 3)
            {
                if (inpt[1] >= 128)
                    result = -1 * ((inpt[1] - 128) * 16777216 + inpt[2] * 65536 + inpt[3] * 256 + inpt[4]);
                else result = inpt[1] * 16777216 + inpt[2] * 65536 + inpt[3] * 256 + inpt[4];
            }

            for (i = 0; i < Pos; i++)
            {
                result *= 0.1;
            }

            return (result);
        }
        /// <summary>
        /// Byteses to float new.
        /// </summary>
        /// <param name="inpt">The inpt.</param>
        /// <returns></returns>
        public double BytesToFloatNew(Byte[] inpt)
        {
            double result = 0;
            int Mnt, Pos;

            Pos = inpt[0] >> 2;
            Mnt = inpt[0] - Pos * 4;

            if (Mnt == 0)
            {
                if (inpt[1] >= 128) result = -1 * ((inpt[1] - 128));
                else result = inpt[1];
            }

            if (Mnt == 1)
            {
                if (inpt[1] >= 128) result = -1 * ((inpt[1] - 128) * 256 + inpt[2]);
                else result = inpt[1] * 256 + inpt[2];
            }

            if (Mnt == 2)
            {
                if (inpt[1] >= 128) result = -1 * ((inpt[1] - 128) * 65536 + inpt[2] * 256 + inpt[3]);
                else result = inpt[1] * 65536 + inpt[2] * 256 + inpt[3];
            }

            if (Mnt == 3)
            {
                if (inpt[1] >= 128)
                    result = -1 * ((inpt[1] - 128) * 16777216 + inpt[2] * 65536 + inpt[3] * 256 + inpt[4]);
                else result = inpt[1] * 16777216 + inpt[2] * 65536 + inpt[3] * 256 + inpt[4];
            }
            result *= 0.1;
            return (result);
        }
        /// <summary>
        /// Doubles to bytes.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public Byte[] DoubleToBytes(double input)
        {
            Byte[] result = BitConverter.GetBytes(input);
            return result;
        }

        public double BytesToDouble(byte[] inB)
        {
            return BitConverter.ToDouble(inB, 0);
        }

        public double BytesToDouble(byte[] inB, short offset, short count)
        {
            double res = 0;
            for (int i = 0; i < count; i++)
            {
                res += inB[i + offset] * Math.Pow(256, i);
            }
            return res;
        }



    }
    