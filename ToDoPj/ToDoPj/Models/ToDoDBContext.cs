namespace ToDoPj.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoDBContext : DbContext
    {
        public ToDoDBContext()
            : base("name=ToDoDB")
        {
        }

        public virtual DbSet<tToDo> DbSettToDo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
