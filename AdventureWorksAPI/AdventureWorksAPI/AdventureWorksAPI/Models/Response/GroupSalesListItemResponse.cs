namespace AdventureWorksAPI.Models.Response
{
    public class GroupProductSalesListItemResponse
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal TotalSalesAmount { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal Price { get; set; }
        public decimal TotalDiscounts { get; set; }
        public int TotalAmountSold { get; set; }
    }
}
