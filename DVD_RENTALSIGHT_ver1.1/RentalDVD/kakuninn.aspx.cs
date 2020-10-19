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
    public partial class kakuninn : System.Web.UI.Page
    {
        List<string> SelectedId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.Handler is Admin)
                {
                    var kakuninn = (Admin)Context.Handler;
                    List<string> array = kakuninn.getCheckBox();
                    SelectedId = kakuninn.getRentalid(); 
                    for (int i = 0; i < array.Count; i++)
                    {
                        BulletedList1.Items.Add(array[i]);
                        blSelectedId.Items.Add(SelectedId[i]);
                    }
                    Label1.Text = string.Format("以下の{0}点の商品を返却します", array.Count);
                }
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            
            
            string strConnectionString = "Addr =192.168.10.172;User Id=sa;password=P@ssw0rd;Initial Catalog=DVDRentalDB_B;Integrated Security =false";
            SqlConnection hConnection = (new SqlConnection(strConnectionString));

            
            hConnection.Open();
            
            //行の削除
            for (int i = 0; i < blSelectedId.Items.Count; i++)
            {
                SqlCommand hCommand = hConnection.CreateCommand();

                hCommand.CommandText = string.Format("DELETE FROM [dbo].[Rental] where [dbo].[Rental].[Id] = {0}",blSelectedId.Items[i].ToString());
                hCommand.ExecuteNonQuery();
                
            }

            //Quantityの更新
            List<string> DVDIdlist;
            DVDIdlist = new List<string>();
            for (int i = 0; i < BulletedList1.Items.Count; i++)
            {
                SqlCommand DVDIdlistcommand = hConnection.CreateCommand();
                DVDIdlistcommand.CommandText = string.Format("SELECT [dbo].[DVDMaster].[Id] FROM [dbo].[DVDMaster] where [dbo].[DVDMaster].[Name] = '{0}'", BulletedList1.Items[i]);
                SqlDataReader DVDIdReader = DVDIdlistcommand.ExecuteReader();
                DVDIdlistcommand.Dispose();
                while (DVDIdReader.Read())
                {
                    DVDIdlist.Add(DVDIdReader["Id"].ToString());
                }
                DVDIdReader.Close();
                DVDIdReader.Dispose();
            }
            for (int i = 0; i < DVDIdlist.Count; i++)
            {
                SqlCommand hCommand3 = hConnection.CreateCommand();
                hCommand3.CommandText = string.Format("UPDATE  [dbo].[Stock] SET [dbo].[Stock].[Quantity] = [dbo].[Stock].[Quantity]+1 where [dbo].[Stock].[DvdId] = '{0}'", DVDIdlist[i]);
                hCommand3.ExecuteNonQuery();
            }












            Server.Transfer("Admin.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("Admin.aspx");
        }
    }
}