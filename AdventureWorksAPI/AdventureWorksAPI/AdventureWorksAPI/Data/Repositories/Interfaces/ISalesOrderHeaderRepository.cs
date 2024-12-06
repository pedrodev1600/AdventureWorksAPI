using AdventureWorksAPI.Models;
using AdventureWorksAPI.Models.ViewModels;

namespace AdventureWorksAPI.Data.Repositories.Interfaces
{
    public interface ISalesOrderHeaderRepository : IRepository<SalesOrderHeader>
    {
        Task<IList<SalesOrderHeader>> GetSales(bool? isOnlineSale, int? territoryId);

        Task<IList<SalesGroupListItem>> GetSalesSummaryGroupByTerritory(int? limit);

        Task<IList<ProductGroupSalesListItem>> GetProductSalesForTerritory(int territoryId);
    }
}
