using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee_Attendence_and_Task_Monitoring_System;
using Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Employee;
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;

namespace Employee_Attendence_and_Task_Monitoring_System.Presentation_layer
{
    public partial class timecalculate : Form
    {
        Data d = new Data();
        BLL b = new BLL();
        int tim, timS, timM, timH ;
        bool isActive;
        static string ab;
    


        public timecalculate()
        {
            InitializeComponent();
        }
        public timecalculate(string a)
        {
            InitializeComponent();
            ab = a;
            label7.Text = ab;


        }

        public void button1_Click(object sender, EventArgs e)
        {
            isActive = true;
            
        }

        public void button2_Click(object sender, EventArgs e)
        {
            isActive = false;
            label7.Text = ab;

            label9.Text = string.Format("{0,00}", timH);
            label8.Text = "Present";
            dateTimePicker1.Value = DateTime.Today;
            if (d.Insertatten(label7.Text, Convert.ToInt32(label9.Text), label8.Text, dateTimePicker1.Value))
            {
                MessageBox.Show("Attendence Recorded Successfully");
            }

            ResetTime();
        }

        public void ResetTime()
        {
            int tim = 0;
               int timS = 0;
                int timM = 0;
                int timH = 0;
              

        }

        private void timecalculate_Load(object sender, EventArgs e)
        {
          
            ResetTime();
            isActive = false;


        }

        public void button3_Click(object sender, EventArgs e)
        {
            isActive = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                tim++;

                if (tim > 100)
                {
                    timS++;
                    tim = 0;

                    if (timS > 60)
                    {
                        timM++;
                        timS = 0;

                        if (timM > 60)
                        {
                            timH++;
                            timM = 0;

                            if (timH > 9)
                            {
                                isActive = false;
                            }
                        }
                    }

                }
            }
            drawtime();
        }

        public void drawtime()
        {
            label9.Text = string.Format("{0,00}", timH);
        }

        private void timecalculate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
