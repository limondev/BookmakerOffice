namespace BookmakerOffice
{
    partial class ChooseWinnerForm
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
            this.radioButtonParticipant1 = new System.Windows.Forms.RadioButton();
            this.radioButtonParticipant2 = new System.Windows.Forms.RadioButton();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonParticipant1
            // 
            this.radioButtonParticipant1.AutoSize = true;
            this.radioButtonParticipant1.Location = new System.Drawing.Point(12, 12);
            this.radioButtonParticipant1.Name = "radioButtonParticipant1";
            this.radioButtonParticipant1.Size = new System.Drawing.Size(103, 20);
            this.radioButtonParticipant1.TabIndex = 0;
            this.radioButtonParticipant1.TabStop = true;
            this.radioButtonParticipant1.Text = "radioButton1";
            this.radioButtonParticipant1.UseVisualStyleBackColor = true;
            // 
            // radioButtonParticipant2
            // 
            this.radioButtonParticipant2.AutoSize = true;
            this.radioButtonParticipant2.Location = new System.Drawing.Point(12, 39);
            this.radioButtonParticipant2.Name = "radioButtonParticipant2";
            this.radioButtonParticipant2.Size = new System.Drawing.Size(103, 20);
            this.radioButtonParticipant2.TabIndex = 1;
            this.radioButtonParticipant2.TabStop = true;
            this.radioButtonParticipant2.Text = "radioButton2";
            this.radioButtonParticipant2.UseVisualStyleBackColor = true;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(12, 81);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "OK";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // ChooseWinnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 240);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.radioButtonParticipant2);
            this.Controls.Add(this.radioButtonParticipant1);
            this.Name = "ChooseWinnerForm";
            this.Text = "ChooseWinnerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonParticipant1;
        private System.Windows.Forms.RadioButton radioButtonParticipant2;
        private System.Windows.Forms.Button buttonConfirm;
    }
}