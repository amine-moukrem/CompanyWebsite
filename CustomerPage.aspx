<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerPage.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Customer Registration</h1>
    <div id="custformdiv" runat="server">
        <div>
            <asp:Label runat="server" Text="First Name:" ID="fnamelabel"></asp:Label>
            <asp:TextBox runat="server" ID="custFNameBox"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label runat="server" Text="Last Name:" ID="lnamelabel"></asp:Label>
            <asp:TextBox runat="server" ID="custLNameBox"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label runat="server" Text="Birthday:" ID="bdaylabel"></asp:Label>
            <input type="date" id="bdaybox"/>
        </div>
        <br />

        <div>
            <asp:Label runat="server" Text="Phone Number"></asp:Label>
            <asp:TextBox runat="server" placeholder="1234567890" ID="phoneBox"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label runat="server" Text="Address"></asp:Label>
            <asp:TextBox runat="server" ID="addressBox"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label runat="server" Text="Total # of Orders:"></asp:Label>
            <asp:TextBox runat="server" ID="numOrdersBox"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label runat="server" Text="First Order Date:"></asp:Label>
            <input type="date" name="fOrderDateBox" />
        </div>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Done" OnClick="DoneClick" />
    </div>
    <div id="custresults" runat="server">

        <asp:Label ID="FNameDisplay" runat="server" Text="Label"></asp:Label>

    </div>
</asp:Content>