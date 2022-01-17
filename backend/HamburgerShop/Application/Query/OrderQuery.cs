using System;
using System.Collections.Generic;
using HamburgerShop.Application.DTO;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Application.Query
{
    public class OrderQuery
    {
        #region プロパティ
        private readonly HamburgerShopContext _context;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderDetailRepository _orderDetailRepo;
        #endregion

        #region コンストラクタ
        public OrderQuery(
            HamburgerShopContext context,
            IOrderRepository orderRepo,
            IOrderDetailRepository orderDetailRepo)
        {
            _context = context;
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
        }
        #endregion

        #region GetAllOrder
        /// <summary>
        /// オーダー取得
        /// </summary>
        /// <returns>オーダーリスト</returns>
        public List<Orders> GetAllOrder()
        {
            return _orderRepo.GetAllOrders();
        }
        #endregion

        #region GetOrderDetailByOrderId
        /// <summary>
        /// オーダー詳細取得
        /// </summary>
        /// <returns>オーダー詳細リスト</returns>
        public List<OrderDetailDTO> GetOrderDetailByOrderId(int orderId)
        {
            return _orderDetailRepo.GetOrderDetailByOrderId(orderId);
        }
        #endregion
    }
}
