<Query Kind="Program">
  <Connection>
    <ID>d80180eb-5b50-4b2e-a89c-c54493944ec4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	int supplier = 39; // 3, 39
	var output = LoadOrders(supplier);
	output.Dump();
}

// Define other methods and classes here
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            //throw new NotImplementedException();
			var result = 
			from sale in Orders
			where !sale.Shipped
				&& sale.OrderDate.HasValue
			select new OutstandingOrder
			{
				OrderId = sale.OrderID,
				ShipToName = sale.ShipName,
				OrderDate = sale.OrderDate.Value,
				RequiredBy = sale.RequiredDate.Value,
				OutstandingItems = from item in sale.OrderDetails
									where item.Product.SupplierID == supplierId
									select new OrderItem
									{
										ProductID = item.ProductID,
										ProductName = item.Product.ProductName,
										Qty = item.Quantity,
										QtyPerUnit = item.Product.QuantityPerUnit,
										// crtl k + c = comments
										// TODO: Figure out the Outstanding Quantity
//										Outstanding = from ship in item.Order.Shipments
//														from shipItem in ship.ManifestItems
//														where shipItem.ProductD == item.ProductID
//														select shipItem.ShipQuantity
									},
				FullShippingAddress = // TODO: how to use sale.ShipAddressID,
				sale.Customer.Address.Address + Environment.NewLine +
				sale.Customer.Address.City + " , " +
				sale.Customer.Address.Region + Environment.NewLine + 
				sale.Customer.Address.Country + " " +
				sale.Customer.Address.PostalCode,
				Comments = sale.Comments
			};
			return result.ToList();
            // TODO: Implement this method with the following
            /*
             * Validation:
                    Make sure the supplier ID exixts, otherwise throw an exception
                    [Advanced] Make sure the logged-in user works for the identified supplier.
                Query for outstanding orders, getting data from the following tables:
                    TODO: List table names
             */
        }
		
	public class OutstandingOrder
    {
        public int OrderId { get; set; }
        public string ShipToName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredBy { get; set; }
        public int DaysRemaining { get; } // TODO: Calculated
        public IEnumerable<OrderItem> OutstandingItems { get; set; }
        public string FullShipppingAddress { get; set; }
        public string Comments { get; set; }
    }
	
	    public class OrderItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; } // TODO: Calculated as OD.Quantity - Sum(Shipped qty)
    }