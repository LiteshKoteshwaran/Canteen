<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DepartmentWiseMonthlyReport.aspx.cs" Inherits="Final.Admin.DepartmentWiseMonthlyReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table class="nav-justified" style="height: 378px">
        <tr>
            <td style="height: 98px"><h3 style="height: 31px">Department Wise Report&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </h3></td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridDeptWiseMonthlyReport" runat="server" AutoGenerateColumns="False" Height="225px" Width="843px" OnSelectedIndexChanged="GridDeptWiseMonthlyReport_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Department">
                 <ItemTemplate>
                    <asp:Label ID="Month" runat="server" Text='<%# Eval("DeptId") %>'></asp:Label>
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
                    <asp:Label ID="Month" runat="server" Text='<%# Eval("TotalCost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
