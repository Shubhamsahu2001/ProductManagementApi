using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Data;

namespace ProductManagement.Infrastructure.Data.Repositories;

public class ItemRepository : Repository<Item>, IItemRepository
{
    public ItemRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}