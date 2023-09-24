Imports System.Data.SqlClient
Imports System.Data

Partial Class LoginPage
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

    Sub clearLoginControl()
        txtlemail.Text = ""
        txtlpassword.Text = ""
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnlogin.Click
        Try
            cmd.CommandText = "select * from tbluser where email='" & txtlemail.Text & "' and password='" & txtlpassword.Text & "'"
            con.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                If dr.GetValue(24) = 1 Then
                    clearLoginControl()
                    lblloginmsg.Text = "login successfully!"
                    lblloginmsg.ForeColor = Drawing.Color.Blue
                    Dim uid As Integer = 0
                    'While (dr.Read())
                    uid = dr.GetValue(0)
                    'End While

                    Dim c As New HttpCookie("user")
                    c.Values("uid") = uid
                    Response.Cookies.Add(c)

                    ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "alert('Log in Successfully!');", True)
                    Response.Redirect("~/HomePage.aspx")
                Else
                    lblloginmsg.Text = "Your Account is not Activated! Try After Some Time..."
                    lblloginmsg.ForeColor = Drawing.Color.Red
                End If

                
            Else
                txtlemail.Focus()
                lblloginmsg.Text = "Invalid email or password"
                lblloginmsg.ForeColor = Drawing.Color.Red
            End If

            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
