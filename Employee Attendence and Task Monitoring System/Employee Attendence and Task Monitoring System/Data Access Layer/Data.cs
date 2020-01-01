using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer;
using Employee_Attendence_and_Task_Monitoring_System.Presentation_layer;

namespace Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer
{
   
    
    public class Data
        
    {
        //Employee_Attendence_and_Task_Monitoring_System.Presentation_layer.Admin_Info ai;
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G7IISFU;Initial Catalog=Data;Integrated Security=True");

        public SqlConnection getcon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }


        public int Excelnonquery(SqlCommand cmd)
        {

            cmd.Connection = getcon();
            int rowsaffected = -1;
            rowsaffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsaffected;

        }

        public object ExeSclar(SqlCommand cmd)
        {

            cmd.Connection = getcon();
            object obj = -1;
            obj = cmd.ExecuteNonQuery();
            con.Close();
            return obj;

        }

        public DataTable ExeReader(SqlCommand cmd)
        {
            cmd.Connection = getcon();
            SqlDataReader sdr;
            DataTable dt = new DataTable();

            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;
        }



        ~Data()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }


        internal int insertEMP(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into t2 VALUES ('" + b.ID + "', '" + b.name + "', '" + b.salary + "', '" + b.DOB + "', '" + b.joinDate + "', '" + b.email + "', '" + b.usertype + "', '" + b.password + "')";
            return Excelnonquery(cmd);

        }
        internal int insertmsg(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into msg VALUES ('" + b.ID + "', '" + b.message + "')";
            return Excelnonquery(cmd);
            
        }

        internal DataTable logininfo(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from t2 where ID = '" + b.ID + "' and Password ='" + b.password + "'";
            return ExeReader(cmd);
        }

        public DataTable viewemp(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from t2 ";
            return ExeReader(cmd);

        }
        /*public DataTable viewPASS(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from t2 where ID = '"+b.ID+"' and Password = '"+b.password+"' ";
            return ExeReader(cmd);

        }*/

        

        public DataTable viewtask(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from task ";
            return ExeReader(cmd);

        }

        
        
        public DataTable viewmsg(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from msg";
            return ExeReader(cmd);


        }
        
        internal int taskassigner(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into task (ID, Task, TaskStatus, Deadline) VALUES ('" + b.ID + "', '" + b.task + "', '" + b.taskstatus+ "', '"+b.deadline+"')";
            return Excelnonquery(cmd);
        }



        public bool modify( string name, int salary, DateTime dob, DateTime join, string email, int id)
        {
            con.Open();
            string query = string.Format("UPDATE t2 SET   Name = '{0}', Salary = {1}, DOB = '{2}', JoiningDate = '{3}', Email = '{4}' where ID = '{5}'",  name, salary, dob, join, email, id);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }

        public bool modifytask(string tasko, string taskstat, int id)
        {
            con.Open();
            string query = string.Format("UPDATE task SET   Task = '{0}', TaskStatus = '{1}'  where ID = {2}", tasko, taskstat,  id);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }



        public bool modifypassword(string pass, int id)
        {
            con.Open();
            string query = string.Format("UPDATE t2 SET   Password = '{0}'  where ID = {1}",pass, id  );
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }
       /* public DataTable labeling(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from t2 where ID = '"+myid+ "'";
            return ExeReader(cmd);


        }
   */

        /*internal DataTable loginhistory(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from loginhistory";
            return ExeReader(cmd);
        }*/

        public bool Delete(int id)
        {
            con.Open();
            string query = string.Format("DELETE FROM t2 WHERE id={0} ", id);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }

        public bool Insert(int id, string message)
        {
            con.Open();
            string query = string.Format("INSERT INTO msg (ID, Message) VALUES('{0}','{1}')", id, message);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }

        public bool Insertatten(string id, int time, string att, DateTime attdate)
        {
            con.Open();
            string query = string.Format("INSERT INTO atten (ID, Time, Attendence, date ) VALUES('{0}','{1}','{2}','{3}')", id, time, att, attdate);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }
        /*public DataTable viewadmin(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from t2 where ID = '"+Admin_Info.myid+"'";
            
           SqlDataReader sdr = cmd.ExecuteReader();
            return ExeReader(cmd);

            

        }*/

        internal DataTable loginhistoryyo(BLL b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from atten";
            return ExeReader(cmd);
        }
    }
}
