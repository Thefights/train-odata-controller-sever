﻿namespace train_odata_controller_sever.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
