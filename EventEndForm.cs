using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BookmakerOffice
{
    public partial class EventEndForm : Form
    {
        private int _event_id;
        private int _user_id;
        private string connectionString;

        public EventEndForm(int user_id, int event_id, string connectionString)
        {
            _user_id = user_id;
            _event_id = event_id;
            this.connectionString = connectionString;
            InitializeComponent();
        }

        private void EventEndForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Завантажуємо ставки користувача на цей івент
                usersBetsByEventTableAdapter.FillUsersBetsByEventID(bookmakerOfficeDataSet.UsersBetsByEvent, _user_id, _event_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні ставок: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            // Отримуємо значення колонки "result"
            var resultValue = row.Cells["result"].Value;

            // Встановлюємо кольори рядків відповідно до результату
            if (resultValue != null)
            {
                if (resultValue.ToString() == "Виграш")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (resultValue.ToString() == "Поразка")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow; // Інші статуси
                }
            }
        }
    }
}
