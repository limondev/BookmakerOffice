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
        private string filterSearch = "";
        private string filterSportType = "";
        private string filterDateRange = "";

        public Form1()
        {
            InitializeComponent();
            connectionString = @"Data Source=DESKTOP-J0D4L3T\SQLEXPRESS;Initial Catalog=BookmakerOffice;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";


            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today.AddMonths(1);

            buttonFilterDate.Click += buttonFilterDate_Click;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.bookmakerOfficeDataSet.User);
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.SportType' table. You can move, or remove it, as needed.
            this.sportTypeTableAdapter.Fill(this.bookmakerOfficeDataSet.SportType);
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.EventTable' table. You can move, or remove it, as needed.
            this.eventTableTableAdapter.Fill(this.bookmakerOfficeDataSet.EventTable);

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
            eventTableBindingSource.Filter = "status = 'Заплановано'";
            UpdateUserBalance();

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
            var user_id = (int)comboBox1.SelectedValue;
            var makeBetForm = new MakeBetForm(user_id, event_id, participant1, participant2);
            makeBetForm.ShowDialog();
        }
        private void EventEnd(DataGridViewCellEventArgs e)
        {
            var arr = new string[]{"Команда 1 виграла", "Команда 2 виграла"};
            int winner_index = new Random().Next(0, arr.Length);
            var user_id = (int)comboBox1.SelectedValue;
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
            string searchQuery = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                filterSearch = ""; // Clear the search filter
            }
            else
            {
                filterSearch = $"eventname LIKE '%{searchQuery}%'"; // Adjust field name here
            }

            UpdateFilter();
        }


        private void comboBoxSports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSports.SelectedIndex == 0) // Assuming "All" is the first item
            {
                filterSportType = ""; // Clear sport type filter
            }
            else if (comboBoxSports.SelectedItem is BookmakerOfficeDataSet.SportTypeRow row)
            {
                string selectedSportType = row.name;

                // Adjust "sporttype" to match your DataGridView column name or database field
                filterSportType = $"sporttype = '{selectedSportType}'";
            }

            UpdateFilter();
        }


        private void UpdateFilter()
        {
            // Base filter (default condition)
            string baseFilter = "status = 'Заплановано'";

            // Combine the base filter with additional filters
            string combinedFilter = baseFilter;

            if (!string.IsNullOrWhiteSpace(filterSearch))
            {
                combinedFilter += $" AND {filterSearch}";
            }

            if (!string.IsNullOrWhiteSpace(filterSportType))
            {
                combinedFilter += $" AND {filterSportType}";
            }

            if (!string.IsNullOrWhiteSpace(filterDateRange))
            {
                combinedFilter += $" AND {filterDateRange}";
            }

            eventTableBindingSource.Filter = combinedFilter;
        }

        private void buttonUserCabinet_Click(object sender, EventArgs e)
        {
            var UserCabinet = new UserCabinet();
            UserCabinet.ShowDialog();
        }

        private void buttonFilterDate_Click(object sender, EventArgs e)
        {
            if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
            {
                MessageBox.Show("Кінцева дата не може бути раніше початкової дати!",
                    "Невірний діапазон дат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string startDate = dateTimePickerStart.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            string endDate = dateTimePickerEnd.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");

            filterDateRange = $"starttime >= #{startDate}# AND starttime <= #{endDate}#";
            UpdateFilter();
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            var AddNewEvent = new AddNewEvent();
            var result = AddNewEvent.ShowDialog();
           
            if (result == DialogResult.OK)
            {
                UpdateFilter();
                this.eventTableTableAdapter.Fill(this.bookmakerOfficeDataSet.EventTable);
            }
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            var StatsForm = new StatsForm();
            StatsForm.ShowDialog();
        }

        private void buttonClearFilters_Click(object sender, EventArgs e)
        {
            filterSearch = "";
            filterSportType = "";
            filterDateRange = "";

            textBox1.Text = ""; 
            comboBoxSports.SelectedIndex = 0; 
            dateTimePickerStart.Value = DateTime.Today; 
            dateTimePickerEnd.Value = DateTime.Today.AddMonths(1); 

            UpdateFilter();
        }
        private void buttonAddBalance_Click(object sender, EventArgs e)
        {
            var selectedUserId = (int)comboBox1.SelectedValue;
            var addBalanceForm = new AddBalanceForm(selectedUserId, connectionString);
            addBalanceForm.ShowDialog();

            userTableAdapter.Fill(bookmakerOfficeDataSet.User);
            UpdateUserBalance();
        }
        private void UpdateUserBalance()
        {
            try
            {
                int userId = (int)comboBox1.SelectedValue;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT balance FROM [User] WHERE user_id = @UserId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        var result = command.ExecuteScalar();
                        decimal balance = result != DBNull.Value ? (decimal)result : 0;

                        // Оновлюємо текст у Label
                        labelBalance.Text = $"Баланс: {balance:F2} грн";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при отриманні балансу: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
