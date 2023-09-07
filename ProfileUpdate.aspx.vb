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

    Dim uid As Integer
    Dim filepath As String

    Sub loadData(ByVal uid As Integer)

        Try
            cmd.CommandText = "select * from tbluser where uid=" & uid & ""
            con.Open()
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                While (dr.Read())
                    utxtname.Text = dr.GetValue(1).ToString
                    utxtage.Text = dr.GetValue(2).ToString
                    utxtmobile.Text = dr.GetValue(3).ToString
                    utxtdob.Text = dr.GetValue(4).ToString
                    uddlgender.SelectedValue = dr.GetValue(5).ToString
                    utxtemail.Text = dr.GetValue(6).ToString
                    filepath = dr.GetValue(8).ToString
                    uprofileimg.ImageUrl = filepath
                    uddlreligion.SelectedValue = dr.GetValue(9).ToString
                    uddlmothertongue.SelectedValue = dr.GetValue(10).ToString
                    uddlcity.SelectedValue = dr.GetValue(11).ToString
                    utxtoccupation.Text = dr.GetValue(12).ToString
                    utxtqualification.Text = dr.GetValue(13).ToString
                    utxtheight.Text = dr.GetValue(14).ToString
                    utxtweight.Text = dr.GetValue(15).ToString
                    utxtnoofmember.Text = dr.GetValue(16).ToString
                    utxtnoofbrother.Text = dr.GetValue(17).ToString
                    utxtnoofsister.Text = dr.GetValue(18).ToString
                    ureqddlgender.SelectedValue = dr.GetValue(19).ToString
                    ureqtxtminage.Text = dr.GetValue(20).ToString
                    ureqtxtmaxage.Text = dr.GetValue(21).ToString
                    ureqddlreligion.SelectedValue = dr.GetValue(22).ToString
                    ureqddlcity.SelectedValue = dr.GetValue(23).ToString
                End While
            End If
            con.Close()
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

            If IsPostBack = False Then
                loadData(uid)
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub ubtnupdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ubtnupdate.Click
        Try
            cmd.CommandText = "update tbluser set name='" & utxtname.Text & "', age=" & utxtage.Text & ", mobileno=" & utxtmobile.Text & ", dob='" & utxtdob.Text & "', gender='" & uddlgender.SelectedItem.Text & "', email='" & utxtemail.Text & "', profile='" & uprofileimg.ImageUrl.ToString & "', religion='" & uddlreligion.SelectedItem.Text & "', mothertongue='" & uddlmothertongue.SelectedItem.Text & "', city='" & uddlcity.SelectedItem.Text & "', occupation='" & utxtoccupation.Text & "', qualification='" & utxtqualification.Text & "', height=" & utxtheight.Text & ", weight=" & utxtweight.Text & ", noofmember=" & utxtnoofmember.Text & ", noofbrother=" & utxtnoofbrother.Text & ", noofsister=" & utxtnoofsister.Text & ", rgender='" & ureqddlgender.SelectedItem.Text & "', rminage=" & ureqtxtminage.Text & ", rmaxage=" & ureqtxtmaxage.Text & ", rreligion='" & ureqddlreligion.SelectedItem.Text & "', rcity='" & ureqddlcity.SelectedItem.Text & "' where uid=" & uid & ""

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Response.Redirect("~/Profile.aspx")
            Response.Write("Updated")
            loadData(uid)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub ubtnselectimg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ubtnselectimg.Click
        If pickImg.HasFile Then
            filepath = "~/images/" + pickImg.FileName
            pickImg.SaveAs(Server.MapPath("~/images/") + pickImg.FileName)
            uprofileimg.ImageUrl = filepath
        End If
    End Sub

    Protected Sub ubtncancle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ubtncancle.Click
        Response.Redirect("~/Profile.aspx")
    End Sub

    Sub clearUControls()
        filepath = "~/images/profile_logo.png"
        uprofileimg.ImageUrl = filepath.ToString
        uddlreligion.SelectedIndex = 0
        uddlmothertongue.SelectedIndex = 0
        uddlcity.SelectedIndex = 0
        utxtoccupation.Text = ""
        utxtqualification.Text = ""
        utxtheight.Text = ""
        utxtweight.Text = ""
        utxtnoofmember.Text = ""
        utxtnoofbrother.Text = ""
        utxtnoofsister.Text = ""
        ureqddlgender.SelectedIndex = 0
        ureqtxtminage.Text = ""
        ureqtxtmaxage.Text = ""
        ureqddlreligion.SelectedIndex = 0
        ureqddlcity.SelectedIndex = 0
    End Sub

    Protected Sub ubtnreset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ubtnreset.Click
        loadData(uid)
    End Sub
End Class
