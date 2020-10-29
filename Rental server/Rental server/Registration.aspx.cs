using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

namespace Rental_server
{
    public partial class Registration : System.Web.UI.Page
    {
        string sConnectlonStrlng = "Addr = 192.168.10.201;"
                  + "User Id = sa;"
                  + "password = P@ssw0rd;"
                  + "Initial Catalog = DVDRentalDB;"
                  + "Integrated Security = false";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)     //最初のアクセス時にのみ行う初期化
            {
               // IDLabel.Text = "登録するID：" + Session["MemberID"].ToString();      //登録ID表示
            }
        }

        protected void NameText_TextChanged(object sender, EventArgs e)
        {

        }

       
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void StreetAdText_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ZipText_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DecButton_Click(object sender, EventArgs e)
        {
            int nErrorNum = 0;                               //情報が入力されていない個数

            //名前
            if (NameText.Text.CompareTo("") == 0)
            {
                ErrorNameLabel.Text = "名前が入力されていません";
                nErrorNum++;
            }
            else
            {
                ErrorNameLabel.Text = "";
            }

            //郵便番号
            var Text = ZipText.Text;

            if (ZipText.Text.CompareTo("") == 0)
            {
                ErrorZipLabel.Text = "郵便番号が入力されていません";
                nErrorNum++;

            }else if(!IsHalfByLength(ZipText.Text))
            {
                ErrorZipLabel.Text = "全角文字が入っています";
                nErrorNum++;
            }
            else if(!Text.All(char.IsDigit))
            {
                ErrorZipLabel.Text = "数値以外が入力されています";
                nErrorNum++;

            }
            else
            {
                ErrorZipLabel.Text = "";
            }

            //住所
            if (StreetAdText.Text.CompareTo("") == 0)
            {
                ErrorStAdLabel.Text = "住所が入力されていません";
                nErrorNum++;

            }
            else
            {
                ErrorStAdLabel.Text = "";
            }

            //電話番号
            Text = TELText.Text;
            if (TELText.Text.CompareTo("") == 0)
            {
                ErrorTELLabel.Text = "電話番号が入力されていません";
                nErrorNum++;

            }
            else if (!IsHalfByLength(TELText.Text))
            {
                ErrorTELLabel.Text = "全角文字が入っています";
                nErrorNum++;
            }
            else if(!Text.All(char.IsDigit))
            {
                ErrorTELLabel.Text = "数値以外が入力されています";
                nErrorNum++;

            }
            else
            {
                ErrorTELLabel.Text = "";
            }

            //どれか一つでも入力されてなかったら登録しない
            if (nErrorNum >0)
            {
                ErrorNumLabel.Text = "入力に失敗している項目が" + nErrorNum.ToString() + "件あります。";

                return;
            }


            //サーバ情報格納
            try
            {

                //---データ登録---
                SqlConnection objConn = new SqlConnection(sConnectlonStrlng);
                //サーバ接続
                objConn.Open();


                //最終行の検索
                string Searchsql
                        = "Select  count(Id) as count from [dbo].[Member] ";

                SqlCommand SearchCommand = objConn.CreateCommand();
                SearchCommand.CommandText = Searchsql;

                SqlDataReader SearchDataReader = SearchCommand.ExecuteReader();
                SearchCommand.Dispose();

                int nLast = -1;     //データベースの最終行格納用

                while (SearchDataReader.Read())
                {
                    nLast = int.Parse(SearchDataReader["count"].ToString());
                }

                SearchDataReader.Close();
          
                string Registsql
                     = " INSERT INTO [dbo].[Member] ([Id],[Name],[ZipCode],[Address],[TEL],[InsertUserId],[InsertDateTime],[UpdateUserId],[UpdateDateTime]) VALUES("
                      + (nLast +1).ToString() + ","        //ID
                      + "'" + NameText.Text + "'" + ","             //新しいメンバーの名前
                      + ZipText.Text + ","                          //郵便番号
                      + "'" + StreetAdText.Text + "'" + ","         //住所
                      + TELText.Text + ","                          //電話番号
                      + Session["Id"].ToString() + ","              //対応した店員のID
                      + "GETDATE()" + ","                           //対応した時間
                      + "NULL" + ","                                //更新した店員のID
                      + "NULL" + ")";                               //更新した店員の時間

                SqlCommand RegistCommand = objConn.CreateCommand();
                RegistCommand.CommandText = Registsql;

                SqlDataReader RentalDataReader = RegistCommand.ExecuteReader();
                RegistCommand.Dispose();

                RentalDataReader.Close();

                //データベース終了
                objConn.Close();

                //レンタル画面に戻る
                Server.Transfer("rental.aspx");
            }
            catch (Exception)
            {
                ErrorNumLabel.Text = "DBが接続されていません";
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //レンタル画面に戻る
            Server.Transfer("rental.aspx");
        }

        /// <summary>
        /// 文字列が半角かどうかを判定します
        /// </summary>
        /// <remarks>半角の判定を長さで行います</remarks>
        /// <param name="target">対象の文字列</param>
        /// <returns>文字列が半角の場合はtrue、それ以外はfalse</returns>
        public bool IsHalfByLength(string target)
        {
            return target.Length == Encoding.GetEncoding("shift_jis").GetByteCount(target);
        }

    }
}