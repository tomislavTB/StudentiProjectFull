using System;
using System.ComponentModel.DataAnnotations;

namespace PubQuiz.Models.Attributes
{
    public class CustomRange : RangeAttribute
    {
        public CustomRange(double minimum, double maximum) : base(minimum, maximum)
        { }

        public CustomRange(Type type, string minimum, string maximum) : base(type, minimum, maximum)
        { }

        public override string FormatErrorMessage(string name)
        {
            return $"\"{name}\" ograničen od {Minimum} do {Maximum}";
        }
    }
}

