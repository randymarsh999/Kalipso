using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ExcelObj = Microsoft.Office.Interop.Excel;
using System.Data;



class FileJob
{
    /// <summary>
    /// Запись в файл строки
    /// </summary>
    /// <param name="s">строка</param>
    /// <param name="FileName">Имя файла</param>
    public void WriteF(string s, string FileName)
    {
        using (StreamWriter sw = new StreamWriter(FileName, true))
        {
            sw.WriteLine(s);
            sw.Close();
        }
    }
    /// <summary>
    /// Writes the header from data grid.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="FileName">Name of the file.</param>
    public void WriteHeaderFromDataGrid(DataGridView DG, string FileName)
    {
        using (StreamWriter sw = new StreamWriter(FileName, true))
        {
            string s = "";
            for (int i = 0; i < DG.Columns.Count; i++)
            {

                if (i == DG.Columns.Count - 1)
                {
                    s += DG.Columns[i].Name;
                }
                else s += DG.Columns[i].Name + "\t";
            }
            sw.WriteLine(s);
        }
    }
    /// <summary>
    /// Clears the data grid view.
    /// </summary>
    /// <param name="DG">The dg.</param>
    public void ClearDataGridView(DataGridView DG)
    {
        DG.Rows.Clear();
        DG.ColumnCount = 0;
    }
    /// <summary>
    /// Writes the string to file from data grid.
    /// </summary>
    /// <param name="DG">The DataGridView.</param>
    /// <param name="FileName">Name of the file.</param>
    /// <param name="StringNum">The string number.</param>
    public void WriteStrToFileFromDataGrid(DataGridView DG, string FileName, int StringNum)
    {
        using (StreamWriter sw = new StreamWriter(FileName, true))
        {
            string s = "";
            for (int j = 0; j < DG.ColumnCount; j++)
            {
                if (j == DG.Columns.Count - 1)
                {
                    s += DG[j, StringNum].Value;
                }
                else s += DG[j, StringNum].Value + "\t";
            }
            sw.WriteLine(s);
            sw.Close();
        }
    }
    /// <summary>
    /// Writes the file full data data grid.
    /// </summary>
    /// <param name="DG">The DataGridView</param>
    /// <param name="FileName">Name of the file.</param>
    public void WriteFileFullDataGrid(DataGridView DG, string FileName)
    {
        using (StreamWriter sw = new StreamWriter(FileName, true))
        {
            string s = "";
            for (int i = 0; i < DG.Columns.Count; i++)
            {

                if (i == DG.Columns.Count - 1)
                {
                    s += DG.Columns[i].Name;
                }
                else s += DG.Columns[i].Name + "\t";
            }
            sw.WriteLine(s);

            for (int i = 0; i < DG.RowCount; i++)
            {
                s = "";
                for (int j = 0; j < DG.ColumnCount; j++)
                {
                    if (j == DG.Columns.Count - 1)
                    {
                        s += DG[j, i].Value;
                    }
                    else s += DG[j, i].Value + "\t";
                }
                sw.WriteLine(s);
            }
            sw.Close();
        }
    }
    /// <summary>
    /// Чтение из файла массива строк
    /// </summary>
    /// <param name="FileName">Имя файла</param>
    /// <returns></returns>
    public string[] ReadF(string FileName)
    {
        string[] lines = System.IO.File.ReadAllLines(FileName);
        return lines;
    }
    /// <summary>
    /// Saves to excel from data grid view.
    /// </summary>
    /// <param name="DG">The DataGridView.</param>
    /// <param name="FileNameSave">The file name save.</param>
    public void SaveToExcelFromDataGridView(DataGridView DG, string FileNameSave)
    {
        try
        {
            ExcelObj.Application app = new ExcelObj.Application();
            ExcelObj.Workbook workbook = app.Workbooks.Add();
            ExcelObj.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 1; i < DG.RowCount + 1; i++)
            {
                for (int j = 1; j < DG.ColumnCount + 1; j++)
                {
                    worksheet.Rows[i].Columns[j] = DG.Rows[i - 1].Cells[j - 1].Value;
                }
            }
            app.AlertBeforeOverwriting = false;
            workbook.SaveAs(FileNameSave);
            app.Quit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
    /// <summary>
    /// Loads the excel file to data grid view.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="FileNameOpen">The file name open.</param>
    public void LoadExcelFileToDataGridView(DataGridView DG, string FileNameOpen)
    {
        try
        {
            DataTable dt = new DataTable();
            ExcelObj.Application app = new ExcelObj.Application();
            ExcelObj.Workbook workbook;
            ExcelObj.Worksheet NwSheet;
            ExcelObj.Range ShtRange;
            //toolStripStatusLabel2.Text = "Open file: " + oDlgPiezo.FileName;
            //Устанавливаем номер листа из котрого будут извлекаться данные
            //Листы нумеруются от 1
            workbook = app.Workbooks.Open(FileNameOpen);
            NwSheet = (ExcelObj.Worksheet)workbook.Sheets.get_Item(1);
            ShtRange = NwSheet.UsedRange;
            //ShtRange = 2;
            for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
            //for (int Cnum = 1; Cnum <= 2; Cnum++)
            {
                dt.Columns.Add(
                   new DataColumn((ShtRange.Cells[1, Cnum] as ExcelObj.Range).Value2.ToString()));
            }
            dt.AcceptChanges();
            string[] columnNames = new String[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                columnNames[0] = dt.Columns[i].ColumnName;
            }

            for (int Rnum = 2; Rnum <= ShtRange.Rows.Count; Rnum++)
            {
                DataRow dr = dt.NewRow();
                for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                {
                    if ((ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2 != null)
                    {
                        dr[Cnum - 1] = (ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2.ToString();
                    }
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();

            }
            app.Quit();
            DG.DataSource = dt;
        }
        catch (Exception msg)
        {
            // something went wrong, and you wanna know why
            MessageBox.Show(msg.ToString());
            throw;
        }
    }
    /// <summary>
    /// Loads the excel file to text.
    /// </summary>
    /// <param name="txtV">The text v.</param>
    /// <param name="txtT">The text t.</param>
    /// <param name="FileNameOpen">The file name open.</param>
    public void LoadExcelFileToTxt(TextBox txtV, TextBox txtT, string FileNameOpen)
    {
        try
        {
            DataTable dt = new DataTable();
            ExcelObj.Application app = new ExcelObj.Application();
            ExcelObj.Workbook workbook;
            ExcelObj.Worksheet NwSheet;
            ExcelObj.Range ShtRange;
            //toolStripStatusLabel2.Text = "Open file: " + oDlgPiezo.FileName;
            //Устанавливаем номер листа из котрого будут извлекаться данные
            //Листы нумеруются от 1
            workbook = app.Workbooks.Open(FileNameOpen);
            NwSheet = (ExcelObj.Worksheet)workbook.Sheets.get_Item(1);
            ShtRange = NwSheet.UsedRange;
            //ShtRange = 2;
            for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
            {
                dt.Columns.Add(
                   new DataColumn((ShtRange.Cells[1, Cnum] as ExcelObj.Range).Value2.ToString()));
            }
            dt.AcceptChanges();
            string[] columnNames = new String[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                columnNames[0] = dt.Columns[i].ColumnName;
            }

            for (int Rnum = 1; Rnum <= ShtRange.Rows.Count; Rnum++)
            {
                DataRow dr = dt.NewRow();
                for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                {
                    if ((ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2 != null)
                    {
                        dr[Cnum - 1] = (ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2.ToString();
                    }
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            app.Quit();

            txtT.Clear();
            txtV.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtT.AppendText(dt.Rows[i][0].ToString() + Environment.NewLine);
                txtV.AppendText(dt.Rows[i][1].ToString() + Environment.NewLine);
            }
        }
        catch (Exception msg)
        {
            // something went wrong, and you wanna know why
            MessageBox.Show(msg.ToString());
            throw;
        }
    }

    /// <summary>
    /// Commons the import.
    /// </summary>
    /// <param name="OpenFileDNON">The open file dnon.</param>
    /// <param name="view">The view.</param>
    public void Common_Import(string OpenFileDNON, DataGridView view)
    {
        int cst = 0;
        DataTable dt = new DataTable();
        string fileN1 = OpenFileDNON;
        DataRow row;
        FileJob FJ = new FileJob();
        string[] s;
        try
        {
            s = FJ.ReadF(OpenFileDNON);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return;
        }
        for (int i = 0; i < s.GetLength(0); i++)
        {
            ParseStringTab p = new ParseStringTab();
            ParseStringTab p1 = new ParseStringTab();
            p.AddString(s[i]);
            //создание заголовков таблицы 
            if (i == 0)
            {
                p.AddString(s[i]);
                IEnumerable<string> pdis = p.Distinct();
                cst = pdis.Count();
                foreach (string st in pdis)
                {
                    p1.Add(st);
                }
                for (int j = 0; j < p1.Count; j++)
                {
                    p1[j] = FJ.CorrectHead(p1[j]);
                    dt.Columns.Add(p1[j]);
                }
            }
            else
            {
                //цикл для сортировки
                int x = 0;
                row = dt.NewRow();
                for (int j = 0; j < p.Count(); j++)
                {
                    try
                    {
                        row[x] = p[j];
                        ++x;
                        if (x == cst)
                        {
                            dt.Rows.Add(row);
                            row = dt.NewRow();
                            x = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            p.Clear();
        }
        view.DataSource = dt;
    }
    /// <summary>
    /// Dnons the rnon import.
    /// </summary>
    /// <param name="OpenFileDNON">The open file dnon.</param>
    /// <param name="view">The view.</param>
    public void DNON_RNON_Import(string OpenFileDNON, DataGridView view)
    {
        int cst = 0;
        DataTable dt = new DataTable();
        string fileN1 = OpenFileDNON;
        string fileN2 = OpenFileDNON.Substring(0, OpenFileDNON.Length - 8) + "RNON.txt";
        DataRow row;
        FileJob FJ = new FileJob();
        string[] s;
        try
        {
            s = FJ.ReadF(OpenFileDNON);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return;
        }
        for (int i = 0; i < s.GetLength(0); i++)
        {
            ParseStringTab p = new ParseStringTab();
            ParseStringTab p1 = new ParseStringTab();
            p.AddString(s[i]);
            //создание заголовков таблицы 
            if (i == 0)
            {
                p.AddString(s[i]);
                IEnumerable<string> pdis = p.Distinct();
                cst = pdis.Count();
                foreach (string st in pdis)
                {
                    p1.Add(st);
                }
                for (int j = 0; j < p1.Count; j++)
                {
                    p1[j] = FJ.CorrectHead(p1[j]);
                    dt.Columns.Add(p1[j]);
                }
            }
            else
            {
                //цикл для сортировки
                int x = 0;
                row = dt.NewRow();
                for (int j = 0; j < p.Count(); j++)
                {
                    try
                    {
                        row[x] = p[j];
                        ++x;
                        if (x == cst)
                        {
                            dt.Rows.Add(row);
                            row = dt.NewRow();
                            x = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            p.Clear();
        }

        try
        {
            s = FJ.ReadF(fileN2);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        for (int i = 1; i < s.GetLength(0); i++)
        {
            ParseStringTab p = new ParseStringTab();
            ParseStringTab p1 = new ParseStringTab();
            p.AddString(s[i]);
            int x = 0;
            row = dt.NewRow();
            for (int j = 0; j < p.Count(); j++)
            {
                try
                {
                    row[x] = p[j];
                    ++x;
                    if (x == cst)
                    {
                        dt.Rows.Add(row);
                        row = dt.NewRow();
                        x = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            p.Clear();
        }
        view.DataSource = dt;
    }
    /// <summary>
    /// Copies the resolved files.
    /// </summary>
    public void CopyResolvedFiles()
    {
        string[] filesname = Directory.GetFiles(@"C:\\temp\\");
        for (int i = 0; i < filesname.Length; i++)
        {
            //создаем директорию
            Directory.CreateDirectory(@"C:\\temp\\resolved\\");
            string[] filespath = filesname[i].Split(Convert.ToChar(92));
            //проверка существует ли в конечной папке копируемый файл
            if (File.Exists(@"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]))
            {
                File.Delete(@"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]);
            }
            File.Move(filesname[i], @"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]);
        }
    }

    /// <summary>
    /// Copies the fyle to temporary dir.
    /// </summary>
    /// <param name="f_in">The f in.</param>
    /// <param name="f_out">The f out.</param>
    public void CopyFileToTempDir(string f_in, string f_out)
    {
        File.Copy(f_in, f_out, true);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    private void Load_obnovlenie(string path)
    {
        //try
        //{
        //    WebClient w = new WebClient();
        //    string adres = Application.StartupPath;
        //    adres += "\\new.program.exe";
        //    w.DownloadFile(new Uri(path), adres);
        //    File.WriteAllBytes(Application.StartupPath + "\\obnov.exe", Properties.Resources.obnov);
        //    Process.Start(Application.StartupPath + "\\obnov.exe");
        //    Process.GetCurrentProcess().Kill();
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //}



        //string path = Application.StartupPath + "\\program.exe";
        //string path1 = Application.StartupPath + "\\new.program.exe";
        //File.Delete(path);
        //File.Move(path1, path);
        //Process.Start(path);
        //Process.GetCurrentProcess().Kill();
    }
    /// <summary>
    /// Corrects the head.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <returns></returns>
    public string CorrectHead(string s)
    {
        if (s == "C,pF" || s == "C.pF" || s == "C, pF")
        {
            s = "C_pF";
        }
        if (s == "e'" || s == "e/e0")
        {
            s = "e_re";
        }
        if (s == "e''")
        {
            s = "e_im";
        }
        if (s == "tgd*1e-2" || s == "tgd1e_minus2" || s == "tgd * 1e-2")
        {
            s = "tgd1e2";
        }
        if (s == "f,Hz" || s == "f, Hz")
        {
            s = "f_Hz";
        }
        if (s == "T,C" || s == "T, C")
        {
            s = "T_C";
        }
        if (s == "T,K" || s == "T, K")
        {
            s = "T_K";
        }
        if (s == "tgd1e_2")
        {
            s = "tgd1e2";
        }
        if (s == "U_V")
        {
            s = "Ubias_V";
        }
        if (s == "H_T")
        {
            s = "Hbias_T";
        }
        return s;
    }
}