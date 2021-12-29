using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HamburgerShop.Models;
using HamburgerShop.Infrastructure.Entities;
using HamburgerShop.Application.Services;
using HamburgerShop.Presentation.Responses;
using HamburgerShop.Presentation.Requests;

namespace HamburgerShop.Presentation.Controllers
{
    public class MenuController : ControllerBase
    {
        #region プロパティ
        private readonly ILogger<MenuController> _logger;
        private readonly MenuQuery _menuQuery;
        #endregion

        #region コンストラクタ
        public MenuController(ILogger<MenuController> logger, MenuQuery menuQuery)
        {
            _logger = logger;
            _menuQuery = menuQuery;
        }
        #endregion

        #region Menu
        [HttpGet]
        [Route("/hamburgershop/menu")]
        public IActionResult Menu()
        {
            _menuQuery.GetMenuData(out List<Items> itemList, out List<OrderTypes> orderTypeList,
                out List<TaxTypes> taxTypeList, out List<PaymentTypes> paymentTypeList);

            MenuResponse response = new MenuResponse()
            {
                itemList = itemList,
                orderTypeList = orderTypeList,
                taxTypeList = taxTypeList,
                paymentTypeList = paymentTypeList
            };

            return Ok(response);
        }
        #endregion
    }
}
