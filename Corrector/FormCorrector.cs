using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using Excel = Microsoft.Office.Interop.Excel;

namespace Corrector
{
    public partial class FormCorrector : Form
    {
        private bool isRunning = false;
        private bool IsRunning
        {
            get { return isRunning; }
            set
            {
                isRunning = value;
                _ = Task.Run(()=> {
                    int count = 10;
                    while(isRunning)
                    {
                        if (this.label1.InvokeRequired)
                        {
                            this.label1.Text += ".";
                        }
                        else
                        {
                            this.label1.Invoke(new Action(() => {
                                this.label1.Text += ".";
                            }));
                        }
                        
                        if (--count <= 0)
                        {
                            this.label1.Text = "";
                        }
                    }
                });
                //TIControl.SetVisible(this.mpsIsRunning, value);
                //TIControl.SetSpinning(this.mpsIsRunning, value);
            }
        }

        public FormCorrector()
        {
            InitializeComponent();

            this.gcEDocs.DataSource = new List<EDoc>();

            var col = gridView1.Columns.ToList().FirstOrDefault(x => x.FieldName == nameof(EDoc.ToStringCSV));
            if (col != null) col.Visible = false;
        }

        List<EDoc> edocs = new List<EDoc>();

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.button3.Left = (this.Width / 2) - this.button3.Width;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal sum = Math.Round(this.edocs.Sum(x => x.PayEDV) / 0.18M, 2);
            foreach (var item in this.edocs)
            {
                if (this.edocs.Sum(x => x.PayMain) == sum)
                {
                    break;
                }
                decimal esasmin1 = Math.Round(((item.PayMain - 0.01M) * 0.18M), 2);
                if (esasmin1 == item.PayEDV)
                {
                    item.PayMain -= 0.01M;
                    item.PaySum = item.PayMain + item.PayEDV;
                    item.Corrected = true;
                }
            }
            this.gcEDocs.RefreshDataSource();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.cmsTo.Show(Cursor.Position);
            }
        }

        private void toCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = File.CreateText("list.csv"))
                {
                    for (int i = 0; i < this.edocs.Count; i++)
                    {
                        sw.WriteLine(this.edocs[i].ToStringCSV);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex?.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        // T is a generic class
        static DataTable ConvertToDataTable<T>(List<T> models)
        {
            // creating a data table instance and typed it as our incoming model 
            // as I make it generic, if you want, you can make it the model typed you want. 
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties of that model
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // Loop through all the properties            
            // Adding Column name to our datatable
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            // Adding Row and its value to our dataTable
            foreach (T item in models)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows  
                    values[i] = Props[i].GetValue(item, null);
                }
                // Finally add value to datatable  
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private void toExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = Task.Run(() => {
                try
                {
                    string fileName = "EDocs.xlsx";
                    string location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string customExcelSavingPath = location + "\\" + fileName;
                    ExcelExport.GenerateExcel(ConvertToDataTable(edocs), customExcelSavingPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    MessageBox.Show("finally");
                }
            });
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.cmsFrom.Show(Cursor.Position);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xls, *.xlsx, *.xlsm)|*.xls; *.xlsx; *.xlsm|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    IsRunning = true;
                    try
                    {
                        string filePath = openFileDialog.FileName;

                        using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                int counter = 0;
                                while (reader.Read())
                                {
                                    if (++counter == 1) continue;
                                    EDoc edoc = new EDoc();
                                    if (reader.FieldCount >= 1)
                                    {
                                        edoc.TIN = reader.GetValue(0)?.ToString();
                                    }
                                    if (edoc == null || edoc.TIN == null || edoc.TIN.Length == 0) continue;
                                    if (reader.FieldCount >= 2)
                                    {
                                        edoc.Name = reader.GetValue(1)?.ToString();
                                        edoc.Name = edoc.Name.Replace("”", "");
                                    }
                                    if (reader.FieldCount >= 3)
                                    {
                                        edoc.Date = Convert.ToDateTime(reader.GetValue(2)?.ToString());
                                    }
                                    if (reader.FieldCount >= 4)
                                    {
                                        edoc.Serial = reader.GetValue(3)?.ToString();
                                    }
                                    if (reader.FieldCount >= 5)
                                    {
                                        edoc.Number = reader.GetValue(4)?.ToString();
                                    }
                                    if (reader.FieldCount >= 6)
                                    {
                                        edoc.RowCode = reader.GetValue(5)?.ToString();
                                    }
                                    if (reader.FieldCount >= 7)
                                    {
                                        edoc.DocMain = Convert.ToDecimal(reader.GetValue(6)?.ToString());
                                    }
                                    if (reader.FieldCount >= 8)
                                    {
                                        edoc.DocEDV = Convert.ToDecimal(reader.GetValue(7)?.ToString());
                                    }
                                    if (reader.FieldCount >= 9)
                                    {
                                        edoc.DocSum = Convert.ToDecimal(reader.GetValue(8)?.ToString());
                                    }
                                    if (reader.FieldCount >= 10)
                                    {
                                        edoc.PayMain = Convert.ToDecimal(reader.GetValue(9)?.ToString());
                                    }
                                    if (reader.FieldCount >= 11)
                                    {
                                        edoc.PayEDV = Convert.ToDecimal(reader.GetValue(10)?.ToString());
                                    }
                                    if (reader.FieldCount >= 12)
                                    {
                                        edoc.PaySum = Convert.ToDecimal(reader.GetValue(11)?.ToString());
                                    }
                                    edocs.Add(edoc);
                                }
                            }
                        }

                        this.gcEDocs.DataSource = edocs;

                        MessageBox.Show(this, this.Text + " yüklənməsi sona çatdı!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex?.Message + "\n" + ex?.InnerException?.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        throw;
                    }
                    finally
                    {
                        IsRunning = false;
                        System.GC.Collect();
                    }
                }
            }
        }
    }
}
