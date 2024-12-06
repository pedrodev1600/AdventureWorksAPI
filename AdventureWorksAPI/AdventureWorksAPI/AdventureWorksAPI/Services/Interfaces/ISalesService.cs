using AdventureWorksAPI.Models.ViewModels;

namespace AdventureWorksAPI.Services.Interfaces
{
    public interface ISalesService
    {
        Task<IList<SalesListItem>> GetAllSales();

        Task<SalesSummary> GetSalesSummary(bool? onlineSales, int? territoryId);

        Task<IList<SalesGroupListItem>> GetSalesSummaryGroupByTerritory(int? limit);

        Task<IList<ProductGroupSalesListItem>> GetProductSalesForTerritory(int territoryId);

    }
}
