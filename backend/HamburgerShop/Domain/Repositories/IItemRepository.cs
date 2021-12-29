using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Domain.Repositories
{
    public interface IItemRepository
    {
        List<Items> GetAllItems();
    }
}
