using System;
using System.Collections.Generic;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HamburgerShop.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        #region プロパティ
        private readonly HamburgerShopContext _context;
        #endregion

        #region コンストラクタ
        public ItemRepository(HamburgerShopContext context)
        {
            _context = context;
        }
        #endregion

        #region GetAllItems
        /// <summary>
        /// 商品データ取得
        /// </summary>
        /// <returns>商品データリスト</returns>
        public List<Items> GetAllItems()
        {
            return _context.Items.ToList();
        }
        #endregion

    }
}
