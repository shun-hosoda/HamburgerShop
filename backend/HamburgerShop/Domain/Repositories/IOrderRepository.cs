using System;
using System.Collections.Generic;
using HamburgerShop.Domain.Models;
using HamburgerShop.Infrastructure.Entities;

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

        /// <summary>
        /// オーダー取得
        /// </summary>
        /// <returns>オーダーリスト</returns>
        List<Orders> GetAllOrders();
    }
}
