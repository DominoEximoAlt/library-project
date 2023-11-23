using System;
using System.ComponentModel.DataAnnotations;

namespace Library2.Shared
{
    public class TodayAttribute : ValidationAttribute
    {
        public TodayAttribute() {}

        public string GetErrorMessage() => "Date must be today or later";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (DateTime.Compare(date, DateTime.Today) >= 0) return ValidationResult.Success ;
            else return new ValidationResult(GetErrorMessage());
        }
    }
}