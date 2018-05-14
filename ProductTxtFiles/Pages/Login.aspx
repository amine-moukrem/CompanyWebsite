<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate"
    CreateUserText="Register" CreateUserUrl="CustomerPage.aspx" HelpPageText="Additional Help" HelpPageUrl="ContactUs.aspx" 
    InstructionText="Please enter your user name and password for login" >
    <TitleTextStyle BackColor="#6B698B" Font-Bold="true" ForeColor="#FFFFFF" />
    </asp:Login>
</asp:Content>

