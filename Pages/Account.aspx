<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Pages_MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
    connectionString ="<%$ ConnectionStrings: SQLDbConnection %>"
    SelectCommand="Select Person.PersonId, FirstName, LastName, BirthDate, Address1, AreaCode, NPA, NXX from IST411.Person, IST411.Address, IST411.Phone where IST411.Person.PersonId = IST411.Address.PersonId AND IST411.Address.PersonId= IST411.Phone.PersonId"
    DeleteCommand ="Delete from IST411.Person where PersonId = @PersonId"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="PastOrdersDataSource" runat="server"
    connectionString ="<%$ ConnectionStrings: SQLDbConnection %>"
    SelectCommand="Select [Order].OrderDate, total from IST411.[Order]"></asp:SqlDataSource>

    <br />
    <div class="elementToFadeInAndOut">
        <asp:label ID="LoggedInLabel" runat="server" text=""></asp:label>
    </div>

    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <br />
            <div class="left-space">
                Name:
                <asp:Label ID="FNameLabel" runat="server" Text='<%# String.Format("{0} {1}", Eval("FirstName"), Eval("LastName")) %>'></asp:Label>
                <br />
                Address:
                <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address1") %>'></asp:Label>
                <br />
                Phone Number:
                <asp:Label ID="AddressDataLabel" runat="server" Text='<%# String.Format("{0}-{1}-{2}", Eval("AreaCode"), Eval("NPA"), Eval("NXX")) %>'></asp:Label>
                <br />
            </div>
        </ItemTemplate>
    </asp:FormView>
    <div class="past-orders">
        <br />
        <h3><asp:Label ID="pastOrderLabel" runat="server" Text="Past orders" CssClass="left-space past-orders-label"></asp:Label></h3>
        <asp:GridView ID="PastOrdersGrid" CssClass="left-space past-orders-grid" DataKeyNames="Total" runat="server" EnableViewState="False">
        </asp:GridView>
    </div>
    <br />
    <div class="left-space">
        <asp:Button ID="LogoutBttn" runat="server" Text="Log Out" OnClick="LogoutBttn_Click"/>
    </div>
</asp:Content>