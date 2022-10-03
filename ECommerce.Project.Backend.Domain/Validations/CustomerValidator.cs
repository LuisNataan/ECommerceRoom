using ECommerce.Project.Backend.Domain.Entities;
using FluentValidation;

namespace ECommerce.Project.Backend.Domain.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private readonly string _stringRule = "^[0-9a-zA-Z\\s]+$";  //áàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ^[a-zA-Z\s]*$
        private readonly string _numberRule = "^[0-9]+$";

        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(4, 60).WithMessage("Name must be 4 to 60 characters long.")
                .Matches(_stringRule).WithMessage("Name has invalid characters.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .Length(12, 60).WithMessage("Email must have 12 to 60 characters.")
                .EmailAddress().WithMessage("Invali email address. Ex: example@examroom.ai");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .Length(12, 12).WithMessage("Phone number must be 12 characters long.")
                .Matches(_numberRule).WithMessage("Phone number has invalid characters.");
        }
    }
}
