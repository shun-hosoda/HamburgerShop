using System;
using HamburgerShop.Domain.Models;

namespace HamburgerShop.Domain.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// オーダーデータ登録
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Order Register(Order order);
    }
}
