using System;
using System.Collections.Generic;
using HamburgerShop.Application.DTO;
using HamburgerShop.Domain.Models;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Application.Command
{
    public class OrderCommand
    {
        #region プロパティ
        private readonly HamburgerShopContext _context;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderDetailRepository _orderDetailRepo;
        #endregion

        #region コンストラクタ
        public OrderCommand(
            HamburgerShopContext context,
            IOrderRepository orderRepo,
            IOrderDetailRepository orderDetailRepo)
        {
            _context = context;
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
        }
        #endregion

        #region RegisterOrder
        /// <summary>
        /// 注文データ登録
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="taxTypeId"></param>
        /// <param name="finalTotal"></param>
        /// <param name="tax"></param>
        /// <param name="orderDetailDTOList"></param>
        public void RegisterOrder(int paymentId, int taxTypeId, int finalTotal, int tax,
            int paymentAmount, int paymentRefund, List<OrderDetailDTO> orderDetailDTOList)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    Order order = new Order();
                    // Orderテーブル登録データ作成
                    order.Register(paymentId, taxTypeId, finalTotal, tax, paymentAmount, paymentRefund);
                    // Orderデータ登録
                    order = _orderRepo.Register(order);

                    List<OrderDetail> orderDetailList = new List<OrderDetail>();

                    foreach (OrderDetailDTO orderDetailDTO in orderDetailDTOList)
                    {
                        OrderDetail orderDetail = new OrderDetail();

                        // OrderDetailテーブル登録データ作成
                        orderDetail.Register(order.OrderId, orderDetailDTO.ItemId, orderDetailDTO.Quantity,
                            orderDetailDTO.Total, orderDetailDTO.Tax);

                        orderDetailList.Add(orderDetail);
                    }

                    // OrderDetail登録
                    _orderDetailRepo.Register(orderDetailList);

                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }

            return;
        }
        #endregion
    }
}
