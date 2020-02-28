using DotNetCoreArchitecture.Model;
using Model;

namespace DotNetCoreArchitecture.Domain
{
    public static class UserFactory
    {
        public static UserEntity Create(long id)
        {
            return new UserEntity(id);
        }

        public static UserEntity Create(AddUserModel addUserModel)
        {
            return new UserEntity
            (
                addUserModel.Id,
                addUserModel.Username,
                new Email(addUserModel.Email),
                new SignIn
                (
                    addUserModel.SignIn.Login,
                    addUserModel.SignIn.Password,
                    addUserModel.SignIn.Salt
                ),
                addUserModel.Roles,
                Status.Active,
                addUserModel.Gender,
                addUserModel.Phone,
                addUserModel.About
            );
        }

        public static UserEntity Create(UserModel userModel)
        {
            return new UserEntity
            (
                userModel.Id,
                userModel.Username,
                new Email(userModel.Email),
                default,
                userModel.Roles,
                Status.Active,
                Gender.Male,
                userModel.Phone,
                userModel.About
            );
        }
    }
}
