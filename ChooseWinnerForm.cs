using System;
using System.Windows.Forms;

namespace BookmakerOffice
{
    public partial class ChooseWinnerForm : Form
    {
        public string SelectedWinner { get; private set; }

        public ChooseWinnerForm(string participant1Name, string participant2Name)
        {
            InitializeComponent();

            // Встановлюємо назви учасників на RadioButton
            radioButtonParticipant1.Text = participant1Name;
            radioButtonParticipant2.Text = participant2Name;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (radioButtonParticipant1.Checked)
            {
                SelectedWinner = "Команда 1 виграла";
            }
            else if (radioButtonParticipant2.Checked)
            {
                SelectedWinner = "Команда 2 виграла";
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть переможця!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
