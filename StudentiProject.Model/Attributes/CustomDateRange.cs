using StudentiProject.Models.Attributes;
using System;

namespace StudentiProject.Models.Attributes
{
    public class CustomDateRange : CustomRange
    {
        public CustomDateRange()
          : base(typeof(DateTime),
                  DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc).ToShortDateString(),
                  DateTime.UtcNow.ToShortDateString())
        { }
    }
}

