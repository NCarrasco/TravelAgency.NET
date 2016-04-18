<%@ Page Title="Offer History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfferHistory.aspx.cs" Inherits="TravelAgency.WF.OfferHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>List of Past Offers</h2>
    <asp:ObjectDataSource ID="OfferHistoryObjectDataSource" runat="server" SelectMethod="GetOfferHistory" TypeName="TravelAgency.BLL.BLL.TravelAgencyService"
        OnSelecting="OfferHistoryObjectDataSource_Selecting">
        <SelectParameters>
            <asp:Parameter Name="userId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridViewOfferHistory" runat="server" AutoGenerateColumns="False" 
        DataSourceID="OfferHistoryObjectDataSource"
        DataKeyNames="IDOferty"
        OnRowDataBound="OfferHistoryGridView_RowDataBound" CssClass="dataTable">
        <Columns>
            <asp:TemplateField HeaderText="Country Name" SortExpression="tHistoriaOfert.tPanstwa.NazwaPanstwa">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("tHistoriaOfert.tPanstwa.NazwaPanstwa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Day Count" SortExpression="tHistoriaOfert.LiczbaDniTrwania">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("tHistoriaOfert.LiczbaDniTrwania") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City" SortExpression="tHistoriaOfert.Miasto">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("tHistoriaOfert.Miasto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="tHistoriaOfert.mCena">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("tHistoriaOfert.mCena") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Departure Date" SortExpression="tHistoriaOfert.DataWyjazdu">
                <ItemTemplate>
                    <asp:Label ID="lblDepartureDate" runat="server" Text='<%# Eval("tHistoriaOfert.DataWyjazdu") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Person Count" SortExpression="tHistoriaOfert.iLiczbaOsob">
                <ItemTemplate>
                    <asp:Label ID="lblPersonCount" runat="server" Text='<%# Eval("tHistoriaOfert.iLiczbaOsob") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ZaplaconaKwota" HeaderText="Payed Amount" SortExpression="ZaplaconaKwota" />
            <asp:TemplateField HeaderText="Details">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDetails" runat="server" Text='Details' OnClick="btnDetails_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
