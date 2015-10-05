<%@ Page Title="Produktdetaljer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProduktDetaljer.aspx.cs" Inherits="TankForm.ProduktDetaljer" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="produktDetaljer" runat="server" ItemType="TankForm.Models.Produkt" SelectMethod ="GetProdukter" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.Beskrivelse%></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.ImagePath %>" style="border:solid; height:300px" alt="<%#:Item.Beskrivelse %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Beskrivelse:</b><br /><%#:Item.Beskrivelse %>
                        <br />
                        <span><b>Pris:</b>&nbsp;<%#:Item.Pris %></span>
                        <br />
                        <span><b>Produktnummer:</b>&nbsp;<%#:Item.Produktnr %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>