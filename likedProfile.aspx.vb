Imports System.Data.SqlClient
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim constring As String = ConfigurationManager.ConnectionStrings("constring").ToString
    Dim uid As Integer

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
            If IsPostBack = False Then
                loadProfiles()
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub loadProfiles()
        Try
            cmd.CommandText = "select * from tbluser u, tblfavlist f where u.uid=f.fav and f.uid=" & uid & ""
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            DataList1.DataSource = dt
            DataList1.DataBind()
            If dt.Rows.Count = 0 Then
                titleofprofiles.Text = "No data Found!!"
            Else
                titleofprofiles.Text = "Your Favourites..."
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "btnview" Then
            Session("matchuid") = e.CommandArgument.ToString
            Response.Write(e.CommandArgument.ToString)
            Response.Redirect("detailProfile.aspx")
        End If
    End Sub
End Class
