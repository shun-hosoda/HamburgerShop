using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Domain.Repositories
{
    public interface IPaymentTypeRepository
    {
        /// <summary>
        /// 支払タイプ取得
        /// </summary>
        /// <returns>支払タイプリスト</returns>
        List<PaymentTypes> GetAllPaymentTypes();
    }
}
