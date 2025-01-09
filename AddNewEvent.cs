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
        private DataView participantView;

        public AddNewEvent()
        {

            InitializeComponent();

            // Create a DataView for filtering
            participantView = new DataView(this.bookmakerOfficeDataSet.Participant);

            // Set the DataSource of participant comboboxes to the DataView
            comboBox1.DataSource = participantView;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "participant_id";

            comboBox2.DataSource = participantView;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "participant_id";
        }

        private void AddNewEvent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.SportType' table. You can move, or remove it, as needed.
            this.sportTypeTableAdapter.Fill(this.bookmakerOfficeDataSet.SportType);
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.Participant' table. You can move, or remove it, as needed.
            this.participantTableAdapter.Fill(this.bookmakerOfficeDataSet.Participant);
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue != null)
            {
                // Get selected sport type ID
                int sportTypeId = Convert.ToInt32(comboBox3.SelectedValue);

                // Update filter
                participantView.RowFilter = $"sport_type_id = {sportTypeId}";

                // Reset participant selections
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
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
