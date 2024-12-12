namespace BookmakerOffice
{
    partial class MakeBetForm
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
            this.ParticipantComboBox = new System.Windows.Forms.ComboBox();
            this.BetAmountTextBox = new System.Windows.Forms.TextBox();
            this.MakeBetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bookmakerOfficeDataSet1 = new BookmakerOffice.BookmakerOfficeDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ParticipantComboBox
            // 
            this.ParticipantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParticipantComboBox.FormattingEnabled = true;
            this.ParticipantComboBox.Location = new System.Drawing.Point(251, 62);
            this.ParticipantComboBox.Name = "ParticipantComboBox";
            this.ParticipantComboBox.Size = new System.Drawing.Size(265, 24);
            this.ParticipantComboBox.TabIndex = 0;
            // 
            // BetAmountTextBox
            // 
            this.BetAmountTextBox.Location = new System.Drawing.Point(251, 190);
            this.BetAmountTextBox.Name = "BetAmountTextBox";
            this.BetAmountTextBox.Size = new System.Drawing.Size(263, 22);
            this.BetAmountTextBox.TabIndex = 1;
            // 
            // MakeBetButton
            // 
            this.MakeBetButton.Location = new System.Drawing.Point(319, 321);
            this.MakeBetButton.Name = "MakeBetButton";
            this.MakeBetButton.Size = new System.Drawing.Size(119, 45);
            this.MakeBetButton.TabIndex = 2;
            this.MakeBetButton.Text = "Поставити";
            this.MakeBetButton.UseVisualStyleBackColor = true;
            this.MakeBetButton.Click += new System.EventHandler(this.MakeBetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "На кого ви хочете зробити ставку?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Скільки ви хочете поставити?";
            // 
            // bookmakerOfficeDataSet1
            // 
            this.bookmakerOfficeDataSet1.DataSetName = "BookmakerOfficeDataSet";
            this.bookmakerOfficeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MakeBetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MakeBetButton);
            this.Controls.Add(this.BetAmountTextBox);
            this.Controls.Add(this.ParticipantComboBox);
            this.Name = "MakeBetForm";
            this.Text = "MakeBetForm";
            ((System.ComponentModel.ISupportInitialize)(this.bookmakerOfficeDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ParticipantComboBox;
        private System.Windows.Forms.TextBox BetAmountTextBox;
        private System.Windows.Forms.Button MakeBetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private BookmakerOfficeDataSet bookmakerOfficeDataSet1;
    }
}