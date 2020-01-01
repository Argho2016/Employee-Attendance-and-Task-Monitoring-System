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
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;
using System.Data.SqlClient;



namespace Employee_Attendence_and_Task_Monitoring_System
{
    public partial class Form1 : Form
    {
        //Admin_Info ai ;
        
         Data d = new Data();
         
        // timecalculate cal;
         BLL b = new BLL();
         public string usertype; 
        DataTable dt = new DataTable(); 
        public Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Employee.Employee_Info ei;
        public Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Supervisor.Supervisor_Info si;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.ID = Convert.ToInt32(textBox1.Text);
            b.password = textBox2.Text;
            dt = d.logininfo(b);
            if (dt.Rows.Count > 0)
            {
                usertype = dt.Rows[0][6].ToString().Trim();
                if (usertype == "Admin")
                {
                    this.Hide(); 
                    Admin_Info si = new Admin_Info();
                   

                    si.Show();
         SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G7IISFU;Initial Catalog=Data;Integrated Security=True");
         con.Open();
         
         string query = "select * from t2 where ID = '"+textBox1.Text+"'";
         SqlCommand cmd = new SqlCommand(query, con);
         SqlDataReader sdr = cmd.ExecuteReader();
         if (sdr.Read())
             si.label8.Text = (sdr["Name"].ToString());
         si.label9.Text = (sdr["ID"].ToString());
         si.label10.Text = (sdr["Salary"].ToString());
         si.label13.Text = (sdr["DOB"].ToString());
         si.label12.Text = (sdr["JoiningDate"].ToString());
         si.label11.Text = (sdr["Email"].ToString());

         timecalculate ti = new timecalculate(textBox1.Text);
         if (sdr.Read())
             ti.label7.Text = (sdr["ID"].ToString());

         con.Close();
                }
                    
                else if (usertype == "Supervisor")
                {
                    this.Hide();
                   Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Supervisor.Supervisor_Info si = new Presentation_layer.Supervisor.Supervisor_Info(textBox1.Text);
                   //cal = new timecalculate(textBox1.Text);
                    si.Show();
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G7IISFU;Initial Catalog=Data;Integrated Security=True");
                    con.Open();
                    string query = "select * from t2 where ID = '" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    si.label8.Text = (sdr["Name"].ToString());
                    si.label9.Text = (sdr["ID"].ToString());
                    si.label10.Text = (sdr["Salary"].ToString());
                    si.label13.Text = (sdr["DOB"].ToString());
                    si.label12.Text = (sdr["JoiningDate"].ToString());
                    si.label11.Text = (sdr["Email"].ToString());


                    timecalculate ti = new timecalculate(textBox1.Text);
                    if (sdr.Read())
                       ti.label7.Text = (sdr["ID"].ToString());
           


                    con.Close();

                   

                    
                }

                else if (usertype == "Officer")
                {
                    this.Hide();
                    Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Employee.Employee_Info ei = new Presentation_layer.Employee.Employee_Info(textBox1.Text);
                    ei.Show();
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G7IISFU;Initial Catalog=Data;Integrated Security=True");
                    con.Open();
                    string query = "select * from t2 where ID = '" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                        ei.label8.Text = (sdr["Name"].ToString());
                    ei.label9.Text = (sdr["ID"].ToString());
                    ei.label10.Text = (sdr["Salary"].ToString());
                    ei.label13.Text = (sdr["DOB"].ToString());
                    ei.label12.Text = (sdr["JoiningDate"].ToString());
                    ei.label11.Text = (sdr["Email"].ToString());


                    timecalculate ti = new timecalculate(textBox1.Text);
                    if (sdr.Read())
                        ti.label7.Text = (sdr["ID"].ToString());
           

                    con.Close();
                }
            }
            else {
                MessageBox.Show("Invalid ID or Password");
            }

              

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
