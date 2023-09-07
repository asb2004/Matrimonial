<%@ Page Title="Liked" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="likedProfile.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="StyleSheet1.css" type="text/css" media="screen" />
    <style>
        p
        {
            text-align: center;
            margin: 20px auto;
        }
        .style1
        {
            width: 95%;
            background-color: #F8F0E5;
            border-radius: 20px;
            margin-top: 20px;
            margin-left: 20px;
            padding: 20px 0px;   
        }
        .style2
        {
            height: 24px;
        }
        td
        {
            padding: 5px 0px;
        }
        .style3
        {
            width: 100%;
        }
        
        .style3 td
        {
            width: 20%;
        }
        .fav-btn
        {
            margin-right: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="conatiner">
        <center>
            <br />
            <asp:Label ID="titleofprofiles" runat="server" Text="Your Favourite..." 
                class="pageTitle"></asp:Label></center>

         <div class="profiles">
             <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" 
                 RepeatDirection="Horizontal" Width="100%">
                 <ItemTemplate >
                     <table class="style1">
                         <tr>
                             <td align="center" rowspan="4" valign="middle" width="200px">
                                 <asp:Image ID="Image1" runat="server" Height="120px" class="profileImg"
                                     ImageUrl='<%# Eval("profile") %>' Width="120px" />
                             </td>
                             <td>
                                 <asp:Label ID="name" runat="server" Text='<%# Eval("name") %>' Font-Size="X-Large"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label2" runat="server" Text='<%# Eval("occupation") %>'></asp:Label>
                                 &nbsp;&#183;&nbsp;
                                 <asp:Label ID="Label3" runat="server" Text='<%# Eval("qualification") %>'></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td class="style2">
                                 <asp:Label ID="Label4" runat="server" Text='<%# Eval("city") %>'></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 Age:
                                 <asp:Label ID="Label5" runat="server" Text='<%# Eval("age") %>'></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td align="center">
                                 <asp:Button ID="Button1" runat="server" Text="View Profile" 
                                     class="text-buttons" Width="80%" CommandArgument='<%# Eval("uid") %>' CommandName="btnview" />
                             </td>
                         </tr>
                     </table>
                 </ItemTemplate>
             </asp:DataList>
        </div>
    </div>
</asp:Content>

