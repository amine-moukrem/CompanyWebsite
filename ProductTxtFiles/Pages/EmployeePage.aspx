<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeePage.aspx.cs" Inherits="EmployeePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="formdiv" runat="server">
        <div id="empheader">
            <h1>Employee Registration</h1>
        </div>
        <div class="emptheme1">
            <div class="left-div">
                <asp:Label runat="server" Text="First Name*:" ID="fnamelabel"></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="empFNameBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="empFNameVal" ControlToValidate="empFNameBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Last Name*:" ID="lnamelabel"></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="empLNameBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="empLNameVal" ControlToValidate="empLNameBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
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
                <asp:TextBox runat="server" CssClass="align-top" placeholder="1234567890" ID="empPhoneBox" MaxLength="10" ></asp:TextBox>
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
                <asp:Label runat="server" Text="Employee #*:"></asp:Label>
            </div>
            <div class="right-div">
                <asp:TextBox runat="server" ID="empNumBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="empNumVal" ControlToValidate="empNumBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Label runat="server" Text="Hire Date*:"></asp:Label>
            </div>
            <div class="right-div">
                <input type="date" id="hireDateBox" runat="server" />
                <asp:RequiredFieldValidator ID="hireDateBoxVal" ControlToValidate="hireDateBox" runat="server" ErrorMessage="Required field" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="left-div">
                <asp:Button ID="FinishCustFormBttn" runat="server" Text="Register" OnClick="DoneClick" />
            </div>
        </div>
    </div>

    <div id="empresults" runat="server" visible="False">
        <div class="resultmainlabelemp">
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
        
        <div class="resultsdisplay"><asp:Label ID="EmpNumLabel" runat="server" Text="Employee #: "></asp:Label>
            <asp:label runat="server" text="" ID="EmpNumDisplay"></asp:label>
        </div>
        <br />

        <div class="resultsdisplay"><asp:Label ID="HireDateLabel" runat="server" Text="Hire Date: "></asp:Label>
            <asp:label runat="server" text="" ID="HireDateDisplay"></asp:label>
        </div>
        <br />
    </div>
</asp:Content>

