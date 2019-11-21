<Query Kind="Expression">
  <Connection>
    <ID>48fffed4-a88f-4390-a6ee-3ca2e9d30f54</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from shipped in Shipments
where shipped.OrderID == 11078
select shipped