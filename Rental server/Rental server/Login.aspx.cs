using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


//----------------------------Uragami------------------------------------------
namespace Rental_server
{
    public partial class Login : System.Web.UI.Page
    {
        List<string> Id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //サーバ情報格納
            try
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
                sqlCommand.CommandText = "SELECT LoginName,LoginPassword,Id,IsAdministrator FROM [dbo].[User]";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                sqlCommand.Dispose();


                //ＩＤまたはパスワードが未入力だった場合
                if (UserID.Text.CompareTo("") == 0 || Pass.Text.CompareTo("") == 0)
                {
                    //IDが未入力だったら
                    if (UserID.Text.CompareTo("") == 0)
                    {
                        UserIDMi.ForeColor = Color.Red;
                        UserIDMi.Text = "ユーザーＩＤが入力されていません";
                    }
                    //パスワードが未入力だったら
                    if (Pass.Text.CompareTo("") == 0)
                    {
                        PasswordMi.ForeColor = Color.Red;
                        PasswordMi.Text = "パスワードが入力されていません";
                    }
                    //パスワードがの中身を消す
                    else
                    {
                        Pass.Text = null;
                    }
                }
                //リスト作成
                var LoginName = new List<string>();
                var Password = new List<string>();
                Id = new List<string>();
                var isAdministrator = new List<string>();

                //データベースの中身をリストに格納する
                while (sqlDataReader.Read())
                {
                    LoginName.Add(sqlDataReader["LoginName"].ToString());
                    Password.Add(sqlDataReader["LoginPassword"].ToString());
                    Id.Add(sqlDataReader["Id"].ToString());
                    isAdministrator.Add(sqlDataReader["IsAdministrator"].ToString());
                }
                //データーベースを閉じる
                sqlDataReader.Close();
                objConn.Close();
                objConn.Dispose();

                //ユーザー分検索
                for (int i = 0; i < Id.Count; i++)
                {
                    //ユーザーＩＤが一致していたら
                    if (UserID.Text == LoginName[i].ToString())
                    {
                        //パスワードが一致していたら
                        if (Pass.Text == Password[i].ToString())
                        {
                            //セッション保持
                            Session["Id"] = Id[i];
                            Session["UserID"] = LoginName[i];

                            //管理者権限チェック 
                            if (isAdministrator[i].CompareTo("True") == 0)
                            {
                                //セッション保持
                                Session["Admin"] = isAdministrator[i];
                                //管理者ページに移動 
                                Response.Redirect("DVDReturn.aspx");
                            }
                            else
                            {
                                //ユーザーページに移動
                                Response.Redirect("rental.aspx");
                            }

                        }
                        //パスワードが違った場合
                        else
                        {
                            UserIDMi.ForeColor = Color.Red;
                            UserIDMi.Text = "ユーザーＩＤまたはパスワードが違います";
                            PasswordMi.Text = null;
                            break;
                        }
                    }
                    //ユーザーＩＤが違った場合 
                    else
                    {
                        UserIDMi.ForeColor = Color.Red;
                        UserIDMi.Text = "ユーザーＩＤまたはパスワードが違います";
                        //パスワードが未入力では無かったら
                        if (Pass.Text.CompareTo("") != 0)
                        {
                            PasswordMi.Text = null;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Label2.ForeColor = Color.Red;
                Label2.Text = "DBが接続されていません";
            }
         }
    
        public List<string>GetId()
        {
            return Id;
        }

        protected void SearchDVD_Click(object sender, EventArgs e)
        {
            Server.Transfer("DVDSearch.aspx");
        }
    }
}