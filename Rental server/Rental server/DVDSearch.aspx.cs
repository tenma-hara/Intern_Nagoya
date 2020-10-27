using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rental_server
{
    public partial class DVDSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Result.Visible      = false;
            DVDListBox1.Visible = false;
        }

        protected void NameSearch_Click(object sender, EventArgs e)
        {
            Result.Visible      = true;
            DVDListBox1.Visible = false;
            ResultCount.Text = "";
            ErrMsg.Text = "";
            DVDListBox1.Items.Clear();

            if (DVDNameText.Text == "")
            {
                ErrMsg.Text = "何も入力されていません";
                Result.Visible = false;
            }
            else
            {
                //サーバ情報格納
                string sConnectlonStrlng = "Addr = localhost;"   //192.168.10.201
                    + "User Id = sa;"
                    + "password = P@ssw0rd;"
                    + "Initial Catalog = DVDRentalDB;"
                    + "Integrated Security = false";

                SqlConnection objConn = new SqlConnection(sConnectlonStrlng);
                //サーバ接続
                objConn.Open();

                SqlCommand sqlCommand = objConn.CreateCommand();
                sqlCommand.CommandText = "SELECT Id,Name FROM DVD WHERE Name LIKE '%" + DVDNameText.Text + "%'";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    DVDListBox1.Items.Add(sqlDataReader["Name"].ToString());
                }
                if (DVDListBox1.Items.Count != 0)
                {
                    Result.Visible      = true;
                    DVDListBox1.Visible = true;
                }

                ResultCount.Text = DVDListBox1.Items.Count + " 件";

                sqlCommand.Dispose();
                sqlDataReader.Close();
                objConn.Close();
                objConn.Dispose();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }
    }
}