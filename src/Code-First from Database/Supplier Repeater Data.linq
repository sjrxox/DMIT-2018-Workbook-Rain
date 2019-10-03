<Query Kind="Program">
  <Connection>
    <ID>bedc7cd6-6eeb-4ad7-a376-36b40eacbb35</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
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
	result.Dump();
	
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
}

// Define other methods and classes here

public class SupplierSummary
{
	public string CompanyName {get; set;} 
	public string Contact {get; set;} 
	public string Phone {get; set;} 
	public IEnumerable<SupplierProduct> Products {get; set;} 
}

public class SupplierProduct
{ 
	public string Name {get; set;} 
	public string Category {get; set;} 
	public decimal Price {get; set;} 
	public string PerUnitQuantity {get; set;} 
}
