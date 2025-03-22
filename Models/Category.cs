﻿namespace train_odata_controller_sever.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
