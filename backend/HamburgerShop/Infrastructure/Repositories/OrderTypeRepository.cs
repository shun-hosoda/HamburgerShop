using System;
using System.Collections.Generic;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HamburgerShop.Infrastructure.Repositories
{
    public class OrderTypeRepository : IOrderTypeRepository
    {
        #region プロパティ
        private readonly HamburgerShopContext _context;
        #endregion

        #region コンストラクタ
        public OrderTypeRepository(HamburgerShopContext context)
        {
            _context = context;
        }
        #endregion

        #region GetAllOrderTypes
        /// <summary>
        /// オーダー区分取得
        /// </summary>
        /// <returns>オーダー区分リスト</returns>
        public List<OrderTypes> GetAllOrderTypes()
        {
            return _context.OrderTypes.ToList();
        }
        #endregion
    }
}
