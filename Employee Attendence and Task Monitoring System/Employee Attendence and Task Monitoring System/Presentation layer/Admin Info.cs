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


namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer
{
    
    public partial class Admin_Info : Form
    {
         Data d = new Data();
        BLL b = new BLL();

        
        DataTable dt = new DataTable(); 
        Create_Account ca  = new Create_Account();
        Modify_Account ma = new Modify_Account();
        Delete_Account da = new Delete_Account();
        User_List ul = new User_List();
        Send_Message sm = new Send_Message();
        User_Login_History uh = new User_Login_History();
        Form1 f = new Form1();
        InboxAll ia = new InboxAll();
        
        public static string empid;


        public Admin_Info()
        {
            InitializeComponent();

        }        
        
        public Admin_Info(string c)
        {
            InitializeComponent();
            empid = c;
            label9.Text = empid; 
            

        }

        private void Admin_Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ca.Show(); 
            
            ca = new Create_Account();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ma.Show();
          ma = new Modify_Account();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            da.Show();
            da = new Delete_Account();
            
           // this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ul.Show();
            ul = new User_List();
            
          //  this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ia = new InboxAll(4);

            ia.Show();
            
           // this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uh.Show();
            uh = new User_Login_History();
            
           // this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            f.Show();
            f = new Form1();
            
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Info_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
