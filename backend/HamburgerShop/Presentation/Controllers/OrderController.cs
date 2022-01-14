using System.Collections.Generic;
using HamburgerShop.Application.Command;
using HamburgerShop.Application.Query;
using HamburgerShop.Infrastructure.Entities;
using HamburgerShop.Presentation.Requests;
using HamburgerShop.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HamburgerShop.Presentation.Controllers
{
    public class OrderController : ControllerBase
    {
        #region プロパティ
        private readonly ILogger<OrderController> _logger;
        private readonly OrderCommand _orderCommand;
        private readonly OrderQuery _orderQuery;
        #endregion

        #region コンストラクタ
        public OrderController(
            ILogger<OrderController> logger,
            OrderCommand orderCommand,
            OrderQuery orderQuery)
        {
            _logger = logger;
            _orderCommand = orderCommand;
            _orderQuery = orderQuery;
        }
        #endregion

        #region RegisterOrder
        [HttpPost]
        [Route("/hamburgershop/order/register")]
        public IActionResult RegisterOrder([FromBody] OrderRequest req)
        {
            // 注文データ登録
            _orderCommand.RegisterOrder(req.paymentTypeId, req.taxTypeId,
                req.finalTotal, req.tax, req.paymentAmount, req.paymentRefund, req.orderDetailDTOList);

            return Ok();
        }
        #endregion

        #region GetAllOrder
        [HttpGet]
        [Route("/hamburgershop/order")]
        public IActionResult GetAllOrder()
        {
            // 注文リスト取得
            List<Orders> orders = _orderQuery.GetAllOrder();

            // レスポンス
            OrderResponse response = new OrderResponse();

            // オーダーリストがnullではない場合はレスポンスに設定
            if (orders != null)
                response.orderList = orders;

            return Ok(response);
        }
        #endregion

        #region GetOrderDetail
        [HttpGet]
        [Route("/hamburgershop/orderDetail")]
        public IActionResult GetOrderDetail([FromBody] OrderDetailRequest req)
        {
            // 注文詳細リスト取得
            List<OrderDetails> orderDetails = _orderQuery.GetOrderDetailByOrderId(req.orderId);

            // レスポンス
            OrderDetailResponse response = new OrderDetailResponse();

            // オーダーリストがnullではない場合はレスポンスに設定
            if (orderDetails != null)
                response.orderDetailList = orderDetails;

            return Ok(response);
        }
        #endregion
    }
}
