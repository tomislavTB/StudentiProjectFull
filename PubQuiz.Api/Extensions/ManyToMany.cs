
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PubQuiz.Models;

namespace PubQuiz.Extensions
{
    public static class ManyToMany
    {

        public static void ManyToManySetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            NoticeBoard(modelBuilder);

        }

        private static void NoticeBoard(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NoticeBoard>()
                .HasOne(bc => bc.City)
                .WithMany(b => b.NoticeBoards)
                .HasForeignKey(bc => bc.CityId);
            modelBuilder.Entity<NoticeBoard>()
                .HasOne(bc => bc.Country)
                .WithMany(c => c.NoticeBoards)
                .HasForeignKey(bc => bc.CoutryId);
            modelBuilder.Entity<NoticeBoard>()
                .HasOne(bc => bc.QuizTheme)
                .WithMany(c => c.NoticeBoards)
                .HasForeignKey(bc => bc.QuizThemeId);

        }


        private static void Champion(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Champion>()
                .HasOne(bc => bc.NoticeBoard)
                .WithMany(b => b.Champions)
                .HasForeignKey(bc => bc.NoticeBoardId);
        }
    }
}
