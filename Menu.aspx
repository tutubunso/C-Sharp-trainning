<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="~/Personne.aspx" Text="Gestion des personnes" Value="Gestion des personnes">
                    <asp:MenuItem NavigateUrl="~/Utilisateurs.aspx" Text="Utilisateur" Value="Utilisateur"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Medecin.aspx" Text="Medecins" Value="Medecins"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Patient.aspx" Text="Patients" Value="Patients"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
    </form>
</body>
</html>
