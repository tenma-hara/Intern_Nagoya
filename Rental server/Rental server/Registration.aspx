<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Rental_server.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang ="ja">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #99FF99;">
         <header style="background-color: #00FF00; font-size: 24px;">               会員登録画面&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </header>
        <div>
            <br />
            <br />
            <asp:Label ID="NameLabel" runat="server" Text="名前"></asp:Label>
            <br />
            <asp:TextBox ID="NameText" runat="server"  placeholder = "(例)山田　太郎"  OnTextChanged="NameText_TextChanged"></asp:TextBox>
            <asp:Label ID="ErrorNameLabel" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="ZipCodeLabel" runat="server" Text="郵便番号"></asp:Label>
            <br />
            <asp:TextBox ID="ZipText" runat="server" placeholder = "半角,ハイフンなし" OnTextChanged="ZipText_TextChanged"></asp:TextBox>
            <asp:Label ID="ErrorZipLabel" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="StreetAdLabel" runat="server" Text="住所"></asp:Label>
            <br />
            <asp:TextBox ID="StreetAdText" runat="server"  placeholder = "(例)愛知県　名古屋市・・・" OnTextChanged="StreetAdText_TextChanged"></asp:TextBox>
            <asp:Label ID="ErrorStrAdLabel" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="TELLabel" runat="server" Text="電話番号"></asp:Label>
            <br />
            <asp:TextBox ID="TELText" runat="server"  placeholder = "半角,ハイフンあり" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Label ID="ErrorTELLabel" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="ErrorNumLabel" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Button ID="CancelButton" runat="server" Text="キャンセル" OnClick="CancelButton_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DecButton" runat="server" OnClick="DecButton_Click" Text="決定" Width="106px" />
            <br />
        </div>
        <footer style="background-color: #00FF00">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="ShopName1" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="HG丸ｺﾞｼｯｸM-PRO" Font-Size="Small" Text="レンタルショップ"></asp:Label>
            <asp:Label ID="ShopName2" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="Red" Text="NA"></asp:Label>
            <asp:Label ID="ShopName3" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="#00CC00" Text="GO"></asp:Label>
            <asp:Label ID="ShopName4" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="Blue" Text="YA"></asp:Label>
        </footer>
    </form>
    <script src ="/EnterScript.js"></script>
</body>
</html>
