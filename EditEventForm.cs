
using System;
using System.Windows.Forms;

namespace BookmakerOffice
{
    public partial class EditEventForm : Form
    {
        public EditEventForm()
        {
            InitializeComponent();

            // Заповнення ComboBox для вибору типу спорту
            cmbSportType.Items.AddRange(new string[] { "Футбол", "Баскетбол", "Теніс", "Хокей" });
        }

        // Обробник для кнопки "Зберегти"
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Перевірка валідності введених даних
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                MessageBox.Show("Будь ласка, введіть назву події.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbSportType.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть тип спорту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Дата початку не може бути пізніше за дату завершення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Якщо все гаразд, закриваємо форму зі статусом OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Обробник для кнопки "Скасувати"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
