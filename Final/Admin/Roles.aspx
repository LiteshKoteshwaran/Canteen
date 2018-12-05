<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="Final.Admin.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified" style="height: 363px">
        <tr>
            <td style="width: 291px">
                <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Width="341px" OnRowEditing="gvRoles_RowEditing" OnRowUpdating="gvRoles_RowUpdating" OnRowDeleting="gvRoles_RowDeleting">
                    <Columns>                        
            <asp:TemplateField HeaderText="Id">  
                <EditItemTemplate> 
                    <asp:Label ID="lblRoleId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>  
                </EditItemTemplate>  
                <ItemTemplate> 
                    <asp:Label ID="lblRoleId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Name">  
                <EditItemTemplate> 
                    <asp:TextBox ID="txtRolesName" Text='<%# Eval("Name") %>' runat="server"></asp:TextBox> 
                </EditItemTemplate>  
                <ItemTemplate> 
                    <asp:Label ID="lblRoleName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>  
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
            <td style="width: 221px">
                &nbsp;</td>
            <td style="width: 145px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 291px; height: 42px">
                <asp:Label ID="lblRoleId" runat="server" Text="RoleId"></asp:Label>
            </td>
            <td style="height: 42px; width: 221px">
                <asp:TextBox ID="txtRoleId" runat="server"></asp:TextBox>
            </td>
            <td style="height: 42px; width: 145px">
                <asp:Button ID="btnGenerateId" runat="server" Text="GenerateId" OnClick="btnGenerateId_Click" />
            </td>
            <td style="height: 42px"></td>
        </tr>
        <tr>
            <td style="width: 291px">
                <asp:Label ID="lblRoleName" runat="server" Text="RoleName"></asp:Label>
            </td>
            <td style="width: 221px">
                <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 145px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 291px">&nbsp;</td>
            <td style="width: 221px">&nbsp;</td>
            <td style="width: 145px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 291px">&nbsp;</td>
            <td style="width: 221px">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            </td>
            <td style="width: 145px">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 291px">&nbsp;</td>
            <td style="width: 221px">&nbsp;</td>
            <td style="width: 145px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
