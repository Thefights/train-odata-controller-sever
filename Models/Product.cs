namespace train_odata_controller_sever.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } 
       public int SubcategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
