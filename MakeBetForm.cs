using BookmakerOffice.BookmakerOfficeDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookmakerOffice
{
    public partial class MakeBetForm : Form
    {
        private int _event_id;
        private int _user_id;

        public MakeBetForm(int user_id, int event_id, Participant participant1, Participant participant2)
        {
            InitializeComponent();
            _event_id = event_id;
            _user_id = user_id;
            ParticipantComboBox.Items.Add(participant1);
            ParticipantComboBox.Items.Add(participant2);
            ParticipantComboBox.ValueMember = nameof(Participant.Id);
            ParticipantComboBox.DisplayMember = nameof(Participant.Name);
            ParticipantComboBox.SelectedIndex = 0;
        }

        private void MakeBetButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(BetAmountTextBox.Text, out decimal amount))
            {
                BetTableAdapter adapter = new BetTableAdapter();
                int new_id = (int)adapter.GetNextID();
                Participant participant = (Participant)ParticipantComboBox.SelectedItem;
                adapter.MakeNewBet(new_id, amount, _user_id, _event_id, participant.Id);
                // update bettable 
                Close();
            }
        }
    }
}
