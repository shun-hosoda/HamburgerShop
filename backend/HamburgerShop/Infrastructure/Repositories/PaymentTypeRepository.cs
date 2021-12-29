using System;
using System.Collections.Generic;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HamburgerShop.Infrastructure.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        #region プロパティ
        private readonly HamburgerShopContext _context;
        #endregion

        #region コンストラクタ
        public PaymentTypeRepository(HamburgerShopContext context)
        {
            _context = context;
        }
        #endregion

        #region GetAllPaymentTypes
        /// <summary>
        /// 支払タイプ取得
        /// </summary>
        /// <returns>支払タイプリスト</returns>
        public List<PaymentTypes> GetAllPaymentTypes()
        {
            return _context.PaymentTypes.ToList();
        }
        #endregion
    }
}
