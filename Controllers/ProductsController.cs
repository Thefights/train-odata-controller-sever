using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using train_odata_controller_sever.Data;
using train_odata_controller_sever.Models;

namespace train_odata_controller_sever.Controllers
{
    public class ProductsController(ApplicationDbContext _dbContext) : ODataController
    {
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Products.Include(p => p.SubCategory).ThenInclude(sc => sc.Category).Include(p => p.Inventories));
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_dbContext.Products.Include(p => p.SubCategory).ThenInclude(sc => sc.Category).Include(p => p.Inventories).FirstOrDefault(p => p.Id == key));
        }
    }
}
