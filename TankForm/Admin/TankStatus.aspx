<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TankStatus.aspx.cs" Inherits="TankForm.TankStatus" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4 table-bordered">

            <asp:Chart ID="Chart3" runat="server" SelectMethod="GetTankVolum3" Width="300" Height="200">
                <Series>
                    <asp:Series Name="Series3" XValueMember="Drivstoff" YValueMembers="AktVolum">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea3">
                        <AxisY Maximum="10000" Minimum="0">
                        </AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:GridView ID="Tankst3" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
                ItemType="TankForm.Models.TankVolum" SelectMethod="GetTankVolum3"
                CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="Tanknummer" HeaderText="Tanknummer" SortExpression="Tanknummer" />
                    <asp:BoundField DataField="Drivstoff" HeaderText="Drivstoff" />
                    <asp:BoundField DataField="Kapasitet" HeaderText="Kapasitet" />
                    <asp:BoundField DataField="AktVolum" HeaderText="Aktuelt volum" />
                </Columns>
            </asp:GridView>

            <asp:Chart ID="Chart4" runat="server" SelectMethod="GetTankVolum4" Width="300" Height="200">
                <Series>
                    <asp:Series Name="Series4" XValueMember="Drivstoff" YValueMembers="AktVolum">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea4">
                        <AxisY Maximum="10000" Minimum="0">
                        </AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:GridView ID="Tankst4" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
                ItemType="TankForm.Models.TankVolum" SelectMethod="GetTankVolum4"
                CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="Tanknummer" HeaderText="Tanknummer" SortExpression="Tanknummer" />
                    <asp:BoundField DataField="Drivstoff" HeaderText="Drivstoff" />
                    <asp:BoundField DataField="Kapasitet" HeaderText="Kapasitet" />
                    <asp:BoundField DataField="AktVolum" HeaderText="Aktuelt volum" />
                </Columns>
            </asp:GridView>

            <asp:Chart ID="Chart7" runat="server" SelectMethod="GetTankVolum7" Width="300" Height="200">
                <Series>
                    <asp:Series Name="Series7" XValueMember="Drivstoff" YValueMembers="AktVolum">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea7">
                        <AxisY Maximum="100000" Minimum="0">
                        </AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:GridView ID="Tankst7" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
                ItemType="TankForm.Models.TankVolum" SelectMethod="GetTankVolum7"
                CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="Tanknummer" HeaderText="Tanknummer" SortExpression="Tanknummer" />
                    <asp:BoundField DataField="Drivstoff" HeaderText="Drivstoff" />
                    <asp:BoundField DataField="Kapasitet" HeaderText="Kapasitet" />
                    <asp:BoundField DataField="AktVolum" HeaderText="Aktuelt volum" />
                </Columns>
            </asp:GridView>
    </div>
</asp:Content>
