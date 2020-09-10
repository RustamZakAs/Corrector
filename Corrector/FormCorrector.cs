using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Corrector.Properties;
using Dapper;
using ExcelDataReader;

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
                _ = Task.Run(() =>
                {
                    int count = 10;
                    do
                    {
                        if (!label1.InvokeRequired)
                        {
                            label1.Text += ".";
                            Thread.Sleep(200);
                        }
                        else
                        {
                            label1.Invoke(new Action(() =>
                            {
                                label1.Text += ".";
                                Thread.Sleep(200);
                            }));
                        }

                        if (--count <= 0)
                        {
                            if (!label1.InvokeRequired)
                            {
                                label1.Text = "";
                            }
                            else
                            {
                                label1.Invoke(new Action(() =>
                                {
                                    label1.Text = "";
                                }));
                            }
                            count = 10;
                        }
                    } while (isRunning);

                    if (!label1.InvokeRequired)
                    {
                        label1.Text = "";
                    }
                    else
                    {
                        label1.Invoke(new Action(() =>
                        {
                            label1.Text = "";
                        }));
                    }
                });
                //TIControl.SetVisible(this.mpsIsRunning, value);
                //TIControl.SetSpinning(this.mpsIsRunning, value);
            }
        }

        public FormCorrector()
        {
            InitializeComponent();

            gcEDocs.DataSource = new List<EDoc>();

            DevExpress.XtraGrid.Columns.GridColumn col = gridView1.Columns.ToList().FirstOrDefault(x => x.FieldName == nameof(EDoc.ToStringCSV));
            if (col != null) col.Visible = false;
            col = gridView1.Columns.ToList().FirstOrDefault(x => x.FieldName == nameof(EDoc.ToStringColumnsCSV));
            if (col != null) col.Visible = false;
        }

        List<EDoc> edocs = new List<EDoc>();

        private void Form1_Resize(object sender, EventArgs e)
        {
            button3.Left = (Width / 2) - button3.Width;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (edocs == null || edocs.Count <= 0) return;
            _ = Task.Run(() =>
            {
                IsRunning = true;

                if (!button3.InvokeRequired)
                    button3.Enabled = false;
                else
                    button3.Invoke(new Action(() => { button3.Enabled = false; }));

                decimal sum = 0M;
                if (this.nudSum.Value == 0)
                    sum = Math.Round(edocs.Sum(x => x.PayVAT) / 0.18M, 2);
                else sum = this.nudSum.Value;
                foreach (EDoc item in edocs)
                {
                    if (edocs.Sum(x => x.PayMain) == sum)
                    {
                        break;
                    }
                    decimal esasmin1 = Math.Round(((item.PayMain - 0.01M) * 0.18M), 2);
                    if (esasmin1 == item.PayVAT)
                    {
                        item.PayMain -= 0.01M;
                        item.PaySum = item.PayMain + item.PayVAT;
                        item.Corrected = true;
                    }
                }
                gcEDocs.RefreshDataSource();
                if (!button3.InvokeRequired)
                    button3.Enabled = true;
                else
                    button3.Invoke(new Action(() => { button3.Enabled = true; }));
                IsRunning = false;
                MessageBox.Show(Text + " düzəliş sona çatdı!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            });
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                cmsTo.Show(Cursor.Position);
            }
        }

        private void toCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = Task.Run(() =>
            {
                try
                {
                    IsRunning = true;

                    if (!button3.InvokeRequired)
                        button2.Enabled = false;
                    else
                        button2.Invoke(new Action(() => { button2.Enabled = false; }));

                    string fileName = "EDocs_" + Guid.NewGuid().ToString("N").Substring(0, 4) + ".csv";
                    string location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string customExcelSavingPath = location + "\\" + fileName;

                    using (StreamWriter sw = File.CreateText(customExcelSavingPath))
                    {
                        sw.WriteLine(EDoc.ToStringColumnsCSV());
                        for (int i = 0; i < edocs.Count; i++)
                        {
                            sw.WriteLine(edocs[i].ToStringCSV());
                        }
                    }

                    if (!button3.InvokeRequired)
                        button2.Enabled = true;
                    else
                        button2.Invoke(new Action(() => { button2.Enabled = true; }));

                    IsRunning = false;
                    MessageBox.Show("Fayl: " + customExcelSavingPath + "", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex?.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
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
                object[] values = new object[Props.Length];
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
            _ = Task.Run(() =>
            {
                try
                {
                    IsRunning = true;
                    if (!button3.InvokeRequired)
                        button2.Enabled = false;
                    else
                        button2.Invoke(new Action(() => { button2.Enabled = false; }));

                    string fileName = "EDocs_" + Guid.NewGuid().ToString("N").Substring(0, 4) + ".xlsx";
                    string location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string customExcelSavingPath = location + "\\" + fileName;

                    ExcelExport.GenerateExcel(ConvertToDataTable(edocs), customExcelSavingPath);

                    if (!button3.InvokeRequired)
                        button2.Enabled = true;
                    else
                        button2.Invoke(new Action(() => { button2.Enabled = true; }));
                    IsRunning = false;
                    MessageBox.Show("Fayl: " + customExcelSavingPath + "", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex?.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                cmsFrom.Show(Cursor.Position);
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
                    button1.Enabled = false;
                    try
                    {
                        string filePath = openFileDialog.FileName;

                        using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                int counter = 0;
                                edocs = new List<EDoc>();
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
                                        edoc.DocVAT = Convert.ToDecimal(reader.GetValue(7)?.ToString());
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
                                        edoc.PayVAT = Convert.ToDecimal(reader.GetValue(10)?.ToString());
                                    }
                                    if (reader.FieldCount >= 12)
                                    {
                                        edoc.PaySum = Convert.ToDecimal(reader.GetValue(11)?.ToString());
                                    }
                                    edocs.Add(edoc);
                                }
                            }
                        }

                        gcEDocs.DataSource = edocs;
                        gcEDocs.RefreshDataSource();
                        lblCount.Text = "Sətir sayı: " + edocs.Count.ToString();
                        this.button1.Enabled = true;
                        IsRunning = false;
                        MessageBox.Show(this, Text + " yüklənməsi sona çatdı!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex?.Message + "\n" + ex?.InnerException?.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        throw;
                    }
                    finally
                    {
                        System.GC.Collect();
                    }
                }
            }
        }

        private void toXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tbTIN.Text.Length != 10)
                {
                    this.panel1.Visible = true;
                    this.tbTIN.Focus();
                    MessageBox.Show("VÖEN səhfdir!");
                }
                int.TryParse(this.tbYear.Text, out int year);
                if (this.tbYear.Text.Length != 4 || year <= 2010)
                {
                    this.panel1.Visible = true;
                    this.tbYear.Focus();
                    MessageBox.Show("İl səhfdir!");
                }
                if (this.cbeMonth.SelectedIndex < 0)
                {
                    this.panel1.Visible = true;
                    this.cbeMonth.Focus();
                    MessageBox.Show("Ay seçilməyib!");
                }
                string main = string.Empty;
                string hat = Resources.Hat;
                main += hat;
                main += "\n<product>";
                main += "\n<voen>" + this.tbTIN.Text + "</voen>";
                main += "\n<dovr>" + year.ToString() + (this.cbeMonth.SelectedIndex + 1).ToString("00") + year.ToString() + (this.cbeMonth.SelectedIndex + 1).ToString("00") + "</dovr>";
                main += "\n<ma></ma>";
                main += "\n<mk></mk>";
                main += "\n\t\t<vhfEVEZTable>\n";
                int counter = 0;
                foreach (EDoc item in edocs)
                {
                    main += "\t\t\t" + $@"<row no = '{counter++}'>
				               <ser>{item.Serial}</ser>
				               <nom>{item.Number}</nom>
				               <date>{item.Date.Day.ToString("00")}{item.Date.Month.ToString("00")}{item.Date.Year}</date>
				               <fv>{item.TIN}</fv>
				               <kod>{item.RowCode}</kod>
				               <dovr>{(this.cbeMonth.SelectedIndex + 1).ToString("00")}{year}</dovr>
				               <uMeb>{Math.Round(item.DocMain, 2).ToString().Replace(",", ".")}</uMeb>
				               <uEdv>{Math.Round(item.DocVAT, 2).ToString().Replace(",", ".")}</uEdv>
				               <oMeb>{Math.Round(item.PayMain, 2).ToString().Replace(",", ".")}</oMeb>
				               <oEdv>{Math.Round(item.PayVAT, 2).ToString().Replace(",", ".")}</oEdv>
			               </row>";
                }
                main += "\n\t\t</vhfEVEZTable>";
                main += "\n\t</product>";
                main += "\n</root>";

                string fileName = $@"C_VHF_EVEZ_1_{this.tbTIN.Text}_{DateTime.Now.ToString("yyyyMMdd")}_v_205_{Guid.NewGuid().ToString("N").Substring(0, 4)}.xml";
                string location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string customExcelSavingPath = location + "\\" + fileName;

                File.WriteAllText(customExcelSavingPath, main);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex?.Message + "\n" + ex?.InnerException?.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw;
            }
            finally
            {
                System.GC.Collect();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = !this.panel1.Visible;
        }

        private void fromDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(this.tbYear.Text);
            int month = this.cbeMonth.SelectedIndex;

            try
            {
                string sql = $@"SELECT p.*, (SELECT TOP 1 Ad FROM Voen WITH(NOLOCK) WHERE [Voen] = p.Voen) AS Name
                                FROM [Evhf_paid] p WITH(NOLOCK) 
                                WHERE p.Il = {year} 
                                  AND p.Tip = 0
                                  AND p.AyRub = {month}
                                  AND p.Evezlesen = N'Y';";
                //using (var connection = new SqlConnection(Corrector.Properties.Resources.ConnectingString1098))
                using (var connection = new SqlConnection(Corrector.Properties.Resources.ConnectingString1020))
                {
                    List<dynamic> list = connection.Query<dynamic>(sql).ToList();
                    foreach (var item in list)
                    {
                        EDoc edoc = new EDoc();
                        edoc.TIN = item.Voen;
                        edoc.Name = item.Name;
                        edoc.Date = item.Tarix;
                        edoc.Serial = item.Evhf_sr;
                        edoc.Number = item.Evhf_no;
                        edoc.RowCode = item.Setir_kod;
                        edoc.PayMain = item.Edvsiz;
                        edoc.PayVAT = item.Edv;
                        edoc.PaySum = edoc.PayMain + edoc.PayVAT;

                        //list.Il;
                        //list.Tip;
                        //list.AyRub;
                        //list.Evezlesen;
                        //list.Line_id;
                        //list.LastEditDateTime;
                        //list.LastEditCompName;
                        //list.LastEditUserName;
                        edocs.Add(edoc);
                    }

                    gcEDocs.DataSource = edocs;
                    gcEDocs.RefreshDataSource();
                    lblCount.Text = "Sətir sayı: " + edocs.Count.ToString();
                    this.button1.Enabled = true;
                    IsRunning = false;
                    MessageBox.Show(this, Text + " yüklənməsi sona çatdı!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex?.Message + "\n" + ex?.InnerException?.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw;
            }
            finally
            {
                System.GC.Collect();
            }
        }

        private void toDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(this.tbYear.Text);
            int month = this.cbeMonth.SelectedIndex;

            try
            {
                string sql = string.Empty;

                //using (var connection = new SqlConnection(Corrector.Properties.Resources.ConnectingString1098))
                using (var connection = new SqlConnection(Corrector.Properties.Resources.ConnectingString1020))
                {
                    connection.Open();
                    foreach (EDoc item in edocs)
                    {
                        if (item.Corrected)
                        {
                            sql = $@"UPDATE [Evhf_paid] SET [Edvsiz] = @PayMain
                                     WHERE Il = {year} 
                                       AND Tip = 0
                                       AND AyRub = {month}
                                       AND Setir_kod = @RowCode
                                       AND Evhf_sr = @Serial
                                       AND Evhf_no = @Number
                                       AND Voen = @TIN
                                       AND Evezlesen = N'Y';";
                            int result = connection.Execute(sql, item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex?.Message + "\n" + ex?.InnerException?.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw;
            }
            finally
            {
                System.GC.Collect();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            edocs = new List<EDoc>();
            gcEDocs.DataSource = edocs;
            gcEDocs.RefreshDataSource();
            lblCount.Text = "Sətir sayı: " + edocs.Count.ToString();
            this.button1.Enabled = true;
            IsRunning = false;
        }
    }
}
