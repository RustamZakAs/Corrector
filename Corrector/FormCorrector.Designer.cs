namespace Corrector
{
    partial class FormCorrector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.cmsFrom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.cmsTo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toXMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gcEDocs = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button3 = new System.Windows.Forms.Button();
            this.nudSum = new System.Windows.Forms.NumericUpDown();
            this.lblCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbeMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTIN = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsFrom.SuspendLayout();
            this.cmsTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSum)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.ContextMenuStrip = this.cmsFrom;
            this.button1.Location = new System.Drawing.Point(12, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "From";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // cmsFrom
            // 
            this.cmsFrom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.cmsFrom.Name = "cmsFrom";
            this.cmsFrom.Size = new System.Drawing.Size(133, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem2.Text = "From Excel";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.ContextMenuStrip = this.cmsTo;
            this.button2.Location = new System.Drawing.Point(710, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "To";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button2_MouseClick);
            // 
            // cmsTo
            // 
            this.cmsTo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toCSVFileToolStripMenuItem,
            this.toExcelToolStripMenuItem,
            this.toXMLFileToolStripMenuItem});
            this.cmsTo.Name = "contextMenuStrip1";
            this.cmsTo.Size = new System.Drawing.Size(136, 70);
            // 
            // toCSVFileToolStripMenuItem
            // 
            this.toCSVFileToolStripMenuItem.Name = "toCSVFileToolStripMenuItem";
            this.toCSVFileToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.toCSVFileToolStripMenuItem.Text = "To CSV file";
            this.toCSVFileToolStripMenuItem.Click += new System.EventHandler(this.toCSVFileToolStripMenuItem_Click);
            // 
            // toExcelToolStripMenuItem
            // 
            this.toExcelToolStripMenuItem.Name = "toExcelToolStripMenuItem";
            this.toExcelToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.toExcelToolStripMenuItem.Text = "To Excel file";
            this.toExcelToolStripMenuItem.Click += new System.EventHandler(this.toExcelToolStripMenuItem_Click);
            // 
            // toXMLFileToolStripMenuItem
            // 
            this.toXMLFileToolStripMenuItem.Name = "toXMLFileToolStripMenuItem";
            this.toXMLFileToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.toXMLFileToolStripMenuItem.Text = "To XML file";
            this.toXMLFileToolStripMenuItem.Click += new System.EventHandler(this.toXMLFileToolStripMenuItem_Click);
            // 
            // gcEDocs
            // 
            this.gcEDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcEDocs.Location = new System.Drawing.Point(12, 17);
            this.gcEDocs.MainView = this.gridView1;
            this.gcEDocs.Name = "gcEDocs";
            this.gcEDocs.Size = new System.Drawing.Size(773, 331);
            this.gcEDocs.TabIndex = 2;
            this.gcEDocs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcEDocs;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(358, 353);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Correct";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // nudSum
            // 
            this.nudSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudSum.DecimalPlaces = 2;
            this.nudSum.Location = new System.Drawing.Point(93, 355);
            this.nudSum.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudSum.Name = "nudSum";
            this.nudSum.Size = new System.Drawing.Size(151, 20);
            this.nudSum.TabIndex = 4;
            this.nudSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSum.Visible = false;
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(640, 1);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(142, 15);
            this.lblCount.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "by Rustam Zak As";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cbeMonth);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbYear);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbTIN);
            this.panel1.Location = new System.Drawing.Point(503, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 82);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // cbeMonth
            // 
            this.cbeMonth.Location = new System.Drawing.Point(61, 56);
            this.cbeMonth.Name = "cbeMonth";
            this.cbeMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeMonth.Properties.Items.AddRange(new object[] {
            "Yanvar",
            "Fevral",
            "Mart",
            "Aprel",
            "May",
            "İyun",
            "İyul",
            "Avqust",
            "Sentyabr",
            "Oktyabr",
            "Noyabr",
            "Dekabr"});
            this.cbeMonth.Size = new System.Drawing.Size(136, 20);
            this.cbeMonth.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ay:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "İl:";
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(61, 30);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(136, 20);
            this.tbYear.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "VÖEN:";
            // 
            // tbTIN
            // 
            this.tbTIN.Location = new System.Drawing.Point(61, 4);
            this.tbTIN.Name = "tbTIN";
            this.tbTIN.Size = new System.Drawing.Size(136, 20);
            this.tbTIN.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(629, 353);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "İnfo";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(474, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 23);
            this.label1.TabIndex = 5;
            // 
            // FormCorrector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 381);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudSum);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gcEDocs);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormCorrector";
            this.Text = "Corrector";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.cmsFrom.ResumeLayout(false);
            this.cmsTo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeMonth.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraGrid.GridControl gcEDocs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip cmsTo;
        private System.Windows.Forms.ToolStripMenuItem toCSVFileToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown nudSum;
        private System.Windows.Forms.ToolStripMenuItem toExcelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsFrom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toXMLFileToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.ComboBoxEdit cbeMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTIN;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
    }
}

