using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamburgerShop.Domain.Models;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        #region プロパティ
        private readonly HamburgerShopContext _context;
        #endregion

        #region コンストラクタ
        public OrderRepository(HamburgerShopContext context)
        {
            _context = context;
        }
        #endregion

        #region public

        #region Register
        /// <summary>
        /// オーダーデータ登録
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Order Register(Order model)
        {
            Orders entity = ModelToEntity(model);

            _context.Orders.AddAsync(entity);

            _context.SaveChangesAsync();

            return EntityToModel(entity);
        }
        #endregion

        #region GetAllOrders
        /// <summary>
        /// オーダー取得
        /// </summary>
        /// <returns>オーダーリスト</returns>
        public List<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
        #endregion

        #endregion

        #region private

        #region ModelToEntity
        /// <summary>
        /// モデルからエンティティに変換
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private Orders ModelToEntity(Order order)
        {
            return new Orders()
            {
                PaymentTypeId = order.PaymentTypeId,
                TaxTypeId = order.TaxTypeId,
                OrderNumber = order.OrderNumber,
                FinalTotal = order.FinalTotal,
                Tax = order.Tax,
                PaymentAmount = order.PaymentAmount,
                PaymentRefund = order.PaymentRefund,
                OrderDate = order.OrderDate,
            };
        }
        #endregion

        #region EntityToModel
        /// <summary>
        /// エンティティからモデルに変換
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        private Order EntityToModel(Orders orders)
        {
            return new Order(orders.OrderId, orders.PaymentTypeId, orders.TaxTypeId, orders.OrderNumber,
                orders.FinalTotal, orders.Tax, orders.PaymentAmount, orders.PaymentRefund, orders.OrderDate);
        }
        #endregion

        #endregion
    }
}
