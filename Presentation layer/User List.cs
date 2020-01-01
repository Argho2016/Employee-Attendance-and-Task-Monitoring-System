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

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer
{
    public partial class User_List : Form
    {
        Data d = new Data();
        BLL b = new BLL();
        //Admin_Info ai; 
        public User_List()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void User_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ad = new Admin_Info();
            //ad.Show(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = d.viewemp(b);
            dataGridView1.DataSource = dt; 
        }

        private void User_List_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = d.viewemp(b);
            dataGridView1.DataSource = dt;
        }
    }
}
