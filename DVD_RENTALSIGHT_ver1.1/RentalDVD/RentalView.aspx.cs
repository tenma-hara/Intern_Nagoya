using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

// Written by Kamiya
namespace RentalDVD
{
    public partial class RentalView : System.Web.UI.Page
    {

        SqlConnection conn;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["isLogined"] == null)
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {

                if (Context.Handler is Rental)
                {

                    var rental = (Rental)Context.Handler;


                    lbMessage.Text = string.Format("以下の{0}点の商品をレンタルします。", rental.getChkedRentalList().Count);

                    if (rental.getChkedRentalList().Count == 0)
                        Response.Redirect("Rental.aspx");

                    for (int i = 0; i < rental.getChkedRentalList().Count; i++)
                    {/*リストの動的表示*/

                        ListItem item = new ListItem();
                        item.Text = rental.getChkedRentalList()[i];
                        blistRentalList.Items.Add(item);
                    }
                }

            }
        }

        protected void Cancel_Click(object sender, EventArgs e) {


            Response.Redirect("Rental.aspx");
        
        }
        protected void Apply_Click(object sender, EventArgs e) {

            
            var enableRentalList = new List<string>();

            ConnectionDB();


            if ((enableRentalList = CheckRentalList()) != null)
            {
                if(enableRentalList.Count == 0)
                    Response.Redirect("Rental.aspx");

                lbMessage.Text = string.Format("以下の{0}点の商品がレンタルできます。", enableRentalList.Count);

                blistRentalList.Items.Clear();
                for (int i = 0; i < enableRentalList.Count; i++)
                {//リストの動的表示
                    ListItem item = new ListItem();
                    item.Text = enableRentalList[i];
                    blistRentalList.Items.Add(item);
                }
                return;//表示して終了
            }

            //各種パラメータの設定
            int userid = Int16.Parse(Session["UserID"].ToString());
            int lastid = Int16.Parse(getLastId()) + 1;
            DateTime dtToday = DateTime.Today;
            string daystring = dtToday.ToString().Substring(0, 10);



            for (int i = 0; i < blistRentalList.Items.Count; i++)
            {//借りるときのDBへの挿入と更新
                
                int dvdid = Int16.Parse(getDvdID(blistRentalList.Items[i].Text));
                SqlCommand command = this.conn.CreateCommand();
                command.CommandText = string.Format("INSERT INTO [dbo].[Rental] (Id,UserID,DvdId,IsReturned,InsertDateTime,InsertUserID,UpdateDateTime,UpdateUserID) VALUES ('{0}','{1}','{2}','false','{3}','{4}','{5}','{6}');",lastid,userid,dvdid,daystring,userid,daystring,userid);

                command.ExecuteNonQuery();
                lastid++;

                SqlCommand update = this.conn.CreateCommand();
                update.CommandText = string.Format("UPDATE [dbo].[Stock] SET Quantity = Quantity - 1 WHERE DvdId = '{0}'",dvdid);
                update.ExecuteNonQuery();

            }

            CloseDB();

            Response.Redirect("Thanks.aspx");
        
        
        }

        protected List<string> CheckRentalList() {// DVDを借りることができるかチェックする

            

            SqlCommand command = this.conn.CreateCommand();
            command.CommandText = "SELECT Name,Quantity FROM [dbo].[Stock] LEFT JOIN [dbo].[DVDMaster] ON [dbo].[Stock].DvdId = [dbo].[DVDMaster].Id";
            SqlDataReader datareader = command.ExecuteReader();
            command.Dispose();
            
            var enableRentalList = new List<string>();
            bool cantRental = false;

            ConnectionDB();
            while (datareader.Read()) {


                for (int i = 0; i < blistRentalList.Items.Count; i++)
                {

                    
                    if(datareader["Name"].ToString().CompareTo(blistRentalList.Items[i].Text) == 0){



                       if (datareader["Quantity"].ToString().CompareTo("0") == 0)
                       {

                          cantRental = true;

                        }
                        else {
                            
                          enableRentalList.Add(datareader["Name"].ToString());
                                        
                        }
                    }
    
                }
                   
            }

             if (cantRental)//レンタルできないものが含まれるとき利用可能なレンタルリストを返す。
                 return enableRentalList;
             else
                 return null;
                   
        }
        protected string getLastId()
        {//最後のIDを取得

            string id = string.Empty;
            SqlCommand readcom = this.conn.CreateCommand();
            readcom.CommandText = "SELECT Id FROM [dbo].[Rental]";
            SqlDataReader dr = readcom.ExecuteReader();
            readcom.Dispose();

            while (dr.Read()){
                id = dr["Id"].ToString();
            }

            dr.Dispose();
            if (id.CompareTo("") == 0)
                id = "0";

            return id;
        }

        protected string getDvdID(string dvd_name)
        {//DVD名からDVDIDの取得

            string id = string.Empty;
            SqlCommand readcom = this.conn.CreateCommand();
            readcom.CommandText = string.Format("SELECT Id FROM [dbo].[DVDMaster] WHERE [dbo].[DVDMaster].Name = '{0}'",dvd_name);
            SqlDataReader dr = readcom.ExecuteReader();
            readcom.Dispose();

            while (dr.Read())
            {
                id = dr["Id"].ToString();
            }

            dr.Dispose();
            return id;
       
        }
        
        protected void ConnectionDB()
        {

            this.conn = new SqlConnection(DBConStr.ConnectionString());
            this.conn.Open();


        }


        protected void CloseDB()
        {


            if (this.conn != null)
            {
                this.conn.Close();
                this.conn.Dispose();
            }
        }
    }
}