namespace AdventureWorksAPI.Models.Response
{
    public class GroupSalesListItemResponse
    {
        public string Name { get; set; } = string.Empty;
        public decimal SubTotal { get; set; }
        public decimal TaxAmount{ get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
    }
}
