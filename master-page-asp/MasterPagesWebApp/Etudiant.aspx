<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etudiant.aspx.cs" Inherits="MasterPagesWebApp.Etudiant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body class="container">
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" class="table" runat="server" AutoGenerateColumns="False" DataKeyNames="numcarteetudiant" DataSourceID="SqlDSEtudiants" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="numcarteetudiant" HeaderText="N Carte d'étudiant" ReadOnly="True" SortExpression="numcarteetudiant" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
                <asp:BoundField DataField="Date_naissance" HeaderText="Date de Naissance" SortExpression="Date_naissance" />
                <asp:ImageField HeaderText="Photo" DataImageUrlField="Photo">
                    <ControlStyle Width="20px" />
                </asp:ImageField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDSEtudiants" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [numcarteetudiant], [Nom], [Prenom], [Date_naissance], [Photo] FROM [Etudiant]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
