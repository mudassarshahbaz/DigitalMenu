using DigitalMenu.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DigitalMenu.Models.MenuDatabasesetting;

namespace DigitalMenu.Services
{
    public class MenuService
    {
        private readonly IMongoCollection<MenuItem> _menuItem;
        private readonly IMongoCollection<Category> _category;
        private readonly IMongoCollection<CustomerOrder> _order;
        public MenuService(IMenuDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _menuItem = database.GetCollection<MenuItem>(settings.MenuCollectionName);
            _category = database.GetCollection<Category>(settings.CatCollectionName);
            _order = database.GetCollection<CustomerOrder>(settings.OrderCollectionName);
        }

        // Get All Menu List
        public List<MenuItem> Get()
        {
            List<MenuItem> menuItems;
            menuItems = _menuItem.Find(emp => true).ToList();
            return menuItems;
        }

        // Get Menu List by Category ID
        public MenuItem Get(string id) =>
            _menuItem.Find<MenuItem>(emp => emp.FkCatId == id).FirstOrDefault();

        // Get Menu List by Name and Status is Active
        public MenuItem GetByName(string name) =>
            _menuItem.Find<MenuItem>(emp => emp.Name == name && emp.Status == "Active").FirstOrDefault();


        //For Category List
        public List<Category> GetCat()
        {
            List<Category> categories;
            categories = _category.Find(emp => true).ToList();
            return categories;
        }


        //For Customer Order List
        public List<CustomerOrder> GetOrder()
        {
            List<CustomerOrder> orders;
            orders = _order.Find(emp => true).ToList();
            return orders;
        }


        //Save the Customer Order
        public void saveOrder(CustomerOrder order)
        {
            _order.InsertOne(order);
        }


        //Update Menu Item Records
        public void updateMenu(string id, MenuItem mItem) =>        
            _menuItem.ReplaceOne(e => e.Id == id, mItem);
        


    }
}
