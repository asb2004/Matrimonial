Imports System.Data.SqlClient
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim constring As String = ConfigurationManager.ConnectionStrings("constring").ToString

    Dim uid As Integer

    Sub showData(ByVal uid As Integer)
        Try
            cmd.CommandText = "select * from tbluser where uid=" & uid & ""
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            dlprofile.DataSource = dt
            dlprofile.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            con.ConnectionString = constring
            cmd.Connection = con
            'uid = Session("uid")

            Dim c As HttpCookie = Request.Cookies("user")
            If Request.Cookies("user") Is Nothing Then
                Response.Redirect("LoginPage.aspx")
            Else
                uid = c.Values("uid")
            End If
            showData(uid)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("ProfileUpdate.aspx")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        ClientScript.RegisterStartupScript(Me.[GetType](), "myalert", "confirm('Are You Sure to Want to Delete Account from www.findyourhearbeat.com');", True)
        Try
            cmd.CommandText = "delete from tbluser where uid=" & uid & ""
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Response.Cookies("user").Expires = Date.Now.AddDays(-1)
            Response.Redirect("Registration.aspx")
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
