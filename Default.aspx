<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdversaryArchiveWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#B5C7DE" />
            <DynamicSelectedStyle BackColor="#507CD1" />
            <Items>
                <asp:MenuItem NavigateUrl="~/" Text="Home" Value="Home"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/StatDisplay.aspx" Text="Stat Display" Value="Stat Display"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/addNPC.aspx" Text="Add NPC" Value="Add NPC"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/addStats.aspx" Text="Add Statblock" Value="Add Statblock"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/addInventory.aspx" Text="Add Inventory Item" Value="Add Inventory Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/linkStats.aspx" Text="Link Stats" Value="Link Stats"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#507CD1" />
        </asp:Menu>
    </div>

    </asp:Content>
