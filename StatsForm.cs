using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BookmakerOffice
{
    public partial class StatsForm : Form
    {
        private string connectionString;

        public StatsForm()
        {
            InitializeComponent();
            connectionString = @"Data Source=DESKTOP-J0D4L3T\SQLEXPRESS;Initial Catalog=BookmakerOffice;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        }

        private void StatsForm_Load(object sender, EventArgs e)
        {
            // Заповнюємо ComboBox типами статистики
            comboBoxStats.Items.Add("Користувачі з найбільшими ставками");
            comboBoxStats.Items.Add("Події з найбільшими ставками");
            comboBoxStats.Items.Add("Кількість ставок по типу спорту");
            comboBoxStats.Items.Add("Середній розмір ставок по типам спорту");
            comboBoxStats.SelectedIndex = 0; // Вибираємо перший елемент за замовчуванням

            LoadStats();
        }

        private void comboBoxStats_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Завантажуємо відповідну статистику при зміні вибору
            LoadStats();
        }

        private void LoadStats()
        {
            string query = "";

            switch (comboBoxStats.SelectedIndex)
            {
                case 0: // Користувачі з найбільшими ставками
                    query = @"
                        SELECT TOP 10 
                        u.name AS [Користувач],
                        SUM(b.amount) AS [Загальна сума ставок]
                        FROM 
                            Bet b
                        INNER JOIN 
                            [User] u ON b.user_id = u.user_id
                        GROUP BY 
                            u.name
                        ORDER BY 
                            [Загальна сума ставок] DESC;";
                    break;

                case 1: // Події з найбільшими ставками
                    query = @"
                       SELECT TOP 10 
                        e.name AS [Подія],
                        SUM(b.amount) AS [Загальна сума ставок]
                    FROM 
                        Bet b
                    INNER JOIN 
                        Event e ON b.event_id = e.event_id
                    GROUP BY 
                        e.name
                    ORDER BY 
                        [Загальна сума ставок] DESC;";
                    break;

                case 2: // Кількість ставок по типу спорту
                    query = @"
                        SELECT 
                        st.name AS [Тип спорту],
                        COUNT(b.bet_id) AS [Кількість ставок]
                    FROM 
                        Bet b
                    INNER JOIN 
                        Event e ON b.event_id = e.event_id
                    INNER JOIN 
                        SportType st ON e.sport_type_id = st.sport_type_id
                    GROUP BY 
                        st.name
                    ORDER BY 
                        [Кількість ставок] DESC;";
                    break;

                case 3: 
                    query = @"SELECT 
                            st.name AS [Тип спорту],
                            AVG(b.amount) AS [Середній розмір ставки]
                        FROM 
                            Bet b
                        INNER JOIN 
                            Event e ON b.event_id = e.event_id
                        INNER JOIN 
                            SportType st ON e.sport_type_id = st.sport_type_id
                        GROUP BY 
                            st.name
                        ORDER BY 
                            [Середній розмір ставки] DESC;
                        ";
                    break;



                default:
                    MessageBox.Show("Виберіть коректну статистику.");
                    return;
            }

            LoadData(query);
        }

        private void LoadData(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewStats.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження даних: {ex.Message}");
                }
            }
        }
    }
}

