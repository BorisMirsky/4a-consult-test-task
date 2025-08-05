using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;



namespace _4aconsultWebForms.DataAccess
{
    public class Database
    {

        //public string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        static public string ConnectionString
        {
            get
            {
                return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog='books';Integrated Security=True"; 
            }
        }
    }
}

