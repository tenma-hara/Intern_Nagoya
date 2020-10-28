<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DVDReturn.aspx.cs" Inherits="Rental_server.DVDReturn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" oncontextmenu="return false;" lang ="ja">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" charset="utf-8"/>
    <title></title>
    <style type="text/css">
        h1{
text-align: center;
}
.center{
text-align: center;
}
        </style>
</head>

<body>
    <form id="form1" runat="server" style="background-color: #FFCCCC;">
        <div style="background-color: #FF66CC">
        &nbsp;<asp:Button ID="Button_LogOut" runat="server" width="96px" style="margin-right:auto; text-align: center; z-index: 1; left: 461px; top: 18px; position: absolute;" Text="ログアウト" OnClick="Button_LogOut_Click"/>
            <asp:Label ID="Label_Title" runat="server" Text="返却管理画面" Font-Size ="300%" ForeColor="Black" ></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label_User" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label>
        </div>
        <p style="background-color: #FFCCCC">
            <asp:Label ID="Label_MemberID" runat="server" Text="会員ID" ForeColor="Black" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TBox_MemberID" placeholder = "半角数字" onclick="this.select(0,this.value.length)" runat="server"></asp:TextBox>
            <asp:Button ID="Button_ShowItem" runat="server" Text="レンタル中の商品を表示" style="text-align: center" OnClick="Button_ShowItem_Click" Width="178px"/>
        </p>
        <p style="background-color: #FFCCCC">
            <asp:Label ID="Label_Error" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
        </p>
        <p style="background-color: #FFCCCC">
            <asp:Label ID="Label_ShowItem" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label>
        </p>
        <asp:CheckBoxList ID="CBoxList_ShowItem" runat="server" Height="245px" Width="666px" BackColor="#99FFCC" BorderColor="#FF0066" BorderWidth="10px" Font-Size="Medium" ForeColor="Black" BorderStyle="Solid" style="margin-right: 0px" Font-Bold="True" >
            </asp:CheckBoxList>
        <asp:CheckBoxList ID="CBoxList_RentalID" runat="server" Visible="false">
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="Button_Return" runat="server" Text="選択した商品を返却" OnClick="Button_Return_Click" Visible="False"/>
        <asp:Label ID="Label_NoCheck" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
    </form>
    
    <script src="/EnterScript.js"></script>

    <footer style="background-color: #FF66CC">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <p class="center" ><asp:Label ID="ShopName1" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="HG丸ｺﾞｼｯｸM-PRO" Font-Size="Small" Text="レンタルショップ" ForeColor="#000000"></asp:Label>
        <asp:Label ID="ShopName2" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="Red" Text="NA"></asp:Label>
        <asp:Label ID="ShopName3" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="#00CC00" Text="GO"></asp:Label>
        <asp:Label ID="ShopName4" runat="server" Font-Names="Mistral" Font-Size="X-Large" ForeColor="Blue" Text="YA"></asp:Label></p>
    </footer>
</body>
    
</html>
