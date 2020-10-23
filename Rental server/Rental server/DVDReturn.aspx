<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DVDReturn.aspx.cs" Inherits="Rental_server.DVDReturn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" oncontextmenu="return false;">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #BFFF80">
        <div style="background-color: #80FF00">
        &nbsp;<asp:Button ID="Button_LogOut" runat="server" width="96px" style="margin-right:auto; text-align: center; z-index: 1; left: 461px; top: 18px; position: absolute;" Text="ログアウト" OnClick="Button_LogOut_Click" />
            <asp:Label ID="Label_Title" runat="server" Text="返却管理画面" Font-Size ="300%"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label_User" runat="server" Text=""></asp:Label>
        </div>
        <p style="background-color: #BFFF80">
            <asp:Label ID="Label_MemberID" runat="server" Text="会員ID"></asp:Label>
            <asp:TextBox ID="TBox_MemberID" placeholder = "半角数字" runat="server"></asp:TextBox>
            <asp:Button ID="Button_ShowItem" runat="server" Text="レンタル中の商品を表示" style="text-align: center" OnClick="Button_ShowItem_Click" Width="178px" />
        </p>
        <p style="background-color: #BFFF80">
            <asp:Label ID="Label_Error" runat="server" Text="" ForeColor="Red"></asp:Label>
        </p>
        <p style="background-color: #BFFF80">
            <asp:Label ID="Label_ShowItem" runat="server" Text=""></asp:Label>
        </p>
        <asp:CheckBoxList ID="CBoxList_ShowItem" runat="server" BackColor="#B5FF6A" BorderStyle="Solid">
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="CBoxList_RentalID" runat="server" Visible="false">
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="Button_Return" runat="server" Text="選択した商品を返却" OnClick="Button_Return_Click" Visible="False"/>
        <asp:Label ID="Label_NoCheck" runat="server" Text="" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
