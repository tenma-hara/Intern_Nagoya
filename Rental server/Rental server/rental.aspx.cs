using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//------   Developer ---  Yuto Otake     -----------------
//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

namespace Rental_server
{
    public partial class rental : System.Web.UI.Page
    {
        static bool bflg = false;
        List<string> SelectedDVDName;   //確認画面へ選択したDVDの名前を渡す用
        List<string> SelectedDVDId;     //確認画面へ選択したDVDのIDを渡す用
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   //最初に行う処理
                //テキストボックスの初期化
                Session["MemberID"] = "";
                Session["nRent"] = 0;
                mIDBox1.Text = Session["MemberID"].ToString();
            }
            else
            { //2回目以降
                Session["MemberID"] = mIDBox1.Text; //初期化しなくてもよい
            }

            //何らかの手法でこの画面から始まった際ログイン画面に戻す
            //ログイン時にIdを控えているのでそれがなければログインしていない状態
            if(Session["Id"] == null)
            {
               Response.Redirect("Login.aspx");
            }
            //ログインユーザーの名前を表示
            UserName.Text = "現在のユーザー" + Session["UserID"] + "様";
        }//Page_Load関数終了

        // ----- ログアウトボタンをクリックした際の処理
        protected void Button1_Click(object sender, EventArgs e)
        {//ログアウトボタン
            Session["MemberID"] = "";   //Sessionで保持する会員IDを初期化
            //ログイン画面へ遷移する
            Response.Redirect("Login.aspx");

        }

        // ----- 会員IDを検索ボタンを押した際の処理
        protected void Button2_Click(object sender, EventArgs e)
        { //会員IDを検索ボタン
            List<string> sMemIDList = new List<string>();//会員ID格納用
            ErrMsg.Text = null;   //都度エラーメッセージは消す
            bflg = false;
            //各種リストはボタンを押す度クリアする
            CheckBoxList1.Items.Clear();
            sMemIDList.Clear();
            ListBox1.Items.Clear();
            try
            {
                //サーバ情報格納
                string sConnectlonStrlng = "Addr = localhost;"
                    + "User Id = sa;"
                    + "password = P@ssw0rd;"
                    + "Initial Catalog = DVDRentalDB;"
                    + "Integrated Security = false";

                SqlConnection objConn = new SqlConnection(sConnectlonStrlng);
                //サーバ接続
                objConn.Open();

                SqlCommand sqlCommand = objConn.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM [dbo].[Member]";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {   //会員IDをリストへ格納
                    sMemIDList.Add(sqlDataReader["Id"].ToString());
                }
                //この場面である条件に入らない場合以降DBを見ないので閉じる
                sqlCommand.Dispose();
                sqlDataReader.Close();
                objConn.Close();
                objConn.Dispose();
            }catch
            {
                ErrMsg.Text = "データベースへの接続に失敗しました";
            }
            int i = 0;  //while中に使用
            //int aaa = 0;  //DBから持ってきた値が正しく参照されているか確認用

            //会員IDが入力されているか
            if (mIDBox1.Text.Length == 0)
            {//何も入力されていなかったら
                Session["MemberID"] = "";
                mIDBox1.Text = "";
                ErrMsg.Text = "※会員IDが未入力です";
                CheckBoxList1.Items.Clear();
            }
            else if (true)            //存在する会員IDかどうか
            {
                while (i < sMemIDList.Count && !bflg)
                {       //↓テキスト入力された文字が会員IDを格納したリストの中にあるか
                    if (sMemIDList.Contains(mIDBox1.Text) != true)
                    { //存在しない場合
                        Session["MemberID"] = "";
                        mIDBox1.Text = "";
                        ErrMsg.Text = "※入力された会員IDは存在しません";
                        CheckBoxList1.Items.Clear();
                        bflg = false;
                    }
                    else
                    {//問題なかった場合
                        ErrMsg.Text = "";

                        //OKの場合会員IDをsessionに代入しておく
                        Session["MemberID"] = sMemIDList[i];
                        bflg = true; //フラグON
                    }//問題なかった時限定処理終了
                    //aaa = int.Parse(sMemIDList[i]); //中身の値を確認する用
                    i++;
                }//ID確認の為のwhile終了

                if (bflg)   //正しい会員IDが入力されていたら
                {
                    //ここでDBを見て商品一覧を表示する
                    //在庫が０の商品はチェックボックスをグレーアウトして
                    //チェックできないようにする
                    CreateRentalList();
                }
            }//elseif(true)終了

        }//Button2_Click関数終了

        //商品一覧を表示する関数
        //DBからDVDと在庫を見て
        //在庫のないものはチェックボックスがグレーアウトされる(チェックできないようになる)
        protected void CreateRentalList()
        {   //商品一覧を作成する関数
            //サーバ情報格納
            string sConnectlonStrlng = "Addr = localhost;" 
                + "User Id = sa;"
                + "password = P@ssw0rd;"
                + "Initial Catalog = DVDRentalDB;"
                + "Integrated Security = false";
            try
            {
                SqlConnection objConn = new SqlConnection(sConnectlonStrlng);
                //サーバ接続
                objConn.Open();

                SqlCommand sqlCommandDVD = objConn.CreateCommand();
                sqlCommandDVD.CommandText = "SELECT Id,Name FROM [dbo].[DVD]";
                SqlDataReader sqlDataReaderDVD = sqlCommandDVD.ExecuteReader();
                sqlCommandDVD.Dispose();
                List<int> DVDlist = new List<int>();
                while (sqlDataReaderDVD.Read())
                {   //商品一覧の表示
                    DVDlist.Add(int.Parse(sqlDataReaderDVD["Id"].ToString()));//IDリスト
                    ListBox1.Items.Add(sqlDataReaderDVD["ID"].ToString()); //画面上で見えないリストで管理
                    CheckBoxList1.Items.Add(sqlDataReaderDVD["Name"].ToString());
                }
                sqlDataReaderDVD.Close();

                //在庫チェック
                SqlCommand sqlCommandStock = objConn.CreateCommand();
                sqlCommandStock.CommandText = "SELECT DVDId,Quantity FROM [dbo].[Stock]";
                SqlDataReader sqlDataReaderStock = sqlCommandStock.ExecuteReader();
                sqlCommandStock.Dispose();

                int i = 0;  //whileの中で扱う用
                while (sqlDataReaderStock.Read())
                {   //
                    if (DVDlist[i] == int.Parse(sqlDataReaderStock["DVDId"].ToString()))
                    {
                        if (int.Parse(sqlDataReaderStock["Quantity"].ToString()) == 0) //←
                        {   //在庫なしはグレーアウト　かつ　DVD名の横にすべて貸出中の文字
                            CheckBoxList1.Items[i].Enabled = false; //チェックをグレーアウト
                            CheckBoxList1.Items[i].Text += "    *すべて貸出中*";
                        }
                    }
                    i++;
                }

                sqlDataReaderStock.Close();
                objConn.Close();
                objConn.Dispose();
            }//try end
            catch
            {
                ErrMsg.Text = "データベースへの接続に失敗しました";
            }
        }//CreateRentalList()終了

        protected void Button3_Click(object sender, EventArgs e)
        { //選択した商品をレンタルボタン

            //チェックボックスが一つ以上チェックされているか
            if (int.Parse(Session["nRent"].ToString()) == 0)
            {   //Label3:チェックある無し確認された時のエラーメッセージ用
                Label3.Text = "商品が一つも選択されていません";
            }
            else
            {
                Label3.Text = "";   //チェックされているかのエラーメッセージ消去
                //チェックボックスに一つ以上のチェックがあり
                //会員IDも正しかった時
                //確認画面へ遷移
                //確認画面へ渡す値をそれぞれリストへ格納
                if(bflg)
                {
                    //選択された商品の貸し出しIDを格納する
                    SelectedDVDId = new List<string>();
                    //選択された商品を格納する
                    SelectedDVDName = new List<string>();

                    //チェックボックスリスト内のすべてのアイテムを調べる
                    for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                    {
                        //選択されたアイテムの貸し出しIDと商品名をリストに追加
                        if (CheckBoxList1.Items[i].Selected == true)
                        {
                            SelectedDVDId.Add(ListBox1.Items[i].ToString());
                            SelectedDVDName.Add(CheckBoxList1.Items[i].ToString());
                        }
                    }
                    //Server.Transfer("Conf_Rental.aspx");   //レンタル確認画面へ遷移
                }

            }//チェック確認のelse終了
        }//Button3_Click関数終了

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //チェックされたものの個数を確認する
            int nRent = 0;
            for(int i = 0; i < CheckBoxList1.Items.Count;i++)
            {   //↓チェックがついていたら1、ついていなかったら0で加算していく
                nRent += (CheckBoxList1.Items[i].Selected ? 1 : 0);
            }
            Session["nRent"] = nRent;
            //Label3.Text = Session["nRent"].ToString() + "個選択中です";
        }

        //チェックされたDVDのIDを確認画面に渡す用の関数
        public List<String> GetSelectedDVDID()
        {
            return SelectedDVDId;
        }
        //チェックされたDVDの名前を確認画面に渡す
        public List<String> GetSelectedDVDName()
        {
            return SelectedDVDName;
        }

    }
}
