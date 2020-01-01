using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;
using Employee_Attendence_and_Task_Monitoring_System.Presentation_layer;

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer
{
    public partial class InboxAll : Form
    {
        
        Data d = new Data();
        BLL b = new BLL();
        Send_Message sm;
        Supervisor.Supervisor_Info si;
        Admin_Info ai;
        Employee.Employee_Info ei;
        int ab;
       // Employee.Employee_Info ei; 
        public InboxAll()
        {
            InitializeComponent();
        }
        public InboxAll(int a)
        {
            InitializeComponent();
            ab = a;


        }
        

        private void InboxAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ab == 1)
            {
                this.Hide();
                si = new Supervisor.Supervisor_Info();
                si.Show();
            }
            else if (ab == 4)
            {
                this.Hide();
                ai = new Admin_Info();
                ai.Show();
            }
            else 
            {
                this.Hide();
                ei = new Employee.Employee_Info();
                ei.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            sm = new Send_Message();
            sm.Show(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InboxAll_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = d.viewmsg(b);
            dataGridView1.DataSource = dt;
        }
    }
}
