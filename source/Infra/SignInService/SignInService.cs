using DotNetCore.Extensions;
using DotNetCore.Objects;
using DotNetCore.Security;
using DotNetCoreArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DotNetCoreArchitecture.Infra
{
    public class SignInService : ISignInService
    {
        private readonly IHashService _hashService;
        private readonly IJsonWebTokenService _jsonWebTokenService;

        public SignInService
        (
            IHashService hashService,
            IJsonWebTokenService jsonWebTokenService
        )
        {
            _hashService = hashService;
            _jsonWebTokenService = jsonWebTokenService;
        }

        public SignInModel CreateSignIn(SignInModel signInModel)
        {
            var salt = Guid.NewGuid().ToString();
            return new SignInModel
            {
                Login = signInModel.Login,
                Salt = salt,
                Password = _hashService.Create(signInModel.Password, salt)
            };
        }

        public TokenModel CreateToken(SignedInModel signedInModel)
        {
            var claims = new List<Claim>();

            claims.AddSub(signedInModel.Id.ToString());

            claims.AddRoles(signedInModel.Roles.ToString().Split(", "));

            var token = _jsonWebTokenService.Encode(claims);

            return new TokenModel(token);
        }

        public IResult Validate(SignedInModel signedInModel, SignInModel signInModel)
        {
            if (signedInModel == default || signInModel == default)
            {
                return Result.Fail("Логін або пароль введено не вірно.");
            }

            var password = _hashService.Create(signInModel.Password, signedInModel.SignIn.Salt);

            if (signedInModel.SignIn.Password != password)
            {
                return Result.Fail("Логін або пароль введено не вірно.");
            }

            return Result.Success();
        }
    }
}
