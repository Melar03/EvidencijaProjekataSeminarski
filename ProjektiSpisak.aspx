<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjektiSpisak.aspx.cs" Inherits="seminarskiVP.ProjektiSpisak" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


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
                    margin-right: 5px;
                    padding: 5px 10px;
                    border: none;
                    border-radius: 3px;
                    cursor: pointer;
                }

                .akcije-btn:first-child {
                    background-color: #28a745;
                    color: white;
                }

                .akcije-btn:last-child {
                    background-color: #dc3545;
                    color: white;
                }

                .akcije-btn:hover {
                    opacity: 0.9;
                }


                #pnlDodajUcesnika {
    margin-top: 30px;
    padding: 25px;
    background-color: #fdfdfd;
    border: 2px solid #007bff;
    border-radius: 10px;
    box-shadow: 0 4px 10px rgba(0,0,0,0.1);
}

#pnlDodajUcesnika h3 {
    color: #007bff;
    margin-bottom: 20px;
    text-align: center;
    font-weight: bold;
}

#pnlDodajUcesnika label {
    font-weight: bold;
    color: #333;
    display: block;
    margin-top: 10px;
    margin-bottom: 5px;
}

#pnlDodajUcesnika .form-control,
#pnlDodajUcesnika select {
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 6px;
    margin-bottom: 15px;
}

#pnlDodajUcesnika .btn {
    margin-right: 10px;
    margin-top: 10px;
}



            </style>




    <title>Spisak Projekata</title>
</head>
<body>
    <form id="form1" runat="server">
                           <div class="container">
                        <h2>📋 Spisak svih projekata</h2>

                        <asp:GridView ID="gvProjekti" runat="server" AutoGenerateColumns="False"
                                      CssClass="gridview-style"
                                      OnRowCommand="gvProjekti_RowCommand" DataKeyNames="ID">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Naziv" HeaderText="Naziv projekta" />
                                <asp:BoundField DataField="Opis" HeaderText="Opis" />
                                <asp:BoundField DataField="DatumPocetka" HeaderText="Početak" DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:BoundField DataField="DatumZavrsetka" HeaderText="Završetak" DataFormatString="{0:dd.MM.yyyy}" />

                                <asp:TemplateField HeaderText="Akcije">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDetalji" runat="server" Text="🔍 Detalji"
                                                    CommandName="Detalji" CommandArgument='<%# Eval("ID") %>'
                                                    CssClass="akcije-btn" />

                                        <asp:Button ID="btnDodajUcesnika" runat="server" Text="➕ Dodaj učesnika"
                                                     CommandName="DodajUcesnika" CommandArgument='<%# Eval("ID") %>'
                                                     CssClass="akcije-btn" />


                                        <asp:Button ID="btnObrisi" runat="server" Text="🗑 Obriši"
                                                    CommandName="Obrisi" CommandArgument='<%# Eval("ID") %>'
                                                    OnClientClick="return confirm('Da li ste sigurni?');"
                                                    CssClass="akcije-btn" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>

                        </asp:GridView>

                        <asp:Panel ID="pnlDodajUcesnika" runat="server" CssClass="container" Visible="false">
                                <h3>Dodaj učesnika na projekat</h3>
                                <asp:DropDownList ID="ddlUcesniciDodaj" runat="server"></asp:DropDownList>


                                <asp:Label ID="lblNazivProjekta" runat="server" Font-Bold="true"></asp:Label>
                                <br /><br />

                                <label for="txtOpisZadatka">Opis zadatka:</label>
                                <asp:TextBox ID="txtOpisZadatka" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                <br /><br />

                                <label for="ddlStatus">Status zadatka:</label>
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                    <asp:ListItem Value="U toku">U toku</asp:ListItem>
                                    <asp:ListItem Value="Završeno">Završeno</asp:ListItem>
                                    <asp:ListItem Value="Na čekanju">Na čekanju</asp:ListItem>
                                </asp:DropDownList>
                                <br /><br />


                                <asp:Button ID="btnDodajUcesnikaPotvrdi" runat="server" Text="Dodaj" OnClick="btnDodajUcesnikaPotvrdi_Click" CssClass="btn" />
                                <asp:Button ID="btnOdustani" runat="server" Text="Odustani" OnClick="btnOdustani_Click" CssClass="btn" />
                        </asp:Panel>

                    </div>

                    <div style="text-align:center; margin-top: 40px;">
                        <a href="Default.aspx" class="btn">🏠 Vrati se na početnu</a>
                    </div>


    </form>
</body>
</html>
