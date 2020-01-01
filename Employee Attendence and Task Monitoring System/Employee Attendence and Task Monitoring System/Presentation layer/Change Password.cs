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
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer
{
    public partial class Change_Password : Form
    {
        Data d = new Data();
        BLL b = new BLL();
       // Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Employee.Employee_Info ei; 
        public Change_Password()
        {
            InitializeComponent();
        }

        private void Change_Password_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (b.modifypassdata(textBox1.Text, Convert.ToInt32(label4.Text)))
            {
               
                MessageBox.Show("Password Changed Successfully");
            }
            else
            {
                MessageBox.Show("Error durring password change");
            }
            textBox1.Text = "";
            label4.Text = "";
            label8.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ei = new Employee.Employee_Info();
            //ei.Show(); 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
