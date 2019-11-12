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
	var output = ListShippers();
	output.Dump();
}



        public List<ShipperSelection> ListShipper()
        {
            // throw new NotImplementedException();
            // TODO: Get all the shippers from the Db
			var result = from shipper in Shippers
						orderby shipper.CompanyName
						select new ShipperSelection
						{
							ShipperId = shipper.ShipperID,
							Shipper = shipper.CompanyName
						};
			return result.ToList();
        }
		
	public class ShipperSelection
    {
        public int ShipperId { get; set; }
        public string Shipper { get; set; }
    }