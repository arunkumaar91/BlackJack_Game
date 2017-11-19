using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Blackjack : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string username = Session["username"].ToString(); //  "Mukesh"; //
            using (var context = new Testdata1Entities())
            {
                var a = from u in context.accountdetails
                        where u.user_name == username
                        select u;
                var b = a.FirstOrDefault();
                lbl_cashavail.Text = String.Format("Wallet - $ {0}", b.balance); ;
            }
        }
    }

    protected void btn_bet_Click(object sender, EventArgs e)
    {
        if (!txt_bet.Visible)
        {
            txt_bet.Visible = true;
            txt_bet.Focus();
        }
        else
        {
            string username = Session["username"].ToString(); // "Mukesh"; //"Mukesh"; //
            if (txt_bet.Text == "" || txt_bet.Text == "0" || txt_bet.Text.Contains("-") || txt_bet.Text.Contains("."))
            {
                lbl_caution.Text = "Please enter a valid amount to bet";
                lbl_caution.BackColor = System.Drawing.Color.Red;
                lbl_caution.Font.Bold = true;
            }
            else
            {
                lbl_caution.Text = "";
                int amount = Convert.ToInt32(txt_bet.Text);
                Session["bet"] = txt_bet.Text;
                using (var context = new Testdata1Entities())
                {
                    var a = from u in context.accountdetails
                            where u.user_name == username
                            select u;
                    var b = a.FirstOrDefault();
                    int cashinhand = Convert.ToInt32(b.balance);
                    int newbet = cashinhand - amount;
                    if (newbet >= 0)
                    {
                        b.balance = Convert.ToString(newbet);
                        context.SaveChanges();
                        lbl_raisebet.Text = "Bet $ " + amount;
                        lbl_cashavail.Text = String.Format("Wallet - $ {0}", newbet);
                        enable("bet");
                    }
                    else
                    {
                        lbl_caution.Text = String.Format("Sorry, you cant bet above your wallet limit. Your bet limit is $ {0}", b.balance);
                        lbl_caution.BackColor = System.Drawing.Color.Red;
                    }

                }
            }
        }
    }

    protected void btn_deal_Click(object sender, EventArgs e)
    {

        #region valiidation
        string username = Session["username"].ToString();// "Mukesh;"//
        using (var context = new Testdata1Entities())
        {
            var a = from u in context.accountdetails
                    where u.user_name == username
                    select u;
            var b = a.FirstOrDefault();
            if (b != null)
            {
                //  lbl_cash.Text = b.balance;
                // lbl_cash.ForeColor = System.Drawing.Color.Green;
            }
        }
        int betamount = Convert.ToInt32(txt_bet.Text);
        int dealerpoint = Convert.ToInt32(hdn_point_dealer.Value);
        int playerpoint = Convert.ToInt32(hdn_point_player.Value);
        #endregion

        #region random logic
        var handcard = new List<CardInfo>();
        Random random = new Random();
        using (var context = new Testdata1Entities())
        {

            for (int i = 0; i < 4; i++)
            {
                var a = (from u in context.CardInfoes
                         select u).ToList();
                int index = random.Next(1, a.Count());
                //int[] index = {1, 13};
                if (hdn_dealer_check.Value == "0" && i % 2 == 0)
                {
                    hdn_dealer_check.Value = hdn_dealer_check.Value.ToString() + Convert.ToString(a[index].CardInfoId);
                }

                else if (i % 2 == 0)
                    hdn_dealer_check.Value = hdn_dealer_check.Value.ToString() + "," + Convert.ToString(a[index].CardInfoId);
                if (hdn_card.Value == "" && i % 2 == 1)
                {
                    hdn_card.Value = hdn_card.Value.ToString() + Convert.ToString(a[index].CardInfoId);
                }
                else if (i % 2 == 1)
                    hdn_card.Value = hdn_card.Value.ToString() + "," + Convert.ToString(a[index].CardInfoId);

                var cardrandom = a[index]; // getting the random no n storing the particular card with that random no
                handcard.Add(cardrandom); // adding it to the handcard
                a.Remove(cardrandom); // removing the card from the card list so that card wont repeat again

                #endregion

                #region dealer
                if (i % 2 == 0)
                {
                    if (handcard[i].CardInfoId % 13 == 0 || handcard[i].CardInfoId % 13 > 10)
                    {
                        dealerpoint += 10;
                    }
                    else
                        dealerpoint += handcard[i].CardInfoId % 13;
                    if (i == 2)
                    {
                        // checking if first card is face card and the 2nd card is A and also the vice versa.
                        if (((handcard[0].CardInfoId % 13 == 0 || handcard[0].CardInfoId % 13 > 10) && handcard[2].CardInfoId % 13 == 1)
                            || ((handcard[2].CardInfoId % 13 == 0 || handcard[2].CardInfoId % 13 > 10) && handcard[0].CardInfoId % 13 == 1))
                        {
                            lbl_msg.Text = "Dealer has hit BlackJack";
                            updatescore("dealer");
                            pontstable("dealer", "");

                        }
                    }
                    // adding points depending on the card

                    // if less than 21 we will check for A and add 10 to the points if possible ... note we will add ten only if the point doesnt go over 21
                    if (dealerpoint < 22)
                    {
                        for (int j = 0; j < handcard.Count(); j = j + 2)
                        {
                            if (handcard[j].CardInfoId % 13 == 1 && dealerpoint + 10 < 21)
                            {
                                dealerpoint += 10;
                            }
                        }
                    }
                    else
                    {
                        lbl_msg.Text = "Dealer has been busted";
                        updatescore("player");
                        pontstable("player", "");
                    }
                }
                #endregion

                #region Player
                if (i % 2 == 1)
                {
                    if (handcard[i].CardInfoId % 13 == 0 || handcard[i].CardInfoId % 13 > 10)
                    {
                        playerpoint += 10;
                    }
                    else
                        playerpoint += handcard[i].CardInfoId % 13;
                    // adding points depending on the card
                    if (handcard.Count == 4 && i == 3)
                    {
                        // checking if first card is face card and the 2nd card is A and also the vice versa.
                        if (((handcard[1].CardInfoId % 13 == 0 || handcard[1].CardInfoId % 13 > 10) && handcard[3].CardInfoId % 13 == 1)
                            || ((handcard[3].CardInfoId % 13 == 0 || handcard[3].CardInfoId % 13 > 10) && handcard[1].CardInfoId % 13 == 1))
                        {
                            lbl_msg.Text = "Player has hit BlackJack";
                            updatescore("player");
                            pontstable("player", "blackjack");

                        }
                    }
                    // if less than 21 we will check for A and add 10 to the points if possible ... note we will add ten only if the point doesnt go over 21

                    if (playerpoint < 22)
                    {
                        for (int j = 1; j < handcard.Count(); j = j + 2)
                        {
                            if (handcard[j].CardInfoId % 13 == 1 && playerpoint + 10 < 21)
                            {
                                playerpoint += 10;
                            }
                        }
                    }

                    //else
                    //{
                    //    lbl_msg.Text = "Player has been busted";
                    //    updatescore("dealer");
                    //    pontstable("dealer", "");
                    //}
                }
                #endregion

                hdn_point_dealer.Value = Convert.ToString(dealerpoint);
                lbl_dealerscore.Text = Convert.ToString(dealerpoint);
                hdn_point_player.Value = Convert.ToString(playerpoint);
                lbl_playerscore.Text = String.Format("PlayerScore {0}", playerpoint);
                if (i == 3)
                {
                    imagedisplay("dealers");
                    imagedisplay("player");
                }
            }

        }
        enable("Deal");
    }

    protected void Stand_Click(object sender, EventArgs e)
    {
        int playerpoint = Convert.ToInt32(hdn_point_player.Value);
        int dealerpoint = Convert.ToInt32(hdn_point_dealer.Value);
        imagedisplay("player");
        start:
        if (dealerpoint == 21)
        {
            lbl_msg.Text = "Dealer has hit blackjack. You have lost.";
            updatescore("dealer");
            pontstable("dealer", "");

        }


        else if (playerpoint == 21)
        {
            lbl_msg.Text = "Congragulations!!!! You have hit BlackJack.";
            updatescore("player");
            pontstable("player", "blackjack");

        }
        else if (dealerpoint == playerpoint && dealerpoint < 22)
        {
            lbl_msg.Text = "Push";
            updatescore("push");
            pontstable("push", "");

        }
        else if (dealerpoint > playerpoint && dealerpoint < 22)
        {
            lbl_msg.Text = "Dealer has won. You have lost.";
            updatescore("dealer");
            pontstable("dealer", "");
        }
        else if (dealerpoint > 17 && playerpoint > dealerpoint && playerpoint < 22)
        {
            lbl_msg.Text = "You have won";
            updatescore("player");
            pontstable("player", "");
        }

        else if (dealerpoint < 17 && playerpoint > dealerpoint)
        {
            {
                var handcard = new List<CardInfo>();
                Random random = new Random();
                using (var context = new Testdata1Entities())
                {
                    var a = (from u in context.CardInfoes
                             select u).ToList();
                    again:
                    int index = random.Next(0, a.Count());
                    var cardrandom = a[index]; // getting the random no n storing the particular card with that random no
                    string id = Convert.ToString(a[index].CardInfoId);
                    if (randomcard(id, hdn_dealer_check.Value) == false)
                    {
                        goto again;
                    }
                    hdn_dealer_check.Value = hdn_dealer_check.Value.ToString() + "," + a[index].CardInfoId; // adding image for that card
                    handcard.Add(cardrandom); // adding it to the handcard
                    a.Remove(cardrandom); // removing the card from the card list so that card wont repeat again
                    if (handcard[0].CardInfoId % 13 == 0 || handcard[0].CardInfoId % 13 > 10)
                    {
                        dealerpoint += 10;
                    }
                    else
                        dealerpoint += handcard[0].CardInfoId % 13;
                    // if less than 21 we will check for A and add 10 to the points if possible ... note we will add ten only if the point doesnt go over 21
                    if (dealerpoint < 22)
                    {
                        for (int j = 0; j < handcard.Count(); j = j + 2)
                        {
                            if (handcard[j].CardInfoId % 13 == 1 && dealerpoint + 10 < 21)
                            {
                                dealerpoint += 10;
                            }
                        }
                    }


                    if (dealerpoint < 17 && dealerpoint < playerpoint)
                    {
                        goto start;
                    }
                    if (dealerpoint > 21)
                    {
                        lbl_msg.Text = "You have won";
                        updatescore("player");
                        pontstable("player", "");
                    }
                    if (dealerpoint <= 17 && playerpoint > 17 && playerpoint < 22)
                    {
                        lbl_msg.Text = "You have won";
                        updatescore("player");
                        pontstable("player", "");
                    }

                    if (dealerpoint > 17 && dealerpoint < 22 && dealerpoint > playerpoint)
                    {
                        lbl_msg.Text = "Dealer has won";
                        updatescore("dealer");
                        pontstable("dealer", "");
                    }
                    if (dealerpoint > 22)
                    {
                        lbl_msg.Text = "You have won";
                        updatescore("player");
                        pontstable("player", "");
                    }
                    if (dealerpoint == playerpoint && playerpoint < 22)
                    {
                        lbl_msg.Text = "Push";
                        updatescore("push");
                        pontstable("push", "");
                    }
                }
            }

        }


        imagedisplay("dealer");
        enable("stand");
    }

    protected void btn_hit_Click(object sender, EventArgs e)
    {
        string username = Session["username"].ToString();//"Mukesh"; // 
        int playerpoint = Convert.ToInt32(hdn_point_player.Value);
        using (var context = new Testdata1Entities())
        {
            var a = from u in context.accountdetails
                    where u.user_name == username
                    select u;
            var b = a.FirstOrDefault();
            if (b != null)
            {
                //  lbl_cash.Text = b.balance;
                // lbl_cash.ForeColor = System.Drawing.Color.Green;
            }
        }
        var handcard = new List<CardInfo>();
        Random random = new Random();
        using (var context = new Testdata1Entities())
        {

            var a = (from u in context.CardInfoes
                     select u).ToList();
            again:
            int index = random.Next(0, a.Count());

            var cardrandom = a[index]; // getting the random no n storing the particular card with that random no
            string id = Convert.ToString(a[index].CardInfoId);
            if (randomcard(id, hdn_card.Value) == false)
            {
                goto again;
            }
            hdn_card.Value = hdn_card.Value.ToString() + "," + a[index].CardInfoId; // adding image for that card
            handcard.Add(cardrandom); // adding it to the handcard
            a.Remove(cardrandom); // removing the card from the card list so that card wont repeat again

            imagedisplay("player");
           
            // adding points depending on the card
            if (handcard[0].CardInfoId % 13 == 0 || handcard[0].CardInfoId % 13 > 10)
            {
                playerpoint += 10;
            }
            else
                playerpoint += handcard[0].CardInfoId % 13;
            // if less than 21 we will check for A and add 10 to the points if possible ... note we will add ten only if the point doesnt go over 21
            if (playerpoint < 21)
            {
                for (int j = 0; j < handcard.Count(); j = j + 2)
                {
                    if (handcard[j].CardInfoId % 13 == 1 && playerpoint + 10 < 21)
                    {
                        playerpoint += 10;
                    }
                }
                imagedisplay("dealers");
            }
            else
            {
                lbl_msg.Text = "Player has been busted";
                updatescore("dealer");
                imagedisplay("dealer");
                pontstable("dealer", "");

            }
            hdn_point_player.Value = Convert.ToString(playerpoint);
            lbl_playerscore.Text = String.Format("PlayerScore {0}", playerpoint);
        }
    }

    public void imagedisplay(string who)
    {
        lbl_dealer.Text = "Dealer";
        lbl_player.Text = "Player";
        if (who == "dealer")
        {
            string[] dealercard = hdn_dealer_check.Value.ToString().Split(',');
            int[] dealerinfoid = new int[dealercard.Length];
            for (int i = 0; i < dealercard.Length; i++)
            {
                dealerinfoid[i] = Convert.ToInt32(dealercard[i]);
            }
            using (var context = new Testdata1Entities())
            {
                
                for (int j = 0; j < dealerinfoid.Length;j++)
                {
                    int id = dealerinfoid[j];
                    var a = from u in context.CardInfoes
                            where u.CardInfoId == id
                            select u;
                    var b = a.FirstOrDefault();
                    var img = new Image();
                    img.ImageUrl = b.Image;
                    img.Height = 150;
                    img.Width = 75;
                    DealerPanel.Controls.Add(img);
                }
            }
        }
        else if (who == "dealers")
        {
            string[] dealercard = hdn_dealer_check.Value.Split(',');
            int[] dealerinfoid = new int[dealercard.Length];
            for (int i = 0; i < dealercard.Length; i++)
            {
                dealerinfoid[i] = Convert.ToInt32(dealercard[i]);
            }
            using (var context = new Testdata1Entities())
            {
                var img = new Image();
                img.ImageUrl = "~/Images/black_joker.svg";
                img.Height = 150;
                img.Width = 75;
                DealerPanel.Controls.Add(img);
                for (int j = 1; j < dealerinfoid.Length; j++)
                {
                    int id = dealerinfoid[j];
                    var a = from u in context.CardInfoes
                            where u.CardInfoId == id
                            select u;
                    var b = a.FirstOrDefault();
                    var img1 = new Image();
                    img1.ImageUrl = b.Image;
                    img1.Height = 150;
                    img1.Width = 75;
                    DealerPanel.Controls.Add(img1);
                }
            }
        }
        else if (who == "player")
        {
            string[] playercard = hdn_card.Value.Split(',');
            int[] playerinfoid = new int[playercard.Length];
            for (int i = 0; i < playercard.Length; i++)
            {
                playerinfoid[i] = Convert.ToInt32(playercard[i]);
            }
            using (var context = new Testdata1Entities())
            {
                for (int j = 0; j < playerinfoid.Length; j++)
                {
                    int id = playerinfoid[j];
                    var a = from u in context.CardInfoes
                            where u.CardInfoId == id
                            select u;
                    var b = a.FirstOrDefault();
                    var img = new Image();
                    img.ImageUrl = b.Image;
                    img.Height = 150;
                    img.Width = 75;
                    PlayerPanel.Controls.Add(img);
                }
            }
        }
        
    }

    public bool randomcard(string id, string cardvalue)
    {

        string[] split = cardvalue.Split(',');
        for (int i = 0; i < split.Length; i++)
        {
            if (split[i] == id)
                return false;
        }
        return true;
    }

    public void enable(string val)
    {
        if (val == "bet")
        {
            btn_deal.Enabled = true;
            btn_bet.Enabled = false;
            txt_bet.Visible = false;
        }
        else if (val == "Deal")
        {
            btn_hit.Enabled = true;
            Stand.Enabled = true;
            btn_bet.Enabled = false;
            btn_deal.Enabled = false;
        }
        else if (val == "stand")
        {
            btn_hit.Enabled = false;
            Stand.Enabled = false;
            btn_bet.Enabled = false;
            btn_deal.Enabled = false;
            txt_bet.Visible = false;
        }
        else if (val == "play")
        {
            btn_deal.Enabled = false;
            btn_hit.Enabled = false;
            Stand.Enabled = false;
            playagain.Visible = true;
            txt_bet.Text = "";
        }


    }

    public void updatescore(string val)
    {
        int betamount = Convert.ToInt32(Session["bet"].ToString());
        string username = Session["username"].ToString();
        using (var context = new Testdata1Entities())
        {
            var newa = from u in context.accountdetails
                       where u.user_name == username
                       select u;
            var newb = newa.FirstOrDefault();
            int bal = Convert.ToInt32(newb.balance);
            if (val == "dealer")
                bal = bal - 0;
            else if (val == "player")
                bal = bal + 2 * betamount;
            else
                bal = bal + betamount;
            string final = Convert.ToString(bal);
            lbl_cashavail.Text = String.Format("Wallet - $ {0}", final);
            lbl_cashavail.ForeColor = System.Drawing.Color.Red;
            newb.balance = final;
            context.SaveChanges();

            enable("play");
        }
    }

    protected void playagain_Click(object sender, EventArgs e)
    {
        lbl_playerscore.Text = "";
        lbl_raisebet.Text = "";
        lbl_msg.Text = "";
        lbl_cashavail.ForeColor = System.Drawing.Color.FromArgb(51, 51, 153);
        btn_bet.Enabled = true;
        playagain.Visible = false;
        hdn_point_dealer.Value = "0";
        hdn_point_player.Value = "0";
        hdn_check.Value = "0";
        hdn_count.Value = "52";
        hdn_card.Value = "";
        hdn_dealer_check.Value = "0";
    }

    public void pontstable(string val, string val1)
    {
        string username = Session["username"].ToString();
        using (var context = new Testdata1Entities())
        {
            var prof = new profile();
            prof.user_name = username;
            prof.played = true;
            if (val == "dealer")
            {
                prof.won = false;
                prof.lost = true;
                prof.blackjack = false;
                prof.push = false;
            }
            else if (val == "player")
            {
                prof.won = true;
                prof.lost = true;
                if (val1 == "blackjack")
                    prof.blackjack = true;
                else
                    prof.blackjack = false;
                prof.push = false;
            }
            else if (val == "push")
            {
                prof.won = false;
                prof.lost = false;
                prof.blackjack = false;
                prof.push = true;
            }
            context.profiles.Add(prof);
            context.SaveChanges();
        }
        using (var context1 = new Testdata1Entities())
        {
            user_scores user = new user_scores();
            user.user_name = username;
            user.score = Convert.ToInt32(hdn_point_player.Value.ToString());
            context1.user_scores.Add(user);
            context1.SaveChanges();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

}