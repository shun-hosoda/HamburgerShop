using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamburgerShop.Domain.Repositories;
using HamburgerShop.Infrastructure.Entities;

namespace HamburgerShop.Application.Services
{
    public class MenuQuery
    {
        #region プロパティ
        private readonly IItemRepository _itemRepository;
        private readonly IOrderTypeRepository _orderTypeRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly ITaxTypeRepository _taxTypeRepository;
        #endregion

        #region コンストラクタ
        public MenuQuery(IItemRepository itemRepository, IOrderTypeRepository orderTypeRepository,
            IPaymentTypeRepository paymentTypeRepository, ITaxTypeRepository taxTypeRepository)
        {
            _itemRepository = itemRepository;
            _orderTypeRepository = orderTypeRepository;
            _paymentTypeRepository = paymentTypeRepository;
            _taxTypeRepository = taxTypeRepository;
        }
        #endregion

        #region GetMenuData
        /// <summary>
        /// メニューデータ取得
        /// </summary>
        /// <param name="items"></param>
        /// <param name="orderTypes"></param>
        /// <param name="taxTypes"></param>
        /// <param name="paymentTypes"></param>
        public void GetMenuData(out List<Items> items, out List<OrderTypes> orderTypes,
            out List<TaxTypes> taxTypes, out List<PaymentTypes> paymentTypes)
        {
            // 商品リスト取得
            items = _itemRepository.GetAllItems();
            items = items.Count <= 0 ? new List<Items>() : items;
            // オーダータイプ取得
            orderTypes = _orderTypeRepository.GetAllOrderTypes();
            orderTypes = orderTypes.Count <= 0 ? new List<OrderTypes>() : orderTypes;
            // 消費税取得
            taxTypes = _taxTypeRepository.GetAllTaxTypes();
            taxTypes = taxTypes.Count <= 0 ? new List<TaxTypes>() : taxTypes;
            // 支払タイプ取得
            paymentTypes = _paymentTypeRepository.GetAllPaymentTypes();
            paymentTypes = paymentTypes.Count <= 0 ? new List<PaymentTypes>() : paymentTypes;

            return;
        }
        #endregion
    }
}
