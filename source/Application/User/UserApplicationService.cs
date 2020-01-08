using DotNetCore.Objects;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Infra;
using DotNetCoreArchitecture.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public sealed class UserApplicationService : IUserApplicationService
    {
        private readonly ISignInService _signInService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserLogApplicationService _userLogApplicationService;
        private readonly IUserRepository _userRepository;

        public UserApplicationService
        (
            ISignInService signInService,
            IUnitOfWork unitOfWork,
            IUserLogApplicationService userLogApplicationService,
            IUserRepository userRepository
        )
        {
            _signInService = signInService;
            _unitOfWork = unitOfWork;
            _userLogApplicationService = userLogApplicationService;
            _userRepository = userRepository;
        }

        public async Task<IDataResult<long>> AddAsync(AddUserModel addUserModel)
        {
            var validation = new AddUserModelValidator().Validate(addUserModel);

            if (validation.Failed)
            {
                return DataResult<long>.Fail(validation.Message);
            }

            addUserModel.SignIn = _signInService.CreateSignIn(addUserModel.SignIn);

            var userEntity = UserFactory.Create(addUserModel);

            userEntity.Add();

            await _userRepository.AddAsync(userEntity);

            await _unitOfWork.SaveChangesAsync();

            return DataResult<long>.Success(userEntity.Id);
        }

        public async Task<IResult> DeleteAsync(long id)
        {
            await _userRepository.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public async Task InactivateAsync(long id)
        {
            var userEntity = UserFactory.Create(id);

            userEntity.Inactivate();

            await _userRepository.UpdateStatusAsync(userEntity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters)
        {
            return await _userRepository.ListAsync<UserModel>(parameters);
        }

        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await _userRepository.ListAsync<UserModel>();
        }

        public async Task<UserModel> SelectAsync(long id)
        {
            return await _userRepository.SelectAsync<UserModel>(id);
        }

        public async Task<IDataResult<TokenModel>> SignInAsync(SignInModel signInModel)
        {
            var validation = new SignInModelValidator().Validate(signInModel);

            if (validation.Failed)
            {
                return DataResult<TokenModel>.Fail(validation.Message);
            }

            var signedInModel = await _userRepository.SignInAsync(signInModel);

            validation = _signInService.Validate(signedInModel, signInModel);

            if (validation.Failed)
            {
                return DataResult<TokenModel>.Fail(validation.Message);
            }

            var userLogModel = new UserLogModel(signedInModel.Id, LogType.SignIn);

            await _userLogApplicationService.AddAsync(userLogModel);

            var tokenModel = _signInService.CreateToken(signedInModel);

            return DataResult<TokenModel>.Success(tokenModel);
        }

        public async Task SignOutAsync(SignOutModel signOutModel)
        {
            var userLogModel = new UserLogModel(signOutModel.Id, LogType.SignOut);

            await _userLogApplicationService.AddAsync(userLogModel);
        }

        public async Task<IResult> UpdateAsync(UpdateUserModel updateUserModel)
        {
            var validation = new UpdateUserModelValidator().Validate(updateUserModel);

            if (validation.Failed)
            {
                return Result.Fail(validation.Message);
            }

            var userEntity = await _userRepository.SelectAsync(updateUserModel.Id);

            if (userEntity == default)
            {
                return Result.Success();
            }

            userEntity.ChangeFullName(updateUserModel.FullName.Name, updateUserModel.FullName.Surname);

            userEntity.ChangeEmail(updateUserModel.Email);

            await _userRepository.UpdateAsync(userEntity.Id, userEntity);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
