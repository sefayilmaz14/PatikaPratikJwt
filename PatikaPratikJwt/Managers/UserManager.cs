
using PatikaPratikJwt.Dtos;
using PatikaPratikJwt.Entities;
using PatikaPratikJwt.Services;
using PatikaPratikJwt.Types;
using PatikaPratikJwt.Context;


namespace PatikaPratikJwt.Managers
{
    public class UserManager : IUserService
    {
        private readonly PatikaPratikJwtDbContext _context;
        

        public UserManager(PatikaPratikJwtDbContext context)
        {
            _context = context;
            
        }
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var userEntity = new UserEntity
            {
                Email = user.Email,
                Password =user.Password,
            };

            _context.Users.Add(userEntity);
            _context.SaveChanges();

            return new ServiceMessage
            { IsSucceed = true };

        }

        public async Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user)
        {
            var userEntity = _context.Users.Where(x => x.Email.ToLower() == user.Email.ToLower()).FirstOrDefault();
            if (userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }
            

            if (userEntity.Password == user.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        Id = userEntity.Id,
                        Email = userEntity.Email,
                        UserType = userEntity.UserType,
                    }
                };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }
        }
    }
}
