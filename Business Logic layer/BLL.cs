using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using Employee_Attendence_and_Task_Monitoring_System.Data_Access_Layer;
using Employee_Attendence_and_Task_Monitoring_System.Presentation_layer;


namespace Employee_Attendence_and_Task_Monitoring_System.Business_Logic_layer
{
    public class BLL
    {
        public Data d = new Data();
        
        //User Informations
        public int ID { get; set;  }
        public string name { get; set; }
        public int  salary { get; set; }
        public DateTime DOB { get; set; }
        public DateTime joinDate { get; set; }
        public string email { get; set; }
        public string usertype { get; set; }
        public string password { get; set; }
        
        //Task Information
        public string task { get; set; }
        public string taskstatus { get; set; }
        public DateTime deadline { get; set;}

        //Message Information
        public string message { get; set;  }


        public bool modifydata( string name, int salary, DateTime dob, DateTime join, string email , int id)
        {

            return d.modify( name, salary, dob, join, email, id);
        }


        public bool modifytaskdata(string tasko, string taskstat, int id)
        {
            return d.modifytask(tasko, taskstat, id);
        }


        public bool DeletePerson(int id)
        {
            return d.Delete(id);
        }


        public bool sendmessage(int id, string message)
        {
            return d.Insert(id, message);
        }


        public bool modifypassdata(string pass,  int id)
        {
            return d.modifypassword(pass, id);
        }

        public bool attcheck(string id, int time, string att, DateTime attdate)
        {
            return d.Insertatten(id, time, att, attdate);
        }

        }

    
       

    }

