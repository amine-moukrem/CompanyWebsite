<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerPage.aspx.cs" Inherits="CustomerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="formdiv" runat="server">
        <div id="custheader">
            <h1>Customer Registration</h1>
        </div>
        <div class="custtheme1">
            <div class="left-div">
                <asp:Label runat="server" Text="First Name*:" ID="fnamelabel"></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="custFNameBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FNameVal" ControlToValidate="custFNameBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
        <br />
        <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Last Name*:" ID="lnamelabel"></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="custLNameBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="LNameVal" ControlToValidate="custLNameBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
        <br />
        <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Birthday*:" ID="bdaylabel"></asp:Label>
            </div>
            <div class="right-div">
                <input type="date" id="bdaybox" name="bdaybox" runat="server"/>
                <asp:RequiredFieldValidator ID="BdayVal" ControlToValidate="bdaybox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
        <br />
        <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Phone Number: "></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" CssClass="align-top" placeholder="1234567890" ID="phoneBox" MaxLength="10" ></asp:TextBox>
                <asp:Button ID="AddPNumButton" runat="server" Text="" CssClass="addbutton align-top" OnClick="AddPhoneNumToListBox" />
                <asp:ListBox ID="phoneNumsListBox" runat="server"></asp:ListBox>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Street Address*: "></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="StreetAddressBox" ></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="City*: "></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="CityBox" ></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="State*: "></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="StateBox" ></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Zip Code*: "></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="ZipBox" ></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Add Address: "></asp:Label>
            </div>
            <div class="right-div">
                <asp:Button ID="addAddressBttn" runat="server" Text="" CssClass="addbutton align-top" OnClick="AddAddressToListBox" />
                <asp:ListBox ID="addressesListBox" runat="server"></asp:ListBox>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Total # of Orders*:"></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="numOrdersBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NumOrdersVal" ControlToValidate="numOrdersBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="First Order Date*:"></asp:Label>
            </div>
            <div class="right-div">
                <input type="date" id="fOrderDateBox" runat="server" />
                <asp:RequiredFieldValidator ID="FOrderDateVal" ControlToValidate="fOrderDateBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Button ID="FinishCustFormBttn" CssClass="bottom-margin" runat="server" Text="Register" OnClick="DoneClickEmp" />
            </div>
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