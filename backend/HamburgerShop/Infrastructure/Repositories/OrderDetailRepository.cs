using System;
using System.Collections.Generic;
using System.Linq;
using HamburgerShop.Application.DTO;
using HamburgerShop.Domain.Models;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Internal;

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

        #region GetOrderDetailByOrderId
        /// <summary>
        /// オーダー詳細取得
        /// </summary>
        /// <returns>オーダー詳細リスト</returns>
        public List<OrderDetailDTO> GetOrderDetailByOrderId(int orderId)
        {
            var result = _context.OrderDetails.Where(x => x.OrderId == orderId).Join(
                        _context.Items,
                        orderDetail => orderDetail.ItemId,
                        item => item.ItemId,
                        (orderDetail, item) => new OrderDetailDTO()
                        {
                            ItemId = orderDetail.ItemId,
                            ItemName = item.ItemName,
                            Quantity = orderDetail.Quantity,
                            Total = orderDetail.Total,
                        }
                    ).ToList();

            return result;
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
