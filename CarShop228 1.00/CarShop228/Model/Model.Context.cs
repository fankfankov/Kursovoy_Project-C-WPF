﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarShop228.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarShopDBEntities : DbContext
    {
        public CarShopDBEntities()
            : base("name=CarShopDBEntities")
        {
        }

        private static CarShopDBEntities _instance;
        public static CarShopDBEntities GetContext()
        {
            if (_instance == null)
                _instance = new CarShopDBEntities();
            return _instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<buying> buying { get; set; }
        public virtual DbSet<car> car { get; set; }
        public virtual DbSet<complectation> complectation { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}