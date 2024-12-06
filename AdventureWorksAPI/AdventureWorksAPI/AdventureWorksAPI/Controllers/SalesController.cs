using AdventureWorksAPI.Models.ViewModels;
using AdventureWorksAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IList<SalesListItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sales = await _salesService.GetAllSales();
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("summary")]
        [ProducesResponseType(typeof(SalesSummary), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSalesSummary([FromQuery] bool? onlineSales, int? territoryId)
        {
            try
            {
                var salesSummary = await _salesService.GetSalesSummary(onlineSales, territoryId);
                return Ok(salesSummary);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("group/territory")]
        [ProducesResponseType(typeof(IList<SalesGroupListItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGroupedSalesByTerritory([FromQuery] int? limit)
        {
            try
            {
                var groupedData = await _salesService.GetSalesSummaryGroupByTerritory(limit);
                return Ok(groupedData);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get Product Sales by Territory
        [HttpGet("group/territory/product/{territoryId}")]
        [ProducesResponseType(typeof(IList<ProductGroupSalesListItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductSalesByTerritory(int territoryId)
        {
            try
            {
                var groupedData = await _salesService.GetProductSalesForTerritory(territoryId);
                return Ok(groupedData); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
