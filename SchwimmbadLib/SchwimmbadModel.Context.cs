﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchwimmbadLib
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchwimmbadModelContainer : DbContext
    {
        public SchwimmbadModelContainer()
            : base("name=SchwimmbadModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Schwimmbahn> SchwimmbahnSet { get; set; }
        public virtual DbSet<Buchung> BuchungSet { get; set; }
        public virtual DbSet<Gast> GastSet { get; set; }
    }
}
