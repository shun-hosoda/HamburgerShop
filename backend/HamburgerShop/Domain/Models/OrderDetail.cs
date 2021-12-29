using System;
namespace HamburgerShop.Domain.Models
{
    public class OrderDetail
    {
        #region プロパティ
        public int OrderDetailId { get; private set; }
        public int OrderId { get; private set; }
        public int ItemId { get; private set; }
        public int Quantity { get; private set; }
        public int Total { get; private set; }
        public int Tax { get; private set; }
        #endregion

        #region コンストラクタ
        public OrderDetail()
        {
        }

        /// <summary>
        /// オーダー詳細
        /// </summary>
        /// <param name="orderDetailId"></param>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <param name="total"></param>
        /// <param name="tax"></param>
        public OrderDetail(int orderDetailId, int orderId, int itemId, int quantity,
            int total, int tax)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
            Total = total;
            Tax = tax;
        }
        #endregion

        #region Register
        /// <summary>
        /// 登録データ生成
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <param name="total"></param>
        /// <param name="tax"></param>
        public void Register(int orderId, int itemId, int quantity, int total, int tax)
        {
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
            Total = total;
            // 消費税率から消費税算出
            Tax = tax;
        }
        #endregion
    }
}
