using TelusInternational.Business.Dto;
using TelusInternational.DataAccess.Repositories.Interfaces;

namespace TelusInternational.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> ValidateCredentials(LoginModel login)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(login.Username);

            if (existingUser != null)
            {
                // we usually hash password upon creating user or changing password and verify here
                // for now we use the value in json file as the password for testing
                if (existingUser.PasswordHash == login.Password)
                {
                    UserDto userDto = new UserDto();
                    userDto.Username = existingUser.Username;
                    return userDto;
                }
            }
            return null;
        }
    }
}
