<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UcesnikDodaj.aspx.cs" Inherits="seminarskiVP.UcesnikDodaj" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dodaj učesnika</title>
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
        input[type="email"] {
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
            <h2>👤 Dodaj novog učesnika</h2>

            <asp:Label runat="server" Text="Ime:" CssClass="aspNetLabel" />
            <asp:TextBox ID="txtIme" runat="server" />

            <asp:Label runat="server" Text="Prezime:" CssClass="aspNetLabel" />
            <asp:TextBox ID="txtPrezime" runat="server" />

            <asp:Label runat="server" Text="Email:" CssClass="aspNetLabel" />
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" />

           <div style="text-align: center; margin-top: 20px;">
              <asp:Button ID="btnSnimi" runat="server" Text="💾 Snimi učesnika" CssClass="btn" OnClick="btnSnimi_Click" />
           </div>

            <asp:Label ID="lblPoruka" runat="server" CssClass="message" ForeColor="Green" />
        </div>

        <div class="btn-link">
            <a href="Default.aspx">🏠 Vrati se na početnu</a>
        </div>
    </form>
</body>
</html>
