using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Rental_server
{
    public partial class Member_search : System.Web.UI.Page
    {
        List<string> Id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button1_Click1(object sender, EventArgs e)
        {
            //サーバー側のIPアドレス
            //string sConnectlonStrlng ="Addr = 192.168.10.201;"
            //PC側のIPアドレス
            string sConnectlonStrlng = "Addr = localhost;"
             + "User Id = sa;"
             + "password = P@ssw0rd;"
             + "Initial Catalog = DVDRentalDB;"
             + "Integrated Security = false";


            SqlConnection objConn = new SqlConnection(sConnectlonStrlng);
            //サーバ接続
            objConn.Open();

            SqlCommand sqlCommand = objConn.CreateCommand();

            //セレクト呼び出し
            sqlCommand.CommandText = "SELECT Id,Name,TEL FROM [dbo].[Member]";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            sqlCommand.Dispose();

            Label4.Visible = false;
            //ＩＤまたはパスワードが未入力だった場合
            if (TextBox1.Text.CompareTo("") == 0)
            {
                Label4.Visible = true;
            }
            //リスト作成
            var Name = new List<string>();
            Id = new List<string>();
            var Tel = new List<string>();

            //データベースの中身をリストに格納する
            while (sqlDataReader.Read())
            {
                Name.Add(sqlDataReader["Name"].ToString());
                Id.Add(sqlDataReader["Id"].ToString());
                Tel.Add(sqlDataReader["TEL"].ToString());
            }
            //データーベースを閉じる
            sqlDataReader.Close();
            objConn.Close();
            objConn.Dispose();

            //名前検索
            for (int i = 0; i < Id.Count; i++)
            {
                //ユーザーＩＤが一致していたら
                if (TextBox1.Text == Name[i].ToString())
                {
                    if (TextBox2.Text == Tel[i].ToString())
                    {
                        //セッション保持
                        Session["Id"] = Id[i];
                        Session["Name"] = Name[i];

                        CheckBoxList1.Items.Add ("ID: " + Id[i]+ " 名前: " + Name[i]+" 電話番号: " + Tel[i]);
                        break;
                    }

                    //パスワードが違った場合
                    else
                    {
                        Label4.Visible = true;
                    }
                }
                //ユーザーＩＤが違った場合 
                else
                {
                    Label4.Visible = true;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("rental.aspx");
        }
    }
}

