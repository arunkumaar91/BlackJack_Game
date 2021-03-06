﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class accountdetail
{
    public string user_name { get; set; }
    public string balance { get; set; }
}

public partial class Card
{
    public int CardId { get; set; }
    public Nullable<int> CardInfoId { get; set; }
    public Nullable<int> Deck { get; set; }
    public Nullable<bool> IsAvailable { get; set; }

    public virtual CardInfo CardInfo { get; set; }
}

public partial class CardInfo
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public CardInfo()
    {
        this.Cards = new HashSet<Card>();
    }

    public int CardInfoId { get; set; }
    public Nullable<int> PokerOrder { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Card> Cards { get; set; }
}

public partial class Datum
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Int1 { get; set; }
    public int Int2 { get; set; }
    public int Int3 { get; set; }
    public int Int4 { get; set; }
    public int Int5 { get; set; }
    public int Int6 { get; set; }
    public int Int7 { get; set; }
    public int Int8 { get; set; }
    public int Int9 { get; set; }
    public string String1 { get; set; }
    public string String2 { get; set; }
    public string String3 { get; set; }
    public string String4 { get; set; }
    public string String5 { get; set; }
    public string String6 { get; set; }
    public string String7 { get; set; }
    public string String8 { get; set; }
    public string String9 { get; set; }
}

public partial class Game
{
    public int GameId { get; set; }
    public bool GameState { get; set; }
    public int PlayerCount { get; set; }
}

public partial class profile
{
    public int Id { get; set; }
    public string user_name { get; set; }
    public bool played { get; set; }
    public bool won { get; set; }
    public bool lost { get; set; }
    public bool blackjack { get; set; }
    public Nullable<bool> push { get; set; }
}

public partial class user
{
    public int userid { get; set; }
    public string user_name { get; set; }
    public string password { get; set; }
}

public partial class user_scores
{
    public int Id { get; set; }
    public string user_name { get; set; }
    public int score { get; set; }
}
