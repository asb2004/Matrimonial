<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginPage.aspx.vb" Inherits="LoginPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        body
        {
            background-image: url("images/loginbg.jpg");
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
            height: 100vh;
            width: 100%;
        }
       
        *
        {
            padding: 0px;
            margin: 0px;
            box-sizing: border-box;
        }
        
        .logo
        {
            position: absolute;
            bottom: 30px;
            left: 30px;
            height: 90px;
            width: 250px;
        }
        
        #Image1
        {
            height: inherit;
            width: inherit;
        } 
        
        .textField
        {
            background: none;
            width: 100%;
            border: 2px solid black;
            border-radius: 10px;
            outline: none;
            padding: 10px;
            margin-top: 4px;
        }
        
        .textField:focus
        {
            box-shadow: 0px 0px 5px gray;
        }
        
        td
        {
            padding: 7px;
        }
        
        .buttons
        {
            background-color: Black;
            color: White;
            font-size: 15px;
            margin-top: 15px;
            cursor: pointer;
            transition: all 0.2s ease-in-out;
        }
        
        .buttons:hover
        {
            background: none;
            border: 2px solid black;
            color: Black;
        }
        
        .text-buttons
        {
            background: none;
            cursor: pointer;
            outline: none;
            border: none;
            display: inline-block;
            color: Blue;
        }
        
        .style2
        {
            height: 25px;
        }
        
        .style3
        {
            width: 30%;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.353);
            backdrop-filter: blur(10px);
            border-radius: 20px;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <div class="logo">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.png" />
            </div>

            <table class="style3">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Login" 
                            Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Username<asp:TextBox ID="txtlemail" runat="server" type="email" CssClass="textField" placeholder="abc@xyz.com" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password<asp:TextBox ID="txtlpassword" runat="server" type="password" CssClass="textField" placeholder="Password" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnlogin" runat="server" CssClass="textField buttons" 
                            Text="Log in" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style2" colspan="2">
                        New User?
                        <asp:HyperLink ID="HyperLink1" runat="server" class="text-buttons" style="text-decoration: none" NavigateUrl="~/Registration.aspx">Sign up</asp:HyperLink>
                        <br />
                        <br />
                        <asp:Label ID="lblloginmsg" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
            </table>
        
        </div>
    </div>
    </form>
</body>
</html>
