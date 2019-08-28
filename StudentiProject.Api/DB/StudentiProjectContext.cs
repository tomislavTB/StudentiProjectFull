using StudentiProject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using StudentiProject.Extensions;
using System;
using StudentiProject.Extensions.ModelBuilder;
using StudentiProject.Models.Interfaces;
using StudentiProject.Extensions.NewContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using StudentiProject.Model.Users;

namespace StudentiProject.DB
{
    public class StudentiProjectContext : IdentityDbContext<AuthUser, IdentityRole<int>, int>
    {
        public StudentiProjectContext(DbContextOptions<StudentiProjectContext> options)
            : base(options)
        { }

        public DbSet<City> Cities { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            OnBeforeOnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);




        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }




        private void OnBeforeOnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ValidationSetup();
            modelBuilder.ManyToManySetup();
            modelBuilder.Seed();
            modelBuilder.SoftDeleteSetup();


        }

        private void OnBeforeSaving()
        {
            this.UpdateBaseDateable();
            this.UpdateSoftDeletable();

        }

       
       


    }
}