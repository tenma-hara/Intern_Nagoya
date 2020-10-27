<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member search.aspx.cs" Inherits="Rental_server.Member_search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"oncontextmenu="return false;" lang="ja">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="会員検索" Font-Size ="300%"></asp:Label>
            <br />
            <br />
            　<asp:Label ID="Label2" runat="server" Text="名前"></asp:Label>
            　<asp:TextBox ID="TextBox1" runat="server" placeholder = "お名前" style="margin-bottom: 0px" onclick="this.select(0,this.value.length)"></asp:TextBox>
            <br />
        </div>
        <p>
            <asp:Label ID="Label3" runat="server" Text="電話番号"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" placeholder = "半角,ハイフンあり" onclick="this.select(0,this.value.length)" ></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="検索" OnClick="Button1_Click1" />
            <asp:Label ID="Label4" runat="server" Text="名前もしくは電話番号が間違っています" ForeColor="Red" Visible="False"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
          <asp:CheckBoxList ID="CheckBoxList1" runat="server"  >
           </asp:CheckBoxList> 
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="戻る" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
