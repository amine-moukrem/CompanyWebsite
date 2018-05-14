<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ProductPage.aspx.cs" Inherits="Pages_ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ProductScriptManager" runat="server"></asp:ScriptManager>
    <script src="../jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div.hidden').fadeIn(500).removeClass('hidden');
            $('.slide').slideDown(500).removeClass('slide');
        });
        </script>
    <h3>
        <asp:Label runat="server" ID="ItemTitle"></asp:Label>
    </h3>
    
    <div class="productdiv" >
        <asp:UpdatePanel ID="MainImgUpdate" UpdateMode="conditional" runat="server">
            <ContentTemplate>
                <asp:Image ID="MainImage" CssClass="mainprodimage" runat="server"></asp:Image>
                <br />
                <asp:imagebutton ID="Thumbnail1" CssClass="thumbnailimages" runat="server" OnClick="ProductImage_OnClick"></asp:imagebutton>
                <asp:imagebutton ID="Thumbnail2" CssClass="thumbnailimages" runat="server" OnClick="ProductImage_OnClick"></asp:imagebutton>
                <asp:imagebutton ID="Thumbnail3" CssClass="thumbnailimages" runat="server" OnClick="ProductImage_OnClick"></asp:imagebutton>
                <asp:imagebutton ID="Thumbnail4" CssClass="thumbnailimages" runat="server" OnClick="ProductImage_OnClick"></asp:imagebutton>
   
            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Thumbnail1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Thumbnail2" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Thumbnail3" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Thumbnail4" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div class="ProductInfoDiv">
        <div class="hidden">
            <asp:button CssClass="AddCartButton" runat="server" text="Add To Cart" OnClick="AddToCart" />
        </div>
        <div class="slide">
            <asp:Label ID="ProdDescLabel" CssClass="ProductDescription" runat="server" ></asp:Label>
            <hr />
            <asp:Label ID="PriceLabel" CssClass="left-space" runat="server" Text="Price:">
            </asp:Label><asp:Label ID="ProdPriceLabel"  CssClass="product-price left-space" runat="server" ></asp:Label>
            <br />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="ProductAddedLabel" CssClass="green-text" runat="server" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>