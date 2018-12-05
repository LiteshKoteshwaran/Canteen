<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CanteenRequestForm.aspx.cs" Inherits="Final.CanteenRequestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <h2><i>CANTEEN REQUEST FORM:</i></h2>
    <table class="nav-justified" id="Table">       
        <tr>
            <td class="auto-style1">
             <asp:Label ID="lblEmpNo" runat="server" Text="Employee No"></asp:Label>
                <br />
            </td>            
            <td class="auto-style2">
                <asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtEmpNo" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="lblEmpName" runat="server" Text="Employee Name"></asp:Label>
                <br />
            </td>
            <td class="auto-style4">
                <br />
                <asp:DropDownList ID="ddlEmpName" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="ddlEmpName_SelectedIndexChanged" >
                </asp:DropDownList>
                <br />
                <asp:TextBox ID="txtEmpLoyee" runat="server"></asp:TextBox>
                <br />
                <br />
            </td>             
        </tr>     
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblLoc" runat="server" Text="Location"></asp:Label>
                <br />
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"  >
                <asp:ListItem Text = "--Select Location--" Value = ""></asp:ListItem>
                </asp:DropDownList>

                <br />
            </td>
            <td class="auto-style7">
                <asp:Label ID="lblCanteen" runat="server" Text="Canteen"></asp:Label>
                <br />
            </td>

            <td class="auto-style8">
                <asp:DropDownList ID="ddlCanteen" runat="server" AutoPostBack = "true" Enabled = "true" OnSelectedIndexChanged="ddlCanteen_SelectedIndexChanged" >
                <asp:ListItem Text = "--Select Canteen--" Value = ""></asp:ListItem>
                </asp:DropDownList>

                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:DropDownList ID="ddlCanteenType" runat="server" >
                    <asp:ListItem>VIP</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style11">
                <asp:Label ID="lblMealType" runat="server" Text="Meal Type"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:DropDownList ID="ddlMealType" AutoPostBack = "true" Enabled = "true" runat="server" >
                <asp:ListItem Text = "--Select Mealtype--" Value = ""></asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="lblFromdate" runat="server" Text="From Date" ></asp:Label>
            </td>
            <td class="auto-style14">
               &nbsp;<br />
                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            </td>
            <td class="auto-style15">
                <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
            </td>
            <td class="auto-style16">
                <br />
                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td> <asp:Label ID="lblDeptId" runat="server" Text="Department Name"></asp:Label></td>
            <td> 
                <br />
                <asp:DropDownList ID="ddlDeptID" runat="server" >
                </asp:DropDownList>
                <br />
                <br />
            </td>
        </tr>
    </table >
    <table class="nav-justified" id="table" >
        <tr>
            <td><asp:Label ID="txtAddDetails" runat="server" Text="Additional Notes"></asp:Label></td>
            <td colspan="3"> <textarea id="txtAddNotes" cols="90" rows="3"></textarea> </td>
        </tr>        
    </table>
    <style>
table 
{
    border-collapse:separate;
    border-spacing:0 8px;
}
[type="date"]::-webkit-inner-spin-button {
  display: none;
}
[type="date"]::-webkit-calendar-picker-indicator {
  opacity: 0;
}
[type="date"] {
  background:#fff url(https://cdn1.iconfinder.com/data/icons/cc_mono_icon_set/blacks/16x16/calendar_2.png)  97% 50% no-repeat ;
}
        .auto-style1 {
            width: 176px;
            height: 41px;
        }
        .auto-style2 {
            width: 277px;
            height: 41px;
        }
        .auto-style3 {
            width: 273px;
            height: 41px;
        }
        .auto-style4 {
            height: 41px;
        }
        .auto-style5 {
            width: 176px;
            height: 42px;
        }
        .auto-style6 {
            width: 277px;
            height: 42px;
        }
        .auto-style7 {
            width: 273px;
            height: 42px;
        }
        .auto-style8 {
            height: 42px;
        }
        .auto-style9 {
            width: 176px;
            height: 44px;
        }
        .auto-style10 {
            width: 277px;
            height: 44px;
        }
        .auto-style11 {
            width: 273px;
            height: 44px;
        }
        .auto-style12 {
            height: 44px;
        }
        .auto-style13 {
            width: 176px;
            height: 53px;
        }
        .auto-style14 {
            width: 277px;
            height: 53px;
        }
        .auto-style15 {
            width: 273px;
            height: 53px;
        }
        .auto-style16 {
            height: 53px;
        }
        .auto-style17 {
            width: 100%;
            height: 247px;
        }
        .auto-style18 {
            height: 62px;
            width: 1093px;
        }
        .auto-style19 {
            width: 1093px;
        }
        .auto-style21 {
            width: 169px;
        }
        .auto-style22 {
            width: 199px;
        }
        .auto-style23 {
            width: 151px;
        }
        .auto-style24 {
            width: 225px;
        }
        .auto-style25 {
            width: 166px;
        }
        .auto-style26 {
            width: 203px;
        }
        .auto-style27 {
            width: 245px;
        }
    </style>
  
    <div>
        <table class="auto-style17">
            <tr>
                <td class="auto-style19">member Details in case of Guest</td>
            </tr>
            <tr>
               <td class="auto-style19">
            <table id="GuestDetails" style="height: 36px; width: 764px;">
                    <tr>
                        <td style="width: 167px">S.No    </td>
                        <td class="modal-sm" style="width: 197px">Name</td>
                        <td style="width: 233px">FromOrganizationName</td>
                        <td class="modal-sm" style="width: 160px">Mobile</td>                       
                        <td class="modal-sm" style="width: 160px">TokenCode</td>
                    </tr>
                    <tr> 
                        <td style="width: 167px">
                            <asp:Label ID="lblCount" runat="server"></asp:Label>
                        </td>
                        <td class="modal-sm" style="width: 197px">
                            <asp:TextBox ID="txtGuestName" runat="server" ></asp:TextBox>
                        </td>
                        <td style="width: 233px">
                            <asp:TextBox ID="txtOrgName" runat="server"></asp:TextBox>
                        </td>
                        <td class="modal-sm" style="width: 160px">
                            <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
                        </td>
                        <td>

                            <asp:Label ID="lblTokenID" runat="server"></asp:Label>

                        </td>
                    </tr>
                </table>
            &nbsp;&nbsp;<br />
                   <table id="TableForHr" runat="server" class="nav-justified">
                       <tr>
                           <td class="auto-style27">
                               Employess Details in case of Hr Login<br />
                               <asp:Label ID="lblHrCount" runat="server" Text="Sl. No"></asp:Label>
                           </td>
                           <td class="auto-style21">
                               <br />
                               <asp:Label ID="lblHrEmpName" runat="server" Text="Employee Name"></asp:Label>
                           </td>
                           <td class="auto-style22">
                               <br />
                               <asp:Label ID="lblHrDept" runat="server" Text="Department Name"></asp:Label>
                           </td>
                           <td class="auto-style23">
                               <br />
                               <asp:Label ID="lblHrMoblie" runat="server" Text="Mobile No."></asp:Label>
                           </td>
                           <td>
                               <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Label ID="lblHrToken" runat="server" Text="Token"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style27">
                               <asp:Label ID="lblHrSlNo" runat="server"></asp:Label>
                           </td>
                           <td class="auto-style21">
                               <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
                           </td>
                           <td class="auto-style22">
                               <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                           </td>
                           <td class="auto-style23">
                               <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                           </td>
                           <td>
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Label ID="lblToken" runat="server"></asp:Label>
                           </td>
                       </tr>
                   </table>
                   &nbsp;<br />
                   <table id="TableForSnacks" runat ="server"  class="nav-justified">
                       <tr>
                           <td class="auto-style24">
                               Snacks Details in case of Hr Login<br />
                               <asp:Label ID="SLNo" runat="server" Text="Sl No."></asp:Label>
                           </td>
                           <td class="auto-style25">
                               <br />
                               <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label>
                           </td>
                           <td class="auto-style26">
                               <br />
                               <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
                           </td>
                           <td>
                               <br />
                               <asp:Label ID="lblTimetoServe" runat="server" Text="Time To Serve"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style24">
                               <asp:Label ID="lblSlNo" runat="server"></asp:Label>
                           </td>
                           <td class="auto-style25">
                               <asp:DropDownList ID="ddlItemName" runat="server">
                               </asp:DropDownList>
                           </td>
                           <td class="auto-style26">
                               <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                           </td>
                           <td>
                               <asp:TextBox ID="txtTimetoServe" runat="server"></asp:TextBox>
                           </td>
                       </tr>
                   </table>
                   <br />
                   <br />
                   <br />
                   <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <br />
            </td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;&nbsp;<asp:TextBox ID="txtMailBody" runat="server" Height="51px" TextMode="MultiLine" Width="348px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRequest" runat="server" Text="Request" OnClick="btnRequest_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnReqSubmit" runat="server" Text="Submit" OnClick="btnReqSubmit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnReqCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </div>




</asp:Content>
