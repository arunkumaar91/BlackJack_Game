﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class Testdata1Entities : DbContext
{
    public Testdata1Entities()
        : base("name=Testdata1Entities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Datum> Data { get; set; }
    public virtual DbSet<user> users { get; set; }
    public virtual DbSet<accountdetail> accountdetails { get; set; }
    public virtual DbSet<profile> profiles { get; set; }
    public virtual DbSet<user_scores> user_scores { get; set; }
    public virtual DbSet<CardInfo> CardInfoes { get; set; }
    public virtual DbSet<Card> Cards { get; set; }
    public virtual DbSet<Game> Games { get; set; }
}
