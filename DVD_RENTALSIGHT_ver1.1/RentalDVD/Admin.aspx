<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="RentalDVD.Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<!-- Written by Kawabata -->
<body>

    <form id="form1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="ログアウト" Height="24px" 
        Width="96px" style="margin-left: 246px" onclick="Button1_Click" />
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="会員ID"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Height="26px" 
        style="margin-bottom: 2px; margin-left: 44px;" Width="242px" 
       ></asp:TextBox>
    <p>
        <asp:Button ID="Button2" runat="server" Height="26px" Text="レンタル中の商品を表示" 
            Width="169px" style="margin-left: 169px" onclick="Button2_Click" />
    </p>
    <asp:Label ID="Label2" runat="server" Text="レンタル商品一覧"></asp:Label><br />
    <asp:Label ID="_Labl3" runat="server" Text=""></asp:Label>
    <p>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="69px" 
            ViewStateMode="Enabled" Width="325px">
        </asp:CheckBoxList>
        <asp:CheckBoxList ID="cbRentalId" runat="server" Visible=false />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button3" runat="server" Height="34px" Text="選択した商品を返却" 
            Width="152px" onclick="Button3_Click" style="margin-left: 192px" />

    </p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
