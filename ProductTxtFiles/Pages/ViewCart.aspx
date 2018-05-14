<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="Pages_ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../jquery-3.3.1.min.js"></script>
    <h2>Your Cart</h2>
    <div id="cartDiv" runat="server">
        <asp:GridView ID="GridView1" CssClass="left-space cart-grid" DataKeyNames="Product" runat="server" EnableViewState="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="RemoveProduct" Text="Remove" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="cartTotalLabel" CssClass="left-space cart-total" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="left-space checkout" ID="CheckoutBttn" runat="server" OnClick="checkoutBttn_Click" Text="Checkout" />
    </div>
</asp:Content>