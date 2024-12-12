namespace BookmakerOffice
{
    partial class EventEndForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.usersBetsByEventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookmakerOfficeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookmakerOfficeDataSet = new BookmakerOffice.BookmakerOfficeDataSet();
            this.usersBetsByEventTableAdapter = new BookmakerOffice.BookmakerOfficeDataSetTableAdapters.UsersBetsByEventTableAdapter();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.participantname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBetsByEventBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.amountDataGridViewTextBoxColumn,
            this.eventname,
            this.participantname,
            this.result,
            this.dateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.usersBetsByEventBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 238);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // usersBetsByEventBindingSource
            // 
            this.usersBetsByEventBindingSource.DataMember = "UsersBetsByEvent";
            this.usersBetsByEventBindingSource.DataSource = this.bookmakerOfficeDataSetBindingSource;
            // 
            // bookmakerOfficeDataSetBindingSource
            // 
            this.bookmakerOfficeDataSetBindingSource.DataSource = this.bookmakerOfficeDataSet;
            this.bookmakerOfficeDataSetBindingSource.Position = 0;
            // 
            // bookmakerOfficeDataSet
            // 
            this.bookmakerOfficeDataSet.DataSetName = "BookmakerOfficeDataSet";
            this.bookmakerOfficeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBetsByEventTableAdapter
            // 
            this.usersBetsByEventTableAdapter.ClearBeforeFill = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сума ставки";
            this.amountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 125;
            // 
            // eventname
            // 
            this.eventname.DataPropertyName = "eventname";
            this.eventname.HeaderText = "Назва події";
            this.eventname.MinimumWidth = 6;
            this.eventname.Name = "eventname";
            this.eventname.Width = 125;
            // 
            // participantname
            // 
            this.participantname.DataPropertyName = "participantname";
            this.participantname.HeaderText = "Ім\'я учасника";
            this.participantname.MinimumWidth = 6;
            this.participantname.Name = "participantname";
            this.participantname.Width = 125;
            // 
            // result
            // 
            this.result.DataPropertyName = "result";
            this.result.HeaderText = "Результат";
            this.result.MinimumWidth = 6;
            this.result.Name = "result";
            this.result.Width = 125;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Час";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // EventEndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EventEndForm";
            this.Text = "EventEndButton";
            this.Load += new System.EventHandler(this.EventEndForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBetsByEventBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource usersBetsByEventBindingSource;
        private System.Windows.Forms.BindingSource bookmakerOfficeDataSetBindingSource;
        private BookmakerOfficeDataSet bookmakerOfficeDataSet;
        private BookmakerOfficeDataSetTableAdapters.UsersBetsByEventTableAdapter usersBetsByEventTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventname;
        private System.Windows.Forms.DataGridViewTextBoxColumn participantname;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
    }
}