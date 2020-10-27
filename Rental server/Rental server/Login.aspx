<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Rental_server.Login" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml" oncontextmenu="return false;" lang="ja">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" charset="utf-8" />
    <title></title>
    <style type="text/css">
h1{
text-align: center;
}
.center{
text-align: center;
}

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
            <p class="center" > <asp:Label ID="Label5" runat="server" Text="レンタルショップ" Font-Bold="True" Font-Italic="False"  Font-Size="Small" Font-Strikeout="False"  ></asp:Label><asp:Label ID="Label6" runat="server" Text="NA" Font-Bold="True" Font-Italic="False"  Font-Size="XX-Large" Font-Strikeout="False" ForeColor="Red" Font-Overline="False"  ></asp:Label><asp:Label ID="Label7" runat="server" Text="GO" Font-Bold="True" Font-Italic="False"  Font-Size="XX-Large" Font-Strikeout="False" ForeColor="#00CC00" Font-Underline="False"  ></asp:Label><asp:Label ID="Label8" runat="server" Text="YA" Font-Bold="True" Font-Italic="False"  Font-Size="XX-Large" Font-Strikeout="False" ForeColor="#0033CC" Font-Overline="False" Font-Underline="False"  ></asp:Label>&nbsp;</p>
            <p class="center" > 
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label></p>
            <p class="center" > 
                <asp:Label ID="Label4" runat="server" Text="ログイン画面" Font-Bold="True" Font-Italic="False"  Font-Size="XX-Large" Font-Strikeout="False"  ></asp:Label></p>
            <p class="center" > &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                
           </p>
        </div>
        <p  class="center">
            
            &nbsp;&nbsp;
            
            <asp:Label ID="Label1" runat="server" Text="ユーザーID" Font-Bold="True" Font-Italic="False" Font-Overline="True" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="True" ></asp:Label>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="UserIDMi" runat="server" Text=""></asp:Label>
        </p>
        <p class="center">
            <asp:TextBox ID="UserID" runat="server" placeholder = "UserID" onclick="this.select(0,this.value.length)"  OnTextChanged="TextBox1_TextChanged" Width="263px"  ></asp:TextBox>
        </p>
        <p class="center">
            &nbsp;&nbsp;
            &nbsp;<asp:Label ID="Label3" runat="server" Text="パスワード" Font-Overline="True" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="True"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Label ID="PasswordMi" runat="server" Text=""></asp:Label>
        </p>
        <p class="center">
            <asp:TextBox ID="Pass" runat="server" placeholder="password" type = "password" OnTextChanged="TextBox2_TextChanged" Width="268px"></asp:TextBox>
        </p>
        <p class="center">
            &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ログイン" />
        </p>
        <p class="center">
            &nbsp;</p>
        <p class="center">
            <asp:Button ID="SearchDVD" runat="server" Text="商品を検索する" Font-Bold="True" Font-Size="Small" OnClick="SearchDVD_Click" />
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
