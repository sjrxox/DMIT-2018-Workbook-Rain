<Query Kind="Expression">
  <Connection>
    <ID>bedc7cd6-6eeb-4ad7-a376-36b40eacbb35</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from vendor in Suppliers
select new
{
	CompanyName = vendor.CompanyName,
	Contact = vendor.ContactName,
	Phone = vendor.Phone,
	Products = from item in vendor.Products
				select new
				{
					Name = item.ProductName,
					Category = item.Category.CategoryName,
					Price = item.UnitPrice,
					PerUnitQuantity = item.QuantityPerUnit
				}
				
}

/*
Supplier:
	CompanyName
	Contact Name
	Phone Number
	Product Summary:
		Product Name
		Category Name
		Unit Price
		Quantity/Quality
*/