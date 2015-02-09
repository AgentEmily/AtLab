namespace Model_Category.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthwindModel : DbContext
    {
        public NorthwindModel()
            : base("name=NorthwindModel1")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
