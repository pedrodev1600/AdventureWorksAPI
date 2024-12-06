namespace AdventureWorksAPI.Models.ViewModels
{
    public class ProductListItem
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;          
        public string ProductNumber { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;            
        public string Size { get; set; } = string.Empty;             
        public decimal StandardCost { get; set; }    
        public decimal ListPrice { get; set; }       
        public string ProductCategory { get; set; } = string.Empty;
        public string ProductModel { get; set; } = string.Empty;
        public decimal? Weight { get; set; }         
        public int SafetyStockLevel { get; set; }    
        public int ReorderPoint { get; set; }       
        public DateTime? DiscontinuedDate { get; set; } 
        public DateTime SellStartDate { get; set; }  
        public DateTime? SellEndDate { get; set; }   
    }
}
