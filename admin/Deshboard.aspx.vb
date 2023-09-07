Imports System.Data.SqlClient
Imports System.Data

Partial Class admin_Deshboard
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable



    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim email As String = GridView1.DataKeys(e.RowIndex).Value

        Try
            cmd.CommandText = "delete from tbluser where email='" & email & "'"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            loadData()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            con.ConnectionString = ConfigurationManager.ConnectionStrings("constring").ToString
            cmd.Connection = con

            If Request.Cookies("admin") Is Nothing Then
                Response.Redirect("AdminLogin.aspx")
            End If

            loadData()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub loadData()
        Try
            cmd.CommandText = "select name as Name,age as Age,mobileno as Mobile,gender as Gender,email as EmailID from tbluser"
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            GridView1.DataSource = dt
            GridView1.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
