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
using System.Data.SqlClient;

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Supervisor
{
    public partial class Supervisor_Info : Form
    {
        Data d = new Data();
        BLL b = new BLL();
        DataTable dt = new DataTable();
        Form1 f;
        Assign_Task at;
        //Send_Message sm;
        InboxAll ia;
        public int c;
        public Change_Password ch;
        timecalculate ti;
        static string supid; 
        public Supervisor_Info()
        {
            InitializeComponent();
        }
       
        public Supervisor_Info(string b)
        {
            InitializeComponent();
            supid = b;
            label9.Text = supid; 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Supervisor_Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            f = new Form1();
            f.Show(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // this.Hide();
            at = new Assign_Task();
            at.Show(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.Hide();
          
            ia = new InboxAll(1);
            ia.Show(); 
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            Change_Password ch = new Change_Password();
            ch.Show();
          /* SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G7IISFU;Initial Catalog=Data;Integrated Security=True");
            con.Open();
            string query = "select * from t2 where ID = '" + label9.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
                ch.label8.Text = (sdr["Password"].ToString());
            ch.label4.Text = (sdr["ID"].ToString());  
            con.Close();*/
        }

        private void Supervisor_Info_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ti = new timecalculate();
            ti.Show();
        }
    }
}
