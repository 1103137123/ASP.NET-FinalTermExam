namespace ASP.NET_FinalTermExam.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeTableDB : DbContext
    {
        public CodeTableDB()
            : base("name=CodeTableDB")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
