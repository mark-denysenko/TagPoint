using Domain.User;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.User
{
    public interface IUserAvatarRepository : IRelationalRepository<UserAvatarEntity>
    {
    }
}
