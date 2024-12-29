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
    public partial class EventEndForm : Form
    {
        private int _event_id;
        private int _user_id;
        public EventEndForm(int user_id, int event_id)
        {
            _user_id = user_id;
            _event_id = event_id;
            InitializeComponent();

        }

        private void EventEndForm_Load(object sender, EventArgs e)
        {
            usersBetsByEventTableAdapter.FillUsersBetsByEventID(bookmakerOfficeDataSet.UsersBetsByEvent,_user_id, _event_id);
           

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            // Retrieve the value of the "result" column (adjust name to match your DataGridView)
            var resultValue = row.Cells["result"].Value;

            // Check the value and set row colors
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
                    row.DefaultCellStyle.BackColor = Color.LightYellow; // For other statuses
                }
            }

        }
    }
}
