<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LittleThingsWebsite._Default" %>

<html>
    <body>
        <form id="form1" runat="server">
        <h1>Users</h1>
            <p>
                <asp:GridView ID="UserGridView" runat="server">
                </asp:GridView>
            </p>
            <h1>Habits</h1>
            <p>
                <asp:GridView ID="HabitGridView" runat="server">
                </asp:GridView>
            </p>
        </form>
          
    </body>
</html>