using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public class UserModelValidator<T> : Validator<T> where T : UserModel
    {
        protected UserModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
