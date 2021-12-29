using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Domain.Repositories
{
    public interface IOrderTypeRepository
    {
        /// <summary>
        /// オーダー区分取得
        /// </summary>
        /// <returns>オーダー区分リスト</returns>
        List<OrderTypes> GetAllOrderTypes();
    }
}
