<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ProductLanding.aspx.cs" Inherits="Pages_ProductLanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="ProductLanding">
        <h2><asp:Label ID="ProductLandingTitle" runat="server" Text="Products"></asp:Label></h2>
        <asp:ImageButton ID="Product1" Class="ProductLandingImages" PostBackUrl="~/Pages/ProductPage.aspx?Product=1001" runat="server" />
        <asp:ImageButton ID="Product2" Class="ProductLandingImages" PostBackUrl="~/Pages/ProductPage.aspx?Product=1002" runat="server" />
        <asp:ImageButton ID="Product3" Class="ProductLandingImages" PostBackUrl="~/Pages/ProductPage.aspx?Product=1003" runat="server" />
     </div>
</asp:Content>