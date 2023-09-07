<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Registration.aspx.vb" Inherits="Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>

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

        .style1
        {
            width: 40%;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.353);
            backdrop-filter: blur(10px);
            border-radius: 20px;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%) scale(1);
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

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <div class="logo">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.png" />
            </div>

            <table class="style1">
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" 
                            Text="Register Your Self!" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Full Name<asp:TextBox ID="txtname" runat="server" CssClass="textField" placeholder="Full Name" required></asp:TextBox>
                    </td>
                    <td align="left">
                        Gender
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="ddlgender" ErrorMessage="Select Gender" ForeColor="Red" 
                            InitialValue="Gender" SetFocusOnError="True">Select Gender</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlgender" runat="server" 
                            CssClass="textField">
                            <asp:ListItem>Gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Age
                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                            ControlToValidate="txtage" ErrorMessage="Enter Valid Age" ForeColor="Red" 
                            MaximumValue="60" MinimumValue="18" SetFocusOnError="True" Type="Integer">Enter Valid Age</asp:RangeValidator>
                        <asp:TextBox ID="txtage" type="number" runat="server" CssClass="textField" placeholder="Age" required></asp:TextBox>
                    </td>
                    <td align="left">
                        Mobile No.<asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmobileno" 
                            ErrorMessage="Enter Valid Number" ForeColor="Red" 
                            ValidationExpression="[0-9]{10}">Enter Valid Number</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtmobileno" type="number" runat="server" CssClass="textField" placeholder="Mobile No." required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        Date of Birthirth<asp:TextBox ID="txtdob" runat="server" CssClass="textField" type="text" onfocus="(this.type='date')" onblur="if(!this.value) this.type='text'" placeholder="Date Of Birth" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        Email ID<asp:TextBox ID="txtemail" runat="server" CssClass="textField" type="email" placeholder="abc@xyz.com" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        Password<asp:TextBox ID="txtpassword" runat="server" type="password" CssClass="textField" placeholder="Password" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style2" colspan="2">
                    Confirm Password<asp:CompareValidator 
                            ID="CompareValidator1" runat="server" ControlToCompare="txtpassword" 
                            ControlToValidate="txtcpassword" ErrorMessage="Enter Same Password" 
                            ForeColor="Red">Enter Same Password</asp:CompareValidator>
                        <asp:TextBox ID="txtcpassword" runat="server" type="password" CssClass="textField" placeholder="Confirm Password" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style2" colspan="2">
                        <asp:Button ID="btnsignin" runat="server" Text="Sign in" 
                            CssClass="textField buttons"/>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style2" colspan="2">
                        Already Registered?
                            <asp:HyperLink ID="HyperLink1" runat="server" class="text-buttons" 
                            style="text-decoration: none" NavigateUrl="~/LoginPage.aspx">Log in</asp:HyperLink>
                        <br />
                        <br />
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
            </table>
        
        </div>
    </div>
    </form>
</body>
</html>
