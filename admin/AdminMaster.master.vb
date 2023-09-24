Partial Class admin_AdminMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Cookies("admin") Is Nothing Then
            Response.Redirect("AdminLogin.aspx")
        End If
    End Sub

    Protected Sub btnsignout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsignout.Click
        Dim c As HttpCookie = Request.Cookies("admin")
        c.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(c)
        Response.Redirect("adminLogin.aspx")
    End Sub
End Class

