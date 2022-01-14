using System;
using System.Collections.Generic;
using System.Linq;
using HamburgerShop.Domain.Models;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        #region プロパティ
        private readonly HamburgerShopContext _context;
        #endregion

        #region コンストラクタ
        public OrderDetailRepository(HamburgerShopContext context)
        {
            _context = context;
        }
        #endregion

        #region Register
        /// <summary>
        /// オーダー詳細登録
        /// </summary>
        /// <param name="modellList"></param>
        public void Register(List<OrderDetail> modellList)
        {
            foreach (OrderDetail model in modellList)
            {
                OrderDetails entity = ModelToEntity(model);
                RegisterOrderDetail(entity);
            }
        }
        #endregion

        #region GetOrderDetailByOrderId
        /// <summary>
        /// オーダー詳細取得
        /// </summary>
        /// <returns>オーダー詳細リスト</returns>
        public List<OrderDetails> GetOrderDetailByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(x => x.OrderId == orderId).ToList();
        }
        #endregion

        #region RegisterOrderDetail
        /// <summary>
        /// オーダー詳細登録
        /// </summary>
        /// <param name="entity"></param>
        private void RegisterOrderDetail(OrderDetails entity)
        {
            _context.OrderDetails.AddAsync(entity);
            _context.SaveChangesAsync();
        }
        #endregion

        #region ModelToEntity
        /// <summary>
        /// モデルからエンティティに変換
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        private OrderDetails ModelToEntity(OrderDetail orderDetail)
        {
            return new OrderDetails()
            {
                OrderId = orderDetail.OrderId,
                ItemId = orderDetail.ItemId,
                Quantity = orderDetail.Quantity,
                Total = orderDetail.Total,
                Tax = orderDetail.Tax,
            };
        }
        #endregion
    }
}
