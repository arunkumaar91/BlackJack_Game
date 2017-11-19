using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["redirect"] = "";
    }
    protected void Loginbtn_Click(object sender, EventArgs e)
    {
        string username = Usertxt.Text;
        string password = Pwdtxt.Text;
        if (username == "" || Pwdtxt.Text == "")
        {
            Errmsg.ForeColor = Color.Red;
            Errmsg.Text = "Invalid Username or password";
        }
        using (var context = new Testdata1Entities())
        {
            var a = from u in context.users
                    where u.user_name == username && u.password == password
                    select u;
            var b = a.FirstOrDefault();
            if (b == null)
            {
                Errmsg.ForeColor = Color.Red;
                Errmsg.Text = "Password is mismatching";
            }
            else
            {
                Session["username"] = username;
                Response.Redirect("~/AfterLogin.aspx");
            }
        }

    }

    protected void Newuser_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registration.aspx");
    }
}