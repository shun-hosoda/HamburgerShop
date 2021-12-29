using System;
namespace HamburgerShop.Domain.Models
{
    public class Order
    {
        #region プロパティ
        public int OrderId { get; private set; }
        public int PaymentTypeId { get; private set; }
        public int TaxTypeId { get; set; }
        public string OrderNumber { get; private set; }
        public int FinalTotal { get; private set; }
        public int Tax { get; private set; }
        public int PaymentAmount { get; private set; }
        public int PaymentRefund { get; private set; }
        public DateTime OrderDate { get; private set; }
        #endregion

        #region コンストラクタ
        public Order()
        {
        }

        /// <summary>
        /// オーダー
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="paymentTypeId"></param>
        /// <param name="taxTypeId"></param>
        /// <param name="orderNumber"></param>
        /// <param name="finalTotal"></param>
        /// <param name="tax"></param>
        /// <param name="orderDate"></param>
        /// <param name="paymentAmount"></param>
        /// <param name="paymentRefund"></param>
        public Order(int orderId, int paymentTypeId, int taxTypeId, string orderNumber,
            int finalTotal, int tax, int paymentAmount, int paymentRefund, DateTime orderDate)
        {
            OrderId = orderId;
            PaymentTypeId = paymentTypeId;
            TaxTypeId = taxTypeId;
            OrderNumber = orderNumber;
            FinalTotal = finalTotal;
            Tax = tax;
            PaymentAmount = paymentAmount;
            PaymentRefund = paymentRefund;
            OrderDate = orderDate;
        }
        #endregion

        #region Register
        /// <summary>
        /// 登録データ生成
        /// </summary>
        /// <param name="paymentTypeId"></param>
        /// <param name="taxTypeId"></param>
        /// <param name="finalTotal"></param>
        /// <param name="tax"></param>
        /// <param name="paymentAmount"></param>
        /// <param name="paymentRefund"></param>
        public void Register(int paymentTypeId, int taxTypeId, int finalTotal, int tax,
            int paymentAmount, int paymentRefund)
        {
            PaymentTypeId = paymentTypeId;
            FinalTotal = finalTotal;
            TaxTypeId = taxTypeId;
            // オーダー番号作成
            OrderNumber = string.Format("{0:ddmmyyyyhhmmss}", DateTime.Now);
            // 消費税率から消費税算出
            Tax = tax;
            PaymentAmount = paymentAmount;
            PaymentRefund = paymentRefund;
            OrderDate = DateTime.Now;
        }
        #endregion
    }
}
