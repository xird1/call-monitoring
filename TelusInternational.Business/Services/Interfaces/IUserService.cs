using TelusInternational.Business.Dto;

namespace TelusInternational.Business
{
    public interface IUserService
    {
        Task<UserDto> ValidateCredentials(LoginModel login);
    }
}
