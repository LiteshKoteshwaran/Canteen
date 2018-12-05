<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="VIPRequestFrom.aspx.cs" Inherits="Final.Admin.VIPRequestFrom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <table class="nav-justified">
        <tr>
            <td style="width: 351px">
                <asp:Label ID="lblRequestID" runat="server" Text="Request ID"></asp:Label>
            </td>
            <td>
                <br />
                <asp:TextBox ID="txtRequestID" runat="server"></asp:TextBox>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 351px">
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="65px" TextMode="MultiLine" Width="403px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="btnAccept" runat="server" OnClick="btnAccept_Click" Text="Accept" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" Text="Reject" />
    <br />
    <br />
</asp:Content>
