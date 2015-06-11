<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="lesson5.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Detials</h1>
    <h5>All fields are required</h5>

    <fieldset>
        <label for="txtLastName" class="col-sm-2">LastName:</label>
        <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" ></asp:TextBox>
    </fieldset>
    <fieldset>
        <label for="txtfirstName" class="col-sm-2">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50"></asp:TextBox>
    </fieldset>
    <fieldset>
        <label for="txtEnrollmentDate" class="col-sm-2">Enrollment Date:</label>
        <asp:TextBox ID="txtEnrollmentDate" runat="server" MaxLength="50"></asp:TextBox>
    </fieldset>

    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
