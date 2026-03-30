<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zaduzenja.aspx.cs" Inherits="seminarskiVP.Zaduzenja" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zaduženja za projekat</title>
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
            margin-bottom: 10px;
        }

        .lbl-projekat {
            text-align: center;
            display: block;
            font-size: 18px;
            font-weight: bold;
            color: #007bff;
            margin-bottom: 30px;
        }

        .container {
            width: 90%;
            margin: auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            margin-top: 40px;
        }

        .btn {
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            text-decoration: none;
            border-radius: 5px;
            display: inline-block;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .gridview-style {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview-style th {
            background-color: #007bff;
            color: white;
            padding: 10px;
            text-align: left;
        }

        .gridview-style td {
            padding: 10px;
            border-bottom: 1px solid #ccc;
        }

        .gridview-style tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .gridview-style tr:hover {
            background-color: #eef1f7;
        }

        .akcije-btn {
            padding: 6px 12px;
            background-color: #dc3545;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .akcije-btn:hover {
            background-color: #c82333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>📋 Zaduženja za projekat</h2>

            <!-- Label za ime projekta -->
            <asp:Label ID="lblImeProjekta" runat="server" CssClass="lbl-projekat" />

            <asp:GridView ID="gvZaduzenja" runat="server" AutoGenerateColumns="False"
                          CssClass="gridview-style"
                          OnRowCommand="gvZaduzenja_RowCommand" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="Ucesnik" HeaderText="👤 Učesnik" />
                    <asp:BoundField DataField="OpisZadatka" HeaderText="📝 Opis" />
                    <asp:BoundField DataField="Status" HeaderText="📌 Status" />

                    <asp:TemplateField HeaderText="🗑 Akcije">
                        <ItemTemplate>
                            <asp:Button ID="btnObrisi" runat="server" Text="Obriši"
                                        CommandName="Obrisi" CommandArgument='<%# Eval("ID") %>'
                                        CssClass="akcije-btn"
                                        OnClientClick="return confirm('Da li ste sigurni?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div style="text-align:center; margin-top: 40px;">
            <a href="Default.aspx" class="btn">🏠 Vrati se na početnu</a>
        </div>
    </form>
</body>
</html>
