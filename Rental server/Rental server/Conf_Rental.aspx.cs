using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Rental_server
{
    public partial class Conf_Rental : System.Web.UI.Page
    {

            string sConnectionString = "Addr = 192.168.10.143;"
         + "User Id = sa;"
         + "password = P@ssw0rd;"
         + "Initial Catalog = DVDRentalDB;"
         + "Integrated Security = false;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)     //最初のアクセス時にのみ行う初期化
            {
                //レンタルするDVDIDと商品名を受け取る
               if (Context.Handler is rental)
                {
                    var Rental = (rental)Context.Handler;

                    List<string> RentalDVDName = Rental.GetSelectedDVDName();     //貸出商品保管用
                    List<string> RentalDVDId = Rental.GetSelectedDVDID();         //DVDID保管用

                    //セッションに追加
                    Session["Conf_Rent_DVDId"] = RentalDVDId;
                    Session["Conf_Rent_DVDName"] = RentalDVDName;

                    //ラベルに何点の商品をレンタルするかを表示する
                    DescriptionLabel.Text = "以下の"+RentalDVDName.Count()+ "点の商品をレンタルします。";

                    //DVDIDからレンタルする商品のリストを表示する
                    //リスト初期化
                    BulletedList1.Items.Clear();

                    //リスト追加
                    for (int i = 0; i < RentalDVDName.Count(); i++)
                    {
                        BulletedList1.Items.Add(RentalDVDName[i]);
                    }

                }
                Session["ConfRental_Flag"] = false; //画面遷移するかどうかのフラグ(返却確認画面用)
                                                    //true:決定キーで画面遷移する,false:しない
            }
        
        }

        //キャンセルボタン
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //返却管理画面へ移動
            Response.Redirect("rental.aspx");
        }

        //確定ボタン
        protected void DecideButton_Click(object sender, EventArgs e)
        {

            if(bool.Parse(Session["ConfRental_Flag"].ToString()))
            {
                //レンタル管理画面へ移動
                Response.Redirect("rental.aspx");
            }

            //--- 在庫確認 ---

            bool bSituation = true;     //在庫の状況確認
                                         //false:在庫あり
                                         //true:在庫なし

            List<int> FailureIDList = new List<int>();          //レンタル失敗したリスト
            //DVDIDの取得
            List<string> DVDID = (List<string>)Session["Conf_Rent_DVDId"];

            //データベース参照
            SqlConnection sqlConnection = new SqlConnection(sConnectionString);
            sqlConnection.Open();

            //DVDIDが同じものを一件ずつ探す
            for(int i=0;i<DVDID.Count();i++)
            {
                string Searchsql                                                   //DVDID
                         = "SELECT [Quantity] FROM [dbo].[Stock]  WHERE [Id] = " + DVDID[i];

                SqlCommand RentalCommand = sqlConnection.CreateCommand();
                RentalCommand.CommandText = Searchsql;

                SqlDataReader RentalDataReader = RentalCommand.ExecuteReader();
                RentalCommand.Dispose();

                string strNum = "-1";      //在庫数

                while (RentalDataReader.Read())
                {
                    strNum = RentalDataReader["Quantity"].ToString();
                }
                RentalDataReader.Close();


                if (int.Parse(strNum) <= 0)    //探していたDVDの在庫が無かったら
                {
                    FailureIDList.Add(i);         //失敗したリストに追加
                }
            }

            //失敗リストにDVDIDが入っていたら(在庫がないものがあったら)
            if(FailureIDList.Count() != 0)
            {
                bSituation = false;     //在庫フラグをおろす
            }

            if (bSituation)                            //在庫あり
            {

                //--- レンタル操作 ---

                //最終行の検索
                string Searchsql                                               
                        = "Select  count(Id) as count from [dbo].[Rental] ";

                SqlCommand SearchCommand = sqlConnection.CreateCommand();
                SearchCommand.CommandText = Searchsql;

                SqlDataReader SearchDataReader = SearchCommand.ExecuteReader();
                SearchCommand.Dispose();

                int nLast = -1;     //データベースの最終行格納用
                
                while(SearchDataReader.Read())
                {
                    nLast = int.Parse( SearchDataReader["count"].ToString());
                }

                SearchDataReader.Close();

                //借りたDVDの本数だけ回す
                for(int i=0;i<DVDID.Count();i++)
                {
                    string Updatesql
                  = "INSERT INTO[dbo].[Rental]([Id],[MemberId],[DvdId],[IsReturned],[InsertDateTime],[InsertUserId],[UpdateDateTime],[UpdateUserId]) VALUES("
                  + (nLast + i + 2).ToString() + ","                //ID(データベースの最終行+借りているDVDの数+2 (IDは2からスタートなので))
                  + Session["MemberID"].ToString() + ","            //借りる客のID
                  + DVDID[i] + ","                                  //借りるDVDID
                  +"0" + ","                                        //返却フラグは　0
                  +DateTime.Now.ToString().Substring(0, 10) + ","   //借り始めた時間
                  + Session["Id"].ToString() + ","                  //対応した店員のID
                  +"NULL" + ","                                     //更新した時間
                  +"NULL" + ")";                                    //更新した店員のID

                    SqlCommand RentalCommand = sqlConnection.CreateCommand();
                    RentalCommand.CommandText = Updatesql;

                    SqlDataReader RentalDataReader = RentalCommand.ExecuteReader();
                    RentalCommand.Dispose();

                    RentalDataReader.Close();

                    //在庫操作
                    string Stocksql
                        = "UPDATE [dbo].[Stock] SET  [Quantity] = [Quantity] - 1 WHERE [DVDId] = " + DVDID[i];

                    SqlCommand StockCommand = sqlConnection.CreateCommand();
                    StockCommand.CommandText = Stocksql;

                    SqlDataReader StockDataReader = StockCommand.ExecuteReader();
                    StockCommand.Dispose();

                    StockDataReader.Close();

                }

            


                //データベース終了
                sqlConnection.Close();
                //レンタル管理画面へ移動
                Response.Redirect("rental.aspx");

            }
            else                 //在庫なし
            {
                //--- 在庫なし通知 ---

                //在庫がないことを表示する
                ErrorLabel.Text = "以下の商品の在庫がありません";

                //貸出中の商品の表示
                //リスト初期化
                FailList.Items.Clear();

                //セッションから貸し出したDVD名を取ってくる。
                List<string> DVDName = (List<string>)Session["Conf_Rent_DVDName"];      

                for (int i=0;i<FailureIDList.Count();i++)
                {
                    //レンタル失敗表示リストに追加
                    FailList.Items.Add(DVDName[FailureIDList[i]]);

                    //レンタルリストからIDとDVD名を消去
                    DVDName.RemoveAt(FailureIDList[i]);
                    DVDID.RemoveAt(FailureIDList[i]);
                }

               

                //レンタルしようとしている商品が無かったら
                if (DVDID.Count() == 0)
                {
                    DescriptionLabel.Text = "レンタルできる商品がありません。";

                    //リスト初期化
                    BulletedList1.Items.Clear();

                    //画面遷移確認用フラグON
                    Session["ConfRental_Flag"] = true;

                    //キャンセルボタンを隠す
                    CancelButton.Visible = false;
                }
                else        //一本でも借りることができるなら
                {
                    //ラベルに何点の商品をレンタルするかを表示する
                    DescriptionLabel.Text = "以下の" + DVDName.Count() + "点の商品をレンタルします。";

                    //DVDIDからレンタルする商品のリストを表示する
                    //リスト初期化
                    BulletedList1.Items.Clear();

                    //リスト追加
                    for (int i = 0; i < DVDName.Count(); i++)
                    {
                        BulletedList1.Items.Add(DVDName[i]);
                    }
                }

                //データベース終了
                sqlConnection.Close();
            }


        }
    }
}