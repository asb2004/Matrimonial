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
                loadRequriements(uid)
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub loadProfiles()
        Try
                cmd.CommandText = "select * from tbluser where gender='" & sddlgender.SelectedItem.Text & "' and age between " & stxtminage.Text & " and " & stxtmaxage.Text & " and religion='" & sddlreligion.SelectedItem.Text & "' and city='" & sddlcity.SelectedItem.Text & "'"
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                da.Fill(dt)
                DataList1.DataSource = dt
            DataList1.DataBind()
            If dt.Rows.Count = 0 Then
                titleofprofiles.Text = "No data Found!!"
            Else
                titleofprofiles.Text = "Best Heartbeats For You..."
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub loadRequriements(ByVal uid As Integer)
        Try
            cmd.CommandText = "select * from tbluser where uid=" & uid & ""
            con.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                If dr.GetValue(19).ToString <> "" Then
                    sddlgender.SelectedValue = dr.GetValue(19).ToString
                    stxtminage.Text = dr.GetValue(20).ToString
                    stxtmaxage.Text = dr.GetValue(21).ToString
                    sddlreligion.SelectedValue = dr.GetValue(22).ToString
                    sddlcity.SelectedValue = dr.GetValue(23).ToString

                    con.Close()
                    loadProfiles()
                Else
                    titleofprofiles.Text = "Upgrad Your Profile..."
                End If
                
            End If

            con.Close()

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "btnview" Then
            Session("matchuid") = e.CommandArgument.ToString
            Response.Redirect("detailProfile.aspx")
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        loadProfiles()
    End Sub
End Class
