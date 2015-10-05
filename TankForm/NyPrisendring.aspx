<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NyPrisendring.aspx.cs" Inherits="TankForm.NyPrisendring" %>



<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-4 table-bordered">
        <asp:Chart ID="Chart1" runat="server" SelectMethod="GetTankVolum">
            <Series>
                <asp:Series Name="Series1" XValueMember="Drivstoff" YValueMembers="AktVolum">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>



   <asp:GridView ID="TankenListe" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="TankForm.Models.TankVolum" SelectMethod="GetTankVolum"
        CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="Tanknummer" HeaderText="Tanknummer" SortExpression="Tanknummer" />
            <asp:BoundField DataField="Stasjons.Stasjonsnummer" HeaderText="Stasjon" />
            <asp:BoundField DataField="Drivstoff" HeaderText="Drivstoff" />
            <asp:BoundField DataField="Kapasitet" HeaderText="Kapasitet" />
            <asp:BoundField DataField="AktVolum" HeaderText="Aktuelt volum" />
            <asp:BoundField DataField="AktPris" HeaderText="Aktuell pris" />

            <asp:TemplateField HeaderText="Ny pris">
                <ItemTemplate>
                    <asp:TextBox ID="NyPris" Width="40" runat="server" Text="<%#: Item.NyPris %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PrisOppdatert" ShowHeader="False" ItemStyle-ForeColor="White" ItemStyle-BackColor="White" />
        </Columns>
    </asp:GridView>

    <table>
        <tr>
            <td>
                <asp:Button ID="UpdateBtn" runat="server" Text="Lagre nye priser" OnClick="UpdateBtn_Click" />
            </td>
        </tr>
    </table>


</asp:Content>
