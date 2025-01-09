using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BookmakerOffice
{
    public partial class UserCabinet : Form
    {
        private string connectionString;
        private string filterSearch = "";
        private string filterAmountRange = "";

        public UserCabinet()
        {
            InitializeComponent();
            connectionString = @"Data Source=DESKTOP-J0D4L3T\SQLEXPRESS;Initial Catalog=BookmakerOffice;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        }

        private void UserCabinet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookmakerOfficeDataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.bookmakerOfficeDataSet.User);
            LoadData();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            int user_id = (int)comboBox1.SelectedValue;
            userBetsTableTableAdapter.FillBetsByUser(bookmakerOfficeDataSet.UserBetsTable, user_id);

        }

        private void btnFilterAmount_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(numericMinAmount.Text, out decimal minAmount))
            {
                minAmount = 0; // Якщо значення некоректне, встановлюємо мінімум
            }

            if (!decimal.TryParse(numericMaxAmount.Text, out decimal maxAmount))
            {
                maxAmount = decimal.MaxValue; // Якщо значення некоректне, встановлюємо максимум
            }

            filterAmountRange = $"amount >= {minAmount} AND amount <= {maxAmount}";

            UpdateFilter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                filterSearch = "";
                filterAmountRange = "";

                textBoxSearch.Text = "";
                numericMinAmount.Text = "";
                numericMaxAmount.Text = "";

                UpdateFilter();
        }

        private void EventsByUserTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == EventsByUserTable.Columns["deleteBetButton"].Index && e.RowIndex >= 0)
            {
                DeleteBet(e);
            }
        }
        private void DeleteBet(DataGridViewCellEventArgs e)
        {
            var row = EventsByUserTable.Rows[e.RowIndex];
            if (row.DataBoundItem is DataRowView dataRow)
            {
                int betId = (int)dataRow["bet_id"]; // Отримуємо ID ставки для видалення

                var result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цю ставку?",
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

                            string deleteBetQuery = "DELETE FROM Bet WHERE bet_id = @betId";

                            using (var command = new SqlCommand(deleteBetQuery, connection))
                            {
                                command.Parameters.AddWithValue("@betId", betId);
                                command.ExecuteNonQuery();
                            }
                        }

                        // Видаляємо рядок із DataGridView
                        userBetsTableBindingSource.RemoveAt(e.RowIndex);

                        MessageBox.Show("Ставку успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при видаленні ставки: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                filterSearch = ""; // Очистити фільтр пошуку
            }
            else
            {
                // Замініть "eventname" на назву колонки, яку потрібно шукати
                filterSearch = $"eventname LIKE '%{searchQuery}%'";
            }

            UpdateFilter();
        }
        private void UpdateFilter()
        {
            string baseFilter = ""; // Базовий фільтр, якщо необхідний

            if (!string.IsNullOrWhiteSpace(filterSearch))
            {
                baseFilter += filterSearch;
            }

            if (!string.IsNullOrWhiteSpace(filterAmountRange))
            {
                if (!string.IsNullOrWhiteSpace(baseFilter))
                {
                    baseFilter += " AND ";
                }
                baseFilter += filterAmountRange;
            }

            userBetsTableBindingSource.Filter = baseFilter;
        }
    
    private void btnExportToPDF_Click(object sender, EventArgs e)
        {
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Будь ласка, виберіть користувача з випадаючого списку.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int userId = (int)comboBox1.SelectedValue;
                string userName = comboBox1.Text; // Отримання імені користувача з ComboBox

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF файли (*.pdf)|*.pdf",
                    Title = "Зберегти PDF",
                    FileName = $"{userName}_Ставки.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string pdfPath = saveFileDialog.FileName;

                        var betsTable = new BookmakerOfficeDataSet.UserBetsTableDataTable();
                        userBetsTableTableAdapter.FillBetsByUser(betsTable, userId);

                        if (betsTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Ставки для цього користувача відсутні.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        var baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        var font = new iTextSharp.text.Font(baseFont, 12);

                        using (var pdfDoc = new Document())
                        {
                            PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                            pdfDoc.Open();

                            // Додати заголовок
                            var title = new Paragraph($"Ставки користувача: {userName}\n\n", font);
                            pdfDoc.Add(title);

                            // Створення таблиці
                            var pdfTable = new PdfPTable(6) // 6 колонок
                            {
                                WidthPercentage = 100
                            };

                            // Додавання заголовків таблиці
                            pdfTable.AddCell(new PdfPCell(new Phrase("ID ставки", font)));
                            pdfTable.AddCell(new PdfPCell(new Phrase("Назва події", font)));
                            pdfTable.AddCell(new PdfPCell(new Phrase("Учасник", font)));
                            pdfTable.AddCell(new PdfPCell(new Phrase("Сума", font)));
                            pdfTable.AddCell(new PdfPCell(new Phrase("Дата", font)));
                            pdfTable.AddCell(new PdfPCell(new Phrase("Результат", font)));

                            // Додавання даних
                            foreach (DataRow row in betsTable.Rows)
                            {
                                pdfTable.AddCell(new PdfPCell(new Phrase(row["bet_id"].ToString(), font)));
                                pdfTable.AddCell(new PdfPCell(new Phrase(row["eventname"].ToString(), font)));
                                pdfTable.AddCell(new PdfPCell(new Phrase(row["participantname"].ToString(), font)));
                                pdfTable.AddCell(new PdfPCell(new Phrase(row["amount"].ToString(), font)));
                                pdfTable.AddCell(new PdfPCell(new Phrase(Convert.ToDateTime(row["date"]).ToString("dd.MM.yyyy"), font)));
                                pdfTable.AddCell(new PdfPCell(new Phrase(row["result"].ToString(), font)));
                            }

                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                        }

                        MessageBox.Show("PDF успішно збережено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });

                }
                catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при створенні PDF: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


    }

}
    
