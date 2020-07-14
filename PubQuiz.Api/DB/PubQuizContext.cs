using PubQuiz.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using PubQuiz.Extensions;
using System;
using PubQuiz.Extensions.ModelBuilder;
using PubQuiz.Models.Interfaces;
using PubQuiz.Extensions.NewContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PubQuiz.Model.Users;

namespace PubQuiz.DB
{
    public class PubQuizContext : IdentityDbContext<AuthUser, IdentityRole<int>, int>
    {
        public PubQuizContext(DbContextOptions<PubQuizContext> options)
            : base(options)
        { }

        public DbSet<City> Cities { get; set; }
        public DbSet<NoticeBoard> NoticeBoards { get; set; }
        public DbSet<QuizTheme> QuizThemes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Champion> Champion { get; set; }


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