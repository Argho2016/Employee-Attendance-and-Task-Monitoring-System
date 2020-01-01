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

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Supervisor
{
    public partial class Assign_Task : Form
    {
        Data d = new Data();
        BLL b = new BLL();
        //Supervisor_Info si;
        public Assign_Task()
        {
            InitializeComponent();
        }
        public void GridUpdate()
        {
            dataGridView1.DataSource = d.viewtask(b);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //si = new Supervisor_Info();
            //si.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.task = textBox1.Text;
            b.ID = Convert.ToInt32(textBox3.Text);
            b.deadline = Convert.ToDateTime(dateTimePicker1.Value);
            b.taskstatus = label1.Text;
            label1.Text = "Incomplete";
            
            int rows = d.taskassigner(b);
            if (rows > 0)
            {
                GridUpdate();
                MessageBox.Show("Task assigned Successfully ");



            }
            else
            {
                MessageBox.Show("Task not assigned ");

            }
            textBox1.Text = "";
            textBox3.Text = "";

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Assign_Task_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void Assign_Task_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = d.viewtask(b);
            dataGridView1.DataSource = dt; 
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
