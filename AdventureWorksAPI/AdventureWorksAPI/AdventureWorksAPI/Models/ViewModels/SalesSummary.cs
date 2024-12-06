namespace AdventureWorksAPI.Models.ViewModels
{
    public class SalesSummary
    {
        public int SalesCount { get; set; }

        public decimal SalesTotalAmount { get; set; }

        public int RoundedSalesCount { get; set; }
    }
}
