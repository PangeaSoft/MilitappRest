﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MilitappRest.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using MilitappRest.Entities;
    
    public partial class MilitappBDConnection : DbContext
    {
        public MilitappBDConnection()
            : base("name=MilitappBDConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbcandidato> tbcandidato { get; set; }
        public DbSet<tbcargo> tbcargo { get; set; }
        public DbSet<tbcomuna> tbcomuna { get; set; }
        public DbSet<tbeleccion> tbeleccion { get; set; }
        public DbSet<tbescuela> tbescuela { get; set; }
        public DbSet<tbfiscal> tbfiscal { get; set; }
        public DbSet<tblista> tblista { get; set; }
        public DbSet<tblistacandidatocargo> tblistacandidatocargo { get; set; }
        public DbSet<tblistacargo> tblistacargo { get; set; }
        public DbSet<tbmesa> tbmesa { get; set; }
        public DbSet<tbplanilla> tbplanilla { get; set; }
        public DbSet<tbplanillacargo> tbplanillacargo { get; set; }
        public DbSet<tbresultado> tbresultado { get; set; }
        public DbSet<tbsistema> tbsistema { get; set; }
    }
}