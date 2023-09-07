Imports System.Data.SqlClient
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim dr As SqlDataReader
    Dim constring As String = ConfigurationManager.ConnectionStrings("constring").ToString
    Dim matchUid As Integer
    Dim uid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            con.ConnectionString = constring
            cmd.Connection = con
            matchUid = Session("matchuid")
            'uid = Session("uid")

            Dim c As HttpCookie = Request.Cookies("user")
            If Not c Is System.DBNull.Value Then
                uid = c.Values("uid")
            Else
                Response.Redirect("LoginPage.aspx")
            End If

            loadData(uid, matchUid)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub loadData(ByVal uid As Integer, ByVal matchUid As Integer)
        Try
            cmd.CommandText = "select * from tbluser where uid=" & matchUid & ""
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            dlprofile.DataSource = dt
            dlprofile.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Try
            cmd.CommandText = "select * from tblfavlist where uid=" & uid & " and fav=" & matchUid & ""
            con.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                btnfavfill.Visible = True
                btnfav.Visible = False
            Else
                btnfav.Visible = True
                btnfavfill.Visible = False
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        con.Close()
    End Sub

    Protected Sub btnfav_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnfav.Click
        If uid <> 0 And matchUid <> 0 Then
            Try
                cmd.CommandText = "insert into tblfavlist(uid,fav) values(" & uid & "," & matchUid & ")"
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Response.Redirect("detailProfile.aspx")
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btnfavfill_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnfavfill.Click
        Try
            cmd.CommandText = "delete from tblfavlist where uid=" & uid & " and fav=" & matchUid & ""
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("deleted!")
            Response.Redirect("detailProfile.aspx")
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
