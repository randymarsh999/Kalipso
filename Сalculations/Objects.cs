using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalipso
{
    class Objects
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DGW"></param>
        public void ExcelToDataGridView(DataGridView DGW)
        {
            int rCnt;
            int cCnt;
            try
            {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Open excel file";
            opf.Filter = "Файл Excel|*.XLSX;*.XLS";
            opf.ShowDialog();
            System.Data.DataTable tb = new System.Data.DataTable();
            string filename = opf.FileName;
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            Microsoft.Office.Interop.Excel.Range ExcelRange;
                ExcelWorkBook = ExcelApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                ExcelRange = ExcelWorkSheet.UsedRange;
                for (rCnt = 2; rCnt <= ExcelRange.Rows.Count; rCnt++)
                {
                    DGW.Rows.Add(1);
                    for (cCnt = 1; cCnt <= ExcelRange.Columns.Count; cCnt++)
                    {
                        DGW.Rows[rCnt - 2].Cells[cCnt - 1].Value = ExcelApp.Cells[rCnt, cCnt].Value;
                    }
                }
                ExcelWorkBook.Close(true, null, null);
                ExcelApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }
}
