<%@ Page Title="Offers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Offers.aspx.cs" Inherits="TravelAgency.WF.Offers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List of Offers</h2>
    <section id="search-form">
        <h4>Filtering options</h4>
        <div class="form-horizontal">
            <table class="serach-table">
                <tr>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="How many rows to display on this page" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:DropDownList
                                    AutoPostBack="true"
                                    ID="rowsToDisplay"
                                    runat="server"
                                    OnSelectedIndexChanged="rowsToDisplay_SelectedIndexChanged"
                                    CssClass="form-control">
                                    <asp:ListItem Value="5"></asp:ListItem>
                                    <asp:ListItem Value="10" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="20"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="Departure start date" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:TextBox runat="server" ID="txtDepartureStart" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator
                                    ID="CompareValidator1" runat="server"
                                    Display="Dynamic"
                                    Type="Date"
                                    Operator="DataTypeCheck"
                                    ControlToValidate="txtDepartureStart"
                                    ErrorMessage="Please enter a valid date.">
                                </asp:CompareValidator>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="Departure end date" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:TextBox runat="server" ID="txtDepartureEnd" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator
                                    ID="dateValidator" runat="server"
                                    Display="Dynamic"
                                    Type="Date"
                                    Operator="DataTypeCheck"
                                    ControlToValidate="txtDepartureEnd"
                                    ErrorMessage="Please enter a valid date.">
                                </asp:CompareValidator>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="Min. day count of stay" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:TextBox runat="server" ID="txtMinDayCount" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                <asp:RangeValidator runat="server" Type="Integer"
                                    Display="Dynamic"
                                    MinimumValue="0" MaximumValue="100" ControlToValidate="txtMinDayCount"
                                    ErrorMessage="Value must be an integer number between 0 and 100" />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="Max. day count of stay" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:TextBox runat="server" ID="txtMaxDayCount" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                <asp:RangeValidator runat="server" Type="Integer"
                                    Display="Dynamic"
                                    MinimumValue="0" MaximumValue="100" ControlToValidate="txtMaxDayCount"
                                    ErrorMessage="Value must be an integer number between 0 and 100" />
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="Min. price" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:TextBox runat="server" ID="txtMinPrice" TextMode="Number" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="Max. price" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:TextBox runat="server" ID="txtMaxPrice" TextMode="Number" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="City" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:TextBox runat="server" ID="txtCity" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group form-group-search">
                            <asp:Label runat="server" Text="Country" CssClass="col-md-search control-label"></asp:Label>
                            <div class="col-md-search">
                                <asp:TextBox runat="server" ID="txtCountry" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="form-group form-group-search">
                <div class="col-md-offset-2 col-md-10">
                    <asp:ValidationSummary runat="server" />
                </div>
            </div>
            <div class="form-group form-group-search">
                <div class="col-md-offset-1 col-md-10 col-md-search-btn">
                    <asp:Button runat="server" Text="Filter" ID="btnFilter" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </section>
    <asp:ObjectDataSource ID="OffersObjectDataSource" runat="server"
        TypeName="TravelAgency.BLL.BLL.TravelAgencyService"
        SelectCountMethod="GetOfferCount"
        EnablePaging="true"
        SelectMethod="GetSubsetOfOffers"
        MaximumRowsParameterName="maxRows"
        StartRowIndexParameterName="startRows">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtDepartureStart" Type="DateTime" Name="minDepartureDate" />
            <asp:ControlParameter ControlID="txtDepartureEnd" Type="DateTime" Name="maxDepartureDate" />
            <asp:ControlParameter ControlID="txtMinPrice" Type="Decimal" Name="minPrice" />
            <asp:ControlParameter ControlID="txtMaxPrice" Type="Decimal" Name="maxPrice" />
            <asp:ControlParameter ControlID="txtMinDayCount" Type="Int32" Name="minStayTimeInDays" DefaultValue="0" />
            <asp:ControlParameter ControlID="txtMaxDayCount" Type="Int32" Name="maxStayTimeInDays" DefaultValue="0" />
            <asp:ControlParameter ControlID="txtCity" Type="String" Name="city" DefaultValue="" />
            <asp:ControlParameter ControlID="txtCountry" Type="String" Name="country" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <p>
        <asp:GridView ID="OffersGridView" runat="server" AutoGenerateColumns="False" DataSourceID="OffersObjectDataSource"
            DataKeyNames="IDOferty" AllowPaging="True" OnRowDataBound="OffersGridView_RowDataBound" CssClass="dataTable" 
            PagerStyle-CssClass="pager">
            <Columns>
                <asp:BoundField DataField="mCena" HeaderText="Price" SortExpression="mCena" />
                <asp:BoundField DataField="Miasto" HeaderText="City" SortExpression="Miasto" />
                <asp:BoundField DataField="MiejsceWyjazdu" HeaderText="Departure Place" SortExpression="MiejsceWyjazdu" />
                <asp:BoundField DataField="LiczbaDniTrwania" HeaderText="Days" SortExpression="LiczbaDniTrwania" />
                <asp:BoundField DataField="DataWyjazdu" HeaderText="Departure Date" SortExpression="DataWyjazdu" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Country" SortExpression="tPanstwa.NazwaPanstwa">
                    <ItemTemplate>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("tPanstwa.NazwaPanstwa") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Details">
                    <ItemTemplate>
                        <asp:LinkButton ID="DetailsLink" runat="server" Text='Details'
                            OnClick="DetailsLink_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
