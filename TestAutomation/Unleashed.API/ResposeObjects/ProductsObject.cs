using System;
using System.Collections.Generic;

public class Pagination
{
    public int NumberOfItems { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int NumberOfPages { get; set; }
}

public class UnitOfMeasure
{
    public string Guid { get; set; }
    public string Name { get; set; }
}

public class SellPriceTier1
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier2
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier3
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier4
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier5
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier6
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier7
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier8
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier9
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class SellPriceTier10
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class ProductGroup
{
    public string GroupName { get; set; }
    public string Guid { get; set; }
    public DateTime LastModifiedOn { get; set; }
}

public class Item
{
    public string ProductCode { get; set; }
    public string ProductDescription { get; set; }
    public object Barcode { get; set; }
    public object PackSize { get; set; }
    public object Width { get; set; }
    public object Height { get; set; }
    public object Depth { get; set; }
    public object Weight { get; set; }
    public double? MinStockAlertLevel { get; set; }
    public double? MaxStockAlertLevel { get; set; }
    public object ReOrderPoint { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public bool NeverDiminishing { get; set; }
    public double? LastCost { get; set; }
    public double? DefaultPurchasePrice { get; set; }
    public double? DefaultSellPrice { get; set; }
    public object CustomerSellPrice { get; set; }
    public double AverageLandPrice { get; set; }
    public bool Obsolete { get; set; }
    public object Notes { get; set; }
    public object Images { get; set; }
    public object ImageUrl { get; set; }
    public SellPriceTier1 SellPriceTier1 { get; set; }
    public SellPriceTier2 SellPriceTier2 { get; set; }
    public SellPriceTier3 SellPriceTier3 { get; set; }
    public SellPriceTier4 SellPriceTier4 { get; set; }
    public SellPriceTier5 SellPriceTier5 { get; set; }
    public SellPriceTier6 SellPriceTier6 { get; set; }
    public SellPriceTier7 SellPriceTier7 { get; set; }
    public SellPriceTier8 SellPriceTier8 { get; set; }
    public SellPriceTier9 SellPriceTier9 { get; set; }
    public SellPriceTier10 SellPriceTier10 { get; set; }
    public object XeroTaxCode { get; set; }
    public object XeroTaxRate { get; set; }
    public bool? TaxablePurchase { get; set; }
    public bool? TaxableSales { get; set; }
    public object XeroSalesTaxCode { get; set; }
    public object XeroSalesTaxRate { get; set; }
    public bool IsComponent { get; set; }
    public bool IsAssembledProduct { get; set; }
    public ProductGroup ProductGroup { get; set; }
    public object XeroSalesAccount { get; set; }
    public object XeroCostOfGoodsAccount { get; set; }
    public object PurchaseAccount { get; set; }
    public object BinLocation { get; set; }
    public object Supplier { get; set; }
    public object AttributeSet { get; set; }
    public object SourceId { get; set; }
    public object SourceVariantParentId { get; set; }
    public bool IsSerialized { get; set; }
    public bool IsBatchTracked { get; set; }
    public bool IsSellable { get; set; }
    public object MinimumSellPrice { get; set; }
    public object MinimumSaleQuantity { get; set; }
    public object MinimumOrderQuantity { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public object CommerceCode { get; set; }
    public object CustomsDescription { get; set; }
    public object SupplementaryClassificationAbbreviation { get; set; }
    public object ICCCountryCode { get; set; }
    public object ICCCountryName { get; set; }
    public string Guid { get; set; }
    public DateTime LastModifiedOn { get; set; }
}

public class ProductsObject
{
    public Pagination Pagination { get; set; }
    public List<Item> Items { get; set; }
}

