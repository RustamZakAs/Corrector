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
            this.gcEDocs = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button3 = new System.Windows.Forms.Button();
            this.nudSum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsFrom.SuspendLayout();
            this.cmsTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSum)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.ContextMenuStrip = this.cmsFrom;
            this.button1.Location = new System.Drawing.Point(12, 419);
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
            this.cmsFrom.Size = new System.Drawing.Size(132, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItem2.Text = "From Excel";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.ContextMenuStrip = this.cmsTo;
            this.button2.Location = new System.Drawing.Point(710, 419);
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
            this.toExcelToolStripMenuItem});
            this.cmsTo.Name = "contextMenuStrip1";
            this.cmsTo.Size = new System.Drawing.Size(137, 48);
            // 
            // toCSVFileToolStripMenuItem
            // 
            this.toCSVFileToolStripMenuItem.Name = "toCSVFileToolStripMenuItem";
            this.toCSVFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.toCSVFileToolStripMenuItem.Text = "To CSV file";
            this.toCSVFileToolStripMenuItem.Click += new System.EventHandler(this.toCSVFileToolStripMenuItem_Click);
            // 
            // toExcelToolStripMenuItem
            // 
            this.toExcelToolStripMenuItem.Name = "toExcelToolStripMenuItem";
            this.toExcelToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.toExcelToolStripMenuItem.Text = "To Excel file";
            this.toExcelToolStripMenuItem.Click += new System.EventHandler(this.toExcelToolStripMenuItem_Click);
            // 
            // gcEDocs
            // 
            this.gcEDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcEDocs.Location = new System.Drawing.Point(12, 12);
            this.gcEDocs.MainView = this.gridView1;
            this.gcEDocs.Name = "gcEDocs";
            this.gcEDocs.Size = new System.Drawing.Size(773, 402);
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
            this.button3.Location = new System.Drawing.Point(358, 419);
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
            this.nudSum.Location = new System.Drawing.Point(93, 421);
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(490, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 15);
            this.label1.TabIndex = 5;
            // 
            // FormCorrector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 447);
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
        private System.Windows.Forms.Label label1;
    }
}

