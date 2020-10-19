<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rental.aspx.cs" Inherits="RentalDVD.Rental" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<!-- Written by Kamiya -->
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">

    <asp:Panel ID="Panel2" runat="Server" Width="400px" BackColor="Azure" ScrollBars="Auto">

  
    <asp:Label runat=server ID="lbLoginUser" /><br />
    <asp:Button ID="btnLogout" runat="server" Text="ログアウト" onclick="Logout_Click"/><br />
    商品一覧<br />
    <br/>
    在庫切れ及び既に借りているDVDは選択できません。<br />
    </asp:Panel>

    

        <asp:Panel ID="Panel1" runat="Server" Height="200px" Width="400px" BackColor="AliceBlue" ScrollBars="Auto">

            <asp:CheckBoxList ID="RentalList" runat="server" BackColor=AliceBlue Height="26px" />

        </asp:Panel>   
            
    <asp:Panel ID="Panel3" runat="Server" Width="400px" BackColor="Azure" ScrollBars="Auto">
    <asp:Button ID="btnRental" runat="server" Text="選択した商品をレンタル" onclick="Rental_Click"/>
    </asp:Panel>
    </form>
</body>
</html>
