using System.ComponentModel.DataAnnotations;

namespace StudentiProject.Models.Attributes
{
    public class CustomRequired : RequiredAttribute
    {
        public CustomRequired()
        { }

        public override string FormatErrorMessage(string name)
        {
            return $"\"{name}\" je obavezan!";
        }
    }
}

