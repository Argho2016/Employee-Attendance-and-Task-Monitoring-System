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
    
    public partial class Send_Message : Form
    {
       
        public Data d = new Data();
        public BLL b = new BLL();
        InboxAll ia;
     //   Admin_Info ai;
        //Supervisor.Supervisor_Info si;
      //  Employee.Employee_Info ei; 
        
        public Send_Message()
        {
            InitializeComponent();
        }

        private void Send_Message_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ia = new InboxAll();
            ia.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (d.Insert(Convert.ToInt32( textBox1.Text), textBox3.Text))
            {
                MessageBox.Show("Message sent Successfully");

            }
            else {
                MessageBox.Show("Message not sent ");
            
            }
            textBox1.Text = "";
            textBox3.Text = "";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Send_Message_Load(object sender, EventArgs e)
        {

        }
    }
}
