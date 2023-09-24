Imports System.Data.SqlClient
Imports System.Data

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim constring As String = ConfigurationManager.ConnectionStrings("constring").ToString

    Dim uid As Integer

    Sub loaddata(ByVal uid As Integer)
        Try
            Try
                cmd.CommandText = "select * from tbluser where uid=" & uid & ""
                con.Open()
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    username.Text = "Hello! " + dr.GetValue(1).ToString
                    imgprofile.ImageUrl = dr.GetValue(8).ToString
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            con.ConnectionString = constring
            cmd.Connection = con
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Dim c As HttpCookie = Request.Cookies("user")
        If Request.Cookies("user") Is Nothing Then
            'Response.Redirect("LoginPage.aspx")
        Else
            uid = c.Values("uid")
        End If

        If IsPostBack = False Then
            loaddata(uid)
        End If
    End Sub

    Protected Sub btnsignout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsignout.Click
        Session.Abandon()
        Response.Cookies("user").Expires = Date.Now.AddDays(-1)
        Response.Redirect("~/LoginPage.aspx")
    End Sub
End Class

