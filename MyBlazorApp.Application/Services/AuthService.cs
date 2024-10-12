using MyBlazorApp.Application.Repositories;
using MyBlazorApp.Model.Entities;

namespace MyBlazorApp.Application.Services;

public interface IAuthService
{
    Task<UserModel> GetUserByLogin(string username, string password);
    Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel);
    Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken);
}

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public Task<UserModel> GetUserByLogin(string username, string password)
    {
        return authRepository.GetUserByLogin(username, password);
    }

    public async Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel)
    {
        await authRepository.RemoveRefreshTokenByUserID(refreshTokenModel.UserID);
        await authRepository.AddRefreshTokenModel(refreshTokenModel);
    }

    public Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken)
    {
        return authRepository.GetRefreshTokenModel(refreshToken);
    }
}
