using BookmakerOffice.BookmakerOfficeDataSetTableAdapters;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookmakerOffice
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private string filterSearch;
        private string filterSportType;
        public Form1()
        {
            InitializeComponent();
            connectionString = @"Data Source=DESKTOP-J0D4L3T\SQLEXPRESS;Initial Catalog=BookmakerOffice;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.SportType' table. You can move, or remove it, as needed.
            this.sportTypeTableAdapter.Fill(this.bookmakerOfficeDataSet.SportType);
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.EventTable' table. You can move, or remove it, as needed.
            this.eventTableTableAdapter.Fill(this.bookmakerOfficeDataSet.EventTable);
            eventTableBindingSource.Filter = "status = 'Заплановано'";
            var sportsTypes = new BookmakerOfficeDataSet.SportTypeDataTable();
            sportTypeTableAdapter.Fill(sportsTypes);
            comboBoxSports.Items.Add("Всі");
            foreach (var sportType in sportsTypes)
            {
                comboBoxSports.Items.Add(sportType);   
            }  
            comboBoxSports.DisplayMember = "name";
            comboBoxSports.ValueMember = "name";
            comboBoxSports.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["makeBetButton"].Index && e.RowIndex >= 0)
            {
                MakeBet(e);
            }
            if (e.ColumnIndex == dataGridView1.Columns["endeventbutton"].Index && e.RowIndex >= 0)
            {
                EventEnd(e);
            }
        }

        private void MakeBet(DataGridViewCellEventArgs e)
        {
            // Retrieve the row data
            var row = dataGridView1.Rows[e.RowIndex];
            DataRowView dataRow = (DataRowView)eventTableBindingSource[e.RowIndex];
            var participant1 = new Participant()
            {
                Id = (int)dataRow["participant1_id"],
                Name = row.Cells["Participant1"].Value.ToString()
            };
            var participant2 = new Participant()
            {
                Id = (int)dataRow["participant2_id"],
                Name = row.Cells["Participant2"].Value.ToString()
            };
            var event_id = (int)dataRow["event_id"];
            var user_id = 1;
            var makeBetForm = new MakeBetForm(user_id, event_id, participant1, participant2);
            makeBetForm.ShowDialog();
        }
        private void EventEnd(DataGridViewCellEventArgs e)
        {
            var arr = new string[]{"Team1Win", "Team2Win"};
            int winner_index = new Random().Next(0, arr.Length);
            var user_id = 1;
            DataRowView dataRow = (DataRowView)eventTableBindingSource[e.RowIndex];
            var event_id = (int)dataRow["event_id"];
            eventTableTableAdapter.UpdateQuery(arr[winner_index], event_id);
            eventTableTableAdapter.Fill(bookmakerOfficeDataSet.EventTable);
            var betcount = new BetTableAdapter().CountBetsByUserAndEvent(user_id, event_id);
            if (betcount == 0)
            {
                MessageBox.Show("Подію завершено, однак ви не поставили жодної ставки :(", "Форма виводу", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var eventEndForm = new EventEndForm(user_id, event_id);
                eventEndForm.ShowDialog();

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text;

            // Assuming your DataGridView is bound to a BindingSource
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                eventTableBindingSource.Filter = null; // Clear filter if search box is empty
            }
            else
            {
                // Adjust "event_name" to match your DataGridView column name or database field
                eventTableBindingSource.Filter = $"eventname LIKE '%{searchQuery}%'";
            }
        }

        private void comboBoxSports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSports.SelectedItem is BookmakerOfficeDataSet.SportTypeRow row)
            {
                string selectedSportType = row.name;

                // Apply filter based on the selected sport type ID
                eventTableBindingSource.Filter = $"sporttype = '{selectedSportType}'";
            }
            else
            {
                // Clear filter if no sport is selected
                eventTableBindingSource.Filter = null;
            }
        }
    }
}
