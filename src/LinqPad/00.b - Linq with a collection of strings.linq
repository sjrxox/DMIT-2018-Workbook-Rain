<Query Kind="Program" />

// To do:
/*

*/


void Main()
{
    Instructors.Dump();
	//  foreach(var person in Instructors)
	var best = from person in Instructors
	//             \string/   \string[]/
	           where person.StartsWith("D")
			   select person;
	best.Dump("The best instructors");
}

// Extension method (dump)
// Define other methods and classes here
public IEnumerable<string> Instructors
{
    get
	{
	    yield return "Dan";
	    yield return "Don";
	    yield return "Sam";
	    yield return "Jim";
	    yield return "Frank";
	    yield return "Steve";
	}
}