using System;
using System.Collections.Generic;
using HamburgerShop.Application.DTO;

namespace HamburgerShop.Presentation.Requests
{
    public class OrderRequest
    {
        /// <summary>支払タイプID</summary>
        public int paymentTypeId { get; set; }
        /// <summary>消費税区分ID</summary>
        public int taxTypeId { get; set; }
        /// <summary>合計</summary>
        public int finalTotal { get; set; }
        /// <summary>消費税</summary>
        public int tax { get; set; }
        /// <summary>支払額</summary>
        public int paymentAmount { get; set; }
        /// <summary>お釣り</summary>
        public int paymentRefund { get; set; }
        /// <summary>注文詳細</summary>
        public List<OrderDetailDTO> orderDetailDTOList { get; set; } = new List<OrderDetailDTO>();
    }
}
