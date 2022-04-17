using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace GetProducts
{
    public partial class ProductInfoGatherer : Form
    {		

        public ProductInfoGatherer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("http://localhost:8000/");
            HttpResponseMessage response = clint.GetAsync("jsonproducts").Result;
            var product = response.Content.ReadAsAsync<IEnumerable<Products>>().Result;

            dataGridView1.DataSource = product;

            
        }

        private void ButtonCSV_Click(object sender, EventArgs e)
        {
            using SaveFileDialog browser = new();
            browser.Filter = "CSV (*.csv)|*.csv";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                CSVExport export = new(browser.FileName, dataGridView1);
                export.CreateCSVFile();
            }
        }
    }

    
}
