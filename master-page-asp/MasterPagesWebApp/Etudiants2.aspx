<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etudiants2.aspx.cs" Inherits="MasterPagesWebApp.Etudiants2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body class="container">
    <form id="form1" runat="server">
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="Code" DataSourceID="SqlDbClasse">
            <EditItemTemplate>
                Code:
                <asp:Label ID="CodeLabel1" runat="server" Text='<%# Eval("Code") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Code:
                <asp:TextBox ID="CodeTextBox" runat="server" Text='<%# Bind("Code") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                Code:
                <asp:Label ID="CodeLabel" runat="server" Text='<%# Eval("Code") %>' />
                <br />

            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDbClasse" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Code] FROM [Classe]"></asp:SqlDataSource>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDBEtudiants" OnItemCommand="Repeater1_ItemCommand">
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDBEtudiants" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [numcarteetudiant], [Nom], [Prenom] FROM [Etudiant]"></asp:SqlDataSource>
    </form>
</body>
</html>