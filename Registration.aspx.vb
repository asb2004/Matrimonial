Imports System.Data.SqlClient
Imports System.Data

Partial Class Registration
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim constring As String = ConfigurationManager.ConnectionStrings("constring").ToString

    Dim dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            con.ConnectionString = constring
            cmd.Connection = con
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub
    Sub clearRegistrationControl()
        txtname.Text = ""
        txtage.Text = ""
        txtcpassword.Text = ""
        txtdob.Text = ""
        txtemail.Text = ""
        txtmobileno.Text = ""
        txtpassword.Text = ""
        ddlgender.SelectedIndex = 0
    End Sub

    Protected Sub btnsignin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsignin.Click
        Try
            cmd.CommandText = "select * from tbluser where email='" & txtemail.Text & "'"
            con.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                clearRegistrationControl()
                txtemail.Focus()
                lblmsg.Text = "User Already Exists!"
                lblmsg.ForeColor = Drawing.Color.Red
                con.Close()
            Else
                con.Close()
                Try
                    cmd.CommandText = "insert into tbluser(name,age,mobileno,dob,gender,email,password,profile) values('" & txtname.Text & "'," & txtage.Text & "," & txtmobileno.Text & ",'" & txtdob.Text & "','" & ddlgender.SelectedItem.Text & "','" & txtemail.Text & "','" & txtpassword.Text & "','" & "~/images/profile_logo.png" & "')"
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    lblmsg.Text = "Registraiton Successfully!"
                    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Registraiton Successfully!');", True)
                    lblmsg.ForeColor = Drawing.Color.Blue
                    clearRegistrationControl()
                    Response.Redirect("LoginPage.aspx")
                Catch ex As Exception
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Red
                End Try
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub
End Class
