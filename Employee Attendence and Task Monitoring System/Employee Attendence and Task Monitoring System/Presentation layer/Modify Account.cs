using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee_Attendence_and_Task_Monitoring_System.Presentation_layer;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer
{
    public partial class Modify_Account : Form
    {
         Data d = new Data();
         BLL b = new BLL();
        //Admin_Info ai ; 
        public Modify_Account()
        {
            InitializeComponent();
        }
        public void GridUpdate()
        {
            dataGridView1.DataSource = d.viewemp(b);
        }
        private void Modify_Account_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = d.viewemp(b);
            dataGridView1.DataSource = dt; 
            
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (b.modifydata( textBox1.Text , Convert.ToInt32(textBox2.Text),  dateTimePicker1.Value, dateTimePicker2.Value, textBox6.Text, Convert.ToInt32(textBox3.Text)))
            {
                GridUpdate();
                MessageBox.Show("Account is Successfully Modified");
            }
            else
            {
                MessageBox.Show("Error in Modifying Account");
            }
        }

        private void Modify_Account_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ai = new Admin_Info();
            //ai.Show(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
