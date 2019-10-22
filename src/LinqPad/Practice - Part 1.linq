<Query Kind="Expression">
  <Connection>
    <ID>2c0d57aa-75fc-4d88-8ca7-43d1887df30e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.
/*

A) List all the customer company names for those with more than 5 orders.
B) Get a list of all the region names
C) Get a list of all the territory names
D) List all the regions and the number of territories in each region
E) List all the region and territory names in a "flat" list
F) List all the region and territory names as an "object graph"
   - use a nested query
G) List all the product names that contain the word "chef" in the name.
H) List all the discontinued products, specifying the product name and unit price.
I) List the company names of all Suppliers in North America (Canada, USA, Mexico)

*/
// A
from buyer in Customers
where buyer.Orders.Count() > 5
select buyer.CompanyName

// B
from place in Regions
select place.RegionDescription

// C
from place in Territories
select place.TerritoryDescription


// D
from place in Regions
select new
{
	Region = place.RegionDescription,
	TerritoryCount = place.Territories.Count()
}


// E
from place in Territories
select new
{
	Region = place.Region.RegionDescription,
	Territory = place.TerritoryDescription
}

// F
from place in Regions
select new
{
	Region = place.RegionDescription,
	Territories = from area in place.Territories
				select area.TerritoryDescription

}

// G
from item in Products
where item.ProductName.ToLower().Contains("chef")
select item.ProductName


// H
from item in Products
where item.Discontinued 
select new
{
	item.ProductName,
	item.UnitPrice
}


//I
from vendor in Suppliers
where  vendor.Address.Country == "Canada" 
	|| vendor.Address.Country == "USA" 
	|| vendor.Address.Country == "Mexico"
select vendor.CompanyName



