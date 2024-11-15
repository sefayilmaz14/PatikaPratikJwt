using PatikaPratikJwt.Dtos;
using PatikaPratikJwt.Types;

namespace PatikaPratikJwt.Services
{
    public interface IUserService
    {

        Task<ServiceMessage> AddUser(AddUserDto user);
        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user);
        
    }
}
