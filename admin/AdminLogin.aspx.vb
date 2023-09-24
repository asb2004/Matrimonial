Imports System.Data.SqlClient
Imports System.Data

Partial Class admin_AdminLogin
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            con.ConnectionString = ConfigurationManager.ConnectionStrings("constring").ToString
            cmd.Connection = con

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub


    Protected Sub btnlogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        Try
            cmd.CommandText = "select * from tbladmin where aname='" & txtadminname.Text & "' and password='" & txtpassword.Text & "'"
            con.Open()
            Dim rcnt = cmd.ExecuteScalar()
            con.Close()

            If rcnt > 0 Then
                err.Text = "Done"
                err.ForeColor = Drawing.Color.Blue
                Dim c As New HttpCookie("admin")
                c.Values("adminLogin") = True
                Response.Cookies.Add(c)
                Response.Redirect("UserDetails.aspx")
            Else
                err.Text = "Invalid Input"
                err.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
