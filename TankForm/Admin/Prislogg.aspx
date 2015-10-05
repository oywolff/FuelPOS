<%@ Page Title="Prishistorikk" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prislogg.aspx.cs" Inherits="TankForm.Prislogg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <p class="lead">Tanken AS, Tanken Svilandsgate </p>
    <asp:GridView ID="PrisLogg" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="TankForm.Models.PrisLogg" SelectMethod="GetPrisLogg"
        CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Endring" SortExpression="ID" />
            <asp:BoundField DataField="Produktnr" HeaderText="Produktnr" />
            <asp:BoundField DataField="Dato" HeaderText="Dato" />
            <asp:BoundField DataField="NyPris" HeaderText="Ny pris" />
        </Columns>
    </asp:GridView>
</asp:Content>
