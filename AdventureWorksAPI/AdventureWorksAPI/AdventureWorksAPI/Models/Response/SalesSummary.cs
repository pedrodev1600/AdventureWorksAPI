using Microsoft.AspNetCore.Authorization;

namespace AdventureWorksAPI.Models.Response
{
    public class SalesSummary
    {
        public int SalesCount { get; set; }

        public decimal SalesTotalAmount { get; set; }

        public int RoundedSalesCount { get; set; }
    }
}
