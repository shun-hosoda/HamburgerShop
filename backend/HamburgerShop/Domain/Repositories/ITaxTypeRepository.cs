using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Domain.Repositories
{
    public interface ITaxTypeRepository
    {
        /// <summary>
        /// 消費税区分取得
        /// </summary>
        /// <returns>消費税区分リスト</returns>
        List<TaxTypes> GetAllTaxTypes();
    }
}
