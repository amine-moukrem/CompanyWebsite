<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="gridviewpage.aspx.cs" Inherits="Pages_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:sqldatasource runat="server" ID="SQLDataSource" DataSourceMode="DataSet" ConnectionString="<%$ ConnectionStrings:SQLDbConnection %>" 
        SelectCommand="SELECT PersonId,FirstName,LastName,BirthDate,Username,Password FROM Person" >
    </asp:sqldatasource>

    <asp:gridview runat="server" ID="GridView" DataSourceId="SqlDataSource"></asp:gridview>
</asp:Content>

