namespace AdventureWorksAPI.Models.ViewModels
{    public class ProductGroupSalesListItem
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductNumber { get; set; } = string.Empty;
        public decimal TotalSalesAmount { get; set; }
        public int TotalQuantitySold { get; set; }
    }
}
