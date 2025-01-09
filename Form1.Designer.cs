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
            this.editEventButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteEventButton = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.buttonUserCabinet = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.userTableAdapter = new BookmakerOffice.BookmakerOfficeDataSetTableAdapters.UserTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonFilterDate = new System.Windows.Forms.Button();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.buttonStats = new System.Windows.Forms.Button();
            this.buttonClearFilters = new System.Windows.Forms.Button();
            this.labelBalance = new System.Windows.Forms.Label();
            this.buttonAddBalance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.endeventbutton,
            this.editEventButton,
            this.deleteEventButton});
            this.dataGridView1.DataSource = this.eventTableBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 236);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1682, 297);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EventName
            // 
            this.EventName.DataPropertyName = "eventname";
            this.EventName.HeaderText = "Назва події";
            this.EventName.MinimumWidth = 6;
            this.EventName.Name = "EventName";
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "starttime";
            this.StartTime.HeaderText = "Початок";
            this.StartTime.MinimumWidth = 6;
            this.StartTime.Name = "StartTime";
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "endtime";
            this.EndTime.HeaderText = "Кінець";
            this.EndTime.MinimumWidth = 6;
            this.EndTime.Name = "EndTime";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            this.Status.HeaderText = "Статус";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // SportType
            // 
            this.SportType.DataPropertyName = "sporttype";
            this.SportType.HeaderText = "Тип спорту";
            this.SportType.MinimumWidth = 6;
            this.SportType.Name = "SportType";
            // 
            // Participant1
            // 
            this.Participant1.DataPropertyName = "participant1";
            this.Participant1.HeaderText = "Учасник 1";
            this.Participant1.MinimumWidth = 6;
            this.Participant1.Name = "Participant1";
            this.Participant1.Visible = false;
            // 
            // Participant2
            // 
            this.Participant2.DataPropertyName = "participant2";
            this.Participant2.HeaderText = "Учасник 2";
            this.Participant2.MinimumWidth = 6;
            this.Participant2.Name = "Participant2";
            this.Participant2.Visible = false;
            // 
            // makeBetButton
            // 
            this.makeBetButton.HeaderText = "";
            this.makeBetButton.MinimumWidth = 6;
            this.makeBetButton.Name = "makeBetButton";
            this.makeBetButton.Text = "Зробити ставку";
            this.makeBetButton.UseColumnTextForButtonValue = true;
            // 
            // endeventbutton
            // 
            this.endeventbutton.HeaderText = "";
            this.endeventbutton.MinimumWidth = 6;
            this.endeventbutton.Name = "endeventbutton";
            this.endeventbutton.Text = "Завершити подію";
            this.endeventbutton.UseColumnTextForButtonValue = true;
            // 
            // editEventButton
            // 
            this.editEventButton.HeaderText = "";
            this.editEventButton.MinimumWidth = 6;
            this.editEventButton.Name = "editEventButton";
            this.editEventButton.Text = "Редагувати подію";
            this.editEventButton.UseColumnTextForButtonValue = true;
            this.editEventButton.Visible = false;
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.HeaderText = "";
            this.deleteEventButton.MinimumWidth = 6;
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Text = "Видалити подію";
            this.deleteEventButton.UseColumnTextForButtonValue = true;
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
            this.label1.Font = new System.Drawing.Font("Impact", 18.2F);
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вітаю в нашій букмекерській конторі! Робіть ставки!";
            // 
            // eventTableTableAdapter
            // 
            this.eventTableTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(390, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пошук (за назвою)";
            // 
            // comboBoxSports
            // 
            this.comboBoxSports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSports.FormattingEnabled = true;
            this.comboBoxSports.Location = new System.Drawing.Point(436, 206);
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
            // buttonUserCabinet
            // 
            this.buttonUserCabinet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonUserCabinet.Location = new System.Drawing.Point(1384, 12);
            this.buttonUserCabinet.Name = "buttonUserCabinet";
            this.buttonUserCabinet.Size = new System.Drawing.Size(161, 64);
            this.buttonUserCabinet.TabIndex = 5;
            this.buttonUserCabinet.Text = "Особистий кабінет";
            this.buttonUserCabinet.UseVisualStyleBackColor = true;
            this.buttonUserCabinet.Click += new System.EventHandler(this.buttonUserCabinet_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.userBindingSource;
            this.comboBox1.DisplayMember = "login";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(154, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.ValueMember = "user_id";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "User";
            this.userBindingSource.DataSource = this.bookmakerOfficeDataSetBindingSource;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Категорії";
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Оберіть користувача";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(578, 208);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerStart.TabIndex = 9;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(804, 208);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerEnd.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(578, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Початок події";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(804, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Кінець події";
            // 
            // buttonFilterDate
            // 
            this.buttonFilterDate.Location = new System.Drawing.Point(1026, 181);
            this.buttonFilterDate.Name = "buttonFilterDate";
            this.buttonFilterDate.Size = new System.Drawing.Size(169, 50);
            this.buttonFilterDate.TabIndex = 13;
            this.buttonFilterDate.Text = "Фільтрувати за датою";
            this.buttonFilterDate.UseVisualStyleBackColor = true;
            this.buttonFilterDate.Click += new System.EventHandler(this.buttonFilterDate_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(1384, 183);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(164, 50);
            this.buttonAddEvent.TabIndex = 14;
            this.buttonAddEvent.Text = "Додати подію";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // buttonStats
            // 
            this.buttonStats.Location = new System.Drawing.Point(1384, 112);
            this.buttonStats.Name = "buttonStats";
            this.buttonStats.Size = new System.Drawing.Size(161, 44);
            this.buttonStats.TabIndex = 15;
            this.buttonStats.Text = "Статистики";
            this.buttonStats.UseVisualStyleBackColor = true;
            this.buttonStats.Click += new System.EventHandler(this.buttonStats_Click);
            // 
            // buttonClearFilters
            // 
            this.buttonClearFilters.Location = new System.Drawing.Point(1218, 180);
            this.buttonClearFilters.Name = "buttonClearFilters";
            this.buttonClearFilters.Size = new System.Drawing.Size(136, 51);
            this.buttonClearFilters.TabIndex = 16;
            this.buttonClearFilters.Text = "Очистити фільтри";
            this.buttonClearFilters.UseVisualStyleBackColor = true;
            this.buttonClearFilters.Click += new System.EventHandler(this.buttonClearFilters_Click);
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelBalance.Location = new System.Drawing.Point(1012, 27);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(161, 20);
            this.labelBalance.TabIndex = 17;
            this.labelBalance.Text = "Ваш баланс: 0 грн";
            // 
            // buttonAddBalance
            // 
            this.buttonAddBalance.Location = new System.Drawing.Point(1218, 12);
            this.buttonAddBalance.Name = "buttonAddBalance";
            this.buttonAddBalance.Size = new System.Drawing.Size(147, 64);
            this.buttonAddBalance.TabIndex = 18;
            this.buttonAddBalance.Text = "Додати собі балансу";
            this.buttonAddBalance.UseVisualStyleBackColor = true;
            this.buttonAddBalance.Click += new System.EventHandler(this.buttonAddBalance_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 533);
            this.Controls.Add(this.buttonAddBalance);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.buttonClearFilters);
            this.Controls.Add(this.buttonStats);
            this.Controls.Add(this.buttonAddEvent);
            this.Controls.Add(this.buttonFilterDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonUserCabinet);
            this.Controls.Add(this.comboBoxSports);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSports;
        private System.Windows.Forms.BindingSource sportTypeBindingSource;
        private BookmakerOfficeDataSetTableAdapters.SportTypeTableAdapter sportTypeTableAdapter;
        private System.Windows.Forms.Button buttonUserCabinet;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource userBindingSource;
        private BookmakerOfficeDataSetTableAdapters.UserTableAdapter userTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonFilterDate;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.Button buttonStats;
        private System.Windows.Forms.Button buttonClearFilters;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Button buttonAddBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn SportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Participant1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Participant2;
        private System.Windows.Forms.DataGridViewButtonColumn makeBetButton;
        private System.Windows.Forms.DataGridViewButtonColumn endeventbutton;
        private System.Windows.Forms.DataGridViewButtonColumn editEventButton;
        private System.Windows.Forms.DataGridViewButtonColumn deleteEventButton;
    }
}

