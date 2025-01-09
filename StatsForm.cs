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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics;

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

        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF файли (*.pdf)|*.pdf",
                    Title = "Зберегти PDF",
                    FileName = $"{comboBoxStats.SelectedItem.ToString()}_Статистика.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pdfPath = saveFileDialog.FileName;

                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter writer = PdfWriter.GetInstance(document, fs);
                        document.Open();

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        var baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        var font = new iTextSharp.text.Font(baseFont, 12);

                        Paragraph title = new Paragraph(comboBoxStats.SelectedItem.ToString(), font);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 20f;
                        document.Add(title);

                        PdfPTable table = new PdfPTable(dataGridViewStats.Columns.Count);
                        table.WidthPercentage = 100;

                        // Додаємо заголовки стовпців
                        for (int i = 0; i < dataGridViewStats.Columns.Count; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(dataGridViewStats.Columns[i].HeaderText, font));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell.Padding = 5;
                            table.AddCell(cell);
                        }

                        // Додаємо дані
                        for (int i = 0; i < dataGridViewStats.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridViewStats.Columns.Count; j++)
                            {
                                var value = dataGridViewStats.Rows[i].Cells[j].Value;
                                string cellText = value != null ? value.ToString() : "";

                                PdfPCell cell = new PdfPCell(new Phrase(cellText, font));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.Padding = 5;
                                table.AddCell(cell);
                            }
                        }

                        document.Add(table);
                        document.Close();
                        writer.Close();
                        fs.Close();

                        MessageBox.Show("PDF файл успішно створено!", "Успіх",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при створенні PDF: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

