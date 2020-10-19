<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalView.aspx.cs" Inherits="RentalDVD.RentalView" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<!-- Written by Kamiya -->
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:panel ID="Panel1" runat="server" Height="200px" Width="400px" BackColor="AliceBlue" >
            <asp:Label ID="lbMessage" runat="server" />
            <br/>
            <asp:BulletedList ID="blistRentalList" runat="server"/>
        </asp:panel>
            <asp:Button ID="btnApply" runat="server" Text="確定" OnClick="Apply_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="キャンセル" onclick="Cancel_Click"/>
    </div>
    </form>
</body>
</html>
