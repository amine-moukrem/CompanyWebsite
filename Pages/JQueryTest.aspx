<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JQueryTest.aspx.cs" Inherits="Pages_JQueryTest" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
<script src="../jquery-3.3.1.min.js"></script>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Hide" runat="server" Text="Hide" OnClientClick="return false"/>
        <asp:Button ID="Show" runat="server" Text="Show" OnClientClick="return false"/>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#Hide").click(function () {
                $("#Label1").toggle(2000);
            });
        });
        </script>
    </form>
</body>
</html>
