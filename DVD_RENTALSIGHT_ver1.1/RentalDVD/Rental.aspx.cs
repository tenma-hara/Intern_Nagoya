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
    public partial class Rental : System.Web.UI.Page


    {
        SqlConnection conn;
        List<string> chkrentalname;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Page_Init(object sender, EventArgs e) {


            if(Session["isLogined"] == null)
                Response.Redirect("Default.aspx");

            lbLoginUser.Text = string.Format("ログインユーザー　: {0}さま", Session["UserName"].ToString());
            CreateRentalList();

        
        }


        protected void Logout_Click(object sender, EventArgs e)
        {

                       
            Session["UserID"] = null;
            Session["isLogined"] = null;
            Session["UserName"] = null;


            Response.Redirect("Default.aspx");
            
        }

        protected void Rental_Click(object sender, EventArgs e) {



            this.chkrentalname = new List<string>();


            for (int i = 0; i < RentalList.Items.Count; i++)
            {

                if(RentalList.Items[i].Selected)
                {
                    this.chkrentalname.Add(RentalList.Items[i].Text);
                  
                }

            }
            if (chkrentalname.Count != 0) {

               Server.Transfer("RentalView.aspx");

            }

       
        }

        protected void CreateRentalList() {



            ConnectionDB();
            SqlCommand command = this.conn.CreateCommand();
            command.CommandText = "SELECT Name,Quantity FROM [dbo].[Stock] LEFT JOIN [dbo].[DVDMaster] ON [dbo].[Stock].DvdId = [dbo].[DVDMaster].Id;";
            SqlDataReader datareader = command.ExecuteReader();
            command.Dispose();


            List<bool> isallrentaled = new List<bool>();//すべてレンタル済みかのリスト
            bool alrdyrentalflag = false;//既にレンタル済みかのフラグ

            while (datareader.Read())
            {//在庫チェック

                ListItem item = new ListItem();

                item.Text = datareader["Name"].ToString();

                if (datareader["Quantity"].ToString().CompareTo("0") == 0)
                {
                    //item.Enabled = false;//選択不可状態にする
                    isallrentaled.Add(true);
               }
                isallrentaled.Add(false);
                RentalList.Items.Add(item);


            }
            datareader.Close();
            datareader.Dispose();

            var RentaledList = new List<string>();
            
            
                 
            SqlCommand alrdyRntlCom = this.conn.CreateCommand();
            alrdyRntlCom.CommandText = string.Format("SELECT Name FROM [dbo].[Rental] LEFT JOIN [dbo].[DVDMaster] ON [dbo].[Rental].Dvdid = [dbo].[DVDMaster].Id WHERE [dbo].[Rental].UserID = '{0}'",Session["UserID"].ToString() );
            SqlDataReader alrdyreader = alrdyRntlCom.ExecuteReader();
            alrdyRntlCom.Clone();

            while (alrdyreader.Read()) {

                    RentaledList.Add(alrdyreader["Name"].ToString());
                
            }
                alrdyreader.Close();
                alrdyreader.Dispose();

            for (int i = 0; i < RentalList.Items.Count; i++)
            {
                alrdyrentalflag = false;
                for (int j = 0; j < RentaledList.Count; j++)
                {

                    if (RentaledList[j].CompareTo(RentalList.Items[i].ToString()) == 0)
                    {//既に借りているものリストと一致した場合

                        RentalList.Items[i].Enabled = false;
                        RentalList.Items[i].Text += "(既にレンタル中です。)";
                        alrdyrentalflag = true;
                        
                    }

                }

                if (isallrentaled[i] && !alrdyrentalflag)
                {//すべて貸出し中で、借りていないものの場合

                    RentalList.Items[i].Enabled = false;
                    RentalList.Items[i].Text += "(すべて貸出し中です。)";
                }
                
            }

            
            CloseDB();
        
        
        }

        public List<string> getChkedRentalList() { 
        
        
        
            return this.chkrentalname;
        
        
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