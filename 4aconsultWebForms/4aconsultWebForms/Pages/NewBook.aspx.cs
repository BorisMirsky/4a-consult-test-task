using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using _4aconsultWebForms.DataAccess;


namespace _4aconsultWebForms.Pages
{
    public partial class NewBook : Page
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                Guid id = Guid.NewGuid();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Bookstable(id,name,author,price,year) values(@id,@name,@author,@price,@year)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@year", txtYear.Text);

                int count = cmd.ExecuteNonQuery();
                if (count == 1)
                    lblMsg.Text = "Book [" + txtName.Text + "] has been added!";
                else
                    lblMsg.Text = "Could not add book!";
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error --> " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{        }
    }
}