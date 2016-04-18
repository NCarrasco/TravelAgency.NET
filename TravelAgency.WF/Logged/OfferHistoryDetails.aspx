<%@ Page Title="Offer History Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfferHistoryDetails.aspx.cs" Inherits="TravelAgency.WF.Logged.OfferHistoryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Offer History</h2>
    <asp:ObjectDataSource ID="OfferHistoryDetailsDataSource" runat="server" SelectMethod="GetOfferHistory" TypeName="TravelAgency.BLL.BLL.TravelAgencyService"
        OnSelecting="OfferHistoryDetailsDataSource_Selecting">
        <SelectParameters>
            <asp:Parameter Name="userId" Type="Int32" />
            <asp:QueryStringParameter Name="offerId" QueryStringField="oid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
        DataSourceID="OfferHistoryDetailsDataSource" CssClass="details-data">
        <Fields>
            <asp:TemplateField HeaderText="Country Name" SortExpression="tHistoriaOfert.tPanstwa.NazwaPanstwa">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("tHistoriaOfert.tPanstwa.NazwaPanstwa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Price" SortExpression="tHistoriaOfert.mCena">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("tHistoriaOfert.mCena") %>' />
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
            <asp:TemplateField HeaderText="Description" SortExpression="tHistoriaOfert.Opis">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("tHistoriaOfert.Opis") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DataZaplaty" HeaderText="Payment Date" SortExpression="DataZaplaty" />
            <asp:BoundField DataField="ZaplaconaKwota" HeaderText="Payed Amount" SortExpression="ZaplaconaKwota" />
            <asp:BoundField DataField="SposobZaplatyText" HeaderText="Paymnet Mannger" ReadOnly="True" SortExpression="SposobZaplatyText" />
            
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Person First Name" SortExpression="tOsoby.Imie">
                <ItemTemplate>
                    <asp:Label ID="lblFistName" runat="server" Text='<%# Eval("tOsoby.Imie") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Person Surname" SortExpression="tOsoby.Nazwisko">
                <ItemTemplate>
                    <asp:Label ID="lblSurname" runat="server" Text='<%# Eval("tOsoby.Nazwisko") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>


    <asp:ObjectDataSource ID="AttractionHistoryObjectDataSource" runat="server" SelectMethod="GetAttractionHistoryList"
        TypeName="TravelAgency.BLL.BLL.TravelAgencyService"
        OnSelecting="AttractionHistoryObjectDataSource_Selecting">
        <SelectParameters>
            <asp:Parameter Name="userId" Type="Int32" />
            <asp:QueryStringParameter Name="offerId" QueryStringField="oid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Panel runat="server" ID="AttractionPanel">
        <h3>Related Attractions</h3>
        <asp:GridView ID="GridViewAttractionHistory" runat="server" AutoGenerateColumns="False" DataSourceID="AttractionHistoryObjectDataSource"
            OnRowDataBound="GridViewAttractionHistory_RowDataBound"
            DataKeyNames="IDAtrakcjiUslugi" CssClass="dataTable">
            <Columns>
                <asp:TemplateField HeaderText="Attraction Name" SortExpression="tAtrakcjeHistoria.Nazwa">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("tAtrakcjeHistoria.Nazwa") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="tAtrakcjeHistoria.mCena">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("tAtrakcjeHistoria.mCena") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Person Count" SortExpression="tAtrakcjeHistoria.iLiczbaOsob">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonCount" runat="server" Text='<%# Eval("tAtrakcjeHistoria.iLiczbaOsob") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DataZaplaty" HeaderText="Payment Date" SortExpression="DataZaplaty" />
                <asp:BoundField DataField="ZaplaconaKwota" HeaderText="Payed Amount" SortExpression="ZaplaconaKwota" />
                <asp:TemplateField HeaderText="Person Count" SortExpression="tAtrakcjeHistoria.iLiczbaOsob">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDetails" runat="server" Text='Details' OnClick="btnDetails_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
