namespace AdventureWorksAPI.Models.ViewModels
{
    public class SalesGroupListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
    }
}
