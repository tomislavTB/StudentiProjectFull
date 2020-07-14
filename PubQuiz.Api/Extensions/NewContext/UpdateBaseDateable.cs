using Microsoft.EntityFrameworkCore;
using PubQuiz.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubQuiz.Extensions.NewContext
{
    public static class UpdateBaseDateableExtension
    {
        public static void UpdateBaseDateable(this DB.PubQuizContext context)
        {
            var entries = context.ChangeTracker.Entries();
            foreach (var entry in entries.Where(entry => entry.Entity is NewBaseDateable).Select(entry => entry))
            {
                var entity = (NewBaseDateable)entry.Entity;
                var now = DateTime.UtcNow;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entity.LastModifiedAt = now;
                        break;
                    case EntityState.Added:
                        entity.CreatedAt = now;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
