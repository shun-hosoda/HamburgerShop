using System;
using System.Collections.Generic;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HamburgerShop.Infrastructure.Repositories
{
    public class TaxTypeRepository : ITaxTypeRepository
    {
        #region プロパティ
        private readonly HamburgerShopContext _context;
        #endregion

        #region コンストラクタ
        public TaxTypeRepository(HamburgerShopContext context)
        {
            _context = context;
        }
        #endregion

        #region GetAllTaxTypes
        /// <summary>
        /// 消費税区分取得
        /// </summary>
        /// <returns>消費税区分リスト</returns>
        public List<TaxTypes> GetAllTaxTypes()
        {
            return _context.TaxTypes.ToList();
        }
        #endregion
    }
}
