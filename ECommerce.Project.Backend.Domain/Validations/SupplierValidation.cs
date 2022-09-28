using ECommerce.Project.Backend.Domain.Entities;
using FluentValidation;

namespace ECommerce.Project.Backend.Domain.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        private readonly string _supplierName = "^[0 - 9 a - zA - ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ] +$";
        private readonly string _numberRule = "^[0 - 9] + $";

        public SupplierValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(4, 50).WithMessage("Name must be 4 to 50 characters long.")
                .Matches(_supplierName).WithMessage("Name has invalid characters.");

            RuleFor(s => s.CorporateName)
                .NotEmpty().WithMessage("Corporate Name cannot be empty.")
                .Length(4, 50).WithMessage("Corporate Name must be 4 to 50 characters long.")
                .Matches(_supplierName).WithMessage("Corporate Name has invalid characters");

            RuleFor(s => s.PhoneNumber)
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .Length(11, 11).WithMessage("Phone number mus be 11 characters long.")
                .Matches(_numberRule).WithMessage("Phone number has invalid characters.");
            
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .Length(12, 60).WithMessage("Email must be 12 to 60 characters long.")
                .EmailAddress().WithMessage("Invalid email address. Ex: example@examroom.ai");

            RuleFor(s => s.EinNumber)
                .NotEmpty().WithMessage("EIN Number cannot be empty.");
        }
    }
}
