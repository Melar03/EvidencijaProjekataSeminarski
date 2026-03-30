<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjekatDodaj.aspx.cs" Inherits="seminarskiVP.ProjekatDodaj" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dodaj Projekat</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }

        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 30px;
        }

        .container {
            width: 500px;
            margin: 60px auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        label, .aspNetLabel {
            display: block;
            font-weight: bold;
            margin-top: 15px;
            margin-bottom: 5px;
            color: #444;
        }

        input[type="text"],
        textarea,
        input[type="date"] {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .btn {
            margin-top: 20px;
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            font-weight: bold;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .btn-link {
            text-align: center;
            display: block;
            margin-top: 30px;
        }

        .btn-link a {
            text-decoration: none;
            background-color: #007bff;
            padding: 10px 20px;
            color: white;
            border-radius: 5px;
        }

        .btn-link a:hover {
            background-color: #0056b3;
        }

        .message {
            margin-top: 20px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>📁 Unos novog projekta</h2>

            <asp:Label ID="lblNaziv" runat="server" Text="Naziv projekta:" CssClass="aspNetLabel" />
            <asp:TextBox ID="txtNaziv" runat="server" />

            <asp:Label ID="lblOpis" runat="server" Text="Opis projekta:" CssClass="aspNetLabel" />
            <asp:TextBox ID="txtOpis" runat="server" TextMode="MultiLine" Rows="4" />

            <asp:Label ID="lblPocetak" runat="server" Text="Datum početka:" CssClass="aspNetLabel" />
            <asp:TextBox ID="txtDatumPocetka" runat="server" TextMode="Date" />

            <asp:Label ID="lblZavrsetak" runat="server" Text="Datum završetka:" CssClass="aspNetLabel" />
            <asp:TextBox ID="txtDatumZavrsetka" runat="server" TextMode="Date" />

            <asp:Button ID="btnSnimi" runat="server" Text="💾 Snimi projekat" CssClass="btn" OnClick="btnSnimi_Click" />

            <asp:Label ID="lblPoruka" runat="server" CssClass="message" ForeColor="Green" />
        </div>

        <div class="btn-link">
            <a href="Default.aspx">🏠 Vrati se na početnu</a>
        </div>
    </form>
</body>
</html>
