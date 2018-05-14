<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Pages_Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Checkout</h2>
    <div id="maincheckoutdiv" class="checkout-div" runat="server">
        <div class="checkout-left column simple-border ">
            <div class="centered-h3"><h3>Payment Method</h3></div>
            Credit card
            <br />
            <asp:TextBox ID="creditCardBox" runat="server" CssClass="long-box" placeholder="xxxxxxxxxxxxxxxx" MaxLength="16"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="CardVal" ControlToValidate="creditCardBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            <br />
            <br />
            Expiration date&nbsp&nbsp&nbsp&nbsp Security code
            <br />
            <asp:TextBox ID="expirationBox" CssClass="expiration-box" runat="server" placeholder="MM/YY"></asp:TextBox>
            <asp:TextBox ID="codeBox" CssClass="code-box" runat="server" placeholder="123"></asp:TextBox>
            <br />
            <br />
            <asp:RequiredFieldValidator ID="ExpCodeVal" ControlToValidate="creditCardBox" runat="server" ErrorMessage="Expiration data required" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="SecurityCodeVal" ControlToValidate="codeBox" runat="server" ErrorMessage="Security code required" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <div id="cartDiv" class="checkout-right column simple-border " runat="server">
            <h3>Summary</h3>
            <asp:GridView ID="GridView1" CssClass="left-space cart-grid" DataKeyNames="Product" runat="server" EnableViewState="False" OnRowCommand="GridView1_RowCommand">
            </asp:GridView>
            <br />
            <asp:Label ID="cartTotalLabel" CssClass="left-space cart-total" runat="server" Text=""></asp:Label>
        </div>
        <div class="complete-checkout-bttn-div column simple-border ">
            <h3>Complete Purchase</h3>
            <asp:Label ID="itemTotal" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="taxTotal" runat="server" Text=""></asp:Label>
            <br />
            <hr />
            <asp:Label ID="finalTotal" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="PurchaseBttn" CssClass="purchase-bttn" runat="server" OnClick="PurchaseBttn_Click" Text="Place order" />
        </div>
    </div>
    <div id="postCheckout" class="postcheckout-msg left-space" runat="server">
        <asp:Label ID="postCheckoutMessage" runat="server" Text="Thank you for purchasing."></asp:Label>
    </div>
</asp:Content>