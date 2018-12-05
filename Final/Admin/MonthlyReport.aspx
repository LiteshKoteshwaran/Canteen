<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MonthlyReport.aspx.cs" Inherits="Final.Admin.MonthlyReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified" style="height: 319px">
        <tr>
            <td style="height: 63px"><h3>Monthly Report&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="MonthlyDropDownList" runat="server" Height="40px" OnSelectedIndexChanged="MonthlyDropDownList_SelectedIndexChanged">
                    <asp:ListItem Value="0">selectMonth</asp:ListItem>
                    <asp:ListItem Value="1">January</asp:ListItem>
                    <asp:ListItem Value="2">February</asp:ListItem>
                    <asp:ListItem Value="3">March</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">August</asp:ListItem>
                    <asp:ListItem Value="9">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnGetMonthlyReport" runat="server" OnClick="btnGetMonthlyReport_Click" Text="GetReport" />
                </h3></td>
        </tr>
        <tr>
            <td>    <asp:GridView ID="GridMonthlyReport" runat="server" AutoGenerateColumns="False" Height="319px" style="margin-left: 0px; margin-top: 8px;" Width="848px" OnSelectedIndexChanged="GridMonthlyReport_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Month">
                <ItemTemplate>
                    <asp:Label ID="Month" runat="server" Text='<%# Eval("Month") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Location">
                <ItemTemplate>
                    <asp:Label ID="Month" runat="server" Text='<%# Eval("LocName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Canteen">
                <ItemTemplate>
                    <asp:Label ID="Month" runat="server" Text='<%# Eval("CanteenName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NumberOfRequests(Intime+Adhoc)">
                <ItemTemplate>
                    <asp:Label ID="Month" runat="server" Text='<%# Eval("NoOfRequests") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NumberOfRequestsConsumed">
                <ItemTemplate>
                    <asp:Label ID="Month" runat="server" Text='<%# Eval("NoOfConsumed") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TotalCost(Consumed)">
                <ItemTemplate>
                    <asp:Label ID="Month" runat="server" Text='<%# Eval("FinalCost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
