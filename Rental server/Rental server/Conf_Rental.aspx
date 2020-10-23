<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Conf_Rental.aspx.cs" Inherits="Rental_server.Conf_Rental" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
            <asp:BulletedList ID="FailList" runat="server">
            </asp:BulletedList>
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
    </form>
</body>
</html>
