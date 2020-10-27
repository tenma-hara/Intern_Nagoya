<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DVDSearch.aspx.cs" Inherits="Rental_server.DVDSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang ="ja">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品検索ページ</title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #99FF99">
        <header style="background-color: #00FF00">

            <asp:Label ID="HeaderName" runat="server" Text="商品検索ページ" Font-Size="XX-Large"></asp:Label>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </header>

        <div>
        </div>
        <asp:Label ID="DVDName" runat="server" Text="DVD名" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="DVDNameText"  placeholder = "一部で可" onclick="this.select(0,this.value.length)" runat="server" Height="16px" Width="160px"></asp:TextBox>
        <asp:Button ID="NameSearch" runat="server" Text="検索" OnClick="NameSearch_Click" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ErrMsg" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Result" runat="server" Text="検索結果" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ResultCount" runat="server" Text=""></asp:Label>
        <br />
&nbsp;
        <asp:ListBox ID="DVDListBox1" runat="server" Height="223px" Width="415px" BackColor="#66FFFF" Font-Size="Large"></asp:ListBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="戻る" OnClick="Button1_Click" />
        <br />
    </form>
     <script src ="/EnterScript.js"></script>
</body>
        <footer style="background-color: #00FF00">

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ShopName1" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="HG丸ｺﾞｼｯｸM-PRO" Font-Size="Small" Text="レンタルショップ"></asp:Label>
        <asp:Label ID="ShopName2" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="Red" Text="NA"></asp:Label>
        <asp:Label ID="ShopName3" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="#00CC00" Text="GO"></asp:Label>
        <asp:Label ID="ShopName4" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="Blue" Text="YA"></asp:Label>

    </footer>
</html>
