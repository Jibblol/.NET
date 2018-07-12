using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameAPI.Models
{
    public partial class WhatsThatGameProdContext : DbContext
    {
        public WhatsThatGameProdContext()
        {
        }

        public WhatsThatGameProdContext(DbContextOptions<WhatsThatGameProdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
