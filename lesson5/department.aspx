<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="lesson5.department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Department Detials</h1>
    <h5>All fields are required&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h5>

    <fieldset>
        <label for="txtDepartmentName" class="col-sm-2">Department Name:</label>
        <asp:TextBox ID="txtDepartmentName" runat="server" MaxLength="50"></asp:TextBox>
    </fieldset>
    <br />
    <fieldset>
        <label for="txtBudget" class="col-sm-2">Budget:</label>
        <asp:TextBox ID="txtBudget" runat="server" MaxLength="50"></asp:TextBox>
    </fieldset>

    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
