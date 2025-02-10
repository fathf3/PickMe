using PickMe.Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Business.Services.Concretes
{
    public class UserService : IUserService
    {
        public string GetUserId(ClaimsPrincipal user)
        {
            return user?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
