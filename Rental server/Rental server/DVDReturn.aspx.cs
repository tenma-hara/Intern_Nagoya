using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Rental_server
{
    //=========================
    //返却管理画面クラス
    //-------------------------
    //Author   Tenma Hara
    //=========================
    public partial class DVDReturn : System.Web.UI.Page
    {
        //確認画面に渡すデータを格納するリスト
        List<string> SelectedItem;
        List<string> SelectedRentalId;

        //データベースから取得したデータを格納するリスト
        List<string> MemberID;
        List<string> MemberName;
        List<string> RentalMemID;
        List<string> RentalID;
        List<string> DVDName;

        string MemName;

        protected void Page_Load(object sender, EventArgs e)
        {
            //何らかの手法でこの画面から始まった際ログイン画面に戻す
            //ログイン時にIDと管理者フラグを控えているのでそれがなければログインしていない状態
            if (Session["UserID"] == null || Session["Admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            
            Label_User.Text = "ログイン中のユーザー：" + Session["UserID"].ToString();
        }
   
        protected void Button_LogOut_Click(object sender, EventArgs e)
        {
            //ログイン画面へ遷移
            Response.Redirect("Login.aspx");
        }

        protected void Button_ShowItem_Click(object sender, EventArgs e)
        {
            //データベースから取得したデータを格納するリスト
            MemberID = new List<string>();
            MemberName = new List<string>();
            RentalMemID = new List<string>();
            RentalID = new List<string>();
            DVDName = new List<string>();

            InitParam();

            if (TBox_MemberID.Text == "")　//会員IDが入力されていない
            {
                Label_Error.Text = "会員IDを入力してください";
            }
            else
            {
                //SQL Serverへの接続処理
                string sConnectionString = "Addr = localhost;" +
                                           "User Id = sa;" +
                                           "password = P@ssw0rd;" +
                                           "Initial Catalog = DVDRentalDB;" +
                                           "Integrated Security = false";

                SqlConnection objConn = new SqlConnection(sConnectionString);
                objConn.Open();

                SqlCommand sqlCommand = objConn.CreateCommand();
                sqlCommand.CommandText = "SELECT Rental.MemberID , Rental.Id , DVD.Name " +
                                         "FROM Rental " +
                                         "INNER JOIN DVD ON DVD.id = Rental.DvdId " +
                                         "INNER JOIN Member ON Rental.MemberId = Member.Id " +
                                         "WHERE Rental.IsReturned = 0";

                SqlDataReader DataReader = sqlCommand.ExecuteReader();

                sqlCommand.Dispose();

                //データがある間、データリーダーでデータを読み出す
                while (DataReader.Read())
                {
                    //読み込んだデータをリストに格納
                    RentalMemID.Add(DataReader["MemberID"].ToString());
                    RentalID.Add(DataReader["Id"].ToString());
                    DVDName.Add(DataReader["Name"].ToString());

                }

                //入力された会員IDが会員IDリストに含まれているか判別
                if (CheckID(sConnectionString))
                {
                    for (int i = 0; i < DVDName.Count(); i++)
                    {
                        //入力したIDの会員が借りているDVDを探索する
                        if (RentalMemID[i].ToString() == TBox_MemberID.Text)
                        {
                            CBoxList_RentalID.Items.Add(RentalID[i].ToString());
                            CBoxList_ShowItem.Items.Add(DVDName[i].ToString());
                        }                    
                    }

                    for(int j = 0;j < MemberName.Count;j++)
                    {
                        if(TBox_MemberID.Text == MemberID[j].ToString())
                        {
                            MemName = MemberName[j].ToString();
                        }
                    }

                    //レンタル中のDVDがなかった場合
                    if (CBoxList_ShowItem.Items.Count == 0)
                    {
                        Label_ShowItem.Text = MemName + "様 :レンタルされているDVDはありません";
                    }
                    else  //レンタル中のDVDがあった場合
                    {
                        Label_ShowItem.Text = MemName + "様 :" +CBoxList_ShowItem.Items.Count.ToString() + "件の商品がレンタルされています";
                        Button_Return.Visible = true;
                    }
                }
                else
                {
                    Label_Error.Text = "存在しない会員IDです";
                }

                //必要な処理を終えたらデータベースへの接続を終了する
                DataReader.Close();
                objConn.Close();
                objConn.Dispose();
            }
        }

        protected void Button_Return_Click(object sender, EventArgs e)
        {
            //選択された商品の貸し出しIDを格納する
            SelectedRentalId = new List<string>();
            //選択された商品を格納する
            SelectedItem = new List<string>();

            //チェックボックスリスト内のすべてのアイテムを調べる
            for (int i = 0; i < CBoxList_ShowItem.Items.Count; i++)
            {
                //選択されたアイテムの貸し出しIDと商品名をリストに追加
                if (CBoxList_ShowItem.Items[i].Selected == true)
                {
                    SelectedRentalId.Add(CBoxList_RentalID.Items[i].ToString());
                    SelectedItem.Add(CBoxList_ShowItem.Items[i].ToString());
                }
            }

            //返却する商品が１つも選択されていなかった場合
            if (SelectedItem.Count == 0)
            {
                Label_NoCheck.Text = "商品が選択されていません";
            }
            else
            {
                //返却確認画面へ遷移
                Server.Transfer("Conf_Return.aspx");
            }
        }

        //入力された会員IDが存在するかどうかチェックする関数
        protected bool CheckID(string sConn)
        {
            SqlConnection objConn = new SqlConnection(sConn);
            objConn.Open();

            SqlCommand sqlCommand = objConn.CreateCommand();
            sqlCommand.CommandText = "select Member.Id as MemberID, Member.Name as MemberName from Member";

            SqlDataReader DataReader = sqlCommand.ExecuteReader();

            sqlCommand.Dispose();

            //データがある間、データリーダーでデータを読み出す
            while (DataReader.Read())
            {
                //読み込んだデータをリストに格納
                MemberID.Add(DataReader["MemberID"].ToString());
                MemberName.Add(DataReader["MemberName"].ToString());
            }

            //必要な処理を終えたらデータベースへの接続を終了する
            DataReader.Close();
            objConn.Close();
            objConn.Dispose();

            //入力された会員IDが会員表に登録されているかどうか
            if (MemberID.Contains(TBox_MemberID.Text) == true)
            {
                return true;
            }
            else
            {
                return false;
            }         
        }

        //入力された情報をリセットする関数
        protected void InitParam()
        {
            MemberID.Clear();
            MemberName.Clear();
            RentalMemID.Clear();
            RentalID.Clear();
            DVDName.Clear();
            CBoxList_ShowItem.Items.Clear();
            CBoxList_RentalID.Items.Clear();

            Label_Error.Text = "";
            Label_ShowItem.Text = "";
            Label_NoCheck.Text = "";

            Button_Return.Visible = false;
        }

        //返却処理に必要な情報を確認画面に引き渡すための関数たち
        public List<String> GetSelectedID()
        {
            return SelectedRentalId;
        }
        public List<String> GetSelectedItem()
        {
            return SelectedItem;
        }
    }
}