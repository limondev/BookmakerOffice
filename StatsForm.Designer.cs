using System;

namespace BookmakerOffice
{
    partial class StatsForm
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
            this.comboBoxStats = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            this.bookmakerOfficeDataSet = new BookmakerOffice.BookmakerOfficeDataSet();
            this.bookmakerOfficeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonExportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxStats
            // 
            this.comboBoxStats.FormattingEnabled = true;
            this.comboBoxStats.Location = new System.Drawing.Point(182, 25);
            this.comboBoxStats.Name = "comboBoxStats";
            this.comboBoxStats.Size = new System.Drawing.Size(393, 24);
            this.comboBoxStats.TabIndex = 0;
            this.comboBoxStats.SelectedIndexChanged += new System.EventHandler(this.comboBoxStats_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Оберіть статистику";
            // 
            // dataGridViewStats
            // 
            this.dataGridViewStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStats.Location = new System.Drawing.Point(-3, 119);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.RowHeadersWidth = 51;
            this.dataGridViewStats.RowTemplate.Height = 24;
            this.dataGridViewStats.Size = new System.Drawing.Size(794, 333);
            this.dataGridViewStats.TabIndex = 2;
            // 
            // bookmakerOfficeDataSet
            // 
            this.bookmakerOfficeDataSet.DataSetName = "BookmakerOfficeDataSet";
            this.bookmakerOfficeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookmakerOfficeDataSetBindingSource
            // 
            this.bookmakerOfficeDataSetBindingSource.DataSource = this.bookmakerOfficeDataSet;
            this.bookmakerOfficeDataSetBindingSource.Position = 0;
            // 
            // buttonExportPDF
            // 
            this.buttonExportPDF.Location = new System.Drawing.Point(629, 25);
            this.buttonExportPDF.Name = "buttonExportPDF";
            this.buttonExportPDF.Size = new System.Drawing.Size(128, 37);
            this.buttonExportPDF.TabIndex = 3;
            this.buttonExportPDF.Text = "Експорт в PDF";
            this.buttonExportPDF.UseVisualStyleBackColor = true;
            this.buttonExportPDF.Click += new System.EventHandler(this.buttonExportPDF_Click);
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonExportPDF);
            this.Controls.Add(this.dataGridViewStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxStats);
            this.Name = "StatsForm";
            this.Text = "StatsForm";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewStats;
        private System.Windows.Forms.BindingSource bookmakerOfficeDataSetBindingSource;
        private BookmakerOfficeDataSet bookmakerOfficeDataSet;
        private System.Windows.Forms.Button buttonExportPDF;
    }
}