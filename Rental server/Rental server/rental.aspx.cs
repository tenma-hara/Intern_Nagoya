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

            //何らかの手法でこの画面から始まった際ログイン画面に戻す
            //ログイン時にIdを控えているのでそれがなければログインしていない状態
            if (Session["Id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {   //最初に行う処理
                //テキストボックスの初期化
                Session["MemberID"] = "";
                Session["nRent"] = 0;
                mIDBox1.Text = Session["MemberID"].ToString();
                RentButton3.Visible = false;    //選択した商品をレンタルボタンを非表示
            }
            else
            { //2回目以降
                Session["MemberID"] = mIDBox1.Text; //初期化しなくてもよい
                if (bflg)
                    RentButton3.Visible = true; //レンタルボタンの表示
                else
                    RentButton3.Visible = false;//レンタルボタンの非表示
            }
            CancelButton.Visible = false;   //会員を新規登録するか
            YESButton.Visible = false;      //否かを選択するボタンを非表示

            //ログインユーザーの名前を表示
            UserName.Text = "現在のユーザー: " + Session["UserID"] ;
        }//Page_Load関数終了

        // ----- ログアウトボタンをクリックした際の処理
        protected void Button1_Click(object sender, EventArgs e)
        {//ログアウトボタン
            Session["MemberID"] = null;   //Sessionをnullにする
            Session["UserID"] = null;
            Session["nRent"] = null;
            //ログイン画面へ遷移する
            Response.Redirect("Login.aspx");

        }

        // ----- 会員の照合ボタンを押した際の処理
        protected void Button2_Click(object sender, EventArgs e)
        { //会員の照合ボタン
            List<string> sMemIDList = new List<string>();//会員ID格納用
            List<string> NameList = new List<string>();//会員名格納用
            ErrMsg.Text = "";   //都度エラーメッセージは消す
            Label3.Text = "";   //レンタルボタンのエラーメッセージ
            MemberName.Text = ""; //会員名のクリア
            bflg = false;
            RentButton3.Visible = false;//レンタルボタンの非表示
            CancelButton.Visible = false;   //ボタンの非表示
            YESButton.Visible = false;      //ボタンの非表示

            //各種リストはボタンを押す度クリアする
            CheckBoxList1.Items.Clear();    //商品一覧
            sMemIDList.Clear();             //会員IDリスト
            ListBox1.Items.Clear();         //DVDIDのリスト

            try
            {
                //サーバ情報格納
                string sConnectionString = "Addr = localhost;"   //192.168.10.201
                    + "User Id = sa;"
                    + "password = P@ssw0rd;"
                    + "Initial Catalog = DVDRentalDB;"
                    + "Integrated Security = false";

                SqlConnection objConn = new SqlConnection(sConnectionString);
                //サーバ接続
                objConn.Open();

                SqlCommand sqlCommand = objConn.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM [dbo].[Member]";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {   //会員IDをリストへ格納
                    sMemIDList.Add(sqlDataReader["Id"].ToString());
                    NameList.Add(sqlDataReader["Name"].ToString());
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
            int nId = 0;
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
                        if (!int.TryParse(mIDBox1.Text, out nId))
                        {//数字以外が入力されていたら
                            Session["MemberID"] = "";
                            mIDBox1.Text = "";
                            ErrMsg.Text = "数字以外が入力されています";
                            CheckBoxList1.Items.Clear();
                        }
                        else
                        {//数字であった場合
                            Session["MemberID"] = mIDBox1.Text;
                            MemberName.Text = "会員を新規登録しますか？";
                            ErrMsg.Text = "※入力された会員IDは存在しません";
                            CheckBoxList1.Items.Clear();
                            CancelButton.Visible = true;    //会員を新規登録するか否か
                            YESButton.Visible = true;       //選択するボタンを表示
                        }
                        bflg = false;
                    }
                    else
                    {//問題なかった場合
                        ErrMsg.Text = "";
                        //照合された会員名を表示
                        for(int j = 0;j < sMemIDList.Count;j++)
                        {   //会員IDリストのIDと入力された番号が合致したとき
                            if(sMemIDList[j] == mIDBox1.Text)
                            {   
                                MemberName.Text = "会員名：" + NameList[j] + " 様";
                            }
                        }

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
                    RentButton3.Visible = true; //選択した商品をレンタルボタンを表示
                }
            }//elseif(true)終了

        }//Button2_Click関数終了

        //商品一覧を表示する関数
        //DBからDVDと在庫を見て
        //在庫のないものはチェックボックスがグレーアウトされる(チェックできないようになる)
        private void CreateRentalList()
        {   //商品一覧を作成する関数
            //サーバ情報格納
            string sConnectionString = "Addr = localhost;"    //192.168.10.201
                + "User Id = sa;"
                + "password = P@ssw0rd;"
                + "Initial Catalog = DVDRentalDB;"
                + "Integrated Security = false";
            try
            {
                SqlConnection objConn = new SqlConnection(sConnectionString);
                //サーバ接続
                objConn.Open();

                SqlCommand sqlCommandDVD = objConn.CreateCommand();
                sqlCommandDVD.CommandText = "SELECT Id,Name FROM [dbo].[DVD]";
                SqlDataReader sqlDataReaderDVD = sqlCommandDVD.ExecuteReader();
                sqlCommandDVD.Dispose();
                List<int> DVDlist = new List<int>();
                while (sqlDataReaderDVD.Read())
                {   //商品一覧の表示
                    DVDlist.Add(int.Parse(sqlDataReaderDVD["Id"].ToString()));//DVDテーブルのIDリスト
                    ListBox1.Items.Add(sqlDataReaderDVD["ID"].ToString()); //画面上で見えないリストで管理
                    CheckBoxList1.Items.Add(sqlDataReaderDVD["Name"].ToString());
                }
                sqlDataReaderDVD.Close();

                //在庫チェック
                SqlCommand sqlCommandStock = objConn.CreateCommand();
                sqlCommandStock.CommandText = "SELECT DVDId,Quantity FROM [dbo].[Stock]";
                SqlDataReader sqlDataReaderStock = sqlCommandStock.ExecuteReader();
                sqlCommandStock.Dispose();
                var DVDId = new List<int>();    //StockテーブルのDVDId
                var Quantity = new List<int>(); //Stoclテーブルの在庫数

                while (sqlDataReaderStock.Read())
                {//在庫情報をリストへ格納
                    DVDId.Add(int.Parse(sqlDataReaderStock["DVDId"].ToString()));
                    Quantity.Add(int.Parse(sqlDataReaderStock["Quantity"].ToString()));
                }
            sqlDataReaderStock.Close();

            int i = 0;  //whileの中で扱う用
                int j = 0;
                while (i < DVDlist.Count)
                {   //
                    if (DVDlist[i] == DVDId[j])
                    {
                        if (Quantity[j] == 0) //←右辺は在庫数
                        {   //在庫なしはグレーアウト　かつ　DVD名の横にすべて貸出中の文字
                            CheckBoxList1.Items[i].Enabled = false; //チェックをグレーアウト
                            CheckBoxList1.Items[i].Text += "    *すべて貸出中*";
                        }
                        j++;
                    }
                    else
                    {   //DVDlistにあるIDがStockのDVDIdになかった場合
                        CheckBoxList1.Items[i].Enabled = false;
                        CheckBoxList1.Items[i].Text += "     *在庫がありません*";
                        DVDId.Add(0);   //DVDlistとDVDIdと要素数が異なると比較ができないため
                        Quantity.Add(0);//DBになかった場合,空のデータを追加する
                    }
                    i++;
                }

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
                    Server.Transfer("Conf_Rental.aspx");   //レンタル確認画面へ遷移
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

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            CancelButton.Visible = false;
            YESButton.Visible = false;
            MemberName.Text = "";
            ErrMsg.Text = "";
            mIDBox1.Text = "";
            Session["MemberID"] = "";
        }

        protected void YESButton_Click(object sender, EventArgs e)
        {//会員登録ページへ
           Server.Transfer("Registration.aspx");
        }

        //--- 会員を検索ボタン
        protected void SearchButton_Click(object sender, EventArgs e)
        { //会員検索ページへ飛ぶ
            Server.Transfer("Member search.aspx");
        }

        protected void RegistButton_Click(object sender, EventArgs e)
        {//会員登録ボタン　->  会員登録ページへ
            Server.Transfer("Registration.aspx");
        }
    }
}
