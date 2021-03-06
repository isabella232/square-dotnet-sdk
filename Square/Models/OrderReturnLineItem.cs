using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class OrderReturnLineItem 
    {
        public OrderReturnLineItem(string quantity,
            string uid = null,
            string sourceLineItemUid = null,
            string name = null,
            Models.OrderQuantityUnit quantityUnit = null,
            string note = null,
            string catalogObjectId = null,
            string variationName = null,
            IList<Models.OrderReturnLineItemModifier> returnModifiers = null,
            IList<Models.OrderLineItemAppliedTax> appliedTaxes = null,
            IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts = null,
            Models.Money basePriceMoney = null,
            Models.Money variationTotalPriceMoney = null,
            Models.Money grossReturnMoney = null,
            Models.Money totalTaxMoney = null,
            Models.Money totalDiscountMoney = null,
            Models.Money totalMoney = null)
        {
            Uid = uid;
            SourceLineItemUid = sourceLineItemUid;
            Name = name;
            Quantity = quantity;
            QuantityUnit = quantityUnit;
            Note = note;
            CatalogObjectId = catalogObjectId;
            VariationName = variationName;
            ReturnModifiers = returnModifiers;
            AppliedTaxes = appliedTaxes;
            AppliedDiscounts = appliedDiscounts;
            BasePriceMoney = basePriceMoney;
            VariationTotalPriceMoney = variationTotalPriceMoney;
            GrossReturnMoney = grossReturnMoney;
            TotalTaxMoney = totalTaxMoney;
            TotalDiscountMoney = totalDiscountMoney;
            TotalMoney = totalMoney;
        }

        /// <summary>
        /// Unique identifier for this return line item entry.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// `uid` of the LineItem in the original sale Order.
        /// </summary>
        [JsonProperty("source_line_item_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceLineItemUid { get; }

        /// <summary>
        /// The name of the line item.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The quantity returned, formatted as a decimal number.
        /// For example: `"3"`.
        /// Line items with a `quantity_unit` can have non-integer quantities.
        /// For example: `"1.70000"`.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

        /// <summary>
        /// Contains the measurement unit for a quantity and a precision which
        /// specifies the number of digits after the decimal point for decimal quantities.
        /// </summary>
        [JsonProperty("quantity_unit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderQuantityUnit QuantityUnit { get; }

        /// <summary>
        /// The note of the returned line item.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// The [CatalogItemVariation](#type-catalogitemvariation) id applied to this returned line item.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The name of the variation applied to this returned line item.
        /// </summary>
        [JsonProperty("variation_name", NullValueHandling = NullValueHandling.Ignore)]
        public string VariationName { get; }

        /// <summary>
        /// The [CatalogModifier](#type-catalogmodifier)s applied to this line item.
        /// </summary>
        [JsonProperty("return_modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderReturnLineItemModifier> ReturnModifiers { get; }

        /// <summary>
        /// The list of references to `OrderReturnTax` entities applied to the returned line item. Each
        /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
        /// `OrderReturnTax` applied to the returned line item. On reads, the amount applied
        /// is populated.
        /// </summary>
        [JsonProperty("applied_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemAppliedTax> AppliedTaxes { get; }

        /// <summary>
        /// The list of references to `OrderReturnDiscount` entities applied to the returned line item. Each
        /// `OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
        /// `OrderReturnDiscount` applied to the returned line item. On reads, the amount
        /// applied is populated.
        /// </summary>
        [JsonProperty("applied_discounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemAppliedDiscount> AppliedDiscounts { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("base_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money BasePriceMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("variation_total_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money VariationTotalPriceMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("gross_return_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money GrossReturnMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalTaxMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalDiscountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Quantity)
                .Uid(Uid)
                .SourceLineItemUid(SourceLineItemUid)
                .Name(Name)
                .QuantityUnit(QuantityUnit)
                .Note(Note)
                .CatalogObjectId(CatalogObjectId)
                .VariationName(VariationName)
                .ReturnModifiers(ReturnModifiers)
                .AppliedTaxes(AppliedTaxes)
                .AppliedDiscounts(AppliedDiscounts)
                .BasePriceMoney(BasePriceMoney)
                .VariationTotalPriceMoney(VariationTotalPriceMoney)
                .GrossReturnMoney(GrossReturnMoney)
                .TotalTaxMoney(TotalTaxMoney)
                .TotalDiscountMoney(TotalDiscountMoney)
                .TotalMoney(TotalMoney);
            return builder;
        }

        public class Builder
        {
            private string quantity;
            private string uid;
            private string sourceLineItemUid;
            private string name;
            private Models.OrderQuantityUnit quantityUnit;
            private string note;
            private string catalogObjectId;
            private string variationName;
            private IList<Models.OrderReturnLineItemModifier> returnModifiers;
            private IList<Models.OrderLineItemAppliedTax> appliedTaxes;
            private IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts;
            private Models.Money basePriceMoney;
            private Models.Money variationTotalPriceMoney;
            private Models.Money grossReturnMoney;
            private Models.Money totalTaxMoney;
            private Models.Money totalDiscountMoney;
            private Models.Money totalMoney;

            public Builder(string quantity)
            {
                this.quantity = quantity;
            }

            public Builder Quantity(string quantity)
            {
                this.quantity = quantity;
                return this;
            }

            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder SourceLineItemUid(string sourceLineItemUid)
            {
                this.sourceLineItemUid = sourceLineItemUid;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder QuantityUnit(Models.OrderQuantityUnit quantityUnit)
            {
                this.quantityUnit = quantityUnit;
                return this;
            }

            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

            public Builder VariationName(string variationName)
            {
                this.variationName = variationName;
                return this;
            }

            public Builder ReturnModifiers(IList<Models.OrderReturnLineItemModifier> returnModifiers)
            {
                this.returnModifiers = returnModifiers;
                return this;
            }

            public Builder AppliedTaxes(IList<Models.OrderLineItemAppliedTax> appliedTaxes)
            {
                this.appliedTaxes = appliedTaxes;
                return this;
            }

            public Builder AppliedDiscounts(IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts)
            {
                this.appliedDiscounts = appliedDiscounts;
                return this;
            }

            public Builder BasePriceMoney(Models.Money basePriceMoney)
            {
                this.basePriceMoney = basePriceMoney;
                return this;
            }

            public Builder VariationTotalPriceMoney(Models.Money variationTotalPriceMoney)
            {
                this.variationTotalPriceMoney = variationTotalPriceMoney;
                return this;
            }

            public Builder GrossReturnMoney(Models.Money grossReturnMoney)
            {
                this.grossReturnMoney = grossReturnMoney;
                return this;
            }

            public Builder TotalTaxMoney(Models.Money totalTaxMoney)
            {
                this.totalTaxMoney = totalTaxMoney;
                return this;
            }

            public Builder TotalDiscountMoney(Models.Money totalDiscountMoney)
            {
                this.totalDiscountMoney = totalDiscountMoney;
                return this;
            }

            public Builder TotalMoney(Models.Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

            public OrderReturnLineItem Build()
            {
                return new OrderReturnLineItem(quantity,
                    uid,
                    sourceLineItemUid,
                    name,
                    quantityUnit,
                    note,
                    catalogObjectId,
                    variationName,
                    returnModifiers,
                    appliedTaxes,
                    appliedDiscounts,
                    basePriceMoney,
                    variationTotalPriceMoney,
                    grossReturnMoney,
                    totalTaxMoney,
                    totalDiscountMoney,
                    totalMoney);
            }
        }
    }
}