﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class demoEntities : DbContext
    {
        public demoEntities()
            : base("name=demoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<activity> activity { get; set; }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<@event> @event { get; set; }
        public virtual DbSet<moderator> moderator { get; set; }
        public virtual DbSet<organization> organization { get; set; }
    }
}