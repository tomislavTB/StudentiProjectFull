using PubQuiz.Models;
using System.Reflection;

namespace PubQuiz.Extensions
{
    public static class SoftDeleteSetupExtension
    {
        public static void SoftDeleteSetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            SetupQueryFilter<City>(modelBuilder);
            SetupQueryFilter<NoticeBoard>(modelBuilder);
            SetupQueryFilter<Country>(modelBuilder);
            SetupQueryFilter<QuizTheme>(modelBuilder);
            SetupQueryFilter<Champion>(modelBuilder);
        }

        private static void SetupQueryFilter<TEntity>(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
            where TEntity : BaseModel
        {
            if (typeof(BaseModel).GetTypeInfo().IsAssignableFrom(typeof(TEntity).Ge‌​tTypeInfo()))
            {
                modelBuilder.Entity<TEntity>().HasQueryFilter(temp => !temp.IsDeleted);
            }
        }
    }
} 