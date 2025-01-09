using BookmakerOffice.BookmakerOfficeDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookmakerOffice
{
    public partial class MakeBetForm : Form
    {
        private int event_id;
        private int user_id;
        private readonly string connectionString;

        public MakeBetForm(int user_id, int event_id, Participant participant1, Participant participant2, string connectionString)
        {
            InitializeComponent();
            this.event_id = event_id;
            this.user_id = user_id;
            this.connectionString = connectionString;

            ParticipantComboBox.Items.Add(participant1);
            ParticipantComboBox.Items.Add(participant2);
            ParticipantComboBox.ValueMember = nameof(Participant.Id);
            ParticipantComboBox.DisplayMember = nameof(Participant.Name);
            ParticipantComboBox.SelectedIndex = 0;

            // Display current balance
            UpdateBalanceLabel();
        }

        private void UpdateBalanceLabel()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT balance FROM [User] WHERE user_id = @UserId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", user_id);
                        var result = command.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Користувача не знайдено!");
                            return;
                        }

                        decimal balance = result != DBNull.Value ? (decimal)result : 0;
                        labelBalance.Text = $"Ваш поточний баланс: {balance:F2} грн";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при отриманні балансу: " + ex.Message);
            }
        }


        private void MakeBetButton_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(BetAmountTextBox.Text, out decimal amount))
            {
                MessageBox.Show("Будь ласка, введіть коректну суму ставки.");
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Сума ставки повинна бути більше нуля.");
                return;
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        // Перевірка балансу
                        var balanceQuery = "SELECT balance FROM [User] WHERE user_id = @UserId";
                        using (var balanceCommand = new SqlCommand(balanceQuery, connection, transaction))
                        {
                            balanceCommand.Parameters.AddWithValue("@UserId", user_id);
                            var currentBalance = (decimal?)balanceCommand.ExecuteScalar() ?? 0;

                            if (currentBalance < amount)
                            {
                                MessageBox.Show("Недостатньо коштів на балансі для здійснення ставки.");
                                return;
                            }
                        }

                        var updateBalanceQuery = "UPDATE [User] SET balance = balance - @Amount WHERE user_id = @UserId";
                        using (var updateCommand = new SqlCommand(updateBalanceQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@Amount", amount);
                            updateCommand.Parameters.AddWithValue("@UserId", user_id);
                            updateCommand.ExecuteNonQuery();
                        }
                        var insertBetQuery = "INSERT INTO Bet (bet_id, amount, result, date, status, user_id, event_id, participant_id) VALUES (@BetId, @Amount, 'Заплановано', GETDATE(), 'Pending', @UserId, @EventId, @ParticipantId)";
                        using (var insertCommand = new SqlCommand(insertBetQuery, connection, transaction))
                        {
                            var participant = (Participant)ParticipantComboBox.SelectedItem;
                            BetTableAdapter adapter = new BetTableAdapter();

                            int newBetId = (int)adapter.GetNextID();

                            insertCommand.Parameters.AddWithValue("@BetId", newBetId);
                            insertCommand.Parameters.AddWithValue("@Amount", amount);
                            insertCommand.Parameters.AddWithValue("@UserId", user_id);
                            insertCommand.Parameters.AddWithValue("@EventId", event_id);
                            insertCommand.Parameters.AddWithValue("@ParticipantId", participant.Id);

                            insertCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Ставку успішно зроблено!");
                        UpdateBalanceLabel(); // Оновлення балансу після ставки
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при створенні ставки: {ex.Message}");
            }
        }


    }
}