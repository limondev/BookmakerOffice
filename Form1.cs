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
            // Завантажуємо дані користувачів
            this.userTableAdapter.Fill(this.bookmakerOfficeDataSet.User);

            // Завантажуємо типи спорту
            this.sportTypeTableAdapter.Fill(this.bookmakerOfficeDataSet.SportType);

            // Завантажуємо події
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

            // Встановлюємо поточного користувача, якщо є
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                currentUserId = (int)comboBox1.SelectedValue;
            }

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
            if (e.ColumnIndex == dataGridView1.Columns["deleteEventButton"].Index && e.RowIndex >= 0)
            {
                DeleteEvent(e);
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

            var makeBetForm = new MakeBetForm(user_id, event_id, participant1, participant2, connectionString);

            if (makeBetForm.ShowDialog() == DialogResult.OK)
            {
                UpdateUserBalance();
            }
        }
        private void EventEnd(DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var participant1Name = row.Cells["Participant1"].Value.ToString();
            var participant2Name = row.Cells["Participant2"].Value.ToString();

            using (var chooseWinnerForm = new ChooseWinnerForm(participant1Name, participant2Name))
            {
                if (chooseWinnerForm.ShowDialog() == DialogResult.OK)
                {
                    var chosenWinnerStatus = chooseWinnerForm.SelectedWinner;
                    DataRowView dataRow = (DataRowView)eventTableBindingSource[e.RowIndex];
                    var event_id = (int)dataRow["event_id"];
                    var user_id = (int)comboBox1.SelectedValue;

                    try
                    {
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (var transaction = connection.BeginTransaction())
                            {
                                try
                                {
                                    // Update event status
                                    string updateEventStatusQuery = @"
                                UPDATE Event
                                SET event_status = @new_status
                                WHERE event_id = @event_id;";

                                    using (var updateEventCommand = new SqlCommand(updateEventStatusQuery, connection, transaction))
                                    {
                                        updateEventCommand.Parameters.AddWithValue("@new_status", chosenWinnerStatus);
                                        updateEventCommand.Parameters.AddWithValue("@event_id", event_id);
                                        updateEventCommand.ExecuteNonQuery();
                                    }

                                    // Get winner and loser IDs
                                    string getTeamsQuery = @"
                                SELECT 
                                    participant_id,
                                    participant2_id
                                FROM 
                                    ParticipantTournament
                                WHERE 
                                    participant_tournament_id = (
                                        SELECT participant_tournament_id 
                                        FROM Event 
                                        WHERE event_id = @event_id
                                    );";

                                    int winningTeamId = 0;
                                    int losingTeamId = 0;

                                    using (var getTeamsCommand = new SqlCommand(getTeamsQuery, connection, transaction))
                                    {
                                        getTeamsCommand.Parameters.AddWithValue("@event_id", event_id);
                                        using (var reader = getTeamsCommand.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                int participant1Id = reader.GetInt32(reader.GetOrdinal("participant_id"));
                                                int participant2Id = reader.GetInt32(reader.GetOrdinal("participant2_id"));

                                                if (chosenWinnerStatus == "Команда 1 виграла")
                                                {
                                                    winningTeamId = participant1Id;
                                                    losingTeamId = participant2Id;
                                                }
                                                else if (chosenWinnerStatus == "Команда 2 виграла")
                                                {
                                                    winningTeamId = participant2Id;
                                                    losingTeamId = participant1Id;
                                                }
                                            }
                                        }
                                    }

                                    // Update bet results
                                    string updateBetResultsQuery = @"
                                UPDATE Bet
                                SET result = CASE 
                                    WHEN participant_id = @WinningTeamId THEN 'Виграш'
                                    WHEN participant_id = @LosingTeamId THEN 'Поразка'
                                END
                                WHERE event_id = @event_id;";

                                    using (var updateBetResultsCommand = new SqlCommand(updateBetResultsQuery, connection, transaction))
                                    {
                                        updateBetResultsCommand.Parameters.AddWithValue("@WinningTeamId", winningTeamId);
                                        updateBetResultsCommand.Parameters.AddWithValue("@LosingTeamId", losingTeamId);
                                        updateBetResultsCommand.Parameters.AddWithValue("@event_id", event_id);
                                        updateBetResultsCommand.ExecuteNonQuery();
                                    }

                                    // Update user balances for ALL winning bets
                                    string updateUserBalanceQuery = @"
                                DECLARE @WinningBets TABLE (
                                    user_id INT,
                                    total_winnings DECIMAL(18,2)
                                );

                                INSERT INTO @WinningBets (user_id, total_winnings)
                                SELECT 
                                    user_id,
                                    SUM(amount * 2) as total_winnings
                                FROM Bet
                                WHERE event_id = @event_id
                                    AND participant_id = @WinningTeamId
                                    AND result = 'Виграш'
                                GROUP BY user_id;

                                UPDATE u
                                SET u.balance = u.balance + wb.total_winnings
                                FROM [User] u
                                INNER JOIN @WinningBets wb ON u.user_id = wb.user_id;";

                                    using (var updateUserBalanceCommand = new SqlCommand(updateUserBalanceQuery, connection, transaction))
                                    {
                                        updateUserBalanceCommand.Parameters.AddWithValue("@event_id", event_id);
                                        updateUserBalanceCommand.Parameters.AddWithValue("@WinningTeamId", winningTeamId);
                                        updateUserBalanceCommand.ExecuteNonQuery();
                                    }

                                    transaction.Commit();

                                    // Refresh data
                                    eventTableTableAdapter.Fill(bookmakerOfficeDataSet.EventTable);
                                    UpdateUserBalance();

                                    // Check for bets and show results
                                    var betcount = new BetTableAdapter().CountBetsByUserAndEvent(user_id, event_id);
                                    if (betcount == 0)
                                    {
                                        MessageBox.Show("Подію завершено, однак ви не поставили жодної ставки :(",
                                            "Форма виводу", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        var eventEndForm = new EventEndForm(user_id, event_id, connectionString);
                                        eventEndForm.ShowDialog();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show($"Помилка при завершенні події: {ex.Message}",
                                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при підключенні до бази даних: {ex.Message}",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteEvent(DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            if (row.DataBoundItem is DataRowView dataRow)
            {
                int eventId = (int)dataRow["event_id"]; // Отримуємо ID події для видалення

                var result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цю подію?",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string deleteEventQuery = "DELETE FROM Event WHERE event_id = @eventId";

                            using (var command = new SqlCommand(deleteEventQuery, connection))
                            {
                                command.Parameters.AddWithValue("@eventId", eventId);
                                command.ExecuteNonQuery();
                            }
                        }

                        // Видаляємо рядок із DataGridView
                        eventTableBindingSource.RemoveAt(e.RowIndex);

                        MessageBox.Show("Подію успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при видаленні події: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
        private int currentUserId = -1;
        private void buttonAddBalance_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || !(comboBox1.SelectedValue is int selectedUserId))
            {
                MessageBox.Show("Користувач не вибраний!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addBalanceForm = new AddBalanceForm(selectedUserId, connectionString)
            {
                Owner = this // Встановлюємо власника форми для оновлення балансу після закриття
            };
            addBalanceForm.ShowDialog();

            // Оновлюємо дані користувачів та баланс після поповнення
            userTableAdapter.Fill(bookmakerOfficeDataSet.User);
            UpdateUserBalance();
        }

        private void UpdateUserBalance()
        {
            try
            {
                // Перевіряємо, чи є вибраний користувач
                if (currentUserId < 0)
                {
                    MessageBox.Show("Користувач не вибраний!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT balance FROM [User] WHERE user_id = @UserId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", currentUserId);
                        var result = command.ExecuteScalar();
                        decimal balance = result != DBNull.Value ? (decimal)result : 0;

                        // Оновлюємо текст у Label
                        if (labelBalance != null)
                        {
                            labelBalance.Text = $"Баланс: {balance:F2} грн";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при отриманні балансу: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue is int selectedUserId)
            {
                currentUserId = selectedUserId;
                UpdateUserBalance();
            }
        }

    }
}
