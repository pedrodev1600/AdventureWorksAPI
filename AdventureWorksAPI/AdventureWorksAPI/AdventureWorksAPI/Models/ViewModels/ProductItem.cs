namespace AdventureWorksAPI.Models.ViewModels
{
    public class ProductItem
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string ProductNumber { get; set; } = null!;

        public bool MakeFlag { get; set; }

        public bool FinishedGoodsFlag { get; set; }

        public string? Color { get; set; }

        public short SafetyStockLevel { get; set; }

        public short ReorderPoint { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public string? Size { get; set; }

        public string? SizeUnitMeasureCode { get; set; }

        public string? WeightUnitMeasureCode { get; set; }

        public decimal? Weight { get; set; }

        public int DaysToManufacture { get; set; }

        public string? ProductLine { get; set; }

        public string? Class { get; set; }

        public string? Style { get; set; }

        public int? ProductSubcategoryId { get; set; }

        public int? ProductModelId { get; set; }
    }
}
