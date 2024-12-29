using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookmakerOffice
{
    public partial class UserCabinet : Form
    {
        public UserCabinet()
        {
            InitializeComponent();
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
            {
                decimal minAmount = numericMinAmount.Value;
                decimal maxAmount = numericMaxAmount.Value;

                if (maxAmount < minAmount)
                {
                    MessageBox.Show("Максимальна сума не може бути менше мінімальної",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string filterExpression = $"amount >= {minAmount} AND amount <= {maxAmount}";

                userBetsTableBindingSource.Filter = filterExpression;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userBetsTableBindingSource.RemoveFilter();

        }
    }
}
