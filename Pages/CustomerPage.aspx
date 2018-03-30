<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerPage.aspx.cs" Inherits="CustomerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="formdiv" runat="server">
        <div id="custheader">
            <h1>Customer Registration</h1>
        </div>
        <div class="custtheme1">
            <asp:Label runat="server" Text="First Name:" ID="fnamelabel"></asp:Label>
            <asp:TextBox runat="server" ID="custFNameBox"></asp:TextBox>
        <br />
        <br />
            <asp:Label runat="server" Text="Last Name:" ID="lnamelabel"></asp:Label>
            <asp:TextBox runat="server" ID="custLNameBox"></asp:TextBox>
        <br />
        <br />
            <asp:Label runat="server" Text="Birthday:" ID="bdaylabel"></asp:Label>
            <input type="date" id="bdaybox" name="bdaybox" runat="server"/>
        <br />
        <br />
            <asp:Label runat="server" Text="Phone Number: "></asp:Label>
            <asp:TextBox runat="server" placeholder="1234567890" ID="phoneBox" MaxLength="10" ></asp:TextBox>
            
            <asp:Button ID="AddPNumButton" runat="server" Text="" CssClass="addbutton" OnClick="AddPhoneNumToListBox" />

            <asp:ListBox ID="phoneNumsListBox" runat="server"></asp:ListBox>
        <br />
        <br />

            <asp:Label runat="server" Text="Address: "></asp:Label>
            <asp:TextBox runat="server" ID="addressBox" ></asp:TextBox>
            
            <asp:Button ID="addAddressBttn" runat="server" Text="" CssClass="addbutton" OnClick="AddAddressToListBox" />

            <asp:ListBox ID="addressesListBox" runat="server"></asp:ListBox>
        <br />
        <br />
            <asp:Label runat="server" Text="Total # of Orders:"></asp:Label>
            <asp:TextBox runat="server" ID="numOrdersBox"></asp:TextBox>
        <br />
        <br />
            <asp:Label runat="server" Text="First Order Date:"></asp:Label>
            <input type="date" id="fOrderDateBox" runat="server" />
            <br />
            <br />
             <asp:Button ID="FinishCustFormBttn" runat="server" Text="Register" OnClick="DoneClickEmp" />
        </div>
    </div>

    <div id="custresults" runat="server" visible="false">
        <div class="resultmainlabelcust">
            <h1><asp:Label ID="ResultsHead" runat="server" text="Your Info"></asp:Label></h1>
        </div>
        <div class="resultsdisplay"><asp:Label ID="FNameDisplay" runat="server" Text="Name: "></asp:Label>
            <asp:label runat="server" text="" ID="fnameDisplayLabel"></asp:label> <asp:label runat="server" text="" ID="lnameDisplayLabel"></asp:label>
        </div>
        <br />
        
        <div class="resultsdisplay"><asp:Label ID="DateOfBirth" runat="server" Text="Date of Birth: "></asp:Label>
            <asp:label runat="server" text="" ID="dobDisplay"></asp:label>
        </div>
        <br />

        <div class="resultsdisplay"><asp:Label ID="PhoneNumbers" runat="server" Text="Phone Numbers: "></asp:Label>
            <asp:label runat="server" text="" ID="DisplayPNums"></asp:label>
        </div>
        <br />

        <div class="resultsdisplay"><asp:Label ID="Addresses" runat="server" Text="Addresses: "></asp:Label>
            <asp:label runat="server" text="" ID="DisplayAddresses"></asp:label>
        </div>
        <br />
        
        <div class="resultsdisplay"><asp:Label ID="NumOrdersLabel" runat="server" Text="# of Orders: "></asp:Label>
            <asp:label runat="server" text="" ID="NumOrdersDisplay"></asp:label>
        </div>
        <br />

        <div class="resultsdisplay"><asp:Label ID="FirstOrderLabel" runat="server" Text="First Order Date: "></asp:Label>
            <asp:label runat="server" text="" ID="FOrderDisplay"></asp:label>
        </div>
        <br />
    </div>
</asp:Content>