using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            scorecard();
        }
        string redirect = Session["redirect"].ToString();
        if (redirect == "success")
        {
            Paymentclick("Reload");
            Session["redirect"] = "";
            Successlbl.Text = "Your wallet has been succesfully credited with $" + Session["amount"].ToString();
            Successlbl.BackColor = System.Drawing.Color.Red;
            play.Visible = true;
        }
        txt_amt.Focus();

    }

    protected void changepwdbtn_Click(object sender, EventArgs e)
    {
        string oldpwd = oldpwdtxt.Text;
        string newpwd = newpwdtxt.Text;
        string renewpwd = repwdtxt.Text;
        string username = Session["username"].ToString();
        if (oldpwd == "" || newpwd == "" || renewpwd == "")
        {
            msglbl.Text = "Password cannot be empty";
            msglbl.BackColor = System.Drawing.Color.Red;
            return; 
        }
        using (var context = new Testdata1Entities())
        {
            var a = from u in context.users
                    where u.password == oldpwd && u.user_name == username
                    select u;
            var b = a.FirstOrDefault();
            if (b != null)
            {
                if (newpwd == renewpwd)
                {
                    b.password = newpwd;
                    context.SaveChanges();
                    msglbl.Text = "Your password has been changed.";
                    msglbl.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    msglbl.Text = "Password mismatch.";
                    msglbl.BackColor = System.Drawing.Color.Red;

                }
            }
            else if (b == null)
            {
                msglbl.Text = "Incorrect existing password.";
                msglbl.BackColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        tbl_bal.Visible = false;
        scorecard();
    }

    public void scorecard()
    {
        tbl_sc.Visible = true;
        tbl_cp.Visible = false;
        string username = Session["username"].ToString();
        int played = 0;
        int won = 0;
        int blackjack = 0;
        int lost = 0;
        int push = 0;
        using (var context = new Testdata1Entities())
        {
            var a = (from u in context.profiles
                     where u.user_name == username
                     select u).ToList();

            foreach(var c in a)
            {
                if (c.won)
                    won++;
                if (c.blackjack)
                    blackjack++;
                if (c.push == true)
                    push++;
                played++;

            }
        }
        lost = played - won -push;
        playedlbl.Text = played + "";
        wonlbl.Text = won + "";
        lostlbl.Text = lost + "";
        blackjacklbl.Text = blackjack + "";
        usernamelbl.Text = username;
        puslbl.Text = push + "";    
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        tbl_cp.Visible = true;
        tbl_sc.Visible = false;
        tbl_bal.Visible = false;
    }

    protected void Payment_Click(object sender, EventArgs e)
    {
        Paymentclick("button");
    }

    public void Paymentclick(string val)
    {
        string username = Session["username"].ToString();
        tbl_bal.Visible = true;
        tbl_cp.Visible = false;
        tbl_sc.Visible = false;

        using (var context = new Testdata1Entities())
        {
            var a = from u in context.accountdetails
                    where u.user_name == username
                    select u;
            lbl_username.Text = username;
            var b = a.FirstOrDefault();
            if (b != null)
            {
                string c = "";
                if (val == "button")
                    bal_lbl.Text =  b.balance;
                else if (val == "Reload")
                {
                    c = Session["amount"].ToString();
                    bal_lbl.Text = c ;
                }
            }
            else
            {
                bal_lbl.Text = "0";
                bal_lbl.BackColor = System.Drawing.Color.Red;
                err_lbl.Text = "You dont have adequate fund to continue playing.Please load your wallet instantly";
                
            }

        }
        

    }

    protected void AddCash_Click(object sender, EventArgs e)
    {
        if (txt_amt.Text == "" || txt_amt.Text=="0")
        {
            Caution.Text = "Please enter a valid amount to be added.";
            Caution.BackColor = System.Drawing.Color.Red;

        }
        else
        {
            Session["amount"] = txt_amt.Text;
            Response.Write("<script>");
            Response.Write("window.open('Payment.aspx','_parent')");
            Response.Write("</script>");
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

    protected void play_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Blackjack.aspx");
    }
}