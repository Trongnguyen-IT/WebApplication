using System.Collections.Generic;
using T.Core;

namespace T.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}
