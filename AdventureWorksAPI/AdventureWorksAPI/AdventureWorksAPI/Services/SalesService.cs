using AdventureWorksAPI.Data.Repositories.Interfaces;
using AdventureWorksAPI.Models.ViewModels;
using AdventureWorksAPI.Services.Interfaces;
using AutoMapper;

namespace AdventureWorksAPI.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesOrderHeaderRepository _salesOrderHeaderRepository;
        private readonly IMapper _mapper;

        public SalesService(ISalesOrderHeaderRepository salesOrderHeaderRepository, IMapper mapper)
        {
            _salesOrderHeaderRepository = salesOrderHeaderRepository;
            _mapper = mapper;
        }

        public async Task<IList<SalesListItem>> GetAllSales()
        {
            try
            {
                var sales = await _salesOrderHeaderRepository.GetAllAsync();
                return _mapper.Map<IList<SalesListItem>>(sales);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {nameof(GetAllSales)}: {ex.Message}");
                throw;
            }
        }

        public Task<IList<SalesGroupListItem>> GetSalesSummaryGroupByTerritory(int? limit)
        {
            try
            {
                var result = _salesOrderHeaderRepository.GetSalesSummaryGroupByTerritory(limit);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {nameof(GetSalesSummaryGroupByTerritory)}: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<ProductGroupSalesListItem>> GetProductSalesForTerritory(int territoryId)
        {
            try
            {
                var result = await _salesOrderHeaderRepository.GetProductSalesForTerritory(territoryId);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {nameof(GetProductSalesForTerritory)}: {ex.Message}");
                throw;
            }
        }

        public async Task<SalesSummary> GetSalesSummary(bool? onlineSales, int? territoryId)
        {
            try
            {
                var sales = await _salesOrderHeaderRepository.GetSales(onlineSales, territoryId);
                var salesCount = sales.Count;
                var salesTotalAmount = sales.Sum(soh => soh.TotalDue);
                var roundedSalesCount = (int)Math.Round((decimal)salesCount / 1000) * 1000;

                return new SalesSummary
                {
                    SalesCount = salesCount,
                    SalesTotalAmount = salesTotalAmount,
                    RoundedSalesCount = roundedSalesCount
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {nameof(GetSalesSummary)}: {ex.Message}");
                throw;
            }
        }
    }
}
