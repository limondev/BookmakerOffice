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
    public partial class AddNewEvent : Form
    {
        public AddNewEvent()
        {

            InitializeComponent();

        }

        private void AddNewEvent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.SportType' table. You can move, or remove it, as needed.
            this.sportTypeTableAdapter.Fill(this.bookmakerOfficeDataSet.SportType);
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.Participant' table. You can move, or remove it, as needed.
            this.participantTableAdapter.Fill(this.bookmakerOfficeDataSet.Participant);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введіть назву події");
                return;
            }
            try
            {
                DataRow ptRow = this.bookmakerOfficeDataSet.ParticipantTournament.NewRow();
                ptRow["participant_id"] = comboBox1.SelectedValue;
                ptRow["tournament_id"] = 1;
                ptRow["participant2_id"] = comboBox2.SelectedValue;
                this.bookmakerOfficeDataSet.ParticipantTournament.Rows.Add(ptRow);
                participantTournamentTableAdapter1.Update(this.bookmakerOfficeDataSet.ParticipantTournament);

                DataRow eventRow = this.bookmakerOfficeDataSet.Event.NewRow();
                eventRow["name"] = textBox1.Text;
                eventRow["event_start_time"] = dateTimePicker1.Value;
                eventRow["event_end_time"] = dateTimePicker2.Value;
                eventRow["event_status"] = "Заплановано";
                eventRow["sport_type_id"] = comboBox3.SelectedValue;
                eventRow["participant_tournament_id"] = ptRow["participant_tournament_id"];

                this.bookmakerOfficeDataSet.Event.Rows.Add(eventRow);
                eventTableAdapter1.Update(this.bookmakerOfficeDataSet.Event);
                MessageBox.Show("Подію успішно додано");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні події: {ex.Message}");
            }
        }
    }
}
