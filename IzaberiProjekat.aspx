<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IzaberiProjekat.aspx.cs" Inherits="seminarskiVP.IzaberiProjekat" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Izaberite projekat</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .container {
            width: 400px;
            margin: auto;
            padding-top: 40px;
            text-align: center;
        }

        h2 {
            margin-bottom: 30px;
        }

        select, input[type="submit"], .btn {
            width: 100%;
            padding: 10px;
            margin-top: 10px;
            font-size: 16px;
            border-radius: 4px;
            border: 1px solid #ccc;
        }

        .btn {
            background-color: #28a745;
            color: white;
            border: none;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #218838;
        }

        .message {
            margin-top: 15px;
            color: red;
        }

        .link-container {
            margin-top: 40px;
            text-align: center;
        }

        .btn-link {
            text-decoration: none;
            background-color: #007bff;
            color: white;
            padding: 8px 16px;
            border-radius: 4px;
            display: inline-block;
        }

        .btn-link:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>📋 Izaberite projekat za koji želite da dodate zaduženje</h2>

            <asp:DropDownList ID="ddlProjekti" runat="server" CssClass="form-control" />
            <br /><br />

            <asp:Button ID="btnNastavi" runat="server" Text="➕ Nastavi na dodavanje zaduženja" OnClick="btnNastavi_Click" CssClass="btn" />
            <br />

            <asp:Label ID="lblPoruka" runat="server" CssClass="message" />
        </div>

        <div class="link-container">
            <a href="Default.aspx" class="btn-link">🏠 Vrati se na početnu</a>
        </div>
    </form>
</body>
</html>
