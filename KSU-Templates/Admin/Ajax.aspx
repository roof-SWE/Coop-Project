<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="KSU_Templates.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">

<head>

    <title></title>

</head>           

<body>
   <div>
       <br /><br /><br /><br /><br /><br />
    <form id="form1">

    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

   

   <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

            <asp:DropDownList ID="DDLAjax" runat="server" Height="30px" Width="117px">

            </asp:DropDownList>

            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Show"

                Width="95px" />

            <br />

            <asp:GridView ID="GridView1" runat="server">

            </asp:GridView>

        </ContentTemplate>

    </asp:UpdatePanel>

    </form>

</div>
</body>

</html>
</asp:Content>
