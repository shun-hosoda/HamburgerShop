using System;
using System.Collections.Generic;
using HamburgerShop.Application.DTO;
using HamburgerShop.Domain.Models;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        /// <summary>
        /// オーダー詳細登録
        /// </summary>
        /// <param name="modellList"></param>
        void Register(List<OrderDetail> modellList);

        /// <summary>
        /// オーダー詳細取得
        /// </summary>
        /// <returns>オーダー詳細リスト</returns>
        List<OrderDetailDTO> GetOrderDetailByOrderId(int orderId);
    }
}
