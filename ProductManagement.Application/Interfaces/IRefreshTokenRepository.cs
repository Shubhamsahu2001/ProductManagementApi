using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Interfaces;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenAsync(string token);

    Task<IEnumerable<RefreshToken>> GetByUsernameAsync(string username);
}