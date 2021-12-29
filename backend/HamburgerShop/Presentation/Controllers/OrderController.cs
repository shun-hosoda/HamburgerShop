using HamburgerShop.Application.Command;
using HamburgerShop.Presentation.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HamburgerShop.Presentation.Controllers
{
    public class OrderController : ControllerBase
    {
        #region プロパティ
        private readonly ILogger<OrderController> _logger;
        private readonly OrderCommand _orderCommand;
        #endregion

        #region コンストラクタ
        public OrderController(ILogger<OrderController> logger, OrderCommand orderCommand)
        {
            _logger = logger;
            _orderCommand = orderCommand;
        }
        #endregion

        #region RegisterOrder
        [HttpPost]
        [Route("/hamburgershop/order/register")]
        public IActionResult RegisterOrder([FromBody] OrderRequest req)
        {
            _orderCommand.RegisterOrder(req.PaymentTypeId, req.TaxTypeId,
                req.FinalTotal, req.Tax, req.PaymentAmount, req.PaymentRefund, req.OrderDetailDTOList);

            return Ok();
        }
        #endregion
    }
}
