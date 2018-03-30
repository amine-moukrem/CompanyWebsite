<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Pages_ContactUs" %>
<%@ Register Src="~/Pages/ContactFormControl.ascx" TagName="FormControl" TagPrefix="uc" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
            <!-- phonebox format onblur
            function textBoxOnBlur(phonebox)
            {
                var nums = phonebox.value.replace(/\D/g, ''),
                char = { 0: '(', 3: ') ', 6: '-' };
                phonebox.value = '';

                for (var i = 0; i < nums.length; i++) {
                    phonebox.value += (char[i] || '') + nums[i];
                }
            }
            // -->
        </script>
    <uc:FormControl runat="server" />
</asp:Content>

