using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "Graphs"
public class Graphs
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "Graphs"
{
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "Graphs.IninitialezedGrafFromDataGrid(DataGridView, Chart)"
    public void IninitialezedGrafFromDataGrid(DataGridView DG, System.Windows.Forms.DataVisualization.Charting.Chart CH)
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "Graphs.IninitialezedGrafFromDataGrid(DataGridView, Chart)"
    {
        for (int i = 0; i < DG.ColumnCount; i++)
        {
            int j = 0;
            Color myRgbColor = new Color();
            if (i > 254) j = 0;
            else j = i;
            myRgbColor = Color.FromArgb(j, 255, j + 5);

            CH.Series.Clear();
            CH.Series.Add(DG.Columns[i].HeaderText);
            CH.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            CH.Series[i].Color = myRgbColor;
        }
    }
    /// <summary>
    /// Ininitialezeds the graf serie.
    /// </summary>
    /// <param name="SeriesName">Name of the series.</param>
    /// <param name="CH">The chart.</param>
    public void IninitialezedGrafSeries(string SeriesName, System.Windows.Forms.DataVisualization.Charting.Chart CH)
    {
        //Random rnd = new Random();
        //int val = rnd.Next(1, 255);
        CH.Series.Clear();
        Color myRgbColor = new Color();
        myRgbColor = Color.FromArgb(0, 255, 0);
        CH.Series.Clear();
        CH.Series.Add(SeriesName);
        CH.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        CH.Series[0].Color = myRgbColor;
    }
    /// <summary>
    /// Ininitialezeds the graf series.
    /// </summary>
    /// <param name="SeriesName">Name of the series.</param>
    /// <param name="seriesNum">The series number.</param>
    /// <param name="CH">The ch.</param>
    public void IninitialezedGrafSeries(string SeriesName, int seriesNum, System.Windows.Forms.DataVisualization.Charting.Chart CH)
    {
        Random rnd = new Random();
        int val = rnd.Next(1, 255);
        CH.Series.Clear();
        Color myRgbColor = new Color();
        myRgbColor = Color.FromArgb(0, val, 0);
        CH.Series.Clear();
        CH.Series.Add(SeriesName);
        CH.Series[seriesNum].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        CH.Series[seriesNum].Color = myRgbColor;
    }
    /// <summary>
    /// Ininitialezeds the graf series from list.
    /// </summary>
    /// <param name="SeriesName">Name of the series.</param>
    /// <param name="CH">The ch.</param>
    public void IninitialezedGrafSeries(string[] SeriesName, System.Windows.Forms.DataVisualization.Charting.Chart CH)
    {
        CH.Series.Clear();
        Color myRgbColor = new Color();
        CH.Series.Clear();
        for (int i = 0; i < SeriesName.Length; i++)
        {
            myRgbColor = Color.FromArgb(0, 255, 0);
            CH.Series.Add(SeriesName[i]);
            CH.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            CH.Series[i].Color = myRgbColor;
        }
    }
#pragma warning disable CS1573 // Параметр "colorB" не имеет совпадающего тега param в комментарии XML для "Graphs.IninitialezedGrafSeries(string[], int, int, int, Chart)" (в отличие от остальных параметров)
#pragma warning disable CS1573 // Параметр "colorR" не имеет совпадающего тега param в комментарии XML для "Graphs.IninitialezedGrafSeries(string[], int, int, int, Chart)" (в отличие от остальных параметров)
#pragma warning disable CS1573 // Параметр "colorG" не имеет совпадающего тега param в комментарии XML для "Graphs.IninitialezedGrafSeries(string[], int, int, int, Chart)" (в отличие от остальных параметров)
    /// <summary>
    /// Ininitialezeds the graf series from list.
    /// </summary>
    /// <param name="SeriesName">Name of the series.</param>
    /// <param name="CH">The ch.</param>
    public void IninitialezedGrafSeries(string[] SeriesName, int colorR, int colorG, int colorB, System.Windows.Forms.DataVisualization.Charting.Chart CH)
#pragma warning restore CS1573 // Параметр "colorG" не имеет совпадающего тега param в комментарии XML для "Graphs.IninitialezedGrafSeries(string[], int, int, int, Chart)" (в отличие от остальных параметров)
#pragma warning restore CS1573 // Параметр "colorR" не имеет совпадающего тега param в комментарии XML для "Graphs.IninitialezedGrafSeries(string[], int, int, int, Chart)" (в отличие от остальных параметров)
#pragma warning restore CS1573 // Параметр "colorB" не имеет совпадающего тега param в комментарии XML для "Graphs.IninitialezedGrafSeries(string[], int, int, int, Chart)" (в отличие от остальных параметров)
    {
        CH.Series.Clear();
        Color myRgbColor = new Color();
        CH.Series.Clear();
        for (int i = 0; i < SeriesName.Length; i++)
        {
            myRgbColor = Color.FromArgb(colorG, colorG, colorB);
            CH.Series.Add(SeriesName[i]);
            CH.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            CH.Series[i].Color = myRgbColor;
        }
    }
    /// <summary>
    /// Ininitialezeds the graf series.
    /// </summary>
    /// <param name="SeriesName">Name of the series.</param>
    /// <param name="colorR">The color r.</param>
    /// <param name="colorG">The color g.</param>
    /// <param name="colorB">The color b.</param>
    /// <param name="CH">The ch.</param>
    public void IninitialezedGrafSeries(string SeriesName, int colorR, int colorG, int colorB, System.Windows.Forms.DataVisualization.Charting.Chart CH)
    {
        bool seriesExist=false;
        Color myRgbColor = new Color();
        for (int i = 0; i < CH.Series.Count; i++)
        {
            if (CH.Series[i].Name == SeriesName)
            {
                seriesExist = true;
            }
        }
        if (seriesExist == false)
        {
            myRgbColor = Color.FromArgb(colorG, colorG, colorB);
            CH.Series.Add(SeriesName);

            for (int i = 0; i < CH.Series.Count; i++)
            {
                if (CH.Series[i].Name == SeriesName)
                {
                    CH.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    CH.Series[i].Color = myRgbColor;
                }
            }
        }


    }


}

