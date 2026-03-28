<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="seminarskiVP.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prijava</title>
    <style>
        body {
            font-family: Arial;
            background-color: #f5f5f5;
        }
        .login-container {
            width: 400px;
            margin: auto;
            margin-top: 100px;
            padding: 30px;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }
        .login-container h2 {
            text-align: center;
            margin-bottom: 30px;
        }
        .login-container input[type="text"],
        .login-container input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .login-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #0275d8;
            border: none;
            color: white;
            font-weight: bold;
            border-radius: 5px;
            cursor: pointer;
        }
        .login-container input[type="submit"]:hover {
            background-color: #025aa5;
        }
        .message {
            color: red;
            text-align: center;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Prijava</h2>
            <asp:Label ID="lblUsername" runat="server" Text="Korisničko ime:" /><br />
            <asp:TextBox ID="txtUsername" runat="server" /><br />
            <asp:Label ID="lblPassword" runat="server" Text="Lozinka:" /><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Prijavi se" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="message" />
        </div>
    </form>
</body>
</html>
