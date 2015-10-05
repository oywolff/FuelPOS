<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tanken.aspx.cs" Inherits="TankForm.Tanken" %>

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

        <!--
         DataSourceID="SqlDataSource1"
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TankForm %>" SelectCommand="SELECT [Tanknummer], [Drivstoff], [Kapasitet], [AktVolum] FROM [TankVolums]"></asp:SqlDataSource>
-->

    </div>
    <asp:Label ID="testlabel" Visible="true" Style="font-size: large; font-style: normal" runat="server"></asp:Label>

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
            <asp:BoundField DataField="ID" ShowHeader="False" ItemStyle-ForeColor="White" ItemStyle-BackColor="White" />
        </Columns>
    </asp:GridView>

    <!--            
                <asp:TemplateField HeaderText="Remove Item">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server" Checked=True></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            -->

    <script type="text/javascript">
        //ask for user input and then create file
        function CreateFile() {
            //get filename from the user
            var fileName = prompt('Type the name of the file you want to create:', '');
            //if the user clicks on OK and if they have entered something
            if ((fileName) && (fileName != "")) {
                //save the filename to the hidden form field 'funcParam'
                document.getElementById('funcParam').innerHTML = fileName;
                //call the postback function with the right ID
                __doPostBack('CreateFile', '');
            }
        }
    </script>

    <script runat="server">

    
        void Page_PreRender(object sender, EventArgs e)
        {

            ViewState["Oppdatering"] = "start";
            if (Master.Oppdatering == "Oppdatert") ViewState["Oppdatering"] = "Nystasjon";
            if (Master.Oppdatering != "Oppdatert") ViewState["Oppdatering"] = "Prisendring";

            string Test = ViewState["Oppdatering"].ToString();
            if (Test == "Nystasjon")
            {
                TankenListe.DataBind();
                Master.Oppdatering = "";
            }


            decimal nypris;
            string s;
            int tn;
            // Nødvendig ved flere tanker men hindrer nypris i å fungere...            
            //   TankenListe.DataBind();

            using (var _db = new TankForm.Models.ProduktContext())
            {

                for (int i = 0; i < TankenListe.Rows.Count; i++)
                {
                    TextBox prisTextBox = new TextBox();
                    prisTextBox = (TextBox)TankenListe.Rows[i].FindControl("NyPris");
                    nypris = Convert.ToDecimal(prisTextBox.Text.ToString());
                    tn = Convert.ToInt32(TankenListe.Rows[i].Cells[0].Text);
                    s = TankenListe.Rows[i].Cells[7].Text;

                    if ((float)nypris > 0)
                    {
                        prisTextBox.BackColor = System.Drawing.Color.Yellow;
                        prisTextBox.ForeColor = System.Drawing.Color.Black;
                    }
                    if (s == "True")
                    {
                        prisTextBox.BackColor = System.Drawing.Color.Green;
                        prisTextBox.ForeColor = System.Drawing.Color.Black;
                    }

                    if ((float)nypris < 0)
                    {
                        TankenListe.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Red;
                    }
                    if ((float)nypris == 0.0)
                        TankenListe.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Black;
                }
            }
            
        }
    </script>



    <table>
        <tr>
            <td>
                <asp:LinkButton ID="CreateFile" runat="server" OnClick="CreateFile_Click" />
                <asp:Label runat="server" ID="funcParam" ClientIDMode="Static">    </asp:Label>

                <asp:Button ID="UpdateBtn" runat="server" Text="Lagre nye priser" OnClick="UpdateBtn_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
