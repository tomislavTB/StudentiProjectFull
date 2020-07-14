using PubQuiz.Models;

namespace PubQuiz.Extensions.ModelBuilder
{
    public static class ModelBuilderValidation
    {
        public static void ValidationSetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            User(modelBuilder);
        }

        private static void User(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Teacher>()
              //   .HasIndex(p => new { p.FirstName, p.LastName, p.Address })
               // .IsUnique(true);


        }
    }
}
