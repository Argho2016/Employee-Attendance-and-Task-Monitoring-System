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
using Employee_Attendence_and_Task_Monitoring_System;
using Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Employee;
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Employee
{
    public partial class Employee_Info : Form
    {
        Data d = new Data();
        BLL b = new BLL();
        Task_Manager tm;
        Send_Message sm;
        InboxAll ia;
        
        //public int c;
        Form1 f;
        //Change_Password ch;
        timecalculate ti;
       public static string empid;
       
        public Employee_Info()
        {
            InitializeComponent();
        }
        public Employee_Info(string c)
        {
            InitializeComponent();
            empid = c;
            label9.Text = empid; 
        }

        private void Employee_Info_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Employee_Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ti = new timecalculate();
            ti.Show();/*
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G7IISFU;Initial Catalog=Data;Integrated Security=True");
            con.Open();
            string query = "select * from t2 where ID = '" + label9.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
                ti.label7.Text = (sdr["ID"].ToString());
           

            con.Close();
*/

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // this.Hide();
            tm =new Task_Manager();
            tm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // this.Hide();
            sm = new Send_Message();
            sm.Show(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // this.Hide();
            
            ia = new InboxAll();
            ia.Show(); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
           this.Hide();
            f = new Form1();
            f.Show(); 
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           // this.Hide();
            
            Change_Password ch = new Change_Password();
            ch.Show();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G7IISFU;Initial Catalog=Data;Integrated Security=True");
            con.Open();
            string query = "select * from t2 where ID = '" + label9.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
                ch.label8.Text = (sdr["Password"].ToString());
            ch.label4.Text = (sdr["ID"].ToString());
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
