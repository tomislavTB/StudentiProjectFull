using Microsoft.EntityFrameworkCore;
using PubQuiz.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubQuiz.Extensions.NewContext
{
    public static class UpdateSoftDeletableExtension
    {
        public static void UpdateSoftDeletable(this DB.PubQuizContext context)
        {
            var entries = context.ChangeTracker.Entries();
            foreach (var entry in entries.Where(entry => entry.Entity is NewSoftDeletable).Select(entry => entry))
            {
                var entity = (NewSoftDeletable)entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.IsDeleted = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entity.IsDeleted = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
