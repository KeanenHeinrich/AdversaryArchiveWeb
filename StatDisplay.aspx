<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatDisplay.aspx.cs" Inherits="AdversaryArchiveWeb.StatDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 62%;
            height: 793px;
        }
        .auto-style2 {
            width: 128px;
        }
        .auto-style3 {
            width: 95px;
        }
        .auto-style4 {
            width: 128px;
            height: 23px;
        }
        .auto-style6 {
            width: 95px;
            height: 23px;
        }
        .auto-style7 {
            width: 128px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
            width: 209px;
        }
        .auto-style9 {
            width: 95px;
            height: 26px;
        }
        .auto-style11 {
            width: 128px;
            height: 84px;
        }
        .auto-style12 {
            height: 84px;
            width: 209px;
        }
        .auto-style14 {
            width: 128px;
            height: 30px;
        }
        .auto-style15 {
            height: 30px;
            width: 209px;
        }
        .auto-style16 {
            width: 95px;
            height: 30px;
        }
        .auto-style17 {
            margin-left: 23px;
        }
        .auto-style18 {
            width: 209px;
        }
        .auto-style19 {
            height: 23px;
            width: 209px;
        }
        </style>
</head>
    <body>
    <form id="form1" runat="server">
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

        <br />

        <table ID="NPCTABLE" class="auto-style1" style="border-style: solid; border-width: 3px; font-size: 14px;">
            <tr>
                <td class="auto-style2">
        <asp:DropDownList ID="handleList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="handleList_SelectedIndexChanged">
        </asp:DropDownList>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="txtRank" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">HP:<asp:TextBox ID="txtHP" runat="server" Width="25px" OnTextChanged="txtHP_TextChanged" AutoPostBack="True"></asp:TextBox>
                    <asp:TextBox ID="txtHPTotal" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style2">Damage Taken:
                    <asp:TextBox ID="txtDamage" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style18">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Body" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Head" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">SP Head:<asp:TextBox ID="txtSPHead" runat="server" Width="25px"></asp:TextBox>
                &nbsp;/
                    <asp:TextBox ID="txtSPHeadTotal" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style2">SP Body:<asp:TextBox ID="txtSPBody" runat="server" Width="25px"></asp:TextBox>
                    /
                    <asp:TextBox ID="txtSPBodyTotal" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Initiative:
                    <asp:TextBox ID="txtInitiative" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style2">Facedown:
                    <asp:TextBox ID="txtFacedown" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Role:
                    <asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4"></td>
                <td class="auto-style19"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">MOVE
                    <asp:TextBox ID="txtMOVE" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style2">BODY
                    <asp:TextBox ID="txtBODY" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style18">EMP
                    <asp:TextBox ID="txtEMP" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style3">LUCK
                    <asp:TextBox ID="txtLUCK" runat="server" Width="25px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Combat Skills:</td>
                <td class="auto-style4"></td>
                <td class="auto-style19"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Melee:
                    <asp:TextBox ID="txtCombat1" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    Ranged:
                    <asp:TextBox ID="txtCombat2" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="txtCombat3Label" runat="server"></asp:Label>
&nbsp;<asp:TextBox ID="txtCombat3" runat="server" Width="25px" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="txtCombat4Label" runat="server"></asp:Label>
&nbsp;<asp:TextBox ID="txtCombat4" runat="server" Width="25px" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Defensive Skills:</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    Brawling:
                    <asp:TextBox ID="txtDefensive1" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    Evasion:
                    <asp:TextBox ID="txtDefensive2" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    Resist T/D:
                    <asp:TextBox ID="txtDefensive3" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    Concentration:
                    <asp:TextBox ID="txtDefensive4" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Utility:</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Perception:
                    <asp:TextBox ID="txtUtility1" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    Stealth:
                    <asp:TextBox ID="txtUtility2" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">
                    Social:
                    <asp:TextBox ID="txtUtility3" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style14">
                    Insight:
                    <asp:TextBox ID="txtUtility4" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="auto-style15"></td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style19"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style2">Weapons:</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11" rowspan="1" style="vertical-align: top">
                    <asp:Label ID="txtWeapon1" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px" Visible="False" Width="185px"></asp:Label>
                    <br />
                    <asp:Label ID="txtWeapon11" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px" Visible="False" Width="185px"></asp:Label>
                    <br />
                    <asp:Label ID="txtWeapon12" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="185px" Visible="False" BackColor="White"></asp:Label>
                    <br />
                </td>
                <td class="auto-style11" style="vertical-align: top">
                    <asp:Label ID="txtWeapon2" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px" Visible="False" Width="185px"></asp:Label>
                    <asp:Label ID="txtWeapon21" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px" Visible="False" Width="185px"></asp:Label>
                    <br />
                    <asp:Label ID="txtWeapon22" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="185px" Visible="False" BackColor="White"></asp:Label>
                </td>
                <td class="auto-style12" style="vertical-align: top">
                    <asp:Label ID="txtWeapon3" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px" Visible="False" Width="185px"></asp:Label>
                    <asp:Label ID="txtWeapon31" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px" Visible="False" Width="185px"></asp:Label>
                    <br />
                    <asp:Label ID="txtWeapon32" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="185px" Visible="False" BackColor="White"></asp:Label>
                </td>
                <td class="auto-style12" style="vertical-align: top">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style11" style="vertical-align: top">
                    Graftings:<asp:BulletedList ID="graftings1" runat="server" CssClass="auto-style17" >
                    </asp:BulletedList>
                </td>
                <td class="auto-style11" style="vertical-align: top">
                    Equipment:<asp:BulletedList ID="equipment1" runat="server" CssClass="auto-style17">
                    </asp:BulletedList>
                </td>
                <td class="auto-style12" style="vertical-align: top">
                    </td>
                <td class="auto-style12" style="vertical-align: top">
                    </td>
            </tr>
            </table>
        <asp:Label ID="errorLabel" runat="server"></asp:Label>

        <br />
        <br />
        <asp:Label ID="errorLabel2" runat="server"></asp:Label>

        <br />

    </form>
</body>
</html>
