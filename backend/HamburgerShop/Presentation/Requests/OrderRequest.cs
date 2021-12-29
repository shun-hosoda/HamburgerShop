using System;
using System.Collections.Generic;
using HamburgerShop.Application.DTO;

namespace HamburgerShop.Presentation.Requests
{
    public class OrderRequest
    {
        /// <summary>支払タイプID</summary>
        public int PaymentTypeId { get; set; }
        /// <summary>消費税区分ID</summary>
        public int TaxTypeId { get; set; }
        /// <summary>合計</summary>
        public int FinalTotal { get; set; }
        /// <summary>消費税</summary>
        public int Tax { get; set; }
        /// <summary>支払額</summary>
        public int PaymentAmount { get; set; }
        /// <summary>お釣り</summary>
        public int PaymentRefund { get; set; }
        /// <summary>注文詳細</summary>
        public List<OrderDetailDTO> OrderDetailDTOList { get; set; } = new List<OrderDetailDTO>();
    }
}
