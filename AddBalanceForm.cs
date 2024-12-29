using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookmakerOffice
{
    public partial class AddBalanceForm : Form
    {
        private int user_id;
        private string connectionString;

        public AddBalanceForm(int userId, string connectionString)
        {
            InitializeComponent();
            this.user_id = userId;
            this.connectionString = connectionString;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxAmount.Text, out decimal amount) && amount > 0)
            {
                try
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        var query = "UPDATE [User] SET balance = balance + @amount WHERE user_id = @user_id";
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@amount", amount);
                            command.Parameters.AddWithValue("@user_id", user_id);
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Баланс успішно поповнено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка під час поповнення балансу: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введіть коректну суму!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}


