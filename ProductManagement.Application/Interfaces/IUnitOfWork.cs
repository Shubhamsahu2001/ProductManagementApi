using ProductManagement.Application.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }

    IItemRepository Items { get; }

    IRefreshTokenRepository RefreshTokens { get; }

    Task<int> SaveChangesAsync();
}