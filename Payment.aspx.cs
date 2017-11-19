using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        paymentpanel.Visible = true;
        List<int> month = new List<int>();
        List<int> year = new List<int>();
        for (int i = 1; i < 13; i++)
        {
            month.Add(i);
        }
        monthddl.DataSource = month;
        monthddl.DataBind();
        DateTime dt = DateTime.Now;
        int a = dt.Year;
        for (int j = a; j < a + 50; j++)
        {
            year.Add(j);
        }
        yearddl.DataSource = year;
        yearddl.DataBind();

    }

    protected void visaimage_Click(object sender, ImageClickEventArgs e)
    {
        tbl_pay.Visible = true;
        cardlbl.Text = "Visa Card Number";
        cardlbl.Font.Bold = true;

    }

    protected void masterimage_Click(object sender, ImageClickEventArgs e)
    {
        tbl_pay.Visible = true;
        cardlbl.Text = "Master Card Number";
        cardlbl.Font.Bold = true;
    }

    protected void Proceedbtn_Click(object sender, EventArgs e)
    {
        #region Error-Validation
        if (cardnotxt.Text.Length != 16)
        {
            cautionlbl.Text = "Invalid card number.Please enter the 16 digit card number again.";
            cautionlbl.ForeColor = Color.Red;
            return;
        }
        if (cvvtxt.Text.Length != 3)
        {
            cautionlbl.Text = "Invalid cvv number.Please enter the 3 digit cvv number again.";
            cautionlbl.ForeColor = Color.Red;
            return;
        }
        if (nametxt.Text.Length == 0)
        {
            cautionlbl.Text = "Please enter a valid name.";
            cautionlbl.ForeColor = Color.Red;
            return;
        }

        char[] cardno = cardnotxt.Text.ToCharArray();
        int length = cardno.Length;
        for (int i = 0; i < length; i++)
        {

            if (!char.IsDigit(cardno[i]))
            {
                cautionlbl.Text = "Only number is allowed in card number.";
                cautionlbl.ForeColor = Color.Red;
                return;
            }
        }
        #endregion

        #region logica-part
        int amount = Convert.ToInt32(Session["amount"].ToString());
        string username = Session["username"].ToString();
        using (var context = new Testdata1Entities())
        {
            string cash = "";
            var a = from u in context.accountdetails
                    where u.user_name == username
                    select u;
            var b = a.FirstOrDefault();
            if (b != null)
            {
                cash = (Convert.ToInt32(b.balance) + amount).ToString();
                b.balance = cash;
                
                context.SaveChanges();
                Session["amount"] = cash;
            }
            else
            {
                cash = amount.ToString();
                accountdetail d = new accountdetail();
                d.balance = cash;
                d.user_name = username;
                context.accountdetails.Add(d);
                context.SaveChanges();
            }

        }
        Session["redirect"] = "success";
        Response.Write("<script>");
        Response.Write("window.open('UserProfile.aspx','_parent')");
        Response.Write("</script>");
        #endregion

    }
}