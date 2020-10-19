<%@ Page Title="ログイン" Language="C#" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="RentalDVD._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" />

<html xmlns="http://www.w3.org/1999/xhtml">
<!-- Written by Kamiya -->
<form runat=server>
<div>



<asp:panel runat="server" Height="200px" Width="400px" BackColor="AliceBlue" >
<center>
    <asp:label runat="server" id="Message"/><br/>
    ユーザーID<br />
    <asp:textbox runat="server" id="UserID" text="" MaxLength="16"/>
    <br />
    <br />
    パスワード<br />
    <asp:textbox runat="server" id="Password" text="" TextMode=Password MaxLength="16"/>
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="ログイン" onclick="btnLogin_Click"/>
</center>
</asp:panel>
</div>

</form>

</html>

