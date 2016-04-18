<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TravelAgency.WF.Account.Register" %>

<%@ Register TagPrefix="travel" TagName="PersonControl" Src="~/Account/_PersonRegister.ascx" %>
<%@ Register TagPrefix="travel" TagName="FirmControl" Src="~/Account/_FirmRegister.ascx" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">

        <asp:DropDownList ID="UserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="UserType_SelectedIndexChanged">
            <asp:ListItem Value="">--Select--</asp:ListItem>
            <asp:ListItem Value="p">Person</asp:ListItem>
            <asp:ListItem Value="f">Firm</asp:ListItem>
        </asp:DropDownList>
        <asp:UpdatePanel runat="server" ID="UpdatePanel">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UserType" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:Panel ID="PersonPanel" runat="server" Visible="false">
                    <div>
                        <h2>Register Person</h2>
                        <travel:PersonControl runat="server" ID="PersonData" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="FirmPanel" runat="server" Visible="false">
                    <div>
                        <h2>Register Firm</h2>
                        <travel:FirmControl runat="server" ID="FirmData" />
                    </div>
                </asp:Panel>

                <asp:Panel runat="server" ID="ButtonPanel" Visible="false">
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
