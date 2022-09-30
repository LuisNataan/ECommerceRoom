using FluentValidation.Results;

namespace ECommerce.Project.Backend.Application.Commom
{
    public static class Validation
    {
        public static void ThrowExceptionIfFails(this ValidationResult result)
        {
            if (result.IsValid)
            {
                return;
            }
            else
            {
                var errors = new List<Error>();
                foreach (var error in result.Errors)
                {
                    var er = new Error(error.ErrorMessage, error.PropertyName);
                    errors.Add(er);
                }
                throw new Exceptions(errors);
            }
        }
    }
}
