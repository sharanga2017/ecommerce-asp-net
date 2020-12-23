namespace Bdd.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyBdd : DbContext
    {
        public MyBdd()
            : base("name=MyBdd")
        {
        }

        public virtual DbSet<bd> bds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bd>()
                .Property(e => e._ref)
                .IsUnicode(false);

            modelBuilder.Entity<bd>()
                .Property(e => e.resume)
                .IsUnicode(false);
        }
    }
}
