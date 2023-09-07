<%@ Page Title="Profile Update" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ProfileUpdate.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="StyleSheet1.css" type="text/css" media="screen" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        
        td
        {
            padding: 10px;
            width: 50%;
        }
        
        .half
        {
            width: 32%
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="conatiner">
        
        <table class="style1">
            <tr>
                <td align="center" colspan="2" class="pageTitle">
                    Update Your Profile!</td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Overline="False" 
                        Font-Size="20px" Font-Underline="True" Text="Personal Details :"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Image ID="uprofileimg" runat="server" Height="200px" 
                        ImageUrl="~/images/profile_logo.png" Width="200px" class="profileImg" required/>
                    <br />
                    <asp:FileUpload ID="pickImg" runat="server" />
                    <asp:Button ID="ubtnselectimg" runat="server" Text="Select Image" />
                </td>
            </tr>
            <tr>
                <td>
                    Name<br />
                    <asp:TextBox ID="utxtname" runat="server" class="textField" placeholder="Enter Name" required></asp:TextBox>
                </td>
                <td>
                    Mobile<br />
                    <asp:TextBox ID="utxtmobile" runat="server" class="textField" type="number" placeholder="Mobile no." required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email ID<br />
                    <asp:TextBox ID="utxtemail" runat="server" class="textField" type="email" placeholder="abc@xyz.com" required></asp:TextBox>
                </td>
                <td>
                    Gender<br />
                    <asp:DropDownList ID="uddlgender" runat="server" class="textField">
                        <asp:ListItem>Select Gender</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Date Of Birth<br />
                    <asp:TextBox ID="utxtdob" runat="server" class="textField" type="text" onfocus="(this.type='date')" onblur="if(!this.value) this.type='text'" placeholder="dd-mm-yyyy" required></asp:TextBox>
                </td>
                <td>
                    Age<br />
                    <asp:TextBox ID="utxtage" runat="server" class="textField" placeholder="Age" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Religion<br />
                    <asp:DropDownList ID="uddlreligion" runat="server" class="textField">
                        <asp:ListItem>Select Religion</asp:ListItem>
                        <asp:ListItem>Hindu</asp:ListItem>
                        <asp:ListItem>Muslim</asp:ListItem>
                        <asp:ListItem>Parsi</asp:ListItem>
                        <asp:ListItem>Christian</asp:ListItem>
                        <asp:ListItem>Jain</asp:ListItem>
                        <asp:ListItem>Buddhist</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Mother Tongue<br />
                    <asp:DropDownList ID="uddlmothertongue" runat="server" class="textField" required>
                        <asp:ListItem>Select Language</asp:ListItem>
                        <asp:ListItem>Hindi</asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                        <asp:ListItem>Gujarati</asp:ListItem>
                        <asp:ListItem>Marathi</asp:ListItem>
                        <asp:ListItem>Panjabi</asp:ListItem>
                        <asp:ListItem>Bengali</asp:ListItem>
                        <asp:ListItem>Urdu</asp:ListItem>
                        <asp:ListItem>Kannada</asp:ListItem>
                        <asp:ListItem>Tamil</asp:ListItem>
                        <asp:ListItem>Telugu</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    City<br />
                    <asp:DropDownList ID="uddlcity" runat="server" class="textField" required>
                        <asp:ListItem>Select City</asp:ListItem>
                        <asp:ListItem>Surat</asp:ListItem>
                        <asp:ListItem>Mumbai</asp:ListItem>
                        <asp:ListItem>Baroda</asp:ListItem>
                        <asp:ListItem>Ahemdabad</asp:ListItem>
                        <asp:ListItem>Morvi</asp:ListItem>
                        <asp:ListItem>Rajkot</asp:ListItem>
                        <asp:ListItem>Bharuch</asp:ListItem>
                        <asp:ListItem>Kolkata</asp:ListItem>
                        <asp:ListItem>Pune</asp:ListItem>
                        <asp:ListItem>Banglore</asp:ListItem>
                        <asp:ListItem>Delhi</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Overline="False" 
                        Font-Size="20px" Font-Underline="True" class="topicLable" Text="Work Details :" required></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Occupation<br />
                    <asp:TextBox ID="utxtoccupation" runat="server" class="textField" placeholder="Occupation" required></asp:TextBox>
                </td>
                <td>
                    Qualification<br />
                    <asp:TextBox ID="utxtqualification" runat="server" class="textField" placeholder="Qualification" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Overline="False" 
                        Font-Size="20px" Font-Underline="True" Text="Physical Details :" required></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Height<br />
                    <asp:TextBox ID="utxtheight" runat="server" class="textField" type="number" placeholder="Height" required></asp:TextBox>
                </td>
                <td>
                    Weight<br />
                    <asp:TextBox ID="utxtweight" runat="server" class="textField" type="number" placeholder="Weight" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Overline="False" 
                        Font-Size="20px" Font-Underline="True" Text="Family Details : " required></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Total Family Member<br />
                    <asp:TextBox ID="utxtnoofmember" runat="server" class="textField" type="number" placeholder="Number of Member in Family" required></asp:TextBox>
                </td>
                <td>
                    Number of Sister<br />
                    <asp:TextBox ID="utxtnoofsister" runat="server" class="textField" type="number" placeholder="Number of Sister" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Number of Brother<br />
                    <asp:TextBox ID="utxtnoofbrother" runat="server" class="textField" type="number" placeholder="Number of Brothers" required></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Overline="False" 
                        Font-Size="20px" Font-Underline="True" Text="Your Requriements :" required></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5" valign="top">
                    Gender<br />
                    <asp:DropDownList ID="ureqddlgender" runat="server" class="textField" required>
                        <asp:ListItem>Select Gender</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Age<br />
                    <asp:TextBox ID="ureqtxtminage" runat="server" class="textField half" type="number" placeholder="Minimum Age" required></asp:TextBox>
                        &nbsp;To&nbsp;
                    <asp:TextBox ID="ureqtxtmaxage" runat="server" class="textField half" type="number" placeholder="Maximum Age" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Religion<br />
                    <asp:DropDownList ID="ureqddlreligion" runat="server" class="textField">
                        <asp:ListItem>Select Religion</asp:ListItem>
                        <asp:ListItem>Hindu</asp:ListItem>
                        <asp:ListItem>Muslim</asp:ListItem>
                        <asp:ListItem>Parsi</asp:ListItem>
                        <asp:ListItem>Christian</asp:ListItem>
                        <asp:ListItem>Jain</asp:ListItem>
                        <asp:ListItem>Buddhist</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    City<br />
                    <asp:DropDownList ID="ureqddlcity" runat="server" class="textField">
                        <asp:ListItem>Select City</asp:ListItem>
                        <asp:ListItem>Surat</asp:ListItem>
                        <asp:ListItem>Mumbai</asp:ListItem>
                        <asp:ListItem>Baroda</asp:ListItem>
                        <asp:ListItem>Ahemdabad</asp:ListItem>
                        <asp:ListItem>Morvi</asp:ListItem>
                        <asp:ListItem>Rajkot</asp:ListItem>
                        <asp:ListItem>Bharuch</asp:ListItem>
                        <asp:ListItem>Kolkata</asp:ListItem>
                        <asp:ListItem>Pune</asp:ListItem>
                        <asp:ListItem>Banglore</asp:ListItem>
                        <asp:ListItem>Delhi</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:Button ID="ubtnupdate" runat="server" Text="Save Changes" class="textField buttons" />
                    <asp:Button ID="ubtncancle" runat="server" Text="Cancle" class="text-buttons"/>
                    <asp:Button ID="ubtnreset" runat="server" Text="Reset" class="text-buttons"/>
                </td>
            </tr>
        </table>
        

        
    </div>

    <script>
        function fileChange(event) {
            var selectedFile = event.target.files[0];
            var reader = new FileReader();

            var imgtag = document.getElementById("htmlimg");
            //imgtag.title = selectedFile.name;

            reader.onload = function (event) {
                imgtag.scr = event.target.result;
            };

            reader.readAsDataURL(selectedFile);
        } 
    </script>
</asp:Content>



