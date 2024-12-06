using AdventureWorksAPI.Data.Repositories.Interfaces;
using AdventureWorksAPI.Models.ViewModels;
using AdventureWorksAPI.Models;
using AdventureWorksAPI.Services.Interfaces;
using AutoMapper;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductItem> GetProductByNameAsync(string productName)
    {
        try
        {
            var product = await _productRepository.GetByNameAsync(productName);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productName} not found.");

            return _mapper.Map<ProductItem>(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in {nameof(GetProductByNameAsync)}: {ex.Message}");
            throw; 
        }
    }

    public async Task AddProductAsync(ProductItem productItem)
    {
        try
        {
            if (productItem == null)
                throw new ArgumentNullException(nameof(productItem), "Product cannot be null.");


            //this is another hack to get a product from the repo and just change the details in my add
            //form so I do not have to create the whole product screen 
            var products = await _productRepository.GetAllAsync();

            var productClone = products.FirstOrDefault();

            var newProduct = new Product
            {
                Name = productItem.Name,
                ProductNumber = productItem.ProductNumber,
                Size = productItem.Size,
                ListPrice = productItem.ListPrice,
                StandardCost = productItem.StandardCost,
                FinishedGoodsFlag = productItem.FinishedGoodsFlag,
                SafetyStockLevel = productItem.SafetyStockLevel,
                ReorderPoint = productItem.ReorderPoint,
                DaysToManufacture = productItem.DaysToManufacture,
                Color = productClone?.Color,
                Class = productClone?.Class,
                Style = productClone?.Style,
                SellStartDate = DateTime.Now,
            };

            await _productRepository.AddAsync(newProduct);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in {nameof(AddProductAsync)}: {ex.Message}");
            throw;
        }
    }

    public async Task UpdateProductAsync(ProductItem productItem)
    {
        try
        {
            if (productItem == null)
                throw new ArgumentNullException(nameof(productItem), "Product cannot be null.");

            var existingProduct = await _productRepository.GetByIdAsync(productItem.ProductId);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {productItem.ProductId} not found.");

            //this is hack as I did not have the time to create the whole 
            //product screen I just wanted to show and update in action
            //so I will just change the values I have added to the product view
            existingProduct.Name = productItem.Name;
            existingProduct.ProductNumber = productItem.ProductNumber;
            existingProduct.Size = productItem.Size;
            existingProduct.ListPrice = productItem.ListPrice;
            existingProduct.StandardCost = productItem.StandardCost;
            existingProduct.FinishedGoodsFlag = productItem.FinishedGoodsFlag;
            existingProduct.SafetyStockLevel =productItem.SafetyStockLevel;
            existingProduct.ReorderPoint = productItem.ReorderPoint;
            existingProduct.DaysToManufacture = productItem.DaysToManufacture;


            await _productRepository.UpdateAsync(existingProduct);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in {nameof(UpdateProductAsync)}: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteProductAsync(int productId)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            await _productRepository.DeleteProductAsync(productId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in {nameof(DeleteProductAsync)}: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync()
    {
        try
        {
            var products = await _productRepository.GetAllAsync();

            products = products.OrderBy(x => x.Name);
            return _mapper.Map<IList<ProductListItem>>(products);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in {nameof(GetAllProductsAsync)}: {ex.Message}");
            throw;
        }
    }
}
