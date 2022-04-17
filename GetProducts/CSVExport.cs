using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace GetProducts
{
    class CSVExport
    {
        private string FileName;

        private DataGridView Grid;


        public CSVExport(string fileName, DataGridView grid)
        {
            this.FileName = fileName;
            this.Grid = grid;
        }

        public void CreateCSVFile()
        {
            StringBuilder sb = new();

            var headers = Grid.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in Grid.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            using StreamWriter sw = new(this.FileName);
            sw.Write(sb.ToString());

        }
    }
}
