using System;
using Microsoft.EntityFrameworkCore;
using PubQuiz.Models;

namespace PubQuiz.Extensions
{
    public static class Seeds
    {
        public static void Seed(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            Cities(modelBuilder);
            NoticeBoard(modelBuilder);
            Countries(modelBuilder);
            QuizTheme(modelBuilder);

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


        public static void NoticeBoard(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<NoticeBoard>().HasData(new NoticeBoard { Id = 1, Name = "kvz od 100 sudionika jdhasudhasjd", DateWhen = new DateTimeOffset(2008, 5, 1, 8, 6, 32, 545, new TimeSpan(1, 0, 0)), CityId = 1, CountryId = 1, QuizThemeId = 1, AuthUserId = 1 });
            modelBuilder.Entity<NoticeBoard>().HasData(new NoticeBoard { Id = 2, Name = "nasjkbdcjsdkbfcjksdbcvjbsdvjcbsdjkb", DateWhen = new DateTimeOffset(2008, 5, 1, 8, 6, 32, 545, new TimeSpan(1, 0, 0)), CityId = 2, CountryId = 1, QuizThemeId = 1, AuthUserId = 1 });
            modelBuilder.Entity<NoticeBoard>().HasData(new NoticeBoard { Id = 3, Name = "hjdgbdasndbhjasdgbbzbdajn jikghdjnasjkdnasuji", DateWhen = new DateTimeOffset(2008, 5, 1, 8, 6, 32, 545, new TimeSpan(1, 0, 0)), CityId = 1, CountryId = 1, QuizThemeId = 1, AuthUserId = 1 });
            modelBuilder.Entity<NoticeBoard>().HasData(new NoticeBoard { Id = 4, Name = "hjdbashjdbsbbbdasjkd nhjbdasjkndasb dashjdbasjkd", DateWhen = new DateTimeOffset(2008, 5, 1, 8, 6, 32, 545, new TimeSpan(1, 0, 0)), CityId = 3, CountryId = 1, QuizThemeId = 1, AuthUserId = 1 });
            modelBuilder.Entity<NoticeBoard>().HasData(new NoticeBoard { Id = 5, Name = "jasdbashjkdbashjk d asdasdjiabhndjas dhjasdbnhasd ", DateWhen = new DateTimeOffset(2008, 5, 1, 8, 6, 32, 545, new TimeSpan(1, 0, 0)), CityId = 4, CountryId = 1, QuizThemeId = 1, AuthUserId = 1 });
        }
        public static void QuizTheme(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 1, Name = "Science fiction",  });
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 2, Name = "Books",  });
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 3, Name = "TV shows",  });
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 4, Name = "Movies",  });
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 5, Name = "Techonolgy",  });
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 6, Name = "Programming",  });
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 7, Name = "Geography",  });
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 8, Name = "History",  });
            modelBuilder.Entity<QuizTheme>().HasData(new QuizTheme { Id = 9, Name = "Games",  });
        }

        public static void Champion(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Champion>().HasData(new Champion { Id = 1, Name = "tomi@gmail.com", NoticeBoardId = 1});
            modelBuilder.Entity<Champion>().HasData(new Champion { Id = 2, Name = "slavko@gmail.com", NoticeBoardId = 2 });
            modelBuilder.Entity<Champion>().HasData(new Champion { Id = 3, Name = "marko@gmail.com", NoticeBoardId = 1});
            modelBuilder.Entity<Champion>().HasData(new Champion { Id = 4, Name = "sjiksdjha@gmail.com", NoticeBoardId = 2});
            modelBuilder.Entity<Champion>().HasData(new Champion { Id = 5, Name = "toddi@gmail.com", NoticeBoardId = 1});
            modelBuilder.Entity<Champion>().HasData(new Champion { Id = 6, Name = "tomeee@gmail.com", NoticeBoardId = 2});
        }
    }
}
