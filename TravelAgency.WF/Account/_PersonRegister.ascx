<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_PersonRegister.ascx.cs" Inherits="TravelAgency.WF.Account._PersonRegister" %>

<%@ Register TagPrefix="travel" TagName="AddressControl" Src="~/Account/_AddressControl.ascx" %>
<%@ Register TagPrefix="travel" TagName="LoginDataControl" Src="~/Account/_LoginDataControl.ascx" %>

<travel:LoginDataControl ID="LoginData" runat="server" />

<hr />
<asp:HiddenField runat="server"  ID="ClientId"/>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
            CssClass="text-danger" ErrorMessage="The first name field is required." />
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="Surname" CssClass="col-md-2 control-label">Surname</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="Surname" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Surname"
            CssClass="text-danger" ErrorMessage="The surname field is required." />
    </div>
</div>

<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="Surname" CssClass="col-md-2 control-label">NIP</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="NIP" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="NIP"
            CssClass="text-danger" ErrorMessage="The NIP field is required." />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="NIP"
            ValidationExpression="[\d-]+"
            CssClass="text-danger" ErrorMessage="The NIP field is invalid." />
    </div>
</div>

<travel:AddressControl runat="server" ID="Address" />
