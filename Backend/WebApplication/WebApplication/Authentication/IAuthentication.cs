using System.Collections.Generic;
using System.Threading.Tasks;
using T.Core;
using T.Core.Shared;

namespace T.Host.Token
{
    public interface IAuthentication
    {
        Task<ApiExcuteResult> Authenticate(string username, string password);

        IEnumerable<User> GetAll();
    }
}
