using Newtonsoft.Json;
using PubQuiz.Models.Attributes;
using PubQuiz.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace PubQuiz.Models
{
     public abstract class BaseModel : NewBaseDateable, NewSoftDeletable

    {
        public int Id { get; set; }

        // modified in ApplicationContext
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        // Inherited from SoftDeletable
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;
    }
}


