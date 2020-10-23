using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

//--- takada akifumi ---

namespace Rental_server
{
    public partial class Conf_Return : System.Web.UI.Page
    {

        string sConnectionString = "Addr = localhost;"
     + "User Id = sa;"
     + "password = P@ssw0rd;"
     + "Initial Catalog = DVDRentalDB;"
     + "Integrated Security = false;";

       

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)     //最初のアクセス時にのみ行う初期化
            {
                
                //--- 値渡し ---
                //*
                //貸出IDを受け取る
                if (Context.Handler is DVDReturn)
                {
                    var Return =  (DVDReturn)Context.Handler;     

                    List<string> RentalDVD = Return.GetSelectedItem();     //貸出商品保管用
                    List<string> RentalId = Return.GetSelectedID();         //貸出ID保管用

                    //セッションに入れる
                    Session["Conf_Ref_DVD"] = RentalDVD;
                    Session["Conf_Ref_ID"] = RentalId;

                    //ラベルに何点の商品を返却するかを表示する
                    DescriptionLabel.Text = "以下の" + RentalDVD.Count() + "点の商品を返却します。";

                    //貸出IDから何を返却するかのリストを表示する
                    //リスト初期化
                    BulletedList1.Items.Clear();

                    //リスト追加
                    for(int i=0;i<RentalDVD.Count();i++)
                    {
                        BulletedList1.Items.Add(RentalDVD[i]);
                    }

                }
                //*/
                
                Session["ConfReturn_Flag"] = false; //ボタンが押されているか確認用フラグ(返却確認画面用)
                                                    //true:押されている,false:されていない
            }               
            else
            {

            }
             
        }

        //キャンセルボタン
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //返却管理画面へ移動
            Response.Redirect("DVDReturn.aspx");
        }

        //確定ボタン
        protected void DecideButton_Click(object sender, EventArgs e)
        {

            if(bool.Parse(Session["ConfReturn_Flag"].ToString()))     //返却済みの商品表示画面の場合
            {
                //返却管理画面へ移動
                Response.Redirect("DVDReturn.aspx");
            }

            //--- 返却済みかどうかのチェック ---

            //返却データベース参照            
            //表示リスト初期化(返却失敗時に使うため)
            BulletedList1.Items.Clear();

            bool bFailFlag = false;       //返却失敗した時に建てるフラグ
            List<string> DVDID = new List<string>();    //DVDID保存用

            //情報取得

            List<string> RentalDVD = (List<string>)Session["Conf_Ref_DVD"];     //貸出商品保管用
            List<string> RentalId = (List<string>)Session["Conf_Ref_ID"];       //貸出ID保管用

            //データベース接続
            SqlConnection sqlConnection = new SqlConnection(sConnectionString);
            sqlConnection.Open();

            for(int i=0;i< RentalId.Count();i++)
            {
                //貸出IDが同じものを探す
                string Returnsql                                                                                            //貸出ID
                         = "SELECT [Id],[MemberId],[DvdId],[IsReturned]   FROM [DVDRentalDB].[dbo].[Rental]   WHERE [Id] = " + RentalId[i];

                SqlCommand ReturnCommand = sqlConnection.CreateCommand();
                ReturnCommand.CommandText = Returnsql;

                SqlDataReader ReturnDataReader = ReturnCommand.ExecuteReader();
                ReturnCommand.Dispose();

                //詳細情報を保存
                bool IsReturned = true;     //返却済みかどうか:(true:返却済み,false:未返却)


                while (ReturnDataReader.Read())
                {
                    DVDID.Add( ReturnDataReader["DvdId"].ToString());
                    IsReturned = bool.Parse(ReturnDataReader["IsReturned"].ToString());
                }

                ReturnDataReader.Close();

             
                    if(IsReturned)     //返却フラグが1だったら(返却済みだったら)
                    {
                      
                        //失敗した商品名を追加
                        BulletedList1.Items.Add(RentalDVD[i]);
                       
                        //失敗フラグを立てる
                        bFailFlag = true;
                    }
            }


            //失敗フラグが立っていなかったら返却操作して画面遷移
            if(!bFailFlag)
            {

                //返却操作
                for (int i = 0; i < RentalId.Count(); i++)
                {
                    string Updatesql                                            //貸出ID
                    = "UPDATE[dbo].[Rental] SET[IsReturned] = 1  WHERE[Id] = " + RentalId[i];

                    SqlCommand UpdateCommand = sqlConnection.CreateCommand();
                    UpdateCommand.CommandText = Updatesql;

                    SqlDataReader UpdateDataReader = UpdateCommand.ExecuteReader();
                    UpdateCommand.Dispose();

                    UpdateDataReader.Close();

                    //在庫操作

                    Updatesql                                                           //DVD ID
                  = "UPDATE [dbo].[Stock] SET  [Quantity] = [Quantity] + 1 WHERE [DVDId] = " + DVDID[i];

                    UpdateCommand = sqlConnection.CreateCommand();
                    UpdateCommand.CommandText = Updatesql;

                    UpdateDataReader = UpdateCommand.ExecuteReader();
                    UpdateCommand.Dispose();

                    UpdateDataReader.Close();
                }
                //データベース終了
                sqlConnection.Close();

                //返却管理画面へ移動
                Response.Redirect("DVDReturn.aspx");
            }
            else       //立っていれば画面再表示
            {

                //すでに返却済みであることを表示する
                DescriptionLabel.Text = "返却済みの商品があります";

                Session["ConfReturn_Flag"] = true; //再描画確認用フラグON

                //キャンセルボタンを隠す
                CancelButton.Visible = false;

            }

            //データベース終了
            sqlConnection.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}