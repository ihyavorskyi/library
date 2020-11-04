using System.Collections.Generic;
using System.Windows.Forms;

namespace New_Lib
{
    public class AddRowsToDataGridView
    {
        public static void addRows(List<string[]> data, DataGridView dataGridView)
        {
            foreach (string[] s in data)
                dataGridView.Rows.Add(s);
        }
    }
}