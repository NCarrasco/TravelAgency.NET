<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_LoginDataControl.ascx.cs" Inherits="TravelAgency.WF.Account._LoginDataControl" %>
<% if (IsEditMode)
   { %>
<asp:PlaceHolder Visible="true" runat="server" ID="EditPlaceHolder">
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
        <div class="col-md-10">
            <asp:Label runat="server" ID="EmailLabel" CssClass="col-md-2 control-label" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="OldPassword" CssClass="col-md-2 control-label">Old password</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="OldPassword" TextMode="Password" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">New password</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="ConfirmNewPassword" CssClass="col-md-2 control-label">Confirm new password</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
            <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
        </div>
    </div>
</asp:PlaceHolder>
<%}
   else
   { %>
<asp:PlaceHolder Visible="true" runat="server" ID="NormalPlaceholder">
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                CssClass="text-danger" ErrorMessage="The email field is required." />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                CssClass="text-danger" ErrorMessage="The password field is required." />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
        </div>
    </div>
</asp:PlaceHolder>
<% } %>