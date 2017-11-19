using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AfterLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
        lbl.Text = Session["username"].ToString() + ", you have logged in successfully.";
        using (var context = new Testdata1Entities())
        {
            var a = (from u in context.user_scores
                     orderby u.score descending
                     select u).Take(10).ToList();
            ScoreGrid.DataSource = a;
            ScoreGrid.DataBind();
        }
    }

    protected void btn_play_Click(object sender, EventArgs e)
    {
        using (var context = new Testdata1Entities())
        {
            string username = Session["username"].ToString();
            var a = from u in context.accountdetails
                    where u.user_name == username
                    select u;
            var b = a.FirstOrDefault();
            if (b != null)
            {
                if (b.balance != "0")
                    Response.Redirect("~/BlackJack.aspx");
                else
                    lbl_err.Text = "Your wallet is empty. Please add cash to your profile before proceeding.";
            }

            else
            {
                lbl_err.Text = "You wallet is empty. Please add cash to your profile";
            }
        }

    }

    protected void btn_profile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserProfile.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/Login.aspx");
    }
}