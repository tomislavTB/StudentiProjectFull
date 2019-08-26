using StudentiProject.Models;
using System.Reflection;

namespace StudentiProject.Extensions
{
    public static class SoftDeleteSetupExtension
    {
        public static void SoftDeleteSetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            SetupQueryFilter<City>(modelBuilder);
            SetupQueryFilter<College>(modelBuilder);
            SetupQueryFilter<Country>(modelBuilder);
            SetupQueryFilter<Course>(modelBuilder);

            SetupQueryFilter<Division>(modelBuilder);
            SetupQueryFilter<Executor>(modelBuilder);
            SetupQueryFilter<Grade>(modelBuilder);
            SetupQueryFilter<Student>(modelBuilder);
            SetupQueryFilter<Teacher>(modelBuilder);
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