using System.ComponentModel;
using System.Linq;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class SupplierManager
    {
        public void ListSupplierSummary()
        {
            using (var context = new WestWindContext()
            {
                    var result = from vendor in Suppliers
    select new SupplierSummary
    {
        CompanyName = vendor.CompanyName,
        Contact = vendor.ContactName,
        Phone = vendor.Phone,
        Products = from item in vendor.Products
                    select new SupplierProduct
                    {
                        Name = item.ProductName,
                        Category = item.Category.CategoryName,
                        Price = item.UnitPrice,
                        PerUnitQuantity = item.QuantityPerUnit
                    }

    };

        }
    }
}
}
