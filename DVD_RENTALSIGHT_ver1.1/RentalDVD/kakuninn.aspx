<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kakuninn.aspx.cs" Inherits="RentalDVD.kakuninn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<!-- Written by Kawabata -->
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    <asp:BulletedList ID="BulletedList1" runat="server">
    </asp:BulletedList>
    <asp:BulletedList ID="blSelectedId" runat="server" visible="false"/>


    <asp:Button ID="Button1" runat="server" style="margin-left: 38px" 
        Text="キャンセル" onclick="Button1_Click" /><asp:Button ID="Button2" 
        runat="server" Text="確認" onclick="Button2_Click" style="margin-left: 14px" 
        Width="106px" />
    </form>
</body>
</html>
