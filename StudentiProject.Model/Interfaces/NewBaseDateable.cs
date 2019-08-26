using StudentiProject.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentiProject.Models.Interfaces
{
    public interface NewBaseDateable
    {
        [DataType(DataType.DateTime)]
        [CustomRequired]
        [CustomDateRange]
        DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [CustomDateRange]
        DateTime? LastModifiedAt { get; set; }
    }
}

