using AdventureWorksAPI.Data.Repositories.Interfaces;
using AdventureWorksAPI.Models;
using AdventureWorksAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace AdventureWorksAPI.Data.Repositories
{
    public class SalesOrderHeaderRepository : Repository<SalesOrderHeader>, ISalesOrderHeaderRepository
    {
        public SalesOrderHeaderRepository(ApplicationDbContext context) :
            base(context)
        {

        }

        public async Task<IList<SalesOrderHeader>> GetSales(bool? isOnlineSale, int? territoryId)
        {
            var sales = await _context.SalesOrderHeaders
                .Where(soh =>
                    (!isOnlineSale.HasValue || soh.OnlineOrderFlag == isOnlineSale.Value)
                    && (!territoryId.HasValue || soh.TerritoryId == territoryId.Value))
                .ToListAsync();

            return sales;
        }

        public async Task<IList<SalesGroupListItem>> GetSalesSummaryGroupByTerritory(int? limit)
        {
            var result = new List<SalesGroupListItem>();

            var query = _context.SalesOrderHeaders
                .Join(_context.SalesTerritories,
                        soh => soh.TerritoryId,
                        st => st.TerritoryId,
                        (soh, st) => new { soh, st })
                .GroupBy(x => new { x.st.Name, x.st.TerritoryId })
                .Select(g => new SalesGroupListItem
                {
                    Id = g.Key.TerritoryId,
                    Name = g.Key.Name,
                    SubTotal = g.Sum(x => x.soh.SubTotal),
                    TaxAmount = g.Sum(x => x.soh.TaxAmt),
                    Freight = g.Sum(x => x.soh.Freight),
                    TotalDue = g.Sum(x => x.soh.TotalDue)
                })
                .AsQueryable()
                .OrderByDescending(x => x.TotalDue);

            if (limit.HasValue)
            {
                result = await query.Take(limit.Value).ToListAsync();
            }
            else
            {
                result = await query.ToListAsync();
            }

            return result;
        }

        public async Task<IList<ProductGroupSalesListItem>> GetProductSalesForTerritory(int territoryId)
        {

            var query = _context.SalesOrderDetails
                .Join(_context.Products, sod => sod.ProductId, p => p.ProductId, (sod, p) => new { sod, p })
                .Join(_context.SalesOrderHeaders, sp => sp.sod.SalesOrderId, soh => soh.SalesOrderId, (sp, soh) => new { sp.sod, sp.p, soh })
                .Where(spsoh => spsoh.soh.TerritoryId == territoryId)
                .GroupBy(spsoh => new { spsoh.p.Name, spsoh.p.ProductNumber})
                .Select(g => new ProductGroupSalesListItem
                {
                    ProductName = g.Key.Name,
                    ProductNumber = g.Key.ProductNumber,
                    TotalSalesAmount = g.Sum(g => g.sod.LineTotal),
                    TotalQuantitySold = g.Sum(g => g.sod.OrderQty)
                })
                .AsQueryable()
                .OrderByDescending(x => x.TotalSalesAmount);


            return await query.ToListAsync(); ;
        }
    }
}
