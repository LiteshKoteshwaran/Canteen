<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="Final.Admin.AdminHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
    <table class="nav-justified">
        <tr>
            <td class="modal-sm" style="width: 307px; height: 57px">
                <asp:Label ID="lblLocation" runat="server" Text="Locations"></asp:Label>
            </td>
            <td style="height: 57px">
                <asp:Button ID="btnLocation" runat="server" Text="View" OnClick="btnLocation_Click" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 307px; height: 59px">
                <asp:Label ID="lblCanteen" runat="server" Text="Canteen"></asp:Label>
            </td>
            <td style="height: 59px">
                <asp:Button ID="btnCanteen" runat="server" Text="View" OnClick="btnCanteen_Click" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 307px; height: 73px">
                <asp:Label ID="lblItemsRates" runat="server" Text="Items and Rates"></asp:Label>
            </td>
            <td style="height: 73px">
                <asp:Button ID="btnItemsRates" runat="server" Text="View" OnClick="btnItemsRates_Click" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 307px; height: 63px">
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </td>
            <td style="height: 63px">
                <asp:Button ID="btnEmail" runat="server" Text="View" OnClick="btnEmail_Click" />
            </td>
        </tr>
    </table>
</p>
<p>
</p>
</asp:Content>
