<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UcesniciParamStampa.aspx.cs" Inherits="seminarskiVP.UcesniciParamStampa" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Parametarska štampa učesnika</title>
    <meta charset="utf-8" />
    <style>
        body {
            font-family: "Segoe UI", Arial, sans-serif;
            background-color: #f4f6f8;
            margin: 0;
            padding: 0;
        }

        .container {
            width: 85%;
            margin: 40px auto;
            background-color: white;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }

        h2 {
            text-align: center;
            color: #007bff;
            margin-bottom: 30px;
            font-size: 24px;
        }

        .filter {
            text-align: center;
            margin-bottom: 25px;
        }

        .filter label {
            font-weight: bold;
            margin-right: 10px;
        }

        .filter select, .filter button {
            padding: 8px 15px;
            font-size: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: white;
            cursor: pointer;
        }

        .filter button {
            background-color: #007bff;
            color: white;
            border: none;
        }

        .filter button:hover {
            background-color: #0056b3;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            font-size: 15px;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: #007bff;
            color: white;
        }

        tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        tr:hover {
            background-color: #eef4ff;
        }

        .center {
            text-align: center;
            margin-top: 30px;
        }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            text-decoration: none;
            background-color: #007bff;
            color: white;
            border-radius: 5px;
            transition: background 0.3s;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .back-btn {
            margin-top: 20px;
            text-align: center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <h2>
                <asp:Label ID="lblProjekat" runat="server" Text="Parametarska štampa učesnika"></asp:Label>
            </h2>

           

            <asp:GridView ID="gvUcesnici" runat="server" AutoGenerateColumns="False" GridLines="Both" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="Ime" HeaderText="Ime" />
                    <asp:BoundField DataField="Prezime" HeaderText="Prezime" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="OpisZadatka" HeaderText="Opis zadatka" />
                    <asp:BoundField DataField="Status" HeaderText="Status zadatka" />
                </Columns>
            </asp:GridView>

            <div class="back-btn">
                <a href="Default.aspx" class="btn">🏠 Vrati se na početnu</a>
            </div>

        </div>
    </form>
</body>
</html>
