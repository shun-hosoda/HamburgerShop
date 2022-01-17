using System;
using System.Collections.Generic;
using HamburgerShop.Application.DTO;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Presentation.Responses
{
    public class OrderDetailResponse
    {
        /// <summary>注文詳細リスト</summary>
        public List<OrderDetailDTO> orderDetailList { get; set; } = new List<OrderDetailDTO>();
    }
}
