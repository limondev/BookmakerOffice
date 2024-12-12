namespace BookmakerOffice
{
    partial class Form1
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
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SportType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Participant1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Participant2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makeBetButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.endeventbutton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.eventTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookmakerOfficeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookmakerOfficeDataSet = new BookmakerOffice.BookmakerOfficeDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.eventTableTableAdapter = new BookmakerOffice.BookmakerOfficeDataSetTableAdapters.EventTableTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSports = new System.Windows.Forms.ComboBox();
            this.sportTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sportTypeTableAdapter = new BookmakerOffice.BookmakerOfficeDataSetTableAdapters.SportTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventName,
            this.StartTime,
            this.EndTime,
            this.Status,
            this.SportType,
            this.Participant1,
            this.Participant2,
            this.makeBetButton,
            this.endeventbutton});
            this.dataGridView1.DataSource = this.eventTableBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1330, 399);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EventName
            // 
            this.EventName.DataPropertyName = "eventname";
            this.EventName.HeaderText = "Назва події";
            this.EventName.MinimumWidth = 6;
            this.EventName.Name = "EventName";
            this.EventName.ReadOnly = true;
            this.EventName.Width = 125;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "starttime";
            this.StartTime.HeaderText = "Початок";
            this.StartTime.MinimumWidth = 6;
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 125;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "endtime";
            this.EndTime.HeaderText = "Кінець";
            this.EndTime.MinimumWidth = 6;
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            this.Status.HeaderText = "Статус";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 125;
            // 
            // SportType
            // 
            this.SportType.DataPropertyName = "sporttype";
            this.SportType.HeaderText = "Тип спорту";
            this.SportType.MinimumWidth = 6;
            this.SportType.Name = "SportType";
            this.SportType.ReadOnly = true;
            this.SportType.Width = 125;
            // 
            // Participant1
            // 
            this.Participant1.DataPropertyName = "participant1";
            this.Participant1.HeaderText = "Учасник 1";
            this.Participant1.MinimumWidth = 6;
            this.Participant1.Name = "Participant1";
            this.Participant1.ReadOnly = true;
            this.Participant1.Visible = false;
            this.Participant1.Width = 125;
            // 
            // Participant2
            // 
            this.Participant2.DataPropertyName = "participant2";
            this.Participant2.HeaderText = "Учасник 2";
            this.Participant2.MinimumWidth = 6;
            this.Participant2.Name = "Participant2";
            this.Participant2.ReadOnly = true;
            this.Participant2.Visible = false;
            this.Participant2.Width = 125;
            // 
            // makeBetButton
            // 
            this.makeBetButton.HeaderText = "";
            this.makeBetButton.MinimumWidth = 6;
            this.makeBetButton.Name = "makeBetButton";
            this.makeBetButton.ReadOnly = true;
            this.makeBetButton.Text = "Зробити ставку";
            this.makeBetButton.UseColumnTextForButtonValue = true;
            this.makeBetButton.Width = 125;
            // 
            // endeventbutton
            // 
            this.endeventbutton.HeaderText = "";
            this.endeventbutton.MinimumWidth = 6;
            this.endeventbutton.Name = "endeventbutton";
            this.endeventbutton.ReadOnly = true;
            this.endeventbutton.Text = "Завершити подію";
            this.endeventbutton.UseColumnTextForButtonValue = true;
            this.endeventbutton.Width = 125;
            // 
            // eventTableBindingSource
            // 
            this.eventTableBindingSource.DataMember = "EventTable";
            this.eventTableBindingSource.DataSource = this.bookmakerOfficeDataSetBindingSource;
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(874, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вітаю в нашій букмекерській конторі! Робіть ставки!";
            // 
            // eventTableTableAdapter
            // 
            this.eventTableTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(390, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пошук";
            // 
            // comboBoxSports
            // 
            this.comboBoxSports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSports.FormattingEnabled = true;
            this.comboBoxSports.Location = new System.Drawing.Point(603, 106);
            this.comboBoxSports.Name = "comboBoxSports";
            this.comboBoxSports.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSports.TabIndex = 4;
            this.comboBoxSports.SelectedIndexChanged += new System.EventHandler(this.comboBoxSports_SelectedIndexChanged);
            // 
            // sportTypeBindingSource
            // 
            this.sportTypeBindingSource.DataMember = "SportType";
            this.sportTypeBindingSource.DataSource = this.bookmakerOfficeDataSetBindingSource;
            // 
            // sportTypeTableAdapter
            // 
            this.sportTypeTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 533);
            this.Controls.Add(this.comboBoxSports);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bookmakerOfficeDataSetBindingSource;
        private BookmakerOfficeDataSet bookmakerOfficeDataSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource eventTableBindingSource;
        private BookmakerOfficeDataSetTableAdapters.EventTableTableAdapter eventTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn назваПодіїDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn початокDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кінецьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn типСпортуDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn учасник1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn учасник2DataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn SportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Participant1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Participant2;
        private System.Windows.Forms.DataGridViewButtonColumn makeBetButton;
        private System.Windows.Forms.DataGridViewButtonColumn endeventbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSports;
        private System.Windows.Forms.BindingSource sportTypeBindingSource;
        private BookmakerOfficeDataSetTableAdapters.SportTypeTableAdapter sportTypeTableAdapter;
    }
}

