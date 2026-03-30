<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UcesniciSpisak.aspx.cs" Inherits="seminarskiVP.UcesniciSpisak" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Spisak učesnika</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f9f9f9;
        }

        .container {
            width: 90%;
            max-width: 1000px;
            margin: 40px auto;
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        h2 {
            text-align: center;
            margin-bottom: 30px;
            color: #333;
        }

        .grid {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 30px;
        }

        .grid th, .grid td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }

        .grid th {
            background-color: #f2f2f2;
            font-weight: bold;
        }

        .btn {
            padding: 6px 12px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            text-decoration: none;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .btn-danger {
            background-color: #dc3545;
        }

        .btn-danger:hover {
            background-color: #c82333;
        }

        .center {
            text-align: center;
            margin-top: 40px;
        }

        #lblZadNaslov {
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
            <h2>👥 Spisak učesnika</h2>

            <asp:GridView ID="gvUcesnici" runat="server" AutoGenerateColumns="False"
                          OnRowCommand="gvUcesnici_RowCommand" DataKeyNames="ID" CssClass="grid">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Ime" HeaderText="Ime" />
                    <asp:BoundField DataField="Prezime" HeaderText="Prezime" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />

                    <asp:TemplateField HeaderText="Akcija">
                        <ItemTemplate>
                            <asp:Button ID="btnPrikaziZad" runat="server" Text="📋 Zaduženja"
                                        CommandName="Zaduzenja"
                                        CommandArgument='<%# Eval("ID") + ";" + Eval("Ime") + " " + Eval("Prezime") %>'
                                        CssClass="btn" />

                            &nbsp;

                            <asp:Button ID="btnDodajZad" runat="server" Text="➕ Dodaj zaduženje"
                                        CommandName="DodajZad" CommandArgument='<%# Eval("ID") %>'
                                        CssClass="btn" />

                            <asp:Button ID="btnIzmeni" runat="server" Text="✏️ Izmeni"
                                        CommandName="Izmeni" CommandArgument='<%# Eval("ID") %>'
                                        CssClass="btn" />
                        </ItemTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="Brisanje">
                        <ItemTemplate>
                            <asp:Button ID="btnObrisi" runat="server" Text="🗑 Obriši"
                                        CommandName="Obrisi" CommandArgument='<%# Eval("ID") %>'
                                        CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>





                </Columns>
            </asp:GridView>


                <div class="center">
                    <asp:Button ID="btnStampaSve" runat="server" Text="🖨 Štampa svih učesnika"
                                OnClick="btnStampaSve_Click" CssClass="btn" />
                    &nbsp;

                    <asp:DropDownList ID="ddlProjekti" runat="server" CssClass="btn"> </asp:DropDownList>

                    <asp:Button ID="btnParamStampa" runat="server" Text="🖨 Parametarska štampa"
                                OnClick="btnParamStampa_Click" CssClass="btn" />
                </div>
    
            <asp:Label ID="lblZadNaslov" runat="server" Font-Bold="true" />



                            <!-- FILTER PO STATUSU -->
                <asp:Panel ID="pnlFilter" runat="server" Visible="false" style="margin-bottom: 20px; text-align:center;">
                    <asp:Label ID="lblFilter" runat="server" Text="Filtriraj zaduženja po statusu: " />
                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                        <asp:ListItem Text="-- Odaberite --" Value="" />
                        <asp:ListItem Text="Planirano" />
                        <asp:ListItem Text="U toku" />
                        <asp:ListItem Text="Završeno" />
                    </asp:DropDownList>
                </asp:Panel>

            <asp:GridView ID="gvZaduzenja" runat="server" AutoGenerateColumns="False"
                          OnRowCommand="gvZaduzenja_RowCommand" DataKeyNames="ID" CssClass="grid">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="OpisZadatka" HeaderText="Opis" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Projekat" HeaderText="Projekat" />

                    <asp:TemplateField HeaderText="Brisanje">
                        <ItemTemplate>
                            <asp:Button ID="btnObrisi" runat="server" Text="🗑 Obriši"
                                        CommandName="Obrisi" CommandArgument='<%# Eval("ID") %>'
                                        CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div class="center">
                <a href="Default.aspx" class="btn">🏠 Vrati se na početnu</a>
            </div>

        </div>
    </form>
</body>
</html>
