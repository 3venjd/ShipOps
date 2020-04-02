using Microsoft.AspNetCore.Identity;
using ShipOps.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> GetUserByEmail(string email);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user,string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);
    }
}
