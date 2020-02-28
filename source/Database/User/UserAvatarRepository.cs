using Domain.User;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.User
{
    public class UserAvatarRepository : EntityFrameworkCoreRelationalRepository<UserAvatarEntity>, IUserAvatarRepository
    {
        public UserAvatarRepository(Context context) : base(context)
        {
        }

    }
}
