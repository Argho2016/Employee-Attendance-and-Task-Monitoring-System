using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;
using Employee_Attendence_and_Task_Monitoring_System.Presentation_layer;

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer
{
    public partial class Create_Account : Form
    {
        string usertype;
        public Data d = new Data();
        public BLL b = new BLL();
        public Admin_Info ai;
        public Create_Account()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Create_Account_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ai = new Admin_Info();
           // ai.Show();
            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                usertype = "Admin";
            }
            if (radioButton2.Checked == true)
            {
                usertype = "Supervisor";
            }
            if (radioButton3.Checked == true)
            {
                usertype = "Officer";
            }
            b.usertype = usertype;

            b.name = textBox1.Text;
            b.ID = Convert.ToInt32(textBox3.Text);
            b.salary = Convert.ToInt32(textBox2.Text);
            b.DOB = Convert.ToDateTime(dateTimePicker1.Value);
            b.joinDate = Convert.ToDateTime(dateTimePicker2.Value);
            b.email = textBox6.Text;
            b.password = textBox4.Text;
            int rows = d.insertEMP(b);
            if (rows > 0)
            {
                MessageBox.Show("Account created Successfully ");
            }
            else {
                MessageBox.Show("Problem in creating account ");

            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy"; 


            
        }

        private void Create_Account_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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
