using Microsoft.EntityFrameworkCore;
using MyBlazorApp.DataAccess.Data;
using MyBlazorApp.Model.Entities;

namespace MyBlazorApp.Application.Repositories;

public interface IAuthRepository
{
    Task<UserModel> GetUserByLogin(string username, string password);
    Task RemoveRefreshTokenByUserID(long userID);
    Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel);
    Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken);
}

public class AuthRepository(AppDbContext dbContext) : IAuthRepository
{
    public Task<UserModel> GetUserByLogin(string username, string password)
    {
        return dbContext.Users.Include(n => n.UserRoles).ThenInclude(n => n.Role).FirstOrDefaultAsync(n => n.Username == username && n.Password == password);
    }

    public async Task RemoveRefreshTokenByUserID(long userID)
    {
        var refreshToken = dbContext.RefreshTokens.FirstOrDefault(n => n.UserID == userID);
        if (refreshToken != null)
        {
            dbContext.RemoveRange(refreshToken);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel)
    {
        await dbContext.RefreshTokens.AddAsync(refreshTokenModel);
        await dbContext.SaveChangesAsync();
    }

    public Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken)
    {
        return dbContext.RefreshTokens.Include(n => n.User).ThenInclude(n => n.UserRoles).ThenInclude(n => n.Role).FirstOrDefaultAsync(n => n.RefreshToken == refreshToken);
    }
}
