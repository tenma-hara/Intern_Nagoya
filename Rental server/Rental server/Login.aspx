<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Rental_server.Login" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml" oncontextmenu="return false;">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

body {
font-size: 100%;
}

/*最も大きい文字サイズ*/
p.example1 { font-size: xx-large; }
/*かなり大きい文字サイズ*/
p.example2 { font-size: x-large; }
/*少し大きい文字サイズ*/
p.example3 { font-size: large; }
/*標準文字サイズ*/
p.example4 { font-size: medium; }
/*少し小さい文字サイズ*/
p.example5 { font-size: small; }
/*かなり小さい文字サイズ*/
p.example6 { font-size: x-small; }
/*最も小さい文字サイズ*/
p.example7 { font-size: xx-small; }

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p class="example1">ログイン画面&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </p></div>
        <p>
            
            <asp:Label ID="Label1" runat="server" Text="ユーザーID" Font-Bold="True" Font-Italic="False" Font-Overline="True" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="True" ForeColor="#003300"></asp:Label>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="UserIDMi" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="UserID" runat="server" placeholder="UserID" onclick="this.select(0,this.value.length)"  OnTextChanged="TextBox1_TextChanged" Width="263px"  ></asp:TextBox>
        </p>
        <p>
            &nbsp;<asp:Label ID="Label3" runat="server" Text="パスワード" Font-Overline="True" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="True"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Label ID="PasswordMi" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="Pass" runat="server" placeholder="password" type = "password" OnTextChanged="TextBox2_TextChanged" Width="268px"></asp:TextBox>
        </p>
        <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ログイン" />
        </p>
    <p>
        &nbsp;</p>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
