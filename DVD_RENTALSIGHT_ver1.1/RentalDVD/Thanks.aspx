<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thanks.aspx.cs" Inherits="RentalDVD.Thanks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<!-- Written by Kamiya -->
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbMessage" runat=server Text="ありがとうございました。" />
        <br />


        <asp:Button ID="btnBack" runat="server" Text="戻る" OnClick="Back_Click" />
    </div>
    </form>
</body>
</html>
