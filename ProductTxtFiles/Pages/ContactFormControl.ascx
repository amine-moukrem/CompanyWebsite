<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactFormControl.ascx.cs" Inherits="Pages_WebUserControl" %>

<div class="contactusform" >
    <h1 id="contactheader">
        Contact Us
    </h1>
    <asp:Label ID="SuccessLabel" CssClass="SuccessLabel" runat="server" Text=""></asp:Label>
    <br />
    <br />

    <asp:TextBox runat="server" ID="FNameBox" CssClass="ContactUsTxtbox" placeholder="First name"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="FNameVal" ControlToValidate="CommentBox" runat="server" ErrorMessage="First name cannot be left empty" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox runat="server" ID="LNameBox" CssClass="ContactUsTxtbox" placeholder="Last name"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="LNameVal" ControlToValidate="CommentBox" runat="server" ErrorMessage="Last name cannot be left empty" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
    <br />

    <asp:TextBox runat="server" onblur="textBoxOnBlur(this)" ID="PhoneBox" MaxLength="10" CssClass="ContactUsTxtbox" placeholder="Phone number" ></asp:TextBox>
    <br />
    <asp:RegularExpressionValidator ID="PhoneNumVal" runat="server" ValidateEmptyText="true" ErrorMessage="Phone number not valid" Display="Dynamic" CssClass="ErrorMessage" ControlToValidate="PhoneBox" 
        ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="PhoneBoxVal" ControlToValidate="PhoneBox" runat="server" ErrorMessage="Phone number cannot be left empty" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
    <br />

    <asp:TextBox runat="server" ID="EmailBox" CssClass="ContactUsTxtbox" placeholder="Your email address"></asp:TextBox>
    <br />
    <asp:CustomValidator ID="EmailCustomVal" ControlToValidate="EmailBox" OnServerValidate="Email_ServerValidate" runat="server" 
        ValidateEmptyText="true" CssClass="ErrorMessage" ErrorMessage="Email not valid" Display="Dynamic" ></asp:CustomValidator>
    <asp:RequiredFieldValidator ID="EmailReqVal" ControlToValidate="EmailBox" runat="server" ErrorMessage="Email cannot be left empty" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
    <br />

    <asp:TextBox runat="server" ID="SubjectBox" CssClass="ContactUsTxtbox" placeholder="Your subject"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="SubjectVal" ControlToValidate="SubjectBox" runat="server" ErrorMessage="Subject cannot be left empty" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
    <br />
        
    <textarea id="CommentBox" runat="server" placeholder="Your Message..." class="usercommentbox" cols="20" rows="3"></textarea>
    <br />
    <asp:RequiredFieldValidator ID="CommentVal" ControlToValidate="CommentBox" runat="server" ErrorMessage="Comment cannot be left empty" CssClass="ErrorMessage" Display="Dynamic" ></asp:RequiredFieldValidator>
    
    <br />
    <asp:Label ID="AttachLabel" runat="server" Text="Attach File: "></asp:Label>
    <asp:FileUpload ID="FileUploadAttch" runat="server" />
    <br />

    <asp:Label ID="UploadStatus" runat="server" Text=""></asp:Label>
    <br />
    <br />

    <asp:CheckBox ID="SendMeChkBox" runat="server" Text="Send me a copy"/>
    <br />
    <br />

    <asp:Button ID="SubmitBttn" runat="server" Text="Submit" CssClass="submitBttn" OnClick="SubmitBttn_Click"/>
    <br />
    <br />
</div>