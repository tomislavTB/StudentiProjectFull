using System;
using Microsoft.EntityFrameworkCore;
using StudentiProject.Models;

namespace StudentiProject.Extensions
{
    public static class Seeds
    {
        public static void Seed(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            Cities(modelBuilder);
            Colleges(modelBuilder);
            Countries(modelBuilder);
            Courses(modelBuilder);
            Divisions(modelBuilder);
            Executors(modelBuilder);
            Grades(modelBuilder);
            Students(modelBuilder);
            Teachers(modelBuilder);
        }




        public static void Countries(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Croatia" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "United States" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "England" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 5, Name = "Netherlands" });

        }

        public static void Cities(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)


        {

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Velika Gorica", CountryId = 1, Zip = "10000" });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "New York", CountryId = 2, Zip = "10001" });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "London ", CountryId = 4, Zip = "56273" });
            modelBuilder.Entity<City>().HasData(new City { Id = 4, Name = "Paris", CountryId = 3, Zip = "75000" });
            modelBuilder.Entity<City>().HasData(new City { Id = 5, Name = "Amsterdam ", CountryId = 5, Zip = "1011" });
        }


        public static void Colleges(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<College>().HasData(new College { Id = 1, Name = "University of Applied Sciences Velika Gorica", Address = "Zagrebačka ul. 5", CityId = 1 });
            modelBuilder.Entity<College>().HasData(new College { Id = 2, Name = "Columbia University", Address = "1585 Massachusetts Avenue", CityId = 2 });
            modelBuilder.Entity<College>().HasData(new College { Id = 3, Name = "Tehničko veleučilište u Zagrebu", Address = "Vrbik 8", CityId = 1 });
            modelBuilder.Entity<College>().HasData(new College { Id = 4, Name = "University of London", Address = "Senate House Malet Street London", CityId = 3 });
            modelBuilder.Entity<College>().HasData(new College { Id = 5, Name = "Paris Diderot University", Address = "5 Rue Thomas Mann", CityId = 4 });
        }


        public static void Courses(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Course>().HasData(new Course { Id = 1, Name = "Python Course", Description = "Full Python Course", DivisionId = 2 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 2, Name = "SQL Course", Description = "Creating sql database", DivisionId = 2 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 3, Name = "Web Development", Description = "Creating web application", DivisionId = 1 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 4, Name = "Internet Infrastructure", Description = "Full internet infrastructure", DivisionId = 1 });

        }

        public static void Divisions(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Division>().HasData(new Division { Id = 1, Name = "Computer System Maintenance", CollegeId = 1 });
            modelBuilder.Entity<Division>().HasData(new Division { Id = 2, Name = "Computer Science", CollegeId = 2 });

        }
        public static void Executors(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Executor>().HasData(new Executor { Id = 1, Description = "Learning syntax", CourseId = 1, TeacherId = 1 });
            modelBuilder.Entity<Executor>().HasData(new Executor { Id = 2, Description = "Introductory lecture", CourseId = 2, TeacherId = 2 });


        }
        public static void Grades(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 1, ExamTime = "01:30H", Evaluation = 5, CourseId = 1, StudentId = 1 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 2, ExamTime = "01:15H", Evaluation = 4, CourseId = 2, StudentId = 2 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 3, ExamTime = "01:30H", Evaluation = 4, CourseId = 3, StudentId = 3 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 4, ExamTime = "01:00H", Evaluation = 3, CourseId = 4, StudentId = 4 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 5, ExamTime = "01:45H", Evaluation = 2, CourseId = 3, StudentId = 2 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 6, ExamTime = "01:30H", Evaluation = 4, CourseId = 2, StudentId = 3 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 7, ExamTime = "01:15H", Evaluation = 5, CourseId = 1, StudentId = 1 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 8, ExamTime = "01:30H", Evaluation = 3, CourseId = 4, StudentId = 4 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 9, ExamTime = "01:00H", Evaluation = 5, CourseId = 3, StudentId = 1 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 10, ExamTime = "01:45H", Evaluation = 5, CourseId = 1, StudentId = 5 });
        }

        public static void Students(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, FirstName = "Tomislav ", LastName = "Buhovac", CityId = 1, DivisionId = 1 });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 2, FirstName = "Marko ", LastName = "Markic", CityId = 2, DivisionId = 2 });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 3, FirstName = "Ivan ", LastName = "Ivic", CityId = 3, DivisionId = 2 });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 4, FirstName = "Josip ", LastName = "Nesto", CityId = 4, DivisionId = 2 });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 5, FirstName = "Filip ", LastName = "Novi", CityId = 5, DivisionId = 2 });
        }

        public static void Teachers(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Teacher>().HasData(new Teacher { Id = 1, FirstName = "Davor ", LastName = "Znasve", Address = "Nova Cesta 5", CityId = 1 });
            modelBuilder.Entity<Teacher>().HasData(new Teacher { Id = 2, FirstName = "Tomislav ", LastName = "Nestovisezna", Address = "Stara Cesta 4", CityId = 2 });
            modelBuilder.Entity<Teacher>().HasData(new Teacher { Id = 3, FirstName = "Josip ", LastName = "Neznabas", Address = "Novi Put 3", CityId = 3 });
            modelBuilder.Entity<Teacher>().HasData(new Teacher { Id = 4, FirstName = "Ivan ", LastName = "Mozeibolje", Address = "Stari Put 2", CityId = 4 });
            modelBuilder.Entity<Teacher>().HasData(new Teacher { Id = 5, FirstName = "Marko ", LastName = "Voliucit", Address = "Nova Ulica 1", CityId = 5 });

        }
    }
}
