using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Registerbtn_Click(object sender, EventArgs e)
    {
        string username = Usertxt.Text;
        string pwd1 = Pwd1txt.Text;
        string pwd2 = Pwd2txt.Text;
        if (username != "")
        {
            if (pwd1 != pwd2 || pwd1 == "" || pwd2 == "")
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = Color.Red;
                ErrMsg.Text = "Password Mismatch or No password. Try again";
                return;
            }
            using (var context = new Testdata1Entities())
            {
                var check = from u in context.users
                            where u.user_name == username
                            select u;
                var b = check.FirstOrDefault();
                if (b == null)
                {
                    #region Insert UserName
                    user a = new user();
                    a.user_name = username;
                    a.password = pwd1;
                    context.users.Add(a);
                    context.SaveChanges();
                    Regislabel.Text = "Registration Completed succesfully";
                    Regislabel.ForeColor = Color.Green;
                    Response.Redirect("~/Login.aspx");
                    #endregion Insert UserName
                }
                else
                {
                    #region UserName already exists
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = Color.Red;
                    ErrMsg.Text = "User Name already exists.";
                    return;
                    #endregion UserName already exists
                }
            }
            ErrMsg.Visible = false;
        }
        else
        {
            #region Invalid Password
            ErrMsg.Visible = true;
            ErrMsg.ForeColor = Color.Red;
            ErrMsg.Text = "Please enter a valid Password";
            #endregion Invalid Password

        }
    }
}