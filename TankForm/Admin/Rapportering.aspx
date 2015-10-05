<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rapportering.aspx.cs" Inherits="TankForm.Rapportering" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       

    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Font-Names="Verdana" Font-Size="8pt" SizeToReportContent="true" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <ServerReport ReportPath="/AzureReport1/Dagsrapport" ReportServerUrl="http://pgazuresql.cloudapp.net/Reportserver" />
            <LocalReport>
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="TankForm.TankFormDataSetTableAdapters.PrisLoggsTableAdapter"></asp:ObjectDataSource>
    </div>



</asp:Content>
