<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BillApproval.aspx.cs" Inherits="Final.Admin.BillApproval" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Button ID="btnViewBill" runat="server" Text="View Bill" />
    </p>
    <p>
        &nbsp;</p>
    <table id="BillForm" class="nav-justified">
        <tr>
            <td style="height: 70px; width: 213px">
                <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
            </td>
            <td style="height: 70px; width: 215px">
                <asp:DropDownList ID="DropDownListYear" runat="server" ItemType="Year">
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="modal-sm" style="width: 270px; height: 70px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label>
            </td>
            <td style="height: 70px">
                <asp:DropDownList ID="DropDownListMonth" runat="server">
                    <asp:ListItem>Jan</asp:ListItem>
                    <asp:ListItem>Feb</asp:ListItem>
                    <asp:ListItem>March</asp:ListItem>
                    <asp:ListItem>April</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>June</asp:ListItem>
                    <asp:ListItem>July</asp:ListItem>
                    <asp:ListItem>August</asp:ListItem>
                    <asp:ListItem>Sep</asp:ListItem>
                    <asp:ListItem>Oct</asp:ListItem>
                    <asp:ListItem>Nov</asp:ListItem>
                    <asp:ListItem>Dec</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 61px; width: 213px">
                <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
            </td>
            <td style="height: 61px; width: 215px">
                <asp:DropDownList ID="DropDownListLocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="LocationName" DataValueField="LocationName">
                </asp:DropDownList>
            </td>
            <td class="modal-sm" style="width: 270px; height: 61px">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCanteen" runat="server" Text="Canteen"></asp:Label>
            </td>
            <td style="height: 61px">
                <asp:DropDownList ID="DropDownListCanteen" runat="server" DataSourceID="SqlDataSource2" DataTextField="CanteenName" DataValueField="CanteenName">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 59px; width: 213px">
                <asp:Label ID="lblNoOfRequest" runat="server" Text="No Of Requests"></asp:Label>
            </td>
            <td style="height: 59px; width: 215px">
                <asp:TextBox ID="txtNoOfRequest" runat="server"></asp:TextBox>
            </td>
            <td class="modal-sm" style="width: 270px; height: 59px">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblNoConsumedRequest" runat="server" Text="No Of Consumed Request"></asp:Label>
            </td>
            <td style="height: 59px">
                <asp:TextBox ID="txtConsumedRequest" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 95px; width: 213px">
                <asp:Label ID="lblTotalCost" runat="server" Text="Total Cost"></asp:Label>
            </td>
            <td style="height: 95px; width: 215px">
                <asp:TextBox ID="txtTotalCost" runat="server"></asp:TextBox>
            </td>
            <td class="modal-sm" style="width: 270px; height: 95px">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblAdditionalnotes" runat="server" Text="Additional Notes"></asp:Label>
            </td>
            <td style="height: 95px">
                <asp:TextBox ID="txtAddNotes" runat="server" Height="71px" TextMode="MultiLine" Width="372px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 89px; width: 213px">
                <asp:Label ID="lblFinalCost" runat="server" Text="Final Cost"></asp:Label>
            </td>
            <td style="height: 89px; width: 215px">
                <asp:TextBox ID="txtFinalCost" runat="server"></asp:TextBox>
            </td>
            <td class="modal-sm" style="width: 270px; height: 89px">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvoiceDate" runat="server" Text="Invoice Date"></asp:Label>
            </td>
            <td style="height: 89px">
                <input id="txtInvoiceDate" type="date"/></td>
        </tr>
        <tr>
            <td style="height: 55px; width: 213px">
                <asp:Label ID="lblInvoiceNumber" runat="server" Text="Invoice Number"></asp:Label>
            </td>
            <td style="height: 55px; width: 215px">
                <asp:TextBox ID="txtInvoiceNumber" runat="server"></asp:TextBox>
            </td>
            <td class="modal-sm" style="width: 270px; height: 55px"></td>
            <td style="height: 55px"></td>
        </tr>
        <tr>
            <td style="width: 213px; height: 10px"></td>
            <td style="width: 215px; height: 10px"></td>
            <td class="modal-sm" style="width: 270px; height: 10px"></td>
            <td style="height: 10px"></td>
        </tr>
        <tr>
            <td style="height: 16px; width: 213px"></td>
            <td style="height: 16px; width: 215px"></td>
            <td class="modal-sm" style="width: 270px; height: 16px"></td>
            <td style="height: 16px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
