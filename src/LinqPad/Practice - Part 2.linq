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

// A) Group employees by region and show the results in this format:
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
 */

// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.

// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.

// F) List all the Suppliers, by Country


// A
from place in Regions
select new
{
	Region = place.RegionDescription,
	// Getting employees and removing duplicates
	Employees = (from area in place.Territories
				from manager in area.EmployeeTerritories
				select manager.Employee.FirstName + " " + manager.Employee.LastName).Distinct()
				
	Employee2 = from area in place.Territories
				from manager in area.EmployeeTerritories
				group manager by manager.Employee into areaManagers
				select areaManagers.Key.FirstName + " " + areaManagers.Key.LastName
}


// B
from company in Customers
select new
{
	CompanyName = company.CompanyName,
	Contact = new
				{
					Name = company.ContactName,
					Title = company.ContactTitle,
					Email = company.ContactEmail,
					Phone = company.Phone,
					Fax = company.Fax
				
				}

}

// C
from person in Employees
orderby person.LastName, person.FirstName
select new
{
	person.FirstName,
	person.LastName,
	OrderCount = person.SalesRepOrders.Count()
}

// E
from company in Customers
group company by company.Address.City into customersByCity
select new
{
	City = customersByCity.Key,
	Customers = from buyer in customersByCity
				select new
				{
					buyer.CompanyName,
					buyer.ContactName,
					buyer.ContactTitle,
					buyer.Phone
				}
}

// F
from vendor in Suppliers
group vendor by vendor.Address.Country into nationalSuppliers
select new 
{
	Country = nationalSuppliers.Key,
	Suppliers = from company in nationalSuppliers
				select company.CompanyName
}




