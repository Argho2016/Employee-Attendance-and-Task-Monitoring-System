using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer
{
    public partial class Delete_Account : Form
    {
        Data d = new Data();
        BLL b = new BLL();
        Admin_Info ai; 
        public Delete_Account()
        {
            InitializeComponent();
        }
        public void GridUpdate()
        {
            dataGridView1.DataSource = d.viewemp(b);
        }
        private void Delete_Account_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ai = new Admin_Info();
            ai.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (d.Delete(Convert.ToInt32(textBox3.Text)))
            {
                GridUpdate();
                MessageBox.Show("Account is Successfully deleted");
            }
            else
            {
                MessageBox.Show("Error in deleting account");

            }
        }

        private void Delete_Account_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = d.viewemp(b);
            dataGridView1.DataSource = dt; 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
