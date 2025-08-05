using _4aconsultWebForms.DataAccess;
using _4aconsultWebForms.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Configuration;



namespace _4aconsultWebForms.Pages
{
    public partial class Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
            {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(Database.ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("select * from Bookstable", con);  //order by title
                DataSet ds = new DataSet();
                da.Fill(ds, "books");  
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
    }
}