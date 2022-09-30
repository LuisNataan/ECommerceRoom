using ECommerce.Project.Backend.Domain.ComplexTypes;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ECommerce.Project.Backend.Domain.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        private readonly string _stringRule = "^[0 - 9 a - zA - ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ] +$";
        private readonly string _stateAbbreviationRule = "^[A - Z]+$";
        private readonly string _numberRule = "^[0 - 9] + $";
        private readonly string _usZipCode = @"^\d{5}(?:[-\s]\d{4})?$";

        public AddressValidator()
        {
            RuleFor(a => a.City)
                .NotEmpty().WithMessage("City cannot be empty.")
                .Length(4, 60).WithMessage("City must be 4 to 60 characters long.")
                .Matches(_numberRule).WithMessage("City has invalid characters.");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("State cannot be empty.")
                .Length(2, 2).WithMessage("State is 2 characters long.")
                .Matches(_stateAbbreviationRule).WithMessage("State has invalid characters.");

            RuleFor(a => a.StreetName)
                .NotEmpty().WithMessage("Street name cannot be empty.")
                .Length(4, 60).WithMessage("Street name must be 4 to 60 characters long.")
                .Matches(_stringRule).WithMessage("Street name has invalid characters.");

            RuleFor(a => a.Number)
                .NotEmpty().WithMessage("Number cannot be empty.")
                .Length(1, 99999)
                .Matches(_numberRule).WithMessage("Number has invalid characters.");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("Zip Code cannot be empty.")
                .Length(6, 6).WithMessage("Zip Code must be 6 characters long.")
                .Must(IsValidZipCode).WithMessage("Invalid Zip Code.");
        }

        internal bool IsValidZipCode(string zipCode)
        {
            var validZipCode = true;
            if (!Regex.Match(zipCode, _usZipCode).Success)
            {
                validZipCode = false;
            }
            return validZipCode;
        }
    }
}
