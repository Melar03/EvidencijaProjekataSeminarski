<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UcesniciStampa.aspx.cs" Inherits="seminarskiVP.UcesniciStampa" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Štampa - Lista učesnika</title>
    <meta charset="utf-8" />
    <style>
        body { font-family: Arial; margin: 40px; }
        h2 { text-align: center; }
        table { width: 100%; border-collapse: collapse; margin-top: 20px; }
        th, td { border: 1px solid #333; padding: 8px; text-align: left; }
        th { background-color: #f2f2f2; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Štampa - Lista svih učesnika</h2>
        <asp:GridView ID="gvUcesnici" runat="server" AutoGenerateColumns="False" GridLines="Both" BorderStyle="Solid">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Ime" HeaderText="Ime" />
                <asp:BoundField DataField="Prezime" HeaderText="Prezime" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
            </Columns>
        </asp:GridView>
    </form>


    <div class="center">
         <a href="Default.aspx" class="btn">🏠 Vrati se na početnu</a>
    </div>



</body>
</html>
