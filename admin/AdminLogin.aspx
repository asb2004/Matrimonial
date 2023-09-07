<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdminLogin.aspx.vb" Inherits="admin_AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <style>
        *
        {
            margin: 0px;
            padding: 0px;
            box-sizing: border-box;
        }
        div
        {
            width: 20%;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            padding: 20px;
            border-radius: 20px;
        }
        
        h2
        {
            text-align:center;
            margin: 10px;
        }
        
        .text-field
        {
            background: none;
            border: 1px solid black;
            border-radius: 10px;
            padding: 10px;
            width: 100%;
            margin-top: 5px;
            margin-bottom: 10px;
            outline: none;
        }
        .text-field:focus
        {
            border: 2px solid black;
        }
        
        .btn
        {
            margin-top: 20px;
            background-color: Black;
            color: white;
            cursor: pointer;
        }  
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Admin Login</h2>
        Name
        <asp:TextBox ID="txtadminname" runat="server" class="text-field" placeholder="Admin Name" required></asp:TextBox>
        Password
        <asp:TextBox ID="txtpassword" runat="server" class="text-field" type="password" placeholder="Password" required></asp:TextBox>
        <asp:Button ID="btnlogin" runat="server" Text="Log in" class="text-field btn" />
        <asp:Label ID="err" runat="server" Text="" class="errmsg" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
