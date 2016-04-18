<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_FirmRegister.ascx.cs" Inherits="TravelAgency.WF.Account._FirmRegister" %>

<%@ Register TagPrefix="travel" TagName="AddressControl" Src="~/Account/_AddressControl.ascx" %>
<%@ Register TagPrefix="travel" TagName="LoginDataControl" Src="~/Account/_LoginDataControl.ascx" %>

<travel:LoginDataControl ID="LoginData" runat="server" />
<hr />
<asp:HiddenField runat="server"  ID="ClientId"/>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Firm Name</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
            CssClass="text-danger" ErrorMessage="The name field is required." />
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="NIP" CssClass="col-md-2 control-label">NIP</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="NIP" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="NIP"
            CssClass="text-danger" ErrorMessage="The NIP field is required." />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="NIP"
            ValidationExpression="[\d-]+"
            CssClass="text-danger" ErrorMessage="The NIP field is invalid." />
    </div>
</div>

<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="REGON" CssClass="col-md-2 control-label">REGON</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="REGON" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="REGON"
            CssClass="text-danger" ErrorMessage="The REGON field is required." />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="REGON"
            ValidationExpression="[\d-]+"
            CssClass="text-danger" ErrorMessage="The REGON field is invalid." />
    </div>
</div>
<travel:AddressControl runat="server" ID="Address" />
