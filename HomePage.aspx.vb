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
                noOfUser.Text = Application("Count")
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub loadProfiles()
        If sddlgender.SelectedItem.Text = "Male" Then
            titleOfProfiles.Text = "Grooms"
        Else
            titleOfProfiles.Text = "Brides"
        End If
        Try
            If stxtminage.Text = "" And stxtmaxage.Text = "" Then
                cmd.CommandText = "select * from tbluser where gender='" & sddlgender.SelectedItem.Text & "' and uid!=" & uid & ""
            ElseIf stxtminage.Text <> "" Then
                cmd.CommandText = "select * from tbluser where gender='" & sddlgender.SelectedItem.Text & "' and age>=" & stxtminage.Text & " and uid!=" & uid & ""
            ElseIf stxtmaxage.Text <> "" Then
                cmd.CommandText = "select * from tbluser where gender='" & sddlgender.SelectedItem.Text & "' and age<=" & stxtmaxage.Text & " and uid!=" & uid & ""
            End If

            If stxtmaxage.Text <> "" And stxtminage.Text <> "" Then
                cmd.CommandText = "select * from tbluser where gender='" & sddlgender.SelectedItem.Text & "' and age between " & stxtminage.Text & " and " & stxtmaxage.Text & " and uid!=" & uid & ""
            End If

            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            DataList1.DataSource = dt
            DataList1.DataBind()
            If dt.Rows.Count = 0 Then
                titleOfProfiles.Text = "No data Found!!"
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

    Protected Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Session("matchuid") = e.CommandArgument.ToString
        Response.Redirect("detailProfile.aspx")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        loadProfiles()
    End Sub
End Class
