using System;
using System.Collections.Generic;
using HamburgerShop.Domain.Models;

namespace HamburgerShop.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        /// <summary>
        /// オーダー詳細登録
        /// </summary>
        /// <param name="modellList"></param>
        void Register(List<OrderDetail> modellList);
    }
}
