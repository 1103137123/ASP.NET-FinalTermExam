namespace ASP.NET_FinalTermExam.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KuasDB : DbContext
    {
        public KuasDB()
            : base("name=KuasDB")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
