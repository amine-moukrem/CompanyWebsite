<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="welcomepg">
        <h1>Welcome!</h1>

        <p class="intro">This site allows you to complete registration for customers and employees.</p>
        <p class="intro">Navigate to either the <a href="CustomerPage.aspx">Customer Page</a> or the <a href="EmployeePage.aspx">Employee Page</a> to register.</p>
    </div>
</asp:Content>