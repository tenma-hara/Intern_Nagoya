using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

//Written by Kawabata
namespace RentalDVD
{
    public partial class Admin : System.Web.UI.Page
    {
        List<string> array;
       // List<string> Rentalid;
        List<string> SelectedRentalid;

        public List<string> getCheckBox()
        {
            return array;
        }
        public List<string> getRentalid()
        {
            return SelectedRentalid;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["isAdmin"] == null) {


                Response.Redirect("Default.aspx");
            }





        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["isAdmin"] = null;
            Session["isLogined"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            array = new List<string>();
            SelectedRentalid = new List<string>();
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    SelectedRentalid.Add(cbRentalId.Items[i].ToString());
                    array.Add(CheckBoxList1.Items[i].ToString());
                    
                }
            }
            if (SelectedRentalid.Count == 0)
            {
                return;
            }
            Server.Transfer("kakuninn.aspx");
        }
            


        protected void Button2_Click(object sender, EventArgs e)
        {
            //Rentalid = new List<string>();
            string strConnectionString = "Addr =192.168.10.172;User Id=sa;password=P@ssw0rd;Initial Catalog=DVDRentalDB_B;Integrated Security =false";

            SqlConnection hConnection = (new SqlConnection(strConnectionString));

            hConnection.Open();
            System.Data.SqlClient.SqlCommand hCommand = hConnection.CreateCommand();
            hCommand.CommandText = "SELECT [dbo].[DVDMaster].[Name],[dbo].[Member].[LoginName],[dbo].[Rental].[Id] FROM [dbo].[Rental] INNER JOIN [dbo].[DVDMaster] ON [dbo].[DVDMaster].[id] = [dbo].[Rental].[DvdId] INNER JOIN [dbo].[Member] ON [dbo].[Rental].[UserId] = [dbo].[Member].[Id]";

            System.Data.SqlClient.SqlDataReader hReader = hCommand.ExecuteReader();

            hCommand.Dispose();
            while(hReader.Read())
            {
                if (hReader["LoginName"].ToString() == TextBox1.Text)
                {
                    cbRentalId.Items.Add(hReader["Id"].ToString());
                    CheckBoxList1.Items.Add(hReader["Name"].ToString());

                }
            }
            if (CheckBoxList1.Items.Count == 0)
            {
                _Labl3.Text = "レンタルされている商品はありません";
            }
            hReader.Close();
            hConnection.Close();
            hConnection.Dispose();
        }
    }
}