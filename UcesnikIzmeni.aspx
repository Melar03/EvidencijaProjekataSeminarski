<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UcesnikIzmeni.aspx.cs" Inherits="seminarskiVP.UcesnikIzmeni" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Izmeni učesnika</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f9f9f9;
        }
        .container {
            width: 400px;
            margin: 60px auto;
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h2 {
            text-align: center;
            color: #333;
        }
        label {
            font-weight: bold;
        }
        input[type="text"], input[type="email"] {
            width: 100%;
            padding: 8px;
            margin-top: 5px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .btn {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0056b3;
        }
        .msg {
            text-align: center;
            font-weight: bold;
            margin-top: 15px;
        }

        #lblUcesnikIme{
            display: block;
            margin-bottom: 20px;
            font-size: 18px;
            color: #0066cc;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Izmeni podatke o učesniku</h2>
            <asp:Label ID="lblUcesnikIme" runat="server" Font-Bold="true" />

            <asp:Label runat="server" Text="Ime:" />
            <asp:TextBox ID="txtIme" runat="server" />

            <asp:Label runat="server" Text="Prezime:" />
            <asp:TextBox ID="txtPrezime" runat="server" />

            <asp:Label runat="server" Text="Email:" />
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" />

            <asp:Button ID="btnSnimi" runat="server" Text="💾 Sačuvaj izmene" CssClass="btn" OnClick="btnSnimi_Click" />

            <asp:Label ID="lblPoruka" runat="server" CssClass="msg" />
        </div>
    </form>
</body>
</html>
