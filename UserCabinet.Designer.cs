namespace BookmakerOffice
{
    partial class UserCabinet
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookmakerOfficeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookmakerOfficeDataSet = new BookmakerOffice.BookmakerOfficeDataSet();
            this.userTableAdapter = new BookmakerOffice.BookmakerOfficeDataSetTableAdapters.UserTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.EventsByUserTable = new System.Windows.Forms.DataGridView();
            this.eventnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.participantnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.betidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteBetButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.userBetsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBetsTableTableAdapter = new BookmakerOffice.BookmakerOfficeDataSetTableAdapters.UserBetsTableTableAdapter();
            this.numericMinAmount = new System.Windows.Forms.NumericUpDown();
            this.numericMaxAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFilterAmount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExportToPDF = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventsByUserTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBetsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.userBindingSource;
            this.comboBox1.DisplayMember = "login";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(229, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(329, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "user_id";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "User";
            this.userBindingSource.DataSource = this.bookmakerOfficeDataSetBindingSource;
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
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Оберіть користувача";
            // 
            // EventsByUserTable
            // 
            this.EventsByUserTable.AutoGenerateColumns = false;
            this.EventsByUserTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventsByUserTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventnameDataGridViewTextBoxColumn,
            this.participantnameDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.result,
            this.dateDataGridViewTextBoxColumn,
            this.betidDataGridViewTextBoxColumn,
            this.deleteBetButton});
            this.EventsByUserTable.DataSource = this.userBetsTableBindingSource;
            this.EventsByUserTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EventsByUserTable.Location = new System.Drawing.Point(0, 168);
            this.EventsByUserTable.Name = "EventsByUserTable";
            this.EventsByUserTable.RowHeadersWidth = 51;
            this.EventsByUserTable.RowTemplate.Height = 24;
            this.EventsByUserTable.Size = new System.Drawing.Size(996, 316);
            this.EventsByUserTable.TabIndex = 2;
            this.EventsByUserTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EventsByUserTable_CellContentClick);
            // 
            // eventnameDataGridViewTextBoxColumn
            // 
            this.eventnameDataGridViewTextBoxColumn.DataPropertyName = "eventname";
            this.eventnameDataGridViewTextBoxColumn.HeaderText = "Подія";
            this.eventnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eventnameDataGridViewTextBoxColumn.Name = "eventnameDataGridViewTextBoxColumn";
            this.eventnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // participantnameDataGridViewTextBoxColumn
            // 
            this.participantnameDataGridViewTextBoxColumn.DataPropertyName = "participantname";
            this.participantnameDataGridViewTextBoxColumn.HeaderText = "Учасник";
            this.participantnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.participantnameDataGridViewTextBoxColumn.Name = "participantnameDataGridViewTextBoxColumn";
            this.participantnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сума";
            this.amountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 125;
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
            this.dateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // betidDataGridViewTextBoxColumn
            // 
            this.betidDataGridViewTextBoxColumn.DataPropertyName = "bet_id";
            this.betidDataGridViewTextBoxColumn.HeaderText = "bet_id";
            this.betidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.betidDataGridViewTextBoxColumn.Name = "betidDataGridViewTextBoxColumn";
            this.betidDataGridViewTextBoxColumn.Visible = false;
            this.betidDataGridViewTextBoxColumn.Width = 125;
            // 
            // deleteBetButton
            // 
            this.deleteBetButton.HeaderText = "";
            this.deleteBetButton.MinimumWidth = 6;
            this.deleteBetButton.Name = "deleteBetButton";
            this.deleteBetButton.Text = "Видалити";
            this.deleteBetButton.UseColumnTextForButtonValue = true;
            this.deleteBetButton.Width = 125;
            // 
            // userBetsTableBindingSource
            // 
            this.userBetsTableBindingSource.DataMember = "UserBetsTable";
            this.userBetsTableBindingSource.DataSource = this.bookmakerOfficeDataSetBindingSource;
            // 
            // userBetsTableTableAdapter
            // 
            this.userBetsTableTableAdapter.ClearBeforeFill = true;
            // 
            // numericMinAmount
            // 
            this.numericMinAmount.Location = new System.Drawing.Point(389, 143);
            this.numericMinAmount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericMinAmount.Name = "numericMinAmount";
            this.numericMinAmount.Size = new System.Drawing.Size(91, 22);
            this.numericMinAmount.TabIndex = 3;
            // 
            // numericMaxAmount
            // 
            this.numericMaxAmount.Location = new System.Drawing.Point(550, 143);
            this.numericMaxAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericMaxAmount.Name = "numericMaxAmount";
            this.numericMaxAmount.Size = new System.Drawing.Size(91, 22);
            this.numericMaxAmount.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Мін. сума ставки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Макс. сума ставки";
            // 
            // btnFilterAmount
            // 
            this.btnFilterAmount.Location = new System.Drawing.Point(668, 130);
            this.btnFilterAmount.Name = "btnFilterAmount";
            this.btnFilterAmount.Size = new System.Drawing.Size(127, 32);
            this.btnFilterAmount.TabIndex = 7;
            this.btnFilterAmount.Text = "Застосувати";
            this.btnFilterAmount.UseVisualStyleBackColor = true;
            this.btnFilterAmount.Click += new System.EventHandler(this.btnFilterAmount_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(833, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Прибрати фільтр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.Location = new System.Drawing.Point(801, 13);
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(183, 36);
            this.btnExportToPDF.TabIndex = 9;
            this.btnExportToPDF.Text = "Вивести звіт ставок";
            this.btnExportToPDF.UseVisualStyleBackColor = true;
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(16, 140);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(285, 22);
            this.textBoxSearch.TabIndex = 10;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Пошук";
            // 
            // UserCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 484);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.btnExportToPDF);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFilterAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericMaxAmount);
            this.Controls.Add(this.numericMinAmount);
            this.Controls.Add(this.EventsByUserTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "UserCabinet";
            this.Text = "UserCabinet";
            this.Load += new System.EventHandler(this.UserCabinet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventsByUserTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBetsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource bookmakerOfficeDataSetBindingSource;
        private BookmakerOfficeDataSet bookmakerOfficeDataSet;
        private System.Windows.Forms.BindingSource userBindingSource;
        private BookmakerOfficeDataSetTableAdapters.UserTableAdapter userTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView EventsByUserTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userBetsTableBindingSource;
        private BookmakerOfficeDataSetTableAdapters.UserBetsTableTableAdapter userBetsTableTableAdapter;
        private System.Windows.Forms.NumericUpDown numericMinAmount;
        private System.Windows.Forms.NumericUpDown numericMaxAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFilterAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn participantnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn betidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn deleteBetButton;
        private System.Windows.Forms.Button btnExportToPDF;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label4;
    }
}