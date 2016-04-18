<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_AddressControl.ascx.cs" Inherits="TravelAgency.WF.Account.AddressControl" %>
<hr />
<asp:HiddenField runat="server" ID="AddressId" />
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">Address</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="Address" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
            CssClass="text-danger" ErrorMessage="The address field is required." />
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="Country" CssClass="col-md-2 control-label">Country</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="Country" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Country" CssClass="text-danger" ErrorMessage="The country field is required." />
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="Region" CssClass="col-md-2 control-label">Region</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="Region" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Region" CssClass="text-danger" ErrorMessage="The region field is required." />
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="City" CssClass="col-md-2 control-label">City</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="City" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="City" CssClass="text-danger" ErrorMessage="The city field is required." />
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="ZipCode" CssClass="col-md-2 control-label">Zip Code</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="ZipCode" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="ZipCode" CssClass="text-danger" ErrorMessage="The zip code field is required." />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="ZipCode"
                    ValidationExpression="[\d-]+"
                    CssClass="text-danger" ErrorMessage="The Zip Code field is invalid." />
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="Phone" CssClass="col-md-2 control-label">Phone</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="Phone" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone" CssClass="text-danger" ErrorMessage="The phone field is required." />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="Phone"
                    ValidationExpression="[\d-]+"
                    CssClass="text-danger" ErrorMessage="The Phone field is invalid." />
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="Fax" CssClass="col-md-2 control-label">Fax</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="Fax" CssClass="form-control" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="Fax"
                    ValidationExpression="[\d-]+"
                    CssClass="text-danger" ErrorMessage="The Fax field is invalid." />
    </div>
</div>
