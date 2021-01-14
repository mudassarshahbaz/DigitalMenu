using DigitalMenu.Models;
using DigitalMenu.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _MenuService;

        public MenuController(MenuService MenuService)
        {
            _MenuService = MenuService;
        }

        //Get All Menu Item List
        [HttpGet]
        public ActionResult<List<MenuItem>> Get() =>
            _MenuService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMenus")]
        public ActionResult<MenuItem> Get(string id)
        {
            var emp = _MenuService.Get(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        // Get Menu Item Records by Name
        [Route("[action]/{name}")]
        [HttpGet]
        public ActionResult<MenuItem> GetByName(string name)
        {
            var emp = _MenuService.GetByName(name);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        //Get All Category List
        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Category>> GetCat() =>
            _MenuService.GetCat();

        //Get Customer Orders List
        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<CustomerOrder>> GetOrder() =>
            _MenuService.GetOrder();


        // Place Order

        [HttpPost]
        [Route("PlaceOrder")]
        [Produces("application/json")]
        public ActionResult<string> PlaceOrder([FromBody] InputParameter input)
        {     

            var emp = _MenuService.GetByName(input.itemName);

            if (emp == null)
            {                
                return "Out of Stock / Sold";
            }
            else
            {
                //Check from database quantity must be greater than 0
                var checkQnty = emp.Quantity;

                if (input.quantity <= checkQnty)
                {
                    emp.Quantity = emp.Quantity - input.quantity;

                    string CustomerId = "5ffdc233e3762842b0d34eb0";  // current user ID
                    string loginUsername = "mudassarshahbaz";        // current username

                    CustomerOrder customerObj = new CustomerOrder();
                    customerObj.CustomerId = CustomerId;
                    customerObj.MenuId = emp.Id;
                    customerObj.OrdersStatus = "In-Process";
                    customerObj.Timestamp = DateTime.Now;
                    customerObj.CreatedBy = loginUsername;
                    _MenuService.saveOrder(customerObj);

                    // Menu Item Quantity and status Update
                    if (emp.Quantity <= 0)
                    {
                        emp.Status = "InActive";
                    }

                    _MenuService.updateMenu(emp.Id, emp);
                }
                else
                {
                    return "Required Food Quantity is not available, Please select within: " + checkQnty;
                    
                }
            }

            return "Order Placed Successfully";
        }

    }
}
