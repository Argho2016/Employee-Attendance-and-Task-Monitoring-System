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

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Employee
{
    public partial class Task_Manager : Form
    {
        Data d = new Data();
        BLL b = new BLL();
        //Employee_Info ei;
        public Task_Manager()
        {
            InitializeComponent();
        }
        public void GridUpdate()
        {
            dataGridView1.DataSource = d.viewtask(b);
        }
        private void Task_Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           // ei = new Employee_Info();
           // ei.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (b.modifytaskdata(label5.Text, textBox2.Text, Convert.ToInt32(label4.Text)))
            {
                GridUpdate();
                MessageBox.Show("Task status changed Successfully ");
            }
            else
            {
                MessageBox.Show("Task status not changed ");

            }
        }

        private void Task_Manager_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = d.viewtask(b);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
