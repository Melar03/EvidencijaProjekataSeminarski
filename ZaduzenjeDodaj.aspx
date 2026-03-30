<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZaduzenjeDodaj.aspx.cs" Inherits="seminarskiVP.ZaduzenjeDodaj" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dodaj Zaduženje</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            padding-top: 40px;
            background-color: #f9f9f9;
        }

        .container {
            width: 450px;
            margin: auto;
            background-color: #fff;
            padding: 25px 30px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            border-radius: 8px;
        }

        h2 {
            text-align: center;
            color: #333;
        }

        label, .aspLabel {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        input[type="text"], textarea, select, .aspTextBox, .aspDropDownList {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btn {
            background-color: #0275d8;
            color: white;
            padding: 10px 16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #025aa5;
        }

        .center {
            text-align: center;
        }

        .label-status {
            margin-top: 10px;
            font-weight: normal;
        }

        .back-link {
            display: inline-block;
            margin-top: 40px;
            text-decoration: none;
            color: white;
            background-color: #5cb85c;
            padding: 10px 16px;
            border-radius: 5px;
        }

        .back-link:hover {
            background-color: #449d44;
        }

        .status-message {
            margin-top: 10px;
            font-weight: bold;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>➕ Dodavanje zaduženja</h2>

            <asp:Label ID="lblProjekatID" runat="server" CssClass="aspLabel" Font-Bold="true" ForeColor="Blue" />
            <asp:Label ID="lblUcesnik" runat="server" CssClass="aspLabel" Font-Bold="true" ForeColor="Green" />

            <asp:DropDownList ID="ddlUcesnici" runat="server" CssClass="aspDropDownList" />

            <asp:Label runat="server" Text="Opis zadatka:" CssClass="aspLabel" />
            <asp:TextBox ID="txtOpis" runat="server" TextMode="MultiLine" Rows="4" CssClass="aspTextBox" />

            <asp:Label runat="server" Text="Status:" CssClass="aspLabel" />
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="aspDropDownList">
                <asp:ListItem Text="Planirano" />
                <asp:ListItem Text="U toku" />
                <asp:ListItem Text="Završeno" />
            </asp:DropDownList>

            <div class="center">
                <asp:Button ID="btnDodaj" runat="server" Text="💾 Dodaj zaduženje" CssClass="btn" OnClick="btnDodaj_Click" />
                <asp:Label ID="lblPoruka" runat="server" CssClass="status-message" />
            </div>
        </div>

        <div class="center">
            <a href="Default.aspx" class="back-link">🏠 Vrati se na početnu</a>
        </div>
    </form>
</body>
</html>
