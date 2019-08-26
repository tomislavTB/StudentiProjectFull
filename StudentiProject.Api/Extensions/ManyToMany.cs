
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentiProject.Models;

namespace StudentiProject.Extensions
{
    public static class ManyToMany
    {

        public static void ManyToManySetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            Executor(modelBuilder);
            Grade(modelBuilder);
        }



        private static void Executor(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<Executor>()
                    .HasOne<Course>(sc => sc.Course)
                    .WithMany(s => s.Executors)
                    .HasForeignKey(sc => sc.CourseId);


            modelBuilder.Entity<Executor>()
                    .HasOne<Teacher>(sc => sc.Teacher)
                    .WithMany(s => s.Executors)
                    .HasForeignKey(sc => sc.TeacherId);
        }
         private static void Grade(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
         { 

            modelBuilder.Entity<Grade>()
                   .HasOne<Course>(sc => sc.Course)
                   .WithMany(s => s.Grades)
                   .HasForeignKey(sc => sc.CourseId);


            modelBuilder.Entity<Grade>()
                    .HasOne<Student>(sc => sc.Student)
                    .WithMany(s => s.Grades)
                    .HasForeignKey(sc => sc.StudentId);
         }
    }
}
