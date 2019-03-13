using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Models.Context
{
    public class ClothesLine_FN_Context : DbContext
    {
        public ClothesLine_FN_Context() : base("ClothesLine_FN")
        {

        }

        public DbSet<MasterCategory> MasterCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<DestinationPlace> DestinationPlaces { get; set; }
        public DbSet<MansProduct> MansProducts { get; set; }
        public DbSet<WomansProduct> WomansProducts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TourPackege> TourPackeges { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MansProduct>()
                .HasRequired(d => d.Colour)
                .WithMany(w => w.MansProducts)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MansProduct>()
                    .HasRequired(d => d.Size)
                    .WithMany(w => w.MansProducts)
                    .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WomansProduct>()
                    .HasRequired(d => d.Colour)
                    .WithMany(w => w.WomansProducts)
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<WomansProduct>()
                    .HasRequired(d => d.Size)
                    .WithMany(w => w.WomansProducts)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<DestinationPlace>()
        .HasRequired(d => d.Category)
        .WithMany(w => w.DestinationPlaces)
        .WillCascadeOnDelete(false);

            modelBuilder.Entity<TourPackege>()
          .HasRequired(d => d.DestinationPlace)
          .WithMany(w => w.TourPackeges)
          .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }


        public void DisableLazy()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public void EnableLazy()
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
    }


}