using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 
/// </summary>
class DataGridJob
{
    /// <summary>
    /// Adds the column.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="s">The s.</param>
    /// <param name="Tag">The tag.</param>
    public void AddColumn(DataGridView DG, string s, string Tag)
    {
        //создание колонки
        DataGridViewTextBoxColumn dgvAge;
        dgvAge = new DataGridViewTextBoxColumn();
        DG.Columns.Add(new DataGridViewTextBoxColumn() { Name = s });
        DG.Columns[s].Tag = Tag;
    }
    /// <summary>
    /// Adds the row.
    /// </summary>
    /// <param name="DG">The dg.</param>
    public void AddRow(DataGridView DG)
    {
        ((DataTable)DG.DataSource).Rows.Add();
    }
}

