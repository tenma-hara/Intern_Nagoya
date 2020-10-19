using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace RentalDVD
{
    public partial class _Default : System.Web.UI.Page
    {

        private SqlConnection conn;


        protected void Page_Load(object sender, EventArgs e)
        {


        }
        

        protected void ConnectionDB(){

            this.conn = new SqlConnection(DBConStr.ConnectionString());
            this.conn.Open();
        }


        protected void CloseDB() { 


            if (this.conn != null){
                    this.conn.Close();
                    this.conn.Dispose();
            }
        }

        protected void btnLogin_Click(object sender,EventArgs e)
        {

            ConnectionDB();

            bool isUser = false;


            SqlCommand command = this.conn.CreateCommand();
            command.CommandText = "SELECT LoginName,Password,Id,isAdministrator FROM [dbo].[Member]";
            SqlDataReader datareader = command.ExecuteReader();
            command.Dispose();


            if (UserID.Text.CompareTo("") == 0 || Password.Text.CompareTo("") == 0) {

                Message.Text = "ユーザーIDまたはパスワードが未入力です。";
                CloseDB();
                UserID.Text = "";
                return;
                
            }


            var usernames = new List<string>();
            var passwords = new List<string>();
            var isadmins = new List<string>();
            var userids = new List<string>();

            string end = string.Empty;


            while (datareader.Read())
            {
            
                usernames.Add(datareader["LoginName"].ToString());
                passwords.Add(datareader["Password"].ToString());
                isadmins.Add(datareader["isAdministrator"].ToString());
                userids.Add(datareader["Id"].ToString());
                
            }
            datareader.Close();
            datareader.Dispose();
            CloseDB();


            for( int i = 0;i<userids.Count;i++){


                if (UserID.Text.CompareTo(usernames[i]) == 0)
                {
                    isUser = true;
                    if (Password.Text.CompareTo(passwords[i]) == 0)
                    {
                        Session["UserID"] = userids[i];
                        Session["UserName"] = usernames[i];
                        Session["isLogined"] = "True";
                        if (isadmins[i].CompareTo("True") == 0)
                        {
                            Session["isAdmin"] = "True";
                            Response.Redirect("Admin.aspx");

                        }
                        else
                        {
                            Response.Redirect("Rental.aspx");
                        }
                    }
                    else
                    {
                        Message.Text = "ログインに失敗しました。パスワードが間違ってます。";
                        break;
                    }

                }
            }
            if(!isUser)
                 Message.Text = "ログインに失敗しました。存在しないユーザーIDです。";
            
            UserID.Text = "";
	                   
            return;
        
        }




    }
}
