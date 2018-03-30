<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ProductPage.aspx.cs" Inherits="Pages_ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ProductScriptManager" runat="server"></asp:ScriptManager>
    
    <h3>
        <asp:Label runat="server" ID="ItemTitle"></asp:Label>
    </h3>
    
    <div class="productdiv" >
        
        <asp:UpdatePanel ID="MainImgUpdate" UpdateMode="conditional" runat="server">
            <ContentTemplate>
                <asp:Image ID="MainImage" Class="mainprodimage" runat="server"></asp:Image>
                <br />
                <asp:imagebutton ID="Thumbnail1" Class="thumbnailimages" runat="server" OnClick="ProductImage_OnClick"></asp:imagebutton>
                <asp:imagebutton ID="Thumbnail2" Class="thumbnailimages" runat="server" OnClick="ProductImage_OnClick"></asp:imagebutton>
                <asp:imagebutton ID="Thumbnail3" Class="thumbnailimages" runat="server" OnClick="ProductImage_OnClick"></asp:imagebutton>
                <asp:imagebutton ID="Thumbnail4" Class="thumbnailimages" runat="server" OnClick="ProductImage_OnClick"></asp:imagebutton>
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
        <asp:button CssClass="AddCartButton" runat="server" text="Add To Cart" />
        <asp:Label ID="ProdDescLabel" CssClass="ProductDescription" runat="server" AutoSize="true"></asp:Label>
    </div>
</asp:Content>

