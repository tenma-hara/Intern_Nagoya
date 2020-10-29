<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Conf_Return.aspx.cs" Inherits="Rental_server.Conf_Return" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" oncontextmenu="return false;" lang ="ja">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>返却確認</title>
</head>
<body>
      <form id="form1" runat="server" style="background-color: #FFCCCC">
          <header style="background-color: #FF66CC; font-size: 24px;">               
              <asp:Label ID="RetTitleLabel" runat="server" Text="返却確認画面" Font-Size ="200%"></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </header>
        <div>
            <br />
            <asp:Label ID="DescriptionLabel" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:BulletedList ID="BulletedList1" runat="server">
        </asp:BulletedList>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CancelButton" runat="server" Text="キャンセル" OnClick="CancelButton_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="DecideButton" runat="server" Text="決定" OnClick="DecideButton_Click" Width="106px" />
        </p>
              <footer style="background-color: #FF66CC">
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
