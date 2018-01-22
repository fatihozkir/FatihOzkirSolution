using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.DataAccess.Concrete.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("name=ProjectContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
			
        }

        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>()
                .HasMany(e => e.UserSkills)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSkills)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
